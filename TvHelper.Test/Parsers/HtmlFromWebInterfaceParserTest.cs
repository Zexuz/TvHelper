using NUnit.Framework;
using TvHelper.Parsers;
using TvHelper.Servicies;

namespace TvHelper.Test
{
    [TestFixture]
    public class HtmlFromWebInterfaceParserTest
    {


        [Test]
        public void ParseHtmlToActiveVideo()
        {

            #region HtmlResponse

            var htmlRes = "<body class=\"page-variables\">" +
                          "<!--[if lt IE 8]>" +
                          "<div class=\"browser-warning\"><strong>Warning!</strong> You are using an <strong>outdated</strong> browser." +
                          "Please <a href=\"http://browsehappy.com/\">upgrade your browser</a> to improve your experience.</div>" +
                          "<![endif]-->" +
                          "<p id=\"file\">Test.Series.S08E16.720p.HDTV.x264-AVS.mkv</p>" +
                          "<p id=\"filepatharg\">D:%5cDownloads%5cTest.Series.S08E16.720p.HDTV.x264-AVS%5cTest.Series.S08E16.720p.HDTV.x264-AVS.mkv</p>" +
                          "<p id=\"filepath\">D:\\Downloads\\Test.Series.S08E16.720p.HDTV.x264-AVS\\Test.Series.S08E16.720p.HDTV.x264-AVS.mkv</p>" +
                          "<p id=\"filedirarg\">D:%5cDownloads%5cTest.Series.S08E16.720p.HDTV.x264-AVS</p>" +
                          "<p id=\"filedir\">D:\\Downloads\\Test.Series.S08E16.720p.HDTV.x264-AVS</p>" +
                          "<p id=\"state\">2</p>" +
                          "<p id=\"statestring\">Playing</p>" +
                          "<p id=\"position\">730000/p>" +
                          "<p id=\"positionstring\">00:12:10</p>" +
                          "<p id=\"duration\">1282656</p>" +
                          "<p id=\"durationstring\">00:21:23</p>" +
                          "<p id=\"volumelevel\">100</p>" +
                          "<p id=\"muted\">0</p>" +
                          "<p id=\"playbackrate\">1</p>" +
                          "<p id=\"size\">623 MB</p>" +
                          "<p id=\"reloadtime\">0</p>" +
                          "<p id=\"version\">1.7.11.0</p>";
            #endregion

            var videoPlayerWebInterfaceServiceTest = new HtmlFromWebInterfaceParser(htmlRes);
            var activeVideo = videoPlayerWebInterfaceServiceTest.GetActiveVideo();

            Assert.AreEqual(true,activeVideo.IsPlaying);
            Assert.AreEqual(21,activeVideo.Duration.Minutes);
            Assert.AreEqual(22,activeVideo.Duration.Seconds);
            Assert.AreEqual(12,activeVideo.CurrentPosition.Minutes);
            Assert.AreEqual(10,activeVideo.CurrentPosition.Seconds);
            Assert.AreEqual("16",activeVideo.EpisodeNr);
            Assert.AreEqual("08",activeVideo.SeasonNr);
            Assert.AreEqual("Test Series",activeVideo.Title);
        }




    }
}