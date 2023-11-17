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

namespace XuTool
{
    public partial class frmmain : Form
    {
        frmManipulation frmManipulation;
        public frmmain()
        {
            InitializeComponent();
            frmManipulation = new frmManipulation();
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
        int selectedIndex = -1;
        private void listViewFuncion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Kiểm tra xem có item được chọn không
            if (listViewFuncion.SelectedItems.Count > 0)
            {
                // Lấy thông tin của item được chọn
                ListViewItem selectedItem = listViewFuncion.SelectedItems[0];
                selectedIndex = selectedItem.Index;
                MessageBox.Show(selectedIndex.ToString());
               
            } 

        }
        private void OpenChildForm(Form childForm)
        {
            if (childForm == null)
            {
                childForm.Close();
            }
           childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            sidebar.Controls.Add(childForm);
            sidebar.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
                OpenChildForm(frmManipulation);
        }

        private void toolStripButtonTe_Click(object sender, EventArgs e)
        {
                OpenChildForm(new frmDocument());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            OpenChildForm(frmManipulation); 
        }
        private void toolStripButtonCaprute_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmFindCapture());
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    foreach(ListViewItem item in listViewFuncion.Items) {
                        item.Checked = true;
                    }
                }
                else
                {
                    foreach (ListViewItem item in listViewFuncion.Items)
                    {
                        item.Checked = false;
                    }
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btncapture_Click(object sender, EventArgs e)
        {
            frmCapture frmCapture = new frmCapture();
            frmCapture.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Sidebartimer.Start();

        }
        bool sidebarExpand;
        private void Sidebartimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                //if sidebar is expand,minimize
                Width -= 10;
                if (Width == MinimumSize.Width)
                {
                    sidebarExpand = false;
                    Sidebartimer.Stop();
                }
            }
            else
            {
                Width += 10;
                if (Width == MaximumSize.Width)
                {
                    sidebarExpand = true;
                    Sidebartimer.Stop();
                }
            }
            //if (sidebarExpand)
            //{
            //    //if sidebar is expand,minimize
            //    sidebar.Width -= 10;
            //    if (sidebar.Width == sidebar.MinimumSize.Width)
            //    {
            //        sidebarExpand = false;
            //        Sidebartimer.Stop();
            //    }
            //}
            //else
            //{
            //    sidebar.Width += 10;
            //    if (sidebar.Width == sidebar.MaximumSize.Width)
            //    {
            //        sidebarExpand = true;
            //        Sidebartimer.Stop();
            //    }
            //}
        }
        private void frmmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông Báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProfile frmProfile = new frmProfile();
            this.Hide();
            frmProfile.ShowDialog();
            this.Show();
        }
        CustomerDAO CustomerDAO = new CustomerDAO();
        private void nhậpMKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(toolStripMenuItemmtestPass.Text.Length <= 0)
            {
                throw new Exception("Không được để trống");
            }
            if(CustomerDAO.AuthenticateAmin(toolStripMenuItemmtestPass.Text))
            {
                qLKHToolStripMenuItem.Enabled = true;
                //frmAdmin frm=new frmAdmin();
                //this.Hide();
                //frm.ShowDialog();
                //this.Show();
            }
            else
            {
                MessageBox.Show("Mật Khẩu không chính xác!!", "Thông Báo");
            }

        }

        private void qLKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin frmAdmin = new frmAdmin();
            this.Hide();
            frmAdmin.ShowDialog();
            this.Show();
        }

       
    }
}
