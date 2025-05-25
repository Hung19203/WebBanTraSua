<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="WebApplication2.ChiTietSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Lib/slide.js" type="text/javascript"></script>
    <style type="text/css">.hinh{display:none;}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="con-ful" style="margin-left:100px;">
        <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>
                    <div class="row">
                        <div style=" width:400px">
                            <asp:Image ID="imgAnh" runat="server" ImageUrl="<%# Bind('Hinh','img/{0}') %>" CssClass="" Height="400px" Width="400px" />
                        </div>
                        <div style="width:500px; margin-top:30px; padding-left:10px;">
                            <div>
                                <h3>Tên: <asp:Label CssClass="text-danger" ID="MaSP" runat="server" Text="<%# Bind('TenSP') %>"></asp:Label></h3>
                            </div><br />
                            <div>
                                <h3 class="text-dark">Thành phần: <asp:Label ID="Label2" CssClass="text-dark" runat="server" Text="<%# Bind('ThanhPhan') %>"></asp:Label></h3>
                            </div><br />
                            <div>
                                <h3 class="text-dark">Giá: <asp:Label ID="Label4" CssClass="text-success font-weight-bold" runat="server" Text="<%# Bind('GiaTien','{0:0,0 vnđ}') %>"></asp:Label>
                                </h3>
                            </div><br />
                            <div>
                                <button class="btn btn-outline-danger" type="button" id="btnThemVaoGioHang" runat="server" clientidmode="Static" onserverclick="btnThemVaoGioHang_Click">
                                   <i class="fas fa-shopping-cart"></i>&nbsp; Thêm vào giỏ hàng
                                </button>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>            
    </div>
</asp:Content>
