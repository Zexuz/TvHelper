using System.Text.RegularExpressions;
using TvHelper.Models;

namespace TvHelper.Servicies
{
    public class StringToTorrentParser
    {
        public Video StringToDownloadedTorrent(string fileName)
        {
            const string pattern = @"(.+)S(\d{2})E(\d{2}).+";
            var lastSubFolder = fileName.Substring(fileName.LastIndexOf('\\') + 1);

            var regEx = new Regex(pattern);

            var match = regEx.Match(lastSubFolder);
            if (!match.Success) return null;

            var torrent = new Video
            {
                Title = match.Groups[1].ToString().Replace('.', ' ').Trim(),
                SeasonNr =  match.Groups[2].Value,
                EpisodeNr = match.Groups[3].Value,
                Path = fileName

            };

            return torrent;
        }
    }
}