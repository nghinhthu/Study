var h_ = screen.height;
var w_ = screen.width;
if (w_ > 800) {
    var w_ = window.innerWidth;
    var h_ = window.innerHeight;
}
$(document).ready(function () {
    if ($(".store-list").length > 0) {
        if (($(window).scrollTop() > $('.store-list').offset().top) && ($(window).scrollTop() < $('.store-list').offset().top + $('.store-list').height() - (h_ / 2))) {
            $(".search-list-alpha > ul").each(function () {
                var $element = $(this);
                $element.addClass('in-view-search-list');
            });
            $(".search-list-foormap > ul").each(function () {
                var $element = $(this);
                $element.addClass('in-view-search-list');
            });
        } else {
            $(".search-list-alpha > ul").removeClass("in-view-search-list");
            $(".search-list-foormap > ul").removeClass("in-view-search-list");
        }
    }
    if (gup('location') != null) {
        scrollupdiv('map_mapplic_content');
    }
});

function subscribe_email(l) {
    var email = document.getElementById("email_subscribe").value;
    if (email == '') {
        document.getElementById("email_subscribe").focus();
    }
    else {
        if (email.indexOf(" ") > 0 || email.indexOf("@") == -1 || email.indexOf(".") == -1) {
            alert('Email không hợp lệ!');
            document.getElementById("email_subscribe").value = "";
            document.getElementById("email_subscribe").focus();
        }
        else {
            var urlinfo = '/xmlhttp.aspx?FID=2' + (l != '' ? '&Language=' + l : '');
            $.ajax({
                url: urlinfo,
                type: "post",
                dataType: "text",
                data: {
                    email: email,
                },
                success: function (result) {
                    alert(result);
                }
            });
        }
    }
}

function scrollupdiv(id) {
    $('html, body').animate({
        scrollTop: $('#' + id).offset().top
    }, 600);
    return false;
}
function gup(name) {
    var url = location.href;
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(url);
    return results == null ? null : results[1];
}
$(window).scroll(function () {
    if ($(".store-list").length > 0) {
        if (($(window).scrollTop() > $('.store-list').offset().top) && ($(window).scrollTop() < $('.store-list').offset().top + $('.store-list').height() - (h_ / 2))) {
            $(".search-list-alpha > ul").each(function () {
                var $element = $(this);
                $element.addClass('in-view-search-list');
            });
            $(".search-list-foormap > ul").each(function () {
                var $element = $(this);
                $element.addClass('in-view-search-list');
            });
        } else {
            $(".search-list-alpha > ul").removeClass("in-view-search-list");
            $(".search-list-foormap > ul").removeClass("in-view-search-list");
        }
    }
});

function time_only(id) {
    // Thiết lập thời gian đích mà ta sẽ đếm
    var countDownDate = new Date('01/12/2019').getTime();

    // Lấy thời gian hiện tại
    var now = new Date().getTime();

    // Lấy số thời gian chênh lệch
    var distance = countDownDate - now;

    // Tính toán số ngày, giờ, phút, giây từ thời gian chênh lệch
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor(distance / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    // HIển thị chuỗi thời gian trong thẻ p
    document.getElementById(id).innerHTML = days;

    // Nếu thời gian kết thúc, hiển thị chuỗi thông báo
    if (distance < 0) {
        clearInterval(x);
        document.getElementById("demo").innerHTML = "Đã kết thúc";
    }

    // cập nhập thời gian sau mỗi 1 giây
    //var x = setInterval(function () {

    //}, 1000);
}
function show_search_form() {
    $('#cssmenu > ul > li').css("opacity", 0);
    $('#cssmenu > ul > li:last-child#search_form').css("opacity", 1);
    $('#cssmenu > ul > li:last-child#search_form').show();
    document.getElementById('search_form').classList.add('w3-animate-opacity');
    document.fsm.searchid.focus();
    document.getElementById('search_form_button').innerHTML = "<a href=\"javascript:void(0)\" onclick=\"hidden_search_form()\"><img src=\"/images/close.png\"></a>";
}
function hidden_search_form() {
    $('#cssmenu > ul > li').css("opacity", 1);
    $('#cssmenu > ul > li:last-child#search_form').css("opacity", 0);
    $('#cssmenu > ul > li:last-child#search_form').hide();
    document.getElementById('search_form').classList.remove('w3-animate-opacity');
    document.getElementById('search_form_button').innerHTML = "<a href=\"javascript:void(0)\" onclick=\"show_search_form()\"><img src=\"/images/search-icon.png\"></a>";
}


var xmlhttpsearchstore;
if (!xmlhttpsearchstore && typeof XMLHttpRequest != 'undefined') {
    try {
        xmlhttpsearchstore = new XMLHttpRequest();
    } catch (e) {
        xmlhttpsearchstore = false;
    }
}
function search_store(l) {
    var span = document.getElementById('store_list');
    span.innerHTML = "<center><img style=\"margin-bottom:40px;\" src=/images/waiting.gif></center>";
    var searchtext = document.getElementById('search_store_text').value;
    var searchlist = document.getElementById('search_store_list').value;
    xmlhttpsearchstore.open('GET.html', '/xmlhttp.aspx?FID=12&search=1&keyword=' + searchtext + '&idstore=' + searchlist + '&Language=' + l + '&rd=' + Math.random(), true);
    xmlhttpsearchstore.onreadystatechange = function () {
        if (xmlhttpsearchstore.readyState == 4) {
            span.innerHTML = xmlhttpsearchstore.responseText;
        }
    }
    xmlhttpsearchstore.send(null);
    return true;
}
function select_store_group(value, name, l) {
    document.getElementById('dropdownMenuButton').innerHTML = name;
    if (parseInt(value) > 0)
        document.getElementById('dropdownMenuButton').style.color = "#000";
    else
        document.getElementById('dropdownMenuButton').style.color = "#c4c4c4";
    var elmnt = document.getElementById("search_store_list");
    for (var i = 0; i < elmnt.options.length; i++) {
        if (elmnt.options[i].value === value) {
            elmnt.selectedIndex = i;
            break;
        }
    }
    var x = document.getElementsByClassName("cat-item");
    for (var i = 0; i < x.length; i++) {
        x[i].classList.remove("active");
    }
    document.getElementById("alpha_all").classList.add("active");
    search_store(l);
}

function listalpha(alphalabel) {
    if (alphalabel == "ALL") {
        var x = document.getElementsByClassName("col-store-item");
        var i;
        for (i = 0; i < x.length; i++) {
            x[i].style.display = "block";
        }
        document.getElementById("alpha_all").classList.add("active");
    }
    else {
        alphalabel = alphalabel.toLowerCase();
        var x = document.getElementsByClassName("col-store-item");
        var i;
        for (i = 0; i < x.length; i++) {
            x[i].style.display = "none";
        }
        x = document.getElementsByClassName("cat-item");
        for (i = 0; i < x.length; i++) {
            x[i].classList.remove("active");
        }
        document.getElementById("alpha_" + alphalabel).classList.add("active");
        x = document.getElementsByClassName("store_alpha_" + alphalabel);
        for (i = 0; i < x.length; i++) {
            x[i].style.display = "block";
        }
    }
}

function listfloormap(floorlabel) {
    var x = document.getElementsByClassName("col-store-item");
    var i;
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    x = document.getElementsByClassName("cat-item");
    for (i = 0; i < x.length; i++) {
        x[i].classList.remove("active");
    }
    document.getElementById("floor_" + floorlabel).classList.add("active");
    x = document.getElementsByClassName("store_floor_" + floorlabel);
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "block";
    }
}

function toggle(elements, specifiedDisplay) {
    var element, index;

    elements = elements.length ? elements : [elements];
    for (index = 0; index < elements.length; index++) {
        element = elements[index];

        if (isElementHidden(element)) {
            element.style.display = '';

            // If the element is still hidden after removing the inline display
            if (isElementHidden(element)) {
                element.style.display = specifiedDisplay || 'block';
            }
        } else {
            element.style.display = 'none';
        }
    }
    function isElementHidden(element) {
        return window.getComputedStyle(element, null).getPropertyValue('display') === 'none';
    }
}

var KEYCODE_ESC = 27;
$(document).keyup(function (e) {
    if (e.keyCode == KEYCODE_ESC) {
        hidden_search_form();
    };
});
var xmlhttplike;
if (!xmlhttplike && typeof XMLHttpRequest != 'undefined') {
    try {
        xmlhttplike = new XMLHttpRequest();
    } catch (e) {
        xmlhttplike = false;
    }
}
function like_article(id) {
    var span = document.getElementById('like_article_' + id);
    xmlhttplike.open('GET.html', '/xmlhttp.aspx?FID=111&like=1&ID=' + id + '&rd=' + Math.random(), true);
    xmlhttplike.onreadystatechange = function () {
        if (xmlhttplike.readyState == 4) {
            span.innerHTML = xmlhttplike.responseText;
        }
    }
    xmlhttplike.send(null);
    return true;
}

function keyEnter(evt, str) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode == "13") {
        search(str);
        return false;
    }
}
function search(str) {
    var $this = $('#searchid');
    var value = $this.val();
    value = $.trim(value);
    if (value != '' & value != null & value != str) {
        $('#fsm').submit();
    }
    return false;
}
function getCookie(c_name) {
    var v = '';
    var i, x, y, ARRcookies = document.cookie.split(";");
    for (i = 0; i < ARRcookies.length; i++) {
        x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("="));
        y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1);
        x = x.replace(/^\s+|\s+$/g, "");
        if (x == c_name) {
            v = unescape(y);
        }
    }
    return v;
}
function createCookieint(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookieint(name, "", -1);
}

function Set_Cookie(name, value, expires, path, domain, secure) {
    // set time, it's in milliseconds
    var today = new Date();
    today.setTime(today.getTime());

    /*
    if the expires variable is set, make the correct
    expires time, the current script below will set
    it for x number of days, to make it for hours,
    delete * 24, for minutes, delete * 60 * 24
    */
    if (expires) {
        expires = expires * 1000 * 60 * 60 * 24;
    }
    var expires_date = new Date(today.getTime() + (expires));

    document.cookie = name + "=" + escape(value) +
        ((expires) ? ";expires=" + expires_date.toGMTString() : "") +
        ((path) ? ";path=" + path : "") +
        ((domain) ? ";domain=" + domain : "") +
        ((secure) ? ";secure" : "");
}





