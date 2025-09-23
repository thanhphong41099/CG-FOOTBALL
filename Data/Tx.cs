// /Data/Tx.cs
using System;
using System.Data.SQLite;

static class Tx
{
    public static void Run(SQLiteConnection conn, Action<SQLiteTransaction> work)
    {
        var tx = conn.BeginTransaction();
        try { work(tx); tx.Commit(); }
        catch (Exception ex) { Logger.Error("Tx rollback", ex); try { tx.Rollback(); } catch { } throw; }
    }
}
