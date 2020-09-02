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
    public partial class DanhMuc_CanLamSan_XetNghiem_KetQua_BenhNhan : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadGV();
        }

        private void loadGV()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT tbl_BenhNhan.MaBenhNhan as 'Mã bệnh nhân', tbl_BenhNhan.HoTenBenhNhan as 'Họ tên bệnh nhân', tbl_BenhNhan.NgaySinh as 'Ngày sinh', tbl_BenhNhan.GioiTinh as 'Giới tính',tbl_BenhNhan.DiaChi as 'Địa chỉ', tbl_BenhNhan.DienThoai as 'Điện thoại', tbl_BenhNhan.NoiLamViec as 'Nơi làm việc', tbl_BenhNhan.SoBHYT as 'Số bảo hiểm y tế', tbl_NgheNghiep.TenNgheNghiep as 'Nghề nghiệp', tbl_BenhNhan.HoTenNguoiNha as 'Họ tên người nhà',tbl_BenhNhan.HoTenCha as 'Họ tên cha',tbl_BenhNhan.HoTenMe as 'Họ tên mẹ' FROM tbl_BenhNhan inner join tbl_NgheNghiep on tbl_BenhNhan.MaNgheNghiep = tbl_NgheNghiep.MaNgheNghiep", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);

            gv_DanhSach.DataSource = dt;
            gv_DanhSach.DataBind();
            for (int i = 0; i < gv_DanhSach.Rows.Count; i++)
            {
                if (dt.Rows[0][3].ToString() == "true")
                    gv_DanhSach.Rows[i].Cells[3].Text = "Nữ";
                else
                    gv_DanhSach.Rows[i].Cells[3].Text = "Nam";
            }
        }

        protected void gv_DanhSach_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dataItem = (DataRowView)e.Row.DataItem;
                // Col ID
                HyperLink colID = new HyperLink();
                colID.Text = dataItem[0].ToString();
                colID.NavigateUrl = "DanhMuc_CanLamSan_XetNghiem_KetQua_DSPhieu.aspx?id=" + dataItem[0].ToString();
                e.Row.Cells[0].Controls.Add(colID);
            }
        }
    }
}