// /Data/Tx.cs
using System;
using System.Data.SQLite;

// Thực hiện các thao tác WRITE trên nhiều bảng ở đây,
// sử dụng transaction tx để đảm bảo tất cả hoặc không thao tác nào.
static class Tx
{
    public static void Run(SQLiteConnection conn, Action<SQLiteTransaction> work)
    {
        var tx = conn.BeginTransaction();
        try { work(tx); tx.Commit(); }
        catch (Exception ex) { Logger.Error("Tx rollback", ex); try { tx.Rollback(); } catch { } throw; }
    }
}
