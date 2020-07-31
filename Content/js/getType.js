function getType(typeName) {

    parentName = typeName;
    $.ajax({
        url: "menu/getTypeList",
        data: { type: typeName },
        //cache: false,
        type: "POST",
        success: function (response) {
            
            newDivs(response,parentName);

        },
        error: function (xhr, status, error) {

        }
    });


}

