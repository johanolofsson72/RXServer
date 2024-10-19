Telerik.Web.UI.RadContextMenuEventArgs=function(_1){
Telerik.Web.UI.RadContextMenuEventArgs.initializeBase(this);
this._domEvent=_1||null;
};
Telerik.Web.UI.RadContextMenuEventArgs.prototype={get_domEvent:function(){
return this._domEvent;
}};
Telerik.Web.UI.RadContextMenuEventArgs.registerClass("Telerik.Web.UI.RadContextMenuEventArgs",Sys.EventArgs);
Telerik.Web.UI.RadContextMenuShownEventArgs=function(_2,_3){
Telerik.Web.UI.RadContextMenuShownEventArgs.initializeBase(this);
this._targetElement=_2;
this._domEvent=_3||null;
};
Telerik.Web.UI.RadContextMenuShownEventArgs.prototype={get_targetElement:function(){
return this._targetElement;
},get_domEvent:function(){
return this._domEvent;
}};
Telerik.Web.UI.RadContextMenuShownEventArgs.registerClass("Telerik.Web.UI.RadContextMenuShownEventArgs",Sys.EventArgs);
Telerik.Web.UI.RadContextMenuShowingEventArgs=function(_4,_5){
Telerik.Web.UI.RadContextMenuShowingEventArgs.initializeBase(this);
this._targetElement=_4;
this._domEvent=_5;
};
Telerik.Web.UI.RadContextMenuShowingEventArgs.prototype={get_targetElement:function(){
return this._targetElement;
},get_domEvent:function(){
return this._domEvent;
}};
Telerik.Web.UI.RadContextMenuShowingEventArgs.registerClass("Telerik.Web.UI.RadContextMenuShowingEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.RadContextMenuItemEventArgs=function(_6,_7,_8){
Telerik.Web.UI.RadContextMenuItemEventArgs.initializeBase(this,[_6,_8]);
this._targetElement=_7;
};
Telerik.Web.UI.RadContextMenuItemEventArgs.prototype={get_targetElement:function(){
return this._targetElement;
}};
Telerik.Web.UI.RadContextMenuItemEventArgs.registerClass("Telerik.Web.UI.RadContextMenuItemEventArgs",Telerik.Web.UI.RadMenuItemEventArgs);
Telerik.Web.UI.RadContextMenuItemCancelEventArgs=function(_9,_a,_b){
Telerik.Web.UI.RadContextMenuItemCancelEventArgs.initializeBase(this,[_9,_b]);
this._targetElement=_a;
};
Telerik.Web.UI.RadContextMenuItemCancelEventArgs.prototype={get_targetElement:function(){
return this._targetElement;
}};
Telerik.Web.UI.RadContextMenuItemCancelEventArgs.registerClass("Telerik.Web.UI.RadContextMenuItemCancelEventArgs",Telerik.Web.UI.RadMenuItemCancelEventArgs);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.ContextMenuTargetType=function(){
throw Error.notImplemented();
};
Telerik.Web.UI.ContextMenuTargetType.prototype={Control:0,Element:1,TagName:2,Document:3};
Telerik.Web.UI.ContextMenuTargetType.registerEnum("Telerik.Web.UI.ContextMenuTargetType");
Telerik.Web.UI.RadContextMenu=function(_c){
Telerik.Web.UI.RadContextMenu.initializeBase(this,[_c]);
this._targets=[];
this._targetElements=null;
this._shown=false;
this._scrollWrapElement=null;
this._scroller=null;
this._animatedElement=null;
this._slide=null;
this._collapseAnimationEndedDelegate=null;
this._detached=false;
this._currentTarget=null;
};
Telerik.Web.UI.RadContextMenu.contextMenus={};
Telerik.Web.UI.RadContextMenu.hideAll=function(){
for(var _d in Telerik.Web.UI.RadContextMenu.contextMenus){
Telerik.Web.UI.RadContextMenu.contextMenus[_d].hide();
}
};
Telerik.Web.UI.RadContextMenu.prototype={initialize:function(){
this.get_element().style.display="block";
this.get_element().style.visibility="hidden";
this._getContextMenuElement().style.display="block";
this._getContextMenuElement().style.visibility="hidden";
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"initialize");
this._getContextMenuElement().style.display="none";
this._getContextMenuElement().style.visibility="visible";
this.get_element().style.display="none";
this.get_element().style.visibility="visible";
this._getContextMenuElement().style.zIndex=this._originalZIndex;
this.get_childListElement().style.cssFloat="left";
Telerik.Web.UI.RadContextMenu.contextMenus[this.get_id()]=this;
this._elementContextMenu=Function.createDelegate(this,this._elementContextMenu);
this._attachShowHandlers();
this._documentClickHandler=Function.createDelegate(this,this._documentClickHandler);
$addHandler(document,"click",this._documentClickHandler);
this._itemClickedHandler=Function.createDelegate(this,this._itemClickedHandler);
this.add_itemClicked(this._itemClickedHandler);
this._initializeAnimation();
this._initializeScroller();
},dispose:function(){
if(this._detached){
this.attachContextMenu();
}
$removeHandler(document,"click",this._documentClickHandler);
this._detachShowHandlers();
this._targetElements=null;
if(this._collapseAnimationEndedDelegate){
if(this._slide){
this._slide.remove_collapseAnimationEnded(this._collapseAnimationEndedDelegate);
}
this._collapseAnimationEndedDelegate=null;
}
if(this._slide){
this._slide.dispose();
this._slide=null;
}
if(this._scroller){
this._scroller.dispose();
this._scroller=null;
}
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"dispose");
},_initializeEventMap:function(){
this._eventMap.initialize(this,this._getContextMenuElement());
},_childInserted:function(_e,_f,_10){
Telerik.Web.UI.RadMenu.callBaseMethod(this,"_childInserted",[_e,_f,_10]);
if(_10._shown){
if(_f._getWidth()>0||_f.get_isSeparator()){
Telerik.Web.UI.RadMenu._adjustChildrenWidth(_10);
}
}
},_attachShowHandlers:function(){
var _11=$telerik.isOpera?"mousedown":"contextmenu";
var _12=this._getTargetElements();
for(var i=0;i<_12.length;i++){
$addHandler(_12[i],_11,this._elementContextMenu);
}
},_detachShowHandlers:function(){
var _14=$telerik.isOpera?"mousedown":"contextmenu";
var _15=this._getTargetElements();
for(var i=0;i<_15.length;i++){
var _17=_15[i];
try{
$removeHandler(_17,_14,this._elementContextMenu);
}
catch(ex){
}
}
},_documentClickHandler:function(e){
var _19=this._getContextMenuElement();
if(!$telerik.isDescendant(_19,e.target)){
this.close();
this._clicked=false;
this._hide(e);
}
},_itemClickedHandler:function(_1a,_1b){
if(!this.get_clickToOpen()){
this._hide(_1b.get_domEvent());
}
},_initializeAnimation:function(){
this._determineExpandDirection();
var _1c=this._getAnimatedElement();
if(_1c){
this._slide=new Telerik.Web.UI.Slide(_1c,this.get_expandAnimation(),this.get_collapseAnimation());
this._slide.initialize();
this._slide.set_direction(this._getSlideDirection());
this._collapseAnimationEndedDelegate=Function.createDelegate(this,this._onCollapseAnimationEnded);
this._slide.add_collapseAnimationEnded(this._collapseAnimationEndedDelegate);
}
},_getRtlClassName:function(){
return "rmRtlContext";
},_getMainElement:function(){
return this._getContextMenuElement();
},_getSlideDirection:function(){
var _1d=this.get_defaultGroupSettings().get_expandDirection();
if(_1d==Telerik.Web.UI.ExpandDirection.Auto){
return null;
}
return _1d;
},_getScrollWrapElement:function(){
var _1e=this._getContextMenuElement();
if(!this._scrollWrapElement){
if(this.get_defaultGroupSettings().get_height()||this.get_defaultGroupSettings().get_width()){
this._scrollWrapElement=$telerik.getFirstChildByTagName(_1e,"div",0);
}
}
return this._scrollWrapElement;
},_getAnimatedElement:function(){
if(!this._animatedElement){
this._animatedElement=this._getScrollWrapElement()||this.get_childListElement();
}
return this._animatedElement;
},_determineExpandDirection:function(){
var _1f=this.get_defaultGroupSettings();
if(_1f.get_expandDirection()!=Telerik.Web.UI.ExpandDirection.Auto){
return;
}
_1f.set_expandDirection(Telerik.Web.UI.ExpandDirection.Down);
},_onCollapseAnimationEnded:function(_20,e){
this._restoreZIndex();
},_getTargetElements:function(){
if(this._targetElements==null){
this._targetElements=[];
for(var i=0;i<this._targets.length;i++){
this._addTargetElements(this._targets[i]);
}
}
return this._targetElements;
},_addTargetElements:function(_23){
switch(_23.type){
case Telerik.Web.UI.ContextMenuTargetType.Document:
this._addTargetElement(document);
break;
case Telerik.Web.UI.ContextMenuTargetType.Control:
case Telerik.Web.UI.ContextMenuTargetType.Element:
this._addTargetElement($get(_23.id));
break;
case Telerik.Web.UI.ContextMenuTargetType.TagName:
var _24=document.getElementsByTagName(_23.tagName);
for(var i=0;i<_24.length;i++){
this._addTargetElement(_24[i]);
}
break;
}
},_addTargetElement:function(_26){
if(_26){
this._targetElements[this._targetElements.length]=_26;
}
},_adjustPositionForScreenBoundaries:function(_27,top){
var _29=$telerik.getViewPortSize();
var _2a=this._getContextMenuElement();
top=Math.min(top,_29.height-_2a.offsetHeight);
if(this.get_rightToLeft()){
_27=Math.max(0,_27);
}else{
_27=Math.min(_27,_29.width-_2a.offsetWidth);
}
if(isNaN(_27)){
_27=0;
}
if(isNaN(top)){
top=0;
}
this._getContextMenuElement().style.left=_27+"px";
this._getContextMenuElement().style.top=top+"px";
},_detach:function(){
if(!$telerik.isIE||document.readyState=="complete"){
this._getContextMenuElement().parentNode.removeChild(this._getContextMenuElement());
document.forms[0].insertBefore(this._getContextMenuElement(),document.forms[0].firstChild);
this._detached=true;
}
},_getContextMenuElement:function(){
if(!this._contextMenuElement){
this._contextMenuElement=$telerik.getFirstChildByTagName(this.get_element(),"div",0);
}
return this._contextMenuElement;
},_isMainElementDescendant:function(_2b){
return $telerik.isDescendant(this._getContextMenuElement(),_2b);
},attachContextMenu:function(){
if(!this._detached){
return;
}
this._getContextMenuElement().parentNode.removeChild(this._getContextMenuElement());
this.get_element().insertBefore(this._getContextMenuElement(),$get(this.get_clientStateFieldID()));
this._detached=false;
},_getExtendedItemClickingEventArgs:function(_2c){
return new Telerik.Web.UI.RadContextMenuItemCancelEventArgs(_2c.get_item(),this._targetElement,_2c.get_domEvent());
},_getExtendedItemClickedEventArgs:function(_2d){
return new Telerik.Web.UI.RadContextMenuItemEventArgs(_2d.get_item(),this._targetElement,_2d.get_domEvent());
},_updateScrollWrapSize:function(){
var _2e=this._getScrollWrapElement();
var _2f=this.get_childListElement();
if(!_2e){
return;
}
if(!_2e.style.height){
_2e.style.height=_2f.offsetHeight+"px";
}
_2e.style.width=_2f.offsetWidth+"px";
},_getAnimationContainer:function(){
return this._getContextMenuElement();
},_initializeScroller:function(){
var _30=this._getScrollWrapElement();
if(_30){
this._scroller=new Telerik.Web.UI.MenuItemScroller(this.get_childListElement(),Telerik.Web.UI.ItemFlow.Vertical);
this._scroller.initialize();
}
},_adjustRootItemsWidthOnShow:function(){
var _31=this.get_items();
var _32=_31.get_count();
for(var i=0;i<_32;i++){
var _34=_31.getItem(i);
var _35=_34.get_parent();
if(_34._adjustSiblingsWidthOnShow){
_34._adjustSiblingsWidth();
_34._adjustSiblingsWidthOnShow=false;
return;
}
}
},_onTopArrowMouseDown:function(e){
var _37=this._extractItemFromDomElement(e.eventMapTarget);
if(_37!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onTopArrowMouseDown",[e]);
return;
}
this._onScrollArrowMouseDown(Telerik.Web.UI.ArrowPosition.Top);
},_onTopArrowMouseUp:function(e){
var _39=this._extractItemFromDomElement(e.eventMapTarget);
if(_39!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onTopArrowMouseDown",[e]);
return;
}
this._onScrollArrowMouseUp(Telerik.Web.UI.ArrowPosition.Top);
},_onTopArrowMouseOver:function(e){
var _3b=this._extractItemFromDomElement(e.eventMapTarget);
if(_3b!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onTopArrowMouseOver",[e]);
return;
}
this._onScrollArrowMouseOver(Telerik.Web.UI.ArrowPosition.Top);
},_onTopArrowMouseOut:function(e){
var _3d=this._extractItemFromDomElement(e.eventMapTarget);
if(_3d!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onTopArrowMouseOut",[e]);
return;
}
this._onScrollArrowMouseOut(Telerik.Web.UI.ArrowPosition.Top);
},_onBottomArrowMouseDown:function(e){
var _3f=this._extractItemFromDomElement(e.eventMapTarget);
if(_3f!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onBottomArrowMouseDown",[e]);
return;
}
this._onScrollArrowMouseDown(Telerik.Web.UI.ArrowPosition.Bottom);
},_onBottomArrowMouseUp:function(e){
var _41=this._extractItemFromDomElement(e.eventMapTarget);
if(_41!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onBottomArrowMouseUp",[e]);
return;
}
this._onScrollArrowMouseUp(Telerik.Web.UI.ArrowPosition.Bottom);
},_onBottomArrowMouseOver:function(e){
var _43=this._extractItemFromDomElement(e.eventMapTarget);
if(_43!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onBottomArrowMouseOver",[e]);
return;
}
this._onScrollArrowMouseOver(Telerik.Web.UI.ArrowPosition.Bottom);
},_onBottomArrowMouseOut:function(e){
var _45=this._extractItemFromDomElement(e.eventMapTarget);
if(_45!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onBottomArrowMouseOut",[e]);
return;
}
this._onScrollArrowMouseOut(Telerik.Web.UI.ArrowPosition.Bottom);
},_onLeftArrowMouseDown:function(e){
var _47=this._extractItemFromDomElement(e.eventMapTarget);
if(_47!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onLeftArrowMouseDown",[e]);
return;
}
this._onScrollArrowMouseDown(Telerik.Web.UI.ArrowPosition.Left);
},_onLeftArrowMouseUp:function(e){
var _49=this._extractItemFromDomElement(e.eventMapTarget);
if(_49!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onLeftArrowMouseUp",[e]);
return;
}
this._onScrollArrowMouseUp(Telerik.Web.UI.ArrowPosition.Left);
},_onLeftArrowMouseOver:function(e){
var _4b=this._extractItemFromDomElement(e.eventMapTarget);
if(_4b!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onLeftArrowMouseOver",[e]);
return;
}
this._onScrollArrowMouseOver(Telerik.Web.UI.ArrowPosition.Left);
},_onLeftArrowMouseOut:function(e){
var _4d=this._extractItemFromDomElement(e.eventMapTarget);
if(_4d!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onLeftArrowMouseOut",[e]);
return;
}
this._onScrollArrowMouseOut(Telerik.Web.UI.ArrowPosition.Left);
},_onRightArrowMouseDown:function(e){
var _4f=this._extractItemFromDomElement(e.eventMapTarget);
if(_4f!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onRightArrowMouseDown",[e]);
return;
}
this._onScrollArrowMouseDown(Telerik.Web.UI.ArrowPosition.Right);
},_onRightArrowMouseUp:function(e){
var _51=this._extractItemFromDomElement(e.eventMapTarget);
if(_51!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onRightArrowMouseUp",[e]);
return;
}
this._onScrollArrowMouseUp(Telerik.Web.UI.ArrowPosition.Right);
},_onRightArrowMouseOver:function(e){
var _53=this._extractItemFromDomElement(e.eventMapTarget);
if(_53!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onRightArrowMouseOver",[e]);
return;
}
this._onScrollArrowMouseOver(Telerik.Web.UI.ArrowPosition.Right);
},_onRightArrowMouseOut:function(e){
var _55=this._extractItemFromDomElement(e.eventMapTarget);
if(_55!=null){
Telerik.Web.UI.RadContextMenu.callBaseMethod(this,"_onRightArrowMouseOut",[e]);
return;
}
this._onScrollArrowMouseOut(Telerik.Web.UI.ArrowPosition.Right);
},_onScrollArrowMouseDown:function(_56){
if(!this._scroller){
return;
}
this._scroller.changeScrollSpeed(Telerik.Web.UI.ScrollerSpeed.Fast);
},_onScrollArrowMouseUp:function(_57){
if(!this._scroller){
return;
}
this._scroller.changeScrollSpeed(Telerik.Web.UI.ScrollerSpeed.Slow);
},_onScrollArrowMouseOver:function(_58){
if(!this._scroller){
return;
}
var _59=1;
if(_58==Telerik.Web.UI.ArrowPosition.Top||_58==Telerik.Web.UI.ArrowPosition.Left){
_59=-1;
}
this._scroller.startScroll(Telerik.Web.UI.ScrollerSpeed.Slow,_59);
},_onScrollArrowMouseOut:function(_5a){
if(!this._scroller){
return;
}
this._scroller.stopScroll();
},_elementContextMenu:function(_5b){
if($telerik.isOpera){
if(_5b.button!=2){
return;
}
}
this.show(_5b);
},_showAt:function(_5c,top,e){
Telerik.Web.UI.RadContextMenu.hideAll();
this._shown=true;
if(!this._detached){
this._detach();
this._getContextMenuElement().style.visibility="hidden";
this._getContextMenuElement().style.display="block";
this.repaint();
}
var _5f=this._getAnimatedElement();
this._slide.show();
if(this._rightToLeft){
_5c-=this._getContextMenuElement().offsetWidth;
}
this._getContextMenuElement().style.left=_5c+"px";
this._getContextMenuElement().style.top=top+"px";
this._adjustRootItemsWidthOnShow();
this._updateScrollWrapSize();
this._slide.updateSize();
if(this.get_enableScreenBoundaryDetection()){
this._adjustPositionForScreenBoundaries(_5c,top);
}
if(this._scroller){
this._scroller.updateState();
}
this._slide.expand();
this.raise_shown(new Telerik.Web.UI.RadContextMenuShownEventArgs(this._targetElement,e||null));
},_hide:function(e){
if(this._shown){
this._shown=false;
this._slide.collapse();
this.raise_hidden(new Telerik.Web.UI.RadContextMenuEventArgs(e||null));
this._targetElement=null;
this._clicked=false;
if(this._focusedItem){
this._focusedItem._doBlur();
}
var _61=this.get_openedItem();
if(_61){
_61.close();
}
}
},get_childListElement:function(){
if(this._getScrollWrapElement()){
this._childListElement=$telerik.getFirstChildByTagName(this._getScrollWrapElement(),"ul",0);
}
if(!this._childListElement){
this._childListElement=$telerik.getFirstChildByTagName(this._getContextMenuElement(),"ul",0);
}
return this._childListElement;
},set_targets:function(_62){
this._targets=_62;
},get_targets:function(){
return this._targets;
},show:function(e){
this._targetElement=e.target;
var _64=new Telerik.Web.UI.RadContextMenuShowingEventArgs(this._targetElement,e||null);
this.raise_showing(_64);
if(_64.get_cancel()){
return;
}
var _65=$telerik.getDocumentRelativeCursorPosition(e);
this._showAt(_65.left,_65.top,e);
$telerik.cancelRawEvent(e);
},showAt:function(_66,top){
this._showAt(_66,top,null);
},hide:function(){
this._hide(null);
},add_showing:function(_68){
this.get_events().addHandler("showing",_68);
},remove_showing:function(_69){
this.get_events().removeHandler("showing",_69);
},raise_showing:function(_6a){
if(this._fireEvents){
this.raiseEvent("showing",_6a);
}
},add_shown:function(_6b){
this.get_events().addHandler("shown",_6b);
},remove_shown:function(_6c){
this.get_events().removeHandler("shown",_6c);
},raise_shown:function(_6d){
if(this._fireEvents){
this.raiseEvent("shown",_6d);
}
},add_hidden:function(_6e){
this.get_events().addHandler("hidden",_6e);
},remove_hidden:function(_6f){
this.get_events().removeHandler("hidden",_6f);
},raise_hidden:function(_70){
if(this._fireEvents){
this.raiseEvent("hidden",_70);
}
}};
Telerik.Web.UI.RadContextMenu.registerClass("Telerik.Web.UI.RadContextMenu",Telerik.Web.UI.RadMenu);

