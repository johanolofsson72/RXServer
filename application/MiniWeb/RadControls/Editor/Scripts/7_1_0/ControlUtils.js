if (typeof(TelerikNamespace)=="undefined"){var TelerikNamespace=new Object(); }TelerikNamespace.Utils= {Og6:function (content,Ifa){var lg6=new Array("%","\x3c",">","\x21","\x22","\043","$","&","\x27","\x28","\x29",",",":",";","\x3d","?","\x5b","\x5c","\x5d","^","`","{","\x7c","}","~","\053"); var i33=content; if (Ifa){for (var i=0; i<lg6.length; i++){i33=i33.replace(new RegExp("\x5cx"+lg6[i].charCodeAt(0).toString(16),"ig"),"\x25"+lg6[i].charCodeAt(0).toString(16)); }}else {for (var i=lg6.length-1; i>=0; i--){i33=i33.replace(new RegExp("\x25"+lg6[i].charCodeAt(0).toString(16),"ig"),lg6[i]); }}return i33; } ,ofc:function (content){return TelerikNamespace.Utils.Og6(content, true); } ,o1f:function (content){return TelerikNamespace.Utils.Og6(content, false); } ,AppendStyleSheet:function (idd,ig6){var Ig6=(navigator.userAgent.toLowerCase().indexOf("\x73af\x61\x72i")!=-1); if (Ig6){TelerikNamespace.Utils.AddStyleSheet(ig6,document); }else {var O7j=document.createElement("LINK"); O7j.rel="st\x79\x6cesheet"; O7j.type="text\x2f\x63ss"; O7j.href=ig6; document.getElementById(idd+"Sty\x6c\x65SheetH\x6f\x6cder").appendChild(O7j); }} ,AddStyleSheet:function (Ob0,T){var og7=T!=null?T:document; var i2p=og7.createElement("link"); i2p.setAttribute("\x68\x72ef",Ob0,0); i2p.setAttribute("typ\x65","\x74ext/c\x73\x73"); i2p.setAttribute("re\x6c","\x73tylesheet",0); var lb0=og7.getElementsByTagName("head")[0]; if (TelerikNamespace.Utils.DetectBrowser("s\x61\x66ari")){var Og7= function (){lb0.appendChild(i2p); };window.setTimeout(Og7,200); }else {lb0.appendChild(i2p); }} ,DetectBrowser:function (lg7){lg7=lg7.toLowerCase(); if ("\x69e"==lg7)lg7="msie"; else if ("mozilla"==lg7 || "\x66\151r\x65\x66ox"==lg7)lg7="\x63\x6fmpatibl\x65"; var i44=navigator.userAgent.toLowerCase(); ig7=i44.indexOf(lg7)+1; if (ig7)return true; else return false; }};
if (typeof(Sys) != "undefined"){if (Sys.Application != null && Sys.Application.notifyScriptLoaded != null){Sys.Application.notifyScriptLoaded();}}
