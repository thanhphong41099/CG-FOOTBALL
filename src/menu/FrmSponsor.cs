using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLeague.src.menu
{
    public partial class FrmSponsor : Form
    {
        public FrmSponsor()
        {
            InitializeComponent();
        }

        private void showSponsor1_Click(object sender, EventArgs e)
        {
            string Sponsor = "\\sponsor1.t2s";
            FrmKarismaMenu.FrmSetting.loadSponsor(Sponsor);
        }

        private void stopSponsor1_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerTSL);
        }

        private void showSponsor2_Click(object sender, EventArgs e)
        {
            string Sponsor = "\\sponsor2.t2s";
            FrmKarismaMenu.FrmSetting.loadSponsor(Sponsor);
        }

        private void stopSponsor2_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerTSL);
        }

        private void showSponsor3_Click(object sender, EventArgs e)
        {
            string Sponsor = "\\sponsor3.t2s";
            FrmKarismaMenu.FrmSetting.loadSponsor(Sponsor);
        }

        private void stopSponsor3_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerTSL);
        }

        private void showSponsor4_Click(object sender, EventArgs e)
        {
            string Sponsor = "\\sponsor4.t2s";
            FrmKarismaMenu.FrmSetting.loadSponsor(Sponsor);
        }

        private void stopSponsor4_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerTSL);
        }

        private void showSponsor5_Click(object sender, EventArgs e)
        {
            string Sponsor = "\\sponsor5.t2s";
            FrmKarismaMenu.FrmSetting.loadSponsor(Sponsor);
        }

        private void stopSponsor5_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerTSL);
        }

        private void showSponsor6_Click(object sender, EventArgs e)
        {
            string Sponsor = "\\sponsor6.t2s";
            FrmKarismaMenu.FrmSetting.loadSponsor(Sponsor);
        }

        private void stopSponsor6_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerTSL);
        }

        private void stopAll_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            showSponsor1.Text = textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            showSponsor2.Text = textBox2.Text;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            showSponsor3.Text = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            showSponsor4.Text = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            showSponsor5.Text = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            showSponsor6.Text = textBox6.Text;
        }

        private void FrmSponsor_Load(object sender, EventArgs e)
        {

        }
    }
}
