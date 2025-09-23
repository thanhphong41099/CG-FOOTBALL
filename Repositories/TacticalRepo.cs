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

        public List<TacticalItem> ByMatch(int matchId)
        {
            var list = new List<TacticalItem>();
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT MATCH_ID, TEAM_ID, TACTICAL_TEXT FROM TACTICAL WHERE MATCH_ID=@mid ORDER BY TEAM_ID;";
                cmd.Parameters.AddWithValue("@mid", matchId);
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var item = new TacticalItem();
                        item.MATCH_ID = rd.GetInt32(0);
                        item.TEAM_ID = rd.GetInt32(1);
                        item.TACTICAL_TEXT = rd.IsDBNull(2) ? null : rd.GetString(2);
                        list.Add(item);
                    }
                }
            }
            return list;
        }
    }
}
