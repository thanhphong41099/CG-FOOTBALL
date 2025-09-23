using System.Collections.Generic;
using System.Data.SQLite;
using VLeague.Models;

namespace VLeague.Repositories
{
    public class TacticalRepo : BaseRepository
    {
        public TacticalRepo(SQLiteConnection c) : base(c) { }

        public void Upsert(int matchId, int teamId, string text)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"
DELETE FROM TACTICAL WHERE MATCH_ID=@mid AND TEAM_ID=@tid;
INSERT INTO TACTICAL(MATCH_ID, TEAM_ID, TACTICAL_TEXT) VALUES(@mid, @tid, @txt);";
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@tid", teamId);
                cmd.Parameters.AddWithValue("@txt", text);
                cmd.ExecuteNonQuery();
            }
        }

        public Dictionary<int, string> ByMatch(int matchId)
        {
            var dict = new Dictionary<int, string>();
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT TEAM_ID, TACTICAL_TEXT FROM TACTICAL WHERE MATCH_ID=@mid;";
                cmd.Parameters.AddWithValue("@mid", matchId);
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var teamId = rd.GetInt32(0);
                        var txt = rd.IsDBNull(1) ? null : rd.GetString(1);
                        dict[teamId] = txt;
                    }
                }
            }
            return dict;
        }
    }
}
