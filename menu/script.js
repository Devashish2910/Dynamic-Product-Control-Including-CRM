
var ww = document.body.clientWidth;

jQuery(document).ready(function () {
    jQuery(".nav1 li a").each(function () {
        if (jQuery(this).next().length > 0) {
            jQuery(this).addClass("parent");
        };
    })

    jQuery(".toggleMenu").click(function (e) {
        e.preventDefault();
        //jQuery(this).toggleClass("active");
        //jQuery(".nav1").toggle();

    });
    adjustMenu();
})

jQuery(window).bind('resize orientationchange', function () {
    ww = document.body.clientWidth;
    adjustMenu();


    jQuery(".nav1").show();
});

var adjustMenu = function () {
    if (ww < 1023) {

        var pathname = window.location.pathname;
       // alert(pathname);
        if (pathname == "" || pathname == "/default.aspx" || pathname == "/Default.aspx" || pathname == "/")
            //if (pathname == "/21-3-2014/" || pathname == "/21-3-2014/Default.aspx") 
        {
            jQuery(".toggleMenu").css("display", "inline-block");
            jQuery(".navbar").css("display", "block");
        }
     
        else {
            jQuery(".toggleMenu").css("display", "none");
            jQuery(".navbar").css("display", "none");
        }

        //jQuery(".toggleMenu").css("display", "inline-block");
        if (!jQuery(".toggleMenu").hasClass("active")) {
            //jQuery(".nav1").hide();
        } else {
            jQuery(".nav1").show();
        }
        jQuery(".nav1 li").unbind('mouseenter mouseleave');
        jQuery(".nav1 li a.parent").unbind('click').bind('click', function (e) {
            // must be attached to anchor element to prevent bubbling
            e.preventDefault();
            jQuery(this).parent("li").toggleClass("hover");
        });
    }
    else if (ww >= 1024) {
        jQuery(".toggleMenu").css("display", "none");
        jQuery(".navbar").css("display", "block");
        jQuery(".nav1").show();
        jQuery(".nav1 li").removeClass("hover");
        jQuery(".nav1 li a").unbind('click');
        jQuery(".nav1 li").unbind('mouseenter mouseleave').bind('mouseenter mouseleave', function () {
            // must be attached to li so that mouseleave is not triggered when hover over submenu
            jQuery(this).toggleClass('hover');
        });
    }
}

