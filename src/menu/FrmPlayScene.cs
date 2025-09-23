using K3DAsyncEngineLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLeague.src.menu
{
    public partial class FrmPlayScene : Form
    {
        string linkScene, Scene;
        public FrmPlayScene()
        {
            InitializeComponent();
        }

        private void EX12_Add_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;

                string[] split = FileName.Split(new char[] { '\\' });
                string SceneName = split[split.Length - 1];

                ListViewItem ListItem;
                ListItem = EX12_Scenelist.Items.Add(Convert.ToString(EX12_Scenelist.Items.Count + 1));
                ListItem.SubItems.Add(FileName);
                ListItem.SubItems.Add(SceneName);
            }
        }

        private void EX12_Delete_Click(object sender, EventArgs e)
        {
            for (int i = EX12_Scenelist.SelectedItems.Count - 1; i >= 0; i--)
            {
                EX12_Scenelist.Items.Remove(EX12_Scenelist.SelectedItems[i]);
            }
        }

        private void EX12_Apply_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(linkScene) && !string.IsNullOrEmpty(Scene))
            {
                FrmKarismaMenu.FrmSetting.LoadScene(linkScene, Scene);
                FrmKarismaMenu.FrmSetting.playScene(int.Parse(cbbLayer.Text));
            }
            else
            {
                MessageBox.Show("Chưa chọn Scene");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Stop(int.Parse(cbbLayer.Text));
        }

        private void StopAll_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.StopAll();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            FrmKarismaMenu.FrmSetting.Resume(int.Parse(cbbLayer.Text));
        }

        private void FrmPlayScene_Load(object sender, EventArgs e)
        {
            cbbLayer.Items.Add("0");
            cbbLayer.Items.Add("1");
            cbbLayer.Items.Add("2");
            cbbLayer.Items.Add("3");

            cbbLayer.SelectedIndex = 1;
        }

        private void EX12_Scenelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EX12_Scenelist.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = EX12_Scenelist.SelectedItems[0];

                linkScene = selectedItem.SubItems[1].Text;
                Scene = selectedItem.SubItems[2].Text;
            }
        }
    }
}
