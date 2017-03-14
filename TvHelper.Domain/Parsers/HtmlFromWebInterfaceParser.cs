using System;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using TvHelper.Domain.Models;

namespace TvHelper.Domain.Parsers
{
    public class HtmlFromWebInterfaceParser
    {
        private readonly HtmlDocument _doc;

        public HtmlFromWebInterfaceParser(string html)
        {
            _doc = new HtmlDocument();
            _doc.LoadHtml(html);
        }

        public ActiveVideo GetActiveVideo()
        {
            var video = GetVideo();
            var activeVideo = new ActiveVideo
            {
                CurrentPosition = GetCurrentPosition(),
                Duration = GetDuration(),
                IsPlaying = IsPlaying(),
                EpisodeNr = video.EpisodeNr,
                SeasonNr = video.SeasonNr,
                Title = video.Title,
                Path = video.Path
            };

            return activeVideo;
        }

        public Video GetVideo()
        {
            var innerText = _doc.GetElementbyId("file").InnerText;
            var fileName = new StringToVideoParser().StringToDownloadedVideo(innerText);
            return fileName;
        }


        private bool IsPlaying()
        {
            var innerText = _doc.GetElementbyId("state").InnerText;
            var state = int.Parse(innerText);

            return state == 2;
        }

        private TimeSpan GetDuration()
        {
            var innerText = _doc.GetElementbyId("duration").InnerText;
            var durationInSec = int.Parse(innerText) / 1000;

            return new TimeSpan(0, 0, durationInSec);
        }

        private TimeSpan GetCurrentPosition()
        {
            var innerText = _doc.GetElementbyId("positionstring").InnerText;
            var regex = new Regex(@"(\d{2}):(\d{2}):(\d{2})");
            var match = regex.Match(innerText);
            var hour = int.Parse(match.Groups[1].Value);
            var min = int.Parse(match.Groups[2].Value);
            var sec = int.Parse(match.Groups[3].Value);

            return new TimeSpan(hour, min, sec);
        }
    }
}