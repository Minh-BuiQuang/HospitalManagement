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
    public partial class DanhMuc_CanLamSan_LoaiSieuAm_XQuang_DanhMuc : System.Web.UI.Page
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
            tb_MaXQuang.Text = btn.Text.Trim();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_ChiTietXQuang where MaXQuang = @ma", conn);
            cmd.Parameters.AddWithValue("@ma", tb_MaXQuang.Text);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                tb_TenXQuang.Text = r["TenXQuang"].ToString();
                ddl_LoaiXQuang.SelectedValue = r["MaLoaiXQuang"].ToString();
            }
            r.Close();
            conn.Close();

            tb_TenXQuang.Enabled = true;
            btn_add.Visible = false;
            btn_del.Visible = true;
            btn_edit.Visible = true;
            btn_Cancel.Visible = true;
            btn_save.Visible = false;
            ddl_LoaiXQuang.Enabled = true;
        }

        private void loadGV()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from  tbl_ChiTietXQuang", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv_PatientList.DataSource = dt;
            gv_PatientList.DataBind();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            tb_MaXQuang.Text = createAutoCode();
            tb_TenXQuang.Enabled = true;
            tb_TenXQuang.Text = "";
            ddl_LoaiXQuang.Enabled = true;
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

        private void add()
        {
            int error = 0;
            string ma = tb_MaXQuang.Text;
            string ten = tb_TenXQuang.Text;
            string maloai = ddl_LoaiXQuang.SelectedValue;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_ChiTietXQuang", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["TenXQuang"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "[ " + ten + " ] đã có trong Danh mục X-Quang";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("insert into tbl_ChiTietXQuang values(@ma,@ten,@maloai)", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.Parameters.AddWithValue("@maloai", maloai);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã thêm thành công";
            }
            conn.Close();
        }

        private void del()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("delete from tbl_ChiTietXQuang where MaXQuang = @ma", conn);
            string ma = tb_MaXQuang.Text.Trim();
            cmd.Parameters.AddWithValue("@ma", ma);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            lbl_error.Text = "Đã xóa mã " + tb_MaXQuang.Text + " thành công";
        }

        private void update()
        {
            int error = 0;
            string ma = tb_MaXQuang.Text;
            string ten = tb_TenXQuang.Text;
            string maloai = ddl_LoaiXQuang.SelectedValue;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_ChiTietXQuang", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "", i = "";
                i = r["MaXQuang"].ToString();
                j = r["TenXQuang"].ToString();
                if (ten.Trim() == j.Trim() && ma.Trim() != i.Trim())
                {
                    lbl_error.Text = "[ " + ten + " ] đã có trong Danh mục X-Quang";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("update tbl_ChiTietXQuang set TenXQuang = @ten, MaLoaiXQuang = @maloai where MaXQuang = @ma", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.Parameters.AddWithValue("@maloai", maloai);
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
            SqlCommand cmd = new SqlCommand("select * from tbl_ChiTietXQuang", conn);
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
                return "XQ0" + so.ToString();
            }
            else
                return "XQ" + so.ToString();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhMuc_CanLamSan_XQuang_ChiTieu.aspx");
        }


    }
}