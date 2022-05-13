var xmlhttp;
/*@cc_on @*/
/*@if (@_jscript_version >= 5)
  try {
  xmlhttp=new ActiveXObject("Msxml2.XMLHTTP");
 } catch (e) {
  try {
    xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  } catch (E) {
   xmlhttp=false;
  }
 }
@else
 xmlhttp=false;
@end @*/
if (!xmlhttp && typeof XMLHttpRequest!='undefined') {
 try {
  xmlhttp = new XMLHttpRequest();
 } catch (e) {
  xmlhttp=false;
 }
}
var xmlhttpview;
/*@cc_on @*/
/*@if (@_jscript_version >= 5)
  try {
  xmlhttp=new ActiveXObject("Msxml2.XMLHTTP");
 } catch (e) {
  try {
    xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
  } catch (E) {
   xmlhttp=false;
  }
 }
@else
 xmlhttp=false;
@end @*/
  if (!xmlhttpview && typeof XMLHttpRequest != 'undefined') {
    try {
        xmlhttpview = new XMLHttpRequest();
    } catch (e) {
        xmlhttpview = false;
    }
}

/*Cart*/
var xmlhttpcart;
/*@cc_on@*/
/*@if (@_jscript_version >= 5)
try {
    xmlhttpcart = new ActiveXObject("Msxml2.XMLHTTP");
} catch (e) {
    try {
        xmlhttpcart = new ActiveXObject("Microsoft.XMLHTTP");
    } catch (E) {
        xmlhttpcart = false;
    }
}
@else
 xmlhttpcart=false;
@end
@*/
if (!xmlhttpcart && typeof XMLHttpRequest != 'undefined') {
    try {
        xmlhttpcart = new XMLHttpRequest();
    } catch (e) {
        xmlhttpcart = false;
    }
}

function showXmlHttp(obj, url, target)
{
   var span = document.getElementById(target);
   span.innerHTML = "<img src=/images/waiting.gif>";
   obj.open('GET.html', url + '&rd=' + Math.random(), true);
   obj.onreadystatechange=function() 
   {
		if (obj.readyState==4)
		{
			span.innerHTML = obj.responseText;
		}
   }
  obj.send(null);
  return true;
}

function closeXmlHttp(target){
  var s = document.getElementById(target);
  s.innerHTML = '';
}

