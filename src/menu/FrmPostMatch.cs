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
using VLeague.src.helper;
using VLeague.src.model;

namespace VLeague.src.menu
{

    public partial class FrmPostMatch : Form
    {
        public FrmPostMatch()
        {
            InitializeComponent();
            ButtonHelper.InitializeButtons(this);
        }
        private void clearTagButton()
        {
            Button[] buttons = new Button[]
            {showStatic, showStaticPenalty, showPostGST};
            ButtonHelper.ClearTagButton(buttons);
        }
        private void clearTagButtonEx(Button clickedButton)
        {
            Button[] buttons = new Button[]
            {showStatic, showStaticPenalty, showPostGST};
            ButtonHelper.ClearTagButtonEx(buttons, clickedButton);
        }
        private void UpdateButtonState(Button btn, int x)
        {
            ButtonHelper.UpdateButtonState(btn, x);
        }
        private void FrmPostMatch_Load(object sender, EventArgs e)
        {
            try
            {
                cbbMatch.Items.Add("HẾT HIỆP 1");
                cbbMatch.Items.Add("HẾT HIỆP 2");
                cbbMatch.Items.Add("HẾT HIỆP 1 ET");
                cbbMatch.Items.Add("HẾT HIỆP 2 ET");
                cbbMatch.Items.Add("HẾT TRẬN");
                cbbMatch.SelectedIndex = 0;
                loadSoccerRanking();
                loadMatchStatistic();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi load dữ liệu, vui lòng LOAD DATA ở DATA IMPORT", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadSoccerRanking()
        {
            DBConfig.doGetSoccerRanking();
            dgvBXH.Rows.Clear();
            foreach (DataRow dr in DBConfig.ranking.Rows)
            {
                dgvBXH.Rows.Add(dr["STT"], dr["MaDoi"].ToString(), dr["TenDoi"].ToString(), dr["Diem"].ToString(), dr["Tran"].ToString(), dr["T"].ToString(), dr["B"].ToString(), dr["H"].ToString(), dr["HS"].ToString());
            }

            dgvBXH.Sort(dgvBXH.Columns[0], ListSortDirection.Ascending);
        }

        public void loadMatchStatistic()
        {
            DBConfig.doGetAllStatistics();
            dgvStatistic.DataSource = DBConfig.statistics;
            dgvStatistic.Columns[1].Width = 220;
            dgvStatistic.Columns[2].Width = 110;
            dgvStatistic.Columns[3].Width = 110;
            dgvStatistic.Columns[2].HeaderText = TeamInfor.homeTenDai;
            dgvStatistic.Columns[3].HeaderText = TeamInfor.awayTenDai;
        }

        private void showStatic_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (showStatic.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPostMatch);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadAllStatistic(cbbMatch.Text, TeamInfor.homeLogoIn, TeamInfor.awayLogoIn, TeamInfor.homeLogoOut, TeamInfor.awayLogoOut,
                        Static.numberHomeScore, Static.numberAwayScore, TeamInfor.homeTenNgan, TeamInfor.awayTenNgan);
                    break;
            }
        }

        private void stopStatic_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPostMatch);
        }

        private void showStaticPenalty_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (showStaticPenalty.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPostMatch);
                    break;
                case 1:
                    string text = $"PENALTY: {Static.numberHomePen} - {Static.numberAwayPen}";
                    FrmKarismaMenu.FrmSetting.loadAllStatistic(text, TeamInfor.homeLogoIn, TeamInfor.awayLogoIn, TeamInfor.homeLogoOut, TeamInfor.awayLogoOut,
                        Static.numberHomeScore, Static.numberAwayScore, TeamInfor.homeTenNgan, TeamInfor.awayTenNgan);
                    break;
            }
        }

        private void stopStaticPen_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPostMatch);
        }

        private void showPostGST_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            DBConfig.doGetSoccerRanking();
            UpdateButtonState(sender as Button, 0);
            switch (showPostGST.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPostMatch);
                    break;
                case 1:
                    ShowRankingTeam(0, 14);
                    break;
                case 2:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPostMatch);
                    break;
            }
        }

        private void ShowRankingTeam(int start, int count)
        {
            string[] team = new string[count];
            string[] diem = new string[count];
            string[] tran = new string[count];
            string[] thang = new string[count];
            string[] bai = new string[count];
            string[] hoa = new string[count];
            string[] heso = new string[count];

            for (int i = 0; i < count && (start + i) < DBConfig.ranking.Rows.Count; i++)
            {
                DataRow row = DBConfig.ranking.Rows[start + i];

                team[i] = row["TenDoi"].ToString();
                diem[i] = row["Diem"].ToString();
                tran[i] = row["Tran"].ToString();
                thang[i] = row["T"].ToString();
                bai[i] = row["B"].ToString();
                hoa[i] = row["H"].ToString();
                heso[i] = row["HS"].ToString();
            }

            FrmKarismaMenu.FrmSetting.loadFullRanking(team, diem, tran, thang, bai, hoa, heso);
        }

        private void stopPostGTS_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPostMatch);
        }

        private void updateStatic_Click(object sender, EventArgs e)
        {
            loadMatchStatistic();
            MessageBox.Show("Đã cập nhật Bảng thống kê");
        }

        private void updatePostGST_Click(object sender, EventArgs e)
        {
            loadSoccerRanking();
            MessageBox.Show("Đã cập nhật Bảng xếp hạng");
        }

        private void stopAll_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopAll();
        }

        private void saveTableToAccess_Click(object sender, EventArgs e)
        {
            dgvBXH_RowValidated();
            dgvStatistic_RowValidated();
            MessageBox.Show("Đã lưu dữ liệu bảng vào Access");
        }
        private void dgvBXH_RowValidated()
        {
            foreach (DataGridViewRow row in dgvBXH.Rows)
            {
                if (row.IsNewRow) continue; 

                int stt = Convert.ToInt32(row.Cells["STT"].Value);
                string maDoi = row.Cells["MaDoi"].Value.ToString();
                string tenDoi = row.Cells["TenDoi"].Value.ToString();
                int diem = Convert.ToInt32(row.Cells["Diem"].Value);
                int tran = Convert.ToInt32(row.Cells["Tran"].Value);
                int t = Convert.ToInt32(row.Cells["T"].Value);
                int b = Convert.ToInt32(row.Cells["B"].Value);
                int h = Convert.ToInt32(row.Cells["H"].Value);
                string hs = row.Cells["HS"].Value.ToString();

                DBConfig.updateBXH(stt, maDoi, tenDoi, diem, tran, t, b, h, hs);
            }
        }
        private void dgvStatistic_RowValidated()
        {

            foreach (DataGridViewRow row in dgvStatistic.Rows)
            {
                if (row.IsNewRow) continue;

                int stt = Convert.ToInt32(row.Cells["STT"].Value);
                string tieude = row.Cells["Tieude"].Value.ToString();
                string chiso1 = row.Cells["ChiSo1"].Value.ToString();
                string chiso2 = row.Cells["ChiSo2"].Value.ToString();

                DBConfig.updateStatistic(stt, tieude, chiso1, chiso2);
            }
        }

    }
}
