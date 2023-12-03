using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_CENTRIX.ChildformGame
{
    public partial class ChildformGHD : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBcontext dbcon = new DBcontext();

        private int newWidth = 150; // Kích thước mới của ảnh (độ rộng)
        private int newHeight = 150;
        private List<string> imageUrls = new List<string>();
        public ChildformGHD()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.connection());
            load();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            load();

        }
        #region Method 
        private void LoadimageToListView()
        {
            listGameGHD.Items.Clear();
            foreach (string imageData in imageUrls)
            {
                string[] data = imageData.Split(',');
                if (data.Length == 2)
                {
                    string imageUrl = data[0];
                    string description = data[1];

                    try
                    {
                        WebClient webClient = new WebClient();
                        byte[] imageBytes = webClient.DownloadData(imageUrl);
                        Image image = Image.FromStream(new System.IO.MemoryStream(imageBytes));
                        imageGHD.Images.Add(image);

                        ListViewItem item = new ListViewItem(description);
                        item.ImageIndex = imageGHD.Images.Count - 1;
                        listGameGHD.Items.Add(item);
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi nếu không tải được ảnh từ URL
                        Console.WriteLine("Error loading image: " + ex.Message);
                    }
                }
            }

            // Thiết lập ListView để hiển thị các ảnh và dòng văn bản
            listGameGHD.LargeImageList = imageGHD;
        }
        private void selectImageFromDb()
        {
            imageUrls.Clear();
            cmd = new SqlCommand("select * from PRODUCT where cateid = 9 and nameP like '%" + txtsearch.Text + "%'", cn);
            cn.Open();
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    string iamgeUrl = rd[3].ToString();
                    string nameGame = rd[1].ToString();


                    imageUrls.Add(iamgeUrl + "," + nameGame);
                }
                rd.Close();
                cn.Close();
            }

        }

        private void load()
        {
            selectImageFromDb();
            LoadimageToListView();
        }

        #endregion Method
    }
}
