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
    public partial class Search_HoSoBenhAn : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB_WebBenhVienConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_TimKiem_Click(object sender, EventArgs e)
        {
            search();
        }

        private string getData()
        {
            string a = "";
            string num = tb_SoBenhAn.Text;
            string id = tb_MaBenhNhan.Text;
            string name = tb_TenBenhNhan.Text;
            if (num != "")
                a += " and tbl_HoSoBenhAn.MaDieuTri = '" + num + "' ";
            if (id != "")
                a += " and tbl_HoSoBenhAn.MaBenhNhan='" + id + "' ";
            if (id != "")
                a += " and tbl_BenhNhan.HoTenBenhNhan like N'%" + name + "%' ";

            return a;
        }

        private void search()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT tbl_HoSoBenhAn.MaDieuTri ,tbl_HoSoBenhAn.MaBenhNhan , tbl_BenhNhan.HoTenBenhNhan,tbl_HoSoBenhAn.MaViTri , tbl_NguonNhapVien.TenNguonNhapVien , tbl_BenhVien.TenBenhVien ,tbl_HinhThucRaVien.TenHinhThucRaVien , tbl_TinhHinhTuVong.TinhHinhTuVong ,tbl_HoSoBenhAn.TamThan_ThanKinh , tbl_HoSoBenhAn.TuanHoan , tbl_HoSoBenhAn.HoHap, tbl_HoSoBenhAn.TieuHoa,tbl_HoSoBenhAn.Da_MoDuoiDa, tbl_HoSoBenhAn.Co_Xuong_Khop,tbl_HoSoBenhAn.Than_TietNieu_SinhDuc,tbl_HoSoBenhAn.Tai_Mui_Hong,tbl_HoSoBenhAn.Rang_Ham_Mat, tbl_HoSoBenhAn.CacBenhLyKhac,tbl_HoSoBenhAn.CacXetNghiemLamSanCanLam, tbl_HoSoBenhAn.ConThu, tbl_HoSoBenhAn.TinhTrangKhiSinh,tbl_HoSoBenhAn.CanNangLucSinh, tbl_HoSoBenhAn.DiTatBamSinh, tbl_HoSoBenhAn.CuTheTatBamSinh,tbl_HoSoBenhAn.PhatTrienVanDong, tbl_HoSoBenhAn.PhatTrienTinhThan, tbl_HoSoBenhAn.CacBenhKhacTruocDay,tbl_HoSoBenhAn.ChamSoc, tbl_HoSoBenhAn.NuoiDuong, tbl_HoSoBenhAn.ChieuCao, tbl_HoSoBenhAn.VongNguc,tbl_HoSoBenhAn.VongDau, tbl_HoSoBenhAn.Mach, tbl_HoSoBenhAn.NhietDo, tbl_HoSoBenhAn.HuyetAp,tbl_HoSoBenhAn.NhipTho, tbl_HoSoBenhAn.CanNang, tbl_HoSoBenhAn.NgayVaoVien, tbl_HoSoBenhAn.GioVaoVien,tbl_HoSoBenhAn.NoiGioiThieu, tbl_HoSoBenhAn.VaoVienViBenhNayLanThu, tbl_HoSoBenhAn.NgayRaVien,tbl_HoSoBenhAn.GioRaVien, tbl_HoSoBenhAn.TongSoNgayDieuTri, tbl_HoSoBenhAn.TongSoNgayDieuTriSauPhauThuat,tbl_HoSoBenhAn.TongSoLanPhauThuat, tbl_HoSoBenhAn.GiaiPhauBenh, tbl_HoSoBenhAn.KhamNghiemTuThi,tbl_HoSoBenhAn.LyDoVaoVien, tbl_HoSoBenhAn.QuaTrinhBenhLy, tbl_HoSoBenhAn.TienSuBenhVeBanThan,tbl_HoSoBenhAn.TienSuBenhVeGiaDinh, tbl_HoSoBenhAn.PhanBiet, tbl_HoSoBenhAn.TienLuong, tbl_HoSoBenhAn.HuongDieuTri,tbl_HoSoBenhAn.NgayLamBenhAn, tbl_HoSoBenhAn.PhuongPhapDieuTri, tbl_HoSoBenhAn.QuaTrinhBenhLy_DienBienLamSan,tbl_HoSoBenhAn.TomTatKQXetNghiemCanLamSan, tbl_HoSoBenhAn.HuongDanDieuTri,tbl_HoSoBenhAn.CacCheDoTiepTheo,tbl_HoSoBenhAn.TenBenhChinh as 'BenhChinh',tbl_HoSoBenhAn.TenBenhKemTheo as 'BenhKemTheo',tbl_HoSoBenhAn.TenBenhCapCuuChanDoan as 'CapCuuChuanDoan',tbl_HoSoBenhAn.TenBenhKhoaDieuTriChanDoan as 'KhoaDieuTriChanDoan',tbl_HoSoBenhAn.TenBenhChanDoanTruocPhauThuat as 'ChanDoanTruocPhauThuat',tbl_HoSoBenhAn.TenBenhChanDoanSauPhauThuat as 'ChanDoanSauPhauThuat',tbl_HoSoBenhAn.TenBenhNoiChuyenChanDoan as 'NoiChuyenChanDoan',tbl_HoSoBenhAn.TenBenhChinhRaVien as 'BenhChinhRaVien',tbl_HoSoBenhAn.TenBenhKemTheoRaVien as 'BenhKemTheoRaVien', tbl_TinhTrangRaVien.TenTinhTrangRaVien, tbl_Khoa.TenKhoa as 'VaoKhoa',tbl_HoSoBenhAn.TenNguoiNhan as 'NguoiNhan',tbl_HoSoBenhAn.TenBSLamBenhAn as 'BSLamBenhAn',tbl_HoSoBenhAn.TenNguoiDuyet as 'HoTenNguoiDuyet',tbl_HoSoBenhAn.TenBacSiKham as 'BacSiKham',tbl_HoSoBenhAn.TenNguoiGiao as 'NguoiGiao',tbl_HoSoBenhAn.XuTri, tbl_HoSoBenhAn.CacBoPhan, tbl_HoSoBenhAn.CaiSuaThangThu, tbl_HoSoBenhAn.NgayTuVong,tbl_HoSoBenhAn.GioTuVong FROM tbl_HoSoBenhAn LEFT JOIN tbl_BenhNhan ON tbl_HoSoBenhAn.MaBenhNhan = tbl_BenhNhan.MaBenhNhan LEFT JOIN tbl_BenhVien ON tbl_HoSoBenhAn.MaBenhVien = tbl_BenhVien.MaBenhVien LEFT JOIN tbl_NguonNhapVien ON tbl_HoSoBenhAn.MaNguonNhapVien =tbl_NguonNhapVien.MaNguonNhapVien LEFT JOIN tbl_HinhThucRaVien ON tbl_HoSoBenhAn.MaHinhThucRaVien = tbl_HinhThucRaVien.MaHinhThucRaVien LEFT JOIN tbl_TinhTrangRaVien ON tbl_HoSoBenhAn.MaTinhTrangRaVien = tbl_TinhTrangRaVien.MaTinhTrangRaVien LEFT JOIN tbl_TinhHinhTuVong ON tbl_HoSoBenhAn.MaTinhHinhTuVong = tbl_TinhHinhTuVong.MaTinhHinhTuVong LEFT JOIN tbl_Benh ON tbl_HoSoBenhAn.BenhChinh = tbl_Benh.MaBenh and tbl_HoSoBenhAn.BenhKemTheo = tbl_Benh.MaBenh and tbl_HoSoBenhAn.CapCuuChanDoan = tbl_Benh.MaBenh and tbl_HoSoBenhAn.KhoaDieuTriChanDoan = tbl_Benh.MaBenh and tbl_HoSoBenhAn.ChanDoanTruocPhauThuat = tbl_Benh.MaBenh and tbl_HoSoBenhAn.ChanDoanSauPhauThuat = tbl_Benh.MaBenh and tbl_HoSoBenhAn.BenhChinhRaVien = tbl_Benh.MaBenh and tbl_HoSoBenhAn.BenhKemTheoRaVien = tbl_Benh.MaBenh  LEFT JOIN tbl_Khoa ON dbo.tbl_HoSoBenhAn.VaoKhoa = tbl_Khoa.MaKhoa LEFT JOIN tbl_CongNhanVien ON tbl_HoSoBenhAn.NguoiNhan = tbl_CongNhanVien.MaCongNhanVien AND tbl_HoSoBenhAn.BSLamBenhAn = tbl_CongNhanVien.MaCongNhanVien AND tbl_HoSoBenhAn.HoTenNguoiDuyet = tbl_CongNhanVien.MaCongNhanVien AND tbl_HoSoBenhAn.NguoiGiao = tbl_CongNhanVien.MaCongNhanVien AND tbl_HoSoBenhAn.BacSiKham = tbl_CongNhanVien.MaCongNhanVien left JOIN tbl_ViTri ON  tbl_HoSoBenhAn.MaViTri = tbl_ViTri.MaViTri WHERE tbl_HoSoBenhAn.MaDieuTri = tbl_HoSoBenhAn.MaDieuTri " + getData(), conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();

            da.Fill(dt);

            gv_DanhSach.DataSource = dt;
            gv_DanhSach.DataBind();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}