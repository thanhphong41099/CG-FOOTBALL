using System.Collections.Generic;
using System.Data.SQLite;
using VLeague.Models;

namespace VLeague.Repositories
{
    public class AwayPlayersRepo : BaseRepository
    {
        public AwayPlayersRepo(SQLiteConnection c) : base(c) { }

        public void CopyFromTeam(int matchId, int teamId)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO AWAY_PLAYERS(PLAYER_ID, TEAM_ID, STT, Name, PLAY, DOB, Nationality,
                         JerseyNo, JerseyName, Position, Title, Card, Pos1,
                         TShirt_LineUp1, TShirt_Sub1, TShirt_LineUp2, TShirt_Sub2, MATCH_ID)
SELECT PLAYER_ID, TEAM_ID, STT, Name, PLAY, DOB, Nationality,
       JerseyNo, JerseyName, Position, Title, Card, Pos1,
       TShirt_LineUp1, TShirt_Sub1, TShirt_LineUp2, TShirt_Sub2, @mid
FROM PLAYERS WHERE TEAM_ID=@tid;";
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@tid", teamId);
                cmd.ExecuteNonQuery();
            }
        }

        public void SetPlayByStt(int matchId, int cutoff)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE AWAY_PLAYERS
                                    SET PLAY = CASE WHEN COALESCE(STT, 999) <= @cut THEN 1 ELSE 2 END
                                    WHERE MATCH_ID=@mid;";
                cmd.Parameters.AddWithValue("@cut", cutoff);
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStt(int matchId, int playerId, int stt)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE AWAY_PLAYERS SET STT=@stt WHERE MATCH_ID=@mid AND PLAYER_ID=@pid;";
                cmd.Parameters.AddWithValue("@stt", stt);
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@pid", playerId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<AwayPlayer> List(int matchId)
        {
            var list = new List<AwayPlayer>();
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT PLAYER_ID, TEAM_ID, STT, Name, PLAY, DOB, Nationality,
                                           JerseyNo, JerseyName, Position, Title, Card, Pos1,
                                           TShirt_LineUp1, TShirt_Sub1, TShirt_LineUp2, TShirt_Sub2, MATCH_ID
                                    FROM AWAY_PLAYERS WHERE MATCH_ID=@mid
                                    ORDER BY PLAY, COALESCE(STT, 999), PLAYER_ID;";
                cmd.Parameters.AddWithValue("@mid", matchId);
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var p = new AwayPlayer();
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
                        p.MATCH_ID = rd.GetInt32(17);
                        list.Add(p);
                    }
                }
            }
            return list;
        }
    }
}
