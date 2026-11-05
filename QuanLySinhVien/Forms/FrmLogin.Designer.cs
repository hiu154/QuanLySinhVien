namespace QuanLySinhVien.Forms
{
    partial class FrmLogin
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
            pnlHero = new Panel();
            pnlRight = new Panel();
            pnlQuickRow = new Panel();
            btnQuickTeacher = new Button();
            btnQuickAdmin = new Button();
            lblOrDemo = new Label();
            btnLogin = new Button();
            pnlOptions = new Panel();
            lblDefaultPassHint = new Label();
            chkRemember = new CheckBox();
            pnlPassBox = new Panel();
            btnToggleEye = new Button();
            txtPassword = new TextBox();
            lblPassIcon = new Label();
            lblPassHeader = new Label();
            pnlUserBox = new Panel();
            txtUsername = new TextBox();
            lblUserIcon = new Label();
            lblUserHeader = new Label();
            lblSub = new Label();
            lblTitle = new Label();
            pnlWindowControls = new Panel();
            btnMinimize = new Button();
            btnClose = new Button();
            pnlRight.SuspendLayout();
            pnlQuickRow.SuspendLayout();
            pnlOptions.SuspendLayout();
            pnlPassBox.SuspendLayout();
            pnlUserBox.SuspendLayout();
            pnlWindowControls.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHero
            // 
            pnlHero.BackColor = Color.FromArgb(15, 23, 42);
            pnlHero.Dock = DockStyle.Left;
            pnlHero.Location = new Point(0, 0);
            pnlHero.Name = "pnlHero";
            pnlHero.Size = new Size(354, 560);
            pnlHero.TabIndex = 0;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(pnlQuickRow);
            pnlRight.Controls.Add(lblOrDemo);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.Controls.Add(pnlOptions);
            pnlRight.Controls.Add(pnlPassBox);
            pnlRight.Controls.Add(lblPassHeader);
            pnlRight.Controls.Add(pnlUserBox);
            pnlRight.Controls.Add(lblUserHeader);
            pnlRight.Controls.Add(lblSub);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Controls.Add(pnlWindowControls);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(354, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(526, 560);
            pnlRight.TabIndex = 1;
            // 
            // pnlQuickRow
            // 
            pnlQuickRow.Controls.Add(btnQuickTeacher);
            pnlQuickRow.Controls.Add(btnQuickAdmin);
            pnlQuickRow.Location = new Point(55, 435);
            pnlQuickRow.Name = "pnlQuickRow";
            pnlQuickRow.Size = new Size(410, 42);
            pnlQuickRow.TabIndex = 10;
            // 
            // btnQuickTeacher
            // 
            btnQuickTeacher.BackColor = Color.FromArgb(240, 249, 255);
            btnQuickTeacher.Cursor = Cursors.Hand;
            btnQuickTeacher.FlatAppearance.BorderColor = Color.FromArgb(186, 230, 253);
            btnQuickTeacher.FlatStyle = FlatStyle.Flat;
            btnQuickTeacher.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnQuickTeacher.ForeColor = Color.FromArgb(3, 105, 161);
            btnQuickTeacher.Location = new Point(219, 2);
            btnQuickTeacher.Name = "btnQuickTeacher";
            btnQuickTeacher.Size = new Size(130, 36);
            btnQuickTeacher.TabIndex = 1;
            btnQuickTeacher.Text = "Giảng Viên";
            btnQuickTeacher.UseVisualStyleBackColor = false;
            btnQuickTeacher.Click += btnQuickTeacher_Click;
            // 
            // btnQuickAdmin
            // 
            btnQuickAdmin.BackColor = Color.FromArgb(238, 242, 255);
            btnQuickAdmin.Cursor = Cursors.Hand;
            btnQuickAdmin.FlatAppearance.BorderColor = Color.FromArgb(199, 210, 254);
            btnQuickAdmin.FlatStyle = FlatStyle.Flat;
            btnQuickAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnQuickAdmin.ForeColor = Color.FromArgb(67, 56, 202);
            btnQuickAdmin.Location = new Point(58, 2);
            btnQuickAdmin.Name = "btnQuickAdmin";
            btnQuickAdmin.Size = new Size(130, 36);
            btnQuickAdmin.TabIndex = 0;
            btnQuickAdmin.Text = "Quản Trị Viên";
            btnQuickAdmin.UseVisualStyleBackColor = false;
            btnQuickAdmin.Click += btnQuickAdmin_Click;
            // 
            // lblOrDemo
            // 
            lblOrDemo.Font = new Font("Segoe UI", 8.5F);
            lblOrDemo.ForeColor = Color.FromArgb(148, 163, 184);
            lblOrDemo.Location = new Point(55, 400);
            lblOrDemo.Name = "lblOrDemo";
            lblOrDemo.Size = new Size(410, 24);
            lblOrDemo.TabIndex = 9;
            lblOrDemo.Text = "─── HOẶC TRẢI NGHIỆM NHANH VỚI ───";
            lblOrDemo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(37, 99, 235);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(55, 345);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(410, 44);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "ĐĂNG NHẬP HỆ THỐNG  →";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pnlOptions
            // 
            pnlOptions.Controls.Add(lblDefaultPassHint);
            pnlOptions.Controls.Add(chkRemember);
            pnlOptions.Location = new Point(55, 305);
            pnlOptions.Name = "pnlOptions";
            pnlOptions.Size = new Size(410, 28);
            pnlOptions.TabIndex = 7;
            // 
            // lblDefaultPassHint
            // 
            lblDefaultPassHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDefaultPassHint.AutoSize = true;
            lblDefaultPassHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblDefaultPassHint.ForeColor = Color.FromArgb(148, 163, 184);
            lblDefaultPassHint.Location = new Point(270, 6);
            lblDefaultPassHint.Name = "lblDefaultPassHint";
            lblDefaultPassHint.Size = new Size(157, 20);
            lblDefaultPassHint.TabIndex = 1;
            lblDefaultPassHint.Text = "Mật khẩu mẫu: 123456";
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.Checked = true;
            chkRemember.CheckState = CheckState.Checked;
            chkRemember.Cursor = Cursors.Hand;
            chkRemember.Font = new Font("Segoe UI", 9F);
            chkRemember.ForeColor = Color.FromArgb(71, 85, 105);
            chkRemember.Location = new Point(2, 5);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(157, 24);
            chkRemember.TabIndex = 0;
            chkRemember.Text = "Ghi nhớ đăng nhập";
            chkRemember.UseVisualStyleBackColor = true;
            // 
            // pnlPassBox
            // 
            pnlPassBox.BackColor = Color.FromArgb(248, 250, 252);
            pnlPassBox.BorderStyle = BorderStyle.FixedSingle;
            pnlPassBox.Controls.Add(btnToggleEye);
            pnlPassBox.Controls.Add(txtPassword);
            pnlPassBox.Controls.Add(lblPassIcon);
            pnlPassBox.Location = new Point(55, 255);
            pnlPassBox.Name = "pnlPassBox";
            pnlPassBox.Size = new Size(410, 42);
            pnlPassBox.TabIndex = 6;
            // 
            // btnToggleEye
            // 
            btnToggleEye.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToggleEye.BackColor = Color.Transparent;
            btnToggleEye.Cursor = Cursors.Hand;
            btnToggleEye.FlatAppearance.BorderSize = 0;
            btnToggleEye.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnToggleEye.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnToggleEye.FlatStyle = FlatStyle.Flat;
            btnToggleEye.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnToggleEye.ForeColor = Color.FromArgb(71, 85, 105);
            btnToggleEye.Location = new Point(354, 4);
            btnToggleEye.Name = "btnToggleEye";
            btnToggleEye.Size = new Size(50, 32);
            btnToggleEye.TabIndex = 2;
            btnToggleEye.Text = "Hiện";
            btnToggleEye.UseVisualStyleBackColor = false;
            btnToggleEye.Click += btnToggleEye_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(248, 250, 252);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.Location = new Point(44, 10);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(304, 25);
            txtPassword.TabIndex = 1;
            // 
            // lblPassIcon
            // 
            lblPassIcon.Font = new Font("Segoe MDL2 Assets", 10F);
            lblPassIcon.ForeColor = Color.FromArgb(100, 116, 139);
            lblPassIcon.Location = new Point(8, 8);
            lblPassIcon.Name = "lblPassIcon";
            lblPassIcon.Size = new Size(28, 24);
            lblPassIcon.TabIndex = 0;
            lblPassIcon.Text = "\uE72E";
            lblPassIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPassHeader
            // 
            lblPassHeader.AutoSize = true;
            lblPassHeader.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblPassHeader.ForeColor = Color.FromArgb(71, 85, 105);
            lblPassHeader.Location = new Point(55, 235);
            lblPassHeader.Name = "lblPassHeader";
            lblPassHeader.Size = new Size(84, 19);
            lblPassHeader.TabIndex = 5;
            lblPassHeader.Text = "MẬT KHẨU";
            // 
            // pnlUserBox
            // 
            pnlUserBox.BackColor = Color.FromArgb(248, 250, 252);
            pnlUserBox.BorderStyle = BorderStyle.FixedSingle;
            pnlUserBox.Controls.Add(txtUsername);
            pnlUserBox.Controls.Add(lblUserIcon);
            pnlUserBox.Location = new Point(55, 175);
            pnlUserBox.Name = "pnlUserBox";
            pnlUserBox.Size = new Size(410, 42);
            pnlUserBox.TabIndex = 4;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(248, 250, 252);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.ForeColor = Color.FromArgb(15, 23, 42);
            txtUsername.Location = new Point(44, 10);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(350, 25);
            txtUsername.TabIndex = 1;
            // 
            // lblUserIcon
            // 
            lblUserIcon.Font = new Font("Segoe MDL2 Assets", 10F);
            lblUserIcon.ForeColor = Color.FromArgb(100, 116, 139);
            lblUserIcon.Location = new Point(8, 8);
            lblUserIcon.Name = "lblUserIcon";
            lblUserIcon.Size = new Size(28, 24);
            lblUserIcon.TabIndex = 0;
            lblUserIcon.Text = "\uE77B";
            lblUserIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserHeader
            // 
            lblUserHeader.AutoSize = true;
            lblUserHeader.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblUserHeader.ForeColor = Color.FromArgb(71, 85, 105);
            lblUserHeader.Location = new Point(55, 155);
            lblUserHeader.Name = "lblUserHeader";
            lblUserHeader.Size = new Size(216, 19);
            lblUserHeader.TabIndex = 3;
            lblUserHeader.Text = "TÀI KHOẢN / TÊN ĐĂNG NHẬP";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.Font = new Font("Segoe UI", 9.5F);
            lblSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblSub.Location = new Point(55, 105);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(345, 21);
            lblSub.TabIndex = 2;
            lblSub.Text = "Chào mừng bạn! Vui lòng đăng nhập để tiếp tục.";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(52, 65);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 46);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Đăng Nhập";
            // 
            // pnlWindowControls
            // 
            pnlWindowControls.Controls.Add(btnMinimize);
            pnlWindowControls.Controls.Add(btnClose);
            pnlWindowControls.Dock = DockStyle.Top;
            pnlWindowControls.Location = new Point(0, 0);
            pnlWindowControls.Name = "pnlWindowControls";
            pnlWindowControls.Size = new Size(526, 38);
            pnlWindowControls.TabIndex = 0;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.FromArgb(100, 116, 139);
            btnMinimize.Location = new Point(430, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(46, 36);
            btnMinimize.TabIndex = 1;
            btnMinimize.Text = "─";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 68, 68);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(100, 116, 139);
            btnClose.Location = new Point(478, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(46, 36);
            btnClose.TabIndex = 0;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += btnClose_MouseEnter;
            btnClose.MouseLeave += btnClose_MouseLeave;
            // 
            // FrmLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(880, 560);
            Controls.Add(pnlRight);
            Controls.Add(pnlHero);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống - Quản lý Sinh viên";
            Load += FrmLogin_Load;
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlQuickRow.ResumeLayout(false);
            pnlOptions.ResumeLayout(false);
            pnlOptions.PerformLayout();
            pnlPassBox.ResumeLayout(false);
            pnlPassBox.PerformLayout();
            pnlUserBox.ResumeLayout(false);
            pnlUserBox.PerformLayout();
            pnlWindowControls.ResumeLayout(false);
            ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHero;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlWindowControls;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblUserHeader;
        private System.Windows.Forms.Panel pnlUserBox;
        private System.Windows.Forms.Label lblUserIcon;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassHeader;
        private System.Windows.Forms.Panel pnlPassBox;
        private System.Windows.Forms.Label lblPassIcon;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnToggleEye;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.Label lblDefaultPassHint;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblOrDemo;
        private System.Windows.Forms.Panel pnlQuickRow;
        private System.Windows.Forms.Button btnQuickAdmin;
        private System.Windows.Forms.Button btnQuickTeacher;
    }
}
