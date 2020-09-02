<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_DanhSachBenhVien.aspx.cs" Inherits="QLBV.DanhMuc_Danhsachbenhvien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="font-weight:bold;padding-left:170px">DANH SÁCH BỆNH VIỆN</h1>
    <asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
    <table>
        <tr>
            <td>
                Mã bệnh viện: 
            </td>
            <td>
                <asp:TextBox ID="txt_MaBenhVien" runat="server" Width="50px" Enabled="false"></asp:TextBox>
            </td>
            <td>
                Tên bệnh viện:
            </td>
            <td>
                <asp:TextBox ID="txt_TenBenhVien" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Loại tuyến:
            </td>
            <td>
                <asp:DropDownList ID="ddl_loaituyen" runat="server" Enabled="False">
                    <asp:ListItem>Tuyến trên</asp:ListItem>
                    <asp:ListItem>Tuyến dưới</asp:ListItem>
                    <asp:ListItem>Khác</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Điện thoại:
            </td>
            <td>
                <asp:TextBox ID="txt_DienThoai" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Địa chỉ:
            </td>
            <td>
                <asp:TextBox ID="txt_DiaChi" Width="300px" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
                Website:
            </td>
            <td>
                <asp:TextBox ID="txt_WebSite" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email:
            </td>
            <td>
                <asp:TextBox ID="txt_Email" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
                Chuyên môn:
            </td>
            <td>
                <asp:TextBox ID="txt_ChuyenMon" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
    </table>

    <asp:Button ID="btn_add" runat="server" Text="Thêm" onclick="btn_add_Click" />
    <asp:Button ID="btn_del" runat="server" Text="Xóa" onclick="btn_del_Click" 
        OnClientClick="return confirm('Bạn có chắc không?')" Visible="false"/> 
    <asp:Button ID="btn_edit" runat="server" Text="Sửa" onclick="btn_edit_Click"
        OnClientClick="return confirm('Bạn có chắc không?')" Visible="false" />  
    <asp:Button ID="btn_save" runat="server" Text="Lưu" onclick="btn_save_Click" Visible="false" />
    <asp:Button ID="btn_Cancel" runat="server" Text="Hủy" Visible="false" 
                    onclick="btn_Cancel_Click" />

    <asp:Panel ID="pn_pan" runat="server" Width="1000px" BorderStyle="Double">
        <asp:GridView ID="gv_PatientList" runat="server" Width="100%"
            EmptyDataText="List empty" AutoGenerateColumns="False" 
            style="margin-top: 0px">
                <Columns>
                    <asp:TemplateField HeaderText="Mã Bệnh Viện">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("MaBenhVien") %>'
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tên Bệnh viện" DataField="TenBenhVien"
                        SortExpression="TenBenhVien"/>
                    <asp:BoundField HeaderText="Địa Chỉ" DataField="DiaChi" 
                        SortExpression="DiaChi" />
                    <asp:BoundField HeaderText="Điện Thoại"  DataField="DienThoai"
                        SortExpression="DienThoai" />
                    <asp:BoundField HeaderText="Email"  DataField="Email"
                        SortExpression="Email" />
                    <asp:BoundField HeaderText="Website"  DataField="Website"
                        SortExpression="Website" />
                    <asp:BoundField HeaderText="Loại Tuyến"  DataField="LoaiTuyen"
                        SortExpression="LoaiTuyen" />
                    <asp:BoundField HeaderText="Chuyên môn"  DataField="ChuyenMon"
                        SortExpression="ChuyenMon" />
                </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
</asp:Content>
