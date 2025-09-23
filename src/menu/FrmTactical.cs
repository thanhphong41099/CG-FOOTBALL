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
using VLeague.src.model;
namespace VLeague.src.menu
{
    public partial class FrmTactical : Form
    {
        public static Dictionary<string, Point> groupBoxPositions = new Dictionary<string, Point>();

        private Dictionary<string, Point[]> tacticalFormations;

        private List<Point> playerHomePositions = new List<Point>();
        private List<Point> playerAwayPositions = new List<Point>();

        private List<Point> originalHomePositions = new List<Point>();
        private List<Point> originalAwayPositions = new List<Point>();

        int saveTeam;

        public FrmTactical()
        {
            InitializeComponent();
            InitializeTacticalFormations();
        }

        private void FrmTactical_Load(object sender, EventArgs e)
        {
            try
            {
                ControlDraggable();

                homeNgan.Text = TeamInfor.homeCode;
                awayNgan.Text = TeamInfor.awayCode;

                DBConfig.matchingTacticalCombobox(cbbTacticalAway);
                cbbTacticalAway.Text = TeamInfor.awayTactical;
                LoadOriginalPositions(originalAwayPositions);

                DBConfig.matchingTacticalCombobox(cbbTacticalHome);
                cbbTacticalHome.Text = TeamInfor.homeTactical;
                LoadOriginalPositions(originalHomePositions);
                loadHomeTeam();
                saveTeam = 1;
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi load dữ liệu, vui lòng LOAD DATA ở DATA IMPORT", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitializeTacticalFormations()
        {
            tacticalFormations = new Dictionary<string, Point[]>
    {
        { "4 - 3 - 3", new Point[]
            {
                new Point(406, 553),
                new Point(106, 395), new Point(292, 395), new Point(512, 395), new Point(700, 395),
                new Point(221, 222), new Point(406, 222), new Point(603, 221),
                new Point(223, 39), new Point(407, 39), new Point(604, 38)
            }},
        { "3 - 4 - 1 - 2", new Point[]
            {
                new Point(406, 553),
                new Point(224, 408), new Point(407, 406), new Point(596, 406),
                new Point(133, 249), new Point(317, 248), new Point(498, 248), new Point(686, 247),
                new Point(414, 96),
                new Point(251, 35), new Point(582, 35)
            }},
        { "3 - 4 - 3", new Point[]
            {
            new Point(406, 553),
                new Point(224, 408), new Point(407, 406), new Point(596, 406),
                new Point(133, 240), new Point(317, 240), new Point(498, 240), new Point(686, 240),
                new Point(224, 65), new Point(407, 65), new Point(596, 65)
            }},
        { "3 - 5 - 2", new Point[] {
            new Point(406, 553),
                new Point(224, 408), new Point(407, 406), new Point(596, 406),
                new Point(70, 240), new Point(237, 240), new Point(407, 240), new Point(581, 240), new Point(743, 240),
                new Point(311, 75), new Point(507, 75)
        }},
        { "4 - 1 - 4 - 1", new Point[] {
            new Point(406, 553),
                new Point(119, 410), new Point(309, 410), new Point(507, 410), new Point(700, 410),
                new Point(409, 270),
                new Point(92, 183), new Point(255, 183), new Point(567, 183), new Point(739, 183),
                new Point(408, 36)
        }},
            { "4 - 2 - 3 - 1", new Point[] {
            new Point(406, 553),
            new Point(116, 410), new Point(309, 410), new Point(507, 410), new Point(700, 410),
            new Point(267, 260), new Point(550, 260),
            new Point(116, 175), new Point(406, 175), new Point(702, 175),
            new Point(407, 26) // Tiền đạo
        }},
            { "4 - 3 - 1 - 2", new Point[] {
            new Point(406, 553),
            new Point(119, 419), new Point(309, 420),new Point(507, 420), new Point(700, 420),
            new Point(221, 279), new Point(408, 278), new Point(599, 278),
            new Point(407, 136),
            new Point(600, 45),  new Point(220, 49)
        }},
            { "4 - 4 - 1 - 1", new Point[] {
            new Point(406, 553),
            new Point(119, 410), new Point(309, 410), new Point(507, 410), new Point(700, 410),
            new Point(119, 286), new Point(309, 286), new Point(507, 286), new Point(700, 286),
            new Point(409, 148),
            new Point(409, 12)
        }},
            { "4 - 4 - 2", new Point[] {
            new Point(406, 553),
            new Point(119, 419), new Point(309, 420), new Point(507, 420), new Point(700, 420),
            new Point(119, 250), new Point(309, 250), new Point(507, 250), new Point(700, 250),
            new Point(309, 90), new Point(507, 90)
        }},
            { "4 - 5 - 1", new Point[] {
            new Point(406, 553),
            new Point(119, 419), new Point(309, 420), new Point(507, 420), new Point(700, 420),
            new Point(70, 270), new Point(237, 270), new Point(407, 270), new Point(581, 270), new Point(743, 270),
            new Point(407, 106)
        }},
            { "5 - 3 - 2", new Point[] {
            new Point(406, 553),
            new Point(70, 416), new Point(237, 416), new Point(407, 416), new Point(581, 416), new Point(743, 416),
            new Point(224, 270), new Point(407, 270), new Point(596, 270),
            new Point(311, 106), new Point(507, 106)
        }},
            { "5 - 4 - 1", new Point[] {
            new Point(406, 553),
            new Point(70, 416), new Point(237, 416), new Point(407, 416), new Point(581, 416), new Point(743, 416),
            new Point(119, 270), new Point(309, 270), new Point(507, 270), new Point(700, 270),
            new Point(407, 106)
        }},
    };
        }
        private void ControlDraggable()
        {
            // Danh sách các GroupBox
            System.Windows.Forms.GroupBox[] groupBoxes = { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5,
                               groupBox6, groupBox7, groupBox8, groupBox9, groupBox10,
                               groupBox11 };

            // Lặp qua từng GroupBox và gọi hàm Draggable
            foreach (var groupBox in groupBoxes)
            {
                ControlExtension.Draggable(groupBox, true);
            }
        }
        private void LoadOriginalPositions(List<Point> originalPositions)
        {
            // Lưu tọa độ gốc cho đội nhà
            originalPositions.Clear();
            originalPositions.Add(groupBox1.Location);
            originalPositions.Add(groupBox2.Location);
            originalPositions.Add(groupBox3.Location);
            originalPositions.Add(groupBox4.Location);
            originalPositions.Add(groupBox5.Location);
            originalPositions.Add(groupBox6.Location);
            originalPositions.Add(groupBox7.Location);
            originalPositions.Add(groupBox8.Location);
            originalPositions.Add(groupBox9.Location);
            originalPositions.Add(groupBox10.Location);
            originalPositions.Add(groupBox11.Location);
        }

        private void loadHomeTeam()
        {
            for (int i = 0; i < 11; i++)
            {
                Label labelName = this.Controls.Find($"labelName{i + 1}", true).FirstOrDefault() as Label;
                if (!string.IsNullOrEmpty(TeamInfor.PlayersHomeLineup[i].ShortName))
                {
                    labelName.Text = TeamInfor.PlayersHomeLineup[i].ShortName;
                }
                else
                { labelName.Text = "Unknown Player"; }

                PictureBox pictureBox = this.Controls.Find($"pic{i + 1}", true).FirstOrDefault() as PictureBox;
                if (!string.IsNullOrEmpty(TeamInfor.PlayersHomeLineup[i].Image) && File.Exists(TeamInfor.PlayersHomeLineup[i].Image))
                {
                    pictureBox.Image = Image.FromFile(TeamInfor.PlayersHomeLineup[i].Image);
                }
                else
                { pictureBox.Image = Properties.Resources.Home_Player_Shirt; }
            }
            cbbTacticalHome.Text = TeamInfor.homeTactical;
            txtTeamName.Text = TeamInfor.homeTenNgan;
        }
        private void loadAwayTeam()
        {
            for (int i = 0; i < 11; i++)
            {
                Label labelName = this.Controls.Find($"labelName{i + 1}", true).FirstOrDefault() as Label;
                if (!string.IsNullOrEmpty(TeamInfor.PlayersAwayLineup[i].ShortName))
                {
                    labelName.Text = TeamInfor.PlayersAwayLineup[i].ShortName;
                }
                else
                { labelName.Text = "Unknown Player"; }

                PictureBox pictureBox = this.Controls.Find($"pic{i + 1}", true).FirstOrDefault() as PictureBox;
                if (!string.IsNullOrEmpty(TeamInfor.PlayersAwayLineup[i].Image) && File.Exists(TeamInfor.PlayersAwayLineup[i].Image))
                {
                    pictureBox.Image = Image.FromFile(TeamInfor.PlayersAwayLineup[i].Image);
                }
                else
                { pictureBox.Image = Properties.Resources.Home_Player_Shirt; }
            }
            cbbTacticalAway.Text = TeamInfor.awayTactical;
            txtTeamName.Text = TeamInfor.awayTenNgan;
        }

        private void HomeTeam_Click(object sender, EventArgs e)
        {
            saveTeam = 1;
            loadHomeTeam();
            RestoreOriginalPositions(originalHomePositions);
        }
        private void AwayTeam_Click(object sender, EventArgs e)
        {
            saveTeam = 2;
            loadAwayTeam();
            RestoreOriginalPositions(originalAwayPositions);
        }
        private void cbbTacticalHome_SelectedIndexChanged(object sender, EventArgs e)
        {
            TeamInfor.homeTactical = cbbTacticalHome.Text;
            if (tacticalFormations.TryGetValue(cbbTacticalHome.SelectedItem.ToString(), out Point[] positions))
            {
                for (int i = 0; i < 11; i++)
                {
                    var groupBox = this.Controls.Find($"groupBox{i + 1}", true).FirstOrDefault() as GroupBox;
                    if (groupBox != null)
                    {
                        groupBox.Location = positions[i];
                    }
                }
                saveTeam = 1;
                loadHomeTeam();
                LoadOriginalPositions(originalHomePositions);
            }
        }
        private void cbbTacticalAway_SelectedIndexChanged(object sender, EventArgs e)
        {
            TeamInfor.awayTactical = cbbTacticalAway.Text;
            if (tacticalFormations.TryGetValue(cbbTacticalAway.SelectedItem.ToString(), out Point[] positions))
            {
                for (int i = 0; i < 11; i++)
                {
                    var groupBox = this.Controls.Find($"groupBox{i + 1}", true).FirstOrDefault() as GroupBox;
                    if (groupBox != null)
                    {
                        groupBox.Location = positions[i];
                    }
                }
                saveTeam = 2;
                loadAwayTeam();
                LoadOriginalPositions(originalAwayPositions);
            }
        }

        private void SaveplayerHomePositions()
        {
            // Xóa danh sách cũ trước khi thêm tọa độ mới
            playerHomePositions.Clear();

            int a = -400;
            int b = -400;
            double c = -1.5;

            // Lưu vị trí cho từng GroupBox với X + a và Y + b, sau đó nhân tọa độ với c
            playerHomePositions.Add(new Point((int)((groupBox1.Location.X + a) * -c), (int)((groupBox1.Location.Y + b) * c)));
            playerHomePositions.Add(new Point((int)((groupBox2.Location.X + a) * -c), (int)((groupBox2.Location.Y + b) * c)));
            playerHomePositions.Add(new Point((int)((groupBox3.Location.X + a) * -c), (int)((groupBox3.Location.Y + b) * c)));
            playerHomePositions.Add(new Point((int)((groupBox4.Location.X + a) * -c), (int)((groupBox4.Location.Y + b) * c)));
            playerHomePositions.Add(new Point((int)((groupBox5.Location.X + a) * -c), (int)((groupBox5.Location.Y + b) * c)));
            playerHomePositions.Add(new Point((int)((groupBox6.Location.X + a) * -c), (int)((groupBox6.Location.Y + b) * c)));
            playerHomePositions.Add(new Point((int)((groupBox7.Location.X + a) * -c), (int)((groupBox7.Location.Y + b) * c)));
            playerHomePositions.Add(new Point((int)((groupBox8.Location.X + a) * -c), (int)((groupBox8.Location.Y + b) * c)));
            playerHomePositions.Add(new Point((int)((groupBox9.Location.X + a) * -c), (int)((groupBox9.Location.Y + b) * c)));
            playerHomePositions.Add(new Point((int)((groupBox10.Location.X + a) * -c), (int)((groupBox10.Location.Y + b) * c)));
            playerHomePositions.Add(new Point((int)((groupBox11.Location.X + a) * -c), (int)((groupBox11.Location.Y + b) * c)));
        }
        private void SaveplayerAwayPositions()
        {
            // Xóa danh sách cũ trước khi thêm tọa độ mới
            playerAwayPositions.Clear();

            int a = -400;
            int b = -400;
            double c = -1.5;

            // Lưu vị trí cho từng GroupBox với X + a và Y + b, sau đó nhân tọa độ với c
            playerAwayPositions.Add(new Point((int)((groupBox1.Location.X + a) * -c), (int)((groupBox1.Location.Y + b) * c)));
            playerAwayPositions.Add(new Point((int)((groupBox2.Location.X + a) * -c), (int)((groupBox2.Location.Y + b) * c)));
            playerAwayPositions.Add(new Point((int)((groupBox3.Location.X + a) * -c), (int)((groupBox3.Location.Y + b) * c)));
            playerAwayPositions.Add(new Point((int)((groupBox4.Location.X + a) * -c), (int)((groupBox4.Location.Y + b) * c)));
            playerAwayPositions.Add(new Point((int)((groupBox5.Location.X + a) * -c), (int)((groupBox5.Location.Y + b) * c)));
            playerAwayPositions.Add(new Point((int)((groupBox6.Location.X + a) * -c), (int)((groupBox6.Location.Y + b) * c)));
            playerAwayPositions.Add(new Point((int)((groupBox7.Location.X + a) * -c), (int)((groupBox7.Location.Y + b) * c)));
            playerAwayPositions.Add(new Point((int)((groupBox8.Location.X + a) * -c), (int)((groupBox8.Location.Y + b) * c)));
            playerAwayPositions.Add(new Point((int)((groupBox9.Location.X + a) * -c), (int)((groupBox9.Location.Y + b) * c)));
            playerAwayPositions.Add(new Point((int)((groupBox10.Location.X + a) * -c), (int)((groupBox10.Location.Y + b) * c)));
            playerAwayPositions.Add(new Point((int)((groupBox11.Location.X + a) * -c), (int)((groupBox11.Location.Y + b) * c)));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveTeam == 1)
            {
                SaveplayerHomePositions(); // Lưu vị trí của đội nhà
                TeamInfor.homePosition = new List<Point>(playerHomePositions); // Gán đúng danh sách cho TeamInfor
                LoadOriginalPositions(originalHomePositions);
                MessageBox.Show("Lưu chiến thuật HOME");

            }
            else if (saveTeam == 2)
            {
                SaveplayerAwayPositions(); // Lưu vị trí của đội khách
                TeamInfor.awayPosition = new List<Point>(playerAwayPositions); // Gán đúng danh sách cho TeamInfor
                LoadOriginalPositions(originalAwayPositions);
                MessageBox.Show("Lưu chiến thuật AWAY");
            }
        }
        private void RestoreOriginalPositions(List<Point> originalPositions)
        {
            groupBox1.Location = originalPositions[0];
            groupBox2.Location = originalPositions[1];
            groupBox3.Location = originalPositions[2];
            groupBox4.Location = originalPositions[3];
            groupBox5.Location = originalPositions[4];
            groupBox6.Location = originalPositions[5];
            groupBox7.Location = originalPositions[6];
            groupBox8.Location = originalPositions[7];
            groupBox9.Location = originalPositions[8];
            groupBox10.Location = originalPositions[9];
            groupBox11.Location = originalPositions[10];
        }
    }
}

