using System.Collections.Generic;
using System.Data.SQLite;
using VLeague.Models;

namespace VLeague.Repositories
{
    public class ScenesRepo : BaseRepository
    {
        public ScenesRepo(SQLiteConnection c) : base(c) { }

        public List<SceneItem> GetAll()
        {
            var list = new List<SceneItem>();
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT SCENE_ID, SCENE_NAME, PATH, LAYER FROM SCENE_LAYERS
                                    ORDER BY LAYER, SCENE_NAME;";
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var s = new SceneItem();
                        s.SCENE_ID = rd.GetInt32(0);
                        s.SCENE_NAME = rd.IsDBNull(1) ? null : rd.GetString(1);
                        s.PATH = rd.IsDBNull(2) ? null : rd.GetString(2);
                        s.LAYER = rd.IsDBNull(3) ? 0 : rd.GetInt32(3);
                        list.Add(s);
                    }
                }
            }
            return list;
        }
    }
}
