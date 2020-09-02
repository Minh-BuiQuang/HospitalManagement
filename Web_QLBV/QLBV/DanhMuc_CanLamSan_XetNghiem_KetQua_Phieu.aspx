<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_CanLamSan_XetNghiem_KetQua_Phieu.aspx.cs" Inherits="QLBV.DanhMuc_CanLamSan_XetNghiem_KetQua_Phieu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="Styles/jquery.datepick.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript" src="Scripts/jquery.datepick.js"></script>
<script type="text/javascript">
    $(function () {
        $('#MainContent_txt_DateResult').datepick();
    });

    function showDate(date) {
        alert('The date chosen is ' + date);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <ul>
        <li><a href="DanhMuc_CanLamSan_XetNghiem_KetQua_BenhNhan.aspx">Bệnh nhân</a></li>
        <li><a href="DanhMuc_CanLamSan_XetNghiem_KetQua_DSPhieu.aspx">Danh sách phiếu chụp X-Quang</a></li>
        <li><a href="DanhMuc_CanLamSan_XetNghiem_KetQua_Phieu.aspx">Phiếu X-Quang</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="font-weight:bold;padding-left:170px;">Phiếu Xét Nghiệm</h1>
    <asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
        <table border="1">
        <tr>
            <td>Họ tên</td>
            <td><asp:TextBox ID="txt_HoTen" runat="server" Enabled="false"></asp:TextBox></td>
            <td>Ngày sinh</td>
            <td><asp:TextBox ID="txt_NgaySinh" runat="server" Enabled="false" Width="55px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Ngày vào viện</td>
            <td><asp:TextBox ID="txt_NgayVaoVien" runat="server" Enabled="false"></asp:TextBox></td>
            
            <td>Phái</td>
            <td>
                <asp:RadioButtonList ID="rdl_GioiTinh" runat="server" RepeatColumns="2" Enabled="false">
                    <asp:ListItem Selected="True" Value="1">Nam</asp:ListItem>
                    <asp:ListItem Value="0">Nữ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>Mã phiếu</td>
            <td><asp:TextBox ID="txt_MaPhieu" runat="server" Width="100px"></asp:TextBox></td>
            <td>Chỉ tiêu xét nghiệm</td>
            <td><asp:DropDownList ID="ddl_ChiTieu" runat="server" Width="120px" 
                    DataSourceID="SqlDataSource1" DataTextField="TenChiTieuXetNghiem" 
                    DataValueField="MaChiTieuXetNghiem"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_ChiTieuXetNghiem]"></asp:SqlDataSource>
            </td>
            <td>Ngày yêu cầu</td>
            <td><asp:TextBox ID="txt_NgayYeuCau" runat="server" Enabled="false" Width="55px"></asp:TextBox></td>
            <td>Lần thứ</td>
            <td><asp:TextBox ID="txt_Lan" runat="server" Enabled="false" Width="25px"></asp:TextBox></td>
        </tr>
    </table>
    <table>
        <tr>
            <td rowspan="3">Yêu cầu siêu âm</td>
            <td rowspan="3">
                <asp:TextBox ID="txt_YeuCau" runat="server" Height="100px" Width="300px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>Bác sĩ điều trị</td>
            <td><asp:DropDownList ID="ddl_BSDTri" runat="server" Width="130px" 
                    DataSourceID="SqlDataSource2" DataTextField="HoTenCongNhanVien" 
                    DataValueField="MaCongNhanVien"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT [MaCongNhanVien], [HoTenCongNhanVien] FROM [tbl_CongNhanVien]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>Ngày ghi kết quả</td>
            <td><asp:TextBox ID="txt_DateResult" runat="server" Width="55px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Bác sĩ chuyên khoa</td>
            <td><asp:DropDownList ID="ddl_Doctor" runat="server" Width="130px" 
                    DataSourceID="SqlDataSource2" DataTextField="HoTenCongNhanVien" 
                    DataValueField="MaCongNhanVien"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Kết quả siêu âm</td>
            <td>
                <asp:TextBox ID="txt_KetQua" runat="server" Height="100px" Width="300px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:Accordion
                ID="MyAccordion"
                runat="Server"
                SelectedIndex="1"
                HeaderCssClass="accordionHeader"
                HeaderSelectedCssClass="accordionHeaderSelected"
                ContentCssClass="accordionContent"
                AutoSize="None"
                FadeTransitions="true"
                TransitionDuration="250"
                FramesPerSecond="40"
                RequireOpenedPane="false"
                SuppressHeaderPostbacks="true">
                    <Panes>
                        <asp:AccordionPane ID="AccordionPane1" runat="server"
                            HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                            <Header>Xem hình</Header>
                            <Content>
                                <asp:Panel ID="pn_image" runat="server" Width="300px">
                                    <asp:FileUpload ID="fu_link" runat="server" EnableTheming="true" Height="20px" 
                                        Width="140px" />
                                        <asp:Button ID="btn_submit" runat="server" Text="Đính kèm" 
                                            onclick="btn_submit_Click" /><br />
                                        <asp:Button ID="btn_delete" runat="server" Text="Hủy file" />
                                        <asp:Button ID="btn_save" runat="server" Text="In phiếu" /><br />
                                        <asp:Image ID="img_upload" runat="server" Width="300px" Height="400px" />
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>
                    </Panes>
                </asp:Accordion>
            </td>
        </tr>
    </table>

    <asp:Button ID="btn_savePage" runat="server" Text="Lưu" 
        style="margin-left:300px" onclick="btn_savePage_Click" />
    <asp:Button ID="btn_cancel" runat="server" Text="Hủy" />
</asp:Content>
