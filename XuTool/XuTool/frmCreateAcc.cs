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
    public partial class frmCreateAcc : Form
    {
        CustomerDAO customerDAO=new CustomerDAO();
        public frmCreateAcc()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtName.Text.Length == 0)
                {
                    throw new Exception("Không được để trống");
                }
                if (txtPassWord.Text.Length == 0)
                {
                    throw new Exception("Không được để trống");
                }
                if (txtUsername.Text.Length == 0)
                {
                    throw new Exception("Không được để trống");
                }
                if (txtNumberPhone.Text.Length == 0 && txtNumberPhone.Text.Length>=10)
                {
                    throw new Exception("Không được để trống và không được vượt quá 10 số");
                }
                if (txtPassWord.Text == txtConfim.Text)
                {
                    customerDAO.CreateACC(txtUsername.Text, txtName.Text, txtPassWord.Text, txtNumberPhone.Text, 30);
                    MessageBox.Show("Đăng ký Thành công", "Thôn báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu không khớp");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
