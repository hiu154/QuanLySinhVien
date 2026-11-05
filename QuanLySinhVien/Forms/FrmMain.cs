using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.Forms
{
    public partial class FrmMain : Form
    {
        private Form? _currentChildForm;
        private Button? _currentActiveButton;

        public FrmMain()
        {
            InitializeComponent();
            SetupCustomDrawing();
        }

        private void SetupCustomDrawing()
        {
            // Tùy biến vẽ Avatar và Thông tin người dùng trên thanh Sidebar
            pnlUserBanner.Paint += PnlUserBanner_Paint;

            // Đường phân cách dưới Top Header
            pnlTopHeader.Paint += (s, e) =>
            {
                using (var pen = new Pen(UiHelper.BorderColor, 1))
                {
                    e.Graphics.DrawLine(pen, 0, pnlTopHeader.Height - 1, pnlTopHeader.Width, pnlTopHeader.Height - 1);
                }
            };
        }

        private void PnlUserBanner_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var user = AuthBLL.CurrentUser;
            string fullName = user?.FullName ?? "Chưa đăng nhập";
            string role = user?.Role ?? "Guest";

            // 1. Vẽ Avatar tròn có chữ viết tắt của người dùng
            Color avatarColor = role switch
            {
                "Admin" => Color.FromArgb(79, 70, 229),      // Indigo
                "Teacher" => Color.FromArgb(2, 132, 199),    // Sky
                "Student" => Color.FromArgb(5, 150, 105),    // Emerald
                _ => UiHelper.Primary
            };

            var avatarRect = new Rectangle(16, 15, 42, 42);
            UiHelper.DrawAvatar(g, avatarRect, fullName, avatarColor);

            // 2. Tên đầy đủ
            using (var nameFont = new Font("Segoe UI", 9.5F, FontStyle.Bold))
            using (var whiteBrush = new SolidBrush(Color.White))
            {
                var nameRect = new Rectangle(66, 15, 160, 20);
                var sf = new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap };
                g.DrawString(fullName, nameFont, whiteBrush, nameRect, sf);
            }

            // 3. Huy hiệu vai trò (Role Pill Badge)
            string roleLabel = role switch
            {
                "Admin" => "👑 Quản trị viên",
                "Teacher" => "👨‍🏫 Giảng viên",
                "Student" => "👨‍🎓 Sinh viên",
                _ => role
            };

            using (var roleFont = new Font("Segoe UI", 8F, FontStyle.Bold))
            using (var roleBrush = new SolidBrush(Color.FromArgb(56, 189, 248)))
            {
                g.DrawString(roleLabel, roleFont, roleBrush, 66, 38);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            SetupSidebarButtons();
            UpdateUserInfo();
            ApplyRolePermissions();
            timerClock_Tick(this, EventArgs.Empty);

            // Mặc định mở Bàn làm việc (Dashboard / Thống kê)
            // Đang xây dựng dashboard tổng quan
        }

        private void SetupSidebarButtons()
        {
            Button[] navButtons = { btnDashboard, btnStudents, btnClasses, btnSubjects, btnGrades, btnStatistics, btnUsers, btnLogs, btnChangePass, btnLogout };
            foreach (var btn in navButtons)
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = UiHelper.SidebarText;
                btn.Font = UiHelper.RegularFont;
                btn.Cursor = Cursors.Hand;
                btn.Padding = new Padding(18, 0, 0, 0);

                btn.MouseEnter += (s, e) =>
                {
                    if (btn != _currentActiveButton && btn != btnLogout)
                    {
                        btn.BackColor = UiHelper.SidebarHover;
                        btn.ForeColor = Color.White;
                    }
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn != _currentActiveButton && btn != btnLogout)
                    {
                        btn.BackColor = Color.Transparent;
                        btn.ForeColor = UiHelper.SidebarText;
                    }
                };
            }
        }

        private void UpdateUserInfo()
        {
            var user = AuthBLL.CurrentUser;
            if (user != null)
            {
                lblUserName.Visible = false; // Đã vẽ trực tiếp đẹp mắt trong PnlUserBanner_Paint
                lblUserRole.Visible = false;

                lblStatusUser.Text = $"Người dùng: {user.Username} ({user.FullName})";
                lblStatusRole.Text = $"|  Vai trò: {user.Role}";
                pnlUserBanner.Invalidate();
            }
        }

        private void ApplyRolePermissions()
        {
            var user = AuthBLL.CurrentUser;
            if (user == null) return;

            if (user.IsTeacher)
            {
                btnUsers.Visible = false;
                btnLogs.Visible = false;
            }
            else if (user.IsStudent)
            {
                btnClasses.Visible = false;
                btnSubjects.Visible = false;
                btnUsers.Visible = false;
                btnLogs.Visible = false;
            }
        }

        private void OpenChildForm(Form childForm, Button activeButton, string title)
        {
            if (_currentChildForm != null)
            {
                _currentChildForm.Close();
                _currentChildForm.Dispose();
            }

            _currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(childForm);
            pnlContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            lblPageTitle.Text = title;
            HighlightButton(activeButton);
        }

        private void HighlightButton(Button btn)
        {
            if (_currentActiveButton != null)
            {
                _currentActiveButton.BackColor = Color.Transparent;
                _currentActiveButton.ForeColor = UiHelper.SidebarText;
                _currentActiveButton.Font = UiHelper.RegularFont;
                _currentActiveButton.Paint -= ActiveButton_Paint;
                _currentActiveButton.Invalidate();
            }

            _currentActiveButton = btn;
            btn.BackColor = Color.FromArgb(30, 41, 59);
            btn.ForeColor = Color.White;
            btn.Font = UiHelper.BoldFont;
            btn.Paint += ActiveButton_Paint;
            btn.Invalidate();
        }

        private void ActiveButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn && btn == _currentActiveButton)
            {
                using (var brush = new SolidBrush(UiHelper.Primary))
                {
                    // Dải màu nhấn 4px Royal Blue ở mép trái nút đang chọn
                    e.Graphics.FillRectangle(brush, 0, 0, 4, btn.Height);
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Đang xây dựng dashboard tổng quan
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý Sinh viên đang được xây dựng...", "Thông báo");
        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Khoa & Lớp học đang được xây dựng...", "Thông báo");
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Môn học đang được xây dựng...", "Thông báo");
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmGrade(), btnGrades, "📝 Quản lý Điểm & Kết quả học tập");
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Thống kê đang được xây dựng...", "Thông báo");
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Quản lý Tài khoản đang được xây dựng...", "Thông báo");
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSystemLogs(), btnLogs, "📜 Nhật ký Hệ thống (Chương 8 - Logging)");
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            using var frm = new FrmChangePassword();
            frm.ShowDialog(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (UiHelper.Confirm("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?", "Xác nhận đăng xuất"))
            {
                AuthBLL.Logout();
                this.Hide();

                using var login = new FrmLogin();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    UpdateUserInfo();
                    ApplyRolePermissions();
                    this.Show();
                    btnDashboard.PerformClick();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = "🕒 " + DateTime.Now.ToString("dddd, dd/MM/yyyy • HH:mm:ss");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!UiHelper.Confirm("Bạn có chắc chắn muốn thoát khỏi ứng dụng Quản lý Sinh viên?", "Xác nhận thoát"))
                {
                    e.Cancel = true;
                }
                else
                {
                    AuthBLL.Logout();
                }
            }
        }
    }
}
