using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;


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
            var dbPath = txtData.Text.Trim();

            try
            {
                using (var conn = Db.Open(dbPath)) // PRAGMA FK+WAL đã bật trong Db.Open
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT 1;";
                        cmd.ExecuteScalar(); // kiểm tra kết nối tối thiểu
                    }
                }

                MessageBox.Show("Kết nối DB thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("SQLite lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
