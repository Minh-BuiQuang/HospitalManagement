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
    public partial class DanhMuc_Loaithuoc1 : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGV();
            }
        }

        private string createAutoCode()
        {
            int so;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiThuoc", conn);
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
                return "LT0" + so.ToString();
            }
            else
                return "LT" + so.ToString();
        }

        private void loadGV()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiThuoc", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv_PatientList.DataSource = dt;
            gv_PatientList.DataBind();
        }

        protected void LoadList(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            tb_MaLoaiThuoc.Text = btn.Text.Trim();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiThuoc where MaLoaiThuoc=@ma", conn);
            cmd.Parameters.AddWithValue("@ma", tb_MaLoaiThuoc.Text);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                tb_TenLoaiThuoc.Text = r["TenLoaiThuoc"].ToString();
            }
            r.Close();
            conn.Close();

            tb_TenLoaiThuoc.Enabled = true;
            btn_del.Visible = true;
            btn_edit.Visible = true;
            btn_save.Visible = false;
            btn_cancel.Visible = false;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            add();
            loadGV();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhMuc_LoaiThuoc.aspx");
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            tb_MaLoaiThuoc.Text = createAutoCode();
            tb_TenLoaiThuoc.Enabled = true;
            btn_save.Visible = true;
            btn_cancel.Visible = true;
            btn_del.Visible = false;
            btn_edit.Visible = false;

        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            if (tb_MaLoaiThuoc.Text != "")
            {
                del();
                Response.Redirect("DanhMuc_LoaiThuoc.aspx");
            }
            else
                lbl_error.Text = "Không xóa được vì chưa chọn mã loại thuốc";
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            if (tb_MaLoaiThuoc.Text != "")
            {
                update();
                Response.Redirect("DanhMuc_LoaiThuoc.aspx");
            }
            else
                lbl_error.Text = "Chọn loại thuốc";
        }

        private void add()
        {
            int error = 0;
            string ma = tb_MaLoaiThuoc.Text;
            string ten = tb_TenLoaiThuoc.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiThuoc", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["TenLoaiThuoc"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "Tên loại thuốc [ " + ten.ToUpper() + " ] đã có trong Danh mục Loại thuốc";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("insert into tbl_LoaiThuoc values(@ma,@ten)", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã thêm thành công";
            }
            conn.Close();
            tb_TenLoaiThuoc.Text = "";
        }

        private void del()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("delete from tbl_LoaiThuoc where MaLoaiThuoc = @ma", conn);
            string ma = tb_MaLoaiThuoc.Text;
            cmd.Parameters.AddWithValue("@ma", ma);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            lbl_error.Text = "Đã xóa mã bệnh " + tb_MaLoaiThuoc.Text + " thành công";
        }

        private void update()
        {
            int error = 0;
            string ma = tb_MaLoaiThuoc.Text; ;
            string ten = tb_TenLoaiThuoc.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiThuoc", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["TenLoaiThuoc"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "Tên loại thuốc [ " + ten.ToUpper() + " ] đã có trong Danh mục Loại thuốc";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("update tbl_LoaiThuoc set TenLoaiThuoc = @ten where MaLoaiThuoc = @ma", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã cập nhật thành công thành công";
            }
            conn.Close();
        }

    }
}