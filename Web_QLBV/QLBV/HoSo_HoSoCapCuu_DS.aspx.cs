using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QLBV
{
    public partial class HoSo_HoSoCapCuu : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("dschitiet");
                loadGV();
            }
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
                HyperLink colID = new HyperLink();
                colID.Text = dataItem[0].ToString();
                colID.NavigateUrl = "HoSo_HoSoCapCuu_HanhChinh.aspx?id=" + dataItem[0].ToString();
                e.Row.Cells[0].Controls.Add(colID);
            }
        }

        protected void gv_PatientList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            loadGV();
            gv_PatientList.PageIndex = e.NewPageIndex;
            gv_PatientList.DataBind();
        }

        protected void loadGV()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select tbl_BenhNhan.MaBenhNhan,tbl_BenhNhan.HoTenBenhNhan,tbl_BenhNhan.GioiTinh,tbl_BenhNhan.NgaySinh,tbl_BenhNhan.DiaChi,tbl_BenhNhan.DienThoai,tbl_NgheNghiep.TenNgheNghiep,tbl_BenhNhan.NoiLamViec,tbl_DoiTuong.TenDoiTuong,tbl_BenhNhan.SoBHYT, tbl_BenhNhan.NgayBD_BHYT,tbl_BenhNhan.NgayKT_BHYT,tbl_DanToc.TenDanToc,tbl_BenhNhan.HoTenNguoiNha,tbl_BenhNhan.DiaChiNguoiNha,tbl_BenhNhan.HoTenCha,tbl_BenhNhan.HoTenMe from tbl_BenhNhan,tbl_DanToc,tbl_DoiTuong,tbl_NgheNghiep where tbl_BenhNhan.MaDoiTuong=tbl_DoiTuong.MaDoiTuong and tbl_BenhNhan.MaNgheNghiep=tbl_NgheNghiep.MaNgheNghiep and tbl_BenhNhan.MaDanToc=tbl_DanToc.MaDanToc", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv_PatientList.DataSource = dt;
            gv_PatientList.DataBind();
            for (int i = 0; i < gv_PatientList.Rows.Count; i++)
            {
                if (dt.Rows[i][2].ToString() == "True")
                    gv_PatientList.Rows[i].Cells[2].Text = "Nam";
                else if(dt.Rows[i][2].ToString() == "False")
                    gv_PatientList.Rows[i].Cells[2].Text = "Nữ";
            }
        }
    }
}