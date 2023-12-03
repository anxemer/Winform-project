namespace QLBH_CENTRIX.ChildformApp
{
    partial class ChildformOffice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildformOffice));
            this.txtIdcate = new System.Windows.Forms.Label();
            this.txtsearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIp = new System.Windows.Forms.Panel();
            this.listOffice = new System.Windows.Forms.ListView();
            this.imageOffice = new System.Windows.Forms.ImageList(this.components);
            this.txtIp.SuspendLayout();
            this.SuspendLayout();
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
            this.txtsearch.Location = new System.Drawing.Point(761, 6);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PasswordChar = '\0';
            this.txtsearch.PlaceholderText = "Tìm kiếm Sản phẩm  ";
            this.txtsearch.SelectedText = "";
            this.txtsearch.Size = new System.Drawing.Size(262, 40);
            this.txtsearch.TabIndex = 175;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // txtIp
            // 
            this.txtIp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtIp.Controls.Add(this.txtIdcate);
            this.txtIp.Controls.Add(this.txtsearch);
            this.txtIp.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtIp.Location = new System.Drawing.Point(0, 0);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(1035, 51);
            this.txtIp.TabIndex = 7;
            this.txtIp.Visible = false;
            // 
            // listOffice
            // 
            this.listOffice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listOffice.HideSelection = false;
            this.listOffice.LargeImageList = this.imageOffice;
            this.listOffice.Location = new System.Drawing.Point(0, 51);
            this.listOffice.Name = "listOffice";
            this.listOffice.Size = new System.Drawing.Size(1035, 525);
            this.listOffice.TabIndex = 8;
            this.listOffice.UseCompatibleStateImageBehavior = false;
            // 
            // imageOffice
            // 
            this.imageOffice.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageOffice.ImageSize = new System.Drawing.Size(100, 100);
            this.imageOffice.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ChildformOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 576);
            this.Controls.Add(this.listOffice);
            this.Controls.Add(this.txtIp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChildformOffice";
            this.Text = "ChildformOffice";
            this.txtIp.ResumeLayout(false);
            this.txtIp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtIdcate;
        private Guna.UI2.WinForms.Guna2TextBox txtsearch;
        private System.Windows.Forms.ListView listOffice;
        public System.Windows.Forms.Panel txtIp;
        private System.Windows.Forms.ImageList imageOffice;
    }
}