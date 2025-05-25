<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QLDH.aspx.cs" Inherits="WebApplication2.QLDH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Lib/Grid_Paging.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="parent">
        <fieldset class="scheduler-border">
            <legend class="scheduler-border text-danger">Đơn hàng</legend>
                 <asp:GridView ID="gdvSP" runat="server" ClientIDMode="Static" 
                AutoGenerateColumns="False">
                     <Columns>
                         <asp:BoundField DataField="MAHD" HeaderText="Mã HD">
                         <HeaderStyle CssClass="btn-dark" />
                         </asp:BoundField>
                         <asp:BoundField DataField="USERNAME" HeaderText="Tên người dùng">
                         <HeaderStyle CssClass="btn-dark" />
                         </asp:BoundField>
                         <asp:TemplateField HeaderText="Tổng tiền">
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("TongTien","{0:0,0 đ}") %>'></asp:Label>
                             </ItemTemplate>
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TongTien") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <HeaderStyle CssClass="btn-dark" />
                         </asp:TemplateField>
                         <asp:BoundField DataField="Ngay" HeaderText="Ngày">
                         <HeaderStyle CssClass="btn-dark" />
                         </asp:BoundField>
                     </Columns>
                 </asp:GridView>
        </fieldset>
    </div>
   
</asp:Content>
