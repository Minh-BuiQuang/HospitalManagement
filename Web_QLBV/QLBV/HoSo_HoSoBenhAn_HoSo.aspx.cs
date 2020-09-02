using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QLBV
{
    public partial class HoSo_HoSoBenhAn_BenhNhan : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                loadGV();
        }

        protected void gv_PatientList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            loadGV();
            gv_PatientList.PageIndex = e.NewPageIndex;
            gv_PatientList.DataBind();
        }

        protected void gv_PatientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.gv_PatientList.SelectedIndex;
        }

        protected void gv_PatientList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dataItem = (DataRowView)e.Row.DataItem;
                // Col ID
                HyperLink colID1 = new HyperLink();
                colID1.Text = dataItem[0].ToString();
                colID1.NavigateUrl = "HoSo_HoSoBenhAn_VaoVien.aspx?id=" + dataItem[0].ToString();
                e.Row.Cells[1].Controls.Add(colID1);
            }
        }

        protected void loadGV()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select tbl_HoSoBenhAn.MaDieuTri, tbl_HoSoBenhAn.MaBenhNhan,"
            +"tbl_BenhNhan.HoTenBenhNhan, tbl_HoSoBenhAn.NgayVaoVien, tbl_HoSoBenhAn.GioVaoVien,"
            +"tbl_HoSoBenhAn.TenBacSiKham, tbl_HoSoBenhAn.TenBenhChinh, tbl_HoSoBenhAn.TenBenhKemTheo,"
            +"tbl_HoSoBenhAn.TenBenhCapCuuChanDoan,tbl_HoSoBenhAn.TenBenhKhoaDieuTriChanDoan,"
            +"tbl_HoSoBenhAn.TenBenhNoiChuyenChanDoan,tbl_HoSoBenhAn.XuTri,tbl_Khoa.TenKhoa,"
            +" tbl_HoSoBenhAn.NgayLamBenhAn, tbl_HoSoBenhAn.TenBSLamBenhAn, tbl_HoSoBenhAn.NgayRaVien,"
            +"tbl_HoSoBenhAn.GioRaVien, tbl_HoSoBenhAn.TenNguoiDuyet, tbl_HoSoBenhAn.MaViTri "
            +"from tbl_HoSoBenhAn, tbl_BenhNhan,tbl_Khoa"
            +" where tbl_HoSoBenhAn.VaoKhoa=tbl_Khoa.MaKhoa and tbl_HoSoBenhAn.MaBenhNhan=tbl_BenhNhan.MaBenhNhan", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv_PatientList.DataSource = dt;
            gv_PatientList.DataBind();
        }
    }
}