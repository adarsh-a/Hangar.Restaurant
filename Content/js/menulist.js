
function sorting(sortName) {
    var elements = document.getElementsByClassName("allSort");
    elements = Array.prototype.slice.call(elements, 0);

    if (sortName == "nameAsc") {
        elements.sort(function (a, b) {
            var aTemp = a.getElementsByClassName("name")[0].innerHTML.toLowerCase(); // ading +a for integer
            var bTemp = b.getElementsByClassName("name")[0].innerHTML.toLowerCase();

            return (aTemp > bTemp ? 1 : -1);
        });
    }
    else if (sortName == "priceDsc") {
        elements.sort(function (a, b) {
            var aTemp = a.getElementsByClassName("price")[0].innerHTML.toLowerCase().split("rs")[1]; // ading +a for integer
            var bTemp = b.getElementsByClassName("price")[0].innerHTML.toLowerCase().split("rs")[1];

            return (bTemp - aTemp);
        });
    }
    else {
        elements.sort(function (a, b) {
            console.log(elements);
            var aTemp = a.children[0].classList[2].toLowerCase();
            var bTemp = b.children[0].classList[2].toLowerCase();
            return (aTemp > bTemp ? 1 : -1);
        });
    }
    var parent = document.getElementsByClassName("rowToSort")[0];
    parent.innerHTML = "";

    for (i = 0; i < elements.length; i++) {
        parent.appendChild(elements[i]);
    }
}
function checkBtnLoad() {
          
    var checkFlagElement = document.getElementById("flagElement").value;
           
    if (checkFlagElement == true) {
        document.getElementById("btnLoad").style.display =  "none";
    }
    else {
        document.getElementById("btnLoad").style.display= "block";
    }

}
  
function getMenu(parentName) {
    var countDisplay = 0;
    var countTypeDisplay = 0;
    var typeName = parentName;

    if (typeName == "all allSort") {
        countDisplay = document.getElementsByClassName("allSort").length;
    }
    else {
       countTypeDisplay = document.getElementById(parentName + "-child").getElementsByClassName(typeName).length;
    }

    $.ajax({
        url: "menu/menuDisplay",
        data: { size: countDisplay, type: typeName, sizeType: countTypeDisplay }, 
        cache: false,
        type: "POST",
        success: function (response) {

            createDivs(response, parentName);

            if (response.flag == false) {
                document.getElementById("btnLoad").style.display = "none";
            }
            else if (response.flagType == false) {

                document.getElementById(typeName + "-divLoad").style.display= "none";

            }
        },
        error: function (xhr, status, error) {

        }
    });
            
}

