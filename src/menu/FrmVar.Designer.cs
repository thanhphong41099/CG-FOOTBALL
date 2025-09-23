namespace VLeague.src.menu
{
    partial class FrmVar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVar));
            this.LowerThirdHome = new System.Windows.Forms.GroupBox();
            this.btnPinP = new System.Windows.Forms.Button();
            this.listDecision = new System.Windows.Forms.ListBox();
            this.listUpdate = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.decisionVar = new System.Windows.Forms.Button();
            this.updateVar = new System.Windows.Forms.Button();
            this.cbbUpdateVar = new System.Windows.Forms.ComboBox();
            this.checkVar = new System.Windows.Forms.Button();
            this.stopVar = new System.Windows.Forms.Button();
            this.cbbDecisionVar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stopAll = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.LowerThirdHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // LowerThirdHome
            // 
            this.LowerThirdHome.Controls.Add(this.btnPinP);
            this.LowerThirdHome.Controls.Add(this.listDecision);
            this.LowerThirdHome.Controls.Add(this.listUpdate);
            this.LowerThirdHome.Controls.Add(this.label8);
            this.LowerThirdHome.Controls.Add(this.label7);
            this.LowerThirdHome.Controls.Add(this.label6);
            this.LowerThirdHome.Controls.Add(this.label2);
            this.LowerThirdHome.Controls.Add(this.label1);
            this.LowerThirdHome.Controls.Add(this.decisionVar);
            this.LowerThirdHome.Controls.Add(this.updateVar);
            this.LowerThirdHome.Controls.Add(this.cbbUpdateVar);
            this.LowerThirdHome.Controls.Add(this.checkVar);
            this.LowerThirdHome.Controls.Add(this.stopVar);
            this.LowerThirdHome.Controls.Add(this.cbbDecisionVar);
            this.LowerThirdHome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LowerThirdHome.Location = new System.Drawing.Point(129, 147);
            this.LowerThirdHome.Name = "LowerThirdHome";
            this.LowerThirdHome.Size = new System.Drawing.Size(1193, 781);
            this.LowerThirdHome.TabIndex = 291;
            this.LowerThirdHome.TabStop = false;
            this.LowerThirdHome.Text = "CHECK VAR";
            // 
            // btnPinP
            // 
            this.btnPinP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(182)))), ((int)(((byte)(213)))));
            this.btnPinP.FlatAppearance.BorderSize = 0;
            this.btnPinP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPinP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPinP.ForeColor = System.Drawing.Color.White;
            this.btnPinP.Location = new System.Drawing.Point(83, 650);
            this.btnPinP.Name = "btnPinP";
            this.btnPinP.Size = new System.Drawing.Size(198, 52);
            this.btnPinP.TabIndex = 307;
            this.btnPinP.Text = "PICTURE IN PICTURE";
            this.btnPinP.UseVisualStyleBackColor = false;
            this.btnPinP.Click += new System.EventHandler(this.btnPinP_Click);
            // 
            // listDecision
            // 
            this.listDecision.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDecision.FormattingEnabled = true;
            this.listDecision.ItemHeight = 21;
            this.listDecision.Location = new System.Drawing.Point(628, 266);
            this.listDecision.Name = "listDecision";
            this.listDecision.Size = new System.Drawing.Size(454, 340);
            this.listDecision.TabIndex = 306;
            this.listDecision.SelectedIndexChanged += new System.EventHandler(this.listDecision_SelectedIndexChanged);
            // 
            // listUpdate
            // 
            this.listUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listUpdate.FormattingEnabled = true;
            this.listUpdate.ItemHeight = 21;
            this.listUpdate.Location = new System.Drawing.Point(83, 266);
            this.listUpdate.Name = "listUpdate";
            this.listUpdate.Size = new System.Drawing.Size(454, 340);
            this.listUpdate.TabIndex = 305;
            this.listUpdate.SelectedIndexChanged += new System.EventHandler(this.listUpdate_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(624, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 21);
            this.label8.TabIndex = 303;
            this.label8.Text = "Decision [2]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 21);
            this.label7.TabIndex = 302;
            this.label7.Text = "Update [1]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 21);
            this.label6.TabIndex = 301;
            this.label6.Text = " IN > OUT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(635, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 21);
            this.label2.TabIndex = 296;
            this.label2.Text = "Decision [2]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 295;
            this.label1.Text = "Update [1]";
            // 
            // decisionVar
            // 
            this.decisionVar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.decisionVar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.decisionVar.Image = ((System.Drawing.Image)(resources.GetObject("decisionVar.Image")));
            this.decisionVar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.decisionVar.Location = new System.Drawing.Point(628, 83);
            this.decisionVar.Name = "decisionVar";
            this.decisionVar.Size = new System.Drawing.Size(176, 69);
            this.decisionVar.TabIndex = 294;
            this.decisionVar.Text = "DECISION VAR";
            this.decisionVar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.decisionVar.UseVisualStyleBackColor = true;
            this.decisionVar.Click += new System.EventHandler(this.decisionVar_Click);
            // 
            // updateVar
            // 
            this.updateVar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.updateVar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updateVar.Image = ((System.Drawing.Image)(resources.GetObject("updateVar.Image")));
            this.updateVar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateVar.Location = new System.Drawing.Point(361, 82);
            this.updateVar.Name = "updateVar";
            this.updateVar.Size = new System.Drawing.Size(176, 69);
            this.updateVar.TabIndex = 293;
            this.updateVar.Text = "UPDATE VAR";
            this.updateVar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.updateVar.UseVisualStyleBackColor = true;
            this.updateVar.Click += new System.EventHandler(this.updateVar_Click);
            // 
            // cbbUpdateVar
            // 
            this.cbbUpdateVar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cbbUpdateVar.FormattingEnabled = true;
            this.cbbUpdateVar.Location = new System.Drawing.Point(83, 210);
            this.cbbUpdateVar.Name = "cbbUpdateVar";
            this.cbbUpdateVar.Size = new System.Drawing.Size(454, 29);
            this.cbbUpdateVar.TabIndex = 292;
            // 
            // checkVar
            // 
            this.checkVar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkVar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkVar.Image = ((System.Drawing.Image)(resources.GetObject("checkVar.Image")));
            this.checkVar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkVar.Location = new System.Drawing.Point(83, 82);
            this.checkVar.Name = "checkVar";
            this.checkVar.Size = new System.Drawing.Size(176, 69);
            this.checkVar.TabIndex = 291;
            this.checkVar.Text = "CHECK VAR";
            this.checkVar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkVar.UseVisualStyleBackColor = true;
            this.checkVar.Click += new System.EventHandler(this.checkVar_Click);
            // 
            // stopVar
            // 
            this.stopVar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopVar.Image = ((System.Drawing.Image)(resources.GetObject("stopVar.Image")));
            this.stopVar.Location = new System.Drawing.Point(1009, 83);
            this.stopVar.Name = "stopVar";
            this.stopVar.Size = new System.Drawing.Size(73, 68);
            this.stopVar.TabIndex = 290;
            this.stopVar.UseVisualStyleBackColor = true;
            this.stopVar.Click += new System.EventHandler(this.stopVar_Click);
            // 
            // cbbDecisionVar
            // 
            this.cbbDecisionVar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cbbDecisionVar.FormattingEnabled = true;
            this.cbbDecisionVar.Location = new System.Drawing.Point(628, 211);
            this.cbbDecisionVar.Name = "cbbDecisionVar";
            this.cbbDecisionVar.Size = new System.Drawing.Size(454, 29);
            this.cbbDecisionVar.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(1364, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 299;
            this.label3.Text = "STOP ALL";
            // 
            // stopAll
            // 
            this.stopAll.Image = ((System.Drawing.Image)(resources.GetObject("stopAll.Image")));
            this.stopAll.Location = new System.Drawing.Point(1367, 58);
            this.stopAll.Name = "stopAll";
            this.stopAll.Size = new System.Drawing.Size(73, 68);
            this.stopAll.TabIndex = 298;
            this.stopAll.UseVisualStyleBackColor = true;
            this.stopAll.Click += new System.EventHandler(this.stopAll_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(102, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 25);
            this.label10.TabIndex = 328;
            this.label10.Text = "VAR";
            // 
            // FrmVar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1670, 950);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stopAll);
            this.Controls.Add(this.LowerThirdHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVar";
            this.Text = "Var";
            this.Load += new System.EventHandler(this.FrmVar_Load);
            this.LowerThirdHome.ResumeLayout(false);
            this.LowerThirdHome.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox LowerThirdHome;
        private System.Windows.Forms.Button decisionVar;
        private System.Windows.Forms.Button updateVar;
        private System.Windows.Forms.ComboBox cbbUpdateVar;
        private System.Windows.Forms.Button checkVar;
        private System.Windows.Forms.Button stopVar;
        private System.Windows.Forms.ComboBox cbbDecisionVar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button stopAll;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox listUpdate;
        private System.Windows.Forms.ListBox listDecision;
        private System.Windows.Forms.Button btnPinP;
    }
}