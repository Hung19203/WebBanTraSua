<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="WebApplication2.GioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">.hinh{display:none;}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-8">
                
                <fieldset class="scheduler-border1">
                <legend class="scheduler-border1">Giỏ hàng</legend>
                    <asp:Label ID="lblTrangThai" CssClass="cart text-dark" runat="server" Text=""></asp:Label>
                    <asp:GridView ID="GridView1" CssClass="text-center border border-light" runat="server" 
                    AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate >
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Hinh") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="Image1" style="width:100px;" runat="server" ImageUrl="<%# Bind('Hinh','../img/{0}') %>"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Tên sản phẩm ">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TenSP") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" style="padding:10px;" runat="server" Text='<%# Bind("TenSP") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Thành phần ">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" style="padding:7px;" runat="server" Text='<%# Bind("ThanhPhan") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" style="padding:7px;" runat="server" Text='<%# Bind("ThanhPhan") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Giá ">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" style="padding:10px;" runat="server" Text='<%# Bind("GiaTien") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" style="padding:10px;" runat="server" Text='<%# Bind("GiaTien","{0:0,0 đ}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Số lượng">
                            <ItemTemplate>
                                <asp:Label ID="Label33" style="padding:10px;" runat="server" Text='<%# Bind("SoLuong") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thành Tiền">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ThanhTien") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" style="padding:10px;" Text='<%# Bind("ThanhTien","{0:0,0 đ}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <button id="btnXoaGH" runat="server" clientidmode="Static" onserverclick="btnXoaGH_Click" class="btn bg-white"><i class="fas fa-trash-alt"></i></button>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HyperLink ID="hplMuaTiep" CssClass="btn btn-dark" style="border-radius:0; margin-top:20px; " runat="server" 
                        NavigateUrl="~/SanPham.aspx">MUA TIẾP</asp:HyperLink>
                </fieldset>
            </div>
            <div class="col-4">
                <fieldset class="scheduler-border1">
                    <legend class="scheduler-border1">Đơn hàng</legend>
                    <div class="right-cart">
                        <h2><asp:Label ID="lblTitle" runat="server" CssClass="text-left" Text="Tổng tiền: "></asp:Label><asp:Label ID="lblTong" runat="server" CssClass="text-danger" style="float:right;" Text=""></asp:Label></h2>
                        <asp:Button ID="btnThanhToan" CssClass="checkout" runat="server" Text="ĐẶT HÀNG" onclick="btnThanhToan_Click"  />

                        <asp:HyperLink ID="hplMua" CssClass="checkout" runat="server" NavigateUrl="~/SanPham.aspx">TIẾP TỤC MUA HÀNG</asp:HyperLink>
                       
                        
                    </div>
                    
                </fieldset>
            </div>
        </div>
    </div>
    
</asp:Content>
