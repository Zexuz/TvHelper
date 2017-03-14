﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TvHelper.Domain.Repositories;
using TvHelper.Domain.Servicies;

namespace TvHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly FileReaderService _fileReaderService;

        public HomeController()
        {
            _fileReaderService = new FileReaderService();
        }

        public ActionResult Index()
        {
            // The view being returned is calculated based on the name of the
            // controller (Home) and the name of the action method (Index).
            // So in this case, the view returned is /Views/Home/Index.cshtml.
            return View();
        }

        public ActionResult Video()
        {
//            // Creates a model and passes it on to the view.
//            var files = _fileReaderService.GetAllFilesAndDirectoriesInPath(dir);
//            var stringToTorrentParses = new StringToVideoParser();
//
//            var videos = files.Select(stringToTorrentParses.StringToDownloadedVideo).ToList();

            //todo check if mpc-hc prosess is running
            //if it is, we are watching a video. Then get the current video from the webinterface.
            //save that info in the db?c
            var videoRepository = new VideoRepository();

            var allVideosFromDb = videoRepository.GetAllVideo();
            return View(allVideosFromDb);
        }
    }
}