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
    public partial class Order : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBcontext dbcon = new DBcontext();
        SqlDataAdapter da = new SqlDataAdapter();
        Home home;
        SqlDataReader dr;
        public Order(Home form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            home = form;

            loadOrder();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            home.Show();
            this.Hide();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            loadOrder();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgv_hoadon.Rows)
            {
                bool checkbox = Convert.ToBoolean(dr.Cells["select"].Value);
                if (checkbox)
                {
                    try
                    {
                        cmd = new SqlCommand("begin transaction\r\nDELETE FROM orderdetail WHERE transno =@transno ;\r\nDELETE FROM cash WHERE transno = @transno;\r\ncommit", cn);
                        cmd.Parameters.AddWithValue("@transno", dr.Cells[1].Value);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            loadOrder();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();    
        }
        #region Method
        public void loadOrder()
        {
            dgv_hoadon.Rows.Clear();
            cmd = new SqlCommand("SELECT * from ORDERDETAIL WHERE nameCus like N'%" + txtsearch.Text + "%' or cusId like '%" + txtsearch.Text + "%' or transno like '%" + txtsearch.Text + "%'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                dgv_hoadon.Rows.Add(dr[0].ToString(), dr[7].ToString(), dr[5].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[6].ToString());
            }
            cn.Close();
            dr.Close();
        }


        #endregion MEthod

        private void dgv_hoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dgv_hoadon.Columns[e.ColumnIndex].Name;
            string transno;
            foreach (DataGridViewRow dr in dgv_hoadon.Rows)
            {
                transno = dr.Cells[1].Value.ToString();

            }

            if (colname == "view")
            {


                OrderDetail detail = new OrderDetail(this);
                detail.lbl_ten.Text = dgv_hoadon.Rows[e.RowIndex].Cells[3].Value.ToString();
                detail.lbl_email.Text = dgv_hoadon.Rows[e.RowIndex].Cells[5].Value.ToString();
                detail.bl_sdt.Text = dgv_hoadon.Rows[e.RowIndex].Cells[4].Value.ToString();
                detail.txtTransno.Text = dgv_hoadon.Rows[e.RowIndex].Cells[1].Value.ToString();
                detail.loadCash();
                detail.Show();


            }
        }

        private void Report_Click(object sender, EventArgs e)
        {
            string sdate = DateTime.Now.ToString("yyyyMMdd");
            cmd = new SqlCommand("select * from ORDERDETAIL where transno like '"+sdate+"%'", cn);
           da.SelectCommand = cmd;
           
            DataTable dt = new DataTable("TableOrder");
            da.Fill(dt);

            CrystalReportReport report = new CrystalReportReport();
            report.SetDataSource(dt);

            ReportOrder ro = new ReportOrder();
            ro.crystalReportOrder.ReportSource = report;
            ro.ShowDialog();

        }
    }
}
