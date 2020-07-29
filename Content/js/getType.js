function getType(typeName) {

   
    $.ajax({
        url: "menu/getTypeList",
        data: { type: typeName },
        //cache: false,
        type: "POST",
        success: function (response) {

            console.log(response.menuTypes);

        },
        error: function (xhr, status, error) {

        }
    });


}

