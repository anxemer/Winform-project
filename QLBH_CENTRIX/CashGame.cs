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
    public partial class CashGame : Form
    {
        public string cid;
        public string idCate;
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBcontext dbcon = new DBcontext();
        SqlDataReader dr;
        Game_cus game;
        public CashGame(Game_cus form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            game = form;
            LoadProduct();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvProduct.Rows)
            {
                bool checkbox = Convert.ToBoolean(dr.Cells["select"].Value);
                if (checkbox)
                {
                    try
                    {
                        cmd = new SqlCommand("insert into CASH(transno,pId,pName,quantity,price,cusId) values (@transno,@pId,@pName,@quantity,@price,@cid)", cn);
                        cmd.Parameters.AddWithValue("@transno", game.lbTransaction.Text);
                        cmd.Parameters.AddWithValue("@pId", dr.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@pName", dr.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@quantity", 1);
                        cmd.Parameters.AddWithValue("@price", Convert.ToDouble(dr.Cells[4].Value.ToString()));
                        cmd.Parameters.AddWithValue("@cid", cid);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();

                    }
                    catch (Exception ex)
                    {
                        cn.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            this.Dispose();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
        #region Method
        public void LoadProduct()
        {
            dgvProduct.Rows.Clear();
            cmd = new SqlCommand("SELECT P.idP, P.nameP, P.price, P.[description], C.nameCategory\r\nFROM Product P\r\nJOIN Category C ON P.cateid = C.idcat \r\nWHERE P.nameP LIKE N'%" + txtsearch.Text + "%'\r\n   and P.cateId LIKE N'%" + game.txtCid.Text + "%'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                dgvProduct.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[4].ToString(), dr[3].ToString(), dr[2].ToString());
            }
            dr.Close();
            cn.Close();
        }
        #endregion Method
    }
}
