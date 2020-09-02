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
    public partial class _Default : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string acc = txt_username.Text;
            string pass = txt_password.Text;
            if (acc == "" && pass == "")
                lbl_thongBao.Text = "Nhập username và password!!";
            else
                login(acc,pass);
        }

        private void login(string acc, string pass)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select TenDangNhap, MatKhau, QuyenHan from  tbl_CongNhanVien where TenDangNhap=@acc and MatKhau=@pass", conn);
            cmd.Parameters.AddWithValue("@acc",acc);
            cmd.Parameters.AddWithValue("@pass", pass);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Session["username"] = dt.Rows[0][0].ToString();
                Session["quyenhan"] = dt.Rows[0][2].ToString().Trim();
                Response.Redirect("Login_succeed.aspx");
            }
            else
                lbl_thongBao.Visible = true;
                lbl_thongBao.Text = "Sai tên đăng nhập hoặc mật khẩu!!!";
        }


    }
}
