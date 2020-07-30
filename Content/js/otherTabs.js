function changeTab(type) {

    //under parent div but ouside loop
    var divUpper1 = document.getElementById(type);
    var divUpper2 = document.getElementsByClassName(type + "-parent")[0];

    if (!document.contains(divUpper1) && !document.contains(divUpper2)) {
        requestTab(type);
    }


}

function requestTab(tabType) {
    $.ajax({
        type: "POST",
        url: "Menu/OtherTabs",
        data: { type: tabType },
        success: function(response) {
            createTab(response, tabType);
        },
        failure: function(response) {
            alert("No more menu!!!");
        }
    });
}



function createTab(data, tabType) {
    var parent = document.getElementById("v-pills-tabContent");

    //hide all other type menu
    var others = document.getElementsByClassName('tab-pane');

    for (i = 0; i < others.length; i++) {
        others[i].setAttribute('class', 'tab-pane fade')
    }

    divUpper1 = document.createElement('div');
    divUpper2 = document.createElement('div');
    loadBtn = document.createElement('button');

    divUpper1.setAttribute('class', 'tab-pane fade show active');
    divUpper1.setAttribute('id', tabType);
    divUpper1.setAttribute('role', 'tabpanel');
    divUpper1.setAttribute('aria-labelledby', tabType + '-tab');
    divUpper2.setAttribute('class', 'row ' + tabType + '-parent');
    loadBtn.setAttribute('id', 'loadMore');
    loadBtn.setAttribute('type', 'submit');
    loadBtn.setAttribute('class', 'btn btn-lg btn-circle btn-outline-new-white');
    loadBtn.setAttribute('onclick', "GetMenu('" + tabType + "')");
    loadBtn.innerHTML = "Load More";

    divUpper1.appendChild(divUpper2);
    divUpper1.appendChild(loadBtn);
    parent.appendChild(divUpper1);

    displayMore(data, tabType);
}