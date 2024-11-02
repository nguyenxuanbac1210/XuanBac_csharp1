//Data Source = DESKTOP - 7VLUV12\MSSQLSERVER05; Initial Catalog = Employee; Persist Security Info=True; User ID = sa; Trust Server Certificate=True
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing; // Ensure you have this using directive for Image
using System.Data.SqlClient;
using System.Net;

namespace Quanlyview
{
    public partial class Quanly : Form
    {
        private string strCon = @"Data Source=DESKTOP-7VLUV12\MSSQLSERVER07;Initial Catalog=Employee;User ID=sa;Password=123;Encrypt=False";
        private SqlConnection sqlCon; // Khai báo SqlConnection

        public List<Employee> lstEmp = new List<Employee>();
        private BindingSource bs = new BindingSource();
        public bool isThoat = true;
        public event EventHandler DangXuat;

        private string employeeImagePath = string.Empty; // Store the image path

        public Quanly()
        {
            InitializeComponent();
            SetupImageList();
            tbSearch.TextChanged += tbSearch_TextChanged;


            //ngay sinh
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MMMM yyyy";
            // Handle value changes (optional)
            dateTimePicker1.ShowUpDown = false;

            tbPhone.KeyPress += TbPhone_KeyPress;

        }



        private void Quanly_Load(object sender, EventArgs e)
        {
            lstEmp = GetData();
            bs.DataSource = lstEmp;
            dgvEmployee.DataSource = bs;
            SetupDataGridView(); // Setup DataGridView columns
            dateTimePicker1.Value = DateTime.Now; // Set the default date to now
            dgvEmployee.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public List<Employee> GetData()
        {
            List<Employee> employee = new List<Employee>();

            using (sqlCon = new SqlConnection(strCon)) // Sử dụng từ khóa using để quản lý tài nguyên
            {
                sqlCon.Open(); // Mở kết nối

                // Câu truy vấn để lấy dữ liệu
                string query = "SELECT Id, Name, BirthDate, Gender, Phone, MaLop, NganhHoc, ImagePath FROM Employee";

                using (SqlCommand cmd = new SqlCommand(query, sqlCon)) // Tạo SqlCommand
                {
                    using (SqlDataReader reader = cmd.ExecuteReader()) // Sử dụng using cho SqlDataReader
                    {
                        while (reader.Read()) // Đọc dữ liệu
                        {
                            Employee emp = new Employee
                            {
                                Id = reader.GetInt32(0), // Mã
                                Name = reader.GetString(1), // Tên
                                BirthDate = reader.GetDateTime(2), // Ngày sinh
                                Gender = reader.GetBoolean(3), // Giới tính
                                Phone = reader.GetString(4),
                                MaLop = reader.GetString(5),
                                NganhHoc = reader.GetString(6),
                                ImagePath = reader.IsDBNull(7) ? null : reader.GetString(7) // Ảnh
                            };
                            employee.Add(emp); // Thêm vào danh sách
                        }
                    }
                }
            }
            return employee; // Trả về danh sách nhân viên
        }
        private void AddEmployee(Employee newEmp)
        {
            using (sqlCon = new SqlConnection(strCon))
            {
                sqlCon.Open();
                string query = "INSERT INTO Employee (Id, Name, BirthDate, Gender, Phone, MaLop, NganhHoc, ImagePath) VALUES (@Id, @Name, @BirthDate, @Gender, @Phone, @MaLop, @NganhHoc, @ImagePath)";

                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Id", newEmp.Id);
                    cmd.Parameters.AddWithValue("@Name", newEmp.Name);
                    cmd.Parameters.AddWithValue("@BirthDate", newEmp.BirthDate);
                    cmd.Parameters.AddWithValue("@Gender", newEmp.Gender);
                    cmd.Parameters.AddWithValue("@Phone", newEmp.Phone);
                    cmd.Parameters.AddWithValue("@MaLop", newEmp.MaLop);
                    cmd.Parameters.AddWithValue("@NganhHoc", newEmp.NganhHoc);
                    cmd.Parameters.AddWithValue("@ImagePath", newEmp.ImagePath);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void UpdateEmployee(Employee emp)
        {
            using (sqlCon = new SqlConnection(strCon))
            {
                sqlCon.Open();
                string query = "UPDATE Employee SET Name=@Name, BirthDate=@BirthDate, Gender=@Gender, Phone=@Phone, MaLop=@MaLop, NganhHoc=@NganhHoc, ImagePath=@ImagePath WHERE Id=@Id";

                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Id", emp.Id);
                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@BirthDate", emp.BirthDate);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Phone", emp.Phone);
                    cmd.Parameters.AddWithValue("@MaLop", emp.MaLop);
                    cmd.Parameters.AddWithValue("@NganhHoc", emp.NganhHoc);
                    cmd.Parameters.AddWithValue("@ImagePath", emp.ImagePath);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void TbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là số và không phải là phím xóa
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự này
                MessageBox.Show("Số điện thoại chỉ được chứa các ký tự số.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteEmployee(int empId)
        {
            using (sqlCon = new SqlConnection(strCon))
            {
                sqlCon.Open();
                string query = "DELETE FROM Employee WHERE Id=@Id";

                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Id", empId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SetupDataGridView()
        {
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployee.Columns[0].HeaderText = "Mã Sinh Viên";
            dgvEmployee.Columns[1].HeaderText = "Tên";
            dgvEmployee.Columns[2].HeaderText = "Ngày Sinh";
            dgvEmployee.Columns[3].HeaderText = "Giới Tính";
            dgvEmployee.Columns[4].HeaderText = "Số Điện Thoại";
            dgvEmployee.Columns[5].HeaderText = "Mã Lớp Học";
            dgvEmployee.Columns[6].HeaderText = "Ngành Học ";
            dgvEmployee.Columns[7].HeaderText = "Ảnh"; // Add header for Birth Date
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat?.Invoke(this, EventArgs.Empty);
        }

        private void Quanly_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat) Application.Exit();
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            if (!IsInputValid()) return; // Nếu dữ liệu không hợp lệ, dừng lại

            try
            {
                int newId = int.Parse(tbId.Text);
                if (lstEmp.Any(emp => emp.Id == newId))
                {
                    MessageBox.Show("Lỗi: ID đã tồn tại. Vui lòng nhập ID khác.");
                    return;
                }

                // Kiểm tra nếu tên chứa ký tự không phải là chữ
                if (tbName.Text.Any(ch => !char.IsLetter(ch) && !char.IsWhiteSpace(ch)))
                {
                    MessageBox.Show("Lỗi: Tên sinh viên không được chứa số hoặc ký tự đặc biệt.");
                    return;
                }

                var newEmp = new Employee
                {
                    Id = newId,
                    Name = tbName.Text,
                    Gender = ckGender.Checked,
                    Phone = tbPhone.Text,
                    NganhHoc = tbNganhHoc.Text,
                    MaLop = cbMaLop.Text,
                    ImagePath = employeeImagePath,
                    BirthDate = dateTimePicker1.Value.Date
                };

                lstEmp.Add(newEmp);
                AddEmployee(newEmp);
                RefreshBindings();
                ClearInputFields();
                tbId.Enabled = true; // Bật lại ô ID cho lần nhập mới
            }
            catch (FormatException)
            {
                MessageBox.Show("Lỗi: Vui lòng nhập số nguyên hợp lệ cho ID.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }




        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow == null) return;

            int idx = dgvEmployee.CurrentRow.Index;
            var emp = lstEmp[idx];
            int originalId = emp.Id; // Lưu ID ban đầu

            try
            {
                // Kiểm tra nếu người dùng thay đổi ID
                int newId = int.Parse(tbId.Text);
                if (newId != originalId)
                {
                    MessageBox.Show("Lỗi: Không được thay đổi mã sinh viên. ID sẽ được khôi phục về giá trị ban đầu.");
                    tbId.Text = originalId.ToString(); // Khôi phục ID cũ trong ô nhập liệu
                    return;
                }

                // Kiểm tra nếu tên chứa ký tự không phải là chữ
                if (tbName.Text.Any(ch => !char.IsLetter(ch) && !char.IsWhiteSpace(ch)))
                {
                    MessageBox.Show("Lỗi: Tên sinh viên không được chứa số hoặc ký tự đặc biệt.");
                    return;
                }

                // Cập nhật các thông tin khác của nhân viên
                emp.Name = tbName.Text;
                emp.Gender = ckGender.Checked;
                emp.Phone = tbPhone.Text;
                emp.NganhHoc = tbNganhHoc.Text;
                emp.MaLop = cbMaLop.Text;
                emp.ImagePath = employeeImagePath;
                emp.BirthDate = dateTimePicker1.Value.Date;

                UpdateEmployee(emp); // Cập nhật vào cơ sở dữ liệu
                RefreshBindings(); // Làm mới dữ liệu hiển thị
                ClearInputFields(); // Xóa trường nhập liệu
            }
            catch (FormatException)
            {
                MessageBox.Show("Lỗi: Vui lòng nhập số nguyên hợp lệ cho ID.");
                tbId.Text = originalId.ToString(); // Khôi phục ID cũ trong trường hợp nhập sai định dạng
            }
        }




        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow == null) return;

            int idx = dgvEmployee.CurrentRow.Index;
            var empId = lstEmp[idx].Id;

            lstEmp.RemoveAt(idx);
            DeleteEmployee(empId);
            RefreshBindings();
        }

        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= lstEmp.Count) return;

            // Clear input fields before populating them with employee data
            ClearInputFields();

            var emp = lstEmp[e.RowIndex];

            // Populate the input fields with the selected employee's data
            tbId.Text = emp.Id.ToString();
            tbName.Text = emp.Name;
            ckGender.Checked = emp.Gender;
            tbPhone.Text = emp.Phone;
            tbNganhHoc.Text = emp.NganhHoc;
            cbMaLop.Text = emp.MaLop;

            // Set the date of birth, or use the current date if none is available
            dateTimePicker1.Value = (emp.BirthDate != DateTime.MinValue) ? emp.BirthDate : DateTime.Now;

            // Load the employee's image if it exists
            if (!string.IsNullOrEmpty(emp.ImagePath) && System.IO.File.Exists(emp.ImagePath))
            {
                pbEmployeeImage.Image = Image.FromFile(emp.ImagePath);
            }
            else
            {
                pbEmployeeImage.Image = null;

            }
        }
        //private void dgvManager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0 || e.RowIndex >= lstEmp.Count) return;

        //    var emp = lstEmp[e.RowIndex];

        //    tbId.Text = emp.Id.ToString();
        //    tbName.Text = emp.Name;
        //    ckGender.Checked = emp.Gender;
        //    tbPhone.Text = emp.Phone;
        //    tbNganhHoc.Text = emp.NganhHoc;
        //    cbMaLop.Text = emp.MaLop;
        //    if (emp.BirthDate != null && emp.BirthDate >= dateTimePicker1.MinDate && emp.BirthDate <= dateTimePicker1.MaxDate)
        //    {
        //        dateTimePicker1.Value = emp.BirthDate;
        //    }
        //    else
        //    {
        //        dateTimePicker1.Value = DateTime.Now; // Default to current date
        //    }


        //    if (File.Exists(emp.ImagePath))
        //    {
        //        pbEmployeeImage.Image = Image.FromFile(emp.ImagePath);
        //    }
        //    else
        //    {
        //        pbEmployeeImage.Image = null;
        //    }
        //}

        private void RefreshBindings()
        {
            bs.DataSource = lstEmp.ToList();
            bs.ResetBindings(false);
            dgvEmployee.ClearSelection(); // Optional: Clear selection for better UX
        }

        private void ClearInputFields()
        {
            tbId.Text = "";
            tbId.Enabled = true; // Bật lại ô ID

            tbName.Text = "";
            tbPhone.Text = "";
            tbNganhHoc.Text = "";
            cbMaLop.Text = "";
            ckGender.Checked = false;
            pbEmployeeImage.Image = null;
            dateTimePicker1.Value = DateTime.Now;
        }

        private bool IsInputValid()
        {
            // Kiểm tra tất cả các ô nhập liệu, nếu ô nào trống thì trả về false
            if (string.IsNullOrWhiteSpace(tbId.Text) ||
                string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbPhone.Text) ||
                string.IsNullOrWhiteSpace(tbNganhHoc.Text) ||
                string.IsNullOrWhiteSpace(cbMaLop.Text) ||
                pbEmployeeImage.Image == null) // Kiểm tra nếu chưa chọn ảnh
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả các thông tin và chọn ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }




        private void SetupImageList()
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(24, 24);

            // Add images to ImageList (make sure paths are correct)
            imageList.Images.Add(Image.FromFile("Images/add.png"));    // Index 0
            imageList.Images.Add(Image.FromFile("Images/edit.png"));   // Index 1
            imageList.Images.Add(Image.FromFile("Images/delete.png")); // Index 2

            // Assign ImageList to buttons
            btAddNew.ImageList = imageList;
            btAddNew.ImageIndex = 0;

            btEdit.ImageList = imageList;
            btEdit.ImageIndex = 1;

            btDelete.ImageList = imageList;
            btDelete.ImageIndex = 2;
        }

        private void btSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    employeeImagePath = ofd.FileName; // Store the image path
                    pbEmployeeImage.Image = Image.FromFile(employeeImagePath); // Show the image
                }
            }
        }

        // Method to set a specific date for the DateTimePicker (if needed)
        private void SetDateForDateTimePicker(DateTime date)
        {
            dateTimePicker1.Value = date; // Set a specific date, e.g. new DateTime(2024, 10, 17)
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            // Do something with the selected date
            this.Text = dateTimePicker1.Value.ToString("dd MMMM yyyy");
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbMaphongban_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                bs.DataSource = lstEmp; // Nếu ô tìm kiếm trống, hiển thị danh sách đầy đủ
            }
            else
            {
                var filteredList = lstEmp.Where(emp =>
                    emp.Id.ToString().Contains(searchTerm) || // Tìm theo mã sinh viên (chuyển sang chuỗi)
                    emp.Name.ToLower().Contains(searchTerm) ||
                 
                    emp.Phone.Contains(searchTerm) || // Tìm theo số điện thoại
                   
                    emp.MaLop.ToLower().Contains(searchTerm) ||
                    emp.NganhHoc.ToLower().Contains(searchTerm)
                ).ToList();
                    
                bs.DataSource = filteredList; // Cập nhật BindingSource với kết quả tìm kiếm
            }

            bs.ResetBindings(false); // Làm mới DataGridView để hiển thị kết quả lọc
        }
    }
}
