using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DTO;
namespace QuanLySinhVien.Forms
{

    public partial class FrmSubject : Form
    {

        private readonly SubjectBLL _subjectBll = new SubjectBLL();

        private readonly SemesterBLL _semesterBll = new SemesterBLL();

        private readonly EnrollmentBLL _enrollBll = new EnrollmentBLL();

        private readonly StudentBLL _studentBll = new StudentBLL();

        private int _selectedSubjectId = 0;

        private string _selectedSemesterId = string.Empty;

        public FrmSubject()
        {

            InitializeComponent();
        }

        private void FrmSubject_Load(object sender, EventArgs e)
        {

            this.BackColor = UiHelper.ContentBg;
            UiHelper.StyleTabControl(tabControl);
            UiHelper.StyleCard(pnlSubjectInput, UiHelper.Primary);
            UiHelper.StyleCard(pnlSemesterInput, Color.FromArgb(79, 70, 229));
            UiHelper.StyleCard(pnlEnrollTop, Color.FromArgb(5, 150, 105));
            UiHelper.StyleDataGridView(dgvSubjects);
            UiHelper.StyleDataGridView(dgvSemesters);
            UiHelper.StyleDataGridView(dgvEnrollments);
            lblSubjectHeader.Font = UiHelper.SubHeaderFont;
            lblSubjectHeader.ForeColor = UiHelper.PrimaryDark;
            lblSemesterHeader.Font = UiHelper.SubHeaderFont;
            lblSemesterHeader.ForeColor = Color.FromArgb(79, 70, 229);
            lblSubjectCode.Font = UiHelper.SmallBoldFont; lblSubjectCode.ForeColor = UiHelper.TextSecondary;
            lblSubjectName.Font = UiHelper.SmallBoldFont; lblSubjectName.ForeColor = UiHelper.TextSecondary;
            lblCredits.Font = UiHelper.SmallBoldFont; lblCredits.ForeColor = UiHelper.TextSecondary;
            lblMidtermWeight.Font = UiHelper.SmallBoldFont; lblMidtermWeight.ForeColor = UiHelper.TextSecondary;
            lblFinalWeight.Font = UiHelper.SmallBoldFont; lblFinalWeight.ForeColor = UiHelper.TextSecondary;
            lblSubjectDesc.Font = UiHelper.SmallBoldFont; lblSubjectDesc.ForeColor = UiHelper.TextSecondary;
            lblSemesterID.Font = UiHelper.SmallBoldFont; lblSemesterID.ForeColor = UiHelper.TextSecondary;
            lblSemesterName.Font = UiHelper.SmallBoldFont; lblSemesterName.ForeColor = UiHelper.TextSecondary;
            lblSchoolYear.Font = UiHelper.SmallBoldFont; lblSchoolYear.ForeColor = UiHelper.TextSecondary;
            lblStartDate.Font = UiHelper.SmallBoldFont; lblStartDate.ForeColor = UiHelper.TextSecondary;
            lblEndDate.Font = UiHelper.SmallBoldFont; lblEndDate.ForeColor = UiHelper.TextSecondary;
            lblEnrollSemester.Font = UiHelper.SmallBoldFont; lblEnrollSemester.ForeColor = UiHelper.TextSecondary;
            lblEnrollSubject.Font = UiHelper.SmallBoldFont; lblEnrollSubject.ForeColor = UiHelper.TextSecondary;
            lblEnrollStudent.Font = UiHelper.SmallBoldFont; lblEnrollStudent.ForeColor = UiHelper.TextSecondary;
            UiHelper.StylePrimaryButton(btnAddSubject);
            UiHelper.StyleWarningButton(btnUpdateSubject);
            UiHelper.StyleDangerButton(btnDeleteSubject);
            UiHelper.StyleSecondaryButton(btnClearSubject);
            UiHelper.StylePrimaryButton(btnAddSemester);
            UiHelper.StyleWarningButton(btnUpdateSemester);
            UiHelper.StyleSuccessButton(btnSetCurrent);
            UiHelper.StyleSecondaryButton(btnClearSemester);
            UiHelper.StylePrimaryButton(btnEnroll);
            UiHelper.StyleDangerButton(btnCancelEnroll);
            InitGridColumns();
            LoadSubjects();
            LoadSemesters();
            LoadEnrollmentComboboxes();
            LoadEnrollments();
            ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {

            var user = AuthBLL.CurrentUser;
            // Phục hồi quyền mặc định trước khi áp dụng
            btnAddSubject.Enabled = true;
            btnUpdateSubject.Enabled = true;
            btnDeleteSubject.Enabled = true;
            btnAddSemester.Enabled = true;
            btnUpdateSemester.Enabled = true;
            btnSetCurrent.Enabled = true;
            btnCancelEnroll.Enabled = true;
            if (user != null && (user.IsStudent || user.IsTeacher))
            {

                btnAddSubject.Enabled = false;
                btnUpdateSubject.Enabled = false;
                btnDeleteSubject.Enabled = false;
                btnAddSemester.Enabled = false;
                btnUpdateSemester.Enabled = false;
                btnSetCurrent.Enabled = false;
                if (user.IsStudent)
                {

                    btnCancelEnroll.Enabled = false;
                }

            }

        }

        private void InitGridColumns()
        {

            // 1. Subjects Grid
            dgvSubjects.Columns.Clear();
            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubjectID", HeaderText = "ID", Visible = false });
            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubjectCode", HeaderText = "Mã môn", Width = 95 });
            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubjectName", HeaderText = "Tên môn học", Width = 220 });
            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Credits", HeaderText = "Số TC", Width = 75 });
            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MidtermWeight", HeaderText = "TS Quá trình", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "P0" } });
            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FinalWeight", HeaderText = "TS Điểm thi", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "P0" } });
            dgvSubjects.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Description", HeaderText = "Mô tả", Width = 200 });
            // 2. Semesters Grid
            dgvSemesters.Columns.Clear();
            dgvSemesters.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SemesterID", HeaderText = "Mã học kỳ", Width = 140 });
            dgvSemesters.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SemesterName", HeaderText = "Tên học kỳ", Width = 130 });
            dgvSemesters.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SchoolYear", HeaderText = "Năm học", Width = 120 });
            dgvSemesters.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StartDate", HeaderText = "Bắt đầu", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvSemesters.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EndDate", HeaderText = "Kết thúc", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvSemesters.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "IsCurrent", HeaderText = "Hiện tại?", Width = 80 });
            // 3. Enrollments Grid
            dgvEnrollments.Columns.Clear();
            dgvEnrollments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EnrollmentID", HeaderText = "ID", Visible = false });
            dgvEnrollments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SemesterName", HeaderText = "Học kỳ", Width = 100 });
            dgvEnrollments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SchoolYear", HeaderText = "Năm học", Width = 100 });
            dgvEnrollments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubjectCode", HeaderText = "Mã môn", Width = 90 });
            dgvEnrollments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubjectName", HeaderText = "Tên môn học", Width = 200 });
            dgvEnrollments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Credits", HeaderText = "Tín chỉ", Width = 70 });
            dgvEnrollments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentCode", HeaderText = "Mã SV", Width = 90 });
            dgvEnrollments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentName", HeaderText = "Họ và tên", Width = 160 });
            dgvEnrollments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClassName", HeaderText = "Lớp", Width = 120 });
            dgvEnrollments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EnrollmentDate", HeaderText = "Ngày ĐK", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvEnrollments.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng thái", Width = 100 });
        }

        #region Môn học (Subjects)

        private void LoadSubjects()
        {

            try
            {

                var list = _subjectBll.GetAllSubjects();
                dgvSubjects.DataSource = null;
                dgvSubjects.DataSource = list;
                dgvSubjects.ClearSelection();
                // Cập nhật combobox môn bên tab Đăng ký môn
                cboEnrollSubject.DisplayMember = "DisplayText";
                cboEnrollSubject.ValueMember = "SubjectID";
                cboEnrollSubject.DataSource = new List<SubjectDTO>(list);
                ClearSubjectForm();
            }

            catch (Exception ex)
            {

                UiHelper.ShowError($"Lỗi tải danh mục môn học: {ex.Message}");
            }

        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {

            try
            {

                var s = new SubjectDTO
                {

                    SubjectCode = txtSubjectCode.Text.Trim(),
                    SubjectName = txtSubjectName.Text.Trim(),
                    Credits = (int)numCredits.Value,
                    MidtermWeight = numMidtermWeight.Value,
                    FinalWeight = numFinalWeight.Value,
                    Description = string.IsNullOrWhiteSpace(txtSubjectDesc.Text) ? null : txtSubjectDesc.Text.Trim()
                };
                _subjectBll.AddSubject(s, AuthBLL.CurrentUser?.Username);
                UiHelper.ShowSuccess($"Thêm môn học '{s.SubjectName}' thành công!");
                LoadSubjects();
            }

            catch (ArgumentException ex) { UiHelper.ShowWarning(ex.Message); }

            catch (Exception ex) { UiHelper.ShowError($"Lỗi thêm môn học: {ex.Message}"); }

        }

        private void btnUpdateSubject_Click(object sender, EventArgs e)
        {

            if (_selectedSubjectId <= 0)
            {

                UiHelper.ShowWarning("Vui lòng chọn môn học cần sửa từ danh sách.");
                return;
            }

            try
            {

                var s = new SubjectDTO
                {

                    SubjectID = _selectedSubjectId,
                    SubjectCode = txtSubjectCode.Text.Trim(),
                    SubjectName = txtSubjectName.Text.Trim(),
                    Credits = (int)numCredits.Value,
                    MidtermWeight = numMidtermWeight.Value,
                    FinalWeight = numFinalWeight.Value,
                    Description = string.IsNullOrWhiteSpace(txtSubjectDesc.Text) ? null : txtSubjectDesc.Text.Trim()
                };
                if (_subjectBll.UpdateSubject(s, AuthBLL.CurrentUser?.Username))
                {

                    UiHelper.ShowSuccess($"Cập nhật môn học '{s.SubjectCode}' thành công!");
                    LoadSubjects();
                }

            }

            catch (ArgumentException ex) { UiHelper.ShowWarning(ex.Message); }

            catch (Exception ex) { UiHelper.ShowError($"Lỗi cập nhật môn học: {ex.Message}"); }

        }

        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {

            if (_selectedSubjectId <= 0)
            {

                UiHelper.ShowWarning("Vui lòng chọn môn học cần xóa.");
                return;
            }

            if (!UiHelper.Confirm($"Bạn có chắc chắn muốn xóa môn học '{txtSubjectCode.Text}'?\nThao tác này không thể hoàn tác!", "Xác nhận xóa môn"))
            {

                return;
            }

            try
            {

                if (_subjectBll.DeleteSubject(_selectedSubjectId, AuthBLL.CurrentUser?.Username))
                {

                    UiHelper.ShowSuccess("Đã xóa môn học thành công!");
                    LoadSubjects();
                }

            }

            catch (InvalidOperationException ex) { UiHelper.ShowWarning(ex.Message, "Ràng buộc dữ liệu"); }

            catch (Exception ex) { UiHelper.ShowError($"Lỗi xóa môn học: {ex.Message}"); }

        }

        private void btnClearSubject_Click(object sender, EventArgs e)
        {

            ClearSubjectForm();
        }

        private void ClearSubjectForm()
        {

            _selectedSubjectId = 0;
            txtSubjectCode.ReadOnly = false;
            txtSubjectCode.Clear();
            txtSubjectName.Clear();
            numCredits.Value = 3;
            numMidtermWeight.Value = 0.40m;
            numFinalWeight.Value = 0.60m;
            txtSubjectDesc.Clear();
            dgvSubjects.ClearSelection();
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;
            if (dgvSubjects.Rows[e.RowIndex].DataBoundItem is not SubjectDTO s) return;
            _selectedSubjectId = s.SubjectID;
            txtSubjectCode.Text = s.SubjectCode;
            txtSubjectName.Text = s.SubjectName;
            numCredits.Value = s.Credits;
            numMidtermWeight.Value = s.MidtermWeight;
            numFinalWeight.Value = s.FinalWeight;
            txtSubjectDesc.Text = s.Description ?? string.Empty;
            txtSubjectCode.ReadOnly = true;
        }

        #endregion

        #region Học kỳ (Semesters)

        private void LoadSemesters()
        {

            try
            {

                var list = _semesterBll.GetAllSemesters();
                dgvSemesters.DataSource = null;
                dgvSemesters.DataSource = list;
                dgvSemesters.ClearSelection();
                // Cập nhật combobox học kỳ bên tab Đăng ký môn
                cboEnrollSemester.DisplayMember = "DisplayText";
                cboEnrollSemester.ValueMember = "SemesterID";
                cboEnrollSemester.DataSource = new List<SemesterDTO>(list);
                ClearSemesterForm();
            }

            catch (Exception ex)
            {

                UiHelper.ShowError($"Lỗi tải danh sách học kỳ: {ex.Message}");
            }

        }

        private void btnAddSemester_Click(object sender, EventArgs e)
        {

            try
            {

                var s = new SemesterDTO
                {

                    SemesterID = txtSemesterID.Text.Trim(),
                    SemesterName = txtSemesterName.Text.Trim(),
                    SchoolYear = txtSchoolYear.Text.Trim(),
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    IsCurrent = chkIsCurrent.Checked
                };
                _semesterBll.AddSemester(s, AuthBLL.CurrentUser?.Username);
                UiHelper.ShowSuccess($"Thêm học kỳ '{s.SemesterName}' thành công!");
                LoadSemesters();
            }

            catch (ArgumentException ex) { UiHelper.ShowWarning(ex.Message); }

            catch (Exception ex) { UiHelper.ShowError($"Lỗi thêm học kỳ: {ex.Message}"); }

        }

        private void btnUpdateSemester_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(_selectedSemesterId))
            {

                UiHelper.ShowWarning("Vui lòng chọn học kỳ cần sửa từ danh sách.");
                return;
            }

            try
            {

                var s = new SemesterDTO
                {

                    SemesterID = _selectedSemesterId,
                    SemesterName = txtSemesterName.Text.Trim(),
                    SchoolYear = txtSchoolYear.Text.Trim(),
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    IsCurrent = chkIsCurrent.Checked
                };
                if (_semesterBll.UpdateSemester(s, AuthBLL.CurrentUser?.Username))
                {

                    UiHelper.ShowSuccess($"Cập nhật học kỳ '{s.SemesterID}' thành công!");
                    LoadSemesters();
                }

            }

            catch (ArgumentException ex) { UiHelper.ShowWarning(ex.Message); }

            catch (Exception ex) { UiHelper.ShowError($"Lỗi cập nhật học kỳ: {ex.Message}"); }

        }

        private void btnSetCurrent_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(_selectedSemesterId))
            {

                UiHelper.ShowWarning("Vui lòng chọn một học kỳ từ danh sách để đặt làm học kỳ hiện tại.");
                return;
            }

            try
            {

                _semesterBll.SetCurrentSemester(_selectedSemesterId, AuthBLL.CurrentUser?.Username);
                UiHelper.ShowSuccess($"Đã đặt học kỳ '{_selectedSemesterId}' làm học kỳ hiện tại!");
                LoadSemesters();
            }

            catch (Exception ex)
            {

                UiHelper.ShowError($"Lỗi đặt học kỳ hiện tại: {ex.Message}");
            }

        }

        private void btnClearSemester_Click(object sender, EventArgs e)
        {

            ClearSemesterForm();
        }

        private void ClearSemesterForm()
        {

            _selectedSemesterId = string.Empty;
            txtSemesterID.ReadOnly = false;
            txtSemesterID.Clear();
            txtSemesterName.Clear();
            txtSchoolYear.Clear();
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddMonths(5);
            chkIsCurrent.Checked = false;
            dgvSemesters.ClearSelection();
        }

        private void dgvSemesters_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;
            if (dgvSemesters.Rows[e.RowIndex].DataBoundItem is not SemesterDTO s) return;
            _selectedSemesterId = s.SemesterID;
            txtSemesterID.Text = s.SemesterID;
            txtSemesterName.Text = s.SemesterName;
            txtSchoolYear.Text = s.SchoolYear;
            if (s.StartDate.HasValue) dtpStartDate.Value = s.StartDate.Value;
            if (s.EndDate.HasValue) dtpEndDate.Value = s.EndDate.Value;
            chkIsCurrent.Checked = s.IsCurrent;
            txtSemesterID.ReadOnly = true;
        }

        #endregion

        #region Đăng ký môn học (Enrollments)

        private void LoadEnrollmentComboboxes()
        {

            try
            {

                var students = _studentBll.GetAllStudents();
                cboEnrollStudent.DisplayMember = "DisplayText";
                cboEnrollStudent.ValueMember = "StudentID";
                cboEnrollStudent.DataSource = students;
            }

            catch (Exception ex)
            {

                UiHelper.ShowError($"Lỗi tải danh mục sinh viên: {ex.Message}");
            }

        }

        private void LoadEnrollments()
        {

            try
            {

                string? semId = cboEnrollSemester.SelectedValue?.ToString();
                var list = _enrollBll.GetEnrollments(semesterId: semId);
                dgvEnrollments.DataSource = null;
                dgvEnrollments.DataSource = list;
                dgvEnrollments.ClearSelection();
            }

            catch (Exception ex)
            {

                UiHelper.ShowError($"Lỗi tải danh sách đăng ký môn: {ex.Message}");
            }

        }

        private void cboEnrollSemester_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadEnrollments();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {

            if (cboEnrollStudent.SelectedValue is not int studentId || studentId <= 0)
            {

                UiHelper.ShowWarning("Vui lòng chọn sinh viên cần đăng ký môn.");
                return;
            }

            if (cboEnrollSubject.SelectedValue is not int subjectId || subjectId <= 0)
            {

                UiHelper.ShowWarning("Vui lòng chọn môn học cần đăng ký.");
                return;
            }

            string? semId = cboEnrollSemester.SelectedValue?.ToString();
            if (string.IsNullOrWhiteSpace(semId))
            {

                UiHelper.ShowWarning("Vui lòng chọn học kỳ.");
                return;
            }

            try
            {

                _enrollBll.EnrollStudent(studentId, subjectId, semId, AuthBLL.CurrentUser?.Username);
                UiHelper.ShowSuccess("Đăng ký môn học thành công!");
                LoadEnrollments();
            }

            catch (InvalidOperationException ex) { UiHelper.ShowWarning(ex.Message); }

            catch (ArgumentException ex) { UiHelper.ShowWarning(ex.Message); }

            catch (Exception ex) { UiHelper.ShowError($"Lỗi đăng ký môn học: {ex.Message}"); }

        }

        private void btnCancelEnroll_Click(object sender, EventArgs e)
        {

            if (dgvEnrollments.CurrentRow?.DataBoundItem is not EnrollmentDTO en)
            {

                UiHelper.ShowWarning("Vui lòng chọn một bản ghi đăng ký từ danh sách bên dưới để hủy.");
                return;
            }

            if (!UiHelper.Confirm($"Hủy đăng ký môn '{en.SubjectName}' cho sinh viên '{en.StudentName}'?\nLưu ý: Mọi điểm số liên quan đến môn học này trong kỳ cũng sẽ bị xóa!", "Xác nhận hủy đăng ký"))
            {

                return;
            }

            try
            {

                if (_enrollBll.CancelEnrollment(en.EnrollmentID, AuthBLL.CurrentUser?.Username))
                {

                    UiHelper.ShowSuccess("Đã hủy đăng ký môn học thành công!");
                    LoadEnrollments();
                }

            }

            catch (Exception ex)
            {

                UiHelper.ShowError($"Lỗi hủy đăng ký môn: {ex.Message}");
            }

        }

        #endregion

    }

}

