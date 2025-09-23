using System;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;
using VLeague.Data;
using System.Windows.Forms;
using VLeague.Repositories;


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

        private void btnConnectDB_Click(object sender, EventArgs e)
        {
            var dbPath = txtData.Text;

            // Trong phương thức Connect hoặc event handler ở UI:
            if (!File.Exists(dbPath))
            {
                MessageBox.Show("File database không tồn tại! Vui lòng kiểm tra lại đường dẫn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tiếp tục mở kết nối nếu file tồn tại
            try
            {
                Db.Connect(dbPath);
                MessageBox.Show("Kết nối thành công đến cơ sở dữ liệu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrids();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataGrids()
        {
            try
            {
                var conn = Db.GetConnection();

                var matchesRepo = new MatchesRepo(conn);

                dgvMatches.AutoGenerateColumns = true;
                dgvMatches.DataSource = matchesRepo.GetAll();
            }
            catch (Exception ex)
            {
                Logger.Error("Load DataGrids failed", ex);
                MessageBox.Show($"Lỗi load dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
