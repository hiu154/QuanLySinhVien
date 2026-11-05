using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.Forms
{
    public partial class FrmStudent : Form
    {
        private readonly StudentBLL _studentBll = new StudentBLL();
        private readonly DepartmentBLL _deptBll = new DepartmentBLL();
        private readonly ClassBLL _classBll = new ClassBLL();

        private int _selectedStudentId = 0;
        private List<StudentDTO> _currentList = new List<StudentDTO>();

        public FrmStudent()
        {
            InitializeComponent();
        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            this.BackColor = UiHelper.ContentBg;
            UiHelper.StyleFilterBar(pnlTop);
            UiHelper.StyleCard(pnlInput, UiHelper.Primary);
            UiHelper.StyleDataGridView(dgvStudents);

            lblInputHeader.Font = UiHelper.SubHeaderFont;
            lblInputHeader.ForeColor = UiHelper.PrimaryDark;
            lblTotalCount.Font = UiHelper.BoldFont;
            lblTotalCount.ForeColor = UiHelper.TextSecondary;

            lblSearch.Font = UiHelper.SmallBoldFont; lblSearch.ForeColor = UiHelper.TextSecondary;
            lblFilterDept.Font = UiHelper.SmallBoldFont; lblFilterDept.ForeColor = UiHelper.TextSecondary;
            lblFilterClass.Font = UiHelper.SmallBoldFont; lblFilterClass.ForeColor = UiHelper.TextSecondary;
            lblFilterStatus.Font = UiHelper.SmallBoldFont; lblFilterStatus.ForeColor = UiHelper.TextSecondary;

            lblCode.Font = UiHelper.SmallBoldFont; lblCode.ForeColor = UiHelper.TextSecondary;
            lblName.Font = UiHelper.SmallBoldFont; lblName.ForeColor = UiHelper.TextSecondary;
            lblDob.Font = UiHelper.SmallBoldFont; lblDob.ForeColor = UiHelper.TextSecondary;
            lblGender.Font = UiHelper.SmallBoldFont; lblGender.ForeColor = UiHelper.TextSecondary;
            lblEmail.Font = UiHelper.SmallBoldFont; lblEmail.ForeColor = UiHelper.TextSecondary;
            lblPhone.Font = UiHelper.SmallBoldFont; lblPhone.ForeColor = UiHelper.TextSecondary;
            lblAddress.Font = UiHelper.SmallBoldFont; lblAddress.ForeColor = UiHelper.TextSecondary;
            lblDept.Font = UiHelper.SmallBoldFont; lblDept.ForeColor = UiHelper.TextSecondary;
            lblClass.Font = UiHelper.SmallBoldFont; lblClass.ForeColor = UiHelper.TextSecondary;
            lblAdmission.Font = UiHelper.SmallBoldFont; lblAdmission.ForeColor = UiHelper.TextSecondary;
            lblStatus.Font = UiHelper.SmallBoldFont; lblStatus.ForeColor = UiHelper.TextSecondary;

            UiHelper.StylePrimaryButton(btnAdd);
            UiHelper.StyleWarningButton(btnUpdate);
            UiHelper.StyleDangerButton(btnDelete);
            UiHelper.StyleSecondaryButton(btnClear);
            UiHelper.StylePrimaryButton(btnSearch);
            UiHelper.StyleSecondaryButton(btnResetFilter);
            UiHelper.StyleSuccessButton(btnExportExcel);

            dgvStudents.CellFormatting += (s, ev) =>
            {
                if (ev.RowIndex >= 0 && dgvStudents.Columns[ev.ColumnIndex].DataPropertyName == "Status")
                {
                    UiHelper.FormatStatusCell(ev);
                }
            };

            InitDataGridViewColumns();
            LoadComboboxData();
            ApplyRolePermissions();
            LoadStudents();
        }

        private void ApplyRolePermissions()
        {
            var user = AuthBLL.CurrentUser;
            if (user != null && user.IsStudent)
            {
                // Sinh viên chỉ được xem thông tin
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                pnlInput.Enabled = false;
            }
            else if (user != null && user.IsTeacher)
            {
                // Giảng viên được xem danh sách, hạn chế xóa
                btnDelete.Enabled = false;
            }
        }

        private void InitDataGridViewColumns()
        {
            dgvStudents.Columns.Clear();

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StudentID",
                HeaderText = "ID",
                Visible = false
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StudentCode",
                HeaderText = "Mã SV",
                Width = 90
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Họ và tên",
                Width = 160
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gender",
                HeaderText = "Giới tính",
                Width = 90
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DateOfBirth",
                HeaderText = "Ngày sinh",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ClassName",
                HeaderText = "Lớp",
                Width = 130
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DepartmentName",
                HeaderText = "Khoa",
                Width = 150
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Width = 170
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhoneNumber",
                HeaderText = "Số ĐT",
                Width = 100
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                Width = 110
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Địa chỉ",
                Width = 140
            });
        }

        private void LoadComboboxData()
        {
            try
            {
                // Status ComboBox
                string[] statuses = new string[] { "Đang học", "Bảo lưu", "Nghỉ học", "Đã tốt nghiệp" };
                cboStatus.Items.Clear();
                cboStatus.Items.AddRange(statuses);
                cboStatus.SelectedIndex = 0;

                cboFilterStatus.Items.Clear();
                cboFilterStatus.Items.Add("Tất cả trạng thái");
                cboFilterStatus.Items.AddRange(statuses);
                cboFilterStatus.SelectedIndex = 0;

                cboGender.SelectedIndex = 0;

                // Departments
                var depts = _deptBll.GetAllDepartments();
                cboDept.DisplayMember = "DepartmentName";
                cboDept.ValueMember = "DepartmentID";
                cboDept.DataSource = new List<DepartmentDTO>(depts);

                cboFilterDept.Items.Clear();
                cboFilterDept.Items.Add(new DepartmentDTO { DepartmentID = "", DepartmentName = "Tất cả các khoa" });
                foreach (var d in depts)
                {
                    cboFilterDept.Items.Add(d);
                }
                cboFilterDept.DisplayMember = "DepartmentName";
                cboFilterDept.ValueMember = "DepartmentID";
                cboFilterDept.SelectedIndex = 0;

                // Classes
                UpdateClassCombobox();
                UpdateFilterClassCombobox();
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Không tải được danh mục Khoa/Lớp: {ex.Message}");
            }
        }

        private void UpdateClassCombobox()
        {
            if (cboDept.SelectedValue is string deptId && !string.IsNullOrWhiteSpace(deptId))
            {
                var classes = _classBll.GetClassesByDepartment(deptId);
                cboClass.DisplayMember = "ClassName";
                cboClass.ValueMember = "ClassID";
                cboClass.DataSource = classes;
            }
            else
            {
                var classes = _classBll.GetAllClasses();
                cboClass.DisplayMember = "ClassName";
                cboClass.ValueMember = "ClassID";
                cboClass.DataSource = classes;
            }
        }

        private void UpdateFilterClassCombobox()
        {
            string? deptId = null;
            if (cboFilterDept.SelectedItem is DepartmentDTO sel && !string.IsNullOrWhiteSpace(sel.DepartmentID))
            {
                deptId = sel.DepartmentID;
            }

            var classes = string.IsNullOrWhiteSpace(deptId) 
                ? _classBll.GetAllClasses() 
                : _classBll.GetClassesByDepartment(deptId);

            cboFilterClass.Items.Clear();
            cboFilterClass.Items.Add(new ClassDTO { ClassID = "", ClassName = "Tất cả lớp" });
            foreach (var c in classes)
            {
                cboFilterClass.Items.Add(c);
            }
            cboFilterClass.DisplayMember = "ClassName";
            cboFilterClass.ValueMember = "ClassID";
            cboFilterClass.SelectedIndex = 0;
        }

        private void LoadStudents()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();

                string? classId = null;
                if (cboFilterClass.SelectedItem is ClassDTO c && !string.IsNullOrWhiteSpace(c.ClassID))
                {
                    classId = c.ClassID;
                }

                string? deptId = null;
                if (cboFilterDept.SelectedItem is DepartmentDTO d && !string.IsNullOrWhiteSpace(d.DepartmentID))
                {
                    deptId = d.DepartmentID;
                }

                string? status = null;
                if (cboFilterStatus.SelectedIndex > 0)
                {
                    status = cboFilterStatus.SelectedItem?.ToString();
                }

                _currentList = _studentBll.SearchStudents(keyword, classId, deptId, status);
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = _currentList;
                dgvStudents.ClearSelection();

                lblTotalCount.Text = $"Tổng số: {_currentList.Count} sinh viên";
            }
            catch (SqlException ex)
            {
                UiHelper.ShowError($"Lỗi SQL Server: {ex.Message}");
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi tải sinh viên: {ex.Message}");
            }
        }

        private StudentDTO GetStudentFromForm()
        {
            return new StudentDTO
            {
                StudentID = _selectedStudentId,
                StudentCode = txtCode.Text.Trim(),
                FullName = txtName.Text.Trim(),
                DateOfBirth = dtpDob.Value,
                Gender = cboGender.SelectedItem?.ToString() ?? "Nam",
                Email = txtEmail.Text.Trim(),
                PhoneNumber = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                ClassID = cboClass.SelectedValue?.ToString() ?? string.Empty,
                AdmissionDate = dtpAdmission.Value,
                Status = cboStatus.SelectedItem?.ToString() ?? "Đang học"
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var s = GetStudentFromForm();
                int newId = _studentBll.AddStudent(s, AuthBLL.CurrentUser?.Username);
                UiHelper.ShowSuccess($"Thêm sinh viên '{s.FullName}' ({s.StudentCode}) thành công!");
                ClearForm();
                LoadStudents();
            }
            catch (ArgumentException ex)
            {
                UiHelper.ShowWarning(ex.Message);
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi thêm sinh viên: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId <= 0)
            {
                UiHelper.ShowWarning("Vui lòng chọn một sinh viên từ danh sách để sửa.");
                return;
            }

            try
            {
                var s = GetStudentFromForm();
                if (_studentBll.UpdateStudent(s, AuthBLL.CurrentUser?.Username))
                {
                    UiHelper.ShowSuccess($"Cập nhật sinh viên '{s.StudentCode}' thành công!");
                    ClearForm();
                    LoadStudents();
                }
                else
                {
                    UiHelper.ShowWarning("Không tìm thấy sinh viên cần cập nhật.");
                }
            }
            catch (ArgumentException ex)
            {
                UiHelper.ShowWarning(ex.Message);
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi cập nhật sinh viên: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId <= 0)
            {
                UiHelper.ShowWarning("Vui lòng chọn một sinh viên từ danh sách để xóa.");
                return;
            }

            if (!UiHelper.Confirm($"Bạn có chắc chắn muốn xóa sinh viên '{txtCode.Text} - {txtName.Text}' khỏi hệ thống?\nThao tác này không thể hoàn tác!", "Xác nhận xóa"))
            {
                return;
            }

            try
            {
                if (_studentBll.DeleteStudent(_selectedStudentId, AuthBLL.CurrentUser?.Username))
                {
                    UiHelper.ShowSuccess("Đã xóa sinh viên thành công!");
                    ClearForm();
                    LoadStudents();
                }
                else
                {
                    UiHelper.ShowWarning("Không tìm thấy sinh viên cần xóa.");
                }
            }
            catch (InvalidOperationException ex)
            {
                UiHelper.ShowWarning(ex.Message, "Ràng buộc dữ liệu");
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi khi xóa sinh viên: {ex.Message}");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedStudentId = 0;
            txtCode.ReadOnly = false;
            txtCode.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            dtpDob.Value = new DateTime(2003, 1, 1);
            dtpAdmission.Value = DateTime.Today;
            cboGender.SelectedIndex = 0;
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;
            dgvStudents.ClearSelection();
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvStudents.Rows[e.RowIndex].DataBoundItem is not StudentDTO s) return;

            _selectedStudentId = s.StudentID;
            txtCode.Text = s.StudentCode;
            txtName.Text = s.FullName;
            dtpDob.Value = s.DateOfBirth;
            cboGender.SelectedItem = s.Gender;
            txtEmail.Text = s.Email;
            txtPhone.Text = s.PhoneNumber ?? string.Empty;
            txtAddress.Text = s.Address ?? string.Empty;
            dtpAdmission.Value = s.AdmissionDate;
            cboStatus.SelectedItem = s.Status;

            // Set Department and Class
            if (!string.IsNullOrWhiteSpace(s.DepartmentID))
            {
                cboDept.SelectedValue = s.DepartmentID;
                UpdateClassCombobox();
            }
            if (!string.IsNullOrWhiteSpace(s.ClassID))
            {
                cboClass.SelectedValue = s.ClassID;
            }

            txtCode.ReadOnly = true; // Khóa mã sinh viên khi sửa để bảo đảm tính nhất quán
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadStudents();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void cboFilterDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilterClassCombobox();
            LoadStudents();
        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateClassCombobox();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterDept.SelectedIndex = 0;
            cboFilterStatus.SelectedIndex = 0;
            UpdateFilterClassCombobox();
            LoadStudents();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (_currentList == null || _currentList.Count == 0)
            {
                UiHelper.ShowWarning("Không có dữ liệu sinh viên để xuất.");
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Tập tin CSV (*.csv)|*.csv|Tất cả tập tin (*.*)|*.*",
                FileName = $"DanhSachSinhVien_{DateTime.Today:yyyyMMdd}.csv",
                Title = "Lưu danh sách sinh viên"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] headers = new string[] {
                        "Mã SV", "Họ và tên", "Giới tính", "Ngày sinh", "Lớp", "Khoa",
                        "Email", "Số ĐT", "Địa chỉ", "Ngày nhập học", "Trạng thái"
                    };

                    StatisticsBLL.ExportToCsv(
                        _currentList,
                        sfd.FileName,
                        s => new string[] {
                            s.StudentCode,
                            s.FullName,
                            s.Gender,
                            s.DateOfBirth.ToString("dd/MM/yyyy"),
                            s.ClassName ?? string.Empty,
                            s.DepartmentName ?? string.Empty,
                            s.Email,
                            s.PhoneNumber ?? string.Empty,
                            s.Address ?? string.Empty,
                            s.AdmissionDate.ToString("dd/MM/yyyy"),
                            s.Status
                        },
                        headers
                    );

                    UiHelper.ShowSuccess($"Đã xuất thành công {_currentList.Count} sinh viên ra file:\n{sfd.FileName}");
                }
                catch (Exception ex)
                {
                    UiHelper.ShowError($"Lỗi khi xuất file Excel/CSV: {ex.Message}");
                }
            }
        }
    }
}
