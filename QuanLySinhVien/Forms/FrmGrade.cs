using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.Forms
{
    public partial class FrmGrade : Form
    {
        private readonly GradeBLL _gradeBll = new GradeBLL();
        private readonly SemesterBLL _semesterBll = new SemesterBLL();
        private readonly ClassBLL _classBll = new ClassBLL();
        private readonly SubjectBLL _subjectBll = new SubjectBLL();
        private readonly StudentBLL _studentBll = new StudentBLL();

        private GradeDTO? _selectedGrade;
        private List<GradeDTO> _currentList = new List<GradeDTO>();

        public FrmGrade()
        {
            InitializeComponent();
        }

        private void FrmGrade_Load(object sender, EventArgs e)
        {
            this.BackColor = UiHelper.ContentBg;
            UiHelper.StyleFilterBar(pnlTop);
            UiHelper.StyleCard(pnlInput, UiHelper.Primary);
            UiHelper.StyleCard(pnlTranscriptSummary, UiHelper.Accent);
            UiHelper.StyleDataGridView(dgvGrades);

            lblInputHeader.Font = UiHelper.SubHeaderFont;
            lblInputHeader.ForeColor = UiHelper.PrimaryDark;

            lblFilterSemester.Font = UiHelper.SmallBoldFont; lblFilterSemester.ForeColor = UiHelper.TextSecondary;
            lblFilterClass.Font = UiHelper.SmallBoldFont; lblFilterClass.ForeColor = UiHelper.TextSecondary;
            lblFilterSubject.Font = UiHelper.SmallBoldFont; lblFilterSubject.ForeColor = UiHelper.TextSecondary;
            lblSearchStudent.Font = UiHelper.SmallBoldFont; lblSearchStudent.ForeColor = UiHelper.TextSecondary;

            lblMidtermScore.Font = UiHelper.SmallBoldFont; lblMidtermScore.ForeColor = UiHelper.TextSecondary;
            lblFinalScore.Font = UiHelper.SmallBoldFont; lblFinalScore.ForeColor = UiHelper.TextSecondary;
            lblNotes.Font = UiHelper.SmallBoldFont; lblNotes.ForeColor = UiHelper.TextSecondary;
            lblTotalScore.Font = UiHelper.SmallBoldFont; lblTotalScore.ForeColor = UiHelper.TextSecondary;
            lblRank.Font = UiHelper.SmallBoldFont; lblRank.ForeColor = UiHelper.TextSecondary;
            lblIsPassed.Font = UiHelper.SmallBoldFont; lblIsPassed.ForeColor = UiHelper.TextSecondary;

            lblSemesterGPA.Font = UiHelper.BoldFont; lblSemesterGPA.ForeColor = UiHelper.TextPrimary;
            lblCumulativeGPA.Font = UiHelper.BoldFont; lblCumulativeGPA.ForeColor = UiHelper.TextPrimary;
            lblTotalCreditsEarned.Font = UiHelper.BoldFont; lblTotalCreditsEarned.ForeColor = UiHelper.TextPrimary;

            UiHelper.StylePrimaryButton(btnFilter);
            UiHelper.StyleSuccessButton(btnSaveGrade);
            UiHelper.StyleSuccessButton(btnExportExcel);

            dgvGrades.CellFormatting += (s, ev) =>
            {
                if (ev.RowIndex >= 0)
                {
                    string prop = dgvGrades.Columns[ev.ColumnIndex].DataPropertyName;
                    if (prop == "TotalScore" && ev.Value != null && decimal.TryParse(ev.Value.ToString(), out decimal sc))
                    {
                        UiHelper.FormatScoreCell(ev, sc);
                    }
                    else if (prop == "AcademicRank" && ev.Value != null)
                    {
                        string rank = ev.Value.ToString() ?? "";
                        if (rank == "Xuất sắc" || rank == "Giỏi")
                        {
                            ev.CellStyle.ForeColor = UiHelper.SuccessDark;
                            ev.CellStyle.Font = UiHelper.BoldFont;
                        }
                        else if (rank == "Kém" || rank == "Yếu")
                        {
                            ev.CellStyle.ForeColor = UiHelper.DangerDark;
                            ev.CellStyle.Font = UiHelper.BoldFont;
                        }
                    }
                }
            };

            InitGridColumns();
            LoadFilterData();
            ApplyRoleRestrictions();
            LoadGrades();
        }

        private void ApplyRoleRestrictions()
        {
            var user = AuthBLL.CurrentUser;
            // Phục hồi quyền mặc định trước khi áp dụng
            pnlInput.Enabled = true;
            btnSaveGrade.Enabled = true;
            txtSearchStudent.ReadOnly = false;

            if (user != null && user.IsStudent)
            {
                // Sinh viên chỉ được xem điểm của chính mình
                pnlInput.Enabled = false;
                btnSaveGrade.Enabled = false;

                // Nếu có liên kết StudentCode hoặc StudentID, tự động điền và khóa ô tìm kiếm
                if (!string.IsNullOrWhiteSpace(user.StudentCode))
                {
                    txtSearchStudent.Text = user.StudentCode;
                    txtSearchStudent.ReadOnly = true;
                }
            }
        }

        private void InitGridColumns()
        {
            dgvGrades.Columns.Clear();
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GradeID", HeaderText = "ID", Visible = false });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EnrollmentID", HeaderText = "EnID", Visible = false });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SemesterName", HeaderText = "Học kỳ", Width = 95 });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentCode", HeaderText = "Mã SV", Width = 85 });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentName", HeaderText = "Họ và tên", Width = 150 });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClassName", HeaderText = "Lớp", Width = 110 });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubjectCode", HeaderText = "Mã môn", Width = 85 });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubjectName", HeaderText = "Tên môn học", Width = 170 });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Credits", HeaderText = "TC", Width = 50 });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MidtermScore", HeaderText = "Điểm QT", Width = 75, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FinalScore", HeaderText = "Điểm Thi", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalScore", HeaderText = "Tổng kết", Width = 85, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight, Font = UiHelper.BoldFont } });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LetterGrade", HeaderText = "Điểm chữ", Width = 85, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AcademicRank", HeaderText = "Xếp loại", Width = 100 });
            dgvGrades.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "IsPassed", HeaderText = "Đạt?", Width = 65 });
            dgvGrades.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Notes", HeaderText = "Ghi chú", Width = 120 });
        }

        private void LoadFilterData()
        {
            try
            {
                // Semesters
                var semesters = _semesterBll.GetAllSemesters();
                cboFilterSemester.Items.Clear();
                cboFilterSemester.Items.Add(new SemesterDTO { SemesterID = "", SemesterName = "Tất cả học kỳ" });
                foreach (var s in semesters) cboFilterSemester.Items.Add(s);
                cboFilterSemester.DisplayMember = "DisplayText";
                cboFilterSemester.ValueMember = "SemesterID";
                cboFilterSemester.SelectedIndex = 0;

                // Classes
                var classes = _classBll.GetAllClasses();
                cboFilterClass.Items.Clear();
                cboFilterClass.Items.Add(new ClassDTO { ClassID = "", ClassName = "Tất cả lớp" });
                foreach (var c in classes) cboFilterClass.Items.Add(c);
                cboFilterClass.DisplayMember = "ClassName";
                cboFilterClass.ValueMember = "ClassID";
                cboFilterClass.SelectedIndex = 0;

                // Subjects
                var subjects = _subjectBll.GetAllSubjects();
                cboFilterSubject.Items.Clear();
                cboFilterSubject.Items.Add(new SubjectDTO { SubjectID = 0, SubjectName = "Tất cả môn học" });
                foreach (var s in subjects) cboFilterSubject.Items.Add(s);
                cboFilterSubject.DisplayMember = "DisplayText";
                cboFilterSubject.ValueMember = "SubjectID";
                cboFilterSubject.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi nạp bộ lọc điểm: {ex.Message}");
            }
        }

        private void LoadGrades()
        {
            try
            {
                string? semId = null;
                if (cboFilterSemester.SelectedItem is SemesterDTO s && !string.IsNullOrWhiteSpace(s.SemesterID))
                    semId = s.SemesterID;

                string? classId = null;
                if (cboFilterClass.SelectedItem is ClassDTO c && !string.IsNullOrWhiteSpace(c.ClassID))
                    classId = c.ClassID;

                int? subId = null;
                if (cboFilterSubject.SelectedItem is SubjectDTO sub && sub.SubjectID > 0)
                    subId = sub.SubjectID;

                int? studentId = null;
                var user = AuthBLL.CurrentUser;
                if (user != null && user.IsStudent && user.StudentID.HasValue)
                {
                    studentId = user.StudentID.Value;
                }

                _currentList = _gradeBll.GetGrades(studentId, subId, semId, classId);

                // Lọc thêm theo chuỗi tìm kiếm nếu có
                string searchKw = txtSearchStudent.Text.Trim();
                if (!string.IsNullOrWhiteSpace(searchKw))
                {
                    _currentList = _currentList.Where(g => 
                        g.StudentCode.Contains(searchKw, StringComparison.OrdinalIgnoreCase) ||
                        g.StudentName.Contains(searchKw, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                dgvGrades.DataSource = null;
                dgvGrades.DataSource = _currentList;
                dgvGrades.ClearSelection();

                // Tính toán GPA & tổng kết bảng điểm
                CalculateTranscriptSummary();
                ClearInputForm();
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi tải bảng điểm: {ex.Message}");
            }
        }

        private void CalculateTranscriptSummary()
        {
            int totalCredits = 0;
            int earnedCredits = 0;
            decimal weightedSum = 0;
            int count = 0;

            foreach (var g in _currentList)
            {
                if (g.TotalScore.HasValue)
                {
                    totalCredits += g.Credits;
                    weightedSum += g.TotalScore.Value * g.Credits;
                    if (g.IsPassed == true)
                    {
                        earnedCredits += g.Credits;
                    }
                    count++;
                }
            }

            decimal gpa10 = totalCredits > 0 ? Math.Round(weightedSum / totalCredits, 2) : 0m;
            decimal gpa4 = 0m;
            if (gpa10 >= 8.5m) gpa4 = 4.0m;
            else if (gpa10 >= 8.0m) gpa4 = 3.5m;
            else if (gpa10 >= 7.0m) gpa4 = 3.0m;
            else if (gpa10 >= 6.5m) gpa4 = 2.5m;
            else if (gpa10 >= 5.5m) gpa4 = 2.0m;
            else if (gpa10 >= 5.0m) gpa4 = 1.5m;
            else if (gpa10 >= 4.0m) gpa4 = 1.0m;

            lblSemesterGPA.Text = $"GPA trung bình: {gpa10:F2} (Hệ 4: {gpa4:F1})";
            lblTotalCreditsEarned.Text = $"Tín chỉ tích lũy đạt: {earnedCredits} / {totalCredits} TC";
            lblCumulativeGPA.Text = $"Tổng số môn hiển thị: {_currentList.Count} ({count} môn đã có điểm)";
        }

        private void dgvGrades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvGrades.Rows[e.RowIndex].DataBoundItem is not GradeDTO g) return;

            _selectedGrade = g;
            lblSelectedStudent.Text = $"Sinh viên: {g.StudentCode} - {g.StudentName}\nLớp: {g.ClassName}";
            lblSelectedSubject.Text = $"Môn học: {g.SubjectCode} - {g.SubjectName} ({g.Credits} TC)\nHọc kỳ: {g.SemesterName} ({g.SchoolYear})";

            numMidtermScore.Value = g.MidtermScore ?? 0m;
            numFinalScore.Value = g.FinalScore ?? 0m;
            txtNotes.Text = g.Notes ?? string.Empty;

            UpdateScoreCalculations();
        }

        private void ScoreInput_ValueChanged(object sender, EventArgs e)
        {
            UpdateScoreCalculations();
        }

        private void UpdateScoreCalculations()
        {
            if (_selectedGrade == null) return;

            decimal mw = _selectedGrade.MidtermWeight > 0 ? _selectedGrade.MidtermWeight : 0.40m;
            decimal fw = _selectedGrade.FinalWeight > 0 ? _selectedGrade.FinalWeight : 0.60m;

            decimal total = Math.Round((numMidtermScore.Value * mw) + (numFinalScore.Value * fw), 2);
            lblTotalScoreVal.Text = total.ToString("F2");

            bool passed = total >= 4.0m && numFinalScore.Value >= 3.0m;
            lblIsPassedVal.Text = passed ? "✅ ĐẠT (Qua môn)" : "❌ KHÔNG ĐẠT (Thi/Học lại)";
            lblIsPassedVal.ForeColor = passed ? Color.FromArgb(39, 174, 96) : Color.FromArgb(192, 57, 43);

            string rank;
            string letter;
            if (total >= 9.0m) { letter = "A+"; rank = "Xuất sắc"; }
            else if (total >= 8.5m) { letter = "A"; rank = "Giỏi"; }
            else if (total >= 8.0m) { letter = "B+"; rank = "Khá giỏi"; }
            else if (total >= 7.0m) { letter = "B"; rank = "Khá"; }
            else if (total >= 6.5m) { letter = "C+"; rank = "Trung bình khá"; }
            else if (total >= 5.5m) { letter = "C"; rank = "Trung bình"; }
            else if (total >= 5.0m) { letter = "D+"; rank = "Trung bình yếu"; }
            else if (total >= 4.0m) { letter = "D"; rank = "Yếu"; }
            else { letter = "F"; rank = "Kém (Học lại)"; }

            lblRankVal.Text = $"{rank} ({letter})";
        }

        private void btnSaveGrade_Click(object sender, EventArgs e)
        {
            if (_selectedGrade == null)
            {
                UiHelper.ShowWarning("Vui lòng chọn một sinh viên từ danh sách bảng điểm để nhập kết quả.");
                return;
            }

            try
            {
                _selectedGrade.MidtermScore = numMidtermScore.Value;
                _selectedGrade.FinalScore = numFinalScore.Value;
                _selectedGrade.Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();

                if (_gradeBll.SaveGrade(_selectedGrade, AuthBLL.CurrentUser?.Username))
                {
                    UiHelper.ShowSuccess($"Lưu kết quả môn '{_selectedGrade.SubjectCode}' cho SV '{_selectedGrade.StudentCode}' thành công!");
                    LoadGrades();
                }
            }
            catch (ArgumentException ex) { UiHelper.ShowWarning(ex.Message); }
            catch (Exception ex) { UiHelper.ShowError($"Lỗi lưu điểm: {ex.Message}"); }
        }

        private void ClearInputForm()
        {
            _selectedGrade = null;
            lblSelectedStudent.Text = "Sinh viên: (Chọn một dòng trong bảng)";
            lblSelectedSubject.Text = "Môn học: (Chưa chọn)";
            numMidtermScore.Value = 0m;
            numFinalScore.Value = 0m;
            txtNotes.Clear();
            lblTotalScoreVal.Text = "--";
            lblRankVal.Text = "--";
            lblIsPassedVal.Text = "--";
        }

        private void Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrades();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadGrades();
        }

        private void txtSearchStudent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadGrades();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (_currentList == null || _currentList.Count == 0)
            {
                UiHelper.ShowWarning("Không có dữ liệu điểm để xuất.");
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Tập tin CSV (*.csv)|*.csv|Tất cả tập tin (*.*)|*.*",
                FileName = $"BangDiem_{DateTime.Today:yyyyMMdd}.csv",
                Title = "Lưu bảng điểm"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] headers = new string[] {
                        "Học kỳ", "Mã SV", "Họ và tên", "Lớp", "Mã môn", "Tên môn học",
                        "Tín chỉ", "Điểm quá trình", "Điểm thi", "Điểm tổng kết",
                        "Điểm chữ", "Xếp loại", "Đạt?", "Ghi chú"
                    };

                    StatisticsBLL.ExportToCsv(
                        _currentList,
                        sfd.FileName,
                        g => new string[] {
                            g.SemesterName,
                            g.StudentCode,
                            g.StudentName,
                            g.ClassName,
                            g.SubjectCode,
                            g.SubjectName,
                            g.Credits.ToString(),
                            g.MidtermScore?.ToString("F2") ?? "",
                            g.FinalScore?.ToString("F2") ?? "",
                            g.TotalScore?.ToString("F2") ?? "",
                            g.LetterGrade ?? "",
                            g.AcademicRank ?? "",
                            g.IsPassed == true ? "Đạt" : (g.IsPassed == false ? "Hỏng" : ""),
                            g.Notes ?? ""
                        },
                        headers
                    );

                    UiHelper.ShowSuccess($"Đã xuất thành công {_currentList.Count} bản ghi điểm ra file:\n{sfd.FileName}");
                }
                catch (Exception ex)
                {
                    UiHelper.ShowError($"Lỗi khi xuất bảng điểm: {ex.Message}");
                }
            }
        }
    }
}
