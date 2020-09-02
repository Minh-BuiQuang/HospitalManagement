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
    public partial class DanhMuc_Thuthuat : System.Web.UI.Page
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
            tb_MaThuThuat.Text = btn.Text.Trim();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_ThuThuat where MaThuThuat=@ma", conn);
            cmd.Parameters.AddWithValue("@ma", tb_MaThuThuat.Text);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                tb_TenThuThuat.Text = r["TenThuThuat"].ToString();
                ddl_tenloaithuthuat.SelectedValue = r["MaLoaiThuThuat"].ToString();
            }
            r.Close();
            conn.Close();

            tb_TenThuThuat.Enabled = true;
            btn_add.Visible = false;
            btn_del.Visible = true;
            btn_edit.Visible = true;
            btn_Cancel.Visible = true;
            btn_save.Visible = false;
            ddl_tenloaithuthuat.Enabled = true;
        }

        private void loadGV()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from  tbl_ThuThuat", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv_PatientList.DataSource = dt;
            gv_PatientList.DataBind();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            tb_MaThuThuat.Text = createAutoCode();
            tb_TenThuThuat.Enabled = true;
            tb_TenThuThuat.Text = "";
            ddl_tenloaithuthuat.Enabled = true;
            btn_save.Visible = true;
            btn_Cancel.Visible = true;
            btn_edit.Visible = false;
            btn_del.Visible = false;
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

        private void del()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("delete from tbl_ThuThuat where MaThuThuat = @ma", conn);
            string ma = tb_MaThuThuat.Text.Trim();
            cmd.Parameters.AddWithValue("@ma", ma);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            lbl_error.Text = "Đã xóa mã bệnh " + tb_MaThuThuat.Text + " thành công";
        }

        private void update()
        {
            int error = 0;
            string ma = tb_MaThuThuat.Text;
            string ten = tb_TenThuThuat.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_ThuThuat", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["TenThuThuat"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "Tên thủ thuật [ " + ten + " ] đã có trong Danh mục Thủ thuật";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("update tbl_ThuThuat set TenThuThuat = @ten where MaThuThuat = @ma", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã cập nhật thành công";
            }
            conn.Close();
        }

        private void add()
        {
            int error = 0;
            string ma = tb_MaThuThuat.Text;
            string ten = tb_TenThuThuat.Text;
            string maloai = ddl_tenloaithuthuat.SelectedValue;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_ThuThuat", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string i = "", j = "";
                i = r["MaThuThuat"].ToString();
                j = r["TenThuThuat"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "Tên thủ thuật [ " + ten + " ] đã có trong Danh mục Thủ thuật";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("insert into tbl_ThuThuat values(@ma,@ten,@maloai)", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.Parameters.AddWithValue("@maloai", maloai);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã thêm thành công";
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
            SqlCommand cmd = new SqlCommand("select * from tbl_ThuThuat", conn);
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
                return "TT0" + so.ToString();
            }
            else
                return "TT" + so.ToString();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhMuc_ThuThuat.aspx");
        }


    }
}