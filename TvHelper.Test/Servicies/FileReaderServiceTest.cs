using System.IO;
using NUnit.Framework;
using TvHelper.Domain.Servicies;

namespace TvHelper.Test.Servicies
{
    [TestFixture]
    public class FileReaderServiceTest
    {
        [Test]
        public void VideoDirectoryShouldReturnAllFilesTest()
        {
            var service = new FileReaderService();

            var result = service.GetAllFilesAndDirectoriesInPath(
                "C:\\Users\\dekstop\\RiderProjects\\TvHelper\\TvHelper.Test\\FileContainingMovies");

            Assert.True(result.Count == 18);
        }

        [Test]
        public void VideoDirectoryShouldReturnOnlyMovies()
        {
            var service = new FileReaderService();

            var result = service.GetOnlyVideosInPath(
                "C:\\Users\\dekstop\\RiderProjects\\TvHelper\\TvHelper.Test\\FileContainingMovies");

            Assert.True(result.Count == 3);
        }

        [Test]
        public void VideoDirectoryShouldReturnNothingTest()
        {
            var service = new FileReaderService();

            var result = service.GetAllFilesAndDirectoriesInPath(
                "C:\\Users\\dekstop\\RiderProjects\\TvHelper\\TvHelper.Test\\FileNotContainingMovies");

            Assert.True(result.Count == 0);
        }

        [Test]
        public void VideoDirectoryInvalidDirReturnVideosTest()
        {
            var service = new FileReaderService();

            Assert.Throws<DirectoryNotFoundException>(() => service.GetAllFilesAndDirectoriesInPath("asd"));
        }
    }
}