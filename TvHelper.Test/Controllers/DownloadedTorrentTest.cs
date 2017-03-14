using NUnit.Framework;
using TvHelper.Domain.Models;
using TvHelper.Domain.Servicies;

namespace TvHelper.Test.Controllers
{
    [TestFixture]
    public class DownloadedTorrentTest
    {
        [Test]
        public void ToStringTestS01E01()
        {
            var vidoe = new Video
            {
                EpisodeNr = 1,
                SeasonNr = 1,
                Title = "Test series"
            };

            var videoToStringService = new VideoToStringService();
            var videoString = videoToStringService.ToSortString(vidoe);

            Assert.AreEqual("Test series S01E01", videoString);
        }

        [Test]
        public void ToStringTestS01E10()
        {
            var vidoe = new Video
            {
                EpisodeNr = 10,
                SeasonNr = 1,
                Title = "Test series"
            };

            var videoToStringService = new VideoToStringService();
            var videoString = videoToStringService.ToSortString(vidoe);

            Assert.AreEqual("Test series S01E10", videoString);
        }

        [Test]
        public void ToStringTestS10E10()
        {
            var vidoe = new Video
            {
                EpisodeNr = 10,
                SeasonNr = 10,
                Title = "Test series"
            };

            var videoToStringService = new VideoToStringService();
            var videoString = videoToStringService.ToSortString(vidoe);

            Assert.AreEqual("Test series S10E10", videoString);
        }


        [Test]
        public void ToStringTestS10E1()
        {
            var vidoe = new Video
            {
                EpisodeNr = 1,
                SeasonNr = 10,
                Title = "Test series"
            };

            var videoToStringService = new VideoToStringService();
            var videoString = videoToStringService.ToSortString(vidoe);

            Assert.AreEqual("Test series S10E01", videoString);
        }

        [Test]
        public void TitleTest()
        {
            var torrent = new Video
            {
                Title = "Test series"
            };

            Assert.AreEqual("Test series", torrent.Title);
        }

        [Test]
        public void SeasonTest()
        {
            var torrent = new Video
            {
                SeasonNr = 1
            };

            Assert.AreEqual(1, torrent.SeasonNr);
        }

        [Test]
        public void EpisodeTest()
        {
            var torrent = new Video
            {
                EpisodeNr = 1
            };

            Assert.AreEqual(1, torrent.EpisodeNr);
        }
    }
}