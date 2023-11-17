namespace XuTool
{
    partial class frmDemo1
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TenLenh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ThuocTinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ThuocTinh2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ThuocTinh3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ThuocTinh4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewFuncion = new System.Windows.Forms.ListView();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 42);
            this.button2.TabIndex = 7;
            this.button2.Text = "Chạy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 43);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listViewFuncion);
            this.panel2.Location = new System.Drawing.Point(357, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 464);
            this.panel2.TabIndex = 5;
            // 
            // TenLenh
            // 
            this.TenLenh.Text = "Tên Lệnh";
            this.TenLenh.Width = 100;
            // 
            // ThuocTinh
            // 
            this.ThuocTinh.Text = "Thuộc tính 1";
            this.ThuocTinh.Width = 100;
            // 
            // ThuocTinh2
            // 
            this.ThuocTinh2.Text = "Thuộc Tinh 2";
            this.ThuocTinh2.Width = 100;
            // 
            // ThuocTinh3
            // 
            this.ThuocTinh3.Text = "Thuộc tính 3";
            this.ThuocTinh3.Width = 100;
            // 
            // ThuocTinh4
            // 
            this.ThuocTinh4.Text = "Thuộc Tính 4";
            this.ThuocTinh4.Width = 100;
            // 
            // phu
            // 
            this.phu.Text = "Thuộc tính phụ";
            this.phu.Width = 100;
            // 
            // listViewFuncion
            // 
            this.listViewFuncion.CheckBoxes = true;
            this.listViewFuncion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TenLenh,
            this.ThuocTinh,
            this.ThuocTinh2,
            this.ThuocTinh3,
            this.ThuocTinh4,
            this.phu});
            this.listViewFuncion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFuncion.GridLines = true;
            this.listViewFuncion.HideSelection = false;
            this.listViewFuncion.Location = new System.Drawing.Point(0, 0);
            this.listViewFuncion.Name = "listViewFuncion";
            this.listViewFuncion.Size = new System.Drawing.Size(397, 464);
            this.listViewFuncion.TabIndex = 1;
            this.listViewFuncion.UseCompatibleStateImageBehavior = false;
            this.listViewFuncion.View = System.Windows.Forms.View.Details;
            // 
            // frmDemo1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 672);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Name = "frmDemo1";
            this.Text = "frmDemo1";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listViewFuncion;
        private System.Windows.Forms.ColumnHeader TenLenh;
        private System.Windows.Forms.ColumnHeader ThuocTinh;
        private System.Windows.Forms.ColumnHeader ThuocTinh2;
        private System.Windows.Forms.ColumnHeader ThuocTinh3;
        private System.Windows.Forms.ColumnHeader ThuocTinh4;
        private System.Windows.Forms.ColumnHeader phu;
    }
}