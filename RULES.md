# RULES.md — WinForms .NET Framework 4.7.2 (C#) — VLeague Controller

**Target**: Single-solution, single-project WinForms app on .NET Framework 4.7.2.  
**DB**: SQLite (`System.Data.SQLite` ADO.NET). One `.db` file per league per session.  
**Style**: .net framework 4.7.2 features only. No nullable reference types. No async `Main`.  

---

## 0) Solution layout (mandatory)

```
/Logger/Logger.cs
/Session/AppSession.cs
/Data/Db.cs
/Data/Tx.cs
/Repositories/BaseRepository.cs
/Repositories/TeamsRepo.cs
/Repositories/PlayersRepo.cs
/Repositories/MatchesRepo.cs
/Repositories/HomePlayersRepo.cs
/Repositories/AwayPlayersRepo.cs
/Repositories/OfficialsRepo.cs
/Repositories/WeatherRepo.cs
/Repositories/TacticalRepo.cs
/Repositories/ScenesRepo.cs
/Repositories/GroupStandingRepo.cs
/Models/Team.cs
/Models/Player.cs
/Models/Match.cs
/Models/HomePlayer.cs
/Models/AwayPlayer.cs
/Models/Official.cs
/Models/WeatherItem.cs
/Models/TacticalItem.cs
/Models/SceneItem.cs
/Models/GroupStanding.cs
/Models/MatchStatic.cs
/UI/SetupUC.cs
/UI/DataUC.cs
```

- **No** `ConfigurationManager`. All runtime values flow through `AppSession`.
- Logger writes to text file. Path chosen at runtime.  
- One `SQLiteConnection` opened per operation scope. Use `Tx.Run` for grouped writes.

---

## 1) Framework and packages

- Target framework: **.NET Framework 4.7.2**.  
- NuGet: `System.Data.SQLite.Core` (ADO.NET provider).  
- Set `x86` or `x64` consistently with provider binaries.

---

## 2) Runtime configuration (via AppSession)

- `DbPath` (required). Set from SetupUC file picker.  
- `CgIp`, `CgPort`: defaults `127.0.0.1` and `30001`.  
- `LogPath`: default `logs\\app.log`.  
- `CurrentMatchId`, `HomeTeamId`, `AwayTeamId`, `HomeColor`, `AwayColor` held in memory.  
- Colors are stored in DB as TEXT: `"R,G,B"`. Convert to/from `System.Drawing.Color`.

---

## 3) Database rules

- Open conn: `new SQLiteConnection($"Data Source={dbPath};Version=3;")` then:
  - `PRAGMA foreign_keys=ON;`
  - `PRAGMA journal_mode=WAL;`
- All multi-table writes wrapped by `Tx.Run(conn, tx => { ... })`. On error → rollback and log.
- Date-time: `MATCHES.MATCH_DAY` is TEXT `"YYYY-MM-DD HH:MM"` (local). No timezone logic.
- `MATCHES` schema (final):  
  `MATCH_ID (PK), ROUND, MATCH_DAY, STADIUM, TOURNAMENT, HOME_TEAM, AWAY_TEAM, HOME_COLOR, AWAY_COLOR`  
  `HOME_COLOR/AWAY_COLOR` format `"R,G,B"`.
- `HOME_PLAYERS` and `AWAY_PLAYERS` **must contain** `MATCH_ID` to log per match.
- `PLAY` values: `1` = starters (exactly 11), `2` = bench.  
- `STT` is the on-field order for layout. Update immediately on drag-drop.
- `TACTICAL` bound by `(MATCH_ID, TEAM_ID)` with `TACTICAL_TEXT` preset list.
- `SCENE_LAYERS` provides scene name, path, and layer (0–3).

---

## 4) Repositories (contracts)

- **TeamsRepo**
  - `List<Team> GetAll()`
  - `Team Get(int teamId)`

- **PlayersRepo**
  - `List<Player> ByTeam(int teamId)`

- **MatchesRepo**
  - `List<Match> GetAll()`
  - `Match Get(int matchId)`
  - `int Insert(Match m)`  // returns `MATCH_ID`
  - `void UpdateColors(int matchId, string homeRgb, string awayRgb)`

- **HomePlayersRepo / AwayPlayersRepo**
  - `void CopyFromTeam(int matchId, int teamId)`  // clone PLAYERS -> HOME/AWAY
  - `void SetPlayByStt(int matchId, int cutoff = 11)`  // STT<=11 → PLAY=1 else 2
  - `void UpdateStt(int matchId, int playerId, int stt)`
  - `List<HomePlayer/AwayPlayer> List(int matchId)`

- **OfficialsRepo**
  - CRUD by `MATCH_ID`

- **WeatherRepo**
  - CRUD by `MATCH_ID`

- **TacticalRepo**
  - `void Upsert(int matchId, int teamId, string tacticalText)`
  - `string Get(int matchId, int teamId)`

- **ScenesRepo**
  - `List<SceneItem> GetAll()`

- **GroupStandingRepo**
  - `List<GroupStanding> GetAll()`

---

## 5) Models (shape)

- Use POCO classes with public fields or auto-properties. No nullable reference types.
- `Match.HomeColor` and `.AwayColor` stored as string `"R,G,B"` in DB. In-memory:
  - `struct Rgb { public int R; public int G; public int B; }` (optional).
  - Provide helper converters.

---

## 6) UI workflow (high level)

### SetupUC
1. **Connect CG**: store IP/Port in session. Log status.
2. **Select league DB**: pick `.db` → set `session.DbPath` → open test query.
3. **Validate DB**: show read-only grids for `MATCHES`, `OFFICIALS`, `WEATHER`.
4. **Load scenes**: list `SCENE_LAYERS`.

### DataUC
1. **Select match**: combobox bound to `MATCHES` → set `session.CurrentMatchId`.
2. **Select Home/Away teams**: two combo boxes bound to `TEAM_ID`. Show logo, coach.
3. **Set tactical**: two combos from fixed list → store via `TacticalRepo.Upsert`.
4. **Pick kits**: two color pickers → save to `MATCHES.HOME_COLOR/AWAY_COLOR` (format `"R,G,B"`). Update session.
5. **Load players**: if empty for `matchId`, `CopyFromTeam(matchId, teamId)` for Home and Away; then `SetPlayByStt(matchId, 11)`.
6. **Arrange lineup**:
   - Two DataGridViews (Home/Away) editable.
   - Drag-drop rows updates `STT` immediately.
   - Validation: must have **exactly 11 rows with `PLAY=1`** per team.
7. **Officials/Weather**: edit in their tabs tied to `MATCH_ID`.
8. **Finalize**: if validation passes (teams selected, kits set, tactics set, 11 starters each) → ready for CG control.

---

## 7) Error policy (simple)

- On DB error: rollback transaction, log with `Logger.Error`, show `MessageBox.Show("Không lưu được. Xem log.")`.
- No automatic retry. User repeats action.
- All repository write operations must be wrapped in `Tx.Run` for atomicity.

---

## 8) Coding constraints (C# 7.3 / .NET 4.7.2)

- Use `using` statements (no `await using`).  
- No `async Main`. UI async via `BackgroundWorker` or `Task.Run` + `Invoke` to UI thread.  
- No nullable reference types. Use classic null checks.  
- Avoid modern features not supported (records, `Span<T>`, `IAsyncEnumerable<>`, etc.).

---

## 9) Conventions

- PascalCase for class/methods, camelCase for locals/parameters.  
- Keep repository methods narrow and side-effect free outside of transactions.  
- Log each user-triggered write operation (who/when/what).  
- All paths stored in DB should be absolute or have a single base folder configured elsewhere.  
- Keep UI event handlers thin; delegate to repositories/services.

---

## 10) Ready checklist per match

- `HomeTeamId` and `AwayTeamId` set.  
- `TACTICAL` exists for both teams.  
- `HOME_COLOR` and `AWAY_COLOR` set in `MATCHES`.  
- `HOME_PLAYERS` and `AWAY_PLAYERS` present for `MATCH_ID`.  
- Exactly **11** with `PLAY=1` for each team.  
- Scene configs loaded.
