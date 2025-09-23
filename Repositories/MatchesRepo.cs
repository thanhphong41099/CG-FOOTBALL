using System.Collections.Generic;
using System.Data.SQLite;
using VLeague.Models;

namespace VLeague.Repositories
{
    public class MatchesRepo : BaseRepository
    {
        public MatchesRepo(SQLiteConnection c) : base(c) { }

        public List<Match> GetAll()
        {
            var list = new List<Match>();
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT MATCH_ID, ROUND, MATCH_DAY, STADIUM, TOURNAMENT,
                                           HOME_TEAM, AWAY_TEAM, HOME_COLOR, AWAY_COLOR
                                    FROM MATCHES ORDER BY MATCH_ID DESC;";
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(Map(rd));
                    }
                }
            }
            return list;
        }

        public Match Get(int matchId)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT MATCH_ID, ROUND, MATCH_DAY, STADIUM, TOURNAMENT,
                                           HOME_TEAM, AWAY_TEAM, HOME_COLOR, AWAY_COLOR
                                    FROM MATCHES WHERE MATCH_ID=@id;";
                cmd.Parameters.AddWithValue("@id", matchId);
                using (var rd = cmd.ExecuteReader())
                {
                    return rd.Read() ? Map(rd) : null;
                }
            }
        }

        public int Insert(Match m)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO MATCHES(ROUND, MATCH_DAY, STADIUM, TOURNAMENT,
                                                        HOME_TEAM, AWAY_TEAM, HOME_COLOR, AWAY_COLOR)
                                    VALUES(@r,@d,@s,@t,@h,@a,@hc,@ac);
                                    SELECT last_insert_rowid();";
                cmd.Parameters.AddWithValue("@r", m.ROUND);
                cmd.Parameters.AddWithValue("@d", m.MATCH_DAY);
                cmd.Parameters.AddWithValue("@s", m.STADIUM);
                cmd.Parameters.AddWithValue("@t", m.TOURNAMENT);
                cmd.Parameters.AddWithValue("@h", m.HOME_TEAM);
                cmd.Parameters.AddWithValue("@a", m.AWAY_TEAM);
                cmd.Parameters.AddWithValue("@hc", m.HOME_COLOR);
                cmd.Parameters.AddWithValue("@ac", m.AWAY_COLOR);
                return (int)(long)cmd.ExecuteScalar();
            }
        }

        public void UpdateColors(int matchId, string homeRgb, string awayRgb)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE MATCHES SET HOME_COLOR=@hc, AWAY_COLOR=@ac WHERE MATCH_ID=@id;";
                cmd.Parameters.AddWithValue("@hc", homeRgb);
                cmd.Parameters.AddWithValue("@ac", awayRgb);
                cmd.Parameters.AddWithValue("@id", matchId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTeams(int matchId, int homeId, int awayId)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE MATCHES SET HOME_TEAM=@h, AWAY_TEAM=@a WHERE MATCH_ID=@id;";
                cmd.Parameters.AddWithValue("@h", homeId);
                cmd.Parameters.AddWithValue("@a", awayId);
                cmd.Parameters.AddWithValue("@id", matchId);
                cmd.ExecuteNonQuery();
            }
        }

        private static Match Map(System.Data.IDataRecord rd)
        {
            var m = new Match();
            m.MATCH_ID = rd.GetInt32(0);
            m.ROUND = rd.IsDBNull(1) ? null : rd.GetString(1);
            m.MATCH_DAY = rd.IsDBNull(2) ? null : rd.GetString(2);
            m.STADIUM = rd.IsDBNull(3) ? null : rd.GetString(3);
            m.TOURNAMENT = rd.IsDBNull(4) ? null : rd.GetString(4);
            m.HOME_TEAM = rd.IsDBNull(5) ? 0 : rd.GetInt32(5);
            m.AWAY_TEAM = rd.IsDBNull(6) ? 0 : rd.GetInt32(6);
            m.HOME_COLOR = rd.IsDBNull(7) ? null : rd.GetString(7);
            m.AWAY_COLOR = rd.IsDBNull(8) ? null : rd.GetString(8);
            return m;
        }
    }
}
