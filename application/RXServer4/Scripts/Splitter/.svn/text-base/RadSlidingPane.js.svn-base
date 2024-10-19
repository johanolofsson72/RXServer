Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.PaneBeforeDockEventArgs=function(){
Telerik.Web.UI.PaneBeforeDockEventArgs.initializeBase(this);
};
Telerik.Web.UI.PaneBeforeDockEventArgs.prototype={};
Telerik.Web.UI.PaneBeforeDockEventArgs.registerClass("Telerik.Web.UI.PaneBeforeDockEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.PaneDockedEventArgs=function(){
Telerik.Web.UI.PaneDockedEventArgs.initializeBase(this);
};
Telerik.Web.UI.PaneDockedEventArgs.prototype={};
Telerik.Web.UI.PaneDockedEventArgs.registerClass("Telerik.Web.UI.PaneDockedEventArgs",Sys.EventArgs);
Telerik.Web.UI.PaneBeforeUndockEventArgs=function(){
Telerik.Web.UI.PaneBeforeUndockEventArgs.initializeBase(this);
};
Telerik.Web.UI.PaneBeforeUndockEventArgs.prototype={};
Telerik.Web.UI.PaneBeforeUndockEventArgs.registerClass("Telerik.Web.UI.PaneBeforeUndockEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.PaneUndockedEventArgs=function(){
Telerik.Web.UI.PaneUndockedEventArgs.initializeBase(this);
};
Telerik.Web.UI.PaneUndockedEventArgs.prototype={};
Telerik.Web.UI.PaneUndockedEventArgs.registerClass("Telerik.Web.UI.PaneUndockedEventArgs",Sys.EventArgs);
Telerik.Web.UI.RadSlidingPane=function(_1){
Telerik.Web.UI.RadSlidingPane.initializeBase(this,[_1]);
this._title="";
this._enableResize=true;
this._enableDock=true;
this._parentPane=null;
this._resizeBarSize=null;
this._slideBorderSize=0;
this._isExpanded=false;
this._isDocked=false;
this._width=150;
this._height=150;
this._minWidth=60;
this._minHeight=60;
this._isInitialSizeApplied=false;
this._popupBehavior=null;
this._originalParent=null;
this._popupElement=null;
this._zone=null;
this._contentElement=null;
this._tableElement=null;
this._tabContainer=null;
this._resizeElement=null;
this.GetContentContainer=this.getContentContainer;
this.GetContent=this.getContent;
this.SetContent=this.setContent;
this.GetDockIconElement=this.getDockIconElement;
this.GetUndockIconElement=this.getUndockIconElement;
this.GetCollapseIconElement=this.getCollapseIconElement;
this.GetSlidingContainerTitle=this.getSlidingContainerTitle;
this.GetSlidingPaneResizeContainer=this.getSlidingPaneResizeContainer;
this.GetTabContainer=this.getTabContainer;
this.HideTab=this.hideTab;
this.ShowTab=this.showTab;
this.IsTabDisplayed=this.isTabDisplayed;
};
Telerik.Web.UI.RadSlidingPane.prototype={initialize:function(){
Telerik.Web.UI.RadSlidingPane.callBaseMethod(this,"initialize");
this._popupElement=this.get_element();
this._zone=this.get_parent();
this._contentElement=this.getContentContainer();
this._tableElement=this._popupElement.getElementsByTagName("TABLE")[0];
this._tabContainer=this.getTabContainer();
this._resizeElement=this.getSlidingPaneResizeContainer();
var _2=this._zone;
var _3=this._tabContainer;
$addHandlers(_3,{"mousedown":_2._paneTab_OnMouseDown,"mouseover":_2._paneTab_OnMouseOver,"mouseout":_2._paneTab_OnMouseOut},_2);
var _4=this._popupElement;
$addHandlers(_4,{"mouseover":this._slidingContainer_OnMouseOver,"mouseout":this._slidingContainer_OnMouseOut},this);
var _5=this._resizeElement;
$addHandlers(_5,{"mouseover":this._resizeSlidePane_OnMouseOver,"mouseout":this._resizeSlidePane_OnMouseOut,"mousedown":this._resizeSlidePane_OnMouseDown},this);
_5.setAttribute("unselectable","on");
var _6=this.getDockIconElement();
$addHandlers(_6,{"mouseover":this._dockElement_OnMouseOver,"mouseout":this._dockElement_OnMouseOut,"mousedown":this._dockElement_OnMouseDown},this);
var _7=this.getUndockIconElement();
$addHandlers(_7,{"mouseover":this._undockElement_OnMouseOver,"mouseout":this._undockElement_OnMouseOut,"mousedown":this._undockElement_OnMouseDown},this);
var _8=this.getCollapseIconElement();
$addHandlers(_8,{"mouseover":this._collapseElement_OnMouseOver,"mouseout":this._collapseElement_OnMouseOut,"mousedown":this._collapseElement_OnMouseDown},this);
if(!$telerik.isIE&&_2._isHorizontalSlide()){
var _9=this._getTitleContainerElement();
if(_9!=null){
_9.style.lineHeight=1;
_9.innerHTML=this._title.split("").join("<br/>");
}
}
this._originalParent=_4.parentNode;
this._moveRootToParent(false);
this.updateClientState();
},dispose:function(){
this._moveRootToParent(true);
if(this._popupBehavior){
this._popupBehavior.dispose();
this._popupBehavior=null;
}
this._originalParent=null;
if(this._expandAnimationEndedDelegate){
if(this._animation){
this._animation.remove_expandAnimationEnded(this._expandAnimationEndedDelegate);
}
this._expandAnimationEndedDelegate=null;
}
if(this._animation){
this._animation.dispose();
this._animation=null;
}
var _a=this._tabContainer;
$clearHandlers(_a);
var _b=this._popupElement;
$clearHandlers(_b);
var _c=this._resizeElement;
$clearHandlers(_c);
var _d=this.getDockIconElement();
$clearHandlers(_d);
var _e=this.getUndockIconElement();
$clearHandlers(_e);
var _f=this.getCollapseIconElement();
$clearHandlers(_f);
Telerik.Web.UI.RadSlidingPane.callBaseMethod(this,"dispose");
},get_enableResize:function(){
return this._enableResize;
},set_enableResize:function(_10){
this._enableResize=_10;
this.updateClientState();
},get_enableDock:function(){
return this._enableDock;
},set_enableDock:function(_11){
this._enableDock=_11;
this.updateClientState();
},set_title:function(_12){
this._title=_12;
var _13=this._getTitleContainerElement();
if(_13!=null){
if(this._zone){
if(!$telerik.isIE&&this._zone._isHorizontalSlide()){
_13.style.lineHeight=1;
_13.innerHTML=this._title.split("").join("<br/>");
}else{
_13.innerHTML=this._title;
}
}
}
var _14=this.getSlidingContainerTitle();
if(_14){
_14.innerHTML=this._title;
}
this.updateClientState();
},get_title:function(){
return this._title;
},get_expanded:function(){
return this._isExpanded;
},get_docked:function(){
return this._isDocked;
},get_parentPane:function(){
return this._parentPane;
},set_parentPane:function(_15){
this._parentPane=_15;
},add_docked:function(_16){
this.get_events().addHandler("docked",_16);
},remove_docked:function(_17){
this.get_events().removeHandler("docked",_17);
},add_undocked:function(_18){
this.get_events().addHandler("undocked",_18);
},remove_undocked:function(_19){
this.get_events().removeHandler("undocked",_19);
},add_beforeDock:function(_1a){
this.get_events().addHandler("beforeDock",_1a);
},remove_beforeDock:function(_1b){
this.get_events().removeHandler("beforeDock",_1b);
},add_beforeUndock:function(_1c){
this.get_events().addHandler("beforeUndock",_1c);
},remove_beforeUndock:function(_1d){
this.get_events().removeHandler("beforePaneUndocked",_1d);
},getContentContainer:function(){
if(!this._contentElement){
this._contentElement=$get("RAD_SLIDING_PANE_CONTENT_"+this.get_id());
}
return this._contentElement;
},get_pane:function(){
return this.get_parentPane().get_element();
},get_paneBounds:function(){
var _1e=this.get_pane();
return $telerik.getBounds(_1e);
},_show:function(x,y){
if($telerik.isFirefox){
var _21=$telerik.getCurrentStyle(this.get_splitter()._containerElement,"marginTop");
if(_21&&!isNaN(parseInt(_21))){
y+=parseInt(_21);
}
var _22=$telerik.getCurrentStyle(this.get_splitter()._containerElement,"marginLeft");
if(_22&&!isNaN(parseInt(_22))){
x+=parseInt(_22);
}
}
var _23=this._popupBehavior;
_23._setCoordinates(x,y);
_23.show();
},get_slidingPaneBounds:function(){
var _24=this._popupElement;
var _25=(_24.style.top==""&&!this._isDocked);
if(_25){
this._setSlidingContainerSize();
}
var _26=$telerik.getBounds(_24);
return _26;
},_fixIeHeight:function(_27,_28){
if("CSS1Compat"==document.compatMode){
var _29=(_27.offsetHeight-parseInt(_28));
if(_29>0){
var _2a=(parseInt(_27.style.height)-_29);
if(_2a>0){
_27.style.height=_2a+"px";
}
}
}
},getContent:function(){
var _2b=this._contentElement;
return _2b.innerHTML;
},setContent:function(_2c){
var _2d=this._contentElement;
_2d.innerHTML=_2c;
},getDockIconElement:function(){
return $get("RAD_SPLITTER_SLIDING_PANE_DOCK_"+this.get_id());
},getDockIconWrapperElement:function(){
return this.getDockIconElement().parentNode;
},getUndockIconElement:function(){
return $get("RAD_SPLITTER_SLIDING_PANE_UNDOCK_"+this.get_id());
},getUnDockIconWrapperElement:function(){
return this.getUndockIconElement().parentNode;
},getCollapseIconElement:function(){
return $get("RAD_SPLITTER_SLIDING_PANE_COLLAPSE_"+this.get_id());
},getCollapseIconWrapperElement:function(){
return this.getCollapseIconElement().parentNode;
},getSlidingContainerTitle:function(){
return $get("RAD_SPLITTER_SLIDING_TITLE_"+this.get_id());
},getSlidingPaneResizeContainer:function(){
if(!this._resizeElement){
this._resizeElement=$get("RAD_SPLITTER_SLIDING_ZONE_RESIZE_"+this.get_id());
}
return this._resizeElement;
},getTabContainer:function(){
if(!this._tabContainer){
this._tabContainer=$get("RAD_SLIDING_PANE_TAB_"+this.get_id());
}
return this._tabContainer;
},hideTab:function(){
var _2e=this._tabContainer;
if(_2e==null){
return;
}
_2e.style.display="none";
},showTab:function(){
var _2f=this._tabContainer;
if(_2f==null){
return;
}
_2f.style.display="";
},isTabDisplayed:function(){
var _30=this._tabContainer;
if(_30==null){
return false;
}
return (_30.style.display!="none");
},_setTabDefaultState:function(){
var _31=this._tabContainer;
if(_31==null){
return false;
}
_31.className="paneTabContainer";
},_setTabDockedState:function(){
var _32=this._tabContainer;
if(_32==null){
return false;
}
_32.className="paneTabContainerDocked";
},_setTabExpandedState:function(){
var _33=this._tabContainer;
if(_33==null){
return false;
}
_33.className="paneTabContainerExpanded";
},_resizeSlidePane_OnMouseOver:function(e){
var _35=this._resizeElement;
_35.className=(this._zone._isHorizontalSlide())?"slideContainerResizeOver":"slideContainerResizeOverHorizontal";
},_resizeSlidePane_OnMouseOut:function(e){
var _37=this._resizeElement;
_37.className=(this._zone._isHorizontalSlide())?"slideContainerResize":"slideContainerResizeHorizontal";
},_resizeSlidePane_OnMouseDown:function(e){
e.preventDefault();
e.stopPropagation();
var _39=this._zone;
var _3a=_39._isHorizontalSlide();
this._maxDecreaseDelta=(_3a)?this.get_width()-this.get_minWidth():this.get_height()-this.get_minHeight();
var _3b=(_3a)?this.get_maxWidth()-this.get_width():this.get_maxHeight()-this.get_height();
var _3c=this.get_parentPane();
var _3d=_3c._getAvailIncreaseDelta();
var _3e=this.get_splitter()._getAvailDecreaseDelta(_3c._indexInPanes,Telerik.Web.UI.SplitterDirection.Forward);
var _3f=Math.min(_3e,_3d);
var _40=_39.get_dockedPaneId();
if(_40!=null){
var _41=_39.getPaneById(_40);
_3f+=(_3a)?_41.get_width():_41.get_height();
}
_3f-=(_3a)?this.get_width():this.get_height();
this._maxIncreaseDelta=Math.min(_3b,_3f);
if(_39.isLeftDirection()||_39.isTopDirection()){
var t=this._maxIncreaseDelta;
this._maxIncreaseDelta=this._maxDecreaseDelta;
this._maxDecreaseDelta=t;
}
var _43=this._resizeElement;
var pos=$telerik.getLocation(_43);
if($telerik.isSafari&&_3a){
var _45=$telerik.getLocation(_43.parentNode);
pos.y=_45.y;
}
this._mouseStartX=e.clientX;
this._mouseStartY=e.clientY;
this._handlerStartLeftPos=pos.x;
this._handlerStartTopPos=pos.y;
this._currentDelta=0;
this._mouseUpResizeHandler=Function.createDelegate(this,this._resizeSlidePane_OnMouseUp);
this._mouseMoveResizeHandler=Function.createDelegate(this,this._resizeSlidePane_OnMouseMove);
$addHandler(document,"mouseup",this._mouseUpResizeHandler);
$addHandler(document,"mousemove",this._mouseMoveResizeHandler);
this._resizeMode=true;
return false;
},_resizeSlidePane_OnMouseUp:function(e){
$telerik.cancelRawEvent(e);
$removeHandler(document,"mouseup",this._mouseUpResizeHandler);
$removeHandler(document,"mousemove",this._mouseMoveResizeHandler);
this._resizeMode=false;
if(this._helperBar){
this._helperBar.parentNode.removeChild(this._helperBar);
this._helperBar=null;
}
var _47=this._zone;
if(_47.isLeftDirection()||_47.isTopDirection()){
this._currentDelta*=-1;
}
if(!this.get_expanded()){
return false;
}
if(this._currentDelta&&this._currentDelta!=0){
var _48=new Telerik.Web.UI.PaneBeforeResizeEventArgs(this._currentDelta);
this.raiseEvent("beforeResize",_48);
if(!_48.get_cancel()){
var _49=null;
var _4a=null;
var _4b=_47._isHorizontalSlide();
var _4c=this.get_slidingPaneBounds();
if(_4b){
_49=_4c.width+this._currentDelta;
}else{
_4a=_4c.height+this._currentDelta;
}
this._setSlidingContainerSize(_49,_4a);
var x=this._popupBehavior.get_x();
var y=this._popupBehavior.get_y();
if(_47.isLeftDirection()){
x-=this._currentDelta;
}else{
if(_47.isTopDirection()){
y-=this._currentDelta;
}
}
this._show(x,y);
var _4f=this.get_width();
var _50=this.get_height();
if(_4b){
this.set_width(_49);
}else{
this.set_height(_4a);
}
$telerik.repaintChildren(this);
this.raiseEvent("resized",new Telerik.Web.UI.PaneResizedEventArgs(_4f,_50));
}
}
return false;
},_resizeSlidePane_OnMouseMove:function(e){
e.preventDefault();
e.stopPropagation();
var _52=this._zone._isHorizontalSlide();
this._resizeMode=true;
var _53=150;
if(!this._helperBar){
var _54=document.createElement("TABLE");
_54.className=this.get_splitter().getContainerElement().className;
_54.style.borderCollapse="separate";
_54.cellSpacing=0;
_54.cellPadding=0;
_54.style.borderWidth="0px";
_54.style.background="";
var _55=document.createElement("TBODY");
_54.appendChild(_55);
var TR=document.createElement("TR");
_55.appendChild(TR);
var TD=document.createElement("TD");
TR.appendChild(TD);
var _58=document.createElement("DIV");
_58.className="helperBarSlideDrag";
if(_52){
_58.style.marginLeft=_53+"px";
_58.style.marginRight=_53+"px";
}else{
_58.style.marginTop=_53+"px";
_58.style.marginBottom=_53+"px";
}
TD.appendChild(_58);
_54.style.position="absolute";
_54.style.left=this._handlerStartLeftPos-(_52?_53:0)+"px";
_54.style.top=this._handlerStartTopPos-(!_52?_53:0)+"px";
this._helperBar=document.body.insertBefore(_54,document.body.firstChild);
var _59=this.get_parentPane();
if(_52){
$telerik.setOuterHeight(_58,_59.get_height());
$telerik.setOuterWidth(_58,3);
}else{
$telerik.setOuterWidth(_58,_59.get_width());
$telerik.setOuterHeight(_58,3);
}
this._helperBarDecoration=_58;
}
var _5a=(_52)?e.clientX-this._mouseStartX:e.clientY-this._mouseStartY;
var _5b=false;
if(_5a<((-1)*this._maxDecreaseDelta)){
_5b=true;
_5a=this._maxDecreaseDelta*(-1);
}
if(_5a>this._maxIncreaseDelta){
_5b=true;
_5a=this._maxIncreaseDelta;
}
if(this._resizeStep>0){
_5a-=_5a%this._resizeStep;
}
this._helperBarDecoration.className=(_52)?"helperBarSlideDrag":"helperBarSlideDragHorizontal";
var _5c=(_52)?"w-resize":"n-resize";
this._helperBarDecoration.style.cursor=_5c;
if(_52){
this._helperBar.style.left=this._handlerStartLeftPos+_5a-_53+"px";
}else{
this._helperBar.style.top=this._handlerStartTopPos+_5a-_53+"px";
}
this._helperBar.style.zIndex=this._popupElement.style.zIndex+1;
this._helperBar.style.cursor=_5c;
this._currentDelta=_5a;
if(_5b){
if(this._helperBarDecoration){
this._helperBarDecoration.className="helperBarSlideError";
}
}
return false;
},_slidingContainer_OnMouseOut:function(e){
if(this.get_docked()){
return;
}
if(this._resizeMode){
return;
}
if(!this.get_expanded()){
return;
}
if(this._isMouseInPaneRectangle(e)){
return;
}
var _5e=this;
var f=function(){
var _60=_5e._zone;
_60._paneTabInMover=null;
_60.collapsePane(_5e.get_id());
};
var _61=this._zone;
window.clearTimeout(_61._paneTabMoutTimeout);
_61._paneTabMoutTimeout=window.setTimeout(f,1000);
},_slidingContainer_OnMouseOver:function(e){
if(this.get_docked()){
return;
}
if(this._resizeMode){
return;
}
window.clearTimeout(this._zone._paneTabMoutTimeout);
},_dockElement_OnMouseDown:function(e){
if(e.button&&e.button!=1){
return true;
}
if(!this.get_expanded()){
return;
}
var _64=this._zone;
if(!_64.collapsePane(this.get_id(),true)){
return;
}
_64.dockPane(this.get_id());
this.getDockIconElement().className="slideHeaderDockIcon";
},_dockElement_OnMouseOver:function(e){
if(e.button&&e.button!=1){
return true;
}
this.getDockIconElement().className="slideHeaderDockIconOver";
},_dockElement_OnMouseOut:function(e){
if(e.button&&e.button!=1){
return true;
}
this.getDockIconElement().className="slideHeaderDockIcon";
},_undockElement_OnMouseDown:function(e){
if(e.button&&e.button!=1){
return true;
}
if(!this.get_docked()){
return;
}
this._zone.undockPane(this.get_id());
},_undockElement_OnMouseOver:function(e){
if(e.button&&e.button!=1){
return true;
}
this.getUndockIconElement().className="slideHeaderUndockIconOver";
},_undockElement_OnMouseOut:function(e){
if(e.button&&e.button!=1){
return true;
}
this.getUndockIconElement().className="slideHeaderUndockIcon";
},_collapseElement_OnMouseDown:function(e){
if(e.button&&e.button!=1){
return true;
}
if(!this.get_expanded()){
return;
}
var _6b=this._zone;
_6b._paneTabInMover=null;
_6b.collapsePane(this.get_id());
},_collapseElement_OnMouseOver:function(e){
if(e.button&&e.button!=1){
return true;
}
this.getCollapseIconElement().className="slideHeaderCollapseIconOver";
},_collapseElement_OnMouseOut:function(e){
if(e.button&&e.button!=1){
return true;
}
this.getCollapseIconElement().className="slideHeaderCollapseIcon";
},_onExpandAnimationEnded:function(){
this._tableElement.style.position="static";
if($telerik.isFirefox){
this._configureScrolling();
Sys.UI.DomElement.removeCssClass(this._contentElement,"hideContentOverflow");
}
if($telerik.getVisible(this.get_element())){
this._showOverlayElement(true);
}
$telerik.repaintChildren(this);
this.raiseEvent("expanded",new Telerik.Web.UI.PaneExpandedEventArgs());
},_expandSlidingContainer:function(){
var _6e=this._tableElement;
_6e.style.top="0px";
_6e.style.left="0px";
if($telerik.isFirefox){
var _6f=this._contentElement;
_6f.style.overflow="hidden";
Sys.UI.DomElement.addCssClass(_6f,"hideContentOverflow");
}
if(!this._animation){
var _70=Telerik.Web.UI.SlideDirection.Right;
var _71=this._zone;
if(_71.isLeftDirection()){
_70=Telerik.Web.UI.SlideDirection.Left;
}else{
if(_71.isBottomDirection()){
_70=Telerik.Web.UI.SlideDirection.Down;
}else{
if(_71.isTopDirection()){
_70=Telerik.Web.UI.SlideDirection.Up;
}
}
}
var _72=new Telerik.Web.UI.AnimationSettings({"duration":_71._slideDuration});
var _73=new Telerik.Web.UI.Slide(this._tableElement,_72,null,false);
_73.initialize();
_73.set_direction(_70);
this._expandAnimationEndedDelegate=Function.createDelegate(this,this._onExpandAnimationEnded);
_73.add_expandAnimationEnded(this._expandAnimationEndedDelegate);
this._animation=_73;
}
this._animation.expand();
this._showOverlayElement(false);
},_collapseSlidingContainer:function(){
try{
this._animation.stop();
}
catch(e){
}
this._hideSlidingContainer();
this.raiseEvent("collapsed",new Telerik.Web.UI.PaneCollapsedEventArgs());
},_setSlidingContainerSize:function(_74,_75){
var _76=this._zone;
if($telerik.isIE){
var _77=this.get_pane();
}else{
var _77=_76.getTabsContainer();
}
var _78=_76._isVerticalSlide();
if(_74==null){
_74=(!_78)?this.get_width():_77.offsetWidth;
}
if(_75==null){
_75=(_78)?this.get_height():_77.offsetHeight;
}
var _79=this._contentElement;
if($telerik.isSafari){
_79.style.width=_74+"px";
_79.style.height=_75+"px";
}
var _7a=$telerik.getBorderBox(_79);
var _7b=$telerik.getPaddingBox(_79);
var _7c=$telerik.getMarginBox(_79);
var _7d=this._popupElement;
if(parseInt(_7d.style.width)!=_74){
_7d.style.width=_74+"px";
}
if(parseInt(_7d.style.height)!=_75){
_7d.style.height=_75+"px";
}
var _7e=_75;
if(this.get_enableResize()&&_78){
_7e-=(this._resizeElement.offsetHeight);
}
var _7f=this._tableElement.getElementsByTagName("TR");
var _80=null;
for(var i=0,_82=_7f.length;i<_82;i++){
if(_7f[i].className=="slideHeader"){
_80=_7f[i];
break;
}
}
if(_80){
_7e-=_80.offsetHeight;
}
_7e-=(_7a.vertical+_7b.vertical+_7c.vertical);
if(parseInt(_79.style.height)!=_7e){
_79.style.height=_7e+"px";
}
var _83=_74;
if(this.get_enableResize()&&!_78){
_83-=(this._resizeElement.offsetWidth);
}
_83-=(_7a.horizontal+_7b.horizontal+_7c.horizontal);
if(parseInt(_79.style.width)!=_83){
_79.style.width=_83+"px";
}
this._isInitialSizeApplied=true;
},_hideSlidingContainer:function(){
var _84=this._popupElement;
_84.style.top="";
_84.style.left="";
this._showOverlayElement(false);
},_dockSlidingContainer:function(){
var _85=this._popupElement;
_85.style.position="static";
this._tableElement.style.position="static";
this._showOverlayElement(false);
_85.firstChild.className="slideContainerDocked";
},_unDockSlidingContainer:function(){
var _86=this._popupElement;
_86.style.position="";
this._tableElement.style.position="";
this._showOverlayElement(true);
_86.firstChild.className="slideContainer";
},_setSlidingContainerResizable:function(_87){
var _88=this._resizeElement;
if(_89){
_88=_88.parentNode;
}
if(_87&&_88.style.display==""){
return;
}
if(this._enableResize){
var _89=this._zone._isVerticalSlide();
var _8a=this._resizeBarSize;
if(!_8a){
this._resizeBarSize=parseInt((_89)?_88.offsetHeight:_88.offsetWidth);
_8a=this._resizeBarSize;
}
if(_87){
_8a*=-1;
}
var _8b=this._contentElement;
if(_89){
_8b.style.height=parseInt(_8b.style.height)+_8a+"px";
}else{
_8b.style.width=parseInt(_8b.style.width)+_8a+"px";
}
}
_88.style.display=(_87)?"":"none";
},_setIconsExpandedState:function(){
this._hideAllIcons();
this.getDockIconWrapperElement().style.display=(this.get_enableDock())?"":"none";
this.getDockIconElement().className="slideHeaderDockIcon";
this.getCollapseIconWrapperElement().style.display="";
},_setIconsDockedState:function(){
this._hideAllIcons();
this.getUnDockIconWrapperElement().style.display="";
this.getUndockIconElement().className="slideHeaderUndockIcon";
},_hideAllIcons:function(){
this.getDockIconWrapperElement().style.display="none";
this.getUnDockIconWrapperElement().style.display="none";
this.getCollapseIconWrapperElement().style.display="none";
},_getTitleContainerElement:function(){
return $get("RAD_SLIDING_PANE_TEXT_"+this.get_id());
},_dock:function(){
this._setIconsDockedState();
this._setSlidingContainerResizable(false);
this._dockSlidingContainer();
if(!this._isInitialSizeApplied){
this._setSlidingContainerSize();
}
$telerik.repaintChildren(this);
this._isExpanded=false;
this._isDocked=true;
},_undock:function(){
this._isExpanded=false;
this._isDocked=false;
this._setSlidingContainerResizable(this._enableResize);
this._unDockSlidingContainer();
this._hideSlidingContainer();
},_expand:function(){
var _8c=this._zone;
var _8d=_8c.getTabsContainer();
var _8e=this._popupElement;
if(!this._popupBehavior){
this._popupBehavior=$create(Telerik.Web.PopupBehavior,{"id":(new Date()-100)+"PopupBehavior","parentElement":_8d,"keepInScreenBounds":false,"manageVisibility":false},null,null,_8e);
}
this._setSlidingContainerResizable(this._enableResize);
this._setIconsExpandedState();
var _8f=this.get_slidingPaneBounds();
var _90=$telerik.getBounds(_8d);
var x=0;
var y=0;
if(_8c.isRightDirection()){
x=_90.width;
if($telerik.isIE){
var _93=$telerik.getCurrentStyle(_8d,"borderRightWidth");
if(_93&&!isNaN(parseInt(_93))){
x-=Math.floor(parseInt(_93)/2);
}
}
}else{
if(_8c.isLeftDirection()){
x=-_8f.width;
}else{
if(_8c.isBottomDirection()){
y=_90.height;
if($telerik.isIE){
var _94=$telerik.getCurrentStyle(_8d,"borderBottomWidth");
if(_94&&!isNaN(parseInt(_94))){
y-=Math.floor(parseInt(_94)/2);
}
}
}else{
if(_8c.isTopDirection()){
y=-_8f.height;
}
}
}
}
this._show(x,y);
this._expandSlidingContainer();
this._isExpanded=true;
this._isDocked=false;
},_collapse:function(){
this._isExpanded=false;
this._isDocked=false;
this._collapseSlidingContainer();
},_isMouseInPaneRectangle:function(e){
var _96=this._popupElement;
var _97=null;
try{
_97=$telerik.getBounds(_96);
}
catch(e){
return false;
}
if(e&&e.target){
var _98=e.target.tagName;
if(_98=="SELECT"||_98=="OPTION"){
return true;
}
if(e.clientX<0||e.clientY<0){
return true;
}
}
var _99=(document.compatMode&&document.compatMode!="BackCompat")?document.documentElement:document.body;
var x=e.clientX+_99.scrollLeft;
var y=e.clientY+_99.scrollTop;
return $telerik.containsPoint(_97,x,y);
},saveClientState:function(){
var _9c={};
var _9d=["width","height","title","enableResize","minWidth","maxWidth","minHeight","maxHeight","enableDock"];
for(var i=0,_9f=_9d.length;i<_9f;i++){
var _a0=_9d[i];
_9c[_a0]=this["get_"+_a0]();
}
return Sys.Serialization.JavaScriptSerializer.serialize(_9c);
},_getOverlayElement:function(){
return this._popupElement._hideWindowedElementsIFrame;
},_showOverlayElement:function(_a1){
var _a2=this._getOverlayElement();
if(!_a2){
return;
}
_a2.style.display=_a1?"":"none";
},_moveRootToParent:function(_a3){
var _a4=(_a3)?this._originalParent:document.forms[0];
var _a5=this._popupElement;
if(!_a5){
return;
}
var _a6=_a5.parentNode;
if(!_a4||!_a6||_a4.id==_a6.id){
return;
}
_a6.removeChild(_a5);
_a4.appendChild(_a5);
}};
Telerik.Web.UI.RadSlidingPane.registerClass("Telerik.Web.UI.RadSlidingPane",Telerik.Web.UI.SplitterPaneBase);

