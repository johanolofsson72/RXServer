Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadToolTipControllerClass=function(){
this._tooltipToShow=null;
this._activeToolTip=null;
this._registerGlobalBodyEventHandlers();
};
Telerik.Web.UI.RadToolTipControllerClass.prototype={_registerGlobalBodyEventHandlers:function(){
var _1=Function.createDelegate(this,function(e){
if(e.keyCode==27){
if(this._activeToolTip&&!this._activeToolTip.isModal()){
this._hideCurrentToolTipUnconditionally();
}
}
});
$addHandler(document.body,"keydown",_1);
var _3=Function.createDelegate(this,function(e){
this._hideOnBodyClick(e);
});
$addHandler(document.body,"click",_3);
Sys.Application.add_unload(function(){
$removeHandler(document.body,"keydown",_1);
$removeHandler(document.body,"click",_3);
});
},_hideOnBodyClick:function(e){
var _6=false;
if(this._activeToolTip!=null&&!this._activeToolTip.isModal()){
var _7=this._activeToolTip;
if(_7._isMouseOverElement(e,_7._tableElement)){
return;
}
_6=this._activeToolTip.hide(true);
}
if(_6){
this._activeToolTip=null;
}
},_cancelLastShowRequest:function(){
if(this._tooltipToShow){
var _8=this._tooltipToShow;
this._tooltipToShow=null;
_8.cancelShowDelay();
}
},_hideCurrentToolTipUnconditionally:function(){
this._cancelLastShowRequest();
if(this._activeToolTip!=null){
this._activeToolTip.hide();
}
this._activeToolTip=null;
},requestShow:function(_9){
this._cancelLastShowRequest();
this._tooltipToShow=_9;
},cancelSpecificShowRequest:function(_a){
if(this._tooltipToShow==_a){
this._cancelLastShowRequest();
}
},showTooltip:function(_b){
if(!_b||_b.isVisible()){
return;
}
this._cancelLastShowRequest();
this.set_activeToolTip(_b);
_b.show();
},notifyToolTipClosed:function(_c){
if(this._activeToolTip==_c){
this._activeToolTip=null;
}
},set_activeToolTip:function(_d){
if(_d!=this._activeToolTip){
this._hideCurrentToolTipUnconditionally();
}
this._activeToolTip=_d;
},get_activeToolTip:function(){
return this._activeToolTip;
},getInstance:function(){
return this;
}};
Telerik.Web.UI.RadToolTipControllerClass.registerClass("Telerik.Web.UI.RadToolTipControllerClass",null);
if(!Telerik.Web.UI.RadToolTipController){
Telerik.Web.UI.RadToolTipController=new Telerik.Web.UI.RadToolTipControllerClass();
}
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadToolTip=function(_e){
Telerik.Web.UI.RadToolTip.initializeBase(this,[_e]);
this._offsetX=0;
this._offsetY=6;
this._position=Telerik.Web.UI.ToolTipPosition.BottomCenter;
this._horizontalPosition=null;
this._verticalPosition=null;
this._targetControlID=null;
this._serverTargetControlID=null;
this._serverValue="";
this._formID=null;
this._targetControl=null;
this._popupElement=null;
this._tableElement=null;
this._contentCell=null;
this._titleElement=null;
this._contentElement=null;
this._calloutElement=null;
this._closeLink=null;
this._popupBehavior=null;
this._popupVisible=false;
this._modal=false;
this._onModalShowHandler=null;
this._onModalCloseHandler=null;
this._skin="Default";
this._title="";
this._text="";
this._width="";
this._height="";
this._relativeTo=Telerik.Web.UI.ToolTipRelativeDisplay.Mouse;
this._contentScrolling=Telerik.Web.UI.ToolTipScrolling.Auto;
this._showEvent=Telerik.Web.UI.ToolTipShowEvent.OnMouseOver;
this._visibleOnPageLoad=false;
this._sticky=false;
this._manualClose=false;
this._mouseTrailing=false;
this._showCallout=true;
this._showDelayRef=null;
this._autoCloseRef=null;
this._showDelay=300;
this._autoCloseDelay=2000;
this._hideDelay=100;
this._animation=Telerik.Web.UI.ToolTipAnimation.None;
this._tooltipAnimation=null;
this._zIndex=8000;
};
Telerik.Web.UI.RadToolTip.getCurrent=function(){
var _f=Telerik.Web.UI.RadToolTipController.getInstance();
if(!_f){
return null;
}
return _f.get_activeToolTip();
};
Telerik.Web.UI.RadToolTip.prototype={get_zIndex:function(){
return this._zIndex;
},set_zIndex:function(_10){
var _11=parseInt(_10);
if(isNaN(_10)){
return;
}
if(this._zIndex!=_10){
this._zIndex=_10;
}
},initialize:function(){
Telerik.Web.UI.RadToolTip.callBaseMethod(this,"initialize");
this.set_position(this._position);
if(this._visibleOnPageLoad){
this.show();
}
},dispose:function(){
if(this._tooltipAnimation){
this._tooltipAnimation.dispose();
}
if(this._popupBehavior){
this._popupBehavior.dispose();
this._popupBehavior=null;
}
this._registerPopupHandlers(false);
this._registerMouseHandlers(this._targetControl,false);
this._makeModal(false);
if(this._closeLinkHandler&&this._closeLink){
$removeHandler(this._closeLink,"click",this._closeLinkHandler);
this._closeLinkHandler=null;
}
if(this._popupElement){
var _12=this.get_id();
if(_12){
var _13=$get(_12);
if(_13){
_13.appendChild(this._popupElement);
}
}
}
Telerik.Web.UI.RadToolTip.callBaseMethod(this,"dispose");
},isCreated:function(){
return this._popupElement!=null;
},requestShow:function(){
this._resetShowDelay();
},hide:function(_14){
if(true==_14&&this._manualClose){
return false;
}
this._hide();
return true;
},clone:function(_15,_16){
if(!_15){
alert("clone error: No target element specified");
return;
}
var evs=this._getEventsParameter();
var _18=this._getPropertiesParameter();
_18["targetControlID"]=_15.getAttribute("id");
if(!_18["targetControlID"]){
_18["targetControl"]=_15;
}
var _19=document.createElement("SPAN");
if(_16){
_19.setAttribute("id",_16);
}
var _1a=$create(Telerik.Web.UI.RadToolTip,_18,evs,null,_19);
return _1a;
},show:function(){
this._createUI();
var _1b=new Sys.CancelEventArgs();
this.raiseEvent("beforeShow",_1b);
if(_1b.get_cancel()){
return;
}
if($telerik.isIE6){
var _1c=this;
window.setTimeout(function(){
_1c._registerPopupHandlers(true);
},200);
}else{
this._registerPopupHandlers(true);
}
this._getToolTipController().set_activeToolTip(this);
this._popupBehavior.pin(false);
window.setTimeout(Function.createDelegate(this,function(){
if(this._animation==Telerik.Web.UI.ToolTipAnimation.None){
this._show();
this._afterShow();
}else{
this._playAnimation();
}
}),0);
},updateLocation:function(){
this._show();
},showLoadingMessage:function(_1d){
if(_1d){
var div=document.createElement("DIV");
div.className=this._getFullSkinName()+" LoadingSign";
this._contentCell.appendChild(div);
}else{
this._contentCell.innerHTML="";
}
},isModal:function(){
return this._modal;
},set_contentElement:function(_1f){
this._contentCell.innerHTML="";
if(_1f.parentNode&&_1f.parentNode.removeChild){
_1f.parentNode.removeChild(_1f);
}
this._contentCell.appendChild(_1f);
_1f.style.display="";
this._contentElement=_1f;
},get_contentElement:function(){
return this._contentElement;
},set_content:function(_20){
var _21=document.createElement("DIV");
_21.innerHTML=_20;
this._text=_20;
if(this.isCreated()){
this.set_contentElement(_21);
}
},get_content:function(){
return this._contentElement?this._contentElement.innerHTML:"";
},cancelAutoCloseDelay:function(){
if(this._autoCloseRef){
window.clearTimeout(this._autoCloseRef);
this._autoCloseRef=0;
}
},cancelShowDelay:function(){
if(this._showDelayRef){
window.clearTimeout(this._showDelayRef);
this._showDelayRef=null;
}
this._getToolTipController().cancelSpecificShowRequest(this);
},_getToolTipController:function(){
return Telerik.Web.UI.RadToolTipController.getInstance();
},_resetAutoCloseDelay:function(){
this.cancelAutoCloseDelay();
if(this._manualClose||this._sticky){
return;
}
if(this._autoCloseDelay){
var _22=this;
this._autoCloseRef=window.setTimeout(function(){
_22.hide(true);
},this._autoCloseDelay);
}
},_resetShowDelay:function(){
this.cancelShowDelay();
var _23=this;
var _24=function(){
_23._getToolTipController().showTooltip(_23);
_23.cancelShowDelay();
};
this._showDelayRef=window.setTimeout(_24,this._showDelay);
},_show:function(){
var _25=null;
try{
_25=this.getToolTipBounds();
}
catch(e){
var _26=this;
window.setTimeout(function(){
_26._addToolTipToDocument();
},10);
return;
}
this._setPopupVisible(_25.x,_25.y);
this._resetAutoCloseDelay();
this._popupVisible=true;
},_afterShow:function(){
this._popupBehavior.pin(this._isRelativeToBrowserWindow());
this.raiseEvent("show");
},_hide:function(){
if(this._tooltipAnimation){
this._tooltipAnimation.stop();
}
this.cancelShowDelay();
this.cancelAutoCloseDelay();
var _27=new Sys.CancelEventArgs();
this.raiseEvent("beforeHide",_27);
if(_27.get_cancel()){
return;
}
if(this._tooltipAnimation){
this._tooltipAnimation.play(true);
}else{
this._afterHide();
}
},_afterHide:function(){
try{
if(this._popupBehavior){
this._popupBehavior.hide(true);
this._popupBehavior.pin(false);
}
}
catch(ex){
}
this._popupVisible=false;
this._getToolTipController().notifyToolTipClosed(this);
this.raiseEvent("hide");
this._registerPopupHandlers(false);
},_isRelativeToBrowserWindow:function(){
if(!this._targetControl||this._relativeTo==Telerik.Web.UI.ToolTipRelativeDisplay.BrowserWindow){
return true;
}
return false;
},_playAnimation:function(){
var _28=function(){
var _29=this.controller;
var _2a=_29.getToolTipBounds();
_29._setPopupVisible(_2a.x,_2a.y);
var _2b=$telerik.getBounds(_29._popupElement);
_29._popupBehavior.hide();
this.set_endBounds(_2b);
};
if(!this._tooltipAnimation){
var pos=this._position;
var vp=this._verticalPosition;
var _2e=this._isRelativeToBrowserWindow();
if(_2e&&this._verticalPosition!=2){
vp=(this._verticalPosition==1?3:1);
pos=parseInt(vp+""+this._horizontalPosition);
}
var _2f=_2e?document.documentElement:this._targetControl;
if(this._animation==Telerik.Web.UI.ToolTipAnimation.Fade){
this._tooltipAnimation=new Telerik.Web.UI.Animations.FadeAnimation(this,null,null,this._popupElement,this._position,_2f);
this._tooltipAnimation.onShowStart=function(){
this.controller._show();
};
}else{
if(this._animation==Telerik.Web.UI.ToolTipAnimation.FlyIn){
this._tooltipAnimation=new Telerik.Web.UI.Animations.FlyInAnimation(this,null,null,this._popupElement,this._position,_2f);
this._tooltipAnimation.onShowStart=_28;
}else{
if(this._animation==Telerik.Web.UI.ToolTipAnimation.Slide){
this._tooltipAnimation=new Telerik.Web.UI.Animations.SlideAnimation(this,null,null,this._popupElement,pos,_2f);
this._tooltipAnimation.onShowStart=_28;
}else{
if(this._animation==Telerik.Web.UI.ToolTipAnimation.Resize){
if(_2e&&this._horizontalPosition!=2){
var hp=(this._horizontalPosition==1?3:1);
pos=parseInt(vp+""+hp);
}
this._tooltipAnimation=new Telerik.Web.UI.Animations.ResizeAnimation(this,0.2,50,this._popupElement,pos,_2f);
this._tooltipAnimation.onShowStart=_28;
}
}
}
}
}
if(this._tooltipAnimation){
if(this._isRelativeToBrowserWindow()){
this._documentOverflowX=document.documentElement.style.overflowX;
document.documentElement.style.overflowX="hidden";
}
this._tooltipAnimation.onShowEnd=function(){
this.controller._show();
if(null!=this.controller._documentOverflowX){
document.documentElement.style.overflowX=this.controller._documentOverflowX;
this.controller._documentOverflowX=null;
}
this.controller._afterShow();
};
this._tooltipAnimation.onHideEnd=function(){
this.controller._afterHide();
};
this._tooltipAnimation.play();
}
},_makeModal:function(_31){
if(this._onModalShowHandler){
this.remove_show(this._onModalShowHandler);
this._onModalShowHandler=null;
}
if(this._onModalCloseHandler){
this.remove_hide(this._onModalCloseHandler);
this._onModalCloseHandler=null;
}
if(this._modalExtender){
this._modalExtender.dispose();
this._modalExtender=null;
}
if(!_31){
return;
}
this._onModalShowHandler=function(_32){
if(!_32._modalExtender){
_32._modalExtender=new Telerik.Web.UI.ModalExtender(_32._popupElement);
}
_32._modalExtender.show();
};
this.add_show(this._onModalShowHandler);
this._onModalCloseHandler=function(_33){
if(_33._modalExtender){
_33._modalExtender.hide();
}
};
this.add_hide(this._onModalCloseHandler);
},_isMouseOverElement:function(e,_35){
var _36=null;
try{
_36=$telerik.getBounds(_35);
}
catch(e){
return false;
}
if(e&&e.target){
var _37=e.target.tagName;
if(_37=="SELECT"||_37=="OPTION"){
return true;
}
if(e.clientX<0||e.clientY<0){
return true;
}
}
var _38=(document.compatMode&&document.compatMode!="BackCompat")?document.documentElement:document.body;
var x=e.clientX+_38.scrollLeft;
var y=e.clientY+_38.scrollTop;
_36.x+=3;
_36.y+=2;
_36.width-=4;
_36.height-=4;
var _3b=$telerik.containsPoint(_36,x,y);
return _3b;
},_onMouseOver:function(e){
this._logMousePosition(e);
this._resetShowDelay();
this._getToolTipController().requestShow(this);
if(e){
}
},_onMouseMove:function(e){
this._logMousePosition(e);
this._resetAutoCloseDelay();
if(this._mouseTrailing&&this.isVisible()){
this._show();
}
},_onMouseOut:function(e){
var _3f=this._isMouseOverElement(e,this._targetControl);
if(!_3f){
this.cancelShowDelay();
if(!this._sticky){
if(this._hideDelay>0){
var _40=this;
window.setTimeout(function(){
_40.hide(true);
},this._hideDelay);
}else{
this.hide(true);
}
}
}
},_onClick:function(e){
this._onMouseOver(e);
return $telerik.cancelRawEvent(e);
},_onRightClick:function(e){
this._onMouseOver(e);
return $telerik.cancelRawEvent(e);
},_registerMouseHandlers:function(_43,_44){
if(true==_44){
var _45={};
var _46=Telerik.Web.UI.ToolTipShowEvent;
if(this._showEvent==_46.OnMouseOver){
this._onMouseOverDelegate=Function.createDelegate(this,this._onMouseOver);
this._onMouseMoveDelegate=Function.createDelegate(this,this._onMouseMove);
this._onMouseOutDelegate=Function.createDelegate(this,this._onMouseOut);
$addHandler(_43,"mouseover",this._onMouseOverDelegate);
$addHandler(_43,"mousemove",this._onMouseMoveDelegate);
$addHandler(_43,"mouseout",this._onMouseOutDelegate);
}
if(this._showEvent==_46.OnClick){
this._onClickDelegate=Function.createDelegate(this,this._onClick);
$addHandler(_43,"click",this._onClickDelegate);
}
if(this._showEvent==_46.OnRightClick){
this._onRightClickDelegate=Function.createDelegate(this,this._onRightClick);
$addHandler(_43,"contextmenu",this._onRightClickDelegate);
}
if(this._showEvent==_46.OnFocus){
this._onFocusDelegate=Function.createDelegate(this,this._onMouseOver);
this._onBlurDelegate=Function.createDelegate(this,this._onMouseOut);
$addHandler(_43,"focus",this._onFocusDelegate);
$addHandler(_43,"blur",this._onBlurDelegate);
}
}else{
if(_43){
var _47=[["mouseover",this._onMouseOverDelegate],["mousemove",this._onMouseMoveDelegate],["mouseout",this._onMouseOutDelegate],["click",this._onClickDelegate],["contextmenu",this._onRightClickDelegate],["focus",this._onFocusDelegate],["blur",this._onBlurDelegate]];
for(var i=0;i<_47.length;i++){
var _49=_47[i];
try{
if(null!=_49[1]){
$removeHandler(_43,_49[0],_49[1]);
}
}
catch(e){
}
}
this._onMouseOverDelegate=null;
this._onMouseMoveDelegate=null;
this._onMouseOutDelegate=null;
this._onClickDelegate=null;
this._onRightClickDelegate=null;
this._onFocusDelegate=null;
this._onBlurDelegate=null;
}
}
},_registerPopupHandlers:function(_4a){
if(true==_4a){
if(this._sticky||this._position==Telerik.Web.UI.ToolTipPosition.Center){
this._popupStickyHandler=Function.createDelegate(this,this._onPopupStickyMouseOut);
$addHandler(this._tableElement,"mouseout",this._popupStickyHandler);
this.set_sticky(true);
}
}else{
if(this._popupStickyHandler){
$removeHandler(this._tableElement,"mouseout",this._popupStickyHandler);
this._popupStickyHandler=null;
}
}
},_onPopupStickyMouseOut:function(e){
var _4c=this._isMouseOverElement(e,this._tableElement);
if(!_4c&&!this._manualClose){
this.hide();
}
},_getPropertiesParameter:function(){
if(!this._propertiesParameter){
var _4d={};
for(var _4e in Telerik.Web.UI.RadToolTip.prototype){
var _4f=this[_4e];
if(typeof (_4f)=="function"&&_4e.indexOf("get_")==0){
var _50=_4e.substring(4);
if(null==this["set_"+_50]){
continue;
}
var _51=_4f.call(this);
if(null==_51){
continue;
}
_4d[_50]=_51;
if(_50=="skin"){
break;
}
}
}
this._propertiesParameter=_4d;
}
var _52=this._cloneObject(this._propertiesParameter);
return _52;
},_getEventsParameter:function(){
if(!this._eventsParameter){
var _53={};
var _54=this.get_events();
var _55=["beforeShow","show","beforeHide","hide"];
for(var i=0;i<_55.length;i++){
var _57=_55[i];
var _58=_54.getHandler(_57);
if(_58&&typeof (eval(_58))=="function"){
_53[_57]=eval(_58);
}
}
this._eventsParameter=_53;
}
return this._eventsParameter;
},_cloneObject:function(_59){
var _5a={};
for(var _5b in _59){
_5a[_5b]=_59[_5b];
}
return _5a;
},_getPosRelativeToMouse:function(_5c){
var _5d=_5c.x;
var _5e=_5c.y;
var pos=this._getMousePosition();
var _60=pos.clientX;
var _61=pos.clientY;
var _62=$telerik.standardsMode;
if(!$telerik.isIE&&document.compatMode!="CSS1Compat"){
_62=false;
}
if(_62){
_5d-=document.documentElement.scrollLeft;
_5e-=document.documentElement.scrollTop;
}else{
_5d-=document.body.scrollLeft;
_5e-=document.body.scrollTop;
}
var _63=_60-_5d;
var _64=_61-_5e;
return {x:_63,y:_64};
},_logMousePosition:function(e){
if(!e){
return;
}
this._mouseX=e.clientX;
this._mouseY=e.clientY;
},_getMousePosition:function(){
var obj={};
obj.clientX=this._mouseX;
obj.clientY=this._mouseY;
return obj;
},_getCalloutBounds:function(){
var _67={width:0,height:0,marginLeft:0,marginTop:0};
if(this._showCallout&&this._calloutElement){
_67.marginLeft=parseInt($telerik.getCurrentStyle(this._calloutElement,"marginLeft"));
_67.marginTop=parseInt($telerik.getCurrentStyle(this._calloutElement,"marginTop"));
if(isNaN(_67.marginLeft)){
_67.marginLeft=0;
}
if(isNaN(_67.marginLeft)){
_67.marginLeft=0;
}
var _68=$telerik.getBounds(this._calloutElement);
if(_68){
if(_68.width){
_67.width=_68.width;
}
if(_68.height){
_67.height=_68.height;
}
}
}
return _67;
},_getBoundsRelativeToBrowser:function(_69,_6a,_6b){
var _6c=this._horizontalPosition;
var _6d=this._verticalPosition;
var x=0;
var y=0;
if(!_6b){
_6b=$telerik.getClientBounds();
}
var _70=$telerik.getScrollOffset(document.compatMode&&document.compatMode!="BackCompat"?document.documentElement:document.body);
if("fixed"!=this._popupElement.style.position){
x+=_70.x;
y+=_70.y;
}
switch(_6c){
case 2:
x+=-parseInt(_69.width/2-_6b.width/2);
x+=this._offsetX;
break;
case 3:
x+=_6b.width;
x-=_69.width;
x-=this._offsetX;
break;
case 1:
default:
x+=-_69.width;
x+=(-_6a.width-_6a.marginLeft);
x+=this._offsetX;
break;
}
switch(_6d){
case 2:
y+=-parseInt((_69.height-_6b.height)/2);
break;
case 1:
y+=this._offsetY;
break;
case 3:
default:
y+=_6b.height;
y-=this._offsetY;
y-=_69.height;
break;
}
return new Sys.UI.Bounds(x,y,_69.width,_69.height);
},_getBoundsRelativeToElement:function(_71,_72,_73){
var _74=this._horizontalPosition;
var _75=this._verticalPosition;
var x=0;
var y=0;
if(!_73){
_73=$telerik.getBounds(this._targetControl);
}
switch(_74){
case 2:
x+=-parseInt(_71.width/2-_73.width/2);
x+=this._offsetX;
break;
case 3:
x+=_73.width;
x-=_72.marginLeft;
x+=this._offsetX;
break;
case 1:
default:
x+=-_71.width;
x+=(-_72.width-_72.marginLeft);
x-=this._offsetX;
break;
}
switch(_75){
case 2:
y+=-parseInt(_71.height/2-_73.height/2);
y+=this._offsetY;
break;
case 1:
y-=_71.height;
y-=_72.height+_72.marginTop;
y-=this._offsetY;
break;
case 3:
default:
y+=_73.height;
y-=_72.marginTop;
y+=this._offsetY;
break;
}
return new Sys.UI.Bounds(x,y,_71.width,_71.height);
},_getBoundsRelativeToMouse:function(_78,_79,_7a){
var _7a=this._targetControl?$telerik.getBounds(this._targetControl):$telerik.getClientBounds();
var pos=this._getPosRelativeToMouse(_7a);
if(isNaN(pos.x)){
pos.x=0;
pos.y=0;
}else{
_7a.width=0;
_7a.height=0;
}
var _7c=this._getBoundsRelativeToElement(_78,_79,_7a);
var _7d=new Sys.UI.Bounds(pos.x+_7c.x,pos.y+_7c.y,_78.width,_78.height);
return _7d;
},getToolTipBounds:function(){
var _7e=this._popupElement;
var _7f=(_7e.style.display=="none")?true:false;
_7e.style.left="-3000px";
_7e.style.top="-3000px";
_7e.style.display="";
this._setOverflow();
if(this._firstShow!=true){
this._fixIeHeight(this._tableElement,this._height);
this._firstShow=true;
}
var _80=this._isRelativeToBrowserWindow()?document.documentElement:this._targetControl;
this._popupBehavior.set_parentElement(_80);
var _81=$telerik.getBounds(_7e);
var _82=this._getCalloutBounds();
if(_7f){
this._popupElement.style.display="none";
}
var _83=Telerik.Web.UI.ToolTipRelativeDisplay;
var _84=Telerik.Web.UI.ToolTipShowEvent;
var _85=null;
if(this._relativeTo==_83.BrowserWindow){
_85=this._getBoundsRelativeToBrowser(_81,_82);
}else{
if(!this._targetControl&&this._showEvent==_84.FromCode){
_85=this._getBoundsRelativeToBrowser(_81,_82);
}else{
if(this._targetControl&&this._showEvent==_84.FromCode){
_85=this._getBoundsRelativeToElement(_81,_82);
}else{
if((this._mouseTrailing||this._relativeTo==_83.Mouse)){
_85=this._getBoundsRelativeToMouse(_81,_82);
}else{
if(this._relativeTo==_83.Element){
_85=this._getBoundsRelativeToElement(_81,_82);
}
}
}
}
}
return _85;
},_fixIeHeight:function(_86,_87){
if("CSS1Compat"==document.compatMode){
var _88=(_86.offsetHeight-parseInt(_87));
if(_88>0){
var _89=(parseInt(_86.style.height)-_88);
if(_89>0){
_86.style.height=_89+"px";
}
}
}
},_refreshTitle:function(){
if(null==this._titleElement){
return;
}
this._titleElement.innerHTML=this._title;
this._titleElement.style.display=(this._title)?"":"none";
},_createUI:function(){
if(!this._popupElement){
var _8a=this.get_id();
var _8b="RadToolTipWrapper_"+_8a;
var _8c=document.createElement("DIV");
_8c.id=_8b;
_8c.className=this._getFullSkinName()+(this.get_showCallout()?" visiblecallout":"");
_8c.setAttribute("unselectable","on");
this._popupElement=_8c;
var _8d=document.createElement("DIV");
_8d.className="ToolTipCallout "+this._getCalloutPosition(this._position);
_8d.innerHTML="&nbsp;";
this._calloutElement=_8d;
var _8e=document.createElement("TABLE");
_8e.className="ToolTipWrapper";
_8e.style.width=this._width;
_8e.style.height=this._height;
this._tableElement=_8e;
var _8f=["ToolTipTopLeft","ToolTipTopCenter","ToolTipTopRight","ToolTipLeftMiddle","ToolTipContent","ToolTipRightMiddle","ToolTipBottomLeft","ToolTipBottomCenter","ToolTipBottomRight"];
var _90=0;
for(var i=1;i<=3;i++){
var _92=_8e.insertRow(-1);
for(var j=1;j<=3;j++){
var _94=_92.insertCell(-1);
_94.innerHTML="&nbsp;";
_94.className=_8f[_90];
_90++;
}
}
var _95=_8e.rows[0].cells[1];
_95.innerHTML="";
var _96=document.createElement("DIV");
_96.className="ToolTipTitlebar VisibleTitlebar";
_96.style.display="none";
this._titleElement=_96;
this._refreshTitle();
_95.appendChild(_96);
if(this._manualClose){
var _97=document.createElement("A");
_97.href="javascript: void(0);";
_97.className="CloseButton";
this._closeLinkHandler=Function.createDelegate(this,function(e){
this.hide();
if(e){
e.returnValue=false;
e.cancelBubble=true;
if(e.stopPropagation){
e.stopPropagation();
}
}
return false;
});
$addHandler(_97,"click",this._closeLinkHandler);
this._closeLink=_97;
var _99=document.createElement("SPAN");
_99.innerHTML="Close";
_97.title="Close";
_97.appendChild(_99);
_95.appendChild(_97);
}
var _9a=_8e.rows[1].cells[1];
_9a.vAlign="top";
_9a.innerHTML="";
this._contentCell=_9a;
var _9b=null;
var _9c=this._targetControl;
var _9d=this.get_text();
var _9b=null;
var _9e=this.get_text();
if(this._targetControl&&!_9e){
_9e=this._targetControl.getAttribute("title");
if(_9e){
this._targetControl.removeAttribute("title");
}
this._text=_9e;
}
if(this._text){
this.set_content(this._text);
}else{
var _9f=this.get_id();
if(_9f){
_9b=$get(_9f);
}
if(_9b&&_9b.innerHTML){
var _a0=this._transferNodeChildren(_9b);
this.set_contentElement(_a0);
}
}
_8c.appendChild(_8d);
_8c.appendChild(_8e);
this._popupElement.style.display="none";
this._popupElement.style.position="absolute";
this._addToolTipToDocument(_9b);
}
if(!this._popupBehavior){
this._popupBehavior=$create(Telerik.Web.PopupBehavior,{"id":(new Date()-100)+"PopupBehavior","parentElement":this._targetControl},null,null,this._popupElement);
}
},_transferNodeChildren:function(_a1){
if(!_a1){
return null;
}
var _a2=_a1.ownerDocument.createElement(_a1.tagName);
var _a3=0;
while(_a1.childNodes&&_a1.childNodes.length>_a3){
var _a4=_a1.childNodes[_a3];
if(this._clientStateFieldID&&_a4.id==this._clientStateFieldID){
_a3=1;
continue;
}
_a1.removeChild(_a4);
_a2.appendChild(_a4);
}
return _a2;
},_addToolTipToDocument:function(_a5){
if(null!=_a5){
_a5.parentNode.insertBefore(this._popupElement,_a5);
return;
}
var _a6=document.getElementById(this._formID);
if(!_a6){
_a6=document.forms[0];
}
_a6.appendChild(this._popupElement);
},_getParentByTagName:function(_a7,_a8){
var _a9=_a7;
_a8=_a8.toUpperCase();
while(_a9.tagName.toUpperCase()!=_a8){
_a9=_a9.parentNode;
if(!_a9){
break;
}
}
return _a9;
},_getFullSkinName:function(){
return "radtooltip_"+this._skin;
},_getUniqueString:function(){
return ""+(new Date()-100);
},_getCalloutPosition:function(_aa){
with(Telerik.Web.UI.ToolTipPosition){
switch(_aa){
case TopLeft:
return "BottomRight";
case TopCenter:
return "BottomCenter";
case TopRight:
return "BottomLeft";
case MiddleLeft:
return "MiddleRight";
case Center:
return "Center";
case MiddleRight:
return "MiddleLeft";
case BottomLeft:
return "TopRight";
case BottomCenter:
return "TopCenter";
case BottomRight:
return "TopLeft";
}
}
return "";
},_getHorizontalSide:function(_ab){
return parseInt((_ab+"").charAt(1));
},_getVerticalSide:function(_ac){
return parseInt((_ac+"").charAt(0));
},_setPopupVisible:function(x,y){
this._popupBehavior.set_x(x);
this._popupBehavior.set_y(y);
this._popupBehavior.show();
if(!this.get_width()){
this._popupElement.style.width="";
}
this._popupElement.style.zIndex=this._zIndex;
},_setOverflow:function(){
var _af=this._contentScrolling;
if(_af==Telerik.Web.UI.ToolTipScrolling.Auto){
return;
}
var el=this._contentElement;
if(!el){
return;
}
var _b1="";
with(Telerik.Web.UI.ToolTipScrolling){
switch(_af){
case Auto:
_b1="auto";
break;
case None:
_b1="hidden";
break;
case X:
_b1="";
el.style.overflowX="scroll";
break;
case Y:
_b1="";
el.style.overflowY="scroll";
break;
case Both:
_b1="scroll";
}
}
var _b2=el.parentNode;
el.style.display="none";
var _b3=$telerik.getBounds(_b2).height;
el.style.height=_b3+"px";
if(!el.style.overflowX&&!el.style.overflowY){
el.style.overflow=_b1;
}
el.style.display="";
},_getLeftOffset:function(){
var _b4=Telerik.Web.UI.ToolTipPosition;
if(_b4.Left==this._position){
return (-1*this._targetControl.offsetWidth)+this._offsetX;
}else{
if(_b4.Right==this._position){
return this._targetControl.offsetWidth+this._offsetX;
}else{
return this._offsetX;
}
}
},_getTopOffset:function(){
var _b5;
var _b6=Telerik.Web.UI.ToolTipPosition;
if(_b6.Top==this._position){
_b5=(-1*this._targetControl.offsetHeight)+this._offsetY;
}else{
if(_b6.Bottom==this._position){
_b5=this._targetControl.offsetHeight+this._offsetY;
}else{
_b5=this._offsetY;
}
}
return _b5;
},isVisible:function(){
return this._popupVisible;
},get_targetControlID:function(){
return this._targetControlID;
},set_targetControlID:function(_b7){
if(this._targetControlID!=_b7){
this._targetControlID=_b7;
var _b8=(this._targetControlID?$get(this._targetControlID):null);
this.set_targetControl(_b8);
}
},get_targetControl:function(){
return this._targetControl;
},set_targetControl:function(_b9){
if(this._targetControl!=_b9){
if(this._targetControl&&(this._targetControl!=_b9)){
this._registerMouseHandlers(this._targetControl,false);
}
this._targetControl=_b9;
var _ba=this._targetControl;
if(_ba){
if($telerik.isIE&&_ba){
_ba.removeAttribute("alt");
}
this._registerMouseHandlers(_ba,true);
if(this._popupBehavior){
this._popupBehavior.set_parentElement(_ba);
}
}
}
},get_serverTargetControlID:function(){
return this._serverTargetControlID;
},set_serverTargetControlID:function(_bb){
this._serverTargetControlID=_bb;
},get_serverValue:function(){
return this._serverValue;
},set_serverValue:function(_bc){
this._serverValue=_bc;
},get_value:function(){
return this.get_serverValue();
},set_value:function(_bd){
this.set_serverValue(_bd);
},get_formID:function(){
return this._formID;
},set_formID:function(_be){
if(this._formID!=_be){
this._formID=_be;
}
},get_position:function(){
return this._position;
},set_position:function(_bf){
if(this._position!=_bf){
this._position=_bf;
if(this._calloutElement){
this._calloutElement.className="ToolTipCallout "+this._getCalloutPosition(this._position);
}
}
this._horizontalPosition=this._getHorizontalSide(this._position);
this._verticalPosition=this._getVerticalSide(this._position);
},get_offsetX:function(){
return this._offsetX;
},set_offsetX:function(_c0){
if(this._offsetX!=_c0){
this._offsetX=_c0;
}
},get_offsetY:function(){
return this._offsetY;
},set_offsetY:function(_c1){
if(this._offsetY!=_c1){
this._offsetY=_c1;
}
},get_title:function(){
return this._title;
},set_title:function(_c2){
if(this._title!=_c2){
this._title=_c2;
}
this._refreshTitle();
},get_text:function(){
return this._text;
},set_text:function(_c3){
if(this._text!=_c3){
this._text=_c3;
}
if(this.isCreated()){
this.set_content(this._text);
}
},get_width:function(){
return this._width;
},set_width:function(_c4){
if(this._width!=_c4){
this._width=_c4;
}
},get_height:function(){
return this._height;
},set_height:function(_c5){
if(this._height!=_c5){
this._height=_c5;
}
},get_relativeTo:function(){
return this._relativeTo;
},set_relativeTo:function(_c6){
if(this._relativeTo!=_c6){
this._relativeTo=_c6;
}
},get_contentScrolling:function(){
return this._contentScrolling;
},set_contentScrolling:function(_c7){
if(this._contentScrolling!=_c7){
this._contentScrolling=_c7;
}
},get_sticky:function(){
return this._sticky;
},set_sticky:function(_c8){
if(this._sticky!=_c8){
this._sticky=_c8;
}
},get_manualClose:function(){
return this._manualClose;
},set_manualClose:function(_c9){
if(this._manualClose!=_c9){
this._manualClose=_c9;
}
},get_showCallout:function(){
return this._showCallout;
},set_showCallout:function(_ca){
if(this._showCallout!=_ca){
this._showCallout=_ca;
}
},get_showDelay:function(){
return this._showDelay;
},set_showDelay:function(_cb){
if(this._showDelay!=_cb){
this._showDelay=_cb;
}
},get_autoCloseDelay:function(){
return this._autoCloseDelay;
},set_autoCloseDelay:function(_cc){
if(this._autoCloseDelay!=_cc){
this._autoCloseDelay=_cc;
}
},get_hideDelay:function(){
return this._hideDelay;
},set_hideDelay:function(_cd){
if(this._hideDelay!=_cd){
this._hideDelay=_cd;
}
},get_mouseTrailing:function(){
return this._mouseTrailing;
},set_mouseTrailing:function(_ce){
if(this._mouseTrailing!=_ce){
this._mouseTrailing=_ce;
if(true==_ce){
this.set_relativeTo(Telerik.Web.UI.ToolTipRelativeDisplay.Mouse);
}
}
},get_visibleOnPageLoad:function(){
return this._visibleOnPageLoad;
},set_visibleOnPageLoad:function(_cf){
if(this._visibleOnPageLoad!=_cf){
this._visibleOnPageLoad=_cf;
}
},get_animation:function(){
return this._animation;
},set_animation:function(_d0){
if(this._animation!=_d0){
this._animation=_d0;
}
},get_showEvent:function(){
return this._showEvent;
},set_showEvent:function(_d1){
if(this._showEvent!=_d1){
this._showEvent=_d1;
}
},get_skin:function(){
return this._skin;
},set_skin:function(_d2){
if(_d2&&this._skin!=_d2){
this._skin=_d2;
}
},get_popupElement:function(){
return this._popupElement;
},get_modal:function(){
return this._modal;
},set_modal:function(_d3){
if(this._modal!=_d3){
this._modal=_d3;
}
this._makeModal(this._modal);
},add_beforeShow:function(_d4){
this.get_events().addHandler("beforeShow",_d4);
},remove_beforeShow:function(_d5){
this.get_events().removeHandler("beforeShow",_d5);
},add_show:function(_d6){
this.get_events().addHandler("show",_d6);
},remove_show:function(_d7){
this.get_events().removeHandler("show",_d7);
},add_beforeHide:function(_d8){
this.get_events().addHandler("beforeHide",_d8);
},remove_beforeHide:function(_d9){
this.get_events().removeHandler("beforeHide",_d9);
},add_hide:function(_da){
this.get_events().addHandler("hide",_da);
},remove_hide:function(_db){
this.get_events().removeHandler("hide",_db);
},saveClientState:function(){
var _dc=["text","position"];
var _dd={};
for(var i=0;i<_dc.length;i++){
_dd[_dc[i]]=this["get_"+_dc[i]]();
}
return Sys.Serialization.JavaScriptSerializer.serialize(_dd);
}};
Telerik.Web.UI.RadToolTip.registerClass("Telerik.Web.UI.RadToolTip",Telerik.Web.UI.RadWebControl);
Telerik.Web.UI.ToolTipPosition=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.ToolTipPosition.prototype={TopLeft:11,TopCenter:12,TopRight:13,MiddleLeft:21,Center:22,MiddleRight:23,BottomLeft:31,BottomCenter:32,BottomRight:33};
Telerik.Web.UI.ToolTipPosition.registerEnum("Telerik.Web.UI.ToolTipPosition",false);
Telerik.Web.UI.ToolTipRelativeDisplay=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.ToolTipRelativeDisplay.prototype={Mouse:0,Element:1,BrowserWindow:2};
Telerik.Web.UI.ToolTipRelativeDisplay.registerEnum("Telerik.Web.UI.ToolTipRelativeDisplay",false);
Telerik.Web.UI.ToolTipScrolling=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.ToolTipScrolling.prototype={Auto:0,None:1,X:2,Y:3,Both:4};
Telerik.Web.UI.ToolTipScrolling.registerEnum("Telerik.Web.UI.ToolTipScrolling",false);
Telerik.Web.UI.ToolTipAnimation=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.ToolTipAnimation.prototype={None:0,Resize:1,Fade:2,Slide:4,FlyIn:8};
Telerik.Web.UI.ToolTipAnimation.registerEnum("Telerik.Web.UI.ToolTipAnimation",false);
Telerik.Web.UI.ToolTipShowEvent=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.ToolTipShowEvent.prototype={OnMouseOver:1,OnClick:2,OnRightClick:4,OnFocus:8,FromCode:16};
Telerik.Web.UI.ToolTipShowEvent.registerEnum("Telerik.Web.UI.ToolTipShowEvent",false);

