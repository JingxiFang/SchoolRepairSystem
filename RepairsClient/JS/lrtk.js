//star
$(document).ready(function () {
    var stepW = 80;
    var stars = $("#star > li");
    var rank;
    $("#showb").css("width", 0);
    $("#btnCancle").click(function () {
        window.history.back(-1);
    });

    stars.each(function (i) {
        $(stars[i]).click(function (e) {
            var n = i + 1;
            rank = n;
            //alert(n);
            $("#showb").css({ "width": stepW * n });
            $(this).find('a').blur();
            return stopDefault(e);
        });
    });
    $("#btnSubmit").click(function () {
        //alert(rank);
        var id = $("#faultID").text();
        var content = $("#txtEvaluate").val();
        //alert(id);
        // alert(content);
        updateEvaluate(id, rank, content);
    });
});
function updateEvaluate(id, rank, content) {
    $.post(
    "Evaluate.ashx",
    "id=" + id + "&rank=" + rank + "&content=" + content,
    function (msg) {
        if (msg == "1") {
            alert("谢谢，评价成功，我们会认真参考");
            window.history.back(-1);
        }
        else {
            alert("评价失败，请稍后重试");
        }
    }
    );
}
function stopDefault(e) {
    if (e && e.preventDefault)
        e.preventDefault();
    else
        window.event.returnValue = false;
    return false;
};
