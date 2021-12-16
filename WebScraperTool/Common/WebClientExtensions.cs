using System;
using System.Net;
using HtmlAgilityPack;

namespace WebScraperTool
{
    public static class WebClientExtensions
    {
        public static HtmlNode DownloadWebPage(this WebClient webClient, Uri uri)
        {
            var htmlSourceCode = webClient.DownloadString(uri);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlSourceCode);
            return htmlDocument.DocumentNode;
        }
    }
}
