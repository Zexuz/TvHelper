using HtmlAgilityPack;

namespace TvHelper.Domain.Extensions
{
    public static class HtmlHasClassExtension
    {
        public static bool HasClass(this HtmlNode node, string className)
        {
            return node.Attributes.Contains("class") &&
                   node.Attributes["class"].Value.Contains(className);
        }
    }
}