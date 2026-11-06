namespace QuanLySinhVien.Forms
{
    partial class FrmClassDepartment
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
            this.tabClasses = new System.Windows.Forms.TabPage();
            this.splitClass = new System.Windows.Forms.SplitContainer();
            this.pnlClassInput = new System.Windows.Forms.Panel();
            this.btnClearClass = new System.Windows.Forms.Button();
            this.btnDeleteClass = new System.Windows.Forms.Button();
            this.btnUpdateClass = new System.Windows.Forms.Button();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.txtHeadTeacher = new System.Windows.Forms.TextBox();
            this.lblHeadTeacher = new System.Windows.Forms.Label();
            this.txtAcademicYear = new System.Windows.Forms.TextBox();
            this.lblAcademicYear = new System.Windows.Forms.Label();
            this.cboClassDept = new System.Windows.Forms.ComboBox();
            this.lblClassDept = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.txtClassID = new System.Windows.Forms.TextBox();
            this.lblClassID = new System.Windows.Forms.Label();
            this.lblClassHeader = new System.Windows.Forms.Label();
            this.dgvClasses = new System.Windows.Forms.DataGridView();
            this.pnlClassStudents = new System.Windows.Forms.Panel();
            this.btnMoveStudent = new System.Windows.Forms.Button();
            this.cboMoveTargetClass = new System.Windows.Forms.ComboBox();
            this.lblMoveTo = new System.Windows.Forms.Label();
            this.dgvClassStudents = new System.Windows.Forms.DataGridView();
            this.lblClassStudentsTitle = new System.Windows.Forms.Label();
            this.tabDepartments = new System.Windows.Forms.TabPage();
            this.splitDept = new System.Windows.Forms.SplitContainer();
            this.pnlDeptInput = new System.Windows.Forms.Panel();
            this.btnClearDept = new System.Windows.Forms.Button();
            this.btnDeleteDept = new System.Windows.Forms.Button();
            this.btnUpdateDept = new System.Windows.Forms.Button();
            this.btnAddDept = new System.Windows.Forms.Button();
            this.txtDeptDesc = new System.Windows.Forms.TextBox();
            this.lblDeptDesc = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.lblDeptName = new System.Windows.Forms.Label();
            this.txtDeptID = new System.Windows.Forms.TextBox();
            this.lblDeptID = new System.Windows.Forms.Label();
            this.lblDeptHeader = new System.Windows.Forms.Label();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabClasses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitClass)).BeginInit();
            this.splitClass.Panel1.SuspendLayout();
            this.splitClass.Panel2.SuspendLayout();
            this.splitClass.SuspendLayout();
            this.pnlClassInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.pnlClassStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassStudents)).BeginInit();
            this.tabDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDept)).BeginInit();
            this.splitDept.Panel1.SuspendLayout();
            this.splitDept.Panel2.SuspendLayout();
            this.splitDept.SuspendLayout();
            this.pnlDeptInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabClasses);
            this.tabControl.Controls.Add(this.tabDepartments);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1080, 650);
            this.tabControl.TabIndex = 0;
            // 
            // tabClasses
            // 
            this.tabClasses.Controls.Add(this.splitClass);
            this.tabClasses.Location = new System.Drawing.Point(4, 26);
            this.tabClasses.Name = "tabClasses";
            this.tabClasses.Padding = new System.Windows.Forms.Padding(10);
            this.tabClasses.Size = new System.Drawing.Size(1072, 620);
            this.tabClasses.TabIndex = 0;
            this.tabClasses.Text = "■ Quản lý Lớp học";
            this.tabClasses.UseVisualStyleBackColor = true;
            // 
            // splitClass
            // 
            this.splitClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitClass.Location = new System.Drawing.Point(10, 10);
            this.splitClass.Name = "splitClass";
            // 
            // splitClass.Panel1
            // 
            this.splitClass.Panel1.Controls.Add(this.pnlClassInput);
            // 
            // splitClass.Panel2
            // 
            this.splitClass.Panel2.Controls.Add(this.dgvClasses);
            this.splitClass.Panel2.Controls.Add(this.pnlClassStudents);
            this.splitClass.Size = new System.Drawing.Size(1052, 600);
            this.splitClass.SplitterDistance = 330;
            this.splitClass.TabIndex = 0;
            // 
            // pnlClassInput
            // 
            this.pnlClassInput.BackColor = System.Drawing.Color.White;
            this.pnlClassInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlClassInput.Controls.Add(this.btnClearClass);
            this.pnlClassInput.Controls.Add(this.btnDeleteClass);
            this.pnlClassInput.Controls.Add(this.btnUpdateClass);
            this.pnlClassInput.Controls.Add(this.btnAddClass);
            this.pnlClassInput.Controls.Add(this.txtHeadTeacher);
            this.pnlClassInput.Controls.Add(this.lblHeadTeacher);
            this.pnlClassInput.Controls.Add(this.txtAcademicYear);
            this.pnlClassInput.Controls.Add(this.lblAcademicYear);
            this.pnlClassInput.Controls.Add(this.cboClassDept);
            this.pnlClassInput.Controls.Add(this.lblClassDept);
            this.pnlClassInput.Controls.Add(this.txtClassName);
            this.pnlClassInput.Controls.Add(this.lblClassName);
            this.pnlClassInput.Controls.Add(this.txtClassID);
            this.pnlClassInput.Controls.Add(this.lblClassID);
            this.pnlClassInput.Controls.Add(this.lblClassHeader);
            this.pnlClassInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClassInput.Location = new System.Drawing.Point(0, 0);
            this.pnlClassInput.Name = "pnlClassInput";
            this.pnlClassInput.Padding = new System.Windows.Forms.Padding(12);
            this.pnlClassInput.Size = new System.Drawing.Size(330, 600);
            this.pnlClassInput.TabIndex = 0;
            // 
            // btnClearClass
            // 
            this.btnClearClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.btnClearClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearClass.Location = new System.Drawing.Point(236, 360);
            this.btnClearClass.Name = "btnClearClass";
            this.btnClearClass.Size = new System.Drawing.Size(78, 34);
            this.btnClearClass.TabIndex = 14;
            this.btnClearClass.Text = "↻ Làm mới";
            this.btnClearClass.UseVisualStyleBackColor = false;
            this.btnClearClass.Click += new System.EventHandler(this.btnClearClass_Click);
            // 
            // btnDeleteClass
            // 
            this.btnDeleteClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnDeleteClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteClass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteClass.ForeColor = System.Drawing.Color.White;
            this.btnDeleteClass.Location = new System.Drawing.Point(158, 360);
            this.btnDeleteClass.Name = "btnDeleteClass";
            this.btnDeleteClass.Size = new System.Drawing.Size(72, 34);
            this.btnDeleteClass.TabIndex = 13;
            this.btnDeleteClass.Text = "✕ Xóa";
            this.btnDeleteClass.UseVisualStyleBackColor = false;
            this.btnDeleteClass.Click += new System.EventHandler(this.btnDeleteClass_Click);
            // 
            // btnUpdateClass
            // 
            this.btnUpdateClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnUpdateClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateClass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdateClass.ForeColor = System.Drawing.Color.White;
            this.btnUpdateClass.Location = new System.Drawing.Point(85, 360);
            this.btnUpdateClass.Name = "btnUpdateClass";
            this.btnUpdateClass.Size = new System.Drawing.Size(68, 34);
            this.btnUpdateClass.TabIndex = 12;
            this.btnUpdateClass.Text = "✎ Sửa";
            this.btnUpdateClass.UseVisualStyleBackColor = false;
            this.btnUpdateClass.Click += new System.EventHandler(this.btnUpdateClass_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAddClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddClass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddClass.ForeColor = System.Drawing.Color.White;
            this.btnAddClass.Location = new System.Drawing.Point(12, 360);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(68, 34);
            this.btnAddClass.TabIndex = 11;
            this.btnAddClass.Text = "+ Thêm";
            this.btnAddClass.UseVisualStyleBackColor = false;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // txtHeadTeacher
            // 
            this.txtHeadTeacher.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtHeadTeacher.Location = new System.Drawing.Point(12, 305);
            this.txtHeadTeacher.Name = "txtHeadTeacher";
            this.txtHeadTeacher.Size = new System.Drawing.Size(302, 24);
            this.txtHeadTeacher.TabIndex = 10;
            // 
            // lblHeadTeacher
            // 
            this.lblHeadTeacher.AutoSize = true;
            this.lblHeadTeacher.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHeadTeacher.Location = new System.Drawing.Point(12, 285);
            this.lblHeadTeacher.Name = "lblHeadTeacher";
            this.lblHeadTeacher.Size = new System.Drawing.Size(124, 15);
            this.lblHeadTeacher.TabIndex = 9;
            this.lblHeadTeacher.Text = "Giáo viên chủ nhiệm:";
            // 
            // txtAcademicYear
            // 
            this.txtAcademicYear.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtAcademicYear.Location = new System.Drawing.Point(12, 245);
            this.txtAcademicYear.Name = "txtAcademicYear";
            this.txtAcademicYear.Size = new System.Drawing.Size(302, 24);
            this.txtAcademicYear.TabIndex = 8;
            // 
            // lblAcademicYear
            // 
            this.lblAcademicYear.AutoSize = true;
            this.lblAcademicYear.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAcademicYear.Location = new System.Drawing.Point(12, 225);
            this.lblAcademicYear.Name = "lblAcademicYear";
            this.lblAcademicYear.Size = new System.Drawing.Size(126, 15);
            this.lblAcademicYear.TabIndex = 7;
            this.lblAcademicYear.Text = "Niên khóa (Khóa học):";
            // 
            // cboClassDept
            // 
            this.cboClassDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassDept.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboClassDept.FormattingEnabled = true;
            this.cboClassDept.Location = new System.Drawing.Point(12, 185);
            this.cboClassDept.Name = "cboClassDept";
            this.cboClassDept.Size = new System.Drawing.Size(302, 25);
            this.cboClassDept.TabIndex = 6;
            // 
            // lblClassDept
            // 
            this.lblClassDept.AutoSize = true;
            this.lblClassDept.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblClassDept.Location = new System.Drawing.Point(12, 165);
            this.lblClassDept.Name = "lblClassDept";
            this.lblClassDept.Size = new System.Drawing.Size(95, 15);
            this.lblClassDept.TabIndex = 5;
            this.lblClassDept.Text = "Khoa trực thuộc:";
            // 
            // txtClassName
            // 
            this.txtClassName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtClassName.Location = new System.Drawing.Point(12, 125);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(302, 24);
            this.txtClassName.TabIndex = 4;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblClassName.Location = new System.Drawing.Point(12, 105);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(51, 15);
            this.lblClassName.TabIndex = 3;
            this.lblClassName.Text = "Tên lớp:";
            // 
            // txtClassID
            // 
            this.txtClassID.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtClassID.Location = new System.Drawing.Point(12, 68);
            this.txtClassID.Name = "txtClassID";
            this.txtClassID.Size = new System.Drawing.Size(302, 24);
            this.txtClassID.TabIndex = 2;
            // 
            // lblClassID
            // 
            this.lblClassID.AutoSize = true;
            this.lblClassID.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblClassID.Location = new System.Drawing.Point(12, 48);
            this.lblClassID.Name = "lblClassID";
            this.lblClassID.Size = new System.Drawing.Size(48, 15);
            this.lblClassID.TabIndex = 1;
            this.lblClassID.Text = "Mã lớp:";
            // 
            // lblClassHeader
            // 
            this.lblClassHeader.AutoSize = true;
            this.lblClassHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblClassHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblClassHeader.Location = new System.Drawing.Point(12, 12);
            this.lblClassHeader.Name = "lblClassHeader";
            this.lblClassHeader.Size = new System.Drawing.Size(176, 21);
            this.lblClassHeader.TabIndex = 0;
            this.lblClassHeader.Text = "THÔNG TIN LỚP HỌC";
            // 
            // dgvClasses
            // 
            this.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClasses.Location = new System.Drawing.Point(0, 0);
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.Size = new System.Drawing.Size(718, 350);
            this.dgvClasses.TabIndex = 0;
            this.dgvClasses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClasses_CellClick);
            // 
            // pnlClassStudents
            // 
            this.pnlClassStudents.BackColor = System.Drawing.Color.White;
            this.pnlClassStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlClassStudents.Controls.Add(this.btnMoveStudent);
            this.pnlClassStudents.Controls.Add(this.cboMoveTargetClass);
            this.pnlClassStudents.Controls.Add(this.lblMoveTo);
            this.pnlClassStudents.Controls.Add(this.dgvClassStudents);
            this.pnlClassStudents.Controls.Add(this.lblClassStudentsTitle);
            this.pnlClassStudents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlClassStudents.Location = new System.Drawing.Point(0, 350);
            this.pnlClassStudents.Name = "pnlClassStudents";
            this.pnlClassStudents.Padding = new System.Windows.Forms.Padding(8);
            this.pnlClassStudents.Size = new System.Drawing.Size(718, 250);
            this.pnlClassStudents.TabIndex = 1;
            // 
            // btnMoveStudent
            // 
            this.btnMoveStudent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnMoveStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoveStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveStudent.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnMoveStudent.ForeColor = System.Drawing.Color.White;
            this.btnMoveStudent.Location = new System.Drawing.Point(590, 8);
            this.btnMoveStudent.Name = "btnMoveStudent";
            this.btnMoveStudent.Size = new System.Drawing.Size(118, 28);
            this.btnMoveStudent.TabIndex = 4;
            this.btnMoveStudent.Text = "⇄ Chuyển lớp";
            this.btnMoveStudent.UseVisualStyleBackColor = false;
            this.btnMoveStudent.Click += new System.EventHandler(this.btnMoveStudent_Click);
            // 
            // cboMoveTargetClass
            // 
            this.cboMoveTargetClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMoveTargetClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoveTargetClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboMoveTargetClass.FormattingEnabled = true;
            this.cboMoveTargetClass.Location = new System.Drawing.Point(420, 11);
            this.cboMoveTargetClass.Name = "cboMoveTargetClass";
            this.cboMoveTargetClass.Size = new System.Drawing.Size(160, 23);
            this.cboMoveTargetClass.TabIndex = 3;
            // 
            // lblMoveTo
            // 
            this.lblMoveTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMoveTo.AutoSize = true;
            this.lblMoveTo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMoveTo.Location = new System.Drawing.Point(340, 15);
            this.lblMoveTo.Name = "lblMoveTo";
            this.lblMoveTo.Size = new System.Drawing.Size(76, 15);
            this.lblMoveTo.TabIndex = 2;
            this.lblMoveTo.Text = "Chuyển sang:";
            // 
            // dgvClassStudents
            // 
            this.dgvClassStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClassStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassStudents.Location = new System.Drawing.Point(8, 42);
            this.dgvClassStudents.Name = "dgvClassStudents";
            this.dgvClassStudents.Size = new System.Drawing.Size(700, 198);
            this.dgvClassStudents.TabIndex = 1;
            // 
            // lblClassStudentsTitle
            // 
            this.lblClassStudentsTitle.AutoSize = true;
            this.lblClassStudentsTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblClassStudentsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblClassStudentsTitle.Location = new System.Drawing.Point(8, 12);
            this.lblClassStudentsTitle.Name = "lblClassStudentsTitle";
            this.lblClassStudentsTitle.Size = new System.Drawing.Size(232, 17);
            this.lblClassStudentsTitle.TabIndex = 0;
            this.lblClassStudentsTitle.Text = "Danh sách sinh viên thuộc lớp đang chọn";
            // 
            // tabDepartments
            // 
            this.tabDepartments.Controls.Add(this.splitDept);
            this.tabDepartments.Location = new System.Drawing.Point(4, 26);
            this.tabDepartments.Name = "tabDepartments";
            this.tabDepartments.Padding = new System.Windows.Forms.Padding(10);
            this.tabDepartments.Size = new System.Drawing.Size(1072, 620);
            this.tabDepartments.TabIndex = 1;
            this.tabDepartments.Text = "■ Quản lý Khoa";
            this.tabDepartments.UseVisualStyleBackColor = true;
            // 
            // splitDept
            // 
            this.splitDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDept.Location = new System.Drawing.Point(10, 10);
            this.splitDept.Name = "splitDept";
            // 
            // splitDept.Panel1
            // 
            this.splitDept.Panel1.Controls.Add(this.pnlDeptInput);
            // 
            // splitDept.Panel2
            // 
            this.splitDept.Panel2.Controls.Add(this.dgvDepartments);
            this.splitDept.Size = new System.Drawing.Size(1052, 600);
            this.splitDept.SplitterDistance = 330;
            this.splitDept.TabIndex = 0;
            // 
            // pnlDeptInput
            // 
            this.pnlDeptInput.BackColor = System.Drawing.Color.White;
            this.pnlDeptInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDeptInput.Controls.Add(this.btnClearDept);
            this.pnlDeptInput.Controls.Add(this.btnDeleteDept);
            this.pnlDeptInput.Controls.Add(this.btnUpdateDept);
            this.pnlDeptInput.Controls.Add(this.btnAddDept);
            this.pnlDeptInput.Controls.Add(this.txtDeptDesc);
            this.pnlDeptInput.Controls.Add(this.lblDeptDesc);
            this.pnlDeptInput.Controls.Add(this.txtDeptName);
            this.pnlDeptInput.Controls.Add(this.lblDeptName);
            this.pnlDeptInput.Controls.Add(this.txtDeptID);
            this.pnlDeptInput.Controls.Add(this.lblDeptID);
            this.pnlDeptInput.Controls.Add(this.lblDeptHeader);
            this.pnlDeptInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeptInput.Location = new System.Drawing.Point(0, 0);
            this.pnlDeptInput.Name = "pnlDeptInput";
            this.pnlDeptInput.Padding = new System.Windows.Forms.Padding(12);
            this.pnlDeptInput.Size = new System.Drawing.Size(330, 600);
            this.pnlDeptInput.TabIndex = 0;
            // 
            // btnClearDept
            // 
            this.btnClearDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.btnClearDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearDept.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearDept.Location = new System.Drawing.Point(236, 280);
            this.btnClearDept.Name = "btnClearDept";
            this.btnClearDept.Size = new System.Drawing.Size(78, 34);
            this.btnClearDept.TabIndex = 10;
            this.btnClearDept.Text = "↻ Làm mới";
            this.btnClearDept.UseVisualStyleBackColor = false;
            this.btnClearDept.Click += new System.EventHandler(this.btnClearDept_Click);
            // 
            // btnDeleteDept
            // 
            this.btnDeleteDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnDeleteDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteDept.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDept.Location = new System.Drawing.Point(158, 280);
            this.btnDeleteDept.Name = "btnDeleteDept";
            this.btnDeleteDept.Size = new System.Drawing.Size(72, 34);
            this.btnDeleteDept.TabIndex = 9;
            this.btnDeleteDept.Text = "✕ Xóa";
            this.btnDeleteDept.UseVisualStyleBackColor = false;
            this.btnDeleteDept.Click += new System.EventHandler(this.btnDeleteDept_Click);
            // 
            // btnUpdateDept
            // 
            this.btnUpdateDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnUpdateDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdateDept.ForeColor = System.Drawing.Color.White;
            this.btnUpdateDept.Location = new System.Drawing.Point(85, 280);
            this.btnUpdateDept.Name = "btnUpdateDept";
            this.btnUpdateDept.Size = new System.Drawing.Size(68, 34);
            this.btnUpdateDept.TabIndex = 8;
            this.btnUpdateDept.Text = "✎ Sửa";
            this.btnUpdateDept.UseVisualStyleBackColor = false;
            this.btnUpdateDept.Click += new System.EventHandler(this.btnUpdateDept_Click);
            // 
            // btnAddDept
            // 
            this.btnAddDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAddDept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddDept.ForeColor = System.Drawing.Color.White;
            this.btnAddDept.Location = new System.Drawing.Point(12, 280);
            this.btnAddDept.Name = "btnAddDept";
            this.btnAddDept.Size = new System.Drawing.Size(68, 34);
            this.btnAddDept.TabIndex = 7;
            this.btnAddDept.Text = "+ Thêm";
            this.btnAddDept.UseVisualStyleBackColor = false;
            this.btnAddDept.Click += new System.EventHandler(this.btnAddDept_Click);
            // 
            // txtDeptDesc
            // 
            this.txtDeptDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDeptDesc.Location = new System.Drawing.Point(12, 185);
            this.txtDeptDesc.Multiline = true;
            this.txtDeptDesc.Name = "txtDeptDesc";
            this.txtDeptDesc.Size = new System.Drawing.Size(302, 70);
            this.txtDeptDesc.TabIndex = 6;
            // 
            // lblDeptDesc
            // 
            this.lblDeptDesc.AutoSize = true;
            this.lblDeptDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDeptDesc.Location = new System.Drawing.Point(12, 165);
            this.lblDeptDesc.Name = "lblDeptDesc";
            this.lblDeptDesc.Size = new System.Drawing.Size(43, 15);
            this.lblDeptDesc.TabIndex = 5;
            this.lblDeptDesc.Text = "Mô tả:";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDeptName.Location = new System.Drawing.Point(12, 125);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(302, 24);
            this.txtDeptName.TabIndex = 4;
            // 
            // lblDeptName
            // 
            this.lblDeptName.AutoSize = true;
            this.lblDeptName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDeptName.Location = new System.Drawing.Point(12, 105);
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(60, 15);
            this.lblDeptName.TabIndex = 3;
            this.lblDeptName.Text = "Tên khoa:";
            // 
            // txtDeptID
            // 
            this.txtDeptID.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDeptID.Location = new System.Drawing.Point(12, 68);
            this.txtDeptID.Name = "txtDeptID";
            this.txtDeptID.Size = new System.Drawing.Size(302, 24);
            this.txtDeptID.TabIndex = 2;
            // 
            // lblDeptID
            // 
            this.lblDeptID.AutoSize = true;
            this.lblDeptID.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDeptID.Location = new System.Drawing.Point(12, 48);
            this.lblDeptID.Name = "lblDeptID";
            this.lblDeptID.Size = new System.Drawing.Size(57, 15);
            this.lblDeptID.TabIndex = 1;
            this.lblDeptID.Text = "Mã khoa:";
            // 
            // lblDeptHeader
            // 
            this.lblDeptHeader.AutoSize = true;
            this.lblDeptHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDeptHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblDeptHeader.Location = new System.Drawing.Point(12, 12);
            this.lblDeptHeader.Name = "lblDeptHeader";
            this.lblDeptHeader.Size = new System.Drawing.Size(155, 21);
            this.lblDeptHeader.TabIndex = 0;
            this.lblDeptHeader.Text = "THÔNG TIN KHOA";
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartments.Location = new System.Drawing.Point(0, 0);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.Size = new System.Drawing.Size(718, 600);
            this.dgvDepartments.TabIndex = 0;
            this.dgvDepartments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartments_CellClick);
            // 
            // FrmClassDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1080, 650);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FrmClassDepartment";
            this.Text = "Quản lý Khoa và Lớp học";
            this.Load += new System.EventHandler(this.FrmClassDepartment_Load);
            this.tabControl.ResumeLayout(false);
            this.tabClasses.ResumeLayout(false);
            this.splitClass.Panel1.ResumeLayout(false);
            this.splitClass.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitClass)).EndInit();
            this.splitClass.ResumeLayout(false);
            this.pnlClassInput.ResumeLayout(false);
            this.pnlClassInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            this.pnlClassStudents.ResumeLayout(false);
            this.pnlClassStudents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassStudents)).EndInit();
            this.tabDepartments.ResumeLayout(false);
            this.splitDept.Panel1.ResumeLayout(false);
            this.splitDept.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDept)).EndInit();
            this.splitDept.ResumeLayout(false);
            this.pnlDeptInput.ResumeLayout(false);
            this.pnlDeptInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabClasses;
        private System.Windows.Forms.SplitContainer splitClass;
        private System.Windows.Forms.Panel pnlClassInput;
        private System.Windows.Forms.Label lblClassHeader;
        private System.Windows.Forms.Label lblClassID;
        private System.Windows.Forms.TextBox txtClassID;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label lblClassDept;
        private System.Windows.Forms.ComboBox cboClassDept;
        private System.Windows.Forms.Label lblAcademicYear;
        private System.Windows.Forms.TextBox txtAcademicYear;
        private System.Windows.Forms.Label lblHeadTeacher;
        private System.Windows.Forms.TextBox txtHeadTeacher;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnUpdateClass;
        private System.Windows.Forms.Button btnDeleteClass;
        private System.Windows.Forms.Button btnClearClass;
        private System.Windows.Forms.DataGridView dgvClasses;
        private System.Windows.Forms.Panel pnlClassStudents;
        private System.Windows.Forms.Label lblClassStudentsTitle;
        private System.Windows.Forms.DataGridView dgvClassStudents;
        private System.Windows.Forms.Label lblMoveTo;
        private System.Windows.Forms.ComboBox cboMoveTargetClass;
        private System.Windows.Forms.Button btnMoveStudent;
        private System.Windows.Forms.TabPage tabDepartments;
        private System.Windows.Forms.SplitContainer splitDept;
        private System.Windows.Forms.Panel pnlDeptInput;
        private System.Windows.Forms.Label lblDeptHeader;
        private System.Windows.Forms.Label lblDeptID;
        private System.Windows.Forms.TextBox txtDeptID;
        private System.Windows.Forms.Label lblDeptName;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.Label lblDeptDesc;
        private System.Windows.Forms.TextBox txtDeptDesc;
        private System.Windows.Forms.Button btnAddDept;
        private System.Windows.Forms.Button btnUpdateDept;
        private System.Windows.Forms.Button btnDeleteDept;
        private System.Windows.Forms.Button btnClearDept;
        private System.Windows.Forms.DataGridView dgvDepartments;
    }
}
