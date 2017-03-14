using System.Collections.Generic;
using System.Linq;
using TvHelper.Domain.Interfaces;
using TvHelper.Domain.Models;

namespace TvHelper.Domain.Servicies
{
    public class PreProcessorService : IPreProcessorService
    {

        public List<Video> GetNewVidosFromAllVideos(List<Video> allVideos, List<Video> oldVideos)
        {
            var newList = new List<Video>();

            foreach (var video in allVideos)
            {
                if(oldVideos.Any(oldVid => oldVid.Path.Equals(video.Path))) continue;
                newList.Add(video);
            }

            return newList;
        }
    }
}