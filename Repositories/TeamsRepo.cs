using System.Collections.Generic;
using System.Data.SQLite;
using VLeague.Models;

namespace VLeague.Repositories
{
    public class TeamsRepo : BaseRepository
    {
        public TeamsRepo(SQLiteConnection c) : base(c) { }

        public List<Team> GetAll()
        {
            var list = new List<Team>();
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT TEAM_ID, TEAMS_FULL_NAME, CLOCK_NAME, LOWER_THIRD_NAME,
                                           TEAMLOGO, COACH_NAME, COACH_POS, HOME_ITEM, AWAY_ITEM, GOAL_ITEM
                                    FROM TEAM_ID ORDER BY TEAM_ID;";
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var item = new Team();
                        item.TEAM_ID = rd.GetInt32(0);
                        item.TEAMS_FULL_NAME = rd.IsDBNull(1) ? null : rd.GetString(1);
                        item.CLOCK_NAME = rd.IsDBNull(2) ? null : rd.GetString(2);
                        item.LOWER_THIRD_NAME = rd.IsDBNull(3) ? null : rd.GetString(3);
                        item.TEAMLOGO = rd.IsDBNull(4) ? null : rd.GetString(4);
                        item.COACH_NAME = rd.IsDBNull(5) ? null : rd.GetString(5);
                        item.COACH_POS = rd.IsDBNull(6) ? null : rd.GetString(6);
                        item.HOME_ITEM = rd.IsDBNull(7) ? null : rd.GetString(7);
                        item.AWAY_ITEM = rd.IsDBNull(8) ? null : rd.GetString(8);
                        item.GOAL_ITEM = rd.IsDBNull(9) ? null : rd.GetString(9);
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public Team Get(int teamId)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT TEAM_ID, TEAMS_FULL_NAME, CLOCK_NAME, LOWER_THIRD_NAME,
                                           TEAMLOGO, COACH_NAME, COACH_POS, HOME_ITEM, AWAY_ITEM, GOAL_ITEM
                                    FROM TEAM_ID WHERE TEAM_ID=@id;";
                cmd.Parameters.AddWithValue("@id", teamId);
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;
                    var item = new Team();
                    item.TEAM_ID = rd.GetInt32(0);
                    item.TEAMS_FULL_NAME = rd.IsDBNull(1) ? null : rd.GetString(1);
                    item.CLOCK_NAME = rd.IsDBNull(2) ? null : rd.GetString(2);
                    item.LOWER_THIRD_NAME = rd.IsDBNull(3) ? null : rd.GetString(3);
                    item.TEAMLOGO = rd.IsDBNull(4) ? null : rd.GetString(4);
                    item.COACH_NAME = rd.IsDBNull(5) ? null : rd.GetString(5);
                    item.COACH_POS = rd.IsDBNull(6) ? null : rd.GetString(6);
                    item.HOME_ITEM = rd.IsDBNull(7) ? null : rd.GetString(7);
                    item.AWAY_ITEM = rd.IsDBNull(8) ? null : rd.GetString(8);
                    item.GOAL_ITEM = rd.IsDBNull(9) ? null : rd.GetString(9);
                    return item;
                }
            }
        }
    }
}
