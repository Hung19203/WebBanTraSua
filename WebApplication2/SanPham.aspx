<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="SanPham.aspx.cs" Inherits="WebApplication2.SanPham" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Lib/Datalist_Paging.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".btnSua").click(function () {

                var imgURL = $(this).closest('td').find('div').find('div').find('div').find('img').attr('src');

                $("#imgAnh").attr('src', imgURL);
                var name = imgURL.substring(0, imgURL.lastIndexOf('.'));
                var type = imgURL.substring(imgURL.lastIndexOf('.'), imgURL.length);
                $("#img4").attr('src', name + type);
                $("#img1").attr('src', name + "_1" + type);
                $("#img2").attr('src', name + "_2" + type);
                $("#img3").attr('src', name + "_3" + type);

                $("#Label3").html($(this).closest('td').find('div').find('h6').find('a').html());
                $("#Label4").html($(this).closest('td').find('div').find('h4').find('span').html());
                $("#img1").click(function () {
                    $("#imgAnh").attr('src', $(this).attr('src'));
                });
                $("#img2").click(function () {
                    $("#imgAnh").attr('src', $(this).attr('src'));
                });
                $("#img3").click(function () {
                    $("#imgAnh").attr('src', $(this).attr('src'));
                });
                $("#img4").click(function () {
                    $("#imgAnh").attr('src', $(this).attr('src'));
                });

               
            });
        });
    </script>
    <style type="text/css">.hinh{display:none;}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid col-lg-12 col-md-12 col-sm-12 ">
    <div class="row"> <!--Danh muc nhom-->
        <div class="col-3" >
            <div class="container">
                <a class="btn btn-action  text-xl-left" style="font-size: 20pt;" data-toggle="collapse"
                    href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample">
                    Danh mục nhóm </a>
                <div class="collapse show" id="collapseExample">
                    <div>
                        <ul class="list-group danhmuc" >
                            <li class="list-group-item border-0" ><a class="a text-dark" runat="server" id="filAll" onserverclick="filAll_Click" href="#">ALL</a></li>
                            <li class="list-group-item border-0"><a class="a text-secondary" runat="server" id="filAdidas" onserverclick="filAdidas_Click" href="#">Kem</a></li>
                            <li class="list-group-item border-0"><a class="a text-info" runat="server" id="filJordan" onserverclick="filJordan_Click" href="#">Trà sữa trái cây</a></li>
                            <li class="list-group-item border-0"><a class="a text-primary" runat="server" id="filNike" onserverclick="filNike_Click" href="#">Trà sữa rau củ</a></li>
                            <li class="list-group-item border-0"><a class="a text-success" runat="server" id="filAcis" onserverclick="filAcis_Click" href="#">Trà nguyên chất</a></li>
                            <li class="list-group-item border-0"><a class="a text-warning" runat="server" id="filPuma" onserverclick="filPuma_Click" href="#">Trà sữa sáng tạo</a></li>
                            <li class="list-group-item border-0"><a class="a text-body" runat="server" id="filBitis" onserverclick="filBitis_Click" href="#">Trà sữa đá xay</a></li>
                            <li class="list-group-item border-0"><a class="a text-warning" runat="server" id="filConverse" onserverclick="filConverse_Click" href="#">Trà sữa</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-9"> <!--Cac san pham-->
            <div id="par" class="container">
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" CssClass="text-left" DataKeyField="MaSP" ClientIDMode="Static"
                    RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <div class="card" style="width: 282px; margin-right:20px; margin-bottom:20px;">
                            <div class="d_effect" style="width: 100%; height: 330px;">
                                <div class="d_outside">
                                    <asp:Image ID="Image1" class="card-img-top" runat="server" CssClass="" ImageUrl="<%# Bind('Hinh','img/{0}') %>" />
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("MaSP") %>'/>
                                    <input id="mama" name="masp" type="hidden" value='<%# Eval("MaSP") %>' />
                                </div>       
                            </div>
                            <div class="card-body">
                                <h3 >
                                    <asp:LinkButton   ID="LinkButton1"  PostBackUrl='<%# Eval("MaSP","ChiTietSanPham.aspx?masp={0}") %>' Text="<%# Bind('TenSP') %>" runat="server"></asp:LinkButton> 
                                </h3>
                            </div>
                            <div class="card-footer bg-white">
                                <h4 class=" text-success font-weight-bold">
                                    <asp:Label ID="Label2" runat="server" Text="<%# Bind('GiaTien','{0:0,0 đ}') %>"
                                        Width="300px"></asp:Label>
                                </h4>
                                <button class="btn btn-danger" style="border-radius:0; height:38px;"><i class="fas fa-shopping-cart"></i></button><asp:Button ID="Button2" CssClass="btn btn-outline-danger" style="border-radius:0;" runat="server" Text="Thêm vào giỏ hàng" onclick="Button2_Click" />
                                
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</div>
</asp:Content>
