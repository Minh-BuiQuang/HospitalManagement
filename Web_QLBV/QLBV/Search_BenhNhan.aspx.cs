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
    public partial class Search_BenhNhan : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string getData()
        {
            string a = "";
            string id = tb_MSBenhNhan.Text;
            string name = tb_HoTen.Text;
            string khoa = ddl_Khoa.SelectedValue;
            string day_from = tb_TuNgay.Text;
            string day_to = tb_DenNgay.Text;
            int gt = int.Parse(rdl_GioiTinh.SelectedValue);

            if (gt == 1)
                a += " GioiTinh=1 ";
            else
                a += " GioiTinh=0 ";

            if (id != "")
                a += "and tbl_BenhNhan.MaBenhNhan='" + id + "' ";
            if (name != "")
                a += "and HoTenBenhNhan like N'%" + name + "%' ";
            if (ddl_Khoa.Enabled == true)
                a += "and tbl_HoSoBenhAn.VaoKhoa='" + khoa + "' ";
            if (day_from != "" && day_to != "")
                a += "and tbl_HoSoBenhAn.NgayVaoVien between'" + day_from + "'and'" + day_to + "'";
            
            return a;
        }

        private void search()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT tbl_BenhNhan.MaBenhNhan as 'Mã bệnh nhân', tbl_BenhNhan.HoTenBenhNhan as 'Họ tên bệnh nhân', tbl_BenhNhan.NgaySinh as 'Ngày sinh', tbl_BenhNhan.GioiTinh as 'Giới tính',tbl_HoSoBenhAn.NgayVaoVien as 'Ngày vào viện',tbl_Khoa.TenKhoa as 'Vào khoa', tbl_ViTri.MaViTri as 'Vị trí',tbl_BenhNhan.DiaChi as 'Địa chỉ', tbl_BenhNhan.DienThoai as 'Điện thoại', tbl_BenhNhan.NoiLamViec as 'Nơi làm việc',tbl_BenhNhan.HoTenNguoiNha as 'Họ tên người nhà',tbl_BenhNhan.HoTenCha as 'Họ tên cha',tbl_BenhNhan.HoTenMe as 'Họ tên mẹ' FROM tbl_BenhNhan inner JOIN tbl_HoSoBenhAn ON tbl_BenhNhan.MaBenhNhan = tbl_HoSoBenhAn.MaBenhNhan INNER JOIN tbl_ViTri ON tbl_HoSoBenhAn.MaViTri = tbl_ViTri.MaViTri LEFT JOIN tbl_Khoa ON tbl_HoSoBenhAn.VaoKhoa = tbl_Khoa.MaKhoa WHERE " + getData(), conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);

            gv_DanhSach.DataSource = dt;
            gv_DanhSach.DataBind();
            //cmd.ExecuteNonQuery();
            //conn.Close();
            for (int i = 0; i < gv_DanhSach.Rows.Count; i++)
            {
                if (dt.Rows[0][3].ToString() == "true")
                    gv_DanhSach.Rows[i].Cells[3].Text = "Nữ";
                else
                    gv_DanhSach.Rows[i].Cells[3].Text = "Nam";
            }
        }

        protected void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (tb_TuNgay.Text == "" && tb_DenNgay.Text != "" || tb_TuNgay.Text != "" && tb_DenNgay.Text == "")
                lbl_error.Visible = true;
            else
            {
                lbl_error.Visible = false;
                search();
            }
        }

        protected void cb_enable_CheckedChanged(object sender, EventArgs e)
        {
            if (ddl_Khoa.Enabled==false)
                ddl_Khoa.Enabled = true;
            else
                ddl_Khoa.Enabled = false;
        }
    }
}