using System;

namespace VLeague.Models
{
    public class Match
    {
        public int MATCH_ID { get; set; }
        public string ROUND { get; set; }
        public string MATCH_DAY { get; set; }
        public string STADIUM { get; set; }
        public string TOURNAMENT { get; set; }
        public int HOME_TEAM { get; set; }
        public int AWAY_TEAM { get; set; }
        public string HOME_NAME { get; set; }
        public string AWAY_NAME { get; set; }
        public string HOME_COLOR { get; set; }
        public string AWAY_COLOR { get; set; }
    }

}
