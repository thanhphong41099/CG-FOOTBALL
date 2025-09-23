using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLeague.src.helper;
using VLeague.src.model;

namespace VLeague.src.menu
{
    public partial class FrmPenalty : Form
    {

        string red = FrmKarismaMenu.FrmSetting.txtWorkingFolder.Text + "\\LPBank_TV Graphics\\4_PENALTY\\ICON\\ra.png";
        string green = FrmKarismaMenu.FrmSetting.txtWorkingFolder.Text + "\\LPBank_TV Graphics\\4_PENALTY\\ICON\\vao.png";
        string white = FrmKarismaMenu.FrmSetting.txtWorkingFolder.Text + "\\LPBank_TV Graphics\\4_PENALTY\\ICON\\default.png";

        string[] home = new string[5];
        string[] away = new string[5];
        public FrmPenalty()
        {
            InitializeComponent();
            ButtonHelper.InitializeButtons(this);

        }
        private void clearTagButton()
        {
            Button[] buttons = new Button[]
            {showPenalty};
            ButtonHelper.ClearTagButton(buttons);
        }

        private void UpdateButtonState(Button btn, int x)
        {
            ButtonHelper.UpdateButtonState(btn, x);
        }
        private void FrmPenalty_Load(object sender, EventArgs e)
        {
            try
            {
                homeName.Text = TeamInfor.homeTenDai;
                awayName.Text = TeamInfor.awayTenDai;
                picHomeColor.BackColor = TeamInfor.Player_HomeColor;
                picAwayColor.BackColor = TeamInfor.Player_AwayColor;
                picHomeLogo.Image = Image.FromFile(TeamInfor.homeLogo);
                picAwayLogo.Image = Image.FromFile(TeamInfor.awayLogo);
                FillComboBoxes();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi load dữ liệu, vui lòng LOAD DATA ở DATA IMPORT", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillComboBoxes()
        {
            ComboBox[] comboBoxes = { cbbHome1, cbbHome2, cbbHome3, cbbHome4, cbbHome5,
                              cbbAway1, cbbAway2, cbbAway3, cbbAway4, cbbAway5 };

            string[] values = { "", "Vào", "Ra" };

            foreach (ComboBox comboBox in comboBoxes)
            {
                comboBox.Items.Clear();
                comboBox.Items.AddRange(values);
                comboBox.SelectedIndex = 0;
            }
        }
        private void loadHomeShootout(ComboBox cbb, PictureBox pic)
        {
            if (cbb.SelectedIndex == 1)
            {
                pic.ImageLocation = green;
                numHomePen.Value += 1;
            }
            else if (cbb.SelectedIndex == 2)
            {
                pic.ImageLocation = red;
            }
            else
            {
                pic.ImageLocation = white;
            }
        }
        private void loadAwayShootout(ComboBox cbb, PictureBox pic)
        {
            if (cbb.SelectedIndex == 1)
            {
                pic.ImageLocation = green;
                numAwayPen.Value += 1;
            }
            else if (cbb.SelectedIndex == 2)
            {
                pic.ImageLocation = red;
            }
            else
            {
                pic.ImageLocation = white;
            }
        }
        private void showPenalty_Click(object sender, EventArgs e)
        {
            updateImagePen();
            UpdateButtonState(sender as Button, 1);
            switch (showPenalty.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPenalty);

                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadPenalty(TeamInfor.homeTenNgan, TeamInfor.awayTenNgan, TeamInfor.homeLogo,
                        TeamInfor.awayLogo, numHomePen.Value.ToString(), numAwayPen.Value.ToString(), numRound.Value.ToString(), home, away);
                    break;
            }
        }
        private void cbbHome1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadHomeShootout(cbbHome1, picHomePen1);
        }

        private void cbbHome2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadHomeShootout(cbbHome2, picHomePen2);
        }

        private void cbbHome3_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadHomeShootout(cbbHome3, picHomePen3);
        }

        private void cbbHome4_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadHomeShootout(cbbHome4, picHomePen4);
        }

        private void cbbHome5_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadHomeShootout(cbbHome5, picHomePen5);
        }

        private void cbbAway1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadAwayShootout(cbbAway1, picAwayPen1);
        }

        private void cbbAway2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadAwayShootout(cbbAway2, picAwayPen2);
        }

        private void cbbAway3_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadAwayShootout(cbbAway3, picAwayPen3);
        }

        private void cbbAway4_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadAwayShootout(cbbAway4, picAwayPen4);
        }

        private void cbbAway5_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadAwayShootout(cbbAway5, picAwayPen5);
        }

        private void stopPenalty_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPenalty);
        }

        private void ResetRound_Click(object sender, EventArgs e)
        {
            ComboBox[] comboBoxes = { cbbHome1, cbbHome2, cbbHome3, cbbHome4, cbbHome5,
                                  cbbAway1, cbbAway2, cbbAway3, cbbAway4, cbbAway5 };

            foreach (ComboBox comboBox in comboBoxes)
            {
                if (comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
        }

        private void stopAll_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.StopAll();
        }

        private void numHomePen_ValueChanged(object sender, EventArgs e)
        {
            Static.numberHomePen = (int)numHomePen.Value;
        }

        private void numAwayPen_ValueChanged(object sender, EventArgs e)
        {
            Static.numberAwayPen = (int)numAwayPen.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateImagePen();
            FrmKarismaMenu.FrmSetting.updatePenalty(numHomePen.Value.ToString(), numAwayPen.Value.ToString(), home, away);
        }
        private void updateImagePen()
        {
            home[0] = picHomePen1.ImageLocation;
            home[1] = picHomePen2.ImageLocation;
            home[2] = picHomePen3.ImageLocation;
            home[3] = picHomePen4.ImageLocation;
            home[4] = picHomePen5.ImageLocation;

            away[0] = picAwayPen1.ImageLocation;
            away[1] = picAwayPen2.ImageLocation;
            away[2] = picAwayPen3.ImageLocation;
            away[3] = picAwayPen4.ImageLocation;
            away[4] = picAwayPen5.ImageLocation;
        }
    }
}
