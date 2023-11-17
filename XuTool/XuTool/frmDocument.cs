using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XuTool
{
    public partial class frmDocument : Form
    {
        public frmDocument()
        {
            InitializeComponent();
        }

        private void btnTakeFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFile();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
           
        }
        string filePath = "";
        private string OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "File VB|*.txt |tất cả file|*.*";
            ofd.Title = "Mở File";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = ofd.FileName;
                filePath = ofd.FileName;
                //MessageBox.Show(ofd.FileName);

            }
            return ofd.FileName;
        }

        //private void Delete(string lineToDelete)
        //{
        //    try
        //    {
        //        // Sử dụng StreamReader để đọc file
        //        using (StreamReader reader = new StreamReader(filePath))
        //        {
        //            // Sử dụng StreamWriter để ghi vào file mới
        //            using (StreamWriter writer = new StreamWriter(filePath))
        //            {
        //                // Đọc từng dòng và xóa dòng cần xóa
        //                while (!reader.EndOfStream)
        //                {
        //                    string line = reader.ReadLine();

        //                    if (line != lineToDelete)
        //                    {
        //                        // Ghi dòng vào file mới nếu nó không phải là dòng cần xóa
        //                        writer.WriteLine(line);
        //                    }
        //                }
        //            }
        //        }

        //        // Xóa file cũ
        //        File.Delete(filePath);

        //        // Đổi tên file mới thành tên file gốc
        //        File.Move("temp_file.txt", filePath);

        //        MessageBox.Show("Đã xóa dòng cụ thể thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonAll.Checked)
                {
                    // Sử dụng StreamReader để đọc dữ liệu từ file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Đọc toàn bộ nội dung của file và hiển thị trong TextBox
                        string fileContent = reader.ReadToEnd();
                        MessageBox.Show(fileContent);
                        //txtContent.Text = fileContent;
                    }
                }
                else
                {
                    // Số dòng cần đọc (ví dụ: dòng thứ 3)
                    int LineNumber = int.Parse( txtLineNumber.Text);

                    using (StreamReader reader = new StreamReader(filePath))
                    {
                       
                            // Đọc từng dòng cho đến khi đến dòng cần lấy
                            for (int i = 1; i < LineNumber; i++)
                            {
                                // Nếu không còn dòng nào để đọc, thoát khỏi vòng lặp
                                if (reader.ReadLine() == null)
                                {
                                    MessageBox.Show("Dòng cần đọc không tồn tại trong file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                            // Đọc và hiển thị dòng cần lấy
                            string targetLine = reader.ReadLine();
                            MessageBox.Show(targetLine);
                            //txtContent.Text = targetLine;
                            //if (checkBoxDelete.Checked)
                            //{
                            //    //Delete(targetLine);
                            //}
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetDevice()
        {
            string deviceID = null;
            var listDevice = KAutoHelper.ADBHelper.GetDevices();
            if (listDevice != null && listDevice.Count > 0)
            {
                deviceID = listDevice.First();
            }
            return deviceID;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnTakeFile.Enabled = true;
            txtFileName.Enabled = true;
        }

        private void btnTestTaketxt_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonDelay.Checked)
                {
                    // Sử dụng StreamReader để đọc từng dòng của file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Xóa nội dung hiện tại của TextBox
                        textBox1.Clear();

                        // Đọc từng dòng và hiển thị trong TextBox
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Xử lý dòng đọc được theo nhu cầu của bạn
                            // Ở đây, chúng ta đơn giản hiển thị từng dòng trong TextBox
                            double delay = double.Parse(txtNumberDelay.Text);
                            KAutoHelper.ADBHelper.Delay(delay);
                            //Thread.Sleep(TimeSpan.FromSeconds(1));
                            textBox1.AppendText(line + Environment.NewLine);
                        }
                    }
                }
                else
                {
                    // Sử dụng StreamReader để đọc dữ liệu từ file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Đọc toàn bộ nội dung của file và hiển thị trong TextBox
                        string fileContent = reader.ReadToEnd();
                        textBox1.Text = fileContent;
                        //txtContent.Text = fileContent;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
