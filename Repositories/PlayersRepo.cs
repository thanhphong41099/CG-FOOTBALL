using System.Collections.Generic;
using System.Data.SQLite;
using VLeague.Models;

namespace VLeague.Repositories
{
    public class PlayersRepo : BaseRepository
    {
        public PlayersRepo(SQLiteConnection c) : base(c) { }

        public List<Player> ByTeam(int teamId)
        {
            var list = new List<Player>();
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT PLAYER_ID, TEAM_ID, STT, Name, PLAY, DOB, Nationality,
                                           JerseyNo, JerseyName, Position, Title, Card, Pos1,
                                           TShirt_LineUp1, TShirt_Sub1, TShirt_LineUp2, TShirt_Sub2
                                    FROM PLAYERS WHERE TEAM_ID=@tid
                                    ORDER BY COALESCE(STT, 999), PLAYER_ID;";
                cmd.Parameters.AddWithValue("@tid", teamId);
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var p = new Player();
                        p.PLAYER_ID = rd.GetInt32(0);
                        p.TEAM_ID = rd.GetInt32(1);
                        p.STT = rd.IsDBNull(2) ? (int?)null : rd.GetInt32(2);
                        p.Name = rd.IsDBNull(3) ? null : rd.GetString(3);
                        p.PLAY = rd.IsDBNull(4) ? (int?)null : rd.GetInt32(4);
                        p.DOB = rd.IsDBNull(5) ? null : rd.GetString(5);
                        p.Nationality = rd.IsDBNull(6) ? null : rd.GetString(6);
                        p.JerseyNo = rd.IsDBNull(7) ? null : rd.GetString(7);
                        p.JerseyName = rd.IsDBNull(8) ? null : rd.GetString(8);
                        p.Position = rd.IsDBNull(9) ? null : rd.GetString(9);
                        p.Title = rd.IsDBNull(10) ? null : rd.GetString(10);
                        p.Card = rd.IsDBNull(11) ? null : rd.GetString(11);
                        p.Pos1 = rd.IsDBNull(12) ? null : rd.GetString(12);
                        p.TShirt_LineUp1 = rd.IsDBNull(13) ? null : rd.GetString(13);
                        p.TShirt_Sub1 = rd.IsDBNull(14) ? null : rd.GetString(14);
                        p.TShirt_LineUp2 = rd.IsDBNull(15) ? null : rd.GetString(15);
                        p.TShirt_Sub2 = rd.IsDBNull(16) ? null : rd.GetString(16);
                        list.Add(p);
                    }
                }
            }
            return list;
        }
    }
}
