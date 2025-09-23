// /Data/Db.cs
using System.Data.SQLite;

static class Db
{
    public static SQLiteConnection Open(string dbPath)
    {
        // dbPath bắt buộc truyền từ SetupUC
        var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "PRAGMA foreign_keys=ON; PRAGMA journal_mode=WAL;";
            cmd.ExecuteNonQuery();
        }
        return conn;
    }
}
