using System;
using System.Collections.Generic;
using System.Linq;
using VLeague.Data;
using VLeague.Models;
using VLeague.Repositories;

namespace VLeague.Session
{
    public static class DataManager
    {
        private static readonly object SyncRoot = new object();

        private static int? _currentMatchId;

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
            lock (SyncRoot)
            {
                Teams = null;
                HomePlayers = null;
                AwayPlayers = null;
                Officials = null;
                Weather = null;
                Tactical = null;
                Scenes = null;
                _currentMatchId = null;
            }
        }

        public static IReadOnlyList<Team> GetTeams()
        {
            EnsureCommonDataLoaded();
            return Teams;
        }

        public static Team GetTeam(int teamId)
        {
            EnsureCommonDataLoaded();
            return Teams?.FirstOrDefault(t => t.TEAM_ID == teamId);
        }

        public static IReadOnlyList<SceneItem> GetScenes()
        {
            EnsureCommonDataLoaded();
            return Scenes;
        }

        public static IReadOnlyList<HomePlayer> GetHomePlayers(int matchId)
        {
            EnsureMatchDataLoaded(matchId);
            return HomePlayers;
        }

        public static IReadOnlyList<AwayPlayer> GetAwayPlayers(int matchId)
        {
            EnsureMatchDataLoaded(matchId);
            return AwayPlayers;
        }

        public static IReadOnlyList<Official> GetOfficials(int matchId)
        {
            EnsureMatchDataLoaded(matchId);
            return Officials;
        }

        public static IReadOnlyList<WeatherItem> GetWeather(int matchId)
        {
            EnsureMatchDataLoaded(matchId);
            return Weather;
        }

        public static IReadOnlyList<TacticalItem> GetTactical(int matchId)
        {
            EnsureMatchDataLoaded(matchId);
            return Tactical;
        }

        public static void LoadMatchData(int matchId)
        {
            EnsureMatchDataLoaded(matchId);
        }

        private static void EnsureCommonDataLoaded()
        {
            if (Teams != null && Scenes != null) return;

            lock (SyncRoot)
            {
                if (Teams != null && Scenes != null) return;

                var conn = Db.GetConnection();

                if (Teams == null)
                {
                    var teamsRepo = new TeamsRepo(conn);
                    Teams = teamsRepo.GetAll();
                }

                if (Scenes == null)
                {
                    var scenesRepo = new ScenesRepo(conn);
                    Scenes = scenesRepo.GetAll();
                }
            }
        }

        private static void EnsureMatchDataLoaded(int matchId)
        {
            if (_currentMatchId == matchId &&
                HomePlayers != null &&
                AwayPlayers != null &&
                Officials != null &&
                Weather != null &&
                Tactical != null)
            {
                return;
            }

            lock (SyncRoot)
            {
                if (_currentMatchId != matchId)
                {
                    HomePlayers = null;
                    AwayPlayers = null;
                    Officials = null;
                    Weather = null;
                    Tactical = null;
                }

                if (HomePlayers != null &&
                    AwayPlayers != null &&
                    Officials != null &&
                    Weather != null &&
                    Tactical != null &&
                    _currentMatchId == matchId)
                {
                    return;
                }

                EnsureCommonDataLoaded();

                var conn = Db.GetConnection();

                var homeRepo = new HomePlayersRepo(conn);
                var awayRepo = new AwayPlayersRepo(conn);
                var officialsRepo = new OfficialsRepo(conn);
                var weatherRepo = new WeatherRepo(conn);
                var tacticalRepo = new TacticalRepo(conn);

                HomePlayers = homeRepo.List(matchId);
                AwayPlayers = awayRepo.List(matchId);
                Officials = officialsRepo.ByMatch(matchId);
                Weather = weatherRepo.ByMatch(matchId);
                Tactical = tacticalRepo.ByMatch(matchId);

                _currentMatchId = matchId;
            }
        }
    }
}
