<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HoSo_HoSoBenhAn_VaoVien.aspx.cs" Inherits="QLBV.HoSo_HoSoBenhAn_VaoVien" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/jquery.datepick.css" rel="Stylesheet" type="text/css" />
    <link rel="Stylesheet" href="Styles/timePicker.css" type="text/css" media="all" />
    <script type="text/javascript" src="Scripts/jquery.timePicker.js"></script>
    <script type="text/javascript" src="Scripts/ui.timepickr.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="Scripts/jquery.datepick.js"></script>
        <script type="text/javascript">
            $(function () {
                $('#MainContent_day_checkin').datepick();
                $('#MainContent_txt_CheckInDay').datepick();
            });
        </script>
        <script type="text/javascript">
            jQuery(function () {
                $("#MainContent_Hour_Checkin").timePicker();
            });
        </script>
    <style type="text/css">
        .style1
        {
            height: 48px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftContent" runat="server">
    <ul>
        <li><a href="HoSo_HoSoBenhAn_HoSo.aspx">Hồ sơ</a></li>
   </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:panel runat="server">
    <div>
        <asp:Label Text="Hành chính" Width="80px" runat="server"></asp:Label>
        <asp:Panel runat="server" Width="90%" BorderWidth="1">
            <table>
                <tr>
                    <td>
                        Số bệnh án
                    </td>
                    <td>
                        <asp:TextBox Enabled="false" ID="txt_SoBA" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Mã số BN
                    </td>
                    <td>
                        <asp:TextBox ID="txt_MaBN" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Họ và tên
                    </td>
                    <td>
                        <asp:TextBox ID="txt_HoTen" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Quốc tịch
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Nationality" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ngày sinh
                    </td>
                    <td>
                        <asp:TextBox runat="server" Enabled="false" ID="dob" />
                    </td>
                    <td>
                        Phái
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rdl_GioiTinh" Enabled="false" runat="server" RepeatColumns="2">
                            <asp:ListItem Selected="True" Value="0">Nam</asp:ListItem>
                            <asp:ListItem Value="1">Nữ</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        Đối tượng
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Target" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Mã BHYT
                    </td>
                    <td>
                        <asp:TextBox ID="txt_MaBHYT" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Dân tộc
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Race" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Nghề nghiệp
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Job" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Địa chỉ
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Address" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Điện thoại
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Mobile" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
        </div>
        <br />
        <asp:Label runat="server" ID="lbl_Notification" ForeColor="Red" Font-Bold="true"></asp:Label>
        <br />
        <asp:Label Text="Quản lý người bệnh" runat="server"></asp:Label>
        <div>

            &nbsp;<asp:Panel BorderWidth="1" Width="90%" runat="server">
            <table>
                <tr>
                    <td>
                        Ngày vào viện
                    </td>
                    <td>
                        <asp:TextBox Enabled="false" ID="day_checkin" runat="server"/>
                    </td>
                    <td>
                        Giờ khám
                    </td>
                    <td>
                        <asp:TextBox ID="Hour_Checkin" Enabled="false" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Nguồn nhập viện
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_FromWhere" runat="server" 
                            DataSourceID="NguonNhapVien" DataTextField="TenNguonNhapVien" 
                            DataValueField="MaNguonNhapVien" AutoPostBack="True" 
                            OnSelectedIndexChanged="ddl_FromWhere_SelectedIndexChanged"></asp:DropDownList>
                        <asp:SqlDataSource ID="NguonNhapVien" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                            SelectCommand="SELECT * FROM [tbl_NguonNhapVien]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        Vào khoa
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_Khoa" runat="server" DataSourceID="Khoa" 
                            DataTextField="TenKhoa" DataValueField="MaKhoa"></asp:DropDownList>
                        <asp:SqlDataSource ID="Khoa" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                            SelectCommand="SELECT * FROM [tbl_Khoa]"></asp:SqlDataSource>
                    </td>
                    <td>
                        Phòng/Giường
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_Position" width="90px" runat="server" 
                            DataSourceID="ViTri" DataTextField="MaViTri" DataValueField="MaViTri" ></asp:DropDownList>
                        <asp:SqlDataSource ID="ViTri" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                            SelectCommand="SELECT [MaViTri] FROM [tbl_ViTri]"></asp:SqlDataSource>
                    </td>
                    <td>
                        Chuyển từ
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_FromHospital" Enabled="False" runat="server" 
                            DataSourceID="BenhVien" DataTextField="TenBenhVien" DataValueField="MaBenhVien"></asp:DropDownList>
                        <asp:SqlDataSource ID="BenhVien" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                            SelectCommand="SELECT [MaBenhVien], [TenBenhVien] FROM [tbl_BenhVien]">
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />

        </div><br />
        <div>
  
        <asp:Label runat="server" width="80px" Text="Chuẩn đoán"></asp:Label>
        <asp:Panel runat="server" Width="400px" BorderWidth="1">
                <table>
                    <tr>
                        <td class="style1">
                            Nơi chuyển đến
                        </td>
                        <td class="style1">
                            <asp:DropDownList ID="ddl_NoiChuyenDen" runat="server" Enabled="false"
                                DataSourceID="BenhChanDoan" DataTextField="TenBenh" DataValueField="MaBenh"></asp:DropDownList>
                            <asp:SqlDataSource ID="BenhChanDoan" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                                SelectCommand="SELECT [MaBenh], [TenBenh] FROM [tbl_Benh]">
                            </asp:SqlDataSource>
                        </td>
                        <td class="style1">
                            <asp:CheckBox ID="cb_NoiChuyenDen" runat="server" AutoPostBack="true" 
                                oncheckedchanged="cb_NoiChuyenDen_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            KKB.Cấp cứu
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_KKBCC" runat="server" DataSourceID="BenhChanDoan" Enabled="false"
                                DataTextField="TenBenh" DataValueField="MaBenh"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox ID="cb_CapCuu" runat="server" AutoPostBack="true" 
                                oncheckedchanged="cb_CapCuu_CheckedChanged"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Khi vào khoa điều trị
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_KDTCD" runat="server" DataSourceID="BenhChanDoan" Enabled="false"
                                DataTextField="TenBenh" DataValueField="MaBenh"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:CheckBox ID="cb_KDT" runat="server" AutoPostBack="true" 
                                oncheckedchanged="cb_KDT_CheckedChanged" />
                        </td>
                    </tr>
                </table>
        </asp:Panel>

        </div>
        <br /><br />
        <asp:Panel runat="server" BorderWidth="1" Width="800px">
        <table>
            <tr>
                <td>
                    Ngày làm bệnh án
                </td>
                <td>
                    <asp:TextBox ID="txt_CheckInDay" runat="server"></asp:TextBox>
                </td>
                <td>
                    Bác sĩ làm bệnh án
                </td>
                <td>
                    <asp:DropDownList ID="ddl_DrList" runat="server" DataSourceID="BacSi" 
                        DataTextField="HoTenCongNhanVien" DataValueField="MaCongNhanVien"></asp:DropDownList>
                    <asp:SqlDataSource ID="BacSi" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                        SelectCommand="SELECT [HoTenCongNhanVien], [MaCongNhanVien] FROM [tbl_CongNhanVien]">
                    </asp:SqlDataSource>
                </td>
                <td>
                    Người duyệt
                </td>
                <td>
                    <asp:DropDownList ID="ddl_CnfrmList" runat="server" DataSourceID="BacSi" 
                        DataTextField="HoTenCongNhanVien" DataValueField="MaCongNhanVien"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Lý do vào viện
                </td>
                <td colspan="3">
                    <asp:TextBox Width="300px" ID="txt_Reason" runat="server"></asp:TextBox>
                </td>
                <td colspan="2" rowspan="2">
                    <asp:Accordion
                    ID="MyAccordion"
                    runat="Server"
                    SelectedIndex="1"
                    HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected"
                    ContentCssClass="accordionContent"
                    AutoSize="None"
                    FadeTransitions="true"
                    TransitionDuration="250"
                    FramesPerSecond="40"
                    RequireOpenedPane="false"
                    SuppressHeaderPostbacks="true">
                        <Panes>
                            <asp:AccordionPane ID="AccordionPane1" runat="server"
                                HeaderCssClass="accordionHeader"
                                HeaderSelectedCssClass="accordionHeaderSelected"
                                ContentCssClass="accordionContent">
                                <Header>Tiền sử bệnh</Header>
                                <Content>
                                    <table>
                                        <tr>
                                            <td>
                                                Bản thân
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_PatientBackgroud" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Gia đình
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_FamilyBackground" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>
                </td>
            </tr>
            <tr>
                <td>
                    Quá trình bệnh lý
                </td>
                <td>
                    <asp:TextBox ID="txt_QTBL" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
        </table>
        </asp:Panel>
        <br />
        <div>
      <br /><br />
        Quá trình điều trị
        <asp:Panel runat="server" BorderWidth="1" Width="650px">
            <asp:TabContainer ID="Tabcontainer" runat="server" ActiveTabIndex="0">
                <asp:TabPanel ID="tbpn_WholeBody" runat="server" HeaderText="Chi tiết khám toàn thân">
                    <ContentTemplate>
                            <table>
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
                                        <td>
                                            Nhịp thở
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_Breathe" runat="server"></asp:TextBox>
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
                                            <asp:TextBox ID="txt_Temperature" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            độ C
                                        </td>
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
                                </table>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="tbpn_Organs" HeaderText="Các cơ quan" runat="server">
                    <ContentTemplate>
                        <asp:Panel runat="server" ScrollBars="Horizontal">
                            <table>
                                <tr>
                                    <td>
                                        Thần kinh
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_mental" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        Tuần hoàn
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_circulatory" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        Hô hấp
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_HoHap" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        Tiêu hóa
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_TieuHoa" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        Da-Mô dưới da
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_Skin" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Cơ-Xương-Khớp
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_Joint_Bone" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        Thận-Tiết niệu-Sinh dục
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_BaiTiet" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        Tai-Mũi-Họng
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_TaiMuiHong" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        Răng-Hàm-Mặt
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_Teeth" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        Các bệnh lý khác
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_Others" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </asp:Panel>
        <br />    
        </div>
        <br />
        <br />
        <div>
        
            &nbsp;<asp:Panel runat="server" BorderWidth="1" Width="500px">
        <table>
            <tr>
                <td>
                    Tiên lượng
                </td>
                <td>
                    <asp:TextBox Width="400px" Height="50px" ID="txt_TienLuong" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Hướng điều trị
                </td>
                <td>
                    <asp:TextBox  Width="400px" Height="50px" ID="txt_HuongDieuTri" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        </asp:Panel>
            
        </div>
    </asp:panel>
    <asp:Accordion
                ID="Accordion1"
                runat="Server"
                SelectedIndex="1"
                HeaderCssClass="accordionHeader"
                HeaderSelectedCssClass="accordionHeaderSelected"
                ContentCssClass="accordionContent"
                AutoSize="None"
                FadeTransitions="true"
                Width="620px"
                TransitionDuration="250"
                FramesPerSecond="40"
                RequireOpenedPane="false"
                SuppressHeaderPostbacks="true">
                    <Panes>
                        <asp:AccordionPane ID="AccordionPane2" runat="server"
                            HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                            <Header>Tiền sử bệnh</Header>
                                <Content>
                                    Chẩn đoán khi vào khoa điều trị
                                    <asp:Panel runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    Bệnh chính
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_BenhChinh" runat="server" DataSourceID="Benh" 
                                                        DataTextField="TenBenh" DataValueField="MaBenh"></asp:DropDownList>
                                                    <asp:SqlDataSource ID="Benh" runat="server" 
                                                        ConnectionString="<%$ ConnectionStrings:DB_WebBenhVienConnectionString %>" 
                                                        SelectCommand="SELECT [MaBenh], [TenBenh] FROM [tbl_Benh]">
                                                    </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Bệnh kèm theo
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_BenhKem" Enabled="False" runat="server" 
                                                        DataSourceID="Benh" DataTextField="TenBenh" DataValueField="MaBenh"></asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:CheckBox OnCheckedChanged="cb_BenhKem_CheckedChanged" AutoPostBack="true" Text="Có bệnh kèm" ID="cb_BenhKem" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
    </asp:Accordion>
    
        <asp:Button style="margin-left:270px" ID="btn_Save" runat="server" Text="Lưu" onclick="btn_Save_Click"/>
        <asp:Button style="margin-left:20px" ID="btn_Cancel" runat="server" Text="Hủy" 
            onclick="btn_Cancel_Click"/>

</asp:Content>
