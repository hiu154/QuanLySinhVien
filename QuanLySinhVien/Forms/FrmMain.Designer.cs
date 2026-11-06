namespace QuanLySinhVien.Forms
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnGrades = new System.Windows.Forms.Button();
            this.btnSubjects = new System.Windows.Forms.Button();
            this.btnClasses = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlUserBanner = new System.Windows.Forms.Panel();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblDbStatus = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusDb = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar.SuspendLayout();
            this.pnlUserBanner.SuspendLayout();
            this.pnlBrand.SuspendLayout();
            this.pnlTopHeader.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnChangePass);
            this.pnlSidebar.Controls.Add(this.btnLogs);
            this.pnlSidebar.Controls.Add(this.btnUsers);
            this.pnlSidebar.Controls.Add(this.btnStatistics);
            this.pnlSidebar.Controls.Add(this.btnGrades);
            this.pnlSidebar.Controls.Add(this.btnSubjects);
            this.pnlSidebar.Controls.Add(this.btnClasses);
            this.pnlSidebar.Controls.Add(this.btnStudents);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.pnlUserBanner);
            this.pnlSidebar.Controls.Add(this.pnlBrand);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 720);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 676);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(240, 44);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "➔   Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePass.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChangePass.FlatAppearance.BorderSize = 0;
            this.btnChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnChangePass.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnChangePass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePass.Location = new System.Drawing.Point(0, 492);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnChangePass.Size = new System.Drawing.Size(240, 44);
            this.btnChangePass.TabIndex = 10;
            this.btnChangePass.Text = "🔒   Đổi mật khẩu";
            this.btnChangePass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // btnLogs
            // 
            this.btnLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogs.FlatAppearance.BorderSize = 0;
            this.btnLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogs.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogs.Location = new System.Drawing.Point(0, 448);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnLogs.Size = new System.Drawing.Size(240, 44);
            this.btnLogs.TabIndex = 9;
            this.btnLogs.Text = "≡   Nhật ký hệ thống";
            this.btnLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(0, 404);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(240, 44);
            this.btnUsers.TabIndex = 8;
            this.btnUsers.Text = "👤   Quản lý tài khoản";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatistics.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStatistics.FlatAppearance.BorderSize = 0;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnStatistics.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnStatistics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistics.Location = new System.Drawing.Point(0, 360);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnStatistics.Size = new System.Drawing.Size(240, 44);
            this.btnStatistics.TabIndex = 7;
            this.btnStatistics.Text = "◆   Thống kê && Báo cáo";
            this.btnStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnGrades
            // 
            this.btnGrades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrades.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGrades.FlatAppearance.BorderSize = 0;
            this.btnGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrades.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGrades.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnGrades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrades.Location = new System.Drawing.Point(0, 316);
            this.btnGrades.Name = "btnGrades";
            this.btnGrades.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnGrades.Size = new System.Drawing.Size(240, 44);
            this.btnGrades.TabIndex = 6;
            this.btnGrades.Text = "★   Điểm && Kết quả";
            this.btnGrades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrades.UseVisualStyleBackColor = true;
            this.btnGrades.Click += new System.EventHandler(this.btnGrades_Click);
            // 
            // btnSubjects
            // 
            this.btnSubjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubjects.FlatAppearance.BorderSize = 0;
            this.btnSubjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubjects.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSubjects.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnSubjects.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubjects.Location = new System.Drawing.Point(0, 272);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnSubjects.Size = new System.Drawing.Size(240, 44);
            this.btnSubjects.TabIndex = 5;
            this.btnSubjects.Text = "▲   Môn học && Học kỳ";
            this.btnSubjects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubjects.UseVisualStyleBackColor = true;
            this.btnSubjects.Click += new System.EventHandler(this.btnSubjects_Click);
            // 
            // btnClasses
            // 
            this.btnClasses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClasses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClasses.FlatAppearance.BorderSize = 0;
            this.btnClasses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasses.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClasses.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnClasses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClasses.Location = new System.Drawing.Point(0, 228);
            this.btnClasses.Name = "btnClasses";
            this.btnClasses.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnClasses.Size = new System.Drawing.Size(240, 44);
            this.btnClasses.TabIndex = 4;
            this.btnClasses.Text = "■   Khoa && Lớp học";
            this.btnClasses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClasses.UseVisualStyleBackColor = true;
            this.btnClasses.Click += new System.EventHandler(this.btnClasses_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStudents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStudents.FlatAppearance.BorderSize = 0;
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnStudents.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnStudents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudents.Location = new System.Drawing.Point(0, 184);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnStudents.Size = new System.Drawing.Size(240, 44);
            this.btnStudents.TabIndex = 3;
            this.btnStudents.Text = "●   Quản lý Sinh viên";
            this.btnStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 140);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(240, 44);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "❖   Bàn làm việc";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnlUserBanner
            // 
            this.pnlUserBanner.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlUserBanner.Controls.Add(this.lblUserRole);
            this.pnlUserBanner.Controls.Add(this.lblUserName);
            this.pnlUserBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserBanner.Location = new System.Drawing.Point(0, 70);
            this.pnlUserBanner.Name = "pnlUserBanner";
            this.pnlUserBanner.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.pnlUserBanner.Size = new System.Drawing.Size(240, 70);
            this.pnlUserBanner.TabIndex = 1;
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblUserRole.ForeColor = System.Drawing.Color.FromArgb(56, 189, 248);
            this.lblUserRole.Location = new System.Drawing.Point(18, 38);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(84, 15);
            this.lblUserRole.TabIndex = 1;
            this.lblUserRole.Text = "Quản trị viên";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(18, 14);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(147, 19);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Nguyễn Văn Quản Trị";
            // 
            // pnlBrand
            // 
            this.pnlBrand.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlBrand.Controls.Add(this.lblBrandSub);
            this.pnlBrand.Controls.Add(this.lblBrand);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(240, 70);
            this.pnlBrand.TabIndex = 0;
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.AutoSize = true;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblBrandSub.Location = new System.Drawing.Point(18, 42);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(183, 13);
            this.lblBrandSub.TabIndex = 1;
            this.lblBrandSub.Text = "Hệ thống Quản lý Đào tạo 3 Tầng";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(16, 14);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(155, 25);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "★ QLSV SYSTEM";
            // 
            // pnlTopHeader
            // 
            this.pnlTopHeader.BackColor = System.Drawing.Color.White;
            this.pnlTopHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopHeader.Controls.Add(this.lblCurrentTime);
            this.pnlTopHeader.Controls.Add(this.lblDbStatus);
            this.pnlTopHeader.Controls.Add(this.lblPageTitle);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(240, 0);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.pnlTopHeader.Size = new System.Drawing.Size(960, 60);
            this.pnlTopHeader.TabIndex = 1;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentTime.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCurrentTime.Location = new System.Drawing.Point(740, 18);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(200, 23);
            this.lblCurrentTime.TabIndex = 2;
            this.lblCurrentTime.Text = "Thứ sáu, 30/10/2026 02:00";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDbStatus
            // 
            this.lblDbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDbStatus.AutoSize = true;
            this.lblDbStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDbStatus.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblDbStatus.Location = new System.Drawing.Point(540, 22);
            this.lblDbStatus.Name = "lblDbStatus";
            this.lblDbStatus.Size = new System.Drawing.Size(181, 15);
            this.lblDbStatus.TabIndex = 1;
            this.lblDbStatus.Text = "● SQL Server: Đang hoạt động";
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPageTitle.Location = new System.Drawing.Point(18, 16);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(157, 25);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "❖ Bàn làm việc";
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(240, 60);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(960, 638);
            this.pnlContainer.TabIndex = 2;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusUser,
            this.lblStatusRole,
            this.lblStatusDb});
            this.statusStrip.Location = new System.Drawing.Point(240, 698);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(960, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblStatusUser
            // 
            this.lblStatusUser.Name = "lblStatusUser";
            this.lblStatusUser.Size = new System.Drawing.Size(126, 17);
            this.lblStatusUser.Text = "Người dùng: (Chưa có)";
            // 
            // lblStatusDb
            // 
            this.lblStatusDb.Name = "lblStatusDb";
            this.lblStatusDb.Size = new System.Drawing.Size(176, 17);
            this.lblStatusDb.Text = "|   Database: QuanLySinhVienDB";
            // 
            // lblStatusRole
            // 
            this.lblStatusRole.Name = "lblStatusRole";
            this.lblStatusRole.Size = new System.Drawing.Size(93, 17);
            this.lblStatusRole.Text = "|   Vai trò: Admin";
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pnlTopHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Sinh viên - Kiến trúc 3 Tầng UI - BLL - DAL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlUserBanner.ResumeLayout(false);
            this.pnlUserBanner.PerformLayout();
            this.pnlBrand.ResumeLayout(false);
            this.pnlBrand.PerformLayout();
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Panel pnlUserBanner;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnClasses;
        private System.Windows.Forms.Button btnSubjects;
        private System.Windows.Forms.Button btnGrades;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblDbStatus;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusUser;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusRole;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusDb;
        private System.Windows.Forms.Timer timerClock;
    }
}
