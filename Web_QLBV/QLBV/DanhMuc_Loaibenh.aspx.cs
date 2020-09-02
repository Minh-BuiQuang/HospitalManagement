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
    public partial class DanhMuc_Loaibenh1 : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGV();
            }
        }

        private void loadGV()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiBenh", conn);
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
            tb_MaLoaibenh.Text = btn.Text.Trim();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_DanhSachDichTruyen where MaLoaiBenh=@ma", conn);
            cmd.Parameters.AddWithValue("@ma", tb_MaLoaibenh.Text);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                tb_Tenloaibenh.Text = r["TenLoaiBenh"].ToString();
            }
            r.Close();
            conn.Close();

            tb_Tenloaibenh.Enabled = true;
            btn_add.Visible = false;
            btn_del.Visible = true;
            btn_edit.Visible = true;
            btn_save.Visible = false;
            btn_cancel.Visible = true;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            add();
            loadGV();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhMuc_LoaiBenh.aspx");
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            tb_MaLoaibenh.Text = createAutoCode();
            tb_Tenloaibenh.Enabled = true;
            btn_save.Visible = true;
            btn_cancel.Visible = true;
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

        private string createAutoCode()
        {
            int so;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiBenh", conn);
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
                return "A0" + so.ToString();
            }
            else
                return "A" + so.ToString();
        }

        private void add()
        {
            int error = 0;
            string ma = tb_MaLoaibenh.Text;
            string ten = tb_Tenloaibenh.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiBenh", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["TenLoaiBenh"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "Tên loại bệnh [ " + ten + " ] đã có trong Danh mục Loại bệnh";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("insert into tbl_LoaiBenh values(@ma,@ten)", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã thêm thành công";
            }
            conn.Close();
            tb_Tenloaibenh.Text = "";
        }

        private void del()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("delete from tbl_LoaiBenh where MaLoaiBenh = @ma", conn);
            string ma = tb_MaLoaibenh.Text;
            cmd.Parameters.AddWithValue("@ma", ma);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            lbl_error.Text = "Đã xóa mã bệnh " + tb_MaLoaibenh.Text + " thành công";
        }

        private void update()
        {
            int error = 0;
            string ma = tb_MaLoaibenh.Text; ;
            string ten = tb_Tenloaibenh.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiBenh", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["TenLoaiBenh"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "Tên loại bệnh [ " + ten + " ] đã có trong Danh mục Loại bệnh";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("update tbl_LoaiBenh set TenLoaiBenh = @ten where MaLoaiBenh = @ma", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã cập nhật thành công";
            }
            conn.Close();
        }
       
    }
}