using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FakeItEasy;
using NUnit.Framework;
using TvHelper.Controllers;
using TvHelper.Domain.Interfaces;
using TvHelper.Domain.Models;

namespace TvHelper.Test.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void VideoDirectoryShouldReturnVideosTest()
        {
            var fakeDb = A.Fake<IVideoRepository>();
            var fakeList = A.CollectionOfFake<Video>(11);;

            A.CallTo(() => fakeDb.GetAllVideosFromDatabase()).Returns(fakeList.ToList());

            var controller = new HomeController(fakeDb);

            var result = controller.Video() as ViewResult;
            var resultLenght = (List<Video>) result.Model;

            Assert.True(resultLenght.Count == 11);
        }
    }
}