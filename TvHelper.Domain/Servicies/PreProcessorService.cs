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
            return allVideos.Where(video => !oldVideos.Contains(video)).ToList();
        }
    }
}