using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuanLySinhVien.Forms
{
    public static class UiHelper
    {
        // ==========================================
        // 1. MODERN COLOR PALETTE (Fluent / Tailwind Slate & Royal Blue)
        // ==========================================
        public static readonly Color Primary = Color.FromArgb(37, 99, 235);          // Royal Blue 600 (#2563EB)
        public static readonly Color PrimaryDark = Color.FromArgb(29, 78, 216);      // Blue 700 (#1D4ED8)
        public static readonly Color PrimaryLight = Color.FromArgb(239, 246, 255);   // Blue 50 (#EFF6FF)
        public static readonly Color PrimaryBorder = Color.FromArgb(191, 219, 254);  // Blue 200

        public static readonly Color Accent = Color.FromArgb(14, 165, 233);          // Sky Blue (#0EA5E9)
        public static readonly Color Success = Color.FromArgb(16, 185, 129);         // Emerald (#10B981)
        public static readonly Color SuccessDark = Color.FromArgb(5, 150, 105);      // Emerald 600 (#059669)
        public static readonly Color SuccessLight = Color.FromArgb(236, 253, 245);   // Emerald 50

        public static readonly Color Warning = Color.FromArgb(245, 158, 11);         // Amber (#F59E0B)
        public static readonly Color WarningDark = Color.FromArgb(217, 119, 6);      // Amber 600
        public static readonly Color WarningLight = Color.FromArgb(254, 243, 199);   // Amber 100

        public static readonly Color Danger = Color.FromArgb(239, 68, 68);           // Rose / Red (#EF4444)
        public static readonly Color DangerDark = Color.FromArgb(220, 38, 38);       // Red 600
        public static readonly Color DangerLight = Color.FromArgb(254, 242, 242);    // Red 50

        // Sidebar & Navigation Colors
        public static readonly Color SidebarBg = Color.FromArgb(15, 23, 42);         // Slate 900 (#0F172A)
        public static readonly Color SidebarCard = Color.FromArgb(30, 41, 59);       // Slate 800 (#1E293B)
        public static readonly Color SidebarHover = Color.FromArgb(51, 65, 85);      // Slate 700 (#334155)
        public static readonly Color SidebarActive = Color.FromArgb(37, 99, 235);    // Royal Blue (#2563EB)
        public static readonly Color SidebarText = Color.FromArgb(148, 163, 184);    // Slate 400 (#94A3B8)
        public static readonly Color SidebarTextActive = Color.White;

        // Content & Background Colors
        public static readonly Color ContentBg = Color.FromArgb(248, 250, 252);      // Slate 50 (#F8FAFC)
        public static readonly Color CardBg = Color.White;
        public static readonly Color BorderColor = Color.FromArgb(226, 232, 240);    // Slate 200 (#E2E8F0)
        public static readonly Color BorderDark = Color.FromArgb(203, 213, 225);     // Slate 300 (#CBD5E1)

        // Text Colors
        public static readonly Color TextPrimary = Color.FromArgb(15, 23, 42);       // Slate 900
        public static readonly Color TextSecondary = Color.FromArgb(71, 85, 105);    // Slate 600
        public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);      // Slate 500

        // Compatibility aliases for existing references
        public static readonly Color PrimaryColor = Primary;
        public static readonly Color AccentColor = Accent;
        public static readonly Color SuccessColor = SuccessDark;
        public static readonly Color WarningColor = WarningDark;
        public static readonly Color DangerColor = DangerDark;

        // ==========================================
        // 2. MODERN TYPOGRAPHY (Segoe UI)
        // ==========================================
        public static readonly Font TitleFont = new Font("Segoe UI", 16F, FontStyle.Bold);
        public static readonly Font HeaderFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font SubHeaderFont = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        public static readonly Font RegularFont = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        public static readonly Font BoldFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font SmallFont = new Font("Segoe UI", 8.5F, FontStyle.Regular);
        public static readonly Font SmallBoldFont = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        public static readonly Font KpiNumberFont = new Font("Segoe UI", 22F, FontStyle.Bold);

        // ==========================================
        // 3. DATAGRIDVIEW MODERN STYLING
        // ==========================================
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = BorderColor;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.Font = RegularFont;
            dgv.RowTemplate.Height = 36;
            dgv.AllowUserToResizeRows = false;

            // Header Style
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = SidebarCard;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = BoldFont;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 6, 8, 6);
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Default Row Style
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 231, 255); // Indigo 100
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 27, 75);     // Indigo 950
            dgv.DefaultCellStyle.Padding = new Padding(6, 3, 6, 3);

            // Alternating Row Style
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252); // Slate 50
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 231, 255);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 27, 75);
        }

        // ==========================================
        // 4. BUTTON MODERN STYLING
        // ==========================================
        public static void StylePrimaryButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Primary;
            btn.ForeColor = Color.White;
            btn.Font = BoldFont;
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.MouseOverBackColor = PrimaryDark;
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 58, 138);
        }

        public static void StyleSuccessButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = SuccessDark;
            btn.ForeColor = Color.White;
            btn.Font = BoldFont;
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(4, 120, 87);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(6, 95, 70);
        }

        public static void StyleDangerButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = DangerDark;
            btn.ForeColor = Color.White;
            btn.Font = BoldFont;
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(185, 28, 28);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 27, 27);
        }

        public static void StyleWarningButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = WarningDark;
            btn.ForeColor = Color.White;
            btn.Font = BoldFont;
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 83, 9);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(146, 64, 14);
        }

        public static void StyleSecondaryButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = BorderDark;
            btn.BackColor = Color.White;
            btn.ForeColor = TextSecondary;
            btn.Font = BoldFont;
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(226, 232, 240);
        }

        // ==========================================
        // 5. CARD & PANEL STYLING
        // ==========================================
        public static void StyleCard(Panel panel, Color? accentBorderColor = null)
        {
            panel.BorderStyle = BorderStyle.None;
            panel.BackColor = CardBg;
            panel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Viền xung quanh
                using (var pen = new Pen(BorderColor, 1f))
                {
                    g.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }

                // Dải màu nhấn phía trên nếu có
                if (accentBorderColor.HasValue)
                {
                    using (var brush = new SolidBrush(accentBorderColor.Value))
                    {
                        g.FillRectangle(brush, 0, 0, panel.Width, 4);
                    }
                }
            };
        }

        public static void StyleFilterBar(Panel panel)
        {
            panel.BorderStyle = BorderStyle.None;
            panel.BackColor = Color.White;
            panel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                using (var pen = new Pen(BorderColor, 1f))
                {
                    // Viền dưới ngăn cách giữa filter bar và content
                    g.DrawLine(pen, 0, panel.Height - 1, panel.Width, panel.Height - 1);
                }
            };
        }

        public static void StyleTabControl(TabControl tc)
        {
            tc.Font = RegularFont;
            foreach (TabPage tp in tc.TabPages)
            {
                tp.BackColor = ContentBg;
            }
        }

        // ==========================================
        // 6. AVATAR DRAWING HELPER
        // ==========================================
        public static void DrawAvatar(Graphics g, Rectangle rect, string fullName, Color bgColor)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // Hình tròn nền
            using (var brush = new SolidBrush(bgColor))
            {
                g.FillEllipse(brush, rect);
            }

            // Trích xuất chữ cái đầu viết tắt (Initials)
            string initials = "U";
            if (!string.IsNullOrWhiteSpace(fullName))
            {
                var parts = fullName.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 1)
                    initials = parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpper();
                else if (parts.Length > 1)
                    initials = $"{parts[0][0]}{parts[parts.Length - 1][0]}".ToUpper();
            }

            using (var font = new Font("Segoe UI", rect.Height * 0.38f, FontStyle.Bold))
            using (var textBrush = new SolidBrush(Color.White))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString(initials, font, textBrush, rect, sf);
            }
        }

        // ==========================================
        // 7. CELL FORMATTING HELPERS
        // ==========================================
        public static void FormatStatusCell(DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            string status = e.Value.ToString() ?? "";

            switch (status)
            {
                case "Đang học":
                    e.CellStyle.ForeColor = Color.FromArgb(5, 150, 105);
                    e.CellStyle.Font = BoldFont;
                    break;
                case "Tốt nghiệp":
                    e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                    e.CellStyle.Font = BoldFont;
                    break;
                case "Bảo lưu":
                    e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6);
                    e.CellStyle.Font = BoldFont;
                    break;
                case "Đình chỉ":
                case "Thôi học":
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                    e.CellStyle.Font = BoldFont;
                    break;
            }
        }

        public static void FormatScoreCell(DataGridViewCellFormattingEventArgs e, decimal score)
        {
            if (score < 5.0m)
            {
                e.CellStyle.ForeColor = DangerDark;
                e.CellStyle.Font = BoldFont;
            }
            else if (score >= 8.5m)
            {
                e.CellStyle.ForeColor = SuccessDark;
                e.CellStyle.Font = BoldFont;
            }
        }

        public static void FormatRoleCell(DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            string role = e.Value.ToString() ?? "";

            switch (role)
            {
                case "Admin":
                    e.CellStyle.ForeColor = Color.FromArgb(79, 70, 229);
                    e.CellStyle.Font = BoldFont;
                    break;
                case "Teacher":
                    e.CellStyle.ForeColor = Color.FromArgb(2, 132, 199);
                    e.CellStyle.Font = BoldFont;
                    break;
                case "Student":
                    e.CellStyle.ForeColor = Color.FromArgb(5, 150, 105);
                    e.CellStyle.Font = BoldFont;
                    break;
            }
        }

        public static void FormatLogLevelCell(DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            string lvl = e.Value.ToString() ?? "";

            switch (lvl)
            {
                case "Debug":
                    e.CellStyle.ForeColor = Color.FromArgb(100, 116, 139);
                    break;
                case "Information":
                    e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                    e.CellStyle.Font = BoldFont;
                    break;
                case "Warning":
                    e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6);
                    e.CellStyle.Font = BoldFont;
                    break;
                case "Error":
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                    e.CellStyle.Font = BoldFont;
                    break;
                case "Critical":
                    e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);
                    e.CellStyle.BackColor = Color.FromArgb(254, 242, 242);
                    e.CellStyle.Font = BoldFont;
                    break;
            }
        }

        // ==========================================
        // 8. DIALOG NOTIFICATIONS
        // ==========================================
        public static void ShowSuccess(string message, string title = "Thành công")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string message, string title = "Cảnh báo")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string message, string title = "Lỗi hệ thống")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirm(string message, string title = "Xác nhận hành động")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
