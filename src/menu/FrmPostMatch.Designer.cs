namespace VLeague.src.menu
{
    partial class FrmPostMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPostMatch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.showStaticPenalty = new System.Windows.Forms.Button();
            this.stopStaticPen = new System.Windows.Forms.Button();
            this.showStatic = new System.Windows.Forms.Button();
            this.stopStatic = new System.Windows.Forms.Button();
            this.updateStatic = new System.Windows.Forms.Button();
            this.cbbMatch = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.showPostGST = new System.Windows.Forms.Button();
            this.stopPostGTS = new System.Windows.Forms.Button();
            this.updatePostGST = new System.Windows.Forms.Button();
            this.gridMatchStatic = new System.Windows.Forms.GroupBox();
            this.dgvStatistic = new System.Windows.Forms.DataGridView();
            this.gridPostGST = new System.Windows.Forms.GroupBox();
            this.dgvBXH = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.stopAll = new System.Windows.Forms.Button();
            this.saveTableToAccess = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gridMatchStatic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistic)).BeginInit();
            this.gridPostGST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBXH)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.showStaticPenalty);
            this.groupBox1.Controls.Add(this.stopStaticPen);
            this.groupBox1.Controls.Add(this.showStatic);
            this.groupBox1.Controls.Add(this.stopStatic);
            this.groupBox1.Controls.Add(this.updateStatic);
            this.groupBox1.Controls.Add(this.cbbMatch);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(48, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 314);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MATCH STATISTIC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans", 9F);
            this.label2.Location = new System.Drawing.Point(25, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 302;
            this.label2.Text = "HIỆP ĐẤU";
            // 
            // showStaticPenalty
            // 
            this.showStaticPenalty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.showStaticPenalty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showStaticPenalty.Image = ((System.Drawing.Image)(resources.GetObject("showStaticPenalty.Image")));
            this.showStaticPenalty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showStaticPenalty.Location = new System.Drawing.Point(28, 216);
            this.showStaticPenalty.Name = "showStaticPenalty";
            this.showStaticPenalty.Size = new System.Drawing.Size(295, 69);
            this.showStaticPenalty.TabIndex = 301;
            this.showStaticPenalty.Text = "SHOW STATISTIC + PENALTY";
            this.showStaticPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showStaticPenalty.UseVisualStyleBackColor = true;
            this.showStaticPenalty.Click += new System.EventHandler(this.showStaticPenalty_Click);
            // 
            // stopStaticPen
            // 
            this.stopStaticPen.Image = ((System.Drawing.Image)(resources.GetObject("stopStaticPen.Image")));
            this.stopStaticPen.Location = new System.Drawing.Point(349, 217);
            this.stopStaticPen.Name = "stopStaticPen";
            this.stopStaticPen.Size = new System.Drawing.Size(73, 68);
            this.stopStaticPen.TabIndex = 300;
            this.stopStaticPen.UseVisualStyleBackColor = true;
            this.stopStaticPen.Click += new System.EventHandler(this.stopStaticPen_Click);
            // 
            // showStatic
            // 
            this.showStatic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.showStatic.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showStatic.Image = ((System.Drawing.Image)(resources.GetObject("showStatic.Image")));
            this.showStatic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showStatic.Location = new System.Drawing.Point(28, 130);
            this.showStatic.Name = "showStatic";
            this.showStatic.Size = new System.Drawing.Size(295, 69);
            this.showStatic.TabIndex = 299;
            this.showStatic.Text = "SHOW STATISTIC";
            this.showStatic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showStatic.UseVisualStyleBackColor = true;
            this.showStatic.Click += new System.EventHandler(this.showStatic_Click);
            // 
            // stopStatic
            // 
            this.stopStatic.Image = ((System.Drawing.Image)(resources.GetObject("stopStatic.Image")));
            this.stopStatic.Location = new System.Drawing.Point(349, 131);
            this.stopStatic.Name = "stopStatic";
            this.stopStatic.Size = new System.Drawing.Size(73, 68);
            this.stopStatic.TabIndex = 298;
            this.stopStatic.UseVisualStyleBackColor = true;
            this.stopStatic.Click += new System.EventHandler(this.stopStatic_Click);
            // 
            // updateStatic
            // 
            this.updateStatic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(182)))), ((int)(((byte)(213)))));
            this.updateStatic.FlatAppearance.BorderSize = 0;
            this.updateStatic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateStatic.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.updateStatic.ForeColor = System.Drawing.Color.White;
            this.updateStatic.Location = new System.Drawing.Point(28, 76);
            this.updateStatic.Name = "updateStatic";
            this.updateStatic.Size = new System.Drawing.Size(295, 39);
            this.updateStatic.TabIndex = 1;
            this.updateStatic.Text = "UPDATE STATIC DATA";
            this.updateStatic.UseVisualStyleBackColor = false;
            this.updateStatic.Click += new System.EventHandler(this.updateStatic_Click);
            // 
            // cbbMatch
            // 
            this.cbbMatch.Font = new System.Drawing.Font("Noto Sans", 9F);
            this.cbbMatch.FormattingEnabled = true;
            this.cbbMatch.Location = new System.Drawing.Point(126, 36);
            this.cbbMatch.Name = "cbbMatch";
            this.cbbMatch.Size = new System.Drawing.Size(197, 26);
            this.cbbMatch.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.showPostGST);
            this.groupBox2.Controls.Add(this.stopPostGTS);
            this.groupBox2.Controls.Add(this.updatePostGST);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(48, 434);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 192);
            this.groupBox2.TabIndex = 302;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MATCH POST STANDING";
            // 
            // showPostGST
            // 
            this.showPostGST.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.showPostGST.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showPostGST.Image = ((System.Drawing.Image)(resources.GetObject("showPostGST.Image")));
            this.showPostGST.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showPostGST.Location = new System.Drawing.Point(28, 89);
            this.showPostGST.Name = "showPostGST";
            this.showPostGST.Size = new System.Drawing.Size(295, 69);
            this.showPostGST.TabIndex = 299;
            this.showPostGST.Text = "POST GROUP STANDING";
            this.showPostGST.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showPostGST.UseVisualStyleBackColor = true;
            this.showPostGST.Click += new System.EventHandler(this.showPostGST_Click);
            // 
            // stopPostGTS
            // 
            this.stopPostGTS.Image = ((System.Drawing.Image)(resources.GetObject("stopPostGTS.Image")));
            this.stopPostGTS.Location = new System.Drawing.Point(349, 90);
            this.stopPostGTS.Name = "stopPostGTS";
            this.stopPostGTS.Size = new System.Drawing.Size(73, 68);
            this.stopPostGTS.TabIndex = 298;
            this.stopPostGTS.UseVisualStyleBackColor = true;
            this.stopPostGTS.Click += new System.EventHandler(this.stopPostGTS_Click);
            // 
            // updatePostGST
            // 
            this.updatePostGST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(182)))), ((int)(((byte)(213)))));
            this.updatePostGST.FlatAppearance.BorderSize = 0;
            this.updatePostGST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatePostGST.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.updatePostGST.ForeColor = System.Drawing.Color.White;
            this.updatePostGST.Location = new System.Drawing.Point(28, 35);
            this.updatePostGST.Name = "updatePostGST";
            this.updatePostGST.Size = new System.Drawing.Size(295, 39);
            this.updatePostGST.TabIndex = 1;
            this.updatePostGST.Text = "UPDATE POST GROUP STANDING";
            this.updatePostGST.UseVisualStyleBackColor = false;
            this.updatePostGST.Click += new System.EventHandler(this.updatePostGST_Click);
            // 
            // gridMatchStatic
            // 
            this.gridMatchStatic.Controls.Add(this.dgvStatistic);
            this.gridMatchStatic.Font = new System.Drawing.Font("Noto Sans", 9F);
            this.gridMatchStatic.Location = new System.Drawing.Point(553, 100);
            this.gridMatchStatic.Name = "gridMatchStatic";
            this.gridMatchStatic.Size = new System.Drawing.Size(636, 314);
            this.gridMatchStatic.TabIndex = 303;
            this.gridMatchStatic.TabStop = false;
            this.gridMatchStatic.Text = "MATCH STATISTIC";
            // 
            // dgvStatistic
            // 
            this.dgvStatistic.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Noto Sans", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatistic.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStatistic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Noto Sans", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStatistic.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStatistic.Location = new System.Drawing.Point(18, 22);
            this.dgvStatistic.Name = "dgvStatistic";
            this.dgvStatistic.RowHeadersWidth = 51;
            this.dgvStatistic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatistic.Size = new System.Drawing.Size(599, 276);
            this.dgvStatistic.TabIndex = 5;
            // 
            // gridPostGST
            // 
            this.gridPostGST.Controls.Add(this.dgvBXH);
            this.gridPostGST.Font = new System.Drawing.Font("Noto Sans", 9F);
            this.gridPostGST.Location = new System.Drawing.Point(553, 434);
            this.gridPostGST.Name = "gridPostGST";
            this.gridPostGST.Size = new System.Drawing.Size(636, 320);
            this.gridPostGST.TabIndex = 304;
            this.gridPostGST.TabStop = false;
            this.gridPostGST.Text = "POST GROUP STANDING";
            // 
            // dgvBXH
            // 
            this.dgvBXH.AllowDrop = true;
            this.dgvBXH.AllowUserToAddRows = false;
            this.dgvBXH.AllowUserToDeleteRows = false;
            this.dgvBXH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBXH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBXH.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Noto Sans", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBXH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBXH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBXH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaDoi,
            this.TenDoi,
            this.Diem,
            this.Tran,
            this.T,
            this.B,
            this.H,
            this.HS});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBXH.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBXH.Location = new System.Drawing.Point(16, 35);
            this.dgvBXH.MultiSelect = false;
            this.dgvBXH.Name = "dgvBXH";
            this.dgvBXH.RowHeadersWidth = 51;
            this.dgvBXH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBXH.Size = new System.Drawing.Size(601, 275);
            this.dgvBXH.TabIndex = 295;
            // 
            // STT
            // 
            this.STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.Width = 45;
            // 
            // MaDoi
            // 
            this.MaDoi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaDoi.FillWeight = 150F;
            this.MaDoi.HeaderText = "Mã Đội";
            this.MaDoi.MinimumWidth = 6;
            this.MaDoi.Name = "MaDoi";
            this.MaDoi.Width = 80;
            // 
            // TenDoi
            // 
            this.TenDoi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenDoi.HeaderText = "Tên Đội";
            this.TenDoi.MinimumWidth = 6;
            this.TenDoi.Name = "TenDoi";
            // 
            // Diem
            // 
            this.Diem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Diem.HeaderText = "Điểm";
            this.Diem.MinimumWidth = 6;
            this.Diem.Name = "Diem";
            this.Diem.Width = 50;
            // 
            // Tran
            // 
            this.Tran.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Tran.HeaderText = "Trận";
            this.Tran.MinimumWidth = 6;
            this.Tran.Name = "Tran";
            this.Tran.Width = 50;
            // 
            // T
            // 
            this.T.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.T.HeaderText = "Thắng";
            this.T.MinimumWidth = 6;
            this.T.Name = "T";
            this.T.Width = 45;
            // 
            // B
            // 
            this.B.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.B.HeaderText = "Bại";
            this.B.MinimumWidth = 6;
            this.B.Name = "B";
            this.B.Width = 45;
            // 
            // H
            // 
            this.H.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.H.HeaderText = "Hòa";
            this.H.MinimumWidth = 6;
            this.H.Name = "H";
            this.H.Width = 45;
            // 
            // HS
            // 
            this.HS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.HS.HeaderText = "HS";
            this.HS.MinimumWidth = 6;
            this.HS.Name = "HS";
            this.HS.Width = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1247, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 306;
            this.label1.Text = "STOP ALL";
            // 
            // stopAll
            // 
            this.stopAll.Image = ((System.Drawing.Image)(resources.GetObject("stopAll.Image")));
            this.stopAll.Location = new System.Drawing.Point(1250, 58);
            this.stopAll.Name = "stopAll";
            this.stopAll.Size = new System.Drawing.Size(73, 68);
            this.stopAll.TabIndex = 305;
            this.stopAll.UseVisualStyleBackColor = true;
            this.stopAll.Click += new System.EventHandler(this.stopAll_Click);
            // 
            // saveTableToAccess
            // 
            this.saveTableToAccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(182)))), ((int)(((byte)(70)))));
            this.saveTableToAccess.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.saveTableToAccess.FlatAppearance.BorderSize = 0;
            this.saveTableToAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveTableToAccess.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.saveTableToAccess.ForeColor = System.Drawing.Color.White;
            this.saveTableToAccess.Location = new System.Drawing.Point(48, 674);
            this.saveTableToAccess.Name = "saveTableToAccess";
            this.saveTableToAccess.Size = new System.Drawing.Size(449, 48);
            this.saveTableToAccess.TabIndex = 307;
            this.saveTableToAccess.Text = "SAVE ALL TABLE TO DATA ACCESS";
            this.saveTableToAccess.UseVisualStyleBackColor = false;
            this.saveTableToAccess.Click += new System.EventHandler(this.saveTableToAccess_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(54, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 25);
            this.label10.TabIndex = 329;
            this.label10.Text = "POST MATCH";
            // 
            // FrmPostMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1670, 950);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.saveTableToAccess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopAll);
            this.Controls.Add(this.gridPostGST);
            this.Controls.Add(this.gridMatchStatic);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPostMatch";
            this.Text = "Post Match";
            this.Load += new System.EventHandler(this.FrmPostMatch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gridMatchStatic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistic)).EndInit();
            this.gridPostGST.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBXH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button updateStatic;
        private System.Windows.Forms.ComboBox cbbMatch;
        private System.Windows.Forms.Button showStaticPenalty;
        private System.Windows.Forms.Button stopStaticPen;
        private System.Windows.Forms.Button showStatic;
        private System.Windows.Forms.Button stopStatic;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button showPostGST;
        private System.Windows.Forms.Button stopPostGTS;
        private System.Windows.Forms.Button updatePostGST;
        private System.Windows.Forms.GroupBox gridMatchStatic;
        private System.Windows.Forms.DataGridView dgvStatistic;
        private System.Windows.Forms.GroupBox gridPostGST;
        private System.Windows.Forms.DataGridView dgvBXH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button stopAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tran;
        private System.Windows.Forms.DataGridViewTextBoxColumn T;
        private System.Windows.Forms.DataGridViewTextBoxColumn B;
        private System.Windows.Forms.DataGridViewTextBoxColumn H;
        private System.Windows.Forms.DataGridViewTextBoxColumn HS;
        private System.Windows.Forms.Button saveTableToAccess;
        private System.Windows.Forms.Label label10;
    }
}