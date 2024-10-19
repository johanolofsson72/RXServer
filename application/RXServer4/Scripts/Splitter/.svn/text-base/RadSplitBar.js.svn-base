Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.SplitBarCollapseMode=function(){
};
Telerik.Web.UI.SplitBarCollapseMode.prototype={None:1,Forward:2,Backward:3,Both:4};
Telerik.Web.UI.SplitBarCollapseMode.registerEnum("Telerik.Web.UI.SplitBarCollapseMode",false);
Telerik.Web.UI.RadSplitBar=function(_1){
Telerik.Web.UI.RadSplitBar.initializeBase(this,[_1]);
this._collapseMode=Telerik.Web.UI.SplitBarCollapseMode.None;
this._enableResize=true;
this._resizeStep=0;
this._indexInSplitBars=0;
this._prevPane=null;
this._nextPane=null;
this._collapsed={};
this._collapsed[Telerik.Web.UI.SplitterDirection.Forward]=false;
this._collapsed[Telerik.Web.UI.SplitterDirection.Backward]=false;
this.IsCollapseDirectionEnabled=this.isCollapseDirectionEnabled;
this.GetCollapseBarElement=this.getCollapseBarElement;
this.IsCollapsed=this.isCollapsed;
this.GetWidth=this.getWidth;
this.GetHeight=this.getHeight;
};
Telerik.Web.UI.RadSplitBar.prototype={initialize:function(){
Telerik.Web.UI.RadSplitBar.callBaseMethod(this,"initialize");
this.get_splitter()._addSplitBar(this);
var _2=Telerik.Web.UI.SplitterDirection.Forward;
if(this.isCollapseDirectionEnabled(_2)){
var _3=this.getCollapseBarElement(_2);
$addHandlers(_3,{"mousedown":this._collapseBarFwdOnMouseDown,"mouseover":this._collapseBarFwdOnMouseOver,"mouseout":this._collapseBarFwdOnMouseOut},this);
}
var _2=Telerik.Web.UI.SplitterDirection.Backward;
if(this.isCollapseDirectionEnabled(_2)){
var _3=this.getCollapseBarElement(_2);
$addHandlers(_3,{"mousedown":this._collapseBarBackOnMouseDown,"mouseover":this._collapseBarBackOnMouseOver,"mouseout":this._collapseBarBackOnMouseOut},this);
}
if(this.get_enableResize()){
var _4=this.get_element();
$addHandlers(_4,{"mousedown":this._onMouseDown,"mouseover":this._onMouseOver,"mouseout":this._onMouseOut},this);
}
this._setCursorStyle();
this._splitterLoadedHandler=Function.createDelegate(this,this._splitterLoadedHandler);
this.get_splitter().add_loaded(this._splitterLoadedHandler);
},dispose:function(){
var _5=Telerik.Web.UI.SplitterDirection.Forward;
if(this.isCollapseDirectionEnabled(_5)){
var _6=this.getCollapseBarElement(_5);
$clearHandlers(_6);
}
var _5=Telerik.Web.UI.SplitterDirection.Backward;
if(this.isCollapseDirectionEnabled(_5)){
var _6=this.getCollapseBarElement(_5);
$clearHandlers(_6);
}
if(this.get_enableResize()){
var _7=this.get_element();
$clearHandlers(_7);
}
Telerik.Web.UI.RadSplitBar.callBaseMethod(this,"dispose");
},endUpdate:function(){
Telerik.Web.UI.RadSplitBar.callBaseMethod(this,"endUpdate");
},set_collapseMode:function(_8){
this._collapseMode=_8;
},get_collapseMode:function(){
return this._collapseMode;
},set_resizeStep:function(_9){
this._resizeStep=_9;
},get_resizeStep:function(){
return this._resizeStep;
},set_enableResize:function(_a){
this._enableResize=_a;
},get_enableResize:function(){
return this._enableResize;
},set_nextPane:function(_b){
this._nextPane=_b;
},get_nextPane:function(_c){
return this._nextPane;
},set_prevPane:function(_d){
this._prevPane=_d;
},get_prevPane:function(_e){
return this._prevPane;
},get_splitter:function(){
return this._parent;
},isCollapseDirectionEnabled:function(_f){
if(this._collapseMode==Telerik.Web.UI.SplitBarCollapseMode.Both){
return true;
}
if(_f==Telerik.Web.UI.SplitterDirection.Forward&&this._collapseMode==Telerik.Web.UI.SplitBarCollapseMode.Forward){
return true;
}
if(_f==Telerik.Web.UI.SplitterDirection.Backward&&this._collapseMode==Telerik.Web.UI.SplitBarCollapseMode.Backward){
return true;
}
return false;
},getCollapseBarElement:function(_10){
var _11="Forward";
if(_10==Telerik.Web.UI.SplitterDirection.Backward){
_11="Backward";
}
return $get("RAD_SPLITTER_BAR_COLLAPSE_"+_11+"_"+this.get_id());
},isCollapsed:function(_12){
return this._collapsed[_12];
},getWidth:function(){
return this.get_element().offsetWidth;
},getHeight:function(){
return this.get_element().offsetHeight;
},_collapseBarFwdOnMouseOut:function(e){
e.stopPropagation();
var _14=this.getCollapseBarElement(Telerik.Web.UI.SplitterDirection.Forward);
var _15=this._collapsed[Telerik.Web.UI.SplitterDirection.Forward];
_14.className=(this.get_splitter().isVertical())?((!_15)?"collapseBarCollapse":"collapseBarExpand"):((!_15)?"collapseBarHorizontalCollapse":"collapseBarHorizontalExpand");
return false;
},_collapseBarFwdOnMouseOver:function(e){
e.stopPropagation();
var _17=this.getCollapseBarElement(Telerik.Web.UI.SplitterDirection.Forward);
var _18=this._collapsed[Telerik.Web.UI.SplitterDirection.Forward];
_17.className=(this.get_splitter().isVertical())?((!_18)?"collapseBarCollapseOver":"collapseBarExpandOver"):((!_18)?"collapseBarHorizontalCollapseOver":"collapseBarHorizontalExpandOver");
this._setHorizontalWrapperWidth();
return false;
},_collapseBarFwdOnMouseDown:function(e){
if(e.button&&e.button!=1){
return true;
}
e.preventDefault();
e.stopPropagation();
this._collapseTargetPane(Telerik.Web.UI.SplitterDirection.Forward);
var _1a=this;
var _1b=function(){
_1a._collapseBarFwdOnMouseOut(e);
};
setTimeout(_1b,10);
return false;
},_collapseBarBackOnMouseOut:function(e){
e.stopPropagation();
var _1d=this.getCollapseBarElement(Telerik.Web.UI.SplitterDirection.Backward);
var _1e=this._collapsed[Telerik.Web.UI.SplitterDirection.Backward];
_1d.className=(this.get_splitter().isVertical())?((!_1e)?"collapseBarExpand":"collapseBarCollapse"):((!_1e)?"collapseBarHorizontalExpand":"collapseBarHorizontalCollapse");
return false;
},_collapseBarBackOnMouseOver:function(e){
e.stopPropagation();
var _20=this.getCollapseBarElement(Telerik.Web.UI.SplitterDirection.Backward);
var _21=this._collapsed[Telerik.Web.UI.SplitterDirection.Backward];
_20.className=(this.get_splitter().isVertical())?((!_21)?"collapseBarExpandOver":"collapseBarCollapseOver"):((!_21)?"collapseBarHorizontalExpandOver":"collapseBarHorizontalCollapseOver");
this._setHorizontalWrapperWidth();
return false;
},_collapseBarBackOnMouseDown:function(e){
if(e.button&&e.button!=1){
return true;
}
e.preventDefault();
e.stopPropagation();
this._collapseTargetPane(Telerik.Web.UI.SplitterDirection.Backward);
var _23=this;
var _24=function(){
_23._collapseBarBackOnMouseOut(e);
};
setTimeout(_24,10);
return false;
},_onMouseDown:function(e){
e.preventDefault();
e.stopPropagation();
if(this.isCollapsed(Telerik.Web.UI.SplitterDirection.Forward)||this.isCollapsed(Telerik.Web.UI.SplitterDirection.Backward)){
return false;
}
this._maxDecreaseDelta=this._getAvailDecreaseDelta();
this._maxIncreaseDelta=this._getAvailIncreaseDelta();
var _26=this.get_element();
var _27=this.get_splitter();
var pos=$telerik.getLocation(_26);
if($telerik.isSafari&&_27.isVertical()){
var _29=$telerik.getLocation(_26.parentNode);
pos.y=_29.y;
}
this._mouseStartX=e.clientX;
this._mouseStartY=e.clientY;
this._targetResizePane=_27._getAvailAdjacentPane(this._prevPane._indexInPanes+1,Telerik.Web.UI.SplitterDirection.Backward);
if(this._targetResizePane==null){
return false;
}
this._liveResMouseX=e.clientX;
this._liveResMouseY=e.clientY;
this._liveResPaneStartSize=this._targetResizePane.getVarSize();
this._mouseOffsetX=e.clientX-pos.x;
this._mouseOffsetY=e.clientY-pos.y;
this._handlerStartLeftPos=pos.x;
this._handlerStartTopPos=pos.y;
this._currentDelta=0;
this._onMouseUpDelegate=Function.createDelegate(this,this._onMouseUp);
this._onMouseMoveDelegate=Function.createDelegate(this,this._onMouseMove);
$addHandler(document,"mouseup",this._onMouseUpDelegate);
$addHandler(document,"mousemove",this._onMouseMoveDelegate);
return false;
},_onMouseMove:function(e){
e.preventDefault();
e.stopPropagation();
var _2b=this.get_splitter();
var _2c=_2b.isVertical();
var _2d=_2b._borderSize;
var _2e=Math.floor(_2d/2);
var _2f=_2b.get_liveResize();
var _30=0;
if(_2c){
_30=e.clientX-this._mouseStartX;
}else{
_30=e.clientY-this._mouseStartY;
}
var _31=150;
if(!this._helperBar){
var _32=document.createElement("TABLE");
_32.className=_2b.getContainerElement().className;
_32.style.borderCollapse="separate";
_32.cellSpacing=0;
_32.cellPadding=0;
_32.style.borderWidth="0px";
_32.style.background="";
_32.style.cursor=this._getCursorStyle();
var _33=document.createElement("TBODY");
_32.appendChild(_33);
var TR=document.createElement("TR");
_33.appendChild(TR);
var TD=document.createElement("TD");
TR.appendChild(TD);
var _36=document.createElement("DIV");
_36.className="helperBarDrag";
if(_2c){
_36.style.marginLeft=_31+"px";
_36.style.marginRight=_31+"px";
}else{
_36.style.marginTop=_31+"px";
_36.style.marginBottom=_31+"px";
}
var _37=this.getWidth();
var _38=0;
if(_2c||!$telerik.isIE){
_38=(_37>_2d)?_2d:(_37>_2e)?_2e:0;
}
_36.style.width=_37-_38+"px";
var _39=this.getHeight();
var _3a=0;
if(!_2c||!$telerik.isIE){
_3a=(_37>_2d)?_2d:(_37>_2e)?_2e:0;
}
_36.style.height=_39-_3a+"px";
TD.appendChild(_36);
_32.style.position="absolute";
var _3b=0;
var _3c=0;
_32.style.left=this._handlerStartLeftPos-(_2c?_31:0)+((!$telerik.isIE)?_2e:0)+(($telerik.isSafari)?_2e:0)+_3b+"px";
_32.style.top=this._handlerStartTopPos-(!_2c?_31:0)+((!$telerik.isIE)?_2e:0)+(($telerik.isSafari)?_2e:0)+_3c+"px";
_32.style.zIndex=1;
this._helperBar=document.body.insertBefore(_32,document.body.firstChild);
this._helperBarDecoration=_36;
}
var _3d=false;
if(_30<((-1)*this._maxDecreaseDelta)){
_3d=true;
_30=this._maxDecreaseDelta*(-1);
}
if(_30>this._maxIncreaseDelta){
_3d=true;
_30=this._maxIncreaseDelta;
}
if(this._resizeStep>0&&!_2f){
_30-=_30%this._resizeStep;
}
this._helperBarDecoration.className="helperBarDrag";
if(_2c){
this._helperBar.style.left=this._handlerStartLeftPos-(_2c?_31:0)+_2e+_30+"px";
}else{
this._helperBar.style.top=this._handlerStartTopPos-(!_2c?_31:0)+_2e+_30+"px";
}
if(!_2f){
this._currentDelta=_30;
}
if(_3d){
if(this._helperBarDecoration){
this._helperBarDecoration.className="helperBarError";
}
if(!_2f){
return false;
}
}
if(_2f){
var _3e=32;
if(this._lastUpdate&&((new Date()-this._lastUpdate)<_3e)){
return false;
}
this._lastUpdate=new Date();
if(_2c){
_30=e.clientX-this._liveResMouseX;
}else{
_30=e.clientY-this._liveResMouseY;
}
this._liveResMouseX=e.clientX;
this._liveResMouseY=e.clientY;
var _3f=_30;
if(_3d){
var _40=this._liveResPaneStartSize;
var _41=this._targetResizePane.getVarSize();
var _42=(_2c)?(this._liveResMouseX-this._mouseStartX):(this._liveResMouseY-this._mouseStartY);
if(_42>0){
_3f=this._maxIncreaseDelta-(_41-_40);
}else{
_3f=this._maxDecreaseDelta-(_40-_41);
_3f*=-1;
}
if(_3f==0){
return;
}
}
this._targetResizePane.resize(_3f,Telerik.Web.UI.SplitterDirection.Forward);
}
return false;
},_onMouseUp:function(e){
e.preventDefault();
e.stopPropagation();
$removeHandler(document,"mouseup",this._onMouseUpDelegate);
$removeHandler(document,"mousemove",this._onMouseMoveDelegate);
if(this._helperBar){
this._helperBar.parentNode.removeChild(this._helperBar);
this._helperBar=null;
}
if(!this.get_splitter().get_liveResize()&&this._currentDelta!=0){
this._targetResizePane.resize(this._currentDelta,Telerik.Web.UI.SplitterDirection.Forward);
}
return false;
},_onMouseOver:function(e){
if(!this._isInactive){
var _45=this.get_element();
_45.className=(this.get_splitter().isVertical())?"resizeBarOver":"resizeBarOverHorizontal";
}
},_onMouseOut:function(e){
if(!this._isInactive){
var _47=this.get_element();
_47.className=(this.get_splitter().isVertical())?"resizeBar":"resizeBarHorizontal";
}
},_setCursorStyle:function(){
var _48=this.get_element();
_48.style.cursor=this._getCursorStyle();
},_getCursorStyle:function(){
if(!this.get_enableResize()){
return "";
}
if(this.get_splitter().isVertical()){
return "w-resize";
}else{
return "n-resize";
}
},_getCollapseTarget:function(_49){
return (_49==Telerik.Web.UI.SplitterDirection.Forward)?this._prevPane:this._nextPane;
},_getAvailDecreaseDelta:function(){
var _4a=this.get_splitter()._getAvailAdjacentPane(this._prevPane._indexInPanes+1,Telerik.Web.UI.SplitterDirection.Backward);
if(_4a==null){
return 0;
}
var _4b=0;
_4b=_4a._getAvailDecreaseDelta();
if(_4b<=0){
return 0;
}
var _4c=this.get_splitter()._getAvailIncreaseDelta(_4a._indexInPanes,Telerik.Web.UI.SplitterDirection.Forward);
return Math.min(_4c,_4b);
},_getAvailIncreaseDelta:function(){
var _4d=this.get_splitter()._getAvailAdjacentPane(this._prevPane._indexInPanes+1,Telerik.Web.UI.SplitterDirection.Backward);
if(_4d==null){
return 0;
}
var _4e=0;
_4e=_4d._getAvailIncreaseDelta();
if(_4e<=0){
return 0;
}
var _4f=this.get_splitter()._getAvailDecreaseDelta(_4d._indexInPanes,Telerik.Web.UI.SplitterDirection.Forward);
return Math.min(_4f,_4e);
},_getCollapseBarHeight:function(_50){
if(this.getCollapseBarElement(_50)==null){
return 0;
}
return this.getCollapseBarElement(_50).offsetHeight;
},_getCollapseDivClass:function(_51){
var _52=(this.get_splitter().isVertical())?"collapseBarCollapse":"collapseBarHorizontalCollapse";
if(_51==Telerik.Web.UI.SplitterDirection.Backward){
_52=(this.get_splitter().isVertical())?"collapseBarExpand":"collapseBarHorizontalExpand";
}
return _52;
},_getExpandDivClass:function(_53){
var _54=(this.get_splitter().isVertical())?"collapseBarExpand":"collapseBarHorizontalExpand";
if(_53==Telerik.Web.UI.SplitterDirection.Backward){
_54=(this.get_splitter().isVertical())?"collapseBarCollapse":"collapseBarHorizontalCollapse";
}
return _54;
},_collapseTargetPane:function(_55){
var _56=this._getCollapseTarget(_55);
if(!_56){
return false;
}
if(_56.isLocked()){
this._showExpandCollapseError(_55);
return false;
}
var _57=this.getCollapseBarElement(_55);
var _58=this.get_element();
var _59=false;
if(this.isCollapsed(_55)||(_56._initialExpandMode)){
if(_56.get_collapsed()&&_56._expandedSize>0){
if(this.get_splitter()._expandPane(_56,_55)){
if(_57!=null){
_57.className=this._getCollapseDivClass(_55);
}
this._setActive();
this._collapsed[_55]=false;
_59=true;
}else{
this._showExpandCollapseError(_55);
}
}
}else{
if(!(_56.get_collapsed()&&_56._expandedSize>0)){
if(this.get_splitter()._collapsePane(_56,_55)){
if(_57!=null){
_57.className=this._getExpandDivClass(_55);
}
this._setInactive();
this._collapsed[_55]=true;
_59=true;
}else{
this._showExpandCollapseError(_55);
}
}
}
if(_59){
var _5a=(_55==Telerik.Web.UI.SplitterDirection.Forward)?Telerik.Web.UI.SplitterDirection.Backward:Telerik.Web.UI.SplitterDirection.Forward;
var _5b=this.getCollapseBarElement(_5a);
if(_5b!=null){
_5b.style.display=(_56.get_collapsed())?"none":"";
}
this._setHorizontalWrapperWidth();
}
return _59;
},_showExpandCollapseError:function(_5c){
var _5d=this.getCollapseBarElement(_5c);
if(_5d==null){
return;
}
var _5e=(this.get_splitter().isVertical())?((_5c==Telerik.Web.UI.SplitterDirection.Forward)?"collapseBarCollapse":"collapseBarExpand"):((_5c==Telerik.Web.UI.SplitterDirection.Forward)?"collapseBarHorizontalCollapse":"collapseBarHorizontalExpand");
var _5f=(this.get_splitter().isVertical())?((_5c==Telerik.Web.UI.SplitterDirection.Forward)?"collapseBarCollapseError":"collapseBarExpandError"):((_5c==Telerik.Web.UI.SplitterDirection.Forward)?"collapseBarHorizontalCollapseError":"collapseBarHorizontalExpandError");
setTimeout(function(){
setCollapseBarCss(_5f);
},0);
setTimeout(function(){
setCollapseBarCss(_5e);
},200);
setTimeout(function(){
setCollapseBarCss(_5f);
},400);
setTimeout(function(){
setCollapseBarCss(_5e);
},600);
setTimeout(function(){
setCollapseBarCss(_5f);
},800);
setTimeout(function(){
setCollapseBarCss(_5e);
},1000);
function setCollapseBarCss(_60){
_5d.className=_60;
}
},_splitterLoadedHandler:function(){
if(!this.get_splitter()._isVisible()){
return;
}
var _61=this.get_splitter()._getSplitBarsSize()/this.get_splitter().getSplitBars().length;
var _62=$get("RAD_SPLITBAR_SPACER_"+this.get_id());
if(this.get_splitter().isVertical()){
$telerik.setOuterWidth(this.get_element(),_61);
if(_62){
_62.style.width=_61+"px";
}
}else{
$telerik.setOuterHeight(this.get_element(),_61);
if(_62){
_62.style.height=_61+"px";
}
this._setHorizontalWrapperWidth();
}
this.get_splitter().remove_loaded(this._splitterLoadedHandler);
},_setHorizontalWrapperWidth:function(){
if(this.get_splitter().isVertical()){
return;
}
var _63=$get("RAD_SPLITTER_BAR_COLLAPSE_WRAPPER_"+this.get_id());
if(_63){
var _64=0;
var _65=this.getCollapseBarElement(Telerik.Web.UI.SplitterDirection.Forward);
if(_65!=null){
_64+=_65.offsetWidth;
}
_65=this.getCollapseBarElement(Telerik.Web.UI.SplitterDirection.Backward);
if(_65!=null){
_64+=_65.offsetWidth;
}
if(_64){
_63.style.width=_64+"px";
}
}
},_setActive:function(){
var _66=this.get_element();
this._setCursorStyle();
_66.className=(this.get_splitter().isVertical())?"resizeBar":"resizeBarHorizontal";
this._isInactive=false;
},_setInactive:function(){
var _67=this.get_element();
_67.style.cursor="";
var _68=(this.get_splitter().isVertical())?"resizeBarInactive":"resizeBarInactiveHorizontal";
_67.className=(this.get_splitter().isVertical())?"resizeBarInactive":"resizeBarInactiveHorizontal";
this._isInactive=true;
}};
Telerik.Web.UI.RadSplitBar.registerClass("Telerik.Web.UI.RadSplitBar",Telerik.Web.UI.SplitterItem);

