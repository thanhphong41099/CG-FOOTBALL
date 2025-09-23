using System.Collections.Generic;
using System.Data.SQLite;
using VLeague.Models;

namespace VLeague.Repositories
{
    public class WeatherRepo : BaseRepository
    {
        public WeatherRepo(SQLiteConnection c) : base(c) { }

        public List<WeatherItem> ByMatch(int matchId)
        {
            var list = new List<WeatherItem>();
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT MATCH_ID, CONDITION, VALUE, IMG_ID, LINK_IMAGE
                                    FROM WEATHER WHERE MATCH_ID=@mid ORDER BY CONDITION;";
                cmd.Parameters.AddWithValue("@mid", matchId);
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var w = new WeatherItem();
                        w.MATCH_ID = rd.GetInt32(0);
                        w.CONDITION = rd.IsDBNull(1) ? null : rd.GetString(1);
                        w.VALUE = rd.IsDBNull(2) ? null : rd.GetString(2);
                        w.IMG_ID = rd.IsDBNull(3) ? null : rd.GetString(3);
                        w.LINK_IMAGE = rd.IsDBNull(4) ? null : rd.GetString(4);
                        list.Add(w);
                    }
                }
            }
            return list;
        }

        public void Upsert(int matchId, string condition, string value, string imgId, string link)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"
DELETE FROM WEATHER WHERE MATCH_ID=@mid AND CONDITION=@c AND IMG_ID=@img;
INSERT INTO WEATHER(MATCH_ID, CONDITION, VALUE, IMG_ID, LINK_IMAGE)
VALUES(@mid, @c, @v, @img, @link);";
                cmd.Parameters.AddWithValue("@mid", matchId);
                cmd.Parameters.AddWithValue("@c", condition);
                cmd.Parameters.AddWithValue("@v", value);
                cmd.Parameters.AddWithValue("@img", imgId);
                cmd.Parameters.AddWithValue("@link", link);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
