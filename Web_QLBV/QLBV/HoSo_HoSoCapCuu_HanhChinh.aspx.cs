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
    public partial class HoSo_HoSoCapCuu_HanhChinh : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBN();
            }

        }

        private void loadBN()
        {
            if (Session["dschitiet"] == null)
            {
                string MaBN = Request.QueryString["ID"];
                txt_MaBN.Text = MaBN;
                string gioitinh = "";
                string MaBA = createAutoCode();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("select tbl_BenhNhan.DiaChi,tbl_BenhNhan.NgaySinh,tbl_BenhNhan.NoiLamViec,tbl_BenhNhan.DienThoai,tbl_BenhNhan.HoTenBenhNhan, tbl_BenhNhan.GioiTinh from tbl_BenhNhan where tbl_BenhNhan.MaBenhNhan=@MaBN", conn);
                cmd.Parameters.AddWithValue("@MaBN", MaBN);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txt_Address.Text = dt.Rows[0][0].ToString();
                dob.Text = dt.Rows[0][1].ToString();
                txt_WorkAddress.Text = dt.Rows[0][2].ToString();
                txt_mobile.Text = dt.Rows[0][3].ToString();
                txt_HoTen.Text = dt.Rows[0][4].ToString();
                txt_SoBA.Text = MaBA;
                gioitinh = dt.Rows[0][5].ToString();
                if (gioitinh == "True")
                    rdl_GioiTinh.Items.FindByText("Nam").Selected = true;
                else if (gioitinh == "False")
                    rdl_GioiTinh.Items.FindByText("Nữ").Selected = true;
            }
            else
            {
                string gioitinh = "";
                string MaDieuTri = Session["dschitiet"].ToString();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("select tbl_HoSoBenhAn.MaDieuTri,"
                +"tbl_BenhNhan.GioiTinh,"
                +"tbl_BenhNhan.DiaChi,"
                +"tbl_BenhNhan.MaBenhNhan,"
                +"tbl_BenhNhan.NgaySinh,"
                +"tbl_BenhNhan.NoiLamViec,"
                +"tbl_BenhNhan.DienThoai,"
                +"tbl_BenhNhan.HoTenBenhNhan,"
                +"tbl_HoSoBenhAn.NgayVaoVien,"
                +"tbl_HoSoBenhAn.GioVaoVien,"
                +"tbl_HoSoBenhAn.MaNguonNhapVien,"
                +"tbl_HoSoBenhAn.ChuyenVienTu,"
                +"tbl_HoSoBenhAn.BacSiKham,"
                +"tbl_HoSoBenhAn.LyDoVaoVien,"
                +"tbl_HoSoBenhAn.QuaTrinhBenhLy,"
                +"tbl_HoSoBenhAn.TienSuBenhVeBanThan,"
                +"tbl_HoSoBenhAn.TienSuBenhVeGiaDinh,"
                +"tbl_HoSoBenhAn.Mach,"
                +"tbl_HoSoBenhAn.NhietDo,"
                +"tbl_HoSoBenhAn.HuyetAp,"
                +"tbl_HoSoBenhAn.NhipTho,"
                +"tbl_HoSoBenhAn.CanNang,"
                +"tbl_HoSoBenhAn.CacBoPhan,"
                +"tbl_HoSoBenhAn.ChanDoan,"
                +"tbl_HoSoBenhAn.BenhChinh,"
                +"tbl_HoSoBenhAn.BenhKemTheo,"
                +"tbl_HoSoBenhAn.XuTri,"
                +"tbl_HoSoBenhAn.VaoKhoa from tbl_BenhNhan,tbl_HoSoBenhAn,tbl_BenhVien,tbl_NguonNhapVien where tbl_HoSoBenhAn.MaDieuTri=@MaDieuTri", conn);
                cmd.Parameters.AddWithValue("@MaDieuTri", MaDieuTri);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //MaDieuTri
                txt_SoBA.Text = dt.Rows[0][0].ToString();

                //Gioi Tinh
                gioitinh = dt.Rows[0][1].ToString();
                if (gioitinh == "True")
                    rdl_GioiTinh.Items.FindByText("Nam").Selected = true;
                else if (gioitinh == "False")
                    rdl_GioiTinh.Items.FindByText("Nữ").Selected = true;

                //DiaChi
                txt_Address.Text = dt.Rows[0][2].ToString();

                //MaBenhNhan
                txt_MaBN.Text = dt.Rows[0][3].ToString();

                //NgaySinh
                dob.Text = dt.Rows[0][4].ToString();

                //NoiLamViec
                txt_WorkAddress.Text = dt.Rows[0][5].ToString();

                //DienThoai
                txt_mobile.Text = dt.Rows[0][6].ToString();

                //HoTenBenhNhan
                txt_HoTen.Text = dt.Rows[0][7].ToString();

                //NgayVaoVien
                day_checkin.Text = dt.Rows[0][8].ToString();

                Hour_Checkin.Text = dt.Rows[0][9].ToString();
                //lay nguon nhap vien tu DB
                if (dt.Rows[0][10].ToString() != "")
                    ddl_NguonNhapVien.SelectedValue = dt.Rows[0][10].ToString();

                //check co chuyen tu benh vien khac qua khong (mabenhvien)
                if (dt.Rows[0][11].ToString() != "")
                    ddl_From.SelectedValue = dt.Rows[0][11].ToString();
               
                //Bac Si Kham
                if (dt.Rows[0][12].ToString() != "")
                    ddl_DrList.SelectedValue = dt.Rows[0][12].ToString();

                //Ly do vao vien
                txt_Reason.Text = dt.Rows[0][13].ToString();

                //Qua trinh benh ly
                txt_QTBenhLy.Text = dt.Rows[0][14].ToString();
                txt_PatientBackGround.Text = dt.Rows[0][15].ToString();
                txt_FamilyBackGround.Text = dt.Rows[0][16].ToString();
                txt_Pulse.Text = dt.Rows[0][17].ToString();
                txt_Tempurature.Text = dt.Rows[0][18].ToString();
                txt_BlPressure.Text = dt.Rows[0][19].ToString();
                txt_Breath.Text = dt.Rows[0][20].ToString();
                txt_Weight.Text = dt.Rows[0][21].ToString();
                txt_CacBoPhan.Text = dt.Rows[0][22].ToString();
                txt_ChuanDoan.Text = dt.Rows[0][23].ToString();
                //Loai Benh Chinh null
                if (dt.Rows[0][24].ToString() != "")
                {
                    ddl_LoaiBenh.SelectedValue=dt.Rows[0][24].ToString();
                    ddl_BenhKem.SelectedValue=dt.Rows[0][25].ToString();
                }
                else if (dt.Rows[0][24].ToString() == "")
                {
                    ddl_LoaiBenh.SelectedValue = "A00.0     ";
                    ddl_BenhKem.SelectedValue = "A00.0     ";
                }
                if(dt.Rows[0][26].ToString() != "")
                    ddl_XuTri.SelectedValue = dt.Rows[0][26].ToString();
                if (dt.Rows[0][27].ToString() != "")
                    ddl_Khoa.SelectedValue = dt.Rows[0][27].ToString();
                
            }
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string cmd = "insert into tbl_HoSoBenhAn (MaDieuTri,MaBenhNhan,MaNguonNhapVien,MaBenhVien,BacSiKham,TenBacSiKham,NgayVaoVien,GioVaoVien,LyDoVaoVien,QuaTrinhBenhLy,TienSuBenhVeBanThan,TienSuBenhVeGiaDinh,Mach,NhietDo,HuyetAp,NhipTho,CanNang,ChanDoan,XuTri,CacBoPhan";
            string cmd_end = "values(@MaBA, @MaBN, @MaNguonNhapVien, @MaBenhVien, @BacSiKham,@TenBacSiKham,@NgayVaoVien,@GioVaoVien,@LyDoVaoVien,@QuaTrinhBenhLy,@TienSuBenhVeBanThan,@TienSuBenhVeGiaDinh,@Mach,@NhietDo,@HuyetAp,@Tho,@CanNang,@ChanDoan,@XuTri,@CacBoPhan";
            if (ddl_XuTri.SelectedItem.ToString() == "Nhập viện")
            {
                cmd += ",VaoKhoa";
                cmd_end += ",@VaoKhoa";
            }
            if (ddl_From.SelectedItem.ToString() == "Khoa khám bệnh" || ddl_From.SelectedItem.ToString() == "Khác")
            {
                cmd += ",BenhChinh,BenhKemTheo,KhoaDieuTriChanDoan";
                cmd_end += ",@BenhChinh,@BenhKemTheo,@KhoaDieuTriChanDoan";
            }
            if (ddl_From.SelectedItem.ToString() == "Cấp cứu")
            {
                cmd += ",CapCuuChanDoan";
                cmd += ",@CapCuuChanDoan";
            }
            if (ddl_From.SelectedItem.ToString() == "Bệnh viện khác")
            {
                cmd += ",NoiChuyenChanDoan";
                cmd_end += ",@NoiChuynChanDoan";
            }            
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("select tbl_HoSoBenhAn.VaoKhoa", conn);
            SqlCommand cmd2 = new SqlCommand(cmd + ")" + cmd_end + ")", conn);
            cmd2.Parameters.AddWithValue("@MaBA", txt_SoBA.Text);
            cmd2.Parameters.AddWithValue("@MaBN", txt_MaBN.Text);
            cmd2.Parameters.AddWithValue("@MaNguonNhapVien", ddl_NguonNhapVien.SelectedValue);
            cmd2.Parameters.AddWithValue("@MaBenhVien",ddl_From.SelectedValue);
            cmd2.Parameters.AddWithValue("@BacSiKham", ddl_DrList.SelectedValue);
            cmd2.Parameters.AddWithValue("@TenBacSiKham", ddl_DrList.SelectedItem.ToString());
            cmd2.Parameters.AddWithValue("@NgayVaoVien", day_checkin.Text);
            cmd2.Parameters.AddWithValue("@GioVaoVien", Hour_Checkin.Text);
            cmd2.Parameters.AddWithValue("@LyDoVaoVien", txt_Reason.Text);
            cmd2.Parameters.AddWithValue("@QuaTrinhBenhLy", txt_QTBenhLy.Text);
            cmd2.Parameters.AddWithValue("@TienSuBenhVeBanThan", txt_PatientBackGround.Text);
            cmd2.Parameters.AddWithValue("@TienSuBenhVeGiaDinh", txt_FamilyBackGround.Text);
            cmd2.Parameters.AddWithValue("@Mach", txt_Pulse.Text);
            cmd2.Parameters.AddWithValue("@NhietDo", txt_Tempurature.Text);
            cmd2.Parameters.AddWithValue("@HuyetAp", txt_BlPressure.Text);
            cmd2.Parameters.AddWithValue("@Tho", txt_Breath.Text);
            cmd2.Parameters.AddWithValue("@CanNang", txt_Weight.Text);
            cmd2.Parameters.AddWithValue("@ChanDoan", txt_ChuanDoan.Text);
            if (ddl_XuTri.SelectedItem.ToString() == "Nhập viện")
                cmd2.Parameters.AddWithValue("@VaoKhoa", ddl_Khoa.SelectedValue);            
            if (ddl_From.SelectedItem.ToString() == "Khoa khám bệnh" || ddl_From.SelectedItem.ToString() == "Khác")
            {
                cmd2.Parameters.AddWithValue("@BenhChinh", ddl_LoaiBenh.SelectedValue);
                cmd2.Parameters.AddWithValue("@BenhKemTheo", ddl_BenhKem.SelectedValue);
                cmd2.Parameters.AddWithValue("@KhoaDieuTriChanDoan", ddl_LoaiBenh.SelectedValue);
            }
            if (ddl_From.SelectedItem.ToString() == "Cấp cứu")
            {
                cmd2.Parameters.AddWithValue("@CapCuuChanDoan", ddl_LoaiBenh.SelectedValue);
                cmd2.Parameters.AddWithValue("@TenBenhCapCuuChanDoan", ddl_LoaiBenh.SelectedItem.ToString());
            }
            if (ddl_From.SelectedItem.ToString() == "Bệnh viện khác")
            {
                cmd2.Parameters.AddWithValue("@NoiChuyenChanDoan", ddl_LoaiBenh.SelectedValue);
                cmd2.Parameters.AddWithValue("@TenBenhNoiChuyenChanDoan", ddl_LoaiBenh.SelectedItem.ToString());
            }
            cmd2.Parameters.AddWithValue("@XuTri", ddl_XuTri.SelectedItem.ToString());
            cmd2.Parameters.AddWithValue("@CacBoPhan", txt_CacBoPhan.Text);
            cmd2.ExecuteNonQuery();
            conn.Close();
            lbl_Notification.Text = "Thêm hồ sơ cấp cứu thành công";
        }


        public string createAutoCode()
        {
            string _year;
            int so;

            _year = DateTime.Now.Year.ToString().Substring(2);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_HoSoBenhAn", conn);
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);
            int i = (dt.Rows.Count);
            if (i == 0) so = 1;
            else
                so = Int32.Parse(dt.Rows[i - 1][0].ToString().Substring(10)) + 1;

            if (so < 10)
            {
                return "HSBA" + _year + "/0000" + so.ToString();
            }
            else
                return "HSBA" + _year + "/000" + so.ToString();
        }


        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            string cmd = "update tbl_HoSoBenhAn set MaBenhNhan=@MaBenhNhan,MaNguonNhapVien=@MaNguonNhapVien,MaBenhVien=@MaBenhVien,BacSiKham=@BacSiKham,NgayVaoVien=@NgayVaoVien,GioVaoVien=@GioVaoVien,LyDoVaoVien=@LyDoVaoVien,QuaTrinhBenhLy=@QuaTrinhBenhLy,TienSuBenhVeBanThan=@TienSuBenhVeBanThan,TienSuBenhVeGiaDinh=@TienSuBenhVeGiaDinh,Mach=@Mach,NhietDo=@NhietDo,HuyetAp=@HuyetAp,NhipTho=@NhipTho,CanNang=@CanNang,ChanDoan=@ChanDoan,XuTri=@XuTri,CacBoPhan=@CacBoPhan";
            string cmd_end = " where MaDieuTri=@MaDieuTri";
            string MaDieuTri = Request.QueryString["ID"];
            if (ddl_XuTri.SelectedItem.ToString() == "Nhập viện")
            {
                cmd += ",VaoKhoa=@VaoKhoa";
            }
            if (ddl_From.SelectedItem.ToString() == "Khoa khám bệnh" || ddl_From.SelectedItem.ToString() == "Khác")
            {
                cmd += ",BenhChinh=@BenhChinh,BenhKemTheo=@BenhKemTheo,KhoaDieuTriChanDoan=@KhoaDieuTriChanDoan";
            }
            if (ddl_From.SelectedItem.ToString() == "Cấp cứu")
            {
                cmd += ",CapCuuChanDoan=@CapCuuChanDoan";
            }
            if (ddl_From.SelectedItem.ToString() == "Bệnh viện khác")
            {
                cmd += ",NoiChuyenChanDoan=@NoiChuyenChanDoan";
            }
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(cmd + cmd_end, conn);
            cmd1.Parameters.AddWithValue("@MaDieuTri", MaDieuTri);
            cmd1.Parameters.AddWithValue("@MaBenhNhan", txt_MaBN.Text);
            cmd1.Parameters.AddWithValue("@MaNguonNhapVien", ddl_NguonNhapVien.SelectedValue);
            cmd1.Parameters.AddWithValue("@MaBenhVien", ddl_From.SelectedValue);
            cmd1.Parameters.AddWithValue("@BacSiKham", ddl_DrList.SelectedValue);
            cmd1.Parameters.AddWithValue("@TenBacSiKham", ddl_DrList.SelectedItem.ToString());
            cmd1.Parameters.AddWithValue("@NgayVaoVien", day_checkin.Text);
            cmd1.Parameters.AddWithValue("@GioVaoVien", Hour_Checkin.Text);
            cmd1.Parameters.AddWithValue("@LyDoVaoVien", txt_Reason.Text);
            cmd1.Parameters.AddWithValue("@QuaTrinhBenhLy", txt_QTBenhLy.Text);
            cmd1.Parameters.AddWithValue("@TienSuBenhVeBanThan", txt_PatientBackGround.Text);
            cmd1.Parameters.AddWithValue("@TienSuBenhVeGiaDinh", txt_FamilyBackGround.Text);
            cmd1.Parameters.AddWithValue("@Mach", txt_Pulse.Text);
            cmd1.Parameters.AddWithValue("@NhietDo", txt_Tempurature.Text);
            cmd1.Parameters.AddWithValue("@HuyetAp", txt_BlPressure.Text);
            cmd1.Parameters.AddWithValue("@NhipTho", txt_Breath.Text);
            cmd1.Parameters.AddWithValue("@CanNang", txt_Weight.Text);
            cmd1.Parameters.AddWithValue("@ChanDoan", txt_ChuanDoan.Text);
            if (ddl_XuTri.SelectedItem.ToString() == "Nhập viện")
                cmd1.Parameters.AddWithValue("@VaoKhoa", ddl_Khoa.SelectedValue);
            if (ddl_From.SelectedItem.ToString() == "Khoa khám bệnh" || ddl_From.SelectedItem.ToString() == "Khác")
            {
                cmd1.Parameters.AddWithValue("@BenhChinh", ddl_LoaiBenh.SelectedValue);
                cmd1.Parameters.AddWithValue("@BenhKemTheo", ddl_BenhKem.SelectedValue);
                cmd1.Parameters.AddWithValue("@KhoaDieuTriChanDoan", ddl_LoaiBenh.SelectedValue);
            }
            if (ddl_From.SelectedItem.ToString() == "Cấp cứu")
            {
                cmd1.Parameters.AddWithValue("@CapCuuChanDoan", ddl_LoaiBenh.SelectedValue);
                cmd1.Parameters.AddWithValue("@TenBenhCapCuuChanDoan", ddl_LoaiBenh.SelectedItem.ToString());
            }
            if (ddl_From.SelectedItem.ToString() == "Bệnh viện khác")
            {
                cmd1.Parameters.AddWithValue("@NoiChuyenChanDoan", ddl_LoaiBenh.SelectedValue);
                cmd1.Parameters.AddWithValue("@TenBenhNoiChuyenChanDoan", ddl_LoaiBenh.SelectedItem.ToString());
            }
            cmd1.Parameters.AddWithValue("@XuTri", ddl_XuTri.SelectedItem.ToString());
            cmd1.Parameters.AddWithValue("@CacBoPhan", txt_CacBoPhan.Text);
            cmd1.ExecuteNonQuery();
            conn.Close();
            lbl_Notification.Text = "Sửa hồ sơ bệnh án thành công";
        }

        protected void ddl_NguonNhapVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_NguonNhapVien.SelectedItem.ToString() == "Bệnh viện khác")
                ddl_From.Enabled = true;
            else
                ddl_From.Enabled = false;
        }
    }
}