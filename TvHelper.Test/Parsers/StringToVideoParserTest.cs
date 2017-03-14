using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using TvHelper.Domain.Parsers;

namespace TvHelper.Test.Parsers
{
    [TestFixture]
    public class TorrentNamingServiceTest
    {
        [Test]
        public void NamingTestNormal()
        {
            var name =
                "C:\\Users\\dekstop\\RiderProjects\\TvHelper\\TvHelper.Test\\FileContainingMovies\\test.name.of.series.S02E13.AAC.MP4-Mobile\\test.name.of.series.S02E13.AAC.MP4-Mobile.mp4";

            var torrent = StringToVideoParser.StringToVideo(name);
            Assert.AreEqual(13,torrent.EpisodeNr);
            Assert.AreEqual(2,torrent.SeasonNr);
            Assert.AreEqual("test name of series",torrent.Title);
        }

        [Test]
        public void NamingTestSample()
        {
            var name =
                "D:\\Downloads\\TorrentDay\\The.Last.Man.On.Earth.S03E11.720p.HDTV.x264-AVS\\Sample\\sample-the.last.man.on.earth.s03e11.720p.hdtv.x264-avs.mkv";

            var torrent = StringToVideoParser.StringToVideo(name);
            Assert.AreEqual(11,torrent.EpisodeNr);
            Assert.AreEqual(3,torrent.SeasonNr);
            Assert.AreEqual("The Last Man On Earth",torrent.Title);
        }
    }
}