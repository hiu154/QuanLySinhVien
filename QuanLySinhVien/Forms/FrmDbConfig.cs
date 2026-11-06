using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.DAL;

namespace QuanLySinhVien.Forms
{
    public partial class FrmDbConfig : Form
    {
        public bool IsConnectionSuccessful { get; private set; }

        public FrmDbConfig()
        {
            InitializeComponent();
        }

        private void FrmDbConfig_Load(object sender, EventArgs e)
        {
            // Nạp các gợi ý Server phổ biến
            cboServer.Items.Clear();
            cboServer.Items.Add(".");
            cboServer.Items.Add("localhost");
            cboServer.Items.Add("(local)");
            cboServer.Items.Add(@".\SQLEXPRESS");
            cboServer.Items.Add(@"(localdb)\MSSQLLocalDB");
            cboServer.Items.Add(@".\MSSQLSERVER01");
            cboServer.Items.Add(@".\MSSQLSERVER");

            // Lấy server hiện tại từ connection string
            string currentCs = DbConnectionFactory.ConnectionString;
            try
            {
                var builder = new SqlConnectionStringBuilder(currentCs);
                cboServer.Text = builder.DataSource;
                if (!builder.IntegratedSecurity && !string.IsNullOrWhiteSpace(builder.UserID))
                {
                    rdoSqlAuth.Checked = true;
                    txtUsername.Text = builder.UserID;
                    txtPassword.Text = builder.Password;
                }
                else
                {
                    rdoWindowsAuth.Checked = true;
                }
            }
            catch
            {
                cboServer.Text = ".";
                rdoWindowsAuth.Checked = true;
            }

            // Tự động kiểm tra nhanh trạng thái ban đầu
            CheckCurrentConnectionQuick();
        }

        private void rdoAuth_CheckedChanged(object sender, EventArgs e)
        {
            pnlSqlAuth.Enabled = rdoSqlAuth.Checked;
        }

        private string BuildCurrentConnectionString(bool connectToMaster = false)
        {
            string srv = cboServer.Text.Trim();
            if (string.IsNullOrWhiteSpace(srv)) srv = ".";
            string db = connectToMaster ? "master" : DbConnectionFactory.DefaultDatabaseName;

            var builder = new SqlConnectionStringBuilder
            {
                DataSource = srv,
                InitialCatalog = db,
                TrustServerCertificate = true,
                ConnectTimeout = 8
            };

            if (rdoWindowsAuth.Checked)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = txtUsername.Text.Trim();
                builder.Password = txtPassword.Text;
            }

            return builder.ConnectionString;
        }

        private void CheckCurrentConnectionQuick()
        {
            string cs = BuildCurrentConnectionString(false);
            var res = DbConnectionFactory.TestConnection(cs);
            if (res.Success)
            {
                lblStatus.ForeColor = Color.FromArgb(16, 185, 129);
                lblStatus.Text = "● Trạng thái: CSDL 'QuanLySinhVienDB' đã sẵn sàng hoạt động!";
                IsConnectionSuccessful = true;
            }
            else
            {
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
                lblStatus.Text = "● Trạng thái: " + res.Message;
                IsConnectionSuccessful = false;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            btnTest.Enabled = false;
            lblStatus.ForeColor = Color.FromArgb(71, 85, 105);
            lblStatus.Text = "Đang kiểm tra kết nối tới SQL Server...";
            Application.DoEvents();

            string cs = BuildCurrentConnectionString(false);
            var res = DbConnectionFactory.TestConnection(cs);

            if (res.Success)
            {
                lblStatus.ForeColor = Color.FromArgb(16, 185, 129);
                lblStatus.Text = "● Kết nối THÀNH CÔNG tới CSDL 'QuanLySinhVienDB'!";
                IsConnectionSuccessful = true;
                UiHelper.ShowSuccess("Kết nối cơ sở dữ liệu thành công! Bạn có thể lưu và đăng nhập.");
            }
            else
            {
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
                lblStatus.Text = "● " + res.Message;
                IsConnectionSuccessful = false;

                // Kiểm tra xem có phải do chưa tạo DB không
                string masterCs = BuildCurrentConnectionString(true);
                var masterTest = DbConnectionFactory.TestConnection(masterCs);
                if (masterTest.Success)
                {
                    lblStatus.Text += "\n👉 Gợi ý: Máy chủ SQL Server hoạt động tốt, hãy bấm '🚀 TỰ ĐỘNG TẠO CSDL MỚI' để tạo CSDL!";
                }
                UiHelper.ShowWarning(res.Message);
            }

            btnTest.Enabled = true;
        }

        private void btnAutoDetect_Click(object sender, EventArgs e)
        {
            btnAutoDetect.Enabled = false;
            lblStatus.ForeColor = Color.FromArgb(71, 85, 105);
            lblStatus.Text = "Đang quét các instance SQL Server trên máy (., SQLEXPRESS, LocalDB, MSSQLSERVER01)...";
            Application.DoEvents();

            var autoRes = DbConnectionFactory.AutoDetectAndFixConnection();
            if (autoRes.Success)
            {
                cboServer.Text = autoRes.WorkingServer;
                lblStatus.ForeColor = Color.FromArgb(16, 185, 129);
                lblStatus.Text = "● " + autoRes.Message;
                IsConnectionSuccessful = true;
                UiHelper.ShowSuccess(autoRes.Message);
            }
            else
            {
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
                lblStatus.Text = "● " + autoRes.Message;
                UiHelper.ShowWarning("Không tìm thấy instance SQL Server tự động. Vui lòng nhập tên Server thủ công hoặc kiểm tra dịch vụ SQL Server đã chạy chưa.");
            }

            btnAutoDetect.Enabled = true;
        }

        private void btnAutoInit_Click(object sender, EventArgs e)
        {
            string srv = cboServer.Text.Trim();
            if (string.IsNullOrWhiteSpace(srv))
            {
                UiHelper.ShowWarning("Vui lòng chọn hoặc nhập tên máy chủ SQL Server.");
                cboServer.Focus();
                return;
            }

            if (!UiHelper.Confirm($"Bạn có chắc chắn muốn TỰ ĐỘNG KHỞI TẠO CSDL 'QuanLySinhVienDB' trên máy chủ '{srv}'?\n\nQuá trình này sẽ tạo 9 bảng và nạp toàn bộ dữ liệu mẫu (admin, sinh viên, môn học, điểm, v.v.).", "Xác nhận tạo CSDL"))
            {
                return;
            }

            btnAutoInit.Enabled = false;
            lblStatus.ForeColor = Color.FromArgb(37, 99, 235);
            lblStatus.Text = "Đang tạo cơ sở dữ liệu và nạp dữ liệu mẫu...";
            Application.DoEvents();

            string? user = rdoSqlAuth.Checked ? txtUsername.Text.Trim() : null;
            string? pass = rdoSqlAuth.Checked ? txtPassword.Text : null;

            var res = DbConnectionFactory.InitializeDatabase(srv, user, pass, msg =>
            {
                lblStatus.Text = msg;
                Application.DoEvents();
            });

            if (res.Success)
            {
                lblStatus.ForeColor = Color.FromArgb(16, 185, 129);
                lblStatus.Text = "● " + res.Message;
                IsConnectionSuccessful = true;
                UiHelper.ShowSuccess(res.Message + "\n\nBạn có thể đăng nhập ngay bằng tài khoản:\n• Quản trị viên: admin / 123456\n• Giảng viên: gv_khoacntt / 123456");
            }
            else
            {
                lblStatus.ForeColor = Color.FromArgb(239, 68, 68);
                lblStatus.Text = "● " + res.Message;
                UiHelper.ShowError(res.Message);
            }

            btnAutoInit.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string cs = BuildCurrentConnectionString(false);
            DbConnectionFactory.ConnectionString = cs;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
