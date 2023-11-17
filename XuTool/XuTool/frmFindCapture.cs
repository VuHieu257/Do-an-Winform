using KAutoHelper;
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

namespace XuTool
{
    public partial class frmFindCapture : Form
    {
        public frmFindCapture()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartEmulator();
        }
        private Process emulatorProcess;
        private void StartEmulator()
        {
            emulatorProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    //FileName = @"D:\\LDPlayer\\LDPlayer9\\dnplayer.exe",
                    FileName = txtFile.Text,
                    Arguments = "-avd LDPlayer",
                    UseShellExecute = true
                }
            };
            emulatorProcess.Start();
            System.Threading.Thread.Sleep(5000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        private string OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "File VB|*.txt |exe|*.exe |tất cả file|*.*";
            ofd.Title = "Mở File";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofd.FileName;
                //MessageBox.Show(ofd.FileName);

            }
            return ofd.FileName;
        }
        int x = 0, y = 0;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOSIZE = 0x0001;
        private const int HWND_TOP = 0;
        private void btnRule_Click(object sender, EventArgs e)
        {
            x = int.Parse(txtX.Text);
            y = int.Parse(txtY.Text);
            ResizeEmulator(x, y);
        }

        //thay đổi kích thước
        private void ResizeEmulator(int width, int height)
        {

            if (IsEmulatorRunning())
            {
                //emulatorProcess.WaitForInputIdle();
                //SetWindowPos(emulatorProcess.MainWindowHandle, 0, 0, 0, width, height, 0);
                IntPtr intPtr = IntPtr.Zero;
                intPtr = AutoControl.FindWindowHandle(txtClassName.Text, txtNameApp.Text);
                SetWindowPos(intPtr, 0, 0, 0, width, height, 0);
            }
            else
            {
                MessageBox.Show("Trình giả lập không đang chạy.");
            }
        }
        public new void Click(int x,int y)
        {
            OnDataReceived(x, y);
        }
        public event EventHandler<int> DataReceived;
        public int Y, X;
        public virtual void OnDataReceived(int E, int Z)
        {
            DataReceived?.Invoke(this, E);
            DataReceived?.Invoke(this, Z);
            X= E;
            Y= Z;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //Lấy tọa độ của điểm click trên pictureBox
            //mydata(int.Parse(toolStripButtonX.Text), int.Parse(toolStripButtonY.Text));
            // Tọa độ của sự kiện click chuột
            int clickX = X;
            int clickY = Y;

           if(X !=0 && Y!=0)
            {
                // Kích thước của phần cần cắt (ví dụ: 100x100)
                int cropWidth = 100;
                int cropHeight = 100;

                // Tạo một hình mới để lưu phần đã cắt
                Bitmap croppedImage = new Bitmap(cropWidth, cropHeight);

                // Tạo một đối tượng Graphics để vẽ phần cắt lên hình mới
                using (Graphics g = Graphics.FromImage(croppedImage))
                {
                    // Vẽ phần cắt từ hình gốc
                    g.DrawImage(pictureBoxFindImg.Image, new Rectangle(0, 0, cropWidth, cropHeight),
                                new Rectangle(clickX - cropWidth / 2, clickY - cropHeight / 2, cropWidth, cropHeight),
                                GraphicsUnit.Pixel);
                }
                // Hiển thị hình đã cắt (ví dụ: thông qua PictureBox)
                //PictureBox pictureBox = new PictureBox();
                pictureBoxFindImg.Image = croppedImage;
                pictureBoxFindImg.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            else
            {
                MessageBox.Show("Chưa có giá trị X , Y");
            }

         
           

            //// Hiển thị hình đã cắt trong một form mới (ví dụ)
            //Form croppedImageForm = new Form();
            //croppedImageForm.Controls.Add(pictureBoxFindImg);
            //croppedImageForm.ShowDialog();
        }

        private bool IsEmulatorRunning()
        {
            IntPtr intPtr = IntPtr.Zero;
            intPtr = AutoControl.FindWindowHandle(txtClassName.Text,txtNameApp.Text);
            return intPtr != IntPtr.Zero;
        }
    }
}
