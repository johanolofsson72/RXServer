Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.SplitterSlideDirection=function(){
};
Telerik.Web.UI.SplitterSlideDirection.prototype={Right:1,Left:2,Top:3,Bottom:4};
Telerik.Web.UI.SplitterSlideDirection.registerEnum("Telerik.Web.UI.SplitterSlideDirection",false);
Telerik.Web.UI.RadSlidingZone=function(_1){
Telerik.Web.UI.RadSlidingZone.initializeBase(this,[_1]);
this._width=null;
this._height=null;
this._clickToOpen=false;
this._resizeStep=0;
this._slideDuration=300;
this._splitter=null;
this._slideDirection=Telerik.Web.UI.SplitterSlideDirection.Right;
this._slidingPanes=[];
this._slidingPanesById=[];
this._dockedPaneId=null;
this._initiallyDockedPaneId=null;
this._expandedPaneId=null;
this.GetPaneById=this.getPaneById;
this.GetTabsContainer=this.getTabsContainer;
this.DockPane=this.dockPane;
this.UndockPane=this.undockPane;
this.GetPanes=this.getPanes;
this.ExpandPane=this.expandPane;
this.CollapsePane=this.collapsePane;
this.IsLeftDirection=this.isLeftDirection;
this.IsRightDirection=this.isRightDirection;
this.IsTopDirection=this.isTopDirection;
this.IsBottomDirection=this.isBottomDirection;
};
Telerik.Web.UI.RadSlidingZone.prototype={endUpdate:function(){
if(this._width.toString().indexOf("px")>-1){
this._width=parseInt(this._width,10);
}
if(this._height.toString().indexOf("px")>-1){
this._height=parseInt(this._height,10);
}
Telerik.Web.UI.RadSlidingZone.callBaseMethod(this,"endUpdate");
},dispose:function(){
var _2=this.getPanes();
for(var i=0,_4=_2.length;i<_4;i++){
_2[i]._moveRootToParent(true);
}
Telerik.Web.UI.RadSlidingZone.callBaseMethod(this,"dispose");
},initialize:function(){
Telerik.Web.UI.RadSlidingZone.callBaseMethod(this,"initialize");
this._splitterLoadedHandler=Function.createDelegate(this,this._splitterLoadedHandler);
this.get_splitter().add_loaded(this._splitterLoadedHandler);
},set_clickToOpen:function(_5){
this._clickToOpen=_5;
this.updateClientState();
},get_clickToOpen:function(){
return this._clickToOpen;
},set_resizeStep:function(_6){
this._resizeStep=_6;
this.updateClientState();
},get_resizeStep:function(){
return this._resizeStep;
},set_slideDuration:function(_7){
this._slideDuration=_7;
this.updateClientState();
},get_slideDuration:function(){
return this._slideDuration;
},get_width:function(){
return this._width;
},get_height:function(){
return this._height;
},get_expandedPaneId:function(){
return this._expandedPaneId;
},get_dockedPaneId:function(){
return this._dockedPaneId;
},get_splitter:function(){
return this._splitter;
},set_splitter:function(_8){
this._splitter=_8;
},add_loaded:function(_9){
this.get_events().addHandler("loaded",_9);
},remove_loaded:function(_a){
this.get_events().removeHandler("loaded",_a);
},getPaneById:function(_b){
return this._slidingPanesById[_b];
},getTabsContainer:function(){
return $get("RAD_SLIDING_ZONE_TABS_CONTAINER_"+this.get_id());
},dockPane:function(_c){
var _d=this.getPaneById(_c);
if(!_d||!_d.get_enableDock()){
return false;
}
var _e=new Telerik.Web.UI.PaneBeforeDockEventArgs();
_d.raiseEvent("beforeDock",_e);
if(_e.get_cancel()){
return false;
}
if(this._dockedPaneId){
if(!this.undockPane(this._dockedPaneId)){
return false;
}
}
var _f=$get("RAD_SLIDING_ZONE_PANES_CONTAINER_"+this.get_id());
if(this.isLeftDirection()&&$telerik.isSafari){
_f.style.width="";
}
_d._moveRootToParent(true);
this._dockingMode=true;
var _10=(this._isHorizontalSlide())?_d.get_width():_d.get_height();
var _11=(this.isLeftDirection()||this.isTopDirection())?Telerik.Web.UI.SplitterDirection.Backward:Telerik.Web.UI.SplitterDirection.Forward;
var _12=this.get_parent();
var _13=this.get_splitter()._getAvailIncreaseDelta(_12._indexInPanes,_11);
var _14=(this._isHorizontalSlide())?_d.get_minWidth():_d.get_minHeight();
if(_13<_14){
return false;
}
var _15=_10+this._getTabsContainerSize();
var _16=_12.getVarSize();
var _17=_16+_13;
var _18=Math.min(_17,_15);
var _19=_18-_16;
if(_19!=0){
_12.resize(_19,_11);
}
_d._dock();
_d._setTabDockedState();
if(this._isVerticalSlide()){
var _1a=_d.get_height()+this._getTabsContainerSize();
var _1b=this.get_element();
$telerik.setOuterHeight(_f,_d.get_height());
$telerik.setOuterHeight(_1b,_1a);
}else{
if(this.isLeftDirection()&&$telerik.isSafari){
_f.style.width="1px";
}
}
this._dockedPaneId=_c;
this.updateClientState();
this._dockingMode=false;
_d.raiseEvent("docked",new Telerik.Web.UI.PaneDockedEventArgs());
return true;
},undockPane:function(_1c){
var _1d=this.getPaneById(_1c);
if(!_1d){
return false;
}
var _1e=new Telerik.Web.UI.PaneBeforeUndockEventArgs();
_1d.raiseEvent("beforeUndock",_1e);
if(_1e.get_cancel()){
return false;
}
if(!_1c){
_1c=this._dockedPaneId;
}
if(this.get_parent().get_collapsed()){
return false;
}
_1d._moveRootToParent(false);
this._dockingMode=true;
_1d._undock();
this._dockedPaneId=null;
var _1f=this._getTabsContainerSize();
if(this._isVerticalSlide()){
var _20=this.get_element();
$telerik.setOuterHeight(document.getElementById("RAD_SLIDING_ZONE_PANES_CONTAINER_"+this.get_id()),0);
$telerik.setOuterHeight(_20,_1f);
}
var _21=this.get_parent().getVarSize();
var _22=_21-_1f;
var _23=(this.isLeftDirection()||this.isTopDirection())?Telerik.Web.UI.SplitterDirection.Backward:Telerik.Web.UI.SplitterDirection.Forward;
this.get_parent().resize(_22*(-1),_23);
_1d._setTabDefaultState();
this.updateClientState();
this._dockingMode=false;
_1d.raiseEvent("undocked",new Telerik.Web.UI.PaneUndockedEventArgs());
this._paneTabInMover=null;
return true;
},getPanes:function(){
return this._slidingPanes;
},expandPane:function(_24){
if(this._dockedPaneId==_24){
return false;
}
var _25=this.getPaneById(_24);
var _26=_25.getTabContainer();
if(!_25||!_26){
return false;
}
var _27=new Telerik.Web.UI.PaneBeforeExpandEventArgs();
_25.raiseEvent("beforeExpand",_27);
if(_27.get_cancel()){
return false;
}
_25._setTabExpandedState();
_25._expand();
this._expandedPaneId=_24;
this.updateClientState();
return true;
},collapsePane:function(_28,_29){
if(this._expandedPaneId!=_28){
return true;
}
if(this._dockedPaneId==_28){
return false;
}
var _2a=this.getPaneById(_28);
var _2b=_2a.getTabContainer();
if(!_2a||!_2b){
return false;
}
var _2c=new Telerik.Web.UI.PaneBeforeCollapseEventArgs();
_2a.raiseEvent("beforeCollapse",_2c);
if(_2c.get_cancel()){
return false;
}
_2a._setTabDefaultState();
if(_2a._animation){
_2a._animation._stopAnimation();
}
if(!_29){
_2a._tableElement.style.position="";
}
_2a._collapse();
this._expandedPaneId=null;
this.updateClientState();
return true;
},isLeftDirection:function(e){
return (this._slideDirection==Telerik.Web.UI.SplitterSlideDirection.Left);
},isRightDirection:function(){
return (this._slideDirection==Telerik.Web.UI.SplitterSlideDirection.Right);
},isTopDirection:function(){
return (this._slideDirection==Telerik.Web.UI.SplitterSlideDirection.Top);
},isBottomDirection:function(){
return (this._slideDirection==Telerik.Web.UI.SplitterSlideDirection.Bottom);
},_paneTab_OnMouseOver:function(e){
window.clearTimeout(this._paneTabMoutTimeout);
var _2f=e.target;
var _30=this._getPaneIdFromTabElement(_2f);
if(!_30){
return;
}
if(_30==this._paneTabInMover){
return;
}
this._paneTabInMover=_30;
if(!this._clickToOpen){
if(this._expandedPaneId!=null){
if(!this.collapsePane(this._expandedPaneId)){
return;
}
}
this.expandPane(_30);
}
},_paneTab_OnMouseOut:function(e){
if(this._clickToOpen){
return;
}
var _32=e.target;
var _33=this._getPaneIdFromTabElement(_32);
if(!_33){
return;
}
var _34=this;
var f=function(){
_34._paneTabInMover=null;
_34.collapsePane(_33);
};
this._paneTabMoutTimeout=window.setTimeout(f,100);
},_paneTab_OnMouseDown:function(e){
if(!this._clickToOpen){
return;
}
var _37=e.target;
var _38=this._getPaneIdFromTabElement(_37);
if(this._expandedPaneId==_38){
this.collapsePane(_38);
}else{
if(this._expandedPaneId){
if(!this.collapsePane(this._expandedPaneId)){
return;
}
}
this.expandPane(_38);
}
},_isHorizontalSlide:function(){
return (this._slideDirection==Telerik.Web.UI.SplitterSlideDirection.Left||this._slideDirection==Telerik.Web.UI.SplitterSlideDirection.Right);
},_isVerticalSlide:function(){
return !this._isHorizontalSlide();
},_getPaneIdFromTabElement:function(_39){
while(_39&&_39.tagName!="DIV"){
_39=_39.parentNode;
}
if(!_39||_39.id.indexOf("RAD_SLIDING_PANE_TAB_")==-1){
return "";
}
return _39.id.substr("RAD_SLIDING_PANE_TAB_".length);
},_handleBeforeParentPaneResized:function(_3a,_3b){
if(this._dockingMode){
return;
}
var _3c=_3b.get_delta();
if(this._dockedPaneId){
var _3d=this.getPaneById(this._dockedPaneId);
if(!_3d.get_enableResize()){
_3b.set_cancel(true);
return;
}
var _3e=this._getTabsContainerSize();
var _3f=_3e+(this._isHorizontalSlide())?_3d.get_minWidth():_3d.get_minHeight();
var _40=_3e+(this._isHorizontalSlide())?_3d.get_maxWidth():_3d.get_maxHeight();
var _41=_3d.get_slidingPaneBounds();
var _42=(this._isHorizontalSlide())?_41.width:_41.height;
var _43=_42+_3c;
if(_43>_40||_43<_3f){
_3b.set_cancel(true);
return;
}
var _44=new Telerik.Web.UI.PaneBeforeResizeEventArgs(_3c);
_3d.raiseEvent("beforeResize",_44);
_3b.set_cancel(_44.get_cancel());
}
},_getTabsContainerSize:function(){
var _45=this.getTabsContainer();
return (this._isHorizontalSlide())?_45.offsetWidth:_45.offsetHeight;
},_handleParentPaneResized:function(_46,_47){
if(this._dockingMode){
return;
}
if(!this._dockedPaneId){
return;
}
var _48=this.getPaneById(this._dockedPaneId);
if(!_48.get_enableResize()){
return;
}
var _49=_48.get_slidingPaneBounds();
var _4a=_49.width;
var _4b=_46.get_width()-_47.get_oldWidth();
var _4c=_4a+_4b;
var _4d=_49.height;
var _4e=_46.get_height()-_47.get_oldHeight();
var _4f=_4d+_4e;
_48._setSlidingContainerSize(_4c,_4f);
var _50=_48.get_width();
var _51=_47.get_oldHeight();
var _4f=_46.get_height();
_48.set_width(_4c);
_48.set_height(_4f);
if(this._isVerticalSlide()){
var _52=_4f;
var _53=this.get_element();
$telerik.setOuterHeight(_53,_52);
$telerik.setOuterHeight(document.getElementById("RAD_SLIDING_ZONE_PANES_CONTAINER_"+this.get_id()),_4f-this._getTabsContainerSize());
}
_48.raiseEvent("resized",new Telerik.Web.UI.PaneResizedEventArgs(_50,_51));
},_handleSplitterResized:function(_54,_55){
if(this._expandedPaneId){
if(_54.get_width()!=_55.get_oldWidth()||_54.get_height()!=_55.get_oldHeight()){
var _56=this._expandedPaneId;
this.collapsePane(_56);
this.expandPane(_56);
}
}
},_addPane:function(_57){
this._slidingPanes[this._slidingPanes.length]=_57;
this._slidingPanesById[_57.get_id()]=_57;
},_splitterLoadedHandler:function(){
$get("RAD_SLIDING_ZONE_PANES_CONTAINER_"+this.get_id()).style.display="";
this.get_parent().add_beforeResize(Function.createDelegate(this,this._handleBeforeParentPaneResized));
this.get_parent().add_resized(Function.createDelegate(this,this._handleParentPaneResized));
this.get_splitter().add_resized(Function.createDelegate(this,this._handleSplitterResized));
if(this._initiallyDockedPaneId!=null){
this.dockPane(this._initiallyDockedPaneId);
}
if(this._expandedPaneId!=null){
this.expandPane(this._expandedPaneId);
}
if(!this.isLeftDirection()&&Sys.Browser.agent==Sys.Browser.Firefox){
this.get_parent().getContentElement().style.overflow="";
}
this.updateClientState();
this.get_splitter().remove_loaded(this._splitterLoadedHandler);
this.raiseEvent("loaded");
},saveClientState:function(){
if(this.get_isUpdating()){
return null;
}
var _58={"dockedPaneId":this._dockedPaneId||"","expandedPaneId":this._expandedPaneId||""};
var _59=["clickToOpen","resizeStep","slideDuration"];
for(var i=0,_5b=_59.length;i<_5b;i++){
var _5c=_59[i];
_58[_5c]=this["get_"+_5c]();
}
return Sys.Serialization.JavaScriptSerializer.serialize(_58);
}};
Telerik.Web.UI.RadSlidingZone.registerClass("Telerik.Web.UI.RadSlidingZone",Telerik.Web.UI.RadWebControl);

