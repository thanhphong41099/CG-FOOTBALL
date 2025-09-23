using K3DAsyncEngineLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VLeague.src.helper;
using VLeague.src.model;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace VLeague.src.menu
{
    public partial class FrmInMatchClock : Form
    {
        private static string workingPath = "WORKINGFOLDER";
        private static string key = "CONNECT";
        private static string PATH = AppConfig.ConfigReader.ReadString(key, workingPath);
        public static int match;
        public static int durationInMinutes; // số phút diễn ra
        public static int durationInSecond; // số giây diễn ra
        public static int SetTime = 0; // số giây thêm bớt
        public static int minutes; // số phút
        private static int endTime; // thời gian kết thúc
        private DateTime timeStart; // thời gian bắt đầu
        private TimeSpan startTime; //thời gian bắt đầu kể từ phút
        private TimeSpan duration; // 
        private static int currentTime; // thời gian diễn ra
        public static int StartTime; // bắt đầu
        public static int EndTime; //Kết thúc

         public FrmInMatchClock()
        {
            InitializeComponent();
            ButtonHelper.InitializeButtons(this);

        }
        private void clearTagButtonTSL(Button clickedButton)
        {
            Button[] buttons = new Button[]
            {
                btnKickOff, btnTransID, WipeTrans, showHomeCoach, showAwayCoach, showBXHMini,
                LTHomePlayer, LTAwayPlayer, ShowGoalHomePlayer, ShowGoalAwayPlayer, homePlayerOG, awayPlayerOG, 
                HomeYellow, AwayYellow, Home2Yellow, Away2Yellow, HomeRed, AwayRed, HomeCancelYellow, AwayCancelYellow
            };
            ButtonHelper.ClearTagButtonEx(buttons, clickedButton);
        }
        private void clearTagButtonTSN()
        {
            Button[] buttons = new Button[]
            {
                btnTSN,
            };
            ButtonHelper.ClearTagButton(buttons);
        }
        private void clearTagButtonTheDo()
        {
            Button[] buttons = new Button[]
            {
                btnShowRedCard
            };
            ButtonHelper.ClearTagButton(buttons);
        }
        private void clearTagButtonAddTime()
        {
            Button[] buttons = new Button[]
            {
                ShowAddTime
            };
            ButtonHelper.ClearTagButton(buttons);
        }
        private void UpdateButtonState(Button btn, int x)
        {
            ButtonHelper.UpdateButtonState(btn, x);
        }
        private void FrmInMatchClock_Load(object sender, EventArgs e)
        {
            try
            {
                FillCbbPlayerInMatchClock();
                picHomeLogo2.Image = Image.FromFile(TeamInfor.homeLogo);
                picAwayLogo2.Image = Image.FromFile(TeamInfor.awayLogo);
                groupHome1.BackColor = groupHome2.BackColor = groupHome3.BackColor = groupHome4.BackColor = TeamInfor.Player_HomeColor;
                groupAway1.BackColor = groupAway2.BackColor = groupAway3.BackColor = groupAway4.BackColor = TeamInfor.Player_AwayColor;

                // Xác định màu chữ dựa trên độ sáng
                Color homeTextColor = GetContrastColor(TeamInfor.Player_HomeColor);
                Color awayTextColor = GetContrastColor(TeamInfor.Player_AwayColor);

                // Áp dụng màu chữ cho GroupBox và control con trong các group Home
                foreach (GroupBox group in new[] { groupHome1, groupHome2, groupHome3, groupHome4 })
                {
                    group.ForeColor = homeTextColor; // Đổi màu chữ tiêu đề GroupBox
                    foreach (Control ctrl in group.Controls)
                    {
                        if (ctrl is Label || ctrl is TextBox)
                        {
                            ctrl.ForeColor = homeTextColor;
                        }
                    }
                }

                // Áp dụng màu chữ cho GroupBox và control con trong các group Away
                foreach (GroupBox group in new[] { groupAway1, groupAway2, groupAway3, groupAway4 })
                {
                    group.ForeColor = awayTextColor; // Đổi màu chữ tiêu đề GroupBox
                    foreach (Control ctrl in group.Controls)
                    {
                        if (ctrl is Label || ctrl is TextBox)
                        {
                            ctrl.ForeColor = awayTextColor;
                        }
                    }
                }

                radHiep1.Checked = true;
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi load dữ liệu, vui lòng LOAD DATA ở DATA IMPORT", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm tính độ sáng và trả về màu chữ phù hợp
        private Color GetContrastColor(Color backgroundColor)
        {
            // Tính độ sáng (luminance)
            double luminance = 0.299 * backgroundColor.R + 0.587 * backgroundColor.G + 0.114 * backgroundColor.B;

            // Nếu màu nền sáng (L > 128), dùng chữ đen; nếu tối, dùng chữ trắng
            return luminance > 128 ? Color.Black : Color.White;
        }

        public static void FillCbbPlayer(ComboBox comboBox, Player[] players)
        {
            comboBox.Items.Clear();
            // Lặp qua mảng players và thêm ShortName của mỗi player vào ComboBox
            foreach (Player player in players)
            {
                comboBox.Items.Add(player.ShortName);
            }
        }
        private void FillCbbPlayerInMatchClock()
        {
            FillCbbPlayer(cbbHomePlayer, TeamInfor.PlayersHome);
            FillCbbPlayer(cbbHomeGoal, TeamInfor.PlayersHome);
            FillCbbPlayer(cbbHomeCard, TeamInfor.PlayersHome);
            FillCbbPlayer(cbbAwayPlayer, TeamInfor.PlayersAway);
            FillCbbPlayer(cbbAwayGoal, TeamInfor.PlayersAway);
            FillCbbPlayer(cbbAwayCard, TeamInfor.PlayersAway);
        }
        public void UpdateMatchScore()
        {
            Static.numberHomeScore = HomeScore.Value.ToString();
            Static.numberAwayScore = AwayScore.Value.ToString();
        }
        public void UpdateMatchTime()
        {
            StartTime = durationInMinutes * 60 + durationInSecond + 1;
            EndTime = endTime * 60;
        }
        //when button Start Time click
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (match == 0)
            {
                MessageBox.Show("Chưa chọn hiệp đấu");
                return;
            }
            if (match == 1)
            {
                for (int i = 0; i < 9; i++)
                {
                    Static.HomeNameGoals[i, 0] = string.Empty;
                    Static.HomeNameGoals[i, 1] = string.Empty;
                    Static.HomeNameGoals[i, 2] = string.Empty;

                    Static.AwayNameGoals[i, 0] = string.Empty;
                    Static.AwayNameGoals[i, 1] = string.Empty;
                    Static.AwayNameGoals[i, 2] = string.Empty;
                }
            }
            //timeStart = DateTime.Now;
            AppConfig.LogReader.Write("General", "OnPlaying", 1);
            AppConfig.LogReader.Write("General", "Half", match);
            AppConfig.LogReader.Write("General", "Start", DateTime.Now.ToString("hh:mm:ss tt"));
            //AppConfig.LogReader.Write("General", "Min", minutes);


            txtStartClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            string[] timeParts = txtTimeNow.Text.Split(':');
            if (timeParts.Length == 2 && int.TryParse(timeParts[0], out int minutes) && int.TryParse(timeParts[1], out int seconds))
            {
                startTime = new TimeSpan(0, minutes, seconds);
                timeStart = DateTime.Now.Subtract(startTime);
            }

            btnStart.Enabled = false;
            radHiep1.Enabled = false;
            radHiep2.Enabled = false;
            radHiep3.Enabled = false;
            radHiep4.Enabled = false;
            btnTheEnd.Enabled = true;
            tckRealTime.Start();
            btnStart.BackColor = Color.Lime;
            btnTheEnd.BackColor = Color.LightGray;

        }
        //when button End Time click
        private void btnTheEnd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn hiệp đấu đã kết thúc không ?", "Kết thúc hiệp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Kết thúc hiệp đấu");
                tckRealTime.Stop();
                btnStart.Enabled = true;
                radHiep1.Enabled = true;
                radHiep2.Enabled = true;
                radHiep3.Enabled = true;
                radHiep4.Enabled = true;
                btnTheEnd.Enabled = false;
                btnTheEnd.BackColor = Color.Lime;
                btnStart.BackColor = Color.LightGray;
                SetTime = 0;
            }
        }

        public void tckRealTime_Tick_1(object sender, EventArgs e)
        {
            try
            {
                if (currentTime < endTime * 60)
                {
                    duration = DateTime.Now.Subtract(timeStart);
                    currentTime = (int)duration.TotalSeconds;
                    durationInMinutes = currentTime / 60 + minutes;
                    durationInSecond = currentTime % 60;
                    txtTimeNow.Text = durationInMinutes.ToString("00") + ":" + durationInSecond.ToString("00");
                    txtNowClock.Text = DateTime.Now.Subtract(timeStart).ToString("hh\\:mm\\:ss");
                }
                else
                {
                    //MessageBox.Show("Nopass");
                    tckRealTime.Stop();
                    
                }
            }
            catch
            {
                MessageBox.Show("Lỗi định dạng Clock");
            }

        }
        //Xử lý chọn hiệp đấu radHiep1,2,3,4
        private void HandlePeriodChange(int matchNumber, string matchKey, string endMatchKey)
        {
            try
            {
                match = matchNumber;
                txtTimeNow.Text = AppConfig.ConfigReader.ReadString("General", matchKey) + ":00";
                string[] timeParts = txtTimeNow.Text.Split(':');
                if (timeParts.Length == 2 && int.TryParse(timeParts[0], out int minutes) && int.TryParse(timeParts[1], out int seconds))
                {
                    startTime = new TimeSpan(0, minutes, seconds);
                    timeStart = DateTime.Now.Subtract(startTime);
                }


                durationInMinutes = AppConfig.ConfigReader.ReadInteger("General", matchKey);
                minutes = AppConfig.ConfigReader.ReadInteger("General", matchKey);
                endTime = AppConfig.ConfigReader.ReadInteger("General", endMatchKey);
                EndTime = endTime * 60;
            }
            catch (Exception ex)
            {
                Handler.handlerError($"{matchKey}_Checked", ex);
            }
        }
        private void radHiep1_CheckedChanged(object sender, EventArgs e)
        {
            if (radHiep1.Checked)
            {
                HandlePeriodChange(1, "oneMatch", "endOneMatch");
            }
        }
        private void radHiep2_CheckedChanged(object sender, EventArgs e)
        {
            if (radHiep2.Checked)
            {
                HandlePeriodChange(2, "twoMatch", "endTwoMatch");
            }
        }
        private void radHiep3_CheckedChanged(object sender, EventArgs e)
        {
            if (radHiep3.Checked)
            {
                HandlePeriodChange(3, "threeMatch", "endThreeMatch");
            }
        }
        private void radHiep4_CheckedChanged(object sender, EventArgs e)
        {
            if (radHiep4.Checked)
            {
                HandlePeriodChange(4, "fourMatch", "endFourMatch");
            }
        }

        //button Show Add Time
        private void ShowAddTime_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddTime.Text))
            {
                MessageBox.Show("Chưa chọn thời gian bù giờ");
                return;
            }
            else
            {
                UpdateButtonState(sender as Button, 1);
                switch (ShowAddTime.Tag)
                {
                    case 0:
                        FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerBuGio);
                        break;
                    case 1:
                        FrmKarismaMenu.FrmSetting.loadDisplayAddtime(txtAddTime.Text);
                        break;
                }
            }
        }
        //button Stop Add Time
        private void StopAddTime_Click(object sender, EventArgs e)
        {
            clearTagButtonAddTime();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerBuGio);
        }

        //Lấy số áo (Number) của các Combobox Player được chọn: đánh tên ra số áo
        private void cbbHomePlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbbHomePlayer.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < TeamInfor.PlayersHome.Length)
            {
                string selectedNumber = TeamInfor.PlayersHome[selectedIndex].Number;
                numHomePlayer.Text = selectedNumber;
            }
        }
        private void cbbHomeGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbbHomeGoal.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < TeamInfor.PlayersHome.Length)
            {
                string selectedNumber = TeamInfor.PlayersHome[selectedIndex].Number;
                numHomeGoal.Text = selectedNumber;
            }
            int getMinutes = durationInMinutes;
            if (getMinutes < 1)
            {
                getMinutes = 1;
            }
            else
            {
                getMinutes++;
            }
            GoalTimeHome.Text = getMinutes.ToString();
        }
        private void cbbAwayPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbbAwayPlayer.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < TeamInfor.PlayersAway.Length)
            {
                string selectedNumber = TeamInfor.PlayersAway[selectedIndex].Number;
                numAwayPlayer.Text = selectedNumber;
            }
        }
        private void cbbAwayGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbbAwayGoal.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < TeamInfor.PlayersAway.Length)
            {
                string selectedNumber = TeamInfor.PlayersAway[selectedIndex].Number;
                numAwayGoal.Text = selectedNumber;
            }

            int getMinutes = durationInMinutes;
            if (getMinutes < 1)
            {
                getMinutes = 1;
            }
            else
            {
                getMinutes++;
            }
            GoalTimeAway.Text = getMinutes.ToString();
        }

        private void cbbHomeCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbbHomeCard.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < TeamInfor.PlayersHome.Length)
            {
                string selectedNumber = TeamInfor.PlayersHome[selectedIndex].Number;
                numHomeCard.Text = selectedNumber;
            }
        }

        private void cbbAwayCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbbAwayCard.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < TeamInfor.PlayersAway.Length)
            {
                string selectedNumber = TeamInfor.PlayersAway[selectedIndex].Number;
                numAwayCard.Text = selectedNumber;
            }
        }

        private void btnTSN_Click(object sender, EventArgs e)
        {
            UpdateMatchScore();
            StartTime = durationInMinutes * 60 + durationInSecond + 1;
            EndTime = endTime * 60;
            UpdateButtonState(sender as Button, 1);
            switch (btnTSN.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTheDo);
                    FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerBuGio);
                    clearTagButtonTheDo();
                    clearTagButtonAddTime();

                    StartTime = StartTime - 1;
                    FrmKarismaMenu.FrmSetting.loadTSNOut(TeamInfor.homeCode, TeamInfor.awayCode, Static.numberHomeScore, Static.numberAwayScore, StartTime, EndTime);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadTSN(TeamInfor.homeCode, TeamInfor.awayCode, Static.numberHomeScore, Static.numberAwayScore, StartTime, EndTime);
                    break;
            }
        }

        private void stopTSN_Click(object sender, EventArgs e)
        {
            clearTagButtonAddTime();
            clearTagButtonTheDo();
            clearTagButtonTSN();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerBuGio);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTheDo);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSN);
        }

        private void btnKickOff_Click(object sender, EventArgs e)
        {
            UpdateMatchScore();
            StartTime = durationInMinutes * 60 + durationInSecond + 2;
            EndTime = endTime * 60;
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (btnKickOff.Tag)
            {
                case 0:
                    int Time2 = StartTime - 1;
                    FrmKarismaMenu.FrmSetting.loadKickOffTimeOut(TeamInfor.homeTenNgan, TeamInfor.awayTenNgan, Static.numberHomeScore, Static.numberAwayScore,
                        TeamInfor.homeLogo, TeamInfor.awayLogo, Time2, EndTime);

                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadKickOffTime(TeamInfor.homeTenNgan, TeamInfor.awayTenNgan, Static.numberHomeScore, Static.numberAwayScore,
                        TeamInfor.homeLogo, TeamInfor.awayLogo, StartTime, EndTime);
                    break;
            }
        }
        private void stopKickOff_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void btnShowRedCard_Click(object sender, EventArgs e)
        {
            UpdateButtonState(sender as Button, 1);
            switch (btnShowRedCard.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTheDo);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.showRedCard((int)numHomeRed.Value, (int)numAwayRed.Value);
                    break;
            }
        }

        private void StopShowRedCard_Click(object sender, EventArgs e)
        {
            clearTagButtonTheDo();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTheDo);
        }

        private void HomeScore_ValueChanged(object sender, EventArgs e)
        {
            Static.numberHomeScore = HomeScore.Value.ToString();
            Static.numberAwayScore = AwayScore.Value.ToString();
            //UpdateMatchTime();

        }

        private void AwayScore_ValueChanged(object sender, EventArgs e)
        {
            Static.numberHomeScore = HomeScore.Value.ToString();
            Static.numberAwayScore = AwayScore.Value.ToString();
            //UpdateMatchTime();

        }
        private void LTHomePlayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbHomePlayer.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (LTHomePlayer.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    if (!string.IsNullOrEmpty(inforHomePlayer.Text))
                    {
                        FrmKarismaMenu.FrmSetting.loadTitleScene(cbbHomePlayer.Text, inforHomePlayer.Text, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut);
                    }
                    else
                    {
                        FrmKarismaMenu.FrmSetting.loadTitleScene(cbbHomePlayer.Text, TeamInfor.homeTenDai, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut);
                    }
                    break;
            }



        }
        private void StopLTHomePlayer_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
        }

        private void LTAwayPlayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbAwayPlayer.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (LTAwayPlayer.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    if (!string.IsNullOrEmpty(inforAwayPlayer.Text))
                    {
                        FrmKarismaMenu.FrmSetting.loadTitleScene(cbbAwayPlayer.Text, inforAwayPlayer.Text, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut);
                    }
                    else
                    {
                        FrmKarismaMenu.FrmSetting.loadTitleScene(cbbAwayPlayer.Text, TeamInfor.awayTenDai, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut);
                    }
                    break;
            }

        }
        private void StopLTAwayPlayer_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
        }
        private void SaveHomeNameGoal()
        {
            for (int i = 0; i < 10; i++)
            {
                if (string.IsNullOrEmpty(Static.HomeNameGoals[i, 0]))
                {
                    // Lấy phần tên sau dấu cách đầu tiên
                    Static.HomeNameGoals[i, 0] = cbbHomeGoal.Text.Substring(cbbHomeGoal.Text.IndexOf(' ') + 1);
                    Static.HomeNameGoals[i, 1] = numHomeGoal.Text;
                    Static.HomeNameGoals[i, 2] = GoalTimeHome.Text + "'";
                    if (checkPenHome.Checked)
                    {
                        Static.HomeNameGoals[i, 2] += " (P)";
                    }
                    break;
                }
            }
        }

        private void SaveHomeNameOG()
        {
            for (int i = 0; i < 10; i++)
            {
                if (string.IsNullOrEmpty(Static.HomeNameGoals[i, 0]))
                {
                    Static.HomeNameGoals[i, 0] = cbbHomeGoal.Text.Substring(cbbHomeGoal.Text.IndexOf(' ') + 1);
                    Static.HomeNameGoals[i, 1] = numHomeGoal.Text;
                    Static.HomeNameGoals[i, 2] = GoalTimeHome.Text + "' (OG)";
                    break;
                }
            }
        }
        private void SaveAwayNameGoal()
        {
            for (int i = 0; i < 10; i++)
            {
                if (string.IsNullOrEmpty(Static.AwayNameGoals[i, 0]))
                {
                    Static.AwayNameGoals[i, 0] = cbbAwayGoal.Text.Substring(cbbAwayGoal.Text.IndexOf(' ') + 1);
                    Static.AwayNameGoals[i, 1] = numAwayGoal.Text;
                    Static.AwayNameGoals[i, 2] = GoalTimeAway.Text + "'";
                    if (checkPenAway.Checked)
                    {
                        Static.AwayNameGoals[i, 2] += " (P)";
                    }
                    break;
                }
            }
        }

        private void SaveAwayNameOG()
        {
            for (int i = 0; i < 10; i++)
            {
                if (string.IsNullOrEmpty(Static.AwayNameGoals[i, 0]))
                {
                    Static.AwayNameGoals[i, 0] = cbbAwayGoal.Text.Substring(cbbAwayGoal.Text.IndexOf(' ') + 1);
                    Static.AwayNameGoals[i, 1] = numAwayGoal.Text;
                    Static.AwayNameGoals[i, 2] = GoalTimeAway.Text + "' (OG)";
                    break; 
                }
            }
        }

        private void ShowGoalHomePlayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbHomeGoal.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(clickedButton, 1);
            switch (ShowGoalHomePlayer.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    if (checkSaveHomeGoal.Checked)
                    {
                        SaveHomeNameGoal();
                    }
                    if (!checkPenHome.Checked)
                    {
                        FrmKarismaMenu.FrmSetting.loadGoalInfo(cbbHomeGoal.Text, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut, GoalTimeHome.Text);
                    }
                    else
                    {
                        FrmKarismaMenu.FrmSetting.loadGoalPenInfo(cbbHomeGoal.Text, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut, GoalTimeHome.Text);
                    }
                    break;
            }
        }

        private void StopGoalHomePlayer_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void ShowGoalAwayPlayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbAwayGoal.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(clickedButton, 1);
            switch (ShowGoalAwayPlayer.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    if (checkSaveAwayGoal.Checked)
                    {
                        SaveAwayNameGoal();
                    }
                    if (checkPenAway.Checked)
                    {
                        FrmKarismaMenu.FrmSetting.loadGoalPenInfo(cbbAwayGoal.Text, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut, GoalTimeAway.Text);
                    }
                    else
                    {
                        FrmKarismaMenu.FrmSetting.loadGoalInfo(cbbAwayGoal.Text, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut, GoalTimeAway.Text);
                    }
                    break;
            }
        }

        private void HomeYellow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbHomeCard.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (HomeYellow.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadYellowCard(cbbHomeCard.Text, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut);
                    break;
            }
        }

        private void AwayYellow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbAwayCard.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (AwayYellow.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadYellowCard(cbbAwayCard.Text, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut);
                    break;
            }
        }

        private void HomeCancelYellow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbHomeCard.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            //UpdateButtonState(sender as Button, 1);
            //switch (HomeCancelYellow.Tag)
            //{
            //    case 0:
            //        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
            //        break;
            //    case 1:
            //        FrmKarismaMenu.FrmSetting.loadYellowCard(cbbHomeCard.Text, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut);
            //        break;
            //}
        }

        private void AwayCancelYellow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbAwayCard.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            //UpdateButtonState(sender as Button, 1);
            //switch (HomeYellow.Tag)
            //{
            //    case 0:
            //        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
            //        break;
            //    case 1:
            //        FrmKarismaMenu.FrmSetting.loadYellowCard(cbbHomeCard.Text, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut);
            //        break;
            //}
        }

        private void Home2Yellow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbHomeCard.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (Home2Yellow.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadTwoYellowCard(cbbHomeCard.Text, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut);
                    break;
            }
        }

        private void Away2Yellow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbAwayCard.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (Away2Yellow.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadTwoYellowCard(cbbAwayCard.Text, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut);
                    break;
            }
        }

        private void HomeRed_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbHomeCard.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (HomeRed.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadRedCard(cbbHomeCard.Text, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut);
                    break;
            }
        }

        private void AwayRed_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbAwayCard.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (AwayRed.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadRedCard(cbbAwayCard.Text, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut);
                    break;
            }
        }

        private void StopHomeYellow_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void StopAwayYellow_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void StopHomeCancelYellow_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void StopAwayCancelYellow_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void StopHome2Yellow_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void StopAway2Yellow_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void StopHomeRed_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void StopAwayRed_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void showHomeCoach_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (showHomeCoach.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadCoachName(TeamInfor.homeHLV, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut);
                    break;
            }
        }

        private void stopHomeCoach_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void showAwayCoach_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (showAwayCoach.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    
                    FrmKarismaMenu.FrmSetting.loadCoachName(TeamInfor.awayHLV, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut);
                    break;
            }
        }

        private void stopAwayCoach_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void homePlayerOG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbHomeGoal.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (homePlayerOG.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadOGInfo(cbbHomeGoal.Text, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut, GoalTimeHome.Text);
                    if (checkSaveHomeGoal.Checked) // Kiểm tra checkbox trước khi lưu
                    {
                        SaveHomeNameOG();
                    }
                    break;
            }
        }

        private void awayPlayerOG_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbAwayGoal.Text))
            {
                MessageBox.Show("Chưa chọn cầu thủ");
                return;
            }
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (awayPlayerOG.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    if (checkSaveAwayGoal.Checked) // Kiểm tra checkbox trước khi lưu
                    {
                        SaveAwayNameOG();
                    }
                    FrmKarismaMenu.FrmSetting.loadOGInfo(cbbAwayGoal.Text, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut, GoalTimeAway.Text);
                    break;
            }
        }

        private void btnTransID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Chưa nhập NAME");
                return;
            }
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Chưa nhập TITLE");
                return;
            }
            else
            {
                UpdateButtonState(sender as Button, 1);
                switch (btnTransID.Tag)
                {
                    case 0:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                    case 1:
                        FrmKarismaMenu.FrmSetting.loadBarScene(txtName.Text, txtTitle.Text);
                        break;
                }
            }
        }

        private void showBXHMini_Click(object sender, EventArgs e)
        {
            //DBConfig.doGetSoccerRanking();
            //ShowMiniRanking(0, 14);
        }

        private void ShowMiniRanking(int start, int count)
        {
            string[] hang = new string[count];
            string[] team = new string[count];
            string[] diem = new string[count];

            for (int i = 0; i < count && (start + i) < DBConfig.ranking.Rows.Count; i++)
            {
                DataRow row = DBConfig.ranking.Rows[start + i];
                hang[i] = row["STT"].ToString();
                team[i] = row["TenDoi"].ToString();
                diem[i] = row["Diem"].ToString();
            }

            FrmKarismaMenu.FrmSetting.loadGrStanding(hang, team, diem);
        }

        private void stopBXHMini_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
        }

        private void WipeTrans_Click(object sender, EventArgs e)
        {
            string scene = "\\transition.t2s";
            FrmKarismaMenu.FrmSetting.loadScene(scene);
        }
        
        private void stopWipeTrans_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
        }

        private void stopALL_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopAll();
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            clearTagButtonTSN();
        }

        private void updateData_Click(object sender, EventArgs e)
        {
            FillCbbPlayerInMatchClock();
        }

        private void homeGoalEffect_Click(object sender, EventArgs e)
        {
            UpdateMatchScore();
            string tiso1 = Static.numberHomeScore;
            string tiso2 = Static.numberAwayScore;
            FrmKarismaMenu.FrmSetting.updatePermClock(tiso1, tiso2);
        }
        private void awayGoalEffect_Click(object sender, EventArgs e)
        {
            UpdateMatchScore();
            string tiso1 = Static.numberHomeScore;
            string tiso2 = Static.numberAwayScore;
            FrmKarismaMenu.FrmSetting.updatePermClock(tiso1, tiso2);
        }
        private void btnStopTrans_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
        }

        private void StopShowGoalAwayPlayer_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonTSL(clickedButton);
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
        }

        private void numHomePlayer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectPlayerByNumber(cbbHomePlayer, numHomePlayer);
            }
        }
        public static void SelectPlayerByNumber(ComboBox comboBox, TextBox textBox)
        {
            string enteredNumber = textBox.Text;

            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                string itemText = comboBox.Items[i].ToString();
                string playerNumber = itemText.Split(' ')[0].Trim();

                if (playerNumber == enteredNumber)
                {
                    comboBox.SelectedIndex = i;
                    break;
                }
            }
        }
        //đánh số ra tên
        private void numHomeGoal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectPlayerByNumber(cbbHomeGoal, numHomeGoal);
            }
        }

        private void numHomeCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectPlayerByNumber(cbbHomeCard, numHomeCard);
            }
        }

        private void numAwayPlayer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectPlayerByNumber(cbbAwayPlayer, numAwayPlayer);
            }
        }

        private void numAwayGoal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectPlayerByNumber(cbbAwayGoal, numAwayGoal);
            }
        }

        private void numAwayCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectPlayerByNumber(cbbAwayCard, numAwayCard);
            }
        }
    }
}
