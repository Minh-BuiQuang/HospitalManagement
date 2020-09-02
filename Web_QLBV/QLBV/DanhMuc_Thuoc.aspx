<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_Thuoc.aspx.cs" Inherits="QLBV.DanhMuc_Thuoc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <h1 style="font-weight:bold;padding-left:170px">DANH MỤC THUỐC</h1>
     <asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
    <table>
        <tr>
            <td>
                Mã thuốc : 
            </td>
            <td>
                <asp:TextBox ID="tb_MaThuoc" runat="server" Width="50px" Enabled="false"></asp:TextBox>
            </td>
            <td>
                Đơn vị tính :
            </td>
            <td>
                <asp:TextBox ID="tb_DonViTinh" runat="server" Enabled="false"></asp:TextBox>
            </td>
        </tr>
     <tr>
        <td>Tên thuốc</td>
        <td>          
              <asp:TextBox ID="tb_TenThuoc" runat="server" Enabled="false"></asp:TextBox>
            </td>
        <td>Lô sản xuất:</td>
        <td><asp:TextBox ID="tb_Losanxuat" runat="server"></asp:TextBox></td>            
     </tr>
     <tr>
        <td>Mã loại thuốc</td>
        <td>
            <asp:DropDownList ID="ddl_maloaithuoc" runat="server" Enabled="False" 
                DataSourceID="SqlDataSource1" DataTextField="TenLoaiThuoc" 
                DataValueField="MaLoaiThuoc"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                SelectCommand="SELECT * FROM [tbl_LoaiThuoc]"></asp:SqlDataSource>
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

    <asp:Panel ID="pn_pan" runat="server" Width="500px" BorderStyle="Double">
        <asp:GridView ID="gv_PatientList" runat="server" Width="100%"
            EmptyDataText="List empty" AutoGenerateColumns="False" 
            style="margin-top: 0px">
                <Columns>
                    <asp:TemplateField HeaderText="Mã Thuốc">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("MaThuoc") %>'
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tên Thuốc" DataField="TenThuoc"
                        SortExpression="TenBenh"/>
                    <asp:BoundField DataField="DVTinh" HeaderText="Đơn Vị Tính" 
                        SortExpression="DVTinh" />
                    <asp:BoundField DataField="MaLoaiThuoc" HeaderText="Mã Loại Thuốc" 
                        SortExpression="MaLoaiThuoc" />
                    <asp:BoundField DataField="LoSanXuat" HeaderText="Lô Sản Xuất" 
                        SortExpression="LoSanXuat" />
                </Columns>
        </asp:GridView>
    </asp:Panel>
    <br />
    
</asp:Content>
