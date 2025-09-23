namespace VLeague.Models
{
    public class Match
    {
        public int MATCH_ID;
        public string ROUND;
        public string MATCH_DAY;    // "YYYY-MM-DD HH:MM"
        public string STADIUM;
        public string TOURNAMENT;
        public int HOME_TEAM;
        public int AWAY_TEAM;
        public string HOME_COLOR;   // "R,G,B"
        public string AWAY_COLOR;   // "R,G,B"
    }
}
