﻿using System;
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
    public partial class DanhMuc_Loaiphauthuat : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiPhauThuat", conn);
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
            tb_MaLoaiPhauThuat.Text = btn.Text.Trim();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiPhauThuat where MaLoaiPhauThuat=@ma", conn);
            cmd.Parameters.AddWithValue("@ma", tb_MaLoaiPhauThuat.Text);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                tb_TenLoaiPhauThuat.Text = r["TenLoaiPhauThuat"].ToString();
            }
            r.Close();
            conn.Close();

            tb_TenLoaiPhauThuat.Enabled = true;
            btn_add.Visible = false;
            btn_del.Visible = true;
            btn_edit.Visible = true;
            btn_save.Visible = false;
            btn_Cancel.Visible = true;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            add();
            loadGV();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhMuc_LoaiPhauThuat.aspx");
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            tb_MaLoaiPhauThuat.Text = createAutoCode();
            tb_TenLoaiPhauThuat.Enabled = true;
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

        private string createAutoCode()
        {
            int so;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiPhauThuat", conn);
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
                return "LPT0" + so.ToString();
            }
            else
                return "LpT" + so.ToString();
        }

        private void add()
        {
            int error = 0;
            string ma = tb_MaLoaiPhauThuat.Text;
            string ten = tb_TenLoaiPhauThuat.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiPhauThuat", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["TenLoaiPhauThuat"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "[ " + ten + " ] đã có trong Danh mục Loại phẫu thuật";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("insert into tbl_LoaiPhauThuat values(@ma,@ten)", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã thêm thành công";
            }
            conn.Close();
            tb_TenLoaiPhauThuat.Text = "";
        }

        private void del()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("delete from tbl_LoaiPhauThuat where MaLoaiPhauThuat = @ma", conn);
            string ma = tb_MaLoaiPhauThuat.Text;
            cmd.Parameters.AddWithValue("@ma", ma);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            lbl_error.Text = "Đã xóa mã phẫu thuật " + ma + " thành công";
        }

        private void update()
        {
            int error = 0;
            string ma = tb_MaLoaiPhauThuat.Text; ;
            string ten = tb_TenLoaiPhauThuat.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand("select * from tbl_LoaiPhauThuat", conn);
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string j = "";
                j = r["TenLoaiPhauThuat"].ToString();
                if (ten.Trim() == j.Trim())
                {
                    lbl_error.Text = "[ " + ten + " ] đã có trong Danh mục Loại phẫu thuật";
                    error = 1;
                }
            }
            r.Close();
            if (error == 0)
            {
                SqlCommand cmd1 = new SqlCommand("update tbl_LoaiPhauThuat set TenLoaiPhauThuat = @ten where MaLoaiPhauThuat = @ma", conn);
                cmd1.Parameters.AddWithValue("@ma", ma);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.ExecuteNonQuery();
                lbl_error.Text = "Đã cập thành công";
            }
            conn.Close();
        }


    }
}