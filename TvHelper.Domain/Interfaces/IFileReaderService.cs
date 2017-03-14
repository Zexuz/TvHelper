using System.Collections.Generic;
using TvHelper.Domain.Models;

namespace TvHelper.Domain.Interfaces
{
    public interface IFileReaderService
    {
        List<Video> GetOnlyVideosInPath(string path);
        List<string> GetAllFilesAndDirectoriesInPath(string path);
    }
}