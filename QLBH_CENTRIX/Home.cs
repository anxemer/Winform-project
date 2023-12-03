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
using System.Xml.Linq;

namespace QLBH_CENTRIX
{
    public partial class Home : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBcontext dbcon = new DBcontext();
        DataTable dt = new DataTable();
        public Home()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void btnapp_Click(object sender, EventArgs e)
        {
            App app = new App(this);
            app.lblusername.Text = lblusername.Text;
            app.Show();
            this.Hide();
        }

        private void btngame_Click(object sender, EventArgs e)
        {
            Game game = new Game(this);
            game.lblusername.Text = lblusername.Text;
            game.Show();
            this.Hide();
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            Order order = new Order(this);
            order.Show();
            this.Hide();
        }

        private void btncash_Click(object sender, EventArgs e)
        {
            Cash cash = new Cash(this);
            cash.Show();
            cash.loadCash();
            this.Hide();
        }

        private void btncustomer_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer(this);
            cus.Show();
            this.Hide();
        }
    }
}
