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
    public partial class Cash : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBcontext dbcon = new DBcontext();
        Home_Cus homeC;
        Home home;
        Game_cus game;
        App_cus app;
        SqlDataReader dr;
       
        public Cash(Home_Cus form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            homeC = form;
            txtId.Text = homeC.txtId.Text;
            getTransno();
        }

        public Cash(Home form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            home = form;
            txtId.Text = home.txtId.Text;
            getTransno();
        } public Cash(Game_cus form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            game = form;
            txtId.Text = game.txtId.Text;
            getTransno();
        } public Cash(App_cus form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            app = form;
            txtId.Text = app.txtId.Text;
            getTransno();
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            if (homeC != null && !homeC.IsDisposed)
            {
                homeC.Show();
            }
            else if (home != null && !home.IsDisposed)
            {
                home.Show();
            }
            this.Hide();
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            CashProduct product = new CashProduct(this);
            if (homeC != null && !homeC.IsDisposed)
            {
                product.cid = homeC.txtId.Text;
            }
            else if (home != null && !home.IsDisposed)
            {
                product.cid = home.txtId.Text;
            }

            product.ShowDialog();
        }

        private void btn_dathang_Click(object sender, EventArgs e)
        {
            string cid = "";
            foreach (DataGridViewRow dr in dgvDonhang.Rows)
            {
                cid = dr.Cells[2].Value.ToString();

            }
            try
            {
                cmd = new SqlCommand("insert into ORDERDETAIL(nameCus,phonenumber,emailCus,cusId,total,transno,statusOrder) values (@name,@phome,@email,@cusid,@total,@transno,@status)", cn);
                cmd.Parameters.AddWithValue("@name", txtHoten.Text);
                cmd.Parameters.AddWithValue("@phome", txtSdt.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@cusid", cid);
                cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lbTotal.Text));
                cmd.Parameters.AddWithValue("@transno", lbTransaction.Text);
                cmd.Parameters.AddWithValue("@status", '0');
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Đặt hàng thành công", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvDonhang.Rows.Clear();
            getTransno();
            clear();
        }
        #region Method
        
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

        
        public void loadCash()
        {
            try
            {
                int i = 0;
                double total = 0;
                dgvDonhang.Rows.Clear();
                cmd = new SqlCommand("SELECT cashId,pId,pName,quantity,price,total,c.id from CASH left join ACCOUNT c on CASH.cusId  = c.id where transno like '" + lbTransaction.Text + "' and CASH.cusId like '" + txtId.Text + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvDonhang.Rows.Add(i, dr[0].ToString(), dr[6].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                    total += double.Parse(dr[5].ToString());
                }
                dr.Close();
                cn.Close();
                lbTotal.Text = total.ToString("#,##0");
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public void clear()
        {
            txtEmail.Clear();
            txtHoten.Clear();
            txtSdt.Clear();
            lbTotal.Text = "0,00";
        }
        #endregion Method

        private void dgvDonhang_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dgvDonhang.Columns[e.ColumnIndex].Name;
        removeitem:
            if (colname == "Delete")
            {
                cn.Open();
                cmd = new SqlCommand("delete from CASH where cashId like '" + dgvDonhang.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                dr = cmd.ExecuteReader();
                cn.Close();
            }
            else if (colname == "increase")
            {
                cn.Open();
                cmd = new SqlCommand("update CASH set quantity = quantity +" + 1 + "where cashId like '" + dgvDonhang.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                dr = cmd.ExecuteReader();
                cn.Close();
            }
            else if (colname == "Decrease")
            {
                if (int.Parse(dgvDonhang.Rows[e.RowIndex].Cells[5].Value.ToString()) == 1)
                {
                    colname = "Delete";
                    goto removeitem;
                }
                cn.Open();
                cmd = new SqlCommand("update CASH set quantity = quantity - " + 1 + "where cashId like '" + dgvDonhang.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                dr = cmd.ExecuteReader();
                cn.Close();
            }
            loadCash();
        }
    }
}
