using System;
using System.Collections.Generic;
using System.Data.SQLite;
using VLeague.Models;
using VLeague.Repositories;
using VLeague.Data;

namespace VLeague.Session
{
    public static class DataManager
    {
        // Cache dữ liệu để tái sử dụng
        public static List<Team> Teams { get; private set; }
        public static List<HomePlayer> HomePlayers { get; private set; }
        public static List<AwayPlayer> AwayPlayers { get; private set; }
        public static List<Official> Officials { get; private set; }
        public static List<WeatherItem> Weather { get; private set; }
        public static List<TacticalItem> Tactical { get; private set; }
        public static List<SceneItem> Scenes { get; private set; }

        // Clear cache khi chuyển trận khác
        public static void ClearCache()
        {
            Teams = null;
            HomePlayers = null;
            AwayPlayers = null;
            Officials = null;
            Weather = null;
            Tactical = null;
            Scenes = null;
        }
    }
}
