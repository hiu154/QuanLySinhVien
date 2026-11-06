using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DTO;
using QuanLySinhVien.Logging;

namespace QuanLySinhVien.Forms
{
    public partial class FrmSystemLogs : Form
    {
        private readonly AppLogBLL _logBll = new AppLogBLL();
        private List<AppLogDTO> _currentLogs = new List<AppLogDTO>();

        public FrmSystemLogs()
        {
            InitializeComponent();
        }

        private void FrmSystemLogs_Load(object sender, EventArgs e)
        {
            this.BackColor = UiHelper.ContentBg;
            UiHelper.StyleFilterBar(pnlTop);
            UiHelper.StyleCard(pnlDetail, Color.FromArgb(100, 116, 139));
            UiHelper.StyleDataGridView(dgvLogs);

            lblLevel.Font = UiHelper.SmallBoldFont; lblLevel.ForeColor = UiHelper.TextSecondary;
            lblUser.Font = UiHelper.SmallBoldFont; lblUser.ForeColor = UiHelper.TextSecondary;
            lblFrom.Font = UiHelper.SmallBoldFont; lblFrom.ForeColor = UiHelper.TextSecondary;
            lblTo.Font = UiHelper.SmallBoldFont; lblTo.ForeColor = UiHelper.TextSecondary;

            lblMessage.Font = UiHelper.SmallBoldFont; lblMessage.ForeColor = UiHelper.TextSecondary;
            lblException.Font = UiHelper.SmallBoldFont; lblException.ForeColor = UiHelper.TextSecondary;

            UiHelper.StylePrimaryButton(btnRefresh);
            UiHelper.StyleSuccessButton(btnExportLog);
            UiHelper.StyleDangerButton(btnClearOld);

            dgvLogs.CellFormatting += (s, ev) =>
            {
                if (ev.RowIndex >= 0 && dgvLogs.Columns[ev.ColumnIndex].DataPropertyName == "LogLevel")
                {
                    UiHelper.FormatLogLevelCell(ev);
                }
            };

            InitGridColumns();

            cboLevel.SelectedIndex = 0; // Tất cả
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today;

            LoadLogs();

            // Đăng ký nhận sự kiện realtime từ AppLogger
            AppLogger.OnLogLogged += AppLogger_OnLogLogged;
        }

        private void AppLogger_OnLogLogged(AppLogDTO log)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            // Đưa về UI thread an toàn
            this.BeginInvoke((Action)(() =>
            {
                _currentLogs.Insert(0, log);
                dgvLogs.DataSource = null;
                dgvLogs.DataSource = _currentLogs;
            }));
        }

        private void InitGridColumns()
        {
            dgvLogs.Columns.Clear();
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LogID", HeaderText = "ID", Width = 60 });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Timestamp", HeaderText = "Thời gian", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm:ss" } });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LogLevel", HeaderText = "Mức độ", Width = 100 });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Username", HeaderText = "Người dùng", Width = 110 });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Action", HeaderText = "Thao tác (Action)", Width = 160 });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Message", HeaderText = "Nội dung", Width = 450 });
        }

        private void LoadLogs()
        {
            try
            {
                string? level = cboLevel.SelectedItem?.ToString();
                string? username = string.IsNullOrWhiteSpace(txtUsername.Text) ? null : txtUsername.Text.Trim();
                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo.Value.Date;

                _currentLogs = _logBll.GetLogs(level, username, from, to, limit: 300);
                dgvLogs.DataSource = null;
                dgvLogs.DataSource = _currentLogs;
                dgvLogs.ClearSelection();

                ColorRows();
                ClearDetail();
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi tải nhật ký hệ thống: {ex.Message}");
            }
        }

        private void ColorRows()
        {
            foreach (DataGridViewRow row in dgvLogs.Rows)
            {
                if (row.DataBoundItem is AppLogDTO log)
                {
                    switch (log.LogLevel.ToUpperInvariant())
                    {
                        case "ERROR":
                        case "CRITICAL":
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                            row.DefaultCellStyle.Font = UiHelper.BoldFont;
                            break;
                        case "WARNING":
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(214, 137, 16);
                            break;
                        case "DEBUG":
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(127, 140, 141);
                            break;
                    }
                }
            }
        }

        private void dgvLogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvLogs.Rows[e.RowIndex].DataBoundItem is not AppLogDTO log) return;

            txtMessage.Text = $"[{log.Timestamp:dd/MM/yyyy HH:mm:ss}] [{log.LogLevel}] [{log.Username}] [{log.Action}]: {log.Message}";
            txtException.Text = log.ExceptionDetails ?? "(Không có ngoại lệ)";
        }

        private void ClearDetail()
        {
            txtMessage.Clear();
            txtException.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void cboLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLogs();
        }

        private void btnClearOld_Click(object sender, EventArgs e)
        {
            if (!UiHelper.Confirm("Bạn có chắc chắn muốn dọn dẹp các bản ghi nhật ký hệ thống cũ hơn 30 ngày?", "Dọn nhật ký"))
            {
                return;
            }

            try
            {
                _logBll.ClearOldLogs(daysToKeep: 30);
                UiHelper.ShowSuccess("Đã dọn dẹp nhật ký cũ thành công!");
                LoadLogs();
            }
            catch (Exception ex)
            {
                UiHelper.ShowError($"Lỗi khi dọn nhật ký: {ex.Message}");
            }
        }

        private void btnExportLog_Click(object sender, EventArgs e)
        {
            if (_currentLogs == null || _currentLogs.Count == 0)
            {
                UiHelper.ShowWarning("Không có dữ liệu nhật ký để xuất.");
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Tập tin Text (*.log;*.txt)|*.log;*.txt|Tất cả tập tin (*.*)|*.*",
                FileName = $"SystemLogs_{DateTime.Today:yyyyMMdd}.txt",
                Title = "Lưu file nhật ký hệ thống"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("=========================================================================");
                    sb.AppendLine($"NHẬT KÝ HOẠT ĐỘNG HỆ THỐNG - QUẢN LÝ SINH VIÊN (Xuất ngày: {DateTime.Now:dd/MM/yyyy HH:mm:ss})");
                    sb.AppendLine("=========================================================================\n");

                    foreach (var l in _currentLogs)
                    {
                        sb.AppendLine($"[{l.Timestamp:yyyy-MM-dd HH:mm:ss}] [{l.LogLevel.ToUpperInvariant()}] [User:{l.Username}] [Action:{l.Action}]");
                        sb.AppendLine($"  Message: {l.Message}");
                        if (!string.IsNullOrEmpty(l.ExceptionDetails))
                        {
                            sb.AppendLine($"  Exception: {l.ExceptionDetails}");
                        }
                        sb.AppendLine(new string('-', 70));
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    UiHelper.ShowSuccess($"Đã xuất {_currentLogs.Count} dòng nhật ký ra file:\n{sfd.FileName}");
                }
                catch (Exception ex)
                {
                    UiHelper.ShowError($"Lỗi khi xuất file: {ex.Message}");
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            AppLogger.OnLogLogged -= AppLogger_OnLogLogged;
            base.OnFormClosed(e);
        }
    }
}
