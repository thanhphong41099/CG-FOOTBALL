using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLeague.src.model
{
    public static class Static
    {
        public static string numberHomeScore { get; set; } = "0";
        public static string numberAwayScore { get; set; } = "0";
        public static int numberHomePen { get; set; } = 0;
        public static int numberAwayPen { get; set; } = 0;

        public static string[,] HomeNameGoals = new string[10, 3];

        public static string[,] AwayNameGoals = new string[10, 3];

        // Các phương thức để cập nhật và truy cập biến
        public static void UpdatePenaltyScores(int numHomePen, int numAwayPen)
        {
            numberHomePen = numHomePen;
            numberAwayPen = numAwayPen;
        }

        public static void UpdateScores(string homeScore, string awayScore)
        {
            numberHomeScore = homeScore;
            numberAwayScore = awayScore;
        }
        public static void UpdateNameGoals(string[,] newHomeNameGoals, string[,] newAwayNameGoals)
        {
            HomeNameGoals = newHomeNameGoals;
            AwayNameGoals = newAwayNameGoals;
        }
    }
}
