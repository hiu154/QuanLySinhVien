namespace QuanLySinhVien.Forms
{

    partial class FrmStatistics
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

            this.pnlKpi = new System.Windows.Forms.Panel();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlCardScore = new System.Windows.Forms.Panel();
            this.lblCardScoreVal = new System.Windows.Forms.Label();
            this.lblCardScoreTitle = new System.Windows.Forms.Label();
            this.pnlCardSubjects = new System.Windows.Forms.Panel();
            this.lblCardSubjectsVal = new System.Windows.Forms.Label();
            this.lblCardSubjectsTitle = new System.Windows.Forms.Label();
            this.pnlCardClasses = new System.Windows.Forms.Panel();
            this.lblCardClassesVal = new System.Windows.Forms.Label();
            this.lblCardClassesTitle = new System.Windows.Forms.Label();
            this.pnlCardDepts = new System.Windows.Forms.Panel();
            this.lblCardDeptsVal = new System.Windows.Forms.Label();
            this.lblCardDeptsTitle = new System.Windows.Forms.Label();
            this.pnlCardStudents = new System.Windows.Forms.Panel();
            this.lblCardStudentsVal = new System.Windows.Forms.Label();
            this.lblCardStudentsTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabWarning = new System.Windows.Forms.TabPage();
            this.dgvWarning = new System.Windows.Forms.DataGridView();
            this.pnlWarningTop = new System.Windows.Forms.Panel();
            this.btnExportWarning = new System.Windows.Forms.Button();
            this.numWarningThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.lblWarningNote = new System.Windows.Forms.Label();
            this.tabGPA = new System.Windows.Forms.TabPage();
            this.dgvStudentGPA = new System.Windows.Forms.DataGridView();
            this.pnlGpaTop = new System.Windows.Forms.Panel();
            this.btnExportGPA = new System.Windows.Forms.Button();
            this.lblGpaTitle = new System.Windows.Forms.Label();
            this.tabDistribution = new System.Windows.Forms.TabPage();
            this.splitDistribution = new System.Windows.Forms.SplitContainer();
            this.dgvDeptStats = new System.Windows.Forms.DataGridView();
            this.lblDeptStatsTitle = new System.Windows.Forms.Label();
            this.dgvStatusStats = new System.Windows.Forms.DataGridView();
            this.lblStatusStatsTitle = new System.Windows.Forms.Label();
            this.pnlKpi.SuspendLayout();
            this.pnlCardScore.SuspendLayout();
            this.pnlCardSubjects.SuspendLayout();
            this.pnlCardClasses.SuspendLayout();
            this.pnlCardDepts.SuspendLayout();
            this.pnlCardStudents.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabWarning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarning)).BeginInit();
            this.pnlWarningTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWarningThreshold)).BeginInit();
            this.tabGPA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentGPA)).BeginInit();
            this.pnlGpaTop.SuspendLayout();
            this.tabDistribution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDistribution)).BeginInit();
            this.splitDistribution.Panel1.SuspendLayout();
            this.splitDistribution.Panel2.SuspendLayout();
            this.splitDistribution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusStats)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlKpi
            // 
            this.pnlKpi.BackColor = System.Drawing.Color.White;
            this.pnlKpi.Controls.Add(this.btnExportReport);
            this.pnlKpi.Controls.Add(this.btnRefresh);
            this.pnlKpi.Controls.Add(this.pnlCardScore);
            this.pnlKpi.Controls.Add(this.pnlCardSubjects);
            this.pnlKpi.Controls.Add(this.pnlCardClasses);
            this.pnlKpi.Controls.Add(this.pnlCardDepts);
            this.pnlKpi.Controls.Add(this.pnlCardStudents);
            this.pnlKpi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi.Name = "pnlKpi";
            this.pnlKpi.Padding = new System.Windows.Forms.Padding(12);
            this.pnlKpi.Size = new System.Drawing.Size(1080, 110);
            this.pnlKpi.TabIndex = 0;
            // 
            // btnExportReport
            // 
            this.btnExportReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExportReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportReport.ForeColor = System.Drawing.Color.White;
            this.btnExportReport.Location = new System.Drawing.Point(945, 55);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(123, 35);
            this.btnExportReport.TabIndex = 6;
            this.btnExportReport.Text = "Xuất Excel";
            this.btnExportReport.UseVisualStyleBackColor = false;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(945, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(123, 35);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlCardScore
            // 
            this.pnlCardScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(231)))));
            this.pnlCardScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardScore.Controls.Add(this.lblCardScoreVal);
            this.pnlCardScore.Controls.Add(this.lblCardScoreTitle);
            this.pnlCardScore.Location = new System.Drawing.Point(740, 14);
            this.pnlCardScore.Name = "pnlCardScore";
            this.pnlCardScore.Padding = new System.Windows.Forms.Padding(8);
            this.pnlCardScore.Size = new System.Drawing.Size(175, 80);
            this.pnlCardScore.TabIndex = 4;
            // 
            // lblCardScoreVal
            // 
            this.lblCardScoreVal.AutoSize = true;
            this.lblCardScoreVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardScoreVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(137)))), ((int)(((byte)(16)))));
            this.lblCardScoreVal.Location = new System.Drawing.Point(8, 35);
            this.lblCardScoreVal.Name = "lblCardScoreVal";
            this.lblCardScoreVal.Size = new System.Drawing.Size(58, 30);
            this.lblCardScoreVal.TabIndex = 1;
            this.lblCardScoreVal.Text = "0.00";
            // 
            // lblCardScoreTitle
            // 
            this.lblCardScoreTitle.AutoSize = true;
            this.lblCardScoreTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardScoreTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblCardScoreTitle.Location = new System.Drawing.Point(8, 10);
            this.lblCardScoreTitle.Name = "lblCardScoreTitle";
            this.lblCardScoreTitle.Size = new System.Drawing.Size(89, 15);
            this.lblCardScoreTitle.TabIndex = 0;
            this.lblCardScoreTitle.Text = "ĐIỂM TB TOÀN";
            // 
            // pnlCardSubjects
            // 
            this.pnlCardSubjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.pnlCardSubjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardSubjects.Controls.Add(this.lblCardSubjectsVal);
            this.pnlCardSubjects.Controls.Add(this.lblCardSubjectsTitle);
            this.pnlCardSubjects.Location = new System.Drawing.Point(555, 14);
            this.pnlCardSubjects.Name = "pnlCardSubjects";
            this.pnlCardSubjects.Padding = new System.Windows.Forms.Padding(8);
            this.pnlCardSubjects.Size = new System.Drawing.Size(175, 80);
            this.pnlCardSubjects.TabIndex = 3;
            // 
            // lblCardSubjectsVal
            // 
            this.lblCardSubjectsVal.AutoSize = true;
            this.lblCardSubjectsVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardSubjectsVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.lblCardSubjectsVal.Location = new System.Drawing.Point(8, 35);
            this.lblCardSubjectsVal.Name = "lblCardSubjectsVal";
            this.lblCardSubjectsVal.Size = new System.Drawing.Size(26, 30);
            this.lblCardSubjectsVal.TabIndex = 1;
            this.lblCardSubjectsVal.Text = "0";
            // 
            // lblCardSubjectsTitle
            // 
            this.lblCardSubjectsTitle.AutoSize = true;
            this.lblCardSubjectsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardSubjectsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblCardSubjectsTitle.Location = new System.Drawing.Point(8, 10);
            this.lblCardSubjectsTitle.Name = "lblCardSubjectsTitle";
            this.lblCardSubjectsTitle.Size = new System.Drawing.Size(102, 15);
            this.lblCardSubjectsTitle.TabIndex = 0;
            this.lblCardSubjectsTitle.Text = "TỔNG MÔN HỌC";
            // 
            // pnlCardClasses
            // 
            this.pnlCardClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(250)))), ((int)(((byte)(234)))));
            this.pnlCardClasses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardClasses.Controls.Add(this.lblCardClassesVal);
            this.pnlCardClasses.Controls.Add(this.lblCardClassesTitle);
            this.pnlCardClasses.Location = new System.Drawing.Point(370, 14);
            this.pnlCardClasses.Name = "pnlCardClasses";
            this.pnlCardClasses.Padding = new System.Windows.Forms.Padding(8);
            this.pnlCardClasses.Size = new System.Drawing.Size(175, 80);
            this.pnlCardClasses.TabIndex = 2;
            // 
            // lblCardClassesVal
            // 
            this.lblCardClassesVal.AutoSize = true;
            this.lblCardClassesVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardClassesVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblCardClassesVal.Location = new System.Drawing.Point(8, 35);
            this.lblCardClassesVal.Name = "lblCardClassesVal";
            this.lblCardClassesVal.Size = new System.Drawing.Size(26, 30);
            this.lblCardClassesVal.TabIndex = 1;
            this.lblCardClassesVal.Text = "0";
            // 
            // lblCardClassesTitle
            // 
            this.lblCardClassesTitle.AutoSize = true;
            this.lblCardClassesTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardClassesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblCardClassesTitle.Location = new System.Drawing.Point(8, 10);
            this.lblCardClassesTitle.Name = "lblCardClassesTitle";
            this.lblCardClassesTitle.Size = new System.Drawing.Size(95, 15);
            this.lblCardClassesTitle.TabIndex = 0;
            this.lblCardClassesTitle.Text = "TỔNG LỚP HỌC";
            // 
            // pnlCardDepts
            // 
            this.pnlCardDepts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.pnlCardDepts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardDepts.Controls.Add(this.lblCardDeptsVal);
            this.pnlCardDepts.Controls.Add(this.lblCardDeptsTitle);
            this.pnlCardDepts.Location = new System.Drawing.Point(185, 14);
            this.pnlCardDepts.Name = "pnlCardDepts";
            this.pnlCardDepts.Padding = new System.Windows.Forms.Padding(8);
            this.pnlCardDepts.Size = new System.Drawing.Size(175, 80);
            this.pnlCardDepts.TabIndex = 1;
            // 
            // lblCardDeptsVal
            // 
            this.lblCardDeptsVal.AutoSize = true;
            this.lblCardDeptsVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardDeptsVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblCardDeptsVal.Location = new System.Drawing.Point(8, 35);
            this.lblCardDeptsVal.Name = "lblCardDeptsVal";
            this.lblCardDeptsVal.Size = new System.Drawing.Size(26, 30);
            this.lblCardDeptsVal.TabIndex = 1;
            this.lblCardDeptsVal.Text = "0";
            // 
            // lblCardDeptsTitle
            // 
            this.lblCardDeptsTitle.AutoSize = true;
            this.lblCardDeptsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardDeptsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblCardDeptsTitle.Location = new System.Drawing.Point(8, 10);
            this.lblCardDeptsTitle.Name = "lblCardDeptsTitle";
            this.lblCardDeptsTitle.Size = new System.Drawing.Size(81, 15);
            this.lblCardDeptsTitle.TabIndex = 0;
            this.lblCardDeptsTitle.Text = "TỔNG KHOA";
            // 
            // pnlCardStudents
            // 
            this.pnlCardStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.pnlCardStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardStudents.Controls.Add(this.lblCardStudentsVal);
            this.pnlCardStudents.Controls.Add(this.lblCardStudentsTitle);
            this.pnlCardStudents.Location = new System.Drawing.Point(12, 14);
            this.pnlCardStudents.Name = "pnlCardStudents";
            this.pnlCardStudents.Padding = new System.Windows.Forms.Padding(8);
            this.pnlCardStudents.Size = new System.Drawing.Size(165, 80);
            this.pnlCardStudents.TabIndex = 0;
            // 
            // lblCardStudentsVal
            // 
            this.lblCardStudentsVal.AutoSize = true;
            this.lblCardStudentsVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardStudentsVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblCardStudentsVal.Location = new System.Drawing.Point(8, 35);
            this.lblCardStudentsVal.Name = "lblCardStudentsVal";
            this.lblCardStudentsVal.Size = new System.Drawing.Size(26, 30);
            this.lblCardStudentsVal.TabIndex = 1;
            this.lblCardStudentsVal.Text = "0";
            // 
            // lblCardStudentsTitle
            // 
            this.lblCardStudentsTitle.AutoSize = true;
            this.lblCardStudentsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardStudentsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblCardStudentsTitle.Location = new System.Drawing.Point(8, 10);
            this.lblCardStudentsTitle.Name = "lblCardStudentsTitle";
            this.lblCardStudentsTitle.Size = new System.Drawing.Size(107, 15);
            this.lblCardStudentsTitle.TabIndex = 0;
            this.lblCardStudentsTitle.Text = "TỔNG SINH VIÊN";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabWarning);
            this.tabControl.Controls.Add(this.tabGPA);
            this.tabControl.Controls.Add(this.tabDistribution);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 110);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1080, 540);
            this.tabControl.TabIndex = 1;
            // 
            // tabWarning
            // 
            this.tabWarning.Controls.Add(this.dgvWarning);
            this.tabWarning.Controls.Add(this.pnlWarningTop);
            this.tabWarning.Location = new System.Drawing.Point(4, 26);
            this.tabWarning.Name = "tabWarning";
            this.tabWarning.Padding = new System.Windows.Forms.Padding(10);
            this.tabWarning.Size = new System.Drawing.Size(1072, 510);
            this.tabWarning.TabIndex = 0;
            this.tabWarning.Text = "Cảnh báo Học vụ (Điểm thấp / Rớt môn)";
            this.tabWarning.UseVisualStyleBackColor = true;
            // 
            // dgvWarning
            // 
            this.dgvWarning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWarning.Location = new System.Drawing.Point(10, 60);
            this.dgvWarning.Name = "dgvWarning";
            this.dgvWarning.Size = new System.Drawing.Size(1052, 440);
            this.dgvWarning.TabIndex = 1;
            // 
            // pnlWarningTop
            // 
            this.pnlWarningTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(237)))), ((int)(((byte)(236)))));
            this.pnlWarningTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWarningTop.Controls.Add(this.btnExportWarning);
            this.pnlWarningTop.Controls.Add(this.numWarningThreshold);
            this.pnlWarningTop.Controls.Add(this.lblThreshold);
            this.pnlWarningTop.Controls.Add(this.lblWarningNote);
            this.pnlWarningTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWarningTop.Location = new System.Drawing.Point(10, 10);
            this.pnlWarningTop.Name = "pnlWarningTop";
            this.pnlWarningTop.Padding = new System.Windows.Forms.Padding(8);
            this.pnlWarningTop.Size = new System.Drawing.Size(1052, 50);
            this.pnlWarningTop.TabIndex = 0;
            // 
            // btnExportWarning
            // 
            this.btnExportWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnExportWarning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportWarning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportWarning.ForeColor = System.Drawing.Color.White;
            this.btnExportWarning.Location = new System.Drawing.Point(895, 9);
            this.btnExportWarning.Name = "btnExportWarning";
            this.btnExportWarning.Size = new System.Drawing.Size(148, 30);
            this.btnExportWarning.TabIndex = 3;
            this.btnExportWarning.Text = "Xuất DS Cảnh báo";
            this.btnExportWarning.UseVisualStyleBackColor = false;
            this.btnExportWarning.Click += new System.EventHandler(this.btnExportWarning_Click);
            // 
            // numWarningThreshold
            // 
            this.numWarningThreshold.DecimalPlaces = 1;
            this.numWarningThreshold.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numWarningThreshold.Increment = new decimal(new int[] {

            5,
            0,
            0,
            65536});
            this.numWarningThreshold.Location = new System.Drawing.Point(620, 12);
            this.numWarningThreshold.Maximum = new decimal(new int[] {

            10,
            0,
            0,
            0});
            this.numWarningThreshold.Name = "numWarningThreshold";
            this.numWarningThreshold.Size = new System.Drawing.Size(70, 24);
            this.numWarningThreshold.TabIndex = 2;
            this.numWarningThreshold.Value = new decimal(new int[] {

            5,
            0,
            0,
            0});
            this.numWarningThreshold.ValueChanged += new System.EventHandler(this.numWarningThreshold_ValueChanged);
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThreshold.Location = new System.Drawing.Point(440, 16);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(170, 15);
            this.lblThreshold.TabIndex = 1;
            this.lblThreshold.Text = "Ngưỡng điểm cảnh báo ( < ):";
            // 
            // lblWarningNote
            // 
            this.lblWarningNote.AutoSize = true;
            this.lblWarningNote.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblWarningNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblWarningNote.Location = new System.Drawing.Point(10, 14);
            this.lblWarningNote.Name = "lblWarningNote";
            this.lblWarningNote.Size = new System.Drawing.Size(395, 17);
            this.lblWarningNote.TabIndex = 0;
            this.lblWarningNote.Text = "Danh sách sinh viên có môn học có điểm tổng kết dưới chuẩn:";
            // 
            // tabGPA
            // 
            this.tabGPA.Controls.Add(this.dgvStudentGPA);
            this.tabGPA.Controls.Add(this.pnlGpaTop);
            this.tabGPA.Location = new System.Drawing.Point(4, 26);
            this.tabGPA.Name = "tabGPA";
            this.tabGPA.Padding = new System.Windows.Forms.Padding(10);
            this.tabGPA.Size = new System.Drawing.Size(1072, 510);
            this.tabGPA.TabIndex = 1;
            this.tabGPA.Text = "Bảng Tổng kết GPA & Xếp loại";
            this.tabGPA.UseVisualStyleBackColor = true;
            // 
            // dgvStudentGPA
            // 
            this.dgvStudentGPA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentGPA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudentGPA.Location = new System.Drawing.Point(10, 60);
            this.dgvStudentGPA.Name = "dgvStudentGPA";
            this.dgvStudentGPA.Size = new System.Drawing.Size(1052, 440);
            this.dgvStudentGPA.TabIndex = 1;
            // 
            // pnlGpaTop
            // 
            this.pnlGpaTop.BackColor = System.Drawing.Color.White;
            this.pnlGpaTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGpaTop.Controls.Add(this.btnExportGPA);
            this.pnlGpaTop.Controls.Add(this.lblGpaTitle);
            this.pnlGpaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGpaTop.Location = new System.Drawing.Point(10, 10);
            this.pnlGpaTop.Name = "pnlGpaTop";
            this.pnlGpaTop.Padding = new System.Windows.Forms.Padding(8);
            this.pnlGpaTop.Size = new System.Drawing.Size(1052, 50);
            this.pnlGpaTop.TabIndex = 0;
            // 
            // btnExportGPA
            // 
            this.btnExportGPA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportGPA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExportGPA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportGPA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportGPA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportGPA.ForeColor = System.Drawing.Color.White;
            this.btnExportGPA.Location = new System.Drawing.Point(895, 9);
            this.btnExportGPA.Name = "btnExportGPA";
            this.btnExportGPA.Size = new System.Drawing.Size(148, 30);
            this.btnExportGPA.TabIndex = 1;
            this.btnExportGPA.Text = "Xuất Bảng Điểm GPA";
            this.btnExportGPA.UseVisualStyleBackColor = false;
            this.btnExportGPA.Click += new System.EventHandler(this.btnExportGPA_Click);
            // 
            // lblGpaTitle
            // 
            this.lblGpaTitle.AutoSize = true;
            this.lblGpaTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGpaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblGpaTitle.Location = new System.Drawing.Point(10, 14);
            this.lblGpaTitle.Name = "lblGpaTitle";
            this.lblGpaTitle.Size = new System.Drawing.Size(370, 19);
            this.lblGpaTitle.TabIndex = 0;
            this.lblGpaTitle.Text = "Bảng xếp hạng điểm trung bình tích lũy và xếp loại học lực:";
            // 
            // tabDistribution
            // 
            this.tabDistribution.Controls.Add(this.splitDistribution);
            this.tabDistribution.Location = new System.Drawing.Point(4, 26);
            this.tabDistribution.Name = "tabDistribution";
            this.tabDistribution.Padding = new System.Windows.Forms.Padding(10);
            this.tabDistribution.Size = new System.Drawing.Size(1072, 510);
            this.tabDistribution.TabIndex = 2;
            this.tabDistribution.Text = "Phân bố Sinh viên theo Khoa & Trạng thái";
            this.tabDistribution.UseVisualStyleBackColor = true;
            // 
            // splitDistribution
            // 
            this.splitDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDistribution.Location = new System.Drawing.Point(10, 10);
            this.splitDistribution.Name = "splitDistribution";
            // 
            // splitDistribution.Panel1
            // 
            this.splitDistribution.Panel1.Controls.Add(this.dgvDeptStats);
            this.splitDistribution.Panel1.Controls.Add(this.lblDeptStatsTitle);
            this.splitDistribution.Panel1.Padding = new System.Windows.Forms.Padding(6);
            // 
            // splitDistribution.Panel2
            // 
            this.splitDistribution.Panel2.Controls.Add(this.dgvStatusStats);
            this.splitDistribution.Panel2.Controls.Add(this.lblStatusStatsTitle);
            this.splitDistribution.Panel2.Padding = new System.Windows.Forms.Padding(6);
            this.splitDistribution.Size = new System.Drawing.Size(1052, 490);
            this.splitDistribution.SplitterDistance = 520;
            this.splitDistribution.TabIndex = 0;
            // 
            // dgvDeptStats
            // 
            this.dgvDeptStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeptStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeptStats.Location = new System.Drawing.Point(6, 41);
            this.dgvDeptStats.Name = "dgvDeptStats";
            this.dgvDeptStats.Size = new System.Drawing.Size(508, 443);
            this.dgvDeptStats.TabIndex = 1;
            // 
            // lblDeptStatsTitle
            // 
            this.lblDeptStatsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDeptStatsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDeptStatsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblDeptStatsTitle.Location = new System.Drawing.Point(6, 6);
            this.lblDeptStatsTitle.Name = "lblDeptStatsTitle";
            this.lblDeptStatsTitle.Size = new System.Drawing.Size(508, 35);
            this.lblDeptStatsTitle.TabIndex = 0;
            this.lblDeptStatsTitle.Text = "Số lượng sinh viên theo Khoa:";
            this.lblDeptStatsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvStatusStats
            // 
            this.dgvStatusStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatusStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatusStats.Location = new System.Drawing.Point(6, 41);
            this.dgvStatusStats.Name = "dgvStatusStats";
            this.dgvStatusStats.Size = new System.Drawing.Size(516, 443);
            this.dgvStatusStats.TabIndex = 1;
            // 
            // lblStatusStatsTitle
            // 
            this.lblStatusStatsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatusStatsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusStatsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblStatusStatsTitle.Location = new System.Drawing.Point(6, 6);
            this.lblStatusStatsTitle.Name = "lblStatusStatsTitle";
            this.lblStatusStatsTitle.Size = new System.Drawing.Size(516, 35);
            this.lblStatusStatsTitle.TabIndex = 0;
            this.lblStatusStatsTitle.Text = "Số lượng sinh viên theo Trạng thái:";
            this.lblStatusStatsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1080, 650);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlKpi);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "FrmStatistics";
            this.Text = "Thống kê và Báo cáo";
            this.Load += new System.EventHandler(this.FrmStatistics_Load);
            this.pnlKpi.ResumeLayout(false);
            this.pnlCardScore.ResumeLayout(false);
            this.pnlCardScore.PerformLayout();
            this.pnlCardSubjects.ResumeLayout(false);
            this.pnlCardSubjects.PerformLayout();
            this.pnlCardClasses.ResumeLayout(false);
            this.pnlCardClasses.PerformLayout();
            this.pnlCardDepts.ResumeLayout(false);
            this.pnlCardDepts.PerformLayout();
            this.pnlCardStudents.ResumeLayout(false);
            this.pnlCardStudents.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabWarning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarning)).EndInit();
            this.pnlWarningTop.ResumeLayout(false);
            this.pnlWarningTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWarningThreshold)).EndInit();
            this.tabGPA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentGPA)).EndInit();
            this.pnlGpaTop.ResumeLayout(false);
            this.pnlGpaTop.PerformLayout();
            this.tabDistribution.ResumeLayout(false);
            this.splitDistribution.Panel1.ResumeLayout(false);
            this.splitDistribution.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDistribution)).EndInit();
            this.splitDistribution.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusStats)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlKpi;

        private System.Windows.Forms.Panel pnlCardStudents;

        private System.Windows.Forms.Label lblCardStudentsTitle;

        private System.Windows.Forms.Label lblCardStudentsVal;

        private System.Windows.Forms.Panel pnlCardDepts;

        private System.Windows.Forms.Label lblCardDeptsTitle;

        private System.Windows.Forms.Label lblCardDeptsVal;

        private System.Windows.Forms.Panel pnlCardClasses;

        private System.Windows.Forms.Label lblCardClassesTitle;

        private System.Windows.Forms.Label lblCardClassesVal;

        private System.Windows.Forms.Panel pnlCardSubjects;

        private System.Windows.Forms.Label lblCardSubjectsTitle;

        private System.Windows.Forms.Label lblCardSubjectsVal;

        private System.Windows.Forms.Panel pnlCardScore;

        private System.Windows.Forms.Label lblCardScoreTitle;

        private System.Windows.Forms.Label lblCardScoreVal;

        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.Button btnExportReport;

        private System.Windows.Forms.TabControl tabControl;

        private System.Windows.Forms.TabPage tabWarning;

        private System.Windows.Forms.TabPage tabGPA;

        private System.Windows.Forms.TabPage tabDistribution;

        private System.Windows.Forms.Panel pnlWarningTop;

        private System.Windows.Forms.Label lblWarningNote;

        private System.Windows.Forms.Label lblThreshold;

        private System.Windows.Forms.NumericUpDown numWarningThreshold;

        private System.Windows.Forms.Button btnExportWarning;

        private System.Windows.Forms.DataGridView dgvWarning;

        private System.Windows.Forms.Panel pnlGpaTop;

        private System.Windows.Forms.Label lblGpaTitle;

        private System.Windows.Forms.Button btnExportGPA;

        private System.Windows.Forms.DataGridView dgvStudentGPA;

        private System.Windows.Forms.SplitContainer splitDistribution;

        private System.Windows.Forms.Label lblDeptStatsTitle;

        private System.Windows.Forms.DataGridView dgvDeptStats;

        private System.Windows.Forms.Label lblStatusStatsTitle;

        private System.Windows.Forms.DataGridView dgvStatusStats;
    }

}

