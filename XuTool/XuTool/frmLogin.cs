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
    public partial class frmLogin : Form
    {
        CustomerDAO customerDAO=new CustomerDAO();
        //frmProfile frmProfile ;
        public frmLogin()
        {
            InitializeComponent();
            //frmProfile = new frmProfile();
        }
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát?","Thông Báo",MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }    
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Length == 0)
                {
                    throw new Exception("Không được để trống tên đăng nhập");
                }
                if (txtPassWord.Text.Length == 0)
                {
                    throw new Exception("Không được để trống tên đăng nhập");
                }
                if(customerDAO.AuthenticateUser(txtUserName.Text, txtPassWord.Text))
                {
                    frmmain frm = new frmmain();
                    this.Hide();
                    frm.ShowDialog();
                    //frmProfile.UserName(txtUserName.Text);
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Thất Bại. Vui lòng kiểm tra lại tên đăng nhập và mật khẩu.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            frmCreateAcc frmCreateAcc = new frmCreateAcc();
            this.Hide();
            frmCreateAcc.ShowDialog();
            this.Show();
        }
        
    }
}
