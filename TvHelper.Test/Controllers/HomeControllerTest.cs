using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using TvHelper.Controllers;
using TvHelper.Domain.Models;

namespace TvHelper.Test.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void VideoDirectoryShouldReturnVideosTest()
        {
            var controller = new HomeController();

            var result = controller.Video() as ViewResult;
            var resultLenght = (List<Video>) result.Model;

            Assert.True(resultLenght.Count == 11);
        }
    }
}