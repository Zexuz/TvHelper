using System.Collections.Generic;
using NUnit.Framework;
using TvHelper.Domain.Models;
using TvHelper.Domain.Servicies;

namespace TvHelper.Test.Servicies
{
    [TestFixture]
    public class PreProcessorServiceTest
    {
        [Test]
        public void SimpleTest()
        {
            var allVideos = new List<Video>
            {
                new Video
                {
                    Title = "Some Random Video",
                    EpisodeNr = 17,
                    SeasonNr = 01
                },
                new Video
                {
                    Title = "Another Random Video",
                    EpisodeNr = 15,
                    SeasonNr = 03
                },
                new Video
                {
                    Title = "Last Random Video",
                    EpisodeNr = 05,
                    SeasonNr = 01
                }
            };

            var oldVideo = new List<Video>
            {
                new Video
                {
                    Title = "Last Random Video",
                    EpisodeNr = 05,
                    SeasonNr = 01
                }
            };

            var preProcessorService = new PreProcessorService();

            var newFiles = preProcessorService.GetNewVidosFromAllVideos(allVideos, oldVideo);

            Assert.AreEqual(newFiles.Count, 3);
            Assert.AreEqual(newFiles[0],allVideos[0]);
            Assert.AreEqual(newFiles[1],allVideos[1]);
        }
    }
}