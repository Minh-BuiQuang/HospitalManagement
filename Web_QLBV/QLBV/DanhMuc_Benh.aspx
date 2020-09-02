<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_Benh.aspx.cs" Inherits="QLBV.DanhMuc_Benh1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="font-weight:bold;padding-left:170px">DANH MỤC BỆNH</h1>
    <asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
    <table>
        <tr>
            <td>
                Mã bệnh : 
            </td>
            <td>
                <asp:TextBox ID="tb_Mabenh" runat="server" Width="50px" Enabled="false"></asp:TextBox>
            </td>
            <td>
                Tên bệnh :
            </td>
            <td>
                <asp:TextBox ID="tb_TenBenh" runat="server" Width="250px" Enabled="false"></asp:TextBox>
            </td>
        </tr>
     <tr>
        <td>Loại bệnh:</td>
        <td colspan="3">
            <asp:DropDownList ID="ddl_loaibenh" runat="server" Enabled="false" AutoPostBack="true"
                DataSourceID="SqlDataSource1" DataTextField="TenLoaiBenh" 
                DataValueField="MaLoaiBenh" 
                onselectedindexchanged="ddl_loaibenh_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                SelectCommand="SELECT * FROM [tbl_LoaiBenh]"></asp:SqlDataSource>
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
            style="margin-top: 0px" BackColor="#DEBA84" BorderColor="#DEBA84" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <Columns>
                    <asp:TemplateField HeaderText="Mã Bệnh">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("MaBenh") %>'
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Tên Bệnh" DataField="TenBenh"
                        SortExpression="TenBenh"/>
                    <asp:BoundField HeaderText="Mã Loại Bệnh" DataField="MaLoaiBenh" 
                        SortExpression="MaLoaiBenh" />
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
    <br />
</asp:Content>
