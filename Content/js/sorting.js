function sorting(sortName) {
    sortingName = sortName;
    
    parentName = "all allSort";
    $.ajax({
        url: "menu/getSort",
        data: { sortType: sortingName },
        cache: false,
        type: "POST",
        success: function (response) {
            document.getElementById("rowToSort").innerHTML = "";
            createDivs(response, parentName);  
        },
        error: function (xhr, status, error) {

        }
    });
}