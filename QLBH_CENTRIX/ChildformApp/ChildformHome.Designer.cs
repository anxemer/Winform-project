namespace QLBH_CENTRIX.ChildformApp
{
    partial class ChildformHome
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
            this.listHome = new System.Windows.Forms.ListView();
            this.imageHome = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // listHome
            // 
            this.listHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listHome.HideSelection = false;
            this.listHome.LargeImageList = this.imageHome;
            this.listHome.Location = new System.Drawing.Point(0, 0);
            this.listHome.Name = "listHome";
            this.listHome.Size = new System.Drawing.Size(1035, 576);
            this.listHome.TabIndex = 4;
            this.listHome.UseCompatibleStateImageBehavior = false;
            // 
            // imageHome
            // 
            this.imageHome.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageHome.ImageSize = new System.Drawing.Size(100, 100);
            this.imageHome.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ChildformHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 576);
            this.Controls.Add(this.listHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChildformHome";
            this.Text = "ChildformHome";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listHome;
        private System.Windows.Forms.ImageList imageHome;
    }
}