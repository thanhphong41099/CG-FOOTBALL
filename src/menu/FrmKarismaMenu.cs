using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using VLeague.src.helper;
using VLeague.src.menu;
using VLeague.src.model;

namespace VLeague
{
    public partial class FrmKarismaMenu : Form
    {
        public  FrmLowerThird FrmLowerThird;
        public static FrmSetting FrmSetting;
        public  FrmCheckLicenseKey FrmCheckLicenseKey;
        public  FrmAbout FrmAbout;
        public  FrmOption FrmOption;

        public static SetupUC setupUC;
        public static DataUC DataUC;

        public FrmKarismaMenu()
        {

            InitializeComponent();
        }
        private void FrmKarismaMenu_Load(object sender, EventArgs e)
        {
            string licenseKey = LicenseKeyHandler.readLicenseLocalFile();
            bool isLicenseKeyValid = LicenseKeyHandler.onCheckLicenseKeyIsValid(licenseKey, false);

            if (!isLicenseKeyValid)
            {
                OpenFrmCheckLicenseKey();
                bóngĐáToolStripMenuItem.Enabled = false; //check KEY False sau khi Build
            }
            else
            {
                bóngĐáToolStripMenuItem.Enabled = true;
            }
        }

        private void OpenFrmCheckLicenseKey()
        {
            if (FrmCheckLicenseKey == null || FrmCheckLicenseKey.IsDisposed)
            {
                FrmCheckLicenseKey = new FrmCheckLicenseKey();
                FrmCheckLicenseKey.MdiParent = this;
                this.panelDesktop.Controls.Add(FrmCheckLicenseKey);
            }

            FrmCheckLicenseKey.BringToFront();
            FrmCheckLicenseKey.Show();

            CenterChildFormInPanel(FrmCheckLicenseKey, panelDesktop);
        }
        private void CenterChildFormInPanel(Form childForm, Panel panel)
        {
            int centerX = (panel.Width - childForm.Width) / 2;
            int centerY = (panel.Height - childForm.Height) / 2;

            childForm.Location = new Point(centerX, centerY);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đóng ứng dụng không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void layoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string licenseKey = LicenseKeyHandler.readLicenseLocalFile();
            bool isLicenseKeyValid = LicenseKeyHandler.onCheckLicenseKeyIsValid(licenseKey, false);

            if (isLicenseKeyValid)
            {
                bóngĐáToolStripMenuItem.Enabled = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmAbout == null || FrmAbout.IsDisposed)
            {
                FrmAbout = new FrmAbout();
                FrmAbout.MdiParent = this;
                this.panelDesktop.Controls.Add(FrmAbout);
            }

            FrmAbout.BringToFront();
            FrmAbout.Show();

            CenterChildFormInPanel(FrmAbout, panelDesktop);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmOption == null || FrmOption.IsDisposed)
            {
                FrmOption = new FrmOption();
                FrmOption.MdiParent = this;
                this.panelDesktop.Controls.Add(FrmOption);
            }

            FrmOption.BringToFront();
            FrmOption.Show();

            CenterChildFormInPanel(FrmOption, panelDesktop);
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            if (setupUC == null || setupUC.IsDisposed)
            {
                setupUC = new SetupUC();
                this.panelDesktop.Controls.Add(setupUC);
            }
            setupUC.BringToFront();
            setupUC.Show();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            if (DataUC == null || DataUC.IsDisposed)
            {
                DataUC = new DataUC();
                this.panelDesktop.Controls.Add(DataUC);
            }
            DataUC.BringToFront();
            DataUC.Show();
        }

        private void btnPreMatch_Click(object sender, EventArgs e)
        {

        }

        private void btnInMatch_Click(object sender, EventArgs e)
        {

        }

        private void btnVar_Click(object sender, EventArgs e)
        {

        }

        private void btnLowerthird_Click_1(object sender, EventArgs e)
        {

        }

        private void bóngĐáToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
