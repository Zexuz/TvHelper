using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using TvHelper.Domain.Interfaces;
using TvHelper.Domain.Models;
using TvHelper.Domain.Parsers;

namespace TvHelper.Domain.Servicies
{
    public class WebScraperTorrentDayService : IWebScraper
    {
        public List<Video> FindTorrentsByName(string name, HtmlDocument htmlDocument, string webStite)
        {
            var nodes = htmlDocument.DocumentNode
                .SelectNodes("//a[@class='index']")
                .Select(node => webStite + node.Attributes["href"].Value)
                .ToList();

            var videos = nodes
                .Select(StringToVideoParser.StringToVideo)
                .Where(str => str.Title.ToLower().Contains(name.ToLower())
                              || str.Title.ToLower().Contains(Uri.EscapeUriString(name).ToLower()))
                .ToList();

            return videos;
        }
    }
}