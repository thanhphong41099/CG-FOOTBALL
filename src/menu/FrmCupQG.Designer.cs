namespace VLeague.src.menu
{
    partial class FrmCupQG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCupQG));
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.btnLinkBrowser = new System.Windows.Forms.Button();
            this.link = new System.Windows.Forms.TextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.btnStopCupQG = new System.Windows.Forms.Button();
            this.btnCupQG = new System.Windows.Forms.Button();
            this.picCupQG = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCupQG)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.btnLinkBrowser);
            this.groupBox18.Controls.Add(this.link);
            this.groupBox18.Controls.Add(this.label86);
            this.groupBox18.Controls.Add(this.btnStopCupQG);
            this.groupBox18.Controls.Add(this.btnCupQG);
            this.groupBox18.Font = new System.Drawing.Font("Noto Sans SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox18.Location = new System.Drawing.Point(101, 61);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(990, 148);
            this.groupBox18.TabIndex = 16;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "KẾT QUẢ CUP QG";
            // 
            // btnLinkBrowser
            // 
            this.btnLinkBrowser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLinkBrowser.Location = new System.Drawing.Point(553, 60);
            this.btnLinkBrowser.Name = "btnLinkBrowser";
            this.btnLinkBrowser.Size = new System.Drawing.Size(36, 25);
            this.btnLinkBrowser.TabIndex = 193;
            this.btnLinkBrowser.Text = "...";
            this.btnLinkBrowser.UseVisualStyleBackColor = true;
            this.btnLinkBrowser.Click += new System.EventHandler(this.btnLinkBrowser_Click);
            // 
            // link
            // 
            this.link.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.link.Location = new System.Drawing.Point(121, 60);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(413, 23);
            this.link.TabIndex = 192;
            this.link.KeyDown += new System.Windows.Forms.KeyEventHandler(this.link_KeyDown);
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label86.Location = new System.Drawing.Point(37, 63);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(74, 15);
            this.label86.TabIndex = 191;
            this.label86.Text = "LINK IMAGE:";
            // 
            // btnStopCupQG
            // 
            this.btnStopCupQG.Image = ((System.Drawing.Image)(resources.GetObject("btnStopCupQG.Image")));
            this.btnStopCupQG.Location = new System.Drawing.Point(859, 38);
            this.btnStopCupQG.Name = "btnStopCupQG";
            this.btnStopCupQG.Size = new System.Drawing.Size(73, 68);
            this.btnStopCupQG.TabIndex = 8;
            this.btnStopCupQG.UseVisualStyleBackColor = true;
            this.btnStopCupQG.Click += new System.EventHandler(this.btnStopCupQG_Click);
            // 
            // btnCupQG
            // 
            this.btnCupQG.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCupQG.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCupQG.Image = global::VLeague.Properties.Resources.playicon481;
            this.btnCupQG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCupQG.Location = new System.Drawing.Point(647, 38);
            this.btnCupQG.Name = "btnCupQG";
            this.btnCupQG.Size = new System.Drawing.Size(179, 68);
            this.btnCupQG.TabIndex = 9;
            this.btnCupQG.Text = "KQ CUP QG";
            this.btnCupQG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCupQG.UseVisualStyleBackColor = true;
            this.btnCupQG.Click += new System.EventHandler(this.btnCupQG_Click);
            // 
            // picCupQG
            // 
            this.picCupQG.Location = new System.Drawing.Point(101, 244);
            this.picCupQG.Name = "picCupQG";
            this.picCupQG.Size = new System.Drawing.Size(990, 566);
            this.picCupQG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCupQG.TabIndex = 17;
            this.picCupQG.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans SemiBold", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(473, 835);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 30);
            this.label1.TabIndex = 18;
            this.label1.Text = "KẾT QUẢ CUP QUỐC GIA";
            // 
            // FrmCupQG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1670, 950);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCupQG);
            this.Controls.Add(this.groupBox18);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCupQG";
            this.Text = "KQ Cup QG";
            this.Load += new System.EventHandler(this.FrmCupQG_Load);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCupQG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Button btnStopCupQG;
        private System.Windows.Forms.Button btnCupQG;
        private System.Windows.Forms.PictureBox picCupQG;
        private System.Windows.Forms.Button btnLinkBrowser;
        public System.Windows.Forms.TextBox link;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label1;
    }
}