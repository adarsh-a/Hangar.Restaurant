window.onload = function() {
    this.checkLoadMore("load");
}

function checkLoadMore(child) {
    var btn = document.getElementById("loadMore");

    if (document.contains(btn)) {
        shButton(child)
    }
}

function shButton(child, hasNext) {

    var btn = document.getElementById("v-pills-home").getElementsByClassName("btn")[0];;

    if (child == "load") {
        hasNextLoad = document.getElementById("hasNext").value;

        if (hasNextLoad == "True" || hasNextLoad == "true") {
            btn.style.display = "block";
        } else {
            btn.style.display = "none";
        }
    } else if (child == 'all') {
        if (hasNext) {
            btn.style.display = "block";
        } else {
            btn.style.display = "none";
        }
    } else {
        btn = document.getElementById(child).getElementsByClassName("btn")[0];
        if (hasNext) {
            btn.style.display = "block";
        } else {
            btn.style.display = "none";
        }
    }
}

function GetMenu(childClassName) {
    var divCount = "";

    if (childClassName != "all") {
        divCount = document.getElementById(childClassName).getElementsByClassName(childClassName).length;
    } else {
        divCount = document.getElementsByClassName(childClassName).length;
    }

    $.ajax({
        type: "POST",
        url: "Menu/loadMenu",
        data: { skip: divCount, type: childClassName },
        success: function(response) {
            displayMore(response, childClassName);
        },
        failure: function(response) {
            alert("No more menu!!!");
        }
    });
}

function displayMore(data, childClassName) {
    var parent = document.getElementsByClassName(childClassName + "-parent")[0];
    var menu = data.menuListModel;
    var hasNext = data.hasNext;
    for (i = 0; i < menu.length; i++) {

        //create elements

        var div1 = document.createElement('div');
        var div2 = document.createElement('div');
        var div3 = document.createElement('div');
        var img = document.createElement('img');
        var h4 = document.createElement('h4');
        var h5 = document.createElement('h5');
        var p = document.createElement('p');
        div1.setAttribute('class', 'col-lg-4 col-md-6 special-grid ' + childClassName);
        div2.setAttribute('class', 'gallery-single fix ' + menu[i].Type.name);
        div3.setAttribute('class', 'why-text');
        img.setAttribute('src', menu[i].Image);
        img.setAttribute('class', 'img-fluid');
        img.setAttribute('alt', 'Image');
        h4.setAttribute('class', 'name');
        h5.setAttribute('class', 'price');

        textP = document.createTextNode(menu[i].Description);
        textH4 = document.createTextNode(menu[i].Name);
        textH5 = document.createTextNode(menu[i].Price);

        //assign text
        p.appendChild(textP);
        h4.appendChild(textH4);
        h5.appendChild(textH5);

        //div structure
        div3.appendChild(h4);
        div3.appendChild(p);
        div3.appendChild(h5);
        div2.appendChild(img);
        div2.appendChild(div3);
        div1.appendChild(div2);
        parent.appendChild(div1);

    }
    //show or hide loadMore button
    shButton(childClassName, hasNext);
}