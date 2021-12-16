using System;
using System.Linq;
using System.Net;

namespace WebScraperTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The team with most NBA Championships is: {GetBestNbaTeam()}");
            Console.ReadLine();
        }

        static NbaTeam GetBestNbaTeam()=>
            new WebClient().DownloadWebPage(new Uri("https://en.wikipedia.org/wiki/National_Basketball_Association"))
            .SelectNodes("//table[@class='wikitable']/tbody//tr/td/b")
            .Select(teamNode =>
                    NbaTeam.Create(
                        teamNode.InnerText,
                        new WebClient().DownloadWebPage(new Uri(CreateUrl(teamNode.SelectSingleNode("a").Attributes["href"].Value)))
                        .SelectSingleNode("//th[text()='Championships']/following-sibling::td/b").InnerText.ToInt()))
            .Aggregate(NbaTeam.Create(), (best, next) => next.Championships > best.Championships ? next : best);

        private static string CreateUrl(string partialUrl) => string.Format("{0}{1}", "https://en.wikipedia.org", partialUrl);
    }
}
