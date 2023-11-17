using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XuTool
{
    public partial class frmProfile : Form
    {
        public frmProfile()
        {
            InitializeComponent();
        }
        public string username;
        public void UserName(string name)
        {
            username = name;
            MessageBox.Show(name);
        }
        private void frmProfile_Load(object sender, EventArgs e)
        {
            getRow();
        }
        SqlConnection conn = null;
        SqlCommand cmd = null;
        public void getRow()
        {
            //string sql = "SELECT *";
            //sql += " FROM customers WHERE username =@Username";
            //cmd = new SqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@Username", "Vuhieu");

            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.Read())
            //{
            //    txtUserName.Text = reader.GetString(reader.GetOrdinal("username"));
            //   txtName.Text = reader.GetString(reader.GetOrdinal("display_name"));
            //    txtNumberphone.Text = reader.GetString(reader.GetOrdinal("phone_number"));
            //    int day = reader.GetInt32(reader.GetOrdinal("number_of_days"));
            //    txtNumberofDay.Text=day.ToString();
            //MessageBox.Show($"Thông tin người dùng:\nUsername: {username}\nDisplay Name: {displayName}\nPhone Number: {phoneNumber}\nNumber of Days: {numberOfDays}");
            //}
            //cmd.ExecuteNonQuery();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            txtNumberphone.Enabled = true;
            txtNumberofDay.Enabled = true;
            txtUserName.Enabled = true;
        }
        private void Updata()
        {
            string username = txtUserName.Text;
            string name = txtName.Text;
            string numberphone = txtNumberphone.Text;
            int Numberphone = int.Parse(txtNumberphone.Text);
            string sql = "UPDATE customers SET username = @NewUsername, display_name = @NewDisplayName, phone_number = @NewPhoneNumber, number_of_days = @NewNumberOfDays ";
            sql += " WHERE username = @NewUsername";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@NewUsername", username);
            cmd.Parameters.AddWithValue("@NewDisplayName", name);
            //cmd.Parameters.AddWithValue("@NewPassword", txtPassnew.Text);
            cmd.Parameters.AddWithValue("@NewPhoneNumber", numberphone);
            cmd.Parameters.AddWithValue("@NewNumberOfDays", Numberphone);
            cmd.ExecuteNonQuery();
          

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Length <= 1)
                {
                    throw new Exception("Tên Khách hàng phải có ít nhất 1 ký tự");
                }
                if (txtUserName.Text.Length <= 1)
                {
                    throw new Exception("Không được để trống ");

                }
                if (txtNumberphone.Text.Length <= 1)
                {
                    throw new Exception("Không được để trống SĐT");

                }
                int day = 0;
                if (!int.TryParse(txtNumberofDay.Text, out day))
                {

                    throw new Exception("Không được để trống Ngày");
                }
                if (txtUserName.Enabled)
                {
                    Updata();
                }
                if (panel4.Enabled)
                {
                    string sql = "UPDATE customers SET password = @NewPassword";
                    sql += " FROM customers WHERE username =@Username";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@NewPassword", txtPassnew.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
