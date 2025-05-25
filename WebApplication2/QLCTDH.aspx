<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QLCTDH.aspx.cs" Inherits="WebApplication2.QLCTDH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Lib/Grid_Paging.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="parent">
        <fieldset class="scheduler-border">
            <legend class="scheduler-border text-danger">Chi tiết đơn hàng</legend>
                <asp:GridView ID="gdvSP" runat="server" ClientIDMode="Static" 
                AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate >
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle CssClass="btn-dark" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="USERNAME" HeaderText="Tên người dùng">
                        <HeaderStyle CssClass="btn-dark" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MaSP" HeaderText="Mã sản phẩm">
                        <HeaderStyle CssClass="btn-dark" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SoLuong" HeaderText="Số lượng">
                        <HeaderStyle CssClass="btn-dark" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Giá ">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("GiaTien","{0:0,0 đ}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("GiaTien") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle CssClass="btn-dark" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="TrangThai" HeaderText="Trạng thái">
                        <HeaderStyle CssClass="btn-dark" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
        </fieldset>
    </div>
</asp:Content>
