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
    public partial class DanhMuc_Thuoc1 : System.Web.UI.Page
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
            tb_MaThuoc.Text = btn.Text.Trim();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_Thuoc where MaThuoc=@ma", conn);
            cmd.Parameters.AddWithValue("@ma", tb_MaThuoc.Text);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                tb_TenThuoc.Text = r["TenThuoc"].ToString();
                tb_DonViTinh.Text = r["DVTinh"].ToString();
                tb_Losanxuat.Text = r["LoSanXuat"].ToString();
                ddl_maloaithuoc.SelectedValue = r["MaLoaiThuoc"].ToString();
            }
            r.Close();
            conn.Close();

            tb_TenThuoc.Enabled = true;
            tb_DonViTinh.Enabled = true;
            tb_Losanxuat.Enabled = true;
            btn_add.Visible = false;
            btn_del.Visible = true;
            btn_edit.Visible = true;
            btn_save.Visible = false;
            btn_Cancel.Visible = true;
            ddl_maloaithuoc.Enabled = true;
        }

        private void loadGV()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select MaThuoc, TenThuoc, DVTinh, MaLoaiThuoc, LoSanXuat from  tbl_Thuoc", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv_PatientList.DataSource = dt;
            gv_PatientList.DataBind();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            tb_MaThuoc.Text = createAutoCode();
            tb_TenThuoc.Enabled = true;
            tb_DonViTinh.Enabled = true;
            tb_Losanxuat.Enabled = true;
            ddl_maloaithuoc.Enabled = true;
            tb_TenThuoc.Text = "";
            tb_DonViTinh.Text = "";
            tb_Losanxuat.Text = "";
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
            string ma = tb_MaThuoc.Text;
            string ten = tb_TenThuoc.Text;
            string donvi = tb_DonViTinh.Text;
            string losx = tb_Losanxuat.Text;
            string maloai = ddl_maloaithuoc.SelectedValue;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_Thuoc", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["TenThuoc"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "Tên thuốc [ " + ten + " ] đã có trong Danh mục Thuốc";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("insert into tbl_Thuoc values(@ma,@ten,@donvi,@maloai,@losx)", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.Parameters.AddWithValue("@donvi", donvi);
                cmd1.Parameters.AddWithValue("@maloai", maloai);
                cmd1.Parameters.AddWithValue("@losx", losx);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã thêm thành công";
            }
            conn.Close();
        }

        private void del()
        {
            string ma = tb_MaThuoc.Text.Trim();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("delete from tbl_Thuoc where MaThuoc = @ma", conn);
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
            string ma = tb_MaThuoc.Text;
            string ten = tb_TenThuoc.Text;
            string maloai = ddl_maloaithuoc.SelectedValue;
            string donvi = tb_DonViTinh.Text;
            string losx = tb_Losanxuat.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_Thuoc", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = r["TenThuoc"].ToString().Trim();
                string i = r["MaThuoc"].ToString().Trim();
                if (ten.Trim() == j && ma.Trim() != i)
                {
                    lbl_error.Text = "Tên thuốc [ " + ten + " ] đã có trong Danh mục Thuốc";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("update tbl_Thuoc set TenThuoc = @ten, DVTinh = @donvi, MaLoaiThuoc = @maloai, LoSanXuat = @losx where MaThuoc = @ma", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.Parameters.AddWithValue("@donvi", donvi);
                cmd1.Parameters.AddWithValue("@maloai", maloai);
                cmd1.Parameters.AddWithValue("@losx", losx);
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
            SqlCommand cmd = new SqlCommand("select * from tbl_Thuoc", conn);
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);
            int i = (dt.Rows.Count);
            if (i == 0) so = 1;
            else
                so = Int32.Parse(dt.Rows[i - 1][0].ToString().Substring(1)) + 1;

            if (so < 10)
            {
                return "T0" + so.ToString();
            }
            else
                return "T" + so.ToString();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhMuc_Thuoc.aspx");
        }

    }
}