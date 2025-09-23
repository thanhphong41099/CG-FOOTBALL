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
    public partial class FrmInMatchStatic : Form
    {
        public FrmInMatchStatic()
        {
            InitializeComponent();
            ButtonHelper.InitializeButtons(this);
        }
        private void clearTagButton()
        {
            Button[] buttons = new Button[]
            {showStatic1, showStatic2, showStatic3, showStatic4, showStatic5 };
            ButtonHelper.ClearTagButton(buttons);
        }
        private void clearTagButtonEx(Button clickedButton)
        {
            Button[] buttons = new Button[]
            {showStatic1, showStatic2, showStatic3, showStatic4, showStatic5 };
            ButtonHelper.ClearTagButtonEx(buttons, clickedButton);
        }

        private void UpdateButtonState(Button btn, int x)
        {
            ButtonHelper.UpdateButtonState(btn, x);
        }
        private void FrmInMatchStatic_Load(object sender, EventArgs e)
        {
            try
            {
                picHomeLogo.Image = Image.FromFile(TeamInfor.homeLogo);
                picAwayLogo.Image = Image.FromFile(TeamInfor.awayLogo);
                DBConfig.matchingMatchDetailCombobox(cbbStatic1);
                DBConfig.matchingMatchDetailCombobox(cbbStatic2);
                DBConfig.matchingMatchDetailCombobox(cbbStatic3);
                DBConfig.matchingMatchDetailCombobox(cbbStatic4);
                DBConfig.matchingMatchDetailCombobox(cbbStatic5);
                // Gọi hàm để lấy dữ liệu từ bảng THONGKE
                DBConfig.doGetAllStatistics();
                //Điền sẵn các giá trị cbbStatic
                cbbStatic1.SelectedIndex = 0;
                cbbStatic2.SelectedIndex = 1;
                cbbStatic3.SelectedIndex = 2;
                cbbStatic4.SelectedIndex = 3;
                cbbStatic5.SelectedIndex = 8;
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi load dữ liệu, vui lòng LOAD DATA ở DATA IMPORT", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void showStatic1_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (showStatic1.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadStatistic(cbbStatic1.Text, home1.Text, away1.Text, TeamInfor.homeCode, TeamInfor.awayCode);
                    break;
            }
        }

        private void showStatic2_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (showStatic2.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadStatistic2(cbbStatic1.Text, home1.Text, away1.Text, 
                        cbbStatic2.Text, home2.Text, away2.Text, TeamInfor.homeCode, TeamInfor.awayCode);
                    break;
            }
        }

        private void showStatic3_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (showStatic3.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadStatistic3(cbbStatic1.Text, home1.Text, away1.Text,
                        cbbStatic2.Text, home2.Text, away2.Text,
                        cbbStatic3.Text, home3.Text, away3.Text, 
                        TeamInfor.homeCode, TeamInfor.awayCode);
                    break;
            }
        }

        private void showStatic4_Click(object sender, EventArgs e)
        {
           //FrmKarismaMenu.FrmSetting.loadStatistic(cbbStatic4.Text, home4.Text, away4.Text, TeamInfor.homeLogo, TeamInfor.awayLogo);
 
        }

        private void showStatic5_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (showStatic5.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadStatistic5(cbbStatic1.Text, home1.Text, away1.Text,
                        cbbStatic2.Text, home2.Text, away2.Text,
                        cbbStatic3.Text, home3.Text, away3.Text,
                        cbbStatic4.Text, home4.Text, away4.Text,
                        cbbStatic5.Text, home5.Text, away5.Text,
                        TeamInfor.homeCode, TeamInfor.awayCode);
                    break;
            }
        }

        private void stopStatic1_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            clearTagButton();
        }

        private void stopStatic2_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            clearTagButton();
        }

        private void stopStatic3_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            clearTagButton();
        }

        private void stopStatic4_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            clearTagButton();
        }

        private void stopStatic5_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            clearTagButton();
        }

        private void stopAll_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopAll();
            clearTagButton();
        }

        private void updateData_Click(object sender, EventArgs e)
        {
            updateStaticToAccess();
            MessageBox.Show("Đã lưu vào bảng THONGKE");
        }
        private void updateStaticToAccess()
        {
            DBConfig.updateStatisticTieude(cbbStatic1.Text, home1.Text, away1.Text);
            DBConfig.updateStatisticTieude(cbbStatic2.Text, home2.Text, away2.Text);
            DBConfig.updateStatisticTieude(cbbStatic3.Text, home3.Text, away3.Text);
            DBConfig.updateStatisticTieude(cbbStatic4.Text, home4.Text, away4.Text);
            DBConfig.updateStatisticTieude(cbbStatic5.Text, home5.Text, away5.Text);
        }
        private void UpdateTextBoxesFromComboBoxes()
        {
            // Gọi hàm để lấy dữ liệu từ bảng THONGKE
            DBConfig.doGetAllStatistics();

            // Cập nhật giá trị cho TextBox dựa trên giá trị của ComboBox
            UpdateTextBoxFromComboBox(cbbStatic1, home1, away1);
            UpdateTextBoxFromComboBox(cbbStatic2, home2, away2);
            UpdateTextBoxFromComboBox(cbbStatic3, home3, away3);
            UpdateTextBoxFromComboBox(cbbStatic4, home4, away4);
            UpdateTextBoxFromComboBox(cbbStatic5, home5, away5);
        }

        private void UpdateTextBoxFromComboBox(ComboBox comboBox, TextBox homeTextBox, TextBox awayTextBox)
        {
            foreach (DataRow row in DBConfig.statistics.Rows)
            {
                if (row["Tieude"].ToString() == comboBox.Text)
                {
                    homeTextBox.Text = row["ChiSo1"].ToString();
                    awayTextBox.Text = row["ChiSo2"].ToString();
                    break; // Dừng vòng lặp khi tìm thấy kết quả
                }
            }
        }

        private void cbbStatic1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextBoxFromComboBox(cbbStatic1, home1, away1);
        }

        private void cbbStatic2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextBoxFromComboBox(cbbStatic2, home2, away2);
        }

        private void cbbStatic3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextBoxFromComboBox(cbbStatic3, home3, away3);
        }

        private void cbbStatic4_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextBoxFromComboBox(cbbStatic4, home4, away4);
        }

        private void cbbStatic5_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextBoxFromComboBox(cbbStatic5, home5, away5);
        }
        //Gọi hàm cập nhật giá trị Statistic thay đổi từ DBConfig
        private void UpdateStatisticForTextBox(string title, string chiso1, string chiso2)
        {
            if (!string.IsNullOrEmpty(title))
            {
                DBConfig.UpdateStatisticByTitle(title, chiso1, chiso2);
            }
        }
        //10 hàm cập nhật từng thống kê khi thay đổi giá trị vào data Access
        private void home1_TextChanged(object sender, EventArgs e)
        {
            UpdateStatisticForTextBox(cbbStatic1.Text, home1.Text, away1.Text);
        }

        private void home2_TextChanged(object sender, EventArgs e)
        {
            UpdateStatisticForTextBox(cbbStatic2.Text, home2.Text, away2.Text);
        }

        private void home3_TextChanged(object sender, EventArgs e)
        {
            UpdateStatisticForTextBox(cbbStatic3.Text, home3.Text, away3.Text);
        }

        private void home4_TextChanged(object sender, EventArgs e)
        {
            UpdateStatisticForTextBox(cbbStatic4.Text, home4.Text, away4.Text);
        }

        private void home5_TextChanged(object sender, EventArgs e)
        {
            UpdateStatisticForTextBox(cbbStatic5.Text, home5.Text, away5.Text);
        }

        private void away1_TextChanged(object sender, EventArgs e)
        {
            UpdateStatisticForTextBox(cbbStatic1.Text, home1.Text, away1.Text);
        }

        private void away2_TextChanged(object sender, EventArgs e)
        {
            UpdateStatisticForTextBox(cbbStatic2.Text, home2.Text, away2.Text);
        }

        private void away3_TextChanged(object sender, EventArgs e)
        {
            UpdateStatisticForTextBox(cbbStatic3.Text, home3.Text, away3.Text);
        }

        private void away4_TextChanged(object sender, EventArgs e)
        {
            UpdateStatisticForTextBox(cbbStatic4.Text, home4.Text, away4.Text);
        }

        private void away5_TextChanged(object sender, EventArgs e)
        {
            UpdateStatisticForTextBox(cbbStatic5.Text, home5.Text, away5.Text);
        }
    }
}
