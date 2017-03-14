using System.Collections.Generic;
using TvHelper.Domain.Models;

namespace TvHelper.Domain.Interfaces
{
    public interface IPreProcessorService
    {

        List<Video> GetNewVidosFromAllVideos(List<Video> allVideos, List<Video> oldVideos);
    }
}