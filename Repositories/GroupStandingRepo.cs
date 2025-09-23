using System.Collections.Generic;
using System.Data.SQLite;
using VLeague.Models;

namespace VLeague.Repositories
{
    public class GroupStandingRepo : BaseRepository
    {
        public GroupStandingRepo(SQLiteConnection c) : base(c) { }

        public List<GroupStanding> GetAll()
        {
            var list = new List<GroupStanding>();
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT TEAM_ID, TEAMS, TRAN, THANG, HOA, THUA, HIEU_SO, DIEM
                                    FROM GROUPSTANDING;";
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var g = new GroupStanding();
                        g.TEAM_ID = rd.GetInt32(0);
                        g.TEAMS = rd.IsDBNull(1) ? null : rd.GetString(1);
                        g.TRAN = rd.IsDBNull(2) ? 0 : rd.GetInt32(2);
                        g.THANG = rd.IsDBNull(3) ? 0 : rd.GetInt32(3);
                        g.HOA = rd.IsDBNull(4) ? 0 : rd.GetInt32(4);
                        g.THUA = rd.IsDBNull(5) ? 0 : rd.GetInt32(5);
                        g.HIEU_SO = rd.IsDBNull(6) ? 0 : rd.GetInt32(6);
                        g.DIEM = rd.IsDBNull(7) ? 0 : rd.GetInt32(7);
                        list.Add(g);
                    }
                }
            }
            return list;
        }
    }
}
