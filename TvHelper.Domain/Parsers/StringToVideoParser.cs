using System.Text.RegularExpressions;
using TvHelper.Domain.Models;

namespace TvHelper.Domain.Parsers
{
    public static class StringToVideoParser
    {
        public static Video StringToVideo(string fileName)
        {
            const string pattern = @"(.+)[S|s](\d{2})[E|e](\d{2}).+";
            string lastSubFolder;
            if (fileName.Contains("\\"))
                lastSubFolder = fileName.Substring(fileName.LastIndexOf('\\') + 1);
            else
                lastSubFolder = fileName.Substring(fileName.LastIndexOf('/') + 1);

            var regEx = new Regex(pattern);

            var match = regEx.Match(lastSubFolder);
            if (!match.Success) return null;

            var torrent = new Video
            {
                Title = match.Groups[1].ToString().Replace('.', ' ').Trim(),
                SeasonNr = int.Parse(match.Groups[2].Value),
                EpisodeNr = int.Parse(match.Groups[3].Value),
                Path = fileName
            };

            return torrent;
        }
    }
}