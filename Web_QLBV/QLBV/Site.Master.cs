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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                string user = Session["username"].ToString();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString;
                SqlCommand cmd = new SqlCommand("select * from tbl_CongNhanVien where TenDangNhap = @user", conn);
                cmd.Parameters.AddWithValue("@user", user);
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    lb_fullName.Text = r["HoTenCongNhanVien"].ToString();
                }
                if (Session["quyenhan"].ToString() == "admin")
                    lkb_fullName.Visible = true;

                if (Session["quyenhan"].ToString() == "bacsi")
                {
                    SieuAm.Visible = false;
                    XQuang.Visible = false;
                    XetNghiem.Visible = false;
                    ThongKe.Visible = false;
                }
                else if (Session["quyenhan"].ToString() == "dieuduong")
                {
                    DanhMuc.Visible = false;
                }

            }
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }


    }
}
