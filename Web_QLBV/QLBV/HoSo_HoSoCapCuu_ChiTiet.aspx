<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HoSo_HoSoCapCuu_ChiTiet.aspx.cs" Inherits="QLBV.HoSo_HoSoCapCuu_ChiTiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <ul>
        <li><a href="HoSo_HoSoCapCuu_DS.aspx">Danh sách</a></li>
        <li><a href="#">Chi tiết</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel ID="pn_GridView" runat="server" BackColor="White" Width="1130px"
        ScrollBars="Horizontal">
        <asp:GridView ID="gv_DSCapCuuChiTiet" runat="server"
         EmptyDataText="List empty" AllowPaging="True"
        AutoGenerateColumns="False" OnPageIndexChanging="gv_DSCapCuuChiTiet_PageIndexChanging"
        OnSelectedIndexChanged="gv_DSCapCuuChiTiet_SelectedIndexChanged"
            style="margin-top: 0px" BackColor="#DEBA84" BorderColor="#DEBA84" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
            <Columns>
             <asp:TemplateField HeaderText="Mã điều trị">
                        <ItemTemplate>
                            <asp:LinkButton ID="lb_ID" runat="server" Text='<%# Eval("MaDieuTri") %>' 
                               OnClick="LoadList" ></asp:LinkButton>
                        </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField HeaderText="Ngày vào viện" DataField="NgayVaoVien"/>
             <asp:BoundField HeaderText="Giờ vào viện" DataField="GioVaoVien"/>
             <asp:BoundField HeaderText="Bác sĩ khám" DataField="BacSiKham"/>
             <asp:BoundField HeaderText="Bệnh chính" DataField="TenBenhChinh"/>
             <asp:BoundField HeaderText="Bệnh kèm theo" DataField="TenBenhKemTheo"/>
             <asp:BoundField HeaderText="Cấp cứu chẩn đoán" DataField="TenBenhCapCuuChanDoan"/>
             <asp:BoundField HeaderText="Khoa điều trị chẩn đoán" DataField="TenBenhKhoaDieuTriChanDoan"/>
             <asp:BoundField HeaderText="Nơi chuyển chẩn đoán" DataField="TenBenhNoiChuyenChanDoan"/>
             <asp:BoundField HeaderText="Xử trí" DataField="XuTri"/>
             <asp:BoundField HeaderText="Vào khoa" DataField="TenKhoa"/>
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
