using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLeague.src.helper;
using VLeague.src.model;

namespace VLeague.src.menu
{
    public partial class FrmLowerThird : Form
    {

        string goalhome1, goalhome2;

        string goalaway1, goalaway2;

        private List<ComboBox> homeGoalComboBoxes;
        private List<TextBox> numHomeGoalTextBoxes;
        private List<TextBox> timeHomeGoalTextBoxes;

        private List<ComboBox> awayGoalComboBoxes;
        private List<TextBox> numAwayGoalTextBoxes;
        private List<TextBox> timeAwayGoalTextBoxes;

        public FrmLowerThird()
        {
            InitializeComponent();
            ButtonHelper.InitializeButtons(this);
        }
        private void clearTagButton()
        {
            Button[] buttons = new Button[]
            {btnKickOff, btnFullTime, penaltyLowerThird, timeLowerThird};
            ButtonHelper.ClearTagButton(buttons);
        }
        private void clearTagButtonEx(Button clickedButton)
        {
            Button[] buttons = new Button[]
            {btnKickOff, btnFullTime, penaltyLowerThird, timeLowerThird};
            ButtonHelper.ClearTagButtonEx(buttons, clickedButton);
        }
        private void UpdateButtonState(Button btn, int x)
        {
            ButtonHelper.UpdateButtonState(btn, x);
        }
        private void FrmLowerThird_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeBoxLists();
                LoadGoalHomeData();
                LoadGoalAwayData();
                string[] values = { "HẾT HIỆP 1", "HẾT HIỆP 2", "HẾT HIỆP 1 ET", "HẾT HIỆP 2 ET", "HẾT TRẬN" };
                cbbMatch.Items.AddRange(values);
                cbbMatch.SelectedIndex = 0;

                homeName.Text = TeamInfor.homeTenDai;
                awayName.Text = TeamInfor.awayTenDai;

                ComboBox[] homeGoals = { homeGoal1, homeGoal2, homeGoal3, homeGoal4, homeGoal5, homeGoal6, homeGoal7, homeGoal8, homeGoal9 };
                ComboBox[] awayGoals = { awayGoal1, awayGoal2, awayGoal3, awayGoal4, awayGoal5, awayGoal6, awayGoal7, awayGoal8, awayGoal9 };

                foreach (ComboBox homeGoal in homeGoals)
                {
                    FillCbbPlayer(homeGoal, TeamInfor.PlayersHome);
                }
                foreach (ComboBox awayGoal in awayGoals)
                {
                    FillCbbPlayer(awayGoal, TeamInfor.PlayersAway);
                }
                picHomeLogo.Image = Image.FromFile(TeamInfor.homeLogo);
                picAwayLogo.Image = Image.FromFile(TeamInfor.awayLogo);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi load dữ liệu, vui lòng LOAD DATA ở DATA IMPORT", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillCbbPlayer(ComboBox comboBox, Player[] players)
        {
            comboBox.Items.Clear();
            // Lặp qua mảng players và thêm ShortName của mỗi player vào ComboBox
            foreach (Player player in players)
            {
                string item = player.ShortName;
                comboBox.Items.Add(item.Substring(item.IndexOf(' ') + 1));
            }
        }
        private void InitializeBoxLists()
        {
            homeGoalComboBoxes = new List<ComboBox>
        {
            homeGoal1, homeGoal2, homeGoal3, homeGoal4, homeGoal5, homeGoal6, homeGoal7, homeGoal8, homeGoal9
        };
            numHomeGoalTextBoxes = new List<TextBox>
        {
            numHomeGoal1, numHomeGoal2, numHomeGoal3, numHomeGoal4, numHomeGoal5, numHomeGoal6, numHomeGoal7, numHomeGoal8, numHomeGoal9
        };
            timeHomeGoalTextBoxes = new List<TextBox>
        {
            timeHomeGoal1, timeHomeGoal2, timeHomeGoal3, timeHomeGoal4, timeHomeGoal5, timeHomeGoal6, timeHomeGoal7, timeHomeGoal8, timeHomeGoal9
        };
            awayGoalComboBoxes = new List<ComboBox>
        {
            awayGoal1, awayGoal2, awayGoal3, awayGoal4, awayGoal5, awayGoal6, awayGoal7, awayGoal8, awayGoal9
        };
            numAwayGoalTextBoxes = new List<TextBox>
        {
            numAwayGoal1, numAwayGoal2, numAwayGoal3, numAwayGoal4, numAwayGoal5, numAwayGoal6, numAwayGoal7, numAwayGoal8, numAwayGoal9
        };
            timeAwayGoalTextBoxes = new List<TextBox>
        {
            timeAwayGoal1, timeAwayGoal2, timeAwayGoal3, timeAwayGoal4, timeAwayGoal5, timeAwayGoal6, timeAwayGoal7, timeAwayGoal8, timeAwayGoal9
        };
        }
        private void LoadGoalHomeData()
        {
            for (int i = 0; i < 9; i++)
            {
                homeGoalComboBoxes[i].Text = Static.HomeNameGoals[i, 0];
                numHomeGoalTextBoxes[i].Text = Static.HomeNameGoals[i, 1];
                timeHomeGoalTextBoxes[i].Text = Static.HomeNameGoals[i, 2];
            }
        }
        private void LoadGoalAwayData()
        {
            for (int i = 0; i < 9; i++)
            {
                awayGoalComboBoxes[i].Text = Static.AwayNameGoals[i, 0];
                numAwayGoalTextBoxes[i].Text = Static.AwayNameGoals[i, 1];
                timeAwayGoalTextBoxes[i].Text = Static.AwayNameGoals[i, 2];
            }
        }

        // Hàm chung để lấy số áo (Number) của cầu thủ được chọn
        public void UpdatePlayerNumber(ComboBox comboBox, TextBox textBox, Player[] players)
        {
            int selectedIndex = comboBox.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < players.Length)
            {
                string selectedNumber = players[selectedIndex].Number;
                textBox.Text = selectedNumber;
            }
        }

        // Hàm tìm Name từ giá trị TextBox chuyển về int
        public void UpdatePlayerName(ComboBox comboBox , TextBox textBox, Player[] players)
        {
            int number;
            if (int.TryParse(textBox.Text, out number))
            {
                var player = players.FirstOrDefault(p => p.Number == number.ToString());
                if (player != null)
                {
                    comboBox.Text = player.ShortName.Substring(player.ShortName.IndexOf(' ') + 1);
                }
            }
        }

        // Hàm xử lý String cho LowerThird ghi bàn
        private void StringLT()
        {
            // Danh sách các ComboBox và TextBox cho cầu thủ ghi bàn của đội nhà
            ComboBox[] homeGoals = { homeGoal1, homeGoal2, homeGoal3, homeGoal4, homeGoal5, homeGoal6, homeGoal7, homeGoal8, homeGoal9 };
            TextBox[] homeGoalTimes = { timeHomeGoal1, timeHomeGoal2, timeHomeGoal3, timeHomeGoal4, timeHomeGoal5, timeHomeGoal6, timeHomeGoal7, timeHomeGoal8, timeHomeGoal9 };

            // Danh sách các ComboBox và TextBox cho cầu thủ ghi bàn của đội khách
            ComboBox[] awayGoals = { awayGoal1, awayGoal2, awayGoal3, awayGoal4, awayGoal5, awayGoal6, awayGoal7, awayGoal8, awayGoal9 };
            TextBox[] awayGoalTimes = { timeAwayGoal1, timeAwayGoal2, timeAwayGoal3, timeAwayGoal4, timeAwayGoal5, timeAwayGoal6, timeAwayGoal7, timeAwayGoal8, timeAwayGoal9 };

            // Xử lý cho đội nhà
            (goalhome1, goalhome2) = BuildGoalStrings(homeGoals, homeGoalTimes);

            // Xử lý cho đội khách
            (goalaway1, goalaway2) = BuildGoalStrings(awayGoals, awayGoalTimes);
        }

        // Hàm xử lý ĐK combobox + Time cho cầu thủ ghi bàn và phân bổ chúng
        private (string, string) BuildGoalStrings(ComboBox[] goalComboboxes, TextBox[] timeTextBoxes)
        {
            // Sử dụng Dictionary để lưu trữ các cầu thủ và danh sách thời gian ghi bàn của họ
            Dictionary<string, List<string>> goalData = new Dictionary<string, List<string>>();

            for (int i = 0; i < goalComboboxes.Length; i++)
            {
                string playerName = goalComboboxes[i].Text;
                string goalTime = timeTextBoxes[i].Text;

                if (!string.IsNullOrWhiteSpace(playerName) && !string.IsNullOrWhiteSpace(goalTime))
                {
                    if (!goalData.ContainsKey(playerName))
                    {
                        goalData[playerName] = new List<string>();
                    }

                    goalData[playerName].Add(goalTime);
                }
            }

            List<string> goalStrings1 = new List<string>();
            List<string> goalStrings2 = new List<string>();

            int index = 0;

            foreach (var player in goalData)
            {
                string goals = string.Join(" ", player.Value);
                string goalString = $"{player.Key} {goals}";

                if (index < 3)
                {
                    goalStrings1.Add(goalString);
                }
                else
                {
                    goalStrings2.Add(goalString);
                }

                index++;
            }

            // Trả về hai chuỗi kết quả cho goalhome1 và goalhome2
            return (string.Join("  ", goalStrings1), string.Join("  ", goalStrings2));
        }

        private void homeGoal1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(homeGoal1, numHomeGoal1, TeamInfor.PlayersHome);
        }

        private void homeGoal2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(homeGoal2, numHomeGoal2, TeamInfor.PlayersHome);
        }

        private void homeGoal3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(homeGoal3, numHomeGoal3, TeamInfor.PlayersHome);
        }

        private void homeGoal4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(homeGoal4, numHomeGoal4, TeamInfor.PlayersHome);
        }

        private void homeGoal5_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(homeGoal5, numHomeGoal5, TeamInfor.PlayersHome);
        }

        private void homeGoal6_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(homeGoal6, numHomeGoal6, TeamInfor.PlayersHome);
        }

        private void homeGoal7_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(homeGoal7, numHomeGoal7, TeamInfor.PlayersHome);
        }
        private void homeGoal8_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(homeGoal8, numHomeGoal8, TeamInfor.PlayersHome);
        }

        private void homeGoal9_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(homeGoal9, numHomeGoal9, TeamInfor.PlayersHome);
        }

        private void awayGoal1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(awayGoal1, numAwayGoal1, TeamInfor.PlayersAway);
        }

        private void awayGoal2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(awayGoal2, numAwayGoal2, TeamInfor.PlayersAway);
        }

        private void awayGoal3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(awayGoal3, numAwayGoal3, TeamInfor.PlayersAway);
        }

        private void awayGoal4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(awayGoal4, numAwayGoal4, TeamInfor.PlayersAway);
        }

        private void awayGoal5_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(awayGoal5, numAwayGoal5, TeamInfor.PlayersAway);
        }

        private void awayGoal6_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(awayGoal6, numAwayGoal6, TeamInfor.PlayersAway);
        }

        private void awayGoal7_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(awayGoal7, numAwayGoal7, TeamInfor.PlayersAway);
        }
        private void awayGoal8_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(awayGoal8, numAwayGoal8, TeamInfor.PlayersAway);
        }
        private void awayGoal9_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(awayGoal9, numAwayGoal9, TeamInfor.PlayersAway);
        }
        private void stopAll_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.StopAll();
        }

        private void btnKickOff_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (btnKickOff.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    StringLT();
                    string hiepdau = cbbMatch.Text;
                    FrmKarismaMenu.FrmSetting.loadKickOffGoal(TeamInfor.homeTenNgan, TeamInfor.awayTenNgan, Static.numberHomeScore, Static.numberAwayScore,
                        TeamInfor.homeLogo, TeamInfor.awayLogo, hiepdau, goalhome1, goalhome2, goalaway1, goalaway2); 
                    break;
            }

        }

        private void stopKickOff_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void timeLowerThird_Click(object sender, EventArgs e)
        {
            StringLT();
            //MessageBox.Show($"{goalhome1}\n" + $"{goalhome2}\n" + $"{goalaway1}\n" + $"{goalaway2}\n");
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (timeLowerThird.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.loadTimeLowerThirdOut(TeamInfor.homeTenNgan, TeamInfor.awayTenNgan, Static.numberHomeScore, Static.numberAwayScore,
                        TeamInfor.homeLogo, TeamInfor.awayLogo, goalhome1, goalhome2, goalaway1, goalaway2, FrmInMatchClock.StartTime, FrmInMatchClock.EndTime);
                    break;
                case 1:
                    StringLT();
                    FrmKarismaMenu.FrmSetting.loadTimeLowerThird(TeamInfor.homeTenNgan, TeamInfor.awayTenNgan, Static.numberHomeScore, Static.numberAwayScore,
                        TeamInfor.homeLogo, TeamInfor.awayLogo, goalhome1, goalhome2, goalaway1, goalaway2, FrmInMatchClock.StartTime, FrmInMatchClock.EndTime);
                    break;
            }
        }

        private void stopTimeLowerThird_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void penaltyLowerThird_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(clickedButton, 1);
            switch (penaltyLowerThird.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    StringLT();
                    string text = $"PENALTY: {Static.numberHomePen} - {Static.numberAwayPen}";
                    FrmKarismaMenu.FrmSetting.loadLTPenalty(TeamInfor.homeTenNgan, TeamInfor.awayTenNgan, Static.numberHomeScore, Static.numberAwayScore,
                        TeamInfor.homeLogo, TeamInfor.awayLogo, text, goalhome1, goalhome2, goalaway1, goalaway2);
                    break;
            }
        }

        private void stopPenaltyLowerThird_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void updateData_Click(object sender, EventArgs e)
        {
            InitializeBoxLists();
            LoadGoalHomeData();
            LoadGoalAwayData();
        }

        private void btnFullTime_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (btnFullTime.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    StringLT();
                    string hiepdau = "HẾT TRẬN";
                    FrmKarismaMenu.FrmSetting.loadKickOffGoal(TeamInfor.homeTenNgan, TeamInfor.awayTenNgan, Static.numberHomeScore, Static.numberAwayScore,
                        TeamInfor.homeLogo, TeamInfor.awayLogo, hiepdau, goalhome1, goalhome2, goalaway1, goalaway2);
                    break;
            }
        }

        private void stopFullTime_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void saveListGoalPlayer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có muốn lưu lại danh sách ghi bàn không?",
                "Xác nhận lưu dữ liệu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                SaveGoalData();
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void SaveGoalData()
        {
            for (int i = 0; i < 9; i++)
            {
                // Cập nhật dữ liệu đội nhà (Home)
                Static.HomeNameGoals[i, 0] = homeGoalComboBoxes[i].Text;
                Static.HomeNameGoals[i, 1] = numHomeGoalTextBoxes[i].Text;
                Static.HomeNameGoals[i, 2] = timeHomeGoalTextBoxes[i].Text;

                // Cập nhật dữ liệu đội khách (Away)
                Static.AwayNameGoals[i, 0] = awayGoalComboBoxes[i].Text;
                Static.AwayNameGoals[i, 1] = numAwayGoalTextBoxes[i].Text;
                Static.AwayNameGoals[i, 2] = timeAwayGoalTextBoxes[i].Text;
            }
        }


        private void ClearAllInputs(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = string.Empty;
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).Text = string.Empty;
                }
                else if (c.Controls.Count > 0)
                {
                    ClearAllInputs(c);
                }
            }
        }

        private void numHomeGoal1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(homeGoal1, numHomeGoal1, TeamInfor.PlayersHome);
            }
        }

        private void numHomeGoal2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(homeGoal2, numHomeGoal2, TeamInfor.PlayersHome);
            }
        }

        private void numHomeGoal3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(homeGoal3, numHomeGoal3, TeamInfor.PlayersHome);
            }
        }

        private void numHomeGoal4_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(homeGoal4, numHomeGoal4, TeamInfor.PlayersHome);
            }
        }

        private void numHomeGoal5_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(homeGoal5, numHomeGoal5, TeamInfor.PlayersHome);
            }
        }

        private void numHomeGoal6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(homeGoal6, numHomeGoal6, TeamInfor.PlayersHome);
            }
        }

        private void numHomeGoal8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(homeGoal8, numHomeGoal8, TeamInfor.PlayersHome);
            }
        }

        private void numHomeGoal9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(homeGoal9, numHomeGoal9, TeamInfor.PlayersHome);
            }
        }

        private void numAwayGoal1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(awayGoal1, numAwayGoal1, TeamInfor.PlayersAway);
            }
        }

        private void numAwayGoal2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(awayGoal2, numAwayGoal2, TeamInfor.PlayersAway);
            }
        }

        private void numAwayGoal3_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(awayGoal3, numAwayGoal3, TeamInfor.PlayersAway);
            }
        }

        private void numAwayGoal4_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(awayGoal4, numAwayGoal4, TeamInfor.PlayersAway);
            }
        }

        private void numAwayGoal5_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(awayGoal5, numAwayGoal5, TeamInfor.PlayersAway);
            }
        }

        private void numAwayGoal6_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(awayGoal6, numAwayGoal6, TeamInfor.PlayersAway);
            }
        }

        private void numAwayGoal7_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(awayGoal7, numAwayGoal7, TeamInfor.PlayersAway);
            }
        }

        private void numAwayGoal8_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(awayGoal8, numAwayGoal8, TeamInfor.PlayersAway);
            }
        }

        private void numAwayGoal9_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(awayGoal9, numAwayGoal9, TeamInfor.PlayersAway);
            }
        }

        private void numHomeGoal7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatePlayerName(homeGoal7, numHomeGoal7, TeamInfor.PlayersHome);
            }
        }


        private void clearTextBox_Click(object sender, EventArgs e)
        {
            ClearAllInputs(this);
        }
    }
}
