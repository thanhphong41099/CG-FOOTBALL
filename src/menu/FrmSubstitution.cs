using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLeague.src.helper;
using VLeague.src.model;

namespace VLeague.src.menu
{
    public partial class FrmSubstitution : Form
    {
        private static string workingPath = "WORKINGFOLDER";

        private static string key = "CONNECT";

        private static string PATH = AppConfig.ConfigReader.ReadString(key, workingPath);

        string[] iconPaths = {
            @"..\..\Images\playicon48.png",
            @"..\..\Images\continue1.png",
            @"..\..\Images\continue2.png"
        };
        public FrmSubstitution()
        {
            InitializeComponent();
            ButtonHelper.InitializeButtons(this);
        }
        private void clearTagButton()
        {
            Button[] buttons = new Button[]
            {subHome1, subHome2, subHome3, SubAway1, SubAway2, SubAway3};
            ButtonHelper.ClearTagButton(buttons);
        }
        private void clearTagButtonEx(Button clickedButton)
        {
            Button[] buttons = new Button[]
            {subHome1, subHome2, subHome3, SubAway1, SubAway2, SubAway3};
            ButtonHelper.ClearTagButtonEx(buttons, clickedButton);
        }
        private void UpdateButtonState(Button btn, int x)
        {
            ButtonHelper.UpdateButtonState(btn, x);
        }

        private void FrmSubstitution_Load(object sender, EventArgs e)
        {
            try
            {
                fillAllcbb();
                picHomeLogo.Image = Image.FromFile(TeamInfor.homeLogo);
                picAwayLogo.Image = Image.FromFile(TeamInfor.awayLogo);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi load dữ liệu, vui lòng LOAD DATA ở DATA IMPORT", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdatePlayerNumber(ComboBox comboBox, TextBox textBox, Player[] players)
        {
            int selectedIndex = comboBox.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < players.Length)
            {
                string selectedNumber = players[selectedIndex].Number;
                textBox.Text = selectedNumber;
            }
        }
        //Event chọn player, lấy số áo (Number) của các Cbb LineUp
        private void cbbHomeLineUp1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(cbbHomeLineUp1, numHomeLine1, TeamInfor.PlayersHome);
        }
        private void cbbHomeLineUp2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(cbbHomeLineUp2, numHomeLine2, TeamInfor.PlayersHome);
        }
        private void cbbHomeLineUp3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(cbbHomeLineUp3, numHomeLine3, TeamInfor.PlayersHome);
        }
        private void cbbAwayLineUp1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(cbbAwayLineUp1, numAwayLine1, TeamInfor.PlayersAway);
        }
        private void cbbAwayLineUp2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(cbbAwayLineUp2, numAwayLine2, TeamInfor.PlayersAway);
        }
        private void cbbAwayLineUp3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(cbbAwayLineUp3, numAwayLine3, TeamInfor.PlayersAway);
        }
        //Event chọn player, lấy số áo (Number) của các Cbb Sub
        private void cbbHomeSub1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(cbbHomeSub1, numHomeSub1, TeamInfor.PlayersHome);
        }
        private void cbbHomeSub2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(cbbHomeSub2, numHomeSub2, TeamInfor.PlayersHome);
        }
        private void cbbHomeSub3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(cbbHomeSub3, numHomeSub3, TeamInfor.PlayersHome);
        }
        private void cbbAwaySub1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(cbbAwaySub1, numAwaySub1, TeamInfor.PlayersAway);
        }
        private void cbbAwaySub2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(cbbAwaySub2, numAwaySub2, TeamInfor.PlayersAway);
        }
        private void cbbAwaySub3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlayerNumber(cbbAwaySub3, numAwaySub3, TeamInfor.PlayersAway);
        }
        //Hàm đổi cầu thủ Ra sân và Dự bị khi thay người
        private void SwapPlayer(ComboBox cbbLineUp, ComboBox cbbSub,TextBox numLineup, TextBox numSub, Player[] playerLineup, Player[] playerSub)
        {
            //int selectedIndexOut = cbbLineUp.SelectedIndex;
            //int selectedIndexIn = cbbSub.SelectedIndex;
            //string Line = cbbLineUp.Text;
            //string numLine = numLineup.Text;
            //if (selectedIndexOut >= 0 && selectedIndexOut < playerLineup.Length)
            //{
            //    playerLineup[selectedIndexOut].ShortName = cbbSub.Text;
            //    playerLineup[selectedIndexOut].Number = numSub.Text;

            //    playerSub[selectedIndexIn].ShortName = Line;
            //    playerSub[selectedIndexIn].Number = numLine;               
            //}
        }

        private void subHome1_Click(object sender, EventArgs e)
        {
            if (!ValidatePlayerSelection(cbbHomeLineUp1, cbbHomeSub1))
            {
                MessageBox.Show("Chưa chọn đủ cầu thủ ra - vào sân");
                return;
            }
            try
            {
                Button clickedButton = sender as Button;
                clearTagButtonEx(clickedButton);
                UpdateButtonState(sender as Button, 0);
                switch (subHome1.Tag)
                {
                    case 0:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                    case 1:
                        //SwapPlayer(cbbHomeLineUp1, cbbHomeSub1, numHomeLine1, numHomeSub1, TeamInfor.PlayersHome, TeamInfor.PlayersHome);
                        //fillAllcbb();

                        FrmKarismaMenu.FrmSetting.swapOnePlayer(cbbHomeLineUp1.Text,
                        cbbHomeSub1.Text, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut);
                        break;
                    case 2:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình hoán đổi cầu thủ");
            }
        }

        private void stopSubHome1_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            clearTagButton();
        }

        private void subHome2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbHomeLineUp1.Text) || string.IsNullOrWhiteSpace(cbbHomeSub1.Text) || 
                string.IsNullOrWhiteSpace(cbbHomeLineUp2.Text) || string.IsNullOrWhiteSpace(cbbHomeSub2.Text))
            {
                MessageBox.Show("Chưa chọn đủ cầu thủ ra - vào sân");
                return;
            }
            try
            {
                Button clickedButton = sender as Button;
                clearTagButtonEx(clickedButton);
                UpdateButtonState(sender as Button, 0);
                switch (subHome2.Tag)
                {
                    case 0:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                    case 1:
                        //SwapPlayer(cbbHomeLineUp1, cbbHomeSub1, numHomeLine1, numHomeSub1, TeamInfor.PlayersHome, TeamInfor.PlayersHome);
                        //SwapPlayer(cbbHomeLineUp2, cbbHomeSub2, numHomeLine2, numHomeSub2, TeamInfor.PlayersHome, TeamInfor.PlayersHome);
                        //fillAllcbb();

                        FrmKarismaMenu.FrmSetting.swapTwoPlayer(cbbHomeLineUp1.Text, cbbHomeSub1.Text, 
                            cbbHomeLineUp2.Text, cbbHomeSub2.Text, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut);
                        break;
                    case 2:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Chưa chọn đủ cầu thủ ra - vào sân");
            }
        }

        private void stopSubHome2_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            clearTagButton();
        }

        private void subHome3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbHomeLineUp1.Text) || string.IsNullOrWhiteSpace(cbbHomeSub1.Text) ||
                string.IsNullOrWhiteSpace(cbbHomeLineUp2.Text) || string.IsNullOrWhiteSpace(cbbHomeSub2.Text) ||
                string.IsNullOrWhiteSpace(cbbHomeLineUp3.Text) || string.IsNullOrWhiteSpace(cbbHomeSub3.Text))
            {
                MessageBox.Show("Chưa chọn đủ cầu thủ ra - vào sân");
                return;
            }
            try
            {
                Button clickedButton = sender as Button;
                clearTagButtonEx(clickedButton);
                UpdateButtonState(sender as Button, 0);
                switch (subHome3.Tag)
                {
                    case 0:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                    case 1:
                        //SwapPlayer(cbbHomeLineUp1, cbbHomeSub1, numHomeLine1, numHomeSub1, TeamInfor.PlayersHome, TeamInfor.PlayersHome);
                        //SwapPlayer(cbbHomeLineUp2, cbbHomeSub2, numHomeLine2, numHomeSub2, TeamInfor.PlayersHome, TeamInfor.PlayersHome);
                        //SwapPlayer(cbbHomeLineUp3, cbbHomeSub3, numHomeLine3, numHomeSub3, TeamInfor.PlayersHome, TeamInfor.PlayersHome);
                        //fillAllcbb();

                        FrmKarismaMenu.FrmSetting.swapThreePlayer(cbbHomeLineUp1.Text, cbbHomeSub1.Text, 
                            cbbHomeLineUp2.Text, cbbHomeSub2.Text, cbbHomeLineUp3.Text, cbbHomeSub3.Text, 
                        TeamInfor.homeLogoIn, TeamInfor.homeLogoOut);
                        break;
                    case 2:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                }

            }
            catch
            {
                MessageBox.Show("Chưa chọn đủ cầu thủ ra - vào sân");
            }
        }

        private void stopSubHome3_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            clearTagButton();
        }
        //Swap Away Team
        private void SubAway1_Click(object sender, EventArgs e)
        {
            if (!ValidatePlayerSelection(cbbAwayLineUp1, cbbAwaySub1))
            {
                MessageBox.Show("Chưa chọn đủ cầu thủ ra - vào sân");
                return;
            }
            try
            {
                Button clickedButton = sender as Button;
                clearTagButtonEx(clickedButton);
                UpdateButtonState(sender as Button, 0);
                switch (SubAway1.Tag)
                {
                    case 0:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                    case 1:
                        //SwapPlayer(cbbAwayLineUp1, cbbAwaySub1, numAwayLine1, numAwaySub1, TeamInfor.PlayersAway, TeamInfor.PlayersAway);
                        //fillAllcbb();

                        FrmKarismaMenu.FrmSetting.swapOnePlayer(cbbAwayLineUp1.Text,
                        cbbAwaySub1.Text, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut);
                        break;
                    case 2:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Chưa chọn đủ cầu thủ ra - vào sân");
            }
        }

        private void stopSubAway1_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            clearTagButton();
        }

        private void SubAway2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbAwayLineUp1.Text) || string.IsNullOrWhiteSpace(cbbAwaySub1.Text) ||
            string.IsNullOrWhiteSpace(cbbAwayLineUp2.Text) || string.IsNullOrWhiteSpace(cbbAwaySub2.Text))
            {
                MessageBox.Show("Chưa chọn đủ cầu thủ ra - vào sân");
                return;
            }
            try
            {
                Button clickedButton = sender as Button;
                clearTagButtonEx(clickedButton);
                UpdateButtonState(sender as Button, 0);
                switch (SubAway2.Tag)
                {
                    case 0:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                    case 1:
                        //SwapPlayer(cbbAwayLineUp1, cbbAwaySub1, numAwayLine1, numAwaySub1, TeamInfor.PlayersAway, TeamInfor.PlayersAway);
                        //SwapPlayer(cbbAwayLineUp2, cbbAwaySub2, numAwayLine2, numAwaySub2, TeamInfor.PlayersAway, TeamInfor.PlayersAway);
                        //fillAllcbb();

                        FrmKarismaMenu.FrmSetting.swapTwoPlayer(cbbAwayLineUp1.Text, cbbAwaySub1.Text,
                            cbbAwayLineUp2.Text, cbbAwaySub2.Text, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut);
                        break;
                    case 2:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Chưa chọn đủ cầu thủ ra - vào sân");
            }
        }

        private void stopSubAway2_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            clearTagButton();
        }

        private void SubAway3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbbAwayLineUp1.Text) || string.IsNullOrWhiteSpace(cbbAwaySub1.Text) ||
            string.IsNullOrWhiteSpace(cbbAwayLineUp2.Text) || string.IsNullOrWhiteSpace(cbbAwaySub2.Text) ||
            string.IsNullOrWhiteSpace(cbbAwayLineUp3.Text) || string.IsNullOrWhiteSpace(cbbAwaySub3.Text))
            {
                MessageBox.Show("Chưa chọn đủ cầu thủ ra - vào sân");
                return;
            }
            try
            {
                Button clickedButton = sender as Button;
                clearTagButtonEx(clickedButton);
                UpdateButtonState(sender as Button, 0);
                switch (SubAway3.Tag)
                {
                    case 0:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                    case 1:
                        //SwapPlayer(cbbAwayLineUp1, cbbAwaySub1, numAwayLine1, numAwaySub1, TeamInfor.PlayersAway, TeamInfor.PlayersAway);
                        //SwapPlayer(cbbAwayLineUp2, cbbAwaySub2, numAwayLine2, numAwaySub2, TeamInfor.PlayersAway, TeamInfor.PlayersAway);
                        //SwapPlayer(cbbAwayLineUp3, cbbAwaySub3, numAwayLine3, numAwaySub3, TeamInfor.PlayersAway, TeamInfor.PlayersAway);
                        //fillAllcbb();

                        FrmKarismaMenu.FrmSetting.swapThreePlayer(cbbAwayLineUp1.Text, cbbAwaySub1.Text,
                            cbbAwayLineUp2.Text, cbbAwaySub2.Text, cbbAwayLineUp3.Text, cbbAwaySub3.Text,
                            TeamInfor.awayLogoIn, TeamInfor.awayLogoOut);
                        break;
                    case 2:
                        FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Chưa chọn đủ cầu thủ ra - vào sân");
            }
        }

        private void stopSubAway3_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            clearTagButton();
        }

        private void stopAll_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopAll();
            clearTagButton();
        }
        private void fillAllcbb()
        {
            //Fill combobox Line Up
            FrmInMatchClock.FillCbbPlayer(cbbHomeLineUp1, TeamInfor.PlayersHome);
            FrmInMatchClock.FillCbbPlayer(cbbHomeLineUp2, TeamInfor.PlayersHome);
            FrmInMatchClock.FillCbbPlayer(cbbHomeLineUp3, TeamInfor.PlayersHome);
            FrmInMatchClock.FillCbbPlayer(cbbAwayLineUp1, TeamInfor.PlayersAway);
            FrmInMatchClock.FillCbbPlayer(cbbAwayLineUp2, TeamInfor.PlayersAway);
            FrmInMatchClock.FillCbbPlayer(cbbAwayLineUp3, TeamInfor.PlayersAway);
            //Fill combobox Sub
            FrmInMatchClock.FillCbbPlayer(cbbHomeSub1, TeamInfor.PlayersHome);
            FrmInMatchClock.FillCbbPlayer(cbbHomeSub2, TeamInfor.PlayersHome);
            FrmInMatchClock.FillCbbPlayer(cbbHomeSub3, TeamInfor.PlayersHome);
            FrmInMatchClock.FillCbbPlayer(cbbAwaySub1, TeamInfor.PlayersAway);
            FrmInMatchClock.FillCbbPlayer(cbbAwaySub2, TeamInfor.PlayersAway);
            FrmInMatchClock.FillCbbPlayer(cbbAwaySub3, TeamInfor.PlayersAway);
        }

        private void updateData_Click(object sender, EventArgs e)
        {
            fillAllcbb();
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
        private bool ValidatePlayerSelection(params ComboBox[] combos)
        {
            foreach (var combo in combos)
            {
                if (string.IsNullOrWhiteSpace(combo.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private void clearCbb_Click(object sender, EventArgs e)
        {
            ClearAllInputs(this);
        }

        private void numHomeLine1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmInMatchClock.SelectPlayerByNumber(cbbHomeLineUp1, numHomeLine1);
            }
        }

        private void numHomeLine2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmInMatchClock.SelectPlayerByNumber(cbbHomeLineUp2, numHomeLine2);
            }
        }

        private void numHomeLine3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmInMatchClock.SelectPlayerByNumber(cbbHomeLineUp3, numHomeLine3);
            }
        }

        private void numHomeSub1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmInMatchClock.SelectPlayerByNumber(cbbHomeSub1, numHomeSub1);
            }
        }

        private void numHomeSub2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmInMatchClock.SelectPlayerByNumber(cbbHomeSub2, numHomeSub2);
            }
        }

        private void numHomeSub3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmInMatchClock.SelectPlayerByNumber(cbbHomeSub3, numHomeSub3);
            }
        }

        private void numAwayLine1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmInMatchClock.SelectPlayerByNumber(cbbAwayLineUp1, numAwayLine1);
            }
        }

        private void numAwayLine2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmInMatchClock.SelectPlayerByNumber(cbbAwayLineUp2, numAwayLine2);
            }
        }

        private void numAwayLine3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmInMatchClock.SelectPlayerByNumber(cbbAwayLineUp3, numAwayLine3);
            }
        }

        private void numAwaySub1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmInMatchClock.SelectPlayerByNumber(cbbAwaySub1, numAwaySub1);
            }
        }

        private void numAwaySub2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmInMatchClock.SelectPlayerByNumber(cbbAwaySub2, numAwaySub2);
            }
        }

        private void numAwaySub3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrmInMatchClock.SelectPlayerByNumber(cbbAwaySub3, numAwaySub3);
            }
        }


    }
}
