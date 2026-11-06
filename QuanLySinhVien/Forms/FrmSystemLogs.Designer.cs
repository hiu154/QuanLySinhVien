namespace QuanLySinhVien.Forms
{
    partial class FrmSystemLogs
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnExportLog = new System.Windows.Forms.Button();
            this.btnClearOld = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cboLevel = new System.Windows.Forms.ComboBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.txtException = new System.Windows.Forms.TextBox();
            this.lblException = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnExportLog);
            this.pnlTop.Controls.Add(this.btnClearOld);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.dtpTo);
            this.pnlTop.Controls.Add(this.lblTo);
            this.pnlTop.Controls.Add(this.dtpFrom);
            this.pnlTop.Controls.Add(this.lblFrom);
            this.pnlTop.Controls.Add(this.txtUsername);
            this.pnlTop.Controls.Add(this.lblUser);
            this.pnlTop.Controls.Add(this.cboLevel);
            this.pnlTop.Controls.Add(this.lblLevel);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlTop.Size = new System.Drawing.Size(1080, 70);
            this.pnlTop.TabIndex = 0;
            // 
            // btnExportLog
            // 
            this.btnExportLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExportLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportLog.ForeColor = System.Drawing.Color.White;
            this.btnExportLog.Location = new System.Drawing.Point(955, 30);
            this.btnExportLog.Name = "btnExportLog";
            this.btnExportLog.Size = new System.Drawing.Size(113, 30);
            this.btnExportLog.TabIndex = 10;
            this.btnExportLog.Text = "⤓ Xuất file text";
            this.btnExportLog.UseVisualStyleBackColor = false;
            this.btnExportLog.Click += new System.EventHandler(this.btnExportLog_Click);
            // 
            // btnClearOld
            // 
            this.btnClearOld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOld.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnClearOld.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearOld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearOld.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearOld.ForeColor = System.Drawing.Color.White;
            this.btnClearOld.Location = new System.Drawing.Point(830, 30);
            this.btnClearOld.Name = "btnClearOld";
            this.btnClearOld.Size = new System.Drawing.Size(118, 30);
            this.btnClearOld.TabIndex = 9;
            this.btnClearOld.Text = "✕ Dọn log cũ";
            this.btnClearOld.UseVisualStyleBackColor = false;
            this.btnClearOld.Click += new System.EventHandler(this.btnClearOld_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(695, 30);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 30);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "↻ Lọc";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(540, 33);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(140, 24);
            this.dtpTo.TabIndex = 7;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblTo.Location = new System.Drawing.Point(540, 12);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(60, 15);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "Đến ngày:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(385, 33);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(140, 24);
            this.dtpFrom.TabIndex = 5;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblFrom.Location = new System.Drawing.Point(385, 12);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(53, 15);
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Text = "Từ ngày:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtUsername.Location = new System.Drawing.Point(180, 33);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "Tên tài khoản...";
            this.txtUsername.Size = new System.Drawing.Size(190, 24);
            this.txtUsername.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblUser.Location = new System.Drawing.Point(180, 12);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(74, 15);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Người dùng:";
            // 
            // cboLevel
            // 
            this.cboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboLevel.FormattingEnabled = true;
            this.cboLevel.Items.AddRange(new object[] {
            "Tất cả",
            "Debug",
            "Information",
            "Warning",
            "Error",
            "Critical"});
            this.cboLevel.Location = new System.Drawing.Point(12, 33);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Size = new System.Drawing.Size(150, 23);
            this.cboLevel.TabIndex = 1;
            this.cboLevel.SelectedIndexChanged += new System.EventHandler(this.cboLevel_SelectedIndexChanged);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblLevel.Location = new System.Drawing.Point(12, 12);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(89, 15);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Mức độ (Level):";
            // 
            // dgvLogs
            // 
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogs.Location = new System.Drawing.Point(0, 70);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.Size = new System.Drawing.Size(1080, 420);
            this.dgvLogs.TabIndex = 1;
            this.dgvLogs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLogs_CellClick);
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetail.Controls.Add(this.txtException);
            this.pnlDetail.Controls.Add(this.lblException);
            this.pnlDetail.Controls.Add(this.txtMessage);
            this.pnlDetail.Controls.Add(this.lblMessage);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetail.Location = new System.Drawing.Point(0, 490);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlDetail.Size = new System.Drawing.Size(1080, 160);
            this.pnlDetail.TabIndex = 2;
            // 
            // txtException
            // 
            this.txtException.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtException.BackColor = System.Drawing.Color.White;
            this.txtException.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.txtException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.txtException.Location = new System.Drawing.Point(12, 85);
            this.txtException.Multiline = true;
            this.txtException.Name = "txtException";
            this.txtException.ReadOnly = true;
            this.txtException.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtException.Size = new System.Drawing.Size(1054, 65);
            this.txtException.TabIndex = 3;
            // 
            // lblException
            // 
            this.lblException.AutoSize = true;
            this.lblException.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblException.Location = new System.Drawing.Point(12, 68);
            this.lblException.Name = "lblException";
            this.lblException.Size = new System.Drawing.Size(126, 15);
            this.lblException.TabIndex = 2;
            this.lblException.Text = "Chi tiết ngoại lệ / Lỗi:";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMessage.Location = new System.Drawing.Point(12, 28);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(1054, 35);
            this.txtMessage.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Location = new System.Drawing.Point(12, 8);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(108, 15);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Nội dung thao tác:";
            // 
            // FrmSystemLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1080, 650);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FrmSystemLogs";
            this.Text = "Nhật ký Hệ thống (Chương 8 - Logging)";
            this.Load += new System.EventHandler(this.FrmSystemLogs_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.ComboBox cboLevel;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClearOld;
        private System.Windows.Forms.Button btnExportLog;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblException;
        private System.Windows.Forms.TextBox txtException;
    }
}
