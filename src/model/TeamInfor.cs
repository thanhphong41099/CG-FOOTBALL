using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLeague.src.model
{
    public static class TeamInfor
    {
        public static string homeCode { get; set; }
        public static string homeTactical { get; set; }
        public static string homeTenDai { get; set; }
        public static string homeTenNgan { get; set; }
        public static string homeHLV { get; set; }
        public static string homeLogo { get; set; }
        public static string homeLogoIn { get; set; }
        public static string homeLogoOut { get; set; }
        public static string homeIconPlayer { get; set; }
        public static string homeIconGK { get; set; }
        public static Color Player_HomeColor { get; set; }
        public static Color GK_HomeColor { get; set; }

        public static List<Point> homePosition { get; set; } = new List<Point>();



        public static string awayCode { get; set; }
        public static string awayTactical { get; set; }
        public static string awayTenDai { get; set; }
        public static string awayTenNgan { get; set; }
        public static string awayHLV { get; set; }
        public static string awayLogo { get; set; }
        public static string awayLogoIn { get; set; }
        public static string awayLogoOut { get; set; }
        public static string awayIconPlayer { get; set; }
        public static string awayIconGK { get; set; }
        public static Color Player_AwayColor { get; set; }
        public static Color GK_AwayColor { get; set; }
        public static List<Point> awayPosition { get; set; } = new List<Point>();

        public static Player[] PlayersHomeLineup { get; set; }
        public static Player[] PlayersHomeSub { get; set; }
        public static Player[] PlayersAwayLineup { get; set; }
        public static Player[] PlayersAwaySub { get; set; }
        public static Player[] PlayersHome { get; set; }
        public static Player[] PlayersAway { get; set; }
        // Phương thức để cập nhật SharedData từ FrmDataImport
        public static void UpdateData(string newhomeCode, string newhomeTactical, string newhomeTenDai, string newhomeTenNgan, string newhomeHLV, string newhomeLogo,
                                               string newawayCode, string newawayTactical, string newawayTenDai, string newawayTenNgan, string newawayHLV, string newawayLogo, Color newHomeColor, Color newAwayColor,
                                               string newhomeLogoIn, string newhomeLogoOut, string newawayLogoIn, string newawayLogoOut, Color GKHomeColor, Color GKAwayColor)
        {
            homeCode = newhomeCode;
            homeTactical = newhomeTactical;
            homeTenDai = newhomeTenDai;
            homeTenNgan = newhomeTenNgan;
            homeHLV = newhomeHLV;
            homeLogo = newhomeLogo;
            homeLogoIn = newhomeLogoIn;
            homeLogoOut = newhomeLogoOut;
            Player_HomeColor = newHomeColor;
            GK_HomeColor = GKHomeColor;

            awayCode = newawayCode;
            awayTactical = newawayTactical;
            awayTenDai = newawayTenDai;
            awayTenNgan = newawayTenNgan;
            awayHLV = newawayHLV;
            awayLogo = newawayLogo;
            awayLogoIn = newawayLogoIn;
            awayLogoOut = newawayLogoOut;
            Player_AwayColor = newAwayColor;
            GK_AwayColor = GKAwayColor;

        }
    }

}
