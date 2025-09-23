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

namespace VLeague.src.menu
{
    public partial class FrmVar : Form
    {
        string txtCheck;

        public FrmVar()
        {
            InitializeComponent();
            ButtonHelper.InitializeButtons(this);
        }

        private void clearTagButton()
        {
            Button[] buttons = new Button[]
            {checkVar, updateVar, decisionVar};
            ButtonHelper.ClearTagButton(buttons);
        }
        private void clearTagButtonEx(Button clickedButton)
        {
            Button[] buttons = new Button[]
            {checkVar, updateVar, decisionVar};
            ButtonHelper.ClearTagButtonEx(buttons, clickedButton);
        }
        private void UpdateButtonState(Button btn, int x)
        {
            ButtonHelper.UpdateButtonState(btn, x);
        }

        private void FrmVar_Load(object sender, EventArgs e)
        {
            try
            {
                string[] items1 = new string[]
                {
            "VAR ĐANG KIỂM TRA", "KIỂM TRA BÀN THẮNG", "KIỂM TRA PHẠT ĐỀN",
            "KIỂM TRA THẺ ĐỎ", "KIỂM TRA THẺ PHẠT CẦU THỦ", "XEM LẠI TÌNH HUỐNG", "KIỂM TRA HOÀN TẤT"
                };
                listUpdate.Items.AddRange(items1);
                if (listUpdate.Items.Count > 0)
                {
                    listUpdate.SelectedIndex = 0;
                }
                cbbUpdateVar.Items.AddRange(items1);
                if (cbbUpdateVar.Items.Count > 0)
                {
                    cbbUpdateVar.SelectedIndex = 0;
                }
                string[] items2 = new string[]
                {
            "BÀN THẮNG","KHÔNG BÀN THẮNG", "PHẠT ĐỀN", "KHÔNG PHẠT ĐỀN", "THẺ ĐỎ",
            "THẺ VÀNG", "XÓA THẺ VÀNG" ,"XÓA THẺ ĐỎ", "KIỂM TRA HOÀN TẤT"
                };

                cbbDecisionVar.Items.AddRange(items2);
                if (cbbDecisionVar.Items.Count > 0)
                {
                    cbbDecisionVar.SelectedIndex = 0;
                }

                listDecision.Items.AddRange(items2);
                if (listDecision.Items.Count > 0)
                {
                    listDecision.SelectedIndex = 0;
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi load dữ liệu, vui lòng LOAD DATA ở DATA IMPORT", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkVar_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (checkVar.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                    clearTagButton();

                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.varChecking(cbbUpdateVar.Text.ToUpper());
                    txtCheck = cbbUpdateVar.Text.ToUpper();

                    break;
            }
        }

        private void updateVar_Click(object sender, EventArgs e)
        {
            updateVar.Image = Properties.Resources.continue11;
            FrmKarismaMenu.FrmSetting.varUpdate(txtCheck, cbbUpdateVar.Text.ToUpper());
            txtCheck = cbbUpdateVar.Text.ToUpper();
        }

        private void decisionVar_Click(object sender, EventArgs e)
        {
            decisionVar.Image = Properties.Resources.continue11;
            FrmKarismaMenu.FrmSetting.varUpdate(txtCheck, cbbDecisionVar.Text.ToUpper());
            txtCheck = cbbDecisionVar.Text.ToUpper();
        }

        private void stopVar_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerTSL);
            clearTagButton();
        }

        private void stopAll_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopAll();
            clearTagButton();
        }

        private void listUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listUpdate.SelectedItem != null)
            {
                cbbUpdateVar.Text = listUpdate.SelectedItem.ToString();
            }
        }

        private void listDecision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDecision.SelectedItem != null)
            {
                cbbDecisionVar.Text = listDecision.SelectedItem.ToString();
            }
        }

        private void btnPinP_Click(object sender, EventArgs e)
        {
            int currentState = (int)btnPinP.Tag;
            currentState = (currentState + 1) % 2;
            btnPinP.Tag = currentState;
            switch (btnPinP.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
                    btnPinP.Text = "PICTURE IN PICTURE";
                    break;
                case 1:
                    string scene = "\\var.t2s";
                    FrmKarismaMenu.FrmSetting.loadScene(scene);
                    btnPinP.Text = "OFF";
                    break;
            }
        }
    }
}
