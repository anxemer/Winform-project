using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Xml.Linq;

namespace QLBH_CENTRIX
{
    public partial class App : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBcontext dbcon = new DBcontext();
        SqlDataReader dr;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable dt = new DataTable();
        Home home;
        public App(Home form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            home = form;
        }
        public void loaddata()
        {
            adt.Fill(dt);
            dgvapp.DataSource = dt;
            dgvapp.Columns[0].HeaderText = "ID ";
            dgvapp.Columns[1].HeaderText = "Tên sản phẩm ";
            dgvapp.Columns[2].HeaderText = "Giá ";
            dgvapp.Columns[3].HeaderText = "ID loại sp ";
            dgvapp.Columns[0].Width = 50;
            dgvapp.Columns[1].Width = 330;
            dgvapp.Columns[2].Width = 90;
            dgvapp.Columns[3].Width = 70;
            this.dgvapp.DefaultCellStyle.Font = new Font("UTM avo", 10);
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
;            cmd = new SqlCommand("SELECT IDP, NAMEP, PRICE, CATEID FROM PRODUCT WHERE nameP like '%"+txtsearch.Text+ "%'or idP like '%" + txtsearch.Text + "%'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();

            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dgvapp.DataSource = dt;
            cn.Close();
            
           
        }

        private void btnall_Click(object sender, EventArgs e)
        {

            dt.Clear();
            adt = new SqlDataAdapter("SELECT IDP,NAMEP,PRICE,CATEID FROM PRODUCT WHERE cateid = '1' or  cateid = '2' or cateid = '3' or cateid = '4' or cateid = '5'", cn);
            loaddata();

        }

        private void btnchatgpt_Click(object sender, EventArgs e)
        {

            dt.Clear();
            adt = new SqlDataAdapter("SELECT IDP,NAMEP,PRICE,CATEID FROM PRODUCT WHERE cateid = '1' ", cn);
            loaddata();

        }

        private void btnhoctap_Click(object sender, EventArgs e)
        {
            dt.Clear();
            adt = new SqlDataAdapter("SELECT IDP,NAMEP,PRICE,CATEID FROM PRODUCT WHERE cateid = '2'", cn);
            loaddata();

        }

        private void btnoffice_Click(object sender, EventArgs e)
        {
            dt.Clear();
            adt = new SqlDataAdapter("SELECT IDP,NAMEP,PRICE,CATEID FROM PRODUCT WHERE cateid = '3' ", cn);
            loaddata();
        }

        private void btnip_Click(object sender, EventArgs e)
        {
            dt.Clear();
            adt = new SqlDataAdapter("SELECT IDP,NAMEP,PRICE,CATEID FROM PRODUCT WHERE  cateid = '4' ", cn);
            loaddata();

        }

        private void btnytb_Click(object sender, EventArgs e)
        {
            dt.Clear();
            adt = new SqlDataAdapter("SELECT IDP,NAMEP,PRICE,CATEID FROM PRODUCT WHERE  cateid = '5'", cn);
            loaddata();


        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sqlinsert = "INSERT INTO PRODUCT VALUES (@NAMEP,@PRICE,@IMAGE,@CATEID,@DESCRIPTION) ";
            using (cmd = new SqlCommand(sqlinsert, cn))
            {

                cmd.Parameters.AddWithValue("@NAMEP", txt_tensp.Text);
                cmd.Parameters.AddWithValue("@PRICE", txt_gia.Text);
                cmd.Parameters.AddWithValue("@IMAGE", "");
                cmd.Parameters.AddWithValue("@CATEID", txt_idcat.Text);
                cmd.Parameters.AddWithValue("@DESCRIPTION", "");

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm SẢN PHẨM thành công!");
                    dt.Clear();
                    adt = new SqlDataAdapter("SELECT IDP,NAMEP,PRICE,CATEID FROM PRODUCT", cn);
                    adt.Fill(dt);
                    dgvapp.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txt_id.Text = "";
                txt_tensp.Text = "";
                txt_gia.Text = "";
                txt_idcat.Text = "";

            }
            cn.Close();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sqlupdate = "UPDATE PRODUCT SET NAMEP= @NAMEP , PRICE =@PRICE , CATEID =@CATEID WHERE IDP =@IDP";
            using (cmd = new SqlCommand(sqlupdate, cn))
            {
                cmd.Parameters.AddWithValue("@NAMEP", txt_tensp.Text);
                cmd.Parameters.AddWithValue("@PRICE", txt_gia.Text);
                cmd.Parameters.AddWithValue("@IMAGE", "");
                cmd.Parameters.AddWithValue("@CATEID", txt_idcat.Text);

                try
                {
                    cmd.Parameters.AddWithValue("@IDP", txt_id.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công ");
                    dt.Clear();
                    adt = new SqlDataAdapter("SELECT IDP,NAMEP,PRICE,CATEID FROM PRODUCT", cn);
                    adt.Fill(dt);
                    dgvapp.DataSource = dt;

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                txt_id.Text = "";
                txt_tensp.Text = "";
                txt_gia.Text = "";
                txt_idcat.Text = "";
            }
            cn.Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sqldelete = "DELETE FROM PRODUCT WHERE IDP = @IDP";
            using (cmd = new SqlCommand(sqldelete, cn))
            {
                cmd.Parameters.AddWithValue("@IDP", txt_id.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công ");
                dt.Clear();
                adt = new SqlDataAdapter("SELECT IDP,NAMEP,PRICE,CATEID FROM PRODUCT", cn);
                adt.Fill(dt);
                dgvapp.DataSource = dt;

            }
            txt_id.Text = "";
            cn.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            home.Show();
            this.Close();
        }

        private void dgvapp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvapp.Rows[e.RowIndex];
            txt_id.Text = Convert.ToString(row.Cells[0].Value);
            txt_tensp.Text = Convert.ToString(row.Cells[1].Value);
            txt_gia.Text = Convert.ToString(row.Cells[2].Value);
            txt_idcat.Text = Convert.ToString(row.Cells[3].Value);
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            txt_tensp.Text = "";
            txt_gia.Text = "";
            txt_idcat.Text = "";
        }
    }
}
