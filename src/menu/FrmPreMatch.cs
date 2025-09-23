using K3DAsyncEngineLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLeague.src.helper;
using VLeague.src.model;

namespace VLeague.src.menu
{
    public partial class FrmPreMatch : Form
    {
        //string iconTacticalPlayer, iconTacticalGK;
        Color playerColor, GKColor;

        public FrmPreMatch()
        {
            InitializeComponent();
            ButtonHelper.InitializeButtons(this);
        }

        private void clearTagButton()
        {
            Button[] buttons = new Button[]
            {
        btnWeather, btnMatchID, btnGroupSTD, btnHomeLineUp, btnAwayLineUp,
        btnHomeAllLineUp, btnAwayAllLineUp, btnReferee, btnVar
            };
            ButtonHelper.ClearTagButton(buttons);
        }
        private void clearTagButtonEx(Button clickedButton)
        {
            Button[] buttons = new Button[]
            {
        btnWeather, btnMatchID, btnGroupSTD, btnHomeLineUp, btnAwayLineUp,
        btnHomeAllLineUp, btnAwayAllLineUp, btnReferee, btnVar
            };
            ButtonHelper.ClearTagButtonEx(buttons, clickedButton);
        }
        private void UpdateButtonState(Button btn, int x)
        {
            ButtonHelper.UpdateButtonState(btn, x);
        }

        private void FrmPreMatch_Load(object sender, EventArgs e)
        {
            try
            {
                homeTeamName.Text = TeamInfor.homeTenNgan;
                awayTeamName.Text = TeamInfor.awayTenNgan;
                groupHome.BackColor = TeamInfor.Player_HomeColor;
                groupAway.BackColor = TeamInfor.Player_AwayColor;

                // Xác định màu chữ dựa trên độ sáng
                Color homeTextColor = GetContrastColor(TeamInfor.Player_HomeColor);
                Color awayTextColor = GetContrastColor(TeamInfor.Player_AwayColor);

                // Áp dụng màu chữ cho GroupBox và control con trong groupHome
                groupHome.ForeColor = homeTextColor; // Đổi màu chữ tiêu đề GroupBox
                foreach (Control ctrl in groupHome.Controls)
                {
                    if (ctrl is Label || ctrl is TextBox)
                    {
                        ctrl.ForeColor = homeTextColor;
                    }
                }

                // Áp dụng màu chữ cho GroupBox và control con trong groupAway
                groupAway.ForeColor = awayTextColor; // Đổi màu chữ tiêu đề GroupBox
                foreach (Control ctrl in groupAway.Controls)
                {
                    if (ctrl is Label || ctrl is TextBox)
                    {
                        ctrl.ForeColor = awayTextColor;
                    }
                }

                // Đảm bảo homeTeamName và awayTeamName có màu đúng
                homeTeamName.ForeColor = homeTextColor;
                awayTeamName.ForeColor = awayTextColor;
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

        private void btnMatchID_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            DBConfig.doGetInfoTournaments();
            String round = DBConfig.tournaments.Tables[0].Rows[1]["Name"].ToString();
            String date = DBConfig.tournaments.Tables[0].Rows[3]["Name"].ToString();
            String location = DBConfig.tournaments.Tables[0].Rows[2]["Name"].ToString();

            UpdateButtonState(sender as Button, 1);
            switch (btnMatchID.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPreMatch);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadMatchID(TeamInfor.homeLogoIn, TeamInfor.awayLogoIn, TeamInfor.homeLogoOut, TeamInfor.awayLogoOut, 
                        TeamInfor.homeTenNgan, TeamInfor.awayTenNgan,round, date, location);
                    break;
            }
        }
        private void btnStopMatchID_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
        }

        private void btnWeather_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            DBConfig.doGetInfoWeather();
            String Icons = DBConfig.weather.Tables[0].Rows[0]["Name"].ToString();
            String ThoiTiet = DBConfig.weather.Tables[0].Rows[1]["Name"].ToString();
            String NhietDo = DBConfig.weather.Tables[0].Rows[2]["Name"].ToString();
            String DoAm = DBConfig.weather.Tables[0].Rows[3]["Name"].ToString();
            String SucGio = DBConfig.weather.Tables[0].Rows[4]["Name"].ToString();

            UpdateButtonState(sender as Button, 1);

            switch (btnWeather.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPreMatch);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadWeather(Icons, ThoiTiet, DoAm, SucGio, NhietDo);
                    break;
            }
        }

        private void btnStopWeather_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
        }

        private void btnGroupSTD_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            DBConfig.doGetSoccerRanking();
            //Đổi icon button
            UpdateButtonState(sender as Button, 0);
            //function theo btn.tag
            switch (btnGroupSTD.Tag)
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

        private void btnStopGroupSTD_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
        }

        private void btnHomeLineUp_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (btnHomeLineUp.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPreMatch);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadLineUpSub(TeamInfor.homeTenNgan, TeamInfor.homeHLV, TeamInfor.homeLogoIn, TeamInfor.homeLogoOut, TeamInfor.PlayersHomeLineup, TeamInfor.PlayersHomeSub);
                    break;
            }           
        }

        private void StopHomeLineUp_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
        }

        private void btnHomeSub_Click(object sender, EventArgs e)
        {
        }
        private void StopHomeSub_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
        }

        private void btnHomeAllLineUp_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 0);
            switch (btnHomeAllLineUp.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPreMatch);
                    break;
                case 1:
                    playerColor = TeamInfor.Player_HomeColor;
                    GKColor = TeamInfor.GK_HomeColor;

                    FrmKarismaMenu.FrmSetting.loadLineUpSubTac(TeamInfor.homePosition , playerColor, GKColor, TeamInfor.homeTenNgan, TeamInfor.homeHLV, TeamInfor.homeTactical, 
                        TeamInfor.homeLogoIn, TeamInfor.homeLogoOut, TeamInfor.PlayersHomeLineup, TeamInfor.PlayersHomeSub); 
                    break;
                case 2:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPreMatch);
                    break;
            }           
        }

        private void StopHomeAllLineUp_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
        }

        private void btnAwayLineUp_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 1);
            switch (btnAwayLineUp.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPreMatch);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadLineUpSub(TeamInfor.awayTenNgan, TeamInfor.awayHLV, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut, TeamInfor.PlayersAwayLineup, TeamInfor.PlayersAwaySub);
                    break;
            }
        }

        private void StopAwayLineUp_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
        }

        private void btnAwaySub_Click(object sender, EventArgs e)
        {

            FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
            checkAutoResume(FrmOption.TimeOff);
        }

        private void StopAwaySub_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);

        }

        private void btnAwayAllLineUp_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            UpdateButtonState(sender as Button, 0);
            switch (btnAwayAllLineUp.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPreMatch);
                    break;
                case 1:
                    playerColor = TeamInfor.Player_AwayColor;
                    GKColor = TeamInfor.GK_AwayColor;

                    FrmKarismaMenu.FrmSetting.loadLineUpSubTac(TeamInfor.awayPosition, playerColor, GKColor, TeamInfor.awayTenNgan, TeamInfor.awayHLV, 
                        TeamInfor.awayTactical, TeamInfor.awayLogoIn, TeamInfor.awayLogoOut, TeamInfor.PlayersAwayLineup, TeamInfor.PlayersAwaySub);
                    break;
                case 2:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPreMatch);
                    break;
            }
        }

        private void StopAwayAllLineUp_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
        }

        private void SetBackground_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.loadBackGround(); 
        }

        private void btnReferee_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            DBConfig.doGetInforeferee();
            string mainReferee = DBConfig.referee.Tables[0].Rows[0]["Name"].ToString();
            string refereeOne = DBConfig.referee.Tables[0].Rows[1]["Name"].ToString();
            string refereeTwo = DBConfig.referee.Tables[0].Rows[2]["Name"].ToString();
            string refereeThree = DBConfig.referee.Tables[0].Rows[3]["Name"].ToString();
            if (mainReferee.Equals(""))
            {
                MessageBox.Show("Vui lòng thêm tên trọng tài !");
                return;
            }
            UpdateButtonState(sender as Button, 1);
            switch (btnReferee.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPreMatch);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadReferre(mainReferee, refereeOne, refereeTwo, refereeThree);
                    break;
            }

        }
        private void btnStopReferee_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
        }
        private void btnVar_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            DBConfig.doGetInforeferee();
            string varRefereeOne = DBConfig.referee.Tables[0].Rows[4]["Name"].ToString();
            string varRefereeTwo = DBConfig.referee.Tables[0].Rows[5]["Name"].ToString();
            if (varRefereeOne.Equals(""))
            {
                MessageBox.Show("Vui lòng thêm tên trọng tài !");
                return;
            }

            UpdateButtonState(sender as Button, 1);
            switch (btnVar.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerPreMatch);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadVarReferee(varRefereeOne, varRefereeTwo);
                    break;
            }
        }

        private void btnStopVar_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
        }


        private void btnTransID_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clearTagButtonEx(clickedButton);
            string scene = "\\transition.t2s";
            FrmKarismaMenu.FrmSetting.loadScene(scene);
        }

        private void btnStopTrans_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerTSL);
        }

        private void stopAll_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.StopAll();
        }


        private void btnCountDown_Click(object sender, EventArgs e)
        {
            //int startTime = (int)(minute.Value * 60 + second.Value);
            //int endTime = 0;
            //FrmKarismaMenu.FrmSetting.loadCountDown(TeamInfor.homeLogo, TeamInfor.awayLogo, startTime, endTime);
        }

        private void stopCountDown_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerTSL);
        }
        public async static void checkAutoResume(int Time)
        {
            if (FrmOption.AutoOffScene)
            {
                await Task.Delay(Time);
                FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
            }
        }
        public async static void checkAutoStopEff(int Time)
        {
            if (FrmOption.AutoOffScene)
            {
                await Task.Delay(Time);
                FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerTSL);
            }

        }
        public async static void checkAutoStop2()
        {
            if (FrmOption.AutoOffScene)
            {
                await Task.Delay(FrmOption.TimeTrans);
                FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                await Task.Delay(FrmOption.TimeOff);
                FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerTSL);
            }
            else
            {
                await Task.Delay(FrmOption.TimeTrans);
                FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
            }
        }
        public async static void checkAutoResume2()
        {
            if (FrmOption.AutoOffScene)
            {
                await Task.Delay(FrmOption.TimeTrans);
                FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
                await Task.Delay(FrmOption.TimeOff);
                FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
            }
            else
            {
                await Task.Delay(FrmOption.TimeTrans);
                FrmKarismaMenu.FrmSetting.Resume(FrmSetting.layerTSL);
            }
        }
    }
}
