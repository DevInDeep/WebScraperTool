using System;
using System.Linq;
using System.Net;

namespace WebScraperTool
{
    class Program
    {
        static void Main() =>
            Console.WriteLine($"The team with most NBA Championships is: {GetBestNbaTeam()}");

        static NbaTeam GetBestNbaTeam() =>
            new WebClient().DownloadWebPage(new Uri(Wikipedia.NbaTeamsUrl))
            .SelectNodes(Wikipedia.NbaTeamsTableXPath)
            .Select(teamNode =>
                    NbaTeam.Create(
                        teamNode.InnerText,
                        new WebClient()
                        .DownloadWebPage(Wikipedia.CreateUrl(teamNode.SelectSingleNode("a").Attributes["href"].Value))
                        .SelectSingleNode(Wikipedia.NbaTeamChampionshipsXPath).InnerText.ToInt()))
            .Aggregate(NbaTeam.Create(), (best, next) => next.Championships > best.Championships ? next : best);
    }
}
