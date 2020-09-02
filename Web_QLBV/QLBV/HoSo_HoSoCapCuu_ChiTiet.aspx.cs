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
    public partial class HoSo_HoSoCapCuu_ChiTiet : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGV();
            }
        }

        protected void gv_DSCapCuuChiTiet_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.gv_DSCapCuuChiTiet.SelectedIndex;
        }

        protected void gv_DSCapCuuChiTiet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            loadGV();
            gv_DSCapCuuChiTiet.PageIndex = e.NewPageIndex;
            gv_DSCapCuuChiTiet.DataBind();
        }

        protected void loadGV()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select tbl_HoSoBenhAn.MaDieuTri,tbl_HoSoBenhAn.NgayVaoVien,tbl_HoSoBenhAn.GioVaoVien,tbl_HoSoBenhAn.BacSiKham,tbl_HoSoBenhAn.TenBenhChinh,tbl_HoSoBenhAn.TenBenhKemTheo,tbl_HoSoBenhAn.TenBenhCapCuuChanDoan,tbl_HoSoBenhAn.TenBenhKhoaDieuTriChanDoan,tbl_HoSoBenhAn.TenBenhNoiChuyenChanDoan,tbl_HoSoBenhAn.XuTri,tbl_Khoa.TenKhoa from tbl_HoSoBenhAn left join tbl_Khoa on tbl_HoSoBenhAn.VaoKhoa = tbl_Khoa.MaKhoa", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv_DSCapCuuChiTiet.DataSource = dt;
            gv_DSCapCuuChiTiet.DataBind();
        }

        //protected void gv_DSCapCuuChiTiet_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        DataRowView dataItem = (DataRowView)e.Row.DataItem;
        //        // Col ID
        //        HyperLink colID = new HyperLink();
        //        colID.Text = dataItem[0].ToString();
        //        colID.NavigateUrl = "HoSo_HoSoCapCuu_HanhChinh.aspx?id=" + dataItem[0].ToString();
        //        e.Row.Cells[0].Controls.Add(colID);
        //        Session["dschitiet"] = dataItem[0].ToString().Trim();

        //    }
        //}

        protected void LoadList(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Session["dschitiet"] = btn.Text.Trim();
            Response.Redirect("HoSo_HoSoCapCuu_HanhChinh.aspx?id=" + btn.Text.Trim());
            
        }
    }
}