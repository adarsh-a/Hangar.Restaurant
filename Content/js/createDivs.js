function createDivs(response, parentName) {
    count = response.modelCount;
    flag = response.flag;
  
    for (var i = 0; i < count; i++) {//all all-parent drinks drinks-parent var child+ '-parent'

        var name = document.createTextNode(response.menulist[i].Name);
        var price = document.createTextNode(response.menulist[i].Price);
        var description = document.createTextNode(response.menulist[i].Description);
        var typeName = response.menulist[i].Type.Name;
        var image = response.menulist[i].Image;

        var container = document.createElement("DIV");
        var container2 = document.createElement("DIV");
        var img = document.createElement("IMG");
        var containerTxt = document.createElement("DIV");
        var h4 = document.createElement("H4");
        var p = document.createElement("P");
        var h5 = document.createElement("H5");

        container.setAttribute("class", "col-lg-4 col-md-6 special-grid " + parentName);
        container2.setAttribute("class", "gallery-single fix ");

        img.setAttribute("class", "img-fluid");
        img.setAttribute("src", image);
        img.setAttribute("alt", "Image");


        containerTxt.setAttribute("class", "why-text");
        h4.setAttribute("class", "name");
        h5.setAttribute("class", "price");

        if (parentName == "all allSort") {
            document.getElementById("rowToSort").appendChild(container);

        }
        else if (parentName == typeName){
            document.getElementById(parentName + "-child").appendChild(container);

        }
        container.appendChild(container2);
        container2.appendChild(img);
        container2.appendChild(containerTxt);
        containerTxt.appendChild(h4);
        containerTxt.appendChild(p);
        containerTxt.appendChild(h5);


        h4.appendChild(name);
        h5.appendChild(price);
        p.appendChild(description);
    }
}
function newDivs(response, parentName) {
    var elements = document.getElementById(parentName);

    if (!document.contains(elements)) {
        var elementShow = document.getElementsByClassName("tab-pane fade show active");

        for (var i = 0; i < elementShow.length; i++) {
            document.getElementsByClassName("tab-pane fade show active")[i].setAttribute("class", "tab-pane fade");
        }
        var divParentType = document.createElement("DIV");
        divParentType.setAttribute("class", "tab-pane fade show active");
        divParentType.setAttribute("id", parentName );
        divParentType.setAttribute("role", "tabpanel");
        divParentType.setAttribute("aria-labelledby",parentName+"-tab");

        
        document.getElementById("v-pills-tabContent").appendChild(divParentType);

        var divParentRow = document.createElement("DIV");
        divParentRow.setAttribute("id", parentName+"-child");
        divParentRow.setAttribute("class", "row");
        document.getElementById(parentName).appendChild(divParentRow);

        createDivs(response, parentName);

        var divBtnLoad = document.createElement("DIV");
        divBtnLoad.setAttribute("id", parentName + "-divLoad");
        var btnLoadMore = document.createElement("BUTTON");
        btnLoadMore.setAttribute("class", "btn btn-lg btn-circle btn-outline-new-white btnLoad");
        btnLoadMore.setAttribute("onclick", "getMenu('" + parentName + "')");
        btnLoadMore.setAttribute("id", "btnloadType");
        var txtBtnLoad = document.createTextNode("Load More");
        btnLoadMore.appendChild(txtBtnLoad);
        divBtnLoad.appendChild(btnLoadMore);
        divParentType.appendChild(divBtnLoad);

    }
}