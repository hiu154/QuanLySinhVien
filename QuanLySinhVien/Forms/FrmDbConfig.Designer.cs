namespace QuanLySinhVien.Forms
{

    partial class FrmDbConfig
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

            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSub = new Label();
            pnlBody = new Panel();
            lblStatus = new Label();
            btnSave = new Button();
            btnAutoInit = new Button();
            btnTest = new Button();
            btnAutoDetect = new Button();
            pnlSqlAuth = new Panel();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            rdoSqlAuth = new RadioButton();
            rdoWindowsAuth = new RadioButton();
            lblAuthType = new Label();
            txtDatabase = new TextBox();
            lblDatabase = new Label();
            cboServer = new ComboBox();
            lblServer = new Label();
            pnlHeader.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlSqlAuth.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblSub);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(540, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(390, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CẤU HÌNH & KHỞI TẠO SQL SERVER";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.Font = new Font("Segoe UI", 9F);
            lblSub.ForeColor = Color.FromArgb(148, 163, 184);
            lblSub.Location = new Point(22, 48);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(450, 20);
            lblSub.TabIndex = 1;
            lblSub.Text = "Tự động nhận diện và sửa lỗi kết nối để chạy mượt mà trên nhiều máy";
            // 
            // pnlBody
            // 
            pnlBody.BackColor = Color.White;
            pnlBody.Controls.Add(lblStatus);
            pnlBody.Controls.Add(btnSave);
            pnlBody.Controls.Add(btnAutoInit);
            pnlBody.Controls.Add(btnTest);
            pnlBody.Controls.Add(btnAutoDetect);
            pnlBody.Controls.Add(pnlSqlAuth);
            pnlBody.Controls.Add(rdoSqlAuth);
            pnlBody.Controls.Add(rdoWindowsAuth);
            pnlBody.Controls.Add(lblAuthType);
            pnlBody.Controls.Add(txtDatabase);
            pnlBody.Controls.Add(lblDatabase);
            pnlBody.Controls.Add(cboServer);
            pnlBody.Controls.Add(lblServer);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 80);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(25, 20, 25, 20);
            pnlBody.Size = new Size(540, 480);
            pnlBody.TabIndex = 1;
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblServer.ForeColor = Color.FromArgb(30, 41, 59);
            lblServer.Location = new Point(25, 15);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(188, 20);
            lblServer.TabIndex = 0;
            lblServer.Text = "Tên Máy chủ (SQL Server):";
            // 
            // cboServer
            // 
            cboServer.Font = new Font("Segoe UI", 10F);
            cboServer.FormattingEnabled = true;
            cboServer.Location = new Point(25, 38);
            cboServer.Name = "cboServer";
            cboServer.Size = new Size(340, 31);
            cboServer.TabIndex = 1;
            // 
            // btnAutoDetect
            // 
            btnAutoDetect.BackColor = Color.FromArgb(241, 245, 249);
            btnAutoDetect.Cursor = Cursors.Hand;
            btnAutoDetect.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnAutoDetect.FlatStyle = FlatStyle.Flat;
            btnAutoDetect.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAutoDetect.ForeColor = Color.FromArgb(30, 41, 59);
            btnAutoDetect.Location = new Point(375, 37);
            btnAutoDetect.Name = "btnAutoDetect";
            btnAutoDetect.Size = new Size(140, 33);
            btnAutoDetect.TabIndex = 2;
            btnAutoDetect.Text = "⚡ Tự động tìm";
            btnAutoDetect.UseVisualStyleBackColor = false;
            btnAutoDetect.Click += btnAutoDetect_Click;
            // 
            // lblDatabase
            // 
            lblDatabase.AutoSize = true;
            lblDatabase.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDatabase.ForeColor = Color.FromArgb(30, 41, 59);
            lblDatabase.Location = new Point(25, 80);
            lblDatabase.Name = "lblDatabase";
            lblDatabase.Size = new Size(160, 20);
            lblDatabase.TabIndex = 3;
            lblDatabase.Text = "Tên Cơ sở dữ liệu (DB):";
            // 
            // txtDatabase
            // 
            txtDatabase.Font = new Font("Segoe UI", 10F);
            txtDatabase.Location = new Point(25, 103);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.ReadOnly = true;
            txtDatabase.Size = new Size(490, 30);
            txtDatabase.TabIndex = 4;
            txtDatabase.Text = "QuanLySinhVienDB";
            // 
            // lblAuthType
            // 
            lblAuthType.AutoSize = true;
            lblAuthType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAuthType.ForeColor = Color.FromArgb(30, 41, 59);
            lblAuthType.Location = new Point(25, 145);
            lblAuthType.Name = "lblAuthType";
            lblAuthType.Size = new Size(157, 20);
            lblAuthType.TabIndex = 5;
            lblAuthType.Text = "Hình thức xác thực:";
            // 
            // rdoWindowsAuth
            // 
            rdoWindowsAuth.AutoSize = true;
            rdoWindowsAuth.Checked = true;
            rdoWindowsAuth.Cursor = Cursors.Hand;
            rdoWindowsAuth.Font = new Font("Segoe UI", 9F);
            rdoWindowsAuth.Location = new Point(25, 170);
            rdoWindowsAuth.Name = "rdoWindowsAuth";
            rdoWindowsAuth.Size = new Size(244, 24);
            rdoWindowsAuth.TabIndex = 6;
            rdoWindowsAuth.TabStop = true;
            rdoWindowsAuth.Text = "Windows Authentication (Khuyên dùng)";
            rdoWindowsAuth.UseVisualStyleBackColor = true;
            rdoWindowsAuth.CheckedChanged += rdoAuth_CheckedChanged;
            // 
            // rdoSqlAuth
            // 
            rdoSqlAuth.AutoSize = true;
            rdoSqlAuth.Cursor = Cursors.Hand;
            rdoSqlAuth.Font = new Font("Segoe UI", 9F);
            rdoSqlAuth.Location = new Point(285, 170);
            rdoSqlAuth.Name = "rdoSqlAuth";
            rdoSqlAuth.Size = new Size(205, 24);
            rdoSqlAuth.TabIndex = 7;
            rdoSqlAuth.Text = "SQL Server Authentication";
            rdoSqlAuth.UseVisualStyleBackColor = true;
            rdoSqlAuth.CheckedChanged += rdoAuth_CheckedChanged;
            // 
            // pnlSqlAuth
            // 
            pnlSqlAuth.Controls.Add(txtPassword);
            pnlSqlAuth.Controls.Add(lblPassword);
            pnlSqlAuth.Controls.Add(txtUsername);
            pnlSqlAuth.Controls.Add(lblUsername);
            pnlSqlAuth.Enabled = false;
            pnlSqlAuth.Location = new Point(25, 200);
            pnlSqlAuth.Name = "pnlSqlAuth";
            pnlSqlAuth.Size = new Size(490, 65);
            pnlSqlAuth.TabIndex = 8;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 8.5F);
            lblUsername.Location = new Point(3, 8);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(78, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tài khoản:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.Location = new Point(5, 30);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(220, 27);
            txtUsername.TabIndex = 1;
            txtUsername.Text = "sa";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 8.5F);
            lblPassword.Location = new Point(255, 8);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(255, 30);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(230, 27);
            txtPassword.TabIndex = 3;
            // 
            // btnTest
            // 
            btnTest.BackColor = Color.FromArgb(241, 245, 249);
            btnTest.Cursor = Cursors.Hand;
            btnTest.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnTest.FlatStyle = FlatStyle.Flat;
            btnTest.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTest.ForeColor = Color.FromArgb(51, 65, 85);
            btnTest.Location = new Point(25, 275);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(230, 38);
            btnTest.TabIndex = 9;
            btnTest.Text = "Kiểm tra kết nối";
            btnTest.UseVisualStyleBackColor = false;
            btnTest.Click += btnTest_Click;
            // 
            // btnAutoInit
            // 
            btnAutoInit.BackColor = Color.FromArgb(16, 185, 129);
            btnAutoInit.Cursor = Cursors.Hand;
            btnAutoInit.FlatAppearance.BorderSize = 0;
            btnAutoInit.FlatStyle = FlatStyle.Flat;
            btnAutoInit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAutoInit.ForeColor = Color.White;
            btnAutoInit.Location = new Point(275, 275);
            btnAutoInit.Name = "btnAutoInit";
            btnAutoInit.Size = new Size(240, 38);
            btnAutoInit.TabIndex = 10;
            btnAutoInit.Text = "TỰ ĐỘNG TẠO CSDL MỚI";
            btnAutoInit.UseVisualStyleBackColor = false;
            btnAutoInit.Click += btnAutoInit_Click;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.FromArgb(248, 250, 252);
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Font = new Font("Segoe UI", 8.5F);
            lblStatus.ForeColor = Color.FromArgb(71, 85, 105);
            lblStatus.Location = new Point(25, 325);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(10, 8, 10, 8);
            lblStatus.Size = new Size(490, 80);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "Sẵn sàng kiểm tra và khởi tạo cơ sở dữ liệu.";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(25, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(490, 42);
            btnSave.TabIndex = 12;
            btnSave.Text = "LƯU CẤU HÌNH VÀ SỬ DỤNG";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // FrmDbConfig
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 560);
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDbConfig";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cấu hình kết nối SQL Server";
            Load += FrmDbConfig_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            pnlSqlAuth.ResumeLayout(false);
            pnlSqlAuth.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlHeader;

        private Label lblTitle;

        private Label lblSub;

        private Panel pnlBody;

        private Label lblServer;

        private ComboBox cboServer;

        private Button btnAutoDetect;

        private Label lblDatabase;

        private TextBox txtDatabase;

        private Label lblAuthType;

        private RadioButton rdoWindowsAuth;

        private RadioButton rdoSqlAuth;

        private Panel pnlSqlAuth;

        private Label lblUsername;

        private TextBox txtUsername;

        private Label lblPassword;

        private TextBox txtPassword;

        private Button btnTest;

        private Button btnAutoInit;

        private Label lblStatus;

        private Button btnSave;
    }

}

