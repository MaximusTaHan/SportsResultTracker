using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsResultTracker
{
    internal class BasketballStatsModel
    {
        public string TeamName { get; set; }
        public string Wins { get; set; }
        public string Loses { get; set; }
        public string WinLosePrecent { get; set; }
        public string GamesBehind { get; set; }
        public string PointsPerGame { get; set; }
        public string OpponentPointsPerGame { get; set; }
    }
}
