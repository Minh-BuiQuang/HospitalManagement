<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HoSo_HoSoCapCuu_KhamBenh.aspx.cs" Inherits="QLBV.HoSo_HoSoCapCuu_NgoaiChuan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
   <ul>
        <li><a href="HoSo_HoSoCapCuu_ChiTiet.aspx">Danh sách</a></li>
        <li><a href="HoSo_HoSoCapCuu_ChiTiet.aspx">Chi tiết</a></li>
        <li><a href="HoSo_HoSoCapCuu_HanhChinh.aspx">Hành Chính</a></li>
        <li><a href="HoSo_HoSoCapCuu_KhamBenh.aspx">Khám bệnh</a></li>
   </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <table>
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
                                <asp:DropDownList ID="ddl_CacBoPhan" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Label Text="Chuẩn đoán - Xử trí" runat="server"></asp:Label>
        <asp:Panel runat="server" Width="90%" border="1">
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
                                <asp:TextBox ID="txt_MaBenh" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_LoaiBenh" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Bệnh kèm theo
                            </td>
                            <td>
                                <asp:TextBox ID="txt_MaBenhKem" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_BenhKem" runat="server"></asp:DropDownList>
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
                                <asp:DropDownList ID="ddl_XuTri" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vào điều trị tại khoa
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_Khoa" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
</asp:Content>
