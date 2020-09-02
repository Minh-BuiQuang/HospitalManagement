using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QLBV
{
    public partial class Load_Image : System.Web.UI.Page
    {
        private string source = ConfigurationManager.ConnectionStrings["Image"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_back.Attributes.Add("onclick", "javascript:history.go(-1);return false");
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {

            string Image = "";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = source;
            conn.Open();
            if (fu_link.HasFile)
            {
                Image += "~/source/" + fu_link.FileName;
                fu_link.SaveAs(Server.MapPath(Image));
            }
            SqlCommand cmd = new SqlCommand("Insert into image values(@link)", conn);
            cmd.Parameters.AddWithValue("@link", Image);
            cmd.ExecuteNonQuery();
            conn.Close();
            img_upload.ImageUrl = Image;

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            
        }
    }
}