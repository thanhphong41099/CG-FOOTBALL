// /Logger/Logger.cs
using System;
using System.IO;

static class Logger
{
    static readonly object _lock = new object();
    static string _path;

    public static void Init(string path)
    {
        if (!string.IsNullOrWhiteSpace(path)) _path = path;
        var dir = Path.GetDirectoryName(_path);
        if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
    }

    public static void Info(string msg) => Write("INFO", msg);
    public static void Error(string msg, Exception ex = null) => Write("ERROR", $"{msg} | {ex}");

    static void Write(string level, string msg)
    {
        lock (_lock)
            File.AppendAllText(_path, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {msg}{Environment.NewLine}");
    }
}
