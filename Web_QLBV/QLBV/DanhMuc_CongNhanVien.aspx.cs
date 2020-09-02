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
    public partial class DanhMuc_Danhsachcongnhanvien2 : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGV();
            }
        }

        protected void LoadList(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            tb_MaCongNhanVien.Text = btn.Text.Trim();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_CongNhanVien where MaCongNhanVien=@ma", conn);
            cmd.Parameters.AddWithValue("@ma", tb_MaCongNhanVien.Text);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                tb_HoTen.Text = r["HoTenCongNhanVien"].ToString();
                dob.Text = r["NgaySinh"].ToString();
                tb_DienThoai.Text = r["DienThoai"].ToString();
                tb_DiaChi.Text = r["DiaChi"].ToString();
                tb_Email.Text = r["Email"].ToString();
                ddl_trinhdo.SelectedValue = r["MaTrinhDo"].ToString();
                ddl_khoa.SelectedValue = r["MaKhoa"].ToString();
                ddl_chucdanh.SelectedValue = r["MaChucDanh"].ToString();
                ddl_chucvu.SelectedValue = r["MaChucVu"].ToString();
            }
            r.Close();
            conn.Close();

            tb_HoTen.Enabled = true;
            tb_DiaChi.Enabled = true;
            tb_DienThoai.Enabled = true;
            tb_Email.Enabled = true;
            dob.Enabled = true;
            rbl_gioitinh.Enabled = true;
            ddl_trinhdo.Enabled = true;
            ddl_khoa.Enabled = true;
            ddl_chucdanh.Enabled = true;
            ddl_chucvu.Enabled = true;
            btn_add.Visible = false;
            btn_del.Visible = true;
            btn_edit.Visible = true;
            btn_save.Visible = false;
            btn_Cancel.Visible = true;
        }

        private void loadGV()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select MaCongNhanVien, HoTenCongNhanVien, NgaySinh, DienThoai, DiaChi, GioiTinh, Email, MaTrinhDo, MaKhoa, MaChucDanh, MaChucVu from  tbl_CongNhanVien", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv_PatientList.DataSource = dt;
            gv_PatientList.DataBind();
            for (int i = 0; i < gv_PatientList.Rows.Count; i++)
            {
                if (dt.Rows[i][5].ToString() == "True")
                    gv_PatientList.Rows[i].Cells[5].Text = "Nam";
                else
                    gv_PatientList.Rows[i].Cells[5].Text = "Nữ";

            }

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            tb_MaCongNhanVien.Text = createAutoCode();
            tb_HoTen.Enabled = true;
            tb_DiaChi.Enabled = true;
            tb_DienThoai.Enabled = true;
            tb_Email.Enabled = true;
            dob.Enabled = true;
            rbl_gioitinh.Enabled = true;
            ddl_trinhdo.Enabled = true;
            ddl_khoa.Enabled = true;
            ddl_chucdanh.Enabled = true;
            ddl_chucvu.Enabled = true;
            btn_save.Visible = true;
            btn_Cancel.Visible = true;
            btn_del.Visible = false;
            btn_edit.Visible = false;
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            del();
            loadGV();
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            update();
            loadGV();
        }

        private void add()
        {
            int error = 0;
            string ma = tb_MaCongNhanVien.Text;
            string ten = tb_HoTen.Text;
            string ngaysinh = dob.Text;
            string phone = tb_DienThoai.Text;
            string diachi = tb_DiaChi.Text;
            string sex = rbl_gioitinh.SelectedValue;
            string mail = tb_Email.Text;
            string trinhdo = ddl_trinhdo.SelectedValue;
            string khoa = ddl_khoa.SelectedValue;
            string chucdanh = ddl_chucdanh.SelectedValue;
            string chucvu = ddl_chucvu.SelectedValue;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_CongNhanVien", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["HoTenCongNhanVien"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "[ " + ten + " ] đã có trong Danh mục Công nhân viên";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("insert into tbl_CongNhanVien values(@ma, @ten, @sex, @ngaysinh, @trinhdo, @diachi, @phone, @mail, @khoa, @chucvu, @chucdanh, '', '', '')", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                cmd1.Parameters.AddWithValue("@phone", phone);
                cmd1.Parameters.AddWithValue("@diachi", diachi);
                cmd1.Parameters.AddWithValue("@sex", sex);
                cmd1.Parameters.AddWithValue("@mail", mail);
                cmd1.Parameters.AddWithValue("@trinhdo", trinhdo);
                cmd1.Parameters.AddWithValue("@khoa", khoa);
                cmd1.Parameters.AddWithValue("@chucdanh", chucdanh);
                cmd1.Parameters.AddWithValue("@chucvu", chucvu);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã thêm thành công";
            }
            conn.Close();
        }

        private void del()
        {
            string ma = tb_MaCongNhanVien.Text.Trim();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("delete from tbl_CongNhanVien where MaCongNhanVien = @ma", conn);
            cmd.Parameters.AddWithValue("@ma", ma);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            lbl_error.Text = "Đã xóa mã nhân viên " + ma + " thành công";
        }

        private void update()
        {
            int error = 0;
            string ma = tb_MaCongNhanVien.Text;
            string ten = tb_HoTen.Text;
            string ngaysinh = dob.Text;
            string phone = tb_DienThoai.Text;
            string diachi = tb_DiaChi.Text;
            string sex = rbl_gioitinh.SelectedValue;
            string mail = tb_Email.Text;
            string trinhdo = ddl_trinhdo.SelectedValue;
            string khoa = ddl_khoa.SelectedValue;
            string chucdanh = ddl_chucdanh.SelectedValue;
            string chucvu = ddl_chucvu.SelectedValue;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_CongNhanVien", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = r["HoTenCongNhanVien"].ToString().Trim();
                string i = r["MaCongNhanVien"].ToString().Trim();
                if (ten.Trim() == j && ma.Trim() != i)
                {
                    lbl_error.Text = "[ " + ten + " ] đã có trong Danh sách Công nhân viên";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("update tbl_CongNhanVien set HoTenCongNhanVien = @ten, NgaySinh = @ngaysinh, DienThoai = @phone, DiaChi = @diachi, GioiTinh = @sex, Email = @mail, MaTrinhDo = @trinhdo, MaKhoa = @khoa, MaChucDanh = @chucdanh, MaChucVu = @chucvu where MaCongNhanVien = @ma", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                cmd1.Parameters.AddWithValue("@phone", phone);
                cmd1.Parameters.AddWithValue("@diachi", diachi);
                cmd1.Parameters.AddWithValue("@sex", sex);
                cmd1.Parameters.AddWithValue("@mail", mail);
                cmd1.Parameters.AddWithValue("@trinhdo", trinhdo);
                cmd1.Parameters.AddWithValue("@khoa", khoa);
                cmd1.Parameters.AddWithValue("@chucdanh", chucdanh);
                cmd1.Parameters.AddWithValue("@chucvu", chucvu);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã cập nhật thành công";
            }
            conn.Close();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            add();
            loadGV();
        }

        private string createAutoCode()
        {
            int so;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_CongNhanVien", conn);
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);
            int i = (dt.Rows.Count);
            if (i == 0) so = 1;
            else
                so = Int32.Parse(dt.Rows[i - 1][0].ToString().Substring(3)) + 1;

            if (so < 10)
            {
                return "CNV0" + so.ToString();
            }
            else
                return "CNV" + so.ToString();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhMuc_CongNhanVien.aspx");
        }


    }
}