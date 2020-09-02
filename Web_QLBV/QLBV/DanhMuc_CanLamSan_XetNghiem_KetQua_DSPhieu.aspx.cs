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
    public partial class DanhMuc_CanLamSan_XetNghiem_KetQua_DSPhieu : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];
            if (!IsPostBack && id != null)
            {
                loadInfo();
                loadData();
            }
            if (id == null)
            {
                Response.Redirect("DanhMuc_CanLamSan_XetNghiem_KetQua_BenhNhan.aspx");
            }
        }

        private void loadInfo()
        {
            string id = Request.QueryString["ID"];
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT tbl_BenhNhan.HoTenBenhNhan, tbl_BenhNhan.NgaySinh, tbl_BenhNhan.GioiTinh,tbl_HoSoBenhAn.NgayVaoVien FROM tbl_BenhNhan inner JOIN tbl_HoSoBenhAn ON tbl_BenhNhan.MaBenhNhan = tbl_HoSoBenhAn.MaBenhNhan INNER JOIN tbl_ViTri ON tbl_HoSoBenhAn.MaViTri = tbl_ViTri.MaViTri WHERE tbl_BenhNhan.MaBenhNhan = @MaBN", conn);
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
            }
        }

        private void loadData()
        {
            string id = Request.QueryString["ID"];
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT      tbl_Phieu.MaPhieu as 'Mã phiếu', tbl_Phieu.LanThu as 'Lần thứ', tbl_Phieu.NgayYeuCau as 'Ngày yêu cầu', tbl_ChiTieuXetNghiem.TenChiTieuXetNghiem as 'Chỉ tiêu xét nghiệm', tbl_Phieu.YeuCauXetNghiem as 'Yêu cầu xét nghiệm', tbl_Phieu.KQXetNghiem as 'Kết quả xét nghiệm', tbl_Phieu.NgayGhiKQ as 'Ngày ghi kết quả', tbl_Phieu.BacSiDieuTri as 'Bác sĩ điều trị', tbl_Phieu.BacSiChuyenKhoa as 'Bác sĩ chuyên khoa' FROM       tbl_Phieu, tbl_ChiTieuXetNghiem , tbl_HoSoBenhAn WHERE     (tbl_HoSoBenhAn.MaBenhNhan = @id) AND (tbl_HoSoBenhAn.MaDieuTri = tbl_Phieu.MaDieuTri) AND (tbl_Phieu.MaChiTieuXetNghiem IS NOT NULL) AND (tbl_ChiTieuXetNghiem.MaChiTieuXetNghiem = tbl_Phieu.MaChiTieuXetNghiem)", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);

            gv_PatientList.DataSource = dt;
            gv_PatientList.DataBind();

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];
            Response.Redirect("DanhMuc_CanLamSan_XetNghiem_KetQua_Phieu.aspx?id=" + id);
        }

        protected void gv_PatientList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dataItem = (DataRowView)e.Row.DataItem;
                // Col ID
                HyperLink colID = new HyperLink();
                colID.Text = dataItem[0].ToString();
                colID.NavigateUrl = "DanhMuc_CanLamSan_XetNghiem_KetQua_Phieu.aspx?code=" + dataItem[0].ToString().Trim();
                e.Row.Cells[0].Controls.Add(colID);
            }
        }

    }
}