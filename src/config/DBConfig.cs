using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VLeague.src.helper;
using static System.Net.Mime.MediaTypeNames;

namespace VLeague
{
    internal class DBConfig
    {
        private static OleDbConnection oledbConnection;
        private static OleDbDataAdapter oledbAdapter;
        private static string oledbConnString;

        public static OleDbCommand oledbCommand;

        public static Handler handle = new Handler();

        public static DataSet teams, matchInfoTeam, colorRGB;

        public static DataTable AllTeams, homeTeam, awayTeam;

        public static DataTable playersTeam;

        public static DataSet tactical;

        public static DataSet matchDetail;

        public static DataTable statistics;

        public static DataSet tournaments;

        public static DataSet weather;

        public static DataSet referee;

        public static DataTable ranking;

        public static DataSet layerDataset;

        public static DataSet MC;
        public static DataSet DiaDiem;
        public static DataSet TinTuc;
        public static DataSet PhatBieu;

        //Funtional use to create connection to Access DB
        public static void Connection(string dataPath)
        {
            try
            {
                oledbConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dataPath;
                oledbConnection = new OleDbConnection(oledbConnString);
                oledbConnection.Open();
                FrmKarismaMenu.FrmSetting.OnLogMessage("ODBC Connected!");
            }
            catch (Exception ex)
            {
                Handler.handlerError("Connection",ex);
            }
        }
        // The genneric funtional to use is a components do get data
        public static void doGet(string query, ref DataSet dataSet)
        {
            try
            {
                dataSet = new DataSet();
                dataSet.Clear();
                oledbAdapter = new OleDbDataAdapter(query, oledbConnection);
                oledbAdapter.Fill(dataSet);
            }catch (Exception ex)
            {
                Handler.handlerError("doGet", ex);
            }
        }
        // The genneric funtional to use is a components do get datatable
        public static void doGet(string query, ref DataTable dataTable)
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                oledbAdapter = new OleDbDataAdapter(query, oledbConnString);
                oledbAdapter.Fill(dataTable);
            }catch (Exception ex)
            {
                Handler.handlerError("doGetTable", ex);
            }
        }
        // Find list teams from table TEAM_ID 
        public static void Listteams()
        {
            doGet("SELECT * FROM TEAM_ID", ref teams);
        }
        public static string doGetTeamID(string name, string column1, string column)
        {
            try
            {
                doGet("SELECT * FROM TEAM_ID", ref teams);

                foreach (DataRow row in teams.Tables[0].Rows)
                {
                    if (row[column1].ToString() == name)
                    {
                        return row[column].ToString();
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        public static string doGetStringTeamID(string name, string column)
        {
            try
            {
                doGet("SELECT * FROM TEAM_ID", ref teams);

                foreach (DataRow row in teams.Tables[0].Rows)
                {
                    if (row["MaDoi"].ToString() == name)
                    {
                        return row[column].ToString();
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        public static string doGetStringRGB(string name, string column)
        {
            try
            {
                doGet("SELECT * FROM RGB", ref colorRGB);

                foreach (DataRow row in colorRGB.Tables[0].Rows)
                {
                    if (row["Code"].ToString() == name)
                    {
                        return row[column].ToString();
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        public static string doGetStringMatchInfo(string name, string column)
        {
            try
            {
                doGet("SELECT * FROM MATCH_INFO", ref matchInfoTeam);

                foreach (DataRow row in matchInfoTeam.Tables[0].Rows)
                {
                    if (row["CLOCK_NAME"].ToString() == name)
                    {
                        return row[column].ToString();
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        public static void doGetAllTeams()
        {

            doGet("SELECT * FROM TEAM_ID", ref AllTeams);
            
        }
        public static void HomeTeam()
        {
            doGet("SELECT * FROM HOME_PLAYERS", ref homeTeam);
        }
        public static void AwayTeam()
        {
            doGet("SELECT * FROM AWAY_PLAYERS", ref awayTeam);
        }
        public static void getMatchInfo()
        {
            doGet("SELECT * FROM MATCH_INFO", ref matchInfoTeam);
        }
        //Update player of team from datagridview
        public static void updatePlayersTeam(int ID, string code, string name, int stt, int soao, string tenao, int play, string pos, string card, string image, string path)
        {
            try
            {
                // Đảm bảo rằng tất cả tên cột có dấu cách được bao quanh bởi dấu ngoặc vuông
                oledbCommand = new OleDbCommand("Update DANHSACHCAUTHU set Name = @name, STT = @stt, [Jersey #] = @soao, [Jersey Name] = @tenao, [PLAY] = @play, [Position] = @pos, [Card] = @card, [IMAGE] = @image, [PATH] = @path where ID = @ID", oledbConnection);
                oledbCommand.CommandType = CommandType.Text;

                oledbCommand.Parameters.Add("@name", OleDbType.VarWChar).Value = (object)name ?? DBNull.Value;
                oledbCommand.Parameters.Add("@stt", OleDbType.Integer).Value = (object)stt ?? DBNull.Value;
                oledbCommand.Parameters.Add("@soao", OleDbType.Integer).Value = (object)soao ?? DBNull.Value;
                oledbCommand.Parameters.Add("@tenao", OleDbType.VarWChar).Value = (object)tenao ?? DBNull.Value;
                oledbCommand.Parameters.Add("@play", OleDbType.Integer).Value = (object)play == null || play == 0 ? DBNull.Value : (object)play ?? DBNull.Value;
                oledbCommand.Parameters.Add("@pos", OleDbType.VarWChar).Value = (object)pos ?? DBNull.Value;
                oledbCommand.Parameters.Add("@card", OleDbType.VarWChar).Value = (object)card ?? DBNull.Value;
                oledbCommand.Parameters.Add("@image", OleDbType.VarWChar).Value = (object)image ?? DBNull.Value;
                oledbCommand.Parameters.Add("@path", OleDbType.VarWChar).Value = (object)path ?? DBNull.Value;

                oledbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = (object)ID ?? DBNull.Value;
                oledbCommand.ExecuteNonQuery();
                oledbCommand.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void insertPlayer(int ID, string code, string name, int stt, int soao, string tenao, int play, string pos, string card, string image, string path)
        {
            try
            {
                string query = "INSERT INTO DANHSACHCAUTHU (ID, CODE, Name, STT, [Jersey #], [Jersey Name], [PLAY], [Position], [Card], [IMAGE], [PATH]) VALUES (@ID, @code, @name, @stt, @soao, @tenao, @play, @pos, @card, @image, @path)";

                oledbCommand = new OleDbCommand(query, oledbConnection);
                oledbCommand.CommandType = CommandType.Text;

                oledbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = (object)ID ?? DBNull.Value;

                oledbCommand.Parameters.Add("@code", OleDbType.VarWChar).Value = (object)code ?? DBNull.Value;
                oledbCommand.Parameters.Add("@name", OleDbType.VarWChar).Value = (object)name ?? DBNull.Value;
                oledbCommand.Parameters.Add("@stt", OleDbType.Integer).Value = (object)stt ?? DBNull.Value;
                oledbCommand.Parameters.Add("@soao", OleDbType.Integer).Value = (object)soao ?? DBNull.Value;
                oledbCommand.Parameters.Add("@tenao", OleDbType.VarWChar).Value = (object)tenao ?? DBNull.Value;
                oledbCommand.Parameters.Add("@play", OleDbType.Integer).Value = play == 0 ? DBNull.Value : (object)play;
                oledbCommand.Parameters.Add("@pos", OleDbType.VarWChar).Value = (object)pos ?? DBNull.Value;
                oledbCommand.Parameters.Add("@card", OleDbType.VarWChar).Value = (object)card ?? DBNull.Value;
                oledbCommand.Parameters.Add("@image", OleDbType.VarWChar).Value = (object)image ?? DBNull.Value;
                oledbCommand.Parameters.Add("@path", OleDbType.VarWChar).Value = (object)path ?? DBNull.Value;

                oledbCommand.ExecuteNonQuery();
                oledbCommand.Dispose();

                MessageBox.Show($"Đã thêm cầu thủ mới: {name}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool isPlayerExist(int ID)
        {
            try
            {
                // Tạo câu lệnh SQL kiểm tra sự tồn tại của hàng theo ID
                oledbCommand = new OleDbCommand("SELECT COUNT(*) FROM DANHSACHCAUTHU WHERE ID = @ID", oledbConnection);
                oledbCommand.CommandType = CommandType.Text;
                oledbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = ID;

                // Run và get KQ
                int count = (int)oledbCommand.ExecuteScalar();
                oledbCommand.Dispose();

                // Nếu số lượng lớn hơn 0 thì hàng tồn tại
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        //Update team info when setup homeTeam or awayTeam
        public static void updateTeamInfo(string teamCode, string longName ,
            string shortName , string coach , string logo, string gk_color , string player_color) 
        {
            try
            {
                oledbCommand = new OleDbCommand("Update TEAM_ID set TenDai = @tendai, TenNgan = @tenngan, HLV = @hlv, Logo = @logo where MaDoi = @madoi", oledbConnection);
                oledbCommand.CommandType = CommandType.Text;
                oledbCommand.Parameters.Add("@tendai", OleDbType.VarWChar).Value = longName;
                oledbCommand.Parameters.Add("@tenngan", OleDbType.VarWChar).Value = shortName;
                oledbCommand.Parameters.Add("@hlv", OleDbType.VarWChar).Value = coach;
                oledbCommand.Parameters.Add("@logo", OleDbType.VarWChar).Value = logo;

                oledbCommand.Parameters.Add("@madoi", OleDbType.VarWChar).Value = teamCode;
                oledbCommand.ExecuteNonQuery();
                oledbCommand.Dispose();
            }catch (Exception ex)
            {
                Handler.handlerError("updateTeamInfo", ex);
            }
        }

        // Get players list of Team by TeamCode
        public static void doGetPlayersTeam(string teamCode)
        {
            doGet("SELECT * FROM DANHSACHCAUTHU WHERE CODE = '" + teamCode + "'", ref playersTeam);
        }
        //Query get tactical list from table Tacical 
        private static void doGetTacticals()
        {
            try
            {
                doGet("SELECT * FROM TACTIC", ref tactical);
            }catch ( Exception ex )
            {
                Handler.handlerError("doGetTacticals", ex);
            }
        }
        //funtional use get Match info of Static
        public static void goGetMatchInfoDetail()
        {
            try
            {
                doGet("SELECT * FROM THONGKE",ref matchDetail);
            }catch ( Exception ex)
            {
                Handler.handlerError("goGetMatchInfoDetail", ex);
            }
        }
        //Funtional use generic to matching data
        public static void matchingMatchDetailCombobox(ComboBox cbb)
        {
            goGetMatchInfoDetail();
            foreach (DataRow dt in matchDetail.Tables[0].Rows)
            {
                cbb.Items.Add(dt["Tieude"].ToString());
            }
        }
        //Matching data to combobox tactical
        public static void matchingTacticalCombobox(ComboBox cbb)
        {
            try
            {
                doGetTacticals();
                foreach (DataRow dt in tactical.Tables[0].Rows)
                {
                    cbb.Items.Add(dt["Name"].ToString());
                }
            }catch (Exception ex)
            {
                Handler.handlerError("matchingCombobox", ex);
            }
        }
        //Funtion use get all player from DANHSACHCAUTHU


        public static void doGetAllStatistics()
        {
            try
            {
                doGet("SELECT * FROM THONGKE", ref statistics);

                // Sắp xếp DataTable theo cột STT từ thấp đến cao
                statistics = statistics.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                Handler.handlerError("doGetAllStatistics", ex);
            }
        }
        public static void updateMatchID(int ID, string text)
        {
            try
            {
                oledbCommand = new OleDbCommand("Update MATCHID set Name = @text where ID = @ID", oledbConnection);
                oledbCommand.CommandType = CommandType.Text;
                oledbCommand.Parameters.Add("@text", OleDbType.VarWChar).Value = text;
                oledbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = ID;
                oledbCommand.ExecuteNonQuery();
                oledbCommand.Dispose();
            }
            catch (Exception ex)
            {
                Handler.handlerError("updateMatchID", ex);
                MessageBox.Show("Lỗi cập nhật bảng Match ID: " + ex.Message);
            }
        }

        public static void updateWeather(int ID, string text)
        {
            try
            {
                oledbCommand = new OleDbCommand("Update THOITIET set Name = @text where ID = @ID", oledbConnection);
                oledbCommand.CommandType = CommandType.Text;
                oledbCommand.Parameters.Add("@text", OleDbType.VarWChar).Value = text;
                oledbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = ID;
                oledbCommand.ExecuteNonQuery();
                oledbCommand.Dispose();
            }
            catch (Exception ex)
            {
                Handler.handlerError("updateWeather", ex);
                MessageBox.Show("Lỗi cập nhật bảng Thời Tiết: " + ex.Message);
            }
        }

        public static void UpdateReferee(string Label, string text)
        {
            try
            {
                oledbCommand = new OleDbCommand("Update TRONGTAI set Name = @text where Label = @Label", oledbConnection);
                oledbCommand.CommandType = CommandType.Text;
                oledbCommand.Parameters.Add("@text", OleDbType.VarWChar).Value = text;
                oledbCommand.Parameters.Add("@Label", OleDbType.VarWChar).Value = Label;
                oledbCommand.ExecuteNonQuery();
                oledbCommand.Dispose();
            }
            catch (Exception ex)
            {
                Handler.handlerError("updateReferee", ex);
                MessageBox.Show("Lỗi cập nhật bảng TRỌNG TÀI: " + ex.Message);
            }
        }

        public static void updateStatisticTieude(string tieude, string chiso1, string chiso2)
        {
            try
            {
                oledbCommand = new OleDbCommand("Update THONGKE set ChiSo1 = @chiso1, ChiSo2 = @chiso2 where Tieude = @tieude", oledbConnection);
                oledbCommand.CommandType = CommandType.Text;
                oledbCommand.Parameters.Add("@tieude", OleDbType.VarWChar).Value = tieude;
                oledbCommand.Parameters.Add("@chiso1", OleDbType.VarWChar).Value = chiso1;
                oledbCommand.Parameters.Add("@chiso2", OleDbType.VarWChar).Value = chiso2;
                oledbCommand.ExecuteNonQuery();
                oledbCommand.Dispose();
            }
            catch (Exception ex)
            {
                Handler.handlerError("updateStatistic", ex);
            }
        }

        public static void updateStatistic(int stt, string tieude, string chiso1, string chiso2)
        {
            try
            {
                oledbCommand = new OleDbCommand("Update THONGKE set Tieude = @tieude, ChiSo1 = @chiso1, ChiSo2 = @chiso2 where STT = @stt", oledbConnection);
                oledbCommand.CommandType = CommandType.Text;
                oledbCommand.Parameters.Add("@tieude", OleDbType.VarWChar).Value = tieude;
                oledbCommand.Parameters.Add("@chiso1", OleDbType.VarWChar).Value = chiso1;
                oledbCommand.Parameters.Add("@chiso2", OleDbType.VarWChar).Value = chiso2;
                oledbCommand.Parameters.Add("@stt", OleDbType.Integer).Value = stt;
                oledbCommand.ExecuteNonQuery();
                oledbCommand.Dispose();
            }
            catch (Exception ex)
            {
                Handler.handlerError("updateStatistic", ex);
            }
        }
        public static void doGetInfoTournaments()
        {
            try
            {
                doGet("SELECT * FROM MATCHID", ref tournaments);
            }catch (Exception ex)
            {
                Handler.handlerError("doGetInfoTournaments", ex);
                MessageBox.Show(ex.Message);
            }
           
        }
        public static void doGetInfoWeather()
        {
            try
            {
                doGet("SELECT * FROM THOITIET", ref weather);
            }
            catch (Exception ex)
            {
                Handler.handlerError("doGetInfoTournaments", ex);
                MessageBox.Show(ex.Message);
            }

        }
        public static void doGetInforeferee()
        {
            try
            {
                doGet("SELECT * FROM TRONGTAI", ref referee);
            }
            catch (Exception ex)
            {
                Handler.handlerError("doGetInfoTournaments", ex);
                MessageBox.Show(ex.Message);
            }

        }
        public static void doGetSoccerRanking()
        {
            try
            {
                doGet("SELECT * FROM BANGXEPHANG", ref ranking);

                // Sắp xếp DataTable theo cột STT từ thấp đến cao
                ranking.DefaultView.Sort = "STT ASC";
                ranking = ranking.DefaultView.ToTable();
            }
            catch (Exception ex)
            {
                Handler.handlerError("doGetSoccerRanking", ex);
            }
        }
        public static void updateBXH(int stt, string maDoi, string tenDoi, int diem, int tran, int t, int b, int h, string hs)
        {
            try
            {
                oledbCommand = new OleDbCommand("UPDATE BANGXEPHANG SET [STT] = @stt, TenDoi = @tenDoi, Diem = @diem, Tran = @tran, T = @t, B = @b, H = @h, HS = @hs WHERE MaDoi = @maDoi", oledbConnection);
                oledbCommand.CommandType = CommandType.Text;
                oledbCommand.Parameters.Add("@stt", OleDbType.Integer).Value = stt;
                oledbCommand.Parameters.Add("@tenDoi", OleDbType.VarWChar).Value = tenDoi;
                oledbCommand.Parameters.Add("@diem", OleDbType.Integer).Value = diem;
                oledbCommand.Parameters.Add("@tran", OleDbType.Integer).Value = tran;
                oledbCommand.Parameters.Add("@t", OleDbType.Integer).Value = t;
                oledbCommand.Parameters.Add("@b", OleDbType.Integer).Value = b;
                oledbCommand.Parameters.Add("@h", OleDbType.Integer).Value = h;
                oledbCommand.Parameters.Add("@hs", OleDbType.VarWChar).Value = hs;
                oledbCommand.Parameters.Add("@maDoi", OleDbType.VarWChar).Value = maDoi;


                oledbCommand.ExecuteNonQuery();
                oledbCommand.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật dữ liệu: {ex.Message}");
            }
        }
        //Hàm cập nhật ChiSo1 và ChiSo2 trong bảng THONGKE theo giá trị cột Tieude
        public static void UpdateStatisticByTitle(string title, string chiso1, string chiso2)
        {
            try
            {
                oledbCommand = new OleDbCommand("UPDATE THONGKE SET ChiSo1 = @chiso1, ChiSo2 = @chiso2 WHERE Tieude = @tieude", oledbConnection);
                oledbCommand.CommandType = CommandType.Text;
                oledbCommand.Parameters.Add("@chiso1", OleDbType.VarWChar).Value = chiso1;
                oledbCommand.Parameters.Add("@chiso2", OleDbType.VarWChar).Value = chiso2;
                oledbCommand.Parameters.Add("@tieude", OleDbType.VarWChar).Value = title;
                oledbCommand.ExecuteNonQuery();
                oledbCommand.Dispose();
            }
            catch (Exception ex)
            {
                Handler.handlerError("UpdateStatisticByTitle", ex);
            }
        }
        public static void doGetInfoLayer()
        {
            try
            {
                doGet("SELECT * FROM Layer", ref layerDataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static string doGetStringValue(string name, string column)
        {
            try
            {
                doGet("SELECT * FROM Layer", ref layerDataset);

                foreach (DataRow row in layerDataset.Tables[0].Rows)
                {
                    if (row["Name"].ToString() == name)
                    {
                        return row[column].ToString();
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        public static int doGetIntValue(string name, string column)
        {

            doGet("SELECT * FROM Layer", ref layerDataset);
            foreach (DataRow row in layerDataset.Tables[0].Rows)
            {
                if (row["Name"].ToString() == name)
                {
                    return int.Parse(row[column].ToString());
                }
            }
            return 0;
        }
        public static void doGetInfoMC()
        {
            try
            {
                doGet("SELECT * FROM MC", ref MC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void doGetInfoDiaDiem()
        {
            try
            {
                doGet("SELECT * FROM DiaDiem", ref DiaDiem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void doGetTinTuc()
        {
            doGet("Select * from TinTuc Order by STT", ref TinTuc);
        }
        public static void doGetPhatBieu()
        {
            doGet("Select * from PhatBieu", ref PhatBieu);
        }
    }
}
