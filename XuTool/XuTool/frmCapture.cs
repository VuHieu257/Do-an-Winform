using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XuTool
{
    public partial class frmCapture : Form
    {
        public int x = 540, y = 960;
        int E =0; int Z=0;
        private frmManipulation frmManipulation;
        private frmFindCapture frmFindCapture;
        public frmCapture()
        {
            InitializeComponent();
            frmManipulation=new frmManipulation();
            frmFindCapture=new frmFindCapture();
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            int a = e.X;
            int b = e.Y;

            // Hiển thị thông báo với tọa độ click chuột
            toolStripButtonX.Text=a.ToString();
            toolStripButtonY.Text=b.ToString();
            double percentageX = Math.Round((double)a / x * 100);
            double percentageY = Math.Round((double)b / y * 100);
            toolStripButtonpenX.Text=percentageX.ToString();
            toolStripButtonpenY.Text=percentageY.ToString();
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int a = e.X;
            int b = e.Y;
            frmManipulation.loadXY(a, b);
            frmFindCapture.Click(a, b);
            E = a; Z = b;
            toolStripButtonX.Text = a.ToString();
            toolStripButtonY.Text = b.ToString();
            double percentageX = Math.Round((double)a / x * 100);
            double percentageY = Math.Round((double)b / y * 100);
            toolStripButtonpenX.Text = percentageX.ToString();
            toolStripButtonpenY.Text = percentageY.ToString();

            MessageBox.Show($"Tọa độ X: {a}, Y: {b} \n Tọa độ %X: {percentageX}, %Y: {percentageY}");
            //int clickX = e.X;
            //int clickY = e.Y;

            //if (clickX != 0 && clickY != 0)
            //{
            //    // Kích thước của phần cần cắt (ví dụ: 100x100)
            //    int cropWidth = 100;
            //    int cropHeight = 100;

            //    // Tạo một hình mới để lưu phần đã cắt
            //    Bitmap croppedImage = new Bitmap(cropWidth, cropHeight);

            //    // Tạo một đối tượng Graphics để vẽ phần cắt lên hình mới
            //    using (Graphics g = Graphics.FromImage(croppedImage))
            //    {
            //        // Vẽ phần cắt từ hình gốc
            //        g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, cropWidth, cropHeight),
            //                    new Rectangle(clickX - cropWidth / 2, clickY - cropHeight / 2, cropWidth, cropHeight),
            //                    GraphicsUnit.Pixel);
            //    }
            //    // Hiển thị hình đã cắt (ví dụ: thông qua PictureBox)
            //    PictureBox pictureBox = new PictureBox();
            //    pictureBox.Image = croppedImage;
            //    pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            //    Form form = new Form();
            //    form.ShowDialog(pictureBox);
            //}
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
        private void toolStripButtonCapture_Click(object sender, EventArgs e)
        {
            Task t = new Task(() =>
            {
                Capture();
            });
            Capture();

        }
        private new void Capture()
        {
            var screen = KAutoHelper.ADBHelper.ScreenShoot(GetDevice());
            var scre = KAutoHelper.CaptureHelper.ResizeImage(screen, x, y);
            pictureBox1.Image = scre;
            loadform();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Coor(E,Z);
            toolStripButtonX.Text = E.ToString();
            toolStripButtonY.Text = Z.ToString();
        }
        //public void Coor(int x,int y)
        //{
        //    frmManipulation form2 = new frmManipulation();
        //    //Point coordinates = pictureBox1.PointToClient(Cursor.Position);
        //    // Mở Form2 và truyền tọa độ
        //    form2.loadXY(x,y);
        //}
        private void loadform()
        {
            this.Width = x;
            this.Height = y;
        }
    }
}
