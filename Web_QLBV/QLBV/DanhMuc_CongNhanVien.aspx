<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc_CongNhanVien.aspx.cs" Inherits="QLBV.DanhMuc_Danhsachcongnhanvien2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="Styles/jquery.datepick.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript" src="Scripts/jquery.datepick.js"></script>
<script type="text/javascript">
    $(function () {
        $('#MainContent_dob').datepick();
    });

    function showDate(date) {
        alert('The date chosen is ' + date);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="font-weight:bold;padding-left:170px">DANH SÁCH CÔNG NHÂN VIÊN</h1>
<asp:label ID="lbl_error" runat="server" Font-Bold="true" ForeColor="Red"></asp:label>
    <table>
        <tr>
            <td>Mã công nhân viên :</td>
            <td>
                <asp:TextBox ID="tb_MaCongNhanVien" runat="server" Width="50px" Enabled="false"></asp:TextBox>
            </td>
            <td>Họ tên :</td>
            <td>
                <asp:TextBox ID="tb_HoTen" runat="server" Width="150px" Enabled="false"></asp:TextBox>
            </td>
            <td>Ngày sinh</td>
            <td>
                <asp:TextBox ID="dob" runat="server" Width="60px" Enabled="false"></asp:TextBox>
            </td>
        </tr>
     <tr>
        <td>Điện thoại:</td>
        <td>
            <asp:TextBox ID="tb_DienThoai" runat="server" Width="150px" Enabled="false"></asp:TextBox>
        </td>
        <td>Địa chỉ :</td>
        <td colspan="3">
            <asp:TextBox ID="tb_DiaChi" runat="server" Enabled="false" Width="100%"></asp:TextBox>
        </td>            
     </tr>
     <tr>
         <td>Giới tính:</td>
         <td>
             <asp:Radiobuttonlist ID="rbl_gioitinh" runat="server" RepeatDirection="Horizontal" Enabled="false">
                <asp:ListItem Value="1">Nam</asp:ListItem>
                <asp:ListItem Value="0">Nữ</asp:ListItem>
             </asp:Radiobuttonlist>
         </td>
         <td>Email:</td>
         <td>
             <asp:TextBox ID="tb_Email" runat="server" Width="150px" Enabled="false"></asp:TextBox>
         </td>
         <td>Khoa:</td>
         <td>        
             <asp:DropDownList ID="ddl_khoa" runat="server" DataSourceID="SqlDataSource3" Enabled="false"
                 DataTextField="TenKhoa" DataValueField="MaKhoa"></asp:DropDownList>        
             <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                 SelectCommand="SELECT * FROM [tbl_Khoa]"></asp:SqlDataSource>
         </td>
     </tr>
     <tr>
         <td>Trình độ:</td>
         <td>
             <asp:DropDownList ID="ddl_trinhdo" runat="server" DataSourceID="SqlDataSource1" Enabled="false"
                 DataTextField="TrinhDo" DataValueField="MaTrinhDo"></asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                 SelectCommand="SELECT * FROM [tbl_TrinhDo]"></asp:SqlDataSource>
         </td>
         <td>Chức danh:</td>
         <td>
             <asp:DropDownList ID="ddl_chucdanh" runat="server" Enabled="false" 
                 DataSourceID="SqlDataSource2" DataTextField="ChucDanh" 
                 DataValueField="MaChucDanh"></asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                 SelectCommand="SELECT * FROM [tbl_ChucDanh]"></asp:SqlDataSource>
         </td>
         <td>Chức vụ:</td>
         <td>
             <asp:DropDownList ID="ddl_chucvu" runat="server" DataSourceID="SqlDataSource4" Enabled="false" 
                 DataTextField="TenChucVu" DataValueField="MaChucVu"></asp:DropDownList>
             <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                 ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                 SelectCommand="SELECT * FROM [tbl_ChucVu]"></asp:SqlDataSource>
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

    <asp:Panel ID="pn_pan" runat="server" Width="1100px" BorderStyle="Double" ScrollBars="Horizontal">
        <asp:GridView ID="gv_PatientList" runat="server" Width="100%"
            EmptyDataText="List empty" AutoGenerateColumns="False" 
            style="margin-top: 0px" BackColor="#DEBA84" BorderColor="#DEBA84" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <Columns>
                    <asp:TemplateField HeaderText="Mã CNV">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("MaCongNhanVien") %>'
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Họ Tên" DataField="HoTenCongNhanVien"
                        SortExpression="HoTenCongNhanVien"/>
                    <asp:BoundField HeaderText="Ngày Sinh" DataField="NgaySinh"
                        SortExpression="NgaySinh"/>
                    <asp:BoundField HeaderText="Điện Thoại" DataField="DienThoai"
                        SortExpression="DienThoai"/>
                    <asp:BoundField HeaderText="Địa Chỉ" DataField="DiaChi"
                        SortExpression="DiaChi"/>
                    <asp:BoundField HeaderText="Giới Tính" DataField="GioiTinh"
                        SortExpression="GioiTinh"/>
                    <asp:BoundField HeaderText="Email" DataField="Email"
                        SortExpression="Email"/>
                    <asp:BoundField HeaderText="Trình Độ" DataField="MaTrinhDo"
                        SortExpression="MaTrinhDo"/>
                    <asp:BoundField HeaderText="Khoa" DataField="MaKhoa"
                        SortExpression="MaKhoa"/>
                    <asp:BoundField HeaderText="Chức Danh" DataField="MaChucDanh"
                        SortExpression="MaChucDanh"/>
                    <asp:BoundField HeaderText="Chức Vụ" DataField="MaChucVu"
                        SortExpression="MaChucVu"/>
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
