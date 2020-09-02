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
    public partial class TaiKhoan_QuanLy : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        protected void LoadList(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string name = btn.Text.Trim();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_CongNhanVien where HoTenCongNhanVien = @name", conn);
            cmd.Parameters.AddWithValue("@name", name);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                txt_maCNV.Text = r["MaCongNhanVien"].ToString();
                txt_ngaysinh.Text = r["NgaySinh"].ToString();
                rbl_gioitinh.SelectedValue = r["GioiTinh"].ToString();
                ddl_ChucVu.SelectedValue = r["MaChucVu"].ToString();
                ddl_ChucDanh.SelectedValue = r["MaChucDanh"].ToString();
                ddl_Khoa.SelectedValue = r["MaKhoa"].ToString();
                string quyen = r["QuyenHan"].ToString().Trim();
                if (quyen != "")
                    ddl_PhanQuyen.SelectedItem.Text = quyen;
                txt_username.Text = r["TenDangNhap"].ToString();
                txt_password.Text = r["MatKhau"].ToString();
            }
            r.Close();
            conn.Close();
        }

        private void loadData()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from  tbl_CongNhanVien", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv_PatientList.DataSource = dt;
            gv_PatientList.DataBind();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string maCNV = txt_maCNV.Text;
            string username = txt_username.Text;
            string pass = txt_password.Text;
            string quyen = ddl_PhanQuyen.SelectedItem.Text;
            if (maCNV != "")
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString;
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tbl_CongNhanVien SET TenDangNhap = @user, MatKhau = @pass, QuyenHan = @quyen WHERE MaCongNhanVien = @macnv", conn);
                cmd.Parameters.AddWithValue("@macnv", maCNV);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@quyen", quyen);
                cmd.ExecuteNonQuery();
                conn.Close();
                loadData();
                lbl_error.Text = "Đã cập nhật thành công";
            }
        }
    }
}