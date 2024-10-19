Type.registerNamespace("Telerik.Web.UI.Calendar");
Telerik.Web.UI.Calendar.PresentationType=function(){
};
Telerik.Web.UI.Calendar.PresentationType.prototype={Interactive:1,Preview:2};
Telerik.Web.UI.Calendar.PresentationType.registerEnum("Telerik.Web.UI.Calendar.PresentationType",false);
Telerik.Web.UI.Calendar.FirstDayOfWeek=function(){
};
Telerik.Web.UI.Calendar.FirstDayOfWeek.prototype={Monday:1,Tuesday:2,Wednesday:3,Thursday:4,Friday:5,Saturday:6,Sunday:7};
Telerik.Web.UI.Calendar.FirstDayOfWeek.registerEnum("Telerik.Web.UI.Calendar.FirstDayOfWeek",false);
Telerik.Web.UI.Calendar.Orientation=function(){
};
Telerik.Web.UI.Calendar.Orientation.prototype={RenderInRows:1,RenderInColumns:2};
Telerik.Web.UI.Calendar.Orientation.registerEnum("Telerik.Web.UI.Calendar.Orientation",false);
Telerik.Web.UI.Calendar.AutoPostBackControl=function(){
};
Telerik.Web.UI.Calendar.AutoPostBackControl.prototype={None:0,Both:1,TimeView:2,Calendar:3};
Telerik.Web.UI.Calendar.AutoPostBackControl.registerEnum("Telerik.Web.UI.Calendar.AutoPostBackControl",false);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.CalendarClickEventArgs=function(_1,_2){
Telerik.Web.UI.CalendarClickEventArgs.initializeBase(this);
this._domElement=_1;
this._index=_2;
};
Telerik.Web.UI.CalendarClickEventArgs.prototype={get_domElement:function(){
return this._domElement;
},get_index:function(){
return this._index;
}};
Telerik.Web.UI.CalendarClickEventArgs.registerClass("Telerik.Web.UI.CalendarClickEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.CalendarDayRenderEventArgs=function(_3,_4,_5){
Telerik.Web.UI.CalendarDayRenderEventArgs.initializeBase(this);
this._cell=_3;
this._date=_4;
this._renderDay=_5;
};
Telerik.Web.UI.CalendarDayRenderEventArgs.prototype={get_cell:function(){
return this._cell;
},get_date:function(){
return this._date;
},get_renderDay:function(){
return this._renderDay;
}};
Telerik.Web.UI.CalendarDayRenderEventArgs.registerClass("Telerik.Web.UI.CalendarDayRenderEventArgs",Sys.EventArgs);
Telerik.Web.UI.CalendarDateClickEventArgs=function(_6,_7){
Telerik.Web.UI.CalendarDateClickEventArgs.initializeBase(this);
this._domEvent=_6;
this._renderDay=_7;
};
Telerik.Web.UI.CalendarDateClickEventArgs.prototype={get_domEvent:function(){
return this._domEvent;
},get_renderDay:function(){
return this._renderDay;
}};
Telerik.Web.UI.CalendarDateClickEventArgs.registerClass("Telerik.Web.UI.CalendarDateClickEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.CalendarDateSelectingEventArgs=function(_8,_9){
Telerik.Web.UI.CalendarDateSelectingEventArgs.initializeBase(this);
this._isSelecting=_8;
this._renderDay=_9;
};
Telerik.Web.UI.CalendarDateSelectingEventArgs.prototype={get_isSelecting:function(){
return this._isSelecting;
},get_renderDay:function(){
return this._renderDay;
}};
Telerik.Web.UI.CalendarDateSelectingEventArgs.registerClass("Telerik.Web.UI.CalendarDateSelectingEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.CalendarDateSelectedEventArgs=function(_a){
Telerik.Web.UI.CalendarDateSelectedEventArgs.initializeBase(this);
this._renderDay=_a;
};
Telerik.Web.UI.CalendarDateSelectedEventArgs.prototype={get_renderDay:function(){
return this._renderDay;
}};
Telerik.Web.UI.CalendarDateSelectedEventArgs.registerClass("Telerik.Web.UI.CalendarDateSelectedEventArgs",Sys.EventArgs);
Telerik.Web.UI.CalendarViewChangingEventArgs=function(_b){
Telerik.Web.UI.CalendarViewChangingEventArgs.initializeBase(this);
this._step=_b;
};
Telerik.Web.UI.CalendarViewChangingEventArgs.prototype={get_step:function(){
return this._step;
}};
Telerik.Web.UI.CalendarViewChangingEventArgs.registerClass("Telerik.Web.UI.CalendarViewChangingEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.CalendarViewChangedEventArgs=function(_c){
Telerik.Web.UI.CalendarViewChangedEventArgs.initializeBase(this);
this._step=_c;
};
Telerik.Web.UI.CalendarViewChangedEventArgs.prototype={get_step:function(){
return this._step;
}};
Telerik.Web.UI.CalendarViewChangedEventArgs.registerClass("Telerik.Web.UI.CalendarViewChangedEventArgs",Sys.EventArgs);
Telerik.Web.UI.DatePickerPopupOpeningEventArgs=function(_d,_e){
Telerik.Web.UI.DatePickerPopupOpeningEventArgs.initializeBase(this);
this._popupControl=_d;
this._cancelCalendarSynchronization=_e;
};
Telerik.Web.UI.DatePickerPopupOpeningEventArgs.prototype={get_popupControl:function(){
return this._popupControl;
},get_cancelCalendarSynchronization:function(){
return this._cancelCalendarSynchronization;
},set_cancelCalendarSynchronization:function(_f){
if(this._cancelCalendarSynchronization!==_f){
this._cancelCalendarSynchronization=_f;
}
}};
Telerik.Web.UI.DatePickerPopupOpeningEventArgs.registerClass("Telerik.Web.UI.DatePickerPopupOpeningEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.DatePickerPopupClosingEventArgs=function(_10){
Telerik.Web.UI.DatePickerPopupClosingEventArgs.initializeBase(this);
this._popupControl=_10;
};
Telerik.Web.UI.DatePickerPopupClosingEventArgs.prototype={get_popupControl:function(){
return this._popupControl;
}};
Telerik.Web.UI.DatePickerPopupClosingEventArgs.registerClass("Telerik.Web.UI.DatePickerPopupClosingEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.TimeViewSelectedEventArgs=function(_11,_12){
Telerik.Web.UI.TimeViewSelectedEventArgs.initializeBase(this);
this._newTime=_11;
this._oldTime=_12;
};
Telerik.Web.UI.TimeViewSelectedEventArgs.prototype={get_newTime:function(){
return this._newTime;
},get_oldTime:function(){
return this._oldTime;
}};
Telerik.Web.UI.TimeViewSelectedEventArgs.registerClass("Telerik.Web.UI.TimeViewSelectedEventArgs",Sys.EventArgs);
if(typeof (window["RadCalendarNamespace"])=="undefined"){
window["RadCalendarNamespace"]={};
}
Type.registerNamespace("Telerik.Web.UI.Calendar");
Telerik.Web.UI.Calendar.Popup=function(){
this.DomElement=null;
this.ExcludeFromHiding=[];
};
Telerik.Web.UI.Calendar.Popup.zIndex=5000;
Telerik.Web.UI.Calendar.Popup.prototype={CreateContainer:function(){
var div=document.createElement("DIV");
var _14=RadHelperUtils.GetStyleObj(div);
_14.position="absolute";
if(navigator.userAgent.match(/Safari/)){
_14.visibility="hidden";
_14.left="-1000px";
}else{
_14.display="none";
}
_14.border="0";
_14.zIndex=Telerik.Web.UI.Calendar.Popup.zIndex;
Telerik.Web.UI.Calendar.Popup.zIndex+=2;
div.onclick=function(e){
if(!e){
e=window.event;
}
e.returnValue=false;
e.cancelBubble=true;
if(e.stopPropagation){
e.stopPropagation();
}
return false;
};
document.body.insertBefore(div,document.body.firstChild);
return div;
},RemoveScriptsOnOpera:function(_16){
if(window.opera){
var _17=_16.getElementsByTagName("*");
for(var i=0;i<_17.length;i++){
var _19=_17[i];
if(_19.tagName!=null&&_19.tagName.toLowerCase()=="script"){
_19.parentNode.removeChild(_19);
}
}
}
},Show:function(x,y,_1c,_1d){
if(this.IsVisible()){
this.Hide();
}
this.ExitFunc=("function"==typeof (_1d)?_1d:null);
var div=this.DomElement;
if(!div){
div=this.CreateContainer();
this.DomElement=div;
}
if(_1c){
div.innerHTML="";
if(_1c.nextSibling){
this.Sibling=_1c.nextSibling;
}
this.Parent=_1c.parentNode;
this.RemoveScriptsOnOpera(_1c);
div.appendChild(_1c);
if(navigator.userAgent.match(/Safari/)&&_1c.style.visibility=="hidden"){
_1c.style.visibility="visible";
_1c.style.position="";
_1c.style.left="";
}else{
if(_1c.style.display=="none"){
_1c.style.display="";
}
}
}
var _1f=RadHelperUtils.GetStyleObj(div);
_1f.left=parseInt(x)+"px";
_1f.top=parseInt(y)+"px";
if(navigator.userAgent.match(/Safari/)){
_1f.visibility="visible";
}else{
_1f.display="";
}
RadHelperUtils.ProcessIframe(div,true);
this.OnClickFunc=Telerik.Web.UI.Calendar.Utils.AttachMethod(this.OnClick,this);
this.OnKeyPressFunc=Telerik.Web.UI.Calendar.Utils.AttachMethod(this.OnKeyPress,this);
var _20=this;
window.setTimeout(function(){
RadHelperUtils.AttachEventListener(document,"click",_20.OnClickFunc);
RadHelperUtils.AttachEventListener(document,"keypress",_20.OnKeyPressFunc);
},300);
},Hide:function(_21){
var div=this.DomElement;
var _23=RadHelperUtils.GetStyleObj(div);
if(div){
if(navigator.userAgent.match(/Safari/)){
_23.visibility="hidden";
_23.position="absolute";
_23.left="-1000px";
}else{
_23.display="none";
}
_23=null;
if(div.childNodes.length!=0){
if(navigator.userAgent.match(/Safari/)){
div.childNodes[0].style.visibility="hidden";
div.childNodes[0].style.position="absolute";
div.childNodes[0].style.left="-1000px";
}else{
div.childNodes[0].style.display="none";
}
}
var _24=div.childNodes[0];
if(_24!=null){
div.removeChild(_24);
if(this.Parent!=null||this.Sibling!=null){
if(this.Sibling!=null){
var _25=this.Sibling.parentNode;
if(_25!=null){
_25.insertBefore(_24,this.Sibling);
}
}else{
this.Parent.appendChild(_24);
}
}
if(navigator.userAgent.match(/Safari/)){
RadHelperUtils.GetStyleObj(_24).visibility="hidden";
RadHelperUtils.GetStyleObj(_24).position="absolute";
RadHelperUtils.GetStyleObj(_24).left="-1000px";
}else{
RadHelperUtils.GetStyleObj(_24).display="none";
}
}
RadHelperUtils.ProcessIframe(div,false);
}
if(this.OnClickFunc!=null){
RadHelperUtils.DetachEventListener(document,"click",this.OnClickFunc);
this.OnClickFunc=null;
}
if(this.OnKeyPressFunc!=null){
RadHelperUtils.DetachEventListener(document,"keydown",this.OnKeyPressFunc);
this.OnKeyPressFunc=null;
}
if(_21&&this.ExitFunc){
this.ExitFunc();
}
},IsVisible:function(){
var div=this.DomElement;
var _27=RadHelperUtils.GetStyleObj(div);
if(div){
if(navigator.userAgent.match(/Safari/)){
return (_27.visibility!="hidden");
}
return (_27.display!="none");
}
return false;
},IsChildOf:function(_28,_29){
while(_28.parentNode){
if(_28.parentNode==_29){
return true;
}
_28=_28.parentNode;
}
return false;
},ShouldHide:function(e){
var _2b=e.target;
if(_2b==null){
_2b=e.srcElement;
}
for(var i=0;i<this.ExcludeFromHiding.length;i++){
if(this.ExcludeFromHiding[i]==_2b){
return false;
}
if(this.IsChildOf(_2b,this.ExcludeFromHiding[i])){
return false;
}
}
return true;
},OnKeyPress:function(e){
if(!e){
e=window.event;
}
if(e.keyCode==27){
this.Hide();
}
},OnClick:function(e){
if(!e){
e=window.event;
}
if(this.ShouldHide(e)){
this.Hide();
}
}};
Telerik.Web.UI.Calendar.Popup.registerClass("Telerik.Web.UI.Calendar.Popup");
Type.registerNamespace("Telerik.Web.UI.Calendar");
Telerik.Web.UI.Calendar.Utils={COLUMN_HEADER:1,VIEW_HEADER:2,ROW_HEADER:3,FIRST_DAY:0,FIRST_FOUR_DAY_WEEK:2,FIRST_FULL_WEEK:1,DEFAULT:7,FRIDAY:5,MONDAY:1,SATURDAY:6,SUNDAY:0,THURSDAY:4,TUESDAY:2,WEDNESDAY:3,RENDERINROWS:1,RENDERINCOLUMNS:2,NONE:4,RECURRING_DAYINMONTH:1,RECURRING_DAYANDMONTH:2,RECURRING_WEEK:4,RECURRING_WEEKANDMONTH:8,RECURRING_TODAY:16,RECURRING_WEEKDAYWEEKNUMBERANDMONTH:32,RECURRING_NONE:64,AttachMethod:function(_2f,_30){
return function(){
return _2f.apply(_30,arguments);
};
},GetDateFromId:function(id){
var arr=id.split("_");
if(arr.length<2){
return null;
}
var _33=[parseInt(arr[arr.length-3]),parseInt(arr[arr.length-2]),parseInt(arr[arr.length-1])];
return _33;
},GetRenderDay:function(_34,_35){
var _36=Telerik.Web.UI.Calendar.Utils.GetDateFromId(_35);
var _37=_34.RenderDays.Get(_36);
return _37;
},FindTarget:function(e,_39){
var _3a;
if(e&&e.target){
_3a=e.target;
}else{
if(window.event&&window.event.srcElement){
_3a=window.event.srcElement;
}
}
if(!_3a){
return null;
}
if(_3a.tagName==null&&_3a.nodeType==3&&(navigator.userAgent.match(/Safari/))){
_3a=_3a.parentNode;
}
while(_3a!=null&&_3a.tagName.toLowerCase()!="body"){
if((_3a.tagName.toLowerCase()=="th"||_3a.tagName.toLowerCase()=="td")&&Telerik.Web.UI.Calendar.Utils.FindTableElement(_3a)!=null&&Telerik.Web.UI.Calendar.Utils.FindTableElement(_3a).id.indexOf(_39)!=-1){
break;
}
_3a=_3a.parentNode;
}
if(_3a.tagName==null||(_3a.tagName.toLowerCase()!="td"&&_3a.tagName.toLowerCase()!="th")){
return null;
}
return _3a;
},FindTableElement:function(_3b){
while(_3b!=null&&_3b.tagName.toLowerCase()!="table"){
_3b=_3b.parentNode;
}
return _3b;
},GetElementPosition:function(el){
var _3d=null;
var pos={x:0,y:0};
var box;
if(el.getBoundingClientRect){
box=el.getBoundingClientRect();
var _40=document.documentElement.scrollTop||document.body.scrollTop;
var _41=document.documentElement.scrollLeft||document.body.scrollLeft;
pos.x=box.left+_41-2;
pos.y=box.top+_40-2;
return pos;
}else{
if(document.getBoxObjectFor){
box=document.getBoxObjectFor(el);
pos.x=box.x-2;
pos.y=box.y-2;
}else{
pos.x=el.offsetLeft;
pos.y=el.offsetTop;
_3d=el.offsetParent;
if(_3d!=el){
while(_3d){
pos.x+=_3d.offsetLeft;
pos.y+=_3d.offsetTop;
_3d=_3d.offsetParent;
}
}
}
}
if(window.opera){
_3d=el.offsetParent;
while(_3d&&_3d.tagName!="BODY"&&_3d.tagName!="HTML"){
pos.x-=_3d.scrollLeft;
pos.y-=_3d.scrollTop;
_3d=_3d.offsetParent;
}
}else{
_3d=el.parentNode;
while(_3d&&_3d.tagName!="BODY"&&_3d.tagName!="HTML"){
pos.x-=_3d.scrollLeft;
pos.y-=_3d.scrollTop;
_3d=_3d.parentNode;
}
}
return pos;
},MergeStyles:function(_42,_43){
if(_42.lastIndexOf(";",_42.length)!=_42.length-1){
_42+=";";
}
var _44=_43.split(";");
var _45=_42;
for(var i=0;i<_44.length-1;i++){
var _47=_44[i].split(":");
if(_42.indexOf(_47[0])==-1){
_45+=_44[i]+";";
}
}
return _45;
},MergeClassName:function(_48,_49){
var p=_49.split(" ");
if(p.length==1&&p[0]==""){
p=[];
}
var l=p.length;
for(var i=0;i<l;i++){
if(p[i]==_48){
return _49;
}
}
p[p.length]=_48;
return p.join(" ");
}};
if(typeof (RadHelperUtils)=="undefined"){
var RadHelperUtils={IsDefined:function(_4d){
if((typeof (_4d)!="undefined")&&(_4d!=null)){
return true;
}
return false;
},StringStartsWith:function(_4e,_4f){
if(typeof (_4f)!="string"){
return false;
}
return (0==_4e.indexOf(_4f));
},AttachEventListener:function(_50,_51,_52){
var _53=RadHelperUtils.CompatibleEventName(_51);
if(typeof (_50.addEventListener)!="undefined"){
_50.addEventListener(_53,_52,false);
}else{
if(_50.attachEvent){
_50.attachEvent(_53,_52);
}else{
_50["on"+_51]=_52;
}
}
},DetachEventListener:function(_54,_55,_56){
var _57=RadHelperUtils.CompatibleEventName(_55);
if(typeof (_54.removeEventListener)!="undefined"){
_54.removeEventListener(_57,_56,false);
}else{
if(_54.detachEvent){
_54.detachEvent(_57,_56);
}else{
_54["on"+_55]=null;
}
}
},CompatibleEventName:function(_58){
_58=_58.toLowerCase();
if(document.addEventListener){
if(RadHelperUtils.StringStartsWith(_58,"on")){
return _58.substr(2);
}else{
return _58;
}
}else{
if(document.attachEvent&&!RadHelperUtils.StringStartsWith(_58,"on")){
return "on"+_58;
}else{
return _58;
}
}
},MouseEventX:function(_59){
if(_59.pageX){
return _59.pageX;
}else{
if(_59.clientX){
if(RadBrowserUtils.StandardMode){
return (_59.clientX+document.documentElement.scrollLeft);
}
return (_59.clientX+document.body.scrollLeft);
}
}
},MouseEventY:function(_5a){
if(_5a.pageY){
return _5a.pageY;
}else{
if(_5a.clientY){
if(RadBrowserUtils.StandardMode){
return (_5a.clientY+document.documentElement.scrollTop);
}
return (_5a.clientY+document.body.scrollTop);
}
}
},IframePlaceholder:function(_5b,_5c){
var _5d=document.createElement("IFRAME");
_5d.src="javascript:false;";
if(RadHelperUtils.IsDefined(_5c)){
switch(_5c){
case 0:
_5d.src="javascript:void(0);";
break;
case 1:
_5d.src="about:blank";
break;
case 2:
_5d.src="blank.htm";
break;
}
}
_5d.frameBorder=0;
_5d.style.position="absolute";
_5d.style.display="none";
_5d.style.left="-500px";
_5d.style.top="-2000px";
_5d.style.height=RadHelperUtils.ElementHeight(_5b)+"px";
var _5e=0;
_5e=RadHelperUtils.ElementWidth(_5b);
_5d.style.width=_5e+"px";
_5d.style.filter="progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=0)";
_5d.allowTransparency=false;
return _5b.parentNode.insertBefore(_5d,_5b);
},ProcessIframe:function(_5f,_60,_61,_62){
if(document.readyState=="complete"&&(RadBrowserUtils.IsIE55Win||RadBrowserUtils.IsIE6Win)){
if(!(RadHelperUtils.IsDefined(_5f))){
return;
}
if(!RadHelperUtils.IsDefined(_5f.iframeShim)){
_5f.iframeShim=RadHelperUtils.IframePlaceholder(_5f);
}
_5f.iframeShim.style.top=(RadHelperUtils.IsDefined(_62))?(_62+"px"):_5f.style.top;
_5f.iframeShim.style.left=(RadHelperUtils.IsDefined(_61))?(_61+"px"):_5f.style.left;
_5f.iframeShim.style.zIndex=(_5f.style.zIndex-1);
RadHelperUtils.ChangeDisplay(_5f.iframeShim,_60);
}
},ChangeDisplay:function(_63,_64){
var obj=RadHelperUtils.GetStyleObj(_63);
if(_64!=null&&_64==true){
obj.display="";
}else{
if(_64!=null&&_64==false){
obj.display="none";
}
}
return obj.display;
},GetStyleObj:function(_66){
if(!RadHelperUtils.IsDefined(_66)){
return null;
}
if(_66.style){
return _66.style;
}else{
return _66;
}
},ElementWidth:function(_67){
if(!_67){
return 0;
}
if(RadHelperUtils.IsDefined(_67.style)){
if(RadBrowserUtils.StandardMode&&(RadBrowserUtils.IsIE55Win||RadBrowserUtils.IsIE6Win)){
if(RadHelperUtils.IsDefined(_67.offsetWidth)&&_67.offsetWidth!=0){
return _67.offsetWidth;
}
}
if(RadHelperUtils.IsDefined(_67.style.pixelWidth)&&_67.style.pixelWidth!=0){
var _68=_67.style.pixelWidth;
if(RadHelperUtils.IsDefined(_67.offsetWidth)&&_67.offsetWidth!=0){
_68=(_68<_67.offsetWidth)?_67.offsetWidth:_68;
}
return _68;
}
}
if(RadHelperUtils.IsDefined(_67.offsetWidth)){
return _67.offsetWidth;
}
return 0;
},ElementHeight:function(_69){
if(!_69){
return 0;
}
if(RadHelperUtils.IsDefined(_69.style)){
if(RadHelperUtils.IsDefined(_69.style.pixelHeight)&&_69.style.pixelHeight!=0){
return _69.style.pixelHeight;
}
}
if(_69.offsetHeight){
return _69.offsetHeight;
}
return 0;
}};
RadHelperUtils.GetElementByID=function(_6a,id){
var res=null;
for(var i=0;i<_6a.childNodes.length;i++){
if(!_6a.childNodes[i].id){
continue;
}
if(_6a.childNodes[i].id==id){
res=_6a.childNodes[i];
}
}
return res;
};
}
if(typeof (RadBrowserUtils)=="undefined"){
var RadBrowserUtils={Version:"1.0.0",IsInitialized:false,IsOsWindows:false,IsOsLinux:false,IsOsUnix:false,IsOsMac:false,IsUnknownOS:false,IsNetscape4:false,IsNetscape6:false,IsNetscape6Plus:false,IsNetscape7:false,IsNetscape8:false,IsMozilla:false,IsFirefox:false,IsSafari:false,IsIE:false,IsIEMac:false,IsIE5Mac:false,IsIE4Mac:false,IsIE5Win:false,IsIE55Win:false,IsIE6Win:false,IsIE4Win:false,IsOpera:false,IsOpera4:false,IsOpera5:false,IsOpera6:false,IsOpera7:false,IsOpera8:false,IsKonqueror:false,IsOmniWeb:false,IsCamino:false,IsUnknownBrowser:false,UpLevelDom:false,AllCollection:false,Layers:false,Focus:false,StandardMode:false,HasImagesArray:false,HasAnchorsArray:false,DocumentClear:false,AppendChild:false,InnerWidth:false,HasComputedStyle:false,HasCurrentStyle:false,HasFilters:false,HasStatus:false,Name:"",Codename:"",BrowserVersion:"",Platform:"",JavaEnabled:false,AgentString:"",Init:function(){
if(window.navigator){
this.AgentString=navigator.userAgent.toLowerCase();
this.Name=navigator.appName;
this.Codename=navigator.appCodeName;
this.BrowserVersion=navigator.appVersion.substring(0,4);
this.Platform=navigator.platform;
this.JavaEnabled=navigator.javaEnabled();
}
this.InitOs();
this.InitFeatures();
this.InitBrowser();
this.IsInitialized=true;
},CancelIe:function(){
this.IsIE=this.IsIE6Win=this.IsIE55Win=this.IsIE5Win=this.IsIE4Win=this.IsIEMac=this.IsIE5Mac=this.IsIE4Mac=false;
},CancelOpera:function(){
this.IsOpera4=this.IsOpera5=this.IsOpera6=this.IsOpera7=false;
},CancelMozilla:function(){
this.IsFirefox=this.IsMozilla=this.IsNetscape7=this.IsNetscape6Plus=this.IsNetscape6=this.IsNetscape4=false;
},InitOs:function(){
if((this.AgentString.indexOf("win")!=-1)){
this.IsOsWindows=true;
}else{
if((this.AgentString.indexOf("mac")!=-1)||(navigator.appVersion.indexOf("mac")!=-1)){
this.IsOsMac=true;
}else{
if((this.AgentString.indexOf("linux")!=-1)){
this.IsOsLinux=true;
}else{
if((this.AgentString.indexOf("x11")!=-1)){
this.IsOsUnix=true;
}else{
this.IsUnknownBrowser=true;
}
}
}
}
},InitFeatures:function(){
if((document.getElementById&&document.createElement)){
this.UpLevelDom=true;
}
if(document.all){
this.AllCollection=true;
}
if(document.layers){
this.Layers=true;
}
if(window.focus){
this.Focus=true;
}
if(document.compatMode&&document.compatMode=="CSS1Compat"){
this.StandardMode=true;
}
if(document.images){
this.HasImagesArray=true;
}
if(document.anchors){
this.HasAnchorsArray=true;
}
if(document.clear){
this.DocumentClear=true;
}
if(document.appendChild){
this.AppendChild=true;
}
if(window.innerWidth){
this.InnerWidth=true;
}
if(window.getComputedStyle){
this.HasComputedStyle=true;
}
if(document.documentElement&&document.documentElement.currentStyle){
this.HasCurrentStyle=true;
}else{
if(document.body&&document.body.currentStyle){
this.HasCurrentStyle=true;
}
}
try{
if(document.body&&document.body.filters){
this.HasFilters=true;
}
}
catch(e){
}
if(typeof (window.status)!="undefined"){
this.HasStatus=true;
}
},InitBrowser:function(){
if(this.AllCollection||(navigator.appName=="Microsoft Internet Explorer")){
this.IsIE=true;
if(this.IsOsWindows){
if(this.UpLevelDom){
if((navigator.appVersion.indexOf("MSIE 6")>0)||(document.getElementById&&document.compatMode)){
this.IsIE6Win=true;
}else{
if((navigator.appVersion.indexOf("MSIE 5.5")>0)&&document.getElementById&&!document.compatMode){
this.IsIE55Win=true;
this.IsIE6Win=true;
}else{
if(document.getElementById&&!document.compatMode&&typeof (window.opera)=="undefined"){
this.IsIE5Win=true;
}
}
}
}else{
this.IsIE4Win=true;
}
}else{
if(this.IsOsMac){
this.IsIEMac=true;
if(this.UpLevelDom){
this.IsIE5Mac=true;
}else{
this.IsIE4Mac=true;
}
}
}
}
if(this.AgentString.indexOf("opera")!=-1&&typeof (window.opera)=="undefined"){
this.IsOpera4=true;
this.IsOpera=true;
this.CancelIe();
}else{
if(typeof (window.opera)!="undefined"&&!typeof (window.print)=="undefined"){
this.IsOpera5=true;
this.IsOpera=true;
this.CancelIe();
}else{
if(typeof (window.opera)!="undefined"&&typeof (window.print)!="undefined"&&typeof (document.childNodes)=="undefined"){
this.IsOpera6=true;
this.IsOpera=true;
this.CancelIe();
}else{
if(typeof (window.opera)!="undefined"&&typeof (document.childNodes)!="undefined"){
this.IsOpera7=true;
this.IsOpera=true;
this.CancelIe();
}
}
}
}
if(this.IsOpera7&&(this.AgentString.indexOf("8.")!=-1)){
this.CancelIe();
this.CancelOpera();
this.IsOpera8=true;
this.IsOpera=true;
}
if(this.AgentString.indexOf("firefox/")!=-1){
this.CancelIe();
this.CancelOpera();
this.IsMozilla=true;
this.IsFirefox=true;
}else{
if(navigator.product=="Gecko"&&window.find){
this.CancelIe();
this.CancelOpera();
this.IsMozilla=true;
}
}
if(navigator.vendor&&navigator.vendor.indexOf("Netscape")!=-1&&navigator.product=="Gecko"&&window.find){
this.CancelIe();
this.CancelOpera();
this.IsNetscape6Plus=true;
this.IsMozilla=true;
}
if(navigator.product=="Gecko"&&!window.find){
this.CancelIe();
this.CancelOpera();
this.IsNetscape6=true;
}
if((navigator.vendor&&navigator.vendor.indexOf("Netscape")!=-1&&navigator.product=="Gecko"&&window.find)||(this.AgentString.indexOf("netscape/7")!=-1||this.AgentString.indexOf("netscape7")!=-1)){
this.CancelIe();
this.CancelOpera();
this.CancelMozilla();
this.IsMozilla=true;
this.IsNetscape7=true;
}
if((navigator.vendor&&navigator.vendor.indexOf("Netscape")!=-1&&navigator.product=="Gecko"&&window.find)||(this.AgentString.indexOf("netscape/8")!=-1||this.AgentString.indexOf("netscape8")!=-1)){
this.CancelIe();
this.CancelOpera();
this.CancelMozilla();
this.IsMozilla=true;
this.IsNetscape8=true;
}
if(navigator.vendor&&navigator.vendor=="Camino"){
this.CancelIe();
this.CancelOpera();
this.IsCamino=true;
this.IsMozilla=true;
}
if(((navigator.vendor&&navigator.vendor=="KDE")||(document.childNodes)&&(!document.all)&&(!navigator.taintEnabled))){
this.CancelIe();
this.CancelOpera();
this.IsKonqueror=true;
}
if((document.childNodes)&&(!document.all)&&(!navigator.taintEnabled)&&(navigator.accentColorName)){
this.CancelIe();
this.CancelOpera();
this.IsOmniWeb=true;
}else{
if(document.layers&&navigator.mimeTypes["*"]){
this.CancelIe();
this.CancelOpera();
this.IsNetscape4=true;
}
}
if((document.childNodes)&&(!document.all)&&(!navigator.taintEnabled)&&(!navigator.accentColorName)){
this.CancelIe();
this.CancelOpera();
this.IsSafari=true;
}else{
IsUnknownBrowser=true;
}
},DebugBrowser:function(){
var _6e="IsNetscape4 "+this.IsNetscape4+"\n";
_6e+="IsNetscape6 "+this.IsNetscape6+"\n";
_6e+="IsNetscape6Plus "+this.IsNetscape6Plus+"\n";
_6e+="IsNetscape7 "+this.IsNetscape7+"\n";
_6e+="IsNetscape8 "+this.IsNetscape8+"\n";
_6e+="IsMozilla "+this.IsMozilla+"\n";
_6e+="IsFirefox "+this.IsFirefox+"\n";
_6e+="IsSafari "+this.IsSafari+"\n";
_6e+="IsIE "+this.IsIE+"\n";
_6e+="IsIEMac "+this.IsIEMac+"\n";
_6e+="IsIE5Mac "+this.IsIE5Mac+"\n";
_6e+="IsIE4Mac "+this.IsIE4Mac+"\n";
_6e+="IsIE5Win "+this.IsIE5Win+"\n";
_6e+="IsIE55Win "+this.IsIE55Win+"\n";
_6e+="IsIE6Win "+this.IsIE6Win+"\n";
_6e+="IsIE4Win "+this.IsIE4Win+"\n";
_6e+="IsOpera "+this.IsOpera+"\n";
_6e+="IsOpera4 "+this.IsOpera4+"\n";
_6e+="IsOpera5 "+this.IsOpera5+"\n";
_6e+="IsOpera6 "+this.IsOpera6+"\n";
_6e+="IsOpera7 "+this.IsOpera7+"\n";
_6e+="IsOpera8 "+this.IsOpera8+"\n";
_6e+="IsKonqueror "+this.IsKonqueror+"\n";
_6e+="IsOmniWeb "+this.IsOmniWeb+"\n";
_6e+="IsCamino "+this.IsCamino+"\n";
_6e+="IsUnknownBrowser "+this.IsUnknownBrowser+"\n";
alert(_6e);
},DebugOS:function(){
var _6f="IsOsWindows "+this.IsOsWindows+"\n";
_6f+="IsOsLinux "+this.IsOsLinux+"\n";
_6f+="IsOsUnix "+this.IsOsUnix+"\n";
_6f+="IsOsMac "+this.IsOsMac+"\n";
_6f+="IsUnknownOS "+this.IsUnknownOS+"\n";
alert(_6f);
},DebugFeatures:function(){
var _70="UpLevelDom "+this.UpLevelDom+"\n";
_70+="AllCollection "+this.AllCollection+"\n";
_70+="Layers "+this.Layers+"\n";
_70+="Focus "+this.Focus+"\n";
_70+="StandardMode "+this.StandardMode+"\n";
_70+="HasImagesArray "+this.HasImagesArray+"\n";
_70+="HasAnchorsArray "+this.HasAnchorsArray+"\n";
_70+="DocumentClear "+this.DocumentClear+"\n";
_70+="AppendChild "+this.AppendChild+"\n";
_70+="InnerWidth "+this.InnerWidth+"\n";
_70+="HasComputedStyle "+this.HasComputedStyle+"\n";
_70+="HasCurrentStyle "+this.HasCurrentStyle+"\n";
_70+="HasFilters "+this.HasFilters+"\n";
_70+="HasStatus "+this.HasStatus+"\n";
alert(_70);
}};
RadBrowserUtils.Init();
}

