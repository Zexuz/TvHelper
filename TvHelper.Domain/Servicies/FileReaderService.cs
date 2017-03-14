using System.Collections.Generic;
using System.IO;
using System.Linq;
using TvHelper.Domain.Interfaces;
using TvHelper.Domain.Models;
using TvHelper.Domain.Parsers;
using Directory = System.IO.Directory;

namespace TvHelper.Domain.Servicies
{
    public class FileReaderService : IFileReaderService
    {
        public List<Video> GetOnlyVideosInPath(string path)
        {
            var allFiles = GetAllFilesAndDirectoriesInPath(path);
            var movieStringsOnly = GetOnlyVideoFiles(allFiles);


            var moviesOnly = movieStringsOnly.Select(StringToVideoParser.StringToVideo).ToList();
            return moviesOnly;
        }

        public List<string> GetAllFilesAndDirectoriesInPath(string path)
        {
            var filesAndDirs = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            return filesAndDirs.ToList();
        }

        private List<string> GetOnlyVideoFiles(IEnumerable<string> allFiles)
        {
            var extensions = new List<string> {".mkv", ".mp4"};
            return allFiles.Where(file => extensions.Contains(Path.GetExtension(file))).ToList();
        }
    }
}