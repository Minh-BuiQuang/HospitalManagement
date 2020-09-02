using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace QLBV
{
    public partial class DanhMuc_Benh1 : System.Web.UI.Page
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
            tb_Mabenh.Text = btn.Text.Trim();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_Benh where MaBenh=@ma", conn);
            cmd.Parameters.AddWithValue("@ma", tb_Mabenh.Text);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                tb_TenBenh.Text = r["TenBenh"].ToString();
                ddl_loaibenh.SelectedValue = r["MaLoaiBenh"].ToString();
            }
            r.Close();
            conn.Close();

            tb_TenBenh.Enabled = true;
            btn_add.Visible = false;
            btn_del.Visible = true;
            btn_edit.Visible = true;
            btn_Cancel.Visible = true;
            btn_save.Visible = false;
            ddl_loaibenh.Enabled = true;
        }

        private void loadGV()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from  tbl_Benh", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv_PatientList.DataSource = dt;
            gv_PatientList.DataBind();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            tb_Mabenh.Text = createAutoCode(ddl_loaibenh.SelectedValue);
            tb_TenBenh.Enabled = true;
            tb_TenBenh.Text = "";
            ddl_loaibenh.Enabled = true;
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
            SqlCommand cmd = new SqlCommand("delete from tbl_Benh where MaBenh = @ma", conn);
            string ma = tb_Mabenh.Text.Trim();
            cmd.Parameters.AddWithValue("@ma", ma);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            lbl_error.Text = "Đã xóa mã bệnh " + tb_Mabenh.Text + " thành công";
        }

        private void update()
        {
            int error = 0;
            string ma = tb_Mabenh.Text;
            string ten = tb_TenBenh.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_Benh", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["TenBenh"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "Tên Bệnh [ " + ten + " ] đã có trong Danh mục Bệnh";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("update tbl_Benh set TenBenh = @ten where MaBenh = @ma", conn);
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
            string ma = tb_Mabenh.Text;
            string ten = tb_TenBenh.Text;
            string maloai = ddl_loaibenh.SelectedValue;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_Benh", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["TenBenh"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "Tên bệnh [ " + ten + " ] đã có trong Danh mục Bệnh";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("insert into tbl_Benh values(@ma,@ten,@maloai)", conn);
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

        protected void ddl_loaibenh_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Mabenh.Text = createAutoCode(ddl_loaibenh.SelectedValue);
        }

        private string createAutoCode(string maLB)
        {
            int i = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Benh", conn);
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["MaLoaiBenh"].ToString();
                if (maLB.Trim() == j.Trim())
                {
                    i++;
                }
            }
            r.Close();
            conn.Close();
            string id = maLB.Trim() + "." + i.ToString();
            return id;
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhMuc_Benh.aspx");
        }

    }
}