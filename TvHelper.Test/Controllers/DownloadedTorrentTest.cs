using System;
using NUnit.Framework;
using TvHelper.Models;

namespace TvHelper.Test
{
    [TestFixture]
    public class DownloadedTorrentTest
    {
        [Test]
        public void ToStringTest()
        {
            var torrent = new Video
            {
                EpisodeNr = 1,
                SeasonNr = 1,
                Title = "Test series"
            };

            Assert.AreEqual("Test series S01E01",torrent.ToString());
        }

        [Test]
        public void TitleTest()
        {
            var torrent = new Video
            {
                Title = "Test series"
            };

            Assert.AreEqual("Test series",torrent.Title);
        }

        [Test]
        public void SeasonTest()
        {
            var torrent = new Video
            {
                SeasonNr= 1
            };

            Assert.AreEqual(1,torrent.SeasonNr);
        }
        [Test]
        public void EpisodeTest()
        {
            var torrent = new Video
            {
                EpisodeNr= 1
            };

            Assert.AreEqual(1,torrent.EpisodeNr);
        }
    }
}