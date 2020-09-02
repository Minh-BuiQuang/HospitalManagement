<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HoSo_ChiTietTTBN.aspx.cs" Inherits="QLBV.HoSo_ChiTietTTBN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">    
    <link href="Styles/jquery.datepick.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript" src="Scripts/jquery.datepick.js"></script>
<script type="text/javascript">
    $(function () {
        $('#MainContent_dob').datepick();
        $('#MainContent_bd_bhyt').datepick();
        $('#MainContent_kt_bhyt').datepick();
    });

    function showDate(date) {
        alert('The date chosen is ' + date);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <ul>
        <li><a href="HoSo_DS_ThongTinBenhNhan.aspx">Danh sách thông tin bệnh nhân</a></li>
        <li><a href="HoSo_ChiTietTTBN.aspx">Chi tiết thông tin bệnh nhân</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lbl_Notification" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>
    <table>
        <tr>
            <td style="padding-left:10px">Mã Số BN:</td>
            <td>
                <asp:TextBox ID="txt_MSBN" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td style="padding-left:10px">Họ Tên:</td>
            <td>
                <asp:TextBox ID="txt_HoTenBN" runat="server"></asp:TextBox>
            </td>
            <td style="padding-left:10px">Ngày sinh:<br />Giới tính</td>
            <td>
                <asp:TextBox ID="dob" runat="server"></asp:TextBox>
                <asp:RadioButtonList ID="rd_Gender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="true">Nam</asp:ListItem>
                    <asp:ListItem Value="false">Nữ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="padding-left:10px">Điện thoại:</td>
            <td>
                <asp:TextBox  ID="txt_Phone" runat="server"></asp:TextBox>
            </td>
            <td style="padding-left:10px">Địa chỉ:</td>
            <td>
                <asp:TextBox ID="txt_Address" runat="server"></asp:TextBox>
            </td>
            <td style="padding-left:10px">Nơi làm việc:</td>
            <td>
                <asp:TextBox  ID="txt_WorkPlace" runat="server" ></asp:TextBox>
            </td>                
        </tr>
        <tr>
            <td style="padding-left:10px">Đối tượng</td>
            <td>
                <asp:DropDownList ID="ddl_DoiTuong" runat="server">
                    <asp:ListItem Value="0">Chưa biết</asp:ListItem>
                    <asp:ListItem Value="1">Thu phí</asp:ListItem>
                    <asp:ListItem Value="2">BHYT</asp:ListItem>
                    <asp:ListItem Value="3">Miễn</asp:ListItem>
                    <asp:ListItem Value="4">Trẻ em dưới 6 tuổi</asp:ListItem>
                    <asp:ListItem Value="5">Khác</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="padding-left:10px">Mã BHYT</td>
            <td>
                <asp:TextBox ID="txt_MaBHYT" runat="server"></asp:TextBox>
            </td>
            <td style="padding-left:10px">Ngày BD BHYT</td>
            <td>
                <asp:TextBox ID="bd_bhyt" runat="server"></asp:TextBox>
            </td>                
        </tr>
        <tr>
            <td style="padding-left:10px">Tỉnh thành</td>
            <td>
                <asp:DropDownList ID="ddl_City" runat="server" DataSourceID="SqlDataSource1" 
                    DataTextField="TenTinhThanh" DataValueField="MaTinhThanh" 
                    AutoPostBack="True">
                    </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_TinhThanh]"></asp:SqlDataSource>

            </td>
            <td style="padding-left:10px">Họ tên cha</td>
            <td>
                <asp:TextBox ID="txt_DadsName" runat="server"></asp:TextBox>
            </td>
            <td style="padding-left:10px">Ngày KT BHYT</td>
            <td>
                <asp:TextBox ID="kt_bhyt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-left:10px">Quận huyện</td>
            <td>
                <asp:DropDownList ID="ddl_District" runat="server" 
                    DataSourceID="SqlDataSource2" DataTextField="TenQuanHuyen" 
                    DataValueField="MaQuanHuyen" AutoPostBack="True">
                    </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT [MaQuanHuyen], [TenQuanHuyen] FROM [tbl_QuanHuyen]">
                </asp:SqlDataSource>

            </td>
            <td style="padding-left:10px">Nghề nghiệp</td>
            <td>
                <asp:DropDownList ID="ddl_DadJob" runat="server" DataSourceID="SqlDataSource3" 
                    DataTextField="TenNgheNghiep" DataValueField="MaNgheNghiep">
                    </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_NgheNghiep]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="padding-left:10px">Phường xã</td>
            <td>
                <asp:DropDownList ID="ddl_Ward" runat="server" DataSourceID="SqlDataSource4" 
                    DataTextField="TenPhuongXa" DataValueField="MaPhuongXa">
                    </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    
                    
                    SelectCommand="SELECT [MaPhuongXa], [TenPhuongXa], [MaQuanHuyen] FROM [tbl_PhuongXa]">
                </asp:SqlDataSource>
            </td>
            <td style="padding-left:10px">Họ tên mẹ</td>
            <td>
                <asp:TextBox ID="txt_MomsName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-left:10px">Dân tộc</td>
            <td>
                <asp:DropDownList ID="ddl_Race" runat="server" DataSourceID="SqlDataSource5" 
                    DataTextField="TenDanToc" DataValueField="MaDanToc">
                    </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_DanToc]"></asp:SqlDataSource>
            </td>
            <td style="padding-left:10px">Nghề nghiệp</td>
            <td>
                <asp:DropDownList ID="ddl_MomJob" runat="server" DataSourceID="SqlDataSource6" 
                    DataTextField="TenNgheNghiep" DataValueField="MaNgheNghiep">
                    </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_NgheNghiep]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="padding-left:10px">Nghề nghiệp</td>
            <td>
                <asp:DropDownList ID="ddl_Job" runat="server" DataSourceID="SqlDataSource6" 
                    DataTextField="TenNgheNghiep" DataValueField="MaNgheNghiep">
                    </asp:DropDownList>
            </td>
            <td style="padding-left:10px">Họ tên người liên lạc</td>
            <td>
                <asp:TextBox ID="txt_Relative" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-left:10px">Quốc tịch</td>
            <td>
                <asp:DropDownList ID="ddl_Nationality" runat="server" 
                    DataSourceID="SqlDataSource7" DataTextField="TenQuocTich" 
                    DataValueField="MaQuocTich">
                    </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_QuocTich]"></asp:SqlDataSource>
            </td>
            <td style="padding-left:10px">Địa chỉ</td>
            <td>
                <asp:TextBox ID="txt_FamilyAddress"  runat="server"></asp:TextBox>
            </td>
        </tr>
    </table><br />

        <asp:Panel runat="server" ID="pn_btn">
            <asp:Button runat="server" style="margin-left:84px;" ID="btn_Them" Text="Thêm" 
                onclick="btn_Them_Click" />
            <asp:Button runat="server" ID="btn_Sua" Text="Sửa" onclick="btn_Sua_Click" />
        </asp:Panel>
</asp:Content>
