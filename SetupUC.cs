using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLeague
{
    public partial class SetupUC : UserControl
    {
        string ip, port, data;

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

        private void btnConnectDB_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = Application.StartupPath + "\\config.cfg";
            process.Start();
        }

        private void radioVL1_CheckedChanged(object sender, EventArgs e)
        {
            data = AppConfig.ConfigReader.ReadString("CONNECT", "DATAVLEAGUE1");
            txtData.Text = data;
        }

        private void radioVL2_CheckedChanged(object sender, EventArgs e)
        {
            data = AppConfig.ConfigReader.ReadString("CONNECT", "DATAVLEAGUE2");
            txtData.Text = data;
        }

        private void radioCQG_CheckedChanged(object sender, EventArgs e)
        {
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
