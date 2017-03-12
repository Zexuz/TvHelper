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
            return filesAndDirs;
        }



    }
}