namespace QLBH_CENTRIX.ChildformGame
{
    partial class ChildformGOPW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildformGOPW));
            this.txtIdcate = new System.Windows.Forms.Label();
            this.txtsearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listGameGOPW = new System.Windows.Forms.ListView();
            this.imageGOPW = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.txtIdcate);
            this.panel1.Controls.Add(this.txtsearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 51);
            this.panel1.TabIndex = 12;
            // 
            // listGameGOPW
            // 
            this.listGameGOPW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGameGOPW.HideSelection = false;
            this.listGameGOPW.LargeImageList = this.imageGOPW;
            this.listGameGOPW.Location = new System.Drawing.Point(0, 51);
            this.listGameGOPW.Name = "listGameGOPW";
            this.listGameGOPW.Size = new System.Drawing.Size(1035, 525);
            this.listGameGOPW.TabIndex = 13;
            this.listGameGOPW.UseCompatibleStateImageBehavior = false;
            // 
            // imageGOPW
            // 
            this.imageGOPW.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageGOPW.ImageSize = new System.Drawing.Size(100, 100);
            this.imageGOPW.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ChildformGOPW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 576);
            this.Controls.Add(this.listGameGOPW);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChildformGOPW";
            this.Text = "ChildformGOPW";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtsearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listGameGOPW;
        public System.Windows.Forms.Label txtIdcate;
        private System.Windows.Forms.ImageList imageGOPW;
    }
}