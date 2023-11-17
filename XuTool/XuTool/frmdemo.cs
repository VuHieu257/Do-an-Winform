using KAutoHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace XuTool
{
    public partial class frmdemo : Form
    {
        bool sidebarExpand;
        int x = 0, y = 0;
        int a = 0, b = 0;
        public frmdemo()
        {
            InitializeComponent();
        }

        private void Sidebartimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                //if sidebar is expand,minimize
                Sidebar.Height -= 10;
                if (Sidebar.Height == Sidebar.MinimumSize.Height)
                {
                    sidebarExpand = false;
                    Sidebartimer.Stop();
                }
            }
            else
            {
                Sidebar.Height += 10;
                if (Sidebar.Height == Sidebar.MaximumSize.Height)
                {
                    sidebarExpand = true;
                    Sidebartimer.Stop();
                }
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            Sidebartimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //----------Get the first device------------------ -
            string deviceID = null;
            var listDevice = KAutoHelper.ADBHelper.GetDevices();
            if (listDevice != null && listDevice.Count > 0)
            {
                deviceID = listDevice.First();
            }

            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
            var scre = KAutoHelper.CaptureHelper.ResizeImage(screen, x, y);
            pictureBox1.Image = scre;
            //lấy được tỷ lệ khung hình x,y
            //var tets= KAutoHelper.ADBHelper.GetScreenResolution(deviceID);
            // MessageBox.Show(tets.ToString());

            //Nhấn với tọa độ



            //panel4.
            //screen.GetType();
            //chụp ảnh với theo kích thước

            //Chụp màn hình latop
            //var scre=KAutoHelper.CaptureHelper.CaptureScreen();

            //chụp lại cửa sổ chương trình
            //var scre =KAutoHelper.CaptureHelper.CaptureWindow(Handle);


            //chụp màn hình lưu hình
            //KAutoHelper.CaptureHelper.CaptureScreenToFile("test.png",System.Drawing.Imaging.ImageFormat.Png);

            //chụp lại cửa sổ chương trình
            //var scre = KAutoHelper.CaptureHelper.X;
            //MessageBox.Show(scre.ToString());
            //scre.ToString();
        }
        //thay đổi kích thước của giả lập
        private void button4_Click(object sender, EventArgs e)
        {
            x = int.Parse(txtX.Text);
            y = int.Parse(txtY.Text);
            ResizeEmulator(x, y);
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            StartEmulator();

        }
        private Process emulatorProcess;

        //string emulatorPath = Path.Combine(androidSdkPath, "dnplayer", "D:\\LDPlayer\\LDPlayer9\\dnplayer.exe");

        // Tên của trình giả lập
        //string avdName = "LDPlayer";
        //private void StartEmulator()
        //{
        //    // Đường dẫn đến trình giả lập Android
        //    string emulatorPath = @"D:\LDPlayer\LDPlayer9\dnplayer.exe";

        //    // Tên máy ảo Android
        //    string avdName = "LDPlayer";

        //    // Tạo quy trình để chạy trình giả lập
        //    emulatorProcess = new Process();
        //    emulatorProcess.StartInfo.FileName = emulatorPath;
        //    emulatorProcess.StartInfo.Arguments = $"-avd {avdName}";
        //    emulatorProcess.Start();

        //    // Đợi một khoảng thời gian ngắn để đảm bảo rằng trình giả lập đã khởi động
        //    System.Threading.Thread.Sleep(5000);

        //    // Có thể thêm mã để kiểm tra xem trình giả lập đã khởi động thành công hay không
        //}

        //private void ResizeEmulator()
        //{
        //    // Kiểm tra xem quy trình trình giả lập có đang chạy hay không
        //    if (emulatorProcess != null && !emulatorProcess.HasExited)
        //    {
        //        // Điều chỉnh kích thước trình giả lập
        //        emulatorProcess.WaitForInputIdle(); // Chờ đến khi trình giả lập sẵn sàng để nhận đầu vào
        //        int x=0,y=0;
        //        x = int.Parse(txtX.Text);
        //        y= int.Parse(txtY.Text);
        //        SetWindowPos(emulatorProcess.MainWindowHandle, 0, 0, 0, x, y, 0); // Điều chỉnh kích thước theo ý muốn
        //    }
        //    else
        //    {
        //        MessageBox.Show("Trình giả lập không đang chạy.");
        //    }
        //}

        // Dùng để điều chỉnh kích thước cửa sổ
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOSIZE = 0x0001;
        private const int HWND_TOP = 0;
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

        private void ResizeEmulator(int width, int height)
        {

            if (IsEmulatorRunning())
            {
                //emulatorProcess.WaitForInputIdle();
                //SetWindowPos(emulatorProcess.MainWindowHandle, 0, 0, 0, width, height, 0);
                IntPtr intPtr = IntPtr.Zero;
                intPtr = AutoControl.FindWindowHandle("LDPlayerMainFrame", "LDPlayer");
                SetWindowPos(intPtr, 0, 0, 0, width, height, 0);
            }
            else
            {
                MessageBox.Show("Trình giả lập không đang chạy.");
            }
        }

        private bool IsEmulatorRunning()
        {
            IntPtr intPtr = IntPtr.Zero;
            intPtr = AutoControl.FindWindowHandle("LDPlayerMainFrame", "LDPlayer");
            return intPtr != IntPtr.Zero;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string deviceID = null;
            var listDevice = KAutoHelper.ADBHelper.GetDevices();
            if (listDevice != null && listDevice.Count > 0)
            {
                deviceID = listDevice.First();
            }
            KAutoHelper.ADBHelper.Tap(deviceID, a, b);
            //KAutoHelper.ADBHelper.Tap(deviceID, 206,168);
            KAutoHelper.AutoControl.MouseClick(a, b, EMouseKey.LEFT);
            //KAutoHelper.ADBHelper.LongPress(deviceID, a, b);
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //int x = e.X;
            //int y = e.Y;
            a = e.X;
            b = e.Y;

            // Hiển thị thông báo với tọa độ click chuột
            MessageBox.Show($"Clicked at X: {a}, Y: {b}", "Mouse Click");

            // Tọa độ của sự kiện click chuột
            int clickX = e.X;
            int clickY = e.Y;

            // Kích thước của phần cần cắt (ví dụ: 100x100)
            int cropWidth = 100;
            int cropHeight = 100;

            // Tạo một hình mới để lưu phần đã cắt
            Bitmap croppedImage = new Bitmap(cropWidth, cropHeight);

            // Tạo một đối tượng Graphics để vẽ phần cắt lên hình mới
            using (Graphics g = Graphics.FromImage(croppedImage))
            {
                // Vẽ phần cắt từ hình gốc
                g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, cropWidth, cropHeight),
                            new Rectangle(clickX - cropWidth / 2, clickY - cropHeight / 2, cropWidth, cropHeight),
                            GraphicsUnit.Pixel);
            }

            // Hiển thị hình đã cắt (ví dụ: thông qua PictureBox)
            //PictureBox pictureBox = new PictureBox();
            pictureBox2.Image = croppedImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;

            // Hiển thị hình đã cắt trong một form mới (ví dụ)
            Form croppedImageForm = new Form();
            croppedImageForm.Controls.Add(pictureBox2);
            croppedImageForm.ShowDialog();
            //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            //{
            //    if (IsEmulatorRunning())
            //    {
            //        emulatorProcess.CloseMainWindow();
            //        emulatorProcess.WaitForExit(5000);
            //    }
            //}
        }
    }
}
