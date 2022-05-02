using System.Net;
using System.Net.Mail;

using System.Text;

namespace SportsResultTracker
{
    internal class EmailService
    {
        public string PopulateBody(List<BasketballStatsModel> statsList)
        {
            string body = string.Empty;
            StringBuilder rows = new(100);
            using (StreamReader reader = new("C:\\Users\\Max\\Source\\Repos\\SportsResultTracker\\EmailTemplate.html"))
            {
                body = reader.ReadToEnd();
            }
            
            foreach(var item in statsList)
            {
                rows.Append(@$"<tr>
                                <td>{item.TeamName}</td>
                                <td>{item.Wins}</td>
                                <td>{item.Loses}</td>
                                <td>{item.WinLosePrecent}</td>
                                <td>{item.GamesBehind}</td>
                                <td>{item.PointsPerGame}</td>
                                <td>{item.OpponentPointsPerGame}</td>
                        </tr>");
            }
            body = body.Replace("{TableRows}", rows.ToString());
            return body;
        }

        public static void Email(string htmlString)
        {
            using MailMessage message = new MailMessage();

            message.From = new MailAddress("sender@gmail.com");
            message.To.Add("receiver@gmail.com");
            message.Subject = "Test";
            message.Body = htmlString;
            message.IsBodyHtml = true;

            using SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            smtp.Credentials = new NetworkCredential("sender@gmail.com", "password");
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
    }
}
