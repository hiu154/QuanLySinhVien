namespace QuanLySinhVien.Forms
{

    partial class FrmSubject
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

            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSubjects = new System.Windows.Forms.TabPage();
            this.splitSubject = new System.Windows.Forms.SplitContainer();
            this.pnlSubjectInput = new System.Windows.Forms.Panel();
            this.btnClearSubject = new System.Windows.Forms.Button();
            this.btnDeleteSubject = new System.Windows.Forms.Button();
            this.btnUpdateSubject = new System.Windows.Forms.Button();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.txtSubjectDesc = new System.Windows.Forms.TextBox();
            this.lblSubjectDesc = new System.Windows.Forms.Label();
            this.numFinalWeight = new System.Windows.Forms.NumericUpDown();
            this.lblFinalWeight = new System.Windows.Forms.Label();
            this.numMidtermWeight = new System.Windows.Forms.NumericUpDown();
            this.lblMidtermWeight = new System.Windows.Forms.Label();
            this.numCredits = new System.Windows.Forms.NumericUpDown();
            this.lblCredits = new System.Windows.Forms.Label();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.lblSubjectName = new System.Windows.Forms.Label();
            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.lblSubjectCode = new System.Windows.Forms.Label();
            this.lblSubjectHeader = new System.Windows.Forms.Label();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.tabSemesters = new System.Windows.Forms.TabPage();
            this.splitSemester = new System.Windows.Forms.SplitContainer();
            this.pnlSemesterInput = new System.Windows.Forms.Panel();
            this.btnSetCurrent = new System.Windows.Forms.Button();
            this.chkIsCurrent = new System.Windows.Forms.CheckBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.txtSchoolYear = new System.Windows.Forms.TextBox();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.txtSemesterName = new System.Windows.Forms.TextBox();
            this.lblSemesterName = new System.Windows.Forms.Label();
            this.txtSemesterID = new System.Windows.Forms.TextBox();
            this.lblSemesterID = new System.Windows.Forms.Label();
            this.lblSemesterHeader = new System.Windows.Forms.Label();
            this.btnClearSemester = new System.Windows.Forms.Button();
            this.btnUpdateSemester = new System.Windows.Forms.Button();
            this.btnAddSemester = new System.Windows.Forms.Button();
            this.dgvSemesters = new System.Windows.Forms.DataGridView();
            this.tabEnrollments = new System.Windows.Forms.TabPage();
            this.pnlEnrollTop = new System.Windows.Forms.Panel();
            this.btnCancelEnroll = new System.Windows.Forms.Button();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.cboEnrollStudent = new System.Windows.Forms.ComboBox();
            this.lblEnrollStudent = new System.Windows.Forms.Label();
            this.cboEnrollSubject = new System.Windows.Forms.ComboBox();
            this.lblEnrollSubject = new System.Windows.Forms.Label();
            this.cboEnrollSemester = new System.Windows.Forms.ComboBox();
            this.lblEnrollSemester = new System.Windows.Forms.Label();
            this.dgvEnrollments = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabSubjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSubject)).BeginInit();
            this.splitSubject.Panel1.SuspendLayout();
            this.splitSubject.Panel2.SuspendLayout();
            this.splitSubject.SuspendLayout();
            this.pnlSubjectInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFinalWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMidtermWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCredits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.tabSemesters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSemester)).BeginInit();
            this.splitSemester.Panel1.SuspendLayout();
            this.splitSemester.Panel2.SuspendLayout();
            this.splitSemester.SuspendLayout();
            this.pnlSemesterInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSemesters)).BeginInit();
            this.tabEnrollments.SuspendLayout();
            this.pnlEnrollTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollments)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSubjects);
            this.tabControl.Controls.Add(this.tabSemesters);
            this.tabControl.Controls.Add(this.tabEnrollments);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1080, 650);
            this.tabControl.TabIndex = 0;
            // 
            // tabSubjects
            // 
            this.tabSubjects.Controls.Add(this.splitSubject);
            this.tabSubjects.Location = new System.Drawing.Point(4, 26);
            this.tabSubjects.Name = "tabSubjects";
            this.tabSubjects.Padding = new System.Windows.Forms.Padding(10);
            this.tabSubjects.Size = new System.Drawing.Size(1072, 620);
            this.tabSubjects.TabIndex = 0;
            this.tabSubjects.Text = "Danh mục Môn học";
            this.tabSubjects.UseVisualStyleBackColor = true;
            // 
            // splitSubject
            // 
            this.splitSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitSubject.Location = new System.Drawing.Point(10, 10);
            this.splitSubject.Name = "splitSubject";
            // 
            // splitSubject.Panel1
            // 
            this.splitSubject.Panel1.Controls.Add(this.pnlSubjectInput);
            // 
            // splitSubject.Panel2
            // 
            this.splitSubject.Panel2.Controls.Add(this.dgvSubjects);
            this.splitSubject.Size = new System.Drawing.Size(1052, 600);
            this.splitSubject.SplitterDistance = 330;
            this.splitSubject.TabIndex = 0;
            // 
            // pnlSubjectInput
            // 
            this.pnlSubjectInput.BackColor = System.Drawing.Color.White;
            this.pnlSubjectInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSubjectInput.Controls.Add(this.btnClearSubject);
            this.pnlSubjectInput.Controls.Add(this.btnDeleteSubject);
            this.pnlSubjectInput.Controls.Add(this.btnUpdateSubject);
            this.pnlSubjectInput.Controls.Add(this.btnAddSubject);
            this.pnlSubjectInput.Controls.Add(this.txtSubjectDesc);
            this.pnlSubjectInput.Controls.Add(this.lblSubjectDesc);
            this.pnlSubjectInput.Controls.Add(this.numFinalWeight);
            this.pnlSubjectInput.Controls.Add(this.lblFinalWeight);
            this.pnlSubjectInput.Controls.Add(this.numMidtermWeight);
            this.pnlSubjectInput.Controls.Add(this.lblMidtermWeight);
            this.pnlSubjectInput.Controls.Add(this.numCredits);
            this.pnlSubjectInput.Controls.Add(this.lblCredits);
            this.pnlSubjectInput.Controls.Add(this.txtSubjectName);
            this.pnlSubjectInput.Controls.Add(this.lblSubjectName);
            this.pnlSubjectInput.Controls.Add(this.txtSubjectCode);
            this.pnlSubjectInput.Controls.Add(this.lblSubjectCode);
            this.pnlSubjectInput.Controls.Add(this.lblSubjectHeader);
            this.pnlSubjectInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubjectInput.Location = new System.Drawing.Point(0, 0);
            this.pnlSubjectInput.Name = "pnlSubjectInput";
            this.pnlSubjectInput.Padding = new System.Windows.Forms.Padding(12);
            this.pnlSubjectInput.Size = new System.Drawing.Size(330, 600);
            this.pnlSubjectInput.TabIndex = 0;
            // 
            // btnClearSubject
            // 
            this.btnClearSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.btnClearSubject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSubject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearSubject.Location = new System.Drawing.Point(238, 410);
            this.btnClearSubject.Name = "btnClearSubject";
            this.btnClearSubject.Size = new System.Drawing.Size(76, 34);
            this.btnClearSubject.TabIndex = 16;
            this.btnClearSubject.Text = "Làm mới";
            this.btnClearSubject.UseVisualStyleBackColor = false;
            this.btnClearSubject.Click += new System.EventHandler(this.btnClearSubject_Click);
            // 
            // btnDeleteSubject
            // 
            this.btnDeleteSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnDeleteSubject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSubject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteSubject.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSubject.Location = new System.Drawing.Point(158, 410);
            this.btnDeleteSubject.Name = "btnDeleteSubject";
            this.btnDeleteSubject.Size = new System.Drawing.Size(72, 34);
            this.btnDeleteSubject.TabIndex = 15;
            this.btnDeleteSubject.Text = "Xóa môn";
            this.btnDeleteSubject.UseVisualStyleBackColor = false;
            this.btnDeleteSubject.Click += new System.EventHandler(this.btnDeleteSubject_Click);
            // 
            // btnUpdateSubject
            // 
            this.btnUpdateSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnUpdateSubject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSubject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdateSubject.ForeColor = System.Drawing.Color.White;
            this.btnUpdateSubject.Location = new System.Drawing.Point(85, 410);
            this.btnUpdateSubject.Name = "btnUpdateSubject";
            this.btnUpdateSubject.Size = new System.Drawing.Size(68, 34);
            this.btnUpdateSubject.TabIndex = 14;
            this.btnUpdateSubject.Text = "Cập nhật";
            this.btnUpdateSubject.UseVisualStyleBackColor = false;
            this.btnUpdateSubject.Click += new System.EventHandler(this.btnUpdateSubject_Click);
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAddSubject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddSubject.ForeColor = System.Drawing.Color.White;
            this.btnAddSubject.Location = new System.Drawing.Point(12, 410);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(68, 34);
            this.btnAddSubject.TabIndex = 13;
            this.btnAddSubject.Text = "Thêm môn";
            this.btnAddSubject.UseVisualStyleBackColor = false;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // txtSubjectDesc
            // 
            this.txtSubjectDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSubjectDesc.Location = new System.Drawing.Point(12, 320);
            this.txtSubjectDesc.Multiline = true;
            this.txtSubjectDesc.Name = "txtSubjectDesc";
            this.txtSubjectDesc.Size = new System.Drawing.Size(302, 65);
            this.txtSubjectDesc.TabIndex = 12;
            // 
            // lblSubjectDesc
            // 
            this.lblSubjectDesc.AutoSize = true;
            this.lblSubjectDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSubjectDesc.Location = new System.Drawing.Point(12, 300);
            this.lblSubjectDesc.Name = "lblSubjectDesc";
            this.lblSubjectDesc.Size = new System.Drawing.Size(43, 15);
            this.lblSubjectDesc.TabIndex = 11;
            this.lblSubjectDesc.Text = "Mô tả:";
            // 
            // numFinalWeight
            // 
            this.numFinalWeight.DecimalPlaces = 2;
            this.numFinalWeight.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numFinalWeight.Increment = new decimal(new int[] {

            5,
            0,
            0,
            131072});
            this.numFinalWeight.Location = new System.Drawing.Point(170, 255);
            this.numFinalWeight.Maximum = new decimal(new int[] {

            1,
            0,
            0,
            0});
            this.numFinalWeight.Name = "numFinalWeight";
            this.numFinalWeight.Size = new System.Drawing.Size(144, 24);
            this.numFinalWeight.TabIndex = 10;
            this.numFinalWeight.Value = new decimal(new int[] {

            6,
            0,
            0,
            65536});
            // 
            // lblFinalWeight
            // 
            this.lblFinalWeight.AutoSize = true;
            this.lblFinalWeight.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFinalWeight.Location = new System.Drawing.Point(170, 235);
            this.lblFinalWeight.Name = "lblFinalWeight";
            this.lblFinalWeight.Size = new System.Drawing.Size(107, 15);
            this.lblFinalWeight.TabIndex = 9;
            this.lblFinalWeight.Text = "Trọng số điểm thi:";
            // 
            // numMidtermWeight
            // 
            this.numMidtermWeight.DecimalPlaces = 2;
            this.numMidtermWeight.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numMidtermWeight.Increment = new decimal(new int[] {

            5,
            0,
            0,
            131072});
            this.numMidtermWeight.Location = new System.Drawing.Point(12, 255);
            this.numMidtermWeight.Maximum = new decimal(new int[] {

            1,
            0,
            0,
            0});
            this.numMidtermWeight.Name = "numMidtermWeight";
            this.numMidtermWeight.Size = new System.Drawing.Size(140, 24);
            this.numMidtermWeight.TabIndex = 8;
            this.numMidtermWeight.Value = new decimal(new int[] {

            4,
            0,
            0,
            65536});
            // 
            // lblMidtermWeight
            // 
            this.lblMidtermWeight.AutoSize = true;
            this.lblMidtermWeight.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMidtermWeight.Location = new System.Drawing.Point(12, 235);
            this.lblMidtermWeight.Name = "lblMidtermWeight";
            this.lblMidtermWeight.Size = new System.Drawing.Size(104, 15);
            this.lblMidtermWeight.TabIndex = 7;
            this.lblMidtermWeight.Text = "Trọng số điểm QT:";
            // 
            // numCredits
            // 
            this.numCredits.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numCredits.Location = new System.Drawing.Point(12, 190);
            this.numCredits.Maximum = new decimal(new int[] {

            15,
            0,
            0,
            0});
            this.numCredits.Minimum = new decimal(new int[] {

            1,
            0,
            0,
            0});
            this.numCredits.Name = "numCredits";
            this.numCredits.Size = new System.Drawing.Size(302, 24);
            this.numCredits.TabIndex = 6;
            this.numCredits.Value = new decimal(new int[] {

            3,
            0,
            0,
            0});
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCredits.Location = new System.Drawing.Point(12, 170);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(61, 15);
            this.lblCredits.TabIndex = 5;
            this.lblCredits.Text = "Số tín chỉ:";
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSubjectName.Location = new System.Drawing.Point(12, 125);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(302, 24);
            this.txtSubjectName.TabIndex = 4;
            // 
            // lblSubjectName
            // 
            this.lblSubjectName.AutoSize = true;
            this.lblSubjectName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSubjectName.Location = new System.Drawing.Point(12, 105);
            this.lblSubjectName.Name = "lblSubjectName";
            this.lblSubjectName.Size = new System.Drawing.Size(81, 15);
            this.lblSubjectName.TabIndex = 3;
            this.lblSubjectName.Text = "Tên môn học:";
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSubjectCode.Location = new System.Drawing.Point(12, 68);
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.Size = new System.Drawing.Size(302, 24);
            this.txtSubjectCode.TabIndex = 2;
            // 
            // lblSubjectCode
            // 
            this.lblSubjectCode.AutoSize = true;
            this.lblSubjectCode.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSubjectCode.Location = new System.Drawing.Point(12, 48);
            this.lblSubjectCode.Name = "lblSubjectCode";
            this.lblSubjectCode.Size = new System.Drawing.Size(78, 15);
            this.lblSubjectCode.TabIndex = 1;
            this.lblSubjectCode.Text = "Mã môn học:";
            // 
            // lblSubjectHeader
            // 
            this.lblSubjectHeader.AutoSize = true;
            this.lblSubjectHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubjectHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblSubjectHeader.Location = new System.Drawing.Point(12, 12);
            this.lblSubjectHeader.Name = "lblSubjectHeader";
            this.lblSubjectHeader.Size = new System.Drawing.Size(189, 21);
            this.lblSubjectHeader.TabIndex = 0;
            this.lblSubjectHeader.Text = "THÔNG TIN MÔN HỌC";
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubjects.Location = new System.Drawing.Point(0, 0);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.Size = new System.Drawing.Size(718, 600);
            this.dgvSubjects.TabIndex = 0;
            this.dgvSubjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubjects_CellClick);
            // 
            // tabSemesters
            // 
            this.tabSemesters.Controls.Add(this.splitSemester);
            this.tabSemesters.Location = new System.Drawing.Point(4, 26);
            this.tabSemesters.Name = "tabSemesters";
            this.tabSemesters.Padding = new System.Windows.Forms.Padding(10);
            this.tabSemesters.Size = new System.Drawing.Size(1072, 620);
            this.tabSemesters.TabIndex = 1;
            this.tabSemesters.Text = "Học kỳ & Năm học";
            this.tabSemesters.UseVisualStyleBackColor = true;
            // 
            // splitSemester
            // 
            this.splitSemester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitSemester.Location = new System.Drawing.Point(10, 10);
            this.splitSemester.Name = "splitSemester";
            // 
            // splitSemester.Panel1
            // 
            this.splitSemester.Panel1.Controls.Add(this.pnlSemesterInput);
            // 
            // splitSemester.Panel2
            // 
            this.splitSemester.Panel2.Controls.Add(this.dgvSemesters);
            this.splitSemester.Size = new System.Drawing.Size(1052, 600);
            this.splitSemester.SplitterDistance = 330;
            this.splitSemester.TabIndex = 0;
            // 
            // pnlSemesterInput
            // 
            this.pnlSemesterInput.BackColor = System.Drawing.Color.White;
            this.pnlSemesterInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSemesterInput.Controls.Add(this.btnSetCurrent);
            this.pnlSemesterInput.Controls.Add(this.chkIsCurrent);
            this.pnlSemesterInput.Controls.Add(this.dtpEndDate);
            this.pnlSemesterInput.Controls.Add(this.lblEndDate);
            this.pnlSemesterInput.Controls.Add(this.dtpStartDate);
            this.pnlSemesterInput.Controls.Add(this.lblStartDate);
            this.pnlSemesterInput.Controls.Add(this.txtSchoolYear);
            this.pnlSemesterInput.Controls.Add(this.lblSchoolYear);
            this.pnlSemesterInput.Controls.Add(this.txtSemesterName);
            this.pnlSemesterInput.Controls.Add(this.lblSemesterName);
            this.pnlSemesterInput.Controls.Add(this.txtSemesterID);
            this.pnlSemesterInput.Controls.Add(this.lblSemesterID);
            this.pnlSemesterInput.Controls.Add(this.lblSemesterHeader);
            this.pnlSemesterInput.Controls.Add(this.btnClearSemester);
            this.pnlSemesterInput.Controls.Add(this.btnUpdateSemester);
            this.pnlSemesterInput.Controls.Add(this.btnAddSemester);
            this.pnlSemesterInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSemesterInput.Location = new System.Drawing.Point(0, 0);
            this.pnlSemesterInput.Name = "pnlSemesterInput";
            this.pnlSemesterInput.Padding = new System.Windows.Forms.Padding(12);
            this.pnlSemesterInput.Size = new System.Drawing.Size(330, 600);
            this.pnlSemesterInput.TabIndex = 0;
            // 
            // btnSetCurrent
            // 
            this.btnSetCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSetCurrent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetCurrent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSetCurrent.ForeColor = System.Drawing.Color.White;
            this.btnSetCurrent.Location = new System.Drawing.Point(12, 420);
            this.btnSetCurrent.Name = "btnSetCurrent";
            this.btnSetCurrent.Size = new System.Drawing.Size(302, 34);
            this.btnSetCurrent.TabIndex = 15;
            this.btnSetCurrent.Text = "Đặt làm kỳ hiện tại";
            this.btnSetCurrent.UseVisualStyleBackColor = false;
            this.btnSetCurrent.Click += new System.EventHandler(this.btnSetCurrent_Click);
            // 
            // chkIsCurrent
            // 
            this.chkIsCurrent.AutoSize = true;
            this.chkIsCurrent.Location = new System.Drawing.Point(12, 315);
            this.chkIsCurrent.Name = "chkIsCurrent";
            this.chkIsCurrent.Size = new System.Drawing.Size(183, 23);
            this.chkIsCurrent.TabIndex = 14;
            this.chkIsCurrent.Text = "Học kỳ hiện tại đang học";
            this.chkIsCurrent.UseVisualStyleBackColor = true;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(165, 260);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(149, 25);
            this.dtpEndDate.TabIndex = 13;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEndDate.Location = new System.Drawing.Point(165, 240);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(89, 15);
            this.lblEndDate.TabIndex = 12;
            this.lblEndDate.Text = "Ngày kết thúc:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(12, 260);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(140, 25);
            this.dtpStartDate.TabIndex = 11;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStartDate.Location = new System.Drawing.Point(12, 240);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(84, 15);
            this.lblStartDate.TabIndex = 10;
            this.lblStartDate.Text = "Ngày bắt đầu:";
            // 
            // txtSchoolYear
            // 
            this.txtSchoolYear.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSchoolYear.Location = new System.Drawing.Point(12, 195);
            this.txtSchoolYear.Name = "txtSchoolYear";
            this.txtSchoolYear.Size = new System.Drawing.Size(302, 24);
            this.txtSchoolYear.TabIndex = 9;
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSchoolYear.Location = new System.Drawing.Point(12, 175);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(155, 15);
            this.lblSchoolYear.TabIndex = 8;
            this.lblSchoolYear.Text = "Năm học (VD: 2025-2026):";
            // 
            // txtSemesterName
            // 
            this.txtSemesterName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSemesterName.Location = new System.Drawing.Point(12, 130);
            this.txtSemesterName.Name = "txtSemesterName";
            this.txtSemesterName.Size = new System.Drawing.Size(302, 24);
            this.txtSemesterName.TabIndex = 7;
            // 
            // lblSemesterName
            // 
            this.lblSemesterName.AutoSize = true;
            this.lblSemesterName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSemesterName.Location = new System.Drawing.Point(12, 110);
            this.lblSemesterName.Name = "lblSemesterName";
            this.lblSemesterName.Size = new System.Drawing.Size(133, 15);
            this.lblSemesterName.TabIndex = 6;
            this.lblSemesterName.Text = "Tên học kỳ (VD: HK 1):";
            // 
            // txtSemesterID
            // 
            this.txtSemesterID.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSemesterID.Location = new System.Drawing.Point(12, 68);
            this.txtSemesterID.Name = "txtSemesterID";
            this.txtSemesterID.Size = new System.Drawing.Size(302, 24);
            this.txtSemesterID.TabIndex = 5;
            // 
            // lblSemesterID
            // 
            this.lblSemesterID.AutoSize = true;
            this.lblSemesterID.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSemesterID.Location = new System.Drawing.Point(12, 48);
            this.lblSemesterID.Name = "lblSemesterID";
            this.lblSemesterID.Size = new System.Drawing.Size(186, 15);
            this.lblSemesterID.TabIndex = 4;
            this.lblSemesterID.Text = "Mã học kỳ (VD: HK1_2025_2026):";
            // 
            // lblSemesterHeader
            // 
            this.lblSemesterHeader.AutoSize = true;
            this.lblSemesterHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSemesterHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblSemesterHeader.Location = new System.Drawing.Point(12, 12);
            this.lblSemesterHeader.Name = "lblSemesterHeader";
            this.lblSemesterHeader.Size = new System.Drawing.Size(171, 21);
            this.lblSemesterHeader.TabIndex = 3;
            this.lblSemesterHeader.Text = "THÔNG TIN HỌC KỲ";
            // 
            // btnClearSemester
            // 
            this.btnClearSemester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.btnClearSemester.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSemester.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearSemester.Location = new System.Drawing.Point(218, 360);
            this.btnClearSemester.Name = "btnClearSemester";
            this.btnClearSemester.Size = new System.Drawing.Size(96, 34);
            this.btnClearSemester.TabIndex = 2;
            this.btnClearSemester.Text = "Làm mới";
            this.btnClearSemester.UseVisualStyleBackColor = false;
            this.btnClearSemester.Click += new System.EventHandler(this.btnClearSemester_Click);
            // 
            // btnUpdateSemester
            // 
            this.btnUpdateSemester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnUpdateSemester.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSemester.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdateSemester.ForeColor = System.Drawing.Color.White;
            this.btnUpdateSemester.Location = new System.Drawing.Point(115, 360);
            this.btnUpdateSemester.Name = "btnUpdateSemester";
            this.btnUpdateSemester.Size = new System.Drawing.Size(96, 34);
            this.btnUpdateSemester.TabIndex = 1;
            this.btnUpdateSemester.Text = "Cập nhật";
            this.btnUpdateSemester.UseVisualStyleBackColor = false;
            this.btnUpdateSemester.Click += new System.EventHandler(this.btnUpdateSemester_Click);
            // 
            // btnAddSemester
            // 
            this.btnAddSemester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAddSemester.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSemester.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSemester.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddSemester.ForeColor = System.Drawing.Color.White;
            this.btnAddSemester.Location = new System.Drawing.Point(12, 360);
            this.btnAddSemester.Name = "btnAddSemester";
            this.btnAddSemester.Size = new System.Drawing.Size(96, 34);
            this.btnAddSemester.TabIndex = 0;
            this.btnAddSemester.Text = "Thêm kỳ";
            this.btnAddSemester.UseVisualStyleBackColor = false;
            this.btnAddSemester.Click += new System.EventHandler(this.btnAddSemester_Click);
            // 
            // dgvSemesters
            // 
            this.dgvSemesters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSemesters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSemesters.Location = new System.Drawing.Point(0, 0);
            this.dgvSemesters.Name = "dgvSemesters";
            this.dgvSemesters.Size = new System.Drawing.Size(718, 600);
            this.dgvSemesters.TabIndex = 0;
            this.dgvSemesters.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSemesters_CellClick);
            // 
            // tabEnrollments
            // 
            this.tabEnrollments.Controls.Add(this.dgvEnrollments);
            this.tabEnrollments.Controls.Add(this.pnlEnrollTop);
            this.tabEnrollments.Location = new System.Drawing.Point(4, 26);
            this.tabEnrollments.Name = "tabEnrollments";
            this.tabEnrollments.Padding = new System.Windows.Forms.Padding(10);
            this.tabEnrollments.Size = new System.Drawing.Size(1072, 620);
            this.tabEnrollments.TabIndex = 2;
            this.tabEnrollments.Text = "Đăng ký Môn học";
            this.tabEnrollments.UseVisualStyleBackColor = true;
            // 
            // pnlEnrollTop
            // 
            this.pnlEnrollTop.BackColor = System.Drawing.Color.White;
            this.pnlEnrollTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEnrollTop.Controls.Add(this.btnCancelEnroll);
            this.pnlEnrollTop.Controls.Add(this.btnEnroll);
            this.pnlEnrollTop.Controls.Add(this.cboEnrollStudent);
            this.pnlEnrollTop.Controls.Add(this.lblEnrollStudent);
            this.pnlEnrollTop.Controls.Add(this.cboEnrollSubject);
            this.pnlEnrollTop.Controls.Add(this.lblEnrollSubject);
            this.pnlEnrollTop.Controls.Add(this.cboEnrollSemester);
            this.pnlEnrollTop.Controls.Add(this.lblEnrollSemester);
            this.pnlEnrollTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEnrollTop.Location = new System.Drawing.Point(10, 10);
            this.pnlEnrollTop.Name = "pnlEnrollTop";
            this.pnlEnrollTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlEnrollTop.Size = new System.Drawing.Size(1052, 75);
            this.pnlEnrollTop.TabIndex = 0;
            // 
            // btnCancelEnroll
            // 
            this.btnCancelEnroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancelEnroll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelEnroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEnroll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelEnroll.ForeColor = System.Drawing.Color.White;
            this.btnCancelEnroll.Location = new System.Drawing.Point(905, 30);
            this.btnCancelEnroll.Name = "btnCancelEnroll";
            this.btnCancelEnroll.Size = new System.Drawing.Size(130, 32);
            this.btnCancelEnroll.TabIndex = 7;
            this.btnCancelEnroll.Text = "Hủy đăng ký";
            this.btnCancelEnroll.UseVisualStyleBackColor = false;
            this.btnCancelEnroll.Click += new System.EventHandler(this.btnCancelEnroll_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnEnroll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnroll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEnroll.ForeColor = System.Drawing.Color.White;
            this.btnEnroll.Location = new System.Drawing.Point(760, 30);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(135, 32);
            this.btnEnroll.TabIndex = 6;
            this.btnEnroll.Text = "Đăng ký môn";
            this.btnEnroll.UseVisualStyleBackColor = false;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // cboEnrollStudent
            // 
            this.cboEnrollStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEnrollStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEnrollStudent.FormattingEnabled = true;
            this.cboEnrollStudent.Location = new System.Drawing.Point(485, 34);
            this.cboEnrollStudent.Name = "cboEnrollStudent";
            this.cboEnrollStudent.Size = new System.Drawing.Size(260, 25);
            this.cboEnrollStudent.TabIndex = 5;
            // 
            // lblEnrollStudent
            // 
            this.lblEnrollStudent.AutoSize = true;
            this.lblEnrollStudent.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEnrollStudent.Location = new System.Drawing.Point(485, 14);
            this.lblEnrollStudent.Name = "lblEnrollStudent";
            this.lblEnrollStudent.Size = new System.Drawing.Size(89, 15);
            this.lblEnrollStudent.TabIndex = 4;
            this.lblEnrollStudent.Text = "Chọn sinh viên:";
            // 
            // cboEnrollSubject
            // 
            this.cboEnrollSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEnrollSubject.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEnrollSubject.FormattingEnabled = true;
            this.cboEnrollSubject.Location = new System.Drawing.Point(235, 34);
            this.cboEnrollSubject.Name = "cboEnrollSubject";
            this.cboEnrollSubject.Size = new System.Drawing.Size(235, 25);
            this.cboEnrollSubject.TabIndex = 3;
            // 
            // lblEnrollSubject
            // 
            this.lblEnrollSubject.AutoSize = true;
            this.lblEnrollSubject.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEnrollSubject.Location = new System.Drawing.Point(235, 14);
            this.lblEnrollSubject.Name = "lblEnrollSubject";
            this.lblEnrollSubject.Size = new System.Drawing.Size(89, 15);
            this.lblEnrollSubject.TabIndex = 2;
            this.lblEnrollSubject.Text = "Chọn môn học:";
            // 
            // cboEnrollSemester
            // 
            this.cboEnrollSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEnrollSemester.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEnrollSemester.FormattingEnabled = true;
            this.cboEnrollSemester.Location = new System.Drawing.Point(10, 34);
            this.cboEnrollSemester.Name = "cboEnrollSemester";
            this.cboEnrollSemester.Size = new System.Drawing.Size(210, 25);
            this.cboEnrollSemester.TabIndex = 1;
            this.cboEnrollSemester.SelectedIndexChanged += new System.EventHandler(this.cboEnrollSemester_SelectedIndexChanged);
            // 
            // lblEnrollSemester
            // 
            this.lblEnrollSemester.AutoSize = true;
            this.lblEnrollSemester.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEnrollSemester.Location = new System.Drawing.Point(10, 14);
            this.lblEnrollSemester.Name = "lblEnrollSemester";
            this.lblEnrollSemester.Size = new System.Drawing.Size(81, 15);
            this.lblEnrollSemester.TabIndex = 0;
            this.lblEnrollSemester.Text = "Chọn học kỳ:";
            // 
            // dgvEnrollments
            // 
            this.dgvEnrollments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnrollments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEnrollments.Location = new System.Drawing.Point(10, 85);
            this.dgvEnrollments.Name = "dgvEnrollments";
            this.dgvEnrollments.Size = new System.Drawing.Size(1052, 525);
            this.dgvEnrollments.TabIndex = 1;
            // 
            // FrmSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1080, 650);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FrmSubject";
            this.Text = "Quản lý Môn học và Học kỳ";
            this.Load += new System.EventHandler(this.FrmSubject_Load);
            this.tabControl.ResumeLayout(false);
            this.tabSubjects.ResumeLayout(false);
            this.splitSubject.Panel1.ResumeLayout(false);
            this.splitSubject.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitSubject)).EndInit();
            this.splitSubject.ResumeLayout(false);
            this.pnlSubjectInput.ResumeLayout(false);
            this.pnlSubjectInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFinalWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMidtermWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCredits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.tabSemesters.ResumeLayout(false);
            this.splitSemester.Panel1.ResumeLayout(false);
            this.splitSemester.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitSemester)).EndInit();
            this.splitSemester.ResumeLayout(false);
            this.pnlSemesterInput.ResumeLayout(false);
            this.pnlSemesterInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSemesters)).EndInit();
            this.tabEnrollments.ResumeLayout(false);
            this.pnlEnrollTop.ResumeLayout(false);
            this.pnlEnrollTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollments)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;

        private System.Windows.Forms.TabPage tabSubjects;

        private System.Windows.Forms.SplitContainer splitSubject;

        private System.Windows.Forms.Panel pnlSubjectInput;

        private System.Windows.Forms.Label lblSubjectHeader;

        private System.Windows.Forms.Label lblSubjectCode;

        private System.Windows.Forms.TextBox txtSubjectCode;

        private System.Windows.Forms.Label lblSubjectName;

        private System.Windows.Forms.TextBox txtSubjectName;

        private System.Windows.Forms.Label lblCredits;

        private System.Windows.Forms.NumericUpDown numCredits;

        private System.Windows.Forms.Label lblMidtermWeight;

        private System.Windows.Forms.NumericUpDown numMidtermWeight;

        private System.Windows.Forms.Label lblFinalWeight;

        private System.Windows.Forms.NumericUpDown numFinalWeight;

        private System.Windows.Forms.Label lblSubjectDesc;

        private System.Windows.Forms.TextBox txtSubjectDesc;

        private System.Windows.Forms.Button btnAddSubject;

        private System.Windows.Forms.Button btnUpdateSubject;

        private System.Windows.Forms.Button btnDeleteSubject;

        private System.Windows.Forms.Button btnClearSubject;

        private System.Windows.Forms.DataGridView dgvSubjects;

        private System.Windows.Forms.TabPage tabSemesters;

        private System.Windows.Forms.SplitContainer splitSemester;

        private System.Windows.Forms.Panel pnlSemesterInput;

        private System.Windows.Forms.Label lblSemesterHeader;

        private System.Windows.Forms.Label lblSemesterID;

        private System.Windows.Forms.TextBox txtSemesterID;

        private System.Windows.Forms.Label lblSemesterName;

        private System.Windows.Forms.TextBox txtSemesterName;

        private System.Windows.Forms.Label lblSchoolYear;

        private System.Windows.Forms.TextBox txtSchoolYear;

        private System.Windows.Forms.Label lblStartDate;

        private System.Windows.Forms.DateTimePicker dtpStartDate;

        private System.Windows.Forms.Label lblEndDate;

        private System.Windows.Forms.DateTimePicker dtpEndDate;

        private System.Windows.Forms.CheckBox chkIsCurrent;

        private System.Windows.Forms.Button btnAddSemester;

        private System.Windows.Forms.Button btnUpdateSemester;

        private System.Windows.Forms.Button btnClearSemester;

        private System.Windows.Forms.Button btnSetCurrent;

        private System.Windows.Forms.DataGridView dgvSemesters;

        private System.Windows.Forms.TabPage tabEnrollments;

        private System.Windows.Forms.Panel pnlEnrollTop;

        private System.Windows.Forms.Label lblEnrollSemester;

        private System.Windows.Forms.ComboBox cboEnrollSemester;

        private System.Windows.Forms.Label lblEnrollSubject;

        private System.Windows.Forms.ComboBox cboEnrollSubject;

        private System.Windows.Forms.Label lblEnrollStudent;

        private System.Windows.Forms.ComboBox cboEnrollStudent;

        private System.Windows.Forms.Button btnEnroll;

        private System.Windows.Forms.Button btnCancelEnroll;

        private System.Windows.Forms.DataGridView dgvEnrollments;
    }

}

