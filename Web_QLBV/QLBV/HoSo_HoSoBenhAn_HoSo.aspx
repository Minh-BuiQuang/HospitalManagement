<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HoSo_HoSoBenhAn_HoSo.aspx.cs" Inherits="QLBV.HoSo_HoSoBenhAn_BenhNhan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
   <ul>
        <li><a href="#">Hồ sơ</a></li>
   </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pn_GridView" Width="1130px" runat="server" BackColor="White" 
        ScrollBars="Horizontal">
        <asp:GridView ID="gv_PatientList" runat="server" OnRowDataBound="gv_PatientList_RowDataBound"
        EmptyDataText="List empty" AllowPaging="True" Width="3000px"
        AutoGenerateColumns="False" OnPageIndexChanging="gv_PatientList_PageIndexChanging"
        OnSelectedIndexChanged="gv_PatientList_SelectedIndexChanged"
        style="margin-top: 0px" BackColor="#DEBA84" BorderColor="#DEBA84" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" PageSize="10">
            <Columns>
                <asp:TemplateField HeaderText="In phiếu">
                    <ItemTemplate> 
                        <asp:HyperLink ID="HyperLink1" runat="server" Text="In phiếu" NavigateUrl='<%#"GiayRaVien.aspx?id="+ Eval("MaDieuTri") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Mã điều trị" DataField="MaDieuTri"/>
                <asp:BoundField HeaderText="Mã bệnh nhân" DataField="MaBenhNhan"/>
                <asp:BoundField HeaderText="Họ tên" DataField="HoTenBenhNhan"/>
                <asp:BoundField HeaderText="Ngày vào viện" DataField="NgayVaoVien"/>
                <asp:BoundField HeaderText="Giờ vào viện" DataField="GioVaoVien"/>
                <asp:BoundField HeaderText="Bác sĩ khám" DataField="TenBacSiKham"/>
                <asp:BoundField HeaderText="Bệnh chính" DataField="TenBenhChinh"/>
                <asp:BoundField HeaderText="Bệnh kèm theo" DataField="TenBenhKemTheo"/>
                <asp:BoundField HeaderText="Cấp cứu chẩn đoán" DataField="TenBenhCapCuuChanDoan"/>
                <asp:BoundField HeaderText="Khoa điều trị chẩn đoán" DataField="TenBenhKhoaDieuTriChanDoan"/>
                <asp:BoundField HeaderText="Nơi chuyển chẩn đoán" DataField="TenBenhNoiChuyenChanDoan"/>
                <asp:BoundField HeaderText="Xử trí" DataField="XuTri"/>
                <asp:BoundField HeaderText="Vào khoa" DataField="TenKhoa"/>
                <asp:BoundField HeaderText="Ngày làm bệnh án" DataField="NgayLamBenhAn"/>
                <asp:BoundField HeaderText="Bác sĩ làm bệnh án" DataField="TenBSLamBenhAn"/>
                <asp:BoundField HeaderText="Ngày ra viện" DataField="NgayRaVien"/>
                <asp:BoundField HeaderText="Giờ ra viện" DataField="GioRaVien"/>
                <asp:BoundField HeaderText="Người duyệt" DataField="TenNguoiDuyet"/>
                <asp:BoundField HeaderText="Mã vị trí" DataField="MaViTri"/>
            </Columns>
            <FooterStyle BackColor="#F7DFB5" BorderStyle="None" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Left" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
    </asp:Panel>
</asp:Content>
