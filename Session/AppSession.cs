// /Session/AppSession.cs
using System.Drawing;

sealed class AppSession
{
    public string DbPath { get; set; }          // set từ SetupUC (file picker)
    public int? CurrentMatchId { get; set; }
    public int? HomeTeamId { get; set; }
    public int? AwayTeamId { get; set; }
    public Color? HomeColor { get; set; }       // "R,G,B" parse về Color
    public Color? AwayColor { get; set; }
    public string CgIp { get; set; } 
    public int CgPort { get; set; } 
    public string LogPath { get; set; }
}
