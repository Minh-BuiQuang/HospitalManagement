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
    public partial class Search_CongNhanhVien : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cb_Khoa_CheckedChanged(object sender, EventArgs e)
        {
            if (ddl_Khoa.Enabled == false)
                ddl_Khoa.Enabled = true;
            else
                ddl_Khoa.Enabled = false;
        }

        protected void cb_ChucVu_CheckedChanged(object sender, EventArgs e)
        {
            if (ddl_ChucVu.Enabled == false)
                ddl_ChucVu.Enabled = true;
            else
                ddl_ChucVu.Enabled = false;
        }

        protected void cb_ChucDanh_CheckedChanged(object sender, EventArgs e)
        {
            if (ddl_ChucDanh.Enabled == false)
                ddl_ChucDanh.Enabled = true;
            else
                ddl_ChucDanh.Enabled = false;
        }

        private string getData()
        {
            string a = "";
            string id = tb_MaCongNhanVien.Text;
            string name = tb_HoTen.Text;
            string khoa = ddl_Khoa.SelectedValue;
            string cv = ddl_ChucVu.SelectedValue;
            string cd = ddl_ChucDanh.SelectedValue;
            int gt = int.Parse(rdl_GioiTinh.SelectedValue);

            if (gt == 1)
                a += " tbl_CongNhanVien.GioiTinh=1 ";
            else
                a += " tbl_CongNhanVien.GioiTinh=0 ";

            if (id != "")
                a += "and tbl_CongNhanVien.MaCongNhanVien='" + id + "' ";
            if (name != "")
                a += "and tbl_CongNhanVien.HoTenCongNhanVien like N'%" + name + "%' ";
            if (ddl_Khoa.Enabled == true)
                a += "and tbl_CongNhanVien.MaKhoa='" + khoa + "' ";
            if (ddl_ChucVu.Enabled == true)
                a += "and tbl_CongNhanVien.MaChucVu='" + cv + "' ";
            if (ddl_ChucDanh.Enabled == true)
                a += "and tbl_CongNhanVien.MaChucDanh='" + cd + "' ";

            return a;
        }

        private void search()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT tbl_CongNhanVien.MaCongNhanVien as 'Mã CNV' , tbl_CongNhanVien.HoTenCongNhanVien as 'Họ tên',tbl_CongNhanVien.GioiTinh as 'Giới tính' ,tbl_CongNhanVien.NgaySinh as 'Ngày sinh',tbl_TrinhDo.TrinhDo as 'Trình độ',tbl_CongNhanVien.DiaChi as 'Địa chỉ',tbl_CongNhanVien.DienThoai as 'Điện thoại',tbl_CongNhanVien.Email,tbl_Khoa.TenKhoa as 'Khoa',tbl_ChucVu.TenChucVu as 'Chức vụ', tbl_ChucDanh.ChucDanh  as 'Chức danh' FROM tbl_CongNhanVien LEFT JOIN tbl_Khoa ON tbl_CongNhanVien.MaKhoa = tbl_Khoa.MaKhoa LEFT JOIN tbl_TrinhDo ON tbl_CongNhanVien.MaTrinhDo = tbl_TrinhDo.MaTrinhDo LEFT JOIN tbl_ChucVu ON tbl_CongNhanVien.MaChucVu = tbl_ChucVu.MaChucVu LEFT JOIN tbl_ChucDanh ON tbl_CongNhanVien.MaChucDanh = tbl_ChucDanh.MaChucDanh WHERE " + getData() , conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);

            gv_DanhSach.DataSource = dt;
            gv_DanhSach.DataBind();

            for (int i = 0; i < gv_DanhSach.Rows.Count; i++)
            {
                if (dt.Rows[i][2].ToString() == "True")
                    gv_DanhSach.Rows[i].Cells[2].Text = "Nam";
                else
                    gv_DanhSach.Rows[i].Cells[2].Text = "Nữ";

            }
        }

        protected void btn_TimKiem_Click(object sender, EventArgs e)
        {
            search();
        }

    }
}