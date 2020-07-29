
        /*$(document).ready(function () {
            $(".all").hide();
            $(".all").slice(0, 3).show();
            if ($(".all").length>3) {
                $("#btnLoadMore").show();
            }
            else {
                $("#btnLoadMore").hide();
            }
            $("#btnLoadMore").on('click', function (e) {
                e.preventDefault();
                $(".all:hidden").slice(0, 3).slideDown();
                if ($(".all:hidden").length == 0) {
                        $("#btnLoadMore").fadeOut('slow');
                }
            });
            //lunch
            $(".lunch").hide();
            $(".lunch").slice(0, 9).show();
            if ($(".lunch").length > 9 ) {
                $("#btn-lunch").show();
            }
            else {
                $("#btn-lunch").hide();
            }
            $("#btn-lunch").on('click', function (e) {
                e.preventDefault();
                $(".lunch:hidden").slice(0, 9).slideDown();
                if ($(".lunch:hidden").length == 0) {
                    $("#btn-lunch").fadeOut('slow');
                }
            });
            //dinner
            $(".dinner").hide();
            $(".dinner").slice(0, 9).show();
            if ($(".dinner").length > 9) {
                $("#btn-dinner").show();
            }
            else {
                $("#btn-dinner").hide();
            }
            $("#btn-dinner").on('click', function (e) {
                e.preventDefault();
                $(".dinner:hidden").slice(0, 9).slideDown();
                if ($(".dinner:hidden").length == 0) {
                    $("#btn-dinner").fadeOut('slow');
                }
            });
            //drink
            $(".drinks").hide();
            $(".drinks").slice(0, 9).show();
            if ($(".drinks").length > 9) {
                $("#btn-drinks").show();
            }
            else {
                $("#btn-drinks").hide();
            }
            $("#btn-drinks").on('click', function (e) {
                e.preventDefault();
                $(".drinks:hidden").slice(0, 9).slideDown();
                if ($(".drinks:hidden").length == 0) {
                    $("#btn-drinks").fadeOut('slow');
                }
            });
        });*/

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
        /*function checkBtnLoad() {
          
            var checkFlagElement = document.getElementById("flagElement").value;
            console.log(checkFlagElement);
            if (checkFlagElement == true) {
                document.getElementsByClassName("btnLoad").style("display", "none");
            }
            else {
                document.getElementsByClassName("btnLoad").style("display", "none");
            }

        }*/
  
        function getMenu() {
            var countDisplay = document.getElementsByClassName("allSort").length;
            $.ajax({
                url: "menu/menuDisplay",
                data: { size: countDisplay }, 
                cache: false,
                type: "POST",
                success: function (response) {
                    
                    count = response.modelCount;
                    flag = response.flag;
                    for (var i = 0; i < count; i++) {
                    
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

                        container.setAttribute("class", "col-lg-4 col-md-6 special-grid all allSort");
                        container2.setAttribute("class", "gallery-single fix " +typeName );
                        
                        img.setAttribute("class", "img-fluid");
                        img.setAttribute("src", image);
                        img.setAttribute("alt", "Image");
                        
                       
                        containerTxt.setAttribute("class", "why-text");
                        h4.setAttribute("class", "name");
                        h5.setAttribute("class", "price");

                        document.getElementById("rowToSort").appendChild(container);
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
                    //countAllDisplay = countDisplay + count;
                    /*
                    if ( countAllDisplay ==response.collectionCount) {
                        $("#btnLoadMore").hide();
                    }*/
                    if (flag == false) {
                        document.getElementsByClassName("btnLoad").style("display", "none");
                    }

                },
                error: function (xhr, status, error) {

                }
            });
            
                
        }

