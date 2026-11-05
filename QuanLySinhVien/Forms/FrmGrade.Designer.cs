namespace QuanLySinhVien.Forms
{
    partial class FrmGrade
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtSearchStudent = new System.Windows.Forms.TextBox();
            this.lblSearchStudent = new System.Windows.Forms.Label();
            this.cboFilterSubject = new System.Windows.Forms.ComboBox();
            this.lblFilterSubject = new System.Windows.Forms.Label();
            this.cboFilterClass = new System.Windows.Forms.ComboBox();
            this.lblFilterClass = new System.Windows.Forms.Label();
            this.cboFilterSemester = new System.Windows.Forms.ComboBox();
            this.lblFilterSemester = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.btnSaveGrade = new System.Windows.Forms.Button();
            this.lblIsPassedVal = new System.Windows.Forms.Label();
            this.lblIsPassed = new System.Windows.Forms.Label();
            this.lblRankVal = new System.Windows.Forms.Label();
            this.lblRank = new System.Windows.Forms.Label();
            this.lblTotalScoreVal = new System.Windows.Forms.Label();
            this.lblTotalScore = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.numFinalScore = new System.Windows.Forms.NumericUpDown();
            this.lblFinalScore = new System.Windows.Forms.Label();
            this.numMidtermScore = new System.Windows.Forms.NumericUpDown();
            this.lblMidtermScore = new System.Windows.Forms.Label();
            this.lblSelectedSubject = new System.Windows.Forms.Label();
            this.lblSelectedStudent = new System.Windows.Forms.Label();
            this.lblInputHeader = new System.Windows.Forms.Label();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.pnlTranscriptSummary = new System.Windows.Forms.Panel();
            this.lblCumulativeGPA = new System.Windows.Forms.Label();
            this.lblTotalCreditsEarned = new System.Windows.Forms.Label();
            this.lblSemesterGPA = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFinalScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMidtermScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.pnlTranscriptSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnExportExcel);
            this.pnlTop.Controls.Add(this.btnFilter);
            this.pnlTop.Controls.Add(this.txtSearchStudent);
            this.pnlTop.Controls.Add(this.lblSearchStudent);
            this.pnlTop.Controls.Add(this.cboFilterSubject);
            this.pnlTop.Controls.Add(this.lblFilterSubject);
            this.pnlTop.Controls.Add(this.cboFilterClass);
            this.pnlTop.Controls.Add(this.lblFilterClass);
            this.pnlTop.Controls.Add(this.cboFilterSemester);
            this.pnlTop.Controls.Add(this.lblFilterSemester);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlTop.Size = new System.Drawing.Size(1080, 70);
            this.pnlTop.TabIndex = 0;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(955, 30);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(113, 30);
            this.btnExportExcel.TabIndex = 9;
            this.btnExportExcel.Text = "📥 Xuất bảng điểm";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(825, 30);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(80, 30);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "🔍 Lọc";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtSearchStudent
            // 
            this.txtSearchStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearchStudent.Location = new System.Drawing.Point(625, 33);
            this.txtSearchStudent.Name = "txtSearchStudent";
            this.txtSearchStudent.PlaceholderText = "Nhập Mã SV / Tên SV...";
            this.txtSearchStudent.Size = new System.Drawing.Size(190, 24);
            this.txtSearchStudent.TabIndex = 7;
            this.txtSearchStudent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchStudent_KeyDown);
            // 
            // lblSearchStudent
            // 
            this.lblSearchStudent.AutoSize = true;
            this.lblSearchStudent.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSearchStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSearchStudent.Location = new System.Drawing.Point(625, 12);
            this.lblSearchStudent.Name = "lblSearchStudent";
            this.lblSearchStudent.Size = new System.Drawing.Size(107, 15);
            this.lblSearchStudent.TabIndex = 6;
            this.lblSearchStudent.Text = "Tìm theo sinh viên:";
            // 
            // cboFilterSubject
            // 
            this.cboFilterSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterSubject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFilterSubject.FormattingEnabled = true;
            this.cboFilterSubject.Location = new System.Drawing.Point(405, 33);
            this.cboFilterSubject.Name = "cboFilterSubject";
            this.cboFilterSubject.Size = new System.Drawing.Size(210, 23);
            this.cboFilterSubject.TabIndex = 5;
            this.cboFilterSubject.SelectedIndexChanged += new System.EventHandler(this.Filter_SelectedIndexChanged);
            // 
            // lblFilterSubject
            // 
            this.lblFilterSubject.AutoSize = true;
            this.lblFilterSubject.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFilterSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblFilterSubject.Location = new System.Drawing.Point(405, 12);
            this.lblFilterSubject.Name = "lblFilterSubject";
            this.lblFilterSubject.Size = new System.Drawing.Size(58, 15);
            this.lblFilterSubject.TabIndex = 4;
            this.lblFilterSubject.Text = "Môn học:";
            // 
            // cboFilterClass
            // 
            this.cboFilterClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFilterClass.FormattingEnabled = true;
            this.cboFilterClass.Location = new System.Drawing.Point(225, 33);
            this.cboFilterClass.Name = "cboFilterClass";
            this.cboFilterClass.Size = new System.Drawing.Size(170, 23);
            this.cboFilterClass.TabIndex = 3;
            this.cboFilterClass.SelectedIndexChanged += new System.EventHandler(this.Filter_SelectedIndexChanged);
            // 
            // lblFilterClass
            // 
            this.lblFilterClass.AutoSize = true;
            this.lblFilterClass.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFilterClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblFilterClass.Location = new System.Drawing.Point(225, 12);
            this.lblFilterClass.Name = "lblFilterClass";
            this.lblFilterClass.Size = new System.Drawing.Size(53, 15);
            this.lblFilterClass.TabIndex = 2;
            this.lblFilterClass.Text = "Lớp học:";
            // 
            // cboFilterSemester
            // 
            this.cboFilterSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterSemester.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFilterSemester.FormattingEnabled = true;
            this.cboFilterSemester.Location = new System.Drawing.Point(12, 33);
            this.cboFilterSemester.Name = "cboFilterSemester";
            this.cboFilterSemester.Size = new System.Drawing.Size(200, 23);
            this.cboFilterSemester.TabIndex = 1;
            this.cboFilterSemester.SelectedIndexChanged += new System.EventHandler(this.Filter_SelectedIndexChanged);
            // 
            // lblFilterSemester
            // 
            this.lblFilterSemester.AutoSize = true;
            this.lblFilterSemester.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFilterSemester.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblFilterSemester.Location = new System.Drawing.Point(12, 12);
            this.lblFilterSemester.Name = "lblFilterSemester";
            this.lblFilterSemester.Size = new System.Drawing.Size(49, 15);
            this.lblFilterSemester.TabIndex = 0;
            this.lblFilterSemester.Text = "Học kỳ:";
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 70);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.pnlInput);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.dgvGrades);
            this.splitMain.Panel2.Controls.Add(this.pnlTranscriptSummary);
            this.splitMain.Size = new System.Drawing.Size(1080, 580);
            this.splitMain.SplitterDistance = 330;
            this.splitMain.TabIndex = 1;
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInput.Controls.Add(this.btnSaveGrade);
            this.pnlInput.Controls.Add(this.lblIsPassedVal);
            this.pnlInput.Controls.Add(this.lblIsPassed);
            this.pnlInput.Controls.Add(this.lblRankVal);
            this.pnlInput.Controls.Add(this.lblRank);
            this.pnlInput.Controls.Add(this.lblTotalScoreVal);
            this.pnlInput.Controls.Add(this.lblTotalScore);
            this.pnlInput.Controls.Add(this.txtNotes);
            this.pnlInput.Controls.Add(this.lblNotes);
            this.pnlInput.Controls.Add(this.numFinalScore);
            this.pnlInput.Controls.Add(this.lblFinalScore);
            this.pnlInput.Controls.Add(this.numMidtermScore);
            this.pnlInput.Controls.Add(this.lblMidtermScore);
            this.pnlInput.Controls.Add(this.lblSelectedSubject);
            this.pnlInput.Controls.Add(this.lblSelectedStudent);
            this.pnlInput.Controls.Add(this.lblInputHeader);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Padding = new System.Windows.Forms.Padding(12);
            this.pnlInput.Size = new System.Drawing.Size(330, 580);
            this.pnlInput.TabIndex = 0;
            // 
            // btnSaveGrade
            // 
            this.btnSaveGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnSaveGrade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveGrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveGrade.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveGrade.ForeColor = System.Drawing.Color.White;
            this.btnSaveGrade.Location = new System.Drawing.Point(12, 440);
            this.btnSaveGrade.Name = "btnSaveGrade";
            this.btnSaveGrade.Size = new System.Drawing.Size(302, 38);
            this.btnSaveGrade.TabIndex = 15;
            this.btnSaveGrade.Text = "💾 LƯU KẾT QUẢ ĐIỂM";
            this.btnSaveGrade.UseVisualStyleBackColor = false;
            this.btnSaveGrade.Click += new System.EventHandler(this.btnSaveGrade_Click);
            // 
            // lblIsPassedVal
            // 
            this.lblIsPassedVal.AutoSize = true;
            this.lblIsPassedVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblIsPassedVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblIsPassedVal.Location = new System.Drawing.Point(120, 395);
            this.lblIsPassedVal.Name = "lblIsPassedVal";
            this.lblIsPassedVal.Size = new System.Drawing.Size(18, 17);
            this.lblIsPassedVal.TabIndex = 14;
            this.lblIsPassedVal.Text = "--";
            // 
            // lblIsPassed
            // 
            this.lblIsPassed.AutoSize = true;
            this.lblIsPassed.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblIsPassed.Location = new System.Drawing.Point(12, 395);
            this.lblIsPassed.Name = "lblIsPassed";
            this.lblIsPassed.Size = new System.Drawing.Size(59, 15);
            this.lblIsPassed.TabIndex = 13;
            this.lblIsPassed.Text = "Kết luận:";
            // 
            // lblRankVal
            // 
            this.lblRankVal.AutoSize = true;
            this.lblRankVal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRankVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblRankVal.Location = new System.Drawing.Point(120, 365);
            this.lblRankVal.Name = "lblRankVal";
            this.lblRankVal.Size = new System.Drawing.Size(18, 17);
            this.lblRankVal.TabIndex = 12;
            this.lblRankVal.Text = "--";
            // 
            // lblRank
            // 
            this.lblRank.AutoSize = true;
            this.lblRank.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRank.Location = new System.Drawing.Point(12, 365);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(57, 15);
            this.lblRank.TabIndex = 11;
            this.lblRank.Text = "Xếp loại:";
            // 
            // lblTotalScoreVal
            // 
            this.lblTotalScoreVal.AutoSize = true;
            this.lblTotalScoreVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalScoreVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTotalScoreVal.Location = new System.Drawing.Point(120, 330);
            this.lblTotalScoreVal.Name = "lblTotalScoreVal";
            this.lblTotalScoreVal.Size = new System.Drawing.Size(22, 21);
            this.lblTotalScoreVal.TabIndex = 10;
            this.lblTotalScoreVal.Text = "--";
            // 
            // lblTotalScore
            // 
            this.lblTotalScore.AutoSize = true;
            this.lblTotalScore.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalScore.Location = new System.Drawing.Point(12, 335);
            this.lblTotalScore.Name = "lblTotalScore";
            this.lblTotalScore.Size = new System.Drawing.Size(89, 15);
            this.lblTotalScore.TabIndex = 9;
            this.lblTotalScore.Text = "Điểm tổng kết:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNotes.Location = new System.Drawing.Point(12, 280);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(302, 24);
            this.txtNotes.TabIndex = 8;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNotes.Location = new System.Drawing.Point(12, 260);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(53, 15);
            this.lblNotes.TabIndex = 7;
            this.lblNotes.Text = "Ghi chú:";
            // 
            // numFinalScore
            // 
            this.numFinalScore.DecimalPlaces = 2;
            this.numFinalScore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numFinalScore.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numFinalScore.Location = new System.Drawing.Point(170, 215);
            this.numFinalScore.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFinalScore.Name = "numFinalScore";
            this.numFinalScore.Size = new System.Drawing.Size(144, 25);
            this.numFinalScore.TabIndex = 6;
            this.numFinalScore.ValueChanged += new System.EventHandler(this.ScoreInput_ValueChanged);
            // 
            // lblFinalScore
            // 
            this.lblFinalScore.AutoSize = true;
            this.lblFinalScore.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFinalScore.Location = new System.Drawing.Point(170, 195);
            this.lblFinalScore.Name = "lblFinalScore";
            this.lblFinalScore.Size = new System.Drawing.Size(91, 15);
            this.lblFinalScore.TabIndex = 5;
            this.lblFinalScore.Text = "Điểm thi (0-10):";
            // 
            // numMidtermScore
            // 
            this.numMidtermScore.DecimalPlaces = 2;
            this.numMidtermScore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numMidtermScore.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numMidtermScore.Location = new System.Drawing.Point(12, 215);
            this.numMidtermScore.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMidtermScore.Name = "numMidtermScore";
            this.numMidtermScore.Size = new System.Drawing.Size(140, 25);
            this.numMidtermScore.TabIndex = 4;
            this.numMidtermScore.ValueChanged += new System.EventHandler(this.ScoreInput_ValueChanged);
            // 
            // lblMidtermScore
            // 
            this.lblMidtermScore.AutoSize = true;
            this.lblMidtermScore.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMidtermScore.Location = new System.Drawing.Point(12, 195);
            this.lblMidtermScore.Name = "lblMidtermScore";
            this.lblMidtermScore.Size = new System.Drawing.Size(126, 15);
            this.lblMidtermScore.TabIndex = 3;
            this.lblMidtermScore.Text = "Điểm quá trình (0-10):";
            // 
            // lblSelectedSubject
            // 
            this.lblSelectedSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.lblSelectedSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedSubject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSelectedSubject.Location = new System.Drawing.Point(12, 120);
            this.lblSelectedSubject.Name = "lblSelectedSubject";
            this.lblSelectedSubject.Padding = new System.Windows.Forms.Padding(6);
            this.lblSelectedSubject.Size = new System.Drawing.Size(302, 55);
            this.lblSelectedSubject.TabIndex = 2;
            this.lblSelectedSubject.Text = "Môn học: (Chưa chọn)";
            // 
            // lblSelectedStudent
            // 
            this.lblSelectedStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.lblSelectedStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSelectedStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblSelectedStudent.Location = new System.Drawing.Point(12, 50);
            this.lblSelectedStudent.Name = "lblSelectedStudent";
            this.lblSelectedStudent.Padding = new System.Windows.Forms.Padding(6);
            this.lblSelectedStudent.Size = new System.Drawing.Size(302, 60);
            this.lblSelectedStudent.TabIndex = 1;
            this.lblSelectedStudent.Text = "Sinh viên: (Chọn một dòng trong bảng)";
            // 
            // lblInputHeader
            // 
            this.lblInputHeader.AutoSize = true;
            this.lblInputHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblInputHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblInputHeader.Location = new System.Drawing.Point(12, 12);
            this.lblInputHeader.Name = "lblInputHeader";
            this.lblInputHeader.Size = new System.Drawing.Size(183, 21);
            this.lblInputHeader.TabIndex = 0;
            this.lblInputHeader.Text = "NHẬP / XEM ĐIỂM SỐ";
            // 
            // dgvGrades
            // 
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrades.Location = new System.Drawing.Point(0, 0);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.Size = new System.Drawing.Size(746, 520);
            this.dgvGrades.TabIndex = 0;
            this.dgvGrades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrades_CellClick);
            // 
            // pnlTranscriptSummary
            // 
            this.pnlTranscriptSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlTranscriptSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTranscriptSummary.Controls.Add(this.lblCumulativeGPA);
            this.pnlTranscriptSummary.Controls.Add(this.lblTotalCreditsEarned);
            this.pnlTranscriptSummary.Controls.Add(this.lblSemesterGPA);
            this.pnlTranscriptSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTranscriptSummary.Location = new System.Drawing.Point(0, 520);
            this.pnlTranscriptSummary.Name = "pnlTranscriptSummary";
            this.pnlTranscriptSummary.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlTranscriptSummary.Size = new System.Drawing.Size(746, 60);
            this.pnlTranscriptSummary.TabIndex = 1;
            // 
            // lblCumulativeGPA
            // 
            this.lblCumulativeGPA.AutoSize = true;
            this.lblCumulativeGPA.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCumulativeGPA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.lblCumulativeGPA.Location = new System.Drawing.Point(460, 20);
            this.lblCumulativeGPA.Name = "lblCumulativeGPA";
            this.lblCumulativeGPA.Size = new System.Drawing.Size(183, 19);
            this.lblCumulativeGPA.TabIndex = 2;
            this.lblCumulativeGPA.Text = "GPA tích lũy: 0.00 (Hệ 4: 0.0)";
            // 
            // lblTotalCreditsEarned
            // 
            this.lblTotalCreditsEarned.AutoSize = true;
            this.lblTotalCreditsEarned.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalCreditsEarned.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTotalCreditsEarned.Location = new System.Drawing.Point(240, 20);
            this.lblTotalCreditsEarned.Name = "lblTotalCreditsEarned";
            this.lblTotalCreditsEarned.Size = new System.Drawing.Size(175, 19);
            this.lblTotalCreditsEarned.TabIndex = 1;
            this.lblTotalCreditsEarned.Text = "Số tín chỉ tích lũy: 0 / 0 TC";
            // 
            // lblSemesterGPA
            // 
            this.lblSemesterGPA.AutoSize = true;
            this.lblSemesterGPA.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSemesterGPA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblSemesterGPA.Location = new System.Drawing.Point(12, 20);
            this.lblSemesterGPA.Name = "lblSemesterGPA";
            this.lblSemesterGPA.Size = new System.Drawing.Size(174, 19);
            this.lblSemesterGPA.TabIndex = 0;
            this.lblSemesterGPA.Text = "GPA học kỳ: 0.00 (Hệ 4: 0.0)";
            // 
            // FrmGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1080, 650);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FrmGrade";
            this.Text = "Quản lý Điểm & Kết quả học tập";
            this.Load += new System.EventHandler(this.FrmGrade_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFinalScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMidtermScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.pnlTranscriptSummary.ResumeLayout(false);
            this.pnlTranscriptSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblFilterSemester;
        private System.Windows.Forms.ComboBox cboFilterSemester;
        private System.Windows.Forms.Label lblFilterClass;
        private System.Windows.Forms.ComboBox cboFilterClass;
        private System.Windows.Forms.Label lblFilterSubject;
        private System.Windows.Forms.ComboBox cboFilterSubject;
        private System.Windows.Forms.Label lblSearchStudent;
        private System.Windows.Forms.TextBox txtSearchStudent;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblInputHeader;
        private System.Windows.Forms.Label lblSelectedStudent;
        private System.Windows.Forms.Label lblSelectedSubject;
        private System.Windows.Forms.Label lblMidtermScore;
        private System.Windows.Forms.NumericUpDown numMidtermScore;
        private System.Windows.Forms.Label lblFinalScore;
        private System.Windows.Forms.NumericUpDown numFinalScore;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblTotalScore;
        private System.Windows.Forms.Label lblTotalScoreVal;
        private System.Windows.Forms.Label lblRank;
        private System.Windows.Forms.Label lblRankVal;
        private System.Windows.Forms.Label lblIsPassed;
        private System.Windows.Forms.Label lblIsPassedVal;
        private System.Windows.Forms.Button btnSaveGrade;
        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.Panel pnlTranscriptSummary;
        private System.Windows.Forms.Label lblSemesterGPA;
        private System.Windows.Forms.Label lblTotalCreditsEarned;
        private System.Windows.Forms.Label lblCumulativeGPA;
    }
}
