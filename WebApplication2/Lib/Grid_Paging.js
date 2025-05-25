$(document).ready(function () {
    /* Đổi thông số tại đây */
    var ID_Grid_View = "gdvSP"; // id của grid view
    var ID_Div_Chua_Grid_View = "parent"; // id của cặp div chứa gridview
    //////////////////////////
    // Code xử lý phía dưới không sửa
    //////////////////////////
    // Biến toàn cục
    var RowTotal = $("#" + ID_Grid_View + " tr").length - 1; // Tổng số dòng grdiview
    var GridView = $("#" + ID_Grid_View);
    var Parent = $("#" + ID_Div_Chua_Grid_View);
    var pagenumber = CreatePageNumber();    // Tạo số trang
    GridView.addClass('table');
    GridView.addClass('table-sm');
    GridView.addClass('text-center');
    // Tạo danh sách phân trang
    DisplayGridView(1);
    // Hiển thị số trang
    Paging();
    /* Thao tác chọn trang */
    $(".page_number").click(function () {
        var x = $(this).html();
        DisplayGridView(x);
        CurrenPage(x);
    });
    /*---------- Thủ tục xử lý ----------*/
    // Hiển thị số lượng phần tử gridview theo trang
    function DisplayGridView(pageNumber) {
        for (var i = 1; i <= RowTotal; i++) {
            if (i >= (((pageNumber - 1) * 5) + 1) && i <= (pageNumber * 5))
                GridView.find('tr:eq(' + i + ')').css('display', '');
            else
                GridView.find('tr:eq(' + i + ')').css('display', 'none');
        }
    }
    // Tạo số trang
    function CreatePageNumber() {
        var x = Math.floor(RowTotal / 5);
        var y = RowTotal % 5;
        return y > 0 ? (x + 1) : x;
    }
    // Tạo danh sách số trang phía dưới
    function Paging() {
        var paging = '<div>';
        paging += '<div class="row justify-content-center">';
        for (var i = 1; i <= pagenumber; i++) {
            paging += '<div class="col-sm-1 text-center page-link page_number">';
            paging += i;
            paging += '</div>';
        }
        paging += '</div>';
        paging += '</div>';
        paging += '<div class="text-center" id="currentPage">';
        paging += "Trang " + 1;
        paging += "</div>";
        // Hiển thị lên DOM
        Parent.append(paging);
    }
    // Trang đang chọn
    function CurrenPage(pageNumber) {
        $("#currentPage").html("Trang " + pageNumber);
    }
});