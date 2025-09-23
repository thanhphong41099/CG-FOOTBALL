// /Data/Db.cs
using System;
using System.Data.SQLite;

namespace VLeague.Data
{
    public static class Db
    {
        private static SQLiteConnection _connection;

        // Mở và giữ kết nối một lần, dùng lại suốt app
        public static void Connect(string dbPath)
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }

            _connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            _connection.Open();

            using (var cmd = new SQLiteCommand("PRAGMA foreign_keys=ON; PRAGMA journal_mode=WAL;", _connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static SQLiteConnection GetConnection()
        {
            if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
                throw new Exception("Database connection is not open.");
            return _connection;
        }

        public static void Close()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
