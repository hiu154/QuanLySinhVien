using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.Forms
{
    public partial class FrmUserAccount : Form
    {
        private readonly AuthBLL _authBll = new AuthBLL();
        private readonly StudentBLL _studentBll = new StudentBLL();

        private int _selectedUserId = 0;

        public FrmUserAccount()
        {
            InitializeComponent();
        }

        private void FrmUserAccount_Load(object sender, EventArgs e)
        {
            this.BackColor = UiHelper.ContentBg;
            UiHelper.StyleCard(pnlInput, UiHelper.Primary);
            UiHelper.StyleDataGridView(dgvUsers);

            lblHeader.Font = UiHelper.SubHeaderFont;
            lblHeader.ForeColor = UiHelper.PrimaryDark;

            lblUsername.Font = UiHelper.SmallBoldFont; lblUsername.ForeColor = UiHelper.TextSecondary;
            lblPassword.Font = UiHelper.SmallBoldFont; lblPassword.ForeColor = UiHelper.TextSecondary;
            lblFullName.Font = UiHelper.SmallBoldFont; lblFullName.ForeColor = UiHelper.TextSecondary;
            lblRole.Font = UiHelper.SmallBoldFont; lblRole.ForeColor = UiHelper.TextSecondary;
            lblEmail.Font = UiHelper.SmallBoldFont; lblEmail.ForeColor = UiHelper.TextSecondary;
            lblPhone.Font = UiHelper.SmallBoldFont; lblPhone.ForeColor = UiHelper.TextSecondary;
            lblStudentLink.Font = UiHelper.SmallBoldFont; lblStudentLink.ForeColor = UiHelper.TextSecondary;

            UiHelper.StylePrimaryButton(btnAdd);
            UiHelper.StyleWarningButton(btnUpdate);
            UiHelper.StyleDangerButton(btnDelete);
            UiHelper.StyleSecondaryButton(btnClear);
            UiHelper.StyleWarningButton(btnResetPass);

            dgvUsers.CellFormatting += (s, ev) =>
            {
                if (ev.RowIndex >= 0 && dgvUsers.Columns[ev.ColumnIndex].DataPropertyName == "Role")
                {
                    UiHelper.FormatRoleCell(ev);
                }
            };

            InitGridColumns();
            LoadStudentCombobox();
            LoadUsers();
            cboRole.SelectedIndex = 1; // Default Teacher
        }

        private void InitGridColumns()
        {
            dgvUsers.Columns.Clear();
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UserID", HeaderText = "ID", Width = 50 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Tên đăng nhập", Width = 130 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Họ và tên", Width = 180 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Role", HeaderText = "Vai trò", Width = 100 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentCode", HeaderText = "Mã SV", Width = 90 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Width = 170 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PhoneNumber", HeaderText = "Số ĐT", Width = 110 });
            dgvUsers.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "IsActive", HeaderText = "Hoạt động?", Width = 90 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LastLogin", HeaderText = "Đăng nhập gần nhất", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CreatedAt", HeaderText = "Ngày tạo", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
        }

        private void LoadStudentCombobox()
        {
            try
            {
                var students = _studentBll.GetAllStudents();
                cboStudentLink.Items.Clear();
                cboStudentLink.Items.Add(new StudentDTO { StudentID = 0, StudentCode = "", FullName = "-- Không liên kết sinh viên --" });
                foreach (var s in students)
                {
                    cboStudentLink.Items.Add(s);
                }
                cboStudentLink.DisplayMember = "DisplayText";
                cboStudentLink.ValueMember = "StudentID";
                cboStudentLink.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi nạp danh sách sinh viên: {ex.Message}");
            }
        }

        private void LoadUsers()
        {
            try
            {
                var users = _authBll.GetAllUsers();
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = users;
                dgvUsers.ClearSelection();
                ClearForm();
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi tải danh sách tài khoản: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                UiHelper.ShowWarning("Vui lòng nhập tên đăng nhập.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                UiHelper.ShowWarning("Mật khẩu phải từ 6 ký tự trở lên.");
                return;
            }

            try
            {
                int? studentId = null;
                if (cboStudentLink.SelectedItem is StudentDTO sel && sel.StudentID > 0)
                {
                    studentId = sel.StudentID;
                }

                var u = new UserDTO
                {
                    Username = username,
                    FullName = txtFullName.Text.Trim(),
                    Role = cboRole.SelectedItem?.ToString() ?? "Student",
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    PhoneNumber = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                    StudentID = studentId,
                    IsActive = chkActive.Checked
                };

                _authBll.AddUser(u, password, AuthBLL.CurrentUser?.Username);
                UiHelper.ShowSuccess($"Tạo tài khoản '{u.Username}' thành công!");
                LoadUsers();
            }
            catch (ArgumentException ex) { UiHelper.ShowWarning(ex.Message); }
            catch (Exception ex) { UiHelper.ShowError($"Lỗi tạo tài khoản: {ex.Message}"); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedUserId <= 0)
            {
                UiHelper.ShowWarning("Vui lòng chọn tài khoản cần sửa từ danh sách.");
                return;
            }

            try
            {
                int? studentId = null;
                if (cboStudentLink.SelectedItem is StudentDTO sel && sel.StudentID > 0)
                {
                    studentId = sel.StudentID;
                }

                var u = new UserDTO
                {
                    UserID = _selectedUserId,
                    Username = txtUsername.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Role = cboRole.SelectedItem?.ToString() ?? "Student",
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    PhoneNumber = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                    StudentID = studentId,
                    IsActive = chkActive.Checked
                };

                if (_authBll.UpdateUser(u, AuthBLL.CurrentUser?.Username))
                {
                    UiHelper.ShowSuccess($"Cập nhật tài khoản '{u.Username}' thành công!");
                    LoadUsers();
                }
            }
            catch (ArgumentException ex) { UiHelper.ShowWarning(ex.Message); }
            catch (Exception ex) { UiHelper.ShowError($"Lỗi cập nhật tài khoản: {ex.Message}"); }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (_selectedUserId <= 0)
            {
                UiHelper.ShowWarning("Vui lòng chọn tài khoản cần đặt lại mật khẩu.");
                return;
            }

            if (!UiHelper.Confirm($"Bạn có chắc muốn đặt lại mật khẩu của tài khoản '{txtUsername.Text}' về mật khẩu mặc định '123456'?", "Xác nhận đặt lại mật khẩu"))
            {
                return;
            }

            try
            {
                if (_authBll.ResetPassword(_selectedUserId, "123456", AuthBLL.CurrentUser?.Username))
                {
                    UiHelper.ShowSuccess($"Đã đặt lại mật khẩu của '{txtUsername.Text}' về: 123456");
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi đặt lại mật khẩu: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUserId <= 0)
            {
                UiHelper.ShowWarning("Vui lòng chọn tài khoản cần xóa.");
                return;
            }

            if (!UiHelper.Confirm($"Bạn có chắc chắn muốn xóa tài khoản '{txtUsername.Text}'?", "Xác nhận xóa tài khoản"))
            {
                return;
            }

            try
            {
                if (_authBll.DeleteUser(_selectedUserId, AuthBLL.CurrentUser?.Username))
                {
                    UiHelper.ShowSuccess("Đã xóa tài khoản thành công!");
                    LoadUsers();
                }
            }
            catch (InvalidOperationException ex) { UiHelper.ShowWarning(ex.Message); }
            catch (Exception ex) { UiHelper.ShowError($"Lỗi xóa tài khoản: {ex.Message}"); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedUserId = 0;
            txtUsername.ReadOnly = false;
            txtUsername.Clear();
            txtPassword.Clear();
            txtPassword.Enabled = true;
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            cboRole.SelectedIndex = 1;
            cboStudentLink.SelectedIndex = 0;
            chkActive.Checked = true;
            dgvUsers.ClearSelection();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvUsers.Rows[e.RowIndex].DataBoundItem is not UserDTO u) return;

            _selectedUserId = u.UserID;
            txtUsername.Text = u.Username;
            txtUsername.ReadOnly = true; // Khóa username khi cập nhật
            txtPassword.Clear();
            txtPassword.Enabled = false; // Mật khẩu đổi qua nút reset mật khẩu
            txtFullName.Text = u.FullName;
            cboRole.SelectedItem = u.Role;
            txtEmail.Text = u.Email ?? string.Empty;
            txtPhone.Text = u.PhoneNumber ?? string.Empty;
            chkActive.Checked = u.IsActive;

            // Student Link
            if (u.StudentID.HasValue && u.StudentID.Value > 0)
            {
                for (int i = 0; i < cboStudentLink.Items.Count; i++)
                {
                    if (cboStudentLink.Items[i] is StudentDTO s && s.StudentID == u.StudentID.Value)
                    {
                        cboStudentLink.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                cboStudentLink.SelectedIndex = 0;
            }
        }
    }
}
