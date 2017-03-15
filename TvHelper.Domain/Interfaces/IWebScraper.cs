using System.Collections.Generic;
using HtmlAgilityPack;
using TvHelper.Domain.Models;

namespace TvHelper.Domain.Interfaces
{
    public interface IWebScraper
    {
        List<Video> FindTorrentsByName(string name, HtmlDocument htmlDocument, string webStite);

    }
}