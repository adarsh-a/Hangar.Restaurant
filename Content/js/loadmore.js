$(function () {

    $(".js_LoadMore").on("click", function (e) {
        e.preventDefault();
        var container = $(".tab-pane.fade.show.active").find(".row");
        var menulist = container.find(".special-grid").length;
        
        console.log("text" + menulist);
         $.ajax({url: "/menu/loadmore", 
          data: {count: menulist},
            dataType: "json",
          success: function(result) 
          {         
            var menuHtml = '<div class="col-lg-4 col-md-6 special-grid Hangar.Restaurant.Models.MenuType"> <div class="gallery-single fix"><img src="../Content/images/img-01.jpg" class="img-fluid" alt="Image"><div class="why-text"><h4>SD1</h4><p>Sed id magna vitae eros sagittis euismod.</p> <h5>$7.79</h5></div></div></div>';

//dummy
       var menulist = result.Menus;     
        if(!result.ShowLoadMore)
        {
          $(".js_LoadMore").toggle();  
        } 
            
            
                                 
             //var div = $("<div>");
             //div.addClass("tab-pane fade" ) 
             //alert("success");
             for (i=0;i<menulist.length; i++)
             {
                 //console.log(result[i].Name);
                 //console.log(i);
                 console.log(menulist[i]);
                 //$('.loadmenu').html('Names'+ result[i].Name);
                 var divElement = document.createElement('div');
                 divElement.className="col-lg-4 col-md-6 special-grid " + menulist[i].Typex.Name;
     
                 var divGallery = document.createElement('div');
                 divGallery.className="gallery-single fix";
     
                 var divClass = document.createElement('div');
                 divClass.className="why-text";
     
                 var img = document.createElement('img');
                 img.src='../' + menulist[i].Image;
                 img.className="img-fluid";
     
                 var para = document.createElement('p');
                 var add_para = document.createTextNode(menulist[i].Description);
     
                 var head4 = document.createElement('h4');
                 var header4 = document.createTextNode(menulist[i].Name);
     
                 var head5 = document.createElement('h5');
                 var header5 = document.createTextNode('$' + menulist[i].Price);
     
                 divGallery.append(img);
                 para.append(add_para);
                 head4.append(header4);
                 head5.append(header5);
                 divClass.append(head4, para, head5);
                 divGallery.append(divClass);
                 divElement.append(divGallery);

                 $(".tab-pane.fade.show.active").find(".row").append(divElement);
                 
                 
             }


             //console.log(result);
             
             //console.log(result[i].Name);
             //console.log(result[i].Price);
             //console.log(result[i].Description);
             //console.log(result[i].Image);
          }
          
          
        });
        
    });

    
});