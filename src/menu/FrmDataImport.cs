using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using VLeague.src.helper;
using VLeague.src.model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VLeague.src.menu
{
    public partial class FrmDataImport : Form
    {
        public static string homeCode, homeTactical, homeTenDai, homeTenNgan, homeHLV, homeLogo, homeLogoIn, homeLogoOut;

        public static string awayCode, awayTactical, awayTenDai, awayTenNgan, awayHLV, awayLogo, awayLogoIn, awayLogoOut;

        private ColorDialog colorDialog;

        private static string workingPath = "WORKINGFOLDER";

        private static string key = "CONNECT";

        private static string PATH = AppConfig.ConfigReader.ReadString(key, workingPath);


        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        private DataGridViewRow rowToMove;
        private int previousRowIndex = -1;
        private bool isDragging = false;

        public FrmDataImport()
        {
            InitializeComponent();
            colorDialog = new ColorDialog();
            loadDgvAllTeam();
            InitializeComboBoxes();
        }

        private void FrmDataImport_Load(object sender, EventArgs e)
        {
            try
            {
                DBConfig.Listteams();
                foreach (DataRow dt in DBConfig.teams.Tables[0].Rows)
                {
                    cbbHomeTeam.Items.Add(dt[2].ToString());
                    cbbAwayTeam.Items.Add(dt[2].ToString());
                }
                DBConfig.matchingTacticalCombobox(cbbAwayTactic);
                DBConfig.matchingTacticalCombobox(cbbHomeTactic);
                cbbHomeTactic.SelectedIndex = 0;
                cbbAwayTactic.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi load dữ liệu: " + ex.Message + ", kiểm tra đường dẫn Setup", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbbHomeTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            TeamInfor.homeTenNgan = homeTenNgan = cbbHomeTeam.Text;
            LoadTeamInfoHome();
            cbbPlayerIcon1.SelectedIndex = 0;
            Player_HomeColor.BackColor = GetColorFromCbbHome("1");
            cbbGKIcon1.SelectedIndex = 1;
            GK_HomeColor.BackColor = GetColorFromCbbHome("2");

        }

        private void cbbAwayTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            TeamInfor.awayTenNgan = awayTenNgan = cbbAwayTeam.Text;
            LoadTeamInfoAway();
            cbbPlayerIcon2.SelectedIndex = 2;
            Player_AwayColor.BackColor = GetColorFromCbbAway("3");
            cbbGKIcon2.SelectedIndex = 3;
            GK_AwayColor.BackColor = GetColorFromCbbAway("4");

        }
        private void LoadTeamInfoHome()
        {
            TeamInfor.homeCode = homeCode = DBConfig.doGetTeamID(TeamInfor.homeTenNgan, "TenNgan", "MaDoi");

            homeTenDai = DBConfig.doGetStringTeamID(homeCode, "TenDai");

            homeHLV = DBConfig.doGetStringTeamID(homeCode, "HLV");

            homeLogo = DBConfig.doGetStringTeamID(homeCode, "Logo");
            picHomeLogo.Image = Image.FromFile(homeLogo);

            homeLogoIn = DBConfig.doGetStringTeamID(homeCode, "LOGOIN");
            homeLogoOut = DBConfig.doGetStringTeamID(homeCode, "LOGOOUT");

        }
        private void LoadTeamInfoAway()
        {
            TeamInfor.awayCode = awayCode = DBConfig.doGetTeamID(TeamInfor.awayTenNgan, "TenNgan", "MaDoi");

            awayTenDai = DBConfig.doGetStringTeamID(awayCode, "TenDai");

            awayHLV = DBConfig.doGetStringTeamID(awayCode, "HLV");

            awayLogo = DBConfig.doGetStringTeamID(awayCode, "Logo");
            picAwayLogo.Image = Image.FromFile(awayLogo);

            awayLogoIn = DBConfig.doGetStringTeamID(awayCode, "LOGOIN");

            awayLogoOut = DBConfig.doGetStringTeamID(awayCode, "LOGOOUT");
            awayLogoOut = DBConfig.doGetStringTeamID(awayCode, "LOGOOUT");
        }

        private void InitializeComboBoxes()
        {
            string[] values = { "1", "2", "3", "4", "5", "6" };

            cbbPlayerIcon1.Items.AddRange(values);
            cbbPlayerIcon2.Items.AddRange(values);
            cbbGKIcon1.Items.AddRange(values);
            cbbGKIcon2.Items.AddRange(values);
        }

        private Color ConvertStringToColor(string rgbString)
        {
            // Tách chuỗi "R,G,B" thành các phần tử
            var rgbValues = rgbString.Split(',');

            // Kiểm tra xem có đủ 3 giá trị R, G, B hay không
            if (rgbValues.Length == 3)
            {
                // Chuyển đổi các chuỗi thành số nguyên
                int r = Convert.ToInt32(rgbValues[0]);
                int g = Convert.ToInt32(rgbValues[1]);
                int b = Convert.ToInt32(rgbValues[2]);

                // Tạo đối tượng Color từ các giá trị R, G, B
                return Color.FromArgb(r, g, b);
            }
            return Color.DarkGray;
        }
        private void loadDgvAllTeam()
        {
            DBConfig.doGetAllTeams();
            dgvAllTeam.DataSource = DBConfig.AllTeams;
        }
        private void dgvAllTeam_RowValidated()
        {

            foreach (DataGridViewRow row in dgvAllTeam.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua hàng mới

                string teamCode = row.Cells["MaDoi"].Value?.ToString();
                string longName = row.Cells["TenDai"].Value?.ToString();
                string shortName = row.Cells["TenNgan"].Value?.ToString();
                string coach = row.Cells["HLV"].Value?.ToString();
                string logo = row.Cells["Logo"].Value?.ToString();
                string gk_color = row.Cells["Gk_Color"].Value?.ToString();
                string player_color = row.Cells["Player_Color"].Value?.ToString();

                // Gọi hàm cập nhật cơ sở dữ liệu
                DBConfig.updateTeamInfo(teamCode, longName, shortName, coach, logo, gk_color, player_color);
            }

        }

        private void dgvHomePlayer_CellValueChanged()
        {

            foreach (DataGridViewRow row in dgvHomePlayer.Rows)
            {
                if (row.IsNewRow) continue;
                int ID = Convert.ToInt32(row.Cells["ID"].Value);
                string name = row.Cells["Name"].Value.ToString();
                int stt = Convert.ToInt32(row.Cells["STT"].Value);
                int soao = Convert.ToInt32(row.Cells["Jersey #"].Value);
                string tenao = row.Cells["Jersey Name"].Value.ToString();

                int play = row.Cells["PLAY"].Value != null && int.TryParse(row.Cells["PLAY"].Value.ToString(), out int parsedPlay) ? parsedPlay : 0;

                string pos = row.Cells["Position"].Value.ToString();
                string card = row.Cells["Card"].Value.ToString();
                string image = row.Cells["IMAGE"].Value.ToString();
                string path = row.Cells["PATH"].Value.ToString();

                DBConfig.updatePlayersTeam(ID,TeamInfor.homeCode, name, stt, soao, tenao, play, pos, card, image, path);
            }
        }
        private void dgvAwayPlayer_CellValueChanged()
        {

            foreach (DataGridViewRow row in dgvAwayPlayer.Rows)
            {
                if (row.IsNewRow) continue;
                int ID = Convert.ToInt32(row.Cells["ID"].Value);
                string name = row.Cells["Name"].Value.ToString();
                int stt = Convert.ToInt32(row.Cells["STT"].Value);
                int soao = Convert.ToInt32(row.Cells["Jersey #"].Value);
                string tenao = row.Cells["Jersey Name"].Value.ToString();

                int play = row.Cells["PLAY"].Value != null && int.TryParse(row.Cells["PLAY"].Value.ToString(), out int parsedPlay) ? parsedPlay : 0;

                string pos = row.Cells["Position"].Value.ToString();
                string card = row.Cells["Card"].Value.ToString();
                string image = row.Cells["IMAGE"].Value.ToString();
                string path = row.Cells["PATH"].Value.ToString();

                DBConfig.updatePlayersTeam(ID, TeamInfor.awayCode, name, stt, soao, tenao, play, pos, card, image, path);
            }
        }

        private void Player_HomeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Player_HomeColor.BackColor = colorDialog.Color;
            }
        }

        private void Player_AwayColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Player_AwayColor.BackColor = colorDialog.Color;
            }
        }

        private void GK_HomeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                GK_HomeColor.BackColor = colorDialog.Color;
            }
        }

        private void GK_AwayColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                GK_AwayColor.BackColor = colorDialog.Color;
            }
        }

        private void upMatchID_Click(object sender, EventArgs e)
        {
            DBConfig.doGetInfoTournaments();
            MessageBox.Show("Đã cập nhật dữ liệu Match ID");
        }

        private void upWeather_Click(object sender, EventArgs e)
        {
            DBConfig.doGetInfoWeather();
            MessageBox.Show("Đã cập nhật dữ liệu thời tiết");
        }

        private void upBXH_Click(object sender, EventArgs e)
        {
            DBConfig.doGetSoccerRanking();
            MessageBox.Show("Đã cập nhật dữ liệu Bảng xếp hạng");
        }

        private void upVar_Click(object sender, EventArgs e)
        {
            DBConfig.doGetInforeferee();
            MessageBox.Show("Đã cập nhật dữ liệu trọng tài Var");
        }

        private void upReferee_Click(object sender, EventArgs e)
        {
            DBConfig.doGetInforeferee();
            MessageBox.Show("Đã cập nhật dữ liệu Trọng tài chính");
        }

        private void upStatic_Click(object sender, EventArgs e)
        {
            DBConfig.doGetAllStatistics();
            MessageBox.Show("Đã cập nhật dữ liệu Thống kê");
        }

        private void upHomeLineup_Click(object sender, EventArgs e)
        {
            loadPlayerHomeLineSub();
            MessageBox.Show("Đã cập nhật dữ liệu Ra sân đội nhà");
        }

        private void cbbPlayerIcon1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Value = cbbPlayerIcon1.SelectedItem.ToString();
                Player_HomeColor.BackColor = GetColorFromCbbHome(Value);
                //TeamInfor.homeIconPlayer = PATH + $"\\LPBank_TV Graphics\\2_GRAPHICS\\IconTactical\\{TeamInfor.homeTenNgan}\\{Value}.png";
            }
            catch { MessageBox.Show("Mã màu không hợp lệ");
            };
        }
        private void cbbGKIcon1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Value = cbbGKIcon1.SelectedItem.ToString();
                GK_HomeColor.BackColor = GetColorFromCbbHome(Value);
                //TeamInfor.homeIconGK = PATH + $"\\LPBank_TV Graphics\\2_GRAPHICS\\IconTactical\\{TeamInfor.homeTenNgan}\\{Value}.png";
            }
            catch { MessageBox.Show("Mã màu không hợp lệ");
            };
        }
        private Color GetColorFromCbbHome(string value)
        {
            switch (value)
            {
                case "1": return ConvertStringToColor(DBConfig.doGetStringRGB(TeamInfor.homeCode, "Player_Official"));
                case "2": return ConvertStringToColor(DBConfig.doGetStringRGB(TeamInfor.homeCode, "GK_Official"));
                case "3": return ConvertStringToColor(DBConfig.doGetStringRGB(TeamInfor.homeCode, "Player_1"));
                case "4": return ConvertStringToColor(DBConfig.doGetStringRGB(TeamInfor.homeCode, "GK_1"));
                case "5": return ConvertStringToColor(DBConfig.doGetStringRGB(TeamInfor.homeCode, "Player_2"));
                case "6": return ConvertStringToColor(DBConfig.doGetStringRGB(TeamInfor.homeCode, "GK_2"));
                default: return Color.White;
            }
        }
        private Color GetColorFromCbbAway(string value)
        {
            switch (value)
            {
                case "1": return ConvertStringToColor(DBConfig.doGetStringRGB(TeamInfor.awayCode, "Player_Official"));
                case "2": return ConvertStringToColor(DBConfig.doGetStringRGB(TeamInfor.awayCode, "GK_Official"));
                case "3": return ConvertStringToColor(DBConfig.doGetStringRGB(TeamInfor.awayCode, "Player_1"));
                case "4": return ConvertStringToColor(DBConfig.doGetStringRGB(TeamInfor.awayCode, "GK_1"));
                case "5": return ConvertStringToColor(DBConfig.doGetStringRGB(TeamInfor.awayCode, "Player_2"));
                case "6": return ConvertStringToColor(DBConfig.doGetStringRGB(TeamInfor.awayCode, "GK_2"));
                default: return Color.White;
            }
        }

        private void cbbPlayerIcon2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Value = cbbPlayerIcon2.SelectedItem.ToString();
                Player_AwayColor.BackColor = GetColorFromCbbAway(Value);
                //TeamInfor.awayIconPlayer = PATH + $"\\LPBank_TV Graphics\\2_GRAPHICS\\IconTactical\\{TeamInfor.awayTenNgan}\\{Value}.png";
            }
            catch { MessageBox.Show("Mã màu không hợp lệ");
            };
        }

        private void btnAddHomePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow newRow = dgvHomePlayer.Rows[dgvHomePlayer.Rows.Count - 2]; // -2 để bỏ qua hàng trống cuối cùng

                int ID = newRow.Cells["ID"].Value != null && int.TryParse(newRow.Cells["ID"].Value.ToString(), out int parsedID) ? parsedID : 0;
                string name = newRow.Cells["Name"].Value?.ToString() ?? string.Empty;
                int stt = newRow.Cells["STT"].Value != null ? Convert.ToInt32(newRow.Cells["STT"].Value) : 0;
                int soao = newRow.Cells["Jersey #"].Value != null ? Convert.ToInt32(newRow.Cells["Jersey #"].Value) : 0;
                string tenao = newRow.Cells["Jersey Name"].Value?.ToString() ?? string.Empty;
                int play = newRow.Cells["PLAY"].Value != null && int.TryParse(newRow.Cells["PLAY"].Value.ToString(), out int parsedPlay) ? parsedPlay : 0;
                string pos = newRow.Cells["Position"].Value?.ToString() ?? string.Empty;
                string card = newRow.Cells["Card"].Value?.ToString() ?? string.Empty;
                string image = newRow.Cells["IMAGE"].Value?.ToString() ?? string.Empty;
                string path = newRow.Cells["PATH"].Value?.ToString() ?? string.Empty;

                if (ID == 0)
                {
                    Random rand = new Random();
                    ID = rand.Next(500, 9999);
                }
                    DBConfig.insertPlayer(ID, TeamInfor.homeCode, name, stt, soao, tenao, play, pos, card, image, path);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm cầu thủ mới: " + ex.Message);
            }
        }

        private void btnAddAwayPlayer_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow newRow = dgvAwayPlayer.Rows[dgvAwayPlayer.Rows.Count - 2]; // -2 để bỏ qua hàng trống cuối cùng

                int ID = newRow.Cells["ID"].Value != null && int.TryParse(newRow.Cells["ID"].Value.ToString(), out int parsedID) ? parsedID : 0;
                string name = newRow.Cells["Name"].Value?.ToString() ?? string.Empty;
                int stt = newRow.Cells["STT"].Value != null ? Convert.ToInt32(newRow.Cells["STT"].Value) : 0;
                int soao = newRow.Cells["Jersey #"].Value != null ? Convert.ToInt32(newRow.Cells["Jersey #"].Value) : 0;
                string tenao = newRow.Cells["Jersey Name"].Value?.ToString() ?? string.Empty;
                int play = newRow.Cells["PLAY"].Value != null && int.TryParse(newRow.Cells["PLAY"].Value.ToString(), out int parsedPlay) ? parsedPlay : 0;
                string pos = newRow.Cells["Position"].Value?.ToString() ?? string.Empty;
                string card = newRow.Cells["Card"].Value?.ToString() ?? string.Empty;
                string image = newRow.Cells["IMAGE"].Value?.ToString() ?? string.Empty;
                string path = newRow.Cells["PATH"].Value?.ToString() ?? string.Empty;

                if (ID == 0)
                {
                    Random rand = new Random();
                    ID = rand.Next(500, 9999);
                }
                DBConfig.insertPlayer(ID, TeamInfor.awayCode, name, stt, soao, tenao, play, pos, card, image, path);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm cầu thủ mới: " + ex.Message);
            }
        }

        #region Kéo thả chuột để hoán đổi vị trí 2 cầu thủ dgvHomePlayer/dgvAwayPlayer
        private void dgvHomePlayer_MouseDown(object sender, MouseEventArgs e)
        {
            HandleMouseDown(dgvHomePlayer, e);
        }

        private void dgvAwayPlayer_MouseDown(object sender, MouseEventArgs e)
        {
            HandleMouseDown(dgvAwayPlayer, e);
        }

        private void HandleMouseDown(DataGridView dataGridView, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataGridView.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0)
                {
                    dataGridView.ClearSelection();
                    dataGridView.Rows[hitTestInfo.RowIndex].Selected = true;
                    dataGridView.CurrentCell = dataGridView.Rows[hitTestInfo.RowIndex].Cells[0];
                }
            }
            DataGridView.HitTestInfo hit = dataGridView.HitTest(e.X, e.Y);

            // Bỏ qua các dòng trống hoặc dòng không hợp lệ
            if (hit.RowIndex >= 0 && hit.RowIndex != dataGridView.NewRowIndex)
            {
                rowIndexFromMouseDown = hit.RowIndex;
                rowToMove = dataGridView.Rows[rowIndexFromMouseDown];
                isDragging = false; // Đặt cờ isDragging thành false khi nhấn chuột xuống
            }
        }

        private void dgvHomePlayer_MouseMove(object sender, MouseEventArgs e)
        {
            HandleMouseMove(dgvHomePlayer, e);
        }

        private void dgvAwayPlayer_MouseMove(object sender, MouseEventArgs e)
        {
            HandleMouseMove(dgvAwayPlayer, e);
        }

        private void HandleMouseMove(DataGridView dataGridView, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && rowToMove != null)
            {
                rowIndexOfItemUnderMouseToDrop = dataGridView.HitTest(e.X, e.Y).RowIndex;

                if (rowIndexOfItemUnderMouseToDrop >= 0 && rowIndexOfItemUnderMouseToDrop != dataGridView.NewRowIndex)
                {
                    // Đặt cờ isDragging thành true khi có di chuyển chuột
                    isDragging = true;
                    // Khôi phục màu của hàng trước đó (nếu có)
                    if (previousRowIndex >= 0 && previousRowIndex < dataGridView.Rows.Count)
                    {
                        var previousRow = dataGridView.Rows[previousRowIndex];
                        previousRow.DefaultCellStyle.BackColor = Color.White;
                    }
                    var targetRow = dataGridView.Rows[rowIndexOfItemUnderMouseToDrop];
                    targetRow.DefaultCellStyle.BackColor = Color.LightBlue;

                    previousRowIndex = rowIndexOfItemUnderMouseToDrop;
                }
            }
        }

        private void dgvHomePlayer_MouseUp(object sender, MouseEventArgs e)
        {
            HandleMouseUp(dgvHomePlayer, e);
        }

        private void dgvAwayPlayer_MouseUp(object sender, MouseEventArgs e)
        {
            HandleMouseUp(dgvAwayPlayer, e);
        }

        private void HandleMouseUp(DataGridView dataGridView, MouseEventArgs e)
        {
            if (isDragging && rowToMove != null)
            {
                ResetAllRowColors(dataGridView);

                if (rowIndexOfItemUnderMouseToDrop >= 0 &&
                    rowIndexOfItemUnderMouseToDrop != dataGridView.NewRowIndex && rowIndexFromMouseDown != rowIndexOfItemUnderMouseToDrop)
                {
                    // Lấy dữ liệu từ hàng được kéo
                    DataGridViewRow newRow = (DataGridViewRow)rowToMove.Clone();
                    for (int i = 0; i < rowToMove.Cells.Count; i++)
                    {
                        newRow.Cells[i].Value = rowToMove.Cells[i].Value;
                    }

                    // Xóa hàng cũ
                    dataGridView.Rows.RemoveAt(rowIndexFromMouseDown);

                    // Chèn hàng vào vị trí mới
                    dataGridView.Rows.Insert(rowIndexOfItemUnderMouseToDrop, newRow);

                    // Cập nhật lại số thứ tự (STT)
                    UpdateSTTColumn(dataGridView);

                    // Chọn hàng mới
                    dataGridView.ClearSelection();
                    newRow.Selected = true;
                    dataGridView.CurrentCell = newRow.Cells[0];
                }

                // Đặt lại các biến sau khi hoàn thành thao tác
                rowToMove = null;
                previousRowIndex = -1;
            }

            isDragging = false;
        }

        private void ResetAllRowColors(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void UpdateSTTColumn(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].IsNewRow) continue; // Bỏ qua hàng mới

                dataGridView.Rows[i].Cells["STT"].Value = i + 1;
            }
        }
        #endregion

        private void SortDataGridViewByPlayColumn(DataGridView dataGridView)
        {
            var rows = dataGridView.Rows.Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .OrderBy(row => {
                    int value;
                    return int.TryParse(row.Cells["PLAY"].Value?.ToString(), out value) ? value : int.MaxValue;
                })
                .ToList();

            dataGridView.Rows.Clear();
            foreach (var row in rows)
            {
                dataGridView.Rows.Add(row);
            }
        }
        private void btnSaveHomePlayer_Click(object sender, EventArgs e)
        {
            dgvHomePlayer_CellValueChanged();
            loadPlayerHomeLineSub();
            LoadPlayersHome();

            MessageBox.Show("Đã lưu danh sách cầu thủ: ĐỘI NHÀ");
        }

        private void btnSaveAwayPlayer_Click(object sender, EventArgs e)
        {
            dgvAwayPlayer_CellValueChanged();
            loadPlayerAwayLineSub();
            LoadPlayersAway();

            MessageBox.Show("Đã lưu danh sách cầu thủ: ĐỘI KHÁCH");
        }

        private void btnSortHomePlayer_Click(object sender, EventArgs e)
        {
            SortDataGridViewByPlayColumn(dgvHomePlayer);
            UpdateSTTColumn(dgvHomePlayer);
            MessageBox.Show("Sắp xếp đội hình ra sân: ĐỘI NHÀ");
        }

        private void btnSortAwayPlayer_Click(object sender, EventArgs e)
        {
            SortDataGridViewByPlayColumn(dgvAwayPlayer);
            UpdateSTTColumn(dgvAwayPlayer);
            MessageBox.Show("Sắp xếp đội hình ra sân: ĐỘI KHÁCH");
        }

        private void cbbGKIcon2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Value = cbbGKIcon2.SelectedItem.ToString();
                GK_AwayColor.BackColor = GetColorFromCbbAway(Value);
                //TeamInfor.awayIconGK = PATH + $"\\LPBank_TV Graphics\\2_GRAPHICS\\IconTactical\\{TeamInfor.awayTenNgan}\\{Value}.png";
            }
            catch { MessageBox.Show("Mã màu không hợp lệ");
            };
        }


        private void upHomeSub_Click(object sender, EventArgs e)
        {
            loadPlayerHomeLineSub();
            MessageBox.Show("Đã cập nhật dữ liệu Dự bị đội nhà");
        }

        private void upAwayLineup_Click(object sender, EventArgs e)
        {
            loadPlayerAwayLineSub();
            MessageBox.Show("Đã cập nhật dữ liệu Ra sân đội khách");
        }

        private void upAwaySub_Click(object sender, EventArgs e)
        {
            loadPlayerAwayLineSub();
            MessageBox.Show("Đã cập nhật dữ liệu Dự bị đội khách");
        }

        private void UpAllData_Click(object sender, EventArgs e)
        {
            loadPlayerHomeLineSub();
            loadPlayerAwayLineSub();
            MessageBox.Show("Đã cập nhật toàn bộ dữ liệu");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvHomePlayer_CellValueChanged();
            dgvAwayPlayer_CellValueChanged();
            loadPlayerHomeLineSub();
            loadPlayerAwayLineSub();

            dgvAllTeam_RowValidated();

            MessageBox.Show("Đã lưu dữ liệu bảng");
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            if (cbbHomeTeam.Text.Equals("") || cbbAwayTeam.Text.Equals(""))
            {
                MessageBox.Show("Chưa chọn đội bóng");
                FrmKarismaMenu.FrmSetting.OnLogMessage("Chưa chọn đội");
                labelStatus.Text = "Chưa chọn đội bóng";
                return;
            }
            if (cbbHomeTactic.Text.Equals("") || cbbAwayTactic.Text.Equals(""))
            {
                MessageBox.Show("Chưa chọn đội hình");
                FrmKarismaMenu.FrmSetting.OnLogMessage("Chưa chọn đội hình");
                labelStatus.Text = "Chưa chọn đội hình";
                return;
            }
            LoadTeamInfoHome();
            LoadTeamInfoAway();
            loadPlayerHomeTeam();
            loadPlayerAwayTeam();
            loadPlayerHomeLineSub();
            loadPlayerAwayLineSub();
            LoadPlayersHome();
            LoadPlayersAway();
            TeamInfor.UpdateData(homeCode, homeTactical, homeTenDai, homeTenNgan, homeHLV, homeLogo,
            awayCode, awayTactical, awayTenDai, awayTenNgan, awayHLV, awayLogo,
         Player_HomeColor.BackColor, Player_AwayColor.BackColor, homeLogoIn, homeLogoOut, awayLogoIn, awayLogoOut,
         GK_HomeColor.BackColor, GK_AwayColor.BackColor);
            Static.AwayNameGoals = new string[10, 3];
            Static.HomeNameGoals = new string[10, 3];

            labelStatus.Text = "OK!";
            labelTimeUpdated.Text = DateTime.Now.ToString("hh:mm:ss tt");
            MessageBox.Show("Thiết lập thành công!");
        }

        public void loadPlayerHomeTeam()
        {
            // Tạo cột DataGridView trước khi thêm dữ liệu
            if (dgvHomePlayer.Columns.Count == 0)
            {
                dgvHomePlayer.Columns.Add("STT", "STT");
                dgvHomePlayer.Columns.Add("Name", "Tên cầu thủ");
                dgvHomePlayer.Columns.Add("Jersey #", "Số áo");
                dgvHomePlayer.Columns.Add("Jersey Name", "Tên áo");
                dgvHomePlayer.Columns.Add("PLAY", "Ra sân");
                dgvHomePlayer.Columns.Add("Position", "Vị trí");
                dgvHomePlayer.Columns.Add("Card", "Thẻ");
                dgvHomePlayer.Columns.Add("IMAGE", "Ảnh");
                dgvHomePlayer.Columns.Add("PATH", "PATH");
                dgvHomePlayer.Columns.Add("ID", "ID");
            }
            dgvHomePlayer.Columns[0].Width = 40;
            dgvHomePlayer.Columns[1].Width = 200;
            dgvHomePlayer.Columns[2].Width = 70;
            dgvHomePlayer.Columns[3].Width = 120;
            DataGridViewCompare.Load_Players(TeamInfor.homeCode, dgvHomePlayer);
            // Sắp xếp DataGridView của đội hình theo cột STT thứ tự tăng dần
            dgvHomePlayer.Sort(dgvHomePlayer.Columns["STT"], ListSortDirection.Ascending);
        }
        public void loadPlayerAwayTeam()
        {
            // Tạo cột DataGridView trước khi thêm dữ liệu
            if (dgvAwayPlayer.Columns.Count == 0)
            {
                dgvAwayPlayer.Columns.Add("STT", "STT");
                dgvAwayPlayer.Columns.Add("Name", "Tên cầu thủ");
                dgvAwayPlayer.Columns.Add("Jersey #", "Số áo");
                dgvAwayPlayer.Columns.Add("Jersey Name", "Tên áo");
                dgvAwayPlayer.Columns.Add("PLAY", "Ra sân");
                dgvAwayPlayer.Columns.Add("Position", "Vị trí");
                dgvAwayPlayer.Columns.Add("Card", "Thẻ");
                dgvAwayPlayer.Columns.Add("IMAGE", "Ảnh");
                dgvAwayPlayer.Columns.Add("PATH", "PATH");
                dgvAwayPlayer.Columns.Add("ID", "ID");
            }
            dgvAwayPlayer.Columns[0].Width = 40;
            dgvAwayPlayer.Columns[1].Width = 200;
            dgvAwayPlayer.Columns[2].Width = 70;
            dgvAwayPlayer.Columns[3].Width = 120;
            DataGridViewCompare.Load_Players(TeamInfor.awayCode, dgvAwayPlayer);
            // Sắp xếp DataGridView của đội hình theo cột STT thứ tự tăng dần
            dgvAwayPlayer.Sort(dgvAwayPlayer.Columns["STT"], ListSortDirection.Ascending);
        }
        public void LoadPlayersHome()
        {
            PlayerOLD[] teamPlayers = new PlayerOLD[21]; // Khởi tạo mảng 21 phần tử

            for (int i = 0; i < 21; i++)
            {
                if (dgvHomePlayer.Rows[i].IsNewRow) continue; // Bỏ qua hàng mới

                PlayerOLD player = new PlayerOLD
                {
                    Name = dgvHomePlayer.Rows[i].Cells["Name"].Value.ToString(),
                    ShortName = dgvHomePlayer.Rows[i].Cells["Jersey #"].Value.ToString() +
                                " " + dgvHomePlayer.Rows[i].Cells["Jersey Name"].Value.ToString(),
                    Number = dgvHomePlayer.Rows[i].Cells["Jersey #"].Value.ToString(),
                    Position = dgvHomePlayer.Rows[i].Cells["Position"].Value.ToString(),
                    Image = dgvHomePlayer.Rows[i].Cells["PATH"].Value.ToString() + "\\" +
                            dgvHomePlayer.Rows[i].Cells["IMAGE"].Value.ToString()
                };

                teamPlayers[i] = player;
            }
            TeamInfor.PlayersHome = teamPlayers;
        }
        public void LoadPlayersAway()
        {
            PlayerOLD[] teamPlayers = new PlayerOLD[21]; // Khởi tạo mảng 21 phần tử

            for (int i = 0; i < 21; i++)
            {
                if (dgvAwayPlayer.Rows[i].IsNewRow) continue; // Bỏ qua hàng mới

                PlayerOLD player = new PlayerOLD
                {
                    Name = dgvAwayPlayer.Rows[i].Cells["Name"].Value.ToString(),
                    ShortName = dgvAwayPlayer.Rows[i].Cells["Jersey #"].Value.ToString() +
                                " " + dgvAwayPlayer.Rows[i].Cells["Jersey Name"].Value.ToString(),
                    Number = dgvAwayPlayer.Rows[i].Cells["Jersey #"].Value.ToString(),
                    Position = dgvAwayPlayer.Rows[i].Cells["Position"].Value.ToString(),
                    Image = dgvAwayPlayer.Rows[i].Cells["PATH"].Value.ToString() + "\\" +
                            dgvAwayPlayer.Rows[i].Cells["IMAGE"].Value.ToString()
                };

                teamPlayers[i] = player;
            }
            TeamInfor.PlayersAway = teamPlayers;
        }
        //Load DS thi đấu và dự bị đội nhà
        public void loadPlayerHomeLineSub()
        {
            PlayerOLD[] playersLineup = new PlayerOLD[11];
            PlayerOLD[] playersSub = new PlayerOLD[10];
            for (int i = 0; i < 11; i++)
            {
                PlayerOLD player = new PlayerOLD();
                player.Name = dgvHomePlayer.Rows[i].Cells["Name"].Value.ToString();
                player.ShortName = dgvHomePlayer.Rows[i].Cells["Jersey #"].Value.ToString() +
                    " " + dgvHomePlayer.Rows[i].Cells["Jersey Name"].Value.ToString();
                player.Number = dgvHomePlayer.Rows[i].Cells["Jersey #"].Value.ToString();
                player.Position = dgvHomePlayer.Rows[i].Cells["Position"].Value.ToString();
                player.Image = dgvHomePlayer.Rows[i].Cells["PATH"].Value.ToString() + "\\" + dgvHomePlayer.Rows[i].Cells["IMAGE"].Value.ToString();
                playersLineup[i] = player;
            }
            for (int i = 11; i < 21; i++)
            {
                PlayerOLD player = new PlayerOLD();
                player.Name = dgvHomePlayer.Rows[i].Cells["Name"].Value.ToString();
                player.ShortName = dgvHomePlayer.Rows[i].Cells["Jersey #"].Value.ToString() +
                    " " + dgvHomePlayer.Rows[i].Cells["Jersey Name"].Value.ToString();
                player.Number = dgvHomePlayer.Rows[i].Cells["Jersey #"].Value.ToString();
                player.Position = dgvHomePlayer.Rows[i].Cells["Position"].Value.ToString();
                player.Image = dgvHomePlayer.Rows[i].Cells["PATH"].Value.ToString() + "\\"+ dgvHomePlayer.Rows[i].Cells["IMAGE"].Value.ToString();
                playersSub[i - 11] = player;
            }
            TeamInfor.PlayersHomeLineup = playersLineup;
            TeamInfor.PlayersHomeSub = playersSub;
        }
        //Load DS thi đấu và dự bị đội khách
        public void loadPlayerAwayLineSub()
        {
            PlayerOLD[] playersLineup = new PlayerOLD[11];
            PlayerOLD[] playersSub = new PlayerOLD[10];
            for (int i = 0; i < 11; i++)
            {
                PlayerOLD player = new PlayerOLD();
                player.Name = dgvAwayPlayer.Rows[i].Cells["Name"].Value.ToString();
                player.ShortName = dgvAwayPlayer.Rows[i].Cells["Jersey #"].Value.ToString() +
                    " " + dgvAwayPlayer.Rows[i].Cells["Jersey Name"].Value.ToString();
                player.Number = dgvAwayPlayer.Rows[i].Cells["Jersey #"].Value.ToString();
                player.Position = dgvAwayPlayer.Rows[i].Cells["Position"].Value.ToString();
                player.Image = dgvAwayPlayer.Rows[i].Cells["PATH"].Value.ToString() + "\\" + dgvAwayPlayer.Rows[i].Cells["IMAGE"].Value.ToString();
                playersLineup[i] = player;
            }
            for (int i = 11; i < 21; i++)
            {
                PlayerOLD player = new PlayerOLD();
                player.Name = dgvAwayPlayer.Rows[i].Cells["Name"].Value.ToString();
                player.ShortName = dgvAwayPlayer.Rows[i].Cells["Jersey #"].Value.ToString() +
                    " " + dgvAwayPlayer.Rows[i].Cells["Jersey Name"].Value.ToString();
                player.Number = dgvAwayPlayer.Rows[i].Cells["Jersey #"].Value.ToString();
                player.Position = dgvAwayPlayer.Rows[i].Cells["Position"].Value.ToString();
                player.Image = dgvAwayPlayer.Rows[i].Cells["PATH"].Value.ToString() + "\\" + dgvAwayPlayer.Rows[i].Cells["IMAGE"].Value.ToString();
                playersSub[i - 11] = player;
            }
            TeamInfor.PlayersAwayLineup = playersLineup;
            TeamInfor.PlayersAwaySub = playersSub;
        }
        private Color AdjustColor(Color color, double darkenFactor, double lightenFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            // Tăng độ nhạt
            red = red + (255 - red) * lightenFactor;
            green = green + (255 - green) * lightenFactor;
            blue = blue + (255 - blue) * lightenFactor;

            // Giảm độ sáng
            red = red * (1 - darkenFactor);
            green = green * (1 - darkenFactor);
            blue = blue * (1 - darkenFactor);

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

        private void cbbHomeTactic_SelectedIndexChanged(object sender, EventArgs e)
        {
            TeamInfor.homeTactical = homeTactical = cbbHomeTactic.Text;
        }
        private void cbbAwayTactic_SelectedIndexChanged(object sender, EventArgs e)
        {
            TeamInfor.awayTactical = awayTactical = cbbAwayTactic.Text;
        }

    }
}
