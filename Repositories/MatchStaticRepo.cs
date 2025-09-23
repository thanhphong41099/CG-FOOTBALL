using System.Collections.Generic;
using System.Data.SQLite;
using VLeague.Models;

namespace VLeague.Repositories
{
    public class MatchStaticRepo : BaseRepository
    {
        public MatchStaticRepo(SQLiteConnection c) : base(c) { }

        public List<MatchStatic> Template()
        {
            var list = new List<MatchStatic>();
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT ID, PARM, HOME_VALUE, AWAY_VALUE FROM MATCHSTATIC ORDER BY ID;";
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var m = new MatchStatic();
                        m.ID = rd.GetInt32(0);
                        m.PARM = rd.IsDBNull(1) ? null : rd.GetString(1);
                        m.HOME_VALUE = rd.IsDBNull(2) ? 0 : rd.GetInt32(2);
                        m.AWAY_VALUE = rd.IsDBNull(3) ? 0 : rd.GetInt32(3);
                        list.Add(m);
                    }
                }
            }
            return list;
        }
    }
}
