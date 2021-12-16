using System;

namespace WebScraperTool
{
    public class Wikipedia
    {
        public const string NbaTeamsUrl = "https://en.wikipedia.org/wiki/National_Basketball_Association";
        public const string NbaTeamsTableXPath = "//table[@class='wikitable']/tbody//tr/td/b";
        public const string NbaTeamChampionshipsXPath = "//th[text()='Championships']/following-sibling::td/b";

        public static Uri CreateUrl(string partial) =>
            new Uri(string.Format("{0}{1}", "https://en.wikipedia.org", partial));
    }
}
