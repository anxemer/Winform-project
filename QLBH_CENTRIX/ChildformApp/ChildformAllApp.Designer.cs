namespace QLBH_CENTRIX.ChildformApp
{
    partial class ChildformAllApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildformAllApp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdcate = new System.Windows.Forms.Label();
            this.txtsearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listApp = new System.Windows.Forms.ListView();
            this.imageApp = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtIdcate);
            this.panel1.Controls.Add(this.txtsearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 51);
            this.panel1.TabIndex = 0;
            // 
            // txtIdcate
            // 
            this.txtIdcate.AutoSize = true;
            this.txtIdcate.Location = new System.Drawing.Point(388, 13);
            this.txtIdcate.Name = "txtIdcate";
            this.txtIdcate.Size = new System.Drawing.Size(44, 16);
            this.txtIdcate.TabIndex = 176;
            this.txtIdcate.Text = "label1";
            this.txtIdcate.Visible = false;
            // 
            // txtsearch
            // 
            this.txtsearch.BorderColor = System.Drawing.Color.Black;
            this.txtsearch.BorderRadius = 10;
            this.txtsearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsearch.DefaultText = "";
            this.txtsearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtsearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtsearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearch.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtsearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtsearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtsearch.IconLeft")));
            this.txtsearch.Location = new System.Drawing.Point(761, 5);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PasswordChar = '\0';
            this.txtsearch.PlaceholderText = "Tìm kiếm Sản phẩm  ";
            this.txtsearch.SelectedText = "";
            this.txtsearch.Size = new System.Drawing.Size(262, 40);
            this.txtsearch.TabIndex = 175;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listApp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1035, 572);
            this.panel2.TabIndex = 1;
            // 
            // listApp
            // 
            this.listApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listApp.HideSelection = false;
            this.listApp.LargeImageList = this.imageApp;
            this.listApp.Location = new System.Drawing.Point(0, 0);
            this.listApp.Name = "listApp";
            this.listApp.Size = new System.Drawing.Size(1035, 572);
            this.listApp.TabIndex = 1;
            this.listApp.UseCompatibleStateImageBehavior = false;
            this.listApp.SelectedIndexChanged += new System.EventHandler(this.listApp_SelectedIndexChanged);
            // 
            // imageApp
            // 
            this.imageApp.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageApp.ImageSize = new System.Drawing.Size(100, 100);
            this.imageApp.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ChildformAllApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1035, 623);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChildformAllApp";
            this.Text = "ChildformApp";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtsearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listApp;
        public System.Windows.Forms.Label txtIdcate;
        private System.Windows.Forms.ImageList imageApp;
    }
}