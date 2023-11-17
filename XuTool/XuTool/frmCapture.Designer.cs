namespace XuTool
{
    partial class frmCapture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapture));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCapture = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonX = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonY = new System.Windows.Forms.ToolStripLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonpenX = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonpenY = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCapture,
            this.toolStripButton5,
            this.toolStripButton2,
            this.toolStripLabel1,
            this.toolStripButtonX,
            this.toolStripButton4,
            this.toolStripButtonY,
            this.toolStripButton1,
            this.toolStripButtonpenX,
            this.toolStripButton6,
            this.toolStripButtonpenY});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(375, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonCapture
            // 
            this.toolStripButtonCapture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCapture.Image = global::XuTool.Properties.Resources.Captures1;
            this.toolStripButtonCapture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCapture.Name = "toolStripButtonCapture";
            this.toolStripButtonCapture.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonCapture.Text = "toolStripButton1";
            this.toolStripButtonCapture.ToolTipText = "Chụp ảnh màn hình";
            this.toolStripButtonCapture.Click += new System.EventHandler(this.toolStripButtonCapture_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(67, 24);
            this.toolStripButton2.Text = "LDPlayer";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(23, 24);
            this.toolStripLabel1.Text = "X:";
            // 
            // toolStripButtonX
            // 
            this.toolStripButtonX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonX.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonX.Image")));
            this.toolStripButtonX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonX.Name = "toolStripButtonX";
            this.toolStripButtonX.Size = new System.Drawing.Size(21, 24);
            this.toolStripButtonX.Text = "   ";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(22, 24);
            this.toolStripButton4.Text = "Y:";
            // 
            // toolStripButtonY
            // 
            this.toolStripButtonY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonY.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonY.Image")));
            this.toolStripButtonY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonY.Name = "toolStripButtonY";
            this.toolStripButtonY.Size = new System.Drawing.Size(21, 24);
            this.toolStripButtonY.Text = "   ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(370, 574);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(17, 24);
            this.toolStripButton5.Text = "  ";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 24);
            this.toolStripButton1.Text = "%X:";
            // 
            // toolStripButtonpenX
            // 
            this.toolStripButtonpenX.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonpenX.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonpenX.Image")));
            this.toolStripButtonpenX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonpenX.Name = "toolStripButtonpenX";
            this.toolStripButtonpenX.Size = new System.Drawing.Size(25, 24);
            this.toolStripButtonpenX.Text = "    ";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(35, 24);
            this.toolStripButton6.Text = "%Y:";
            // 
            // toolStripButtonpenY
            // 
            this.toolStripButtonpenY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonpenY.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonpenY.Image")));
            this.toolStripButtonpenY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonpenY.Name = "toolStripButtonpenY";
            this.toolStripButtonpenY.Size = new System.Drawing.Size(25, 24);
            this.toolStripButtonpenY.Text = "    ";
            // 
            // frmCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 609);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCapture";
            this.Text = "frmCapture";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripButton2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripButtonX;
        private System.Windows.Forms.ToolStripButton toolStripButtonCapture;
        private System.Windows.Forms.ToolStripLabel toolStripButton4;
        private System.Windows.Forms.ToolStripLabel toolStripButtonY;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripLabel toolStripButton5;
        private System.Windows.Forms.ToolStripLabel toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripButtonpenX;
        private System.Windows.Forms.ToolStripLabel toolStripButton6;
        private System.Windows.Forms.ToolStripLabel toolStripButtonpenY;
    }
}