function getType(typeName) {

    parentName = typeName;
    $.ajax({
        url: "menu/getTypeList",
        data: { type: typeName },
        //cache: false,
        type: "POST",
        success: function (response) {
            var elementShow = document.getElementsByClassName("tab-pane fade show active");
           
            for (var i = 0; i < elementShow.length; i++) {
                document.getElementsByClassName("tab-pane fade show active")[i].setAttribute("class", "tab-pane fade");
            }
            newDivs(response,parentName);

        },
        error: function (xhr, status, error) {

        }
    });


}

