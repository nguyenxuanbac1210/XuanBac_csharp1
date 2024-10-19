namespace Quanlyview
{
    partial class Quanly
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btThoat = new Button();
            btDangXuat = new Button();
            dgvEmployee = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbId = new TextBox();
            tbName = new TextBox();
            ckGender = new CheckBox();
            btAddNew = new Button();
            btEdit = new Button();
            btDelete = new Button();
            label5 = new Label();
            tbAddress = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            cbMaphongban = new ComboBox();
            tbMaduan = new TextBox();
            pbEmployeeImage = new PictureBox();
            btSelectImage = new Button();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEmployeeImage).BeginInit();
            SuspendLayout();
            // 
            // btThoat
            // 
            btThoat.Location = new Point(1186, 13);
            btThoat.Margin = new Padding(3, 4, 3, 4);
            btThoat.Name = "btThoat";
            btThoat.Size = new Size(84, 32);
            btThoat.TabIndex = 0;
            btThoat.Text = "Thoát";
            btThoat.UseVisualStyleBackColor = true;
            btThoat.Click += btThoat_Click;
            // 
            // btDangXuat
            // 
            btDangXuat.Location = new Point(1138, 468);
            btDangXuat.Margin = new Padding(3, 4, 3, 4);
            btDangXuat.Name = "btDangXuat";
            btDangXuat.Size = new Size(91, 32);
            btDangXuat.TabIndex = 1;
            btDangXuat.Text = "Đăng xuất";
            btDangXuat.UseVisualStyleBackColor = true;
            btDangXuat.Click += btDangXuat_Click;
            // 
            // dgvEmployee
            // 
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Location = new Point(28, 44);
            dgvEmployee.Margin = new Padding(3, 4, 3, 4);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.RowHeadersWidth = 51;
            dgvEmployee.Size = new Size(1242, 125);
            dgvEmployee.TabIndex = 2;
            dgvEmployee.CellContentClick += dgvEmployee_CellContentClick;
            dgvEmployee.RowEnter += dgvEmployee_RowEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(746, 337);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 3;
            label1.Text = "Mã Môn Học ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(216, 275);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 4;
            label2.Text = "Tên";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(216, 333);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 5;
            label3.Text = "Tuổi";
            // 
            // tbId
            // 
            tbId.Location = new Point(294, 196);
            tbId.Margin = new Padding(3, 4, 3, 4);
            tbId.Name = "tbId";
            tbId.Size = new Size(247, 27);
            tbId.TabIndex = 6;
            tbId.TextChanged += tbId_TextChanged;
            // 
            // tbName
            // 
            tbName.Location = new Point(294, 268);
            tbName.Margin = new Padding(3, 4, 3, 4);
            tbName.Name = "tbName";
            tbName.Size = new Size(247, 27);
            tbName.TabIndex = 8;
            // 
            // ckGender
            // 
            ckGender.AutoSize = true;
            ckGender.Checked = true;
            ckGender.CheckState = CheckState.Checked;
            ckGender.Location = new Point(369, 380);
            ckGender.Margin = new Padding(3, 4, 3, 4);
            ckGender.Name = "ckGender";
            ckGender.Size = new Size(63, 24);
            ckGender.TabIndex = 9;
            ckGender.Text = "Nam";
            ckGender.UseVisualStyleBackColor = true;
            // 
            // btAddNew
            // 
            btAddNew.Location = new Point(216, 464);
            btAddNew.Margin = new Padding(3, 4, 3, 4);
            btAddNew.Name = "btAddNew";
            btAddNew.Size = new Size(56, 40);
            btAddNew.TabIndex = 10;
            btAddNew.UseVisualStyleBackColor = true;
            btAddNew.Click += btAddNew_Click;
            // 
            // btEdit
            // 
            btEdit.Location = new Point(321, 464);
            btEdit.Margin = new Padding(3, 4, 3, 4);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(56, 40);
            btEdit.TabIndex = 11;
            btEdit.UseVisualStyleBackColor = true;
            btEdit.Click += btEdit_Click;
            // 
            // btDelete
            // 
            btDelete.Location = new Point(436, 464);
            btDelete.Margin = new Padding(3, 4, 3, 4);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(56, 40);
            btDelete.TabIndex = 12;
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(586, 5);
            label5.Name = "label5";
            label5.Size = new Size(222, 35);
            label5.TabIndex = 13;
            label5.Text = "Quản Lý Sinh Viên ";
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(858, 199);
            tbAddress.Margin = new Padding(3, 4, 3, 4);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(239, 27);
            tbAddress.TabIndex = 14;
            tbAddress.TextChanged += tbAddress_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(173, 202);
            label6.Name = "label6";
            label6.Size = new Size(99, 20);
            label6.TabIndex = 17;
            label6.Text = "Mã Sinh Viên ";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(746, 268);
            label7.Name = "label7";
            label7.Size = new Size(90, 20);
            label7.TabIndex = 18;
            label7.Text = "Mã Lớp Học";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(746, 202);
            label8.Name = "label8";
            label8.Size = new Size(102, 20);
            label8.TabIndex = 19;
            label8.Text = "Số Điện Thoại";
            // 
            // cbMaphongban
            // 
            cbMaphongban.FormattingEnabled = true;
            cbMaphongban.Items.AddRange(new object[] { "CCQ2211M", "CCQ2211A", "CCQ2211G", "CCQ2211C" });
            cbMaphongban.Location = new Point(858, 260);
            cbMaphongban.Margin = new Padding(3, 4, 3, 4);
            cbMaphongban.Name = "cbMaphongban";
            cbMaphongban.Size = new Size(239, 28);
            cbMaphongban.TabIndex = 20;
            cbMaphongban.SelectedIndexChanged += cbMaphongban_SelectedIndexChanged;
            // 
            // tbMaduan
            // 
            tbMaduan.Location = new Point(858, 330);
            tbMaduan.Margin = new Padding(3, 4, 3, 4);
            tbMaduan.Name = "tbMaduan";
            tbMaduan.Size = new Size(239, 27);
            tbMaduan.TabIndex = 21;
            // 
            // pbEmployeeImage
            // 
            pbEmployeeImage.Location = new Point(858, 380);
            pbEmployeeImage.Margin = new Padding(3, 4, 3, 4);
            pbEmployeeImage.Name = "pbEmployeeImage";
            pbEmployeeImage.Size = new Size(107, 114);
            pbEmployeeImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEmployeeImage.TabIndex = 22;
            pbEmployeeImage.TabStop = false;
            // 
            // btSelectImage
            // 
            btSelectImage.Location = new Point(727, 380);
            btSelectImage.Margin = new Padding(3, 4, 3, 4);
            btSelectImage.Name = "btSelectImage";
            btSelectImage.Size = new Size(109, 33);
            btSelectImage.TabIndex = 23;
            btSelectImage.Text = "Chọn ảnh...";
            btSelectImage.UseVisualStyleBackColor = true;
            btSelectImage.Click += btSelectImage_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(294, 328);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(247, 27);
            dateTimePicker1.TabIndex = 24;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // Quanly
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1290, 559);
            Controls.Add(dateTimePicker1);
            Controls.Add(btSelectImage);
            Controls.Add(pbEmployeeImage);
            Controls.Add(tbMaduan);
            Controls.Add(cbMaphongban);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(tbAddress);
            Controls.Add(label5);
            Controls.Add(btDelete);
            Controls.Add(btEdit);
            Controls.Add(btAddNew);
            Controls.Add(ckGender);
            Controls.Add(tbName);
            Controls.Add(tbId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvEmployee);
            Controls.Add(btDangXuat);
            Controls.Add(btThoat);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Quanly";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quanly";
            FormClosed += Quanly_FormClosed;
            Load += Quanly_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbEmployeeImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btThoat;
        private Button btDangXuat;
        private DataGridView dgvEmployee;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbId;
        private TextBox tbName;
        private CheckBox ckGender;
        private Button btAddNew;
        private Button btEdit;
        private Button btDelete;
        private Label label5;
        private TextBox tbAddress;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox cbMaphongban;
        private TextBox tbMaduan;
        private PictureBox pbEmployeeImage;
        private Button btSelectImage;
        private DateTimePicker dateTimePicker1;
    }
}