Type.registerNamespace("Telerik.Web.UI");
Type.registerNamespace("Telerik.Web.UI.Editor");
Telerik.Web.UI.Editor.Utils={getInvisibleParent:function(_1){
while(_1!=document){
if("none"==$telerik.getCurrentStyle(_1,"display","")){
return _1;
}
_1=_1.parentNode;
}
return null;
},evalScriptCode:function(_2){
var _3=$telerik.isSafari;
if(_3){
_2=_2.replace(/^\s*<!--((.|\n)*)-->\s*$/mi,"$1");
}
var _4=document.createElement("script");
_4.setAttribute("type","text/javascript");
if(_3){
_4.appendChild(document.createTextNode(_2));
}else{
_4.text=_2;
}
var _5=document.getElementsByTagName("head")[0];
_5.appendChild(_4);
if(_3){
_4.innerHTML="";
}else{
_4.parentNode.removeChild(_4);
}
},cleanPastedContent:function(_6,_7,_8,_9){
var _a=_6;
if(_7==Telerik.Web.UI.StripFormattingOptions.None){
if((_6.match(/style="[^"]*?mso[^"]*?"/ig)||_6.match(/class="?[^"]*?mso[^"]*?"?/ig))&&confirm(_8)){
_a=Telerik.Web.UI.Editor.Utils.stripFormatting(_6,"WORD");
}
}else{
if(_7&Telerik.Web.UI.StripFormattingOptions.All){
_a=Telerik.Web.UI.Editor.Utils.stripFormatting(_6,"ALL");
}else{
if(_7&Telerik.Web.UI.StripFormattingOptions.AllExceptNewLines){
_a=Telerik.Web.UI.Editor.Utils.stripFormatting(_6,"ALL_NO_BRAKES");
}else{
if(_7&Telerik.Web.UI.StripFormattingOptions.MSWordRemoveAll){
_6=Telerik.Web.UI.Editor.Utils.stripFormatting(_6,"WORD_ALL");
}
if(_7&Telerik.Web.UI.StripFormattingOptions.MSWordNoFonts){
_6=Telerik.Web.UI.Editor.Utils.stripFormatting(_6,"WORD_NO_FONTS");
}
if(_7&Telerik.Web.UI.StripFormattingOptions.MSWord){
_6=Telerik.Web.UI.Editor.Utils.stripFormatting(_6,"WORD");
}
if(_7&Telerik.Web.UI.StripFormattingOptions.Css){
_6=Telerik.Web.UI.Editor.Utils.stripFormatting(_6,"CSS");
}
if(_7&Telerik.Web.UI.StripFormattingOptions.Font){
_6=Telerik.Web.UI.Editor.Utils.stripFormatting(_6,"FONT");
}
if(_7&Telerik.Web.UI.StripFormattingOptions.Span){
_6=Telerik.Web.UI.Editor.Utils.stripFormatting(_6,"SPAN");
}
_a=_6;
}
}
}
if(null!=_9&&false==_9){
_a=Telerik.Web.UI.Editor.Utils.stripFormatting(_a,"SCRIPT");
}
return _a;
},isCursorMovingKey:function(_b){
if(_b>=33&&_b<=40){
return true;
}
return false;
},isSystemKey:function(_c){
if(_c>=112&&_c<=123){
return true;
}
if(_c>=8&&_c<=27){
return true;
}
if(_c>=32&&_c<=46){
return true;
}
if(_c==93){
return true;
}
return false;
},storeBrowserPosition:function(){
var _d=document.body;
var _e=document.documentElement;
this._browserTop=_d.scrollTop>_e.scrollTop?_d.scrollTop:_e.scrollTop;
this._browserLeft=_d.scrollLeft>_e.scrollLeft?_d.scrollTop:_e.scrollLeft;
return {x:this._browserLeft,y:this._browserTop};
},restoreBrowserPosition:function(_f,top){
try{
if(null==_f){
_f=this._browserLeft;
}
if(null==top){
top=this._browserTop;
}
var _11=document.body;
var _12=document.documentElement;
_11.scrollTop=top;
_11.scrollLeft=_f;
_12.scrollTop=top;
_12.scrollLeft=_f;
}
catch(ex){
}
},_getPasteIframe:function(){
if(!this._pasteIframe){
this._pasteIframe=document.createElement("IFRAME");
var _13=this._pasteIframe.style;
_13.width="1px";
_13.height="1px";
_13.border="0px solid red";
_13.overflow="hidden";
_13.position="absolute";
document.body.appendChild(this._pasteIframe);
var doc=this._pasteIframe.contentWindow.document;
var _15=doc.open("text/html","replace");
var _16="<html><head><title>New Document</title></head>"+"<body contentEditable='true' style='overflow:hidden;margin:0px;padding:0px;height:100%'>"+"</html>";
_15.write(_16);
_15.close();
}
return this._pasteIframe;
},getPasteContainer:function(){
var _17=this._getPasteIframe();
return _17.contentWindow.document.body;
},getClipboardAsHtml:function(){
var div=this.getPasteContainer();
div.innerHTML="";
if(div.setActive){
div.setActive();
}
document.execCommand("Paste",null);
var _19=div.innerHTML;
div.innerHTML="";
return _19;
},stripFormatting:function(_1a,_1b){
switch(_1b){
case "ALL":
_1a=_1a.replace(/<\/?[^>]*>/ig,"");
break;
case "ALL_NO_BRAKES":
_1a=_1a.replace(/<BR(\s[^>]*)?\/?>/ig,"~RADEDITORBRAKE~");
_1a=_1a.replace(/<\/?[^>]*>/ig,"");
_1a=_1a.replace(/~RADEDITORBRAKE~/ig,"<br/>");
_1a=_1a.replace(/\n/ig,"<br/>");
_1a=_1a.replace(/\r/ig,"");
break;
case "WORD":
case "WORD_ALL":
case "WORD_NO_FONTS":
_1a=this.stripWordFormatting(_1a,_1b);
break;
case "CSS":
_1a=_1a.replace(new RegExp("(<[^>]+) class=[^ |^>]*([^>]*>)","ig"),"$1 $2");
_1a=_1a.replace(/(<[^>]+) style="[^"]*"([^>]*>)/ig,"$1 $2");
break;
case "FONT":
_1a=_1a.replace(/<\/?font[^>]*>/ig,"");
break;
case "SPAN":
_1a=_1a.replace(/<\/?span[^>]*>/ig,"");
break;
case "SCRIPT":
_1a=_1a.replace(new RegExp("<(SCRIPT)([^>]*)/>","ig"),"");
_1a=_1a.replace(new RegExp("<(SCRIPT)([^>]*)>[\\s\\S]*?</(SCRIPT)([^>]*)>","ig"),"");
break;
default:
break;
}
return _1a;
},replaceNewLineWithBr:function(_1c){
try{
_1c=_1c.replace(/\n/g,"<br>");
return _1c;
}
catch(exc){
}
},convertText2Html:function(_1d){
try{
_1d=_1d.replace(/</g,"&lt;");
_1d=_1d.replace(/>/g,"&gt;");
_1d=_1d.replace(/\n/g,"<br>");
return _1d;
}
catch(exc){
}
},clearWordAttributesInElement:function(_1e,_1f){
var _20=$telerik.isIE?_1e.all:_1e.getElementsByTagName("*");
for(var i=0;i<_20.length;i++){
var _22=_20[i];
var _23=new RegExp("mso","gi");
if(_22.nodeType==1){
if(_23.exec(_22.className)){
_22.className="";
}
_22.removeAttribute("lang","",0);
_22.removeAttribute("stylw","",0);
_22.style.cssText=_22.style.cssText.replace(/(([\w-]*?mso[\w-]*?):(.+?)([;^$]|$))/gi,"");
if($telerik.isIE){
_22.style.removeAttribute("tab-stops",0);
_22.style.removeAttribute("textIndent",0);
}
if($telerik.isIE&&(_1f=="WORD_NO_FONTS"||_1f=="WORD_ALL")){
_22.style.removeAttribute("fontFamily",0);
_22.removeAttribute("face",0);
}
for(j=_22.attributes.length-1;j>=0;j--){
var _24=_22.attributes[j];
if("null"!=_24.value&&""!=_24.value){
if(_23.exec(_24.name)||_23.exec(_24.value)){
_22.removeAttribute(_24.name);
}
}
}
}
}
},stripWordFormatting:function(_25,_26){
if(_26=="WORD_ALL"){
var _27=/<SPAN[^>]*?>([\s\S]*?)<\/SPAN[^>]*?>/ig;
while(_25.match(_27)){
_25=_25.replace(_27,"$1");
}
var _28=/<FONT[^>]*?>([\s\S]*?)<\/FONT[^>]*?>/ig;
while(_25.match(_28)){
_25=_25.replace(_28,"$1");
}
}
_25=_25.replace(/<span>([^<>]+)<\/span>/gi,"<span EditorSaved='true'>$1</span>");
_25=_25.replace(/<font>([^<>]+)<\/font>/gi,"<font EditorSaved='true'>$1</font>");
var _29=document.createElement("DIV");
Telerik.Web.UI.Editor.Utils.setElementInnerHtml(_29,_25);
this.clearWordAttributesInElement(_29,_26);
var _2a=_29.innerHTML;
_2a=_2a.replace(/\t/g," ");
_2a=_2a.replace(/<\/?\w+:[^>]*>/gi,"");
_2a=_2a.replace(/<\\?\??xml[^>]>/gi,"");
_2a=_2a.replace(/<p>&nbsp;<\/p>/gi,"<BR><BR>");
_2a=_2a.replace(/[ ]+/g," ");
_2a=_2a.replace(/<(\/)?strong>/ig,"<$1B>");
_2a=_2a.replace(/<(\/)?em>/ig,"<$1I>");
_2a=_2a.replace(/^\s/i,"");
_2a=_2a.replace(/\s$/i,"");
_2a=_2a.replace(/<o:[pP]>&nbsp;<\/o:[pP]>/gi,"");
_2a=_2a.replace(/<st1:.*?>/gi,"");
_2a=_2a.replace(/<font>([^<>]+)<\/font>/gi,"$1");
_2a=_2a.replace(/<span>([^<>]+)<\/span>/gi,"$1");
_2a=_2a.replace(/[\s]+EditorSaved=[\'\"]true[\'\"]/gi,"");
_2a=_2a.replace(/<\?xml[^>]*>/ig,"");
_2a=_2a.replace(/<\/?[a-z]+:[^>]*>/ig,"");
_2a=_2a.replace(/style=(""|'')/ig,"");
_2a=_2a.replace(/class=(""|'')/ig,"");
_2a=_2a.replace(/v:shape="[^"]+"/ig,"");
_2a=_2a.replace(/<span[^>]*>\s*<\/span[^>]*>/ig," ");
_2a=_2a.replace(/<font[^>]*>\s*<\/font[^>]*>/ig," ");
_2a=_2a.replace(/\s+/ig," ");
_2a=_2a.replace(/<span><span>/ig,"<span>");
_2a=_2a.replace(/<\/span><\/span>/ig,"</span>");
return _2a;
},createTable:function(_2b,_2c,_2d){
if(!_2d){
_2d=document;
}
var _2e=_2d.createElement("TABLE");
for(var r=0;r<_2b;r++){
oRow=_2e.insertRow(-1);
for(var c=0;c<_2c;c++){
oCell=oRow.insertCell(-1);
oCell.innerHTML="&nbsp;";
}
}
return _2e;
},mergeElementAttributes:function(_31,_32,_33){
if(!_31||!_32){
return;
}
if(_31.mergeAttributes){
_32.mergeAttributes(_31,_33);
}else{
for(var ac=0;ac<_31.attributes.length;ac++){
var _35=_31.attributes[ac].nodeValue;
_32.setAttribute(_31.attributes[ac].nodeName,_35);
}
if(""==_32.getAttribute("style")){
_32.removeAttribute("style");
}
}
},getElementParentByTag:function(_36,_37){
if(null==_36){
return null;
}
if(null==_37){
return _36;
}
try{
while(_36&&null!=_36.tagName&&_36.tagName!=_37){
_36=_36.parentNode;
}
return ((_36.tagName==_37)?_36:null);
}
catch(e){
return null;
}
},selectElement:function(_38,_39){
if(!_39){
return;
}
var _3a=_38.document;
if($telerik.isIE){
var _3b;
switch(_39.tagName){
case "TABLE":
case "IMG":
case "HR":
case "INPUT":
_3b=_3a.body.createControlRange();
_3b.add(_39);
break;
case "UL":
case "OL":
_3b=_3a.body.createTextRange();
_3b.moveToElementText(_39);
var _3c=_3b.parentElement();
if(_3c.tagName!="UL"||_3c.tagName!="OL"){
_3b.moveEnd("character",-1);
}
break;
default:
_3b=_3a.body.createTextRange();
_3b.moveToElementText(_39);
break;
}
if(_3b){
_3b.select();
return true;
}
}else{
if(_38.getSelection){
var _3b=_3a.createRange();
_3b.selectNode(_39);
if(window.opera){
_3b.selectNodeContents(_39);
}
var _3d=_38.getSelection();
if($telerik.isSafari){
_3d.setBaseAndExtent(_3b.startContainer,_3b.startOffset,_3b.endContainer,_3b.endOffset);
}else{
_3d.removeAllRanges();
_3d.addRange(_3b);
}
return true;
}
}
return false;
},getOuterHtml:function(_3e){
return $telerik.getOuterHtml(_3e);
},setElementInnerHtml:function(_3f,_40){
var _41=$telerik.isIE?this.getStoredOriginalPathsAndAttributes(_40):_40;
_3f.innerHTML="<span>&nbsp;</span>"+_41;
_3f.removeChild(_3f.firstChild);
if($telerik.isIE){
this.restoreOriginalPathsAndAttributes(_3f);
}
},getStoredOriginalPathsAndAttributes:function(_42){
var _43=function(_44,g1,g2,g3,g4,g5,g6,_4b,_4c){
if(!g3){
g3="";
g4=g4+g6;
var _4d=g4.search(/(\s|>)/gi);
if(_4d>0){
g6=g4.substring(_4d,g4.length);
g4=g4.substring(0,_4d);
}else{
return _44;
}
}
return g1+" "+g2+"="+g3+g4+g3+" originalAttribute=\""+g2+"\" originalPath=\""+g4+"\""+g6;
};
var _4e=new RegExp("(<[^>]*?)\\s(href|src)\\s*=\\s*('|\")?(.+?)(\\3)([^<]*?>)","ig");
_42=_42.replace(_4e,_43);
var _4f=new RegExp("(<!--[\\s\\S]*?) originalAttribute=\"(href|src)\" originalPath=\"[^\"]+\"([\\s\\S]*?-->)","ig");
var _50=_42.length+1;
while(_42.length<_50){
_50=_42.length;
_42=_42.replace(_4f,"$1$3");
}
return _42;
},restoreOriginalPathsAndAttributes:function(_51){
var _52=_51.getElementsByTagName("*");
for(var i=0;i<_52.length;i++){
var _54=_52[i];
var _55=_54.getAttribute("originalPath");
var _56=_54.getAttribute("originalAttribute");
if(_55!=null&&_56!=null){
_54.removeAttribute("originalPath");
_54.removeAttribute("originalAttribute");
if(_55.toLowerCase().indexOf("mailto:")==0){
continue;
}
_55=_55.replace(window.location.href+"#","#");
_54.removeAttribute(_56);
var _57=_54.innerHTML;
_54.setAttribute(_56,_55);
if(_57.indexOf("www.")==0&&_54.innerHTML.match("[a-z]+://")){
_54.innerHTML=_57;
}
}
}
},_encodeHtmlContent:function(_58,_59){
var _5a=new Array("%","<",">","!","\"","#","$","&","'","(",")",",",":",";","=","?","[","]","\\","^","`","{","|","}","~","+");
var _5b=_58;
if(_59){
for(var i=0;i<_5a.length;i++){
_5b=_5b.replace(new RegExp("\\x"+_5a[i].charCodeAt(0).toString(16),"ig"),"%"+_5a[i].charCodeAt(0).toString(16));
}
}else{
for(var i=_5a.length-1;i>=0;i--){
_5b=_5b.replace(new RegExp("%"+_5a[i].charCodeAt(0).toString(16),"ig"),_5a[i]);
}
}
return _5b;
},encodePostbackContent:function(_5d){
return Telerik.Web.UI.Editor.Utils._encodeHtmlContent(_5d,true);
},decodePostbackContent:function(_5e){
return Telerik.Web.UI.Editor.Utils._encodeHtmlContent(_5e,false);
},addStyleSheet:function(url,doc,id){
doc=doc||document;
var _62=doc.createElement("link");
_62.setAttribute("href",url,0);
_62.setAttribute("type","text/css");
if(id){
_62.setAttribute("id",id);
}else{
id="";
}
_62.setAttribute("rel","stylesheet",0);
var _63=doc.getElementsByTagName("head")[0];
if($telerik.isSafari){
var _64=function(){
_63.appendChild(_62);
};
window.setTimeout(_64,200);
}else{
_63.appendChild(_62);
}
},_copyElementsBetweenNodes:function(_65,_66,_67){
var _68=_65.getElementsByTagName(_67);
var _69=_66.getElementsByTagName(_67);
for(var i=0;i<_68.length;i++){
switch(_67){
case "script":
case "title":
_69[i].text=_68[i].text;
break;
case "style":
if(_69[i].innerHTML!=_68[i].innerHTML){
_69[i].styleSheet.cssText=_68[i].styleSheet.cssText;
}
break;
default:
_69[i].innerHTML=_68[i].innerHTML;
break;
}
}
},cloneNodeWithChildren:function(_6b){
if(!_6b){
return null;
}
if($telerik.isIE&&_6b.getElementsByTagName){
var _6c=_6b.cloneNode(true);
if(typeof (_6c.innerHTML)!="string"){
this.setElementInnerHtml(_6c,_6b.innerHTML);
}
this._copyElementsBetweenNodes(_6b,_6c,"script");
this._copyElementsBetweenNodes(_6b,_6c,"map");
this._copyElementsBetweenNodes(_6b,_6c,"style");
this._copyElementsBetweenNodes(_6b,_6c,"title");
return _6c;
}else{
return _6b.cloneNode(true);
}
},getUniqueID:function(){
if(!window["RadEditor_uniqueSeed"]){
window["RadEditor_uniqueSeed"]=new Date()-101;
}
if(!window["RadEditor_uniqueIdCounter"]){
window["RadEditor_uniqueIdCounter"]=1;
}else{
window["RadEditor_uniqueIdCounter"]++;
}
var _6d=window["RadEditor_uniqueSeed"]-window["RadEditor_uniqueIdCounter"];
return "UniqueID"+_6d;
}};
Type.registerNamespace("Telerik.Web.UI.Editor");
Telerik.Web.UI.Editor.CommandStates=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.Editor.CommandStates.prototype={Disabled:-1,Off:0,On:1};
Telerik.Web.UI.Editor.CommandStates.registerEnum("Telerik.Web.UI.Editor.CommandStates",false);
Telerik.Web.UI.Editor.CommandBase=function(_6e,_6f,_70){
this.isSafari=$telerik.isSafari;
this.isIE=$telerik.isIE;
this.isOpera=$telerik.isOpera;
this.isFirefox=$telerik.isFirefox;
this._title=_6e;
this._window=_6f;
this._isExecuted=false;
this._canUnexecute=(_70!=false);
};
Telerik.Web.UI.Editor.CommandBase.prototype={getState:function(_71){
return Telerik.Web.UI.Editor.CommandStates.Off;
},getValue:function(_72){
return null;
},set_window:function(_73){
this._window=_73;
},get_window:function(){
return this._window;
},get_title:function(){
return this._title;
},set_title:function(_74){
this._title=_74;
},execute:function(){
this._isExecuted=false;
if(null==this.onExecute||null==this.get_window()){
return false;
}
try{
if(!this.RestorePoint1){
this.RestorePoint1=new Telerik.Web.UI.Editor.RestorePoint(this.get_window());
}else{
this.RestorePoint1.select();
}
return (this._isExecuted=this.onExecute());
}
catch(ex){
}
return false;
},onExecute:function(){
if(this.isIE&&null!=this.OnExecuteIE){
return this.OnExecuteIE();
}else{
if(null!=window.getSelection&&null!=this.OnExecuteMoz){
return this.OnExecuteMoz();
}
}
return false;
},unexecute:function(){
try{
if(this._canUnexecute&&this._isExecuted){
this.RestorePoint1.restore();
}
}
catch(ex){
}
}};
Telerik.Web.UI.Editor.CommandBase.registerClass("Telerik.Web.UI.Editor.CommandBase",null);
Telerik.Web.UI.Editor.PasteHtmlCommand=function(_75,_76,_77,_78){
Telerik.Web.UI.Editor.PasteHtmlCommand.initializeBase(this,[(_75||"Insert Html"),_76,true]);
this.HtmlText=_77;
this.SelectText=(true==_78);
};
Telerik.Web.UI.Editor.PasteHtmlCommand.prototype={clone:function(){
return new Telerik.Web.UI.Editor.PasteHtmlCommand(this.get_title(),this.get_window(),this.HtmlText);
},onExecute:function(){
var sel=new Telerik.Web.UI.Editor.Selection(this.get_window());
sel.pasteHtml(this.HtmlText,this.SelectText);
return true;
}};
Telerik.Web.UI.Editor.PasteHtmlCommand.registerClass("Telerik.Web.UI.Editor.PasteHtmlCommand",Telerik.Web.UI.Editor.CommandBase);
Telerik.Web.UI.Editor.GenericCommand=function(_7a,_7b){
Telerik.Web.UI.Editor.GenericCommand.initializeBase(this,[_7a,_7b,true]);
this.RestorePoint1=new Telerik.Web.UI.Editor.RestorePoint(this.get_window());
};
Telerik.Web.UI.Editor.GenericCommand.prototype={execute:function(){
if(null==this.RestorePoint2){
this.RestorePoint2=new Telerik.Web.UI.Editor.RestorePoint(this.get_window());
}else{
this.RestorePoint2.restore();
}
return true;
},unexecute:function(){
this.RestorePoint1.restore(true);
}};
Telerik.Web.UI.Editor.GenericCommand.registerClass("Telerik.Web.UI.Editor.GenericCommand",Telerik.Web.UI.Editor.CommandBase);
Telerik.Web.UI.Editor.TextTypeCommand=function(_7c,_7d){
Telerik.Web.UI.Editor.TextTypeCommand.initializeBase(this,[(_7c||"Typing"),_7d]);
};
Telerik.Web.UI.Editor.TextTypeCommand.prototype={update:function(){
if(this.RestorePoint2){
this.RestorePoint2.update();
}
}};
Telerik.Web.UI.Editor.TextTypeCommand.registerClass("Telerik.Web.UI.Editor.TextTypeCommand",Telerik.Web.UI.Editor.GenericCommand);
Telerik.Web.UI.Editor.BrowserCommand=function(_7e,_7f,_80,_81){
var _82=true;
switch(this.CommandID){
case "Copy":
case "SelectAll":
case "Print":
_82=false;
break;
}
Telerik.Web.UI.Editor.BrowserCommand.initializeBase(this,[(_7e||_80),_7f,_82]);
this.CommandID=_80;
this.Value=_81;
};
Telerik.Web.UI.Editor.BrowserCommand.prototype={clone:function(){
return new Telerik.Web.UI.Editor.BrowserCommand(this._title,this.get_window(),this.CommandID,this.Value);
},getState:function(_83){
try{
_83=_83||this.get_window();
var _84=_83.document;
if(null==_84){
return Telerik.Web.UI.Editor.CommandStates.Disabled;
}
var _85=true;
if("Paste"!=this.CommandID){
_85=_84.queryCommandEnabled(this.CommandID);
}else{
if(!$telerik.isIE7){
_85=_84.queryCommandEnabled(this.CommandID);
}
}
if(!this.isOpera&&!_85){
if(!this.isSafari||!this.CommandID=="RealFontSize"){
return Telerik.Web.UI.Editor.CommandStates.Disabled;
}
}
var _86=null;
if("Paste"!=this.CommandID){
_86=_84.queryCommandState(this.CommandID);
}else{
if(!$telerik.isIE7){
_86=_84.queryCommandState(this.CommandID);
}
}
return _86?Telerik.Web.UI.Editor.CommandStates.On:Telerik.Web.UI.Editor.CommandStates.Off;
}
catch(ex){
return Telerik.Web.UI.Editor.CommandStates.Off;
}
},getValue:function(_87){
try{
_87=_87||this.get_window();
return _87.document.queryCommandValue(this.CommandID);
}
catch(ex){
}
return null;
},onExecute:function(){
var _88=this.get_window();
if(!_88){
return false;
}
var _89=_88.document;
if("AbsolutePosition"==this.CommandID){
_89.execCommand("2D-Position",false,true);
}
var _8a=true;
if(this.CommandID=="BackColor"&&(this.isOpera||this.isFirefox)){
this.CommandID="HiliteColor";
_8a=false;
}
if(this.CommandID=="FontSize"&&this.isSafari&&!$telerik.isSafari3){
var _8b=parseInt(this.Value);
switch(_8b){
case 1:
this.Value="8pt";
break;
case 2:
this.Value="10pt";
break;
case 3:
this.Value="12pt";
break;
case 4:
this.Value="14pt";
break;
case 5:
this.Value="18pt";
break;
case 6:
this.Value="24pt";
break;
case 7:
this.Value="36pt";
break;
}
}
try{
_89.execCommand("UseCSS",false,(false!=_8a));
}
catch(e){
}
var _8c=_89.execCommand(this.CommandID,false,this.Value);
try{
_89.execCommand("UseCSS",false,true);
}
catch(e){
}
return _8c;
}};
Telerik.Web.UI.Editor.BrowserCommand.registerClass("Telerik.Web.UI.Editor.BrowserCommand",Telerik.Web.UI.Editor.CommandBase);
Telerik.Web.UI.Editor.StyleRuleCommand=function(_8d,_8e,_8f,_90,_91){
Telerik.Web.UI.Editor.StyleRuleCommand.initializeBase(this,[(_8d||sCmdID),_8e,true]);
if(!_8f){
var _92=new Telerik.Web.UI.Editor.Selection(this._window);
_8f=_92.getParentElement();
}
this._nodeBookmark=new Telerik.Web.UI.Editor.SelectionBookmark(this._window,_8f);
this._styleAttributeName=_90;
this._newValue=_91;
};
Telerik.Web.UI.Editor.StyleRuleCommand.prototype={clone:function(){
return new Telerik.Web.UI.Editor.StyleRuleCommand(this._title,this._window,null,this._styleAttributeName,this._newValue);
},execute:function(){
var _93=this._nodeBookmark.select();
if(!_93){
return false;
}
if(!this._isExecuted){
this._oldValue=_93.style[this._styleAttributeName];
}
_93.style[this._styleAttributeName]=this._newValue;
this._isExecuted=true;
return true;
},unexecute:function(){
var _94=this._nodeBookmark.select();
_94.style[this._styleAttributeName]=this._oldValue;
}};
Telerik.Web.UI.Editor.StyleRuleCommand.registerClass("Telerik.Web.UI.Editor.StyleRuleCommand",Telerik.Web.UI.Editor.CommandBase);
Telerik.Web.UI.Editor.AttributeCommand=function(_95,_96,_97,_98,_99){
Telerik.Web.UI.Editor.AttributeCommand.initializeBase(this,[(_95||sCmdID),_96,true]);
if(!_97){
var _9a=new Telerik.Web.UI.Editor.Selection(this._window);
_97=_9a.getParentElement();
}
this._nodeBookmark=new Telerik.Web.UI.Editor.SelectionBookmark(this._window,_97);
this._attribName=_98;
this._newValue=_99;
};
Telerik.Web.UI.Editor.AttributeCommand.prototype={clone:function(){
return new Telerik.Web.UI.Editor.AttributeCommand(this._title,this._window,null,this._attribName,this._newValue);
},execute:function(){
var _9b=this._nodeBookmark.select();
if(!_9b){
return false;
}
if(!this._isExecuted){
this._oldValue=_9b.getAttribute(this._attribName);
}
if(this._attribName&&this._attribName.toLowerCase()=="name"&&document.all){
_9b.name=this._newValue;
_9b.removeAttribute("name");
_9b.removeAttribute("NAME");
}
var _9c=this._newValue.trim();
if(""==_9c){
_9b.removeAttribute(this._attribName,0);
if("className"==this._attribName){
_9b.removeAttribute("class",0);
}
}else{
_9b[this._attribName]=this._newValue;
if(this._attribName.toLowerCase()=="nowrap"){
_9b.setAttribute(this._attribName,this._newValue);
}
}
this._isExecuted=true;
return true;
},unexecute:function(){
var _9d=this._nodeBookmark.select();
_9d[this._attribName]=this._oldValue;
}};
Telerik.Web.UI.Editor.AttributeCommand.registerClass("Telerik.Web.UI.Editor.AttributeCommand",Telerik.Web.UI.Editor.CommandBase);
Telerik.Web.UI.Editor.ClassNameCommand=function(_9e,_9f,_a0){
Telerik.Web.UI.Editor.ClassNameCommand.initializeBase(this,[(_9e||"Classname"),_9f,true]);
};
Telerik.Web.UI.Editor.ClassNameCommand.prototype={getValue:function(_a1){
_a1=_a1||this._window;
if($telerik.isIE){
return this._getValueIE(_a1);
}else{
return this._getValueMoz(_a1);
}
},_getValueIE:function(_a2){
var _a3=new Telerik.Web.UI.Editor.Selection(_a2);
var _a4=_a3.getParentElement();
if("BODY"==_a4.tagName){
return "";
}else{
return (""==_a4.className?"":_a4.className);
}
},_getValueMoz:function(_a5){
if(!_a5){
return "";
}
var _a6=_a5.getSelection();
if(!_a6){
return "";
}
if(_a6.rangeCount!=1){
return "";
}
var _a7=(_a6.focusNode.nodeType!=3?_a6.focusNode:_a6.focusNode.parentNode);
var _a8=(_a6.anchorNode.nodeType!=3?_a6.anchorNode:_a6.anchorNode.parentNode);
if(_a7!=_a8){
return "";
}
var _a9=new Telerik.Web.UI.Editor.Selection(_a5);
var _aa="",_ab;
if(null!=_a9&&null!=(_ab=_a9.getParentElement())){
_aa=_ab.className;
}
return (""==_aa?"":_aa);
}};
Telerik.Web.UI.Editor.ClassNameCommand.registerClass("Telerik.Web.UI.Editor.ClassNameCommand",Telerik.Web.UI.Editor.CommandBase);
Telerik.Web.UI.Editor.FormatBlockCommand=function(_ac,_ad,_ae){
Telerik.Web.UI.Editor.FormatBlockCommand.initializeBase(this,[(_ac||"Format Block"),_ad,true]);
this.FormatValue=_ae;
};
Telerik.Web.UI.Editor.FormatBlockCommand.prototype={clone:function(){
return new Telerik.Web.UI.Editor.FormatBlockCommand(this.Title,this._window,this.FormatValue);
},getValue:function(_af){
try{
_af=_af||this._window;
var _b0=_af.document.queryCommandValue("FormatBlock");
if(!document.all){
switch(_b0){
case "x":
case "":
_b0="Normal";
break;
}
}
return _b0;
}
catch(ex){
}
return null;
},_isFormatBlockElement:function(_b1){
if(!_b1||!_b1.tagName){
return false;
}
var _b2=_b1.tagName;
if(_b2=="H1"||_b2=="H2"||_b2=="H3"||_b2=="H4"||_b2=="H5"||_b2=="H6"||_b2=="H7"||_b2=="ADDRESS"||_b2=="PRE"){
return true;
}
},OnExecuteIE:function(){
var _b3=this._window.document;
if("<p>"==this.FormatValue.toLowerCase()){
return _b3.execCommand("FormatBlock",false,"<p>")&&_b3.execCommand("RemoveFormat");
}
var _b4=_b3.selection.createRange();
var _b5=false;
var _b6=_b4.htmlText.trim();
if(_b6&&_b6.length>2&&_b6.substr(0,2).toLowerCase()=="<p"){
_b5=true;
}
if(!_b5&&""!=_b4.text){
var _b7=this.FormatValue.substring(1,this.FormatValue.length-1);
_b3.execCommand("FormatBlock",false,"<p>");
_b3.execCommand("RemoveFormat");
var _b8=_b3.createElement(_b7);
_b8.innerHTML=_b4.htmlText;
_b4.pasteHTML(_b8.outerHTML);
return true;
}else{
return _b3.execCommand("FormatBlock",false,this.FormatValue);
}
},OnExecuteMoz:function(){
var _b9=this.FormatValue.substring(1,this.FormatValue.length-1);
var _ba=this._window.document;
var _bb=("body"==this.FormatValue.toLowerCase()||"normal"==this.FormatValue.toLowerCase());
var _bc=null;
var _bd=_b9.indexOf(" ");
if(_bd!=-1){
_bc=_b9.substring(_bd+1);
_b9=_b9.substring(0,_bd);
}
if(this.isSafari){
if(_bb){
}else{
var _be=_ba.createElement(_b9);
if(_bc){
var _bf="";
_bf=_bc.replace(/class\=[\'|\"]?([^\'|^\"]+)[\'|\"]?/gi,"$1");
if(_bf.length>0){
_be.className=_bf;
}
}
var _c0=new Telerik.Web.UI.Editor.Selection(this._window);
_be.innerHTML=_c0.getHtml();
var _c1=new Telerik.Web.UI.Editor.PasteHtmlCommand(this.Title,this._window,_be.outerHTML,true);
_c1.execute();
}
return;
}
if(_bb){
return _ba.execCommand("FormatBlock",false,"Normal");
}
var _c2=this._window.getSelection();
if(_c2.rangeCount<1){
return false;
}
var _c3=_c2.getRangeAt(0);
var _c4=new Telerik.Web.UI.Editor.Selection(this._window).getParentElement();
if(_c3.toString()!=""&&!this._isFormatBlockElement(_c4)){
try{
var _be=_ba.createElement(_b9);
if(_bc){
var _bf="";
_bf=_bc.replace(/class\=[\'|\"]?([^\'|^\"]+)[\'|\"]?/gi,"$1");
if(_bf.length>0){
_be.className=_bf;
}
}
_be.appendChild(_c3.extractContents());
_c3.insertNode(_be);
return true;
}
catch(ex){
return false;
}
}else{
return _ba.execCommand("FormatBlock",false,this.FormatValue);
}
return false;
}};
Telerik.Web.UI.Editor.FormatBlockCommand.registerClass("Telerik.Web.UI.Editor.FormatBlockCommand",Telerik.Web.UI.Editor.CommandBase);
Telerik.Web.UI.Editor.InsertListCommand=function(_c5,_c6,_c7,_c8,_c9){
Telerik.Web.UI.Editor.InsertListCommand.initializeBase(this,[(_c5||"Insert List"),_c6,true]);
this._newLineBr=(_c7==true);
this._commandName=_c8;
this._listType=(_c8=="InsertOrderedList")?"OL":"UL";
this._listStyle=_c9;
this._document=this._window.document;
};
Telerik.Web.UI.Editor.InsertListCommand.prototype={_insertList:function(){
return this._document.execCommand(this._commandName,false,false);
},_pasteHtml:function(_ca){
var _cb=new Telerik.Web.UI.Editor.PasteHtmlCommand(this.Title,this._window,_ca);
_cb.execute();
},_expandSelection:function(_cc,_cd,_ce){
var _cf=_cc.duplicate();
var _d0=null;
var _d1=null;
for(var i=_cd.length-1;i>=0;i--){
_cf.moveToElementText(_cd[i]);
var _d3=_cc.compareEndPoints("StartToStart",_cf);
if(-1==_d3||0==_d3){
if(_ce[_cd[i].tagName]!=null){
_d1=_cd[i];
}
}else{
if(_ce[_cd[i].tagName]!=null){
_d0=_cd[i];
break;
}
}
}
if(_d0){
_cf.moveToElementText(_d0);
_cc.setEndPoint("StartToEnd",_cf);
}else{
var _d4=_cc.parentElement();
_cf.moveToElementText(_d4);
_cc.setEndPoint("StartToStart",_cf);
}
if(_d1){
_cf.moveToElementText(_d1);
if("BR"==_d1.tagName){
_cc.setEndPoint("EndToEnd",_cf);
}else{
_cc.setEndPoint("EndToStart",_cf);
}
}else{
var _d4=_cc.parentElement();
_cf.moveToElementText(_d4);
_cc.setEndPoint("EndToEnd",_cf);
}
_cc.select();
},_handleEmptyListSelection:function(_d5,_d6){
var _d7=_d5.parentElement();
var _d8=(_d7&&"P"==_d7.tagName.toUpperCase());
var brs=_d7.getElementsByTagName("BR");
if(_d8&&brs.length==0){
return this._insertList();
}else{
var _da={};
_da["BR"]="";
_da["TD"]="";
_da["OL"]="";
_da["UL"]="";
_da["TABLE"]="";
_da["DIV"]="";
_da["IMG"]="";
_da["OBJECT"]="";
var _db=_d5.parentElement().getElementsByTagName("*");
this._expandSelection(_d5,_db,_da);
if(_d5.htmlText){
return this.OnExecuteIE();
}
}
},OnExecuteIE:function(){
if(!this._newLineBr){
return this._insertList();
}
var _dc=new Telerik.Web.UI.Editor.Selection(this._window).getParentElement();
var _dd=this._document.selection.createRange();
if("OL"==_dc.tagName||Telerik.Web.UI.Editor.Utils.getElementParentByTag(_dc,"OL")!=null||"UL"==_dc.tagName||Telerik.Web.UI.Editor.Utils.getElementParentByTag(_dc,"UL")!=null){
return this._insertList();
}else{
if("TD"==_dc.tagName||"TR"==_dc.tagName||"TBODY"==_dc.tagName||"TABLE"==_dc.tagName){
var _dd=this._document.selection.createRange();
var _de=_dd.parentElement().getElementsByTagName("TD");
for(var i=_de.length-1;i>=0;i--){
brRange=_dd.duplicate();
brRange.moveToElementText(_de[i]);
if(_dd.inRange(brRange)&&_de[i].innerHTML!=""){
_dd.moveToElementText(_de[i]);
}
}
}
}
var _e0=this._document.selection;
var _e1=this._listType;
if(_e0.type=="Control"){
var _e2=this._document.body.createTextRange();
_e2.moveToElementText(_dd(0));
var _e3=_e2.parentElement();
var _e4=_e3.tagName.toLowerCase();
if(_e4=="table"||_e4=="tbody"){
var _e5=_e3.parentNode.outerHTML;
_e3.parentNode.outerHTML="<"+_e1+"><LI>"+_e5+"</LI></"+_e1+">";
}else{
var _e5=_e2.htmlText;
this._pasteHtml("<"+_e1+"><LI>"+_e5+"</LI></"+_e1+">");
}
}else{
if(_dd.htmlText==""){
return this._handleEmptyListSelection(_dd,this._commandName);
}
var _e6=this._document.createElement("SPAN");
_e6.innerHTML=_dd.htmlText;
if(_e6.getElementsByTagName("P").length>0){
return this._insertList();
}else{
var _e7;
if(_dd.parentElement().tagName.toUpperCase()=="LI"){
_e7=_dd.parentElement().parentNode;
}else{
_e7=_dd.parentElement();
}
if(_e7.tagName.toUpperCase()=="OL"||_e7.tagName.toUpperCase()=="UL"){
var _e8=_e7.tagName.toUpperCase();
if(_e1==_e8){
if(this._newLineBr){
var _e9=_dd.duplicate();
var _ea=_dd.duplicate();
_ea.moveToElementText(_e7);
var _eb=_dd.duplicate();
var _ec=_e7.getElementsByTagName("LI");
var _ed=0;
var _ee=_ec.length-1;
var _ef=_dd.duplicate();
_ef.moveToElementText(_ec[0]);
var _f0=_dd.duplicate();
_f0.moveToElementText(_ec[_ec.length-1]);
_eb.setEndPoint("EndToEnd",_f0);
_eb.setEndPoint("StartToStart",_ef);
while((_ed<_ec.length)&&(_eb.compareEndPoints("StartToStart",_e9)<=0)){
_eb.moveToElementText(_ec[_ed]);
_eb.setEndPoint("EndToEnd",_f0);
_ed++;
}
_ed-=2;
while((_ee>0)&&(_eb.compareEndPoints("EndToEnd",_e9)>=0)){
_eb.moveToElementText(_ec[_ee]);
_eb.setEndPoint("StartToStart",_ef);
_ee--;
}
_ee+=2;
var _f1=_dd.duplicate();
var _f2=_dd.duplicate();
_f1.moveToElementText(_ec[_ed]);
_f1.collapse(true);
_f1.setEndPoint("StartToStart",_ea);
_f2.moveToElementText(_ec[_ee]);
_f2.collapse(false);
_f2.setEndPoint("EndToEnd",_ea);
_dd.setEndPoint("StartToEnd",_f1);
_dd.setEndPoint("EndToStart",_f2);
var _f3="";
var _f4=false;
var _f5=false;
if(_f1.htmlText.replace(/<(.*?)>/)!=""){
_f3+="<"+_e8+">"+_f1.htmlText+"</"+_e8+">";
}else{
_f4=true;
}
_f3+=_dd.htmlText.replace(/<LI\/?>/gi,"<BR>").replace(/<\/LI>/gi,"").replace(/^\s*<BR\/?>/gi,"").replace(/<BR\/?>\s*$/gi,"");
if(_f2.htmlText.replace(/<(.*?)>/)!=""){
_f3+="<"+_e8+">"+_f2.htmlText+"</"+_e8+">";
}else{
_f5=true;
_f3+="<BR>";
}
if(_f4&&_f5){
_f3=_f3.replace(new RegExp("</?"+_e8+"/?>","gi"),"").replace(/^\s*<BR\/?>/gi,"");
}
if(_e7.parentNode.childNodes[0]==_e7){
_ea.collapse();
_e7.parentNode.removeChild(_e7,_f3);
}else{
_ea.moveStart("character",-1);
}
this._pasteHtml(_f3);
}else{
return this._insertList();
}
}else{
return this._insertList();
}
}else{
var _f6=_dd.duplicate();
_f6.collapse(false);
_f6.moveEnd("character",1);
if(_f6.htmlText.match(/<BR\/?>/gi)){
_dd.moveEnd("character",1);
}
var _f7="<"+_e1+"><LI>"+_dd.htmlText.replace(/(<BR\s*>\s*)*$/gi,"").replace(/<BR\/?>$/gi,"").replace(/<BR\/?>/gi,"</LI><LI>")+"</LI></"+_e1+">";
try{
_dd.pasteHTML(_f7);
}
catch(e){
}
}
}
}
return true;
},OnExecuteMoz:function(){
return this._insertList();
}};
Telerik.Web.UI.Editor.InsertListCommand.registerClass("Telerik.Web.UI.Editor.InsertListCommand",Telerik.Web.UI.Editor.CommandBase);
Telerik.Web.UI.Editor.TableCommandBase=function(_f8,_f9){
Telerik.Web.UI.Editor.TableCommandBase.initializeBase(this,[(_f8||"Table Command"),_f9,true]);
};
Telerik.Web.UI.Editor.TableCommandBase.prototype={getState:function(_fa){
return this.getSelectedCell(_fa)?Telerik.Web.UI.Editor.CommandStates.Off:Telerik.Web.UI.Editor.CommandStates.Disabled;
},getSelectedCell:function(_fb){
var _fc=new Telerik.Web.UI.Editor.Selection(_fb||this._window);
var _fd;
if(_fc){
_fd=_fc.getParentElement();
}
while(null!=_fd&&_fd.tagName!="TD"&&_fd.tagName!="TH"&&_fd.tagName!="BODY"){
_fd=_fd.parentNode;
}
if(!_fd||!_fd.tagName){
return null;
}
return (_fd.tagName=="TD"||_fd.tagName=="TH"?_fd:null);
},getSelectedRow:function(_fe){
var _ff=new Telerik.Web.UI.Editor.Selection(_fe||this._window);
var _100;
if(_ff){
_100=_ff.getParentElement();
}
if(!_100){
return null;
}
while(null!=_100&&_100.tagName!="TR"&&_100.tagName!="BODY"){
_100=_100.parentNode;
}
return (_100&&_100.tagName=="TR"?_100:null);
},getParentTable:function(_101){
if(!_101){
return null;
}
while(null!=_101&&_101.parentNode!=_101&&"TABLE"!=_101.tagName){
_101=_101.parentNode;
}
return (_101&&_101.tagName=="TABLE"?_101:null);
},getNextSiblingCell:function(cell){
if(!cell){
return null;
}
var row=cell.parentNode;
var _104=cell.cellIndex+1;
if(0<=_104&&_104<row.cells.length){
return row.cells[_104];
}
return null;
},getPreviouseSiblingCell:function(cell){
if(!cell){
return null;
}
var row=cell.parentNode;
var _107=cell.cellIndex-1;
if(0<=_107&&_107<row.cells.length){
return row.cells[_107];
}
return null;
}};
Telerik.Web.UI.Editor.TableCommandBase.registerClass("Telerik.Web.UI.Editor.TableCommandBase",Telerik.Web.UI.Editor.CommandBase);
Telerik.Web.UI.Editor.TableInsertRow=function(_108,_109,_10a){
Telerik.Web.UI.Editor.TableInsertRow.initializeBase(this,[(_108||"Insert row"),_109,true]);
this._direction=_10a||"above";
};
Telerik.Web.UI.Editor.TableInsertRow.prototype={clone:function(){
return new Telerik.Web.UI.Editor.TableInsertRow(this._title,this._window,this._direction);
},getState:function(_10b){
return (this.getSelectedRow(_10b)?Telerik.Web.UI.Editor.CommandStates.Off:Telerik.Web.UI.Editor.CommandStates.Disabled);
},onExecute:function(){
var cell=this.getSelectedCell();
if(!cell){
return false;
}
var row=cell.parentNode;
var _10e=row.rowIndex;
if("below"==this._direction){
_10e++;
}
var _10f=this.getParentTable(row);
if(!_10f){
return false;
}
var _110=_10f.insertRow(_10e);
if(!_110){
return false;
}
Telerik.Web.UI.Editor.Utils.mergeElementAttributes(row,_110);
var _111;
for(var i=0;i<row.cells.length;i++){
cell=row.cells[i];
_111=_110.insertCell(-1);
_111.colSpan=cell.colSpan;
Telerik.Web.UI.Editor.Utils.mergeElementAttributes(cell,_111);
_111.innerHTML=this.isIE?"":"&nbsp;";
}
return true;
}};
Telerik.Web.UI.Editor.TableInsertRow.registerClass("Telerik.Web.UI.Editor.TableInsertRow",Telerik.Web.UI.Editor.TableCommandBase);
Telerik.Web.UI.Editor.TableDeleteRow=function(_113,_114){
Telerik.Web.UI.Editor.TableDeleteRow.initializeBase(this,[(_113||"Delete Row"),_114,true]);
};
Telerik.Web.UI.Editor.TableDeleteRow.prototype={clone:function(){
return new Telerik.Web.UI.Editor.TableDeleteRow(this._title,this._window);
},getState:function(_115){
return (this.getSelectedRow(_115)?Telerik.Web.UI.Editor.CommandStates.Off:Telerik.Web.UI.Editor.CommandStates.Disabled);
},onExecute:function(){
var row=this.getSelectedRow();
if(!row){
return false;
}
row.parentNode.removeChild(row);
return true;
}};
Telerik.Web.UI.Editor.TableDeleteRow.registerClass("Telerik.Web.UI.Editor.TableDeleteRow",Telerik.Web.UI.Editor.TableCommandBase);
Telerik.Web.UI.Editor.TableInsertColumn=function(_117,_118,_119){
Telerik.Web.UI.Editor.TableInsertColumn.initializeBase(this,[(_117||"Insert column"),_118,true]);
this._direction=_119||"left";
};
Telerik.Web.UI.Editor.TableInsertColumn.prototype={clone:function(){
return new Telerik.Web.UI.Editor.TableInsertColumn(this._title,this._window,this._direction);
},getState:function(_11a){
return (this.getSelectedCell(_11a)?Telerik.Web.UI.Editor.CommandStates.Off:Telerik.Web.UI.Editor.CommandStates.Disabled);
},onExecute:function(){
var cell=this.getSelectedCell();
if(!cell){
return false;
}
var _11c=cell.cellIndex;
if("right"==this._direction){
_11c++;
}
var _11d=this.getParentTable(cell);
if(!_11d){
return false;
}
var rows=_11d.rows;
var _11f;
for(var i=0;i<rows.length;i++){
_11f=rows[i].insertCell(_11c);
Telerik.Web.UI.Editor.Utils.mergeElementAttributes(cell,_11f);
_11f.innerHTML=this.isIE?"":"&nbsp;";
}
return true;
}};
Telerik.Web.UI.Editor.TableInsertColumn.registerClass("Telerik.Web.UI.Editor.TableInsertColumn",Telerik.Web.UI.Editor.TableCommandBase);
Telerik.Web.UI.Editor.TableDeleteColumn=function(_121,_122,_123){
Telerik.Web.UI.Editor.TableDeleteColumn.initializeBase(this,[(_121||"Delete column"),_122,true]);
};
Telerik.Web.UI.Editor.TableDeleteColumn.prototype={clone:function(){
return Telerik.Web.UI.Editor.TableDeleteColumn.New(this._title,this._window);
},getState:function(_124){
return (this.getSelectedCell(_124)?Telerik.Web.UI.Editor.CommandStates.Off:Telerik.Web.UI.Editor.CommandStates.Disabled);
},onExecute:function(){
var cell=this.getSelectedCell();
if(!cell){
return false;
}
var _126=cell.cellIndex;
var _127=this.getParentTable(cell);
if(!_127){
return false;
}
var rows=_127.rows;
for(var i=0;i<rows.length;i++){
cell=rows[i].cells[_126];
if(cell){
cell.parentNode.removeChild(cell);
}
}
return true;
}};
Telerik.Web.UI.Editor.TableDeleteColumn.registerClass("Telerik.Web.UI.Editor.TableDeleteColumn",Telerik.Web.UI.Editor.TableCommandBase);
Telerik.Web.UI.Editor.TableMergeRows=function(_12a,_12b){
Telerik.Web.UI.Editor.TableMergeRows.initializeBase(this,[(_12a||"Merge rows"),_12b,true]);
};
Telerik.Web.UI.Editor.TableMergeRows.prototype={clone:function(){
return Telerik.Web.UI.Editor.TableMergeRows.New(this._title,this._window);
},getState:function(_12c){
var cell=this.getSelectedCell(_12c);
if(null!=cell&&null!=this.getLowerCell(cell)&&1==cell.colSpan){
return Telerik.Web.UI.Editor.CommandStates.Off;
}else{
return Telerik.Web.UI.Editor.CommandStates.Disabled;
}
},onExecute:function(){
var cell=this.getSelectedCell();
if(!cell){
return false;
}
var _12f=this.getLowerCell(cell);
if(!_12f){
return false;
}
if(""!=_12f.innerHTML){
if(""!=cell.innerHTML){
cell.innerHTML+="<br>";
}
cell.innerHTML+=_12f.innerHTML;
}
cell.rowSpan+=_12f.rowSpan;
_12f.parentNode.removeChild(_12f);
return true;
},getLowerCell:function(cell){
if(!cell){
return null;
}
var _131=this.getParentTable(cell);
var row=cell.parentNode;
var _133=_131.rows[row.rowIndex+cell.rowSpan];
if(!_133){
return null;
}
var _134=_133.cells[cell.cellIndex];
return _134;
}};
Telerik.Web.UI.Editor.TableMergeRows.registerClass("Telerik.Web.UI.Editor.TableMergeRows",Telerik.Web.UI.Editor.TableCommandBase);
Telerik.Web.UI.Editor.TableMergeColumns=function(_135,_136){
Telerik.Web.UI.Editor.TableMergeColumns.initializeBase(this,[(_135||"Merge columns"),_136,true]);
};
Telerik.Web.UI.Editor.TableMergeColumns.prototype={clone:function(){
return Telerik.Web.UI.Editor.TableMergeColumns.New(this._title,this._window);
},getState:function(_137){
var cell=this.getSelectedCell(_137);
if(null!=cell&&null!=this.getNextSiblingCell(cell)){
return Telerik.Web.UI.Editor.CommandStates.Off;
}else{
return Telerik.Web.UI.Editor.CommandStates.Disabled;
}
},onExecute:function(){
var cell=this.getSelectedCell();
if(null==cell){
return false;
}
var _13a=this.getNextSiblingCell(cell);
if(!_13a){
return false;
}
cell.colSpan+=_13a.colSpan;
if(""!=_13a.innerHTML){
if(""!=cell.innerHTML){
cell.innerHTML+="<br>";
}
cell.innerHTML+=_13a.innerHTML;
}
_13a.parentNode.removeChild(_13a);
return true;
}};
Telerik.Web.UI.Editor.TableMergeColumns.registerClass("Telerik.Web.UI.Editor.TableMergeColumns",Telerik.Web.UI.Editor.TableCommandBase);
Telerik.Web.UI.Editor.TableSplitCell=function(_13b,_13c){
Telerik.Web.UI.Editor.TableSplitCell.initializeBase(this,[(_13b||"Split cell"),_13c,true]);
this._newRows=2;
this._newColumns=2;
};
Telerik.Web.UI.Editor.TableSplitCell.prototype={clone:function(){
return new Telerik.Web.UI.Editor.TableSplitCell(this._title,this._window);
},getState:function(_13d){
var cell=this.getSelectedCell(_13d);
if(!cell){
return Telerik.Web.UI.Editor.CommandStates.Disabled;
}
return ((cell.colSpan>1||cell.rowSpan>1)?Telerik.Web.UI.Editor.CommandStates.Off:Telerik.Web.UI.Editor.CommandStates.Disabled);
},onExecute:function(){
var cell=this.getSelectedCell();
if(!cell){
return false;
}
var _140=this.getParentTable(cell);
if(!_140){
return false;
}
var row=cell.parentNode;
var _142=("THEAD"==row.parentNode.tagName.toUpperCase()?"TH":"TD");
if(cell.colSpan>1){
for(i=1;i<this._newColumns;i++){
var _143=this._window.document.createElement(_142);
_143.innerHTML=this.isIE?"":"&nbsp;";
Telerik.Web.UI.Editor.Utils.mergeElementAttributes(cell,_143);
_143.colSpan=1;
if(cell.cellIndex+1<row.cells.length){
row.insertBefore(_143,row.cells[cell.cellIndex+1]);
}else{
row.appendChild(_143);
}
cell.colSpan--;
}
}
if(cell.rowSpan>1){
for(i=1;i<this._newRows;i++){
var _144=_140.rows[row.rowIndex+cell.rowSpan-1];
if(!_144||0==_144.cells.length){
break;
}
var _143=this._window.document.createElement(_142);
_143.innerHTML=this.isIE?"":"&nbsp;";
Telerik.Web.UI.Editor.Utils.mergeElementAttributes(cell,_143);
_143.rowSpan=1;
if(cell.cellIndex+1<_144.cells.length){
_144.insertBefore(_143,_144.cells[cell.cellIndex+1]);
}else{
_144.appendChild(_143);
}
cell.rowSpan--;
}
}
return true;
}};
Telerik.Web.UI.Editor.TableSplitCell.registerClass("Telerik.Web.UI.Editor.TableSplitCell",Telerik.Web.UI.Editor.TableCommandBase);
Telerik.Web.UI.Editor.TableDeleteCell=function(_145,_146){
Telerik.Web.UI.Editor.TableDeleteCell.initializeBase(this,[(_145||"Delete cell"),_146,true]);
};
Telerik.Web.UI.Editor.TableDeleteCell.prototype={clone:function(){
return new Telerik.Web.UI.Editor.TableDeleteCell(this._title,this._window);
},onExecute:function(){
var cell=this.getSelectedCell();
if(!cell){
return false;
}
cell.parentNode.removeChild(cell);
return true;
}};
Telerik.Web.UI.Editor.TableDeleteCell.registerClass("Telerik.Web.UI.Editor.TableDeleteCell",Telerik.Web.UI.Editor.TableCommandBase);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.EditorButton=function(_148){
Telerik.Web.UI.EditorButton.initializeBase(this,[_148]);
this._attributes={};
this._autoPostBack=false;
this._enabled=true;
this._name="";
this._text="";
this._shortCut="";
this._showIcon=true;
this._showText=false;
this._clientTypeName="Telerik.Web.UI.EditorButton";
this._isOn=false;
this._skin="";
this._addClickHandler=false;
};
Telerik.Web.UI.EditorButton.createToolWrapper=function(_149,skin){
var ul=document.createElement("UL");
var li=document.createElement("LI");
li.innerHTML="&nbsp;";
li.className="rade_grip grip_first";
ul.appendChild(li);
ul.className="rade_toolbar "+skin;
var _14d=_149.get_element();
ul.appendChild(_14d);
li=document.createElement("LI");
li.innerHTML="&nbsp;";
li.className="rade_grip grip_last";
ul.appendChild(li);
return ul;
};
Telerik.Web.UI.EditorButton.getToolRootNode=function(_14e){
while(_14e&&_14e.tagName!="LI"){
_14e=_14e.parentNode;
}
return _14e;
};
Telerik.Web.UI.EditorButton._createButton=function(_14f){
var _150=document.createElement("LI");
var a=document.createElement("A");
_150.appendChild(a);
a.className=_14f.showText==true?"rade_tool_text":"rade_tool";
var text=_14f["text"];
a.title=text?text:_14f["name"];
a.href="#";
a.setAttribute("unselectable","on");
if(_14f.showIcon!=false){
var span=document.createElement("SPAN");
span.className=_14f.name;
span.innerHTML="&nbsp;";
span.setAttribute("unselectable","on");
a.appendChild(span);
}
if(_14f.showText==true){
var span=document.createElement("SPAN");
span.className="rade_button_text";
span.innerHTML=_14f.text?_14f.text:_14f.name;
span.setAttribute("unselectable","on");
a.appendChild(span);
}
return _150;
};
Telerik.Web.UI.EditorButton.createTool=function(_154,_155,type,_157,_158){
if(!type){
type=Telerik.Web.UI.EditorButton;
}
if(!_157){
_157=Telerik.Web.UI.EditorButton._createButton(_154);
if(type==Telerik.Web.UI.EditorSplitButton||type.inheritsFrom(Telerik.Web.UI.EditorSplitButton)){
var a=_157.getElementsByTagName("A")[0];
if(a){
Sys.UI.DomElement.addCssClass(a,"rad_splitbutton");
var span=document.createElement("SPAN");
span.className="split_arrow";
span.innerHTML="&nbsp;";
a.appendChild(span);
}
}else{
if(type==Telerik.Web.UI.EditorDropDown||type.inheritsFrom(Telerik.Web.UI.EditorDropDown)){
var a=_157.getElementsByTagName("A")[0];
if(a){
Sys.UI.DomElement.removeCssClass(a,"rade_tool");
Sys.UI.DomElement.addCssClass(a,"rade_dropdown");
a.innerHTML="";
var span=document.createElement("SPAN");
span.innerHTML="&nbsp;";
var _15b=_154["width"]?_154["width"]:"50px";
span.style.width=_15b;
a.appendChild(span);
}
}
}
}
var tool=$create(type,_154,_155,null,_157);
if(_158&&_158.appendChild){
_158.appendChild(_157);
}
return tool;
};
Telerik.Web.UI.EditorButton.prototype={initialize:function(){
var _15d=this.getAnchorElement();
if(_15d){
if(!_15d.title||_15d.title.length==0){
_15d.title=this.get_text();
}
_15d.setAttribute("unselectable","on");
}
var span=this.getSpanElement();
if(span){
span.setAttribute("unselectable","on");
}
if(this._addClickHandler){
var _15f=this.get_element();
$addHandlers(_15f,{"click":this.click},this);
}
},dispose:function(){
var _160=this.get_element();
if(_160){
$clearHandlers(_160);
}
Telerik.Web.UI.EditorButton.callBaseMethod(this,"dispose");
},click:function(e){
this.raiseEvent("valueSelected");
return $telerik.cancelRawEvent(e);
},add_valueSelected:function(_162){
this.get_events().addHandler("valueSelected",_162);
},remove_valueSelected:function(_163){
this.get_events().removeHandler("valueSelected",_163);
},raiseEvent:function(_164,_165){
var _166=this.get_events().getHandler(_164);
if(_166){
if(!_165){
_165=Sys.EventArgs.Empty;
}
_166(this,_165);
}
},set_width:function(_167){
var span=this.getSpanElement();
if(span){
span.style.width=_167;
}
},get_width:function(){
return this.get_element().offsetWidth;
},set_height:function(_169){
var span=this.getSpanElement();
if(span){
span.style.height=_169;
}
},get_height:function(){
return this.get_element().offsetHeight;
},isTarget:function(e){
return $telerik.isDescendantOrSelf(this.get_element(),e.target);
},setState:function(_16c){
this.set_enabled(_16c!=Telerik.Web.UI.Editor.CommandStates.Disabled);
this.setOn(_16c==Telerik.Web.UI.Editor.CommandStates.On);
},setFocus:function(){
var elem=this.getAnchorElement();
if(elem&&elem.focus){
elem.focus();
}
},get_addClickHandler:function(){
return this._addClickHandler;
},set_addClickHandler:function(_16e){
this._addClickHandler=_16e;
},get_attributes:function(){
return this._attributes;
},set_attributes:function(_16f){
this._attributes=_16f;
},get_autoPostBack:function(){
return this._autoPostBack;
},set_autoPostBack:function(_170){
this._autoPostBack=_170;
},get_enabled:function(){
return this._enabled;
},set_enabled:function(_171){
if(this._enabled!=_171){
this._enabled=_171;
var _172=this.getAnchorElement();
if(!this._enabled){
this._addAnchorCssClass("rade_tool_disabled");
_172.setAttribute("disabled","disabled");
}else{
this._removeAnchorCssClass("rade_tool_disabled");
_172.removeAttribute("disabled");
}
}
},isOn:function(){
return this._isOn;
},setOn:function(_173){
if(this._isOn!=_173){
this._isOn=_173;
if(this._isOn){
this._addAnchorCssClass("rade_tool_selected");
}else{
this._removeAnchorCssClass("rade_tool_selected");
}
}
},get_name:function(){
return this._name;
},set_name:function(_174){
this._name=_174;
},get_text:function(){
if(!this._text){
return this.get_name();
}else{
return this._text;
}
},set_text:function(_175){
if(this._text!=_175){
this._text=_175;
if(this.get_showText()){
this.getSpanElement().innerHTML=_175;
}
}
},get_shortCut:function(){
return this._shortCut;
},set_shortCut:function(_176){
this._shortCut=_176;
},get_showIcon:function(){
return this._showIcon;
},set_showIcon:function(_177){
if(this._showIcon!=_177){
this._showIcon=_177;
}
},get_skin:function(){
return this._skin;
},set_skin:function(_178){
this._skin=_178;
},_addAnchorCssClass:function(_179){
Sys.UI.DomElement.addCssClass(this.getAnchorElement(),_179);
},_removeAnchorCssClass:function(_17a){
Sys.UI.DomElement.removeCssClass(this.getAnchorElement(),_17a);
},get_showText:function(){
return this._showText;
},set_showText:function(_17b){
if(this._showText!=_17b){
this._showText=_17b;
}
},get_type:function(){
return this._type;
},set_type:function(_17c){
this._type=_17c;
},get_clientTypeName:function(){
return this._clientTypeName;
},set_clientTypeName:function(_17d){
this._clientTypeName=_17d;
},getAnchorElement:function(){
var _17e=this.get_element().firstChild;
while(_17e!=null&&(_17e.tagName==null)){
_17e=_17e.nextSibling;
}
return _17e;
},getSpanElement:function(){
var _17f=this.getAnchorElement();
var _180=_17f.firstChild;
while(_180!=null&&(_180.tagName==null||_180.tagName.toLowerCase()!="span")){
_180=_180.nextSibling;
}
return _180;
}};
Telerik.Web.UI.EditorButton.registerClass("Telerik.Web.UI.EditorButton",Sys.UI.Control);
Telerik.Web.UI.EditorSpinBoxEventArgs=function(_181,_182){
Telerik.Web.UI.EditorSpinBoxEventArgs.initializeBase(this);
this._newValue=_181;
this._oldValue=_182;
};
Telerik.Web.UI.EditorSpinBoxEventArgs.prototype={get_oldValue:function(){
return this._oldValue;
},get_newValue:function(){
return this._newValue;
}};
Telerik.Web.UI.EditorSpinBoxEventArgs.registerClass("Telerik.Web.UI.EditorSpinBoxEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.EditorSpinBox=function(_183){
Telerik.Web.UI.EditorSpinBox.initializeBase(this,[_183]);
this._width="50px";
this._className="rade_SpinBox";
this._selectedItem="";
this._initialValue="";
this._visibleInput=true;
this._enabledIncrease=true;
this._enabledDecrease=true;
this._clientStateFieldID=null;
};
Telerik.Web.UI.EditorSpinBox.prototype={dispose:function(){
this._inputElement.onchange=null;
this._inputElement.onkeypress=null;
this._inputElement.onclick=null;
this._inputElement=null;
this._increaseButton.onclick=null;
this._increaseButton=null;
this._decreaseButton.onclick=null;
this._decreaseButton=null;
Telerik.Web.UI.EditorSpinBox.callBaseMethod(this,"dispose");
},initialize:function(){
this._createControls();
},_createControls:function(){
var _184=document.createElement("table");
_184.cellSpacing=0;
_184.cellPadding=0;
_184.className="rade_SpinBox";
_184.insertRow(-1);
var _185=_184.rows[0].insertCell(-1);
var _186=document.createElement("INPUT");
_186.type="text";
_186.onclick=function(e){
this.focus();
};
_186.onkeypress=Function.createDelegate(this,this._onKeyPressHandler);
_186.onchange=Function.createDelegate(this,this._onChangeHandler);
this._inputElement=_186;
_185.appendChild(_186);
_185=_184.rows[0].insertCell(-1);
var _188=document.createElement("table");
_188.cellSpacing=0;
_188.cellPadding=0;
_188.insertRow(-1);
var _189=_188.rows[0].insertCell(-1);
var _18a=document.createElement("A");
_18a.title="Increase";
_18a.href="javascript:void(0);";
_18a.innerHTML="Increase";
_18a.className="rade_SpinBoxIncrease";
_18a.onclick=Function.createDelegate(this,this._onPlusMinusClickHandler);
this._increaseButton=_18a;
_189.appendChild(_18a);
_188.insertRow(-1);
_189=_188.rows[1].insertCell(-1);
_18a=document.createElement("A");
_18a.title="Decrease";
_18a.href="javascript:void(0);";
_18a.innerHTML="Decrease";
_18a.className="rade_SpinBoxDecrease";
_18a.onclick=Function.createDelegate(this,this._onPlusMinusClickHandler);
this._decreaseButton=_18a;
_189.appendChild(_18a);
_185.appendChild(_188);
var _18b=this.get_element();
_18b.appendChild(_184);
_18b.style.width=this.get_width();
},_executeFunction:function(e,elem,_18e){
if(_18e){
if(elem.Executed){
elem.Executed=false;
return $telerik.cancelRawEvent(e);
}
}
elem.Executed=true;
var _18f=(this._selectedItem!="")?this._selectedItem:this._initialValue;
this._selectedItem=elem.value;
var _190=new Telerik.Web.UI.EditorSpinBoxEventArgs(elem.value,_18f);
this.raiseEvent("valueSelected",_190);
},_onPlusMinusClickHandler:function(e){
var _192=null;
if(!e){
_192=window.event.srcElement;
}else{
_192=e.target;
}
if(!_192){
return;
}
var _193=this.get_value();
_193=_193.replace(/^0+(\d)/ig,"$1");
if(""==_193){
_193="0";
}
var _194=parseInt(_193);
var _195=_194+"";
if(isNaN(_194)){
return;
}else{
_195=_193.substring(_195.length);
}
if(_192==this._increaseButton){
if(this._enabledIncrease){
_194++;
}else{
return;
}
}else{
if(_192==this._decreaseButton){
if(this._enabledDecrease){
_194--;
}else{
return;
}
}else{
_192=null;
}
}
if(_192){
this.set_value(_194+_195);
this._executeFunction(e,this._inputElement);
}
},_onChangeHandler:function(e){
if(!e){
e=window.event;
}
this._executeFunction(e,this._inputElement);
},_onKeyPressHandler:function(e){
if(!e){
e=window.event;
}
if(e.keyCode==13){
this._executeFunction(e,this._inputElement);
return $telerik.cancelRawEvent(e);
}
},_onKeyDownHandler:function(e){
if(!e){
var e=window.event;
}
e.returnValue=this._isKeyValid(e);
},_onKeyUpHandler:function(e){
if(!e){
var e=window.event;
}
if(this._isKeyValid(e,true)){
var _19a=this._selectedItem;
var _19b=this.get_value();
var _19c=new Telerik.Web.UI.EditorSpinBoxEventArgs(_19b,_19a);
this.raiseEvent("valueSelected",_19c);
}
},_isKeyValid:function(e,_19e){
try{
if(!_19e){
_19e=false;
}
if(!e){
e=window.event;
}
var _19f=((48<=e.keyCode&&e.keyCode<=57)||(96<=e.keyCode&&e.keyCode<=105)||(13==e.keyCode)||(8==e.keyCode)||(46==e.keyCode)||(9==e.keyCode));
if(!_19e){
_19f|=((35<=e.keyCode&&e.keyCode<=40));
}
return _19f;
}
catch(ex){
return true;
}
},get_selectedItem:function(){
return this._selectedItem;
},get_value:function(){
return this._inputElement.value;
},set_value:function(_1a0){
if(null==_1a0){
_1a0="";
}
this._inputElement.value=_1a0;
if(this._initialValue==""){
this._initialValue=_1a0;
}
},get_width:function(){
return this._width;
},set_width:function(_1a1){
this._width=_1a1;
var _1a2=this.get_element();
_1a2.style.width=this._width;
},get_enabledIncrease:function(){
return this._enabledIncrease;
},set_enabledIncrease:function(_1a3){
this._enabledIncrease=_1a3;
if(!this._enabledIncrease){
Sys.UI.DomElement.addCssClass(this._increaseButton,"disabled-button");
}else{
Sys.UI.DomElement.removeCssClass(this._increaseButton,"disabled-button");
}
},get_enabledDecrease:function(){
return this._enabledDecrease;
},set_enabledDecrease:function(_1a4){
this._enabledDecrease=_1a4;
if(!this._enabledDecrease){
Sys.UI.DomElement.addCssClass(this._decreaseButton,"disabled-button");
}else{
Sys.UI.DomElement.removeCssClass(this._decreaseButton,"disabled-button");
}
},get_visibleInput:function(){
return this._visibleInput;
},set_visibleInput:function(_1a5){
this._visibleInput=_1a5;
if(!this._visibleInput){
this._inputElement.style.display="none";
}else{
this._inputElement.style.display="";
}
},get_clientStateFieldID:function(){
return this._clientStateFieldID;
},set_clientStateFieldID:function(_1a6){
this._clientStateFieldID=_1a6;
}};
Telerik.Web.UI.EditorSpinBox.registerClass("Telerik.Web.UI.EditorSpinBox",Telerik.Web.UI.EditorButton);
Telerik.Web.UI.EditorCheckBox=function(_1a7){
Telerik.Web.UI.EditorCheckBox.initializeBase(this,[_1a7]);
this._selectedItem=false;
};
Telerik.Web.UI.EditorCheckBox.prototype={dispose:function(){
this._inputElement.onclick=null;
this._inputElement.Parent=null;
this._inputElement=null;
Telerik.Web.UI.EditorCheckBox.callBaseMethod(this,"dispose");
},get_selectedItem:function(){
return this._selectedItem;
},set_value:function(_1a8){
if(this._inputElement.checked!=_1a8){
this._inputElement.checked=_1a8;
}
},initialize:function(){
var _1a9=document.createElement("INPUT");
_1a9.setAttribute("type","CHECKBOX");
_1a9.Parent=this;
_1a9.onclick=function(e){
var oP=this.Parent;
oP._selectedItem=!oP._selectedItem;
this.checked=oP._selectedItem;
oP._selectedItem=this.checked;
oP.raiseEvent("valueSelected");
};
this._inputElement=_1a9;
this.get_element().appendChild(_1a9);
}};
Telerik.Web.UI.EditorCheckBox.registerClass("Telerik.Web.UI.EditorCheckBox",Telerik.Web.UI.EditorButton);
Telerik.Web.UI.EditorTextBox=function(_1ac){
Telerik.Web.UI.EditorTextBox.initializeBase(this,[_1ac]);
this._width="110px";
this._selectedItem="";
};
Telerik.Web.UI.EditorTextBox.prototype={dispose:function(){
this._inputElement.onchange=null;
this._inputElement.onkeypress=null;
this._inputElement.onclick=null;
this._inputElement.Parent=null;
this._inputElement=null;
Telerik.Web.UI.EditorTextBox.callBaseMethod(this,"dispose");
},get_width:function(){
return this._width;
},set_width:function(_1ad){
this._width=_1ad;
},initialize:function(){
var _1ae=document.createElement("INPUT");
_1ae.style.width=this.get_width();
_1ae.Parent=this;
var _1af=this.get_name();
var _1b0=function(e,elem,_1b3){
if(_1b3){
if(elem.Executed){
elem.Executed=false;
return $telerik.cancelRawEvent(e);
}
}
elem.Executed=true;
elem.Parent._selectedItem=elem.value;
elem.Parent.raiseEvent("valueSelected");
return $telerik.cancelRawEvent(e);
};
_1ae.onchange=function(e){
if(!e){
e=window.event;
}
return _1b0(e,this,true);
};
_1ae.onclick=function(e){
this.focus();
};
_1ae.onkeypress=function(e){
if(!e){
e=window.event;
}
if(e.keyCode==13){
return _1b0(e,this);
}
};
this._inputElement=_1ae;
this.get_element().appendChild(_1ae);
},get_selectedItem:function(){
return this._selectedItem;
},get_value:function(){
return this._inputElement.value;
},set_value:function(_1b7){
if(null==_1b7){
_1b7="";
}
this._inputElement.value=_1b7;
}};
Telerik.Web.UI.EditorTextBox.registerClass("Telerik.Web.UI.EditorTextBox",Telerik.Web.UI.EditorButton);
Telerik.Web.UI.ImageDialogCaller=function(_1b8){
Telerik.Web.UI.ImageDialogCaller.initializeBase(this,[_1b8]);
this._width="150px";
this._className="rade_ImageDialogCaller";
this._editor=null;
this._clientStateFieldID=null;
};
Telerik.Web.UI.ImageDialogCaller.prototype={dispose:function(){
this._inputElement=null;
this._pushButton.onclick=null;
this._pushButton=null;
this._editor=null;
Telerik.Web.UI.ImageDialogCaller.callBaseMethod(this,"dispose");
},initialize:function(){
this._createInputElement();
this._createButton();
var _1b9=this.get_element();
_1b9.style.width=parseInt(this._inputElement.style.width)+30+"px";
_1b9.className=(this.get_skin()+" "+this._className);
},_createInputElement:function(){
var _1ba=document.createElement("INPUT");
_1ba.style.width=this.get_width();
this._inputElement=_1ba;
this.get_element().appendChild(_1ba);
},_createButton:function(){
var _1bb=document.createElement("A");
_1bb.title="Call Image Manager";
_1bb.href="javascript:void(0);";
_1bb.onclick=Function.createDelegate(this,this._onButtonClickHandler);
_1bb.innerHTML="<span>...</span>";
this.get_element().appendChild(_1bb);
this._pushButton=_1bb;
},_onButtonClickHandler:function(e){
var _1bd=this;
var _1be=function(_1bf,args){
var src="";
var img=args.Result;
if(img){
src=img.getAttribute("src",2);
}
if(src){
_1bd._inputElement.value=src;
_1bd.raiseEvent("valueSelected");
}
};
var args={editor:this.get_editor()};
this._editor.showDialog("ImageManager",args,_1be);
},get_editor:function(){
return this._editor;
},set_editor:function(_1c4){
this._editor=_1c4;
},get_value:function(){
return this._inputElement.value;
},set_value:function(_1c5){
if(null==_1c5){
_1c5="";
}
this._inputElement.value=_1c5;
},get_width:function(){
return this._width;
},set_width:function(_1c6){
this._width=_1c6;
},get_clientStateFieldID:function(){
return this._clientStateFieldID;
},set_clientStateFieldID:function(_1c7){
this._clientStateFieldID=_1c7;
}};
Telerik.Web.UI.ImageDialogCaller.registerClass("Telerik.Web.UI.ImageDialogCaller",Telerik.Web.UI.EditorButton);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.EditorDropDown=function(_1c8){
Telerik.Web.UI.EditorDropDown.initializeBase(this,[_1c8]);
this.isIE=$telerik.isIE;
this._popupVisible=false;
this._rendered=false;
this._childrenRendered=false;
this._popupElement=null;
this._itemRootElement=null;
this._onPopupClickDelegate=null;
this._onPopupMouseDownDelegate=null;
this._onPopupMouseOverDelegate=null;
this._items=[];
this._isArrayCollection=false;
this._selectedIndex=-1;
this._activeIndex=-1;
this._itemsPerRow=1;
this._sizeToFit=false;
this._clearSelectedOnShow=true;
this._rootPopupClassName="rade_dropDownBody";
this._popupClassName="";
this._popupWidth="200px";
this._popupHeight="200px";
};
Telerik.Web.UI.EditorDropDown.prototype={click:function(e){
this.show();
return $telerik.cancelRawEvent(e);
},dispose:function(){
Telerik.Web.UI.EditorDropDown.callBaseMethod(this,"dispose");
this.disposeChildren();
this.detachEventHandlers();
},isExpanded:function(){
return this._popupVisible;
},show:function(){
if(this._popupVisible){
return;
}
if(this.get_clearSelectedOnShow()){
this.set_selectedIndex(-1);
}
var _1ca=false;
if(!this._rendered){
this.render();
_1ca=true;
}
this.raiseEvent("show");
if(!this._childrenRendered){
this.renderChildren();
this._childrenRendered=true;
_1ca=true;
}
if(_1ca){
this._makeAllItemsUnselectable();
}
this._show();
},configurePopupPropertiesBeforeShow:function(){
this._popupBehavior.set_positioningMode(Telerik.Web.PositioningMode.BottomLeft);
},hide:function(){
if(this._popupBehavior){
this._popupBehavior.hide(true);
}
this._popupVisible=false;
this._getPopupVisibilityController().notifyPopupClosed(this);
this.raiseEvent("hide");
},onPopupMouseOver:function(e){
var _1cc=this.resolveActiveIndex(e);
if(_1cc>-1){
this.set_activeIndex(_1cc,e);
}
this._cancelEvent(e);
},_cancelEvent:function(e){
if(e){
e.preventDefault();
e.stopPropagation();
e.returnValue=false;
e.cancelBubble=true;
}
},_onPopupClick:function(e){
var _1cf=this.resolveActiveIndex(e);
this._cancelEvent(e);
if(_1cf>-1){
this._selectedIndex=_1cf;
this.hide();
this.raiseEvent("valueSelected");
}
},get_activeIndex:function(){
return this._activeIndex;
},set_activeIndex:function(_1d0,e){
this._activeIndex=_1d0;
this.selectUIItem(e);
},selectPreviousItem:function(){
var _1d2=this.get_activeIndex();
if(_1d2-1>=0){
this.set_activeIndex(_1d2-1);
}
},selectNextItem:function(){
var _1d3=this.get_activeIndex();
if(_1d3+1<this._items.length){
this.set_activeIndex(_1d3+1);
}
},selectUIItem:function(e,_1d5){
if(!this._popupElement){
return;
}
var _1d6=this._popupElement.getElementsByTagName("TD");
var len=_1d6.length;
var _1d8=this.get_activeIndex();
var _1d9=null;
for(var i=0;i<len;i++){
var _1db=_1d6[i];
if(_1db.item_index==_1d8){
_1db.className="rade_itemOver";
_1d9=_1db;
}else{
if(_1d5&&_1db.item_index<=_1d8){
_1db.className="rade_itemOver";
}else{
_1db.className="";
}
}
}
if(_1d9&&!e){
this._scrollIntoView(_1d9,_1d9.parentNode.parentNode.parentNode.parentNode);
}
return _1d9;
},_scrollIntoView:function(_1dc,_1dd){
if($telerik.isIE||!_1dd){
var _1de=_1dd;
_1de.scrollTop=0;
var _1df=_1de.getClientRects()[0];
var _1e0=_1df.top;
var _1e1=_1df.bottom;
var _1e2=_1dc.getClientRects()[0].bottom;
if(_1e2==0){
return;
}
while(_1e2>_1e1||_1e2<_1e0){
var _1e3="down";
if(_1e2<_1e0){
_1e3="up";
}
_1de.doScroll(_1e3);
_1e2=_1dc.getClientRects()[0].bottom;
}
}else{
if(_1dc.scrollIntoView){
_1dc.scrollIntoView(false);
}
}
},attachEventHandlers:function(){
if(!this._popupElement){
return;
}
this.detachEventHandlers();
this._onPopupMouseOverDelegate=Function.createDelegate(this,this.onPopupMouseOver);
$addHandler(this._popupElement,"mouseover",this._onPopupMouseOverDelegate);
this._onPopupClickDelegate=Function.createDelegate(this,this._onPopupClick);
$addHandler(this._popupElement,"mousedown",this._onPopupClickDelegate);
},detachEventHandlers:function(){
if(null!=this._onPopupMouseOverDelegate){
$removeHandler(this._popupElement,"mouseover",this._onPopupMouseOverDelegate);
this._onPopupMouseOverDelegate=null;
}
if(null!=this._onPopupClickDelegate){
$addHandler(this._popupElement,"mousedown",this._onPopupClickDelegate);
this._onPopupClickDelegate=null;
}
},disposeChildren:function(){
this._childrenRendered=false;
if(this._itemRootElement&&this._itemRootElement.parentNode){
var _1e4=this._itemRootElement;
this.renderItemRoot();
_1e4.parentNode.replaceChild(this._itemRootElement,_1e4);
}
},render:function(){
this._createUI();
this.renderHeader();
this.renderChildren();
this.renderFooter();
this._rendered=true;
this._childrenRendered=true;
},renderHeader:function(){
},renderFooter:function(){
},renderItemRoot:function(){
this._itemRootElement=this._getTable();
return this._itemRootElement;
},renderNewRow:function(){
return (this._itemRootElement.insertRow(-1));
},renderItemContainer:function(){
var _1e5=this._itemRootElement.rows[this._itemRootElement.rows.length-1];
var cell=_1e5.insertCell(-1);
return cell;
},renderChildren:function(){
for(var i=0;i<this._items.length;i++){
if(0==(i%this._itemsPerRow)){
this.renderNewRow();
}
var _1e8=this.renderItemContainer();
this.markItemContainer(_1e8,i);
this.renderChild(_1e8,this._items[i],i);
}
},renderChild:function(_1e9,_1ea,_1eb){
var _1ec=document.createElement("span");
if(_1ea){
var _1ed=null;
var _1ee=null;
if(_1ea instanceof Array){
_1ed=_1ea[1];
_1ee=_1ea[2];
}else{
_1ed=_1ea;
}
if(_1ee){
var _1ef=document.createElement("span");
_1ef.innerHTML="&nbsp;";
_1ef.className=_1ee;
_1ec.appendChild(_1ef);
}
if(_1ed){
_1ec.innerHTML+=_1ed;
_1ec.noWrap=true;
}
}
_1e9.innerHTML=_1ec.innerHTML;
},resolveActiveIndex:function(e){
var _1f1=e.target;
var _1f2=-1;
while(_1f1&&_1f1!=this._itemRootElement){
if(null!=_1f1.item_index){
_1f2=_1f1.item_index;
break;
}
_1f1=_1f1.parentNode;
}
return _1f2;
},markItemContainer:function(_1f3,_1f4){
_1f3.item_index=_1f4;
},_makeAllItemsUnselectable:function(){
if(!this._popupElement){
return;
}
this._popupElement.setAttribute("unselectable","on");
var _1f5=this._popupElement.getElementsByTagName("*");
var len=_1f5.length;
for(var i=0;i<len;i++){
_1f5[i].unselectable="on";
}
},_show:function(){
this.configurePopupPropertiesBeforeShow();
var _1f8=this._popupElement;
var _1f9=this.get_sizetofit();
var _1fa=_1f8.style.overflow;
if(_1f9){
_1f8.style.overflowY="hidden";
}
_1f8.style.width=this.get_popupwidth();
_1f8.style.height=this.get_popupheight();
this._itemRootElement.style.width="100%";
this._popupBehavior.show();
if(_1f9){
_1f8.style.width=this._getPopupChildrenWidth();
var _1fb=this._getPopupChildrenHeight();
if(_1fb!="0px"){
_1f8.style.height=_1fb;
}
}
this._popupBehavior.show();
this._getPopupVisibilityController().set_activePopup(this);
_1f8.style.zIndex="100000";
if(_1f9){
_1f8.style.overflowY=_1fa;
}
this._popupVisible=true;
},_getPopupChildrenWidth:function(){
var _1fc=this.get_popupElement().childNodes;
var _1fd=0;
for(var i=0;i<_1fc.length;i++){
var _1ff=_1fc[i].offsetWidth;
if(_1ff&&_1ff>_1fd){
_1fd=_1ff;
}
}
return _1fd+"px";
},_getPopupChildrenHeight:function(){
var _200=this.get_popupElement().childNodes;
var _201=0;
for(var i=0;i<_200.length;i++){
if(_200[i].offsetHeight){
_201+=_200[i].offsetHeight;
}
}
return _201+"px";
},_getPopupVisibilityController:function(){
return Telerik.Web.UI.Editor.PopupController;
},getUniqueID:function(){
if(!window["RadEditor_uniqueSeed"]){
window["RadEditor_uniqueSeed"]=new Date()-101;
}
if(!window["RadEditor_uniqueIdCounter"]){
window["RadEditor_uniqueIdCounter"]=1;
}else{
window["RadEditor_uniqueIdCounter"]++;
}
var _203=window["RadEditor_uniqueSeed"]-window["RadEditor_uniqueIdCounter"];
return "UniqueID"+_203;
},_createUI:function(){
if(this._popupBehavior){
return;
}
var _204=this.get_element();
if(!this._popupElement){
var _205=document.createElement("DIV");
$telerik.addCssClasses(_205,[this.get_skin(),this._rootPopupClassName,this.get_popupclassname()]);
this._popupElement=_205;
this._popupElement.style.display="none";
this._popupElement.style.position="absolute";
document.body.appendChild(this._popupElement);
}
this.renderItemRoot();
this._popupElement.appendChild(this._itemRootElement);
this._popupBehavior=$create(Telerik.Web.PopupBehavior,{"id":this.getUniqueID(),"parentElement":_204},null,null,this._popupElement);
this.attachEventHandlers();
},_getTable:function(){
var _206=document.createElement("table");
_206.border=0;
_206.cellPadding=0;
_206.setAttribute("unselectable","on");
_206.style.cursor="default";
return _206;
},get_clearSelectedOnShow:function(){
return this._clearSelectedOnShow;
},set_clearSelectedOnShow:function(_207){
this._clearSelectedOnShow=_207;
},get_popupElement:function(){
return this._popupElement;
},get_selectedItem:function(){
if(this._items&&this._selectedIndex>-1){
var item=this._items[this._selectedIndex];
var _209=((true==this._isArrayCollection)||(item instanceof Array))?item[0]:item;
return _209;
}
return null;
},get_selectedIndex:function(){
return this._selectedIndex;
},set_selectedIndex:function(_20a){
this._selectedIndex=_20a;
this.set_activeIndex(_20a);
},get_items:function(){
return this._items;
},set_items:function(_20b){
this.disposeChildren();
this._items=_20b;
},get_itemsperrow:function(){
return this._itemsPerRow;
},set_itemsperrow:function(_20c){
this._itemsPerRow=_20c;
},get_sizetofit:function(){
return this._sizeToFit;
},set_sizetofit:function(_20d){
this._sizeToFit=_20d;
},get_popupclassname:function(){
return this._popupClassName;
},set_popupclassname:function(_20e){
this._popupClassName=_20e;
},get_rootpopupclassname:function(){
return this._rootPopupClassName;
},set_rootpopupclassname:function(_20f){
this._rootPopupClassName=_20f;
},get_popupwidth:function(){
return this._popupWidth;
},set_popupwidth:function(_210){
this._popupWidth=_210;
},get_popupheight:function(){
return this._popupHeight;
},set_popupheight:function(_211){
this._popupHeight=_211;
},add_show:function(_212){
this.get_events().addHandler("show",_212);
},remove_show:function(_213){
this.get_events().removeHandler("show",_213);
},add_hide:function(_214){
this.get_events().addHandler("hide",_214);
},remove_hide:function(_215){
this.get_events().removeHandler("hide",_215);
}};
Telerik.Web.UI.EditorDropDown.registerClass("Telerik.Web.UI.EditorDropDown",Telerik.Web.UI.EditorButton);
Telerik.Web.UI.EditorUpdateableDropDown=function(_216){
Telerik.Web.UI.EditorUpdateableDropDown.initializeBase(this,[_216]);
};
Telerik.Web.UI.EditorUpdateableDropDown.prototype={updateValue:function(oVal){
if(null==oVal){
return;
}
try{
if(!oVal){
oVal=this.get_text();
}
var _218=this.getSpanElement();
if(_218){
this._value=(""+oVal).replace(/\s+/ig,"&nbsp;");
_218.innerHTML=this._value;
}
}
catch(e){
}
},get_value:function(){
if(!this._value||this._value==this.get_text()){
return "";
}
return this._value;
},set_value:function(oVal){
this.updateValue(oVal);
}};
Telerik.Web.UI.EditorUpdateableDropDown.registerClass("Telerik.Web.UI.EditorUpdateableDropDown",Telerik.Web.UI.EditorDropDown);
Telerik.Web.UI.EditorSelfUpdateableDropDown=function(_21a){
Telerik.Web.UI.EditorSelfUpdateableDropDown.initializeBase(this,[_21a]);
this._clientStateFieldID=null;
};
Telerik.Web.UI.EditorSelfUpdateableDropDown.prototype={_onPopupClick:function(e){
var _21c=this.resolveActiveIndex(e);
this._cancelEvent(e);
if(_21c>-1){
this._selectedIndex=_21c;
this.hide();
var _21d=this.get_selectedItem();
if(_21d){
this.updateValue(_21d);
}
this.raiseEvent("valueSelected");
}
},get_clientStateFieldID:function(){
return this._clientStateFieldID;
},set_clientStateFieldID:function(_21e){
this._clientStateFieldID=_21e;
}};
Telerik.Web.UI.EditorSelfUpdateableDropDown.registerClass("Telerik.Web.UI.EditorSelfUpdateableDropDown",Telerik.Web.UI.EditorUpdateableDropDown);
Telerik.Web.UI.EditorSplitButton=function(_21f){
Telerik.Web.UI.EditorSplitButton.initializeBase(this,[_21f]);
};
Telerik.Web.UI.EditorSplitButton.prototype={click:function(e){
var _221=this.isArrowClicked(e.target);
if(_221){
this.show();
}else{
var _222=this.get_selectedItem();
if(null==_222){
this.show();
}else{
this.raiseEvent("valueSelected");
}
}
return $telerik.cancelRawEvent(e);
},initialize:function(){
Telerik.Web.UI.EditorSplitButton.callBaseMethod(this,"initialize");
this.set_clearSelectedOnShow(false);
},isArrowClicked:function(_223){
var _224=this._getArrowElement();
if(_223==_224){
return true;
}
return false;
},_getArrowElement:function(){
var _225=this.getAnchorElement().getElementsByTagName("SPAN");
var _226=_225[_225.length-1];
return _226;
}};
Telerik.Web.UI.EditorSplitButton.registerClass("Telerik.Web.UI.EditorSplitButton",Telerik.Web.UI.EditorUpdateableDropDown);
Telerik.Web.UI.EditorToolStrip=function(_227){
Telerik.Web.UI.EditorToolStrip.initializeBase(this,[_227]);
this._tools=[];
this._udpateHeader=true;
};
Telerik.Web.UI.EditorToolStrip.prototype={selectUIItem:function(e){
for(var i=0;i<this._items.length;i++){
var tool=this._items[i];
if(i==this._activeIndex&&tool.get_enabled()){
tool.setOn(true);
}else{
tool.setOn(false);
if(this.isIE){
var a=tool.getAnchorElement();
if(a){
var newA=a.cloneNode(true);
a.replaceNode(newA);
}
}
}
}
},set_selectedIndex:function(_22d){
Telerik.Web.UI.EditorToolStrip.callBaseMethod(this,"set_selectedIndex",[_22d]);
if(this.get_updateHeader()){
var tool=this.get_selectedItem();
if(!tool||!tool.getSpanElement){
return;
}
var span=tool.getSpanElement();
if(span){
var _230=span.cloneNode(true);
var _231=this.getSpanElement();
var _232=_231.parentNode;
_232.replaceChild(_230,_231);
var _233=tool.getAnchorElement();
if(_233){
_232.setAttribute("title",_233.getAttribute("title"));
}
}
}
},_onPopupClick:function(e){
var tool=this._resolveSelectedTool(e);
this._cancelEvent(e);
if(tool){
var _236=Array.indexOf(this._items,tool);
if($telerik.isSafari){
this._selectedIndex=_236;
this.set_activeIndex(_236);
}else{
this.set_selectedIndex(_236);
}
this.hide();
this.raiseEvent("valueSelected");
}
},renderItemRoot:function(){
var _237=document.createElement("DIV");
_237.className="rade_tlbVertical";
_237.style.cssFloat="left";
_237.style.width="100%";
this._itemRootElement=_237;
return this._itemRootElement;
},renderChildren:function(){
var _238=this.get_itemsperrow();
var _239=this.get_tools();
var ul=document.createElement("UL");
ul.className="rade_toolbar "+this.get_skin();
this._itemRootElement.appendChild(ul);
for(var i=0;i<_239.length;i++){
if(_238>1&&i>1&&(i%this.get_itemsperrow()==0)){
ul=document.createElement("UL");
ul.className="rade_toolbar "+this.get_skin();
this._itemRootElement.appendChild(ul);
}
var _23c=_239[i];
if(null==_23c["showText"]){
_23c["showText"]=true;
}
var tool=Telerik.Web.UI.EditorButton.createTool(_23c,null,null,null,ul);
this._items[this._items.length]=tool;
}
},_resolveSelectedTool:function(e){
for(var i=0;i<this._items.length;i++){
var tool=this._items[i];
if(tool.isTarget(e)){
if(tool.get_enabled()){
return tool;
}else{
return null;
}
}
}
},get_tools:function(){
return this._tools;
},set_tools:function(_241){
this._tools=_241;
},get_updateHeader:function(){
return this._udpateHeader;
},set_updateHeader:function(_242){
this._udpateHeader=_242;
}};
Telerik.Web.UI.EditorToolStrip.registerClass("Telerik.Web.UI.EditorToolStrip",Telerik.Web.UI.EditorSplitButton);
Telerik.Web.UI.EditorContextMenu=function(_243){
Telerik.Web.UI.EditorContextMenu.initializeBase(this,[_243]);
this._parentElement=null;
this._eventObject=null;
};
Telerik.Web.UI.EditorContextMenu.prototype={initialize:function(){
this.set_updateHeader(false);
this.set_clearSelectedOnShow(true);
},show:function(){
this.set_activeIndex(-1);
Telerik.Web.UI.EditorContextMenu.callBaseMethod(this,"show");
},configurePopupPropertiesBeforeShow:function(){
var _244=this._popupBehavior;
_244.set_positioningMode(Telerik.Web.PositioningMode.Absolute);
var _245=this.get_parentElement();
if(_245){
_244.set_parentElement(_245);
}
var e=this._eventObject;
if(e){
_244.set_x(e.clientX+10);
_244.set_y(e.clientY+10);
}
},set_eventObject:function(_247){
this._eventObject=_247;
},get_tagName:function(){
return this._tagName;
},set_tagName:function(_248){
this._tagName=_248;
},get_parentElement:function(){
return this._parentElement;
},set_parentElement:function(_249){
this._parentElement=_249;
}};
Telerik.Web.UI.EditorContextMenu.registerClass("Telerik.Web.UI.EditorContextMenu",Telerik.Web.UI.EditorToolStrip);
Type.registerNamespace("Telerik.Web.UI.Editor");
Telerik.Web.UI.Editor.AlignmentSelector=function(_24a){
Telerik.Web.UI.Editor.AlignmentSelector.initializeBase(this,[_24a]);
this._popupWidth="78px";
this._popupHeight="100px";
this._popupClassName="rade_AlignmentSelector";
this._tagName="TD";
this._selectedTuple=null;
this._noAlignmentIndex=0;
this._itemsPerRow=3;
this._onValueSelectedDelegate=null;
this._clientStateFieldID=null;
};
Telerik.Web.UI.Editor.AlignmentSelector.prototype={initialize:function(){
Telerik.Web.UI.Editor.AlignmentSelector.callBaseMethod(this,"initialize");
this._onValueSelectedDelegate=Function.createDelegate(this,this._onDropDownValueSelected);
this.add_valueSelected(this._onValueSelectedDelegate);
this.setTagName(this._tagName);
this._configureAlignmentTable(this._tagName);
},dispose:function(){
Telerik.Web.UI.Editor.AlignmentSelector.callBaseMethod(this,"dispose");
this.remove_valueSelected(this._onValueSelectedDelegate);
},_imgAlignment:[["",""],["none",""],["",""],["",""],["top",""],["",""],["left",""],["absmiddle",""],["right",""],["",""],["bottom",""],["",""]],_cellAlignment:[["",""],["none",""],["",""],["left","top"],["center","top"],["right","top"],["left","middle"],["center","middle"],["right","middle"],["left","bottom"],["center","bottom"],["right","bottom"]],_tableAlignment:[["",""],["none",""],["",""],["left",""],["center",""],["right",""],["",""],["",""],["",""],["",""],["",""],["",""]],_captionIEAlignment:[["",""],["none",""],["",""],["left","top"],["center","top"],["right","top"],["",""],["",""],["",""],["left","bottom"],["center","bottom"],["right","bottom"]],_captionNSAlignment:[["",""],["none",""],["",""],["",""],["","top"],["",""],["",""],["",""],["",""],["",""],["","bottom"],["",""]],_alignmentClassName:["rade_NoAlignment","rade_NoAlignment","rade_NoAlignment","rade_TopLeft","rade_TopCenter","rade_TopRight","rade_MiddleLeft","rade_MiddleCenter","rade_MiddleRight","rade_BottomLeft","rade_BottomCenter","rade_BottomRight"],_getLookupTableByTagName:function(_24b){
switch(_24b.toUpperCase()){
case "IMG":
return this._imgAlignment;
case "TABLE":
return this._tableAlignment;
case "TD":
return this._cellAlignment;
case "TH":
return this._cellAlignment;
case "CAPTION":
return ($telerik.isIE?this._captionIEAlignment:this._captionNSAlignment);
default:
return null;
}
},_configureAlignmentTable:function(_24c){
if(!this._rendered){
this.render();
}
var _24d=this._itemRootElement;
var _24e=0;
for(var i=0;i<_24d.rows.length;i++){
var _250=false;
for(var j=0;j<_24d.rows[i].cells.length;j++){
var cell=_24d.rows[i].cells[j];
var _253=this._isAvailable(_24e++);
cell.style.visibility=_253?"visible":"hidden";
_250|=_253;
}
if(null!=document.all){
_24d.rows[i].style.display=_250?"":"none";
}
}
},_isAvailable:function(_254){
var _255=false;
if(this._items){
var _256=this._items[_254];
_255=((null!=_256)&&(""!=_256[0]||""!=_256[1]));
}
return _255;
},renderChild:function(_257,_258,_259){
var _25a=document.createElement("div");
if(_258){
_25a.innerHTML="&nbsp;";
_25a.className=this._alignmentClassName[_259];
}
_257.appendChild(_25a);
},_onDropDownValueSelected:function(){
this.set_selectedIndex(this.get_selectedIndex());
},_selectAlignment:function(_25b,_25c){
_25b=(""==_25b||!_25b)?"none":_25b.toUpperCase();
_25c=!_25c?"":_25c.toUpperCase();
if(this._items){
var _25d=-1;
for(i=0;i<this._items.length;i++){
if(this._isAvailable(i)){
var ha=this._items[i][0].toUpperCase();
var va=this._items[i][1].toUpperCase();
if(-1==_25d){
_25d=i;
}
if((_25b==ha||_25b==va)&&(_25c==ha||_25c==va)){
this.set_selectedIndex(i);
return;
}
}
}
this.set_selectedIndex(_25d);
}
},set_selectedIndex:function(_260){
Telerik.Web.UI.Editor.AlignmentSelector.callBaseMethod(this,"set_selectedIndex",[_260]);
var span=this.getSpanElement();
var _262=this._alignmentClassName[_260];
span.className=_262;
},setTagName:function(_263){
this._tagName=_263;
this._items=this._getLookupTableByTagName(this._tagName);
this.set_selectedIndex(this._noAlignmentIndex);
},updateValue:function(_264,_265){
this._selectAlignment(_264,_265);
},getAlign:function(){
var _266=this._items[this._selectedIndex];
var _267=(_266?_266[0]:"");
if("none"==_267){
_267="";
}
return _267;
},getVAlign:function(){
var _268=this._items[this._selectedIndex];
var _269=(_268?_268[1]:"");
if("none"==_269){
_269="";
}
return _269;
},show:function(){
Telerik.Web.UI.Editor.AlignmentSelector.callBaseMethod(this,"show");
this._itemRootElement.cellSpacing=0;
this._configureAlignmentTable(this._tagName);
},get_clientStateFieldID:function(){
return this._clientStateFieldID;
},set_clientStateFieldID:function(_26a){
this._clientStateFieldID=_26a;
}};
Telerik.Web.UI.Editor.AlignmentSelector.registerClass("Telerik.Web.UI.Editor.AlignmentSelector",Telerik.Web.UI.EditorSplitButton);
Telerik.Web.UI.Editor.InsertTableHelper=function(_26b){
Telerik.Web.UI.Editor.InsertTableHelper.initializeBase(this,[_26b]);
};
Telerik.Web.UI.Editor.InsertTableHelper.prototype={initialize:function(){
var _26c=new Array(this.get_itemsperrow()*this.get_itemsperrow());
for(var i=0;i<_26c.length;i++){
_26c[i]=i;
}
this._items=_26c;
},hide:function(){
},renderChild:function(_26e,_26f,_270){
var oDiv=document.createElement("div");
oDiv.innerHTML="&nbsp;";
_26e.appendChild(oDiv);
var dim=this._getDimensionByIndex(_270);
_26e.setAttribute("title"," "+dim.rows+" x "+dim.cols+" ");
},_getDimensionByIndex:function(_273){
var _274=0;
var _275=0;
var _276=this.get_itemsperrow();
for(var i=0;i<this._items.length;i++){
if(i%_276==0){
_274++;
_275=0;
}
_275++;
if(_273==i){
break;
}
}
var obj={rows:_274,cols:_275};
return obj;
},get_selectedItem:function(){
var _279=this.get_selectedIndex();
return this._getDimensionByIndex(_279);
},selectUIItem:function(e,_27b){
var _27c=this._popupElement.getElementsByTagName("TD");
var len=_27c.length;
var _27e=this.get_activeIndex();
var dim=this._getDimensionByIndex(_27e);
var cols=dim.cols;
for(var i=0;i<len;i++){
var _282=_27c[i];
var _283=_282.item_index;
if(_283<=_27e&&_282.cellIndex<cols){
_282.className="rade_itemOver";
}else{
_282.className="";
}
}
}};
Telerik.Web.UI.Editor.InsertTableHelper.registerClass("Telerik.Web.UI.Editor.InsertTableHelper",Telerik.Web.UI.EditorDropDown);
Telerik.Web.UI.Editor.InsertTable=function(_284){
Telerik.Web.UI.Editor.InsertTable.initializeBase(this,[_284]);
};
Telerik.Web.UI.Editor.InsertTable.prototype={initialize:function(){
Telerik.Web.UI.Editor.InsertTable.callBaseMethod(this,"initialize");
this._onTableHelperValueSelectedDelegate=Function.createDelegate(this,this._onTableHelperValueSelected);
this._tableHelper=null;
this._tableHelperItemsPerRow=this.get_itemsperrow();
this.set_itemsperrow(6);
this.set_popupwidth("140px");
var _285=this.get_tools();
this._longTool=_285[0];
Array.removeAt(_285,0);
for(var i=0;i<_285.length;i++){
_285[i].showText=false;
}
},show:function(){
Telerik.Web.UI.Editor.InsertTable.callBaseMethod(this,"show");
this._tableHelper.set_selectedIndex(-1);
},_onPopupClick:function(e){
this._tableHelperClicked=false;
Telerik.Web.UI.Editor.InsertTable.callBaseMethod(this,"_onPopupClick",[e]);
},_onTableHelperValueSelected:function(){
this._tableHelperClicked=true;
this.set_selectedIndex(-1);
var span=this.getSpanElement();
span.className="InsertTable";
this.hide();
this.raiseEvent("valueSelected");
},get_selectedItem:function(){
if(this._tableHelperClicked){
return this._tableHelper.get_selectedItem();
}else{
return Telerik.Web.UI.Editor.InsertTable.callBaseMethod(this,"get_selectedItem");
}
},renderHeader:function(){
var args={"skin":this.get_skin(),"itemsperrow":this._tableHelperItemsPerRow,"sizetofit":true};
var _28a={"valueSelected":this._onTableHelperValueSelectedDelegate};
var tool=$create(Telerik.Web.UI.Editor.InsertTableHelper,args,_28a,null,document.createElement("DIV"));
tool.set_rootpopupclassname("");
this._tableHelper=tool;
tool.render();
var _28c=tool.get_popupElement();
_28c.style.display="";
_28c.style.visibility="visible";
_28c.style.position="";
_28c.style.cssFloat="left";
var _28d=this.get_popupElement();
_28d.insertBefore(_28c,_28d.firstChild);
},renderChildren:function(){
Telerik.Web.UI.Editor.InsertTable.callBaseMethod(this,"renderChildren");
var _28e=this._itemRootElement;
if(this._longTool){
var ul=document.createElement("UL");
_28e.insertBefore(ul,_28e.firstChild);
this._longTool["showText"]=true;
var tool=Telerik.Web.UI.EditorButton.createTool(this._longTool,null,null,null,ul);
tool.get_element().style.width="auto";
this._items[this._items.length]=tool;
}
}};
Telerik.Web.UI.Editor.InsertTable.registerClass("Telerik.Web.UI.Editor.InsertTable",Telerik.Web.UI.EditorToolStrip);
Telerik.Web.UI.Editor.ColorPicker=function(_291){
Telerik.Web.UI.Editor.ColorPicker.initializeBase(this,[_291]);
this._onValueSelectedDelegate=Function.createDelegate(this,this._onDropDownValueSelected);
this._itemsPerRow=10;
this._popupClassName="rade_ColorPicker";
this._sizeToFit=true;
this._clientStateFieldID=null;
};
Telerik.Web.UI.Editor.ColorPicker.prototype={initialize:function(){
Telerik.Web.UI.Editor.ColorPicker.callBaseMethod(this,"initialize");
this.add_valueSelected(this._onValueSelectedDelegate);
},dispose:function(){
Telerik.Web.UI.Editor.ColorPicker.callBaseMethod(this,"dispose");
this.remove_valueSelected(this._onValueSelectedDelegate);
},_onDropDownValueSelected:function(){
var _292=this.get_selectedItem();
this.set_color(_292);
},set_color:function(_293){
if(!_293){
_293="";
}
var _294=this.getSpanElement();
_294.style.borderBottom="0px";
_294.style.height="";
if(_293){
var _295=_294.offsetHeight;
if(_295){
_294.style.height=(_295-3)+"px";
}
_294.style.borderBottom="3px solid "+_293;
}
this._color=_293;
},get_color:function(){
return this._color;
},onPopupMouseOver:function(e){
Telerik.Web.UI.Editor.ColorPicker.callBaseMethod(this,"onPopupMouseOver",[e]);
var _297=this.get_activeIndex();
var _298=this._items[_297];
if(null==_298){
return;
}
if(this._infoSpan1){
this._infoSpan1.innerHTML=_298;
this._infoSpan1.style.backgroundColor=_298;
}
if(this._infoSpan2){
this._infoSpan2.innerHTML=_298;
this._infoSpan2.style.color=_298;
}
},renderFooter:function(){
var oDiv=document.createElement("div");
oDiv.className="rade_ColorPickerFooter";
var _29a=document.createElement("span");
_29a.className="rade_DarkColor";
var _29b=document.createElement("span");
_29b.className="rade_LightColor";
_29a.innerHTML=_29b.innerHTML="&nbsp";
oDiv.appendChild(_29a);
oDiv.appendChild(_29b);
this.get_popupElement().appendChild(oDiv);
this._infoSpan1=_29a;
this._infoSpan2=_29b;
},renderChild:function(_29c,_29d,_29e){
var oDiv=document.createElement("div");
if(null!=_29d){
oDiv.style.backgroundColor=_29d;
oDiv.setAttribute("title",_29d);
oDiv.innerHTML="&nbsp;";
}
_29c.appendChild(oDiv);
},get_clientStateFieldID:function(){
return this._clientStateFieldID;
},set_clientStateFieldID:function(_2a0){
this._clientStateFieldID=_2a0;
}};
Telerik.Web.UI.Editor.ColorPicker.registerClass("Telerik.Web.UI.Editor.ColorPicker",Telerik.Web.UI.EditorSplitButton);
Telerik.Web.UI.Editor.UndoRedoDropDown=function(_2a1){
Telerik.Web.UI.Editor.UndoRedoDropDown.initializeBase(this,[_2a1]);
};
Telerik.Web.UI.Editor.UndoRedoDropDown.prototype={renderFooter:function(){
},get_selectedItem:function(){
var _2a2=Telerik.Web.UI.Editor.UndoRedoDropDown.callBaseMethod(this,"get_selectedItem");
if(!_2a2){
_2a2=1;
}
return _2a2;
},selectUIItem:function(e,_2a4){
return Telerik.Web.UI.Editor.UndoRedoDropDown.callBaseMethod(this,"selectUIItem",[e,true]);
}};
Telerik.Web.UI.Editor.UndoRedoDropDown.registerClass("Telerik.Web.UI.Editor.UndoRedoDropDown",Telerik.Web.UI.EditorSplitButton);
Telerik.Web.UI.Editor.ApplyClassDropDown=function(_2a5){
Telerik.Web.UI.Editor.ApplyClassDropDown.initializeBase(this,[_2a5]);
this._popupClassName="rade_ApplyClass";
this._onValueSelectedDelegate=null;
this._clientStateFieldID=null;
this._isArrayCollection=true;
};
Telerik.Web.UI.Editor.ApplyClassDropDown.prototype={initialize:function(){
Telerik.Web.UI.Editor.ApplyClassDropDown.callBaseMethod(this,"initialize");
this._onValueSelectedDelegate=Function.createDelegate(this,this._onDropDownValueSelected);
this.add_valueSelected(this._onValueSelectedDelegate);
this._cssClassRegex=/[^\{]*\{([^\}]+)\}/gi;
this._cssClasses={a:"rade_class_a",img:"rade_class_img",table:"rade_class_table",td:"rade_class_td",all:"rade_class_all",unknown:"rade_class_unknown"};
},dispose:function(){
Telerik.Web.UI.Editor.ApplyClassDropDown.callBaseMethod(this,"dispose");
this.remove_valueSelected(this._onValueSelectedDelegate);
},_onDropDownValueSelected:function(){
this.updateValue(this.get_selectedItem());
},_getClassIcon:function(tag){
var _2a7="";
if(!tag){
_2a7=this._cssClasses["notag"];
}else{
tag=tag.toLowerCase();
var res=this._cssClasses[tag];
_2a7=res?res:this._cssClasses["unknown"];
}
var _2a9=document.createElement("span");
_2a9.innerHTML="&nbsp;"+tag;
_2a9.className=_2a7;
return _2a9;
},_getClassTag:function(rule){
var str=rule&&rule.selectorText?rule.selectorText:"";
var _2ac=str.lastIndexOf(".");
if(_2ac==0){
return "ALL";
}
var _2ad=str.lastIndexOf(" ",_2ac);
return str.substring((_2ad+1),_2ac);
},_getClassCss:function(_2ae){
var re=this._cssClassRegex;
var oCss="";
if(null!=_2ae.cssText){
oCss=_2ae.cssText;
oCss=oCss.replace(re,"$1");
}else{
oCss=_2ae.style.cssText;
}
return oCss;
},_getDisplayName:function(rule){
if(!rule||!rule.selectorText){
return "";
}
var _2b2=rule.selectorText;
var _2b3=_2b2.indexOf(".");
if(-1==_2b3){
_2b3=0;
}else{
_2b3+=1;
}
var _2b4=_2b2.indexOf(":");
if(-1==_2b4){
_2b4=_2b2.length;
}
return _2b2.substring(_2b3,_2b4);
},_getClassName:function(rule){
var str=rule&&rule.selectorText?rule.selectorText:"";
var _2b7=str.lastIndexOf(".");
if(_2b7==-1){
return "";
}
var _2b8=str.indexOf(" ",_2b7);
if(-1==_2b8){
_2b8=str.indexOf(":",_2b7);
}
if(-1==_2b8){
_2b8=str.length;
}
return str.substring((_2b7+1),_2b8);
},_getChild:function(_2b9,_2ba,_2bb){
var elem=document.createElement("DIV");
if(_2ba.toLowerCase()=="a"){
elem=document.createElement("A");
elem.href="#";
elem.onmouseover="window.status = ''; return false;";
elem.onclick=new Function("return false;");
elem.style.cursor="default";
}
if(null!=elem.style.cssText){
elem.style.cssText=_2b9;
}
elem.setAttribute("style",_2b9);
elem.innerHTML=_2bb;
elem.style.visibility="visible";
elem.style.marginLeft="0px";
elem.style.overflowX="hidden";
elem.style.position="";
elem.style.cssFloat="";
elem.style.styleFloat="";
return elem;
},set_items:function(_2bd){
Telerik.Web.UI.Editor.ApplyClassDropDown.callBaseMethod(this,"set_items",[_2bd]);
this._items.splice(0,0,["",{cssText:"",selectorText:"Clear Class"}]);
},renderChild:function(cell,_2bf,_2c0){
var _2c1=_2bf[1];
var oTag=this._getClassTag(_2c1);
var oCss=this._getClassCss(_2c1);
var _2c4=_2bf[2]?_2bf[2]:this._getDisplayName(_2c1);
cell.setAttribute("title",_2c1.selectorText);
var _2c5=this._getClassIcon(oTag);
cell.appendChild(_2c5);
var div=this._getChild(oCss,oTag,_2c4);
cell.appendChild(div);
},get_clientStateFieldID:function(){
return this._clientStateFieldID;
},set_clientStateFieldID:function(_2c7){
this._clientStateFieldID=_2c7;
}};
Telerik.Web.UI.Editor.ApplyClassDropDown.registerClass("Telerik.Web.UI.Editor.ApplyClassDropDown",Telerik.Web.UI.EditorUpdateableDropDown);
Telerik.Web.UI.Editor.FontNameDropDown=function(_2c8){
Telerik.Web.UI.Editor.FontNameDropDown.initializeBase(this,[_2c8]);
};
Telerik.Web.UI.Editor.FontNameDropDown.prototype={updateValue:function(oVal){
try{
if(!oVal){
oVal=this.get_text();
}
if(null==oVal||"AZBY"==oVal){
return;
}
var _2ca=this.getSpanElement();
if(_2ca){
this._value=(""+oVal).replace(/\s+/ig,"&nbsp;");
_2ca.innerHTML=this._value;
}
}
catch(e){
}
},renderChildren:function(){
var _2cb=this._items;
if(_2cb&&_2cb[0]&&!(_2cb[0] instanceof Array)){
for(var i=0;i<_2cb.length;i++){
var item=_2cb[i];
_2cb[i]=[item,String.format("<span style='font:normal 13px {0};'>",item)+item+"</span>"];
}
}
return Telerik.Web.UI.Editor.FontNameDropDown.callBaseMethod(this,"renderChildren");
}};
Telerik.Web.UI.Editor.FontNameDropDown.registerClass("Telerik.Web.UI.Editor.FontNameDropDown",Telerik.Web.UI.EditorUpdateableDropDown);
Telerik.Web.UI.Editor.FontSizeDropDown=function(_2ce){
Telerik.Web.UI.Editor.FontSizeDropDown.initializeBase(this,[_2ce]);
};
Telerik.Web.UI.Editor.FontSizeDropDown.prototype={renderChildren:function(){
var _2cf=this._items;
if(_2cf&&_2cf[0]&&!(_2cf[0] instanceof Array)){
for(var i=0;i<_2cf.length;i++){
var item=_2cf[i];
_2cf[i]=[item,String.format("<font size={0}>",item)+item+"</font>"];
}
}
return Telerik.Web.UI.Editor.FontSizeDropDown.callBaseMethod(this,"renderChildren");
}};
Telerik.Web.UI.Editor.FontSizeDropDown.registerClass("Telerik.Web.UI.Editor.FontSizeDropDown",Telerik.Web.UI.EditorUpdateableDropDown);
Telerik.Web.UI.Editor.InsertCustomLinkDropDown=function(_2d2){
Telerik.Web.UI.Editor.InsertCustomLinkDropDown.initializeBase(this,[_2d2]);
};
Telerik.Web.UI.Editor.InsertCustomLinkDropDown.prototype={renderItemRoot:function(){
var ul=document.createElement("UL");
ul.className="rade_CustomLinks";
this._itemRootElement=ul;
return this._itemRootElement;
},show:function(){
this._linkCounter=0;
return Telerik.Web.UI.Editor.InsertCustomLinkDropDown.callBaseMethod(this,"show");
},renderChildren:function(){
this.FlatLinksArray=[];
for(var i=0;i<this._items.length;i++){
var link=this._items[i];
this._parseSubtree(link,this._itemRootElement);
}
},get_selectedItem:function(){
var _2d6=this.FlatLinksArray[this.get_selectedIndex()];
return {innerHTML:_2d6.name,href:_2d6.href,target:_2d6.target,title:_2d6.toolTip};
},_parseSubtree:function(_2d7,t){
var _2d9=this._linkCounter;
this.FlatLinksArray[_2d9]=_2d7;
var li=document.createElement("LI");
t.appendChild(li);
var _2db=_2d7.childLinks&&_2d7.childLinks.length;
var span=document.createElement("SPAN");
span.innerHTML="&nbsp;";
span.className=_2db?"rade_CustomLinksIcon rade_icon_plus":"rade_CustomLinksIcon rade_icon_empty";
if(_2db){
function onclick(e){
var _2de=Sys.UI.DomElement.containsCssClass(this,"rade_icon_plus");
var ul=this.parentNode.getElementsByTagName("UL")[0];
if(ul){
ul.style.display=_2de?"":"none";
var _2e0=_2de?"rade_icon_plus":"rade_icon_minus";
var _2e1=_2de?"rade_icon_minus":"rade_icon_plus";
Sys.UI.DomElement.removeCssClass(this,_2e0);
Sys.UI.DomElement.addCssClass(this,_2e1);
}
return false;
}
$addHandler(span,"click",onclick);
}
li.appendChild(span);
var _2e2=null;
if(_2d7.href){
_2e2=document.createElement("A");
_2e2.href="#";
_2e2.innerHTML=_2d7.name;
li.appendChild(_2e2);
this.markItemContainer(_2e2,this._linkCounter);
}else{
_2e2=document.createElement("SPAN");
_2e2.innerHTML=_2d7.name;
li.appendChild(_2e2);
}
this._linkCounter++;
if(_2db){
var ul=document.createElement("UL");
li.appendChild(ul);
var _2e4=_2d7.childLinks;
for(var i=0;i<_2d7.childLinks.length;i++){
var _2e6=_2e4[i];
this._parseSubtree(_2e6,ul);
}
ul.style.display="none";
}
}};
Telerik.Web.UI.Editor.InsertCustomLinkDropDown.registerClass("Telerik.Web.UI.Editor.InsertCustomLinkDropDown",Telerik.Web.UI.EditorDropDown);
Type.registerNamespace("Telerik.Web.UI");
Type.registerNamespace("Telerik.Web.UI.Editor");
Telerik.Web.UI.Editor._PopupController=function(){
this._activePopup=null;
this._registerGlobalBodyEventHandlers();
};
Telerik.Web.UI.Editor._PopupController.prototype={_registerGlobalBodyEventHandlers:function(){
function configureFrameHandlers(_2e7,_2e8){
var _2e9=window.frames;
for(var i=0;i<_2e9.length;i++){
var _2eb=null;
try{
_2eb=_2e9[i].window.document;
}
catch(e){
}
if(!_2eb){
continue;
}
try{
if(false!=_2e7){
_2e8.attachToDocument(_2eb);
}else{
_2e8.detachFromDocument(_2eb);
}
}
catch(e){
}
}
}
var _2ec=Function.createDelegate(null,function(e){
if(e.keyCode==27){
Telerik.Web.UI.Editor.PopupController.hideActivePopup();
}
});
$addHandler(document.body,"keydown",_2ec);
configureFrameHandlers(true,this);
$addHandler(document.body,"mousedown",this._hideHandler);
Sys.Application.add_unload(function(){
configureFrameHandlers(false,Telerik.Web.UI.Editor.PopupController);
$removeHandler(document.body,"mousedown",Telerik.Web.UI.Editor.PopupController._hideHandler);
$removeHandler(document.body,"keydown",_2ec);
});
},attachToDocument:function(_2ee){
$telerik.addExternalHandler(_2ee,"mousedown",this._hideHandler);
},detachFromDocument:function(_2ef){
$telerik.removeExternalHandler(_2ef,"mousedown",this._hideHandler);
},_hideHandler:function(e){
Telerik.Web.UI.Editor.PopupController._hideIfOutsidePopup(e);
},hideActivePopup:function(){
if(this._activePopup!=null){
this._activePopup.hide();
this._activePopup=null;
}
},_hideIfOutsidePopup:function(e){
if(this._activePopup!=null){
if(!this._activePopup.get_popupElement){
return;
}
var _2f2=this._activePopup.get_popupElement();
if(!this._isMouseOverElement(e,_2f2)){
this.hideActivePopup();
}
}
},_isMouseOverElement:function(e,_2f4){
var rect=null;
try{
rect=$telerik.getBounds(_2f4);
}
catch(e){
return false;
}
if(e&&e.target&&e.target.tagName=="SELECT"&&e.clientX<0){
return true;
}
var body=(document.compatMode&&document.compatMode!="BackCompat")?document.documentElement:document.body;
var x=e.clientX-2+body.scrollLeft;
var y=e.clientY-2+body.scrollTop;
return $telerik.containsPoint(rect,x,y);
},notifyPopupClosed:function(_2f9){
if(this._activePopup==_2f9){
this._activePopup=null;
}
},set_activePopup:function(_2fa){
if(this._activePopup&&(_2fa!=this._activePopup)){
this._activePopup.hide();
}
this._activePopup=_2fa;
},get_activePopup:function(){
return this._activePopup;
}};
Telerik.Web.UI.Editor._PopupController.registerClass("Telerik.Web.UI.Editor._PopupController",null);
if(!Telerik.Web.UI.Editor.PopupController){
Sys.Application.add_load(function(){
window.setTimeout(function(){
Telerik.Web.UI.Editor.PopupController=new Telerik.Web.UI.Editor._PopupController();
},100);
});
}
Type.registerNamespace("Telerik.Web.UI");
Type.registerNamespace("Telerik.Web.UI.Editor");
Telerik.Web.UI.Editor.DefaultToolAdapter=function(_2fb){
Telerik.Web.UI.Editor.DefaultToolAdapter.initializeBase(this,[_2fb]);
this._editor=null;
this._toolJSON=[];
this._tools=[];
this._contextMenusEnabled=true;
this.isIE=$telerik.isIE;
this._editorIEFirstShow=false;
};
Telerik.Web.UI.Editor.DefaultToolAdapter._visibleWrapper=null;
Telerik.Web.UI.Editor.DefaultToolAdapter.prototype={initialize:function(){
this._onEditorSelectionChangeDelegate=Function.createDelegate(this,this._onEditorSelectionChange);
this._onEditorModeChangeDelegate=Function.createDelegate(this,this._onEditorModeChange);
this._onToolAdapterClickDelegate=Function.createDelegate(this,this._onToolBarClick);
this._onToolAdapterKeyDownDelegate=Function.createDelegate(this,this._onKeyDownHandler);
this._onDropDownValueSelectedDelegate=Function.createDelegate(this,this._onDropDownValueSelected);
this._onDropDownBeforeShowDelegate=Function.createDelegate(this,this._onDropDownBeforeShow);
this._onDropDownHideDelegate=Function.createDelegate(this,this._onDropDownHide);
this._initContextMenus();
this._registerEditorHandlers();
var _2fc=Telerik.Web.UI.EditorToolbarMode;
var _2fd=this.get_editor();
switch(_2fd.get_toolbarMode()){
case _2fc.Default:
_2fd.add_firstShow(Function.createDelegate(this,function(){
this._hookToolbarJson2Html();
var _2fe=this.get_editor();
var _2ff=_2fe.get_element().style.height;
_2fe._updateEditorSize(_2ff);
}));
break;
case _2fc.Floating:
this._createFloatingButton();
break;
case _2fc.PageTop:
case _2fc.ShowOnFocus:
this._hookToolbarModeEventHandlers();
break;
}
},_hookToolbarJson2Html:function(){
if(this._initializedToolbars){
return;
}
this._initializedToolbars=true;
var _300=this.get_toolJSON();
var _301=this._getToolBarElements();
var _302=[];
for(var i=0;i<_300.length;i++){
var json=_300[i];
var _305=_301[i];
this._initializeToolbar(json,_305);
var _306=json["attributes"];
var zone=_306?_306["dockingzone"]:null;
if(zone){
_302[_302.length]=[zone,_305];
}
}
if($telerik.isIE){
var elem=this.get_element();
elem.style.height="";
}
var _309=this.get_editor();
var _30a=_309.get_id();
for(var i=0;i<_302.length;i++){
var _30b=_302[i][0];
var zone=_30b.charAt(0).toUpperCase()+_30b.substring(1);
var _30c=$get(_30a+zone);
if(!_30c){
_30c=$get(_30b);
}
if(_30c){
if(_30c.innerHTML=="&nbsp;"){
_30c.innerHTML="";
}
_30c.appendChild(_302[i][1]);
}
}
},_initNonDefaultToolbarMode:function(){
var _30d=this.get_editor();
var _30e=Telerik.Web.UI.EditorToolbarMode;
var _30f=_30d.get_toolbarMode();
if(_30f==_30e.ShowOnFocus){
var wnd=this._toolbarHolder;
var _311=Telerik.Web.UI.WindowBehaviors;
wnd.set_behaviors(_311.Resize);
wnd.set_visibleTitlebar(false);
}else{
if(_30f==_30e.PageTop){
var wnd=this._toolbarHolder;
wnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.None);
wnd.set_visibleTitlebar(false);
}
}
var _312=this.get_element();
_312.style.visibility="visible";
},_showToolbarHolder:function(_313){
if(!_313){
if(this._toolbarHolder){
this._toolbarHolder.hide();
}
return;
}else{
if($telerik.isIE&&!this._editorIEFirstShow){
if(this.get_editor().get_toolbarMode()!=Telerik.Web.UI.EditorToolbarMode.Floating){
this._editorIEFirstShow=true;
return;
}
}
}
if(this.get_editor().isFullScreen()){
return;
}
var _314=Telerik.Web.UI.Editor.DefaultToolAdapter._visibleWrapper;
if(_314==this&&_314._toolbarHolder&&_314._toolbarHolder.isVisible()){
_314.get_toolbarHolder().setActive(true);
return;
}
if(_314&&_314._showToolbarHolder){
_314._showToolbarHolder(false);
}
Telerik.Web.UI.Editor.DefaultToolAdapter._visibleWrapper=this;
this.get_window();
this._initNonDefaultToolbarMode();
this._toolbarHolder.show();
},_positionWindow:function(){
var _315=Telerik.Web.UI.EditorToolbarMode;
var _316=this.get_editor();
var _317=_316.get_toolbarMode();
if(_317==_315.ShowOnFocus){
this._positionToolbarAboveEditor();
}else{
if(_317==_315.PageTop){
this._positionOnPageTop();
}else{
if(_317==_315.Floating){
if(!this._wasShown){
this._positionToolbarAboveEditor();
this._wasShown=true;
}
}
}
}
},get_window:function(){
if(!this._toolbarHolder){
var _318=this.get_editor();
var _319=_318.get_dialogOpener();
if(!_319){
return;
}
var wnd=_319.get_container().clone(_318.get_id()+"_toolbarMode");
wnd.set_visibleStatusbar(false);
var _31b=this.get_element();
var _31c=_31b.offsetWidth;
wnd.setSize(_31c+10,"");
wnd.add_show(Function.createDelegate(this,function(_31d,args){
var _31f=_31d.get_contentElement();
if(!_31f){
return;
}
var _320=_31d.get_popupElement();
_320.style.zIndex="10000";
this._hookToolbarJson2Html();
_31f.style.overflow="";
_31f.style.height="";
var _321=_31f.offsetWidth;
_31f.style.width=_321+"px";
var _322=_318.get_toolsWidth();
if(!_322){
var _323=_31d.getWindowBounds();
_322=_323.width;
}
_31d.setSize(_322,"");
_31f.style.width="100%";
this._positionWindow();
}));
this._toolbarHolder=wnd;
this._moveToolbarsToEditor(false);
}
return this._toolbarHolder;
},_moveToolbarsToEditor:function(_324){
var _325=this.get_element();
if(!_324){
if(!this._fakeToolbarParentCreated){
var div=_325.ownerDocument.createElement("DIV");
div.control=_325.control;
_325.parentNode.appendChild(div);
this._fakeToolbarParentCreated=true;
_325.control=null;
var _327=div.style;
_327.height=_327.fontSize=_327.lineHeight="1px";
_327.border="1px solid red";
_327.visibility="hidden";
if(!$telerik.isIE){
_327.display="none";
}
}
var wnd=this.get_toolbarHolder();
wnd.set_contentElement(_325);
_325.style.width="100%";
}else{
_325.style.width="";
var _329=this.get_editor().get_TopZone();
_329.appendChild(_325);
}
},_positionToolbarAboveEditor:function(){
var wnd=this._toolbarHolder;
var _32b=this.get_editor();
var _32c=$telerik.getBounds(_32b.get_element());
var x=_32c.x;
var _32e=$telerik.getBounds(wnd.get_popupElement()).height;
var y=_32c.y-_32e;
wnd.moveTo(x,y);
},_positionOnPageTop:function(){
var wnd=this._toolbarHolder;
var _331=wnd._getViewportBounds();
var x=_331.scrollLeft;
var y=_331.scrollTop;
wnd.moveTo(x,y);
wnd.set_width("");
if(!wnd.isPinned()){
wnd.togglePin();
}
},_createFloatingButton:function(){
this._onToggleFloatingToolbarDelegate=Function.createDelegate(this,this._onToggleFloatingToolbar);
var _334=this.get_editor();
var skin=_334.get_skin();
var _336={name:"ToggleFloatingToolbar",addClickHandler:true,skin:skin};
var _337={"valueSelected":this._onToggleFloatingToolbarDelegate};
var _338=Telerik.Web.UI.EditorButton.createTool(_336,_337);
var _339=Telerik.Web.UI.EditorButton.createToolWrapper(_338,skin);
var _33a=$get(_334.get_id()+"Top");
if(_33a){
_33a.appendChild(_339);
}
},_onToggleFloatingToolbar:function(){
var _33b=!this._toolbarHolder||!this._toolbarHolder.isVisible();
this._showToolbarHolder(_33b);
},_hookToolbarModeEventHandlers:function(){
var _33c=this;
var _33d=function(){
_33c._showToolbarHolder(true);
};
var _33e=this.get_editor();
if(_33e.isIE){
this.get_editor().add_editReady(function(){
_33e.attachEventHandler("beforeeditfocus",_33d);
});
}else{
_33e.add_selectionChange(_33d);
}
_33e.add_modeChange(function(){
_33c._showToolbarHolder(_33c.get_editor().get_mode()==Telerik.Web.UI.EditModes.Design);
});
_33e.add_submit(function(){
_33c._showToolbarHolder(false);
});
_33e.add_toggleScreenMode(function(){
var _33f=_33c.get_editor().isFullScreen();
_33c._moveToolbarsToEditor(_33f);
var wnd=_33c.get_toolbarHolder();
if(_33f){
wnd.hide();
}else{
wnd.show();
}
});
this._bodyClickDelegate=Function.createDelegate(this,this._onBodyClick);
$addHandler(document.body,"click",this._bodyClickDelegate);
},_disposeToolbarModeHandlers:function(){
if(this._bodyClickDelegate){
$removeHandler(document.body,"click",this._bodyClickDelegate);
this._bodyClickDelegate=null;
}
},onContextMenu:function(e){
if(!this._contextMenusEnabled){
return;
}
var _342=this.get_editor();
if(_342.get_mode()!=Telerik.Web.UI.EditModes.Design){
return;
}
this.createContextMenus();
var _343=e.srcElement?e.srcElement:e.target;
var _344=_343.tagName;
var _345=this._contextMenus[_344];
if("TH"==_344&&!_345){
_345=this._contextMenus["TD"];
}
var _346="";
if(!_345){
var _347=Telerik.Web.UI.Editor.Utils.getElementParentByTag(_343,"A");
if(!_347){
_347=Telerik.Web.UI.Editor.Utils.getElementParentByTag(_343,"TD");
}
if(!_347){
_347=Telerik.Web.UI.Editor.Utils.getElementParentByTag(_343,"TABLE");
}
if(_347){
_346=_347.tagName;
_343=_347;
}else{
_346="*";
}
_345=this._contextMenus[_346];
}
if(_345&&_344=="IMG"&&_343&&"true"==_343.getAttribute("isflash")){
_345=null;
}
if(!this.isIE&&_346=="*"){
return;
}
if(_345){
_345.set_eventObject(e);
_345.show();
}
return $telerik.cancelRawEvent(e);
},enableContextMenus:function(_348){
this._contextMenusEnabled=_348;
},_initContextMenus:function(){
var _349=Function.createDelegate(this,this.onContextMenu);
var _34a=this.get_editor();
_34a.add_editReady(function(){
_34a.attachEventHandler("contextmenu",_349);
});
},createContextMenus:function(){
if(this._contextMenus){
return;
}
this._contextMenus={};
var _34b=this.get_editor();
var skin=_34b.get_skin();
var _34d=_34b.get_contextMenusJSON();
var _34e={"valueSelected":this._onDropDownValueSelectedDelegate,"show":this._onDropDownBeforeShowDelegate,"hide":this._onDropDownHideDelegate};
for(var i=0;i<_34d.length;i++){
var args=_34d[i];
args["sizetofit"]=true;
args["parentElement"]=_34b.get_contentAreaElement();
args["skin"]=skin;
var tool=$create(Telerik.Web.UI.EditorContextMenu,args,_34e,null,document.createElement("SPAN"));
this._contextMenus[args.tagName]=tool;
}
},dispose:function(){
var _352=this._getToolBarElements();
for(var i=0;i<_352.length;i++){
$clearHandlers(_352[i]);
}
this._tools=[];
this._disposeToolbarModeHandlers();
var wnd=this._toolbarHolder;
if(wnd&&wnd.dispose){
wnd.dispose();
}
Telerik.Web.UI.Editor.DefaultToolAdapter.callBaseMethod(this,"dispose");
},setFocus:function(){
var tool=this._tools[0];
window.setTimeout(function(){
if(tool){
tool.setFocus();
}
},100);
return false;
},getContextMenuByTagName:function(_356){
this.createContextMenus();
return this._contextMenus[_356];
},getToolByName:function(name){
for(var i=0;i<this._tools.length;i++){
var tool=this._tools[i];
if(tool&&tool.get_name()==name){
return tool;
}
}
return null;
},setToolState:function(_35a,_35b){
if(!_35a){
_35a=this._tools;
}
var _35c=this.get_editor();
for(var i=0;i<_35a.length;i++){
var _35e=_35a[i];
var _35f=_35e.get_name();
if(_35e.setState){
var _360=_35b;
if(null==_360){
_360=_35c.getToolState(_35f);
}
if(null!=_360){
_35e.setState(_360);
}
}
if(_35e.updateValue){
_35e.updateValue(_35c.getToolValue(_35f));
}
}
},_convertCommandsArray:function(_361){
var _362=[];
for(var i=0;i<_361.length;i++){
_362[i]=[i+1,_361[i].get_title()];
}
return _362;
},_onDropDownHide:function(_364,args){
var _366=this.get_editor();
_366.enableContentArea(true);
},_onDropDownBeforeShow:function(_367,args){
var _369=this.get_editor();
if(Telerik.Web.UI.EditorToolStrip.isInstanceOfType(_367)){
this.setToolState(_367.get_items());
}
if(!_369.getSelection().isControl()&&!Telerik.Web.UI.EditorContextMenu.isInstanceOfType(_367)){
_369.enableContentArea(false);
}
var _36a=_367.get_name();
if(_36a=="Undo"){
var _36b=_369.get_commandsManager().getCommandsToUndo();
_36b=this._convertCommandsArray(_36b);
_367.set_items(_36b);
}else{
if(_36a=="Redo"){
var _36c=_369.get_commandsManager().getCommandsToRedo();
_36c=this._convertCommandsArray(_36c);
_367.set_items(_36c);
}else{
if(_36a=="ModuleManager"){
var _36d=_369.get_modulesManager();
if(!_36d){
return;
}
var _36e=_36d.get_modules();
var _36f=[];
for(var i=0;i<_36e.length;i++){
var _371=_36e[i];
var name=_371.get_name();
var _373=_371.get_title();
if(!_373){
_373=name;
}
cssClass=_371.get_visible()?"rade_module_visible_icon":"rade_module_hidden_icon";
_36f[i]=[name,_373,cssClass];
}
_367.set_items(_36f);
}
}
}
var _374=_367.get_items();
if(_374&&_374.length>0){
return;
}
var _375=null;
switch(_36a){
case "ApplyClass":
_375=_369.getCssArray();
break;
case "FontName":
_375=_369.get_fontNames();
break;
case "FontSize":
_375=_369.get_fontSizes();
break;
case "InsertSymbol":
_375=_369.get_symbols();
break;
case "BackColor":
case "ForeColor":
_375=_369.get_colors();
break;
case "RealFontSize":
_375=_369.get_realFontSizes();
break;
case "InsertSnippet":
_375=_369.get_snippets();
break;
case "Zoom":
_375=["10%","20%","50%","100%","150%","200%","300%","500%"];
break;
case "FormatBlock":
_375=_369.get_paragraphs();
break;
case "InsertCustomLink":
_375=_369.get_links();
break;
case "AjaxSpellCheck":
case "SpellCheck":
_375=_369.get_languages();
break;
}
if(_375){
_367.set_items(_375);
}
},_initializeToolbar:function(_376,_377){
var _378=_377.getElementsByTagName("li");
var _379=_376.tools;
var _37a=this.get_editor();
var skin=_37a.get_skin();
var _37c=0;
if(_379){
var _37d=0;
for(var i=0;i<_379.length;i++){
var _37f=_378[i+1];
_37d+=_37f.offsetWidth;
var _380=Telerik.Web.UI.EditorButton;
var _381=_379[i].type;
var _382=_379[i].name;
var _383=Telerik.Web.UI.EditorToolType;
var args=_379[i];
var tool=null;
var _386=false;
if(_381){
switch(_381){
case _383.Button:
break;
case _383.Separator:
if(!_37c){
_37c+=parseInt($telerik.getCurrentStyle(_37f,"marginLeft"));
_37c+=parseInt($telerik.getCurrentStyle(_37f,"marginRight"));
}
_37d+=_37c;
_380=null;
break;
case _383.DropDown:
_380=Telerik.Web.UI.EditorDropDown;
_386=true;
if(_382=="FontName"){
_380=Telerik.Web.UI.Editor.FontNameDropDown;
}else{
if(_382=="FontSize"){
_380=Telerik.Web.UI.Editor.FontSizeDropDown;
}else{
if(_382=="FormatBlock"){
_380=Telerik.Web.UI.EditorUpdateableDropDown;
}else{
if(_382=="RealFontSize"){
_380=Telerik.Web.UI.EditorUpdateableDropDown;
}else{
if(_382=="Zoom"){
_380=Telerik.Web.UI.EditorUpdateableDropDown;
}else{
if(_382=="InsertCustomLink"){
_380=Telerik.Web.UI.Editor.InsertCustomLinkDropDown;
}else{
if(_382=="ApplyClass"){
_380=Telerik.Web.UI.Editor.ApplyClassDropDown;
}
}
}
}
}
}
}
break;
case _383.SplitButton:
_380=Telerik.Web.UI.EditorSplitButton;
if(_382=="ForeColor"||_382=="BackColor"){
_380=Telerik.Web.UI.Editor.ColorPicker;
}else{
if(_382=="Undo"||_382=="Redo"){
_380=Telerik.Web.UI.Editor.UndoRedoDropDown;
}
}
_386=true;
break;
case _383.ToolStrip:
if(_382=="InsertTable"){
_380=Telerik.Web.UI.Editor.InsertTable;
}else{
_380=Telerik.Web.UI.EditorToolStrip;
}
_386=true;
break;
case _383.Custom:
break;
}
}
if(args.attributes){
for(var item in args.attributes){
args[item.toLowerCase()]=args.attributes[item];
}
}
if(_380){
var _388=null;
if(_386){
_388={"valueSelected":this._onDropDownValueSelectedDelegate,"show":this._onDropDownBeforeShowDelegate,"hide":this._onDropDownHideDelegate};
args["skin"]=skin;
}
tool=$create(_380,args,_388,null,_37f);
}
if(tool){
Array.add(this._tools,tool);
var _389=tool.get_shortCut();
if(_389){
var _38a=tool.get_name();
if(Telerik.Web.UI.EditorDropDown.isInstanceOfType(tool)&&!(Telerik.Web.UI.EditorSplitButton.isInstanceOfType(tool))){
_38a="RadE_ToolAdapter_"+_38a;
Telerik.Web.UI.Editor.CommandList[_38a]=this._toolAdapterDropDownExpander;
}
_37a.setShortCut(_38a,_389);
}
}
}
var ul=_377;
if(this.isIE&&ul&&_37d){
ul.style.width=(_37d+(_378[0].offsetWidth)*2)+"px";
}
if($telerik.isSafari){
ul.setAttribute("onmousedown","return false;");
}
$addHandlers(_377,{"click":this._onToolAdapterClickDelegate,"keydown":this._onToolAdapterKeyDownDelegate},this);
}
},_toolAdapterDropDownExpander:function(_38c,_38d){
var tool=_38d.getToolByName(_38c.replace("RadE_ToolAdapter_",""));
tool.setFocus();
tool.show();
tool.selectNextItem();
return false;
},_onEditorModeChange:function(_38f,args){
var _391=Telerik.Web.UI.EditModes;
var mode=_38f.get_mode();
this._setEnabled((mode==_391.Design));
},_onEditorSelectionChange:function(_393,args){
this.setToolState();
},_setEnabled:function(_395){
var _396=this._tools;
for(var i=0;i<_396.length;i++){
var tool=_396[i];
tool.set_enabled(_395);
}
},_registerEditorHandlers:function(){
var _399=this.get_editor();
_399.add_selectionChange(this._onEditorSelectionChangeDelegate);
_399.add_modeChange(this._onEditorModeChangeDelegate);
},_onBodyClick:function(){
if(this._preventToolbarFromHiding){
this._preventToolbarFromHiding=false;
return;
}
this._showToolbarHolder(false);
},_onDropDownValueSelected:function(_39a,args){
this._preventToolbarFromHiding=true;
var _39c=_39a.get_selectedItem();
if(Telerik.Web.UI.EditorButton.isInstanceOfType(_39c)){
this._raiseEditorEvent(_39c,null);
}else{
this._raiseEditorEvent(_39a,_39c);
}
},_onKeyDownHandler:function(e){
var _39e=e.keyCode;
if(9==_39e||37==_39e||39==_39e||121==_39e){
if(Telerik.Web.UI.Editor.PopupController){
Telerik.Web.UI.Editor.PopupController.hideActivePopup();
}
}
if(121==_39e){
var _39f=this.get_editor();
window.setTimeout(function(){
if(_39f){
_39f.setFocus();
}
},100);
if(e.rawEvent){
$telerik.cancelRawEvent(e.rawEvent);
}
return $telerik.cancelRawEvent(e);
}
if(9==_39e){
return;
}
var _3a0=this._getSelectedTool(e);
if(!Telerik.Web.UI.EditorButton.isInstanceOfType(_3a0)){
return;
}
if(37==_39e||39==_39e){
var tool=_3a0;
while(true){
tool=(37==_39e)?this._getPreviousTool(tool):this._getNextTool(tool);
if(null==tool){
break;
}
if(tool.get_enabled()){
break;
}
}
if(tool&&tool.get_enabled()){
tool.setFocus();
}
}
if(13==_39e&&_3a0&&!_3a0.get_selectedItem){
this._raiseEditorEvent(_3a0,null);
return;
}
if(!Telerik.Web.UI.EditorDropDown.isInstanceOfType(_3a0)){
return;
}
if(38==_39e||40==_39e){
var _3a2=false;
if(!_3a0.isExpanded()){
_3a0.show();
_3a2=true;
}
if(_3a2||40==_39e){
_3a0.selectNextItem();
}else{
_3a0.selectPreviousItem();
}
}else{
if(13==_39e){
_3a0.hide();
if(_3a0.get_activeIndex){
_3a0.set_selectedIndex(_3a0.get_activeIndex());
}
this._onDropDownValueSelected(_3a0);
}else{
if(27==_39e){
_3a0.hide();
}
}
}
},_onToolBarClick:function(e){
var _3a4=this._getSelectedTool(e);
if(_3a4){
if(Telerik.Web.UI.EditorDropDown.isInstanceOfType(_3a4)){
_3a4.click(e);
}else{
if(false){
}else{
this._raiseEditorEvent(_3a4);
}
}
}
var _3a5=this.get_editor();
if(_3a5.get_mode()!=Telerik.Web.UI.EditModes.Design){
$telerik.cancelRawEvent(e);
}
},_raiseEditorEvent:function(tool,_3a7){
var _3a8=this.get_events().getHandler("ToolClick");
if(_3a8){
var _3a9=tool.get_name?tool.get_name():"";
var _3aa=new Telerik.Web.UI.EditorCommandEventArgs(_3a9,tool,_3a7);
_3a8(tool,_3aa);
}
},_getPreviousTool:function(tool){
var _3ac=Array.indexOf(this._tools,tool);
return this._tools[_3ac-1];
},_getNextTool:function(tool){
var _3ae=Array.indexOf(this._tools,tool);
return this._tools[_3ae+1];
},_getSelectedTool:function(e){
var _3b0=Telerik.Web.UI.EditorButton.getToolRootNode(e.target);
if(null==_3b0){
return;
}
var _3b1=_3b0.control;
if(null==_3b1){
return;
}
if(_3b1.get_enabled&&_3b1.get_enabled()==false){
return;
}
if(e&&_3b1){
e.preventDefault();
e.stopPropagation();
}
return _3b1;
},_getToolBarElements:function(){
var _3b2=this.get_element();
var _3b3=_3b2.getElementsByTagName("ul");
return _3b3;
},get_tools:function(){
return this._tools;
},get_toolbarHolder:function(){
return this.get_window();
},get_editor:function(){
return this._editor;
},set_editor:function(_3b4){
if(this._editor!=_3b4){
this._editor=_3b4;
}
},get_toolJSON:function(){
return this._toolJSON;
},set_toolJSON:function(_3b5){
this._toolJSON=_3b5;
},add_toolClick:function(_3b6){
this.get_events().addHandler("ToolClick",_3b6);
},remove_toolClick:function(_3b7){
this.get_events().removeHandler("ToolClick",_3b7);
}};
Telerik.Web.UI.Editor.DefaultToolAdapter.registerClass("Telerik.Web.UI.Editor.DefaultToolAdapter",Sys.UI.Control);
Type.registerNamespace("Telerik.Web.UI");
Type.registerNamespace("Telerik.Web.UI.Editor");
with(Telerik.Web.UI.Editor){
Telerik.Web.UI.Editor.UpdateCommandsArray={InsertOrderedList:new BrowserCommand(null,null,"InsertOrderedList"),InsertUnorderedList:new BrowserCommand(null,null,"InsertUnorderedList"),Unlink:new BrowserCommand(null,null,"Unlink"),Bold:new BrowserCommand(null,null,"Bold"),Italic:new BrowserCommand(null,null,"Italic"),Underline:new BrowserCommand(null,null,"Underline"),FontName:new BrowserCommand(null,null,"FontName"),FontSize:new BrowserCommand(null,null,"FontSize"),Paste:new BrowserCommand(null,null,"Paste"),Cut:new BrowserCommand(null,null,"Cut"),Copy:new BrowserCommand(null,null,"Copy"),JustifyLeft:new BrowserCommand(null,null,"JustifyLeft"),JustifyRight:new BrowserCommand(null,null,"JustifyRight"),JustifyCenter:new BrowserCommand(null,null,"JustifyCenter"),JustifyNone:new BrowserCommand(null,null,"JustifyNone"),JustifyFull:new BrowserCommand(null,null,"JustifyFull"),Indent:new BrowserCommand(null,null,"Indent"),Outdent:new BrowserCommand(null,null,"Outdent"),Unlink:new BrowserCommand(null,null,"Unlink"),Subscript:new BrowserCommand(null,null,"Subscript"),Superscript:new BrowserCommand(null,null,"Superscript"),StrikeThrough:new BrowserCommand(null,null,"StrikeThrough"),AbsolutePosition:new BrowserCommand(null,null,"AbsolutePosition"),FormatBlock:new FormatBlockCommand(null,null,null),InsertRowAbove:new TableInsertRow(null,null,"above"),InsertRowBelow:new TableInsertRow(null,null,"below"),InsertColumnLeft:new TableInsertColumn(null,null,"left"),InsertColumnRight:new TableInsertColumn(null,null,"right"),DeleteRow:new TableDeleteRow(null,null),DeleteColumn:new TableDeleteColumn(null,null),DeleteCell:new TableDeleteCell(null,null),MergeColumns:new TableMergeColumns(null,null),MergeRows:new TableMergeRows(null,null),SplitCell:new TableSplitCell(null,null),ApplyClass:new ClassNameCommand(null,null)};
}
Telerik.Web.UI.Editor.CommandList=new (function(){
this.AjaxSpellCheck=function(_3b8,_3b9,args){
function createSpellCheckEngine(){
if(!_3b9.get_ajaxSpellCheck()){
var _3bb={"editor":_3b9};
var _3bc=document.createElement("DIV");
var _3bd=$create(Telerik.Web.UI.Editor.AjaxSpellCheck,_3bb,null,null,_3bc);
var _3be=_3bd.get_element();
var _3bf=$get(_3b9.get_id()+"Top");
if(_3bf){
_3bf.appendChild(_3be);
}
_3b9.set_ajaxSpellCheck(_3bd);
}
var _3c0=_3b9.get_ajaxSpellCheck();
if(args&&args.value){
_3c0.set_language(args.value);
}
_3c0.spellCheck();
}
if(typeof (Telerik.Web.UI.Editor.AjaxSpellCheck)=="undefined"){
function OnWebRequestCompleted(_3c1,_3c2){
var _3c3=_3c1.get_responseData();
Telerik.Web.UI.Editor.Utils.evalScriptCode(_3c3);
createSpellCheckEngine();
}
var _3c4=_3b9.get_ajaxSpellCheckScriptReference();
var _3c5=new Sys.Net.WebRequest();
_3c5.set_url(_3c4);
_3c5.set_httpVerb("GET");
_3c5.add_completed(OnWebRequestCompleted);
_3c5.invoke();
}else{
createSpellCheckEngine();
}
return false;
};
this.ModuleManager=function(_3c6,_3c7,args){
var _3c9=args.value;
var _3ca=_3c7.get_modulesManager();
if(!_3ca){
return false;
}
var _3cb=_3ca.getModuleByName(_3c9);
if(_3cb){
_3cb.toggleVisibility();
_3c7._updateEditorSize(null,true);
}
return false;
};
this.ToggleScreenMode=function(_3cc,_3cd,args){
_3cd.toggleScreenMode();
return false;
};
this.InsertRowAbove=this.InsertRowBelow=function(_3cf,_3d0,args){
_3d0.executeCommand(new Telerik.Web.UI.Editor.TableInsertRow(_3d0.getLocalizedString(_3cf),null,_3cf=="InsertRowAbove"?"above":"below"));
};
this.InsertColumnLeft=this.InsertColumnRight=function(_3d2,_3d3,args){
_3d3.executeCommand(new Telerik.Web.UI.Editor.TableInsertColumn(_3d3.getLocalizedString(_3d2),null,_3d2=="InsertColumnLeft"?"left":"right"));
};
this.DeleteRow=function(_3d5,_3d6,args){
_3d6.executeCommand(new Telerik.Web.UI.Editor.TableDeleteRow(_3d6.getLocalizedString(_3d5)));
};
this.DeleteColumn=function(_3d8,_3d9,args){
_3d9.executeCommand(new Telerik.Web.UI.Editor.TableDeleteColumn(_3d9.getLocalizedString(_3d8)));
};
this.DeleteCell=function(_3db,_3dc,args){
_3dc.executeCommand(new Telerik.Web.UI.Editor.TableDeleteCell(_3dc.getLocalizedString(_3db)));
};
this.MergeColumns=function(_3de,_3df,args){
_3df.executeCommand(new Telerik.Web.UI.Editor.TableMergeColumns(_3df.getLocalizedString(_3de)));
};
this.MergeRows=function(_3e1,_3e2,args){
_3e2.executeCommand(new Telerik.Web.UI.Editor.TableMergeRows(_3e2.getLocalizedString(_3e1)));
};
this.SplitCell=function(_3e4,_3e5,args){
_3e5.executeCommand(new Telerik.Web.UI.Editor.TableSplitCell(_3e5.getLocalizedString(_3e4)));
};
this.DeleteTable=function(_3e7,_3e8,args){
var _3ea=args.value;
if(!_3ea){
_3ea=_3e8.getSelectedElement();
}
if(_3ea&&"TABLE"!=_3ea.tagName){
_3ea=Telerik.Web.UI.Editor.Utils.getElementParentByTag(_3ea,"TABLE");
}
if(_3ea){
_3e8.selectElement(_3ea);
_3e8.executeBrowserCommand("Delete");
}
};
this.InsertFormForm=this.InsertFormButton=this.InsertFormCheckbox=this.InsertFormHidden=this.InsertFormImageButton=this.InsertFormPassword=this.InsertFormRadio=this.InsertFormReset=this.InsertFormSelect=this.InsertFormSubmit=this.InsertFormTextarea=this.InsertFormText=function(_3eb,_3ec,args){
var _3ee=_3eb.substring(10);
var _3ef=new Telerik.Web.UI.EditorCommandEventArgs(_3eb,args.get_tool(),_3ee);
_3ec.fire("InsertFormElement",_3ef);
};
this.StripAll=this.StripCss=this.StripFont=this.StripSpan=this.StripWord=function(_3f0,_3f1,args){
var _3f3=_3f0.substring(5);
var _3f4=new Telerik.Web.UI.EditorCommandEventArgs(_3f0,args.get_tool(),_3f3.toUpperCase());
_3f1.fire("FormatStripper",_3f4);
};
this.FormatStripper=function(_3f5,_3f6,args){
var _3f8=args.value;
var _3f9="";
try{
_3f9=_3f6.getSelectionHtml();
}
catch(e){
}
var oSel=_3f6.get_document().selection?_3f6.get_document().selection:_3f6.get_contentWindow().getSelection();
var _3fb=oSel.type?oSel.type.toLowerCase()=="none":oSel.isCollapsed;
if(_3fb||_3f9==""||_3f6.get_html()==_3f9){
var _3fc=Telerik.Web.UI.Editor.Utils.stripFormatting(_3f6.get_html(),_3f8);
_3f6.set_html(_3fc,_3f6.getLocalizedString(_3f5)+" "+_3f8);
}else{
if(_3f9!=null){
var _3fc=Telerik.Web.UI.Editor.Utils.stripFormatting(_3f9,_3f8);
_3f6.pasteHtml(_3fc,_3f5);
}
}
};
this.InsertTable=function(_3fd,_3fe,args){
var _400=args.value;
if(_400){
var _401=Telerik.Web.UI.Editor.Utils.createTable(_400.rows,_400.cols);
var _402=Telerik.Web.UI.Editor.Utils.getOuterHtml(_401);
_3fe.pasteHtml(_402,_3fd);
}
};
this.InsertTab=function(_403,_404,_405){
var _406=_404.getSelectedElement();
if(_406.tagName=="LI"){
_404.fire("Indent");
}else{
_404.pasteHtml(" &nbsp;&nbsp;&nbsp;&nbsp;",_403);
}
return false;
};
this.SetToolFocus=function(_407,_408,_409){
var _40a=_408.get_toolAdapter();
if(_40a){
_40a.setFocus();
}
return false;
};
this.ViewHtml=function(_40b,_40c,_40d){
alert(_40c.get_html(true));
return false;
};
this.Undo=this.Redo=function(_40e,_40f,args){
var _411=args?args.value:1;
if(!_411){
_411=1;
}
if(_40e=="Redo"){
_40f.redo(_411);
}else{
_40f.undo(_411);
}
};
this.PastePlainText=function(_412,_413,_414){
var _415=function(_416){
if(_416){
var _417=_416.replace(/\&/g,"&amp;").replace(/</g,"&lt;").replace(/>/g,"&gt;");
_417=Telerik.Web.UI.Editor.Utils.replaceNewLineWithBr(_417);
if(_417){
_413.pasteHtml(_417,_412);
}
}
};
if(_413.isIE){
_415(window.clipboardData.getData("Text"));
}else{
var _418=function(_419,args){
_415(args.get_content());
};
_413.showDialog("CleanPasteTextContent",{},_418);
return false;
}
};
this.PasteFromWord=this.PasteFromWordNoFontsNoSizes=this.PasteAsHtml=function(_41b,_41c,_41d){
var _41e=function(_41f,_420){
var _421="";
if(_41b=="PasteFromWord"){
_421=Telerik.Web.UI.Editor.Utils.stripFormatting(_41f,"WORD");
}else{
if(_41b=="PasteFromWordNoFontsNoSizes"){
_421=Telerik.Web.UI.Editor.Utils.stripFormatting(_41f,"WORD_ALL");
}else{
_421=Telerik.Web.UI.Editor.Utils.convertText2Html(_41f);
}
}
if(_420){
_420.select();
}
if(_421){
_41c.pasteHtml(_421,_41b);
}
};
if(_41c.isIE){
var _422=_41c.createRestorePoint();
var _423=Telerik.Web.UI.Editor.Utils.getClipboardAsHtml();
_41e(_423,_422);
}else{
var _424=function(_425,args){
_41e(args.get_content());
};
_41c.showDialog("CleanPasteHtmlContent",{},_424);
}
};
this.Copy=function(_427,_428,args){
if(null!=args){
var _42a=window.opera?false:true;
if(_42a){
try{
document.queryCommandEnabled(_427);
}
catch(e){
_42a=false;
}
}
if(_42a){
_428.get_document().execCommand(_427,false,null);
}else{
alert(_428.getLocalizedString("UseCtrlC"));
}
}
};
this.Cut=this.Paste=function(_42b,_42c,args){
if(null!=args){
var _42e=window.opera?false:true;
if(_42e){
try{
if(!_42c.isIE7){
document.queryCommandEnabled(_42b);
}
}
catch(e){
_42e=false;
}
}
if(_42b=="Paste"&&_42e&&_42c.isIE7){
_42c.get_document().body.fireEvent("onbeforepaste");
}
if(_42e){
var oCmd=new Telerik.Web.UI.Editor.GenericCommand(_42c.getLocalizedString(_42b),_42c.get_contentWindow());
_42c.get_document().execCommand(_42b,false,null);
_42c.executeCommand(oCmd);
}else{
var id=(_42b=="Cut"?"UseCtrlX":"UseCtrlV");
alert(_42c.getLocalizedString(id));
}
}else{
_42c._pendingCutPasteCommand=new Telerik.Web.UI.Editor.GenericCommand(_42c.getLocalizedString(_42b),_42c.get_contentWindow());
}
};
this.InsertParagraph=function(_431,_432,_433){
_432.executeBrowserCommand(_431,true,"");
return true;
};
this.FormatBlock=function(_434,_435,args){
_435.executeCommand(new Telerik.Web.UI.Editor.FormatBlockCommand(_435.getLocalizedString(_434),_435.get_contentWindow(),args.value));
};
this.InsertOrderedList=this.InsertUnorderedList=function(_437,_438,args){
_438.setFocus();
_438.executeCommand(new Telerik.Web.UI.Editor.InsertListCommand(_438.getLocalizedString(_437),_438.get_contentWindow(),_438.get_newLineBr(),_437,null));
};
this.Bold=this.Italic=this.Underline=this.JustifyLeft=this.JustifyRight=this.JustifyCenter=this.JustifyNone=this.Indent=this.Outdent=this.SelectAll=this.Unlink=this.JustifyFull=this.StrikeThrough=this.Subscript=this.Superscript=this.AbsolutePosition=function(_43a,_43b,_43c){
_43b.setActive();
var _43d="SelectAll"!=_43a;
if(_43a=="Unlink"&&!_43b.isIE){
var elem=_43b.getSelectedElement();
if(elem&&elem.tagName=="A"){
_43b.selectElement(elem,false);
}
}
_43b.executeBrowserCommand(_43a,_43d,null,null);
return true;
};
this.ForeColor=this.BackColor=this.FontName=this.FontSize=function(_43f,_440,args){
var _442=args.value;
_440.executeBrowserCommand(_43f,true,_442);
};
this.Zoom=function(_443,_444,args){
var _446=args.value;
var tool=args.get_tool?args.get_tool():null;
if(_446&&tool&&tool.updateValue){
tool.updateValue(_446);
}
_444._contentArea.style.zoom=_446;
return false;
};
this.Print=function(_448,_449,args){
if(_449.isIE){
_449.get_document().execCommand(_448,false,null);
}else{
if(_449.get_contentWindow().print){
_449.get_contentWindow().print();
}
}
return false;
};
this.InsertSnippet=function(_44b,_44c,args){
_44c.pasteHtml(args.value,_44b);
};
this.InsertFormElement=function(_44e,_44f,args){
var _451=args.value;
_451=_451.toLowerCase();
var _452=null;
switch(_451){
case "form":
_452=_44f.createElement("form","150px","150px");
_452.innerHTML="&nbsp;";
break;
case "textarea":
_452=_44f.createElement("textarea");
break;
case "select":
_452=_44f.createElement("select","100px","22px");
break;
case "checkbox":
case "radio":
_452=_44f.createElement("input");
_452.setAttribute("type",_451);
break;
case "button":
case "reset":
case "submit":
_452=_44f.createElement("input","50px","22px");
_452.setAttribute("type",_451);
break;
case "hidden":
case "password":
case "text":
_452=_44f.createElement("input","100px","22px");
_452.setAttribute("type",_451);
break;
}
if(_452){
var id=Telerik.Web.UI.Editor.Utils.getUniqueID();
_452.setAttribute("id",id);
var html=Telerik.Web.UI.Editor.Utils.getOuterHtml(_452);
_44f.pasteHtml(html,_44e);
var _455=_44f.get_document().getElementById(id);
if(_455){
_455.removeAttribute("id");
if(_455.setActive){
_455.setActive();
}
return false;
}
}
};
this.InsertGroupbox=this.InsertDate=this.InsertTime=this.InsertSymbol=this.InsertHorizontalRule=function(_456,_457,args){
var _459="";
switch(_456){
case "InsertSymbol":
_459=args.value;
break;
case "InsertHorizontalRule":
_459="<hr>";
break;
case "InsertDate":
var now=new Date();
_459="&nbsp;"+now.toLocaleDateString();
break;
case "InsertTime":
var now=new Date();
_459="&nbsp;"+now.toLocaleTimeString();
break;
default:
_459="<fieldset style='WIDTH: 200px; HEIGHT: 76px'> <legend>Title</legend>Content... </fieldset> ";
}
_457.pasteHtml(_459,_456);
};
this.ImageManager=function(_45b,_45c,_45d){
var _45e=function(_45f,args){
_45c.pasteHtml(Telerik.Web.UI.Editor.Utils.getOuterHtml(args.Result),_45b);
};
var _461=_45c.get_dialogOpener().get_additionalQueryString();
var _462=_45c.getSelectedElement();
if(_462&&_462.tagName.toLowerCase()=="img"){
_45c.get_dialogOpener().set_additionalQueryString("&PreselectedItemUrl="+encodeURIComponent(_462.src));
}
var args={editor:_45c};
_45c.showDialog("ImageManager",args,_45e);
_45c.get_dialogOpener().set_additionalQueryString(_461);
return false;
};
this.SilverlightManager=function(_464,_465,_466){
var _467=function(_468,args){
var html=args.Result;
var _46b=_465._filtersManager.getFilterByName("IEKeepObjectParamsFilter");
var _46c=_465._filtersManager.getFilterByName("MozillaKeepFlashString");
html=(_46b)?_46b.getDesignContent(html):html;
html=(_46c)?_46c.getDesignContent(html):html;
_465.pasteHtml(html,_464);
};
var _46d={};
var _46e=_465.get_dialogOpener().get_additionalQueryString();
var _46f=_465.getSelectedElement();
if(_46f){
if($telerik.isIE&&_46f.object&&_46f.object.Movie){
var _470=_46f.object.Movie;
_465.get_dialogOpener().set_additionalQueryString("&PreselectedItemUrl="+encodeURIComponent(_470));
_46d.selectedItemUrl=_470;
_46d.selectedObject=_46f;
}
}
_465.showDialog("SilverlightManager",_46d,_467);
_465.get_dialogOpener().set_additionalQueryString(_46e);
return false;
};
this.FlashManager=function(_471,_472,_473){
var _474=function(_475,args){
var _477=_472._filtersManager.getFilterByName("IEKeepObjectParamsFilter");
var _478=_472._filtersManager.getFilterByName("MozillaKeepFlashString");
var html=args.Result;
html=(_477)?_477.getDesignContent(html):html;
html=(_478)?_478.getDesignContent(html):html;
_472.pasteHtml(html,_471);
};
var _47a={};
var _47b=_472.get_dialogOpener().get_additionalQueryString();
var _47c=_472.getSelectedElement();
if(_47c){
if($telerik.isIE&&_47c.object&&_47c.object.Movie){
var _47d=_47c.object.Movie;
_472.get_dialogOpener().set_additionalQueryString("&PreselectedItemUrl="+encodeURIComponent(_47d));
_47a.selectedItemUrl=_47d;
_47a.selectedObject=_47c;
}
}
_472.showDialog("FlashManager",_47a,_474);
_472.get_dialogOpener().set_additionalQueryString(_47b);
return false;
};
this.MediaManager=function(_47e,_47f,_480){
var _481=function(_482,args){
var _484=_47f._filtersManager.getFilterByName("IEKeepObjectParamsFilter");
var _485=_47f._filtersManager.getFilterByName("MozillaKeepFlashString");
var html=args.Result;
html=(_484)?_484.getDesignContent(html):html;
html=(_485)?_485.getDesignContent(html):html;
_47f.pasteHtml(html,_47e);
};
var _487={};
var _488=_47f.get_dialogOpener().get_additionalQueryString();
var _489=_47f.getSelectedElement();
if(_489){
if($telerik.isIE&&_489.object&&_489.object.FileName){
var _48a=_489.object.FileName;
_47f.get_dialogOpener().set_additionalQueryString("&PreselectedItemUrl="+encodeURIComponent(_48a));
_487.selectedItemUrl=_48a;
_487.selectedObject=_489;
}
}
_47f.showDialog("MediaManager",_487,_481);
_47f.get_dialogOpener().set_additionalQueryString(_488);
return false;
};
this.TemplateManager=function(_48b,_48c,_48d){
var _48e=function(_48f,args){
_48c.pasteHtml(args.Result,_48b);
};
_48c.showDialog("TemplateManager",{},_48e);
return false;
};
this.AboutDialog=function(_491,_492,_493){
_492.showDialog("AboutDialog");
return false;
};
this.Help=function(_494,_495,_496){
_495.showDialog("Help");
return false;
};
this.PageProperties=function(_497,_498,_499){
var _49a=function(_49b,args){
};
var _49d={};
Telerik.Web.UI.Editor.CommandList._getDialogArguments(_49d,"BODY",_498,_497);
_498.showDialog("PageProperties",_49d,_49a);
return false;
};
this.ImageMapDialog=function(_49e,_49f,args){
var _4a1=Telerik.Web.UI.Editor.CommandList._getImageMapDialogArgument(_49f);
var _4a2=function(wnd,_4a4){
Telerik.Web.UI.Editor.CommandList._setImageMapProperties(_49f,_4a4);
return false;
};
_49f.showDialog("ImageMapDialog",_4a1,_4a2);
return false;
};
this._setImageMapProperties=function(_4a5,args){
if(!args){
return;
}
var _4a7=_4a5.getSelectedElement();
var _4a8;
if(_4a7&&_4a7.tagName=="IMG"){
_4a8=_4a7;
if(args.ImageSrc!=_4a8.src){
_4a8.src=args.ImageSrc;
}
}else{
if(!args.ImageSrc){
return;
}
_4a5.pasteHtml("<img src=\""+args.ImageSrc+"\" id = \"__tmp__\">");
_4a8=_4a5.get_document().getElementById("__tmp__");
_4a8.removeAttribute("id");
if(document.all){
var oRng=_4a5.get_document().body.createTextRange();
oRng.collapse();
oRng.moveToElementText(_4a8);
oRng.select();
}
}
var _4aa=document.createElement("SPAN");
_4aa.innerHTML=args.MapHtml;
var _4ab=_4aa.getElementsByTagName("map");
if(_4ab.length==0){
return;
}
var _4ac=_4ab[0].innerHTML;
_4aa=null;
if(!_4ac){
_4a8.removeAttribute("useMap");
return;
}
var _4ad="";
var map=null;
var _4af=_4a8.getAttribute("useMap");
if(_4af){
_4ad=_4af.substr(1);
map=Telerik.Web.UI.Editor.CommandList._getImageMapByName(_4a5,_4ad);
}
if(map==null){
var _4b0=new Date()-100;
var _4ad="rade_img_map_"+_4b0;
map=_4a5.get_document().createElement("map");
map.id=_4ad;
this._setNameAttribute(map,_4ad);
map=_4a5.get_document().body.appendChild(map);
_4a8.setAttribute("useMap","#"+_4ad);
_4a8.setAttribute("border","0");
}
map.innerHTML=_4ac;
};
this._setNameAttribute=function(_4b1,name){
_4b1.removeAttribute("name");
_4b1.removeAttribute("NAME");
_4b1.name=null;
_4b1.name=name;
_4b1["NAME"]=name;
};
this._getImageMapDialogArgument=function(_4b3){
var _4b4={};
_4b4._editor=_4b3;
var _4b5=_4b3.getSelectedElement();
if(_4b5&&_4b5.tagName=="IMG"){
_4b4.ImageSrc=_4b5.getAttribute("src",2);
_4b4.ImageWidth=(_4b5.style.width)?_4b5.style.width:_4b5.width;
_4b4.ImageHeight=(_4b5.style.height)?_4b5.style.height:_4b5.height;
if($telerik.isIE){
var oRng=_4b3.get_document().body.createTextRange();
oRng.collapse();
oRng.moveToElementText(_4b5);
oRng.select();
}
if(_4b5.useMap){
var _4b7=_4b5.getAttribute("useMap").substr(1);
var map=Telerik.Web.UI.Editor.CommandList._getImageMapByName(_4b3,_4b7);
if(map!=null){
_4b4.ImageMapHTML="<map name = \""+_4b7+"\">"+map.innerHTML+"</map>";
}else{
_4b4.ImageMapHTML="";
}
_4b5.style.width=_4b4.ImageWidth;
_4b5.style.height=_4b4.ImageHeight;
}
}
return _4b4;
};
this._getImageMapByName=function(_4b9,_4ba){
var _4bb=_4b9.get_document();
var map=_4bb.getElementById(_4ba);
if(map!=null){
return map;
}
var maps=_4bb.getElementsByTagName("map");
for(var i=0;i<maps.length;i++){
if(maps[i].getAttribute("name")==_4ba){
return maps[i];
}
}
return null;
};
this.DocumentManager=function(_4bf,_4c0,_4c1){
var _4c2={};
var _4c3=function(_4c4,args){
_4c0.pasteHyperLink(args.Result,_4bf);
};
var _4c6=_4c0.get_dialogOpener().get_additionalQueryString();
var _4c7=_4c0.getSelectedElement();
if(_4c7&&_4c7.tagName.toLowerCase()=="a"){
_4c0.get_dialogOpener().set_additionalQueryString(_4c6+"&PreselectedItemUrl="+encodeURIComponent(_4c7.href));
}
_4c0.showDialog("DocumentManager",_4c2,_4c3);
_4c0.get_dialogOpener().set_additionalQueryString(_4c6);
return false;
};
this.TableWizard=function(_4c8,_4c9,_4ca){
var _4cb=Telerik.Web.UI.Editor.CommandList._getTableArgument(_4c9,null,true,false);
Telerik.Web.UI.Editor.CommandList._getDialogArguments(_4cb,"TABLE",_4c9,_4c8);
var _4cc=function(_4cd,args){
_4c9.pasteHtml(Telerik.Web.UI.Editor.Utils.getOuterHtml(args.tableToModify),_4c8);
};
_4c9.showDialog("TableWizard",_4cb,_4cc);
return false;
};
this.SetTableProperties=function(_4cf,_4d0,_4d1){
var _4d2=Telerik.Web.UI.Editor.CommandList._getTableArgument(_4d0,1,false,true);
if(!_4d2){
alert(_4d0.getLocalizedString("tablewarning"));
return false;
}
Telerik.Web.UI.Editor.CommandList._getDialogArguments(_4d2,"TABLE",_4d0,_4cf);
var _4d3=Telerik.Web.UI.Editor.CommandList._getParentTable(_4d0);
var _4d4=function(_4d5,args){
_4d0.selectElement(_4d3);
_4d0.pasteHtml(Telerik.Web.UI.Editor.Utils.getOuterHtml(args.tableToModify),_4cf);
};
_4d0.showDialog("TableWizard",_4d2,_4d4);
return false;
};
this.SetCellProperties=function(_4d7,_4d8,_4d9){
var _4da=Telerik.Web.UI.Editor.CommandList._getTableArgument(_4d8,2,false,true);
if(!_4da){
alert(_4d8.getLocalizedString("cellwarning"));
return false;
}
Telerik.Web.UI.Editor.CommandList._getDialogArguments(_4da,"TABLE",_4d8,_4d7);
var _4db=Telerik.Web.UI.Editor.CommandList._getParentTable(_4d8);
var _4dc=function(_4dd,args){
_4d8.selectElement(_4db);
_4d8.pasteHtml(Telerik.Web.UI.Editor.Utils.getOuterHtml(args.tableToModify),_4d7);
};
_4d8.showDialog("TableWizard",_4da,_4dc);
return false;
};
this.FindAndReplace=function(_4df,_4e0,_4e1){
var _4e2={};
_4e2._editor=_4e0;
var _4e3=function(_4e4,args){
};
_4e0.showDialog("FindAndReplace",_4e2,_4e3);
return false;
};
this.StyleBuilder=function(_4e6,_4e7,_4e8){
var _4e9=function(_4ea,args){
_4e7.pasteHtml(Telerik.Web.UI.Editor.Utils.getOuterHtml(args.Result),_4e6);
};
var _4ec={};
var _4ed=_4e7.getSelection();
var _4ee=_4ed.getParentElement();
if(!_4ed.isControl()){
var _4ef=_4ed.getHtml();
if(_4ef!=""||(_4ee&&_4ee.tagName&&_4ee.tagName.toLowerCase()=="body")){
var _4f0=_4e7.createElement("span");
Telerik.Web.UI.Editor.Utils.setElementInnerHtml(_4f0,_4ef);
_4ee=_4f0;
}else{
_4e7.selectElement(_4ee,false);
}
}
_4ec.htmlElement=_4ee;
Telerik.Web.UI.Editor.CommandList._getDialogArguments(_4ec,"*",_4e7,_4e6);
_4ec.fontNames=_4e7.get_fontNames();
_4e7.showDialog("StyleBuilder",_4ec,_4e9);
return false;
};
this.XhtmlValidator=function(_4f1,_4f2,_4f3){
var _4f4=_4f2;
var _4f5=function(_4f6,args){
};
_4f2.showDialog("XhtmlValidator",_4f4,_4f5);
return false;
};
this.TrackChangesDialog=function(_4f8,_4f9,_4fa){
var _4fb=_4f9;
var _4fc=function(_4fd,args){
};
_4f9.showDialog("TrackChangesDialog",_4fb,_4fc);
};
this.InsertCustomLink=function(_4ff,_500,args){
var link=args.value;
var _503=String.format("<a href='{1}' title='{3}' target='{2}'>{0}</a>",link.innerHTML,link.href,link.target,link.title);
var _504=Telerik.Web.UI.Editor.CommandList._getParentLink(_500);
if(_504){
var _505=_504.cloneNode(true);
if(link.href){
_505.setAttribute("href",link.href);
}
if(link.target){
_505.setAttribute("target",link.target);
}
if(link.title){
_505.setAttribute("title",link.title);
}
if(!_505.innerHTML){
_505.innerHTML=link.innerHTML;
}
_503=Telerik.Web.UI.Editor.Utils.getOuterHtml(_505);
}
_500.pasteHtml(_503,_4ff);
};
this._getDialogArguments=function(_506,_507,_508,_509){
_506.Colors=_508.get_colors();
if("TD"==_507||"TH"==_507||"TABLE"==_507){
_506.CssClasses=_508.getCssArray("TABLE");
_506.CellCssClasses=_508.getCssArray("TD");
}else{
if("A"==_507||"BODY"==_507||"IMG"==_507){
_506.CssClasses=_508.getCssArray(_507);
}
}
_506.Editor=_508;
};
this.SetLinkProperties=this.LinkManager=function(_50a,_50b,_50c){
var _50d=Telerik.Web.UI.Editor.CommandList._getLinkArgument(_50b);
Telerik.Web.UI.Editor.CommandList._getDialogArguments(_50d,"A",_50b,_50a);
var _50e=function(_50f,args){
_50b.pasteHyperLink(args.realLink,_50a);
};
_50b.showDialog("LinkManager",_50d,_50e);
return false;
};
this.SetImageProperties=function(_511,_512,_513){
var _514=_512.getSelectedElement();
if(_514.nodeName.toLowerCase()!="img"){
return false;
}
var _515={};
_515.Element=_514;
Telerik.Web.UI.Editor.CommandList._getDialogArguments(_515,"IMG",_512,_511);
var _516=function(_517,args){
if(_514&&_514.parentNode){
_514.parentNode.replaceChild(args.Result,_514);
}else{
_512.pasteHtml(Telerik.Web.UI.Editor.Utils.getOuterHtml(args.Result),_511);
}
};
_512.showDialog("ImageProperties",_515,_516);
return false;
};
this.FormatCodeBlock=function(_519,_51a,_51b){
var _51c={dirtyCode:_51a.getSelectionHtml()};
if(_51a.get_document().selection&&_51a.get_document().selection){
var _51d=_51a.get_document().selection.type.toLowerCase();
if(_51d=="control"||_51d=="none"){
_51c.dirtyCode="";
}
}
var _51e=function(_51f,args){
_51a.pasteHtml(args.get_code(),_519);
};
_51a.showDialog("FormatCodeBlock",_51c,_51e);
return false;
};
this._getDocumentAnchors=function(_521){
var _522=_521.getElementsByTagName("A");
var _523=new Array();
for(var i=0;i<_522.length;i++){
if(_522[i].name){
_523[_523.length]=_522[i];
}
}
return _523;
};
this._getParentLink=function(_525){
_525.setFocus();
var _526=_525.getSelectedElement();
var _527=Telerik.Web.UI.Editor.Utils.getElementParentByTag(_526,"A");
if(_527){
_525.selectElement(_527);
}else{
var _528="";
if(_526&&_526.tagName=="IMG"){
_528=Telerik.Web.UI.Editor.Utils.getOuterHtml(_526);
}else{
_528=_525.getSelection().getHtml();
}
_527=_525.get_document().createElement("A");
try{
Telerik.Web.UI.Editor.Utils.setElementInnerHtml(_527,_528);
}
catch(e){
_527.innerHTML=Telerik.Web.UI.Editor.Utils.stripFormatting(_528,"ALL");
}
}
return _527;
};
this._getLinkArgument=function(_529,_52a){
var _52b=Telerik.Web.UI.Editor.CommandList._getParentLink(_529);
var _52c=_52b.innerHTML;
var _52d=!_52c?false:_52c.match(/</);
if($telerik.isIE&&_52d){
if(_52c.trim().toLowerCase()=="<p>&nbsp;</p>"){
_52b.innerHTML=" ";
_52d=false;
}
}
return {selectedTabIndex:_52a?_52a:0,realLink:_52b.cloneNode(true),showText:!_52d,documentAnchors:Telerik.Web.UI.Editor.CommandList._getDocumentAnchors(_529.get_document())};
};
this._getParentTable=function(_52e){
_52e.setFocus();
var _52f=_52e.getSelectedElement();
var _530=Telerik.Web.UI.Editor.Utils.getElementParentByTag(_52f,"TABLE");
return _530;
};
this._getParentCell=function(_531){
_531.setFocus();
var _532=_531.getSelectedElement();
var _533=Telerik.Web.UI.Editor.Utils.getElementParentByTag(_532,"TD");
return _533;
};
this._getTableArgument=function(_534,_535,_536,_537){
var _538;
var _539=null;
if(_536){
_538=Telerik.Web.UI.Editor.Utils.createTable(2,2,_534._document);
}else{
_538=Telerik.Web.UI.Editor.CommandList._getParentTable(_534);
}
if(!_536&&!_538){
return null;
}
if(_537){
_539=Telerik.Web.UI.Editor.CommandList._getParentCell(_534);
}
var _53a=_538.cloneNode(true);
var _53b=_538;
return {selectedTabIndex:_535?_535:0,cellToModify:_539,tableToModify:_53a,originalTable:_53b,tableDocument:(_53a.document)?_53a.document:_534.get_document()};
};
this.EnterParagraphMozilla=function(_53c,_53d,args){
var _53f=_53d.getSelectedElement();
if("LI"==_53f.tagName||Telerik.Web.UI.Editor.Utils.getElementParentByTag(_53f,"LI")!=null){
_53d.bubbleKeyEventToBrowser();
return false;
}
var _540=_53d.get_contentWindow();
var oDoc=_540.document;
function checkParent(_542,_543){
_543[_543.length]=_542;
while(_542!=null&&_542.tagName!="P"){
if(_542.tagName=="TD"){
return null;
}
_542=_542.parentNode;
_543[_543.length]=_542;
}
return _542;
}
var _544=_540.getSelection();
var _545=_544.getRangeAt(0);
var _546=_545.cloneRange();
_545.deleteContents();
var _547=_545.startOffset;
var _548=_545.startContainer;
var _549="";
var _54a=[];
var inP=checkParent(_548,_54a);
if(inP){
var _54c=(inP.innerHTML=="");
var _54d=_545.cloneRange();
_54d.setStart(inP,0);
_54d.setEnd(_548,_547);
var _54e=_54d.cloneContents();
var _54f=_545.cloneRange();
_54f.setStart(_548,_547);
if(inP.lastChild){
_54f.setEndAfter(inP.lastChild);
}else{
_54f.setEnd(inP,0);
}
var _550=_54f.cloneContents();
_545.selectNode(inP);
_544.removeAllRanges();
_544.addRange(_545);
inP=inP.cloneNode(true);
inP.innerHTML="";
var _551=inP.cloneNode(true);
if(_54c){
_551.innerHTML="&nbsp;";
}else{
_551.appendChild(_54e);
}
endPar=inP.cloneNode(true);
endPar.appendChild(_550);
var newP=inP.cloneNode(true);
var _553=newP;
if(_54a.length>0){
for(var i=_54a.length;i>0;i--){
var _555=_54a[i];
var _556=_555&&_555.cloneNode?_555.cloneNode(false):null;
if(_556&&_556.tagName!="P"){
_553.appendChild(_556);
_553=_556;
}
}
}
_553.innerHTML="&nbsp;";
_553.setAttribute("id","radETempNode");
var _557=oDoc.createElement("div");
_557.appendChild(_551);
_557.appendChild(newP);
if(!_54c){
_557.appendChild(endPar);
}
_549=_557.innerHTML;
}else{
_549="<p id='radETempNode'>&nbsp;</p>";
}
_53d.pasteHtml(_549,"Enter",false,false,false);
oP=oDoc.getElementById("radETempNode");
if(oP){
oP.removeAttribute("id",0);
var _544=_540.getSelection();
var _545=oDoc.createRange();
_545.selectNodeContents(oP);
_544.removeAllRanges();
_544.addRange(_545);
}
var ps=oDoc.getElementsByTagName("P");
for(var i=0;i<ps.length;i++){
var _559=ps[i].innerHTML;
if(_559==""||_559.trim().toLowerCase()=="<br>"){
ps[i].parentNode.removeChild(ps[i]);
}
}
return false;
};
this.Enter=function(_55a,_55b,args){
var _55d=_55b.getSelectedElement();
if("LI"==_55d.tagName||Telerik.Web.UI.Editor.Utils.getElementParentByTag(_55d,"LI")!=null){
_55b.bubbleKeyEventToBrowser();
return false;
}
try{
var _55e=new Telerik.Web.UI.Editor.GenericCommand("Enter Pressed",_55b.get_contentWindow());
var _55f=_55b.get_document().selection.createRange();
if(_55f.pasteHTML){
var tag=_55d.tagName;
if(tag.charAt(0)=="H"&&parseInt(tag.charAt(1))>0){
var _561=_55f.duplicate();
_561.moveToElementText(_55d);
_55b.bubbleKeyEventToBrowser();
return false;
}
_55f.pasteHTML("<br>");
_55f.select();
_55f.moveEnd("character",1);
_55f.moveStart("character",1);
_55f.collapse(false);
}else{
if(_55f(0)){
_55f.execCommand("Delete");
}
}
_55b.executeCommand(_55e);
}
catch(exc){
alert(exc.message);
}
return false;
};
this.ShiftEnter=function(_562,_563,args){
var _565=_563.getSelectedElement();
if("LI"==_565.tagName||Telerik.Web.UI.Editor.Utils.getElementParentByTag(_565,"LI")!=null){
var _566=new Telerik.Web.UI.Editor.GenericCommand("Enter Pressed",_563.get_contentWindow());
var _567=_563.get_document().selection.createRange();
_567.pasteHTML("<br>");
_567.select();
_567.moveEnd("character",1);
_567.moveStart("character",1);
_567.collapse(false);
_563.executeCommand(_566);
return false;
}
_563.bubbleKeyEventToBrowser();
return false;
};
this.ToggleTableBorder=function(_568,_569,args){
_569.toggleEnhancedEdit();
return false;
};
this.RealFontSize=function(_56b,_56c,args){
var _56e=Telerik.Web.UI.Editor.CommandList._markEditorSelection(_56c);
var _56f=_56e.markedElements;
var _570=_56c.createRestorePoint();
var _571=new Telerik.Web.UI.Editor.GenericCommand(_56c.getLocalizedString(_56b),_56c.get_contentWindow());
if(_56f.length==0){
var _572=_56c.getSelection().getParentElement();
if($telerik.isIE&&!_56c.getSelection().getHtml()&&(_572.tagName=="FONT"||_572.tagName=="SPAN")){
_56c._document.execCommand("RemoveFormat",null,false);
}
_56c.pasteHtml("<font style='font-size:"+args.value+"' id='radERealFont'>&nbsp;</font>",_56b);
var _573=_56c._document.getElementById("radERealFont");
_573.removeAttribute("id");
if($telerik.isIE){
_56c.selectElement(_573);
_56c.getSelection().collapse();
_573.innerHTML="";
}else{
if(_56c._contentWindow.getSelection){
var oSel=_56c._contentWindow.getSelection();
var _575=_56c.getSelection().getRange();
oSel.removeAllRanges();
if(_575&&_575.selectNodeContents){
_575.selectNodeContents(_573);
}
oSel.addRange(_575);
}
}
}else{
for(var i=0;i<_56f.length;i++){
_56f[i].style.fontSize=args.value;
_56f[i].removeAttribute("size");
}
if(_570){
_570.select();
}
_56c.executeCommand(_571);
}
};
this.ConvertToUpper=this.ConvertToLower=function(_577,_578,args){
var _57a;
var endR;
if($telerik.isIE){
if(_578._document.selection.type.toLowerCase()=="control"){
return;
}
var _57c=_578._document.selection.createRange();
_57a=_57c.duplicate();
endR=_57c.duplicate();
_57a.collapse();
endR.collapse(false);
}
var _57d=Telerik.Web.UI.Editor.CommandList._markEditorSelection(_578);
var _57e=_57d.markedElements;
var _57f=_57d.newElements;
var _580=new Telerik.Web.UI.Editor.GenericCommand(_578.getLocalizedString(_577),_578.get_contentWindow());
for(var i=0;i<_57e.length;i++){
changeChildNodesCase(_57e[i]);
}
for(var i=0;i<_57f.length;i++){
if($telerik.isIE){
_57f[i].removeNode(false);
}else{
var _582=document.createRange();
_582.selectNodeContents(_57f[i]);
_57f[i].parentNode.replaceChild(_582.extractContents(),_57f[i]);
}
}
if($telerik.isIE){
var _583=_578._document.selection.createRange();
_583.setEndPoint("StartToStart",_57a);
_583.setEndPoint("EndToEnd",endR);
_583.select();
}else{
var _584=_578.get_contentWindow().getSelection();
var rng=_584.getRangeAt(0);
rng.collapse(true);
}
_578.executeCommand(_580);
function changeChildNodesCase(_586){
var _587=_586.childNodes;
for(var i=0;i<_587.length;i++){
if(_587[i].nodeType==3){
_587[i].nodeValue=("ConvertToLower"==_577)?_587[i].nodeValue.toLowerCase():_587[i].nodeValue.toUpperCase();
}else{
if(_587[i].nodeType==1&&_587[i].tagName.toUpperCase()!="FONT"){
changeChildNodesCase(_587[i]);
}
}
}
}
};
this.ApplyClass=function(_589,_58a,args){
var _58c=args.value;
var _58d=_58a.get_document();
var _58e=_58a.createRestorePoint();
var _58f=new Telerik.Web.UI.Editor.GenericCommand(_58a.getLocalizedString(_589),_58a.get_contentWindow());
if(_58a.isIE){
var _590=_58d.selection.createRange();
var _591=(_590.length>0?_590(0):_590.parentElement());
if(_591.tagName=="LI"){
var _592=_590.htmlText;
var _593=_592.match(/<LI\/?>/gi);
var _594=_593?_593.length:0;
if(_594>1){
_591=_591.parentNode;
}else{
if(_594==0&&(Telerik.Web.UI.Editor.Utils.setElementInnerHtml(_591,_590.htmlText))&&_591.parentNode.childNodes.length==1){
_591=_591.parentNode;
}
}
}
if(_590.length>0||_591.tagName=="OL"||_591.tagName=="UL"){
_591.className=_58c;
return;
}
}
var _595=Telerik.Web.UI.Editor.CommandList._markEditorSelection(_58a);
var _596=_595.markedElements;
if(_596.length==0){
var _597=_58a.getSelection().getParentElement();
if($telerik.isIE&&!_58a.getSelection().getHtml()&&(_597.tagName=="FONT"||_597.tagName=="SPAN")){
_58a._document.execCommand("RemoveFormat",null,false);
}
_58a.pasteHtml("<font class='"+_58c+"' id='radERealFont'>&nbsp;</font>",_589);
var _598=_58a._document.getElementById("radERealFont");
_598.removeAttribute("id");
if($telerik.isIE){
_58a.selectElement(_598);
_58a.getSelection().collapse();
_598.innerHTML="";
}else{
if(_58a._contentWindow.getSelection){
var oSel=_58a._contentWindow.getSelection();
var _59a=_58a.getSelection().getRange();
oSel.removeAllRanges();
if(_59a&&_59a.selectNodeContents){
_59a.selectNodeContents(_598);
}
oSel.addRange(_59a);
}
}
}else{
for(var i=0;i<_596.length;i++){
_596[i].className=_58c;
}
if(_58e){
_58e.select();
}
_58a.executeCommand(_58f);
}
};
this._markEditorSelection=function(_59c){
if(_59c.get_html()==""){
return {markedElements:[],newElements:[]};
}
var _59d="AZBY";
var _59e="_cm";
var _59f=[];
var _5a0=[];
var _5a1=[];
var _5a2=$telerik.isSafari?"span":"font";
var _5a3=_59c._contentArea;
var _5a4=_59c.getSelection();
if(_5a4.isControl()){
var _5a5=_5a4.getParentElement();
var _5a6=_59c._document.createElement(_5a2);
_5a6.appendChild(_5a5.cloneNode(true));
_5a5.parentNode.replaceChild(_5a6,_5a5);
return {markedElements:[_5a6],newElements:[_5a6]};
}
if(!$telerik.isSafari){
keepFontNames();
}
if(!$telerik.isIE){
_5a3.ownerDocument.execCommand("UseCSS",false,true);
}
_5a3.ownerDocument.execCommand("FontName",false,_59d);
var _5a7=_5a3.getElementsByTagName(_5a2);
for(var i=0;i<_5a7.length;i++){
var _5a6=_5a7[i];
if(_5a6.getAttribute("face")==_59d||_5a6.style.fontFamily==_59d){
_5a6.removeAttribute("face");
if(_5a6.style.fontFamily==_59d){
_5a6.style.fontFamily="";
}
_5a0.push(_5a6);
var _5a9=_5a6.getElementsByTagName(_5a2);
for(var j=0;j<_5a9.length;j++){
var _o=_5a9[j];
if(_o.getAttribute("face")!=_59d){
_5a0.push(_o);
}
}
if(!_5a6.getAttribute(_59e)){
_5a1.push(_5a6);
}
}
_5a6.removeAttribute(_59e);
}
if(!$telerik.isSafari){
restoreFontNames();
}
if(!$telerik.isIE){
_5a3.ownerDocument.execCommand("UseCSS",false,false);
}
function keepFontNames(){
var _5ac=_59c._contentArea.getElementsByTagName(_5a2);
for(var i=0;i<_5ac.length;i++){
var _5ae=_5ac[i];
if(_5ac[i].face){
_5ae.setAttribute("_face",_5ae.face);
_59f.push(_5ae);
}
_5ae.setAttribute(_59e,1);
}
}
function restoreFontNames(){
for(var i=0;i<_59f.length;i++){
_59f[i].face=_59f[i].getAttribute("_face");
_59f[i].removeAttribute("_face");
}
_59f=[];
}
return {markedElements:_5a0,newElements:_5a1};
};
})();
if(typeof (RadEditorCommandList)=="undefined"){
var RadEditorCommandList=Telerik.Web.UI.Editor.CommandList;
}
Type.registerNamespace("Telerik.Web.UI.Editor");
Telerik.Web.UI.Editor.CommandsManager=function(_5b0){
this._commands=[];
this._currentCommandIndex=-1;
};
Telerik.Web.UI.Editor.CommandsManager.prototype={get_commands:function(){
return this._commands;
},execute:function(_5b1,_5b2){
if(_5b1&&_5b1.execute){
var _5b3=_5b1.execute();
if(false==_5b2){
return false;
}
if(_5b3&&_5b1._canUnexecute){
this._clearCommandsToRedo();
Array.add(this._commands,_5b1);
this._currentCommandIndex=this._commands.length-1;
return true;
}
}
return false;
},undo:function(_5b4){
if(_5b4>this._commands.length){
_5b4=this._commands.length;
}
var _5b5=0;
var _5b6=null;
while(0<_5b4--&&0<=this._currentCommandIndex&&this._currentCommandIndex<this._commands.length){
_5b6=this._commands[this._currentCommandIndex--];
if(_5b6){
_5b6.unexecute();
_5b5++;
}
}
},redo:function(_5b7){
if(_5b7>this._commands.length){
_5b7=this._commands.length;
}
var _5b8=0;
var _5b9=null;
var _5ba=this._currentCommandIndex+1;
while(0<_5b7--&&0<=_5ba&&_5ba<this._commands.length){
_5b9=this._commands[_5ba];
if(_5b9){
_5b9.execute();
this._currentCommandIndex=_5ba;
_5b8++;
}
_5ba++;
}
},removeCommandAt:function(_5bb){
this._commands.splice(_5bb,1);
if(this._currentCommandIndex>=_5bb){
this._currentCommandIndex--;
}
},isUndoAvailable:function(){
return (-1<this._currentCommandIndex);
},isRedoAvailable:function(){
return (this._currentCommandIndex<this._commands.length-1);
},getCommandsToUndo:function(){
if(this.isUndoAvailable()){
return (this._commands.slice(0,this._currentCommandIndex+1)).reverse();
}else{
return [];
}
},getCommandsToRedo:function(){
if(this.isRedoAvailable()){
return this._commands.slice(this._currentCommandIndex+1);
}else{
return [];
}
},canRepeatLastCommand:function(){
return ((this._currentCommandIndex==this._commands.length-1)&&null!=this._commands[this._currentCommandIndex]&&("function"==typeof (this._commands[this._currentCommandIndex].clone)));
},repeatLastCommand:function(){
if(this.canRepeatLastCommand()){
var _5bc=this._commands[this._currentCommandIndex].clone();
this.execute(_5bc);
}
},_clearCommandsToRedo:function(){
if(this.isRedoAvailable()){
this._commands.splice(this._currentCommandIndex+1,this._commands.length-this._currentCommandIndex);
}
}};
Telerik.Web.UI.Editor.CommandsManager.registerClass("Telerik.Web.UI.Editor.CommandsManager",null);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.EditingOptions=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.EditingOptions.prototype={Typing:1,Tools:2,ContextMenus:4,Tab:8,Modules:16,EditModes:32,All:63};
Telerik.Web.UI.EditingOptions.registerEnum("Telerik.Web.UI.EditingOptions",false);
Telerik.Web.UI.StripFormattingOptions=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.StripFormattingOptions.prototype={None:0,NoneSupressCleanMessage:1,MSWord:2,MSWordNoFonts:4,MSWordRemoveAll:8,Css:16,Font:32,Span:64,AllExceptNewLines:128,All:256};
Telerik.Web.UI.StripFormattingOptions.registerEnum("Telerik.Web.UI.StripFormattingOptions",false);
Telerik.Web.UI.EditModes=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.EditModes.prototype={Design:1,Html:2,Preview:4,All:7};
Telerik.Web.UI.EditModes.registerEnum("Telerik.Web.UI.EditModes",false);
Telerik.Web.UI.EditorToolbarMode=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.EditorToolbarMode.prototype={Default:1,Floating:2,PageTop:4,ShowOnFocus:8};
Telerik.Web.UI.EditorToolbarMode.registerEnum("Telerik.Web.UI.EditorToolbarMode",false);
Telerik.Web.UI.EditorFilters=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.EditorFilters.prototype={None:0,RemoveScripts:1,MakeUrlsAbsolute:2,FixUlBoldItalic:4,FixEnclosingP:8,IECleanAnchors:16,MozEmStrong:32,ConvertFontToSpan:64,ConvertToXhtml:128,IndentHTMLContent:256,DefaultFilters:65533};
Telerik.Web.UI.EditorFilters.registerEnum("Telerik.Web.UI.EditorFilters",false);
Type.registerNamespace("Telerik.Web.UI");
Type.registerNamespace("Telerik.Web.UI.Editor");
Telerik.Web.UI.Editor.Filter=function(){
Telerik.Web.UI.Editor.Filter.initializeBase(this);
this.IsDom=false;
this.Enabled=false;
this.Name="RadEditor filter";
this.Description="RadEditor filter description";
};
Telerik.Web.UI.Editor.Filter.prototype={dispose:function(){
},getHtmlContent:function(_5bd){
return _5bd;
},getDesignContent:function(_5be){
return _5be;
},get_isDom:function(){
return this.IsDom;
},set_isDom:function(_5bf){
this.IsDom=_5bf;
},get_enabled:function(){
return this.Enabled;
},set_enabled:function(_5c0){
this.Enabled=_5c0;
},get_name:function(){
return this.Name;
},set_name:function(_5c1){
this.Name=_5c1;
},get_description:function(){
return this.Description;
},set_description:function(_5c2){
this.Description=_5c2;
}};
Telerik.Web.UI.Editor.Filter.registerClass("Telerik.Web.UI.Editor.Filter",Sys.Component);
Telerik.Web.UI.Editor.StripScriptsFilter=function(){
Telerik.Web.UI.Editor.StripScriptsFilter.initializeBase(this);
this.IsDom=false;
this.Enabled=true;
this.Name="StripScriptsFilter";
this.Description="This filter strips all script tags from the content.";
};
Telerik.Web.UI.Editor.StripScriptsFilter.prototype={getHtmlContent:function(_5c3){
return this._performStripping(_5c3);
},getDesignContent:function(_5c4){
return this._performStripping(_5c4);
},_performStripping:function(_5c5){
var _5c6=_5c5.replace(new RegExp("<(SCRIPT)([^>]*)/>","ig"),"");
_5c6=_5c6.replace(RegExp("<(SCRIPT)([^>]*)>[\\s\\S]*?</(SCRIPT)([^>]*)>","ig"),"");
return _5c6;
}};
Telerik.Web.UI.Editor.StripScriptsFilter.registerClass("Telerik.Web.UI.Editor.StripScriptsFilter",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.EncodeScriptsFilter=function(){
Telerik.Web.UI.Editor.EncodeScriptsFilter.initializeBase(this);
this.IsDom=false;
this.Enabled=true;
this.Name="EncodeScriptsFilter";
this.Description="This filter encodes all script tags from the content.";
};
Telerik.Web.UI.Editor.EncodeScriptsFilter.prototype={getHtmlContent:function(_5c7){
var _5c8=new RegExp("<!"+"--RADEDITORSAVEDTAG_([\\s\\S]*?)--"+">","ig");
var _5c9=new RegExp("--RADEDITORSAVEDTAGENDING>","ig");
var _5ca=_5c7.replace(_5c8,"<$1>");
_5ca=_5ca.replace(_5c9,"--"+">");
return _5ca;
},getDesignContent:function(_5cb){
var _5cc=function(_5cd,_5ce,_5cf,_5d0,_5d1){
var _5d2=_5d1.substring(0,_5d0).lastIndexOf("<!"+"--");
var _5d3=_5d1.substring(0,_5d0).lastIndexOf("--"+">");
if(_5d2>_5d3){
_5d2=_5d1.substring(_5d0,_5d1.length).indexOf("<!"+"--");
_5d3=_5d1.substring(_5d0,_5d1.length).indexOf("--"+">");
if((_5d2==-1&&_5d3>-1)||(_5d3<_5d2)){
return _5cd;
}
}
var _5d4=_5cf.replace("--"+">","--RADEDITORSAVEDTAGENDING>");
var _5d5="<!"+"--RADEDITORSAVEDTAG_"+_5ce+_5d4+"--"+">";
return _5d5;
};
var _5d6=new RegExp("<(script|noscript)([\\s\\S]*?<\\/\\1)>","ig");
var _5d7=_5cb.replace(_5d6,_5cc);
return _5d7;
}};
Telerik.Web.UI.Editor.EncodeScriptsFilter.registerClass("Telerik.Web.UI.Editor.EncodeScriptsFilter",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.RemoveExtraBrakes=function(){
Telerik.Web.UI.Editor.RemoveExtraBrakes.initializeBase(this);
this.IsDom=false;
this.Enabled=true;
this.Name="RemoveExtraBrakes";
this.Description="This filter strips all extra brakse inside some tags like p, h1, etc.";
};
Telerik.Web.UI.Editor.RemoveExtraBrakes.prototype={getHtmlContent:function(_5d8){
return this._performStripping(_5d8);
},_performStripping:function(_5d9){
var _5da=_5d9;
_5da=_5da.replace(/<BR\s?\/?>\s*<\/(H1|H2|H3|H4|H5|H6|LI|P)/ig,"</$1");
_5da=_5da.replace(/<(H1|H2|H3|H4|H5|H6|LI|P)([^>]*)?><BR\s?\/?>/ig,"<$1 $2>");
return _5da;
}};
Telerik.Web.UI.Editor.RemoveExtraBrakes.registerClass("Telerik.Web.UI.Editor.RemoveExtraBrakes",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.FixNestedLists=function(){
Telerik.Web.UI.Editor.FixNestedLists.initializeBase(this);
this.IsDom=true;
this.Enabled=true;
this.Name="FixNestedLists";
this.Description="This filter produces valid XHTML from nested lists";
};
Telerik.Web.UI.Editor.FixNestedLists.prototype={_getElements:function(_5db,_5dc){
var _5dd=_5db.getElementsByTagName(_5dc);
if(!_5dd){
_5dd=_5db.ownerDocument.getElementsByTagName(_5dc);
}
return _5dd;
},fixLists:function(_5de,_5df){
var _5e0=this._getElements(_5de,_5df);
for(var i=_5e0.length-1;i>=0;i--){
var list=_5e0[i];
var _5e3=list.previousSibling;
if(_5e3&&_5e3.nodeType==3){
_5e3=_5e3.previousSibling;
}
if(_5e3&&"li"==list.previousSibling.nodeName.toLowerCase()){
_5e3.appendChild(list.cloneNode(true));
var _5e4=list.parentNode;
_5e4.removeChild(list);
_5e4=null;
}
}
},getHtmlContent:function(_5e5){
this.fixLists(_5e5,"OL");
this.fixLists(_5e5,"UL");
return _5e5;
}};
Telerik.Web.UI.Editor.FixNestedLists.registerClass("Telerik.Web.UI.Editor.FixNestedLists",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.FixUlBoldItalic=function(){
Telerik.Web.UI.Editor.FixUlBoldItalic.initializeBase(this);
this.IsDom=true;
this.Enabled=true;
this.Name="FixUlBoldItalic";
this.Description="This filter changes u, b, i tags to spans with CSS";
};
Telerik.Web.UI.Editor.FixUlBoldItalic.prototype={_getElements:function(_5e6,_5e7){
var _5e8=_5e6.getElementsByTagName(_5e7);
if(!_5e8){
_5e8=_5e6.ownerDocument.getElementsByTagName(_5e7);
}
return _5e8;
},_replaceElementWithSpan:function(_5e9,_5ea,_5eb){
var _5ec=this._getElements(_5e9,_5ea);
while(_5ec.length>0){
var _5ed=_5e9.ownerDocument.createElement("span");
_5ed.style.cssText=_5eb;
var _5ee=_5ec[0].innerHTML;
if($telerik.isIE&&_5ee==" "){
_5ed.innerText=_5ee;
}else{
Telerik.Web.UI.Editor.Utils.setElementInnerHtml(_5ed,_5ee);
}
_5ec[0].parentNode.replaceChild(_5ed,_5ec[0]);
_5ec=this._getElements(_5e9,_5ea);
}
},_replaceSpanWithElement:function(_5ef,_5f0,_5f1){
var _5f2=this._getElements(_5ef,"span");
var _5f3=_5f2.length-1;
while(_5f3>=0){
var _5f4=[];
var _5f5=_5f2[_5f3];
for(var i=0;i<_5f5.childNodes.length;i++){
Array.add(_5f4,_5f5.childNodes[i].cloneNode(true));
}
if(_5f5.style.cssText.toLowerCase()==_5f1||_5f5.style.cssText.toLowerCase()==(_5f1+";")){
var _5f7=_5ef.ownerDocument.createElement(_5f0);
for(var j=0;j<_5f4.length;j++){
_5f7.appendChild(_5f4[j]);
}
_5f5.parentNode.replaceChild(_5f7,_5f2[_5f3]);
_5f2=this._getElements(_5ef,"span");
_5f3=_5f2.length-1;
}else{
_5f3--;
}
}
},getHtmlContent:function(_5f9){
this._replaceElementWithSpan(_5f9,"u","text-decoration:underline;");
return _5f9;
},getDesignContent:function(_5fa){
this._replaceSpanWithElement(_5fa,"u","text-decoration: underline");
return _5fa;
}};
Telerik.Web.UI.Editor.FixUlBoldItalic.registerClass("Telerik.Web.UI.Editor.FixUlBoldItalic",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.IEKeepCommentsFilter=function(){
Telerik.Web.UI.Editor.IEKeepCommentsFilter.initializeBase(this);
this.IsDom=false;
this.Enabled=true;
this.Name="IEKeepCommentsFilter";
this.Description="This filter keeps the conditional comments in IE.";
};
Telerik.Web.UI.Editor.IEKeepCommentsFilter.prototype={getHtmlContent:function(_5fb){
var _5fc=new RegExp("<!"+"--RADEDITORSAVEDCOMMENT","ig");
var _5fd=_5fb.replace(_5fc,"<!--");
return _5fd;
},getDesignContent:function(_5fe){
var _5ff=new RegExp("<!"+"--(\\[[^]]+\\][\\s\\S]*?)-"+"->","ig");
var _600=_5fe.replace(_5ff,"<!-"+"-RADEDITORSAVEDCOMMENT$1-"+"->");
return _600;
}};
Telerik.Web.UI.Editor.IEKeepCommentsFilter.registerClass("Telerik.Web.UI.Editor.IEKeepCommentsFilter",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.IEKeepObjectParamsFilter=function(){
Telerik.Web.UI.Editor.IEKeepObjectParamsFilter.initializeBase(this);
this.IsDom=false;
this.Enabled=true;
this.Name="IEKeepObjectParamsFilter";
this.Description="This filter keeps the params of object tags when going to html mode and back.";
};
Telerik.Web.UI.Editor.IEKeepObjectParamsFilter.prototype={getHtmlContent:function(_601){
var _602=new RegExp("<param([\\s\\S]+?)?>","ig");
var _603=new RegExp("<rade_param([\\s>])","ig");
var _604=_601;
if(_602.test(_601)&&_603.test(_601)){
_604=_604.replace(_602,"");
}
_604=_604.replace(_603,"<param$1");
_604=_604.replace(/<\/rade_param>/gi,"");
return _604;
},getDesignContent:function(_605){
var _606=new RegExp("<param([\\s\\S]+?)/?>","ig");
var _607=_605.replace(_606,"<rade_param$1></rade_param><param$1>");
return _607;
}};
Telerik.Web.UI.Editor.IEKeepObjectParamsFilter.registerClass("Telerik.Web.UI.Editor.IEKeepObjectParamsFilter",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.FixEnclosingP=function(){
Telerik.Web.UI.Editor.FixEnclosingP.initializeBase(this);
this.IsDom=true;
this.Enabled=true;
this.Name="FixEnclosingP";
this.Description="This filter removes a parent paragraph tag if the whole content is inside it.";
};
Telerik.Web.UI.Editor.FixEnclosingP.prototype={_removeNode:function(node){
var _609=node.parentNode;
if(_609!=null){
while(node.childNodes&&node.childNodes.length>0){
_609.insertBefore(node.childNodes[0],node);
}
_609.removeChild(node);
return _609;
}
return true;
},getHtmlContent:function(_60a){
var _60b=null;
if(_60a.tagName.toLowerCase()=="html"){
_60b=_60a.getElementsByTagName("BODY")[0];
}else{
_60b=_60a;
}
if($telerik.isIE){
if(_60b&&(_60b.firstChild)&&("P"==_60b.firstChild.tagName)&&(_60b.childNodes.length==1)&&(_60b.innerHTML.substring(0,3).toLowerCase()=="<p>")){
this._removeNode(_60b.firstChild);
}
}else{
if(_60b&&(_60b.childNodes.length==1)&&(_60b.firstChild.tagName)&&("br"==_60b.firstChild.tagName.toLowerCase())){
_60b.innerHTML="";
}
}
return _60a;
}};
Telerik.Web.UI.Editor.FixEnclosingP.registerClass("Telerik.Web.UI.Editor.FixEnclosingP",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.IEFixEmptyParagraphs=function(){
Telerik.Web.UI.Editor.IEFixEmptyParagraphs.initializeBase(this);
this.IsDom=false;
this.Enabled=true;
this.Name="IEFixEmptyParagraphs";
this.Description="This filter inserts a non-braking space in empty paragraph tags so they are rendered correctly in IE.";
};
Telerik.Web.UI.Editor.IEFixEmptyParagraphs.prototype={getHtmlContent:function(_60c){
var re=new RegExp("(<p[^>]*>)(<\\/p>)","ig");
var _60e=_60c.replace(re,"$1&nbsp;$2");
return _60e;
}};
Telerik.Web.UI.Editor.IEFixEmptyParagraphs.registerClass("Telerik.Web.UI.Editor.IEFixEmptyParagraphs",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.IECleanAnchorsFilter=function(){
Telerik.Web.UI.Editor.IECleanAnchorsFilter.initializeBase(this);
this.IsDom=false;
this.Enabled=true;
this.Name="IECleanAnchorsFilter";
this.Description="This filter removse the current page href from all anchor (#) links .";
};
Telerik.Web.UI.Editor.IECleanAnchorsFilter.prototype={getHtmlContent:function(_60f){
var _610=document.location.href;
var re=new RegExp("(<A[^<>]*?(href)\\s*=\\s*['\"])("+_610+")(\\#[^'\"]*?['\"][^>]*?>)","ig");
var _612=_60f.replace(re,"$1$4");
return _612;
}};
Telerik.Web.UI.Editor.IECleanAnchorsFilter.registerClass("Telerik.Web.UI.Editor.IECleanAnchorsFilter",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.MozEmStrongFilter=function(){
Telerik.Web.UI.Editor.MozEmStrongFilter.initializeBase(this);
this.IsDom=false;
this.Enabled=true;
this.Name="MozEmStrongFilter";
this.Description="This filter changes b,strong and i,em in Mozilla browsers.";
};
Telerik.Web.UI.Editor.MozEmStrongFilter.prototype={getHtmlContent:function(_613){
var _614=_613.replace(new RegExp("<b(\\s([^>])*?)?>","ig"),"<strong$1>");
_614=_614.replace(new RegExp("</b(\\s([^>])*?)?>","ig"),"</strong$1>");
_614=_614.replace(new RegExp("<i(\\s([^>])*?)?>","ig"),"<em$1>");
_614=_614.replace(new RegExp("</i(\\s([^>])*?)?>","ig"),"</em$1>");
return _614;
},getDesignContent:function(_615){
var _616=_615.replace(new RegExp("<strong(\\s([^>])*?)?>","ig"),"<b$1>");
_616=_616.replace(new RegExp("</strong(\\s([^>])*?)?>","ig"),"</b$1>");
_616=_616.replace(new RegExp("<em(\\s([^>])*?)?>","ig"),"<i$1>");
_616=_616.replace(new RegExp("</em(\\s([^>])*?)?>","ig"),"</i$1>");
return _616;
}};
Telerik.Web.UI.Editor.MozEmStrongFilter.registerClass("Telerik.Web.UI.Editor.MozEmStrongFilter",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.MozillaKeepStylesString=function(){
Telerik.Web.UI.Editor.MozillaKeepStylesString.initializeBase(this);
this.IsDom=false;
this.Enabled=true;
this.Name="MozillaKeepStylesString";
this.Description="This filter remembers the positions of link tags in the html content (part 1).";
this.markerCounter=0;
};
Telerik.Web.UI.Editor.MozillaKeepStylesString.prototype={getDesignContent:function(_617){
var self=this;
var _619=function(_61a,_61b,_61c,_61d,_61e){
var _61f=_61e.indexOf("</head>",_61d);
if(_61f!=-1&&_61e.indexOf("<body",_61f)!=-1){
return _61a;
}else{
self.markerCounter++;
var _620="RadEditorStyleKeeper"+self.markerCounter;
var _621="<div id='"+_620+"' style='display:none;'>&nbsp;</div><"+_61b+" reoriginalpositionmarker='"+_620+"'"+_61c;
return _621;
}
};
var _622=new RegExp("<(link|style)([^>]*>)","gi");
var _623=_617.replace(_622,_619);
return _623;
}};
Telerik.Web.UI.Editor.MozillaKeepStylesString.registerClass("Telerik.Web.UI.Editor.MozillaKeepStylesString",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.MozillaKeepStylesDom=function(){
Telerik.Web.UI.Editor.MozillaKeepStylesDom.initializeBase(this);
this.IsDom=true;
this.Enabled=true;
this.Name="MozillaKeepStylesDom";
this.Description="This filter remembers the positions of link tags in the html content(part 2).";
this._divs=[];
};
Telerik.Web.UI.Editor.MozillaKeepStylesDom.prototype={getHtmlContent:function(_624){
var _625=_624.getElementsByTagName("HEAD")[0];
var _626=true;
if(!_625){
_625=_624.ownerDocument.getElementsByTagName("HEAD")[0];
_626=false;
}
if(!_625){
return _624;
}
this._restoreElements(_625,_624,"STYLE");
this._restoreElements(_625,_624,"LINK");
var divs=_624.getElementsByTagName("DIV");
if(divs){
for(var j=divs.length-1;j>=0;j--){
var _629=divs[j];
if(_629.id.indexOf("RadEditorStyleKeeper")==0){
var _62a=_629.parentNode;
_62a.removeChild(_629);
}
}
}
divs=null;
if(_626){
this._removeElements(_625,"STYLE");
this._removeElements(_625,"LINK");
}
this._removeMarkerAttributes(_624,"STYLE");
this._removeMarkerAttributes(_624,"LINK");
return _624;
},_restoreElements:function(_62b,_62c,_62d){
var _62e;
_62e=_62b.getElementsByTagName(_62d);
this._divs=_62c.getElementsByTagName("DIV");
var i=0;
while(_62e.length>0&&i<_62e.length){
this._restoreStyle(_62e[i++]);
}
},_restoreStyle:function(_630){
var _631=_630.getAttribute("reoriginalpositionmarker");
if(_631){
j=0;
var _632=null;
while(j<this._divs.length&&!_632){
if(this._divs[j].id==_631){
_632=this._divs[j];
}
j++;
}
if(_632){
var _633=_630.cloneNode(true);
_633.removeAttribute("reoriginalpositionmarker");
var _634=_632.parentNode;
_634.replaceChild(_633,_632);
return true;
}
}
return false;
},_removeElements:function(_635,_636){
var _637=_635.getElementsByTagName(_636);
if(_637){
for(var j=_637.length-1;j>=0;j--){
var _639=_637[j];
if(null!=_639.getAttribute("reoriginalpositionmarker")){
var _63a=_639.parentNode;
_63a.removeChild(_639);
}
}
_637=null;
}
},_removeMarkerAttributes:function(_63b,_63c){
styles=_63b.getElementsByTagName(_63c);
if(styles){
for(var j=styles.length-1;j>=0;j--){
styles[j].removeAttribute("reoriginalpositionmarker");
}
}
styles=null;
}};
Telerik.Web.UI.Editor.MozillaKeepStylesDom.registerClass("Telerik.Web.UI.Editor.MozillaKeepStylesDom",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.MozillaKeepFlashString=function(_63e){
Telerik.Web.UI.Editor.MozillaKeepFlashString.initializeBase(this);
this.IsDom=false;
this.Enabled=true;
this.Name="MozillaKeepFlashString";
this.Description="This filter replaces the flash/media objects with static images in design mode.";
this._flashImageSrc=_63e?_63e:"FlashManager.gif";
};
Telerik.Web.UI.Editor.MozillaKeepFlashString.prototype={getDesignContent:function(_63f){
var _640=this;
var _641=function(_642,gr1,gr2,gr3,str,_647){
var _648=String.format("<img isflash=\"true\" {0} />{1}",gr1,gr2);
_648=_648.replace(/\ssrc=/gi,String.format(" src=\"{0}\" flashSrc=",_640._flashImageSrc));
return _648;
};
var _649=new RegExp("<embed([^>]*)?>(.*)?(<\\/embed>)?","ig");
var _64a=_63f.replace(_649,_641);
return _64a;
}};
Telerik.Web.UI.Editor.MozillaKeepFlashString.registerClass("Telerik.Web.UI.Editor.MozillaKeepFlashString",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.MozillaKeepFlash=function(){
Telerik.Web.UI.Editor.MozillaKeepFlash.initializeBase(this);
this.IsDom=true;
this.Enabled=true;
this.Name="MozillaKeepFlash";
this.Description="This filter replaces the flash/media objects with static images in design mode.";
};
Telerik.Web.UI.Editor.MozillaKeepFlash.prototype={getHtmlContent:function(_64b){
if(!_64b){
return _64b;
}
var _64c=_64b.getElementsByTagName("IMG");
for(var i=0;i<_64c.length;i++){
var _64e=_64c[i];
var _64f=_64e.getAttribute("isflash");
if(_64f!=null){
var _650=_64e.getAttribute("flashSrc");
var _651=Telerik.Web.UI.Editor.Utils.getOuterHtml(_64e);
_651=_651.replace(/<img/gi,"<embed");
var oDiv=_64e.ownerDocument.createElement("DIV");
oDiv.innerHTML=_651;
newNode=oDiv.firstChild;
if(_650){
newNode.src=_650;
if($telerik.isSafari){
newNode.setAttribute("src",_650);
}
}
newNode.removeAttribute("flashSrc");
newNode.removeAttribute("isflash");
var _653=_64e.parentNode;
_653.insertBefore(newNode,_64e);
_653.removeChild(_64e);
i--;
}
}
return _64b;
}};
Telerik.Web.UI.Editor.MozillaKeepFlash.registerClass("Telerik.Web.UI.Editor.MozillaKeepFlash",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.StripJunkFilter=function(){
Telerik.Web.UI.Editor.StripJunkFilter.initializeBase(this);
this.IsDom=false;
this.Enabled=true;
this.Name="StripJunkFilter";
this.Description="This filter strips extra content, added by the Safari/Firefox browsers.";
};
Telerik.Web.UI.Editor.StripJunkFilter.prototype={getHtmlContent:function(_654){
var html=_654;
if($telerik.isSafari){
html=html.replace(new RegExp(" class=\"khtml-block-placeholder\"","ig"),"");
html=html.replace(new RegExp(" class=\"Apple-style-span\"","ig"),"");
html=html.replace(new RegExp(" class=\"webkit-block-placeholder\"","ig"),"");
}
if($telerik.isFirefox){
html=html.replace(new RegExp("\\s?<br type=\"_moz\" \\/>","ig")," ");
html=html.replace(new RegExp(" _moz_[a-z_]*=\"[^\"]*\"","ig"),"");
html=html.replace(new RegExp(" type=\"_moz\"","ig"),"");
}
return html;
}};
Telerik.Web.UI.Editor.StripJunkFilter.registerClass("Telerik.Web.UI.Editor.StripJunkFilter",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.ConvertFontToSpanFilter=function(){
Telerik.Web.UI.Editor.ConvertFontToSpanFilter.initializeBase(this);
this.IsDom=true;
this.Enabled=true;
this.Name="ConvertFontToSpanFilter";
this.Description="This filter changes deprecated font tags to compliant span tags.";
this._fontSizesPx=["10px","13px","16px","18px","24px","32px","48px"];
this._fontSizesRevPx=[];
for(var i=0;i<this._fontSizesPx.length;i++){
this._fontSizesRevPx[parseInt(this._fontSizesPx[i])]=i;
}
};
Telerik.Web.UI.Editor.ConvertFontToSpanFilter.prototype={dispose:function(){
this._fontSizesPx=null;
this._fontSizesRevPx=null;
},getHtmlContent:function(_657){
var _658=_657.ownerDocument;
var _659=_658.createElement("SPAN");
var span,font,_65c;
var _65d=_657.getElementsByTagName("FONT");
while(_65d.length>0){
font=_65d[0];
_65c=font.parentNode;
span=_659.cloneNode(false);
Telerik.Web.UI.Editor.Utils.mergeElementAttributes(font,span,false);
if(font.style.cssText&&font.style.cssText!=""){
span.style.cssText=font.style.cssText;
}
if(font.className){
span.className=font.className;
}
if(font.face){
span.style.fontFamily=font.face;
if(span.getAttribute("face")!=null){
span.removeAttribute("face");
}
}
var size=0;
if(font.style.fontSize){
span.style.fontSize=font.style.fontSize;
}else{
if(!isNaN(size=parseInt(font.size))&&font.size!="+0"){
try{
if(size<0){
size=size+4;
}
span.style.fontSize=this._fontSizesPx[size-1];
}
catch(ex){
span.style.fontSize=this._fontSizesPx[3];
}
if(span.getAttribute("size")!=null){
span.removeAttribute("size");
}
}
}
if(font.color){
span.style.color=font.color;
if(span.getAttribute("color")!=null){
span.removeAttribute("color");
}
}
if($telerik.isIE&&font.innerHTML==" "){
span.innerText=font.innerHTML;
}else{
Telerik.Web.UI.Editor.Utils.setElementInnerHtml(span,font.innerHTML);
}
_65c.replaceChild(span,font);
_65d=_657.getElementsByTagName("FONT");
}
return _657;
},getDesignContent:function(_65f){
var _660=_65f.ownerDocument;
var _661=_660.createElement("FONT");
var span,font,_664;
var _665=_65f.getElementsByTagName("SPAN");
while(_665.length>0){
span=_665[0];
_664=span.parentNode;
font=_661.cloneNode(false);
Telerik.Web.UI.Editor.Utils.mergeElementAttributes(span,font,false);
if(span.style.cssText&&span.style.cssText!=""){
font.style.cssText=span.style.cssText;
}
if(span.className){
font.className=span.className;
}
if(span.style.fontFamily){
font.face=span.style.fontFamily;
this._removeElementStyleAttribute(font,"fontFamily");
}
if(span.style.fontSize){
var size=3;
var _667=null;
if(-1!=span.style.fontSize.indexOf("px")){
_667=this._fontSizesRevPx[parseInt(span.style.fontSize)];
}
if(typeof (_667)!="undefined"&&null!=_667){
font.size=_667+1;
this._removeElementStyleAttribute(font,"fontSize");
}
}
if(span.style.color){
font.color=this._fixColorValue(span.style.color);
this._removeElementStyleAttribute(font,"color");
}
if($telerik.isIE&&span.innerHTML==" "){
font.innerText=span.innerHTML;
}else{
Telerik.Web.UI.Editor.Utils.setElementInnerHtml(font,span.innerHTML);
}
_664.replaceChild(font,span);
_665=_65f.getElementsByTagName("SPAN");
}
return _65f;
},_fixColorValue:function(_668){
if(_668.toLowerCase().indexOf("rgb")!=-1){
var _669="#";
var _66a=function(val){
var _66c=parseInt(val,10).toString(16);
_669=_669+(_66c.length==1?"0"+_66c:_66c);
return val;
};
_668=_668.replace(/(\d+)/gi,_66a);
_66a=null;
return _669;
}else{
return _668;
}
},_removeElementStyleAttribute:function(_66d,_66e){
if(_66d.style&&_66d.style[_66e]){
if(_66d.style.removeAttribute){
_66d.style.removeAttribute(_66e);
}else{
if(_66d.style.removeProperty){
_66e=_66e.replace(/([A-Z])/g,"-$1").toLowerCase();
_66d.style.removeProperty(_66e);
}
}
if(_66d.style[_66e]){
_66d.style[_66e]=null;
}
if(_66d.style.cssText){
}else{
_66d.removeAttribute("style");
}
}
}};
Telerik.Web.UI.Editor.ConvertFontToSpanFilter.registerClass("Telerik.Web.UI.Editor.ConvertFontToSpanFilter",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.ConvertToXhtmlFilter=function(){
Telerik.Web.UI.Editor.ConvertToXhtmlFilter.initializeBase(this);
this._uniqueIds={};
this.Name="ConvertToXhtmlFilter";
this.Description="This filter converts the HTML from the editor content area to valid XHTML";
this.Enabled=true;
this.IsDom=true;
};
Telerik.Web.UI.Editor.ConvertToXhtmlFilter.prototype={dispose:function(){
this._uniqueIds=null;
},getHtmlContent:function(_66f){
if(!_66f){
return "";
}
var sb=new Sys.StringBuilder("");
this._appendNodeXhtml(_66f,sb);
return sb.toString();
},_convertAttribute:function(s){
return String(s).replace(/\&/g,"&amp;").replace(/</g,"&lt;").replace(/>/g,"&gt;").replace(/\"/g,"&quot;");
},_getAttributeValue:function(_672,_673,sb){
var name=_672.nodeName;
var _676=_672.nodeValue;
if(name!="style"){
if($telerik.isIE&&(name=="type"||name=="value"||name=="selected")){
if(!_676){
return;
}
}else{
if(!_672.specified){
if($telerik.isIE&&_676==""&&typeof (_673[name])=="string"&&_673[name]!=""){
_676=_673[name];
}else{
return;
}
}
}
if(!_676){
return;
}
if(!isNaN(_676)){
_676=_673.getAttribute(name);
}
if($telerik.isIE&&(name=="href"||name=="src")){
_676=_673.getAttribute(name,2);
}
sb.append(" "+(_672.expando?name:name.toLowerCase())+"=\""+this._convertAttribute(_676)+"\"");
}else{
var _677=_673.style.cssText;
if(_677){
sb.append(" style=\""+this._convertAttribute(_677.toLowerCase())+"\"");
}
}
},_canHaveChildren:function(node){
switch(node.tagName.toUpperCase()){
case "AREA":
case "BASE":
case "BASEFONT":
case "COL":
case "FRAME":
case "HR":
case "IMG":
case "BR":
case "INPUT":
case "ISINDEX":
case "LINK":
case "META":
case "PARAM":
return false;
}
return true;
},_appendElementNode:function(node,sb){
if(node.tagName.charAt(0)=="/"){
return;
}
if(node.nodeName=="!"){
sb.append(node.text);
return;
}
var name=node.nodeName;
if(node.scopeName){
if(node.scopeName=="HTML"){
name=name.toLowerCase();
}else{
name=node.scopeName+":"+name;
}
}else{
name=name.toLowerCase();
}
sb.append("<"+name);
if($telerik.isIE){
if("img"==name){
var oImg=document.createElement("IMG");
oImg.mergeAttributes(node);
if(oImg.width){
sb.append(" width=\""+node.getAttribute("width",2)+"\"");
}
if(oImg.height){
sb.append(" height=\""+node.getAttribute("height",2)+"\"");
}
if(oImg.getAttribute("alt").length==0){
sb.append(" alt=\""+oImg.getAttribute("alt")+"\"");
}
}else{
if("area"==name||"a"==name){
if(node.shape){
sb.append(" shape=\""+node.shape.toLowerCase()+"\"");
}
if(node.coords){
sb.append(" coords=\""+node.getAttribute("coords")+"\"");
}
var _67d=node.getAttribute("href",2);
if(_67d){
_67d=_67d.replace("about:blank","");
_67d=_67d.replace("about:","");
_67d=_67d.replace(/&amp;/gi,"&").replace(/&/gi,"&amp;");
sb.append(" href=\""+_67d+"\"");
node.removeAttribute("href",0);
}
}
}
}
try{
var _67e=node.attributes;
var l=_67e.length;
for(var i=0;i<l;i++){
this._getAttributeValue(_67e[i],node,sb);
}
}
catch(exc){
}
switch(name){
case "script":
sb.append(">"+node.text+"</"+name+">");
break;
case "textarea":
sb.append(">"+node.value+"</"+name+">");
break;
case "iframe":
sb.append("></iframe>");
break;
case "object":
sb.append(">");
var _681="";
if(node.altHtml){
_681=node.altHtml;
}else{
_681=node.innerHTML;
}
if($telerik.isIE){
_681=_681.replace(/\soriginalAttribute="[^"]+"/gi,"");
_681=_681.replace(/\soriginalPath="[^"]+"/gi,"");
}
sb.append(_681);
sb.append("</object>");
break;
case "title":
case "style":
case "comment":
case "noscript":
var _681=node.innerHTML;
if($telerik.isIE&&_681.length==0){
_681=node.ownerDocument.title;
}
sb.append(">"+_681+"</"+name+">");
break;
default:
if(node.hasChildNodes()||(true==node.canHaveChildren||(node.canHaveChildren==null&&this._canHaveChildren(node)))){
sb.append(">");
var cs=node.childNodes;
l=cs.length;
for(var i=0;i<l;i++){
this._appendNodeXhtml(cs[i],sb);
}
sb.append("</"+name+">");
}else{
sb.append(" />");
}
break;
}
},_appendTextNode:function(node,sb){
var _685=String(node.nodeValue);
var _686=node.parentNode.nodeName.toLowerCase();
if(!$telerik.isIE&&(_686=="style"||_686=="script")){
sb.append(_685);
}else{
_685=_685.replace(/\&/g,"&amp;").replace(/</g,"&lt;").replace(/>/g,"&gt;");
if($telerik.isFirefox){
_685=_685.replace(/[\u00a0]/g,"&nbsp;");
}
sb.append(_685);
}
},_appendCDataNode:function(node,sb){
sb.append("<![CDA"+"TA[\n"+node.nodeValue+"\n]"+"]>");
},_appendCommentNode:function(node,sb){
var _68b=node.nodeValue;
if(!_68b&&node.text){
_68b=node.text;
}else{
_68b="<!--"+_68b+"-->";
}
sb.append(_68b);
},_appendNodeXhtml:function(node,sb){
if(node.uniqueID){
if(this._uniqueIds[node.uniqueID]){
return;
}else{
this._uniqueIds[node.uniqueID]=true;
}
}
switch(node.nodeType){
case 1:
this._appendElementNode(node,sb);
break;
case 3:
this._appendTextNode(node,sb);
break;
case 4:
this._appendCDataNode(node,sb);
break;
case 8:
this._appendCommentNode(node,sb);
break;
}
}};
Telerik.Web.UI.Editor.ConvertToXhtmlFilter.registerClass("Telerik.Web.UI.Editor.ConvertToXhtmlFilter",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.IndentHTMLContentFilter=function(){
Telerik.Web.UI.Editor.IndentHTMLContentFilter.initializeBase(this);
this.Name="IndentHTMLContentFilter";
this.Description="This filter indents the HTML content so it is more readable when you view the code";
this.Enabled=true;
this.IsDom=false;
this._indentPattern="    ";
this._protectedData=null;
var _68e="P|DIV|H1|H2|H3|H4|H5|H6|ADDRESS|PRE|OL|UL|LI|TITLE|META|LINK|BASE|SCRIPT|LINK|TD|TH|AREA|OPTION";
var _68f="HTML|HEAD|BODY|STYLE|FORM|TABLE|TBODY|THEAD|TR";
var _690=_68f+"|UL|OL";
this._ignoreTags=new RegExp("(<PRE[^>]*>|<!--|<SCRIPT[^>]*>)([\\s\\S]*?)(<\\/PRE>|-->|<\\/SCRIPT>)","gi");
this._tagsNLBefore=new RegExp("<("+_68e+")[^>]*>","gi");
this._tagsNLAfter=new RegExp("<\\/("+_68e+")[^>]*>","gi");
this._tagsNLNoCloseAfter=new RegExp("<(BR|HR)[^>]*\\/?>","gi");
this._tagsNLBeforeAndAfter=new RegExp("<\\/?("+_68f+")[^>]*>","gi");
this._tagsIncIndent=new RegExp("^<("+_690+")[\\s\\/>]","i");
this._tagsDecIndent=new RegExp("^<\\/("+_690+")[\\s\\>]","i");
this._shrinkNL=new RegExp("\\s*\\n+\\s*","gi");
};
Telerik.Web.UI.Editor.IndentHTMLContentFilter.prototype={dispose:function(){
this._protectedData=[];
},getHtmlContent:function(html){
var _692=html.trim();
if(_692.indexOf("<body")==0){
_692=_692.substring(_692.indexOf(">")+1,_692.length-7);
}
this._protectedData=[];
var self=this;
var _694=function(_695,_696,_697,_698,_699,_69a){
Array.add(self._protectedData,_697);
return _696+"RADEDITORFORMATTED_"+self._protectedData.length+_698;
};
_692=_692.replace(this._ignoreTags,_694);
var _69b="$&";
if($telerik.isSafari){
_69b="$0";
}
_692=_692.replace(this._tagsNLBefore,"\n"+_69b);
_692=_692.replace(this._tagsNLAfter,_69b+"\n");
_692=_692.replace(this._tagsNLNoCloseAfter,_69b+"\n");
_692=_692.replace(this._tagsNLBeforeAndAfter,"\n"+_69b+"\n");
var _69c=_692.split(this._shrinkNL);
var _69d=new Sys.StringBuilder("");
var _69e="";
for(var i=0;i<_69c.length;i++){
var line=_69c[i];
if(line.length==0){
continue;
}
if(this._tagsDecIndent.test(line)){
if(_69e.length>this._indentPattern.length){
_69e=_69e.substring(this._indentPattern.length);
}else{
_69e="";
}
}
_69d.append(_69e);
_69d.append(line);
_69d.append("\n");
if(this._tagsIncIndent.test(line)){
_69e+=this._indentPattern;
}
}
_692=_69d.toString();
for(var i=0;i<this._protectedData.length;i++){
var _6a1=new RegExp("RADEDITORFORMATTED_"+(i+1));
var _6a2=this._protectedData[i].replace(/\$/gi,"$$$$");
_692=_692.replace(_6a1,_6a2);
}
return _692;
}};
Telerik.Web.UI.Editor.IndentHTMLContentFilter.registerClass("Telerik.Web.UI.Editor.IndentHTMLContentFilter",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.MakeUrlsAbsolute=function(){
Telerik.Web.UI.Editor.MakeUrlsAbsolute.initializeBase(this);
this.Name="MakeUrlsAbsolute";
this.Description="This filter makes all src and href attributes in the editor content have absolute URLs";
this.Enabled=true;
this.IsDom=true;
};
Telerik.Web.UI.Editor.MakeUrlsAbsolute.prototype={getHtmlContent:function(_6a3){
this._updateElements(_6a3,"A","href");
this._updateElements(_6a3,"AREA","href");
this._updateElements(_6a3,"IMG","src");
this._updateElements(_6a3,"EMBED","src");
return _6a3;
},_getElements:function(_6a4,_6a5){
var _6a6=_6a4.getElementsByTagName(_6a5);
if(!_6a6){
_6a6=_6a4.ownerDocument.getElementsByTagName(_6a5);
}
return _6a6;
},_updateElements:function(_6a7,_6a8,_6a9){
var _6aa=_6a7.ownerDocument.createElement("div");
var _6ab=this._getElements(_6a7,_6a8);
if(_6ab){
for(var i=0;i<_6ab.length;i++){
var _6ad=_6ab[i].getAttribute(_6a9,2);
if("href"==_6a9&&_6ad){
_6aa.innerHTML="<a href=\""+_6ad.replace(/\"/gi,"%22")+"\">test</a>";
if($telerik.isIE){
var _6ae=_6ab[i].innerHTML;
}
_6ab[i].setAttribute("href",_6aa.childNodes[0].href);
if($telerik.isIE){
if((_6ae.indexOf("www.")==0&&_6ab[i].innerHTML.match("[a-z]+://"))||(_6ae.indexOf("mailto:")==-1&&_6ab[i].innerHTML.match("mailto:"))){
_6ab[i].innerHTML=_6ae;
}
}
}else{
if("src"==_6a9&&_6ad){
_6aa.innerHTML="<img src=\""+_6ad.replace(/\"/gi,"%22")+"\" />";
_6ab[i].setAttribute("src",_6aa.childNodes[0].src);
}
}
}
}
_6aa.innerHTML="";
_6aa=null;
}};
Telerik.Web.UI.Editor.MakeUrlsAbsolute.registerClass("Telerik.Web.UI.Editor.MakeUrlsAbsolute",Telerik.Web.UI.Editor.Filter);
Telerik.Web.UI.Editor.FiltersManager=function(){
Telerik.Web.UI.Editor.FiltersManager.initializeBase(this);
this._filters=[];
this._enableXhtmlFilter=true;
this._convertToXhtmlFilter=new Telerik.Web.UI.Editor.ConvertToXhtmlFilter();
};
Telerik.Web.UI.Editor.FiltersManager.prototype={dispose:function(){
this._filters=null;
this._convertToXhtmlFilter=null;
},clear:function(){
Array.clear(this._filters);
},get_enableXhtmlFilter:function(){
return this._enableXhtmlFilter;
},set_enableXhtmlFilter:function(_6af){
this._enableXhtmlFilter=_6af;
},add:function(_6b0){
Array.add(this._filters,_6b0);
},addAt:function(_6b1,_6b2){
Array.insert(this._filters,_6b2,_6b1);
},remove:function(_6b3){
Array.remove(this._filters,_6b3);
},removeAt:function(_6b4){
Array.removeAt(this._filters,_6b4);
},getFilterAt:function(_6b5){
return this._filters[_6b5];
},getFilterByName:function(name){
for(var i=0;i<this._filters.length;i++){
var _6b8=this._filters[i];
if(_6b8&&name==_6b8.get_name()){
return _6b8;
}
}
},getDesignContent:function(_6b9){
var _6ba=_6b9;
for(var i=0;i<this._filters.length;i++){
var _6bc=this._filters[i];
if((!_6bc.get_isDom())&&(false!=_6bc.get_enabled())&&_6bc.getDesignContent){
try{
_6ba=_6bc.getDesignContent(_6ba);
}
catch(exc){
alert("Error while executing filter "+_6bc.get_name()+" - "+exc.toString());
}
}
}
return _6ba;
},getDesignContentDom:function(_6bd){
for(var i=0;i<this._filters.length;i++){
var _6bf=this._filters[i];
if((_6bf.get_isDom())&&(false!=_6bf.get_enabled())&&_6bf.getDesignContent){
try{
_6bd=_6bf.getDesignContent(_6bd);
}
catch(exc){
alert("Error while executing filter "+_6bf.get_name()+" - "+exc.toString());
}
}
}
return _6bd;
},getHtmlContent:function(_6c0){
for(var i=0;i<this._filters.length;i++){
var _6c2=this._filters[i];
if((_6c2.get_isDom())&&(false!=_6c2.get_enabled())&&_6c2.getHtmlContent){
try{
_6c0=_6c2.getHtmlContent(_6c0);
}
catch(exc){
alert("Error while executing filter "+_6c2.get_name()+" - "+exc.toString());
}
}
}
var _6c3;
if(this.get_enableXhtmlFilter()){
try{
_6c3=this._convertToXhtmlFilter.getHtmlContent(_6c0);
}
catch(exc){
alert("Error while executing filter XHTML - "+exc.toString());
}
}else{
_6c3=_6c0.innerHTML;
}
_6c3=_6c3.replace(/<body\s*\/>/i,"<body></body>");
for(var i=0;i<this._filters.length;i++){
var _6c2=this._filters[i];
if((!_6c2.get_isDom())&&(false!=_6c2.get_enabled())&&_6c2.getHtmlContent){
try{
_6c3=_6c2.getHtmlContent(_6c3);
}
catch(exc){
alert("Error while executing filter "+_6c2.get_name()+" - "+exc.toString());
}
}
}
return _6c3;
}};
Telerik.Web.UI.Editor.FiltersManager.registerClass("Telerik.Web.UI.Editor.FiltersManager",Sys.Component);
Type.registerNamespace("Telerik.Web.UI.Editor");
Telerik.Web.UI.Editor.RestorePoint=function(_6c4){
this.Window=_6c4;
this.Document=_6c4.document;
this.update();
this.Update=this.update;
this.Restore=this.restore;
this.Select=this.select;
};
if($telerik.isIE){
Telerik.Web.UI.Editor.RestorePoint.prototype={update:function(){
this.HtmlText=this.Document.body.innerHTML;
var _6c5=this.Document.selection.createRange();
if(_6c5.length){
this.SourceIndex=_6c5.item(0).sourceIndex;
}else{
this.StartBookmark=_6c5.getBookmark();
}
},restore:function(_6c6){
Telerik.Web.UI.Editor.Utils.setElementInnerHtml(this.Document.body,this.HtmlText);
this.select(_6c6);
},select:function(_6c7){
if(null!=this.SourceIndex){
var _6c8=this.Document.body.createControlRange();
_6c8.addElement(this.Document.all(this.SourceIndex));
_6c8.select();
}else{
if(null!=this.StartBookmark){
var _6c8=this.Document.body.createTextRange();
_6c8.moveToBookmark(this.StartBookmark);
_6c8.select();
if(true==_6c7&&_6c8.collapse){
_6c8.collapse();
}
}
}
}};
}else{
Telerik.Web.UI.Editor.RestorePoint.prototype={restore:function(){
try{
this.Window.document.body.innerHTML=this.HtmlText;
this.select();
}
catch(e){
}
},select:function(){
try{
this.Window.focus();
this._moveToBookmark(this.Window.getSelection(),this.Bookmark);
}
catch(ex){
}
},update:function(){
try{
this.HtmlText=this.Window.document.body.innerHTML;
this.Bookmark=this._bookmarkSelection(this.Window.getSelection());
}
catch(e){
}
},_bookmarkSelection:function(_6c9){
if(_6c9){
return {anchorNodeBookmark:new Telerik.Web.UI.Editor.SelectionBookmark(this.Window,_6c9.anchorNode),anchorOffset:_6c9.anchorOffset,focusNodeBookmark:new Telerik.Web.UI.Editor.SelectionBookmark(this.Window,_6c9.focusNode),focusOffset:_6c9.focusOffset,isCollapsed:_6c9.isCollapsed};
}else{
return {};
}
},_moveToBookmark:function(_6ca,_6cb){
var _6cc=_6cb.anchorNodeBookmark.select();
var _6cd=_6cb.focusNodeBookmark.select();
_6ca.collapse(_6cc,_6cb.anchorOffset);
if(!_6cb.isCollapsed){
_6ca.extend(_6cd,_6cb.focusOffset);
}
}};
}
Telerik.Web.UI.Editor.RestorePoint.registerClass("Telerik.Web.UI.Editor.RestorePoint",null);
Telerik.Web.UI.Editor.SelectionBookmark=function(_6ce,node){
this.Window=_6ce;
this.NodePath=this._findNodePath(this.Window.document.documentElement,node);
};
Telerik.Web.UI.Editor.SelectionBookmark.prototype={select:function(){
var node=this._findNode(this.Window.document.documentElement,this.NodePath);
try{
Telerik.Web.UI.Editor.Utils.selectElement(this.Window,node);
}
catch(ex){
}
return node;
},_findNodePath:function(_6d1,node){
var n,res;
for(var i=0;i<_6d1.childNodes.length;i++){
n=_6d1.childNodes[i];
res=this._findNodePath(n,node);
if(""!=res){
return ""+i+","+res;
}
if(n==node){
return ""+i;
}
}
return "";
},_findNode:function(_6d6,_6d7){
var arr=_6d7.split(",");
for(var i=0;i<arr.length;i++){
_6d6=_6d6.childNodes[arr[i]];
}
return _6d6;
}};
Telerik.Web.UI.Editor.SelectionBookmark.registerClass("Telerik.Web.UI.Editor.SelectionBookmark",null);
Type.registerNamespace("Telerik.Web.UI.Editor");
Telerik.Web.UI.Editor.Selection=function(_6da){
this._window=_6da;
this.isSafari=$telerik.isSafari;
this.isOpera=$telerik.isOpera;
this.GetRange=this.getRange;
this.GetParentElement=this.getParentElement;
this.IsControl=this.isControl;
this.GetText=this.getText;
this.GetHtmlText=this.getHtml;
this.PasteHtml=this.pasteHtml;
this.Collapse=this.collapse;
};
Telerik.Web.UI.Editor.Selection.prototype={pasteHtml:function(_6db,_6dc){
_6dc=(_6dc==true);
if($telerik.isIE){
return this._executeIE(_6db,_6dc);
}else{
return this._executeMozilla(_6db,_6dc);
}
},_executeIE:function(_6dd,_6de){
var _6df=this._window.document;
var _6e0=_6df.selection;
if(_6e0.type.toLowerCase()!="none"){
_6e0.createRange().execCommand("Delete");
}
if(_6e0.type.toLowerCase()!="none"){
_6df.execCommand("Delete");
}
_6df.body.setActive();
selRange=_6e0.createRange();
if(selRange&&selRange.length){
var _6e1=selRange.item(0);
if(_6e1&&_6e1.tagName=="BODY"){
var _6e2=_6e1.getElementsByTagName("FORM")[0];
if(_6e2){
Telerik.Web.UI.Editor.Utils.setElementInnerHtml(_6e2,_6e2.innerHTML+_6dd);
}
}
}else{
var _6e3=selRange.duplicate();
_6e3.collapse(true);
_6dd=Telerik.Web.UI.Editor.Utils.getStoredOriginalPathsAndAttributes(_6dd);
selRange.pasteHTML(_6dd);
Telerik.Web.UI.Editor.Utils.restoreOriginalPathsAndAttributes(selRange.parentElement());
if(_6de){
_6e3.setEndPoint("EndToEnd",selRange);
_6e3.select();
}
}
return true;
},_executeMozilla:function(_6e4,_6e5){
var oDoc=this._window.document;
var _6e7=oDoc.createElement("SPAN");
_6e7.innerHTML=_6e4;
var _6e8="radetempnode";
if(this.isOpera){
_6e7.setAttribute("id",_6e8);
}
this._insertNodeAtSelection(this._window,_6e7,true);
if(this.isOpera){
var _6e9=oDoc.createRange();
var _6ea=this._window.getSelection();
var span=oDoc.getElementById(_6e8);
_6e9.selectNodeContents(span);
var _6ec=_6e9.extractContents();
_6e9.selectNode(span);
var _6ed=_6e9.extractContents();
_6e9.insertNode(_6ec);
_6ea.addRange(_6e9);
return true;
}else{
if(!this.isSafari){
var _6e9=oDoc.createRange();
_6e9.selectNodeContents(_6e7);
var _6ec=_6e9.extractContents();
_6e9.selectNode(_6e7);
_6e9.deleteContents();
this._insertNodeAtSelection(this._window,_6ec,_6e5);
}
}
return true;
},_insertNodeAtSelection:function(win,_6ef,_6f0){
var _6f1=win.getSelection();
if(_6f1.rangeCount==0){
win.document.body.appendChild(_6ef);
return;
}
var _6f2=null;
if(_6f1.getRangeAt){
_6f2=_6f1.getRangeAt(0);
}else{
_6f2=win.document.createRange();
_6f2.setStart(_6f1.anchorNode,_6f1.anchorOffset);
_6f2.setEnd(_6f1.focusNode,_6f1.focusOffset);
}
if(_6f1.removeAllRanges){
_6f1.removeAllRanges();
}
_6f2.deleteContents();
var _6f3=$telerik.isSafari&&!$telerik.isSafari3?_6f1.baseNode:_6f2.startContainer;
var _6f4=$telerik.isSafari&&!$telerik.isSafari3?_6f1.baseOffset:_6f2.startOffset;
if($telerik.isSafari&&null==_6f3){
_6f3=win.document.body;
}
_6f2=win.document.createRange();
if((_6ef.nodeType==3)&&(_6f3.nodeType==3)){
_6f3.insertData(_6f4,_6ef.nodeValue);
_6f2.setEnd(_6f3,_6f4+_6ef.length);
if(_6f0){
_6f2.setStart(_6f3,_6f4);
}else{
_6f2.setStart(_6f3,_6f4+_6ef.length);
}
}else{
var _6f5;
if(_6f3.nodeType==3){
var _6f6=_6f3;
_6f3=_6f6.parentNode;
var _6f7=_6f6.nodeValue;
var _6f8=_6f7.substr(0,_6f4);
var _6f9=_6f7.substr(_6f4);
var _6fa=win.document.createTextNode(_6f8);
var _6f5=win.document.createTextNode(_6f9);
_6f3.insertBefore(_6f5,_6f6);
_6f3.insertBefore(_6ef,_6f5);
try{
_6f3.insertBefore(_6fa,_6ef);
}
catch(exc){
}
_6f3.removeChild(_6f6);
}else{
if(_6f3.childNodes.length>0){
_6f5=_6f3.childNodes[_6f4];
_6f3.insertBefore(_6ef,_6f5);
}else{
if(_6f3.tagName!="BODY"){
_6f3=_6f3.parentNode;
}
_6f3.appendChild(_6ef);
}
}
try{
if(_6f0){
_6f2.setStart(_6ef,0);
_6f2.setEnd(_6f5,0);
}else{
_6f2.setEnd(_6f5,0);
_6f2.setStart(_6f5,0);
}
}
catch(exc){
}
}
try{
_6f1.addRange(_6f2);
}
catch(exc){
}
},selectRange:function(_6fb){
if(!_6fb){
return;
}
var _6fc=this._window;
if(_6fb.select){
_6fb.select();
}else{
if(_6fc.getSelection){
var _6fd=_6fc.getSelection();
if(_6fd.removeAllRanges){
_6fd.removeAllRanges();
_6fd.addRange(_6fb);
}else{
var base=_6fb.baseNode;
if(null==base){
base=_6fc.document.body;
}
var _6ff=_6fb.extentNode;
if(null==_6ff){
_6ff=_6fc.document.body;
}
_6fd.setBaseAndExtent(base,_6fb.startOffset,_6ff,_6fb.endOffset);
}
}
}
},getRange:function(){
if(!this._window){
return null;
}
if(this._window.document.selection&&!window.opera){
return this._window.document.selection.createRange();
}else{
if(this._window.getSelection){
var _700=this._window.getSelection();
if(!_700||_700.rangeCount<1){
return null;
}
var rng=null;
if(_700.getRangeAt){
rng=_700.getRangeAt(0);
}else{
rng=this._window.document.createRange();
rng.setStart(_700.anchorNode,_700.anchorOffset);
rng.setEnd(_700.focusNode,_700.focusOffset);
}
return rng;
}
}
},getParentElement:function(){
var rng=this.getRange();
if(!rng){
return null;
}
if(rng.commonAncestorContainer){
var _703=this._window.getSelection();
var _704=rng.startContainer?rng.startContainer:_703.baseNode;
var _705=rng.endContainer?rng.endContainer:_703.extentNode;
var _706=rng.startOffset!=null?rng.startOffset:_703.baseOffset;
var _707=rng.endOffset!=null?rng.endOffset:_703.extentOffset;
if(_704==_705&&(_707-_706)==1){
return _703.anchorNode.childNodes[_703.anchorOffset];
}else{
if(!rng.commonAncestorContainer.tagName){
if(this._window.document==rng.commonAncestorContainer&&_703.baseNode){
return _703.baseNode.parentNode;
}
return rng.commonAncestorContainer.parentNode;
}else{
return rng.commonAncestorContainer;
}
}
}else{
if(rng.length){
return rng.item(0);
}else{
if(rng.parentElement){
return rng.parentElement();
}else{
return null;
}
}
}
},isControl:function(){
if(this._window.document.selection){
return (this._window.document.selection.type=="Control");
}else{
var oSel=this._window.getSelection();
if(oSel.toString()!=""){
return false;
}
var _709=oSel.focusNode;
if(!_709||_709.nodeType==1){
return false;
}
return (_709.tagName=="IMG");
}
},getText:function(){
if(this._window.document.selection){
var rng=this._window.document.selection.createRange();
if(rng.length){
return "";
}else{
if(null!=rng.text){
return rng.text;
}
}
}else{
if(this._window.getSelection){
return this._window.getSelection().toString();
}else{
return "";
}
}
},getHtml:function(){
if(this._window.document.selection&&!window.opera){
var rng=this._window.document.selection.createRange();
if(rng.length){
return rng.item(0).outerHTML;
}else{
if(rng.htmlText){
return rng.htmlText;
}else{
return "";
}
}
}else{
if(this._window.getSelection){
var _70c=this._window.getSelection();
var rng=null;
if(null==_70c){
return "";
}
if(_70c.getRangeAt&&typeof (_70c.rangeCount)!="undefined"&&_70c.rangeCount==0){
return "";
}
if(_70c.getRangeAt){
rng=_70c.getRangeAt(0);
var _70d=this._window.document.createElement("div");
var _70e=rng.cloneContents();
if(_70e){
_70d.appendChild(_70e);
return _70d.innerHTML;
}else{
return "";
}
}else{
return _70c;
}
}else{
return "";
}
}
},collapse:function(_70f){
_70f=(_70f==true);
if(this._window.document.selection){
var rng=this._window.document.selection.createRange();
if(rng.collapse){
rng.collapse(_70f);
rng.select();
}
}else{
if(this._window.getSelection){
var _711=this._window.getSelection();
if(!_711.isCollapsed){
if(_70f){
_711.collapseToStart();
}else{
_711.collapseToEnd();
}
}
}
}
}};
Telerik.Web.UI.Editor.Selection.registerClass("Telerik.Web.UI.Editor.Selection",null);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.EditorShortCutManager=function(){
this._shortcuts=[];
};
Telerik.Web.UI.EditorShortCutManager.prototype={addShortCut:function(_712,_713){
var rs=new Telerik.Web.UI.EditorShortCut(_712,_713);
rs.HashValue=this._getShortCutHashValue(rs);
this._shortcuts[rs.HashValue]=rs;
},removeShortCut:function(_715){
var _716=this._findByName(_715);
if(_716){
this._shortcuts[_716.HashValue]=null;
}
},setShortCut:function(_717,_718){
this.removeShortCut(_717);
this.addShortCut(_717,_718);
},isShortCutHit:function(e){
return this._hitTest(e.keyCode,e.ctrlKey,(null!=e.ctrlLeft?e.ctrlLeft:e.ctrlKey),e.shiftKey,(null!=e.shiftLeft?e.shiftLeft:e.shiftKey),e.altKey,(null!=e.altLeft?e.altLeft:e.altKey));
},_hitTest:function(_71a,_71b,_71c,_71d,_71e,_71f,_720){
var _721=this._getHashValue(_71a,_71b,_71c,_71d,_71e,_71f,_720);
return this._shortcuts[_721];
},_getHashValue:function(_722,_723,_724,_725,_726,_727,_728){
var _729=_722&65535;
var _72a=0;
_72a|=(_723?(1<<0):0);
_72a|=(_725?(1<<2):0);
_72a|=(_727?(1<<4):0);
_729|=(_72a<<16);
return _729;
},_getShortCutHashValue:function(_72b){
return this._getHashValue(_72b.KeyCode,_72b.CtrlKey,_72b.LeftCtrlKey,_72b.ShiftKey,_72b.LeftShiftKey,_72b.AltKey,_72b.LeftAltKey);
},_findByName:function(_72c){
var _72d;
for(var _72e in this._shortcuts){
_72d=this._shortcuts[_72e];
if(null!=_72d&&_72d._name==_72c){
return _72d;
}
}
return null;
}};
Telerik.Web.UI.EditorShortCut=function(_72f,_730){
this._name=_72f;
this.setShortCut(_730);
};
Telerik.Web.UI.EditorShortCut.prototype={CtrlKey:false,LeftCtrlKey:false,ShiftKey:false,LeftShiftKey:false,AltKey:false,LeftAltKey:false,KeyCode:0,get_name:function(){
return this._name;
},set_name:function(_731){
this._name=_731;
},setShortCut:function(_732){
this._parseShortcutString(_732);
},_parseShortcutString:function(_733){
if("string"==typeof (_733)){
this.CtrlKey=false;
this.LeftCtrlKey=false;
this.ShiftKey=false;
this.LeftShiftKey=false;
this.AltKey=false;
this.LeftAltKey=false;
this.KeyCode=0;
_733=_733.replace(/\s*/gi,"");
_733=_733.replace(/\+\+/gi,"+PLUS");
var _734=_733.split("+");
var _735="";
for(var i=0;i<_734.length;i++){
_735=_734[i].toUpperCase();
switch(_735){
case "LCTRL":
this.LeftCtrlKey=true;
case "CTRL":
this.CtrlKey=true;
break;
case "LSHIFT":
this.LeftShiftKey=true;
case "SHIFT":
this.ShiftKey=true;
break;
case "LALT":
this.LeftAltKey=true;
case "ALT":
this.AltKey=true;
break;
case "F1":
this.KeyCode=112;
break;
case "F2":
this.KeyCode=113;
break;
case "F3":
this.KeyCode=114;
break;
case "F4":
this.KeyCode=115;
break;
case "F5":
this.KeyCode=116;
break;
case "F6":
this.KeyCode=117;
break;
case "F7":
this.KeyCode=118;
break;
case "F8":
this.KeyCode=119;
break;
case "F9":
this.KeyCode=120;
break;
case "F10":
this.KeyCode=121;
break;
case "F11":
this.KeyCode=122;
break;
case "F12":
this.KeyCode=123;
break;
case "ENTER":
this.KeyCode=13;
break;
case "HOME":
this.KeyCode=36;
break;
case "END":
this.KeyCode=35;
break;
case "LEFT":
this.KeyCode=37;
break;
case "RIGHT":
this.KeyCode=39;
break;
case "UP":
this.KeyCode=38;
break;
case "DOWN":
this.KeyCode=40;
break;
case "PAGEUP":
this.KeyCode=33;
break;
case "PAGEDOWN":
this.KeyCode=34;
break;
case "SPACE":
this.KeyCode=32;
break;
case "TAB":
this.KeyCode=9;
break;
case "BACK":
this.KeyCode=8;
break;
case "CONTEXT":
this.KeyCode=93;
break;
case "ESCAPE":
case "ESC":
this.KeyCode=27;
break;
case "DELETE":
case "DEL":
this.KeyCode=46;
break;
case "INSERT":
case "INS":
this.KeyCode=45;
break;
case "PLUS":
this.KeyCode="+".charCodeAt(0);
break;
default:
this.KeyCode=_735.charCodeAt(0);
break;
}
}
}else{
throw {description:"Invalid shortcut string"};
}
}};
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI._localization=function(){
this._controls={};
};
Telerik.Web.UI._localization.prototype={merge:function(_737,_738,_739){
if(typeof (this._controls[_737])=="undefined"){
this._controls[_737]={};
}
if(typeof (this._controls[_737][_738])=="undefined"){
this._controls[_737][_738]={};
}
var _73a=this._controls[_737][_738];
for(var _73b in _739){
if(typeof (_739[_73b])=="string"){
_73a[_73b]=_739[_73b];
}
}
return _73a;
}};
Telerik.Web.UI._localization.registerClass("Telerik.Web.UI._localization");
Telerik.Web.UI.Localization=new Telerik.Web.UI._localization();
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.EditorCommandEventArgs=function(_73c,tool,_73e){
Telerik.Web.UI.EditorCommandEventArgs.initializeBase(this);
this._name=this._commandName=_73c;
this._tool=tool;
this._value=_73e;
this.value=_73e;
};
Telerik.Web.UI.EditorCommandEventArgs.prototype={get_name:function(){
return this._name;
},get_commandName:function(){
return this._commandName;
},get_tool:function(){
return this._tool;
},get_value:function(){
return this._value;
},set_value:function(val){
this.value=val;
this._value=val;
}};
Telerik.Web.UI.EditorCommandEventArgs.registerClass("Telerik.Web.UI.EditorCommandEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.RadEditor=function(_740){
Telerik.Web.UI.RadEditor.initializeBase(this,[_740]);
this._rootElement=null;
this._bottomResizer=null;
this._tableElement=null;
this._document=null;
this._contentArea=null;
this._contentAreaElement=null;
this._contentHiddenTextarea=null;
this._contentWindow=null;
this._doctypeString=null;
this._fullPage=null;
this._originalHeight=null;
this._accessKeyTextbox=null;
this._toolJSON=[];
this._contextMenusJSON=[];
this._modulesJSON=[];
this._toolAdapterType="";
this._uniqueID="";
this._skin="";
this._newLineBr=true;
this._autoResizeHeight=false;
this._contentAreaCssFile="";
this._mozillaFlashOverlayImage="FlashManager.gif";
this._stripFormattingOptions=Telerik.Web.UI.StripFormattingOptions.None;
this._editModes=Telerik.Web.UI.EditModes.All;
this._contentFilters=Telerik.Web.UI.EditorFilters.DefaultFilters;
this._mode=Telerik.Web.UI.EditModes.Design;
this._toolbarMode=Telerik.Web.UI.EditorToolbarMode.Default;
this._toolsWidth=null;
this._shortCutManager=new Telerik.Web.UI.EditorShortCutManager();
this._filtersManager=new Telerik.Web.UI.Editor.FiltersManager();
this._commandsManager=new Telerik.Web.UI.Editor.CommandsManager();
if(null!=Telerik.Web.UI.Editor.ModulesManager){
this._modulesManager=new Telerik.Web.UI.Editor.ModulesManager(this);
}
this._resizeExtender=null;
this._toolAdapter=null;
this._localization={};
this._contentAreaEventHandlers={};
this._onToolClickDelegate=Function.createDelegate(this,this._onToolClick);
this._onWindowResizeDelegate=null;
this._dialogOpener=null;
this._saveContentDelegate=null;
this._colors=null;
this._fontNames=null;
this._fontSizes=null;
this._realFontSizes=null;
this._symbols=null;
this._contextMenus=null;
this._snippets=null;
this._cssClasses=null;
this._cssFiles=null;
this._languages=null;
this._paragraphs=null;
this._links=null;
this.isIE=$telerik.isIE;
this.isFirefox=$telerik.isFirefox;
this.isOpera=$telerik.isOpera;
this.isIE7=$telerik.isIE7;
this._spellAllowAddCustom=true;
this._spellCheckJSON={};
this._spellCheckService=null;
this._ajaxSpellCheckScriptReference="";
};
Telerik.Web.UI.RadEditor.prototype={add_spellCheckLoaded:function(_741){
this.get_events().addHandler("spellCheckLoaded",_741);
},remove_spellCheckLoaded:function(_742){
this.get_events().removeHandler("spellCheckLoaded",_742);
},get_ajaxSpellCheck:function(){
return this._ajaxSpellCheck;
},set_ajaxSpellCheck:function(_743){
this._ajaxSpellCheck=_743;
this.raiseEvent("spellCheckLoaded");
},get_ajaxSpellCheckScriptReference:function(){
return this._ajaxSpellCheckScriptReference;
},set_ajaxSpellCheckScriptReference:function(val){
this._ajaxSpellCheckScriptReference=val;
},get_spellAllowAddCustom:function(){
return this._spellAllowAddCustom;
},set_spellAllowAddCustom:function(_745){
this._spellAllowAddCustom=_745;
},get_spellCheckJSON:function(){
return this._spellCheckJSON;
},set_spellCheckJSON:function(_746){
this._spellCheckJSON=_746;
},get_spellCheckService:function(){
if(!this._spellCheckService){
this._spellCheckService=$create(Telerik.Web.UI.SpellCheckService,this.get_spellCheckJSON(),null,null);
this._spellCheckService.add_complete(Function.createDelegate(this,this._responseReceived));
}
return this._spellCheckService;
},startSpellCheck:function(){
this.get_spellCheckService().spellCheck(this.get_html());
},addCustomWord:function(word){
this.get_spellCheckService().addCustomWord(word);
},_responseReceived:function(_748,args){
},raiseEvent:function(_74a,args){
if(_74a!="selectionChange"||this.get_mode()==Telerik.Web.UI.EditModes.Design){
Telerik.Web.UI.RadEditor.callBaseMethod(this,"raiseEvent",[_74a,args]);
}
},_initializeToolProvider:function(){
var _74c=this;
var _74d=_74c.get_toolProviderID();
if(_74d&&$find(_74d)){
var _74e=$find(_74d);
var _74f=_74e.get_dialogOpener();
_74c.set_dialogOpener(_74f);
var _750=_74e.get_contextMenusJSON();
if(_750&&_750.concat){
_74c.set_contextMenusJSON(_750.concat([]));
}
var _751=_74e.get_modulesJSON();
if(_751&&_751.concat){
_74c.set_modulesJSON(_751.concat([]));
}
var root=this.get_toolContainer();
root.innerHTML="";
this._toolJSON=[];
var html=_74e.get_toolHTML();
root.innerHTML=html;
var json=_74e.get_toolJSON().concat([]);
this.set_toolJSON(json);
if(_74e.get_spellCheckJSON){
_74c.set_spellCheckJSON(_74e.get_spellCheckJSON());
}
if(_74e.get_ajaxSpellCheckScriptReference){
var ref=_74e.get_ajaxSpellCheckScriptReference();
if(ref){
_74c.set_ajaxSpellCheckScriptReference(ref);
}
}
}
},get_toolHTML:function(){
var div=this.get_toolContainer().cloneNode(true);
return div.innerHTML;
},get_toolContainer:function(){
return this.get_TopZone().firstChild;
},get_mainTable:function(){
return $get(this.get_id()+"Wrapper");
},_ieHookToClientArea:function(){
var _757=this;
window.setTimeout(function(){
if($telerik.isIE){
var area=_757.get_contentArea();
if(!area){
return;
}
try{
var _759=Telerik.Web.UI.Editor.Utils.storeBrowserPosition();
var r=area.createTextRange();
var _75b=document.body.createTextRange();
if(_759&&_759.y>0){
_75b.moveToElementText(_757.get_contentAreaElement());
}else{
_75b.moveStart("textedit",_75b.text.length);
}
_75b.collapse(true);
_75b.select();
if(_759&&_759.y>0){
Telerik.Web.UI.Editor.Utils.restoreBrowserPosition();
}
}
catch(e){
}
}
},0);
},initialize:function(){
Telerik.Web.UI.RadEditor.callBaseMethod(this,"initialize");
this.raiseEvent("init",Sys.EventArgs.Empty);
this._initializeToolProvider();
var _75c=this.get_mainTable();
this._originalHeight=_75c.style.height;
this._initializeLocalization();
this._addFilters();
this._addDefaultShortCuts();
this._createUI();
this._createTools();
this._makeResizeable(true);
var _75d=$get(this.get_id()+"ContentHiddenTextarea");
if(_75d){
_75d.setAttribute("id",this.get_id());
this._contentHiddenTextarea=_75d;
}
this._setContentAreaHtml(this.get_contentHiddenTextareaValue(),true);
this._registerClientValidation();
this._registerPostBackHandlers();
if(!this._isEditModeEnabled(Telerik.Web.UI.EditModes.Design)){
if(this._isEditModeEnabled(Telerik.Web.UI.EditModes.Html)){
this.set_mode(Telerik.Web.UI.EditModes.Html);
}else{
this.set_mode(Telerik.Web.UI.EditModes.Preview);
}
}
this._ieHookToClientArea();
this._fixIEVisibilityProblems(true);
this._fixMozillaDOMProblems(true);
if(this._modulesManager){
if(!this.isIE){
var _75e=$get(this.get_id()+"Module");
_75e.style.display="none";
var _75f=this;
window.setTimeout(function(){
_75f._modulesManager.initialize();
_75e.style.display="";
},0);
}else{
this._modulesManager.initialize();
this._updateEditorSize(this._originalHeight);
}
}
if(this.get_autoResizeHeight()&&this.isVisible()){
this._makeAutoResizeHeight();
}
this._initialContent=this.get_html(true);
this._applyAccessKey();
this.raiseEvent("load",Sys.EventArgs.Empty);
if(!$telerik.isIE&&!$telerik.isFirefox){
if(!this.isVisible()){
this.raiseEvent("firstShow");
}
}
},dispose:function(){
if(typeof (Sys.WebForms)!="undefined"&&typeof (Sys.WebForms.PageRequestManager)!="undefined"&&this._saveContentDelegate){
var prm=Sys.WebForms.PageRequestManager.getInstance();
if(prm){
prm.remove_initializeRequest(this._saveContentDelegate);
}
prm=null;
}
if(this._contentHiddenTextarea&&this._contentHiddenTextarea.form&&this._saveContentDelegate){
$telerik.removeExternalHandler(this._contentHiddenTextarea.form,"submit",this._saveContentDelegate);
}
if(this._contentAreaElement){
$clearHandlers(this._contentAreaElement);
}
this._detachEvents();
this._fixMozillaDOMProblems(false);
this._fixIEVisibilityProblems(false);
this._makeResizeable(false);
this._onToolClickDelegate=null;
this._onWindowResizeDelegate=null;
this._dialogOpener=null;
this._saveContentDelegate=null;
this._registerModeChangeHandler(false);
if(this._accessKeyTextbox){
$clearHandlers(this._accessKeyTextbox);
this._accessKeyTextbox.removeAttribute("accessKey");
this._accessKeyTextbox=null;
}
Telerik.Web.UI.RadEditor.callBaseMethod(this,"dispose");
},_applyAccessKey:function(){
var _761=this.get_element().getAttribute("accessKey");
if(_761){
this.get_element().removeAttribute("accessKey");
var _762=document.createElement("input");
_762.setAttribute("name",this.get_id()+"EditorAccessKey");
_762.setAttribute("type","text");
_762.setAttribute("id",this.get_id()+"EditorAccessKey");
_762.setAttribute("accessKey",_761);
this._accessKeyTextbox=_762;
$addHandlers(this._accessKeyTextbox,{"focus":this.setFocus},this);
var _763=document.createElement("div");
_763.style.width="0px";
_763.style.height="0px";
_763.style.overflow="hidden";
_763.appendChild(this._accessKeyTextbox);
this.get_element().appendChild(_763);
}
},_makeAutoResizeHeight:function(){
if(this._initialContentHeight&&this._initialContentHeight>0){
return;
}
window.setTimeout(Function.createDelegate(this,function(){
this.get_contentArea().style.overflow="hidden";
this._initialContentHeight=this._contentAreaElement.offsetHeight;
var _764=this;
this.attachEventHandler("keydown",function(e){
if(!_764._isKeyUpButton(e)){
_764._resizeContentArea(e);
}
});
this.attachEventHandler("keyup",function(e){
if(_764._isKeyUpButton(e)||(e.keyCode==13&&!_764.isIE)){
_764._resizeContentArea(e);
}
});
this.add_selectionChange(Function.createDelegate(this,this._resizeContentArea));
this._resizeContentArea();
}),0);
},_isKeyUpButton:function(e){
var _768=e.keyCode;
if(_768==8||_768==46){
return true;
}
return false;
},_getCurrentFontSize:function(){
var o=this.getSelectedElement();
var _76a=parseInt($telerik.getCurrentStyle(o,"fontSize"));
return _76a;
},_resizeContentArea:function(e){
var body=this.isIE?this._document.body:this._document.documentElement;
var _76d=this._contentAreaElement;
var _76e=_76d.parentNode;
var _76f=this._initialContentHeight;
var _770=_76d.offsetHeight;
var _771=body.scrollHeight+(e&&e.keyCode==13&&this.isIE?this._getCurrentFontSize():0);
if(_771==_770){
return;
}
if((_76f==_770)&&(_771<=_76f)){
return;
}
var _772=(_771>_76f)?_771:_76f;
_76d.style.height=_772+"px";
if(_771>_770){
_76e.style.height=parseInt(_771)+"px";
}else{
var _773=this.get_element();
var _774=_773.offsetHeight-(_76e.offsetHeight-_76d.offsetHeight);
if(_76d.style.height!="100%"){
_76e.style.height="";
this._updateEditorSize(_774);
}
return;
}
this._updateEditorSize(null,true);
},_makeResizeable:function(_775){
if(this._resizeExtender){
this._resizeExtender.dispose();
this._resizeExtender=null;
}
if(!_775){
return;
}
if(!this._tableElement){
return;
}
if(!this._bottomResizer){
this._bottomResizer=$get(this.get_id()+"BottomResizer");
if(this.isIE&&this._bottomResizer){
this._bottomResizer.style.styleFloat="right";
}
}
var _776={se:this._bottomResizer};
this._resizeExtender=new Telerik.Web.UI.ResizeExtender(this,this._rootElement,_776,this._tableElement);
},_getInvisibleParent:function(){
return Telerik.Web.UI.Editor.Utils.getInvisibleParent(this.get_element());
},isVisible:function(){
return (this._getInvisibleParent()==null);
},_fixIEVisibilityProblems:function(_777){
if(!this.isIE){
return;
}
if(_777){
var _778=this._getInvisibleParent();
if(_778){
this._onIEParentVisibilityChangeDelegate=Function.createDelegate(this,this._onIEParentVisibilityChange);
this._invisibleParent=_778;
$addHandler(this._invisibleParent,"propertychange",this._onIEParentVisibilityChangeDelegate);
}
}else{
if(this._invisibleParent&&this._onIEParentVisibilityChangeDelegate){
$removeHandler(this._invisibleParent,"propertychange",this._onIEParentVisibilityChangeDelegate);
this._onIEParentVisibilityChangeDelegate=null;
this._invisibleParent=null;
}
}
},_fixMozillaDOMProblems:function(_779){
if(this.isIE){
return;
}
if(_779){
var _77a=this._getInvisibleParent();
if(_77a){
this._invisibleParent=_77a;
this._onMozillaParentVisibilityChangeDelegate=Function.createDelegate(this,this._onMozillaParentVisibilityChange);
_77a.addEventListener("DOMAttrModified",this._onMozillaParentVisibilityChangeDelegate,false);
}
this._onMozillaParentNodeChangedDelegate=Function.createDelegate(this,this._onMozillaParentNodeChanged);
document.addEventListener("DOMNodeInserted",this._onMozillaParentNodeChangedDelegate,false);
}else{
if(this._invisibleParent&&this._onMozillaParentVisibilityChangeDelegate){
this._invisibleParent.removeEventListener("DOMAttrModified",this._onMozillaParentVisibilityChangeDelegate,false);
this._onMozillaParentVisibilityChangeDelegate=null;
this._invisibleParent=null;
}
if(this._onMozillaParentNodeChangedDelegate){
document.removeEventListener("DOMNodeInserted",this._onMozillaParentNodeChangedDelegate,false);
this._onMozillaParentNodeChangedDelegate=null;
}
}
},_onIEParentVisibilityChange:function(e){
var e=e.rawEvent;
if(!e){
return;
}
if(e.propertyName=="style.display"||e.propertyName=="className"){
var _77c=$telerik.getCurrentStyle(this._invisibleParent,"display");
if(_77c!="none"){
this.raiseEvent("firstShow");
if(this.get_autoResizeHeight()){
this._makeAutoResizeHeight();
}
this._updateEditorSize();
this._fixIEVisibilityProblems(false);
}
}
},_onMozillaParentVisibilityChange:function(e){
if(e.attrName=="style"||e.attrName=="class"){
var _77e=e.target;
if((e.currentTarget==e.originalTarget)&&"none"!=$telerik.getCurrentStyle(_77e,"display")){
window.setTimeout(Function.createDelegate(this,function(){
if(!this._editorFirstVisible){
this._editorFirstVisible=true;
this.raiseEvent("firstShow");
}
if(this.get_autoResizeHeight()){
this._makeAutoResizeHeight();
}
this.set_editable(true);
}),0);
}
}
},_onMozillaParentNodeChanged:function(e){
if(!e.target||!this.get_element()){
return;
}
var _780=$telerik.isDescendantOrSelf(e.target,this.get_element());
if(_780){
this.onParentNodeChanged();
}
},onParentNodeChanged:function(){
if(!$telerik.isIE){
var _781=this.get_html(true);
var _782=this.get_contentAreaElement();
this._contentWindow=_782.contentWindow;
this._setContentAreaHtml(_781,true);
this.set_editable(true);
}
},onResizeStart:function(){
this._resizeSelection=this.getSelection().getRange();
},onResizeEnd:function(){
if(!this.isIE){
return;
}
this.setActive();
if(this._resizeSelection){
var _783=this._resizeSelection.parentElement();
if(_783&&(this.get_document()==_783.ownerDocument)){
this.getSelection().selectRange(this._resizeSelection);
}
this._resizeSelection=null;
}
},_initializeLocalization:function(){
this._localization=Telerik.Web.UI.Localization.merge("RadEditor",this.get_language(),this._localization);
},getSelectedElement:function(){
return this.getSelection().getParentElement();
},getSelection:function(){
return new Telerik.Web.UI.Editor.Selection(this.get_contentWindow());
},getSelectionHtml:function(){
return this.getSelection().getHtml();
},selectElement:function(_784,_785){
if(Telerik.Web.UI.Editor.Utils.selectElement(this.get_contentWindow(),_784)&&false!=_785){
this.raiseEvent("selectionChange",Sys.EventArgs.Empty);
}
},undo:function(_786){
this._commandsManager.undo(_786);
},redo:function(_787){
this._commandsManager.redo(_787);
},executeCommand:function(_788,_789,_78a){
if(!_788.get_window()){
_788.set_window(this.get_contentWindow());
}
if(false!=_789&&!this.isOpera){
this.setFocus();
}
this._commandsManager.execute(_788,_78a);
},executeBrowserCommand:function(_78b,_78c,_78d,_78e){
var _78f=this._localization[_78b];
this.executeCommand(new Telerik.Web.UI.Editor.BrowserCommand(_78f,this._contentWindow,_78b,_78d));
this.setActive();
this.setFocus();
if(true==_78e){
this.raiseEvent("selectionChange",Sys.EventArgs.Empty);
}
},createElement:function(_790,_791,_792,sId,_794,_795){
var _796=this._document.createElement(_790);
if(_791){
_796.style.width=_791;
}
if(_792){
_796.style.height=_792;
}
if(null!=sId){
_796.id=sId;
}
if(null!=_794){
_796.name=_794;
}
if(null!=_795){
_796.value=_795;
}
return _796;
},createRestorePoint:function(){
return new Telerik.Web.UI.Editor.RestorePoint(this._contentWindow);
},getToolState:function(_797){
if(_797=="Undo"){
return this.get_commandsManager().isUndoAvailable()?Telerik.Web.UI.Editor.CommandStates.Off:Telerik.Web.UI.Editor.CommandStates.Disabled;
}else{
if(_797=="Redo"){
return this.get_commandsManager().isRedoAvailable()?Telerik.Web.UI.Editor.CommandStates.Off:Telerik.Web.UI.Editor.CommandStates.Disabled;
}else{
var oCmd=Telerik.Web.UI.Editor.UpdateCommandsArray[_797];
if(oCmd&&oCmd.getState){
return oCmd.getState(this._contentWindow);
}
}
}
},getToolValue:function(_799){
var oCmd=Telerik.Web.UI.Editor.UpdateCommandsArray[_799];
if(oCmd&&oCmd.getValue){
return oCmd.getValue(this._contentWindow);
}else{
if(_799=="RealFontSize"){
var o=this.getSelectedElement();
if(o){
var _79c=null;
try{
_79c=$telerik.getCurrentStyle(o,"fontSize","");
}
catch(exc){
}
if(_79c){
var _79d=parseFloat(_79c);
if(_79d>parseInt(_79c)){
if(_79c.indexOf("px")>-1){
_79c=parseInt(_79c)+"px";
}
}
}
return _79c;
}
}
}
},_addFilters:function(){
var _79e=this.get_filtersManager();
var _79f=this.get_contentFilters();
_79e.clear();
var _7a0=_79f&Telerik.Web.UI.EditorFilters.ConvertToXhtml;
_79e.set_enableXhtmlFilter(_7a0);
if(_79f&Telerik.Web.UI.EditorFilters.RemoveScripts){
_79e.add(new Telerik.Web.UI.Editor.StripScriptsFilter());
}
_79e.add(new Telerik.Web.UI.Editor.EncodeScriptsFilter());
if(_79f&Telerik.Web.UI.EditorFilters.FixUlBoldItalic){
_79e.add(new Telerik.Web.UI.Editor.FixUlBoldItalic());
}
_79e.add(new Telerik.Web.UI.Editor.FixNestedLists());
if(_79f&Telerik.Web.UI.EditorFilters.ConvertFontToSpan){
_79e.add(new Telerik.Web.UI.Editor.ConvertFontToSpanFilter());
}
if(_79f&Telerik.Web.UI.EditorFilters.FixEnclosingP){
_79e.add(new Telerik.Web.UI.Editor.FixEnclosingP());
}
if($telerik.isIE){
_79e.add(new Telerik.Web.UI.Editor.IEKeepObjectParamsFilter());
_79e.add(new Telerik.Web.UI.Editor.IEKeepCommentsFilter());
_79e.add(new Telerik.Web.UI.Editor.IEFixEmptyParagraphs());
if(_79f&Telerik.Web.UI.EditorFilters.IECleanAnchors){
_79e.add(new Telerik.Web.UI.Editor.IECleanAnchorsFilter());
}
}
if(!$telerik.isIE&&!$telerik.isOpera){
if(!$telerik.isSafari){
_79e.add(new Telerik.Web.UI.Editor.MozillaKeepFlashString(this.get_mozillaFlashOverlayImage()));
_79e.add(new Telerik.Web.UI.Editor.MozillaKeepFlash());
}
_79e.add(new Telerik.Web.UI.Editor.MozillaKeepStylesString());
_79e.add(new Telerik.Web.UI.Editor.MozillaKeepStylesDom());
if(_79f&Telerik.Web.UI.EditorFilters.MozEmStrong){
_79e.add(new Telerik.Web.UI.Editor.MozEmStrongFilter());
}
}
_79e.add(new Telerik.Web.UI.Editor.StripJunkFilter());
if(_79f&Telerik.Web.UI.EditorFilters.MakeUrlsAbsolute){
_79e.add(new Telerik.Web.UI.Editor.MakeUrlsAbsolute());
}
_79e.add(new Telerik.Web.UI.Editor.RemoveExtraBrakes());
if(_79f&Telerik.Web.UI.EditorFilters.IndentHTMLContent){
_79e.add(new Telerik.Web.UI.Editor.IndentHTMLContentFilter());
}
},addShortCut:function(_7a1,_7a2){
if(this._shortCutManager){
this._shortCutManager.addShortCut(_7a1,_7a2);
}
},removeShortCut:function(_7a3){
if(this._shortCutManager){
this._shortCutManager.removeShortCut(_7a3);
}
},setShortCut:function(_7a4,_7a5){
if(this._shortCutManager){
this._shortCutManager.setShortCut(_7a4,_7a5);
}
},_addDefaultShortCuts:function(){
var _7a6=[["Undo","CTRL+Z"],["Redo","CTRL+Y"],["SelectAll","CTRL+A"],["Copy","CTRL+C"],["Paste","CTRL+V"],["Cut","CTRL+X"],["Bold","CTRL+B"],["Italic","CTRL+I"],["Underline","CTRL+U"],["Copy","CTRL+INS"],["Paste","SHIFT+INS"],["ToggleScreenMode","F11"],["LinkManager","CTRL+K"],["ImageManager","CTRL+G"],["SetToolFocus","F10"]];
for(var i=0;i<_7a6.length;i++){
this.addShortCut(_7a6[i][0],_7a6[i][1]);
}
if(this.isIE){
this.addShortCut("InsertTab","TAB");
}
if(this._newLineBr&&this.isIE){
this.addShortCut("Enter","ENTER");
this.addShortCut("ShiftEnter","SHIFT+ENTER");
this.addShortCut("InsertParagraph","CTRL+ENTER");
}else{
if(this.isFirefox&&!this._newLineBr){
this.addShortCut("EnterParagraphMozilla","ENTER");
}
}
},bubbleKeyEventToBrowser:function(){
this._shortcutHit=false;
},attachEventHandler:function(_7a8,_7a9){
if(_7a8.startsWith("on")){
_7a8=_7a8.replace("on","");
}
$telerik.addExternalHandler(this._document,_7a8,_7a9);
var _7aa=this._contentAreaEventHandlers;
if(!_7aa[_7a8]){
_7aa[_7a8]=[];
}
var _7ab=_7aa[_7a8];
_7ab[_7ab.length]=_7a9;
},detachEventHandler:function(_7ac,_7ad){
if(_7ac.startsWith("on")){
_7ac=_7ac.replace("on","");
}
$telerik.removeExternalHandler(this._document,_7ac,_7ad);
},_detachEvents:function(){
var _7ae=this._contentAreaEventHandlers;
for(var _7af in _7ae){
var _7b0=_7ae[_7af];
if(_7b0.length!=null){
for(var i=0;i<_7b0.length;i++){
var _7b2=_7b0[i];
if(typeof (_7b2)=="function"){
try{
this.detachEventHandler(_7af,_7b2);
}
catch(e){
}
}
}
_7b0=[];
}
}
this._contentAreaEventHandlers={};
this._attachIEBodyHandlers(false);
},get_TopZone:function(){
return $get(this.get_id()+"Top");
},_createTools:function(){
if(!this._toolAdapter){
var _7b3=this.get_toolContainer();
var _7b4=eval(this._toolAdapterType);
this._toolAdapter=$create(_7b4,{"editor":this,"toolJSON":this.get_toolJSON()},{"toolClick":this._onToolClickDelegate},null,_7b3);
if(this.isIE){
if(this.get_toolbarMode()==Telerik.Web.UI.EditorToolbarMode.Default){
_7b3.style.overflow="";
}
this._updateEditorSize();
}
}
},_onToolClick:function(tool,args){
this.fire(tool.get_name(),args);
},getContextMenuByTagName:function(_7b7){
if(this._toolAdapter&&this._toolAdapter.getContextMenuByTagName){
return this._toolAdapter.getContextMenuByTagName(_7b7);
}
},getToolByName:function(_7b8){
if(this._toolAdapter){
return this._toolAdapter.getToolByName(_7b8);
}
return null;
},getLocalizedString:function(name,_7ba){
var str=this.get_localization()[name];
if(null==str){
str=this.get_localization()[name.toLowerCase()];
}
if(null==str){
str=_7ba;
}
return str;
},setFocus:function(){
try{
if(this.get_mode()!=Telerik.Web.UI.EditModes.Html){
this._contentWindow.focus();
}else{
var area=this._getTextArea();
area.focus();
}
}
catch(e){
}
},setActive:function(){
var _7bd=this.get_contentArea();
if(_7bd&&_7bd.setActive){
_7bd.setActive();
}
},set_visible:function(_7be){
var _7bf=this.get_element();
if(_7bf){
_7bf.style.display=_7be?"":"none";
}
this.set_editable(_7be);
},enableEditing:function(_7c0,_7c1,_7c2){
var _7c3=this.get_toolAdapter();
var _7c4=Telerik.Web.UI.EditingOptions;
var _7c5=function(){
};
if(!_7c1){
_7c1=Telerik.Web.UI.EditingOptions.All;
}
this._editingOptions=_7c1;
this._optionalIgnoredTools=_7c2;
if(_7c1&_7c4.ContextMenus){
if(_7c3){
_7c3.enableContextMenus(_7c0);
}
}
if(_7c1&_7c4.EditModes){
if(!_7c0){
this._originalEditModeRef=this.set_mode;
this.set_mode=_7c5;
}else{
if(this._originalEditModeRef){
this.set_mode=this._originalEditModeRef;
this._originalEditModeRef=null;
}
}
}
if(_7c1&_7c4.Tools){
if(_7c3){
if(!_7c0){
_7c3.setToolState(null,Telerik.Web.UI.Editor.CommandStates.Disabled);
if(_7c2){
var _7c6=[];
for(var item in _7c2){
var tool=_7c3.getToolByName(item);
if(tool){
_7c6[_7c6.length]=tool;
}
}
_7c3.setToolState(_7c6);
}
this._originalSetToolStateRef=_7c3.setToolState;
_7c3.setToolState=_7c5;
}else{
_7c3.setToolState=this._originalSetToolStateRef;
this._originalSetToolStateRef=null;
}
}
}
if(_7c1&_7c4.Modules){
var _7c9=this._modulesManager;
if(_7c9){
_7c9.setModulesVisible(_7c0);
}
}
if(_7c1&_7c4.Typing){
if(!_7c0){
this._disableTypingDelegate=$telerik.cancelRawEvent;
this.attachEventHandler("keypress",this._disableTypingDelegate);
}else{
if(this._disableTypingDelegate){
this.detachEventHandler("keypress",this._disableTypingDelegate);
this._disableTypingDelegate=null;
}
}
}
if(_7c1&_7c1.Tab){
if(!_7c0){
this.removeShortCut("InsertTab");
}else{
this.setShortCut("InsertTab","TAB");
}
}
if(_7c0){
if(_7c3){
_7c3.setToolState(null,Telerik.Web.UI.Editor.CommandStates.Off);
}
this.raiseEvent("selectionChange",Sys.EventArgs.Empty);
}
},set_editable:function(_7ca){
if($telerik.isIE||$telerik.isOpera){
var oEd=this;
window.setTimeout(function(){
try{
oEd._document.body.setAttribute("contentEditable",""+_7ca);
oEd._document.execCommand("2D-Position",false,true);
}
catch(ev){
}
},0);
}else{
var oEd=this;
window.setTimeout(function(){
try{
oEd._document["designMode"]=_7ca?"on":"off";
if(_7ca){
oEd._document.execCommand("UseCSS",false,true);
}
}
catch(e){
}
},0);
}
},get_editable:function(){
if($telerik.isIE||$telerik.isOpera){
return this._document.body.contentEditable;
}else{
return (this._document["designMode"]=="on");
}
},enableContentArea:function(_7cc){
if(this.isIE){
this.get_document().body.setAttribute("contentEditable",""+_7cc);
}
},showExternalDialog:function(url,_7ce,_7cf,_7d0,_7d1,_7d2,_7d3,_7d4,_7d5,_7d6,_7d7){
var _7d8=this.getSelection().getRange();
var _7d9=this;
var _7da=function(_7db,args){
window.setTimeout(function(){
_7d9.getSelection().selectRange(_7d8);
if(_7d1){
var _7dd=_7d1(_7db,args);
if(false==_7dd){
return;
}
_7d9.raiseEvent("selectionChange",Sys.EventArgs.Empty);
}
_7d9.setFocus();
},50);
};
this.get_dialogOpener().openUrl(url,_7ce,_7cf,_7d0,_7da,_7d2,_7d3,_7d4,_7d5,_7d6,_7d7);
},showDialog:function(_7de,_7df,_7e0){
this._currentRange=this.getSelection().getRange();
var _7e1=this;
var _7e2=function(_7e3,args){
window.setTimeout(function(){
_7e1.getSelection().selectRange(_7e1._currentRange);
if(_7e0){
var oRes=_7e0(_7e3,args);
if(false==oRes){
return;
}
_7e1.raiseEvent("selectionChange",Sys.EventArgs.Empty);
}
_7e1.setFocus();
},50);
};
this.get_dialogOpener().open(_7de,_7df,_7e2);
if(this.isIE){
var wnd=this.get_dialogOpener()._getDialogContainer(_7de);
if(!wnd||wnd._DRAG_ATTACHED){
return;
}
wnd._DRAG_ATTACHED=true;
wnd.add_dragEnd(function(){
_7e1.getSelection().selectRange(_7e1._currentRange);
});
}
},_getModeButtonsWrapper:function(){
return this._getChildElement("ModesWrapper");
},_registerModeChangeHandler:function(_7e7){
if(_7e7){
this._onModeButtonClickDelegate=Function.createDelegate(this,this._onModeButtonClick);
$addHandler(this._getModeButtonsWrapper(),"click",this._onModeButtonClickDelegate);
}else{
if(this._onModeButtonClickDelegate){
$removeHandler(this._getModeButtonsWrapper(),"click",this._onModeButtonClickDelegate);
this._onModeButtonClickDelegate=null;
}
}
},_onModeButtonClick:function(e){
var _7e9=this.get_mode();
var _7ea=Telerik.Web.UI.Editor.Utils.getElementParentByTag(e.target,"LI");
if(_7ea){
var _7eb=Telerik.Web.UI.EditModes;
var _7ec=Sys.UI.DomElement;
var a=_7ea.getElementsByTagName("A")[0];
if(_7ec.containsCssClass(a,"rade_mode_html")){
_7e9=_7eb.Html;
}else{
if(_7ec.containsCssClass(a,"rade_mode_design")){
_7e9=_7eb.Design;
}else{
_7e9=_7eb.Preview;
}
}
}
if(_7e9!=this.get_mode()){
this.set_mode(_7e9);
}
return $telerik.cancelRawEvent(e);
},_changeModeUI:function(mode){
var _7ef=Sys.UI.DomElement;
var _7f0=Telerik.Web.UI.EditModes;
var _7f1="rade_mode_";
switch(mode){
case _7f0.Html:
_7f1+="html";
break;
case _7f0.Design:
_7f1+="design";
break;
case _7f0.Preview:
_7f1+="preview";
break;
}
var _7f2=this._getModeButtonsWrapper();
var as=_7f2.getElementsByTagName("A");
for(var i=0;i<as.length;i++){
var a=as[i];
_7ef.removeCssClass(a,"rade_mode_selected");
if(_7ef.containsCssClass(a,_7f1)){
_7ef.addCssClass(a,"rade_mode_selected");
}
}
},_isEditModeEnabled:function(_7f6){
return _7f6&this._editModes?true:false;
},get_mode:function(){
return this._mode;
},set_mode:function(_7f7){
this._setEditableDelegate=Function.createDelegate(this,function(){
this.remove_editReady(this._setEditableDelegate);
var _7f8=(this._mode==_7f9.Design);
this.set_editable(_7f8);
this.toggleEnhancedEdit(_7f8);
this._setEditableDelegate=null;
});
this.add_editReady(this._setEditableDelegate);
var _7fa=this._mode;
var _7f9=Telerik.Web.UI.EditModes;
if(_7fa==_7f9.Html||_7f7==_7f9.Html){
var html=this.get_html(true);
this._mode=_7f7;
this._showTextArea(this._mode==_7f9.Html);
this.set_html(html);
}else{
this._mode=_7f7;
this._showTextArea(this._mode==_7f9.Html);
}
this._changeModeUI(_7f7);
if(this._mode!=_7f9.Preview){
this.setFocus();
if(this.isFirefox&&(!this._document||!this._document.body)){
}else{
this.set_editable(true);
}
if(this._mode==_7f9.Design){
this.toggleEnhancedEdit(true);
}
}else{
this.set_editable(false);
this.toggleEnhancedEdit(false);
}
this.setFocus();
var _7fc=this.get_id();
var _7fd=this.get_mainTable();
var _7fe=_7fd.offsetHeight+"px";
this.raiseEvent("modeChange",Sys.EventArgs.Empty);
this._updateEditorSize(_7fe);
},_getTextIframe:function(){
if(!this._textIframe){
var _7ff=this.get_contentAreaElement();
if(_7ff){
this._textIframe=_7ff.cloneNode(true);
this._textIframe.style.position="absolute";
var _800=this._textIframe.style;
_800.height="2px";
_800.width="2px";
_7ff.parentNode.appendChild(this._textIframe);
var doc=this._textIframe.contentWindow.document;
doc.designMode="off";
var _802=doc.open("text/html","replace");
var _803="<html style='height:100%;'><head><title>New Document</title></head>"+"<body style='overflow:hidden;margin:0px;padding:0px;height:100%'>"+"<textarea style='font:normal 11px Tahoma;color: #000080;border:0px;height:100%;width:100%'>"+"</textarea></body></html>";
if(typeof (_802)=="undefined"){
_802=doc;
}
_802.write(_803);
_802.close();
}
}
return this._textIframe;
},_getTextArea:function(){
var area=this._getTextIframe();
if(area&&typeof (area.contentWindow)!="unknown"){
return area.contentWindow.document.body.firstChild;
}else{
return null;
}
},get_textArea:function(){
return this._getTextArea();
},_showTextArea:function(_805){
var area=this._getTextIframe();
var _807=this.get_contentAreaElement();
if(_805){
if($telerik.isSafari){
_807.style.width="0px";
_807.style.height="0px";
}else{
_807.style.display="none";
}
area.style.height="";
area.style.display="";
area.style.position="";
if(!$telerik.isFirefox){
window.setTimeout(function(){
area.style.height=area.parentNode.offsetHeight+"px";
},0);
}
area.style.height="100%";
area.style.width="100%";
}else{
if($telerik.isSafari){
_807.style.width="100%";
_807.style.height="100%";
}else{
_807.style.display="";
}
area.style.display="none";
}
},_setContentAsText:function(_808){
var area=this._getTextArea();
if(area){
area.value=_808;
}
},_getContentAsText:function(){
var area=this._getTextArea();
if(area&&area.value){
var _80b=area.value;
return _80b;
}
return "";
},set_html:function(_80c,_80d,_80e){
var _80f=Telerik.Web.UI.EditModes;
if(this.get_mode()!=_80f.Html){
var cmd=new Telerik.Web.UI.Editor.GenericCommand(_80d?_80d:"Set HTML",this.get_contentWindow());
this._setContentAreaHtml(_80c);
this.executeCommand(cmd,_80e);
this.raiseEvent("selectionChange",Sys.EventArgs.Empty);
}else{
this._setContentAsText(_80c);
}
},get_html:function(_811){
var _812=null;
var _813="";
var mode=this.get_mode();
var _815=Telerik.Web.UI.EditModes;
if(mode==_815.Html){
return this._getContentAsText();
}else{
if(this.get_fullPage()){
if(this._document){
_812=this._document.getElementsByTagName("HTML")[0];
_812=Telerik.Web.UI.Editor.Utils.cloneNodeWithChildren(_812);
var _816=this._getAllSheets(_812);
for(var i=0;i<_816.length;i++){
var _818=_816[i];
var _819=_818.getAttribute("id");
if(_819&&_819.indexOf("RADEDITORSTYLESHEET")==0){
_818.parentNode.removeChild(_818);
}
}
if($telerik.isIE||$telerik.isOpera){
_812.getElementsByTagName("BODY")[0].removeAttribute("contentEditable");
}
}
}else{
if(this.get_contentArea()){
if(true==_811){
_812=Telerik.Web.UI.Editor.Utils.cloneNodeWithChildren(this.get_contentArea());
if($telerik.isIE||$telerik.isOpera){
_812.removeAttribute("contentEditable");
}
}else{
_812=this.get_contentArea();
}
}
}
}
if(_812){
if(true==_811){
_813=this.get_filtersManager().getHtmlContent(_812);
}else{
_813=_812.innerHTML;
}
}
if(_813.indexOf("<body")==0){
_813=_813.trim();
_813=_813.substring(_813.indexOf(">")+1,_813.length-7);
_813=_813.trim();
}
if(this.get_fullPage()&&this._doctypeString){
_813=this._doctypeString+"\n"+_813;
}
return _813;
},set_initialContent:function(){
this._initialContent=this.get_html(true);
},get_initialContent:function(){
return this._initialContent;
},get_text:function(){
var _81a=Telerik.Web.UI.EditModes;
if(this.get_mode()!=_81a.Html){
var _81b="";
var _81c=this.get_contentArea();
if(_81c){
if(_81c.innerText){
_81b=_81c.innerText;
}else{
if(_81c.textContent!=null){
_81b=_81c.textContent;
}else{
_81b=_81c.innerHTML.replace(/<\/?[^>]*>/ig,"");
}
}
}
return _81b;
}else{
return this._getTextArea().value.replace(/<\/?[^>]*>/ig,"");
}
},_getUniqueStyleSheetId:function(i){
return "RADEDITORSTYLESHEET"+i;
},_getAllSheets:function(oDoc){
if(!oDoc){
alert("RadEditor._getAllSheets called with no document object provided");
}
var _81f=oDoc.getElementsByTagName("link");
var _820=oDoc.getElementsByTagName("style");
var _821=[];
for(var x=0;_81f[x];x++){
var rel=_81f[x].rel?_81f[x].rel:_81f[x].getAttribute("rel");
if(typeof (rel)=="string"&&rel.toLowerCase().indexOf("style")+1){
Array.add(_821,_81f[x]);
}
}
for(var x=0;_820[x];x++){
Array.add(_821,_820[x]);
}
return _821;
},_getClassName:function(rule){
var str=rule&&rule.selectorText?rule.selectorText:"";
var _826=str.lastIndexOf(".");
if(_826==-1){
return "";
}
var _827=str.indexOf(" ",_826);
if(-1==_827){
_827=str.indexOf(":",_826);
}
if(-1==_827){
_827=str.length;
}
return str.substring((_826+1),_827);
},_createCssFilterObject:function(){
if(this._cssClassesHash){
return;
}
var _828=this.get_cssClasses();
if(_828&&_828.length>0){
var obj={};
var _82a=_828.length;
for(var i=0;i<_82a;i++){
var oKey=_828[i][0];
var oVal=_828[i][1];
obj[oKey.replace(/(.*?)\./ig,function($1){
return $1.toUpperCase();
})]=oVal;
}
this._cssClassesHash=obj;
}
},_getFilteredCssClasses:function(_82f){
this._createCssFilterObject();
if(_82f&&this._cssClassesHash){
var _830=[];
var _831=_82f.length;
for(var _832=0;_832<_831;_832++){
var _833=_82f[_832];
if(outAlias=this._checkCssFilter(_833[1].selectorText)){
_833[2]=outAlias;
_830[_830.length]=_833;
}
}
return _830;
}else{
return _82f;
}
},_checkCssFilter:function(_834){
if(!_834||!this._cssClassesHash){
return null;
}
return this._cssClassesHash[_834.replace(/(.*?)\./ig,function($1){
return $1.toUpperCase();
})];
},getCssArray:function(_836){
var _837=this.get_document();
var _838=[];
for(var i=0;i<_837.styleSheets.length;i++){
var _83a=_837.styleSheets[i];
this._getStyleSheetRules(_838,_83a,_836);
}
_838=this._getFilteredCssClasses(_838);
return _838;
},_getStyleSheetRules:function(_83b,_83c,_83d){
var _83e=_83c.href;
if(_83e&&_83e.indexOf("WebResource.axd?")>-1){
return;
}
var _83f=(_83c.rules)?_83c.rules:_83c.cssRules;
if($telerik.isIE&&_83c.imports){
for(var k=0;k<_83c.imports.length;k++){
this._getStyleSheetRules(_83b,_83c.imports[k],_83d);
}
}
for(var j=0;j<_83f.length;j++){
var _842=_83f[j];
if(_842&&_842.cssText){
var text=_842.cssText.toLowerCase();
if(text.indexOf("@import")>=0&&_842.parentStyleSheet&&_842.styleSheet&&_842.parentStyleSheet!=_842.styleSheet){
this._getStyleSheetRules(_83b,_842.styleSheet,_83d);
continue;
}
}
var str=_842&&_842.selectorText?_842.selectorText:"";
var _845=str.lastIndexOf(".");
if(_845<0){
continue;
}
var _845=str.lastIndexOf(":");
if(_845>0){
continue;
}
var _846=this._getClassName(_842);
_83b[_83b.length]=[_846,_842];
}
},copyStyleSheets:function(_847,_848){
if(null==_847&&null==_848){
return;
}
var _849=0;
var _84a=null;
if(_848.styleSheets.length==0){
if(_848.createStyleSheet){
_848.createStyleSheet();
}else{
css=_848.createElement("style");
css.media="all";
css.type="text/css";
var _84b=_848.getElementsByTagName("head")[0];
_84b.appendChild(css);
_84a=css;
}
}
if(_848.styleSheets[0]){
_84a=_848.styleSheets[0];
}
for(var i=0;i<_847.styleSheets.length;i++){
try{
var _84d=_847.styleSheets[i];
var _84e=_84d.href;
var _84f=false;
if($telerik.isFirefox){
if(_84d.ownerNode&&_84d.ownerNode.tagName.toLowerCase()=="style"){
_84f=true;
}
}
if(_84e&&!_84f){
continue;
}
var _850=(_84d.rules)?_84d.rules:_84d.cssRules;
for(var j=0;j<_850.length;j++){
var _852=_850[j];
if(_84a.addRule){
var _853=_852.selectorText;
var oCss=_852.style.cssText;
if(oCss&&_853){
_84a.addRule(_853,oCss,_849);
}
}else{
if(_84a.insertRule){
_84a.insertRule(_852.cssText,_849);
}else{
var oCss=_852.selectorText+"{"+_852.style.cssText+"}";
var _855=_848.createTextNode(oCss);
_84a.appendChild(_855);
}
}
_849++;
}
}
catch(exc){
}
}
},_setContentAreaHtml:function(_856,_857){
var _858=this.get_filtersManager().getDesignContent(_856);
this.set_contentHiddenTextareaValue(_858);
var _859=null;
if(-1!=_858.toLowerCase().indexOf("<html")){
this.set_fullPage(true);
_859=_858;
var _85a=new RegExp("(<!DOCTYPE(.|\\n)*?>)(.|\\n)*?","g");
this._doctypeString=(_859.match(_85a))?_859.match(_85a)[0]:"";
}else{
this.set_fullPage(false);
}
if(null!=_859||true==_857){
var _85b=this;
var _85c=function(){
_85d=false;
try{
_85b._document=_85b._contentAreaElement.contentWindow.document;
_85b._contentWindow=_85b._contentAreaElement.contentWindow;
_85b._contentArea=_85b._document.body;
_85b.get_filtersManager().getDesignContentDom(_85b.get_contentArea());
var _85e=1;
Telerik.Web.UI.Editor.Utils.addStyleSheet(_85b.get_contentAreaCssFile(),_85b._document,_85b._getUniqueStyleSheetId(0));
var _85f=_85b.get_cssFiles();
if(_85f.length>0){
for(var i=0;i<_85f.length;i++){
var _861=_85b._getUniqueStyleSheetId(_85e++);
Telerik.Web.UI.Editor.Utils.addStyleSheet(_85f[i],_85b._document,_861);
}
}else{
if(!_85b._fullPage){
_85b.copyStyleSheets(document,_85b._document);
var _862=_85b._getAllSheets(document);
for(var i=0;i<_862.length;i++){
var _861=_85b._getUniqueStyleSheetId(_85e++);
var _863=_862[i];
if(_863.tagName=="LINK"){
var _864=_863.href;
if(_864&&_864.indexOf("WebResource.axd?")>-1){
continue;
}
if(_864){
Telerik.Web.UI.Editor.Utils.addStyleSheet(_863.getAttribute("href"),_85b._document,_861);
}
}else{
if(_863.tagName=="STYLE"){
}
}
}
}
}
var _865=Telerik.Web.UI.Editor.PopupController;
if(_865){
_865.detachFromDocument(_85b._document);
_865.attachToDocument(_85b._document);
}
_85b._initEvents();
if(_85b.isVisible()){
_85b.raiseEvent("firstShow");
}
if(_85b.get_mode()!=Telerik.Web.UI.EditModes.Preview){
_85b.set_editable(true);
}else{
_85b.set_editable(false);
}
_85b.toggleEnhancedEdit(true);
if(_85b._document&&_85b._document.body){
_85b.raiseEvent("editReady",Sys.EventArgs.Empty);
}
}
catch(e){
}
};
if($telerik.isFirefox){
$addHandler(this._contentAreaElement,"load",function(){
if(_85d){
_85c();
}
});
}
if(!_859){
_859="<head><style></style></head><body>"+_858+"</body>";
}
try{
var _866=this._contentAreaElement.contentWindow.document;
_866.open();
_866.write(_859);
_866.close();
var _85d=false;
if(_866.body){
_85c();
}else{
_85d=true;
}
}
catch(e){
}
}else{
Telerik.Web.UI.Editor.Utils.setElementInnerHtml(this._contentArea,_858);
this.get_filtersManager().getDesignContentDom(this.get_contentArea());
}
},_createUI:function(){
if(this._created){
return;
}
this._registerModeChangeHandler(true);
var id=this.get_id();
this._rootElement=$get(id);
this._tableElement=this.get_mainTable();
var _868=$get(id+"Center");
var _869=this.get_contentAreaElement();
_869.style.display="none";
var _86a=_868.offsetHeight;
_868.appendChild(_869);
_869.style.height="100%";
_869.style.display="";
if(!$telerik.isIE&&_86a<160&&_868.offsetHeight>_86a+2){
_868.style.height=_86a+"px";
}
this._created=true;
},_updateEditorSize:function(_86b,_86c){
var _86d=this._tableElement;
var _86e=_86b?_86b:_86d.style.height;
if(true==_86c){
_86e=_86d.offsetHeight+"px";
}
if(parseInt(_86e)==0){
return;
}
_86e=parseInt(_86e)+"px";
_86d.style.height=_86e;
if(this.isIE){
this._fixIeHeight(_86d,_86e);
}else{
}
_86d.parentNode.style.height=_86e;
},_fixIeHeight:function(_86f,_870){
if("CSS1Compat"==document.compatMode){
var _871=(_86f.offsetHeight-parseInt(_870));
if(_871>0){
var _872=(parseInt(_86f.style.height)-_871);
if(_872>0){
_86f.style.height=_872+"px";
}
}
}
},setSize:function(_873,_874){
var _873=parseInt(_873);
var _874=parseInt(_874);
var _875=this;
var _876=this.get_mainTable();
_876.style.height="";
var _877=_876.parentNode;
_877.style.width=_873+"px";
_877.style.height=_874+"px";
_875._fixIeHeight(_877,_874);
if(_875.isIE){
_876.style.height=_874+"px";
_875._fixIeHeight(_876,_874);
}else{
_876.style.height="100%";
}
},pasteHtml:function(_878,_879,_87a,_87b,_87c){
if(!this.get_editable()){
return;
}
var args=new Telerik.Web.UI.EditorCommandEventArgs(_879,null,_878);
if(false==this._executeCommandEvent("pasteHtml",_879,args)){
return;
}
if(_878!=args.get_value()){
_878=args.get_value();
}
var _87e=this.get_localization()[_879];
if(_87e){
_879=_87e;
}
var mode=this.get_mode();
if(Telerik.Web.UI.EditModes.Design==mode){
this.setFocus();
this.executeCommand(new Telerik.Web.UI.Editor.PasteHtmlCommand(_879,this._contentWindow,_878,_87a),null,_87c);
if(_87b!=false){
this.raiseEvent("selectionChange",Sys.EventArgs.Empty);
}
}else{
if(Telerik.Web.UI.EditModes.Html==mode){
var _880=this._getTextArea();
if(this.isIE){
_880.setActive();
var _881=document.selection.createRange();
_881.text=_878;
}else{
if(_880.setSelectionRange){
var _882=_880.selectionStart;
var _883=_880.selectionEnd;
var _884=_880.value.substring(_882,_883);
var _885=_878;
_880.value=_880.value.substring(0,_882)+_885+_880.value.substring(_883);
_880.setSelectionRange(_882+_885.length,_882+_885.length);
this.setFocus();
}
}
}
}
},fire:function(_886,args){
if(false==this._executeCommandEvent("commandExecuting",_886,args)){
return;
}
if(this._optionalIgnoredTools&&!this._optionalIgnoredTools[_886]){
return;
}
this.setActive();
this._pendingTextTypeCmd=null;
var _888=Telerik.Web.UI.Editor.CommandList[_886];
var _889=false;
if(_888){
_889=(false!=_888(_886,this,args));
}else{
alert("The command "+_886+" is not implemented yet.");
}
if(_889){
if(!$telerik.isOpera){
this.setFocus();
}
this.raiseEvent("selectionChange",Sys.EventArgs.Empty);
}
this._executeCommandEvent("commandExecuted",_886,args);
},_executeCommandEvent:function(_88a,_88b,args){
if(!args){
args=new Telerik.Web.UI.EditorCommandEventArgs(_88b);
}
this.raiseEvent(_88a,args);
if(args.get_cancel&&args.get_cancel()){
return false;
}
return true;
},_onWindowResize:function(){
var _88d=this._getViewportBounds();
this.setSize(_88d.width,_88d.height,false);
},_registerWindowResizeHandler:function(_88e){
if(_88e){
this._onWindowResizeDelegate=Function.createDelegate(this,this._onWindowResize);
$addHandler(window,"resize",this._onWindowResizeDelegate);
}else{
if(this._onWindowResizeDelegate){
$removeHandler(window,"resize",this._onWindowResizeDelegate);
this._onWindowResizeDelegate=null;
}
}
},_getViewportBounds:function(){
var _88f=$telerik.getClientBounds();
var _890=document.documentElement.scrollLeft||document.body.scrollLeft;
var _891=document.documentElement.scrollTop||document.body.scrollTop;
_88f.scrollLeft=_890;
_88f.scrollTop=_891;
return _88f;
},_handleParentsWithOverflow:function(_892){
if(false==_892){
if(!this._parentsWithOverflow){
return;
}
var _893=this._parentsWithOverflow;
var _894=_893.length;
for(var i=0;i<_894;i++){
var _896=_893[i];
if(_896[0]){
var _897=_896[0].style;
_897.overflow=_896[1];
_897.height=_896[2];
_897.tableLayout=_896[3];
_897.position=_896[4];
}
}
this._parentsWithOverflow=null;
}else{
this._parentsWithOverflow=[];
var _893=this._parentsWithOverflow;
var _898=this._getRootNode().parentNode;
while(_898&&_898.tagName!="BODY"){
var _897=_898.style;
_893[_893.length]=[_898,_897.overflow,_897.height,_897.tableLayout,_897.position];
_898.style.position="static";
_898.style.tableLayout="auto";
_898.style.overflow="visible";
_898.style.height="auto";
_898=_898.parentNode;
}
}
},_getRootNode:function(){
return this.get_mainTable().parentNode;
},isFullScreen:function(){
return this._isFullScreen;
},toggleScreenMode:function(){
var _899=this;
if(!_899._isFullScreen){
_899._preFullScreenBodyStyle=[document.body.scroll,document.body.style.margin,""];
document.body.scroll="no";
document.body.style.margin="0px";
if(document.documentElement){
_899._preFullScreenBodyStyle[2]=document.documentElement.style.overflow;
document.documentElement.style.overflow="hidden";
}
var _89a=_899._getRootNode();
_899._preFullScreenBounds=$telerik.getBounds(_89a);
_899._handleParentsWithOverflow(true);
_899._onWindowResize();
_899._preFullScreenBrowserRect=_899._getViewportBounds();
var _89b=$telerik.getLocation(_89a);
Telerik.Web.UI.Editor.Utils.restoreBrowserPosition(_89b.x,_89b.y);
_899._isFullScreen=true;
_899._registerWindowResizeHandler(true);
}else{
_899._registerWindowResizeHandler(false);
document.body.scroll=_899._preFullScreenBodyStyle[0];
try{
document.body.style.margin=_899._preFullScreenBodyStyle[1];
}
catch(e){
}
document.documentElement.style.overflow=_899._preFullScreenBodyStyle[2];
_899._isFullScreen=false;
_899._handleParentsWithOverflow(false);
var _89c=_899._preFullScreenBounds;
_899.setSize(_89c.width,_89c.height,false);
var _89b=_899._preFullScreenBrowserRect;
Telerik.Web.UI.Editor.Utils.restoreBrowserPosition(_89b.scrollLeft,_89b.scrollTop);
}
_899.set_editable(true);
_899.setFocus();
var _89d=_899.getToolByName("ToggleScreenMode");
if(_89d){
_89d.setOn(_899._isFullScreen);
}
this.raiseEvent("toggleScreenMode",Sys.EventArgs.Empty);
},get_contentHiddenTextareaValue:function(){
if(this._contentHiddenTextarea){
return Telerik.Web.UI.Editor.Utils.decodePostbackContent(this._contentHiddenTextarea.value);
}else{
return "";
}
},set_contentHiddenTextareaValue:function(_89e){
if($telerik.isSafari&&this._contentHiddenTextarea.innerText!=null){
this._contentHiddenTextarea.innerText=Telerik.Web.UI.Editor.Utils.encodePostbackContent(_89e);
}else{
this._contentHiddenTextarea.value=Telerik.Web.UI.Editor.Utils.encodePostbackContent(_89e);
}
},get_localization:function(){
return this._localization;
},get_contentAreaElement:function(){
if(!this._contentAreaElement){
var elem=document.createElement("iframe");
elem.frameBorder="0";
elem.src="javascript:'<html></html>';";
elem.style.width="100%";
elem.style.margin="0px";
elem.style.padding="0px";
elem.setAttribute("id",this.get_id()+"_contentIframe");
this._contentAreaElement=elem;
}
return this._contentAreaElement;
},get_contentArea:function(){
return this._contentArea;
},get_document:function(){
return this._document;
},get_contentWindow:function(){
return this._contentWindow;
},get_toolAdapter:function(){
return this._toolAdapter;
},set_toolAdapter:function(_8a0){
this._toolAdapter=_8a0;
},get_fullPage:function(){
return this._fullPage;
},set_fullPage:function(_8a1){
this._fullPage=_8a1;
},get_dialogOpener:function(){
return this._dialogOpener;
},set_dialogOpener:function(_8a2){
this._dialogOpener=_8a2;
},get_filtersManager:function(){
return this._filtersManager;
},get_commandsManager:function(){
return this._commandsManager;
},get_modulesManager:function(){
return this._modulesManager;
},get_links:function(){
if(null==this._links){
return [];
}
return this._links;
},set_links:function(_8a3){
this._links=_8a3;
},get_language:function(){
if(null==this._language){
return "en-us";
}
return this._language.toLowerCase();
},set_language:function(_8a4){
this._language=_8a4;
},get_colors:function(){
if(null==this._colors){
return ["","#ffcccc","#ffcc99","#ffff99","#ffffcc","#99ff99","#99ffff","#ccffff","#ccccff","#ffccff","#cccccc","#ff6666","#ff9966","#ffff66","#ffff33","#66ff99","#33ffff","#66ffff","#9999ff","#ff99ff","#c0c0c0","#ff0000","#ff9900","#ffcc66","#ffff00","#33ff33","#66cccc","#33ccff","#6666cc","#cc66cc","#999999","#cc0000","#FF6600","#FFCC33","#FFCC00","#33CC00","#3366FF","#00CCCC","#6633FF","#CC33CC","#666666","#990000","#cc6600","#cc9933","#999900","#009900","#339999","#3333ff","#6600cc","#993399","#333333","#660000","#993300","#996633","#666600","#006600","#336666","#000099","#333399","#663366","#000000","#330000","#663300","#663333","#333300","#003300","#003333","#000066","#330099","#330033"];
}
return this._colors;
},set_colors:function(_8a5){
this._colors=_8a5;
},get_fontNames:function(){
if(null==this._fontNames){
return ["Times New Roman","MS Sans Serif","Tahoma","Verdana","Arial","Courier New"];
}
return this._fontNames;
},set_fontNames:function(_8a6){
this._fontNames=_8a6;
},get_fontSizes:function(){
if(null==this._fontSizes){
return [1,2,3,4,5,6,7];
}
return this._fontSizes;
},set_fontSizes:function(_8a7){
this._fontSizes=_8a7;
},get_symbols:function(){
if(null==this._symbols){
return ["&#8364;","&#162;","&#163;","&#165;","&#164;","&#169;","&#174;","&#8482;","&#177;","&ne;","&#8776;","&#8804;","&#8805;","&#247;","&#215;","&#8734;","&#189;","&#188;","&#190;","&#178;","&#179;","&#8240;","&#182;","&#167;","&#945;","&#946;","&#916;","&#181;","&#937;","&#8721;","&#216;","&ang;","&#186;","&#171;","&raquo;","&#183;","&#8226;","&#8224;","&#8225;","&#402;"];
}
return this._symbols;
},set_symbols:function(_8a8){
this._symbols=_8a8;
},get_realFontSizes:function(){
if(null==this._realFontSizes){
return ["8px","9px","10px","11px","12px","13px","14px","16px","18px","20px","22px","24px","26px","28px","32px","36px","48px","72px"];
}
return this._realFontSizes;
},set_realFontSizes:function(_8a9){
this._realFontSizes=_8a9;
},get_contextMenus:function(){
if(null==this._contextMenus){
return [];
}
return this._contextMenus;
},set_contextMenus:function(_8aa){
this._contextMenus=_8aa;
},get_snippets:function(){
if(null==this._snippets){
return [];
}
return this._snippets;
},set_snippets:function(_8ab){
this._snippets=_8ab;
},get_cssClasses:function(){
if(null==this._cssClasses){
return [];
}
return this._cssClasses;
},set_cssClasses:function(_8ac){
this._cssClasses=_8ac;
},get_cssFiles:function(){
if(null==this._cssFiles){
return [];
}
return this._cssFiles;
},set_cssFiles:function(_8ad){
this._cssFiles=_8ad;
},get_languages:function(){
if(null==this._languages){
return [];
}
return this._languages;
},set_languages:function(_8ae){
this._languages=_8ae;
},get_paragraphs:function(){
if(null==this._paragraphs){
return [["<p>","Normal"],["<h1>","<h1>Heading 1</h1>"],["<h2>","<h2>Heading 2</h2>"],["<h3>","<h3>Heading 3</h3>"],["<h4>","<h4>Heading 4</h4>"],["<h5>","<h5>Heading 5</h5>"],["<h5>","<dir>Directory List</dir>"],["<menu>","<menu>Menu List</menu>"],["<pre>","<pre>Formatted</pre>"],["<address>","<address>Address</address>"]];
}
return this._paragraphs;
},set_paragraphs:function(_8af){
this._paragraphs=_8af;
},get_toolsWidth:function(){
return this._toolsWidth;
},set_toolsWidth:function(_8b0){
this._toolsWidth=_8b0;
},get_toolProviderID:function(){
return this._toolProviderID;
},set_toolProviderID:function(_8b1){
this._toolProviderID=_8b1;
},get_autoResizeHeight:function(){
return this._autoResizeHeight;
},set_autoResizeHeight:function(_8b2){
this._autoResizeHeight=_8b2;
},get_toolbarMode:function(){
return this._toolbarMode;
},set_toolbarMode:function(_8b3){
this._toolbarMode=_8b3;
},get_editModes:function(){
return this._editModes;
},set_editModes:function(_8b4){
this._editModes=_8b4;
},get_stripFormattingOptions:function(){
return this._stripFormattingOptions;
},set_stripFormattingOptions:function(_8b5){
this._stripFormattingOptions=_8b5;
},get_contentFilters:function(){
return this._contentFilters;
},set_contentFilters:function(_8b6){
this._contentFilters=_8b6;
},get_newLineBr:function(){
return this._newLineBr;
},set_newLineBr:function(_8b7){
this._newLineBr=_8b7;
},get_contentAreaCssFile:function(){
return this._contentAreaCssFile;
},set_contentAreaCssFile:function(_8b8){
this._contentAreaCssFile=_8b8;
},get_mozillaFlashOverlayImage:function(){
return this._mozillaFlashOverlayImage;
},set_mozillaFlashOverlayImage:function(_8b9){
this._mozillaFlashOverlayImage=_8b9;
},get_toolAdapterType:function(){
return this._toolAdapterType;
},set_toolAdapterType:function(_8ba){
this._toolAdapterType=_8ba;
},get_toolJSON:function(){
return this._toolJSON;
},set_toolJSON:function(_8bb){
this._toolJSON=_8bb;
},get_modulesJSON:function(){
return this._modulesJSON;
},set_modulesJSON:function(_8bc){
this._modulesJSON=_8bc;
},get_contextMenusJSON:function(){
return this._contextMenusJSON;
},set_contextMenusJSON:function(_8bd){
this._contextMenusJSON=_8bd;
},get_uniqueID:function(){
return this._uniqueID;
},set_uniqueID:function(_8be){
this._uniqueID=_8be;
},get_skin:function(){
if(!this._skin){
return "Default";
}
return this._skin;
},get_qualifiedSkin:function(){
var skin=this.get_skin();
return "radeditor."+skin;
},set_skin:function(_8c0){
this._skin=_8c0;
},_registerClientValidation:function(){
if(typeof (Page_ClientValidate)=="function"){
var _8c1=Page_ClientValidate;
Page_ClientValidate=Function.createDelegate(this,function(_8c2){
var _8c3=this.get_element();
if(_8c3){
var _8c4=this.get_html(true);
this.set_contentHiddenTextareaValue(_8c4);
_8c3.value=_8c4;
_8c3.setAttribute("value",_8c4);
}
_8c3=null;
return _8c1(_8c2);
});
}
},_registerPostBackHandlers:function(){
this._saveContentDelegate=Function.createDelegate(this,function(e){
if(this._saveContentDelegate){
this.raiseEvent("submit",Sys.EventArgs.Empty);
var _8c6=this.get_html(true);
this.set_contentHiddenTextareaValue(_8c6);
}
});
var _8c7=this._contentHiddenTextarea.form;
$telerik.addExternalHandler(_8c7,"submit",this._saveContentDelegate);
if(typeof (__doPostBack)!="undefined"){
var _8c8=this._saveContentDelegate;
var _8c9=__doPostBack;
__doPostBack=function(_8ca,_8cb){
_8c8();
_8c9(_8ca,_8cb);
};
}
if(typeof (Sys.WebForms)!="undefined"&&typeof (Sys.WebForms.PageRequestManager)!="undefined"){
var prm=Sys.WebForms.PageRequestManager.getInstance();
if(prm){
prm.add_initializeRequest(this._saveContentDelegate);
}
prm=null;
}
_8c7=null;
},toggleEnhancedEdit:function(_8cd){
if(!this.get_document()){
return false;
}
var _8ce=this.get_document().getElementById(this._getUniqueStyleSheetId(0));
if(_8ce){
if(_8cd==null){
_8cd=_8ce.disabled;
}
_8ce.disabled=!_8cd;
var tool=this.getToolByName("ToggleTableBorder");
if(tool){
tool.setOn(_8cd);
}
return _8cd;
}else{
return false;
}
},pasteHyperLink:function(_8d0,_8d1){
if($telerik.isIE){
var sel=this.getSelectedElement();
if(sel.tagName=="IMG"&&sel.parentNode&&sel.parentNode.tagName=="A"){
var _8d3=sel.parentNode;
_8d3.parentNode.removeChild(_8d3);
}
if(sel.tagName=="IMG"){
_8d0.innerHTML=Telerik.Web.UI.Editor.Utils.getOuterHtml(sel);
}
}
if($telerik.isOpera){
var sel=this.getSelectedElement();
if(sel.tagName=="A"){
this.fire("Unlink");
}
}
if("DocumentManager"==_8d1){
var _8d4=this.getSelection().getText();
if(""!=_8d4.trim()){
_8d0.innerHTML=_8d4;
}
}
var _8d5=Telerik.Web.UI.Editor.Utils.getOuterHtml(_8d0);
this.pasteHtml(_8d5,_8d1);
},_saveTypedContent:function(_8d6,_8d7){
if(this._pendingTextTypeCmd){
this._pendingTextTypeCmd.update();
}
if(true!=_8d6){
this._pendingTextTypeCmd=null;
}
},_attachIEBodyHandlers:function(_8d8){
var body=null;
if(this._document&&this._document.body){
body=this._document.body;
}
if(!body){
return;
}
if(_8d8){
this._onResizeStartDelegate=Function.createDelegate(this,this._onResizeStart);
this._onResizeEndDelegate=Function.createDelegate(this,this._onResizeEnd);
this._onDropDelegate=Function.createDelegate(this,this._onDrop);
this._onDragEndDelegate=Function.createDelegate(this,this._onDragEnd);
this._onDragStartDelegate=Function.createDelegate(this,this._onDragStart);
this._onPasteDelegate=Function.createDelegate(this,this._onPaste);
this._onBeforePasteDelegate=Function.createDelegate(this,this._onBeforePaste);
$telerik.addExternalHandler(body,"resizestart",this._onResizeStartDelegate);
$telerik.addExternalHandler(body,"resizeend",this._onResizeEndDelegate);
$telerik.addExternalHandler(body,"drop",this._onDropDelegate);
$telerik.addExternalHandler(body,"dragend",this._onDragEndDelegate);
$telerik.addExternalHandler(body,"dragstart",this._onDragStartDelegate);
if(!this.isIE7){
if(!$telerik.isFirefox){
$telerik.addExternalHandler(body,"paste",this._onPasteDelegate);
}else{
}
}else{
$telerik.addExternalHandler(body,"beforepaste",this._onBeforePasteDelegate);
}
}else{
if(this._onResizeStartDelegate){
$telerik.removeExternalHandler(body,"resizestart",this._onResizeStartDelegate);
}
if(this._onResizeEndDelegate){
$telerik.removeExternalHandler(body,"resizeend",this._onResizeEndDelegate);
}
if(this._onDropDelegate){
$telerik.removeExternalHandler(body,"drop",this._onDropDelegate);
}
if(this._onDragEndDelegate){
$telerik.removeExternalHandler(body,"dragend",this._onDragEndDelegate);
}
if(this._onDragStartDelegate){
$telerik.removeExternalHandler(body,"dragstart",this._onDragStartDelegate);
}
if(!this.isIE7){
if(!$telerik.isFirefox){
if(this._onPasteDelegate){
$telerik.removeExternalHandler(body,"paste",this._onPasteDelegate);
}
}else{
}
if(this._onPasteDelegate){
$telerik.removeExternalHandler(body,"paste",this._onPasteDelegate);
}
}else{
if(this._onBeforePasteDelegate){
$telerik.removeExternalHandler(body,"beforepaste",this._onBeforePasteDelegate);
}
}
this._onResizeStartDelegate=null;
this._onResizeEndDelegate=null;
this._onDropDelegate=null;
this._onDragEndDelegate=null;
this._onDragStartDelegate=null;
this._onPasteDelegate=null;
this._onBeforePasteDelegate=null;
}
},_initEvents:function(){
var _8da=this;
var _8db=_8da.fire;
_8da.fire=function(_8dc,_8dd){
if(_8dc!="Copy"){
_8da._saveTypedContent(true,"editor.fire "+_8dc+" executing");
}
_8db.call(_8da,_8dc,_8dd);
try{
if(_8dc=="Undo"&&!_8da.isIE&&_8da._document.body.innerHTML.toLowerCase().trim()=="<br>"){
_8da._document.body.innerHTML="<br>";
}
}
catch(e){
}
};
this.attachEventHandler("onclick",function(e){
_8da._saveTypedContent(false,"Saving typed content because of oclick (somewhere else)");
if(_8da.getSelectionHtml()){
_8da._pendingTextTypeCmd=new Telerik.Web.UI.Editor.TextTypeCommand(_8da.get_localization()["Typing"],_8da.get_contentWindow());
_8da.executeCommand(_8da._pendingTextTypeCmd,false);
}
});
if(!this.isIE){
this.attachEventHandler("keypress",function(e){
if(_8da._onKeyPressed(e)){
e.preventDefault();
return false;
}
});
this.attachEventHandler("click",function(e){
if(!_8da.isFirefox){
return;
}
if(!_8da.get_editable()){
return;
}
if("on"==_8da._document["designMode"]){
window.setTimeout(function(){
_8da.set_editable(true);
_8da.setFocus();
},100);
}
});
}
this.attachEventHandler("keydown",function(e){
if(_8da.isOpera){
return _8da._onKeyDown(e);
}else{
_8da._onKeyDown(e);
}
});
this.attachEventHandler("onmousedown",function(){
_8da._saveTypedContent(false,"Saving typed content onmousedown");
});
this.attachEventHandler("keyup",Function.createDelegate(this,this._onKeyUp));
var _8e2=Function.createDelegate(this,function(e){
this.raiseEvent("selectionChange",Sys.EventArgs.Empty);
});
this.attachEventHandler("mouseup",_8e2);
$telerik.addExternalHandler(document.body,"dragend",Function.createDelegate(this,this._onDocumentDragEnd));
this._attachIEBodyHandlers(true);
},_onKeyDown:function(e){
var _8e5=e.keyCode;
switch(_8e5){
case 46:
if($telerik.isOpera){
this._document.execCommand("Delete");
this.get_contentArea().contentEditable=true;
this._document.designMode="on";
this.get_contentArea().focus();
return $telerik.cancelRawEvent(e);
}
case 8:
this._shortcutHit=false;
if(this.getSelectionHtml()){
this._saveTypedContent(false,"Saving typed content before allowing delete to proceed..");
this._pendingTextTypeCmd=new Telerik.Web.UI.Editor.TextTypeCommand(this.getLocalizedString("Typing"),this._contentWindow);
this._hasDeleteExecuted=true;
}
if(this.isIE){
var _8e6=this;
var _8e7=function(){
var _8e8=_8e6.getSelectedElement();
if(_8e8&&_8e8.tagName=="EMBED"){
_8e8.setAttribute("hidden","true");
_8e8.setAttribute("id","FileToDelete");
window.setTimeout(function(){
var _8e9=_8e6._document.getElementById("FileToDelete");
if(_8e9.parentNode&&_8e9.parentNode.removeChild){
_8e9.parentNode.removeChild(_8e9);
}
},100);
$telerik.cancelRawEvent(e);
return true;
}
};
var _8ea=_8e7();
if(_8ea){
return false;
}
try{
var _8eb=_8e6._document.selection.createRange();
var _8ec=null;
if(_8eb&&_8eb.duplicate){
_8ec=_8eb.duplicate();
}
if(8==e.keyCode){
_8eb.moveStart("character",-1);
}else{
_8eb.moveEnd("character",1);
}
if(_8eb.parentElement().tagName=="EMBED"){
_8eb.select();
_8e7();
if(_8ec&&_8ec.select){
_8ec.select();
}
}
}
catch(ex){
}
var _8ed=new Telerik.Web.UI.Editor.Selection(this._contentWindow);
if(_8ed&&_8ed.isControl()){
var _8ee=_8ed.getRange();
_8ee.execCommand("Delete");
$telerik.cancelRawEvent(e);
}
}
return;
}
var _8ef=e.target?e.target:e.srcElement;
if(_8ef&&"INPUT"!=_8ef.tagName){
var _8f0=this._shortCutManager.isShortCutHit(e);
if(null!=_8f0&&_8f0.get_name()=="Copy"){
this._shortcutHit=false;
return;
}
this._shortcutHit=(null!=_8f0);
if(this._shortcutHit){
this.fire(_8f0.get_name());
}else{
if(Telerik.Web.UI.Editor.Utils.isCursorMovingKey(e.keyCode)){
if(!this._hasCursorMoved){
this._saveTypedContent(false,"Saving typed content before letting the cursor move");
}
this._hasCursorMoved=true;
return;
}
if(32==e.keyCode||13==e.keyCode||!Telerik.Web.UI.Editor.Utils.isSystemKey(e.keyCode)){
if(this._hasCursorMoved){
this._pendingTextTypeCmd=new Telerik.Web.UI.Editor.TextTypeCommand(this.getLocalizedString("Typing"),this._contentWindow);
this.executeCommand(this._pendingTextTypeCmd);
this._hasCursorMoved=false;
return;
}
if(!this._pendingTextTypeCmd){
this._pendingTextTypeCmd=new Telerik.Web.UI.Editor.TextTypeCommand(this.getLocalizedString("Typing"),this._contentWindow);
this.executeCommand(this._pendingTextTypeCmd);
this.raiseEvent("selectionChange",Sys.EventArgs.Empty);
}
}
}
if(this._shortcutHit){
if(this.isIE){
var name=_8f0.get_name();
if(name=="Cut"||name=="Paste"){
return;
}
e.keyCode=123;
e.returnValue=!this._shortcutHit;
}
}
}
},_onKeyUp:function(e){
if(this._hasDeleteExecuted){
if(this._pendingTextTypeCmd){
this.executeCommand(this._pendingTextTypeCmd);
}
this._pendingTextTypeCmd=null;
this._hasDeleteExecuted=false;
return;
}
if(this._pendingTextTypeCmd){
return;
}
if(this._pendingCutPasteCommand){
this.executeCommand(this._pendingCutPasteCommand);
this._pendingCutPasteCommand=null;
}
if(this._shortcutHit){
return false;
}
this.raiseEvent("selectionChange",Sys.EventArgs.Empty);
},_onKeyPressed:function(e){
if(this._pendingTextTypeCmd){
}else{
this.raiseEvent("selectionChange",Sys.EventArgs.Empty);
}
if(this._shortcutHit&&!this._pendingCutPasteCommand){
return true;
}
},_insertPastedContent:function(_8f4,_8f5,_8f6,_8f7){
var _8f8=this;
var _8f9=(this.get_contentFilters()&Telerik.Web.UI.EditorFilters.RemoveScripts)>0;
var _8fa=Telerik.Web.UI.Editor.Utils.cleanPastedContent(_8f5,_8f8.get_stripFormattingOptions(),_8f8.get_localization()["askwordcleaning"],_8f9);
if(_8f4){
_8f4.select();
}
if(_8fa){
window.setTimeout(function(){
if(_8f7&&_8f4){
_8f4.select();
}
_8f8.pasteHtml(_8fa);
},5);
return $telerik.cancelRawEvent(_8f6);
}
return true;
},_onPaste:function(_8fb){
if(this.get_stripFormattingOptions()==Telerik.Web.UI.StripFormattingOptions.NoneSupressCleanMessage){
return;
}
var _8fc=this.createRestorePoint();
var _8fd=this.getSelectionHtml()?true:false;
var _8fe=Telerik.Web.UI.Editor.Utils.getClipboardAsHtml();
return this._insertPastedContent(_8fc,_8fe,_8fb,_8fd);
},_onBeforePaste:function(_8ff){
if(_8ff){
if(this.get_stripFormattingOptions()==Telerik.Web.UI.StripFormattingOptions.NoneSupressCleanMessage){
return;
}
var _900=new Telerik.Web.UI.Editor.GenericCommand("Paste",this._contentWindow);
var _901=this.getSelection().getRange();
var _902=Telerik.Web.UI.Editor.Utils.getUniqueID();
if(_901.pasteHTML){
_901.pasteHTML("&nbsp;<font id='"+_902+"'>&nbsp;</font>");
}else{
this.pasteHtml("&nbsp;<font id='"+_902+"'>&nbsp;</font>");
}
var _903=Telerik.Web.UI.Editor.Utils.getPasteContainer();
_903.innerHTML="";
if(_903.setActive){
_903.setActive();
}else{
_903.focus();
}
var _904=this;
window.setTimeout(function(){
var _905=_903.innerHTML;
var _906=(_904.get_contentFilters()&Telerik.Web.UI.EditorFilters.RemoveScripts)>0;
var _907=Telerik.Web.UI.Editor.Utils.cleanPastedContent(_905,_904.get_stripFormattingOptions(),_904.get_localization()["askwordcleaning"],_906);
var _908=_904._document.getElementById(_902);
_904.setActive(true);
_904._pendingCutPasteCommand=null;
if(_904._document.body.createTextRange){
var _909=_904._document.body.createTextRange();
_909.moveToElementText(_908);
_909.moveStart("character",-1);
_909.select();
_909.pasteHTML(_907);
}else{
_904.getSelection().selectRange(_909);
_904.pasteHtml(_907);
}
_904.executeCommand(_900);
_904.setActive(true);
_904.setFocus(true);
},0);
}else{
}
},_onResizeStart:function(e){
var _90b=this.getSelectedElement();
if(_90b==e.srcElement){
var _90c=this.get_localization()["ResizeCommand"]||"Resize";
this._pendingResizeCmd=new Telerik.Web.UI.Editor.GenericCommand(_90c,this._contentWindow);
}
},_onResizeEnd:function(e){
if(this._pendingResizeCmd){
this.executeCommand(this._pendingResizeCmd);
}
},_onDragStart:function(e){
var _90f=this.get_localization()["MoveCommand"]||"Move";
this._pendingMoveCommand=new Telerik.Web.UI.Editor.GenericCommand(_90f,this.get_contentArea());
this._startRange=null;
if(!e.ctrlKey&&!e.ctrlLeft){
this._startRange=this._contentWindow.document.selection.createRange();
if(this._startRange.length){
var rng=this._contentWindow.document.body.createTextRange();
var _911=this._startRange.item(0);
if("IMG"==_911.tagName&&"A"==_911.parentNode.tagName&&_911.parentNode.childNodes.length==1){
_911=_911.parentNode;
}
rng.moveToElementText(_911);
this._startRange=rng;
}
}
},_onDragEnd:function(e){
if(this._pendingMoveCommand){
if(this._startRange){
var _913=this._contentWindow.document.selection.createRange();
if(_913.length){
var rng=this._contentWindow.document.body.createTextRange();
rng.moveToElementText(_913.item(0));
_913=rng;
}
try{
if(_913.compareEndPoints&&0!=_913.compareEndPoints("StartToStart",this._startRange)&&0!=_913.compareEndPoints("EndToEnd",this._startRange)){
this._startRange.execCommand("Delete",false,null);
}
}
catch(e){
}
}
this.executeCommand(this._pendingMoveCommand);
this._pendingMoveCommand=null;
this.raiseEvent("selectionChange",Sys.EventArgs.Empty);
}
},_onDrop:function(e){
this._saveTypedContent(false,"on drop operation executing");
var _916=this.get_localization()["Drop"]||"Drop external content";
this._pendingDockCommand=new Telerik.Web.UI.Editor.GenericCommand(_916,this._contentWindow);
},_onDocumentDragEnd:function(e){
if(!this._pendingDockCommand){
return;
}
this.executeCommand(this._pendingDockCommand);
this._pendingDockCommand=null;
this.raiseEvent("selectionChange",Sys.EventArgs.Empty);
},add_toggleScreenMode:function(_918){
this.get_events().addHandler("toggleScreenMode",_918);
},remove_toggleScreenMode:function(_919){
this.get_events().removeHandler("toggleScreenMode",_919);
},add_modeChange:function(_91a){
this.get_events().addHandler("modeChange",_91a);
},remove_modeChange:function(_91b){
this.get_events().removeHandler("modeChange",_91b);
},add_load:function(_91c){
this.get_events().addHandler("load",_91c);
},remove_load:function(_91d){
this.get_events().removeHandler("load",_91d);
},add_init:function(_91e){
this.get_events().addHandler("init",_91e);
},remove_init:function(_91f){
this.get_events().removeHandler("init",_91f);
},add_selectionChange:function(_920){
this.get_events().addHandler("selectionChange",_920);
},remove_selectionChange:function(_921){
this.get_events().removeHandler("selectionChange",_921);
},add_commandExecuting:function(_922){
this.get_events().addHandler("commandExecuting",_922);
},remove_commandExecuting:function(_923){
this.get_events().removeHandler("commandExecuting",_923);
},add_commandExecuted:function(_924){
this.get_events().addHandler("commandExecuted",_924);
},remove_commandExecuted:function(_925){
this.get_events().removeHandler("commandExecuted",_925);
},add_submit:function(_926){
this.get_events().addHandler("submit",_926);
},remove_submit:function(_927){
this.get_events().removeHandler("submit",_927);
},add_editReady:function(_928){
this.get_events().addHandler("editReady",_928);
},remove_editReady:function(_929){
this.get_events().removeHandler("editReady",_929);
},add_pasteHtml:function(_92a){
this.get_events().addHandler("pasteHtml",_92a);
},remove_pasteHtml:function(_92b){
this.get_events().removeHandler("pasteHtml",_92b);
},add_firstShow:function(_92c){
this.get_events().addHandler("firstShow",_92c);
},remove_firstShow:function(_92d){
this.get_events().removeHandler("firstShow",_92d);
}};
Telerik.Web.UI.RadEditor.registerClass("Telerik.Web.UI.RadEditor",Telerik.Web.UI.RadWebControl);
Telerik.Web.UI.EditorToolType=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.EditorToolType.prototype={Button:1,DropDown:2,SplitButton:4,Separator:8,ToolStrip:16,Custom:32};
Telerik.Web.UI.EditorToolType.registerEnum("Telerik.Web.UI.EditorToolType",false);

