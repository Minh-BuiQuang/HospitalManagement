using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QLBV
{
    public partial class ThongKeBenhNhan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Load_Click(object sender, EventArgs e)
        {
            if (txt_DayIn.Text != "" && txt_DayOut.Text != "")
            {
                Dataset.DB_WebBenhVienDataSet1.dtDanhSachDataTable database = new Dataset.DB_WebBenhVienDataSet1.dtDanhSachDataTable();
                Dataset.DB_WebBenhVienDataSet1TableAdapters.dtDanhSachTableAdapter tableAdapter = new Dataset.DB_WebBenhVienDataSet1TableAdapters.dtDanhSachTableAdapter();
                //DB_BenhVienDataSet1.EnforceConstraints = False;
                //tableAdapter.Fill(database,txtKhoa.Text);
                DateTime tungay = DateTime.Parse(txt_DayIn.Text);
                DateTime denngay = DateTime.Parse(txt_DayOut.Text);
                tableAdapter.Fill(database, ddl_Khoa.SelectedValue, tungay, denngay);

                CrystalReport.DanhSachBenhNhanNhapXuatVien document = new CrystalReport.DanhSachBenhNhanNhapXuatVien();
                document.SetDataSource((DataTable)database);
                CrystalReportViewer1.ReportSource = document;
            }
        }
    }
}