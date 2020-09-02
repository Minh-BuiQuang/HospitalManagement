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
    public partial class DanhMuc_Danhsachbenhvien : System.Web.UI.Page
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
            txt_MaBenhVien.Text = btn.Text.Trim();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_BenhVien where MaBenhVien=@ma", conn);
            cmd.Parameters.AddWithValue("@ma", txt_MaBenhVien.Text);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                txt_TenBenhVien.Text = r["TenBenhVien"].ToString();
                ddl_loaituyen.SelectedItem.Text = r["LoaiTuyen"].ToString();
                txt_DienThoai.Text = r["DienThoai"].ToString();
                txt_DiaChi.Text = r["DiaChi"].ToString();
                txt_WebSite.Text = r["Website"].ToString(); 
                txt_Email.Text = r["Email"].ToString();
                txt_ChuyenMon.Text = r["ChuyenMon"].ToString();
            }
            r.Close();
            conn.Close();

            txt_TenBenhVien.Enabled = true;
            ddl_loaituyen.Enabled = true;
            txt_DienThoai.Enabled = true;
            txt_DiaChi.Enabled = true;
            txt_WebSite.Enabled = true;
            txt_Email.Enabled = true;
            txt_ChuyenMon.Enabled = true;
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
            SqlCommand cmd = new SqlCommand("select MaBenhVien, TenBenhVien, LoaiTuyen, DienThoai, DiaChi, Website, Email, ChuyenMon  from  tbl_BenhVien", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv_PatientList.DataSource = dt;
            gv_PatientList.DataBind();
        }

        private string createAutoCode()
        {
            int so;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_BenhVien", conn);
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);
            int i = (dt.Rows.Count);
            if (i == 0) so = 1;
            else
                so = Int32.Parse(dt.Rows[i - 1][0].ToString().Substring(2)) + 1;

            if (so < 10)
            {
                return "BV0" + so.ToString();
            }
            else
                return "BV" + so.ToString();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            txt_MaBenhVien.Text = createAutoCode();
            txt_TenBenhVien.Enabled = true;
            ddl_loaituyen.Enabled = true;
            txt_DienThoai.Enabled = true;
            txt_DiaChi.Enabled = true;
            txt_WebSite.Enabled = true;
            txt_Email.Enabled = true;
            txt_ChuyenMon.Enabled = true;

            txt_TenBenhVien.Text = "";
            txt_DienThoai.Text = "";
            txt_DiaChi.Text = "";
            txt_WebSite.Text = "";
            txt_Email.Text = "";
            txt_ChuyenMon.Text = "";

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

        protected void btn_save_Click(object sender, EventArgs e)
        {
            add();
            loadGV();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhMuc_DanhSachBenhVien.aspx");
        }

        private void add()
        {
            int error = 0;
            string ma = txt_MaBenhVien.Text;
            string ten = txt_TenBenhVien.Text;
            string dienthoai = txt_DienThoai.Text;
            string diachi = txt_DiaChi.Text;
            string web = txt_WebSite.Text;
            string mail = txt_Email.Text;
            string chuyenmon = txt_ChuyenMon.Text;
            string loaituyen = ddl_loaituyen.SelectedValue;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_BenhVien", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["TenBenhVien"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "Tên bệnh viện [ " + ten + " ] đã có trong Danh mục Bệnh viện";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("insert into tbl_BenhVien values(@ma, @ten ,@diachi, @dienthoai, @mail, @web, @loaituyen, @chuyenmon)", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.Parameters.AddWithValue("@diachi", diachi);
                cmd1.Parameters.AddWithValue("@dienthoai", dienthoai);
                cmd1.Parameters.AddWithValue("@mail", mail);
                cmd1.Parameters.AddWithValue("@web", web);
                cmd1.Parameters.AddWithValue("@loaituyen", loaituyen);
                cmd1.Parameters.AddWithValue("@chuyenmon", chuyenmon);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã thêm thành công";
            }
            conn.Close();
        }

        private void del()
        {
            string ma = txt_MaBenhVien.Text.Trim();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("delete from tbl_BenhVien where MaBenhVien = @ma", conn);
            cmd.Parameters.AddWithValue("@ma", ma);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            lbl_error.Text = "Đã xóa mã bệnh " + ma + " thành công";
        }

        private void update()
        {
            int error = 0;
            string ma = txt_MaBenhVien.Text;
            string ten = txt_TenBenhVien.Text;
            string dienthoai = txt_DienThoai.Text;
            string diachi = txt_DiaChi.Text;
            string web = txt_WebSite.Text;
            string mail = txt_Email.Text;
            string chuyenmon = txt_ChuyenMon.Text;
            string loaituyen = ddl_loaituyen.SelectedValue;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_BenhVien", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = r["TenBenhVien"].ToString().Trim();
                string i = r["MaBenhVien"].ToString().Trim();
                if (ten.Trim() == j && ma.Trim() != i)
                {
                    lbl_error.Text = "Tên bệnh viên [ " + ten + " ] đã có trong Danh mục Bệnh viện";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("update tbl_BenhVien set TenBenhVien = @ten, DiaChi = @diachi, DienThoai = @dienthoai, Email = @mail, Website = @web, LoaiTuyen = @loaituyen, ChuyenMon = @chuyenmon where MaBenhVien = @ma", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.Parameters.AddWithValue("@diachi", diachi);
                cmd1.Parameters.AddWithValue("@dienthoai", dienthoai);
                cmd1.Parameters.AddWithValue("@mail", mail);
                cmd1.Parameters.AddWithValue("@web", web);
                cmd1.Parameters.AddWithValue("@loaituyen", loaituyen);
                cmd1.Parameters.AddWithValue("@chuyenmon", chuyenmon);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã cập nhật thành công";
            }
            conn.Close();
        }


    }
}