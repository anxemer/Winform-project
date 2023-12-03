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
    public partial class Home_Cus : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBcontext dbcon = new DBcontext();
        SqlDataReader dr;
        public Home_Cus()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            openChildForm(new ChildformHome());
            getTransno();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Dispose();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }

        private void btnapp_Click(object sender, EventArgs e)
        {
            App_cus app_Cus = new App_cus(this);
            app_Cus.Show();
            app_Cus.lbTransaction.Text = lbTransaction.Text;
            app_Cus.lblusername.Text = lblusername.Text;
            this.Hide();
        }

        private void btngame_Click(object sender, EventArgs e)
        {
            Game_cus game_Cus = new Game_cus(this);
            game_Cus.lbTransaction.Text = lbTransaction.Text;
            game_Cus.lblusername.Text= lblusername.Text;
            game_Cus.Show();
            this.Hide();
        }

        private void btncash_Click(object sender, EventArgs e)
        {
            Cash cash = new Cash(this);
            openChildForm(cash);
            cash.loadCash();
        }
        #region Method
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void getTransno()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                int count = 0;
                string transno;

                cn.Open();
                cmd = new SqlCommand("select top 1 transno from CASH where transno like '" + sdate + "%' order by cashId DESC", cn);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    transno = dr[0].ToString();
                    count = int.Parse(transno.Substring(8, 4));
                    lbTransaction.Text = sdate + count;
                    dr.Close();

                    string query = "select * from ORDERDETAIL where transno like '" + lbTransaction.Text + "'";
                    if (HasData(cn, query))
                    {
                        lbTransaction.Text = sdate + (count + 1);
                    }
                }
                else
                {
                    transno = sdate + "1001";
                    lbTransaction.Text = transno;
                    dr.Close();
                }

                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public bool HasData(SqlConnection connection, string sqlQuery)
        {
            bool result = false;

            using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    result = dr.HasRows;
                }
            }

            return result;
        }
        #endregion Method
    }
}
