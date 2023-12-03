namespace QLBH_CENTRIX
{
    partial class ReportOrder
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
            this.crystalReportOrder = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportOrder
            // 
            this.crystalReportOrder.ActiveViewIndex = -1;
            this.crystalReportOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportOrder.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportOrder.Location = new System.Drawing.Point(0, 0);
            this.crystalReportOrder.Name = "crystalReportOrder";
            this.crystalReportOrder.Size = new System.Drawing.Size(800, 450);
            this.crystalReportOrder.TabIndex = 0;
            // 
            // ReportOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportOrder);
            this.Name = "ReportOrder";
            this.Text = "ReportOrder";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportOrder;
    }
}