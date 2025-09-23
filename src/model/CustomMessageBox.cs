using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLeague.src.model
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string message, string title)
        {
            InitializeComponent();
            this.Text = title;
            lblMessage.Text = message;
            // Tùy chỉnh màu sắc, cỡ chữ
            lblMessage.ForeColor = Color.Black;
            lblMessage.Font = new Font("Noto Sans", 12, FontStyle.Bold);
            this.BackColor = Color.White;
            this.Size = new Size(400, 200);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

