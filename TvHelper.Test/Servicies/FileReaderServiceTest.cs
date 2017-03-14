using System.IO;
using NUnit.Framework;
using TvHelper.Domain.Servicies;

namespace TvHelper.Test.Servicies
{
    [TestFixture]
    public class FileReaderServiceTest
    {
        [Test]
        public void VideoDirectoryShouldReturnVideosTest()
        {
            var service = new FileReaderService();

            var result = service.GetAllFilesAndDirectoriesInPath(
                "C:\\Users\\dekstop\\RiderProjects\\TvHelper\\TvHelper.Test\\FileContainingMovies");

            Assert.True(result.Length == 3);
        }

        [Test]
        public void VideoDirectoryShouldNotReturnVideosTest()
        {
            var service = new FileReaderService();

            var result = service.GetAllFilesAndDirectoriesInPath(
                "C:\\Users\\dekstop\\RiderProjects\\TvHelper\\TvHelper.Test\\FileNotContainingMovies");

            Assert.True(result.Length == 0);
        }

        [Test]
        public void VideoDirectoryInvalidDirReturnVideosTest()
        {
            var service = new FileReaderService();

            Assert.Throws<DirectoryNotFoundException>(() => service.GetAllFilesAndDirectoriesInPath("asd"));
        }
    }
}