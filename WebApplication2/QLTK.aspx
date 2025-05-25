<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QLTK.aspx.cs" Inherits="WebApplication2.QLTK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Lib/Grid_Paging.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id ="parent"class="">
        <fieldset class="scheduler-border">
            <legend class="scheduler-border text-danger">Tài khoản</legend>
                <asp:GridView ID="gdvSP" runat="server" AutoGenerateColumns="False"  ClientIDMode="Static"  >
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle CssClass="btn-dark" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="USERNAME" HeaderText="Tên đăng nhập">
                        <HeaderStyle CssClass="btn-dark" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EMAIL" HeaderText="Email">
                        <HeaderStyle CssClass="btn-dark" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PHONE" HeaderText="Phone">
                        <HeaderStyle CssClass="btn-dark" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ADDRESS" HeaderText="Địa chỉ">
                        <HeaderStyle CssClass="btn-dark" />
                        </asp:BoundField>
                    </Columns>      
                </asp:GridView>
        </fieldset>
    </div>
    
</asp:Content>
