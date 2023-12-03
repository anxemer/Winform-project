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
    public partial class Customer : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBcontext dbcon = new DBcontext();
        SqlDataReader dr;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable dt = new DataTable();
        Home home;
       
        public Customer(Home form)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            home = form;
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            adt = new SqlDataAdapter("select *  from CUSTOMER", cn);
            adt.Fill(dt);
            dgv_khachhang.DataSource = dt;
            dgv_khachhang.Columns[0].HeaderText = "ID";
            dgv_khachhang.Columns[1].HeaderText = "Tên";
            dgv_khachhang.Columns[2].HeaderText = "Số điện thoại";
            dgv_khachhang.Columns[3].HeaderText = "Email";
            dgv_khachhang.Columns[0].Width = 50;
            dgv_khachhang.Columns[1].Width = 200;
            dgv_khachhang.Columns[2].Width = 200;
            dgv_khachhang.Columns[3].Width = 200;
          
            this.dgv_khachhang.DefaultCellStyle.Font = new Font("UTM avo", 10);
            this.dgv_khachhang.CellBorderStyle = DataGridViewCellBorderStyle.None;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            home.Show();
            this.Close();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dt.Clear();
            cmd = new SqlCommand("SELECT * FROM CUSTOMER WHERE namecustomer like '%" + txtsearch.Text + "%'  or idCus like '%" + txtsearch.Text + "%'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();

            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dgv_khachhang.DataSource = dt;
            cn.Close();
            
            
           
          
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();    
        }
        

        private void btnthem_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sqlinsert = "INSERT INTO CUSTOMER VALUES (@NAMECUSTOMER,@PHONENUMBER,@EMAIL) ";
            using (cmd = new SqlCommand(sqlinsert, cn))
            {

                cmd.Parameters.AddWithValue("@NAMECUSTOMER", txt_ten.Text);
                cmd.Parameters.AddWithValue("@PHONENUMBER", txt_sdt.Text);  
                cmd.Parameters.AddWithValue("@EMAIL", txt_email.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!");
                    dt.Clear();
                    cmd = new SqlCommand("SELECT * FROM CUSTOMER ", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        dgv_khachhang.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                    }
                    cn.Close();
                    dr.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txt_id.Text = "";
                txt_sdt.Text = "";
                txt_ten.Text = "";
                txt_email.Text = "";

            }
            cn.Close();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sqlupdate = "UPDATE CUSTOMER SET NAMECUSTOMER= @NAMECUSTOMER , PHONENUMBER =@PHONENUMBER , EMAIL =@EMAIL WHERE IDCUS    =@IDCUS";
            using (cmd = new SqlCommand(sqlupdate, cn))
            {
                cmd.Parameters.AddWithValue("@NAMECUSTOMER", txt_ten.Text);
                cmd.Parameters.AddWithValue("@PHONENUMBER", txt_sdt.Text);
                
                cmd.Parameters.AddWithValue("@EMAIL", txt_email.Text);
                cmd.Parameters.AddWithValue("@IDCUS", txt_id.Text);
                try
                {
                   
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công ");
                    dt.Clear();
                    cmd = new SqlCommand("SELECT * FROM CUSTOMER ", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        dgv_khachhang.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                    }
                    cn.Close();
                    dr.Close();

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                txt_id.Text = "";
                txt_ten.Text = "";
                txt_sdt.Text = "";
                txt_email.Text = "";
            }
            cn.Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sqldelete = "DELETE FROM CUSTOMER WHERE IDCUS = @IDCUS";
            using (cmd = new SqlCommand(sqldelete, cn))
            {
                cmd.Parameters.AddWithValue("@IDCUS", txt_id.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công ");
                dt.Clear();
                cmd = new SqlCommand("SELECT * FROM CUSTOMER", cn);
                cn.Open();
                cmd.ExecuteNonQuery();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    dgv_khachhang.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }
                cn.Close();
                dr.Close();

            }
            txt_id.Text = "";
            cn.Close();
        }

        private void dgv_khachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgv_khachhang.Rows[e.RowIndex];
            txt_id.Text = Convert.ToString(row.Cells[0].Value);
            txt_ten.Text = Convert.ToString(row.Cells[1].Value);
            txt_sdt.Text = Convert.ToString(row.Cells[2].Value);
            txt_email.Text = Convert.ToString(row.Cells[3].Value);
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            txt_ten.Text = "";
            txt_sdt.Text = "";
            txt_email.Text = "";
        }
    }
}
