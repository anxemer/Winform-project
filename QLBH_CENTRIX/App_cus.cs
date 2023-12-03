using QLBH_CENTRIX.ChildformApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_CENTRIX
{
    public partial class App_cus : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBcontext dbcon = new DBcontext();
        Home_Cus home;
        private int newWidth = 150; // Kích thước mới của ảnh (độ rộng)
        private int newHeight = 150;
        private List<string> imageUrls = new List<string>();
        public App_cus(Home_Cus form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            openChildForm(new ChildformAllApp());
            home = form;
            txtId.Text = home.txtId.Text;
            txtCid.Text = "";
        }

        private void btnall_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildformAllApp());
            txtCid.Text = "";

        }

        private void btngpt_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildformGpt());
            txtCid.Text = "1";
        }

        private void btnhoctao_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildformHoctap());
            txtCid.Text = "2";
        }

        private void btnoffice_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildformOffice());
            txtCid.Text = "3";
        }

        private void btnhip_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildformIp());
            txtCid.Text = "4";
        }

        private void btnytb_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildformYtb());
            txtCid.Text = "5";
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            home.Show();
            this.Close();

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

       
        private void AddProduct_Click_1(object sender, EventArgs e)
        {
            CashApp product = new CashApp(this);
            product.cid = home.txtId.Text;
            product.ShowDialog();
        }
        #region Method
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                panelchildapp.Controls.Remove(activeForm);
                activeForm = null; // Reset activeForm
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelchildapp.Controls.Add(childForm);
            panelchildapp.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #endregion Method

        private void btncash_Click(object sender, EventArgs e)
        {
            Cash cash = new Cash(this);
            cash.Show();
            cash.loadCash();
            
        }
    }
}
