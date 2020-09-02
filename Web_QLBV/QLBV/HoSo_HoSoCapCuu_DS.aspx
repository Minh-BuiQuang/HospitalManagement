<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HoSo_HoSoCapCuu_DS.aspx.cs" Inherits="QLBV.HoSo_HoSoCapCuu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <ul>
        <li><a href="#">Danh sách</a></li>
        <li><a href="HoSo_HoSoCapCuu_ChiTiet.aspx">Chi tiết</a></li>        
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Thông tin bệnh nhân</h1>
    <asp:Panel ID="pn_GridView" runat="server" BackColor="White" Width="1130px"
        ScrollBars="Horizontal">
        <asp:GridView ID="gv_PatientList" runat="server" Width="2000px" OnRowDataBound="gv_PatientList_RowDataBound"
         EmptyDataText="List empty" AllowPaging="True" PageSize="9"
        AutoGenerateColumns="False" OnPageIndexChanging="gv_PatientList_PageIndexChanging"
        OnSelectedIndexChanged="gv_PatientList_SelectedIndexChanged"
            style="margin-top: 0px" BackColor="#DEBA84" BorderColor="#DEBA84" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
            <Columns>
                <asp:BoundField HeaderText="Mã bệnh nhân" DataField="MaBenhNhan"/>
                <asp:BoundField HeaderText="Họ tên" DataField="HoTenBenhNhan"/>
                <asp:BoundField HeaderText="Giới tính" DataField="GioiTinh"/>
                <asp:BoundField HeaderText="Ngày sinh" DataField="NgaySinh"/>
                <asp:BoundField HeaderText="Địa chỉ" DataField="DiaChi"/>
                <asp:BoundField HeaderText="Điện thoại" DataField="DienThoai"/>
                <asp:BoundField HeaderText="Nghề nghiệp" DataField="TenNgheNghiep"/>
                <asp:BoundField HeaderText="Nơi làm việc" DataField="NoiLamViec"/>
                <asp:BoundField HeaderText="Đối tượng" DataField="TenDoiTuong"/>
                <asp:BoundField HeaderText="Số BHYT" DataField="SoBHYT"/>
                <asp:BoundField HeaderText="Ngày BĐ BHYT" DataField="NgayBD_BHYT"/>
                <asp:BoundField HeaderText="Ngày KT BHYT" DataField="NgayKT_BHYT"/>
                <asp:BoundField HeaderText="Dân tộc" DataField="TenDanToc"/>
                <asp:BoundField HeaderText="Người nhà" DataField="HoTenNguoiNha"/>
                <asp:BoundField HeaderText="Địa chỉ" DataField="DiaChiNguoiNha"/>
                <asp:BoundField HeaderText="Họ tên cha" DataField="HoTenCha"/>
                <asp:BoundField HeaderText="Họ tên mẹ" DataField="HoTenMe"/>
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
        <asp:SqlDataSource ID="gv_PatientListSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
            SelectCommand="SELECT * FROM [tbl_BenhNhan]"></asp:SqlDataSource>
        <br />
</asp:Content>
