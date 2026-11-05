using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.Forms
{
    public partial class FrmClassDepartment : Form
    {
        private readonly DepartmentBLL _deptBll = new DepartmentBLL();
        private readonly ClassBLL _classBll = new ClassBLL();
        private readonly StudentBLL _studentBll = new StudentBLL();

        private string _selectedClassId = string.Empty;
        private string _selectedDeptId = string.Empty;

        public FrmClassDepartment()
        {
            InitializeComponent();
        }

        private void FrmClassDepartment_Load(object sender, EventArgs e)
        {
            this.BackColor = UiHelper.ContentBg;
            UiHelper.StyleTabControl(tabControl);
            UiHelper.StyleCard(pnlClassInput, UiHelper.Primary);
            UiHelper.StyleCard(pnlClassStudents, UiHelper.Accent);
            UiHelper.StyleCard(pnlDeptInput, Color.FromArgb(79, 70, 229));

            UiHelper.StyleDataGridView(dgvClasses);
            UiHelper.StyleDataGridView(dgvClassStudents);
            UiHelper.StyleDataGridView(dgvDepartments);

            lblClassHeader.Font = UiHelper.SubHeaderFont;
            lblClassHeader.ForeColor = UiHelper.PrimaryDark;
            lblClassStudentsTitle.Font = UiHelper.SubHeaderFont;
            lblClassStudentsTitle.ForeColor = UiHelper.TextPrimary;
            lblDeptHeader.Font = UiHelper.SubHeaderFont;
            lblDeptHeader.ForeColor = Color.FromArgb(79, 70, 229);

            lblClassID.Font = UiHelper.SmallBoldFont; lblClassID.ForeColor = UiHelper.TextSecondary;
            lblClassName.Font = UiHelper.SmallBoldFont; lblClassName.ForeColor = UiHelper.TextSecondary;
            lblClassDept.Font = UiHelper.SmallBoldFont; lblClassDept.ForeColor = UiHelper.TextSecondary;
            lblAcademicYear.Font = UiHelper.SmallBoldFont; lblAcademicYear.ForeColor = UiHelper.TextSecondary;
            lblHeadTeacher.Font = UiHelper.SmallBoldFont; lblHeadTeacher.ForeColor = UiHelper.TextSecondary;
            lblMoveTo.Font = UiHelper.SmallBoldFont; lblMoveTo.ForeColor = UiHelper.TextSecondary;

            lblDeptID.Font = UiHelper.SmallBoldFont; lblDeptID.ForeColor = UiHelper.TextSecondary;
            lblDeptName.Font = UiHelper.SmallBoldFont; lblDeptName.ForeColor = UiHelper.TextSecondary;
            lblDeptDesc.Font = UiHelper.SmallBoldFont; lblDeptDesc.ForeColor = UiHelper.TextSecondary;

            UiHelper.StylePrimaryButton(btnAddClass);
            UiHelper.StyleWarningButton(btnUpdateClass);
            UiHelper.StyleDangerButton(btnDeleteClass);
            UiHelper.StyleSecondaryButton(btnClearClass);

            UiHelper.StylePrimaryButton(btnAddDept);
            UiHelper.StyleWarningButton(btnUpdateDept);
            UiHelper.StyleDangerButton(btnDeleteDept);
            UiHelper.StyleSecondaryButton(btnClearDept);

            UiHelper.StylePrimaryButton(btnMoveStudent);

            dgvClassStudents.CellFormatting += (s, ev) =>
            {
                if (ev.RowIndex >= 0 && dgvClassStudents.Columns[ev.ColumnIndex].DataPropertyName == "Status")
                {
                    UiHelper.FormatStatusCell(ev);
                }
            };

            InitGridColumns();
            LoadDepartments();
            LoadClasses();
            ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {
            var user = AuthBLL.CurrentUser;
            if (user != null && (user.IsStudent || user.IsTeacher))
            {
                btnAddClass.Enabled = false;
                btnUpdateClass.Enabled = false;
                btnDeleteClass.Enabled = false;
                btnMoveStudent.Enabled = false;

                btnAddDept.Enabled = false;
                btnUpdateDept.Enabled = false;
                btnDeleteDept.Enabled = false;
            }
        }

        private void InitGridColumns()
        {
            // 1. Classes Grid
            dgvClasses.Columns.Clear();
            dgvClasses.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClassID", HeaderText = "Mã lớp", Width = 90 });
            dgvClasses.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClassName", HeaderText = "Tên lớp", Width = 180 });
            dgvClasses.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DepartmentName", HeaderText = "Khoa", Width = 160 });
            dgvClasses.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AcademicYear", HeaderText = "Niên khóa", Width = 110 });
            dgvClasses.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HeadTeacher", HeaderText = "GV Chủ nhiệm", Width = 160 });
            dgvClasses.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalStudents", HeaderText = "Số SV", Width = 75 });

            // 2. Class Students Grid
            dgvClassStudents.Columns.Clear();
            dgvClassStudents.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentID", HeaderText = "ID", Visible = false });
            dgvClassStudents.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentCode", HeaderText = "Mã SV", Width = 90 });
            dgvClassStudents.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Họ và tên", Width = 160 });
            dgvClassStudents.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Gender", HeaderText = "Giới tính", Width = 80 });
            dgvClassStudents.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DateOfBirth", HeaderText = "Ngày sinh", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvClassStudents.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Width = 160 });
            dgvClassStudents.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng thái", Width = 100 });

            // 3. Departments Grid
            dgvDepartments.Columns.Clear();
            dgvDepartments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DepartmentID", HeaderText = "Mã khoa", Width = 100 });
            dgvDepartments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DepartmentName", HeaderText = "Tên khoa", Width = 220 });
            dgvDepartments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Description", HeaderText = "Mô tả", Width = 250 });
            dgvDepartments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalClasses", HeaderText = "Số lớp", Width = 80 });
            dgvDepartments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalStudents", HeaderText = "Số SV", Width = 80 });
        }

        #region Xử lý Lớp học (Classes)
        private void LoadClasses()
        {
            try
            {
                var list = _classBll.GetAllClasses();
                dgvClasses.DataSource = null;
                dgvClasses.DataSource = list;
                dgvClasses.ClearSelection();

                // Nạp combobox chuyển lớp
                cboMoveTargetClass.DisplayMember = "ClassName";
                cboMoveTargetClass.ValueMember = "ClassID";
                cboMoveTargetClass.DataSource = new List<ClassDTO>(list);

                ClearClassForm();
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi tải danh sách lớp học: {ex.Message}");
            }
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            try
            {
                var c = new ClassDTO
                {
                    ClassID = txtClassID.Text.Trim(),
                    ClassName = txtClassName.Text.Trim(),
                    DepartmentID = cboClassDept.SelectedValue?.ToString() ?? string.Empty,
                    AcademicYear = string.IsNullOrWhiteSpace(txtAcademicYear.Text) ? null : txtAcademicYear.Text.Trim(),
                    HeadTeacher = string.IsNullOrWhiteSpace(txtHeadTeacher.Text) ? null : txtHeadTeacher.Text.Trim()
                };

                _classBll.AddClass(c, AuthBLL.CurrentUser?.Username);
                UiHelper.ShowSuccess($"Thêm lớp '{c.ClassName}' thành công!");
                LoadClasses();
                LoadDepartments(); // Cập nhật lại số lượng lớp trong bảng khoa
            }
            catch (ArgumentException ex) { UiHelper.ShowWarning(ex.Message); }
            catch (Exception ex) { UiHelper.ShowError($"Lỗi thêm lớp: {ex.Message}"); }
        }

        private void btnUpdateClass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedClassId))
            {
                UiHelper.ShowWarning("Vui lòng chọn lớp học cần sửa từ danh sách.");
                return;
            }

            try
            {
                var c = new ClassDTO
                {
                    ClassID = _selectedClassId,
                    ClassName = txtClassName.Text.Trim(),
                    DepartmentID = cboClassDept.SelectedValue?.ToString() ?? string.Empty,
                    AcademicYear = string.IsNullOrWhiteSpace(txtAcademicYear.Text) ? null : txtAcademicYear.Text.Trim(),
                    HeadTeacher = string.IsNullOrWhiteSpace(txtHeadTeacher.Text) ? null : txtHeadTeacher.Text.Trim()
                };

                if (_classBll.UpdateClass(c, AuthBLL.CurrentUser?.Username))
                {
                    UiHelper.ShowSuccess($"Cập nhật lớp '{c.ClassID}' thành công!");
                    LoadClasses();
                }
                else
                {
                    UiHelper.ShowWarning("Không tìm thấy lớp học cần cập nhật.");
                }
            }
            catch (ArgumentException ex) { UiHelper.ShowWarning(ex.Message); }
            catch (Exception ex) { UiHelper.ShowError($"Lỗi cập nhật lớp: {ex.Message}"); }
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedClassId))
            {
                UiHelper.ShowWarning("Vui lòng chọn lớp học cần xóa.");
                return;
            }

            if (!UiHelper.Confirm($"Bạn có chắc chắn muốn xóa lớp '{_selectedClassId}'?\nKhông thể khôi phục sau khi xóa!", "Xác nhận xóa lớp"))
            {
                return;
            }

            try
            {
                if (_classBll.DeleteClass(_selectedClassId, AuthBLL.CurrentUser?.Username))
                {
                    UiHelper.ShowSuccess($"Đã xóa lớp '{_selectedClassId}' thành công!");
                    LoadClasses();
                    LoadDepartments();
                }
                else
                {
                    UiHelper.ShowWarning("Không tìm thấy lớp học cần xóa.");
                }
            }
            catch (InvalidOperationException ex)
            {
                UiHelper.ShowWarning(ex.Message, "Ràng buộc toàn vẹn dữ liệu");
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi xóa lớp học: {ex.Message}");
            }
        }

        private void btnClearClass_Click(object sender, EventArgs e)
        {
            ClearClassForm();
        }

        private void ClearClassForm()
        {
            _selectedClassId = string.Empty;
            txtClassID.ReadOnly = false;
            txtClassID.Clear();
            txtClassName.Clear();
            txtAcademicYear.Clear();
            txtHeadTeacher.Clear();
            dgvClasses.ClearSelection();
            dgvClassStudents.DataSource = null;
            lblClassStudentsTitle.Text = "Danh sách sinh viên thuộc lớp đang chọn";
        }

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvClasses.Rows[e.RowIndex].DataBoundItem is not ClassDTO c) return;

            _selectedClassId = c.ClassID;
            txtClassID.Text = c.ClassID;
            txtClassName.Text = c.ClassName;
            cboClassDept.SelectedValue = c.DepartmentID;
            txtAcademicYear.Text = c.AcademicYear ?? string.Empty;
            txtHeadTeacher.Text = c.HeadTeacher ?? string.Empty;
            txtClassID.ReadOnly = true;

            // Load students in this class
            LoadStudentsInClass(c.ClassID, c.ClassName);
        }

        private void LoadStudentsInClass(string classId, string className)
        {
            try
            {
                var students = _studentBll.SearchStudents(keyword: null, classId: classId);
                dgvClassStudents.DataSource = null;
                dgvClassStudents.DataSource = students;
                lblClassStudentsTitle.Text = $"Danh sách sinh viên lớp '{className}' ({students.Count} SV)";
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi tải sinh viên thuộc lớp: {ex.Message}");
            }
        }

        private void btnMoveStudent_Click(object sender, EventArgs e)
        {
            if (dgvClassStudents.CurrentRow?.DataBoundItem is not StudentDTO selStudent)
            {
                UiHelper.ShowWarning("Vui lòng chọn sinh viên cần chuyển lớp từ bảng danh sách bên dưới.");
                return;
            }

            if (cboMoveTargetClass.SelectedValue is not string targetClassId || string.IsNullOrWhiteSpace(targetClassId))
            {
                UiHelper.ShowWarning("Vui lòng chọn lớp học đích cần chuyển sang.");
                return;
            }

            if (targetClassId == selStudent.ClassID)
            {
                UiHelper.ShowWarning("Sinh viên đã đang ở lớp này rồi.");
                return;
            }

            if (!UiHelper.Confirm($"Chuyển sinh viên '{selStudent.FullName}' ({selStudent.StudentCode}) sang lớp '{targetClassId}'?", "Xác nhận chuyển lớp"))
            {
                return;
            }

            try
            {
                if (_studentBll.ChangeClass(selStudent.StudentID, targetClassId, AuthBLL.CurrentUser?.Username))
                {
                    UiHelper.ShowSuccess("Chuyển lớp cho sinh viên thành công!");
                    LoadClasses();
                    if (!string.IsNullOrWhiteSpace(_selectedClassId))
                    {
                        LoadStudentsInClass(_selectedClassId, txtClassName.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi chuyển lớp: {ex.Message}");
            }
        }
        #endregion

        #region Xử lý Khoa (Departments)
        private void LoadDepartments()
        {
            try
            {
                var depts = _deptBll.GetAllDepartments();
                dgvDepartments.DataSource = null;
                dgvDepartments.DataSource = depts;
                dgvDepartments.ClearSelection();

                // Cập nhật combobox Khoa bên tab lớp học
                cboClassDept.DisplayMember = "DepartmentName";
                cboClassDept.ValueMember = "DepartmentID";
                cboClassDept.DataSource = new List<DepartmentDTO>(depts);

                ClearDeptForm();
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi tải danh sách khoa: {ex.Message}");
            }
        }

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            try
            {
                var d = new DepartmentDTO
                {
                    DepartmentID = txtDeptID.Text.Trim(),
                    DepartmentName = txtDeptName.Text.Trim(),
                    Description = string.IsNullOrWhiteSpace(txtDeptDesc.Text) ? null : txtDeptDesc.Text.Trim()
                };

                _deptBll.AddDepartment(d, AuthBLL.CurrentUser?.Username);
                UiHelper.ShowSuccess($"Thêm khoa '{d.DepartmentName}' thành công!");
                LoadDepartments();
            }
            catch (ArgumentException ex) { UiHelper.ShowWarning(ex.Message); }
            catch (Exception ex) { UiHelper.ShowError($"Lỗi thêm khoa: {ex.Message}"); }
        }

        private void btnUpdateDept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedDeptId))
            {
                UiHelper.ShowWarning("Vui lòng chọn khoa cần sửa từ danh sách.");
                return;
            }

            try
            {
                var d = new DepartmentDTO
                {
                    DepartmentID = _selectedDeptId,
                    DepartmentName = txtDeptName.Text.Trim(),
                    Description = string.IsNullOrWhiteSpace(txtDeptDesc.Text) ? null : txtDeptDesc.Text.Trim()
                };

                if (_deptBll.UpdateDepartment(d, AuthBLL.CurrentUser?.Username))
                {
                    UiHelper.ShowSuccess($"Cập nhật khoa '{d.DepartmentID}' thành công!");
                    LoadDepartments();
                }
                else
                {
                    UiHelper.ShowWarning("Không tìm thấy khoa cần cập nhật.");
                }
            }
            catch (ArgumentException ex) { UiHelper.ShowWarning(ex.Message); }
            catch (Exception ex) { UiHelper.ShowError($"Lỗi cập nhật khoa: {ex.Message}"); }
        }

        private void btnDeleteDept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedDeptId))
            {
                UiHelper.ShowWarning("Vui lòng chọn khoa cần xóa.");
                return;
            }

            if (!UiHelper.Confirm($"Bạn có chắc chắn muốn xóa khoa '{_selectedDeptId}'?\nKhông thể hoàn tác!", "Xác nhận xóa khoa"))
            {
                return;
            }

            try
            {
                if (_deptBll.DeleteDepartment(_selectedDeptId, AuthBLL.CurrentUser?.Username))
                {
                    UiHelper.ShowSuccess($"Đã xóa khoa '{_selectedDeptId}' thành công!");
                    LoadDepartments();
                }
                else
                {
                    UiHelper.ShowWarning("Không tìm thấy khoa cần xóa.");
                }
            }
            catch (InvalidOperationException ex)
            {
                UiHelper.ShowWarning(ex.Message, "Ràng buộc toàn vẹn dữ liệu");
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi xóa khoa: {ex.Message}");
            }
        }

        private void btnClearDept_Click(object sender, EventArgs e)
        {
            ClearDeptForm();
        }

        private void ClearDeptForm()
        {
            _selectedDeptId = string.Empty;
            txtDeptID.ReadOnly = false;
            txtDeptID.Clear();
            txtDeptName.Clear();
            txtDeptDesc.Clear();
            dgvDepartments.ClearSelection();
        }

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvDepartments.Rows[e.RowIndex].DataBoundItem is not DepartmentDTO d) return;

            _selectedDeptId = d.DepartmentID;
            txtDeptID.Text = d.DepartmentID;
            txtDeptName.Text = d.DepartmentName;
            txtDeptDesc.Text = d.Description ?? string.Empty;
            txtDeptID.ReadOnly = true;
        }
        #endregion
    }
}
