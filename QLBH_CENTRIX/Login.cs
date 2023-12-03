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
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBcontext dbcon = new DBcontext();
        Home_Cus home;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string _id = "";
                string _name = "";
                string _isAdmin = "";

                cn.Open();
                cmd = new SqlCommand("select * from ACCOUNT where userName = @name and passWord = @pass", cn);
                cmd.Parameters.AddWithValue("@name", txtusername.Text);
                cmd.Parameters.AddWithValue("@pass", txtmk.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    _name = dr["userName"].ToString();
                    _isAdmin = dr["isAdmin"].ToString();
                    _id = dr["id"].ToString();
                    if (_isAdmin == "admin")
                    {
                        MessageBox.Show("welcome " + _name + " |", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Home home = new Home();
                        home.txtId.Text = _id;
                        home.lblusername.Text = _name;
                        this.Hide();
                        home.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("welcome " + _name + " |", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Home_Cus homecus = new Home_Cus();
                        homecus.txtId.Text = _id;
                        homecus.lblusername.Text = _name;
                        this.Hide();
                        homecus.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("sai tên đăng nhập hoặc mật khẩu....vui lòng nhập lại", "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
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

        private void btnexit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {

            Singup sg = new Singup();
            sg.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
