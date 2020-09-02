using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QLBV
{
    public partial class Login_succeed : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                    welcome();
            }
        }

        private void welcome()
        {
            string acc = Session["username"].ToString();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select HoTenCongNhanVien, QuyenHan from tbl_CongNhanVien where TenDangNhap=@acc", conn);
            cmd.Parameters.AddWithValue("@acc", acc);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                lbl_welcome.Text = "Đăng nhập thành công!!!<br/> Welcome user: " + r["HoTenCongNhanVien"].ToString() + "<br/> Quyền hạn của user là: " + r["QuyenHan"].ToString();
            }
            r.Close();
            conn.Close();

        }

    }
}