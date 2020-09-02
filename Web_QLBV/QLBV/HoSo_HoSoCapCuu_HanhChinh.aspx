<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HoSo_HoSoCapCuu_HanhChinh.aspx.cs" Inherits="QLBV.HoSo_HoSoCapCuu_HanhChinh" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/jquery.datepick.css" rel="Stylesheet" type="text/css" />
    <link rel="Stylesheet" href="Styles/timePicker.css" type="text/css" media="all" />
    <script type="text/javascript" src="Scripts/jquery.timePicker.js"></script>
    <script type="text/javascript" src="Scripts/ui.timepickr.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="Scripts/jquery.datepick.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#MainContent_day_checkin').datepick();
        });
    </script>
    <script type="text/javascript">
        jQuery(function () {
            $("#MainContent_Hour_Checkin").timePicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <ul>
        <li><a href="HoSo_HoSoCapCuu_DS.aspx">Danh sách</a></li>
        <li><a href="HoSo_HoSoCapCuu_ChiTiet.aspx">Chi tiết</a></li>
   </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table border="1">
            <tr>
                <td>
                    Số bệnh án
                </td>
                <td>
                    <asp:TextBox ID="txt_SoBA" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td>
                    Phái
                </td>
                <td>                 
                    <asp:RadioButtonList ID="rdl_GioiTinh" Enabled="false" runat="server" RepeatColumns="2">
                            <asp:ListItem Selected="True" Value="0">Nam</asp:ListItem>
                            <asp:ListItem Value="1">Nữ</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    Địa chỉ
                </td>
                <td>
                    <asp:TextBox ID="txt_Address" Enabled="false" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Mã số BN
                </td>
                <td>
                    <asp:TextBox ID="txt_MaBN" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td>
                    Ngày sinh
                </td>
                <td>
                    <asp:TextBox ID="dob" Enabled="false" runat="server" Width="60px" />
                </td>
                <td>
                    Nơi Làm việc
                </td>
                <td>
                    <asp:TextBox ID="txt_WorkAddress" Enabled="false" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Họ và tên
                </td>
                <td>
                    <asp:TextBox ID="txt_HoTen" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td>
                    Điện thoại
                </td>
                <td>
                    <asp:TextBox ID="txt_mobile" Enabled="false" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Label runat="server" ID="lbl_Notification" Font-Bold="true" ForeColor="Red"></asp:Label><br />
        <table border="1" width="100%">
            <tr>
                <td>
                    <asp:Label Text="Thông tin vào khoa" runat="server"></asp:Label>
                    <asp:Panel runat="server" style="border-width:1px;" width="300px">
                        <table style="border-width:2px;">
                            <tr>
                                <td>
                                    Ngày khám bệnh
                                </td>
                                <td>
                                    <asp:TextBox ID="day_checkin" runat="server"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Giờ khám
                                </td>
                                <td>
                                    <asp:TextBox ID="Hour_Checkin" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Nguồn nhập viện
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_NguonNhapVien" runat="server" 
                                        DataSourceID="DB_BVConn" DataTextField="TenNguonNhapVien" 
                                        DataValueField="MaNguonNhapVien" AutoPostBack="True" 
                                        onselectedindexchanged="ddl_NguonNhapVien_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:SqlDataSource ID="DB_BVConn" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                                        SelectCommand="SELECT * FROM [tbl_NguonNhapVien]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Chuyển từ
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_From" runat="server" Enabled="False" 
                                        DataSourceID="SqlDataSource1" DataTextField="TenBenhVien" 
                                        DataValueField="MaBenhVien"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                                        SelectCommand="SELECT [MaBenhVien], [TenBenhVien] FROM [tbl_BenhVien]">
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Bác sĩ khám
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_DrList" runat="server" DataSourceID="SqlDataSource2" 
                                        DataTextField="HoTenCongNhanVien" DataValueField="MaCongNhanVien"></asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                                        SelectCommand="SELECT [MaCongNhanVien], [HoTenCongNhanVien] FROM [tbl_CongNhanVien]">
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Lý do vào viện
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Reason" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td style="border-width:2px;">
                    <asp:Label Text="Hỏi bệnh" runat="server"></asp:Label>
                    <asp:Panel style="border-width:1px;" runat="server">
                    <table style="border-width:2px;">
                        <tr>
                            <td>
                                Quá trình bệnh lý
                            </td>
                            <td>
                                <asp:TextBox ID="txt_QTBenhLy" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tiền sử bệnh nhân
                            </td>
                            <td>
                                <asp:TextBox ID="txt_PatientBackGround" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tiền sử bệnh gia đình
                            </td>
                            <td>
                                <asp:TextBox ID="txt_FamilyBackGround" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                
                                <table width="90%">
                                    <tr>
                                        <td width="40%">
                                            <asp:Label Text="Toàn thân" ID="lbl_ToanThan" runat="server"></asp:Label>
                                            <table border="1">
                                                <tr>
                                                    <td>
                                                        Mạch
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Pulse" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                         lần/phút
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Nhiệt độ
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Tempurature" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        độ C
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Huyết áp 
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_BlPressure" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        mmHg
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Nhịp thở
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Breath" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        lần/phút
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Cân nặng
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_Weight" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        kg
                                                    </td>
                                                </tr>
                                            </table>&nbsp;
                                        </td>
                                        <td width="10%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        <td width="45%">
                                            <asp:Label ID="lbl_CacBoPhan" Text="Các bộ phận" runat="server"></asp:Label>
                                            <table border="1">
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txt_CacBoPhan" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50">
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddl_CacBoPhan" runat="server">
                                                            <asp:ListItem>Kết quả Siêu Âm</asp:ListItem>
                                                            <asp:ListItem>Kết quả Xét Nghiệm</asp:ListItem>
                                                            <asp:ListItem>Kết quả Chụp X Quang</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="Label1" Text="Chuẩn đoán - Xử trí" runat="server"></asp:Label>
                                <asp:Panel ID="Panel1" runat="server" Width="90%" border="1">
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        Chuẩn đoán
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txt_ChuanDoan" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Bệnh chính
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddl_LoaiBenh" runat="server" 
                                                            DataSourceID="Benh" DataTextField="TenBenh" 
                                                            DataValueField="MaBenh"></asp:DropDownList>
                                                        <asp:SqlDataSource ID="Benh" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                                                            SelectCommand="SELECT [MaBenh], [TenBenh] FROM [tbl_Benh]"></asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Bệnh kèm theo
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddl_BenhKem" runat="server" DataSourceID="Benh" 
                                                            DataTextField="TenBenh" DataValueField="MaBenh"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td></td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        Xử trí
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddl_XuTri" runat="server">
                                                            <asp:ListItem>Cấp toa thuốc</asp:ListItem>
                                                            <asp:ListItem>Tái khám</asp:ListItem>
                                                            <asp:ListItem>Hấp hối xin về</asp:ListItem>
                                                            <asp:ListItem>Chuyển viện</asp:ListItem>
                                                            <asp:ListItem>Nhập viện</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Vào điều trị tại khoa
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddl_Khoa" runat="server" DataSourceID="Khoa" 
                                                            DataTextField="TenKhoa" DataValueField="MaKhoa"></asp:DropDownList>
                                                        <asp:SqlDataSource ID="Khoa" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                                                            SelectCommand="SELECT * FROM [tbl_Khoa]"></asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
            </td>
            </tr>
        </table>
        <center>
            <asp:Button ID="btn_Add" Width="80px" runat="server" Text="Thêm" 
                onclick="btn_Add_Click"/>
            <asp:Button ID="btn_Edit" style="margin-left:150px" runat="server" Width="80px" 
                Text="Sửa" onclick="btn_Edit_Click"/>
        </center>
</asp:Content>
