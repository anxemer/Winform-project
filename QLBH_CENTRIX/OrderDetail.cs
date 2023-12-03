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
    public partial class OrderDetail : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBcontext dbcon = new DBcontext();
        SqlDataReader dr;
        Order order;
        public OrderDetail(Order form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            order = form;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            order.Show();
            this.Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Method
        public void loadCash()
        {
            int i = 0;
            dgvCash.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM CASH where transno like '" + txtTransno.Text + "'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCash.Rows.Add(i, dr[0].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }
        #endregion Method
    }
}
