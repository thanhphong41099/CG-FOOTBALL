using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VLeague.Data;
using VLeague.Repositories;
using VLeague.Session;


namespace VLeague
{
    public partial class SetupUC : UserControl
    {
        string ip, port, data;

        private NameValueCollection appSettings;

        public SetupUC()
        {
            InitializeComponent();
            // Lấy appSettings từ app.config
            appSettings = ConfigurationManager.AppSettings;
        }

        private void SetupUC_Load(object sender, EventArgs e)
        {
            // Đọc giá trị mặc định từ app.config
            ip = appSettings["DefaultIp"] ?? "127.0.0.1";
            port = appSettings["DefaultPort"] ?? "30001";

            txtIpAddress.Text = ip;
            txtPort.Text = port;

            radioVL1.Checked = true;
        }

        private void radioVL1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVL1.Checked)
            {
                data = appSettings["DATAVLEAGUE1"];
                txtData.Text = data;
            }
        }

        private void radioVL2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioVL2.Checked)
            {
                data = appSettings["DATAVLEAGUE2"];
                txtData.Text = data;
            }
        }

        private void radioCQG_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCQG.Checked)
            {
                data = appSettings["DATACUPQUOCGIA"];
                txtData.Text = data;
            }
        }

        private void btnDataBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtData.Text = openFileDialog.FileName;
            }
        }

        private void btnConnectDB_Click(object sender, EventArgs e)
        {
            var dbPath = txtData.Text;

            if (!File.Exists(dbPath))
            {
                MessageBox.Show("File database không tồn tại! Vui lòng kiểm tra lại đường dẫn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Db.Connect(dbPath);
                MessageBox.Show("Kết nối thành công đến cơ sở dữ liệu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMatchesGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigureMatchesGrid()
        {
            dgvMatches.AutoGenerateColumns = false;
            dgvMatches.Columns.Clear();

            // Cột ẩn chứa MATCH_ID
            var colMatchId = new DataGridViewTextBoxColumn
            {
                Name = "MATCH_ID",
                DataPropertyName = "MATCH_ID",
                Visible = false
            };
            dgvMatches.Columns.Add(colMatchId);

            // Cột ngày thi đấu
            var colMatchDay = new DataGridViewTextBoxColumn
            {
                Name = "MATCH_DAY",
                DataPropertyName = "MATCH_DAY",
                HeaderText = "Ngày thi đấu",
                Width = 150
            };
            dgvMatches.Columns.Add(colMatchDay);

            // Cột sân vận động
            var colStadium = new DataGridViewTextBoxColumn
            {
                Name = "STADIUM",
                DataPropertyName = "STADIUM",
                HeaderText = "Sân vận động",
                Width = 150
            };
            dgvMatches.Columns.Add(colStadium);

            // Cột đội nhà
            var colHomeName = new DataGridViewTextBoxColumn
            {
                Name = "HOME_NAME",
                DataPropertyName = "HOME_NAME",
                HeaderText = "Đội nhà",
                Width = 220
            };
            dgvMatches.Columns.Add(colHomeName);

            // Cột đội khách
            var colAwayName = new DataGridViewTextBoxColumn
            {
                Name = "AWAY_NAME",
                DataPropertyName = "AWAY_NAME",
                HeaderText = "Đội khách",
                Width = 220
            };
            dgvMatches.Columns.Add(colAwayName);
        }

        private void LoadMatchesGrid()
        {
            ConfigureMatchesGrid();
            try
            {
                var conn = Db.GetConnection();
                var matchesRepo = new MatchesRepo(conn);
                var matchesList = matchesRepo.GetAll();

                dgvMatches.DataSource = matchesList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load danh sách trận: {ex.Message}");
            }
        }

        private void dgvMatches_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMatches.CurrentRow != null)
            {
                int matchId = (int)dgvMatches.CurrentRow.Cells["MATCH_ID"].Value;
            }
        }

        private void btnSelectMatch_Click(object sender, EventArgs e)
        {
            int selectedMatchId = (int)dgvMatches.CurrentRow.Cells["MATCH_ID"].Value;
            string matchInfo = $"{dgvMatches.CurrentRow.Cells["HOME_NAME"].Value} vs " +
                              $"{dgvMatches.CurrentRow.Cells["AWAY_NAME"].Value}";

            // Lưu vào session
            MessageBox.Show($"Đã chọn trận: {matchInfo}", "Thành công",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

            // TODO: Thực hiện các hành động tiếp theo ở đây
            ProcessSelectedMatch(selectedMatchId);
        }

        private void ProcessSelectedMatch(int matchId)
        {
            try
            {
                // Clear cache dữ liệu cũ
                DataManager.ClearCache();

                // Load tất cả dữ liệu cho trận mới
                DataManager.LoadMatchData(matchId);

                MessageBox.Show("Đã load xong dữ liệu trận đấu!", "Thành công");
            }
            catch (Exception ex)
            {
                Logger.Error($"Error loading match {matchId} data", ex);
                MessageBox.Show($"Lỗi load dữ liệu: {ex.Message}");
            }
        }

    }
}
