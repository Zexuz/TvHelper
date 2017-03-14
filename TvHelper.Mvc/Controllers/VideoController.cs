using System;
using System.Web.Mvc;
using TvHelper.Domain.Interfaces;
using TvHelper.Domain.Models;
using TvHelper.Domain.Parsers;

namespace TvHelper.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoRepository _repository;

        public VideoController(IVideoRepository repository)
        {
            _repository = repository;
        }


        [System.Web.Http.HttpGet]
        public ActionResult Open(string filePath)
        {
            var video = StringToVideoParser.StringToVideo(filePath);
            video.StartTime = DateTime.Now;
            _repository.UpdateVideoToActiveVideo(video);
            System.Diagnostics.Process.Start(filePath);
            return View();
        }
    }
}