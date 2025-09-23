using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLeague.src.menu;

namespace VLeague.src.model
{
    public partial class FrmOption : Form
    {
        public static int TimeOff;
        public static int TimeTrans;

        public static bool AutoOffScene = false;

        public FrmOption()
        {
            InitializeComponent();
        }
        private void FrmOption_Load(object sender, EventArgs e)
        {
            numOffTime.Text = "4";
            numTransTime.Text = "5";

            if (int.TryParse(numOffTime.Text, out int offTimeValue))
            {
                TimeOff = offTimeValue * 1000;
            }
            if (int.TryParse(numTransTime.Text, out int transTimeValue))
            {
                TimeTrans = transTimeValue * 1000;
            }
        }

        private void checkAutoOffScene_CheckedChanged(object sender, EventArgs e)
        {
            AutoOffScene = checkAutoOffScene.Checked;
            numOffTime.Enabled = AutoOffScene;
        }
        private void btnApply_Click_1(object sender, EventArgs e)
        {
            bool isValid = true;

            // Kiểm tra và lấy giá trị từ numOffTime
            if (int.TryParse(numOffTime.Text, out int offTimeValue) && offTimeValue >= 4)
            {
                TimeOff = offTimeValue * 1000;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Thời gian tắt cảnh phải tối thiểu là 4 giây.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Kiểm tra và lấy giá trị từ numTransTime
            if (int.TryParse(numTransTime.Text, out int transTimeValue) && transTimeValue >= 5)
            {
                TimeTrans = transTimeValue * 1000;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Thời gian chuyển cảnh phải tối thiểu là 5 giây.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (isValid)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
