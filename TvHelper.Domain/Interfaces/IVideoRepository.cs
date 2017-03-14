using System.Collections.Generic;
using TvHelper.Domain.Models;

namespace TvHelper.Domain.Interfaces
{
    public interface IVideoRepository
    {
        List<Video> GetAllVideosFromDatabase();
        void InsertVideos(List<Video> newVideos);
    }
}