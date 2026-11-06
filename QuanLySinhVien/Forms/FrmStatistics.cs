using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DTO;

namespace QuanLySinhVien.Forms
{
    public partial class FrmStatistics : Form
    {
        private readonly StatisticsBLL _statsBll = new StatisticsBLL();
        private readonly GradeBLL _gradeBll = new GradeBLL();

        private List<GradeDTO> _warningList = new List<GradeDTO>();
        private List<StudentTranscriptSummaryDTO> _gpaList = new List<StudentTranscriptSummaryDTO>();

        public FrmStatistics()
        {
            InitializeComponent();
        }

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            this.BackColor = UiHelper.ContentBg;
            UiHelper.StyleDataGridView(dgvWarning);
            UiHelper.StyleDataGridView(dgvStudentGPA);
            UiHelper.StyleDataGridView(dgvDeptStats);
            UiHelper.StyleDataGridView(dgvStatusStats);

            UiHelper.StyleTabControl(tabControl);
            StyleDashboardCards();
            InitGridColumns();
            SetupGridFormatting();
            LoadAllStatistics();
        }

        private void StyleDashboardCards()
        {
            UiHelper.StyleFilterBar(pnlKpi);

            UiHelper.StyleCard(pnlCardStudents, UiHelper.Primary);
            UiHelper.StyleCard(pnlCardDepts, Color.FromArgb(79, 70, 229));
            UiHelper.StyleCard(pnlCardClasses, Color.FromArgb(2, 132, 199));
            UiHelper.StyleCard(pnlCardSubjects, Color.FromArgb(217, 119, 6));
            UiHelper.StyleCard(pnlCardScore, Color.FromArgb(5, 150, 105));

            lblCardStudentsTitle.Font = UiHelper.SmallBoldFont;
            lblCardStudentsTitle.ForeColor = UiHelper.TextMuted;
            lblCardStudentsVal.Font = UiHelper.KpiNumberFont;
            lblCardStudentsVal.ForeColor = UiHelper.Primary;

            lblCardDeptsTitle.Font = UiHelper.SmallBoldFont;
            lblCardDeptsTitle.ForeColor = UiHelper.TextMuted;
            lblCardDeptsVal.Font = UiHelper.KpiNumberFont;
            lblCardDeptsVal.ForeColor = Color.FromArgb(79, 70, 229);

            lblCardClassesTitle.Font = UiHelper.SmallBoldFont;
            lblCardClassesTitle.ForeColor = UiHelper.TextMuted;
            lblCardClassesVal.Font = UiHelper.KpiNumberFont;
            lblCardClassesVal.ForeColor = Color.FromArgb(2, 132, 199);

            lblCardSubjectsTitle.Font = UiHelper.SmallBoldFont;
            lblCardSubjectsTitle.ForeColor = UiHelper.TextMuted;
            lblCardSubjectsVal.Font = UiHelper.KpiNumberFont;
            lblCardSubjectsVal.ForeColor = Color.FromArgb(217, 119, 6);

            lblCardScoreTitle.Font = UiHelper.SmallBoldFont;
            lblCardScoreTitle.ForeColor = UiHelper.TextMuted;
            lblCardScoreVal.Font = UiHelper.KpiNumberFont;
            lblCardScoreVal.ForeColor = Color.FromArgb(5, 150, 105);

            UiHelper.StyleCard(pnlWarningTop);
            lblWarningNote.Font = UiHelper.BoldFont;
            lblWarningNote.ForeColor = UiHelper.DangerDark;
            lblThreshold.Font = UiHelper.SmallBoldFont;
            lblThreshold.ForeColor = UiHelper.TextSecondary;

            UiHelper.StyleCard(pnlGpaTop);
            lblGpaTitle.Font = UiHelper.BoldFont;
            lblGpaTitle.ForeColor = UiHelper.PrimaryDark;

            lblDeptStatsTitle.Font = UiHelper.SubHeaderFont;
            lblDeptStatsTitle.ForeColor = UiHelper.TextPrimary;
            lblStatusStatsTitle.Font = UiHelper.SubHeaderFont;
            lblStatusStatsTitle.ForeColor = UiHelper.TextPrimary;

            UiHelper.StylePrimaryButton(btnRefresh);
            UiHelper.StyleSuccessButton(btnExportReport);
            UiHelper.StyleDangerButton(btnExportWarning);
            UiHelper.StyleSuccessButton(btnExportGPA);
        }

        private void SetupGridFormatting()
        {
            dgvWarning.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvWarning.Columns[e.ColumnIndex].DataPropertyName == "TotalScore")
                {
                    if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal sc))
                    {
                        UiHelper.FormatScoreCell(e, sc);
                    }
                }
            };

            dgvStudentGPA.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    string propName = dgvStudentGPA.Columns[e.ColumnIndex].DataPropertyName;
                    if (propName == "GPA10" && e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal gpa))
                    {
                        UiHelper.FormatScoreCell(e, gpa);
                    }
                    else if (propName == "OverallRank" && e.Value != null)
                    {
                        string rank = e.Value.ToString() ?? "";
                        if (rank == "Xuất sắc" || rank == "Giỏi")
                        {
                            e.CellStyle.ForeColor = UiHelper.SuccessDark;
                            e.CellStyle.Font = UiHelper.BoldFont;
                        }
                        else if (rank == "Yếu" || rank == "Kém")
                        {
                            e.CellStyle.ForeColor = UiHelper.DangerDark;
                            e.CellStyle.Font = UiHelper.BoldFont;
                        }
                    }
                }
            };

            dgvStatusStats.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvStatusStats.Columns[e.ColumnIndex].DataPropertyName == "Category")
                {
                    UiHelper.FormatStatusCell(e);
                }
            };
        }

        private void InitGridColumns()
        {
            // 1. Warning Grid
            dgvWarning.Columns.Clear();
            dgvWarning.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentCode", HeaderText = "Mã SV", Width = 90 });
            dgvWarning.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentName", HeaderText = "Họ và tên", Width = 160 });
            dgvWarning.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClassName", HeaderText = "Lớp", Width = 110 });
            dgvWarning.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubjectCode", HeaderText = "Mã môn", Width = 90 });
            dgvWarning.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SubjectName", HeaderText = "Tên môn học", Width = 180 });
            dgvWarning.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SemesterName", HeaderText = "Học kỳ", Width = 100 });
            dgvWarning.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MidtermScore", HeaderText = "Điểm QT", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvWarning.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FinalScore", HeaderText = "Điểm Thi", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvWarning.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalScore", HeaderText = "Tổng kết", Width = 85, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight, Font = UiHelper.BoldFont, ForeColor = System.Drawing.Color.Red } });
            dgvWarning.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AcademicRank", HeaderText = "Xếp loại", Width = 100 });

            // 2. Student GPA Grid
            dgvStudentGPA.Columns.Clear();
            dgvStudentGPA.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentID", HeaderText = "ID", Visible = false });
            dgvStudentGPA.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StudentCode", HeaderText = "Mã SV", Width = 95 });
            dgvStudentGPA.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Họ và tên", Width = 180 });
            dgvStudentGPA.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClassName", HeaderText = "Lớp", Width = 120 });
            dgvStudentGPA.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TotalCredits", HeaderText = "Tổng TC", Width = 80 });
            dgvStudentGPA.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PassedSubjects", HeaderText = "Môn đạt", Width = 80 });
            dgvStudentGPA.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FailedSubjects", HeaderText = "Môn rớt", Width = 80 });
            dgvStudentGPA.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GPA10", HeaderText = "GPA (Hệ 10)", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight, Font = UiHelper.BoldFont } });
            dgvStudentGPA.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GPA4", HeaderText = "GPA (Hệ 4)", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N1", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvStudentGPA.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OverallRank", HeaderText = "Xếp loại chung", Width = 120 });

            // 3. Dept Stats Grid
            dgvDeptStats.Columns.Clear();
            dgvDeptStats.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "Khoa đào tạo", Width = 280 });
            dgvDeptStats.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Count", HeaderText = "Số sinh viên", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvDeptStats.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Percentage", HeaderText = "Tỷ lệ (%)", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N1", Alignment = DataGridViewContentAlignment.MiddleRight } });

            // 4. Status Stats Grid
            dgvStatusStats.Columns.Clear();
            dgvStatusStats.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "Trạng thái học tập", Width = 280 });
            dgvStatusStats.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Count", HeaderText = "Số sinh viên", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvStatusStats.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Percentage", HeaderText = "Tỷ lệ (%)", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N1", Alignment = DataGridViewContentAlignment.MiddleRight } });
        }

        public void LoadAllStatistics()
        {
            try
            {
                // 1. KPI Cards
                var summary = _statsBll.GetDashboardSummary();
                lblCardStudentsVal.Text = summary.TotalStudents.ToString();
                lblCardDeptsVal.Text = summary.TotalDepartments.ToString();
                lblCardClassesVal.Text = summary.TotalClasses.ToString();
                lblCardSubjectsVal.Text = summary.TotalSubjects.ToString();
                lblCardScoreVal.Text = summary.AverageTotalScore.ToString("F2");

                // 2. Warning Students
                decimal threshold = numWarningThreshold.Value;
                _warningList = _gradeBll.GetLowScoreStudents(threshold);
                dgvWarning.DataSource = null;
                dgvWarning.DataSource = _warningList;
                tabWarning.Text = $"⚠ Cảnh báo Học vụ ({_warningList.Count} kết quả)";

                // 3. Overall Student GPA Summaries
                _gpaList = _statsBll.GetStudentGPASummaries();
                dgvStudentGPA.DataSource = null;
                dgvStudentGPA.DataSource = _gpaList;

                // 4. Distribution tables
                var deptStats = _statsBll.GetStudentsByDepartment();
                dgvDeptStats.DataSource = null;
                dgvDeptStats.DataSource = deptStats;

                var statusStats = _statsBll.GetStudentsByStatus();
                dgvStatusStats.DataSource = null;
                dgvStatusStats.DataSource = statusStats;
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi tính toán thống kê: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllStatistics();
        }

        private void numWarningThreshold_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _warningList = _gradeBll.GetLowScoreStudents(numWarningThreshold.Value);
                dgvWarning.DataSource = null;
                dgvWarning.DataSource = _warningList;
                tabWarning.Text = $"⚠ Cảnh báo Học vụ ({_warningList.Count} kết quả)";
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi lọc cảnh báo: {ex.Message}");
            }
        }

        private void btnExportWarning_Click(object sender, EventArgs e)
        {
            if (_warningList == null || _warningList.Count == 0)
            {
                UiHelper.ShowWarning("Không có dữ liệu cảnh báo học vụ để xuất.");
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Tập tin CSV (*.csv)|*.csv|Tất cả tập tin (*.*)|*.*",
                FileName = $"CanhBaoHocVu_{DateTime.Today:yyyyMMdd}.csv",
                Title = "Lưu danh sách cảnh báo học vụ"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] headers = new string[] {
                        "Mã SV", "Họ và tên", "Lớp", "Mã môn", "Tên môn học",
                        "Học kỳ", "Điểm QT", "Điểm Thi", "Điểm Tổng kết", "Xếp loại"
                    };

                    StatisticsBLL.ExportToCsv(
                        _warningList,
                        sfd.FileName,
                        g => new string[] {
                            g.StudentCode,
                            g.StudentName,
                            g.ClassName,
                            g.SubjectCode,
                            g.SubjectName,
                            g.SemesterName,
                            g.MidtermScore?.ToString("F2") ?? "",
                            g.FinalScore?.ToString("F2") ?? "",
                            g.TotalScore?.ToString("F2") ?? "",
                            g.AcademicRank ?? ""
                        },
                        headers
                    );

                    UiHelper.ShowSuccess($"Đã xuất thành công {_warningList.Count} sinh viên điểm thấp ra file:\n{sfd.FileName}");
                }
                catch (Exception ex)
                {
                    UiHelper.ShowError($"Lỗi khi xuất file: {ex.Message}");
                }
            }
        }

        private void btnExportGPA_Click(object sender, EventArgs e)
        {
            if (_gpaList == null || _gpaList.Count == 0)
            {
                UiHelper.ShowWarning("Không có dữ liệu GPA để xuất.");
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Tập tin CSV (*.csv)|*.csv|Tất cả tập tin (*.*)|*.*",
                FileName = $"BangTongKetGPA_{DateTime.Today:yyyyMMdd}.csv",
                Title = "Lưu bảng tổng kết GPA"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] headers = new string[] {
                        "Mã SV", "Họ và tên", "Lớp", "Tổng số tín chỉ", "Số môn đạt",
                        "Số môn rớt", "GPA Hệ 10", "GPA Hệ 4", "Xếp loại học lực"
                    };

                    StatisticsBLL.ExportToCsv(
                        _gpaList,
                        sfd.FileName,
                        item => new string[] {
                            item.StudentCode,
                            item.FullName,
                            item.ClassName,
                            item.TotalCredits.ToString(),
                            item.PassedSubjects.ToString(),
                            item.FailedSubjects.ToString(),
                            item.GPA10.ToString("F2"),
                            item.GPA4.ToString("F1"),
                            item.OverallRank
                        },
                        headers
                    );

                    UiHelper.ShowSuccess($"Đã xuất bảng tổng kết GPA ({_gpaList.Count} sinh viên) thành công!");
                }
                catch (Exception ex)
                {
                    UiHelper.ShowError($"Lỗi khi xuất file GPA: {ex.Message}");
                }
            }
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            btnExportGPA_Click(sender, e);
        }
    }
}
