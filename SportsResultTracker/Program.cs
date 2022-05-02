using HtmlAgilityPack;
using SportsResultTracker;

class Program
{
    static void Main(string[] args)
    {
        HtmlWeb web = new();
        HtmlDocument doc = web.Load("https://www.basketball-reference.com/boxscores/");
        List<BasketballStatsModel> statsList = new List<BasketballStatsModel>();

        var title = doc.DocumentNode.SelectNodes("//*[@id=\"confs_standings_E_sh\"]/h2").First().InnerText;
        var tableData = doc.DocumentNode.SelectNodes("//*[@id=\"confs_standings_E\"]/tbody/tr");
        
        Console.WriteLine(title);
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

        foreach (var item in statsList)
        {
            Console.WriteLine($"Team Name: {item.TeamName}, Wins: {item.Wins}, Loses: {item.Loses}, W/L%: {item.WinLosePrecent}, GB: {item.GamesBehind}, PS/G: {item.PointsPerGame}, PA/G: {item.OpponentPointsPerGame}");
        }
    }
}