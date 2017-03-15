using FakeItEasy;
using HtmlAgilityPack;
using NUnit.Framework;
using TvHelper.Domain.Servicies;

namespace TvHelper.Test.Servicies
{
    [TestFixture]
    public class WebScraperTorrentDayServiceTest
    {

        [Test]
        public void FindTorrentsByNameTest()
        {
            var doc = new HtmlDocument();
            var webScraperService = new WebScraperTorrentDayService();

            #region html

            doc.LoadHtml(@"<table id=""torrentTable""><tbody><tr>
                    <th>Type</th>
                    <th title=""Name""><a href=""?search=Some Random Serie&amp;cata=yes&amp;sort=1&amp;type=asc#torrentTableWrapper"">Name</a></th>
                    <th align=""center"" colspan=""1""><img src=""/images/browse/download.png"" alt=""Download as .torrent file"" title=""Download as .torrent file"" border=""0""></th>
                    <th title=""Comment(s)"" align=""right""><a href=""?search=Some Random Serie&amp;cata=yes&amp;sort=3&amp;type=desc#torrentTableWrapper""><img src=""/images/browse/comments.png"" alt=""Comments"" border=""0""></a></th>
                    <th title=""Size"" align=""center""><a href=""?search=Some Random Serie&amp;cata=yes&amp;sort=5&amp;type=desc#torrentTableWrapper"">Size</a></th>
                    <th title=""Seeder(s)"" align=""right""><a href=""?search=Some Random Serie&amp;cata=yes&amp;sort=7&amp;type=desc#torrentTableWrapper""><img src=""/images/browse/seeders.png"" alt=""Seeders"" border=""0""></a></th>
                    <th title=""Leecher(s)"" align=""right""><a href=""?search=Some Random Serie&amp;cata=yes&amp;sort=8&amp;type=desc#torrentTableWrapper""><img src=""/images/browse/leechers.png"" alt=""Leechers"" border=""0""></a></th>

                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=24#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-480p.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286589""><b>Some Random Serie 2014 S03E16 480p x264-mSD</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 480p | 14 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286589/Some.Random.Serie.2014.S03E16.480p.x264-mSD.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286589#startcomments"">3</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286589&amp;filelist=1#filelist"">182 MB</a></td>
                    <td class=""ac seedersInfo"">251</td>
                    <td class=""ac leechersInfo"">9</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=2#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-xvid.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286503""><b>Some Random Serie 2014 S03E16 HDTV XviD-FUM</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 15 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286503/Some.Random.Serie.2014.S03E16.HDTV.XviD-FUM.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286503#startcomments"">1</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286503&amp;filelist=1#filelist"">349 MB</a></td>
                    <td class=""ac seedersInfo"">318</td>
                    <td class=""ac leechersInfo"">8</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286430""><b>Some Random Serie 2014 S03E16 720p HEVC x265-MeGusta</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 16 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286430/Some.Random.Serie.2014.S03E16.720p.HEVC.x265-MeGusta.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286430#startcomments"">2</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286430&amp;filelist=1#filelist"">234 MB</a></td>
                    <td class=""ac seedersInfo"">285</td>
                    <td class=""ac leechersInfo"">18</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286422""><b>Some Random Serie 2014 S03E16 1080p HDTV X264-DIMENSION</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 16 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286422/Some.Random.Serie.2014.S03E16.1080p.HDTV.X264-DIMENSION.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286422#startcomments"">1</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286422&amp;filelist=1#filelist"">2.15 GB</a></td>
                    <td class=""ac seedersInfo"">315</td>
                    <td class=""ac leechersInfo"">14</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=46#torrentTableWrapper""><img border=""0"" src=""https://lookpic.com/O/i2/334/H8JFMu2k.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286421""><b>Some Random Serie 2014 S03E16 AAC MP4-Mobile</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 16 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286421/Some.Random.Serie.2014.S03E16.AAC.MP4-Mobile.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286421#startcomments"">3</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286421&amp;filelist=1#filelist"">159 MB</a></td>
                    <td class=""ac seedersInfo"">127</td>
                    <td class=""ac leechersInfo"">4</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=2#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-xvid.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286413""><b>Some Random Serie 2014 S03E16 XviD-AFG</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 17 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286413/Some.Random.Serie.2014.S03E16.XviD-AFG.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286413#startcomments"">5</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286413&amp;filelist=1#filelist"">354 MB</a></td>
                    <td class=""ac seedersInfo"">810</td>
                    <td class=""ac leechersInfo"">13</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=26#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-sd-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286402""><b>Some Random Serie 2014 S03E16 HDTV x264-LOL</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 17 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286402/Some.Random.Serie.2014.S03E16.HDTV.x264-LOL.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286402#startcomments"">4</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286402&amp;filelist=1#filelist"">217 MB</a></td>
                    <td class=""ac seedersInfo"">535</td>
                    <td class=""ac leechersInfo"">10</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286401""><b>Some Random Serie 2014 S03E16 720p HDTV X264-DIMENSION</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 17 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286401/Some.Random.Serie.2014.S03E16.720p.HDTV.X264-DIMENSION.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286401#startcomments"">3</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286401&amp;filelist=1#filelist"">715 MB</a></td>
                    <td class=""ac seedersInfo"">1,575</td>
                    <td class=""ac leechersInfo"">76</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2272262""><b>Some Random Serie S03E15 1080p WEB-DL DD5 1 H264-LiGaS</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2272262/Some.Random.Serie.S03E15.1080p.WEB-DL.DD5.1.H264-LiGaS.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2272262&amp;filelist=1#filelist"">1.65 GB</a></td>
                    <td class=""ac seedersInfo"">58</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2272261""><b>Some Random Serie S03E15 720p WEB-DL DD5 1 H264-LiGaS</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2272261/Some.Random.Serie.S03E15.720p.WEB-DL.DD5.1.H264-LiGaS.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2272261&amp;filelist=1#filelist"">1.32 GB</a></td>
                    <td class=""ac seedersInfo"">58</td>
                    <td class=""ac leechersInfo"">3</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2272149""><b>Some Random Serie 2014 S03E15 1080p WEB-DL DD5 1 H 264-DRACULA</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2272149/Some.Random.Serie.2014.S03E15.1080p.WEB-DL.DD5.1.H.264-DRACULA.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2272149#startcomments"">2</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2272149&amp;filelist=1#filelist"">1.65 GB</a></td>
                    <td class=""ac seedersInfo"">0</td>
                    <td class=""ac leechersInfo"">11</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2272147""><b>Some Random Serie 2014 S03E15 720p WEB-DL DD5 1 H 264-DRACULA</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2272147/Some.Random.Serie.2014.S03E15.720p.WEB-DL.DD5.1.H.264-DRACULA.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2272147&amp;filelist=1#filelist"">1.32 GB</a></td>
                    <td class=""ac seedersInfo"">26</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2271371""><b>Some Random Serie 2014 S03E15 1080p HDTV HEVC x265-RMTeam</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2271371/Some%20Random%20Series%202014%20S03E15%201080p%20HDTV%20HEVC%20x265-RMTeam.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2271371&amp;filelist=1#filelist"">494 MB</a></td>
                    <td class=""ac seedersInfo"">48</td>
                    <td class=""ac leechersInfo"">2</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2271010""><b>Some Random Serie 2014 S03E15 1080p HEVC x265-MeGusta</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2271010/Some.Random.Serie.2014.S03E15.1080p.HEVC.x265-MeGusta.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2271010&amp;filelist=1#filelist"">534 MB</a></td>
                    <td class=""ac seedersInfo"">67</td>
                    <td class=""ac leechersInfo"">2</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270895""><b>Some Random Serie 2014 S03E15 1080p HDTV X264-DIMENSION</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270895/Some.Random.Serie.2014.S03E15.1080p.HDTV.X264-DIMENSION.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270895&amp;filelist=1#filelist"">2.15 GB</a></td>
                    <td class=""ac seedersInfo"">155</td>
                    <td class=""ac leechersInfo"">5</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=2#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-xvid.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270826""><b>Some Random Serie 2014 S03E15 HDTV XviD-FUM</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270826/Some.Random.Serie.2014.S03E15.HDTV.XviD-FUM.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2270826#startcomments"">5</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270826&amp;filelist=1#filelist"">349 MB</a></td>
                    <td class=""ac seedersInfo"">269</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270713""><b>Some Random Serie 2014 S03E15 720p HEVC x265-MeGusta</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270713/Some.Random.Serie.2014.S03E15.720p.HEVC.x265-MeGusta.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2270713#startcomments"">4</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270713&amp;filelist=1#filelist"">270 MB</a></td>
                    <td class=""ac seedersInfo"">193</td>
                    <td class=""ac leechersInfo"">5</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=46#torrentTableWrapper""><img border=""0"" src=""https://lookpic.com/O/i2/334/H8JFMu2k.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270712""><b>Some Random Serie 2014 S03E15 AAC MP4-Mobile</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270712/Some.Random.Serie.2014.S03E15.AAC.MP4-Mobile.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2270712#startcomments"">4</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270712&amp;filelist=1#filelist"">172 MB</a></td>
                    <td class=""ac seedersInfo"">114</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=2#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-xvid.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270707""><b>Some Random Serie 2014 S03E15 XviD-AFG</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270707/Some.Random.Serie.2014.S03E15.XviD-AFG.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2270707#startcomments"">6</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270707&amp;filelist=1#filelist"">393 MB</a></td>
                    <td class=""ac seedersInfo"">587</td>
                    <td class=""ac leechersInfo"">2</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270680""><b>Some Random Serie 2014 S03E15 720p HDTV X264-DIMENSION</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270680/Some.Random.Serie.2014.S03E15.720p.HDTV.X264-DIMENSION.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2270680#startcomments"">4</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270680&amp;filelist=1#filelist"">743 MB</a></td>
                    <td class=""ac seedersInfo"">1,221</td>
                    <td class=""ac leechersInfo"">29</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=26#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-sd-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270674""><b>Some Random Serie 2014 S03E15 HDTV x264-LOL</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270674/Some.Random.Serie.2014.S03E15.HDTV.x264-LOL.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2270674#startcomments"">4</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270674&amp;filelist=1#filelist"">263 MB</a></td>
                    <td class=""ac seedersInfo"">391</td>
                    <td class=""ac leechersInfo"">1</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2267970""><b>Some Random Serie 2014 S03E14 WEB-DL 1080p 10bit 5 1 x265 HEVC-Qman</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 1 week 1 day ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2267970/Some.Random.Serie.2014.S03E14.WEB-DL.1080p.10bit.5.1.x265.HEVC-Qman.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2267970&amp;filelist=1#filelist"">797 MB</a></td>
                    <td class=""ac seedersInfo"">25</td>
                    <td class=""ac leechersInfo"">1</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2258852""><b>Some Random Serie 2014 S03E14 1080p HEVC x265-MeGusta</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 1 week 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2258852/Some.Random.Serie.2014.S03E14.1080p.HEVC.x265-MeGusta.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2258852&amp;filelist=1#filelist"">558 MB</a></td>
                    <td class=""ac seedersInfo"">35</td>
                    <td class=""ac leechersInfo"">1</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2256729""><b>Some Random Serie 2014 S03E14 720p WEB-DL DD5 1 H 264-DRACULA</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 1 week 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2256729/Some.Random.Serie.2014.S03E14.720p.WEB-DL.DD5.1.H.264-DRACULA.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2256729&amp;filelist=1#filelist"">1.31 GB</a></td>
                    <td class=""ac seedersInfo"">42</td>
                    <td class=""ac leechersInfo"">2</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2256719""><b>Some Random Serie 2014 S03E14 1080p WEB-DL DD5 1 H 264-DRACULA</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 1 week 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2256719/Some.Random.Serie.2014.S03E14.1080p.WEB-DL.DD5.1.H.264-DRACULA.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2256719&amp;filelist=1#filelist"">1.65 GB</a></td>
                    <td class=""ac seedersInfo"">54</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=2#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-xvid.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255554""><b>Some Random Serie 2014 S03E14 HDTV XviD-FUM</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255554/Some.Random.Serie.2014.S03E14.HDTV.XviD-FUM.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255554#startcomments"">2</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255554&amp;filelist=1#filelist"">349 MB</a></td>
                    <td class=""ac seedersInfo"">175</td>
                    <td class=""ac leechersInfo"">11</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255553""><b>Some Random Serie 2014 S03E14 1080p HDTV X264-DIMENSION</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255553/Some.Random.Serie.2014.S03E14.1080p.HDTV.X264-DIMENSION.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255553&amp;filelist=1#filelist"">2.23 GB</a></td>
                    <td class=""ac seedersInfo"">131</td>
                    <td class=""ac leechersInfo"">4</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=46#torrentTableWrapper""><img border=""0"" src=""https://lookpic.com/O/i2/334/H8JFMu2k.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255537""><b>Some Random Serie 2014 S03E14 AAC MP4-Mobile</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255537/Some.Random.Serie.2014.S03E14.AAC.MP4-Mobile.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255537#startcomments"">2</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255537&amp;filelist=1#filelist"">176 MB</a></td>
                    <td class=""ac seedersInfo"">49</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=24#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-480p.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255533""><b>Some Random Serie 2014 S03E14 480p x264-mSD</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 480p | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255533/Some.Random.Serie.2014.S03E14.480p.x264-mSD.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255533#startcomments"">3</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255533&amp;filelist=1#filelist"">202 MB</a></td>
                    <td class=""ac seedersInfo"">185</td>
                    <td class=""ac leechersInfo"">1</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255449""><b>Some Random Serie 2014 S03E14 720p HEVC x265-MeGusta</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255449/Some.Random.Serie.2014.S03E14.720p.HEVC.x265-MeGusta.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255449#startcomments"">2</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255449&amp;filelist=1#filelist"">280 MB</a></td>
                    <td class=""ac seedersInfo"">146</td>
                    <td class=""ac leechersInfo"">2</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=2#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-xvid.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255435""><b>Some Random Serie 2014 S03E14 XviD-AFG</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255435/Some.Random.Serie.2014.S03E14.XviD-AFG.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255435#startcomments"">12</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255435&amp;filelist=1#filelist"">416 MB</a></td>
                    <td class=""ac seedersInfo"">538</td>
                    <td class=""ac leechersInfo"">2</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=26#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-sd-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255426""><b>Some Random Serie 2014 S03E14 HDTV x264-LOL</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255426/Some.Random.Serie.2014.S03E14.HDTV.x264-LOL.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255426#startcomments"">6</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255426&amp;filelist=1#filelist"">268 MB</a></td>
                    <td class=""ac seedersInfo"">248</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255412""><b>Some Random Serie 2014 S03E14 720p HDTV X264-DIMENSION</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255412/Some.Random.Serie.2014.S03E14.720p.HDTV.X264-DIMENSION.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255412#startcomments"">9</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255412&amp;filelist=1#filelist"">755 MB</a></td>
                    <td class=""ac seedersInfo"">958</td>
                    <td class=""ac leechersInfo"">27</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2252185""><b>Some Random Serie 2014 S03E13 WEB-DL 1080p 10bit 5 1 x265 HEVC-Qman</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 2 weeks 1 day ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2252185/Some.Random.Serie.2014.S03E13.WEB-DL.1080p.10bit.5.1.x265.HEVC-Qman.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2252185&amp;filelist=1#filelist"">914 MB</a></td>
                    <td class=""ac seedersInfo"">12</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2250261""><b>Some Random Serie 2014 S03E13 1080p HEVC x265-MeGusta</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 2 weeks 3 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2250261/Some.Random.Serie.2014.S03E13.1080p.HEVC.x265-MeGusta.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2250261&amp;filelist=1#filelist"">606 MB</a></td>
                    <td class=""ac seedersInfo"">26</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    </tbody></table>");

            #endregion

            var res = webScraperService.FindTorrentsByName("Some Random Serie", doc, "www.torrentday.com/");

            Assert.AreEqual(35,res.Count);
            Assert.AreEqual("Some Random Serie 2014", res[0].Title);

        }

        [Test]
        public void FindTorrentsByNameFailTest()
        {
            var doc = new HtmlDocument();
            var webScraperService = new WebScraperTorrentDayService();

            #region html

            doc.LoadHtml(@"<table id=""torrentTable""><tbody><tr>
                    <th>Type</th>
                    <th title=""Name""><a href=""?search=Some Random Serie&amp;cata=yes&amp;sort=1&amp;type=asc#torrentTableWrapper"">Name</a></th>
                    <th align=""center"" colspan=""1""><img src=""/images/browse/download.png"" alt=""Download as .torrent file"" title=""Download as .torrent file"" border=""0""></th>
                    <th title=""Comment(s)"" align=""right""><a href=""?search=Some Random Serie&amp;cata=yes&amp;sort=3&amp;type=desc#torrentTableWrapper""><img src=""/images/browse/comments.png"" alt=""Comments"" border=""0""></a></th>
                    <th title=""Size"" align=""center""><a href=""?search=Some Random Serie&amp;cata=yes&amp;sort=5&amp;type=desc#torrentTableWrapper"">Size</a></th>
                    <th title=""Seeder(s)"" align=""right""><a href=""?search=Some Random Serie&amp;cata=yes&amp;sort=7&amp;type=desc#torrentTableWrapper""><img src=""/images/browse/seeders.png"" alt=""Seeders"" border=""0""></a></th>
                    <th title=""Leecher(s)"" align=""right""><a href=""?search=Some Random Serie&amp;cata=yes&amp;sort=8&amp;type=desc#torrentTableWrapper""><img src=""/images/browse/leechers.png"" alt=""Leechers"" border=""0""></a></th>

                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=24#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-480p.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286589""><b>Some Random Serie 2014 S03E16 480p x264-mSD</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 480p | 14 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286589/Some.Random.Serie.2014.S03E16.480p.x264-mSD.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286589#startcomments"">3</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286589&amp;filelist=1#filelist"">182 MB</a></td>
                    <td class=""ac seedersInfo"">251</td>
                    <td class=""ac leechersInfo"">9</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=2#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-xvid.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286503""><b>Some Random Serie 2014 S03E16 HDTV XviD-FUM</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 15 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286503/Some.Random.Serie.2014.S03E16.HDTV.XviD-FUM.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286503#startcomments"">1</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286503&amp;filelist=1#filelist"">349 MB</a></td>
                    <td class=""ac seedersInfo"">318</td>
                    <td class=""ac leechersInfo"">8</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286430""><b>Some Random Serie 2014 S03E16 720p HEVC x265-MeGusta</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 16 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286430/Some.Random.Serie.2014.S03E16.720p.HEVC.x265-MeGusta.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286430#startcomments"">2</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286430&amp;filelist=1#filelist"">234 MB</a></td>
                    <td class=""ac seedersInfo"">285</td>
                    <td class=""ac leechersInfo"">18</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286422""><b>Some Random Serie 2014 S03E16 1080p HDTV X264-DIMENSION</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 16 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286422/Some.Random.Serie.2014.S03E16.1080p.HDTV.X264-DIMENSION.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286422#startcomments"">1</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286422&amp;filelist=1#filelist"">2.15 GB</a></td>
                    <td class=""ac seedersInfo"">315</td>
                    <td class=""ac leechersInfo"">14</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=46#torrentTableWrapper""><img border=""0"" src=""https://lookpic.com/O/i2/334/H8JFMu2k.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286421""><b>Some Random Serie 2014 S03E16 AAC MP4-Mobile</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 16 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286421/Some.Random.Serie.2014.S03E16.AAC.MP4-Mobile.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286421#startcomments"">3</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286421&amp;filelist=1#filelist"">159 MB</a></td>
                    <td class=""ac seedersInfo"">127</td>
                    <td class=""ac leechersInfo"">4</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=2#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-xvid.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286413""><b>Some Random Serie 2014 S03E16 XviD-AFG</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 17 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286413/Some.Random.Serie.2014.S03E16.XviD-AFG.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286413#startcomments"">5</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286413&amp;filelist=1#filelist"">354 MB</a></td>
                    <td class=""ac seedersInfo"">810</td>
                    <td class=""ac leechersInfo"">13</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=26#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-sd-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286402""><b>Some Random Serie 2014 S03E16 HDTV x264-LOL</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 17 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286402/Some.Random.Serie.2014.S03E16.HDTV.x264-LOL.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286402#startcomments"">4</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286402&amp;filelist=1#filelist"">217 MB</a></td>
                    <td class=""ac seedersInfo"">535</td>
                    <td class=""ac leechersInfo"">10</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2286401""><b>Some Random Serie 2014 S03E16 720p HDTV X264-DIMENSION</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 17 hours ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2286401/Some.Random.Serie.2014.S03E16.720p.HDTV.X264-DIMENSION.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2286401#startcomments"">3</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2286401&amp;filelist=1#filelist"">715 MB</a></td>
                    <td class=""ac seedersInfo"">1,575</td>
                    <td class=""ac leechersInfo"">76</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2272262""><b>Some Random Serie S03E15 1080p WEB-DL DD5 1 H264-LiGaS</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2272262/Some.Random.Serie.S03E15.1080p.WEB-DL.DD5.1.H264-LiGaS.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2272262&amp;filelist=1#filelist"">1.65 GB</a></td>
                    <td class=""ac seedersInfo"">58</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2272261""><b>Some Random Serie S03E15 720p WEB-DL DD5 1 H264-LiGaS</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2272261/Some.Random.Serie.S03E15.720p.WEB-DL.DD5.1.H264-LiGaS.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2272261&amp;filelist=1#filelist"">1.32 GB</a></td>
                    <td class=""ac seedersInfo"">58</td>
                    <td class=""ac leechersInfo"">3</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2272149""><b>Some Random Serie 2014 S03E15 1080p WEB-DL DD5 1 H 264-DRACULA</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2272149/Some.Random.Serie.2014.S03E15.1080p.WEB-DL.DD5.1.H.264-DRACULA.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2272149#startcomments"">2</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2272149&amp;filelist=1#filelist"">1.65 GB</a></td>
                    <td class=""ac seedersInfo"">0</td>
                    <td class=""ac leechersInfo"">11</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2272147""><b>Some Random Serie 2014 S03E15 720p WEB-DL DD5 1 H 264-DRACULA</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2272147/Some.Random.Serie.2014.S03E15.720p.WEB-DL.DD5.1.H.264-DRACULA.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2272147&amp;filelist=1#filelist"">1.32 GB</a></td>
                    <td class=""ac seedersInfo"">26</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2271371""><b>Some Random Serie 2014 S03E15 1080p HDTV HEVC x265-RMTeam</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2271371/Some%20Random%20Series%202014%20S03E15%201080p%20HDTV%20HEVC%20x265-RMTeam.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2271371&amp;filelist=1#filelist"">494 MB</a></td>
                    <td class=""ac seedersInfo"">48</td>
                    <td class=""ac leechersInfo"">2</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2271010""><b>Some Random Serie 2014 S03E15 1080p HEVC x265-MeGusta</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2271010/Some.Random.Serie.2014.S03E15.1080p.HEVC.x265-MeGusta.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2271010&amp;filelist=1#filelist"">534 MB</a></td>
                    <td class=""ac seedersInfo"">67</td>
                    <td class=""ac leechersInfo"">2</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270895""><b>Some Random Serie 2014 S03E15 1080p HDTV X264-DIMENSION</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270895/Some.Random.Serie.2014.S03E15.1080p.HDTV.X264-DIMENSION.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270895&amp;filelist=1#filelist"">2.15 GB</a></td>
                    <td class=""ac seedersInfo"">155</td>
                    <td class=""ac leechersInfo"">5</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=2#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-xvid.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270826""><b>Some Random Serie 2014 S03E15 HDTV XviD-FUM</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270826/Some.Random.Serie.2014.S03E15.HDTV.XviD-FUM.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2270826#startcomments"">5</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270826&amp;filelist=1#filelist"">349 MB</a></td>
                    <td class=""ac seedersInfo"">269</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270713""><b>Some Random Serie 2014 S03E15 720p HEVC x265-MeGusta</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270713/Some.Random.Serie.2014.S03E15.720p.HEVC.x265-MeGusta.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2270713#startcomments"">4</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270713&amp;filelist=1#filelist"">270 MB</a></td>
                    <td class=""ac seedersInfo"">193</td>
                    <td class=""ac leechersInfo"">5</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=46#torrentTableWrapper""><img border=""0"" src=""https://lookpic.com/O/i2/334/H8JFMu2k.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270712""><b>Some Random Serie 2014 S03E15 AAC MP4-Mobile</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270712/Some.Random.Serie.2014.S03E15.AAC.MP4-Mobile.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2270712#startcomments"">4</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270712&amp;filelist=1#filelist"">172 MB</a></td>
                    <td class=""ac seedersInfo"">114</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=2#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-xvid.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270707""><b>Some Random Serie 2014 S03E15 XviD-AFG</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270707/Some.Random.Serie.2014.S03E15.XviD-AFG.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2270707#startcomments"">6</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270707&amp;filelist=1#filelist"">393 MB</a></td>
                    <td class=""ac seedersInfo"">587</td>
                    <td class=""ac leechersInfo"">2</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270680""><b>Some Random Serie 2014 S03E15 720p HDTV X264-DIMENSION</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270680/Some.Random.Serie.2014.S03E15.720p.HDTV.X264-DIMENSION.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2270680#startcomments"">4</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270680&amp;filelist=1#filelist"">743 MB</a></td>
                    <td class=""ac seedersInfo"">1,221</td>
                    <td class=""ac leechersInfo"">29</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=26#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-sd-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2270674""><b>Some Random Serie 2014 S03E15 HDTV x264-LOL</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 1 week  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2270674/Some.Random.Serie.2014.S03E15.HDTV.x264-LOL.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2270674#startcomments"">4</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2270674&amp;filelist=1#filelist"">263 MB</a></td>
                    <td class=""ac seedersInfo"">391</td>
                    <td class=""ac leechersInfo"">1</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2267970""><b>Some Random Serie 2014 S03E14 WEB-DL 1080p 10bit 5 1 x265 HEVC-Qman</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 1 week 1 day ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2267970/Some.Random.Serie.2014.S03E14.WEB-DL.1080p.10bit.5.1.x265.HEVC-Qman.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2267970&amp;filelist=1#filelist"">797 MB</a></td>
                    <td class=""ac seedersInfo"">25</td>
                    <td class=""ac leechersInfo"">1</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2258852""><b>Some Random Serie 2014 S03E14 1080p HEVC x265-MeGusta</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 1 week 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2258852/Some.Random.Serie.2014.S03E14.1080p.HEVC.x265-MeGusta.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2258852&amp;filelist=1#filelist"">558 MB</a></td>
                    <td class=""ac seedersInfo"">35</td>
                    <td class=""ac leechersInfo"">1</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2256729""><b>Some Random Serie 2014 S03E14 720p WEB-DL DD5 1 H 264-DRACULA</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 1 week 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2256729/Some.Random.Serie.2014.S03E14.720p.WEB-DL.DD5.1.H.264-DRACULA.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2256729&amp;filelist=1#filelist"">1.31 GB</a></td>
                    <td class=""ac seedersInfo"">42</td>
                    <td class=""ac leechersInfo"">2</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2256719""><b>Some Random Serie 2014 S03E14 1080p WEB-DL DD5 1 H 264-DRACULA</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 1 week 6 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2256719/Some.Random.Serie.2014.S03E14.1080p.WEB-DL.DD5.1.H.264-DRACULA.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2256719&amp;filelist=1#filelist"">1.65 GB</a></td>
                    <td class=""ac seedersInfo"">54</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=2#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-xvid.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255554""><b>Some Random Serie 2014 S03E14 HDTV XviD-FUM</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255554/Some.Random.Serie.2014.S03E14.HDTV.XviD-FUM.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255554#startcomments"">2</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255554&amp;filelist=1#filelist"">349 MB</a></td>
                    <td class=""ac seedersInfo"">175</td>
                    <td class=""ac leechersInfo"">11</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255553""><b>Some Random Serie 2014 S03E14 1080p HDTV X264-DIMENSION</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255553/Some.Random.Serie.2014.S03E14.1080p.HDTV.X264-DIMENSION.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255553&amp;filelist=1#filelist"">2.23 GB</a></td>
                    <td class=""ac seedersInfo"">131</td>
                    <td class=""ac leechersInfo"">4</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=46#torrentTableWrapper""><img border=""0"" src=""https://lookpic.com/O/i2/334/H8JFMu2k.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255537""><b>Some Random Serie 2014 S03E14 AAC MP4-Mobile</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255537/Some.Random.Serie.2014.S03E14.AAC.MP4-Mobile.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255537#startcomments"">2</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255537&amp;filelist=1#filelist"">176 MB</a></td>
                    <td class=""ac seedersInfo"">49</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=24#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-480p.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255533""><b>Some Random Serie 2014 S03E14 480p x264-mSD</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 480p | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255533/Some.Random.Serie.2014.S03E14.480p.x264-mSD.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255533#startcomments"">3</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255533&amp;filelist=1#filelist"">202 MB</a></td>
                    <td class=""ac seedersInfo"">185</td>
                    <td class=""ac leechersInfo"">1</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255449""><b>Some Random Serie 2014 S03E14 720p HEVC x265-MeGusta</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255449/Some.Random.Serie.2014.S03E14.720p.HEVC.x265-MeGusta.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255449#startcomments"">2</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255449&amp;filelist=1#filelist"">280 MB</a></td>
                    <td class=""ac seedersInfo"">146</td>
                    <td class=""ac leechersInfo"">2</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=2#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-xvid.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255435""><b>Some Random Serie 2014 S03E14 XviD-AFG</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255435/Some.Random.Serie.2014.S03E14.XviD-AFG.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255435#startcomments"">12</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255435&amp;filelist=1#filelist"">416 MB</a></td>
                    <td class=""ac seedersInfo"">538</td>
                    <td class=""ac leechersInfo"">2</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=26#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-sd-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255426""><b>Some Random Serie 2014 S03E14 HDTV x264-LOL</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255426/Some.Random.Serie.2014.S03E14.HDTV.x264-LOL.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255426#startcomments"">6</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255426&amp;filelist=1#filelist"">268 MB</a></td>
                    <td class=""ac seedersInfo"">248</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=7#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x264.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2255412""><b>Some Random Serie 2014 S03E14 720p HDTV X264-DIMENSION</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 720p | 2 weeks  ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2255412/Some.Random.Serie.2014.S03E14.720p.HDTV.X264-DIMENSION.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""commentsInfo"" align=""center""><a href=""details.php?id=2255412#startcomments"">9</a></td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2255412&amp;filelist=1#filelist"">755 MB</a></td>
                    <td class=""ac seedersInfo"">958</td>
                    <td class=""ac leechersInfo"">27</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2252185""><b>Some Random Serie 2014 S03E13 WEB-DL 1080p 10bit 5 1 x265 HEVC-Qman</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 2 weeks 1 day ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2252185/Some.Random.Serie.2014.S03E13.WEB-DL.1080p.10bit.5.1.x265.HEVC-Qman.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2252185&amp;filelist=1#filelist"">914 MB</a></td>
                    <td class=""ac seedersInfo"">12</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    <tr class=""browse"">
                    <td class=""browse""><a href=""browse.php?cat=34#torrentTableWrapper""><img border=""0"" src=""/images/categories/tv-x265.png""></a></td>
                    <td class=""torrentNameInfo""><div class=""torrentTableNameDiv""><a class=""torrentName"" href=""details.php?id=2250261""><b>Some Random Serie 2014 S03E13 1080p HEVC x265-MeGusta</b></a><span class=""newTags"">NEW!</span></div><span class=""ulInfo"">8.2 2014 Action Adventure Drama 1080p | 2 weeks 3 days ago</span></td><td class=""dlLinksInfo"" align=""center""><a class=""index"" href=""download.php/2250261/Some.Random.Serie.2014.S03E13.1080p.HEVC.x265-MeGusta.torrent""><img src=""/images/browse/uTorrent.png"" alt=""Download as .torrent file"" border=""0""></a></td><td class=""browse"" align=""center"">0</td>
                    <td class=""sizeInfo"" align=""center""><a href=""details.php?id=2250261&amp;filelist=1#filelist"">606 MB</a></td>
                    <td class=""ac seedersInfo"">26</td>
                    <td class=""ac leechersInfo"">0</td>
                    </tr>
                    </tbody></table>");

            #endregion

            var res = webScraperService.FindTorrentsByName("best series ever", doc, "www.torrentday.com/");

            Assert.AreEqual(0,res.Count);


        }
        

    }
}