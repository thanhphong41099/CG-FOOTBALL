namespace VLeague
{
    partial class SetupUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.logBoxKarisma = new System.Windows.Forms.ListBox();
            this.groupSetting = new System.Windows.Forms.GroupBox();
            this.radioCQG = new System.Windows.Forms.RadioButton();
            this.radioVL2 = new System.Windows.Forms.RadioButton();
            this.radioVL1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnectDB = new System.Windows.Forms.Button();
            this.btnOpenConfig = new System.Windows.Forms.Button();
            this.btnDataBrowser = new System.Windows.Forms.Button();
            this.btnDisconnectKarisma = new System.Windows.Forms.Button();
            this.btnConnectKarisma = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnClearLog);
            this.groupBox1.Controls.Add(this.logBoxKarisma);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(808, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(693, 321);
            this.groupBox1.TabIndex = 336;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "STATUS KARISMA";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(182)))), ((int)(((byte)(213)))));
            this.btnClearLog.FlatAppearance.BorderSize = 0;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnClearLog.ForeColor = System.Drawing.Color.White;
            this.btnClearLog.Location = new System.Drawing.Point(601, 288);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(70, 27);
            this.btnClearLog.TabIndex = 191;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = false;
            // 
            // logBoxKarisma
            // 
            this.logBoxKarisma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBoxKarisma.BackColor = System.Drawing.SystemColors.InfoText;
            this.logBoxKarisma.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.logBoxKarisma.ForeColor = System.Drawing.SystemColors.Info;
            this.logBoxKarisma.FormattingEnabled = true;
            this.logBoxKarisma.HorizontalScrollbar = true;
            this.logBoxKarisma.ItemHeight = 17;
            this.logBoxKarisma.Location = new System.Drawing.Point(15, 43);
            this.logBoxKarisma.Name = "logBoxKarisma";
            this.logBoxKarisma.Size = new System.Drawing.Size(656, 242);
            this.logBoxKarisma.TabIndex = 14;
            // 
            // groupSetting
            // 
            this.groupSetting.BackColor = System.Drawing.Color.White;
            this.groupSetting.Controls.Add(this.radioCQG);
            this.groupSetting.Controls.Add(this.radioVL2);
            this.groupSetting.Controls.Add(this.radioVL1);
            this.groupSetting.Controls.Add(this.label1);
            this.groupSetting.Controls.Add(this.btnConnectDB);
            this.groupSetting.Controls.Add(this.btnOpenConfig);
            this.groupSetting.Controls.Add(this.btnDataBrowser);
            this.groupSetting.Controls.Add(this.btnDisconnectKarisma);
            this.groupSetting.Controls.Add(this.btnConnectKarisma);
            this.groupSetting.Controls.Add(this.txtData);
            this.groupSetting.Controls.Add(this.txtPort);
            this.groupSetting.Controls.Add(this.txtIpAddress);
            this.groupSetting.Controls.Add(this.label85);
            this.groupSetting.Controls.Add(this.label86);
            this.groupSetting.Controls.Add(this.label87);
            this.groupSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupSetting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupSetting.Location = new System.Drawing.Point(39, 39);
            this.groupSetting.Name = "groupSetting";
            this.groupSetting.Size = new System.Drawing.Size(743, 321);
            this.groupSetting.TabIndex = 335;
            this.groupSetting.TabStop = false;
            this.groupSetting.Text = "CONNECT CG";
            // 
            // radioCQG
            // 
            this.radioCQG.AutoSize = true;
            this.radioCQG.Location = new System.Drawing.Point(393, 152);
            this.radioCQG.Name = "radioCQG";
            this.radioCQG.Size = new System.Drawing.Size(141, 25);
            this.radioCQG.TabIndex = 208;
            this.radioCQG.TabStop = true;
            this.radioCQG.Text = "CÚP QUỐC GIA";
            this.radioCQG.UseVisualStyleBackColor = true;
            this.radioCQG.CheckedChanged += new System.EventHandler(this.radioCQG_CheckedChanged);
            // 
            // radioVL2
            // 
            this.radioVL2.AutoSize = true;
            this.radioVL2.Location = new System.Drawing.Point(267, 152);
            this.radioVL2.Name = "radioVL2";
            this.radioVL2.Size = new System.Drawing.Size(112, 25);
            this.radioVL2.TabIndex = 207;
            this.radioVL2.TabStop = true;
            this.radioVL2.Text = "VLEAGUE 2";
            this.radioVL2.UseVisualStyleBackColor = true;
            this.radioVL2.CheckedChanged += new System.EventHandler(this.radioVL2_CheckedChanged);
            // 
            // radioVL1
            // 
            this.radioVL1.AutoSize = true;
            this.radioVL1.Location = new System.Drawing.Point(141, 152);
            this.radioVL1.Name = "radioVL1";
            this.radioVL1.Size = new System.Drawing.Size(112, 25);
            this.radioVL1.TabIndex = 206;
            this.radioVL1.TabStop = true;
            this.radioVL1.Text = "VLEAGUE 1";
            this.radioVL1.UseVisualStyleBackColor = true;
            this.radioVL1.CheckedChanged += new System.EventHandler(this.radioVL1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(14, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 202;
            this.label1.Text = "Chọn giải đấu:";
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnectDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(182)))), ((int)(((byte)(213)))));
            this.btnConnectDB.FlatAppearance.BorderSize = 0;
            this.btnConnectDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectDB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnConnectDB.ForeColor = System.Drawing.Color.White;
            this.btnConnectDB.Location = new System.Drawing.Point(609, 194);
            this.btnConnectDB.Name = "btnConnectDB";
            this.btnConnectDB.Size = new System.Drawing.Size(115, 41);
            this.btnConnectDB.TabIndex = 201;
            this.btnConnectDB.Text = "Connect DB";
            this.btnConnectDB.UseVisualStyleBackColor = false;
            this.btnConnectDB.Click += new System.EventHandler(this.btnConnectDB_Click);
            // 
            // btnOpenConfig
            // 
            this.btnOpenConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(182)))), ((int)(((byte)(213)))));
            this.btnOpenConfig.FlatAppearance.BorderSize = 0;
            this.btnOpenConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenConfig.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpenConfig.ForeColor = System.Drawing.Color.White;
            this.btnOpenConfig.Location = new System.Drawing.Point(253, 257);
            this.btnOpenConfig.Name = "btnOpenConfig";
            this.btnOpenConfig.Size = new System.Drawing.Size(126, 36);
            this.btnOpenConfig.TabIndex = 200;
            this.btnOpenConfig.Text = "Open Config File";
            this.btnOpenConfig.UseVisualStyleBackColor = false;
            // 
            // btnDataBrowser
            // 
            this.btnDataBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataBrowser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(182)))), ((int)(((byte)(213)))));
            this.btnDataBrowser.FlatAppearance.BorderSize = 0;
            this.btnDataBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataBrowser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDataBrowser.ForeColor = System.Drawing.Color.White;
            this.btnDataBrowser.Location = new System.Drawing.Point(550, 200);
            this.btnDataBrowser.Name = "btnDataBrowser";
            this.btnDataBrowser.Size = new System.Drawing.Size(42, 29);
            this.btnDataBrowser.TabIndex = 190;
            this.btnDataBrowser.Text = "...";
            this.btnDataBrowser.UseVisualStyleBackColor = false;
            this.btnDataBrowser.Click += new System.EventHandler(this.btnDataBrowser_Click);
            // 
            // btnDisconnectKarisma
            // 
            this.btnDisconnectKarisma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisconnectKarisma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(182)))), ((int)(((byte)(213)))));
            this.btnDisconnectKarisma.FlatAppearance.BorderSize = 0;
            this.btnDisconnectKarisma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnectKarisma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDisconnectKarisma.ForeColor = System.Drawing.Color.White;
            this.btnDisconnectKarisma.Location = new System.Drawing.Point(609, 86);
            this.btnDisconnectKarisma.Name = "btnDisconnectKarisma";
            this.btnDisconnectKarisma.Size = new System.Drawing.Size(115, 42);
            this.btnDisconnectKarisma.TabIndex = 5;
            this.btnDisconnectKarisma.Text = "Disconnect";
            this.btnDisconnectKarisma.UseVisualStyleBackColor = false;
            // 
            // btnConnectKarisma
            // 
            this.btnConnectKarisma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnectKarisma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(182)))), ((int)(((byte)(213)))));
            this.btnConnectKarisma.FlatAppearance.BorderSize = 0;
            this.btnConnectKarisma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectKarisma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnConnectKarisma.ForeColor = System.Drawing.Color.White;
            this.btnConnectKarisma.Location = new System.Drawing.Point(609, 43);
            this.btnConnectKarisma.Name = "btnConnectKarisma";
            this.btnConnectKarisma.Size = new System.Drawing.Size(115, 41);
            this.btnConnectKarisma.TabIndex = 5;
            this.btnConnectKarisma.Text = "Connect";
            this.btnConnectKarisma.UseVisualStyleBackColor = false;
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtData.Location = new System.Drawing.Point(127, 200);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(417, 29);
            this.txtData.TabIndex = 188;
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPort.Location = new System.Drawing.Point(128, 93);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(417, 29);
            this.txtPort.TabIndex = 4;
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIpAddress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtIpAddress.Location = new System.Drawing.Point(127, 51);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(417, 29);
            this.txtIpAddress.TabIndex = 4;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label85.Location = new System.Drawing.Point(15, 94);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(41, 21);
            this.label85.TabIndex = 3;
            this.label85.Text = "Port:";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label86.Location = new System.Drawing.Point(16, 204);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(45, 21);
            this.label86.TabIndex = 2;
            this.label86.Text = "Data:";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label87.Location = new System.Drawing.Point(14, 51);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(86, 21);
            this.label87.TabIndex = 2;
            this.label87.Text = "IP Address:";
            // 
            // SetupUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupSetting);
            this.Name = "SetupUC";
            this.Size = new System.Drawing.Size(1705, 1014);
            this.Load += new System.EventHandler(this.SetupUC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupSetting.ResumeLayout(false);
            this.groupSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox logBoxKarisma;
        private System.Windows.Forms.GroupBox groupSetting;
        private System.Windows.Forms.Button btnDisconnectKarisma;
        private System.Windows.Forms.Button btnConnectKarisma;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnectDB;
        private System.Windows.Forms.Button btnOpenConfig;
        private System.Windows.Forms.Button btnDataBrowser;
        internal System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.RadioButton radioCQG;
        private System.Windows.Forms.RadioButton radioVL2;
        private System.Windows.Forms.RadioButton radioVL1;
        private System.Windows.Forms.Button btnClearLog;
    }
}
