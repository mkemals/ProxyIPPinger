namespace ProxyIPPinger
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnPingAll = new System.Windows.Forms.Button();
            this.gvIPStatus = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_IPStatus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmsiSetToProxy = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkAutoChangeProxy = new System.Windows.Forms.CheckBox();
            this.llCancel = new System.Windows.Forms.LinkLabel();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.btnTimerPause = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.clmnEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnUseCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPingCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPingStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmnFailCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvIPStatus)).BeginInit();
            this.contextMenuStrip_IPStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPingAll
            // 
            this.btnPingAll.Location = new System.Drawing.Point(270, 225);
            this.btnPingAll.Name = "btnPingAll";
            this.btnPingAll.Size = new System.Drawing.Size(81, 23);
            this.btnPingAll.TabIndex = 0;
            this.btnPingAll.Text = "Ping All";
            this.btnPingAll.UseVisualStyleBackColor = true;
            this.btnPingAll.Click += new System.EventHandler(this.btnPingAll_Click);
            // 
            // gvIPStatus
            // 
            this.gvIPStatus.AllowUserToAddRows = false;
            this.gvIPStatus.AllowUserToDeleteRows = false;
            this.gvIPStatus.AllowUserToOrderColumns = true;
            this.gvIPStatus.AllowUserToResizeColumns = false;
            this.gvIPStatus.AllowUserToResizeRows = false;
            this.gvIPStatus.BackgroundColor = System.Drawing.Color.White;
            this.gvIPStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvIPStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnEnable,
            this.clmnUseCount,
            this.clmnPingCount,
            this.clmnIP,
            this.clmnPingStatus,
            this.clmnFailCount});
            this.gvIPStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.gvIPStatus.Location = new System.Drawing.Point(10, 10);
            this.gvIPStatus.Name = "gvIPStatus";
            this.gvIPStatus.RowHeadersVisible = false;
            this.gvIPStatus.RowHeadersWidth = 10;
            this.gvIPStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvIPStatus.Size = new System.Drawing.Size(341, 193);
            this.gvIPStatus.TabIndex = 1;
            // 
            // contextMenuStrip_IPStatus
            // 
            this.contextMenuStrip_IPStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsiSetToProxy});
            this.contextMenuStrip_IPStatus.Name = "contextMenuStrip_IPStatus";
            this.contextMenuStrip_IPStatus.Size = new System.Drawing.Size(137, 26);
            // 
            // tmsiSetToProxy
            // 
            this.tmsiSetToProxy.Name = "tmsiSetToProxy";
            this.tmsiSetToProxy.Size = new System.Drawing.Size(136, 22);
            this.tmsiSetToProxy.Text = "&Set to Proxy";
            this.tmsiSetToProxy.Click += new System.EventHandler(this.tmsiSetToProxy_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "speed_icon_none.png");
            this.imageList1.Images.SetKeyName(1, "speed_icon_slow.png");
            this.imageList1.Images.SetKeyName(2, "speed_icon_fast.png");
            this.imageList1.Images.SetKeyName(3, "pause16.png");
            this.imageList1.Images.SetKeyName(4, "play16.png");
            this.imageList1.Images.SetKeyName(5, "unnamed.png");
            this.imageList1.Images.SetKeyName(6, "settings.png");
            this.imageList1.Images.SetKeyName(7, "closedDot.png");
            this.imageList1.Images.SetKeyName(8, "openDot.png");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(56, 225);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(208, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 2;
            // 
            // chkAutoChangeProxy
            // 
            this.chkAutoChangeProxy.AutoSize = true;
            this.chkAutoChangeProxy.Location = new System.Drawing.Point(56, 206);
            this.chkAutoChangeProxy.Name = "chkAutoChangeProxy";
            this.chkAutoChangeProxy.Size = new System.Drawing.Size(114, 17);
            this.chkAutoChangeProxy.TabIndex = 3;
            this.chkAutoChangeProxy.Text = "AutoChange Proxy";
            this.chkAutoChangeProxy.UseVisualStyleBackColor = true;
            this.chkAutoChangeProxy.CheckedChanged += new System.EventHandler(this.chkAutoChangeProxy_CheckedChanged);
            // 
            // llCancel
            // 
            this.llCancel.AutoSize = true;
            this.llCancel.BackColor = System.Drawing.Color.Transparent;
            this.llCancel.Location = new System.Drawing.Point(221, 230);
            this.llCancel.Name = "llCancel";
            this.llCancel.Size = new System.Drawing.Size(39, 13);
            this.llCancel.TabIndex = 4;
            this.llCancel.TabStop = true;
            this.llCancel.Text = "cancel";
            this.llCancel.Visible = false;
            this.llCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCancel_LinkClicked);
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(193, 204);
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(47, 20);
            this.nudInterval.TabIndex = 5;
            this.nudInterval.Tag = "second";
            this.nudInterval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudInterval.ValueChanged += new System.EventHandler(this.nudInterval_ValueChanged);
            // 
            // btnTimerPause
            // 
            this.btnTimerPause.ImageIndex = 3;
            this.btnTimerPause.ImageList = this.imageList1;
            this.btnTimerPause.Location = new System.Drawing.Point(242, 203);
            this.btnTimerPause.Name = "btnTimerPause";
            this.btnTimerPause.Size = new System.Drawing.Size(23, 21);
            this.btnTimerPause.TabIndex = 6;
            this.btnTimerPause.UseVisualStyleBackColor = true;
            this.btnTimerPause.Click += new System.EventHandler(this.btnTimerPause_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.SystemColors.Control;
            this.btnSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.BackgroundImage")));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSettings.Location = new System.Drawing.Point(10, 208);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(40, 40);
            this.btnSettings.TabIndex = 7;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // clmnEnable
            // 
            this.clmnEnable.DataPropertyName = "Enable";
            this.clmnEnable.FillWeight = 20F;
            this.clmnEnable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clmnEnable.HeaderText = "";
            this.clmnEnable.Name = "clmnEnable";
            this.clmnEnable.Width = 20;
            // 
            // clmnUseCount
            // 
            this.clmnUseCount.DataPropertyName = "UseCount";
            this.clmnUseCount.FillWeight = 45F;
            this.clmnUseCount.HeaderText = "Used";
            this.clmnUseCount.Name = "clmnUseCount";
            this.clmnUseCount.Width = 45;
            // 
            // clmnPingCount
            // 
            this.clmnPingCount.DataPropertyName = "PingCount";
            this.clmnPingCount.FillWeight = 45F;
            this.clmnPingCount.HeaderText = "Ping";
            this.clmnPingCount.Name = "clmnPingCount";
            this.clmnPingCount.Width = 45;
            // 
            // clmnIP
            // 
            this.clmnIP.ContextMenuStrip = this.contextMenuStrip_IPStatus;
            this.clmnIP.DataPropertyName = "IP";
            this.clmnIP.FillWeight = 90F;
            this.clmnIP.HeaderText = "IP";
            this.clmnIP.Name = "clmnIP";
            this.clmnIP.Width = 90;
            // 
            // clmnPingStatus
            // 
            this.clmnPingStatus.DataPropertyName = "StatusImage";
            this.clmnPingStatus.FillWeight = 70F;
            this.clmnPingStatus.HeaderText = "Ping Status";
            this.clmnPingStatus.Name = "clmnPingStatus";
            this.clmnPingStatus.Width = 70;
            // 
            // clmnFailCount
            // 
            this.clmnFailCount.DataPropertyName = "FailCount";
            this.clmnFailCount.FillWeight = 45F;
            this.clmnFailCount.HeaderText = "Fail";
            this.clmnFailCount.Name = "clmnFailCount";
            this.clmnFailCount.Width = 45;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 257);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnTimerPause);
            this.Controls.Add(this.nudInterval);
            this.Controls.Add(this.llCancel);
            this.Controls.Add(this.chkAutoChangeProxy);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.gvIPStatus);
            this.Controls.Add(this.btnPingAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Proxy IP Pinger - (by MKSURMENELI)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvIPStatus)).EndInit();
            this.contextMenuStrip_IPStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPingAll;
        private System.Windows.Forms.DataGridView gvIPStatus;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkAutoChangeProxy;
        private System.Windows.Forms.LinkLabel llCancel;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Button btnTimerPause;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_IPStatus;
        private System.Windows.Forms.ToolStripMenuItem tmsiSetToProxy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnUseCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPingCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIP;
        private System.Windows.Forms.DataGridViewImageColumn clmnPingStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnFailCount;
    }
}

