using System.Collections.Generic;
using System.IO;
using System.Linq;
using Directory = System.IO.Directory;

namespace TvHelper.Servicies
{
    public class FileReaderService
    {

        public string[]GetAllFilesAndDirectoriesInPath(string path)
        {
            var filesAndDirs = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            var moviesOnly = GetOnlyVideoFiles(filesAndDirs);
            return moviesOnly;
        }

        private string[] GetOnlyVideoFiles(IEnumerable<string> allFiles)
        {
            var extensions = new List<string>{".mkv",".mp4"};
            return allFiles.Where(file => extensions.Contains(Path.GetExtension(file))).ToArray();
        }



    }
}