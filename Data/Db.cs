// /Data/Db.cs
using System;
using System.Data.SQLite;

static class Db
{
    // Kết nối tối giản tới file .db SQLite
    public static SQLiteConnection Open(string dbPath)
    {
        if (string.IsNullOrWhiteSpace(dbPath))
            throw new ArgumentException("dbPath rỗng.");

        var conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;");
        conn.Open();
        return conn;
    }
}
