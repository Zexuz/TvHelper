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
            var torrent = new DownloadedTorrent
            {
                EpisodeNr = "01",
                SeasonNr = "01",
                Title = "Test series"
            };

            Assert.AreEqual("Test series S01E01",torrent.ToString());
        }

        [Test]
        public void TitleTest()
        {
            var torrent = new DownloadedTorrent
            {
                Title = "Test series"
            };

            Assert.AreEqual("Test series",torrent.Title);
        }

        [Test]
        public void SeasonTest()
        {
            var torrent = new DownloadedTorrent
            {
                SeasonNr= "01"
            };

            Assert.AreEqual("01",torrent.SeasonNr);
        }
        [Test]
        public void EpisodeTest()
        {
            var torrent = new DownloadedTorrent
            {
                EpisodeNr= "05"
            };

            Assert.AreEqual("05",torrent.EpisodeNr);
        }
    }
}