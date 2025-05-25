<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QLHSX.aspx.cs" Inherits="WebApplication2.QLHSX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Lib/Grid_Paging.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            
            $("#btnLuuHSX").hide(); //ẩn
            $("#btnThemHSX").show(); //hiện
            
            $("#txtMaHang").val('');
            $("#txtTenHang").val('');

            

            $(".btnSuaHSX").click(function () {
                $('#txtMaHang').prop('readonly', true);
                $("#txtMaHang").val($(this).closest('tr').find('td:eq(1)').html());
                $("#txtTenHang").val($(this).closest('tr').find('td:eq(2)').html());
                $("#btnThemHSX").hide(); //ẩn
                $("#btnLuuHSX").show(); //hiện
                return false;
            });

            

            
            $("#btnThemHSX").click(function () {
                if ($("#txtMaHang").val().trim() == "") {
                    setPopover($("#txtMaHang"), "Chưa nhập dữ liệu");
                    return false;
                }
                if ($("#txtTenHang").val().trim() == "") {
                    setPopover($("#txtTenHang"), "Chưa nhập dữ liệu");
                    return false;
                }

                return true;

            });

            $("#btnLuuHSX").click(function () {
                if ($("#txtMaHang").val().trim() == "") {
                    setPopover($("#txtMaHang"), "Chưa nhập dữ liệu");
                    return false;
                }
                if ($("#txtTenHang").val().trim() == "") {
                    setPopover($("#txtTenHang"), "Chưa nhập dữ liệu");
                    return false;
                }

                return true;

            });

           

            $("#btnHuyHSX").click(function () {

                $("#btnLuuHSX").hide(); //ẩn
                $("#btnThemHSX").show(); //hiện
                $("#txtMaHang").val('');
                $("#txtTenHang").val('');


            });

            function setPopover(element, message) {
                element.popover({
                    toggle: 'popover',
                    content: message
                });
                element.popover('show');
                element.focus(function () {
                    $(this).popover('dispose');
                });
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
     <div id ="parent"class="">
        <fieldset class="scheduler-border">
            <legend class="scheduler-border text-danger">Hãng sản xuất</legend>
            <div class="form-group row">
                    <label for="example-text-input" class="col-4 col-form-label text-right">
                        Mã hãng</label>
                    <div class="col-4">
                        <asp:TextBox ID="txtMaHang" CssClass="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="example-text-input" class="col-4 col-form-label text-right">
                        Tên hãng</label>
                    <div class="col-4">
                        <asp:TextBox ID="txtTenHang" CssClass="form-control" runat="server" ClientIDMode="Static" ></asp:TextBox>
                    </div>
                    <div class="col-12">
                    </br>
                        <asp:Button ID="btnThemHSX" CssClass="btn btn-outline-success justify-content-center" runat="server" ClientIDMode="Static" Text="Thêm" onclick="btnThemHSX_Click" />&nbsp
                        <asp:Button ID="btnLuuHSX" CssClass="btn btn-outline-primary" runat="server" 
                            ClientIDMode="Static"  Text="Lưu" onclick="btnLuuHSX_Click" />&nbsp
                        <asp:Button ID="btnHuyHSX" CssClass="btn btn-outline-danger" runat="server" ClientIDMode="Static"  Text="Hủy" />
                    </div>
                    <div class="col-12" style="margin-top:5px; ">
                        <asp:GridView ID="gdvSP" CssClass="text-center" ClientIDMode="Static" runat="server" 
                            AutoGenerateColumns="False" onrowcommand="gdvHangSX_RowCommand" DataKeyNames="MaHang">
                            <Columns>
                                <asp:TemplateField HeaderText="STT">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="btn-dark" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="MaHang" HeaderText="Mã Hãng">
                                <HeaderStyle CssClass="btn-dark" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TenHang" HeaderText="Tên Hãng">
                                <HeaderStyle CssClass="btn-dark" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Sửa" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnSuaHSX" CssClass="btn btn-info btnSuaHSX" value="Sửa" runat="server" ClientIDMode="Static"  Text="Sửa" CausesValidation="false" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="btn-dark" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Xóa" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnXoaHSX" CssClass="btn btn-danger" runat="server" ClientIDMode="Static" CausesValidation="false" OnClientClick="return confirm('Bạn có muốn xóa không?');" CommandArgument='<%# Eval("MaHang") %>'
                                        CommandName="xoa" Text="Xóa" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="btn-dark" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
        </fieldset>
    </div>
</asp:Content>
