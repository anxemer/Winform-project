using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace QLBH_CENTRIX
{
    internal class DBcontext
    {

        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        private String con;

        public String connection()
        {
            con = @"Data Source=LAPTOP-DRPTOLNJ\LENHU;Initial Catalog=Centrix1;Integrated Security=True";

            return con;
        }
    }
}
