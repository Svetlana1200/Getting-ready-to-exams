$("input[name='UserCondition']").change(function () {
    if ($(this).val() == "Timer") {
        $("#Time").show();
    }
    else {
        $("#Time").hide();
        $("#Time").val(1);
    }
});

$("input[name='UserLevel']").change(function () {
    if ($(this).val() == "B1") {
        $("#Images").parent().show();
    }
    else {
        $("#Images").parent().hide();
        if ($("#Images").is(":checked")) {
            $("#All").prop("checked", true);
        }
    }
});

