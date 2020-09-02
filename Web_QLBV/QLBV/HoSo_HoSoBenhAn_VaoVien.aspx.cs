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
    public partial class HoSo_HoSoBenhAn_VaoVien : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadinfo();
            }
        }

        protected void loadinfo()
        {
            //Load
            string MaBA = Request.QueryString["ID"];
            string gioitinh = "";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            //kiểm tra xem vị trí, nguồn nhập viện có null ko
            if (checkNguonNhapVien() == true)
            {
                SqlCommand cmd = new SqlCommand("select tbl_HoSoBenhAn.MaBenhNhan,tbl_BenhNhan.HoTenBenhNhan,tbl_QuocTich.TenQuocTich,tbl_BenhNhan.NgaySinh,tbl_BenhNhan.GioiTinh, tbl_DoiTuong.TenDoiTuong,tbl_BenhNhan.SoBHYT, tbl_DanToc.TenDanToc, tbl_NgheNghiep.TenNgheNghiep, tbl_BenhNhan.DiaChi, tbl_BenhNhan.DienThoai, tbl_HoSoBenhAn.NgayVaoVien,tbl_HoSoBenhAn.GioVaoVien, tbl_HoSoBenhAn.MaNguonNhapVien,tbl_HoSoBenhAn.VaoKhoa,tbl_ViTri.MaViTri,tbl_HoSoBenhAn.ChuyenVienTu,tbl_HoSoBenhAn.NoiChuyenChanDoan,tbl_HoSoBenhAn.CapCuuChanDoan,tbl_HoSoBenhAn.KhoaDieuTriChanDoan,tbl_HoSoBenhAn.NgayLamBenhAn,tbl_HoSoBenhAn.BSLamBenhAn,tbl_HoSoBenhAn.HoTenNguoiDuyet,tbl_HoSoBenhAn.LyDoVaoVien,tbl_HoSoBenhAn.QuaTrinhBenhLy,tbl_HoSoBenhAn.TienSuBenhVeBanThan, tbl_HoSoBenhAn.TienSuBenhVeGiaDinh,tbl_HoSoBenhAn.Mach,tbl_HoSoBenhAn.NhietDo, tbl_HoSoBenhAn.HuyetAp,tbl_HoSoBenhAn.NhipTho, tbl_HoSoBenhAn.CanNang, tbl_HoSoBenhAn.TienLuong, tbl_HoSoBenhAn.HuongDieuTri, tbl_HoSoBenhAn.TamThan_ThanKinh,  tbl_HoSoBenhAn.TuanHoan,tbl_HoSoBenhAn.HoHap,tbl_HoSoBenhAn.TieuHoa,tbl_HoSoBenhAn.Da_MoDuoiDa, tbl_HoSoBenhAn.Co_Xuong_Khop,tbl_HoSoBenhAn.Than_TietNieu_SinhDuc,tbl_HoSoBenhAn.Tai_Mui_Hong,  tbl_HoSoBenhAn.Rang_Ham_Mat, tbl_HoSoBenhAn.CacBenhLyKhac  from tbl_BenhNhan,tbl_HoSoBenhAn,tbl_BenhVien,tbl_NguonNhapVien,tbl_DanToc,tbl_QuocTich,tbl_DoiTuong,tbl_NgheNghiep,tbl_ViTri,tbl_Khoa,tbl_CongNhanVien            where tbl_HoSoBenhAn.MaDieuTri=@MaDieuTri and tbl_HoSoBenhAn.MaBenhNhan=tbl_BenhNhan.MaBenhNhan and tbl_BenhNhan.MaQuocTich=tbl_QuocTich.MaQuocTich and            tbl_BenhNhan.MaDoiTuong=tbl_DoiTuong.MaDoiTuong and tbl_BenhNhan.MaDanToc=tbl_DanToc.MaDanToc and            tbl_BenhNhan.MaNgheNghiep=tbl_NgheNghiep.MaNgheNghiep and tbl_HoSoBenhAn.MaNguonNhapVien=tbl_NguonNhapVien.MaNguonNhapVien and            tbl_HoSoBenhAn.VaoKhoa=tbl_Khoa.MaKhoa and tbl_HoSoBenhAn.MaViTri=tbl_ViTri.MaViTri and tbl_HoSoBenhAn.ChuyenVienTu=tbl_BenhVien.MaBenhVien", conn);
                cmd.Parameters.AddWithValue("@MaDieuTri", MaBA);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //SỐ bệnh án
                txt_SoBA.Text = MaBA;
                //Mã bệnh nhân
                txt_MaBN.Text = dt.Rows[0][0].ToString();
                //Họ tên BN
                txt_HoTen.Text = dt.Rows[0][1].ToString();
                //Quốc tịch
                txt_Nationality.Text = dt.Rows[0][2].ToString();
                //Ngày sinh
                dob.Text = dt.Rows[0][3].ToString();
                //Giới tính
                gioitinh = dt.Rows[0][4].ToString();
                if (gioitinh == "True")
                    rdl_GioiTinh.Items.FindByText("Nam").Selected = true;
                else if (gioitinh == "False")
                    rdl_GioiTinh.Items.FindByText("Nữ").Selected = true;
                //Đối tượng
                txt_Target.Text = dt.Rows[0][5].ToString();
                //Mã BHYT
                txt_MaBHYT.Text = dt.Rows[0][6].ToString();
                //Dân tộc
                txt_Race.Text = dt.Rows[0][7].ToString();
                //Nghề nghiệp
                txt_Job.Text = dt.Rows[0][8].ToString();
                //địa chỉ
                txt_Address.Text = dt.Rows[0][9].ToString();
                //điện thoại
                txt_Mobile.Text = dt.Rows[0][10].ToString();
                //Ngày vào viện
                day_checkin.Text = dt.Rows[0][11].ToString();
                //Giờ vào viện
                Hour_Checkin.Text = dt.Rows[0][12].ToString();
                //Nguồn nhập viện
                if (dt.Rows[0][13].ToString() != "")
                {
                    ddl_FromWhere.SelectedValue = dt.Rows[0][13].ToString();
                    KTBenhVienKhac(dt.Rows[0][13].ToString());
                }
                //vào khoa
                if (dt.Rows[0][14].ToString() != "")
                    ddl_Khoa.SelectedValue = dt.Rows[0][14].ToString();
                //Vị trí
                if (dt.Rows[0][15].ToString() != "")
                    ddl_Position.SelectedValue = dt.Rows[0][15].ToString();
                //Chuyển viện từ BV
                if (dt.Rows[0][16].ToString() != "")
                    ddl_FromHospital.SelectedValue=dt.Rows[0][16].ToString();
                //Nơi chuyển chẩn đoán
                if (dt.Rows[0][17].ToString() != "")
                    ddl_NoiChuyenDen.SelectedValue = dt.Rows[0][17].ToString();
                //Cấp cứu chẩn đoán
                if (dt.Rows[0][18].ToString() != "")
                    ddl_KKBCC.SelectedValue = dt.Rows[0][18].ToString();
                //Khoa điều trị chẩn đoán
                if (dt.Rows[0][19].ToString() != "")
                    ddl_KDTCD.SelectedValue = dt.Rows[0][19].ToString();
                //txt_NoiChuyenDen.Text = dt.Rows[0][18].ToString();
                //txt_KKBCC.Text = dt.Rows[0][19].ToString(); ;
                //txt_KDTCD.Text = dt.Rows[0][20].ToString();
                txt_CheckInDay.Text = dt.Rows[0][20].ToString();
                //Danh sách bác sĩ
                if (dt.Rows[0][21].ToString() != "")
                    ddl_DrList.SelectedValue = dt.Rows[0][21].ToString();
                //Người duyệt
                if (dt.Rows[0][22].ToString() != "")
                    ddl_CnfrmList.SelectedValue = dt.Rows[0][22].ToString();
                //Lý do vào viện
                txt_Reason.Text = dt.Rows[0][23].ToString();
                //Quá trình bệnh lý
                txt_QTBL.Text = dt.Rows[0][24].ToString();
                //Tiền sử bệnh bản thân
                txt_PatientBackgroud.Text = dt.Rows[0][25].ToString();
                //Tiền sử bệnh gia đình
                txt_FamilyBackground.Text = dt.Rows[0][26].ToString();
                //mạch
                txt_Pulse.Text = dt.Rows[0][27].ToString();
                //nhiệt độ
                txt_Temperature.Text = dt.Rows[0][28].ToString();
                //huyết áp
                txt_BlPressure.Text = dt.Rows[0][29].ToString();
                //nhịp thở
                txt_Breathe.Text = dt.Rows[0][30].ToString();
                //cân nặng
                txt_Weight.Text = dt.Rows[0][31].ToString();
                //tiên lượng
                txt_TienLuong.Text = dt.Rows[0][32].ToString();
                //hướng điều trị
                txt_HuongDieuTri.Text = dt.Rows[0][33].ToString();
                //thần kinh
                txt_mental.Text = dt.Rows[0][34].ToString();
                //tuần hoàn
                txt_circulatory.Text = dt.Rows[0][35].ToString();
                //hô hấp
                txt_HoHap.Text = dt.Rows[0][36].ToString();
                //tiêu hóa
                txt_TieuHoa.Text = dt.Rows[0][37].ToString();
                //da
                txt_Skin.Text = dt.Rows[0][38].ToString();
                //cơ xương khớo
                txt_Joint_Bone.Text = dt.Rows[0][39].ToString();
                //thận sinh dục
                txt_BaiTiet.Text = dt.Rows[0][40].ToString();
                //tai mũi họng
                txt_TaiMuiHong.Text = dt.Rows[0][41].ToString();
                //răng
                txt_Teeth.Text = dt.Rows[0][42].ToString();
                //bệnh lý khác
                txt_Others.Text = dt.Rows[0][43].ToString();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select tbl_HoSoBenhAn.MaBenhNhan,"
                + "tbl_BenhNhan.HoTenBenhNhan, "
                + "tbl_QuocTich.TenQuocTich,"
                + "tbl_BenhNhan.NgaySinh,"
                + "tbl_BenhNhan.GioiTinh,"
                + "tbl_DoiTuong.TenDoiTuong,"
                + "tbl_BenhNhan.SoBHYT,"
                + "tbl_DanToc.TenDanToc,"
                + "tbl_NgheNghiep.TenNgheNghiep,"
                + "tbl_BenhNhan.DiaChi,"
                + "tbl_BenhNhan.DienThoai,"
                + "tbl_HoSoBenhAn.NgayVaoVien,"
                + "tbl_HoSoBenhAn.GioVaoVien,"
                + "tbl_HoSoBenhAn.NoiChuyenChanDoan,"
                + "tbl_HoSoBenhAn.CapCuuChanDoan,"
                + "tbl_HoSoBenhAn.KhoaDieuTriChanDoan,"
                + "tbl_HoSoBenhAn.NgayLamBenhAn, "
                + "tbl_HoSoBenhAn.BSLamBenhAn,"
                + "tbl_HoSoBenhAn.HoTenNguoiDuyet,"
                + "tbl_HoSoBenhAn.LyDoVaoVien,"
                + "tbl_HoSoBenhAn.QuaTrinhBenhLy,"
                + "tbl_HoSoBenhAn.TienSuBenhVeBanThan,"
                + "tbl_HoSoBenhAn.TienSuBenhVeGiaDinh,"
                + "tbl_HoSoBenhAn.Mach,"
                + "tbl_HoSoBenhAn.NhietDo,"
                + "tbl_HoSoBenhAn.HuyetAp,"
                + "tbl_HoSoBenhAn.NhipTho, "
                + "tbl_HoSoBenhAn.CanNang,"
                + "tbl_HoSoBenhAn.TienLuong,"
                + "tbl_HoSoBenhAn.HuongDieuTri,"
                + "tbl_HoSoBenhAn.TamThan_ThanKinh,"
                + "tbl_HoSoBenhAn.TuanHoan,"
                + "tbl_HoSoBenhAn.HoHap,"
                + "tbl_HoSoBenhAn.TieuHoa,"
                + "tbl_HoSoBenhAn.Da_MoDuoiDa,  "
                + "tbl_HoSoBenhAn.Co_Xuong_Khop,"
                + "tbl_HoSoBenhAn.Than_TietNieu_SinhDuc,"
                + "tbl_HoSoBenhAn.Tai_Mui_Hong,"
                + "tbl_HoSoBenhAn.Rang_Ham_Mat,"
                + "tbl_HoSoBenhAn.CacBenhLyKhac from tbl_BenhNhan,tbl_HoSoBenhAn,tbl_BenhVien,tbl_NguonNhapVien,tbl_DanToc,tbl_QuocTich,tbl_DoiTuong,tbl_NgheNghiep,tbl_ViTri,tbl_Khoa,tbl_CongNhanVien where tbl_HoSoBenhAn.MaDieuTri=@MaDieuTri and tbl_HoSoBenhAn.MaBenhNhan=tbl_BenhNhan.MaBenhNhan and tbl_BenhNhan.MaQuocTich=tbl_QuocTich.MaQuocTich and tbl_BenhNhan.MaDoiTuong=tbl_DoiTuong.MaDoiTuong and tbl_BenhNhan.MaDanToc=tbl_DanToc.MaDanToc and tbl_BenhNhan.MaNgheNghiep=tbl_NgheNghiep.MaNgheNghiep ", conn);
                cmd.Parameters.AddWithValue("@MaDieuTri", MaBA);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //Mã bệnh án
                txt_SoBA.Text = MaBA;
                //Mã bệnh nhân
                txt_MaBN.Text = dt.Rows[0][0].ToString();
                //Họ tên
                txt_HoTen.Text = dt.Rows[0][1].ToString();
                //Quốc tịch
                txt_Nationality.Text = dt.Rows[0][2].ToString();
                //Ngày sinh
                dob.Text = dt.Rows[0][3].ToString();
                //Giới tính, kiểm tra boolen true hay false
                gioitinh = dt.Rows[0][4].ToString();
                if (gioitinh == "True")
                    rdl_GioiTinh.Items.FindByText("Nam").Selected = true;
                else if (gioitinh == "False")
                    rdl_GioiTinh.Items.FindByText("Nữ").Selected = true;
                //đối tượng
                txt_Target.Text = dt.Rows[0][5].ToString();
                //mã bhyt
                txt_MaBHYT.Text = dt.Rows[0][6].ToString();
                //dân tộc
                txt_Race.Text = dt.Rows[0][7].ToString();
                //nghề nghiệp
                txt_Job.Text = dt.Rows[0][8].ToString();
                //địa chỉ
                txt_Address.Text = dt.Rows[0][9].ToString();
                //địa thoại
                txt_Mobile.Text = dt.Rows[0][10].ToString();
                //Ngày vào viện
                day_checkin.Text = dt.Rows[0][11].ToString();
                //giờ vào viện
                Hour_Checkin.Text = dt.Rows[0][12].ToString();
                //Nơi chuyển chẩn đoán
                if (dt.Rows[0][13].ToString() != "")
                    ddl_NoiChuyenDen.SelectedValue = dt.Rows[0][13].ToString();
                //Cấp cứu chẩn đoán
                if (dt.Rows[0][14].ToString() != "")
                    ddl_KKBCC.SelectedValue = dt.Rows[0][14].ToString();
                //Khoa điều trị chẩn đoán
                if (dt.Rows[0][15].ToString() != "")
                    ddl_KDTCD.SelectedValue = dt.Rows[0][15].ToString();
                //Ngày làm bệnh án
                txt_CheckInDay.Text = dt.Rows[0][16].ToString();
                //Danh sách bác sĩ
                if (dt.Rows[0][17].ToString() != "")
                    ddl_DrList.SelectedValue = dt.Rows[0][17].ToString();
                //Người duyệt
                if (dt.Rows[0][18].ToString() != "")
                    ddl_CnfrmList.SelectedValue = dt.Rows[0][18].ToString();
                //Lý do vào viện
                txt_Reason.Text = dt.Rows[0][19].ToString();
                //Quá trình bệnh lý
                txt_QTBL.Text = dt.Rows[0][19].ToString();
                //Tiền sử bệnh bản thân
                txt_PatientBackgroud.Text = dt.Rows[0][20].ToString();
                //Tiền sử bệnh gia đình
                txt_FamilyBackground.Text = dt.Rows[0][21].ToString();
                //Mạch
                txt_Pulse.Text = dt.Rows[0][22].ToString();
                //Nhiệt độ
                txt_Temperature.Text = dt.Rows[0][23].ToString();
                //Huyết áp
                txt_BlPressure.Text = dt.Rows[0][24].ToString();
                //Nhịp thở
                txt_Breathe.Text = dt.Rows[0][25].ToString();
                //Cân nặng
                txt_Weight.Text = dt.Rows[0][26].ToString();
                //Tiên lượng
                txt_TienLuong.Text = dt.Rows[0][27].ToString();
                //Hướng điều trị
                txt_HuongDieuTri.Text = dt.Rows[0][28].ToString();
                //Thần kinh
                txt_mental.Text = dt.Rows[0][29].ToString();
                //Tuần hoàn
                txt_circulatory.Text = dt.Rows[0][30].ToString();
                //Hô hấp
                txt_HoHap.Text = dt.Rows[0][31].ToString();
                //Tiêu hóa
                txt_TieuHoa.Text = dt.Rows[0][32].ToString();
                //Da
                txt_Skin.Text = dt.Rows[0][33].ToString();
                //Cơ xương khớp
                txt_Joint_Bone.Text = dt.Rows[0][34].ToString();
                //Bài tiết
                txt_BaiTiet.Text = dt.Rows[0][35].ToString();
                //Tai mũi họng
                txt_TaiMuiHong.Text = dt.Rows[0][36].ToString();
                //Răng hàm mặt
                txt_Teeth.Text = dt.Rows[0][37].ToString();
                //Các bệnh lý khác
                txt_Others.Text = dt.Rows[0][38].ToString();
            }
            
        }

        // hàm kiểm tra xem vị trí, nguồn nhập viện có null ko
        protected bool checkNguonNhapVien()
        {
            string MaBA = Request.QueryString["ID"];
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select tbl_HoSoBenhAn.MaNguonNhapVien, tbl_HoSoBenhAn.VaoKhoa, tbl_HoSoBenhAn.MaViTri, tbl_HoSoBenhAn.ChuyenVienTu from tbl_HoSoBenhAn where tbl_HoSoBenhAn.MaDieuTri=@MaDieuTri", conn);
            cmd.Parameters.AddWithValue("@MaDieuTri", MaBA);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][1].ToString() != "" && dt.Rows[0][2].ToString() != "" && dt.Rows[0][3].ToString() != "")
                return true;
            else
                return false;
        }

        //kiểm tra xem có bệnh kèm
        protected void cb_BenhKem_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_BenhKem.Checked == true)
                ddl_BenhKem.Enabled = true;
            else
                ddl_BenhKem.Enabled = false;
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string MaDieuTri = Request.QueryString["ID"];
            string cmd1 = "";
            if (ddl_FromWhere.SelectedItem.ToString() == "Bệnh viện khác")
                cmd1 += ", tbl_HoSoBenhAn.ChuyenVienTu=@ChuyenVienTu";
            if (cb_NoiChuyenDen.Checked == true)
                cmd1 += ",tbl_HoSoBenhAn.NoiChuyenChanDoan=@NoiChuyenChanDoan";
            if (cb_CapCuu.Checked == true)
                cmd1 += ",tbl_HoSoBenhAn.CapCuuChanDoan=@CapCuuChanDoan";
            if (cb_KDT.Checked == true)
                cmd1 += ", tbl_HoSoBenhAn.KhoaDieuTriChanDoan=@KhoaDieuTriChanDoan";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("update tbl_HoSoBenhAn set tbl_HoSoBenhAn.MaNguonNhapVien=@MaNguonNhapVien,tbl_HoSoBenhAn.VaoKhoa=@VaoKhoa,tbl_HoSoBenhAn.MaViTri=@MaViTri,tbl_HoSoBenhAn.NgayLamBenhAn=@NgayLamBenhAn,tbl_HoSoBenhAn.BSLamBenhAn=@BSLamBenhAn,tbl_HoSoBenhAn.HoTenNguoiDuyet=@HoTenNguoiDuyet,tbl_HoSoBenhAn.LyDoVaoVien=@LyDoVaoVien,tbl_HoSoBenhAn.QuaTrinhBenhLy=@QTBenhLy,tbl_HoSoBenhAn.TienSuBenhVeBanThan=@TSBenhBanThan,tbl_HoSoBenhAn.TienSuBenhVeGiaDinh=@TSBenhGiaDinh,tbl_HoSoBenhAn.Mach=@Mach,tbl_HoSoBenhAn.NhipTho=@NhipTho,tbl_HoSoBenhAn.NhietDo=@NhietDo,tbl_HoSoBenhAn.CanNang=@CanNang,tbl_HoSoBenhAn.HuyetAp=@HuyetAp,tbl_HoSoBenhAn.TamThan_ThanKinh=@ThanKinh,tbl_HoSoBenhAn.TuanHoan=@TuanHoan,tbl_HoSoBenhAn.HoHap=@HoHap,tbl_HoSoBenhAn.TieuHoa=@TieuHoa,tbl_HoSoBenhAn.Da_MoDuoiDa=@Da,tbl_HoSoBenhAn.Co_Xuong_Khop=@Xuong,tbl_HoSoBenhAn.Than_TietNieu_SinhDuc=@TietNieu,tbl_HoSoBenhAn.Tai_Mui_Hong=@TaiMuiHong,tbl_HoSoBenhAn.Rang_Ham_Mat=@RangHamMat,tbl_HoSoBenhAn.CacBenhLyKhac=@BenhLyKhac,tbl_HoSoBenhAn.TienLuong=@TienLuong,tbl_HoSoBenhAn.HuongDieuTri=@HuongDieuTri,tbl_HoSoBenhAn.BenhChinh=@BenhChinh,tbl_HoSoBenhAn.BenhKemTheo=@BenhKem where tbl_HoSoBenhAn.MaDieuTri=@MaDieuTri", conn);
            cmd.Parameters.AddWithValue("@MaDieuTri",MaDieuTri);
            cmd.Parameters.AddWithValue("@MaNguonNhapVien", ddl_FromWhere.SelectedValue);
            cmd.Parameters.AddWithValue("@VaoKhoa", ddl_Khoa.SelectedValue);
            cmd.Parameters.AddWithValue("@MaViTri", ddl_Position.SelectedValue);
            if (ddl_FromWhere.SelectedItem.ToString()=="Bệnh viện khác")
                cmd.Parameters.AddWithValue("@ChuyenVienTu", ddl_FromHospital.SelectedValue);
            if (cb_NoiChuyenDen.Checked == true)
                cmd.Parameters.AddWithValue("@NoiChuyenChanDoan", ddl_NoiChuyenDen.SelectedValue);
            if (cb_CapCuu.Checked==true)
                cmd.Parameters.AddWithValue("@CapCuuChanDoan", ddl_KKBCC.SelectedValue);
            if(cb_KDT.Checked==true)
                cmd.Parameters.AddWithValue("@KhoaDieuTriChanDoan", ddl_KDTCD.SelectedValue);
            cmd.Parameters.AddWithValue("@NgayLamBenhAn", txt_CheckInDay.Text);
            cmd.Parameters.AddWithValue("@BSLamBenhAn", ddl_DrList.SelectedValue);
            cmd.Parameters.AddWithValue("@HoTenNguoiDuyet", ddl_CnfrmList.SelectedValue);
            cmd.Parameters.AddWithValue("@LyDoVaoVien", txt_Reason.Text);
            cmd.Parameters.AddWithValue("@QTBenhLy", txt_QTBL.Text);
            cmd.Parameters.AddWithValue("@TSBenhBanThan", txt_PatientBackgroud.Text);
            cmd.Parameters.AddWithValue("@TSBenhGiaDinh", txt_FamilyBackground.Text);
            cmd.Parameters.AddWithValue("@Mach", txt_Pulse.Text);
            cmd.Parameters.AddWithValue("@NhipTho", txt_Breathe.Text);
            cmd.Parameters.AddWithValue("@NhietDo", txt_Temperature.Text);
            cmd.Parameters.AddWithValue("@CanNang", txt_Weight.Text);
            cmd.Parameters.AddWithValue("@HuyetAp", txt_BlPressure.Text);
            cmd.Parameters.AddWithValue("@ThanKinh", txt_mental.Text);
            cmd.Parameters.AddWithValue("@TuanHoan", txt_circulatory.Text);
            cmd.Parameters.AddWithValue("@HoHap", txt_HoHap.Text);
            cmd.Parameters.AddWithValue("@TieuHoa",txt_TieuHoa.Text );
            cmd.Parameters.AddWithValue("@Da",txt_Skin.Text );
            cmd.Parameters.AddWithValue("@Xuong", txt_Joint_Bone.Text);
            cmd.Parameters.AddWithValue("@TietNieu", txt_BaiTiet.Text );
            cmd.Parameters.AddWithValue("@TaiMuiHong", txt_TaiMuiHong.Text);
            cmd.Parameters.AddWithValue("@RangHamMat", txt_Teeth.Text);
            cmd.Parameters.AddWithValue("@BenhLyKhac", txt_Others.Text);
            cmd.Parameters.AddWithValue("@TienLuong",txt_TienLuong.Text);
            cmd.Parameters.AddWithValue("@HuongDieuTri",txt_HuongDieuTri.Text);
            cmd.Parameters.AddWithValue("@BenhChinh",ddl_BenhChinh.SelectedValue);
            if (cb_BenhKem.Checked==true)
                cmd.Parameters.AddWithValue("@BenhKem",ddl_BenhKem.SelectedValue);
            else
                cmd.Parameters.AddWithValue("@BenhKem",ddl_BenhKem.SelectedValue);
            cmd.ExecuteNonQuery();
            conn.Close();
            lbl_Notification.Text = "Sửa hồ sơ bệnh án thành công";
        }


        //button cancel
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HoSo_HoSoBenhAn_HoSo.aspx");
        }

        //từ bệnh viện khác -> chọn bệnh viện
        protected void KTBenhVienKhac(string nguon)
        {
            if (nguon == "3         ")
                ddl_FromHospital.Enabled = true;
            else
                ddl_FromHospital.Enabled = false;
        }
        
        //thay đổi nguồn nhập viện
        protected void ddl_FromWhere_SelectedIndexChanged(object sender, EventArgs e)
        {
            KTBenhVienKhac(ddl_FromWhere.SelectedValue);
        }

        //check noichuyenden có chẩn đoán
        protected void cb_NoiChuyenDen_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_NoiChuyenDen.Checked == true)
                ddl_NoiChuyenDen.Enabled = true;
            else
                ddl_NoiChuyenDen.Enabled = false;
        }
        
        //check capcuu có chẩn đoán
        protected void cb_CapCuu_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_CapCuu.Checked == true)
                ddl_KKBCC.Enabled = true;
            else
                ddl_KKBCC.Enabled = false;
        }

        //check khoadt có chẩn đoán
        protected void cb_KDT_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_KDT.Checked == true)
                ddl_KDTCD.Enabled = true;
            else
                ddl_KDTCD.Enabled = false;
        }
    }
}