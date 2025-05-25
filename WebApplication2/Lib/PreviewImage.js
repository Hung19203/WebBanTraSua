$(document).ready(function () {
    $(".up-preview").change(function () {
        $(".show-preview").html("");
        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
        if (regex.test($(this).val().toLowerCase())) {
            if ($.browser.msie && parseFloat(jQuery.browser.version) <= 9.0) {
                $(".show-preview").show();
                $(".show-preview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
            }
            else {
                if (typeof (FileReader) != "undefined") {
                    $(".show-preview").show();
                    $(".show-preview").append('<img Width="100px" />');
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $(".show-preview img").attr("src", e.target.result);
                    }
                    reader.readAsDataURL($(this)[0].files[0]);
                } else {
                    alert("Trình duyệt này không hỗ trợ FileReader.");
                }
            }
        } else {
            alert("Tệp không hợp lệ");
        }
    });
});