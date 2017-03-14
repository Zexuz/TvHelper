using System.Collections.Generic;

namespace TvHelper.Domain.Interfaces
{
    public interface IFileReaderService
    {
        List<string> GetAllFilesAndDirectoriesInPath(string path);
    }
}