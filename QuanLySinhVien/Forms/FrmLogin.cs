using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.Forms
{
    public partial class FrmLogin : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private readonly AuthBLL _authBll = new AuthBLL();
        private bool _isPasswordShown = false;
        private bool _isUserFocused = false;
        private bool _isPassFocused = false;

        public UserDTO? LoggedInUser { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
            SetupFormBehaviors();
        }

        private void SetupFormBehaviors()
        {
            // Kéo form di chuyển mượt mà
            pnlHero.MouseDown += OnDragMouseDown;
            pnlRight.MouseDown += OnDragMouseDown;
            pnlWindowControls.MouseDown += OnDragMouseDown;
            lblTitle.MouseDown += OnDragMouseDown;
            lblSub.MouseDown += OnDragMouseDown;

            // Gradient và vẽ đồ họa trực tiếp cho Panel Hero để khử hoàn toàn viền đen chữ
            pnlHero.Paint += PnlHero_Paint;

            // Viền ngoài sang trọng cho Form
            this.Paint += FrmLogin_Paint;
            this.Resize += (s, e) => ApplyRoundedRegion(this, 14);
            ApplyRoundedRegion(this, 14);

            pnlUserBox.BorderStyle = BorderStyle.None;
            pnlPassBox.BorderStyle = BorderStyle.None;
            pnlUserBox.Resize += (s, e) => ApplyRoundedRegion(pnlUserBox, 10);
            pnlPassBox.Resize += (s, e) => ApplyRoundedRegion(pnlPassBox, 10);
            ApplyRoundedRegion(pnlUserBox, 10);
            ApplyRoundedRegion(pnlPassBox, 10);

            btnLogin.Resize += (s, e) => ApplyRoundedRegion(btnLogin, 10);
            ApplyRoundedRegion(btnLogin, 10);
            ApplyRoundedRegion(btnQuickAdmin, 8);
            ApplyRoundedRegion(btnQuickTeacher, 8);

            // Hiệu ứng viền sáng khi trỏ chuột vào ô nhập
            pnlUserBox.Paint += (s, e) => DrawInputBoxBorder(e.Graphics, pnlUserBox, _isUserFocused);
            pnlPassBox.Paint += (s, e) => DrawInputBoxBorder(e.Graphics, pnlPassBox, _isPassFocused);

            txtUsername.Enter += (s, e) => { _isUserFocused = true; pnlUserBox.BackColor = Color.White; txtUsername.BackColor = Color.White; pnlUserBox.Invalidate(); };
            txtUsername.Leave += (s, e) => { _isUserFocused = false; pnlUserBox.BackColor = Color.FromArgb(248, 250, 252); txtUsername.BackColor = Color.FromArgb(248, 250, 252); pnlUserBox.Invalidate(); };

            txtPassword.Enter += (s, e) => { _isPassFocused = true; pnlPassBox.BackColor = Color.White; txtPassword.BackColor = Color.White; pnlPassBox.Invalidate(); };
            txtPassword.Leave += (s, e) => { _isPassFocused = false; pnlPassBox.BackColor = Color.FromArgb(248, 250, 252); txtPassword.BackColor = Color.FromArgb(248, 250, 252); pnlPassBox.Invalidate(); };

            // Hover effects cho nút demo
            SetupDemoButtonHover(btnQuickAdmin, Color.FromArgb(238, 242, 255), Color.FromArgb(224, 231, 255));
            SetupDemoButtonHover(btnQuickTeacher, Color.FromArgb(240, 249, 255), Color.FromArgb(224, 242, 254));


            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = Color.FromArgb(29, 78, 216);
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = Color.FromArgb(37, 99, 235);
        }

        private void OnDragMouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PnlHero_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // 1. Nền Gradient hoàng gia Slate 950 -> Deep Royal Navy
            using (var brush = new LinearGradientBrush(
                pnlHero.ClientRectangle,
                Color.FromArgb(15, 23, 42),
                Color.FromArgb(30, 58, 138),
                135f))
            {
                g.FillRectangle(brush, pnlHero.ClientRectangle);
            }

            // 2. Hiệu ứng ánh sáng tinh tế phía góc trên bên trái
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(-60, -60, 320, 320);
                using (var glowBrush = new PathGradientBrush(path))
                {
                    glowBrush.CenterColor = Color.FromArgb(40, 56, 189, 248);
                    glowBrush.SurroundColors = new[] { Color.Transparent };
                    g.FillPath(glowBrush, path);
                }
            }

            // 3. Huy hiệu phiên bản (Version Pill Badge)
            int badgeX = 32, badgeY = 32, badgeW = 160, badgeH = 26;
            using (var badgePath = GetRoundedPath(new Rectangle(badgeX, badgeY, badgeW, badgeH), 13))
            {
                using (var badgeBg = new SolidBrush(Color.FromArgb(50, 30, 41, 59)))
                {
                    g.FillPath(badgeBg, badgePath);
                }
                using (var badgeBorder = new Pen(Color.FromArgb(80, 56, 189, 248), 1))
                {
                    g.DrawPath(badgeBorder, badgePath);
                }
            }
            using (var dotBrush = new SolidBrush(Color.FromArgb(56, 189, 248)))
            {
                g.FillEllipse(dotBrush, badgeX + 12, badgeY + 9, 8, 8);
            }
            using (var badgeFont = new Font("Segoe UI", 8F, FontStyle.Bold))
            using (var textBrush = new SolidBrush(Color.FromArgb(56, 189, 248)))
            {
                g.DrawString("PHIÊN BẢN 2.0 • .NET 10", badgeFont, textBrush, badgeX + 26, badgeY + 6);
            }

            // 4. Logo Mũ Cử Nhân (Graduation Cap Icon vector sạch sẽ)
            DrawGraduationIcon(g, 32, 85);

            // 5. Tiêu đề thương hiệu
            using (var titleFont = new Font("Segoe UI", 22F, FontStyle.Bold))
            using (var whiteBrush = new SolidBrush(Color.White))
            {
                g.DrawString("QLSV SYSTEM", titleFont, whiteBrush, 30, 160);
            }

            // 6. Mô tả phụ
            using (var subFont = new Font("Segoe UI", 9.5F, FontStyle.Regular))
            using (var slateBrush = new SolidBrush(Color.FromArgb(148, 163, 184)))
            {
                var rect = new RectangleF(32, 210, 296, 50);
                g.DrawString("Quản lý sinh viên, đào tạo, điểm số và học vụ trên một nền tảng.", subFont, slateBrush, rect);
            }

            // 7. Đường phân cách mờ
            using (var linePen = new Pen(Color.FromArgb(51, 65, 85), 1))
            {
                g.DrawLine(linePen, 32, 275, 328, 275);
            }

            // 8. Danh sách điểm mạnh của hệ thống (Tính năng cốt lõi)
            string[] features = {
                "Kiến trúc 3 tầng: UI • BLL • DAL • SQL Server",
                "Xác thực SHA-256 + Salt an toàn",
                "Tính điểm, xếp loại & GPA 10 / 4",
                "Thống kê KPI & cảnh báo học vụ",
                "Nhật ký kiểm toán 5 cấp độ"
            };

            int startY = 298;
            using (var checkFont = new Font("Segoe UI", 9F, FontStyle.Bold))
            using (var featFont = new Font("Segoe UI", 9F, FontStyle.Regular))
            using (var checkBrush = new SolidBrush(Color.FromArgb(56, 189, 248)))
            using (var featBrush = new SolidBrush(Color.FromArgb(226, 232, 240)))
            {
                for (int i = 0; i < features.Length; i++)
                {
                    int itemY = startY + (i * 35);

                    // Check circle pill
                    using (var pillBrush = new SolidBrush(Color.FromArgb(40, 56, 189, 248)))
                    {
                        g.FillEllipse(pillBrush, 32, itemY + 1, 16, 16);
                    }
                    g.DrawString("✓", checkFont, checkBrush, 34, itemY - 1);

                    // Text
                    g.DrawString(features[i], featFont, featBrush, 56, itemY);
                }
            }

            // 9. Bản quyền Footer
            using (var footFont = new Font("Segoe UI", 8.5F, FontStyle.Regular))
            using (var footBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
            {
                g.DrawString("© 2026 • Khoa Công Nghệ Thông Tin (CNTT)", footFont, footBrush, 32, 518);
            }
        }

        private void DrawGraduationIcon(Graphics g, int x, int y)
        {
            // Nền bo góc của biểu tượng
            using (var boxPath = GetRoundedPath(new Rectangle(x, y, 60, 60), 16))
            {
                using (var boxBrush = new SolidBrush(Color.FromArgb(40, 30, 41, 59)))
                {
                    g.FillPath(boxBrush, boxPath);
                }
                using (var boxPen = new Pen(Color.FromArgb(80, 56, 189, 248), 1.5f))
                {
                    g.DrawPath(boxPen, boxPath);
                }
            }

            // Biểu tượng Mũ Cử Nhân vẽ bằng vector
            using (var pen = new Pen(Color.FromArgb(56, 189, 248), 2.2f))
            using (var fill = new SolidBrush(Color.FromArgb(14, 165, 233)))
            {
                pen.LineJoin = LineJoin.Round;

                // Thoi chóp mũ
                Point[] diamond = {
                    new Point(x + 30, y + 15),
                    new Point(x + 50, y + 25),
                    new Point(x + 30, y + 35),
                    new Point(x + 10, y + 25)
                };
                g.FillPolygon(fill, diamond);
                g.DrawPolygon(pen, diamond);

                // Thân mũ cong phía dưới
                g.DrawArc(pen, x + 18, y + 27, 24, 16, 0, 180);

                // Dây tua mũ
                g.DrawLine(pen, x + 10, y + 25, x + 10, y + 42);
                g.FillEllipse(new SolidBrush(Color.FromArgb(56, 189, 248)), x + 8, y + 40, 4, 6);
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            float d = radius * 2f;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void FrmLogin_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = GetRoundedPath(new Rectangle(0, 0, this.Width - 1, this.Height - 1), 14))
            using (var pen = new Pen(Color.FromArgb(203, 213, 225), 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void ApplyRoundedRegion(Control control, int radius)
        {
            if (control.Width <= 0 || control.Height <= 0)
            {
                return;
            }

            using var path = GetRoundedPath(new Rectangle(0, 0, control.Width, control.Height), radius);
            control.Region = new Region(path);
        }

        private void DrawInputBoxBorder(Graphics g, Panel panel, bool isFocused)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color borderColor = isFocused ? Color.FromArgb(37, 99, 235) : Color.FromArgb(226, 232, 240);
            int penWidth = isFocused ? 2 : 1;

            using (var path = GetRoundedPath(new Rectangle(1, 1, panel.Width - 3, panel.Height - 3), 9))
            using (var pen = new Pen(borderColor, penWidth))
            {
                g.DrawPath(pen, path);
            }
        }

        private void SetupDemoButtonHover(Button btn, Color normalBg, Color hoverBg)
        {
            btn.MouseEnter += (s, e) => btn.BackColor = hoverBg;
            btn.MouseLeave += (s, e) => btn.BackColor = normalBg;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "123456";
            txtUsername.Focus();
            UpdateDbStatus();
        }

        private void UpdateDbStatus()
        {
            try
            {
                var test = DbConnectionFactory.TestConnection();
                if (test.Success)
                {
                    string srv = DbConnectionFactory.GetServerFromConnectionString(DbConnectionFactory.ConnectionString);
                    lblDbStatus.Text = $"● CSDL: Sẵn sàng ({srv})";
                    lblDbStatus.ForeColor = Color.FromArgb(22, 101, 52);
                }
                else
                {
                    lblDbStatus.Text = "● CSDL: Chưa kết nối";
                    lblDbStatus.ForeColor = Color.FromArgb(220, 38, 38);
                }
            }
            catch
            {
                lblDbStatus.Text = "● CSDL: Chưa kết nối";
                lblDbStatus.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        private void btnDbConfig_Click(object? sender, EventArgs e)
        {
            using var frm = new FrmDbConfig();
            frm.ShowDialog(this);
            UpdateDbStatus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                UiHelper.ShowWarning("Vui lòng nhập tên đăng nhập hoặc mã tài khoản.");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                UiHelper.ShowWarning("Vui lòng nhập mật khẩu đăng nhập.");
                txtPassword.Focus();
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Đang xác thực...";
                Application.DoEvents();

                var user = _authBll.Login(username, password);
                LoggedInUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException ex)
            {
                UiHelper.ShowWarning(ex.Message, "Thông báo");
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
            catch (InvalidOperationException ex)
            {
                UiHelper.ShowError(ex.Message, "Tài khoản bị khóa");
            }
            catch (SqlException ex)
            {
                UpdateDbStatus();

                string msg = (ex.Number == 4060)
                    ? "Cơ sở dữ liệu 'QuanLySinhVienDB' chưa được khởi tạo trên máy chủ SQL Server này.\n\nBạn có muốn hệ thống TỰ ĐỘNG KHỞI TẠO CSDL và nạp dữ liệu mẫu ban đầu ngay bây giờ không?"
                    : $"Lỗi kết nối cơ sở dữ liệu SQL Server: {ex.Message}\n\nBạn có muốn hệ thống TỰ ĐỘNG TÌM KIẾM MÁY CHỦ và KHỞI TẠO CSDL không?";

                var dlg = MessageBox.Show(msg, "Tự động sửa lỗi CSDL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    try
                    {
                        btnLogin.Text = "Đang khởi tạo CSDL...";
                        Application.DoEvents();

                        var fixRes = DbConnectionFactory.AutoDetectAndFixConnection();
                        if (fixRes.Success)
                        {
                            UpdateDbStatus();
                            UiHelper.ShowInfo("Đã khởi tạo cơ sở dữ liệu QuanLySinhVienDB thành công!\nHệ thống sẽ tiến hành đăng nhập lại.");
                            btnLogin.Text = "ĐĂNG NHẬP HỆ THỐNG  →";
                            btnLogin.PerformClick();
                            return;
                        }
                        else
                        {
                            UiHelper.ShowError(fixRes.Message, "Không thể tự động kết nối CSDL");
                            using var frm = new FrmDbConfig();
                            frm.ShowDialog(this);
                            UpdateDbStatus();
                        }
                    }
                    catch (Exception initEx)
                    {
                        UiHelper.ShowError($"Lỗi khi khởi tạo CSDL: {initEx.Message}");
                    }
                }
                else
                {
                    using var frm = new FrmDbConfig();
                    frm.ShowDialog(this);
                    UpdateDbStatus();
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Đã xảy ra lỗi không mong muốn: {ex.Message}");
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "ĐĂNG NHẬP HỆ THỐNG  →";
            }
        }

        private void btnToggleEye_Click(object sender, EventArgs e)
        {
            _isPasswordShown = !_isPasswordShown;
            txtPassword.PasswordChar = _isPasswordShown ? '\0' : '●';
            btnToggleEye.Text = _isPasswordShown ? "Ẩn" : "Hiện";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(239, 68, 68);
            btnClose.ForeColor = Color.White;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.FromArgb(100, 116, 139);
        }

        private void btnQuickAdmin_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "123456";
            btnLogin.PerformClick();
        }

        private void btnQuickTeacher_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "giangvien1";
            txtPassword.Text = "123456";
            btnLogin.PerformClick();
        }

        private void btnQuickStudent_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "sv001";
            txtPassword.Text = "123456";
            btnLogin.PerformClick();
        }

        
    }
}
