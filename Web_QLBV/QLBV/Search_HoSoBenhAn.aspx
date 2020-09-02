<%@ Page Title="Tìm kiếm hồ sợ bệnh án" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search_HoSoBenhAn.aspx.cs" Inherits="QLBV.Search_HoSoBenhAn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <ul>
        <li><a href="Search_HoSoBenhAn.aspx">Tìm kiếm hồ sơ bệnh án</a></li>
        <li><a href="Search_BenhNhan.aspx">Tìm kiếm bệnh nhân</a></li>
        <li><a href="Search_CongNhanVien.aspx">Tìm kiếm công nhân viên</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="font-weight:bold;">TÌM KIẾM HỒ SƠ BỆNH ÁN</h1>
        <table>
            <tr>
                <td style="line-height:23px">
                    Số bệnh án :<br />
                    Mã bệnh nhân :<br />
                    Tên bệnh nhân :<br />
                </td>
                <td>    
                    <asp:TextBox ID="tb_SoBenhAn" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="tb_MaBenhNhan" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="tb_TenBenhNhan" runat="server"></asp:TextBox><br />
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btn_TimKiem" runat="server" Text="Tìm kiếm" 
        onclick="btn_TimKiem_Click" /><br /><br />
        <asp:Panel ID="pn_GridView" Width="1160px" runat="server" BackColor="White" Height="500px"
        ScrollBars="Both">
            <asp:GridView ID="gv_DanhSach" runat="server" BorderStyle="None" Width="10000px"
                CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84" BorderWidth="1px" 
                CellSpacing="2">
                <Columns>
                    <asp:TemplateField HeaderText="Xem hồ sơ">
                        <ItemTemplate>
                            <center>
                                <asp:HyperLink ID="HyperLink1" runat="server" Width="70px" Text="Xem" NavigateUrl='<%#"XemHSBA.aspx?id="+ Eval("MaDieuTri") %>'></asp:HyperLink>
                            </center>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
        </asp:Panel>
</asp:Content>
