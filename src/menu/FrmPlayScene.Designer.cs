namespace VLeague.src.menu
{
    partial class FrmPlayScene
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnResume = new System.Windows.Forms.Button();
            this.EX12_Apply = new System.Windows.Forms.Button();
            this.EX12_Delete = new System.Windows.Forms.Button();
            this.EX12_Add = new System.Windows.Forms.Button();
            this.EX12_Scenelist = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SceneName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStop = new System.Windows.Forms.Button();
            this.StopAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbLayer = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbLayer);
            this.groupBox1.Controls.Add(this.btnResume);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.EX12_Apply);
            this.groupBox1.Controls.Add(this.EX12_Delete);
            this.groupBox1.Controls.Add(this.EX12_Add);
            this.groupBox1.Controls.Add(this.EX12_Scenelist);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.groupBox1.Location = new System.Drawing.Point(38, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 387);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Playlist";
            // 
            // btnResume
            // 
            this.btnResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnResume.Location = new System.Drawing.Point(612, 35);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(93, 31);
            this.btnResume.TabIndex = 20;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // EX12_Apply
            // 
            this.EX12_Apply.Location = new System.Drawing.Point(507, 35);
            this.EX12_Apply.Name = "EX12_Apply";
            this.EX12_Apply.Size = new System.Drawing.Size(99, 31);
            this.EX12_Apply.TabIndex = 22;
            this.EX12_Apply.Text = "▶";
            this.EX12_Apply.UseVisualStyleBackColor = true;
            this.EX12_Apply.Click += new System.EventHandler(this.EX12_Apply_Click);
            // 
            // EX12_Delete
            // 
            this.EX12_Delete.Location = new System.Drawing.Point(129, 35);
            this.EX12_Delete.Name = "EX12_Delete";
            this.EX12_Delete.Size = new System.Drawing.Size(90, 31);
            this.EX12_Delete.TabIndex = 21;
            this.EX12_Delete.Text = "Delete";
            this.EX12_Delete.UseVisualStyleBackColor = true;
            this.EX12_Delete.Click += new System.EventHandler(this.EX12_Delete_Click);
            // 
            // EX12_Add
            // 
            this.EX12_Add.Location = new System.Drawing.Point(33, 35);
            this.EX12_Add.Name = "EX12_Add";
            this.EX12_Add.Size = new System.Drawing.Size(90, 31);
            this.EX12_Add.TabIndex = 20;
            this.EX12_Add.Text = "Add";
            this.EX12_Add.UseVisualStyleBackColor = true;
            this.EX12_Add.Click += new System.EventHandler(this.EX12_Add_Click);
            // 
            // EX12_Scenelist
            // 
            this.EX12_Scenelist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.FileName,
            this.SceneName});
            this.EX12_Scenelist.FullRowSelect = true;
            this.EX12_Scenelist.HideSelection = false;
            this.EX12_Scenelist.Location = new System.Drawing.Point(23, 79);
            this.EX12_Scenelist.Name = "EX12_Scenelist";
            this.EX12_Scenelist.Size = new System.Drawing.Size(682, 281);
            this.EX12_Scenelist.TabIndex = 19;
            this.EX12_Scenelist.UseCompatibleStateImageBehavior = false;
            this.EX12_Scenelist.View = System.Windows.Forms.View.Details;
            this.EX12_Scenelist.SelectedIndexChanged += new System.EventHandler(this.EX12_Scenelist_SelectedIndexChanged);
            // 
            // No
            // 
            this.No.Text = "No";
            this.No.Width = 36;
            // 
            // FileName
            // 
            this.FileName.Text = "FileName";
            this.FileName.Width = 521;
            // 
            // SceneName
            // 
            this.SceneName.Text = "SceneName";
            this.SceneName.Width = 123;
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnStop.Location = new System.Drawing.Point(570, 28);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(93, 33);
            this.btnStop.TabIndex = 19;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // StopAll
            // 
            this.StopAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.StopAll.Location = new System.Drawing.Point(669, 28);
            this.StopAll.Name = "StopAll";
            this.StopAll.Size = new System.Drawing.Size(93, 33);
            this.StopAll.TabIndex = 18;
            this.StopAll.Text = "Stop All";
            this.StopAll.UseVisualStyleBackColor = true;
            this.StopAll.Click += new System.EventHandler(this.StopAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "Layer";
            // 
            // cbbLayer
            // 
            this.cbbLayer.FormattingEnabled = true;
            this.cbbLayer.Location = new System.Drawing.Point(289, 38);
            this.cbbLayer.Name = "cbbLayer";
            this.cbbLayer.Size = new System.Drawing.Size(44, 26);
            this.cbbLayer.TabIndex = 23;
            // 
            // FrmPlayScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 475);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.StopAll);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FrmPlayScene";
            this.Text = "Play Scene";
            this.Load += new System.EventHandler(this.FrmPlayScene_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button EX12_Apply;
        private System.Windows.Forms.Button EX12_Delete;
        private System.Windows.Forms.Button EX12_Add;
        private System.Windows.Forms.ListView EX12_Scenelist;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader SceneName;
        private System.Windows.Forms.Button StopAll;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.ComboBox cbbLayer;
        private System.Windows.Forms.Label label1;
    }
}