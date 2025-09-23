using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace VLeague
{
    public partial class SetupUC : UserControl
    {
        string ip, port, data;
        private bool _connected;

        public SetupUC()
        {
            InitializeComponent();
        }

        private void SetupUC_Load(object sender, EventArgs e)
        {
            AppConfig.envFileConfig();
            txtIpAddress.Text = ip = AppConfig.ConfigReader.ReadString("CONNECT", "IPADDRESS");
            txtPort.Text = port = AppConfig.ConfigReader.ReadString("CONNECT", "PORT");

            radioVL1.Checked = true;
        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = Application.StartupPath + "\\config.cfg";
            psi.UseShellExecute = true;
            Process.Start(psi);
        }

        private void radioVL1_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioVL1.Checked) return;
            data = AppConfig.ConfigReader.ReadString("CONNECT", "DATAVLEAGUE1");
            txtData.Text = data;
        }

        private void radioVL2_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioVL2.Checked) return;
            data = AppConfig.ConfigReader.ReadString("CONNECT", "DATAVLEAGUE2");
            txtData.Text = data;
        }

        private void radioCQG_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioCQG.Checked) return;
            data = AppConfig.ConfigReader.ReadString("CONNECT", "DATACUPQUOCGIA");
            txtData.Text = data;
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
