using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using NUnit.Framework;
using TvHelper.Controllers;
using TvHelper.Models;

namespace TvHelper.Test
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void VideoDirectoryShouldReturnVideosTest()
        {
            var controller = new HomeController();

            var result = controller.Video("C:\\Users\\dekstop\\RiderProjects\\TvHelper\\TvHelper.Test\\FileContainingMovies") as ViewResult;
            var resultLenght = (List<DownloadedTorrent>) result.Model;

            Assert.True(resultLenght.Count == 3);
        }

        [Test]
        public void VideoDirectoryShouldNotReturnVideosTest()
        {
            var controller = new HomeController();

            var result = controller.Video("C:\\Users\\dekstop\\RiderProjects\\TvHelper\\TvHelper.Test\\FileNotContainingMovies") as ViewResult;
            var resultLenght = (List<DownloadedTorrent>) result.Model;

            Assert.True(resultLenght.Count == 0);
        }

        [Test]
        public void VideoDirectoryInvalidDirReturnVideosTest()
        {
            var controller = new HomeController();

            Assert.Throws<DirectoryNotFoundException>(() => controller.Video("asd"));
        }
    }
}