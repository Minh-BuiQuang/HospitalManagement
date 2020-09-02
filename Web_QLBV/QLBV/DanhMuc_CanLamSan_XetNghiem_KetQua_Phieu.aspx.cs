using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QLBV
{
    public partial class DanhMuc_CanLamSan_XetNghiem_KetQua_Phieu : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["ID"] != null)
                loadInfo();
            if (!IsPostBack && Request.QueryString["code"] != null)
            {
                loadInfo();
                loadData();
            }
            if (Request.QueryString["ID"] == null && Request.QueryString["code"] == null)
            {
                Response.Redirect("DanhMuc_CanLamSan_XetNghiem_KetQua_BenhNhan.aspx");
            }
        }

        private void loadInfo()
        {
            if (Request.QueryString["ID"] == null)
            {
                string id = Request.QueryString["code"];
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT tbl_BenhNhan.HoTenBenhNhan, tbl_BenhNhan.NgaySinh, tbl_BenhNhan.GioiTinh,tbl_HoSoBenhAn.NgayVaoVien FROM tbl_BenhNhan, tbl_HoSoBenhAn, tbl_Phieu WHERE tbl_Phieu.MaPhieu = @id AND tbl_BenhNhan.MaBenhNhan = tbl_HoSoBenhAn.MaBenhNhan AND tbl_HoSoBenhAn.MaDieuTri = tbl_Phieu.MaDieuTri", conn);
                cmd.Parameters.AddWithValue("@id", id);
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    txt_HoTen.Text = r["HoTenBenhNhan"].ToString();
                    txt_NgaySinh.Text = r["NgaySinh"].ToString();
                    rdl_GioiTinh.SelectedValue = r["GioiTinh"].ToString();
                    txt_NgayVaoVien.Text = r["NgayVaoVien"].ToString();
                }
            }
            if (Request.QueryString["code"] == null)
            {
                string id = Request.QueryString["ID"];
                string mabn = "";
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT tbl_BenhNhan.HoTenBenhNhan, tbl_BenhNhan.NgaySinh, tbl_BenhNhan.GioiTinh,tbl_HoSoBenhAn.NgayVaoVien, tbl_HoSoBenhAn.MaDieuTri FROM tbl_BenhNhan inner JOIN tbl_HoSoBenhAn ON tbl_BenhNhan.MaBenhNhan = tbl_HoSoBenhAn.MaBenhNhan INNER JOIN tbl_ViTri ON tbl_HoSoBenhAn.MaViTri = tbl_ViTri.MaViTri WHERE tbl_BenhNhan.MaBenhNhan = @MaBN", conn);
                cmd.Parameters.AddWithValue("@MaBN", id);
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    txt_HoTen.Text = r["HoTenBenhNhan"].ToString();
                    txt_NgaySinh.Text = r["NgaySinh"].ToString();
                    rdl_GioiTinh.SelectedValue = r["GioiTinh"].ToString();
                    txt_NgayVaoVien.Text = r["NgayVaoVien"].ToString();
                    mabn = r["MaDieuTri"].ToString();
                }
                txt_MaPhieu.Text = createAutoCode(mabn);
                txt_NgayYeuCau.Text = DateTime.Now.ToString();
            }
        }

        private void loadData()
        {
            string hsba = Request.QueryString["code"];
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Phieu WHERE MaPhieu = @mp", conn);
            cmd.Parameters.AddWithValue("@mp", hsba);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                txt_MaPhieu.Text = r["MaPhieu"].ToString();
                ddl_ChiTieu.SelectedValue = r["MaChiTieuXetNghiem"].ToString();
                txt_NgayYeuCau.Text = r["NgayYeuCau"].ToString();
                txt_Lan.Text = r["LanThu"].ToString();
                txt_YeuCau.Text = r["YeuCauXetNghiem"].ToString();
                txt_KetQua.Text = r["KQXetNghiem"].ToString();
                ddl_BSDTri.SelectedValue = r["BacSiDieuTri"].ToString();
                ddl_Doctor.SelectedValue = r["BacSiChuyenKhoa"].ToString();
            }
        }

        private string createAutoCode(string idbn)
        {
            string id = "";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select tbl_phieu.* from tbl_Phieu, tbl_HoSoBenhAn where tbl_phieu.MaChiTieuXetNghiem is not null and tbl_phieu.MaDieuTri = tbl_HoSoBenhAn.MaDieuTri and tbl_HoSoBenhAn.MaBenhNhan = @id", conn);
            cmd.Parameters.AddWithValue("@id", idbn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);
            int i = dt.Rows.Count + 1;
            string maphieu = dt.Rows[0][1].ToString();

            if (i < 10)
                id = maphieu.Trim() + "XN0" + i.ToString();
            else
                id = maphieu.Trim() + "XN" + i.ToString();
            txt_Lan.Text = i.ToString();
            return id;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string Image = "";
            if (fu_link.HasFile)
            {
                Image += "~/source/" + fu_link.FileName;
            }
            img_upload.ImageUrl = Image;
        }
        protected void btn_savePage_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
            {
                //update
                update();
                lbl_error.Text = "Chỉnh sửa thành công";
            }
            if (Request.QueryString["code"] == null)
            {
                //insert
                insert();
                lbl_error.Text = "Đã thêm thành công";
            }
        }

        private void insert()
        {
            string id = Request.QueryString["ID"];
            string maxetnghiem = ddl_ChiTieu.SelectedValue;
            string ngayyeucau = txt_NgayYeuCau.Text;
            string lanthu = txt_Lan.Text;
            string ngayghiKQ = txt_DateResult.Text;
            string yeucau = txt_YeuCau.Text;
            string KQxetnghiem = txt_KetQua.Text;
            string BSdieutri = ddl_BSDTri.SelectedValue;
            string BSchuyenkhoa = ddl_Doctor.SelectedValue;
            string linkImage = img_upload.ImageUrl.ToString();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT tbl_Phieu VALUES ( @maphieu, @madieutri, null, null, @maxetnghiem, @ngayyeucau, @lanthu, @ngayghiKQ, null ,null, null, null, @yeucau, @kqxetnghiem, @BSdieutri, @BSchuyenkhoa, null, null, null)", conn);
            cmd.Parameters.AddWithValue("@maphieu", createAutoCode(id));
            cmd.Parameters.AddWithValue("@madieutri", createAutoCode(id).Substring(0, createAutoCode(id).Length - 4));
            cmd.Parameters.AddWithValue("@maxetnghiem", maxetnghiem);
            cmd.Parameters.AddWithValue("@ngayyeucau", ngayyeucau);
            cmd.Parameters.AddWithValue("@lanthu", lanthu);
            cmd.Parameters.AddWithValue("@ngayghiKQ", ngayghiKQ);
            cmd.Parameters.AddWithValue("@yeucau", yeucau);
            cmd.Parameters.AddWithValue("@kqxetnghiem", KQxetnghiem);
            cmd.Parameters.AddWithValue("@BSdieutri", BSdieutri);
            cmd.Parameters.AddWithValue("@BSchuyenkhoa", BSchuyenkhoa);
            //cmd.Parameters.AddWithValue("@hinhsieuam", linkImage);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void update()
        {
            string id = Request.QueryString["code"];
            string maxetnghiem = ddl_ChiTieu.SelectedValue;
            string ngayyeucau = txt_NgayYeuCau.Text;
            string lanthu = txt_Lan.Text;
            string ngayghiKQ = txt_DateResult.Text;
            string yeucau = txt_YeuCau.Text;
            string KQxetnghiem = txt_KetQua.Text;
            string BSdieutri = ddl_BSDTri.SelectedValue;
            string BSchuyenkhoa = ddl_Doctor.SelectedValue;
            string linkImage = img_upload.ImageUrl.ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE tbl_Phieu SET MaChiTieuXetNghiem = @maxetnghiem, NgayYeuCau = @ngayyeucau, LanThu = @lanthu, NgayGhiKQ = @ngayghiKQ, YeuCauXetNghiem = @yeucau, KQXetNghiem = @kqxetnghiem, BacSiDieuTri = @BSdieutri, BacSiChuyenKhoa = @BSchuyenkhoa WHERE MaPhieu = @maphieu", conn);
            cmd.Parameters.AddWithValue("@maphieu", id);
            cmd.Parameters.AddWithValue("@maxetnghiem", maxetnghiem);
            cmd.Parameters.AddWithValue("@ngayyeucau", ngayyeucau);
            cmd.Parameters.AddWithValue("@lanthu", lanthu);
            cmd.Parameters.AddWithValue("@ngayghiKQ", ngayghiKQ);
            cmd.Parameters.AddWithValue("@yeucau", yeucau);
            cmd.Parameters.AddWithValue("@kqxetnghiem", KQxetnghiem);
            cmd.Parameters.AddWithValue("@BSdieutri", BSdieutri);
            cmd.Parameters.AddWithValue("@BSchuyenkhoa", BSchuyenkhoa);
            //cmd.Parameters.AddWithValue("@hinhsieuam", linkImage);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}