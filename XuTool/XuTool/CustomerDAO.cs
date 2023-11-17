using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace XuTool
{
    internal class CustomerDAO
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter adapter = null;
        KetNoi Kn = new KetNoi();
        public CustomerDAO()
        {
            conn = Kn.GetConnect();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public DataTable getList()
        {
            string sql = "SELECT * FROM customers";
            cmd = new SqlCommand(sql, conn);
            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public int getCount()
        {
            string sql = "SELECT COUNT(username) FROM customers";
            cmd = new SqlCommand(sql, conn);
            int count = (int)cmd.ExecuteScalar();
            return count;
        }
        
        public void InsertSV(Customer cr)
        {
            string sql = "INSERT INTO customers (username, display_name, password, phone_number, number_of_days) VALUES (@Username, @DisplayName, @Password, @PhoneNumber, @NumberOfDays)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Username", cr.Name);
            cmd.Parameters.AddWithValue("@DisplayName", cr.UserName);
            cmd.Parameters.AddWithValue("@Password", cr.PassWord);
            cmd.Parameters.AddWithValue("@PhoneNumber", cr.SĐT);
            cmd.Parameters.AddWithValue("@NumberOfDays", cr.Number0fDay);
            cmd.ExecuteNonQuery();
        }
        public void UpdateSV(Customer cr)
        {
            string sql = "UPDATE customers SET username = @NewUsername, display_name = @NewDisplayName,password = @NewPassword, phone_number = @NewPhoneNumber, number_of_days = @NewNumberOfDays ";
            sql += " WHERE username = @NewUsername";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@NewUsername", cr.Name);
            cmd.Parameters.AddWithValue("@NewDisplayName", cr.UserName);
            cmd.Parameters.AddWithValue("@NewPassword", cr.PassWord);
            cmd.Parameters.AddWithValue("@NewPhoneNumber", cr.SĐT);
            cmd.Parameters.AddWithValue("@NewNumberOfDays", cr.Number0fDay);
            cmd.ExecuteNonQuery();

        }
        public void DeleteSV(int customerId)
        {
            string sql = "DELETE FROM customers WHERE customer_id = @CustomerId";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CustomerId", customerId);
            cmd.ExecuteNonQuery();
        }
        public bool AuthenticateUser(string username, string password)
        {
            string query = "SELECT * FROM customers WHERE username = @Username AND password = @Password";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                return true;
        }
        public void CreateACC(string username,string name, string password,string sdt,int day)
        {
            string sql = "INSERT INTO customers (username, display_name, password, phone_number, number_of_days) VALUES (@Username, @DisplayName, @Password, @PhoneNumber, @NumberOfDays)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@DisplayName", name);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@PhoneNumber", sdt);
            cmd.Parameters.AddWithValue("@NumberOfDays", day);
            cmd.ExecuteNonQuery();
        }
        public bool AuthenticateAmin(string password)
        {
            string query = "SELECT * FROM admin WHERE password = @Password";

            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Password", password);
            return true;
        }
    }
}
