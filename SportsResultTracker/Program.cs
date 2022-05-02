using HtmlAgilityPack;
using SportsResultTracker;

public class SportsSender
{
    public static void Main()
    {
        var stats = StatsScraperService.GetStats();

        EmailService emailService = new EmailService();
        var html = emailService.PopulateBody(stats);
        EmailService.Email(html);
    }
}