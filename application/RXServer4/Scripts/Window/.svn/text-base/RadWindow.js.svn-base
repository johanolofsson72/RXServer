Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadWindowControllerClass=function(){
this._activeWindow=null;
this._historyStack=[];
this._registerGlobalBodyEventHandlers();
};
Telerik.Web.UI.RadWindowControllerClass.prototype={getInstance:function(){
return this;
},_registerGlobalBodyEventHandlers:function(){
var _1=Function.createDelegate(null,function(e){
if(e.keyCode==27){
Telerik.Web.UI.RadWindowController.hideCurrentWindowIfNonModal();
}
});
$addHandler(document.documentElement,"keydown",_1);
Sys.Application.add_unload(function(){
$removeHandler(document.documentElement,"keydown",_1);
});
},hideCurrentWindowIfNonModal:function(){
if(this._activeWindow!=null&&this._activeWindow.isModal&&!this._activeWindow.isModal()){
this._activeWindow.close();
}
this._activeWindow=null;
},inactivateCurrentWindow:function(){
if(this._activeWindow!=null){
this._activeWindow.setActive(false);
}
this._activeWindow=null;
},set_activeWindow:function(_3){
if(_3==this._activeWindow){
return;
}
this.inactivateCurrentWindow();
this._activeWindow=_3;
Array.remove(this._historyStack,_3);
Array.add(this._historyStack,_3);
},notifyWindowClosed:function(_4){
if(this._activeWindow==_4){
this._activeWindow=null;
}
Array.remove(this._historyStack,_4);
this._activatePreviousWindow();
},_activatePreviousWindow:function(){
var _5=this._historyStack;
var i=_5.length-1;
for(;i>=0;i--){
var _7=_5[i];
if(!_7){
return;
}
if(_7.isCreated()&&!_7.isClosed()&&!_7.isMinimized()){
_7.setActive(true);
break;
}else{
Array.removeAt(_5,i);
}
}
},get_activeWindow:function(){
return this._activeWindow;
}};
Telerik.Web.UI.RadWindowControllerClass.registerClass("Telerik.Web.UI.RadWindowControllerClass",null);
if(!Telerik.Web.UI.RadWindowController){
Telerik.Web.UI.RadWindowController=new Telerik.Web.UI.RadWindowControllerClass();
}
Type.registerNamespace("Telerik.Web.UI");
Type.registerNamespace("Telerik.Web.UI.RadWindowUtils");
Telerik.Web.UI.RadWindowUtils.Localization={"Close":"Close","Minimize":"Minimize","Maximize":"Maximize","Reload":"Reload","PinOn":"Pin on","PinOff":"Pin off","Restore":"Restore","OK":"OK","Cancel":"Cancel","Yes":"Yes","No":"No"};
Telerik.Web.UI.RadWindow=function(_8){
Telerik.Web.UI.RadWindow.initializeBase(this,[_8]);
this._eventNames=["resize","activate","dragStart","dragEnd","show","pageLoad","close","command"];
this._bodyElement=($telerik.standardsMode)?document.documentElement:document.body;
this._openerElement=null;
this._offsetElement=null;
this._popupElement=null;
this._tableElement=null;
this._contentElement=null;
this._contentCell=null;
this._titleElement=null;
this._titleCell=null;
this._titlebarElement=null;
this._statusCell=null;
this._statusMessageElement=null;
this._iframe=null;
this._buttonsElement=null;
this._buttonsArray=[];
this.isIE=($telerik.isIE);
this._openerElementID=null;
this._offsetElementID=null;
this._behaviors=Telerik.Web.UI.WindowBehaviors.Default;
this._initialBehaviors=Telerik.Web.UI.WindowBehaviors.None;
this._navigateUrl=null;
this._left="";
this._top="";
this._formID=null;
this._skin="Default";
this._title="";
this._width="300px";
this._height="300px";
this._minimizeZoneID=null;
this._restrictionZoneID="";
this._clientCallBackFunction=null;
this._reloadOnShow=false;
this._visibleOnPageLoad=false;
this._destroyOnClose=false;
this._visibleTitlebar=true;
this._visibleStatusbar=true;
this._showContentDuringLoad=true;
this._modal=false;
this._overlay=false;
this._keepInScreenBounds=false;
this._iconUrl=null;
this._minimizeIconUrl=null;
this._animation=Telerik.Web.UI.WindowAnimation.None;
this._windowAnimation=null;
this._onMouseDownDelegate=null;
this._onClickDelegate=null;
this._onTitlebarDblclickDelegate=null;
this._onTitlebarClickDelegate=null;
this._onWindowResizeDelegate=null;
this._onIframeLoadDelegate=null;
this._onChildPageUnloadDelegate=null;
this._onChildPageClickDelegate=null;
this._onModalShowHandler=null;
this._onModalCloseHandler=null;
this._loaded=false;
this._isCloned=false;
this._restoreRect=null;
this._popupBehavior=null;
this._popupVisible=false;
this._windowManager;
this.GetWindowManager=this.get_windowManager;
this.BrowserWindow=window;
this.GetContentFrame=this.get_contentFrame;
this.GetLeftPosition=function(){
this.getWindowBounds().x;
};
this.GetTopPosition=function(){
this.getWindowBounds().y;
};
this.GetTitlebar=function(){
return this._titleCell;
};
this.GetStatusbar=function(){
return this._statusCell;
};
this.SetOpenerElementId=this.set_openerElementID;
this.SetStatus=this.set_status;
this.GetStatus=this.get_status;
this.SetModal=this.set_modal;
this.SetWidth=this.set_width;
this.SetHeight=this.set_height;
this.GetWidth=this.get_width;
this.GetHeight=this.get_height;
this.SetOffsetElementId=this.set_offsetElementID;
this.SetTitle=this.set_title;
this.MoveTo=this.moveTo;
this.Center=this.center;
this.SetVisible=this.setVisible;
this.SetSize=this.setSize;
this.Show=this.show;
this.Hide=this.hide;
this.GetUrl=this.get_navigateUrl;
this.SetUrl=this.setUrl;
this.Reload=this.reload;
this.SetActive=this.setActive;
this.Minimize=this.minimize;
this.Restore=this.restore;
this.Maximize=this.maximize;
this.Close=this.close;
this.TogglePin=this.togglePin;
this.IsMaximized=this.isMaximized;
this.IsMinimized=this.isMinimized;
this.IsModal=this.isModal;
this.IsClosed=this.isClosed;
this.IsPinned=this.isPinned;
this.IsVisible=this.isVisible;
this.IsActive=this.isActive;
this.IsBehaviorEnabled=this.isBehaviorEnabled;
};
Telerik.Web.UI.RadWindow.prototype={_getLocalization:function(){
return Telerik.Web.UI.RadWindowUtils.Localization;
},_registerIframeLoadHandler:function(_9){
if(!this._iframe){
return;
}
if(_9){
this._onIframeLoadDelegate=Function.createDelegate(this,this._onIframeLoad);
$addHandler(this._iframe,"load",this._onIframeLoadDelegate);
}else{
if(this._onIframeLoadDelegate){
$removeHandler(this._iframe,"load",this._onIframeLoadDelegate);
this._onIframeLoadDelegate=null;
}
}
},_registerWindowResizeHandler:function(_a){
if(_a){
this._onWindowResizeDelegate=Function.createDelegate(this,this._maintainMaximizedSize);
$addHandler(window,"resize",this._onWindowResizeDelegate);
}else{
if(this._onWindowResizeDelegate){
$removeHandler(window,"resize",this._onWindowResizeDelegate);
this._onWindowResizeDelegate=null;
}
}
},_registerOpenerElementHandler:function(_b,_c){
if(!_b){
return;
}
if(true==_c){
this._onClickDelegate=Function.createDelegate(this,this._onClick);
$addHandler(_b,"click",this._onClickDelegate);
}else{
var _d=$removeHandler(_b,"click",this._onClickDelegate);
this._onClickDelegate=null;
}
},_registerTitlebarHandlers:function(_e){
var _f=this._titleCell;
if(_e){
this._onTitlebarDblclickDelegate=Function.createDelegate(this,function(){
if(this.isMinimized()||this.isMaximized()){
this.restore();
}else{
this.maximize();
}
});
this._onTitlebarClickDelegate=Function.createDelegate(this,function(){
this.setActive(true);
});
$addHandler(_f,"dblclick",this._onTitlebarDblclickDelegate);
$addHandler(_f,"click",this._onTitlebarClickDelegate);
}else{
if(this._titleCell){
if(this._onTitlebarDblclickDelegate){
$removeHandler(_f,"dblclick",this._onTitlebarDblclickDelegate);
this._onTitlebarDblclickDelegate=null;
}
if(this._onTitlebarClickDelegate){
$removeHandler(_f,"click",this._onTitlebarClickDelegate);
this._onTitlebarClickDelegate=null;
}
}
}
},_makeModal:function(_10){
if(this._onModalShowHandler){
this.remove_show(this._onModalShowHandler);
this._onModalShowHandler=null;
}
if(this._onModalCloseHandler){
this.remove_close(this._onModalCloseHandler);
this._onModalCloseHandler=null;
}
if(this._modalExtender){
this._modalExtender.dispose();
this._modalExtender=null;
}
if(!_10){
return;
}
if(typeof (Telerik.Web.UI.RadWindowManager)!="undefined"&&Telerik.Web.UI.RadWindowManager.isInstanceOfType(this)){
return;
}
this._onModalShowHandler=function(_11){
if(!_11._modalExtender){
_11._modalExtender=new Telerik.Web.UI.ModalExtender(_11._popupElement);
}
_11._modalExtender.show();
_11.center();
};
this.add_show(this._onModalShowHandler);
this._onModalCloseHandler=function(_12){
window.setTimeout(function(){
if(_12._modalExtender){
_12._modalExtender.hide();
}
},10);
};
this.add_close(this._onModalCloseHandler);
},_enableMoveResize:function(_13){
if(this._resizeExtender){
this._resizeExtender.dispose();
this._resizeExtender=null;
}
if(!_13){
return;
}
if(!this._popupElement){
return;
}
var _14=this._tableElement.rows;
var _15={};
if(this.isBehaviorEnabled(Telerik.Web.UI.WindowBehaviors.Resize)){
_15={nw:_14[0].cells[0],n:this._topResizer,ne:_14[0].cells[2],w:[_14[1].cells[0],_14[2].cells[0]],e:[_14[1].cells[2],_14[2].cells[2]],sw:_14[3].cells[0],s:_14[3].cells[1],se:[_14[3].cells[2],this._bottomResizer]};
}
if(this.isBehaviorEnabled(Telerik.Web.UI.WindowBehaviors.Move)){
_15["move"]=this._titleCell;
}
this._resizeExtender=new Telerik.Web.UI.ResizeExtender(this,this._popupElement,_15,this._tableElement);
},onResizeStart:function(){
this._cachedDragZoneBounds=this._getRestrictionZoneBounds();
},onResizing:function(_16){
if(!this._cachedDragZoneBounds){
return true;
}
return Telerik.Web.UI.ResizeExtender.containsBounds(this._cachedDragZoneBounds,_16);
},onResizeEnd:function(){
this._cachedDragWindowBounds=null;
var _17=this._getCurrentBounds();
this.moveTo(_17.x,_17.y);
if(this._overlay&&$telerik.isFirefox){
this._popupBehavior._onMove();
}
this.raiseEvent("resize",new Sys.EventArgs());
},onDragStart:function(){
this.setActive(true);
if(this.isPinned()){
return false;
}
if(this.isMinimized()&&this.get_minimizeZoneID()){
return false;
}
this._cachedDragZoneBounds=this._getRestrictionZoneBounds();
this._cachedDragWindowBounds=$telerik.getBounds(this._popupElement);
this.raiseEvent("dragStart",new Sys.EventArgs());
return true;
},onDragEnd:function(_18){
this._cachedDragZoneBounds=null;
this._cachedDragWindowBounds=null;
if(this._overlay&&$telerik.isFirefox){
this._popupBehavior._onMove();
}
this.raiseEvent("dragEnd",new Sys.EventArgs());
this._storeBounds();
this.setActive(true);
},onDrag:function(_19){
if(!this._cachedDragZoneBounds){
return true;
}
var _1a=this._cachedDragWindowBounds;
var _1b=this._cachedDragZoneBounds;
_19.width=_1a.width;
_19.height=_1a.height;
var _1c=Telerik.Web.UI.ResizeExtender.containsBounds(_1b,_19);
if(!_1c){
if(_19.x<=_1b.x){
_19.x=_1b.x;
}else{
if(_1b.x+_1b.width<=_19.x+_1a.width){
_19.x=_1b.x+_1b.width-_1a.width;
}
}
if(_19.y<=_1b.y){
_19.y=_1b.y;
}else{
if(_1b.y+_1b.height<=_19.y+_1a.height){
_19.y=_1b.y+_1b.height-_1a.height;
}
}
_1c=true;
}
return _1c;
},initialize:function(){
Telerik.Web.UI.RadWindow.callBaseMethod(this,"initialize");
if(this._visibleOnPageLoad){
this.show();
}
this._registerWindowResizeHandler(true);
},dispose:function(){
var _1d=this.get_windowManager();
if(_1d){
if(_1d.get_preserveClientState()){
_1d.saveWindowState(this);
}
if(this._destroyOnClose){
_1d.removeWindow(this);
}
}
if(this._windowAnimation){
this._windowAnimation.dispose();
}
if(this._popupBehavior){
this._popupBehavior.dispose();
this._popupBehavior=null;
}
this._enableMoveResize(false);
this._makeModal(false);
this._registerTitlebarHandlers(false);
this._registerWindowResizeHandler(false);
this._registerIframeLoadHandler(false);
if(this._openerElement){
this._registerOpenerElementHandler(this._openerElement,false);
}
this.set_behaviors(Telerik.Web.UI.WindowBehaviors.None);
if(this._iframe){
this._iframe.src="javascript:'<html></html>';";
var _1e=this._iframe;
_1e.name="";
_1e.removeAttribute("name");
_1e.removeAttribute("NAME");
}
if(this._contentElement){
this._contentElement.innerHTML="";
}
Telerik.Web.UI.RadWindow.callBaseMethod(this,"dispose");
},hide:function(){
this._hide();
return true;
},clone:function(_1f,_20){
if(!_1f){
alert("Telerik.Web.UI.RadWindow.clone called without providing a name argument");
return;
}
var evs=(_20!=false)?this._getEventsParameter():null;
var _22=this._getPropertiesParameter();
var _23=document.createElement("SPAN");
_23.setAttribute("id",_1f);
var wnd=$create(Telerik.Web.UI.RadWindow,_22,evs,null,_23);
wnd.set_name(_1f);
wnd._isCloned=true;
return wnd;
},set_contentElement:function(_25){
this._createUI();
if(this._iframe){
this._iframe.style.display="none";
}
if(_25.parentNode&&_25.parentNode.removeChild){
_25.parentNode.removeChild(_25);
}
this._contentCell.appendChild(_25);
_25.style.display="";
this._contentElement=_25;
},get_contentElement:function(){
return this._contentElement;
},isCreated:function(){
return this._popupElement!=null;
},show:function(){
var _26=this.isCreated();
this._createUI();
if(this._navigateUrl&&(!_26||this._reloadOnShow)){
this.setUrl(this._navigateUrl);
}
if(!_26&&(this._initialBehaviors!=Telerik.Web.UI.WindowBehaviors.None)){
this._show();
this._afterShow();
if(this.isInitialBehaviorEnabled(Telerik.Web.UI.WindowBehaviors.Minimize)){
this.minimize();
}
if(this.isInitialBehaviorEnabled(Telerik.Web.UI.WindowBehaviors.Maximize)){
this.maximize();
}
if(this.isInitialBehaviorEnabled(Telerik.Web.UI.WindowBehaviors.Pin)){
this.togglePin();
}
return;
}
if(this._animation==Telerik.Web.UI.WindowAnimation.None){
this._show();
this._afterShow();
}else{
this._playAnimation();
}
},_show:function(){
this.raiseEvent("beforeShow",new Sys.EventArgs());
if(this.get_offsetElementID()&&!this._offsetElement){
var _27=$get(this.get_offsetElementID());
if(_27){
this._offsetElement=_27;
}
}
this._popupBehavior.set_parentElement(this._bodyElement);
if(this._offsetElement&&!this._offsetSet){
this._popupBehavior.set_parentElement(this._offsetElement);
this._offsetSet=true;
}
this.set_visibleTitlebar(this._visibleTitlebar);
this.set_visibleStatusbar(this._visibleStatusbar);
this._reSetWindowPosition();
this._popupBehavior.set_parentElement(this._bodyElement);
this._popupVisible=true;
},_hide:function(){
if(this._windowAnimation){
this._windowAnimation.stop();
}
if(this._windowAnimation){
this._windowAnimation.play(true);
}else{
this._afterHide();
}
},_afterHide:function(){
if(!this._popupBehavior){
return;
}
if(this.isMaximized()){
this._restoreBounds();
}
this._popupBehavior.hide(true);
this._popupVisible=false;
this._getWindowController().notifyWindowClosed(this);
this.raiseEvent("close",new Sys.EventArgs());
},_afterShow:function(){
this.setActive(true);
this._storeBounds();
this.raiseEvent("show",new Sys.EventArgs());
},_playAnimation:function(){
var _28=function(){
var wnd=this.controller;
var _2a=wnd._getCalculatedPopupBounds();
wnd._setPopupVisible(_2a.x,_2a.y);
var _2b=$telerik.getBounds(wnd._popupElement);
wnd._popupBehavior.hide();
this.set_endBounds(_2b);
};
if(!this._windowAnimation){
if(this._animation==Telerik.Web.UI.WindowAnimation.Fade){
this._windowAnimation=new Telerik.Web.UI.Animations.FadeAnimation(this,0.4,null,this._popupElement,null,this._openerElement);
this._windowAnimation.onShowStart=function(){
this.controller._show();
};
}else{
if(this._animation==Telerik.Web.UI.WindowAnimation.Slide){
this._windowAnimation=new Telerik.Web.UI.Animations.SlideAnimation(this,0.2,null,this._popupElement,null,this._openerElement);
this._windowAnimation.onShowStart=_28;
}else{
if(this._animation==Telerik.Web.UI.WindowAnimation.FlyIn){
this._windowAnimation=new Telerik.Web.UI.Animations.FlyInAnimation(this,null,null,this._popupElement,null,this._openerElement);
this._windowAnimation.onShowStart=_28;
}else{
if(this._animation==Telerik.Web.UI.WindowAnimation.Resize){
this._windowAnimation=new Telerik.Web.UI.Animations.ResizeAnimation(this,0.2,50,this._popupElement,null,this._openerElement);
this._windowAnimation.onShowStart=_28;
}
}
}
}
}
if(this._windowAnimation){
this._windowAnimation.onShowEnd=function(){
this.controller._show();
this.controller._afterShow();
};
this._windowAnimation.onHideEnd=function(){
this.controller._afterHide();
};
this._windowAnimation.play();
}
},_onClick:function(e){
this.show();
return this._cancelEvent(e);
},_cancelEvent:function(e){
if(e){
e.returnValue=false;
e.cancelBubble=true;
e.preventDefault();
e.stopPropagation();
}
return false;
},_getWindowController:function(){
return Telerik.Web.UI.RadWindowController.getInstance();
},_getReloadOnShowUrl:function(_2e){
var str="rwndrnd="+Math.random();
if(_2e.indexOf("?")>-1){
str="&"+str;
}else{
str="?"+str;
}
_2e+=str;
return _2e;
},_getPropertiesParameter:function(){
if(!this._propertiesParameter){
var _30={};
for(var _31 in Telerik.Web.UI.RadWindow.prototype){
var _32=this[_31];
if(typeof (_32)=="function"&&_31.indexOf("get_")==0){
var _33=_31.substring(4);
if(null==this["set_"+_33]){
continue;
}
var _34=_32.call(this);
if(null==_34){
continue;
}
_30[_33]=_34;
if(_33=="skin"){
break;
}
}
}
this._propertiesParameter=_30;
}
var _35=this._cloneObject(this._propertiesParameter);
return _35;
},_getEventsParameter:function(){
if(!this._eventsParameter){
var _36={};
var _37=this.get_events();
var _38=this._eventNames;
for(var i=0;i<_38.length;i++){
var _3a=_38[i];
var _3b=_37.getHandler(_3a);
if(_3b&&typeof (eval(_3b))=="function"){
_36[_3a]=eval(_3b);
}
}
this._eventsParameter=_36;
}
return this._eventsParameter;
},_cloneObject:function(_3c){
var _3d={};
for(var _3e in _3c){
_3d[_3e]=_3c[_3e];
}
return _3d;
},getWindowBounds:function(){
return this._getCalculatedPopupBounds();
},toString:function(){
return "[RadWindow id="+this.get_id()+"]";
},center:function(){
var _3f=this._getCentralBounds();
this.moveTo(_3f.x,_3f.y);
},moveTo:function(x,y){
x=parseInt(x);
y=parseInt(y);
this._createUI();
this._setPopupVisible(x,y);
this._storeBounds();
},setSize:function(_42,_43){
this._firstShow=false;
this.set_width(_42);
this.set_height(_43);
this._storeBounds();
},_maintainMaximizedSize:function(){
if(!this.isMaximized()){
return;
}
var _44=this._popupElement;
if(!_44){
return;
}
var _45=this._getViewportBounds();
_44.style.top=(_45.scrollTop+_45.y)+"px";
_44.style.left=(_45.scrollLeft+_45.x)+"px";
_44.style.width=_45.width+"px";
_44.style.height=_45.height+"px";
var _46=this._getRestrictionZoneBounds();
if(!_46){
this._enablePageScrolling(false);
}
var _47=this._tableElement;
_45=this._getViewportBounds();
_47.style.height=_45.height+"px";
this._fixIeHeight(_47,_45.height);
},_enablePageScrolling:function(_48){
if(_48){
var _49=this._documentOverflowX;
if(null!=_49){
this._documentOverflowX=null;
document.documentElement.style.overflowX=_49?_49:"";
}
_49=this._documentOverflowY;
if(null!=_49){
this._documentOverflowY=null;
document.documentElement.style.overflowY=_49?_49:"";
}
_49=this._bodyOverflowX;
if(null!=_49){
this._bodyOverflowX=null;
document.body.style.overflowX=_49?_49:"";
}
_49=this._bodyOverflowY;
if(null!=_49){
this._bodyOverflowY=null;
document.body.style.overflowY=_49?_49:"";
}
}else{
if(!this._documentOverflowX){
this._documentOverflowX=$telerik.getCurrentStyle(document.documentElement,"overflowX");
}
if(!this._documentOverflowY){
this._documentOverflowY=$telerik.getCurrentStyle(document.documentElement,"overflowY");
}
if(!this._bodyOverflowX){
this._bodyOverflowX=$telerik.getCurrentStyle(document.body,"overflowX");
}
if(!this._bodyOverflowY){
this._bodyOverflowY=$telerik.getCurrentStyle(document.body,"overflowY");
}
document.body.style.overflow="hidden";
document.documentElement.style.overflow="hidden";
}
},_getRestrictionZoneBounds:function(){
var _4a=null;
if(this.get_restrictionZoneID()){
var _4b=$get(this.get_restrictionZoneID());
if(_4b){
_4a=$telerik.getBounds(_4b);
_4a.scrollLeft=0;
_4a.scrollTop=0;
}
}
return _4a;
},_storeBounds:function(){
if(!this.isCreated()){
return;
}
var _4c=this._getCurrentBounds();
if(this.isMaximized()){
return false;
}
if(this.isMinimized()){
if(this._restoreRect){
_4c.width=this._restoreRect.width;
_4c.height=this._restoreRect.height;
}else{
_4c.width=this.get_width();
_4c.height=this.get_height();
}
}
this._restoreRect=_4c;
},_restoreBounds:function(){
if(!this._restoreRect){
return;
}
var _4d=this._restoreRect;
this.setSize(_4d.width,_4d.height);
this.moveTo(_4d.x,_4d.y);
},_getStoredBounds:function(){
if(this._restoreRect){
return this._restoreRect;
}
},_deleteStoredBounds:function(){
this._restoreRect=null;
},_getCurrentBounds:function(){
var _4e=(this._popupElement.style.display=="none")?true:false;
this._popupElement.style.display="";
if(this._firstShow!=true){
this._updateWindowSize(this._height);
this._firstShow=true;
}
var _4f=$telerik.getBounds(this._popupElement);
if(_4e){
this._popupElement.style.display="none";
}
var _50=this._getRestrictionZoneBounds();
if(_50){
_4f.x-=_50.x;
_4f.y-=_50.y;
}
return _4f;
},_getCentralBounds:function(){
var _51=this._getCurrentBounds();
var _52=this._getViewportBounds();
var x=parseInt((_52.width-_51.width)/2);
var y=parseInt((_52.height-_51.height)/2);
_51.x=x+_52.scrollLeft;
_51.y=y+_52.scrollTop;
return _51;
},_getViewportBounds:function(){
var _55=this._getRestrictionZoneBounds();
if(_55){
return _55;
}
var _56=$telerik.getClientBounds();
var _57=document.documentElement.scrollLeft||document.body.scrollLeft;
var _58=document.documentElement.scrollTop||document.body.scrollTop;
_56.scrollLeft=_57;
_56.scrollTop=_58;
if(this.isIE){
if(_56.width==0){
_56.width=document.body.clientWidth;
}
if(_56.height==0){
_56.height=document.body.clientHeight;
}
}
return _56;
},_getCalculatedPopupBounds:function(){
var _59=this._getStoredBounds();
if(_59){
return _59;
}
var _5a=this._getCurrentBounds();
var _5b=this._offsetElement;
if(!this._top&&!this._left&&!_5b){
_5a=this._getCentralBounds();
}else{
if(_5b){
_5a.y=0;
_5a.x=0;
}else{
var _5c=this._getViewportBounds();
_5a.x=_5c.scrollLeft;
_5a.y=_5c.scrollTop;
}
var _5d=this._left?this._left:0;
_5a.x+=_5d;
var top=this._top?this._top:0;
_5a.y+=top;
}
return _5a;
},_reSetWindowPosition:function(){
var _5f=this._getCalculatedPopupBounds();
this._setPopupVisible(_5f.x,_5f.y);
},_fixIeHeight:function(_60,_61){
if("CSS1Compat"==document.compatMode){
var _62=(_60.offsetHeight-parseInt(_61));
if(_62>0){
var _63=(parseInt(_60.style.height)-_62);
if(_63>0){
_60.style.height=_63+"px";
}
}
}
},_setPopupVisible:function(x,y){
var _66=this._getRestrictionZoneBounds();
if(_66){
x+=_66.x;
y+=_66.y;
}
this._popupBehavior._setCoordinates(x,y);
this._popupBehavior.show();
if(!this.get_width()){
this._popupElement.style.width="";
}
this._updateTitleWidth();
},_createDefaultTable:function(){
var _67=document.createElement("TABLE");
_67.align="left";
_67.cellSpacing=0;
_67.cellPadding=0;
_67.insertRow(-1);
return _67;
},_createUI:function(){
if(!this._popupElement){
var _68=this.get_id();
var _69="RadWindowWrapper_"+_68;
var _6a=document.createElement("DIV");
_6a.id=_69;
_6a.className=this._getFullSkinName();
_6a.style.width=this._width;
_6a.style.height=this._height;
_6a.setAttribute("unselectable","on");
this._popupElement=_6a;
var _6b=document.createElement("TABLE");
_6b.cellSpacing=0;
_6b.cellPadding=0;
this._tableElement=_6b;
var _6c=["corner topleft","titlebar","corner topright","corner bodyleft","windowcontent","corner bodyright","corner bodyleft","statusbar","corner bodyright","corner footerleft","footercenter","corner footerright"];
var _6d=["titlerow","contentrow","statusbarrow","footerrow"];
var _6e=0;
for(var i=0;i<4;i++){
var row=_6b.insertRow(-1);
row.className=_6d[i];
for(var j=1;j<=3;j++){
var _72=row.insertCell(-1);
_72.innerHTML="&nbsp;";
_72.className=_6c[_6e];
_6e++;
}
}
var _73=_6b.rows[0].cells[1];
_73.innerHTML="";
this._titleCell=_73;
var _74=document.createElement("DIV");
_74.className="topresize";
_74.innerHTML="<!-- / -->";
this._topResizer=_74;
this._titleCell.appendChild(this._topResizer);
var _75=this._createDefaultTable();
_75.className="titlebarcontrols";
this._titlebarElement=_75;
this._titleCell.appendChild(this._titlebarElement);
var _76=this._getTitleIcon();
var _77=this._titlebarElement.rows[0].insertCell(-1);
_77.appendChild(_76);
var _78=this._getTitleElement();
var _73=this._titlebarElement.rows[0].insertCell(-1);
_73.appendChild(_78);
this.set_title(this._title);
var _79=this._titlebarElement.rows[0].insertCell(-1);
_79.noWrap=true;
_79.style.whiteSpace="nowrap";
_79.appendChild(this._getTitleCommandButtonsHolder());
var _7a=_6b.rows[1].cells[1];
_7a.vAlign="top";
_7a.innerHTML="";
this._contentCell=_7a;
var _7b=this.get_name();
var _7c=($telerik.isIE)?document.createElement("<iframe name='"+_7b+"'>"):document.createElement("iframe");
_7c.name=_7b;
_7c.src="javascript:'<html></html>';";
_7c.style.width="100%";
_7c.style.height="100%";
_7c.style.border="0px";
_7c.frameBorder="0";
this._iframe=_7c;
this._contentCell.appendChild(this._iframe);
var _7d=this._createDefaultTable();
_7d.style.width="100%";
this._statusCell=_6b.rows[2].cells[1];
this._statusCell.innerHTML="";
this._statusCell.appendChild(_7d);
var _7e=_7d.rows[0].insertCell(-1);
_7e.style.width="100%";
var _7f=this._getStatusMessageElement();
_7e.appendChild(_7f);
var _80=_7d.rows[0].insertCell(-1);
_80.style.width="15px";
var _81=document.createElement("DIV");
_80.appendChild(_81);
this._bottomResizer=_81;
this._createBackReference();
this._popupElement.appendChild(this._tableElement);
this._popupElement.style.display="none";
this._popupElement.style.position="absolute";
this._addWindowToDocument();
this.set_behaviors(this._behaviors);
this._registerTitlebarHandlers(true);
this.set_visibleTitlebar(this._visibleTitlebar);
this.set_visibleStatusbar(this._visibleStatusbar);
}
if(!this._popupBehavior){
this._popupBehavior=$create(Telerik.Web.PopupBehavior,{"id":(new Date()-100)+"PopupBehavior","parentElement":null,"overlay":this._overlay,"keepInScreenBounds":this._keepInScreenBounds},null,null,this._popupElement);
}
},_getStatusMessageElement:function(){
if(null==this._statusMessageElement){
var el=document.createElement("INPUT");
el.readOnly="readonly";
el.setAttribute("unselectable","on");
this._statusMessageElement=el;
}
return this._statusMessageElement;
},_getTitleCommandButtonsHolder:function(){
if(null==this._buttonsElement){
var ul=document.createElement("UL");
ul.className="controlbuttons";
this._buttonsElement=ul;
}
return this._buttonsElement;
},_getTitleElement:function(){
if(!this._titleElement){
this._titleElement=document.createElement("EM");
this._titleElement.setAttribute("unselectable","on");
}
return this._titleElement;
},_getTitleIcon:function(){
if(null==this._titleIconElement){
var _84=document.createElement("A");
this._titleIconElement=_84;
_84.className="windowicon";
if(this.get_iconUrl()){
_84.style.background="transparent url("+this.get_iconUrl()+") no-repeat scroll 0px 0px";
}
}
return this._titleIconElement;
},_getTitleCommandButton:function(_85){
if(!_85||!this._buttonsArray){
return null;
}
_85=_85.toLowerCase()+"button";
var _86=this._buttonsArray.length;
for(var i=0;i<_86;i++){
var _88=this._buttonsArray[i];
if(_88&&Sys.UI.DomElement.containsCssClass(_88,_85)){
return _88;
}
}
return null;
},_updateTitleWidth:function(){
if(this._visibleTitlebar){
var _89=this._getTitleElement();
if(!_89){
return;
}
var _8a=this._getTitleCommandButtonsHolder();
var _8b=_8a.offsetWidth;
if(_8b>0){
var lis=_8a.getElementsByTagName("LI");
if(lis[0]&&lis[0].offsetWidth>0){
_8b=lis.length*lis[0].offsetWidth;
}
_8a.style.width=_8b+"px";
}
var _8d=this._getTitleIcon();
var _8e=_8d.offsetWidth;
if(_8e>0&&_8d.parentNode.tagName=="TD"){
_8d.parentNode.style.width=_8e+"px";
}
}
},_addWindowToDocument:function(){
var _8f=document.getElementById(this._formID);
if(!_8f){
_8f=document.forms[0];
}
_8f.insertBefore(this._popupElement,_8f.firstChild);
},_invokeDialogCallBackFunction:function(_90,_91){
if(true!=_91){
this.close();
}
var _92=this.get_clientCallBackFunction();
if(_92){
if("string"==typeof (_92)){
_92=eval(_92);
}
if("function"==typeof (_92)){
_92(this,_90);
}
}
},_createBackReference:function(){
var _93=this;
if(!_93.Argument){
_93.Argument={};
}
var _94=this._iframe;
try{
_94.radWindow=_93;
if(_94.contentWindow!=null){
_94.contentWindow.radWindow=_93;
}
}
catch(e){
}
},_getFullSkinName:function(){
return "radwindow radwindow_"+this._skin+" normalwindow transparentwindow";
},_configureMinimizeButton:function(_95){
var loc=this._getLocalization();
var _97=(true==_95)?loc["Restore"]:loc["Minimize"];
var _98=(true==_95)?this.restore:this.minimize;
this._registerTitlebarHandlersButton("Minimize",_97,_98);
},_configureMaximizeButton:function(_99){
var loc=this._getLocalization();
var _9b=(true==_99)?loc["Restore"]:loc["Maximize"];
var _9c=(true==_99)?this.restore:this.maximize;
this._registerTitlebarHandlersButton("Maximize",_9b,_9c);
},_registerTitlebarHandlersButton:function(_9d,_9e,_9f){
var _a0=this._getTitleCommandButton(_9d);
if(_a0){
var loc=this._getLocalization();
_a0.setAttribute("title",_9e);
_a0.innerHTML=_9e;
$clearHandlers(_a0);
$addHandlers(_a0,{"click":_9f},this);
$addHandler(_a0,"dblclick",this._cancelEvent);
$addHandler(_a0,"mousedown",this._cancelEvent);
}
},isCloned:function(){
return this._isCloned;
},isBehaviorEnabled:function(_a2){
return _a2&this._behaviors?true:false;
},isInitialBehaviorEnabled:function(_a3){
return _a3&this._initialBehaviors?true:false;
},setVisible:function(_a4){
if(this._popupBehavior){
if(_a4){
this._popupBehavior.show();
}else{
this._popupBehavior.hide();
}
}
},isVisible:function(){
return this._popupVisible;
},isModal:function(){
return this._modal;
},isActive:function(){
return (this._popupElement&&!Sys.UI.DomElement.containsCssClass(this._popupElement,"inactivewindow"));
},isPinned:function(){
var _a5=this._getTitleCommandButton("Pin");
return (_a5&&Sys.UI.DomElement.containsCssClass(_a5,"on"));
},isClosed:function(){
return (!this.isVisible());
},isMinimized:function(){
return (this._popupElement&&Sys.UI.DomElement.containsCssClass(this._popupElement,"minimizedwindow"));
},isMaximized:function(){
return (this._popupElement&&Sys.UI.DomElement.containsCssClass(this._popupElement,"maximizedwindow"));
},setActive:function(_a6){
var _a7=this._popupElement;
if(!_a6){
Sys.UI.DomElement.addCssClass(_a7,"inactivewindow");
}else{
var _a8=parseInt(_a7.style.zIndex);
var _a9=Telerik.Web.UI.RadWindowUtils.get_newZindex(_a8);
_a7.style.zIndex=""+_a9;
this._getWindowController().set_activeWindow(this);
if(this.isActive()){
return;
}
$telerik.removeCssClasses(_a7,["inactivewindow"]);
this.raiseEvent("activate",new Sys.EventArgs());
}
},_moveToMinimizeZone:function(){
var _aa=$get(this.get_minimizeZoneID());
if(_aa){
if(this.isPinned()){
this._isPinned=true;
this.togglePin();
}
var _ab=this._popupElement;
if(_ab.parentNode!=_aa){
_ab.parentNode.removeChild(_ab);
_aa.appendChild(_ab);
this.setVisible(true);
_ab.style.position="static";
if(this.isIE){
_ab.style.display="inline";
}else{
_ab.style.cssFloat="left";
}
}
}
},_moveToDocument:function(){
var _ac=this._popupElement;
_ac.parentNode.removeChild(_ac);
_ac.style.position="absolute";
if(this.isIE){
_ac.style.display="";
}else{
_ac.style.cssFloat="";
}
this._addWindowToDocument();
if(this._isPinned){
this._isPinned=false;
this.togglePin();
}
},minimize:function(){
if(!this.isCreated()){
return;
}
var _ad=this.onCommand("Minimize");
if(!_ad){
return;
}
var _ae=this._popupElement;
$telerik.removeCssClasses(_ae,["normalwindow","maximizedwindow"]);
Sys.UI.DomElement.addCssClass(_ae,"minimizedwindow");
var _af=_ae._hideWindowedElementsIFrame;
if(_af){
Sys.UI.DomElement.addCssClass(_af,"minimizedwindowoverlay_"+this._skin);
}
this._configureMinimizeButton(true);
this._enablePageScrolling(true);
if(this.get_minimizeZoneID()){
this._moveToMinimizeZone();
}
},restore:function(){
if(!this.isCreated()){
return;
}
var _b0=this.onCommand("Restore");
if(!_b0){
return;
}
this._configureMinimizeButton();
this._configureMaximizeButton();
if(this.isMinimized()&&this.get_minimizeZoneID()){
this._moveToDocument();
}
this._normalizeWindowRootCss();
this._enablePageScrolling(true);
this.setVisible(true);
this._restoreBounds();
this.setVisible(true);
this.setActive(true);
},maximize:function(){
if(!this.isCreated()){
return;
}
var _b1=this.onCommand("Maximize");
if(!_b1){
return;
}
if(!this.isBehaviorEnabled(Telerik.Web.UI.WindowBehaviors.Maximize)){
return;
}
this._storeBounds();
if(this.isMinimized()&&this.get_minimizeZoneID()){
this._moveToDocument();
}
var _b2=this._popupElement;
$telerik.removeCssClasses(_b2,["normalwindow","minimizedwindow"]);
Sys.UI.DomElement.addCssClass(_b2,"maximizedwindow");
this._configureMaximizeButton(true);
this._configureMinimizeButton();
this._maintainMaximizedSize();
this._maintainMaximizedSize();
var _b3=_b2._hideWindowedElementsIFrame;
if(_b3){
$telerik.removeCssClasses(_b3,["minimizedwindowoverlay_"+this._skin]);
this._popupBehavior._handleElementResize();
}
if(!this.isActive()){
this.setActive(true);
}
},togglePin:function(){
if(!this.isCreated()){
return;
}
var _b4=this.onCommand("Pin");
if(!_b4){
return;
}
var _b5=this._getTitleCommandButton("Pin");
var loc=this._getLocalization();
var _b7=this.isPinned();
var _b8=_b7?loc["PinOn"]:loc["PinOff"];
if(_b5){
Sys.UI.DomElement.toggleCssClass(_b5,"on");
}
this._registerTitlebarHandlersButton("Pin",_b8,this.togglePin);
Telerik.Web.UI.RadWindowUtils.setPinned(!_b7,this);
},reload:function(){
if(!this.isCreated()){
return;
}
var _b9=this.onCommand("Reload");
if(!_b9){
return;
}
if(!this._iframe){
return;
}
this._onWindowUrlChanging();
try{
this._iframe.contentWindow.location.reload();
}
catch(e){
this._onWindowUrlChanged();
}
},_normalizeWindowRootCss:function(){
var _ba=this._popupElement;
if(_ba){
$telerik.removeCssClasses(_ba,["minimizedwindow","maximizedwindow"]);
Sys.UI.DomElement.addCssClass(_ba,"normalwindow");
var _bb=_ba._hideWindowedElementsIFrame;
if(_bb){
$telerik.removeCssClasses(_bb,["minimizedwindowoverlay_"+this._skin]);
}
}
},close:function(_bc){
if(this.isClosed()){
return;
}
this.hide();
this._enablePageScrolling(true);
this._normalizeWindowRootCss();
if(null!=_bc&&!(_bc instanceof Sys.UI.DomEvent)){
this._invokeDialogCallBackFunction(_bc);
}
if(this._destroyOnClose){
this.dispose();
}
},onCommand:function(_bd){
var _be=new Sys.CancelEventArgs();
_be._commandName=_bd;
_be.get_commandName=function(){
return this._commandName;
};
this.raise_command(_be);
if(_be.get_cancel()){
return false;
}
return true;
},setUrl:function(url){
this._createUI();
this._navigateUrl=url;
var _c0=url;
if(this._reloadOnShow){
_c0=this._getReloadOnShowUrl(_c0);
}
this._iframe.src=_c0;
this._onWindowUrlChanging();
if(!this._loaded){
this._registerIframeLoadHandler(true);
}
this._loaded=true;
},_registerChildPageHandlers:function(_c1){
var _c2=null;
try{
_c2=this._iframe.contentWindow.document;
if(_c2.domain!=document.domain){
return;
}
}
catch(e){
return;
}
if(null==_c2){
return;
}
if(_c1){
this._onChildPageUnloadDelegate=Function.createDelegate(this,this._onChildPageUnload);
if(this.isIE){
_c2.onunload=this._onChildPageUnloadDelegate;
}else{
this._iframe.contentWindow.onunload=this._onChildPageUnloadDelegate;
}
this._onChildPageClickDelegate=Function.createDelegate(this,this._onChildPageClick);
$telerik.addExternalHandler(_c2,"click",this._onChildPageClickDelegate);
}else{
if(this._onChildPageClickDelegate){
$telerik.removeExternalHandler(_c2,"click",this._onChildPageClickDelegate);
this._onChildPageClickDelegate=null;
}
}
},_onChildPageUnload:function(e){
this._registerChildPageHandlers(false);
},_onChildPageClick:function(e){
if(!this.isVisible()||this.isClosed()){
return;
}
var src=e.target?e.target:e.srcElement;
if(src){
if(src.tagName=="INPUT"&&src.type=="button"){
return;
}else{
if(src.tagName=="BUTTON"||src.tagName=="A"){
return;
}
}
}
this.setActive(true);
},_onIframeLoad:function(){
this._onWindowUrlChanged();
this._registerChildPageHandlers(true);
this.raiseEvent("pageLoad",new Sys.EventArgs());
},_onWindowUrlChanging:function(){
var _c6=this._getStatusMessageElement();
if(_c6){
Sys.UI.DomElement.addCssClass(_c6,"loading");
}
if(!this._showContentDuringLoad){
this._iframe.style.width="0px";
this._iframe.style.height="0px";
}
},_onWindowUrlChanged:function(){
var _c7=this._getStatusMessageElement();
if(_c7){
Sys.UI.DomElement.removeCssClass(_c7,"loading");
this.set_status(this._navigateUrl);
}
if(!this._showContentDuringLoad){
this._iframe.style.width="100%";
this._iframe.style.height="100%";
}
try{
if(this._iframe.contentWindow.document.title){
this.set_title(this._iframe.contentWindow.document.title);
}
}
catch(e){
}
},_updatePopupZindex:function(){
if(this._popupBehavior){
if(this.isVisible()){
this._popupBehavior.show();
}
}
},get_zindex:function(){
if(this._popupElement){
return this._popupElement.style.zIndex;
}else{
return -1;
}
},get_contentFrame:function(){
return this._iframe;
},get_minimizeZoneID:function(){
return this._minimizeZoneID;
},set_minimizeZoneID:function(_c8){
if(this._minimizeZoneID!=_c8){
this._minimizeZoneID=_c8;
}
},get_restrictionZoneID:function(){
return this._restrictionZoneID;
},set_restrictionZoneID:function(_c9){
if(this._restrictionZoneID!=_c9){
this._restrictionZoneID=_c9;
}
},get_minimizeIconUrl:function(){
return this._minimizeIconUrl;
},set_minimizeIconUrl:function(_ca){
if(this._minimizeIconUrl!=_ca){
this._minimizeIconUrl=_ca;
}
},get_iconUrl:function(){
return this._iconUrl;
},set_iconUrl:function(_cb){
if(this._iconUrl!=_cb){
this._iconUrl=_cb;
}
},get_clientCallBackFunction:function(){
return this._clientCallBackFunction;
},set_clientCallBackFunction:function(_cc){
if(this._clientCallBackFunction!=_cc){
this._clientCallBackFunction=_cc;
}
},get_navigateUrl:function(){
return this._navigateUrl;
},set_navigateUrl:function(_cd){
if(this._navigateUrl!=_cd){
this._navigateUrl=_cd;
}
},get_targetControl:function(){
return this._openerElement;
},set_targetControl:function(_ce){
if(this._openerElement!=_ce){
this._openerElement=_ce;
}
},get_name:function(){
return this._name;
},set_name:function(_cf){
if(this._name!=_cf){
this._name=_cf;
}
},get_formID:function(){
return this._formID;
},set_formID:function(_d0){
if(this._formID!=_d0){
this._formID=_d0;
}
},get_offsetElementID:function(){
return this._offsetElementID;
},set_offsetElementID:function(_d1){
if(this._offsetElementID!=_d1){
this._offsetElementID=_d1;
}
if(this.isVisible()){
this._deleteStoredBounds();
this._offsetSet=false;
this._show();
}
},get_openerElementID:function(){
return this._openerElementID;
},set_openerElementID:function(_d2){
if(this._openerElementID!=_d2){
if(this._openerElement){
this._registerOpenerElementHandler(this._openerElement,false);
this._openerElement=null;
}
this._openerElementID=_d2;
if(this._openerElementID){
this._openerElement=$get(this._openerElementID);
}
if(this._openerElement){
this._registerOpenerElementHandler(this._openerElement,true);
}
}
},get_left:function(){
return this._left;
},set_left:function(_d3){
if(this._left!=_d3){
this._left=parseInt(_d3);
}
},get_top:function(){
return this._top;
},set_top:function(_d4){
if(this._top!=_d4){
this._top=parseInt(_d4);
}
},get_title:function(){
return this._title;
},set_title:function(_d5){
if(this._title!=_d5){
this._title=_d5;
}
if(null==this._titleElement){
return;
}
this._titleElement.innerHTML=this._title;
this._updateTitleWidth();
},get_width:function(){
return parseInt(this._width);
},_fixSizeValue:function(_d6){
_d6=""+_d6;
if(-1==_d6.indexOf("px")){
_d6=parseInt(_d6);
if(!isNaN(_d6)){
_d6=_d6+"px";
}else{
_d6="";
}
}
return _d6;
},set_width:function(_d7){
if(null==_d7){
return;
}
_d7=this._fixSizeValue(_d7);
if(this._width!=_d7){
this._width=_d7;
}
if(this._popupElement){
this._deleteStoredBounds();
this._popupElement.style.width=this._width;
this._updatePopupZindex();
}
},get_height:function(){
return parseInt(this._height);
},set_height:function(_d8){
if(null==_d8){
return;
}
_d8=this._fixSizeValue(_d8);
if(this._height!=_d8){
this._height=_d8;
}
if(this._popupElement){
this._deleteStoredBounds();
this._updateWindowSize(this._height);
this._updatePopupZindex();
}
},_updateWindowSize:function(_d9,_da){
var _db=this._tableElement;
var _dc=_d9?_d9:_db.style.height;
if(true==_da){
_dc=_db.offsetHeight+"px";
}
if(parseInt(_dc)==0){
return;
}
_db.style.height=_dc;
this._fixIeHeight(_db,_dc);
_db.parentNode.style.height=_dc;
},get_initialBehaviors:function(){
return this._initialBehaviors;
},set_initialBehaviors:function(_dd){
if(this._initialBehaviors!=_dd){
this._initialBehaviors=_dd;
}
},get_behaviors:function(){
return this._behaviors;
},set_behaviors:function(_de){
if(this._behaviors!=_de){
this._behaviors=_de;
}
if(null==this._titlebarElement){
return;
}
this._enableMoveResize(false);
this._enableMoveResize(true);
if(this._buttonsArray&&this._buttonsArray.length>0){
var len=this._buttonsArray.length;
for(var i=0;i<len;i++){
var _e1=this._buttonsArray[i];
$clearHandlers(_e1);
}
this._buttonsArray=[];
var _e2=this._getTitleCommandButtonsHolder();
_e2.innerHTML="";
}
if(Telerik.Web.UI.WindowBehaviors.None==this._behaviors){
return;
}else{
var loc=this._getLocalization();
var _e4=Telerik.Web.UI.WindowBehaviors;
var _e5=[[this.isBehaviorEnabled(_e4.Pin),"pinbutton",loc["PinOn"],this.togglePin],[this.isBehaviorEnabled(_e4.Reload),"reloadbutton",loc["Reload"],this.reload],[this.isBehaviorEnabled(_e4.Minimize),"minimizebutton",loc["Minimize"],this.minimize],[this.isBehaviorEnabled(_e4.Maximize),"maximizebutton",loc["Maximize"],this.maximize],[this.isBehaviorEnabled(_e4.Close),"closebutton",loc["Close"],this.close]];
for(var i=0;i<_e5.length;i++){
var _e6=_e5[i];
if(!_e6[0]){
continue;
}
var li=document.createElement("LI");
var _e8=document.createElement("A");
_e8.href="javascript:void(0);";
_e8.className=_e6[1];
_e8.setAttribute("title",_e6[2]);
var _e9=document.createElement("SPAN");
_e9.innerHTML=_e6[2];
_e8.appendChild(_e9);
$addHandlers(_e8,{"click":_e6[3],"dblclick":this._cancelEvent,"mousedown":this._cancelEvent},this);
$addHandler(_e8,"click",this._cancelEvent);
li.appendChild(_e8);
this._buttonsElement.appendChild(li);
this._buttonsArray[this._buttonsArray.length]=_e8;
}
}
},get_modal:function(){
return this._modal;
},set_modal:function(_ea){
if(this._modal!=_ea){
this._modal=_ea;
}
this._makeModal(this._modal);
if(this.isVisible()){
this._afterShow();
}
},get_destroyOnClose:function(){
return this._destroyOnClose;
},set_destroyOnClose:function(_eb){
if(this._destroyOnClose!=_eb){
this._destroyOnClose=_eb;
}
},get_reloadOnShow:function(){
return this._reloadOnShow;
},set_reloadOnShow:function(_ec){
if(this._reloadOnShow!=_ec){
this._reloadOnShow=_ec;
}
},get_showContentDuringLoad:function(){
return this._showContentDuringLoad;
},set_showContentDuringLoad:function(_ed){
if(this._showContentDuringLoad!=_ed){
this._showContentDuringLoad=_ed;
}
},get_visibleOnPageLoad:function(){
return this._visibleOnPageLoad;
},set_visibleOnPageLoad:function(_ee){
if(this._visibleOnPageLoad!=_ee){
this._visibleOnPageLoad=_ee;
}
},get_visibleTitlebar:function(){
return this._visibleTitlebar;
},set_visibleTitlebar:function(_ef){
if(this._visibleTitlebar!=_ef){
this._visibleTitlebar=_ef;
}
if(this._titlebarElement){
this._titlebarElement.style.display=_ef?"":"none";
}
},get_visibleStatusbar:function(){
return this._visibleStatusbar;
},set_visibleStatusbar:function(_f0){
if(this._visibleStatusbar!=_f0){
this._visibleStatusbar=_f0;
}
if(this._statusCell){
this._statusCell.parentNode.style.display=_f0?"":"none";
}
},get_animation:function(){
return this._animation;
},set_animation:function(_f1){
if(this._animation!=_f1){
this._animation=_f1;
}
},get_overlay:function(){
return this._overlay;
},set_overlay:function(_f2){
this._overlay=_f2;
if(this._popupBehavior){
this._popupBehavior.set_overlay(this._overlay);
}
if(this.isVisible()){
this._reSetWindowPosition();
}
},get_keepInScreenBounds:function(){
return this._keepInScreenBounds;
},set_keepInScreenBounds:function(_f3){
this._keepInScreenBounds=_f3;
if(this._popupBehavior){
this._popupBehavior.set_keepInScreenBounds(this._keepInScreenBounds);
}
if(this.isVisible()){
this._reSetWindowPosition();
}
},get_skin:function(){
return this._skin;
},set_skin:function(_f4){
if(_f4&&this._skin!=_f4){
this._skin=_f4;
}
},get_popupElement:function(){
return this._popupElement;
},get_windowManager:function(){
return this._windowManager;
},set_windowManager:function(_f5){
this._windowManager=_f5;
},set_status:function(_f6){
var _f7=this._getStatusMessageElement();
if(_f7){
window.setTimeout(function(){
_f7.value=_f6;
},0);
}
},get_status:function(){
var _f8=this._getStatusMessageElement();
if(_f8){
return _f8.value;
}
},add_command:function(_f9){
this.get_events().addHandler("command",_f9);
},remove_command:function(_fa){
this.get_events().removeHandler("command",_fa);
},raise_command:function(_fb){
this.raiseEvent("command",_fb);
},add_dragStart:function(_fc){
this.get_events().addHandler("dragStart",_fc);
},remove_dragStart:function(_fd){
this.get_events().removeHandler("dragStart",_fd);
},add_dragEnd:function(_fe){
this.get_events().addHandler("dragEnd",_fe);
},remove_dragEnd:function(_ff){
this.get_events().removeHandler("dragEnd",_ff);
},add_activate:function(_100){
this.get_events().addHandler("activate",_100);
},remove_activate:function(_101){
this.get_events().removeHandler("activate",_101);
},add_beforeShow:function(_102){
this.get_events().addHandler("beforeShow",_102);
},remove_beforeShow:function(_103){
this.get_events().removeHandler("beforeShow",_103);
},add_show:function(_104){
this.get_events().addHandler("show",_104);
},remove_show:function(_105){
this.get_events().removeHandler("show",_105);
},add_pageLoad:function(_106){
this.get_events().addHandler("pageLoad",_106);
},remove_pageLoad:function(_107){
this.get_events().removeHandler("pageLoad",_107);
},add_close:function(_108){
this.get_events().addHandler("close",_108);
},remove_close:function(_109){
this.get_events().removeHandler("close",_109);
},add_resize:function(_10a){
this.get_events().addHandler("resize",_10a);
},remove_resize:function(_10b){
this.get_events().removeHandler("resize",_10b);
},saveClientState:function(){
var _10c=["position"];
var _10d={};
for(var i=0;i<_10c.length;i++){
_10d[_10c[i]]=this["get_"+_10c[i]]();
}
return Sys.Serialization.JavaScriptSerializer.serialize(_10d);
}};
Telerik.Web.UI.RadWindow.registerClass("Telerik.Web.UI.RadWindow",Telerik.Web.UI.RadWebControl);
Telerik.Web.UI.WindowAnimation=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.WindowAnimation.prototype={None:0,Resize:1,Fade:2,Slide:4,FlyIn:8};
Telerik.Web.UI.WindowAnimation.registerEnum("Telerik.Web.UI.WindowAnimation",false);
Telerik.Web.UI.WindowMinimizeMode=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.WindowMinimizeMode.prototype={SameLocation:1,MinimizeZone:2,Default:1};
Telerik.Web.UI.WindowMinimizeMode.registerEnum("Telerik.Web.UI.WindowMinimizeMode",false);
Telerik.Web.UI.WindowBehaviors=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.WindowBehaviors.prototype={None:0,Resize:1,Minimize:2,Close:4,Pin:8,Maximize:16,Move:32,Reload:64,Default:(1+2+4+8+16+32+64)};
Telerik.Web.UI.WindowBehaviors.registerEnum("Telerik.Web.UI.WindowBehaviors",false);
Telerik.Web.UI.RadWindowUtils._zIndex=3000;
Telerik.Web.UI.RadWindowUtils.get_newZindex=function(_10f){
_10f=parseInt(_10f);
if(null==_10f||isNaN(_10f)){
_10f=0;
}
if(Telerik.Web.UI.RadWindowUtils._zIndex<_10f){
Telerik.Web.UI.RadWindowUtils._zIndex=_10f;
}
Telerik.Web.UI.RadWindowUtils._zIndex++;
return Telerik.Web.UI.RadWindowUtils._zIndex;
};
Telerik.Web.UI.RadWindowUtils._pinnedList={};
Telerik.Web.UI.RadWindowUtils.setPinned=function(_110,oWnd){
if(_110){
var _112=oWnd._getViewportBounds();
var _113=oWnd._getCurrentBounds();
oWnd.LeftOffset=_113.x-_112.scrollLeft;
oWnd.TopOffset=_113.y-_112.scrollTop;
var _114=window.setInterval(function(){
Telerik.Web.UI.RadWindowUtils._updatePinnedElementPosition(oWnd);
},100);
Telerik.Web.UI.RadWindowUtils._pinnedList[_114]=oWnd;
}else{
var _115=null;
var _116=Telerik.Web.UI.RadWindowUtils._pinnedList;
for(var name in _116){
if(_116[name]==oWnd){
_115=name;
break;
}
}
if(null!=_115){
window.clearInterval(_115);
Telerik.Web.UI.RadWindowUtils._pinnedList[_115]=null;
}
oWnd.TopOffset=null;
oWnd.LeftOffset=null;
}
};
Telerik.Web.UI.RadWindowUtils._updatePinnedElementPosition=function(oWnd){
if(oWnd.isMaximized()||!oWnd.isVisible()){
return;
}
var _119=oWnd._getViewportBounds();
var _11a=oWnd._getCurrentBounds();
var left=(oWnd.LeftOffset!=null)?oWnd.LeftOffset+_119.scrollLeft:_11a.x;
var top=(oWnd.TopOffset!=null)?oWnd.TopOffset+_119.scrollTop:_11a.y;
oWnd.moveTo(left,top);
};

