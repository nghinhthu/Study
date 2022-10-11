// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(window).bind('scroll', function () {
    if ($(window).scrollTop() > 100) {
        $('.menu').addClass('fixed');
        $('.active-item').removeClass('active');

    } else {
        $('.menu').removeClass('fixed');
        $('.active-item').addClass('active');
    }
});
//$(window).scroll(function () {
//    var scroll = $(window).scrollTop();

//    if (scroll < 250) {
//        //clearHeader, not clearheader - caps H
//        $("#mnu-home").parent().addClass("active");
//    }
//    if (scroll > 250 && scroll < 600) {
//        //clearHeader, not clearheader - caps H
//        $("#mnu-home").parent().removeClass("active");
//        $("#mnu-project").parent().addClass("active");
//    }
//    else {
//        //clearHeader, not clearheader - caps H
//        $("#mnu-project").parent().removeClass("active");
//        $("#mnu-customer").parent().addClass("active");
//    }
//}); //missing );

function activeClass(id) {
    var child = document.getElementById(id);
    child.parentElement.classList.add("active");
}

function reomveClass(id) {
    var child = document.getElementById(id);
    child.parentElement.classList.remove("active");
}

function goToMenu(id) {
    document.getElementById(id).scrollIntoView({ behavior: 'smooth' });

    //if (id == 'home') {
    //    //removeClass("mnu-project");
    //    //removeClass("mnu-customer");
    //    activeClass("mnu-home");
    //}
    //if (id == 'project') {
    //    //removeClass("mnu-home");
    //    //removeClass("mnu-customer");
    //    activeClass("mnu-project");
    //}
    //if (id == 'customer') {
    //    //removeClass("mnu-home");
    //    //removeClass("mnu-project");
    //    activeClass("mnu-customer");
    //}
}

//function goToHome(id) {
//    document.getElementById(id).scrollIntoView({ behavior: 'smooth' });
//    activeClass("mnu-home");
//}
//function goToProject(id) {
//    document.getElementById(id).scrollIntoView({ behavior: 'smooth' });
//    activeClass("mnu-project");
//}
//function goToCustomer(id) {
//    document.getElementById(id).scrollIntoView({ behavior: 'smooth' });
//    activeClass("mnu-customer");
//    reomveClass("customer");
//}



//$('#mnu-home').on('click', function (e) {
//    event.preventDefault();
//    $.scrollTo($('#introduction'), 1000);
//})
//$('#mnu-project').on('click', function (e) {
//    alert("Sdas");
//    //event.preventDefault();
//    //$.scrollTo($('#project'), 1000);
//    $('.mnu-project').parent.addClass("active")
//    alert($('.mnu-project').parent);
//})
//$('#mnu-customer').on('click', function (e) {
//    event.preventDefault();
//    $.scrollTo($('#customer'), 1000);
//})