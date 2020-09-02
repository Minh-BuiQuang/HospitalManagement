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
    public partial class HoSo_ChiTietTTBN : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["ID"];
                if (id!=null)
                    Edit();
                else
                    txt_MSBN.Text = createAutoCode();
            }
        }

        public string createAutoCode()
        {
            string _year;
            int so;

            _year = DateTime.Now.Year.ToString().Substring(2);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_BenhNhan", conn);
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);
            int i = (dt.Rows.Count);
            if (i == 0) so = 1;
            else
            so = Int32.Parse(dt.Rows[i - 1][0].ToString().Substring(8)) + 1;

            if (so < 10)
            {
                return "HM" + _year + "/0000" + so.ToString();
            }
            else
                return "HM" + _year + "/000" + so.ToString();
        }

        protected void btn_Them_Click(object sender, EventArgs e)
        {
            string MaBN = txt_MSBN.Text;
            string hoten = txt_HoTenBN.Text;
            string birth = dob.Text;
            string dienthoai = txt_Phone.Text;
            string diachi = txt_Address.Text;
            string diachilamviec = txt_WorkPlace.Text;
            string doituong = ddl_DoiTuong.SelectedValue;
            string MaBHYT = txt_MaBHYT.Text;
            string gioitinh = rd_Gender.SelectedValue;

            string bdbhyt = bd_bhyt.Text;
            string ktbhyt = kt_bhyt.Text;
            string hotencha = txt_DadsName.Text;
            string tennghenghiepcha = ddl_DadJob.SelectedValue;
            string hotenme = txt_MomsName.Text;
            string nghenghiepme = ddl_MomJob.SelectedValue;
            string nguoilienlac = txt_Relative.Text;
            string diachilienlac = txt_FamilyAddress.Text;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_BenhNhan values(@MaBenhNhan, @HoTenBenhNhan, @NgaySinh, @GioiTinh, @DiaChi,@DienThoai,@NoiLamViec,@MaDoiTuong,@SoBHYT,@NgayBD_BHYT,@NgayKT_BHYT,@MaQuocTich,@MaTinhThanh,@MaQuanHuyen,@MaPhuongXa,@MaDanToc,@MaNgheNghiep,@HoTenNguoiNha,@DiaChiNguoiNha,@HoTenCha,@NgheNghiepCha,@TenNgheNghiepCha,@HoTenMe,@NgheNghiepMe,@TenNgheNghiepMe)", conn);
            cmd.Parameters.AddWithValue("@MaBenhNhan", MaBN);
            cmd.Parameters.AddWithValue("@HoTenBenhNhan", hoten);
            cmd.Parameters.AddWithValue("@NgaySinh", "01/01/2011");
            cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
            cmd.Parameters.AddWithValue("@DiaChi", diachi);
            cmd.Parameters.AddWithValue("@DienThoai", dienthoai);
            cmd.Parameters.AddWithValue("@NoiLamViec", diachilamviec);
            cmd.Parameters.AddWithValue("@MaDoiTuong", doituong);
            cmd.Parameters.AddWithValue("@SoBHYT", MaBHYT);
            cmd.Parameters.AddWithValue("@NgayBD_BHYT", "01/01/2011");
            cmd.Parameters.AddWithValue("@NgayKT_BHYT", "01/01/2011");
            cmd.Parameters.AddWithValue("@HoTenNguoiNha", nguoilienlac);
            cmd.Parameters.AddWithValue("@DiaChiNguoiNha", diachilienlac);
            cmd.Parameters.AddWithValue("@HoTenCha", hotencha);
            cmd.Parameters.AddWithValue("@NgheNghiepCha", ddl_DadJob.SelectedValue);
            cmd.Parameters.AddWithValue("@TenNgheNghiepCha", ddl_DadJob.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@HoTenMe", hotenme);
            cmd.Parameters.AddWithValue("@NgheNghiepMe", ddl_MomJob.SelectedValue);
            cmd.Parameters.AddWithValue("@TenNgheNghiepMe", ddl_Nationality.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@MaQuocTich", ddl_Nationality.SelectedValue);
            cmd.Parameters.AddWithValue("@MaTinhThanh", ddl_City.SelectedValue);
            cmd.Parameters.AddWithValue("@MaQuanHuyen", ddl_District.SelectedValue);
            cmd.Parameters.AddWithValue("@MaPhuongXa", ddl_Ward.SelectedValue);
            cmd.Parameters.AddWithValue("@MaDanToc", ddl_Race.SelectedValue);
            cmd.Parameters.AddWithValue("@MaNgheNghiep", ddl_Job.SelectedValue);
            cmd.ExecuteNonQuery();
            conn.Close();
            lbl_Notification.Text = "Thêm bệnh nhân thành công";
        }

        protected void Edit()
        {
            string IDBN = Request.QueryString["ID"];
            txt_MSBN.Text = IDBN;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select tbl_BenhNhan.MaBenhNhan,"
            +"tbl_BenhNhan.HoTenBenhNhan,"
            +"tbl_BenhNhan.DienThoai,"
            +"tbl_BenhNhan.NgaySinh,"
            +"tbl_BenhNhan.DiaChi,"
            +"tbl_BenhNhan.NoiLamViec,"
            +"tbl_BenhNhan.MaDoiTuong,"
            +"tbl_BenhNhan.SoBHYT, "
            +"tbl_BenhNhan.NgayBD_BHYT,"
            +"tbl_BenhNhan.NgayKT_BHYT,"
            +"tbl_BenhNhan.MaDanToc,"
            +"tbl_BenhNhan.HoTenCha,"
            +"tbl_BenhNhan.HoTenMe,"
            +"tbl_BenhNhan.MaQuanHuyen,"
            +"tbl_BenhNhan.MaTinhThanh,"
            +"tbl_BenhNhan.MaPhuongXa,"
            +"tbl_BenhNhan.MaNgheNghiep,"
            + "tbl_BenhNhan.NgheNghiepCha,"
            +"tbl_BenhNhan.NgheNghiepMe, tbl_BenhNhan.MaQuocTich, tbl_BenhNhan.GioiTinh from tbl_BenhNhan,tbl_DanToc,tbl_DoiTuong,tbl_NgheNghiep where tbl_BenhNhan.MaBenhNhan=@IDBN", conn);
            cmd.Parameters.AddWithValue("@IDBN", IDBN);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txt_HoTenBN.Text = dt.Rows[0][1].ToString();
            txt_Phone.Text = dt.Rows[0][2].ToString();
            dob.Text = dt.Rows[0][3].ToString();
            txt_Address.Text = dt.Rows[0][4].ToString();
            txt_WorkPlace.Text = dt.Rows[0][5].ToString();
            if(dt.Rows[0][6].ToString()!="")
                ddl_DoiTuong.SelectedValue = dt.Rows[0][6].ToString();
            txt_MaBHYT.Text = dt.Rows[0][7].ToString();
            bd_bhyt.Text = dt.Rows[0][8].ToString();
            kt_bhyt.Text = dt.Rows[0][9].ToString();
            if(dt.Rows[0][10].ToString()!="")
                ddl_Race.SelectedValue = dt.Rows[0][10].ToString();
            txt_DadsName.Text = dt.Rows[0][11].ToString();
            txt_MomsName.Text = dt.Rows[0][12].ToString();
            if (dt.Rows[0][13].ToString() != "")
                ddl_District.SelectedValue = dt.Rows[0][13].ToString();
            if (dt.Rows[0][14].ToString() != "")
                ddl_City.SelectedValue = dt.Rows[0][14].ToString();
            if (dt.Rows[0][15].ToString() != "")
                ddl_Ward.SelectedValue = dt.Rows[0][15].ToString();
            if (dt.Rows[0][16].ToString() != "")
                ddl_Job.SelectedValue = dt.Rows[0][16].ToString();
            if (dt.Rows[0][17].ToString() != "")
                ddl_DadJob.SelectedValue = dt.Rows[0][17].ToString();
            if (dt.Rows[0][18].ToString() != "")
                ddl_MomJob.SelectedValue = dt.Rows[0][18].ToString();
            if (dt.Rows[0][19].ToString() != "")
                ddl_Nationality.SelectedValue = dt.Rows[0][19].ToString();
            if (dt.Rows[0][20].ToString() == "True")
                rd_Gender.Items.FindByText("Nam").Selected = true;
            else if (dt.Rows[0][20].ToString() == "False")
                rd_Gender.Items.FindByText("Nữ").Selected = true;
        }

        protected void btn_Sua_Click(object sender, EventArgs e)
        {
            string IDBN = Request.QueryString["ID"];
            txt_MSBN.Text = IDBN;
            string maquanhuyen = ddl_District.SelectedValue;
            string matinhthanh = ddl_City.SelectedValue;
            string maphuongxa = ddl_Ward.SelectedValue;
            string nghenghiepcha = ddl_DadJob.SelectedValue;
            string nghenghiepme = ddl_MomJob.SelectedValue;
            string maquoctich = ddl_Nationality.SelectedValue;
            string madantoc = ddl_Race.SelectedValue;
            string manghenghiep = ddl_Job.SelectedValue;
            string madoituong = ddl_DoiTuong.SelectedValue;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("update tbl_BenhNhan set HoTenBenhNhan=@HoTenBN,tbl_BenhNhan.DienThoai=@DienThoai, tbl_BenhNhan.NgaySinh=@dob,tbl_BenhNhan.DiaChi=@Address,tbl_BenhNhan.NoiLamViec=@WorkPlace, tbl_BenhNhan.MaDoiTuong=@MaDoiTuong,tbl_BenhNhan.SoBHYT=@SoBHYT, tbl_BenhNhan.NgayBD_BHYT=@bd_BHYT,tbl_BenhNhan.NgayKT_BHYT=@kt_BHYT,tbl_BenhNhan.MaDanToc=@MaDanToc,tbl_BenhNhan.HoTenCha=@HoTenCha,tbl_BenhNhan.HoTenMe=@HoTenMe,tbl_BenhNhan.MaQuanHuyen=@District,tbl_BenhNhan.MaTinhThanh=@City,tbl_BenhNhan.MaPhuongXa=@Ward,tbl_BenhNhan.MaNgheNghiep=@Job,tbl_BenhNhan.NgheNghiepCha=@DadsJob,tbl_BenhNhan.NgheNghiepMe = @MomsJob, tbl_BenhNhan.MaQuocTich=@Nationality where tbl_BenhNhan.MaBenhNhan=@MaBN", conn);
            cmd.Parameters.AddWithValue("@MaBN", IDBN);
            cmd.Parameters.AddWithValue("@HoTenBN", txt_HoTenBN.Text);
            cmd.Parameters.AddWithValue("@DienThoai", txt_Phone.Text);
            cmd.Parameters.AddWithValue("@dob", dob.Text);
            cmd.Parameters.AddWithValue("@Address", txt_Address.Text);
            cmd.Parameters.AddWithValue("@WorkPlace", txt_WorkPlace.Text);
            cmd.Parameters.AddWithValue("@MaDoiTuong", madoituong);
            cmd.Parameters.AddWithValue("@SoBHYT", txt_MaBHYT.Text);
            cmd.Parameters.AddWithValue("@bd_BHYT", bd_bhyt.Text);
            cmd.Parameters.AddWithValue("@kt_BHYT", kt_bhyt.Text);
            cmd.Parameters.AddWithValue("@MaDanToc", madantoc);
            cmd.Parameters.AddWithValue("@HoTenCha", txt_DadsName.Text);
            cmd.Parameters.AddWithValue("@HoTenMe", txt_MomsName.Text);
            cmd.Parameters.AddWithValue("@District", maquanhuyen);
            cmd.Parameters.AddWithValue("@City", matinhthanh);
            cmd.Parameters.AddWithValue("@Ward", maphuongxa);
            cmd.Parameters.AddWithValue("@Job", manghenghiep);
            cmd.Parameters.AddWithValue("@DadsJob", nghenghiepcha);
            cmd.Parameters.AddWithValue("@MomsJob", nghenghiepme);
            cmd.Parameters.AddWithValue("@Nationality", maquoctich);
            cmd.ExecuteNonQuery();
            conn.Close();
            lbl_Notification.Text = "Sửa thành công";
        }
    }
}