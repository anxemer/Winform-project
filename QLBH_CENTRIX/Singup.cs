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
    public partial class Singup : Form
    {
        string connect = @"Data Source=LAPTOP-DRPTOLNJ\LENHU;Initial Catalog=Centrix;Integrated Security=True";
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt;
        public Singup()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            try
            {
                using (conn = new SqlConnection(connect))
                {
                    conn.Open();
                    string email = txtemail.Text;
                    string mk = txtmk.Text;
                    string user = txtusername.Text;
                    string remk = txtconfirm.Text;


                    if (txtusername.Text == "" || txtemail.Text == "" || txtmk.Text == "" || txtconfirm.Text == "")
                    {
                        MessageBox.Show("Vui lòng điền đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    else if (txtconfirm.Text != txtmk.Text)
                    {
                        MessageBox.Show("Mật khẩu không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        string sql = "Insert into ACCOUNT values ('" + user + "','" + mk + "','" + email + "','0')";
                        cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Login lg = new Login();
                        lg.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtmk.UseSystemPasswordChar = !txtmk.UseSystemPasswordChar;
            if (txtmk.UseSystemPasswordChar)
            {
                checkBox1.Text = "show";
            }
            else
            {
                checkBox1.Text = "hide";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txtconfirm.UseSystemPasswordChar = !txtconfirm.UseSystemPasswordChar;
            if (txtconfirm.UseSystemPasswordChar)
            {
                checkBox2.Text = "show";
            }
            else
            {
                checkBox2.Text = "hide";
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Dispose();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
