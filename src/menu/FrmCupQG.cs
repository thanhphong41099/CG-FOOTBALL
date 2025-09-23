using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLeague.src.helper;
using VLeague.src.model;

namespace VLeague.src.menu
{
    public partial class FrmCupQG : Form
    {
        private static string workingPath = "WORKINGFOLDER";

        private static string key = "CONNECT";

        private static string PATH = AppConfig.ConfigReader.ReadString(key, workingPath);

        public FrmCupQG()
        {
            InitializeComponent();
            ButtonHelper.InitializeButtons(this);
        }

        private void clearTagButton()
        {
            Button[] buttons = new Button[]
            {btnCupQG};
            ButtonHelper.ClearTagButton(buttons);
        }
        private void UpdateButtonState(Button btn, int x)
        {
            ButtonHelper.UpdateButtonState(btn, x);
        }
        private void FrmCupQG_Load(object sender, EventArgs e)
        {
            try
            {
                link.Text = PATH + "\\Scenes\\Images\\cupquocgia.jpg";
                picCupQG.Image = Image.FromFile(link.Text);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Có lỗi xảy ra khi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLinkBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    link.Text = openFileDialog.FileName;
                    picCupQG.Image = Image.FromFile(link.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnCupQG_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            UpdateButtonState(sender as Button, 1);
            switch (btnCupQG.Tag)
            {
                case 0:
                    FrmKarismaMenu.FrmSetting.StopEff(FrmSetting.layerPreMatch);
                    break;
                case 1:
                    FrmKarismaMenu.FrmSetting.loadCupQG(link.Text);
                    break;
            }
        }

        private void btnStopCupQG_Click(object sender, EventArgs e)
        {
            clearTagButton();
            FrmKarismaMenu.FrmSetting.Stop(FrmSetting.layerPreMatch);
        }
        private void UpdateImage()
        {
            if (File.Exists(link.Text))  // Kiểm tra nếu file tồn tại
            {
                picCupQG.Image = Image.FromFile(link.Text);
            }
            else
            {
                MessageBox.Show("Đường dẫn không hợp lệ.");
            }
        }

        private void link_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateImage();
                e.SuppressKeyPress = true;  // Ngăn không cho tiếng "ding" của Enter vang lên
            }
        }
    }
}
