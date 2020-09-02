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
    public partial class HoSo_ThongTinBenhNhan : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("TTBN");
            if (!IsPostBack)
                loadBN();
        }

        protected void loadBN()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select tbl_BenhNhan.MaBenhNhan,tbl_BenhNhan.HoTenBenhNhan,tbl_BenhNhan.GioiTinh,tbl_BenhNhan.NgaySinh,tbl_BenhNhan.DiaChi,tbl_BenhNhan.DienThoai,tbl_NgheNghiep.TenNgheNghiep,tbl_BenhNhan.NoiLamViec,tbl_DoiTuong.TenDoiTuong,tbl_BenhNhan.SoBHYT, tbl_BenhNhan.NgayBD_BHYT,tbl_BenhNhan.NgayKT_BHYT,tbl_DanToc.TenDanToc,tbl_BenhNhan.HoTenNguoiNha,tbl_BenhNhan.DiaChiNguoiNha,tbl_BenhNhan.HoTenCha,tbl_BenhNhan.HoTenMe from tbl_BenhNhan,tbl_DanToc,tbl_DoiTuong,tbl_NgheNghiep where tbl_BenhNhan.MaDoiTuong=tbl_DoiTuong.MaDoiTuong and tbl_BenhNhan.MaNgheNghiep=tbl_NgheNghiep.MaNgheNghiep and tbl_BenhNhan.MaDanToc=tbl_DanToc.MaDanToc", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv_TTBN.DataSource = dt;
            gv_TTBN.DataBind();
            for (int i = 0; i < gv_TTBN.Rows.Count; i++)
            {
                if (dt.Rows[i][2].ToString() == "True")
                    gv_TTBN.Rows[i].Cells[2].Text = "Nam";
                else if (dt.Rows[i][2].ToString() == "False")
                    gv_TTBN.Rows[i].Cells[2].Text = "Nữ";
            }
        }

        protected void gv_TTBN_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.gv_TTBN.SelectedIndex;
        }

        protected void gv_TTBN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            loadBN();
            gv_TTBN.PageIndex = e.NewPageIndex;
            gv_TTBN.DataBind();
        }

        protected void gv_TTBN_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dataItem = (DataRowView)e.Row.DataItem;
                // Col ID
                HyperLink colID = new HyperLink();
                colID.Text = dataItem[0].ToString();
                colID.NavigateUrl = "HoSo_ChiTietTTBN.aspx?id=" + dataItem[0].ToString();
                e.Row.Cells[0].Controls.Add(colID);
            }
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("HoSo_ChiTietTTBN.aspx");
        }
    }
}