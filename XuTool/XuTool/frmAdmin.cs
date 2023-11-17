using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XuTool
{
    public partial class frmAdmin : Form
    {
        CustomerDAO customer=new CustomerDAO();
        public frmAdmin()
        {
            InitializeComponent();
            DSCR();
        }
        string insertupdate = "";
        private void DSCR()
        {
            datagvHK.DataSource = customer.getList();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            insertupdate = "insert";
            btnLuu.Enabled = true;
            txtIDKH.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            insertupdate = "update";
            btnLuu.Enabled = true;
            txtIDKH.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDKH.Text.Length == 0)
                {
                    throw new Exception("Mã Khách Hàng phải có ít nhất 1 ký tự");
                }
                if (txtName.Text.Length <= 1)
                {
                    throw new Exception("Tên Khách hàng phải có ít nhất 1 ký tự");
                }
                if(txtUserName.Text.Length <= 1)
                {
                    throw new Exception("Không được để trống ");

                }
                if(txtNumberPhone.Text.Length <= 1)
                {
                    throw new Exception("Không được để trống SĐT");

                }
                int day = 0;
                if (!int.TryParse(txtNumberofDay.Text, out day))
                {
                    
                    throw new Exception("Không được để trống Ngày");
                }
                string name = txtName.Text;
                string userName = txtUserName.Text;
                string pass = txtPass.Text;
                string Sdt = txtNumberPhone.Text;
                Customer sv = new Customer(name,userName,pass,Sdt,day);
                switch (insertupdate)
                {
                    case "insert":
                        {
                            customer.InsertSV(sv);
                            DSCR();
                            MessageBox.Show("Thêm thành công", "thông báo");
                            break;
                        }
                    case "update":
                        {
                            customer.UpdateSV(sv);
                            DSCR();
                            MessageBox.Show("cập nhật thành công", "thông báo");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Length <= 0)
                {
                    throw new Exception("Mã Khách hàng Không được để trống");
                }
                int id =int.Parse(txtIDKH.Text);
                DSCR();
                customer.DeleteSV(id);
                MessageBox.Show("Xóa thành công", "thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datagvHK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1 || rowindex >= datagvHK.Rows.Count - 1)
                {
                    throw new Exception("Chưa chọn sinh viên");
                }
                txtIDKH.Text = datagvHK.Rows[rowindex].Cells["customer_id"].Value.ToString();
                txtUserName.Text = datagvHK.Rows[rowindex].Cells["username"].Value.ToString();
                txtName.Text = datagvHK.Rows[rowindex].Cells["display_name"].Value.ToString();
                txtPass.Text = datagvHK.Rows[rowindex].Cells["password"].Value.ToString();
                txtNumberPhone.Text = datagvHK.Rows[rowindex].Cells["phone_number"].Value.ToString();
                txtNumberofDay.Text = datagvHK.Rows[rowindex].Cells["number_of_days"].Value.ToString();
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
                            Application.Exit();
        }

        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
