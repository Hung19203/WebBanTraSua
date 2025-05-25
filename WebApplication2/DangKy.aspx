<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="DangKy.aspx.cs" Inherits="WebApplication2.DangKy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hinh
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-4">
            </div>
            <div class="col-4">
                <div class="container text-center">
                    <span class="header-contact header-page clearfix">
                        <h1>
                            ĐĂNG KÝ</h1>
                    </span>
                    <div class="col-auto">
                        <div class="input-group mb-2">
                            <div class="input-group-prepend">
                                <div class="input-group-text bg-danger" style="width: 42px; height: 40px; font-size: 16pt;">
                                    <i class="fas fa-user"></i>
                                </div>
                            </div>
                            <asp:TextBox CssClass="form-control" ClientIDMode="Static" ID="txtUser" runat="server"
                                placeholder="Tên đăng nhập"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-auto">
                        <div class="input-group mb-2">
                            <div class="input-group-prepend">
                                <div class="input-group-text bg-danger" style="width: 42px; height: 40px; font-size: 16pt;">
                                    <i class="fas fa-key"></i>
                                </div>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtPass" ClientIDMode="Static" TextMode="Password"
                                runat="server" placeholder="Mật khẩu"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-auto">
                        <div class="input-group mb-2">
                            <div class="input-group-prepend">
                                <div class="input-group-text bg-danger" style="width: 42px; height: 40px; font-size: 16pt;">
                                    <i class="fas fa-key"></i>
                                </div>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtPass2" ClientIDMode="Static" TextMode="Password"
                                runat="server" placeholder="Nhập lại mật khẩu"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-auto">
                        <div class="input-group mb-2">
                            <div class="input-group-prepend">
                                <div class="input-group-text bg-danger" style="width: 42px; height: 40px; font-size: 16pt;">
                                    <i class="fas fa-envelope"></i>
                                </div>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtEmail" ClientIDMode="Static" runat="server"
                                placeholder="Email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-auto">
                        <div class="input-group mb-2">
                            <div class="input-group-prepend">
                                <div class="input-group-text bg-danger" style="width: 42px; height: 40px; font-size: 18pt;">
                                    <i class="fas fa-mobile"></i>
                                </div>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtSDT" ClientIDMode="Static" runat="server"
                                placeholder="Số điện thoại"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-auto">
                        <div class="input-group mb-2">
                            <div class="input-group-prepend">
                                <div class="input-group-text bg-danger" style="width: 42px; height: 40px; font-size: 16pt;">
                                    <i class="fas fa-map-marker"></i>
                                </div>
                            </div>
                            <asp:TextBox CssClass="form-control" ID="txtDiaChi" ClientIDMode="Static" runat="server"
                                placeholder="Địa chỉ"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <asp:Button ID="btnDK" CssClass="btn btn-success" ClientIDMode="Static" Style="width: 100%;"
                            runat="server" Text="Đăng ký" OnClick="btnDK_Click" />
                    </div>
                    <script>
                        $(document).ready(function () {
                            var register = false;
                            $("#btnDK").click(function () {
                                var user = $("#txtUser");
                                var pass = $("#txtPass");
                                var pass_confirm = $("#txtPass2");
                                var mail = $("#txtEmail");
                                var phone = $("#txtSDT");
                                var address = $("#txtDiaChi");
                                // Kiểm tra rỗng
                                switch ('') {
                                    case user.val().trim():
                                        {
                                            user.val('');
                                            setPopover(user, 'Chưa nhập tài khoản');
                                            return false;
                                        }; break;
                                    case pass.val().trim():
                                        {
                                            pass.val('');
                                            setPopover(pass, 'Chưa nhập mật khẩu');
                                            return false;
                                        }; break;
                                    case pass_confirm.val().trim():
                                        {
                                            pass_confirm.val('');
                                            setPopover(pass_confirm, 'Chưa nhập xác nhận mật khẩu');
                                            return false;
                                        }; break;
                                    case mail.val().trim():
                                        {
                                            mail.val('');
                                            setPopover(mail, 'Chưa nhập email');
                                            return false;
                                        }; break;
                                    case phone.val().trim():
                                        {
                                            phone.val('');
                                            setPopover(phone, 'Chưa nhập điện thoại');
                                            return false;
                                        }; break;
                                    case address.val().trim():
                                        {
                                            address.val('');
                                            setPopover(address, 'Chưa nhập địa chỉ');
                                            return false;
                                        }; break;
                                }
                                // Kiểm tra mật khẩu và mật khẩu xác nhận
                                if (pass.val().trim() != pass_confirm.val().trim()) {
                                    setPopover(pass, 'Mật khẩu và xác nhận chưa trùng khớp');
                                    setPopover(pass_confirm, 'Mật khẩu và xác nhận chưa trùng khớp');
                                    return false;
                                }
                                // Kiểm tra tài khoản đã tồn tại chưa
                                if (!register) {
                                    setPopover(user, 'Tài khoản đã tồn tại');
                                    return false;
                                }
                            });

                            $("#btnDK").mouseenter(function () {
                                var user = $("#txtUser").val().trim();
                                $.ajax({
                                    type: "POST",
                                    url: "/Handle/ActionMethod.aspx/isExsistUsername",
                                    data: '{username: "' + user + '"}',
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (response) {
                                        register = response.d;
                                    }
                                });
                            });

                            function setPopover(element, message) {
                                element.popover({
                                    toggle: 'popover',
                                    content: message,
                                    placement: 'right'
                                });
                                element.popover('show');
                                element.focus(function () {
                                    $(this).popover('dispose');
                                });
                            }

                        });
                    </script>
                </div>
            </div>
            <div>
            </div>
        </div>
    </div>
</asp:Content>
