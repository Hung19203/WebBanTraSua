<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DataManager.aspx.cs" Inherits="WebApplication2.DataManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div>
            <h2 class="text-center">
                <asp:Label ID="Label6" runat="server" Text="Quản lý nhân viên" BackColor="White"></asp:Label>
            </h2>
            <asp:Label ID="Label7" runat="server" Text="1" Visible="False"></asp:Label>
            <br />
            <asp:Table ID="Table2" runat="server" BorderStyle="Solid" BorderColor="Black" BorderWidth="1px">

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" Width="100px">
                        <asp:Label ID="Label1" runat="server" Text="Họ và tên:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server" Width="500px">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> 
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" Width="100px">
                        <asp:Label ID="Label2" runat="server" Text="Giới tính:"></asp:Label> 
                    </asp:TableCell>
                    <asp:TableCell runat="server" Width="500px">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> 
                   </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" Width="100px">
                        <asp:Label ID="Label3" runat="server" Text="Địa chỉ:"></asp:Label> 
                    </asp:TableCell>
                    <asp:TableCell runat="server" Width="500px">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox> 
                   </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" Width="100px">
                        <asp:Label ID="Label4" runat="server" Text="SĐT:"></asp:Label> 
                    </asp:TableCell>
                    <asp:TableCell runat="server" Width="500px">
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                   </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Right" Width="100px">
                        <asp:Label ID="Label5" runat="server" Text="Lương:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server" Width="500px">
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox> 
                   </asp:TableCell>
                </asp:TableRow>           
            </asp:Table>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>                       
            <asp:Button ID="Button1" runat="server" Text="Thêm" OnClick="Add_Value"/>            
            <asp:Button ID="Button2" runat="server" Text="Sửa" Enabled="false" OnClick="Button2_Click"/>
            <br />
            <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderColor="Black" BorderWidth="1px">
            </asp:Table>
    </div>
    </form>
</asp:Content>

