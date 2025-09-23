using System.Collections.Generic;
using System.Data.SQLite;
using VLeague.Models;

namespace VLeague.Repositories
{
    public class OfficialsRepo : BaseRepository
    {
        public OfficialsRepo(SQLiteConnection c) : base(c) { }

        public List<Official> ByMatch(int matchId)
        {
            var list = new List<Official>();
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT MATCH_ID, TYPE, NAME FROM OFFICIALS WHERE MATCH_ID=@mid ORDER BY TYPE;";
                cmd.Parameters.AddWithValue("@mid", matchId);
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var o = new Official();
                        o.MATCH_ID = rd.GetInt32(0);
                        o.TYPE = rd.IsDBNull(1) ? null : rd.GetString(1);
                        o.NAME = rd.IsDBNull(2) ? null : rd.GetString(2);
                        list.Add(o);
                    }
                }
            }
            return list;
        }

        public void Upsert(int matchId, string type, string name)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"
DELETE FROM OFFICIALS WHERE MATCH_ID=@mid AND TYPE=@t;
INSERT INTO OFFICIALS(MATCH_ID, TYPE, NAME) VALUES(@mid, @t, @n);";
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@t", type);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
