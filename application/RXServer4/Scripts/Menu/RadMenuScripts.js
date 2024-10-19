Telerik.Web.UI.RadMenuItemEventArgs=function(_1,_2){
Telerik.Web.UI.RadMenuItemEventArgs.initializeBase(this);
this._item=_1;
this._domEvent=_2||null;
};
Telerik.Web.UI.RadMenuItemEventArgs.prototype={get_item:function(){
return this._item;
},get_domEvent:function(){
return this._domEvent;
}};
Telerik.Web.UI.RadMenuItemEventArgs.registerClass("Telerik.Web.UI.RadMenuItemEventArgs",Sys.EventArgs);
Telerik.Web.UI.RadMenuItemCancelEventArgs=function(_3,_4){
Telerik.Web.UI.RadMenuItemCancelEventArgs.initializeBase(this);
this._item=_3;
this._domEvent=_4||null;
};
Telerik.Web.UI.RadMenuItemCancelEventArgs.prototype={get_item:function(){
return this._item;
},get_domEvent:function(){
return this._domEvent;
}};
Telerik.Web.UI.RadMenuItemCancelEventArgs.registerClass("Telerik.Web.UI.RadMenuItemCancelEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.RadMenuMouseOverEventArgs=function(_5,_6){
Telerik.Web.UI.RadMenuMouseOverEventArgs.initializeBase(this,[_5,_6||null]);
};
Telerik.Web.UI.RadMenuMouseOverEventArgs.registerClass("Telerik.Web.UI.RadMenuMouseOverEventArgs",Telerik.Web.UI.RadMenuItemEventArgs);
Telerik.Web.UI.RadMenuMouseOutEventArgs=function(_7,_8){
Telerik.Web.UI.RadMenuMouseOutEventArgs.initializeBase(this,[_7,_8||null]);
};
Telerik.Web.UI.RadMenuMouseOutEventArgs.registerClass("Telerik.Web.UI.RadMenuMouseOutEventArgs",Telerik.Web.UI.RadMenuItemEventArgs);
Telerik.Web.UI.RadMenuItemFocusEventArgs=function(_9,_a){
Telerik.Web.UI.RadMenuItemFocusEventArgs.initializeBase(this,[_9,_a||null]);
};
Telerik.Web.UI.RadMenuItemFocusEventArgs.registerClass("Telerik.Web.UI.RadMenuItemFocusEventArgs",Telerik.Web.UI.RadMenuItemEventArgs);
Telerik.Web.UI.RadMenuItemBlurEventArgs=function(_b,_c){
Telerik.Web.UI.RadMenuItemBlurEventArgs.initializeBase(this,[_b,_c||null]);
};
Telerik.Web.UI.RadMenuItemBlurEventArgs.registerClass("Telerik.Web.UI.RadMenuItemBlurEventArgs",Telerik.Web.UI.RadMenuItemEventArgs);
Telerik.Web.UI.RadMenuItemClickingEventArgs=function(_d,_e){
Telerik.Web.UI.RadMenuItemClickingEventArgs.initializeBase(this,[_d,_e||null]);
};
Telerik.Web.UI.RadMenuItemClickingEventArgs.registerClass("Telerik.Web.UI.RadMenuItemClickingEventArgs",Telerik.Web.UI.RadMenuItemCancelEventArgs);
Telerik.Web.UI.RadMenuItemClickedEventArgs=function(_f,_10){
Telerik.Web.UI.RadMenuItemClickedEventArgs.initializeBase(this,[_f,_10||null]);
};
Telerik.Web.UI.RadMenuItemClickedEventArgs.registerClass("Telerik.Web.UI.RadMenuItemClickedEventArgs",Telerik.Web.UI.RadMenuItemEventArgs);
Telerik.Web.UI.RadMenuItemOpeningEventArgs=function(_11,_12){
Telerik.Web.UI.RadMenuItemOpeningEventArgs.initializeBase(this,[_11,_12||null]);
};
Telerik.Web.UI.RadMenuItemOpeningEventArgs.registerClass("Telerik.Web.UI.RadMenuItemOpeningEventArgs",Telerik.Web.UI.RadMenuItemCancelEventArgs);
Telerik.Web.UI.RadMenuItemOpenedEventArgs=function(_13,_14){
Telerik.Web.UI.RadMenuItemOpenedEventArgs.initializeBase(this,[_13,_14||null]);
};
Telerik.Web.UI.RadMenuItemOpenedEventArgs.registerClass("Telerik.Web.UI.RadMenuItemOpenedEventArgs",Telerik.Web.UI.RadMenuItemEventArgs);
Telerik.Web.UI.RadMenuItemClosingEventArgs=function(_15,_16){
Telerik.Web.UI.RadMenuItemClosingEventArgs.initializeBase(this,[_15,_16||null]);
};
Telerik.Web.UI.RadMenuItemClosingEventArgs.registerClass("Telerik.Web.UI.RadMenuItemClosingEventArgs",Telerik.Web.UI.RadMenuItemCancelEventArgs);
Telerik.Web.UI.RadMenuItemClosedEventArgs=function(_17,_18){
Telerik.Web.UI.RadMenuItemClosedEventArgs.initializeBase(this,[_17,_18||null]);
};
Telerik.Web.UI.RadMenuItemClosedEventArgs.registerClass("Telerik.Web.UI.RadMenuItemClosedEventArgs",Telerik.Web.UI.RadMenuItemEventArgs);
Telerik.Web.UI.RadMenuItemPopulatingEventArgs=function(_19,_1a){
Telerik.Web.UI.RadMenuItemPopulatingEventArgs.initializeBase(this,[_19]);
this._context=_1a;
};
Telerik.Web.UI.RadMenuItemPopulatingEventArgs.prototype={get_context:function(){
return this._context;
}};
Telerik.Web.UI.RadMenuItemPopulatingEventArgs.registerClass("Telerik.Web.UI.RadMenuItemPopulatingEventArgs",Telerik.Web.UI.RadMenuItemCancelEventArgs);
Telerik.Web.UI.RadMenuItemPopulatedEventArgs=function(_1b){
Telerik.Web.UI.RadMenuItemPopulatedEventArgs.initializeBase(this,[_1b]);
};
Telerik.Web.UI.RadMenuItemPopulatedEventArgs.registerClass("Telerik.Web.UI.RadMenuItemPopulatedEventArgs",Telerik.Web.UI.RadMenuItemEventArgs);
Telerik.Web.UI.RadMenuItemPopulationFailedEventArgs=function(_1c,_1d){
Telerik.Web.UI.RadMenuItemPopulationFailedEventArgs.initializeBase(this,[_1c]);
this._errorMessage=_1d;
};
Telerik.Web.UI.RadMenuItemPopulationFailedEventArgs.prototype={get_errorMessage:function(){
return this._errorMessage;
}};
Telerik.Web.UI.RadMenuItemPopulationFailedEventArgs.registerClass("Telerik.Web.UI.RadMenuItemPopulationFailedEventArgs",Telerik.Web.UI.RadMenuItemCancelEventArgs);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.ItemFlow=function(){
};
Telerik.Web.UI.ItemFlow.prototype={Vertical:0,Horizontal:1};
Telerik.Web.UI.ItemFlow.registerEnum("Telerik.Web.UI.ItemFlow");
Telerik.Web.UI.ExpandDirection=function(){
};
Telerik.Web.UI.ExpandDirection.prototype={Auto:0,Up:1,Down:2,Left:3,Right:4};
Telerik.Web.UI.ExpandDirection.registerEnum("Telerik.Web.UI.ExpandDirection");
Telerik.Web.UI.RadMenu=function(_1e){
Telerik.Web.UI.RadMenu.initializeBase(this,[_1e]);
this._childTypeName="Telerik.Web.UI.RadMenuItem";
this._itemData=null;
this._expandAnimation=new Telerik.Web.UI.AnimationSettings({});
this._expandDelay=100;
this._collapseAnimation=new Telerik.Web.UI.AnimationSettings({});
this._collapseDelay=500;
this._flow=Telerik.Web.UI.ItemFlow.Horizontal;
this._defaultGroupSettings=new Telerik.Web.UI.RadMenuItemGroupSettings({});
this._enableAutoScroll=false;
this._autoScrollMinimumHeight=50;
this._autoScrollMinimumWidth=50;
this._enableScreenBoundaryDetection=true;
this._clickToOpen=false;
this._childListElement=null;
this._postBackReference=null;
this._onClickDelegate=null;
this._webServiceSettings=new Telerik.Web.UI.WebServiceSettings({});
this._persistLoadOnDemandItems=true;
this._enableOverlay=true;
this._enabled=true;
this._visible=true;
this._openedItem=null;
this._lastOpenedItem=null;
this._childrenDetached=false;
this._originalZIndex=null;
this._defaultZIndex=7000;
this._zIndexIncrementDepth=0;
this._fireEvents=true;
this._webServiceLoader=null;
this._loadingTemplate="";
this._onMouseOutDelegate=null;
this._onClickDelegate=null;
this._onResizeDelegate=null;
this._aboutToCollapse=false;
this._rightToLeft=null;
this._skin=null;
};
Telerik.Web.UI.RadMenu._createChildControls=function(_1f,_20){
var _21=_1f.get_itemData();
if(!_21){
return;
}
var _22=$telerik.getChildrenByTagName(_1f.get_childListElement(),"li");
Sys.Debug.assert(_21.length==_22.length,"Length of elements and json must be the same!");
for(var i=0;i<_21.length;i++){
var _24=new Telerik.Web.UI.RadMenuItem();
_20.add(_24);
_24._initialize(_21[i],_22[i]);
}
};
Telerik.Web.UI.RadMenu._adjustChildrenWidth=function(_25,_26){
var _27=_25._getControl();
var _28=_25.get_items();
var _29=_28.get_count();
if(_26){
for(var i=0;i<_29;i++){
_28.getItem(i)._clearWidth();
}
}
var _2b=Telerik.Web.UI.RadMenu._getMaxChildWidth(_25)+"px";
Telerik.Web.UI.RadMenu._setChildrenWidth(_25,_2b);
};
Telerik.Web.UI.RadMenu._getMaxChildWidth=function(_2c){
var _2d=0;
var _2e=_2c._getControl();
var _2f=_2c.get_items();
var _30=_2f.get_count();
for(var i=0;i<_30;i++){
if(_2e.get_rightToLeft()){
var _32=_2f.getItem(i).get_imageElement();
if(_32){
_32.style.styleFloat="left";
_32.style.cssFloat="left";
}
}
var _33=_2f.getItem(i)._getWidth();
_2d=Math.max(_33,_2d);
}
if(_2c.get_groupSettings){
groupWidth=_2c.get_groupSettings().get_width();
if(groupWidth){
_2d=groupWidth;
}
}
return _2d;
};
Telerik.Web.UI.RadMenu._setChildrenWidth=function(_34,_35){
var _36=_34._getControl();
var _37=_34.get_items();
var _38=_37.get_count();
for(var i=0;i<_38;i++){
if(_36.get_rightToLeft()){
var _3a=_37.getItem(i).get_imageElement();
if(_3a){
_3a.style.styleFloat="right";
_3a.style.cssFloat="right";
}
}
_37.getItem(i)._setWidth(_35);
}
if($telerik.isSafari){
var _3b=_34.get_childListElement();
_3b.style.width=_35;
}
};
Telerik.Web.UI.RadMenu._adjustRootItemWidth=function(_3c,_3d){
var _3e=$get(_3c);
var _3f=Telerik.Web.UI.RadMenu._getMaxRootItemWidth(_3e,_3d||null);
Telerik.Web.UI.RadMenu._setRootItemWidth(_3e,_3f,_3d||null);
};
Telerik.Web.UI.RadMenu._getChildListElement=function(_40){
var _41=$telerik.getFirstChildByTagName(_40,"ul",0);
if(!_41){
var _42=$telerik.getFirstChildByTagName(_40,"div",0);
_41=$telerik.getFirstChildByTagName(_42,"ul",0);
if(!_41){
var _43=_42;
_42=$telerik.getFirstChildByTagName(_43,"div",0);
_41=$telerik.getFirstChildByTagName(_42,"ul",0);
}
}
return _41;
};
Telerik.Web.UI.RadMenu._getMaxRootItemWidth=function(_44,_45){
if(!_45){
_45=Telerik.Web.UI.RadMenu._getChildListElement(_44);
}
var _46=_45.childNodes;
var _47=_46.length;
var _48=0;
for(var i=0;i<_47;i++){
var _4a=_46[i];
if(_4a.nodeType===3){
continue;
}
var _4b=$telerik.getFirstChildByTagName(_4a,"a",0);
var _4c;
if(_4b){
_4c=_4b.offsetWidth;
}else{
_4c=_4a.offsetWidth;
}
_48=Math.max(_48,_4c);
}
return _48;
};
Telerik.Web.UI.RadMenu._setRootItemWidth=function(_4d,_4e,_4f){
if(!_4f){
_4f=Telerik.Web.UI.RadMenu._getChildListElement(_4d);
}
var _50=_4f.childNodes;
var _51=_50.length;
if($telerik.isOpera){
_4f.style.cssFloat="none";
}
if(_4e==0){
return;
}
for(var i=0;i<_51;i++){
var _53=_50[i];
if(_53.nodeType==3){
continue;
}
var _54=$telerik.getFirstChildByTagName(_53,"a",0);
if(!_54){
_54=_53;
}
var _55=_4e;
var _56=$telerik.getPaddingBox(_54).horizontal;
var _57=$telerik.getBorderBox(_54).horizontal;
_55-=_56+_57;
var _58=_54.style.width;
if(!_58||_55!=_58){
_54.style.width=_55+"px";
}
}
if($telerik.isSafari){
_4f.style.width=_4e;
}
if(_4d.style.width===""&&Telerik.Web.UI.RadMenu._requiresRightToLeft(_4d)){
_4d.style.width=_4e+"px";
}
};
Telerik.Web.UI.RadMenu._requiresRightToLeft=function(_59){
var _5a=_59;
while(_5a.nodeType!==9){
if(_5a.dir=="rtl"){
return true;
}
_5a=_5a.parentNode;
}
return false;
};
Telerik.Web.UI.RadMenu._adjustListWidth=function(_5b){
var _5c=_5b._getControl();
if(_5c.get_rightToLeft()){
Telerik.Web.UI.RadMenu._adjustChildrenWidth(_5b);
}
var _5d=_5b.get_childListElement();
var _5e=0;
for(var i=0;i<_5d.childNodes.length;i++){
var _60=_5d.childNodes[i];
if(_60.nodeType==3){
continue;
}
_5e+=_60.offsetWidth;
_60.style.clear="none";
}
_5d.style.width=_5e+"px";
};
Telerik.Web.UI.RadMenu.prototype={initialize:function(){
Telerik.Web.UI.RadMenu.callBaseMethod(this,"initialize");
var _61=this.get_element();
if(this.get_rightToLeft()){
this._initRightToLeft();
}
if(this._flow==Telerik.Web.UI.ItemFlow.Vertical){
var _62=this.get_element().id;
Telerik.Web.UI.RadMenu._adjustRootItemWidth(_62,this.get_childListElement());
}
this._originalZIndex=parseInt($telerik.getCurrentStyle(_61,"zIndex"));
if(!this._originalZIndex){
_61.style.zIndex=this._defaultZIndex;
this._originalZIndex=this._defaultZIndex;
}
this._onClickDelegate=Function.createDelegate(this,this._onClick);
$addHandler(document,"click",this._onClickDelegate);
if(!this.get_clickToOpen()){
if($telerik.isIE){
this._onMouseOutDelegate=Function.createDelegate(this,this._onMouseOut);
$addHandler(document,"mouseout",this._onMouseOutDelegate);
}
}
this._onResizeDelegate=Function.createDelegate(this,this._onResize);
$addHandler(window,"resize",this._onResizeDelegate);
this._eventMap.addHandlerForClassName("mouseover","rmItem",this._onItemMouseOver);
this._eventMap.addHandlerForClassName("mouseout","rmItem",this._onItemMouseOut);
this._eventMap.addHandlerForClassName("dragstart","rmItem",this._onItemDragStart);
this._eventMap.addHandlerForClassName("click","rmLink",this._onLinkClick);
this._eventMap.addHandlerForClassName("mouseover","rmLink",this._onLinkMouseOver);
this._eventMap.addHandlerForClassName("mouseout","rmLink",this._onLinkMouseOut);
this._eventMap.addHandlerForClassName("mousedown","rmLink",this._onLinkMouseDown);
this._eventMap.addHandlerForClassName("mouseup","rmLink",this._onLinkMouseUp);
this._eventMap.addHandlerForClassName("blur","rmLink",this._onLinkBlur);
this._eventMap.addHandlerForClassName("deactivate","rmLink",this._onLinkBlur);
this._eventMap.addHandlerForClassName("focus","rmLink",this._onLinkFocus);
this._eventMap.addHandlerForClassName("activate","rmLink",this._onLinkFocus);
this._eventMap.addHandlerForClassName("keydown","rmLink",this._onLinkKeyDown);
this._eventMap.addHandlerForClassName("mousedown","rmTopArrow",this._onTopArrowMouseDown);
this._eventMap.addHandlerForClassName("mouseup","rmTopArrow",this._onTopArrowMouseUp);
this._eventMap.addHandlerForClassName("mouseover","rmTopArrow",this._onTopArrowMouseOver);
this._eventMap.addHandlerForClassName("mouseout","rmTopArrow",this._onTopArrowMouseOut);
this._eventMap.addHandlerForClassName("click","rmTopArrow",this._onScrollArrowClicked);
this._eventMap.addHandlerForClassName("mousedown","rmBottomArrow",this._onBottomArrowMouseDown);
this._eventMap.addHandlerForClassName("mouseup","rmBottomArrow",this._onBottomArrowMouseUp);
this._eventMap.addHandlerForClassName("mouseover","rmBottomArrow",this._onBottomArrowMouseOver);
this._eventMap.addHandlerForClassName("mouseout","rmBottomArrow",this._onBottomArrowMouseOut);
this._eventMap.addHandlerForClassName("click","rmBottomArrow",this._onScrollArrowClicked);
this._eventMap.addHandlerForClassName("mousedown","rmLeftArrow",this._onLeftArrowMouseDown);
this._eventMap.addHandlerForClassName("mouseup","rmLeftArrow",this._onLeftArrowMouseUp);
this._eventMap.addHandlerForClassName("mouseover","rmLeftArrow",this._onLeftArrowMouseOver);
this._eventMap.addHandlerForClassName("mouseout","rmLeftArrow",this._onLeftArrowMouseOut);
this._eventMap.addHandlerForClassName("click","rmLeftArrow",this._onScrollArrowClicked);
this._eventMap.addHandlerForClassName("mousedown","rmRightArrow",this._onRightArrowMouseDown);
this._eventMap.addHandlerForClassName("mouseup","rmRightArrow",this._onRightArrowMouseUp);
this._eventMap.addHandlerForClassName("mouseover","rmRightArrow",this._onRightArrowMouseOver);
this._eventMap.addHandlerForClassName("mouseout","rmRightArrow",this._onRightArrowMouseOut);
this._eventMap.addHandlerForClassName("click","rmRightArrow",this._onScrollArrowClicked);
if(!this.get_enabled()){
this.set_enabled(false);
}
this._raiseEvent("load",null);
},dispose:function(){
Telerik.Web.UI.RadMenu.callBaseMethod(this,"dispose");
if(this._onClickDelegate){
$removeHandler(document,"click",this._onClickDelegate);
this._onClickDelegate=null;
}
if(this._onMouseOutDelegate){
$removeHandler(document,"mouseout",this._onMouseOutDelegate);
this._onMouseOutDelegate=null;
}
if(this._onResizeDelegate){
$removeHandler(window,"resize",this._onResizeDelegate);
this._onResizeDelegate=null;
}
if(this._eventMap){
this._eventMap.dispose();
this._eventMap=null;
}
},repaint:function(){
if(this._flow==Telerik.Web.UI.ItemFlow.Vertical){
Telerik.Web.UI.RadMenu._adjustRootItemWidth(this.get_id(),this.get_childListElement());
}
},get_items:function(){
return this._getChildren();
},set_items:function(_63){
this._children=_63;
},get_enableScreenBoundaryDetection:function(){
return this._enableScreenBoundaryDetection;
},set_enableScreenBoundaryDetection:function(_64){
this._enableScreenBoundaryDetection=_64;
},get_enableAutoScroll:function(){
return this._enableAutoScroll;
},set_enableAutoScroll:function(_65){
this._enableAutoScroll=_65;
},get_autoScrollMinimumHeight:function(){
return this._autoScrollMinimumHeight;
},set_autoScrollMinimumHeight:function(_66){
this._autoScrollMinimumHeight=_66;
},get_autoScrollMinimumWidth:function(){
return this._autoScrollMinimumWidth;
},set_autoScrollMinimumWidth:function(_67){
this._autoScrollMinimumWidth=_67;
},get_childListElement:function(){
if(!this._childListElement){
this._childListElement=$telerik.getFirstChildByTagName(this.get_element(),"ul",0);
}
return this._childListElement;
},get_expandAnimation:function(){
return this._expandAnimation;
},set_expandAnimation:function(_68){
var _69=Sys.Serialization.JavaScriptSerializer.deserialize(_68);
this._expandAnimation=new Telerik.Web.UI.AnimationSettings(_69);
},get_collapseAnimation:function(){
return this._collapseAnimation;
},set_collapseAnimation:function(_6a){
var _6b=Sys.Serialization.JavaScriptSerializer.deserialize(_6a);
this._collapseAnimation=new Telerik.Web.UI.AnimationSettings(_6b);
},get_defaultGroupSettings:function(){
return this._defaultGroupSettings;
},set_defaultGroupSettings:function(_6c){
var _6d=Sys.Serialization.JavaScriptSerializer.deserialize(_6c);
this._defaultGroupSettings=new Telerik.Web.UI.RadMenuItemGroupSettings(_6d);
},get_itemData:function(){
return this._itemData;
},set_itemData:function(_6e){
this._itemData=_6e;
},set_enabled:function(_6f){
Telerik.Web.UI.RadMenu.callBaseMethod(this,"set_enabled",[_6f]);
if(!this.get_isInitialized()){
return;
}
var _70=this.get_element();
var _71=this.get_items();
var _72=_71.get_count();
if(!_6f){
_70.disabled="disabled";
this.disableEvents();
for(var i=0;i<_72;i++){
_71.getItem(i).disable();
}
}else{
_70.disabled="";
this.enableEvents();
for(var i=0;i<_72;i++){
_71.getItem(i).enable();
}
}
},get_allItems:function(){
return this._getAllItems();
},get_focusedItem:function(){
return this._focusedItem;
},get_openedItem:function(){
return this._openedItem;
},get_clickToOpen:function(){
return this._clickToOpen;
},set_clickToOpen:function(_74){
this._clickToOpen=_74;
},get_collapseDelay:function(){
return this._collapseDelay;
},set_collapseDelay:function(_75){
this._collapseDelay=_75;
},get_expandDelay:function(){
return this._expandDelay;
},set_expandDelay:function(_76){
this._expandDelay=_76;
},get_loadingTemplate:function(){
return this._loadingTemplate;
},set_loadingTemplate:function(_77){
this._loadingTemplate=_77;
},get_webServiceSettings:function(){
return this._webServiceSettings;
},set_webServiceSettings:function(_78){
var _79=Sys.Serialization.JavaScriptSerializer.deserialize(_78);
this._webServiceSettings=new Telerik.Web.UI.WebServiceSettings(_79);
},get_rightToLeft:function(){
if(this._rightToLeft===null){
this._rightToLeft=Telerik.Web.UI.RadMenu._requiresRightToLeft(this.get_element());
}
return this._rightToLeft;
},set_rightToLeft:function(_7a){
this._rightToLeft=_7a;
},set_clicked:function(_7b){
this._clicked=_7b;
},get_clicked:function(){
return this._clicked;
},saveClientState:function(){
var _7c=this._log._logEntries;
var _7d={logEntries:_7c};
return Sys.Serialization.JavaScriptSerializer.serialize(_7d);
},close:function(){
var _7e=this.get_openedItem();
if(_7e){
_7e.close();
}
},disable:function(){
this.set_enabled(false);
},enable:function(){
this.set_enabled(true);
},disableEvents:function(){
this._fireEvents=false;
},enableEvents:function(){
this._fireEvents=true;
},focus:function(){
this.get_element().focus();
},findItemByText:function(_7f){
return this._findItemByText(_7f);
},findItemByUrl:function(){
Error.notImplemented();
},findItemByValue:function(_80){
return this._findItemByValue(_80);
},findItemByAttribute:function(_81,_82){
return this._findItemByAttribute(_81,_82);
},get_allItems:function(){
return this._getAllItems();
},get_persistLoadOnDemandItems:function(){
return this._persistLoadOnDemandItems;
},set_persistLoadOnDemandItems:function(_83){
this._persistLoadOnDemandItems=_83;
},get_enableOverlay:function(){
return this._enableOverlay;
},set_enableOverlay:function(_84){
this._enableOverlay=_84;
},_isMainElementDescendant:function(_85){
return $telerik.isDescendant(this.get_element(),_85);
},_createChildControls:function(){
this._children=new Telerik.Web.UI.RadMenuItemCollection(this);
Telerik.Web.UI.RadMenu._createChildControls(this,this._children);
},_onMouseOut:function(e){
var _87=e.rawEvent.relatedTarget?e.rawEvent.relatedTarget:e.rawEvent.toElement;
var _88=this.get_element();
if(!_87&&!this._isMainElementDescendant(e.target)){
var _89=this;
setTimeout(function(){
_89.close();
},this.get_collapseDelay());
}
},_onClick:function(e){
if(!this._isMainElementDescendant(e.target)){
var _8b=this.get_clickToOpen();
if(this._focusedItem||_8b){
this.close();
if(this.get_clickToOpen()){
this.set_clicked(false);
}
}
}
},_onResize:function(e){
},_onItemMouseOver:function(e){
var _8e=this._extractItemFromDomElement(e.eventMapTarget);
if(!_8e.get_enabled()){
return true;
}
_8e._preventClose();
if(this.get_clickToOpen()&&!this.get_clicked()){
return true;
}
if(_8e._state==Telerik.Web.UI.RadMenuItemState.Open||_8e._state==Telerik.Web.UI.RadMenuItemState.AboutToOpen){
return true;
}
var _8f=_8e.get_parent();
var _90=_8f.get_openedItem();
if(_90&&_90!=_8e){
_90._clearTimeout();
_90._state=Telerik.Web.UI.RadMenuItemState.AboutToClose;
_90._setTimeout(function(){
_90.close();
_90._timeoutRef=null;
},this.get_expandDelay());
}
if(_8e.get_items().get_count()==0&&!_8e._isWebServiceCallNeeded()){
return true;
}
this._lastOpenedItem=_8e;
_8e._state=Telerik.Web.UI.RadMenuItemState.AboutToOpen;
_8e._setTimeout(function(){
_8e.open();
_8e._timeoutRef=null;
},this.get_expandDelay());
return true;
},_onItemMouseOut:function(e){
var _92=this._extractItemFromDomElement(e.eventMapTarget);
if(!_92.get_enabled()){
return true;
}
var _93=e.eventMapRelatedTarget;
var _94=_92.get_element();
if(!_93||_94==_93||$telerik.isDescendant(_94,_93)){
return true;
}
if(this._childrenDetached&&$telerik.isDescendant(_92.get_parent()._getAnimationContainer(),_93)){
return true;
}
if(_92._state==Telerik.Web.UI.RadMenuItemState.Closed||_92._state==Telerik.Web.UI.RadMenuItemState.AboutToClose){
return true;
}
if(_92._state==Telerik.Web.UI.RadMenuItemState.AboutToOpen){
_92._clearTimeout();
_92._state=Telerik.Web.UI.RadMenuItemState.Closed;
_92.get_parent()._openedItem=null;
return true;
}
if(this.get_clickToOpen()){
return true;
}
_92._state=Telerik.Web.UI.RadMenuItemState.AboutToClose;
_92._setTimeout(function(){
_92.close();
_92._timeoutRef=null;
},this._collapseDelay);
return true;
},_onItemDragStart:function(e){
e.preventDefault();
return false;
},_onLinkClick:function(e){
var _97=this._extractItemFromDomElement(e.eventMapTarget);
if(!_97._click(e)){
e.preventDefault();
return false;
}
return true;
},_onLinkMouseOver:function(e){
var _99=e.eventMapRelatedTarget;
var _9a=this._extractItemFromDomElement(e.eventMapTarget);
if(!_9a.get_enabled()){
return true;
}
var _9b=_9a.get_linkElement();
if(!_99||_9b==_99||$telerik.isDescendant(_9b,_99)){
return true;
}
_9a._hovered=true;
_9a._updateImageSrc();
this._raiseEvent("mouseOver",new Telerik.Web.UI.RadMenuMouseOverEventArgs(_9a,e));
return true;
},_onLinkMouseOut:function(e){
var _9d=e.eventMapRelatedTarget;
var _9e=this._extractItemFromDomElement(e.eventMapTarget);
if(!_9e.get_enabled()){
return true;
}
var _9f=_9e.get_linkElement();
if(!_9d||!_9f){
return;
}
if(_9f==_9d||$telerik.isDescendant(_9f,_9d)){
return true;
}
_9e._hovered=false;
_9e._updateImageSrc();
this._raiseEvent("mouseOut",new Telerik.Web.UI.RadMenuMouseOutEventArgs(_9e,e));
return true;
},_onLinkMouseDown:function(e){
var _a1=this._extractItemFromDomElement(e.eventMapTarget);
if(!_a1.get_enabled()){
return true;
}
_a1._clicked=true;
_a1._updateLinkClass();
_a1._updateImageSrc();
return true;
},_onLinkMouseUp:function(e){
var _a3=this._extractItemFromDomElement(e.eventMapTarget);
if(!_a3.get_enabled()){
return true;
}
_a3._clicked=false;
_a3._updateLinkClass();
_a3._updateImageSrc();
return true;
},_onLinkBlur:function(e){
var _a5=this._extractItemFromDomElement(e.eventMapTarget);
if(!_a5.get_enabled()){
return true;
}
_a5._focused=false;
_a5.blur();
return true;
},_onLinkFocus:function(e){
var _a7=this._extractItemFromDomElement(e.eventMapTarget);
if(!_a7.get_enabled()){
return true;
}
_a7._focused=true;
_a7.focus();
return true;
},_onLinkKeyDown:function(e){
var _a9=this._extractItemFromDomElement(e.eventMapTarget);
if(!_a9.get_enabled()){
return true;
}
return _a9._onKeyDown(e);
},_onTopArrowMouseDown:function(e){
var _ab=this._extractItemFromDomElement(e.eventMapTarget);
_ab._onScrollArrowMouseDown(Telerik.Web.UI.ArrowPosition.Top);
},_onTopArrowMouseUp:function(e){
var _ad=this._extractItemFromDomElement(e.eventMapTarget);
_ad._onScrollArrowMouseUp(Telerik.Web.UI.ArrowPosition.Top);
},_onTopArrowMouseOver:function(e){
var _af=this._extractItemFromDomElement(e.eventMapTarget);
_af._onScrollArrowMouseOver(Telerik.Web.UI.ArrowPosition.Top);
},_onTopArrowMouseOut:function(e){
var _b1=this._extractItemFromDomElement(e.eventMapTarget);
_b1._onScrollArrowMouseOut(Telerik.Web.UI.ArrowPosition.Top);
},_onBottomArrowMouseDown:function(e){
var _b3=this._extractItemFromDomElement(e.eventMapTarget);
_b3._onScrollArrowMouseDown(Telerik.Web.UI.ArrowPosition.Bottom);
},_onBottomArrowMouseUp:function(e){
var _b5=this._extractItemFromDomElement(e.eventMapTarget);
_b5._onScrollArrowMouseUp(Telerik.Web.UI.ArrowPosition.Bottom);
},_onBottomArrowMouseOver:function(e){
var _b7=this._extractItemFromDomElement(e.eventMapTarget);
_b7._onScrollArrowMouseOver(Telerik.Web.UI.ArrowPosition.Bottom);
},_onBottomArrowMouseOut:function(e){
var _b9=this._extractItemFromDomElement(e.eventMapTarget);
_b9._onScrollArrowMouseOut(Telerik.Web.UI.ArrowPosition.Bottom);
},_onLeftArrowMouseDown:function(e){
var _bb=this._extractItemFromDomElement(e.eventMapTarget);
_bb._onScrollArrowMouseDown(Telerik.Web.UI.ArrowPosition.Left);
},_onLeftArrowMouseUp:function(e){
var _bd=this._extractItemFromDomElement(e.eventMapTarget);
_bd._onScrollArrowMouseUp(Telerik.Web.UI.ArrowPosition.Left);
},_onLeftArrowMouseOver:function(e){
var _bf=this._extractItemFromDomElement(e.eventMapTarget);
_bf._onScrollArrowMouseOver(Telerik.Web.UI.ArrowPosition.Left);
},_onLeftArrowMouseOut:function(e){
var _c1=this._extractItemFromDomElement(e.eventMapTarget);
_c1._onScrollArrowMouseOut(Telerik.Web.UI.ArrowPosition.Left);
},_onRightArrowMouseDown:function(e){
var _c3=this._extractItemFromDomElement(e.eventMapTarget);
_c3._onScrollArrowMouseDown(Telerik.Web.UI.ArrowPosition.Right);
},_onRightArrowMouseUp:function(e){
var _c5=this._extractItemFromDomElement(e.eventMapTarget);
_c5._onScrollArrowMouseUp(Telerik.Web.UI.ArrowPosition.Right);
},_onRightArrowMouseOver:function(e){
var _c7=this._extractItemFromDomElement(e.eventMapTarget);
_c7._onScrollArrowMouseOver(Telerik.Web.UI.ArrowPosition.Right);
},_onRightArrowMouseOut:function(e){
var _c9=this._extractItemFromDomElement(e.eventMapTarget);
_c9._onScrollArrowMouseOut(Telerik.Web.UI.ArrowPosition.Right);
},_onScrollArrowClicked:function(e){
e.preventDefault();
e.stopPropagation();
return false;
},_childrenCleared:function(_cb){
if(_cb._slideWrapElement){
_cb._slideWrapElement.outerHTML="";
_cb._slideWrapElement=null;
_cb._scrollWrapElement=null;
}
_cb._linkElement=null;
_cb._childListElement=null;
_cb._animatedElement=null;
_cb._animationContainer=null;
Telerik.Web.UI.RadMenu.callBaseMethod(this,"_childrenCleared",[_cb]);
},_childInserted:function(_cc,_cd,_ce){
Telerik.Web.UI.RadMenu.callBaseMethod(this,"_childInserted",[_cc,_cd,_ce]);
if(_ce._state&&_ce._state==Telerik.Web.UI.RadMenuItemState.Open){
if(_cd._getWidth()>0){
Telerik.Web.UI.RadMenu._adjustChildrenWidth(_ce);
}
}
},_childRemoved:function(_cf,_d0){
_cf.get_text();
var _d1=_cf.get_element();
if(_d0.get_items().get_count()==0){
if(_d0._slide){
_d0._slide.dispose();
_d0._slide=null;
}
_d1=$telerik.getFirstChildByTagName(_d0.get_element(),"div",0);
_d0._linkElement=null;
_d0._childListElement=null;
_d0._scrollWrapElement=null;
_d0._slideWrapElement=null;
_d0._animatedElement=null;
_d0._animationContainer=null;
}
if(_d1){
_d1.outerHTML="";
if(_d1.parentNode){
_d1.parentNode.removeChild(_d1);
}
_d1=null;
}
var _d2=_d0.get_items().get_count();
if(_d2>0){
var _d3=_d0.get_items().getItem(0).get_element();
if(_d3&&!Sys.UI.DomElement.containsCssClass(_d3,"rmFirst")){
_d3.className+=" rmFirst";
}
}
var _d4=_d2-1;
if(_d2>0){
var _d5=_d0.get_items().getItem(_d4).get_element();
if(_d5&&!Sys.UI.DomElement.containsCssClass(_d5,"rmLast")){
_d5.className+=" rmLast";
}
}
Telerik.Web.UI.RadMenu.callBaseMethod(this,"_childRemoved",[_cf,_d0]);
if(_d0._state&&_d0._state==Telerik.Web.UI.RadMenuItemState.Open){
Telerik.Web.UI.RadMenu._adjustChildrenWidth(_d0,true);
}
},_getExtendedItemClickingEventArgs:function(_d6){
return _d6;
},_getExtendedItemClickedEventArgs:function(_d7){
return _d7;
},_incrementZIndex:function(_d8){
if(this._zIndexIncrementDepth==0){
var _d9=this.get_element();
_d9.style.zIndex=this._originalZIndex+_d8;
}
this._zIndexIncrementDepth++;
},_restoreZIndex:function(){
if(this._zIndexIncrementDepth>0){
this._zIndexIncrementDepth--;
}
if(this._zIndexIncrementDepth==0){
var _da=this.get_element();
_da.style.zIndex=this._originalZIndex;
}
},_getRtlClassName:function(){
return "rmRtl";
},_getMainElement:function(){
return this.get_element();
},_initRightToLeft:function(){
var _db=this._getMainElement();
_db.dir="ltr";
if(_db.className.indexOf("rmRtl")<0){
_db.className=String.format("{0} {1}",_db.className,this._getRtlClassName());
if(this._skin){
_db.className=String.format("{0} RadMenu_{1}_rtl",_db.className,this._skin);
}
}
for(var i=0;i<this.get_items().get_count();i++){
var _dd=this.get_items().getItem(i);
var _de=_dd.get_imageElement();
if(_de){
_de.style.styleFloat="left";
_de.style.cssFloat="left";
_dd.get_linkElement().style.width=_dd._getWidth()+"px";
_de.style.styleFloat="right";
_de.style.cssFloat="right";
}
}
},_postback:function(_df){
if(!this._postBackReference){
return;
}
var _e0=this._postBackReference.replace("arguments",_df);
eval(_e0);
},_raiseEvent:function(_e1,_e2){
if(this._fireEvents){
this.raiseEvent(_e1,_e2);
}
},_initializeWebServiceLoader:function(){
this._webServiceLoader=new Telerik.Web.UI.WebServiceLoader(this.get_webServiceSettings());
this._webServiceLoader.add_loadingStarted(Function.createDelegate(this,this._onItemLoadingStarted));
this._webServiceLoader.add_loadingSuccess(Function.createDelegate(this,this._onItemLoadingSuccess));
this._webServiceLoader.add_loadingError(Function.createDelegate(this,this._onItemLoadingError));
},_loadChildrenFromWebService:function(_e3){
if(!this._webServiceLoader){
this._initializeWebServiceLoader();
}
var _e4={};
var _e5=new Telerik.Web.UI.RadMenuItemPopulatingEventArgs(_e3,_e4);
this._raiseEvent("itemPopulating",_e5);
if(_e5.get_cancel()){
return;
}
var _e6={Text:_e3.get_text(),Value:_e3.get_value(),ExpandMode:_e3.get_expandMode()};
var _e7={item:_e6,context:_e4};
this._webServiceLoader.loadData(_e7,_e3);
},_onItemLoadingStarted:function(_e8,_e9){
var _ea=_e9.get_context();
_ea._onChildrenLoading();
},_onItemLoadingSuccess:function(_eb,_ec){
var _ed=_ec.get_data();
var _ee=_ec.get_context();
var _ef=_ee.get_items();
for(i=0;i<_ed.length;i++){
var _f1=_ed[i];
var _f2=new Telerik.Web.UI.RadMenuItem();
_f2._loadFromDictionary(_f1);
if(_f2.get_navigateUrl()===""){
_f2.set_navigateUrl("#");
}
_ef.add(_f2);
}
_ee._onChildrenLoaded();
if(this.get_persistLoadOnDemandItems()){
this.trackChanges();
_ee.set_expandMode(Telerik.Web.UI.MenuItemExpandMode.ClientSide);
var _f3=_ef.get_count();
for(var i=0;i<_f3;i++){
this._log.logInsert(_ef.getItem(i));
}
this.commitChanges();
}
var _f4=new Telerik.Web.UI.RadMenuItemPopulatedEventArgs(_ee);
this._raiseEvent("itemPopulated",_f4);
},_onItemLoadingError:function(_f5,_f6){
var _f7=_f6.get_message();
var _f8=_f6.get_context();
_f8._onChildrenLoadingError();
var _f9=new Telerik.Web.UI.RadMenuItemPopulationFailedEventArgs(_f8,_f7);
this._raiseEvent("itemPopulationFailed",_f9);
if(_f9.get_cancel()){
return;
}
alert(_f7);
},add_mouseOver:function(_fa){
this.get_events().addHandler("mouseOver",_fa);
},remove_mouseOver:function(_fb){
this.get_events().removeHandler("mouseOver",_fb);
},add_mouseOut:function(_fc){
this.get_events().addHandler("mouseOut",_fc);
},remove_mouseOut:function(_fd){
this.get_events().removeHandler("mouseOut",_fd);
},add_itemFocus:function(_fe){
this.get_events().addHandler("itemFocus",_fe);
},remove_itemFocus:function(_ff){
this.get_events().removeHandler("itemFocus",_ff);
},add_itemBlur:function(_100){
this.get_events().addHandler("itemBlur",_100);
},remove_itemBlur:function(_101){
this.get_events().removeHandler("itemBlur",_101);
},add_itemClicking:function(_102){
this.get_events().addHandler("itemClicking",_102);
},remove_itemClicking:function(_103){
this.get_events().removeHandler("itemClicking",_103);
},add_itemClicked:function(_104){
this.get_events().addHandler("itemClicked",_104);
},remove_itemClicked:function(_105){
this.get_events().removeHandler("itemClicked",_105);
},add_itemOpening:function(_106){
this.get_events().addHandler("itemOpening",_106);
},remove_itemOpening:function(_107){
this.get_events().removeHandler("itemOpening",_107);
},add_itemOpened:function(_108){
this.get_events().addHandler("itemOpened",_108);
},remove_itemOpened:function(_109){
this.get_events().removeHandler("itemOpened",_109);
},add_itemClosing:function(_10a){
this.get_events().addHandler("itemClosing",_10a);
},remove_itemClosing:function(_10b){
this.get_events().removeHandler("itemClosing",_10b);
},add_itemClosed:function(_10c){
this.get_events().addHandler("itemClosed",_10c);
},remove_itemClosed:function(_10d){
this.get_events().removeHandler("itemClosed",_10d);
},add_load:function(_10e){
this.get_events().addHandler("load",_10e);
},remove_load:function(_10f){
this.get_events().removeHandler("load",_10f);
},add_itemPopulating:function(_110){
this.get_events().addHandler("itemPopulating",_110);
},remove_itemPopulating:function(_111){
this.get_events().removeHandler("itemPopulating",_111);
},add_itemPopulated:function(_112){
this.get_events().addHandler("itemPopulated",_112);
},remove_itemPopulated:function(_113){
this.get_events().removeHandler("itemPopulated",_113);
},add_itemPopulationFailed:function(_114){
this.get_events().addHandler("itemPopulationFailed",_114);
},remove_itemPopulationFailed:function(_115){
this.get_events().removeHandler("itemPopulationFailed",_115);
}};
Telerik.Web.UI.RadMenu.registerClass("Telerik.Web.UI.RadMenu",Telerik.Web.UI.ControlItemContainer);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadMenuItemState=function(){
};
Telerik.Web.UI.RadMenuItemState.prototype={Closed:0,Open:1,AboutToClose:2,AboutToOpen:3};
Telerik.Web.UI.RadMenuItemState.registerEnum("Telerik.Web.UI.RadMenuItemState");
Telerik.Web.UI.MenuItemExpandMode=function(){
};
Telerik.Web.UI.MenuItemExpandMode.prototype={ClientSide:0,WebService:1};
Telerik.Web.UI.MenuItemExpandMode.registerEnum("Telerik.Web.UI.MenuItemExpandMode");
Telerik.Web.UI.RadMenuItem=function(){
Telerik.Web.UI.RadMenuItem.initializeBase(this);
this._zIndexStep=1000;
this._scrollWrapCssClass="rmScrollWrap";
this._groupCssClass="rmGroup";
this._levelCssClass="rmLevel";
this._horizontalCssClass="rmHorizontal";
this._verticalCssClass="rmVertical";
this._leftImageCssClass="rmLeftImage";
this._defaultDisabledCssClass="rmDisabled";
this._defaultExpandedCssClass="rmExpanded";
this._defaultFocusedCssClass="rmFocused";
this._defaultClickedCssClass="rmClicked";
this._defaultScrollSize=16;
this._menu=null;
this._groupSettings=new Telerik.Web.UI.RadMenuItemGroupSettings({});
this._imageUrl=null;
this._flow=null;
this._openedItem=null;
this._timeoutRef=null;
this._focused=false;
this._clicked=false;
this._hovered=false;
this._isImageOnly=null;
this._itemsLoaded=false;
this._itemsLoading=false;
this._adjustSiblingsWidthOnShow=false;
this._state=Telerik.Web.UI.RadMenuItemState.Closed;
this._linkElement=null;
this._imageElement=null;
this._childListElement=null;
this._scrollWrapElement=null;
this._slideWrapElement=null;
this._animatedElement=null;
this._animationContainer=null;
this._childrenDetached=false;
this._autoScrollActive=false;
this._collapseAnimationEndedDelegate=null;
this._slide=null;
this._scroller=null;
this._styleCssText=null;
};
Telerik.Web.UI.RadMenuItem.prototype={_initialize:function(json,_117){
Telerik.Web.UI.RadMenuItem.callBaseMethod(this,"_initialize",[json,_117]);
var menu=this.get_menu();
if(typeof (json.groupSettings)!="undefined"){
this._groupSettings=new Telerik.Web.UI.RadMenuItemGroupSettings(json.groupSettings,menu.get_defaultGroupSettings());
}
this._initializeAnimation();
this._updateTextElementClass();
this._renderAccessKey();
},_dispose:function(){
Telerik.Web.UI.RadMenuItem.callBaseMethod(this,"_dispose");
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
var _119=this._getAnimationContainer();
if(_119){
_119._item=null;
_119._itemTypeName=null;
}
this._clearTimeout();
},_initializeRenderedItem:function(){
Telerik.Web.UI.RadMenuItem.callBaseMethod(this,"_initializeRenderedItem");
this._initializeAnimation();
this._updateTextElementClass();
this._updateLinkClass();
this._renderAccessKey();
},get_linkElement:function(){
if(!this._linkElement){
this._linkElement=$telerik.getFirstChildByTagName(this.get_element(),"a",0);
}
return this._linkElement;
},get_childListElement:function(){
if(!this._childListElement){
var _11a=this._getSlideWrapElement();
if(_11a){
var _11b=_11a;
var _11c=this._getScrollWrapElement();
if(_11c){
_11b=_11c;
}
this._childListElement=$telerik.getFirstChildByTagName(_11b,"ul",0);
}
}
return this._childListElement;
},get_imageElement:function(){
if(!this._imageElement){
var _11d=this.get_linkElement();
var _11e=this.get_element();
this._imageElement=$telerik.getFirstChildByTagName(_11d||_11e,"img",0);
}
return this._imageElement;
},get_textElement:function(){
var link=this.get_linkElement();
if(link){
return $telerik.getChildByClassName(link,"rmText",0);
}else{
return null;
}
},get_menu:function(){
return this._getControl();
},get_items:function(){
return this._getChildren();
},set_text:function(_120){
Telerik.Web.UI.RadMenuItem.callBaseMethod(this,"set_text",[_120]);
this._adjustSiblingsWidthOnShow=true;
},get_navigateUrl:function(){
return this._getNavigateUrl();
},set_navigateUrl:function(_121){
this._properties.setValue("navigateUrl",_121,true);
if(this.get_linkElement()){
this.get_linkElement().href=_121;
}
},get_target:function(){
return this._properties.getValue("target",null);
},set_target:function(_122){
this._properties.setValue("target",_122);
if(this.get_linkElement()){
this.get_linkElement().target=_122;
}
},get_groupSettings:function(){
return this._groupSettings;
},set_groupSettings:function(_123){
this._groupSettings=_123;
},_getNextItem:function(){
var _124=this.get_parent().get_items();
var _125=this.get_index();
if(_125==_124.get_count()-1){
return _124.getItem(0);
}
return _124.getItem(_125+1);
},_getPreviousItem:function(){
var _126=this.get_parent().get_items();
var _127=this.get_index();
if(_127==0){
return _126.getItem(_126.get_count()-1);
}
return _126.getItem(_127-1);
},_focus:function(e){
this._setFocused(true,e);
},_blur:function(e){
this._setFocused(false,e);
},_setFocused:function(_12a,e){
if(_12a){
this._doFocus(e);
}else{
this._doBlur(e);
}
this._focused=_12a;
this._updateLinkClass();
},_open:function(e){
var menu=this.get_menu();
var _12e=new Telerik.Web.UI.RadMenuItemOpeningEventArgs(this,e);
menu._raiseEvent("itemOpening",_12e);
if(_12e.get_cancel()){
return;
}
if(this._isWebServiceCallNeeded()){
this._loadChildrenFromWebService();
return;
}
this._doOpen(e);
},_close:function(e){
if(this.get_isSeparator()||this._state==Telerik.Web.UI.RadMenuItemState.Closed){
return;
}
var _130=new Telerik.Web.UI.RadMenuItemClosingEventArgs(this,e);
this.get_menu()._raiseEvent("itemClosing",_130);
if(_130.get_cancel()){
return;
}
if(this._openedItem){
this._openedItem._close(e);
}
var _131=this.get_parent();
_131._openedItem=null;
if(!this._getAnimationContainer()){
return;
}
this._state=Telerik.Web.UI.RadMenuItemState.Closed;
var menu=this.get_menu();
if(this.get_level()==0){
menu._aboutToCollapse=true;
}
if(!this._getIsImageOnly()){
this.get_element().style.zIndex=0;
}
this._slide.collapse();
this._updateLinkClass();
this._updateImageSrc();
var _133=new Telerik.Web.UI.RadMenuItemClosedEventArgs(this,e);
this.get_menu()._raiseEvent("itemClosed",_133);
this._closeChildren(e);
},get_nextItem:function(){
return this.get_nextSibling();
},get_previousItem:function(){
return this.get_previousSibling();
},get_focusedItem:function(){
return this._focusedItem;
},get_isSeparator:function(){
return this._properties.getValue("isSeparator",false);
},set_isSeparator:function(_134){
this._properties.setValue("isSeparator",_134,true);
},get_openedItem:function(){
return this._openedItem;
},get_templated:function(){
return this._properties.getValue("templated",false)==true;
},get_cssClass:function(){
return this._properties.getValue("cssClass","");
},set_cssClass:function(_135){
this._properties.setValue("cssClass",_135,true);
},get_focused:function(){
return this._focused;
},set_focused:function(_136){
this._setFocused(_136);
},get_hoveredImageUrl:function(){
return this._properties.getValue("hoveredImageUrl",null);
},set_hoveredImageUrl:function(_137){
this._properties.setValue("hoveredImageUrl",_137,true);
this._updateImageSrc();
},get_clickedImageUrl:function(){
return this._properties.getValue("clickedImageUrl",null);
},set_clickedImageUrl:function(_138){
this._properties.setValue("clickedImageUrl",_138,true);
this._updateImageSrc();
},get_imageUrl:function(){
if(!this._imageUrl){
var _139=this.get_imageElement();
if(_139){
this._imageUrl=_139.src;
}
}
return this._imageUrl;
},set_imageUrl:function(_13a){
this._imageUrl=_13a;
this._properties.setValue("imageUrl",_13a,true);
this._updateImageSrc();
},set_visible:function(_13b){
var _13c=this.get_visible()!=_13b;
if(!_13c){
return;
}
Telerik.Web.UI.RadMenuItem.callBaseMethod(this,"set_visible",[_13b]);
this._adjustSiblingsWidthOnShow=true;
this._clearWidth();
var _13d=_13b?"":"none";
var _13e=this.get_linkElement();
var _13f=this.get_textElement();
var _140;
if(_13e){
_140=_13e;
}else{
if(_13f){
_140=_13f;
}
}
if(this.get_isSeparator()||this.get_templated()){
_140=this.get_element().childNodes[0];
}
_140.style.display=_13d;
if(this.get_visible()){
this.get_element().style.cssText=this._styleCssText;
}else{
this._styleCssText=this.get_element().style.cssText;
this.get_element().style.cssText="padding:0px;margin:0px;height:0px;overflow:hidden;";
}
var _141=this._getParentFlow();
if(_141==Telerik.Web.UI.ItemFlow.Vertical){
if(!_13b){
this._clearSiblingsWidth();
}
var _142=this.get_parent();
if(_142.get_element().offsetWidth>0){
Telerik.Web.UI.RadMenu._adjustChildrenWidth(_142);
}
}
},get_expandedImageUrl:function(){
return this._properties.getValue("expandedImageUrl",null);
},set_expandedImageUrl:function(_143){
this._properties.setValue("expandedImageUrl",_143,true);
this._updateImageSrc();
},get_disabledImageUrl:function(){
return this._properties.getValue("disabledImageUrl",null);
},set_disabledImageUrl:function(_144){
this._properties.setValue("disabledImageUrl",_144,true);
this._updateImageSrc();
},get_disabledCssClass:function(){
return this._properties.getValue("disabledCssClass",this._defaultDisabledCssClass);
},set_disabledCssClass:function(_145){
this._properties.setValue("disabledCssClass",_145,true);
this._updateLinkClass();
},get_expandedCssClass:function(){
return this._properties.getValue("expandedCssClass",this._defaultExpandedCssClass);
},set_expandedCssClass:function(_146){
this._properties.setValue("expandedCssClass",_146,true);
this._updateLinkClass();
},get_focusedCssClass:function(){
return this._properties.getValue("focusedCssClass",this._defaultFocusedCssClass);
},set_focusedCssClass:function(_147){
this._properties.setValue("focusedCssClass",_147,true);
this._updateLinkClass();
},get_clickedCssClass:function(){
return this._properties.getValue("clickedCssClass",this._defaultClickedCssClass);
},set_clickedCssClass:function(_148){
this._properties.setValue("clickedCssClass",_148,true);
this._updateLinkClass();
},get_postBack:function(){
return this._properties.getValue("postBack",true)==true;
},set_postBack:function(_149){
this._properties.setValue("postBack",_149);
},get_expandMode:function(){
return this._properties.getValue("expandMode",Telerik.Web.UI.MenuItemExpandMode.ClientSide);
},set_expandMode:function(_14a){
this._properties.setValue("expandMode",_14a,true);
},set_enabled:function(_14b){
Telerik.Web.UI.RadMenuItem.callBaseMethod(this,"set_enabled",[_14b]);
this._updateLinkClass();
},open:function(){
this._open(null);
},close:function(){
this._close(null);
},hide:function(){
this.set_visible(false);
},show:function(){
this.set_visible(true);
},focus:function(){
this._setFocused(true,null);
},blur:function(){
this._blur(null);
},focusFirstChild:function(e){
var _14d=this.get_items();
if(_14d.get_count()==0){
return;
}
var item=_14d.getItem(0);
var _14f=item;
while(!item._canFocus()){
item=item._getNextItem();
if(item==_14f){
return;
}
}
item._focus(e||null);
},focusLastChild:function(e){
var _151=this.get_items();
if(_151.get_count()==0){
return;
}
var item=_151.getItem(_151.get_count()-1);
var _153=item;
while(!item._canFocus()){
item=item._getPreviousItem();
if(item==_153){
return;
}
}
item._focus(e||null);
},focusNextItem:function(e){
var item=this._getNextItem();
while(!item._canFocus()){
item=item._getNextItem();
}
item._focus(e||null);
},focusPreviousItem:function(e){
var item=this._getPreviousItem();
while(!item._canFocus()){
item=item._getPreviousItem();
}
item._focus(e||null);
},disable:function(){
this.set_enabled(false);
},enable:function(){
this.set_enabled(true);
},click:function(){
this._click(null);
},_modifyPositionClass:function(){
var _158=this._getVisibleIndex();
if(_158==0){
var _159=this._getNextVisibleSibling(this.get_index());
var _15a=this.get_visible()?"rmItem":"rmItem rmFirst";
var _15b=this.get_visible()?"rmItem rmFirst":"rmItem";
this._replaceCssClass(this.get_element(),_15a,_15b);
this._replaceCssClass(_159.get_element(),_15b,_15a);
}
if(_158==this._getVisibleSiblingsCount()){
var _15c=this._getPreviousVisibleSibling(this.get_index());
var _15a=this.get_visible()?"rmItem":"rmItem rmLast";
var _15b=this.get_visible()?"rmItem rmLast":"rmItem";
this._replaceCssClass(this.get_element(),_15a,_15b);
this._replaceCssClass(_15c.get_element(),_15b,_15a);
}
},_getSiblings:function(){
return this.get_parent().get_items();
},_getVisibleIndex:function(){
var _15d=this._getSiblings();
if(this.get_index()==0){
return 0;
}
var _15e=0;
for(var i=0;i<=this.get_index();i++){
if(_15d.getItem(i).get_visible()){
_15e++;
}
}
return _15e;
},_getVisibleSiblingsCount:function(){
var _160=this._getSiblings();
var _161=0;
for(var i=0;i<_160.get_count();i++){
if(_160.getItem(i).get_visible()){
_161++;
}
}
return _161;
},_getPreviousVisibleSibling:function(_163){
var _164=this.get_parent().get_items();
for(var i=_163-1;i>=0;i--){
var item=_164.getItem(i);
if(item.get_visible()){
return item;
}
}
return null;
},_getNextVisibleSibling:function(_167){
var _168=this.get_parent().get_items();
for(var i=_167+1;i<_168.get_count();i++){
var item=_168.getItem(i);
if(item.get_visible()){
return item;
}
}
return null;
},_determineCssClass:function(){
var _16b="rmItem";
var _16c=this.get_parent();
var _16d=_16c.get_items().get_count();
var _16e=_16d-1;
if(this.get_index()==0&&_16d>0){
var _16f=_16c.get_items().getItem(1);
if(_16f&&_16f.get_element()){
if(_16f.get_index()==_16e){
this._replaceCssClass(_16f.get_element(),"rmItem rmFirst","rmItem rmLast");
}else{
this._replaceCssClass(_16f.get_element(),"rmItem rmFirst","rmItem");
}
}
_16b+=" "+"rmFirst";
}
if(this.get_index()==_16e&&_16d>0){
var _170=_16c.get_items().getItem(_16e-1);
if(_170&&_170.get_element()){
if(_170.get_index()==0){
this._replaceCssClass(_170.get_element(),"rmItem rmLast","rmItem rmFirst");
}else{
this._replaceCssClass(_170.get_element(),"rmItem rmLast","rmItem");
}
}
_16b+=" "+"rmLast";
}
if(this.get_isSeparator()){
_16b="rmItem"+" "+"rmSeparator";
}
return _16b;
},_renderImage:function(html){
html[html.length]="<img alt='' src='"+this.get_imageUrl()+"' class='rmLeftImage'";
if(!this.get_enabled()){
html[html.length]=" disabled='disabled'";
}
html[html.length]="/>";
return html;
},_renderLink:function(html){
if(this.get_isSeparator()){
return;
}
var href="#";
var _174=this.get_navigateUrl();
if(_174&&_174!="#"){
href=_174;
}
html[html.length]="<a href=\"";
html[html.length]=href;
html[html.length]="\" ";
var _175=this.get_target();
if(_175){
html[html.length]="target=\"";
html[html.length]=_175;
html[html.length]="\" ";
}
if(this.get_enabled()){
html[html.length]="class=\"rmLink\"";
}else{
html[html.length]="class=\"rmLink rmDisabled\"";
}
html[html.length]=">";
return html;
},_renderChildList:function(html){
var _177=this.get_items().get_count();
if(_177>0){
html[html.length]="<div class='rmSlide'>";
var _178=this.get_groupSettings();
var _179=_178.get_flow();
if(_179==0){
_179="rmVertical";
}else{
_179="rmHorizontal";
}
var _17a;
if(this._getRenderScroll()){
var _17b="rmLevel"+(this.get_level()+1);
var _17c="rmScrollWrap"+" "+"rmGroup"+" "+_17b;
html[html.length]="<div class='"+_17c+"' style='";
var _17d=_178.get_width();
var _17e=_178.get_height();
if(_17d){
html[html.length]="width :"+_17d+";";
}
if(_17e){
html[html.length]="height :"+_17e+";";
}
html[html.length]=" '>";
_17a=_179;
}else{
var _17b="rmLevel"+(this.get_level()+1);
_17a=_179+" "+"rmGroup"+" "+_17b;
}
html[html.length]="<ul class='"+_17a+"'>";
for(var i=0;i<_177;i++){
this.get_items().getItem(i)._render(html);
}
html[html.length]="</ul></div>";
if(this._getRenderScroll()){
html[html.length]="</div>";
}
}
},_doOpen:function(e){
var menu=this.get_menu();
if(this.get_items().get_count()==0){
return;
}
this._ensureChildControls();
var _182=this.get_parent();
menu._aboutToCollapse=false;
if(_182!=menu&&_182._state!=Telerik.Web.UI.RadMenuItemState.Open){
_182._open(e);
}
var _183=this._getAnimationContainer();
if(!_183){
return;
}
_182._openedItem=this;
this._state=Telerik.Web.UI.RadMenuItemState.Open;
var _184=this.get_childListElement();
_184.style.display="block";
_183.style.visibility="hidden";
this._slide.show();
if(this._groupSettings.get_flow()==Telerik.Web.UI.ItemFlow.Vertical){
Telerik.Web.UI.RadMenu._adjustChildrenWidth(this);
}else{
Telerik.Web.UI.RadMenu._adjustListWidth(this);
}
if(this._adjustSiblingsWidthOnShow){
this._adjustSiblingsWidth();
this._adjustSiblingsWidthOnShow=false;
}
this._resetAnimatedElementPosition();
this._slide.set_direction(this._getSlideDirection());
this._updateScrollWrapSize();
this._slide.updateSize();
this._positionChildContainer();
_183=this._getAnimationContainer();
_183.style.visibility="visible";
this.get_element().style.zIndex=_182.get_items().get_count()-this.get_index();
_183.style.zIndex=_182.get_items().get_count()+1;
menu._incrementZIndex(this._zIndexStep);
if(this._scroller){
this._scroller.updateState();
}
this._slide.expand();
this._updateLinkClass();
this._updateImageSrc();
var _185=new Telerik.Web.UI.RadMenuItemOpenedEventArgs(this,e);
this.get_menu()._raiseEvent("itemOpened",_185);
},_shouldInitializeChild:function(_186){
return true;
},_createChildListElement:function(){
var _187=document.createElement("ul");
var _188=this.get_groupSettings();
var _189=_188.get_flow();
if(_189==0){
_189="rmVertical";
}else{
_189="rmHorizontal";
}
var _18a=_189;
var _18b=this._createSlideWrapElement();
var _18c=_18b.firstChild!=null;
if(_18c){
_18b.firstChild.appendChild(_187);
}else{
var _18d="rmLevel"+(this.get_level()+1);
_18a+=" "+"rmGroup"+" "+_18d;
_18b.appendChild(_187);
}
_187.className=_18a;
this.get_element().appendChild(_18b);
this._initializeAnimation();
this._updateTextElementClass();
if(_18c){
this._initializeScroller();
}
return _18b;
},_createSlideWrapElement:function(){
var _18e=document.createElement("div");
_18e.className="rmSlide";
if(this._getRenderScroll()){
var _18f=this._createScrollWrapElement();
_18e.appendChild(_18f);
}
return _18e;
},_createScrollWrapElement:function(){
var _190=document.createElement("div");
var _191="rmLevel"+(this.get_level()+1);
var _192="rmScrollWrap"+" "+"rmGroup"+" "+_191;
_190.className=_192;
var _193=this.get_groupSettings();
var _194=_193.get_width();
var _195=_193.get_height();
if(_194){
_190.style.width=_194;
}
if(_195){
_190.style.height=_195;
}
return _190;
},_getRenderScroll:function(){
var _196;
var _197=this.get_groupSettings();
var _198=_197.get_width();
if(!_198){
_198=this.get_menu().get_defaultGroupSettings().get_width();
}
var _199=_197.get_height();
if(!_199){
_199=this.get_menu().get_defaultGroupSettings().get_height();
}
var _19a=_198||_199;
return _19a;
},_getChildElements:function(){
return $telerik.getChildrenByTagName(this.get_childListElement(),"li");
},_createItemCollection:function(){
var _19b=new Telerik.Web.UI.RadMenuItemCollection(this);
Telerik.Web.UI.RadMenu._createChildControls(this,_19b);
return _19b;
},_getSlideWrapElement:function(){
if(!this._slideWrapElement){
var _19c=$telerik.getFirstChildByTagName(this.get_element(),"div",1);
if(_19c&&Sys.UI.DomElement.containsCssClass(_19c,"rmSlide")){
this._slideWrapElement=_19c;
}
}
return this._slideWrapElement;
},_getScrollWrapElement:function(){
if(!this._scrollWrapElement){
var _19d=this._getSlideWrapElement();
if(_19d){
this._scrollWrapElement=$telerik.getFirstChildByTagName(_19d,"div",0);
}
}
return this._scrollWrapElement;
},_getAnimationContainer:function(){
if(!this._animationContainer){
var _19e=this.get_templated()?1:0;
this._animationContainer=$telerik.getFirstChildByTagName(this.get_element(),"div",_19e);
}
return this._animationContainer;
},_getAnimatedElement:function(){
if(!this._animatedElement){
this._animatedElement=this._getScrollWrapElement()||this.get_childListElement();
}
return this._animatedElement;
},_determineExpandDirection:function(){
var _19f=this.get_groupSettings();
if(_19f.get_expandDirection()!=Telerik.Web.UI.ExpandDirection.Auto){
return;
}
var _1a0=this._getParentFlow();
if(_1a0==Telerik.Web.UI.ItemFlow.Vertical){
if(this.get_menu().get_rightToLeft()){
_19f.set_expandDirection(Telerik.Web.UI.ExpandDirection.Left);
}else{
_19f.set_expandDirection(Telerik.Web.UI.ExpandDirection.Right);
}
}else{
_19f.set_expandDirection(Telerik.Web.UI.ExpandDirection.Down);
}
},_getSlideDirection:function(){
var _1a1=this.get_groupSettings().get_expandDirection();
if(_1a1==Telerik.Web.UI.ExpandDirection.Auto){
return null;
}
return _1a1;
},_getParentFlow:function(){
var _1a2=this.get_parent();
if(!_1a2){
return null;
}
if(_1a2==this.get_menu()){
return _1a2._flow;
}else{
return _1a2.get_groupSettings().get_flow();
}
},_initializeAnimation:function(){
this._determineExpandDirection();
var _1a3=this._getAnimatedElement();
if(_1a3){
var menu=this.get_menu();
this._slide=new Telerik.Web.UI.Slide(_1a3,menu.get_expandAnimation(),menu.get_collapseAnimation(),menu.get_enableOverlay());
this._slide.initialize();
this._slide.set_direction(this._getSlideDirection());
this._collapseAnimationEndedDelegate=Function.createDelegate(this,this._onCollapseAnimationEnded);
this._slide.add_collapseAnimationEnded(this._collapseAnimationEndedDelegate);
}
},_updateTextElementClass:function(){
var _1a5=this.get_textElement();
if(!_1a5){
return;
}
var _1a6="rmText ";
var _1a7=this.get_itemData()&&this.get_itemData().length>0;
if(_1a7||this.get_expandMode()==Telerik.Web.UI.MenuItemExpandMode.WebService){
_1a6+=" "+this._getExpandClassName();
}
_1a5.className=_1a6;
},_onCollapseAnimationEnded:function(_1a8,e){
var menu=this.get_menu();
this.get_element().style.zIndex=0;
menu._restoreZIndex();
if(this.get_level()==0&&menu.get_rightToLeft()){
var _1ab=menu.get_element();
_1ab.style.cssText=_1ab.style.cssText;
}
},_initializeScroller:function(){
var _1ac=this._getScrollWrapElement();
if(_1ac){
this._scroller=new Telerik.Web.UI.MenuItemScroller(this.get_childListElement(),this.get_groupSettings().get_flow());
this._scroller.initialize();
}
},_isAutoScrollPossible:function(){
var menu=this.get_menu();
var _1ae=this._getMaximumExpandSize();
var _1af=this._getAnimationContainer();
if(this.get_groupSettings().get_flow()==Telerik.Web.UI.ItemFlow.Vertical){
return (menu._autoScrollMinimumHeight<_1ae&&_1ae<=_1af.offsetHeight);
}else{
return (menu._autoScrollMinimumWidth<_1ae&&_1ae<=_1af.offsetWidth);
}
},_getMaximumExpandSize:function(){
var _1b0=this._slide.get_direction();
var _1b1=$telerik.getViewPortSize();
var _1b2=this._getAnimationContainer();
var _1b3=$telerik.getLocation(_1b2);
if(this.get_groupSettings().get_flow()==Telerik.Web.UI.ItemFlow.Vertical){
if(_1b0==Telerik.Web.UI.ExpandDirection.Up){
availableHeight=_1b2.offsetHeight+_1b3.y;
}else{
availableHeight=_1b1.height-_1b3.y-this._defaultScrollSize;
}
return availableHeight;
}else{
if(_1b0==Telerik.Web.UI.ExpandDirection.Left){
availableWidth=_1b3.x;
}else{
availableWidth=_1b1.width-_1b3.x;
}
return availableWidth;
}
return null;
},_initializeAutoScroll:function(){
this._buildScrollWrap();
this._initializeScroller();
this._animatedElement=null;
this._scrollWrapElement=null;
this._slide.set_animatedElement(this._getAnimatedElement());
},_removeAutoScroll:function(){
var _1b4=this.get_items();
var _1b5=_1b4.get_count();
for(var i=0;i<_1b5;i++){
_1b4.getItem(i)._removeAutoScroll();
}
this._attachChildren();
if(!this._scroller){
return;
}
this._scroller.dispose();
this._scroller=null;
var _1b7=this._getSlideWrapElement();
var _1b8=this.get_childListElement();
var _1b9=this._getScrollWrapElement();
_1b7.appendChild(_1b8);
_1b7.removeChild(_1b9);
_1b8.className=String.format("{0} {1} {2}{3}",this._getFlowCssClass(),this._groupCssClass,this._levelCssClass,this.get_level());
this._animatedElement=null;
this._scrollWrapElement=null;
this._slide.set_animatedElement(this._getAnimatedElement());
this._slide.updateSize();
},_updateAutoScrollSize:function(){
var _1ba=this._slide.get_direction();
var _1bb=$telerik.getViewPortSize();
var _1bc=this._getAnimationContainer();
var _1bd=$telerik.getLocation(_1bc);
var _1be=this._getScrollWrapElement();
_1be.style.height="";
_1be.style.width="";
var _1bf=this._getMaximumExpandSize();
if(this.get_groupSettings().get_flow()==Telerik.Web.UI.ItemFlow.Vertical){
_1be.style.height=_1bf+"px";
_1be.style.width=_1bc.style.width;
if(_1ba==Telerik.Web.UI.ExpandDirection.Up){
_1bc.style.top=-_1bf+"px";
}
}else{
_1be.style.width=_1bf+"px";
_1be.style.height=_1bc.style.height;
}
this._slide.updateSize();
this._scroller.resetState();
},_buildScrollWrap:function(){
var _1c0=this._getSlideWrapElement();
var _1c1=this.get_childListElement();
var _1c2=document.createElement("div");
_1c2.style.position="relative";
_1c2.style.overflow="hidden";
_1c1.className=this._getFlowCssClass();
_1c2.className=String.format("{0} {1} {2}{3}",this._scrollWrapCssClass,this._groupCssClass,this._levelCssClass,this.get_level());
_1c2.appendChild(_1c1);
_1c0.appendChild(_1c2);
},_updateScrollWrapSize:function(){
var _1c3=this._getScrollWrapElement();
var _1c4=this.get_childListElement();
if(!_1c3){
return;
}
if(!_1c3.style.height){
_1c3.style.height=_1c4.offsetHeight+"px";
}
if(this.get_groupSettings().get_flow()==Telerik.Web.UI.ItemFlow.Vertical){
_1c3.style.width=_1c4.offsetWidth+"px";
}
},_getWidth:function(){
var _1c5=this.get_linkElement();
if(_1c5){
return _1c5.offsetWidth;
}else{
return this.get_element().offsetWidth;
}
},_setWidth:function(_1c6){
var _1c7=this.get_linkElement();
if(!_1c7){
_1c7=this.get_element();
}
if(!_1c7){
return;
}
if($telerik.isOpera){
this.get_element().style.cssFloat="none";
}
var _1c8=parseInt(_1c6);
if(isNaN(_1c8)){
_1c7.style.width=_1c6;
_1c7.style.cssText=_1c7.style.cssText;
return;
}
var _1c9=_1c8;
var _1ca=$telerik.getPaddingBox(_1c7).horizontal;
var _1cb=$telerik.getBorderBox(_1c7).horizontal;
_1c9-=_1ca+_1cb;
if(_1c9<=0){
return;
}
var _1cc=_1c7.style.width;
if(!_1cc||_1c9!=_1cc){
_1c7.style.width=_1c9+"px";
}
},_clearWidth:function(){
this._setWidth("auto");
},_getData:function(){
var data=Telerik.Web.UI.RadMenuItem.callBaseMethod(this,"_getData");
var _1ce=this.get_navigateUrl();
if(_1ce&&_1ce!="#"&&(location.href+"#"!==_1ce)){
data["navigateUrl"]=_1ce;
}
return data;
},_loadFromDictionary:function(data){
Telerik.Web.UI.RadMenuItem.callBaseMethod(this,"_loadFromDictionary",[data]);
if(typeof (data.ExpandMode)!="undefined"&&data.ExpandMode!=Telerik.Web.UI.MenuItemExpandMode.ClientSide){
this.set_expandMode(data.ExpandMode);
}
if(data.NavigateUrl){
this.set_navigateUrl(data.NavigateUrl);
}
if(data.PostBack===false){
this.set_postBack(data.PostBack);
}
if(data.Target){
this.set_target(data.Target);
}
if(data.IsSeparator===true){
this.set_isSeparator(data.IsSeparator);
}
if(data.CssClass){
this.set_cssClass(data.CssClass);
}
if(typeof (data.DisabledCssClass)!="undefined"&&data.DisabledCssClass!=this._defaultDisabledCssClass){
this.set_disabledCssClass(data.DisabledCssClass);
}
if(typeof (data.ExpandedCssClass)!="undefined"&&data.ExpandedCssClass!=this._defaultExpandedCssClass){
this.set_expandedCssClass(data.ExpandedCssClass);
}
if(typeof (data.FocusedCssClass)!="undefined"&&data.FocusedCssClass!=this._defaultFocusedCssClass){
this.set_focusedCssClass(data.FocusedCssClass);
}
if(typeof (data.ClickedCssClass)!="undefined"&&data.ClickedCssClass!=this._defaultClickedCssClass){
this.set_clickedCssClass(data.ClickedCssClass);
}
if(data.ImageUrl){
this.set_imageUrl(data.ImageUrl);
}
if(data.HoveredImageUrl){
this.set_hoveredImageUrl(data.HoveredImageUrl);
}
if(data.ClickedImageUrl){
this.set_clickedImageUrl(data.ClickedImageUrl);
}
if(data.DisabledImageUrl){
this.set_disabledImageUrl(data.DisabledImageUrl);
}
if(data.ExpandedImageUrl){
this.set_expandedImageUrl(data.ExpandedImageUrl);
}
},_replaceCssClass:function(_1d0,_1d1,_1d2){
_1d0.className=_1d0.className.replace(_1d1,_1d2);
},_setChildContainerPosition:function(left,top){
var _1d5=this._getAnimationContainer();
var _1d6=this.get_parent();
var _1d7=null;
if(_1d6._getScrollWrapElement){
_1d7=_1d6._getScrollWrapElement();
}
if(_1d7){
this._detachChildren();
var _1d8=this.get_element();
top+=_1d8.offsetTop;
var _1d9=_1d6.get_childListElement();
var _1da=parseInt(_1d9.style.top);
if(isNaN(_1da)){
_1da=0;
}
if(this.get_groupSettings().get_offsetY()==0){
top+=_1da;
}
}
_1d5.style.left=(left+this.get_groupSettings().get_offsetX())+"px";
_1d5.style.top=(top+this.get_groupSettings().get_offsetY())+"px";
},_detachChildren:function(){
if(this._childrenDetached){
return;
}
var _1db=this._getAnimationContainer();
var _1dc=this.get_parent();
var _1dd=_1dc._getAnimationContainer();
if(!this._childrenDetached){
_1dd.appendChild(_1db);
this._childrenDetached=true;
_1db._item=this;
_1db._itemTypeName=Object.getTypeName(this);
}
},_attachChildren:function(){
if(this._childrenDetached){
var _1de=this.get_element();
_1de.appendChild(this._getAnimationContainer());
this._childrenDetached=false;
}
},_resetAnimatedElementPosition:function(){
var _1df=this._getAnimatedElement();
_1df.style.top="0px";
_1df.style.left="0px";
},_positionChildContainer:function(){
var _1e0=$telerik.getClientBounds();
var top=0;
var left=0;
var _1e3=this._slide._getAnimatedStyleProperty();
var _1e4=this.get_element();
var _1e5=_1e4.offsetHeight;
var _1e6=_1e4.offsetWidth;
var _1e7=this._getAnimationContainer();
var _1e8=_1e7.offsetHeight;
var _1e9=_1e7.offsetWidth;
var _1ea=this.get_groupSettings().get_expandDirection();
switch(_1ea){
case Telerik.Web.UI.ExpandDirection.Up:
top=-_1e8;
break;
case Telerik.Web.UI.ExpandDirection.Down:
top=_1e5;
break;
case Telerik.Web.UI.ExpandDirection.Left:
left=-_1e9;
break;
case Telerik.Web.UI.ExpandDirection.Right:
left=_1e6;
break;
}
var menu=this.get_menu();
if(menu.get_rightToLeft()&&this.get_level()==0){
left=_1e6-_1e9;
if(this._getParentFlow()==Telerik.Web.UI.ItemFlow.Vertical){
left-=_1e6;
}
}
this._setChildContainerPosition(left,top);
var _1ec=menu.get_enableAutoScroll();
var _1ed=menu.get_enableScreenBoundaryDetection();
var _1ee=false;
if(_1ec){
if(this._applyAutoScroll(left,top)){
_1ee=true;
}else{
if(this._autoScrollActive){
this._removeAutoScroll();
this._autoScrollActive=false;
}
if(_1ed){
var _1ef=this._adjustForScreenBoundaries(left,top);
_1ee=true;
this._applyAutoScroll(_1ef.adjustedLeft,_1ef.adjustedTop);
}
}
if(this._autoScrollActive){
this._updateAutoScrollSize();
}
}
if(_1ed&&!_1ee){
this._adjustForScreenBoundaries(left,top);
}
var _1f0=this.get_textElement();
if(_1f0){
_1f0.className="rmText "+this._getExpandClassName();
}
},_applyAutoScroll:function(_1f1,_1f2){
if(this._isAutoScrollPossible()){
if(!this._scroller){
this._initializeAutoScroll();
this._autoScrollActive=true;
this._setChildContainerPosition(_1f1,_1f2);
}
return true;
}
return false;
},_adjustForScreenBoundaries:function(left,top){
var _1f5=this._getAnimationContainer();
var _1f6=_1f5.offsetHeight;
var _1f7=_1f5.offsetWidth;
var _1f8=this.get_element();
var _1f9=_1f8.offsetHeight;
var _1fa=_1f8.offsetWidth;
var _1fb=this.get_groupSettings().get_expandDirection();
var _1fc=_1fb;
var _1fd=$telerik.getViewPortSize();
var _1fe=$telerik.getLocation(_1f5);
switch(_1fb){
case Telerik.Web.UI.ExpandDirection.Up:
if($telerik.elementOverflowsTop(_1f5)){
_1fc=Telerik.Web.UI.ExpandDirection.Down;
top=_1f9;
}
break;
case Telerik.Web.UI.ExpandDirection.Down:
if($telerik.elementOverflowsBottom(_1fd,_1f5)){
var _1ff=$telerik.getLocation(_1f8);
if(_1ff.y>_1f5.offsetHeight){
_1fc=Telerik.Web.UI.ExpandDirection.Up;
top=-_1f6;
}
}
break;
case Telerik.Web.UI.ExpandDirection.Left:
if($telerik.elementOverflowsLeft(_1f5)){
_1fc=Telerik.Web.UI.ExpandDirection.Right;
left=_1fa;
}
break;
case Telerik.Web.UI.ExpandDirection.Right:
if($telerik.elementOverflowsRight(_1fd,_1f5)){
_1fc=Telerik.Web.UI.ExpandDirection.Left;
left=-_1f7;
}
break;
}
switch(_1fc){
case Telerik.Web.UI.ExpandDirection.Down:
case Telerik.Web.UI.ExpandDirection.Up:
if($telerik.elementOverflowsRight(_1fd,_1f5)){
left=_1fd.width-(_1fe.x+_1f7);
}
break;
case Telerik.Web.UI.ExpandDirection.Left:
case Telerik.Web.UI.ExpandDirection.Right:
if($telerik.elementOverflowsBottom(_1fd,_1f5)){
top=_1fd.height-(_1fe.y+_1f6);
}
break;
}
this._setChildContainerPosition(left,top);
this._slide.set_direction(_1fc);
return {adjustedLeft:left,adjustedTop:top};
},_closeChildren:function(e){
var _201=this.get_items();
for(var i=0;i<_201.get_count();i++){
var _203=_201.getItem(i);
_203._stopAnimation();
_203._close(e);
}
},_stopAnimation:function(){
if(this._slide){
this._slide._stopAnimation();
}
},_preventClose:function(){
var _204=this.get_parent();
if(this._state==Telerik.Web.UI.RadMenuItemState.AboutToClose){
this._clearTimeout();
this._state=Telerik.Web.UI.RadMenuItemState.Open;
_204._openedItem=this;
}
if(_204._preventClose){
_204._preventClose();
}
},_setTimeout:function(_205,_206){
this._timeoutRef=setTimeout(_205,_206);
},_clearTimeout:function(){
if(this._timeoutRef){
clearTimeout(this._timeoutRef);
this._timeoutRef=null;
}
},_getExpandClassName:function(){
return "rmExpand"+this._getExpandClass();
},_getExpandClass:function(){
var _207=this._getSlideDirection();
switch(_207){
case Telerik.Web.UI.SlideDirection.Up:
return "Top";
case Telerik.Web.UI.SlideDirection.Down:
return "Down";
case Telerik.Web.UI.SlideDirection.Left:
return "Left";
case Telerik.Web.UI.SlideDirection.Right:
return "Right";
}
},_updateLinkClass:function(){
if(this.get_isSeparator()||this.get_templated()){
return;
}
var _208="rmLink "+this.get_cssClass();
if(this.get_focused()){
_208+=" "+this.get_focusedCssClass();
}
if(this._state==Telerik.Web.UI.RadMenuItemState.Open){
_208+=" "+this.get_expandedCssClass();
}
if(this._clicked){
_208+=" "+this.get_clickedCssClass();
}
if(!this.get_enabled()){
_208+=" "+this.get_disabledCssClass();
}
var _209=this.get_linkElement();
if(_209){
_209.className=_208;
}
},_updateImageSrc:function(){
var _20a=this.get_imageUrl();
if(this._hovered&&this.get_hoveredImageUrl()){
_20a=this.get_hoveredImageUrl();
}
if(this._state==Telerik.Web.UI.RadMenuItemState.Open&&this.get_expandedImageUrl()){
_20a=this.get_expandedImageUrl();
}
if(!this.get_enabled()&&this.get_disabledImageUrl()){
_20a=this.get_disabledImageUrl();
}
if(this._clicked&&this.get_clickedImageUrl()){
_20a=this.get_clickedImageUrl();
}
if(_20a&&this.get_element()){
var _20b=this.get_imageElement();
if(!_20b){
_20b=this._createImageElement();
}
_20a=_20a.replace(/&amp;/ig,"&");
if(_20a!=_20b.src){
_20b.src=_20a;
}
}
},_createImageElement:function(){
this._imageElement=document.createElement("img");
this._imageElement.className=this._leftImageCssClass;
if(!this.get_enabled()){
this._imageElement.disabled="disabled";
}
var _20c=this.get_linkElement()||this.get_element();
if(_20c.firstChild){
_20c.insertBefore(this._imageElement,_20c.firstChild);
}else{
_20c.appendChild(this._imageElement);
}
return this._imageElement;
},_click:function(e){
if(!this.get_enabled()){
return false;
}
var menu=this.get_menu();
var _20f=menu._getExtendedItemClickingEventArgs(new Telerik.Web.UI.RadMenuItemClickingEventArgs(this,e));
menu._raiseEvent("itemClicking",_20f);
if(_20f.get_cancel()){
return false;
}
if(menu.get_clickToOpen()&&this.get_level()==0){
if(menu._clicked){
this._close(e);
}else{
this._open(e);
}
menu._clicked=!menu._clicked;
}
var _210=menu._getExtendedItemClickedEventArgs(new Telerik.Web.UI.RadMenuItemClickedEventArgs(this,e));
menu._raiseEvent("itemClicked",_210);
if(this._shouldNavigate()){
return true;
}
if(this._shouldPostBack()){
menu._postback(this._getHierarchicalIndex());
}
return false;
},_shouldPostBack:function(){
if(!this.get_menu()){
return false;
}
return this.get_postBack()&&this.get_menu()._postBackReference;
},_canFocus:function(){
return (!this.get_isSeparator())&&this.get_enabled();
},_clearSiblingsWidth:function(){
var _211=this.get_parent();
var _212=_211.get_items();
for(var i=0;i<_212.get_count();i++){
var _214=_212.getItem(i);
if(_214!=this){
var _215=_214.get_linkElement();
if(_215){
_215.style.width="auto";
}
}
if($telerik.isSafari){
_211.get_childListElement().style.width="auto";
}
}
},_doFocus:function(e){
if(!this._canFocus()){
return;
}
this._ensureChildControls();
var _217=this.get_parent();
var _218=_217.get_openedItem();
if(_218&&_218!=this){
_218._close(e);
}
if(_217._state!=Telerik.Web.UI.RadMenuItemState.Open&&_217.open){
_217._open(e);
}
_217._focusedItem=this;
var menu=this.get_menu();
menu._focusedItem=this;
var _21a=this.get_linkElement();
if(!this.get_focused()&&_21a){
_21a.focus();
}
this.get_menu()._raiseEvent("itemFocus",new Telerik.Web.UI.RadMenuItemFocusEventArgs(this,e));
},_doBlur:function(e){
if(this.get_isSeparator()){
return;
}
if(this.get_focused()){
this.get_linkElement().blur();
}
this.get_parent()._focusedItem=null;
var menu=this.get_menu();
var _21d=this;
window.setTimeout(function(){
if(menu._focusedItem==_21d){
menu._focusedItem=null;
}
},100);
this.get_menu()._raiseEvent("itemBlur",new Telerik.Web.UI.RadMenuItemBlurEventArgs(this,e));
},_createChildControls:function(){
Telerik.Web.UI.RadMenuItem.callBaseMethod(this,"_createChildControls");
this._initializeScroller();
},_onScrollArrowMouseDown:function(_21e){
if(!this._scroller){
return;
}
this._scroller.changeScrollSpeed(Telerik.Web.UI.ScrollerSpeed.Fast);
},_onScrollArrowMouseUp:function(_21f){
if(!this._scroller){
return;
}
this._scroller.changeScrollSpeed(Telerik.Web.UI.ScrollerSpeed.Slow);
},_onScrollArrowMouseOver:function(_220){
if(!this._scroller){
return;
}
var _221=1;
if(_220==Telerik.Web.UI.ArrowPosition.Top||_220==Telerik.Web.UI.ArrowPosition.Left){
_221=-1;
}
this._scroller.startScroll(Telerik.Web.UI.ScrollerSpeed.Slow,_221);
},_onScrollArrowMouseOut:function(_222){
if(!this._scroller){
return;
}
this._scroller.stopScroll();
},_onKeyDown:function(e){
var _224=e.keyCode?e.keyCode:e.rawEvent.keyCode;
var rtl=this.get_menu().get_rightToLeft();
switch(_224){
case Sys.UI.Key.up:
if(!rtl){
this._onKeyboardUp(e);
}else{
this._onKeyboardDown(e);
}
break;
case Sys.UI.Key.down:
if(!rtl){
this._onKeyboardDown(e);
}else{
this._onKeyboardUp(e);
}
break;
case Sys.UI.Key.left:
if(!rtl){
this._onKeyboardLeft(e);
}else{
this._onKeyboardRight(e);
}
break;
case Sys.UI.Key.right:
if(!rtl){
this._onKeyboardRight(e);
}else{
this._onKeyboardLeft(e);
}
break;
case Sys.UI.Key.esc:
this._onKeyboardEsc(e);
break;
default:
return true;
}
e.preventDefault();
return false;
},_onKeyboardUp:function(e){
var _227=this._getParentFlow();
if(_227==Telerik.Web.UI.ItemFlow.Vertical){
this.focusPreviousItem(e);
}else{
this.focusLastChild(e);
}
},_onKeyboardDown:function(e){
var _229=this._getParentFlow();
if(_229==Telerik.Web.UI.ItemFlow.Vertical){
this.focusNextItem(e);
}else{
this.focusFirstChild(e);
}
},_onKeyboardLeft:function(e){
var _22b=this._getParentFlow();
if(_22b==Telerik.Web.UI.ItemFlow.Horizontal){
this.focusPreviousItem(e);
return;
}
var _22c=this.get_items();
var _22d=this.get_groupSettings();
if(_22c.get_count()>0&&_22d.get_expandDirection()==Telerik.Web.UI.ExpandDirection.Left){
this.focusFirstChild(e);
return;
}
var _22e=this.get_parent();
var _22f=null;
if(_22e.get_groupSettings){
var _22f=_22e.get_groupSettings();
}
if(_22f&&_22f.get_expandDirection()==Telerik.Web.UI.ExpandDirection.Right){
_22e._focus(e);
return;
}
var _230=this.get_menu().get_openedItem();
if(_230){
_230.focusPreviousItem(e);
}
},_onKeyboardRight:function(e){
var _232=this._getParentFlow();
if(_232==Telerik.Web.UI.ItemFlow.Horizontal){
this.focusNextItem(e);
return;
}
var _233=this.get_items();
var _234=this.get_groupSettings();
if(_233.get_count()>0&&_234.get_expandDirection()==Telerik.Web.UI.ExpandDirection.Right){
this.focusFirstChild(e);
return;
}
var _235=this.get_parent();
var _236=null;
if(_235.get_groupSettings){
var _236=_235.get_groupSettings();
}
if(_236&&_236.get_expandDirection()==Telerik.Web.UI.ExpandDirection.Left){
_235.focus();
return;
}
var _237=this.get_menu().get_openedItem();
if(_237){
_237.focusNextItem(e);
}
},_onKeyboardEsc:function(e){
var _239=this.get_parent();
var menu=this.get_menu();
if(_239==menu){
this._blur(e);
}else{
_239._close(e);
_239._focus(e);
}
},_render:function(html){
var _23c="rmItem";
var _23d=false;
if(this.get_parent().get_items().get_count()==1){
_23d=true;
}
html[html.length]="<li class='"+this._determineCssClass()+"'>";
this._renderLink(html);
if(this.get_imageUrl()){
this._renderImage(html);
}
html[html.length]="<span class='rmText'>";
html[html.length]=this.get_text();
html[html.length]="</span></a>";
var _23e=this.get_items();
var _23f=_23e.get_count();
this._renderChildList(html);
html[html.length]="</li>";
},_renderAccessKey:function(){
if(this.get_isSeparator()||this.get_templated()){
return;
}
var _240=this.get_linkElement();
if(!_240){
return;
}
var _241=this.get_linkElement().accessKey.toLowerCase();
if(!_241){
return;
}
var text=this.get_text();
var _243=text.toLowerCase().indexOf(_241);
if(text.toLowerCase().indexOf("<u>")!=-1){
return;
}
if(_243==-1){
return;
}
var _244=this.get_textElement();
_244.innerHTML=text.substr(0,_243)+"<u>"+text.substr(_243,1)+"</u>"+text.substr(_243+1,text.length);
},_getIsImageOnly:function(){
if(this._isImageOnly===null){
this._isImageOnly=this.get_imageElement()!=null;
}
return this._isImageOnly;
},_getFlowCssClass:function(){
if(this.get_groupSettings().get_flow()==Telerik.Web.UI.ItemFlow.Vertical){
return this._verticalCssClass;
}else{
return this._horizontalCssClass;
}
},_isWebServiceCallNeeded:function(){
if(this._itemsLoading){
return false;
}
return (!this._itemsLoaded&&this.get_expandMode()==Telerik.Web.UI.MenuItemExpandMode.WebService);
},_createLoadingItem:function(){
var _245=this.get_menu().get_loadingTemplate();
if(_245===""){
return;
}
var _246=new Telerik.Web.UI.RadMenuItem();
this.get_items().add(_246);
_246.set_text(_245);
},_removeLoadingItem:function(){
if(this.get_menu().get_loadingTemplate()===""){
return;
}
var _247=this.get_items().getItem(0);
this.get_items().remove(_247);
},_loadChildrenFromWebService:function(){
this.get_menu()._loadChildrenFromWebService(this);
},_onChildrenLoading:function(){
this._itemsLoading=true;
this._createLoadingItem();
this._doOpen(null);
},_onChildrenLoaded:function(){
this._removeLoadingItem();
this._itemsLoaded=true;
this._itemsLoading=false;
this._slide.updateSize();
if(this._hovered){
this._doOpen(null);
}
},_onChildrenLoadingError:function(){
this._close(null);
this._removeLoadingItem();
this._itemsLoaded=false;
this._itemsLoading=false;
},_adjustSiblingsWidth:function(){
var _248=this.get_parent();
if(_248){
this._clearSiblingsWidth();
Telerik.Web.UI.RadMenu._adjustChildrenWidth(_248);
}
}};
Telerik.Web.UI.RadMenuItem.registerClass("Telerik.Web.UI.RadMenuItem",Telerik.Web.UI.ControlItem);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadMenuItemCollection=function(_249){
Telerik.Web.UI.RadMenuItemCollection.initializeBase(this,[_249]);
};
Telerik.Web.UI.RadMenuItemCollection.prototype={};
Telerik.Web.UI.RadMenuItemCollection.registerClass("Telerik.Web.UI.RadMenuItemCollection",Telerik.Web.UI.ControlItemCollection);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadMenuItemGroupSettings=function(_24a,_24b){
this._flow=Telerik.Web.UI.ItemFlow.Vertical;
this._expandDirection=Telerik.Web.UI.ExpandDirection.Auto;
this._offsetX=0;
this._offsetY=0;
this._width=null;
this._height=null;
if(typeof (_24a.flow)!="undefined"){
this._flow=_24a.flow;
}else{
if(_24b){
this._flow=_24b.get_flow();
}
}
if(typeof (_24a.expandDirection)!="undefined"){
this._expandDirection=_24a.expandDirection;
}else{
if(_24b){
this._expandDirection=_24b.get_expandDirection();
}
}
if(typeof (_24a.offsetX)!="undefined"){
this._offsetX=_24a.offsetX;
}else{
if(_24b){
this._offsetX=_24b.get_offsetX();
}
}
if(typeof (_24a.offsetY)!="undefined"){
this._offsetY=_24a.offsetY;
}else{
if(_24b){
this._offsetY=_24b.get_offsetY();
}
}
if(typeof (_24a.width)!="undefined"){
this._width=_24a.width;
}else{
if(_24b){
this._width=_24b.get_width();
}
}
if(typeof (_24a.height)!="undefined"){
this._height=_24a.height;
}else{
if(_24b){
this._height=_24b.get_height();
}
}
};
Telerik.Web.UI.RadMenuItemGroupSettings.prototype={get_flow:function(){
return this._flow;
},set_flow:function(_24c){
this._flow=_24c;
},get_expandDirection:function(){
return this._expandDirection;
},set_expandDirection:function(_24d){
this._expandDirection=_24d;
},get_offsetX:function(){
return this._offsetX;
},set_offsetX:function(_24e){
this._offsetX=_24e;
},get_offsetY:function(){
return this._offsetY;
},set_offsetY:function(_24f){
this._offsetY=_24f;
},get_width:function(){
return this._width;
},set_width:function(_250){
this._width=_250;
},get_height:function(){
return this._height;
},set_height:function(_251){
this._height=_251;
}};
Telerik.Web.UI.RadMenuItemGroupSettings.registerClass("Telerik.Web.UI.RadMenuItemGroupSettings");
Telerik.Web.UI.MenuItemScroller=function(_252,_253){
this._leftArrowCssClass="rmLeftArrow";
this._rightArrowCssClass="rmRightArrow";
this._topArrowCssClass="rmTopArrow";
this._bottomArrowCssClass="rmBottomArrow";
this._leftArrowDisabledCssClass="rmLeftArrowDisabled";
this._rightArrowDisabledCssClass="rmRightArrowDisabled";
this._topArrowDisabledCssClass="rmTopArrowDisabled";
this._bottomArrowDisabledCssClass="rmBottomArrowDisabled";
this._arrowsZIndex=2000;
this._scroller=null;
this._childListElement=_252;
this._scrollElement=null;
this._orientation=null;
this._minScrollPosition=null;
this._itemFlow=_253;
this._scrollerPositionChangedDelegate=null;
this._decArrow=null;
this._incArrow=null;
};
Telerik.Web.UI.MenuItemScroller.prototype={initialize:function(){
this._childListElement.style.position="relative";
this._scrollElement=this._childListElement.parentNode;
this._orientation=Telerik.Web.UI.ScrollerOrientation.Horizontal;
if(this._itemFlow==Telerik.Web.UI.ItemFlow.Vertical){
this._orientation=Telerik.Web.UI.ScrollerOrientation.Vertical;
}
this._scroller=new Telerik.Web.UI.Scroller(this._childListElement,this._scrollElement,this._orientation);
this._scroller.initialize();
this._createArrows();
this._scroller.resetState();
this._scrollerPositionChangedDelegate=Function.createDelegate(this,this._onScrollerPositionChanged);
this._scroller.add_positionChanged(this._scrollerPositionChangedDelegate);
},dispose:function(){
if(this._scroller){
this._scroller.dispose();
this._scroller=null;
}
this._scrollerPositionChangedDelegate=null;
},updateState:function(){
this._updateScrollingLimits();
this._updateArrows();
},resetState:function(){
this._scroller.resetState();
},startScroll:function(_254,_255){
this._scroller.startScroll(_254,_255);
},changeScrollSpeed:function(_256){
this._scroller.changeScrollSpeed(_256);
},stopScroll:function(){
this._scroller.stopScroll();
},_createArrows:function(){
this._decArrow=this._createArrowDomElement();
this._incArrow=this._createArrowDomElement();
if(this._orientation==Telerik.Web.UI.ScrollerOrientation.Vertical){
this._decArrow.style.left="0px";
this._decArrow.style.top="0px";
this._incArrow.style.left="0px";
this._incArrow.style.bottom="0px";
}else{
this._decArrow.style.top="0px";
this._decArrow.style.left="-1px";
this._incArrow.style.top="0px";
this._incArrow.style.right="-1px";
}
},_createArrowDomElement:function(){
var _257=document.createElement("a");
_257.href="#";
_257.style.zIndex=this._arrowsZIndex;
_257.appendChild(document.createTextNode("&nbsp;"));
this._scrollElement.appendChild(_257);
return _257;
},_updateArrows:function(){
var _258=this._scroller.isAtMinPosition();
var _259=this._scroller.isAtMaxPosition();
if(_258){
this._decArrow.disabled="disabled";
this._setElementCssClass(this._decArrow,this._getDecArrowCssClass(false));
}else{
this._decArrow.disabled="";
this._setElementCssClass(this._decArrow,this._getDecArrowCssClass(true));
}
if(_259){
this._incArrow.disabled="disabled";
this._setElementCssClass(this._incArrow,this._getIncArrowCssClass(false));
}else{
this._incArrow.disabled="";
this._setElementCssClass(this._incArrow,this._getIncArrowCssClass(true));
}
},_updateScrollingLimits:function(){
var _25a=0;
var _25b=0;
var _25c=0;
if(this._orientation==Telerik.Web.UI.ScrollerOrientation.Vertical){
_25a=this._childListElement.offsetHeight-this._scrollElement.offsetHeight;
_25b=this._decArrow.offsetHeight;
_25c=this._incArrow.offsetHeight;
}else{
_25a=this._childListElement.offsetWidth-this._scrollElement.offsetWidth;
_25b=this._decArrow.offsetWidth;
_25c=this._incArrow.offsetWidth;
}
var _25d=0;
var _25e=_25a;
this._scroller.setScrollingLimits(_25d,_25e);
},_getDecArrowCssClass:function(_25f){
if(this._orientation==Telerik.Web.UI.ScrollerOrientation.Vertical){
return _25f?this._topArrowCssClass:this._topArrowDisabledCssClass;
}else{
return _25f?this._leftArrowCssClass:this._leftArrowDisabledCssClass;
}
},_getIncArrowCssClass:function(_260){
if(this._orientation==Telerik.Web.UI.ScrollerOrientation.Vertical){
return _260?this._bottomArrowCssClass:this._bottomArrowDisabledCssClass;
}else{
return _260?this._rightArrowCssClass:this._rightArrowDisabledCssClass;
}
},_setElementCssClass:function(_261,_262){
var _263=_261.className;
if(_263!=_262){
_261.className=_262;
}
},_onScrollerPositionChanged:function(_264,_265){
this._updateArrows();
}};
Telerik.Web.UI.MenuItemScroller.registerClass("Telerik.Web.UI.MenuItemScroller",null,Sys.IDisposable);

