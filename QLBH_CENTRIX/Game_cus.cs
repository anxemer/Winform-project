using QLBH_CENTRIX.ChildformApp;
using QLBH_CENTRIX.ChildformGame;
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
    public partial class Game_cus : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBcontext dbcon = new DBcontext();
        Cash cash;
        Home_Cus homeC;
        public Game_cus(Home_Cus form
            )
        {

            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            openChildForm(new ChildformAllGame());
            homeC = form;
            txtId.Text = homeC.txtId.Text;
            txtCid.Text = "";


        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Dispose();
        }

        private void btnall_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildformAllGame());
            txtCid.Text = "";

        }

        private void btnSinhton_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildformSurvi());
            txtCid.Text = "6";
        }

        private void btnOpw_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildformGOPW());
            txtCid.Text = "7";

        }

        private void btnChienThuat_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildformCT());
            txtCid.Text = "8";
        }

        private void btnHanhDong_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildformGHD());
            txtCid.Text = "9";
        }

        private void btnGiaiDo_Click(object sender, EventArgs e)
        {
            openChildForm(new ChildformGGD());
            txtCid.Text = "10";
        }

        private void btncash_Click(object sender, EventArgs e)
        {
            Cash cash = new Cash(this);
            cash.Show();
            cash.loadCash();
            

        }
        private void AddProduct_Click(object sender, EventArgs e)
        {
            CashGame game = new CashGame(this);
            game.cid = homeC.txtId.Text;
            game.ShowDialog();
        }
        #region Method
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                panelchilgame.Controls.Remove(activeForm);
                activeForm = null; // Reset activeForm
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelchilgame.Controls.Add(childForm);
            panelchilgame.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        #endregion Method

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            homeC.Show();
            this.Close();
        }
    }
}
