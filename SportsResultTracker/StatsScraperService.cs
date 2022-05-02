using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SportsResultTracker;

namespace SportsResultTracker
{
    internal static class StatsScraperService
    {
        public static List<BasketballStatsModel> GetStats()
        {
            HtmlWeb web = new();
            HtmlDocument doc = web.Load("https://www.basketball-reference.com/boxscores/");

            List<BasketballStatsModel> statsList = new List<BasketballStatsModel>();

            var tableData = doc.DocumentNode.SelectNodes("//*[@id=\"confs_standings_E\"]/tbody/tr");

            tableData.ToList().ForEach(t => statsList.Add(new BasketballStatsModel
            {
                TeamName = t.ChildNodes[0].InnerText,
                Wins = t.ChildNodes[1].InnerText,
                Loses = t.ChildNodes[2].InnerText,
                WinLosePrecent = t.ChildNodes[3].InnerText,
                GamesBehind = t.ChildNodes[4].InnerText,
                PointsPerGame = t.ChildNodes[5].InnerText,
                OpponentPointsPerGame = t.ChildNodes[6].InnerText
            }));

            return statsList;
        }
    }
}
