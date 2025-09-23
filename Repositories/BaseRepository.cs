using System;
using System.Data.SQLite;

namespace VLeague.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly SQLiteConnection Conn;
        protected BaseRepository(SQLiteConnection conn) { Conn = conn; }

        protected int Exec(string sql, Action<SQLiteCommand> bind)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (bind != null) bind(cmd);
                return cmd.ExecuteNonQuery();
            }
        }

        protected T Scalar<T>(string sql, Action<SQLiteCommand> bind)
        {
            using (var cmd = Conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (bind != null) bind(cmd);
                var val = cmd.ExecuteScalar();
                if (val == null || val == DBNull.Value) return default(T);
                return (T)Convert.ChangeType(val, typeof(T));
            }
        }
    }
}
