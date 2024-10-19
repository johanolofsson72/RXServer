Type.registerNamespace("Telerik.Web.UI");
Type.registerNamespace("Telerik.Web.UI.WindowManager");
function GetRadWindowManager(){
return Telerik.Web.UI.WindowManager.Manager;
}
window.radalert=function(_1,_2,_3,_4){
var _5=GetRadWindowManager();
var _6=_5._getStandardPopup("alert",_1);
if(typeof (_4)!="undefined"){
_6.set_title(_4);
}
_6.setSize(_2?_2:280,_3?_3:200);
_6.show();
_6.center();
return _6;
};
window.radconfirm=function(_7,_8,_9,_a,_b,_c){
var _d=GetRadWindowManager();
var _e=_d._getStandardPopup("confirm",_7);
if(typeof (_c)!="undefined"){
_e.set_title(_c);
}
_e.setSize(_9?_9:280,_a?_a:200);
_e.callBack=function(_f){
if(_8){
_8(_f);
}
_e.close();
_e.callBack=null;
};
_e.show();
_e.center();
return _e;
};
window.radprompt=function(_10,_11,_12,_13,_14,_15,_16){
var _17=GetRadWindowManager();
var _18=_17._getStandardPopup("prompt",_10,_16);
if(typeof (_15)!="undefined"){
_18.set_title(_15);
}
_18.setSize(_12?_12:280,_13?_13:200);
_18.callBack=function(_19){
if(_11){
_11(_19);
}
_18.close();
_18.callBack=null;
};
_18.show();
_18.center();
return _18;
};
window.radopen=function(url,_1b){
var _1c=GetRadWindowManager();
return _1c.open(url,_1b);
};
Telerik.Web.UI.RadWindowManager=function(_1d){
Telerik.Web.UI.RadWindowManager.initializeBase(this,[_1d]);
this._windowIDs=[];
this._windows=[];
this._preserveClientState=false;
this.Open=this.open;
this.GetWindowByName=this.getWindowByName;
this.GetWindowById=this.getWindowById;
this.GetActiveWindow=this.getActiveWindow;
this.GetWindowObjects=this.get_windows;
this.GetWindows=this.get_windows;
this.Cascade=this.cascade;
this.Tile=this.tile;
this.RestoreAll=this.restoreAll;
this.MaximizeAll=this.maximizeAll;
this.MinimizeAll=this.minimizeAll;
this.ShowAll=this.showAll;
this.CloseAll=this.closeAll;
this.CloseActiveWindow=this.closeActiveWindow;
this.MinimizeActiveWindow=this.minimizeActiveWindow;
this.RestoreActiveWindow=this.restoreActiveWindow;
};
Telerik.Web.UI.RadWindowManager.prototype={get_zIndex:function(){
return Telerik.Web.UI.RadWindowUtils._zIndex;
},set_zIndex:function(_1e){
var _1f=parseInt(_1e);
if(isNaN(_1e)){
return;
}
Telerik.Web.UI.RadWindowUtils._zIndex=_1e;
},initialize:function(_20){
try{
var _21=this.get_element().style.zIndex;
if(_21){
this.set_zIndex(_21);
}
}
catch(e){
}
this._initialize();
this._registerAsPageManager();
if(this.get_preserveClientState()){
this.restoreState();
}
},dispose:function(){
var _22=this.get_preserveClientState();
if(_22){
this.saveState();
}
this._disposeWindows();
this._windows=null;
Telerik.Web.UI.RadWindowManager.callBaseMethod(this,"dispose");
},open:function(url,_24){
var _25=this.getWindowByName(_24);
if(!_25){
if(!_24){
_24=this.get_id()+this._getUniqueId();
}
_25=this._createWindow(_24);
}
if(url){
_25.setUrl(url);
}
_25.show();
return _25;
},getActiveWindow:function(){
return Telerik.Web.UI.RadWindowController.get_activeWindow();
},getWindowById:function(id){
var _27=this.get_windows();
for(var i=0;i<_27.length;i++){
var _29=_27[i];
if(id==_29.get_id()){
return _29;
}
}
return null;
},getWindowByName:function(_2a){
var _2b=this.get_windows();
if(!_2b){
return null;
}
for(var i=0;i<_2b.length;i++){
var _2d=_2b[i];
if(_2a==_2d.get_name()){
return _2d;
}
}
return null;
},removeWindow:function(_2e){
if(!_2e){
return;
}
var w=this.getWindowByName(_2e.get_name());
var _30=this.get_windows();
if(w){
Array.remove(_30,w);
}
},_getUniqueId:function(){
return ""+(new Date()-100);
},_initialize:function(){
var _31=this._windowIDs;
for(var i=0;i<_31.length;i++){
var _33=_31[i];
var _34=$find(_33);
if(!_34){
continue;
}
_34.set_windowManager(this);
this._windows[this._windows.length]=_34;
}
},_disposeWindows:function(){
for(var i=0;i<this._windows.length;i++){
var t=this._windows[i];
if(t.isCloned()){
t.dispose();
}
}
this._windows=[];
},_createWindow:function(_37,_38){
var wnd=this.clone(_37,_38);
this._windows[this._windows.length]=wnd;
wnd.set_windowManager(this);
return wnd;
},_replaceLocalization:function(_3a,_3b){
var _3c=/##LOC\[(.*?)\]##/;
while(_3a.match(_3c)){
var _3d=_3b[RegExp.$1]?_3b[RegExp.$1]:"";
_3a=_3a.replace(_3c,_3d);
}
return _3a;
},_getStandardPopup:function(_3e,_3f,_40){
var _41=this._createWindow(_3e+this._getUniqueId(),false);
_41.set_destroyOnClose(true);
_41.set_modal(true);
var div=document.getElementById(this.get_id()+"_"+_3e.toLowerCase()+"template");
var _43=this._stringFormat(div.innerHTML,_41.get_id(),_3f,_40?_40:"");
_43=this._replaceLocalization(_43,Telerik.Web.UI.RadWindowUtils.Localization);
var _44=document.createElement("DIV");
_44.innerHTML=_43;
_41.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close);
_41.set_visibleStatusbar(false);
_41.set_contentElement(_44);
var _45=_41.get_contentElement().getElementsByTagName("INPUT")[0];
if(_45&&_45.focus){
window.setTimeout(function(){
_45.focus();
},0);
}
return _41;
},_stringFormat:function(_46){
for(var i=1;i<arguments.length;i++){
_46=_46.replace(new RegExp("\\{"+(i-1)+"\\}","ig"),arguments[i]);
}
return _46;
},_registerAsPageManager:function(){
var _48=Telerik.Web.UI.WindowManager.Manager;
var _49=this.get_id();
if(_48&&_48.get_id()==_49){
_48.dispose();
Telerik.Web.UI.WindowManager.Manager=null;
}
if(!Telerik.Web.UI.WindowManager.Manager){
Telerik.Web.UI.WindowManager.Manager=this;
}
},saveWindowState:function(_4a){
if(!_4a||!_4a.isCreated()){
return;
}
var _4b=_4a.getWindowBounds();
var _4c=(_4a.isVisible()||_4a.isMinimized())+"@"+_4b.width+"@"+_4b.height+"@"+_4b.x+"@"+_4b.y+"@"+_4a.isMinimized();
this._setRadWindowCookie(_4a.get_id(),_4c);
},saveState:function(){
var _4d=this.get_windows();
for(i=0;i<_4d.length;i++){
var _4e=_4d[i];
if(_4e.isCloned()){
this.saveWindowState(_4e);
}
}
},restoreState:function(){
function restoreWindow(_4f,_50){
var _51=_50.split("@");
if(_51.length>1){
if("true"==_51[0]&&!_4f.isVisible()){
_4f.show();
}
window.setTimeout(function(){
if(parseInt(_51[1])>0){
_4f.set_width(_51[1]);
}
if(parseInt(_51[2])>0){
_4f.set_height(_51[2]);
}
if("true"==_51[0]){
_4f.moveTo(parseInt(_51[3]),parseInt(_51[4]));
}
if("true"==_51[5]){
_4f.minimize();
}
},1);
}
}
var _52=this.get_windows();
for(i=0;i<_52.length;i++){
var _53=_52[i];
var _54=this._getRadWindowCookie(_53.get_id());
if(_54){
restoreWindow(_53,_54);
}
}
},_getOnlyCookie:function(){
var _55="RadWindowCookie";
var _56=document.cookie.split("; ");
for(var i=0;i<_56.length;i++){
var _58=_56[i].split("=");
if(_55==_58[0]){
return _58[1];
}
}
return null;
},_setRadWindowCookie:function(_59,_5a){
_59="["+_59+"]";
var _5b=this._getOnlyCookie();
var _5c="";
var _5d="";
if(_5b){
var _5e=_5b.split(_59);
if(_5e&&_5e.length>1){
_5c=_5e[0];
_5d=_5e[1].substr(_5e[1].indexOf("#")+1);
}else{
_5d=_5b;
}
}
var _5f=new Date();
_5f.setFullYear(_5f.getFullYear()+10);
document.cookie="RadWindowCookie"+"="+(_5c+_59+"-"+_5a+"#"+_5d)+";path=/;expires="+_5f.toUTCString()+";";
},_getRadWindowCookie:function(_60){
var _61=this._getOnlyCookie();
if(!_61){
return;
}
var _62=null;
_60="["+_60+"]";
var _63=_61.indexOf(_60);
if(_63>=0){
var _64=_63+_60.length+1;
_62=_61.substring(_64,_61.indexOf("#",_64));
}
return _62;
},cascade:function(){
var _65=40;
var _66=40;
var _67=this._getWindowsSortedByZindex();
for(var i=0;i<_67.length;i++){
var _69=_67[i];
if(!_69.isClosed()&&_69.isVisible()){
var _6a=_69.restore();
_69.moveTo(_65,_66);
_69.setActive(true);
_65+=25;
_66+=25;
}
}
},tile:function(){
var _6b=this._getWindowsSortedByZindex();
var _6c=0;
for(var i=0;i<_6b.length;i++){
var _6e=_6b[i];
if(!_6e.isClosed()&&_6e.isVisible()){
_6c++;
}
}
var _6f=5;
var _70=0;
var _71=1;
if(_6c<=_6f){
_70=_6c;
}else{
var i=2;
while((_6c*i)<(_6f*(i+1))){
i++;
if(i>6){
break;
}
}
_71=i;
_70=Math.ceil(_6c/_71);
}
var _72=$telerik.getClientBounds();
var _73=Math.floor(_72.width/_70);
var _74=Math.floor(_72.height/_71);
var _75=document.documentElement.scrollLeft||document.body.scrollLeft;
var top=document.documentElement.scrollTop||document.body.scrollTop;
var _77=0;
for(var i=0;i<_6b.length;i++){
var _6e=_6b[i];
if(!_6e.isClosed()&&_6e.isVisible()){
_77++;
if((_77-1)%(_70)==0&&_77>_70){
top+=_74;
_75=document.documentElement.scrollLeft||document.body.scrollLeft;
}
_6e.restore();
_6e.moveTo(_75,top);
_6e.setSize(_73,_74);
_75+=_73;
}
}
},closeActiveWindow:function(){
this._executeActiveWindow("close");
},minimizeActiveWindow:function(){
this._executeActiveWindow("minimize");
},restoreActiveWindow:function(){
this._executeActiveWindow("restore");
},closeAll:function(){
this._executeAll("close");
},showAll:function(){
this._executeAll("show");
},minimizeAll:function(){
this._executeAll("minimize");
},maximizeAll:function(){
this._executeAll("maximize");
},restoreAll:function(){
this._executeAll("restore");
},_getWindowsSortedByZindex:function(){
var _78=this._windows.concat([]);
var _79=function(_7a,_7b){
var z1=_7a.get_zindex();
var z2=_7b.get_zindex();
if(z1==z2){
return 0;
}
return (z1<z2?-1:1);
};
return _78.sort(_79);
},_executeAll:function(_7e){
if(!this._windows){
return;
}
var _7f=this._windows.concat([]);
for(var i=0;i<_7f.length;i++){
_7f[i][_7e]();
}
},_executeActiveWindow:function(_81){
var _82=this.getActiveWindow();
if(_82&&"function"==typeof (_82[_81])){
_82[_81]();
}
},get_preserveClientState:function(){
return this._preserveClientState;
},set_preserveClientState:function(_83){
if(this._preserveClientState!=_83){
this._preserveClientState=_83;
}
},set_windowControls:function(_84){
this._windowIDs=eval(_84);
this._disposeWindows();
},get_windowControls:function(){
},get_windows:function(){
return this._windows;
}};
Telerik.Web.UI.RadWindowManager.registerClass("Telerik.Web.UI.RadWindowManager",Telerik.Web.UI.RadWindow);

