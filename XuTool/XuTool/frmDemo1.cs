using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace XuTool
{
    public partial class frmDemo1 : Form
    {
        public frmDemo1()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeListView()
        {
            // Thêm cột cho ListView
            //listViewFuncion.Columns.Add("Chức năng", 150);
            //listViewFuncion.CheckBoxes = false; // Bật checkbox
            // Gán sự kiện cho ListView
            //listViewFuncion.ItemChecked += ListView1_ItemChecked;
        }
        private void AddFunctionToListView(string functionName)
        {
            // Tạo một ListViewItem mới
            ListViewItem newItem = new ListViewItem(functionName);
            newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = $"tào{12} lao"  });
            newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "tào"  });
            //newItem.Checked = true; // Chọn mặc định

            // Thêm ListViewItem vào ListView
            listViewFuncion.Items.Add(newItem);
        }
        // để chạy chức năng 

        private void StartFunctionToListView(string functionName)
        {
            switch(functionName)
            {
                case "Chạy LD":
                    StartEmulator();
                    break;
            }
        }
        //private void ListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        //{
        //    // Xử lý sự kiện khi một item được check hoặc uncheck
        //    string selectedFunctionName = e.Item.Text;

        //    if (e.Item.Checked)
        //    {
        //        // Nếu được chọn, thêm vào danh sách chạy
        //    }
        //    else
        //    {
        //        // Nếu không được chọn, xóa khỏi danh sách chạy
        //    }
        //}
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFuncion.Items)
            {
                if (item.Checked)
                {
                    StartFunctionToListView(item.Text);
                    //item.SubItems[0].ToString();
                    MessageBox.Show($"Chạy chức năng: {item.SubItems[2].ToString()}");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddFunctionToListView("Chạy LD");
        }
        private Process emulatorProcess;
        private void StartEmulator()
        {
            emulatorProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"D:\\LDPlayer\\LDPlayer9\\dnplayer.exe",
                    Arguments = "-avd LDPlayer",
                    UseShellExecute = true
                }
            };
            emulatorProcess.Start();
            System.Threading.Thread.Sleep(5000);
        }
    }

    //form mới
    public class AddFunctionForm : Form
    {
        public string FunctionName { get; private set; }

        public AddFunctionForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Tạo các thành phần giao diện người dùng cần thiết cho Form nhập chức năng
            // Ví dụ: TextBox cho tên chức năng và nút "OK" để xác nhận
            TextBox txtFunctionName = new TextBox
            {
                Top = 10,
                Left = 10
            };

            Button btnOK = new Button
            {
                Text = "OK",
                Top = txtFunctionName.Bottom + 10,
                Left = 10
            };
            btnOK.Click += BtnOK_Click;

            // Thêm các thành phần vào Form
            Controls.Add(txtFunctionName);
            Controls.Add(btnOK);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ TextBox
            FunctionName = ((TextBox)Controls[0]).Text;

            // Đóng Form và trả về DialogResult.OK
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
