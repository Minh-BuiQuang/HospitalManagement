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
    public partial class InGiay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MaBA = Request.QueryString["id"];
            Dataset.DataSet_Main.dtHoSoBenhAnDataTable database = new Dataset.DataSet_Main.dtHoSoBenhAnDataTable();
            Dataset.DataSet_MainTableAdapters.dtHoSoBenhAnTableAdapter tableAdapter = new Dataset.DataSet_MainTableAdapters.dtHoSoBenhAnTableAdapter();
            tableAdapter.Fill(database, MaBA);
            CrystalReport.Giayravien document = new CrystalReport.Giayravien();
            document.SetDataSource((DataTable)database);
            CrystalReportViewer1.ReportSource = document;
        }
    }
}