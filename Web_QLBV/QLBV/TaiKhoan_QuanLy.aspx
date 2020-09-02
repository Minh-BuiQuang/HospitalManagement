<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaiKhoan_QuanLy.aspx.cs" Inherits="QLBV.TaiKhoan_QuanLy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="font-weight:bold;padding-left:170px;">Phân Quyền</h1><br />
    <asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
    <asp:Panel ID="pn_info" runat="server">
    <table>
        <tr>
            <td>Mã CNV</td>
            <td>
                <asp:TextBox ID="txt_maCNV" runat="server" Width="50px" Enabled="false"></asp:TextBox>
            </td>
            <td>Ngày sinh</td>
            <td>
                <asp:TextBox ID="txt_ngaysinh" runat="server" Width="68px" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:Radiobuttonlist ID="rbl_gioitinh" runat="server" RepeatDirection="Horizontal" Enabled="false">
                    <asp:ListItem Value="True" Selected="True">Nam</asp:ListItem>
                    <asp:ListItem Value="False">Nữ</asp:ListItem>
                </asp:Radiobuttonlist>
        </td>

        </tr>
        <tr>
            <td>Chức vụ</td>
            <td colspan="3">
                <asp:DropDownList ID="ddl_ChucVu" runat="server" Enabled="false" DataSourceID="SqlDataSource2" 
                    DataTextField="TenChucVu" DataValueField="MaChucVu">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_ChucVu]"></asp:SqlDataSource>
            </td>
            <td>Quyền user</td>
            <td>
                <asp:DropDownList ID="ddl_PhanQuyen" runat="server">
                    <asp:ListItem Value="admin">admin</asp:ListItem>
                    <asp:ListItem Value="bacsi">bacsi</asp:ListItem>
                    <asp:ListItem Value="dieuduong">dieuduong</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Chức danh</td>
            <td colspan="3">
                <asp:DropDownList ID="ddl_ChucDanh" runat="server" Enabled="False" 
                    DataSourceID="SqlDataSource3" DataTextField="ChucDanh" 
                    DataValueField="MaChucDanh">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_ChucDanh]"></asp:SqlDataSource>
            </td>
            <td>UserName:</td>
            <td>
                <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Khoa</td>
            <td colspan="3">
                <asp:DropDownList ID="ddl_Khoa" runat="server" Enabled="false" DataSourceID="SqlDataSource4" 
                    DataTextField="TenKhoa" DataValueField="MaKhoa">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                    SelectCommand="SELECT * FROM [tbl_Khoa]"></asp:SqlDataSource>
            </td>
            <td>Password:</td>
            <td>
                <asp:TextBox ID="txt_password" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    </asp:Panel>

    <asp:Panel ID="pn_pan" runat="server" Width="500px" BorderStyle="Double">
        <asp:GridView ID="gv_PatientList" runat="server" Width="100%"
            EmptyDataText="List empty" AutoGenerateColumns="False" 
            style="margin-top: 0px" BackColor="#DEBA84" BorderColor="#DEBA84" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <Columns>
                    <asp:TemplateField HeaderText="Họ và Tên">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("HoTenCongNhanVien") %>'
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tài Khoản" DataField="TenDangNhap" 
                        SortExpression="QuyenHan" />
                    <asp:BoundField HeaderText="Mật Khẩu" DataField="MatKhau" 
                        SortExpression="MatKhau" />
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
        
    </asp:Panel><br />
    <div style="margin-left:200px">
        <asp:Button ID="btn_save" runat="server" Text="Đồng ý" 
            OnClientClick="return confirm('Bạn có chắc không?')" onclick="btn_save_Click" />
    </div>
</asp:Content>
