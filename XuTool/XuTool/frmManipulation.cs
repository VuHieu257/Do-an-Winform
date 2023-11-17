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
    public partial class frmManipulation : Form
    {
        private Point receivedCoordinates;
       
        public frmManipulation()
        {
            InitializeComponent();
        }
        //public void loadXY(Point coordinates)
        //{
        //    //Task.Factory.StartNew(() => { 
        //    //    receivedCoordinates = coordinates;
        //    //    numberClickX.Value = receivedCoordinates.X; numberClickY.Value = receivedCoordinates.Y;

        //    //});
        //        receivedCoordinates = coordinates;
        //        numberClickX.Value = receivedCoordinates.X; numberClickY.Value = receivedCoordinates.Y;

        //}
     
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
        private void btnClicknumber_Click(object sender, EventArgs e)
        {
            ////----------Get the first device-------------------
            //string deviceID = null;
            //var listDevice = KAutoHelper.ADBHelper.GetDevices();
            //if (listDevice != null && listDevice.Count > 0)
            //{
            //    deviceID = listDevice.First();
            //}
            //---------------Proportional click position-------------
            try {
                Task t = new Task(() =>
                {
                    if (GetDevice() != null)
                    {
                        if (numberClickX.Value == 0)
                        {
                            throw new Exception("Nhập Giá trị X");
                        }
                        if (numberClickY.Value == 0)
                        {
                            throw new Exception("Nhập Giá trị Y");
                        }
                        KAutoHelper.ADBHelper.Tap(GetDevice(), (int)numberClickX.Value, (int)numberClickY.Value, (int)numberofClick.Value);
                    }
                });
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                if (numberSwipeX1.Value == 0)
                {
                    throw new Exception("Nhập Giá trị X1");
                }
                if (numberSwipeY1.Value == 0)
                {
                    throw new Exception("Nhập Giá trị Y1");
                }
                if (numberSwipeX2.Value == 0)
                {
                    throw new Exception("Nhập Giá trị X1");
                }
                if (numberSwipeY2.Value == 0)
                {
                    throw new Exception("Nhập Giá trị Y1");
                }
                KAutoHelper.ADBHelper.Swipe(GetDevice(), (int)numberSwipeX1.Value, (int)numberSwipeY1.Value, (int)numberSwipeX2.Value, (int)numberSwipeY2.Value, (int)number_Clickspeed.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (numberpercentSwipeX1.Value == 0)
                {
                    throw new Exception("Nhập Giá trị X1");
                }
                if (numberpercentSwipeY1.Value == 0)
                {
                    throw new Exception("Nhập Giá trị Y1");
                }
                if (numberpercentSwipeX2.Value == 0)
                {
                    throw new Exception("Nhập Giá trị X1");
                }
                if (numberpercentSwipeY2.Value == 0)
                {
                    throw new Exception("Nhập Giá trị Y1");
                }
                KAutoHelper.ADBHelper.Swipe(GetDevice(), (int)numberpercentSwipeX1.Value, (int)numberpercentSwipeY1.Value, (int)numberpercentSwipeX2.Value, (int)numberpercentSwipeY2.Value, (int)number_Clickspeed.Value);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool isStop= false;
        void Delay(int delay)
        {
            while(delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;
                if (isStop)
                    break;
            }
        }

        private void btnDelay_Click(object sender, EventArgs e)
        {
            //Delay((int)numberDelay.Value);
            //if (checkBox1.Checked)
            //{
            //    Random random = new Random();
            //    int randomNumber = random.Next(1, 101);
            //    numberDelay.Value = randomNumber;
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try {
                Random random = new Random();
                int randomNumber = random.Next(1, 101);
                numberDelay.Value = randomNumber;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClickpercent_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericpercentClickX.Value == 0)
                {
                    throw new Exception("Nhập Giá trị X");
                }
                if (numericpercentClickY.Value == 0)
                {
                    throw new Exception("Nhập Giá trị Y");
                }
                KAutoHelper.ADBHelper.TapByPercent(GetDevice(), (double)numericpercentClickX.Value, (double)numericpercentClickY.Value, (int)numberofClick.Value);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPasteTxt_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPaste.Text.Length == 0)
                {
                    throw new Exception("Nhập văn bản muốn dán");
                }
                if(numberClickX.Value>=0)
                {
                    KAutoHelper.ADBHelper.Tap(GetDevice(), (int)numberClickX.Value, (int)numberClickY.Value, (int)numberofClick.Value);
                }
                else
                {
                    KAutoHelper.ADBHelper.TapByPercent(GetDevice(), (double)numericpercentClickX.Value, (double)numericpercentClickY.Value, (int)numberofClick.Value);

                }
                KAutoHelper.ADBHelper.InputText(GetDevice(), txtPaste.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmManipulation_Load(object sender, EventArgs e)
        {
            //frmCapture frm = new frmCapture();
            //frm.mydata = new frmCapture.GETDATA(GETVALUE);
            //frm.E = (int)numberClickX.Value;
            //frm.Z = (int)numberClickY.Value;
            //MessageBox.Show($"X: {receivedCoordinates.X}, Y: {receivedCoordinates.Y}") ;
        }
        public void loadXY(int E, int Z)
        {
           OnDataReceived(E, Z);
        }
        private void ReturnValue(int E,int Z)
        {
            numberClickX.Value = E; numberClickY.Value = Z;
        }
        public event EventHandler<int> DataReceived;
        public virtual void OnDataReceived(int E,int Z)
        {
            DataReceived?.Invoke(this, E);
            DataReceived?.Invoke(this, Z);
            ReturnValue(E, Z);
            numberClickX.Value = E; 
            numberClickY.Value = Z;
        }

      
    }
}
