using NUnit.Framework;
using TvHelper.Servicies;

namespace TvHelper.Test
{
    [TestFixture]
    public class TorrentNamingServiceTest
    {
        [Test]
        public void NamingTest()
        {
            var name = "C:\\Users\\dekstop\\RiderProjects\\TvHelper\\TvHelper.Test\\FileContainingMovies\\test.name.of.series.S02E13.AAC.MP4-Mobile\\test.name.of.series.S02E13.AAC.MP4-Mobile.mp4";
            var namingService = new TorrentNamingService();

            var torrent = namingService.ConvertStringToDownloadedTorrent(name);
            Assert.AreEqual(torrent.EpisodeNr,"13");
            Assert.AreEqual(torrent.SeasonNr,"02");
            Assert.AreEqual(torrent.Title,"test name of series");
        }
    }
}