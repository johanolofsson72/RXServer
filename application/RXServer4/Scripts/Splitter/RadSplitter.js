Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.SplitterPaneScrolling=function(){
};
Telerik.Web.UI.SplitterPaneScrolling.prototype={Both:1,X:2,Y:3,None:4};
Telerik.Web.UI.SplitterPaneScrolling.registerEnum("Telerik.Web.UI.SplitterPaneScrolling",false);
Telerik.Web.UI.SplitterResizeMode=function(){
};
Telerik.Web.UI.SplitterResizeMode.prototype={AdjacentPane:1,Proportional:2,EndPane:3};
Telerik.Web.UI.SplitterResizeMode.registerEnum("Telerik.Web.UI.SplitterResizeMode",false);
Telerik.Web.UI.SplitterDirection=function(){
};
Telerik.Web.UI.SplitterDirection.prototype={Forward:1,Backward:2};
Telerik.Web.UI.SplitterDirection.registerEnum("Telerik.Web.UI.SplitterDirection",false);
Telerik.Web.UI.SplitterBeforeResizeEventArgs=function(_1,_2){
Telerik.Web.UI.SplitterBeforeResizeEventArgs.initializeBase(this);
this._newWidth=_1;
this._newHeight=_2;
};
Telerik.Web.UI.SplitterBeforeResizeEventArgs.prototype={get_newWidth:function(){
return this._newWidth;
},get_newHeight:function(){
return this._newHeight;
}};
Telerik.Web.UI.SplitterBeforeResizeEventArgs.registerClass("Telerik.Web.UI.SplitterBeforeResizeEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.SplitterResizedEventArgs=function(_3,_4){
Telerik.Web.UI.SplitterResizedEventArgs.initializeBase(this);
this._oldWidth=_3;
this._oldHeight=_4;
};
Telerik.Web.UI.SplitterResizedEventArgs.prototype={get_oldWidth:function(){
return this._oldWidth;
},get_oldHeight:function(){
return this._oldHeight;
}};
Telerik.Web.UI.SplitterResizedEventArgs.registerClass("Telerik.Web.UI.SplitterResizedEventArgs",Sys.EventArgs);
Telerik.Web.UI.RadSplitter=function(_5){
Telerik.Web.UI.RadSplitter.initializeBase(this,[_5]);
this._fullScreenMode=false;
this._visibleDuringInit=true;
this._liveResize=false;
this._resizeWithBrowserWindow=true;
this._resizeWithParentPane=true;
this._orientation=Telerik.Web.UI.Orientation.Vertical;
this._resizeMode=Telerik.Web.UI.SplitterResizeMode.AdjacentPane;
this._borderSize=1;
this._panesBorderSize=1;
this._splitBarSize=null;
this._width="400px";
this._height="400px";
this._heightOffset=0;
this._resizeHandlerAttached=false;
this._panes=[];
this._panesByIndex=[];
this._panesById=[];
this._splitBars=[];
this._splitBarsByAbsIndex=[];
this._splitBarsById=[];
this._splitBarsByIndex=[];
this._sizeHelper=null;
this._initialSizeApplied=false;
this._splitBarsSizeCalculated=false;
this._containerElement=$get("RAD_SPLITTER_"+this.get_id());
var _6=$telerik.getViewPortSize();
this._initialWindowWidth=_6.width;
this._initialWindowHeight=_6.height;
this._cancelInterval=0;
this._lastResizedValue=0;
this._resizedValue=0;
this.IsNested=this.isNested;
this.GetMinWidth=this.getMinWidth;
this.GetMaxWidth=this.getMaxWidth;
this.GetMinHeight=this.getMinHeight;
this.GetMaxHeight=this.getMaxHeight;
this.GetInnerWidth=this.getInnerWidth;
this.GetInnerHeight=this.getInnerHeight;
this.GetPanes=this.getPanes;
this.Resize=this.resize;
this.GetEndPane=this.getEndPane;
this.GetStartPane=this.getStartPane;
this.IsVertical=this.isVertical;
this.GetPaneByIndex=this.getPaneByIndex;
this.GetPaneById=this.getPaneById;
this.GetSplitBarByIndex=this.getSplitBarByIndex;
this.GetSplitBarById=this.getSplitBarById;
this.GetSplitBars=this.getSplitBars;
this.GetContainerElement=this.getContainerElement;
};
Telerik.Web.UI.RadSplitter.prototype={endUpdate:function(){
if(this._width.toString().indexOf("px")>-1){
this._width=parseInt(this._width,10);
}
if(this._height.toString().indexOf("px")>-1){
this._height=parseInt(this._height,10);
}
Telerik.Web.UI.RadSplitter.callBaseMethod(this,"endUpdate");
},initialize:function(){
Telerik.Web.UI.RadSplitter.callBaseMethod(this,"initialize");
this._originalWidth=this._width;
this._originalHeight=this._height;
var _7=this.isNested();
if(_7&&this._resizeWithParentPane){
this._parent._childSplitter=this;
}
if(this._fullScreenMode){
try{
document.body.style.height="100%";
document.forms[0].style.height="100%";
document.documentElement.style.height="100%";
document.body.style.margin="0px";
}
catch(e){
}
}
this._borderSize=(_7)?0:this._borderSize;
if($telerik.isFirefox){
var _8=Math.ceil(this._borderSize/2);
var _9=this._containerElement;
_9.style.marginTop=_8+"px";
_9.style.marginLeft=_8+"px";
_8=Math.floor(this._borderSize/2);
_9.style.marginBottom=_8+"px";
_9.style.marginRight=_8+"px";
}
this._appLoadHandler=Function.createDelegate(this,this._appLoadHandler);
Sys.Application.add_load(this._appLoadHandler);
},dispose:function(){
if(this._resizeHandlerAttached){
}
if(this._sizeHelper){
this._sizeHelper.parentNode.removeChild(this._sizeHelper);
this._sizeHelper=null;
}
Telerik.Web.UI.RadSplitter.callBaseMethod(this,"dispose");
},set_resizeMode:function(_a){
this._resizeMode=_a;
},get_resizeMode:function(){
return this._resizeMode;
},set_liveResize:function(_b){
this._liveResize=_b;
},get_liveResize:function(){
return this._liveResize;
},set_heightOffset:function(_c){
this._heightOffset=_c;
},get_heightOffset:function(){
return this._heightOffset;
},set_width:function(_d){
if(_d.toString().indexOf("px")>-1){
_d=parseInt(_d,10);
}else{
if(_d.toString().indexOf("%")>-1){
_d=this._calculatePercentWidth(_d);
}
}
if(_d==this._width||isNaN(_d)){
return;
}
this.resize(_d,null);
},get_width:function(){
return this._width;
},set_height:function(_e){
if(_e.toString().indexOf("px")>-1){
_e=parseInt(_e,10);
}else{
if(_e.toString().indexOf("%")>-1){
_e=this._calculatePercentHeight(_e);
}
}
if(_e==this._height||isNaN(_e)){
return;
}
this.resize(null,_e);
},get_height:function(){
return this._height;
},get_parent:function(){
return this._parent;
},add_loaded:function(_f){
this.get_events().addHandler("loaded",_f);
},remove_loaded:function(_10){
this.get_events().removeHandler("loaded",_10);
},add_beforeResize:function(_11){
this.get_events().addHandler("beforeResize",_11);
},remove_beforeResize:function(_12){
this.get_events().removeHandler("beforeResize",_12);
},add_resized:function(_13){
this.get_events().addHandler("resized",_13);
},remove_resized:function(_14){
this.get_events().removeHandler("resized",_14);
},getMinWidth:function(_15,_16){
var _17=this._getMinMaxSize(_15,_16,true,true);
return _17;
},getMaxWidth:function(_18,_19){
var _1a=this._getMinMaxSize(_18,_19,false,true);
return _1a;
},getMinHeight:function(_1b,_1c){
var _1d=this._getMinMaxSize(_1b,_1c,true,false);
return _1d;
},getMaxHeight:function(_1e,_1f){
var _20=this._getMinMaxSize(_1e,_1f,false,false);
return _20;
},isNested:function(){
return (this._parent!=null);
},getInnerWidth:function(){
return this._width-this._getBordersDiff();
},getInnerHeight:function(){
return this._height-this._getBordersDiff();
},getPanes:function(){
return this._panes;
},resize:function(_21,_22,_23){
if(!this._initialSizeApplied){
this._calculateInitialSize();
}
if(!_23){
var _24=new Telerik.Web.UI.SplitterBeforeResizeEventArgs(_21,_22);
this.raiseEvent("beforeResize",_24);
if(_24.get_cancel()){
return false;
}
}
var _25=false;
var _26=false;
var _27=0;
var _28=this._width;
var _29=this._height;
var _2a=this.isVertical();
if(_21!=null&&_21!=_28){
var _2b=_21-_28;
this._setOuterWidth(_21);
this._width=_21;
if(_2a){
_27=_2b;
_25=true;
}else{
_26=true;
}
}
if(_22!=null&&_22!=_29){
var _2c=_22-_29;
this._setOuterHeight(_22);
this._height=_22;
if(!_2a){
_27=_2c;
_25=true;
}else{
_26=true;
}
}
if(_26){
var _2d=(_2a)?this.getInnerHeight():this.getInnerWidth();
for(var i=0,_2f=this._panes.length;i<_2f;i++){
var _30=this._panes[i];
if(_30._collapsed&&_30._expandedSize>0){
continue;
}
var _31=_30._width;
var _32=_30._height;
if(_2a){
_30.set_height(_2d);
}else{
_30.set_width(_2d);
}
$telerik.repaintChildren(_30);
_30.raiseEvent("resized",new Telerik.Web.UI.PaneResizedEventArgs(_31,_32));
}
}
if(_25){
if(this._containsInitialFreeSizedPanes()){
var _33=this._getInitialFreeSizedPanes();
var _34=_33.length;
var _35=parseInt(_27/_34,10);
var _36=0;
for(var i=0;i<_34;i++){
var _30=_33[i];
var _37=(_35>0)?_30._getAvailIncreaseDelta():_30._getAvailDecreaseDelta();
var _38=_35;
if(_37<Math.abs(_35)){
_38=_37*((_35>0)?1:-1);
_36+=_35-_38;
}
var _39=_30.getVarSize()+_38;
var _32=_30._height;
var _31=_30._width;
_30.setVarSize(_39);
if(this._initializedInternal&&!_23){
$telerik.repaintChildren(_30);
_30.raiseEvent("resized",new Telerik.Web.UI.PaneResizedEventArgs(_31,_32));
}
}
this._fixPanesRounding(_33);
if(_36!=0){
_36*=-1;
this._resizeProportional(_36,null,Telerik.Web.UI.SplitterDirection.Forward);
}
}else{
_27*=-1;
this._resizeProportional(_27,null,Telerik.Web.UI.SplitterDirection.Forward);
}
}
if(!_23){
this.raiseEvent("resized",new Telerik.Web.UI.SplitterResizedEventArgs(_28,_29));
}
return true;
},getEndPane:function(){
return this._panesByIndex[this._panes.length-1];
},getStartPane:function(){
return this._panesByIndex[0];
},isVertical:function(){
return (this._orientation==Telerik.Web.UI.Orientation.Vertical);
},getPaneByIndex:function(_3a){
return this._panesByIndex[_3a];
},getPaneById:function(_3b){
return this._panesById[_3b];
},getSplitBarByIndex:function(_3c){
return this._splitBarsByIndex[_3c];
},getSplitBarById:function(_3d){
return this._splitBarsById[_3d];
},getSplitBars:function(){
return this._splitBars;
},getContainerElement:function(){
return this._containerElement;
},_getSplitBarByAbsIndex:function(_3e){
return this._splitBarsByAbsIndex[_3e];
},_resizeAdjacentPane:function(_3f,_40,_41){
if(_3f==0){
return;
}
var _42=this._getAvailAdjacentPane(_40._indexInPanes,_41);
if(_42==null){
return false;
}
if(!this._isCollapseMode&&!this._isExpandMode){
var _43=new Telerik.Web.UI.PaneBeforeResizeEventArgs(_3f,_41);
_40.raiseEvent("beforeResize",_43);
if(_43.get_cancel()){
return false;
}
var _44=new Telerik.Web.UI.PaneBeforeResizeEventArgs(_3f*-1,_41);
_42.raiseEvent("beforeResize",_44);
if(_44.get_cancel()){
return false;
}
}
var _45=_40._width;
var _46=_40._height;
var _47=_42._width;
var _48=_42._height;
var _49=_40.getVarSize()+_3f;
var _4a=_42.getVarSize()-_3f;
_40.setVarSize(_49);
_42.setVarSize(_4a);
if(!this._isCollapseMode&&!this._isExpandMode){
$telerik.repaintChildren(_40);
_40.raiseEvent("resized",new Telerik.Web.UI.PaneResizedEventArgs(_45,_46));
}
$telerik.repaintChildren(_42);
_42.raiseEvent("resized",new Telerik.Web.UI.PaneResizedEventArgs(_47,_48));
return true;
},_resizeEndPane:function(_4b,_4c,_4d){
if(_4b==0){
return;
}
var _4e=(_4d==Telerik.Web.UI.SplitterDirection.Forward)?this.getEndPane():this.getStartPane();
if(!this._isCollapseMode&&!this._isExpandMode){
var _4f=new Telerik.Web.UI.PaneBeforeResizeEventArgs(_4b,_4d);
_4c.raiseEvent("beforeResize",_4f);
if(_4f.get_cancel()){
return false;
}
var _50=new Telerik.Web.UI.PaneBeforeResizeEventArgs(_4b*-1,_4d);
_4e.raiseEvent("beforeResize",_50);
if(_50.get_cancel()){
return false;
}
}
var _51=_4c._width;
var _52=_4c._height;
var _53=_4e._width;
var _54=_4e._height;
var _55=_4c.getVarSize()+_4b;
_4c.setVarSize(_55);
var _56=_4e.getVarSize()-_4b;
_4e.setVarSize(_56);
if(!this._isCollapseMode&&!this._isExpandMode){
$telerik.repaintChildren(_4c);
_4c.raiseEvent("resized",new Telerik.Web.UI.PaneResizedEventArgs(_51,_52));
}
$telerik.repaintChildren(_4e);
_4e.raiseEvent("resized",new Telerik.Web.UI.PaneResizedEventArgs(_53,_54));
return true;
},_resizeProportional:function(_57,_58,_59){
if(_57==0){
return;
}
var _5a=(this._isCollapseMode||this._isExpandMode)?false:true;
if(_5a&&_58!=null){
var _5b=new Telerik.Web.UI.PaneBeforeResizeEventArgs(_57,_59);
_58.raiseEvent("beforeResize",_5b);
if(_5b.get_cancel()){
return;
}
}
var _5c=Math.abs(_57);
var _5d=0;
var _5e=(_57>0);
var _5f=(_58!=null)?((_59==Telerik.Web.UI.SplitterDirection.Forward)?_58._indexInPanes+1:_58._indexInPanes-1):0;
var _60=[];
var _61=this._panesByIndex;
if(_59==Telerik.Web.UI.SplitterDirection.Forward){
for(var i=_5f,_63=this._panes.length;i<_63;i++){
var _64=_61[i];
_60[_60.length]=_64;
_5d+=_64.getVarSize();
}
}else{
for(var i=_5f;i>=0;i--){
var _64=_61[i];
_60[_60.length]=_64;
_5d+=_64.getVarSize();
}
}
if(_60.length<2&&_58!=null){
this._resizeAdjacentPane(_57,_58,_59);
return;
}
var _65=[];
do{
var _66=_5d;
var _67=0;
for(var i=0,_63=_60.length;i<_63;i++){
if(_65[i]){
continue;
}
var _68=_60[i];
if((_68._collapsed&&_68._expandedSize>0)||_68._locked){
_65[i]=true;
continue;
}
var _69=_68.getVarSize();
var _6a=(_5e)?_68._getAvailDecreaseDelta():_68._getAvailIncreaseDelta();
var _6b=_69/_66;
var _6c=_5c*_6b;
if((_6c-_6a)>0){
_65[i]=true;
}
var _6d=Math.min(_6c,_6a);
if(_5e){
_6d*=-1;
}
var _6e=_69+_6d;
if(_5a){
var _6f=new Telerik.Web.UI.PaneBeforeResizeEventArgs(parseInt(_6e),_59);
_68.raiseEvent("beforeResize",_6f);
if(_6f.get_cancel()){
return false;
}
}
_67+=_6c-Math.abs(_6d);
var _70=_68._width;
var _71=_68._height;
_68.setVarSize(_6e);
$telerik.repaintChildren(_68);
_68.raiseEvent("resized",new Telerik.Web.UI.PaneResizedEventArgs(_70,_71));
_5d+=(_65[i])?(-1)*_68.getVarSize()+_6d:_6d;
}
_5c=_67;
}while(_67!=0);
if(_58!=null){
var _72=_58._width;
var _73=_58._height;
_58.setVarSize(_58.getVarSize()+_57);
if(_5a){
$telerik.repaintChildren(_58);
_58.raiseEvent("resized",new Telerik.Web.UI.PaneResizedEventArgs(_72,_73));
}
}
this._fixPanesRounding(_60);
},_fixPanesRounding:function(_74){
var _75=this._panes;
if(!_74){
_74=_75;
}
var _76=(this.isVertical())?this._getPanesAvailWidth():this._getPanesAvailHeight();
var _77=0;
for(var i=0,_79=_75.length;i<_79;i++){
var _7a=_75[i].getVarSize();
_77+=_7a;
}
var _7b=_76-_77;
if(_7b!=0){
for(var i=0,_7c=_74.length;i<_7c;i++){
var _7d=_74[i];
if((_7d._collapsed&&_7d._expandedSize>0)||_7d._locked){
continue;
}
var _7e=new Telerik.Web.UI.PaneBeforeResizeEventArgs(_7b,Telerik.Web.UI.SplitterDirection.Forward);
_7d.raiseEvent("beforeResize",_7e);
if(_7e.get_cancel()){
continue;
}
var _7f=_7d._width;
var _80=_7d._height;
var _81=false;
if(_7b>0){
if(_7d._getAvailIncreaseDelta()>0){
_81=true;
}
}else{
if(_7d._getAvailDecreaseDelta()>0){
_81=true;
}
}
if(_81){
_7d.setVarSize(_7d.getVarSize()+_7b);
$telerik.repaintChildren(_7d);
_7d.raiseEvent("resized",new Telerik.Web.UI.PaneResizedEventArgs(_7f,_80));
break;
}
}
}
},_addPane:function(_82){
this._panes[this._panes.length]=_82;
this._panesByIndex[_82._indexInPanes]=_82;
this._panesById[_82.get_id()]=_82;
},_addSplitBar:function(_83){
this._splitBars[this._splitBars.length]=_83;
this._splitBarsByIndex[_83._indexInSplitBars]=_83;
this._splitBarsById[_83.get_id()]=_83;
this._splitBarsByAbsIndex[_83.get_index()]=_83;
},_setOuterWidth:function(_84){
if(this._width!=_84){
if(this._arePanesFixedSize()){
var _85=this.get_element();
if(_84<=0||_84==""){
_85.style.width="";
}else{
_85.style.width=_84+"px";
}
}
this._width=_84;
}
},_setOuterHeight:function(_86){
if(this._height!=_86){
if(this._arePanesFixedSize()){
var _87=this.get_element();
if(_86<=0||_86==""){
_87.style.height="";
}else{
_87.style.height=_86+"px";
}
}
this._height=_86;
}
},_arePanesFixedSize:function(){
var _88=this._panes;
for(var i=0,_8a=_88.length;i<_8a;i++){
if(!_88[i]._isInitialFixedSize()){
return false;
}
}
return true;
},_containsFreeSizedPanes:function(){
var _8b=this._panes;
for(var i=0,_8d=_8b.length;i<_8d;i++){
if(_8b[i]._isFreeSize()){
return true;
}
}
return false;
},_containsInitialFreeSizedPanes:function(){
var _8e=this._panes;
for(var i=0,_90=_8e.length;i<_90;i++){
if(_8e[i]._isInitialFreeSize()){
return true;
}
}
return false;
},_containsInitialPercentSizedPanes:function(){
var _91=this._panes;
for(var i=0,_93=_91.length;i<_93;i++){
if(_91[i]._isInitialPercentSize()){
return true;
}
}
return false;
},_windowResizeHandler:function(){
if($telerik.isFirefox){
this._handlePageResize();
}else{
this._resizedValue++;
if(!this._cancelInterval){
var _94=this;
this._cancelInterval=window.setInterval(function(){
try{
if(_94._resizedValue>_94._lastResizedValue){
_94._lastResizedValue=_94._resizedValue+1;
return;
}
window.clearInterval(_94._cancelInterval);
_94._cancelInterval=0;
_94._handlePageResize();
}
catch(ex){
}
},200);
}
}
},_handlePageResize:function(_95){
if(!this._isVisible()){
return;
}
if(!this._initialSizeApplied){
this._calculateInitialSize();
}
var _96=$telerik.getViewPortSize();
var _97=_96.width;
var _98=_96.height;
if(!_95&&this._initialWindowHeight==_98&&this._initialWindowWidth==_97){
return;
}
this._initialWindowHeight=_98;
this._initialWindowWidth=_97;
var _99=null;
var _9a=null;
if(this._originalWidth.toString().indexOf("%")>-1){
_9a=this._calculatePercentSize();
var _9b=_9a.width;
if(_9b!=this._width){
_99=_9b;
}
}
var _9c=null;
if(this._originalHeight.toString().indexOf("%")>-1){
if(!_9a){
_9a=this._calculatePercentSize();
}
var _9d=_9a.height;
if(_9d!=this._height){
_9c=_9d;
}
}
this.resize(_99,_9c);
},_setSize:function(){
var _9e=this.isVertical();
if(this._arePanesFixedSize()&&!this._containsInitialFreeSizedPanes()){
var _9f=this._getPanesVarSize();
var _a0=this._getSplitBarsSize();
var _a1=this._getBordersSize();
var _a2=_9f+_a0+_a1;
if(_9e){
this._changeOriginalWidth(_a2);
this._setOuterWidth(_a2);
}else{
this._changeOriginalHeight(_a2);
this._setOuterHeight(_a2);
}
}
var _a3=this._panes;
var _a4=null;
if(this._originalWidth.toString().indexOf("%")>-1){
_a4=this._calculatePercentSize();
var _a5=_a4.width;
this._setOuterWidth(_a5);
if(!_9e){
var _a6=this.getInnerWidth();
for(var i=0,_a8=_a3.length;i<_a8;i++){
_a3[i].set_width(_a6);
}
}
}
if(this._originalHeight.toString().indexOf("%")>-1){
if(!_a4){
_a4=this._calculatePercentSize();
}
var _a9=_a4.height;
this._setOuterHeight(_a9);
if(_9e){
var _aa=this.getInnerHeight();
for(var i=0,_a8=_a3.length;i<_a8;i++){
_a3[i].set_height(_aa);
}
}
}
},_fixSplitterActualSize:function(){
if(this._originalHeight.toString().indexOf("%")==-1){
return;
}
var _ab=this.getContainerElement();
if(parseInt(_ab.style.height)==this._height){
return;
}
this._setOuterHeight(this._height);
},_calculatePercentWidth:function(_ac){
return this._calculatePercentSize(_ac,null).width;
},_calculatePercentHeight:function(_ad){
return this._calculatePercentSize(null,_ad).height;
},_calculatePercentSize:function(_ae,_af){
if(!_ae){
_ae=this._originalWidth;
}
if(!_af){
_af=this._originalHeight;
}
if(!this._sizeHelper&&$telerik.isIE6){
this._createSizeHelper();
}
var _b0=this.get_element();
var _b1=($telerik.isIE6)?this._sizeHelper:_b0;
if(_b1.style.width!=_ae){
_b1.style.width=_ae;
}
if(_b1.style.height!=_af){
_b1.style.height=_af;
}
var _b2=2*this._borderSize;
var _b3=this._containerElement;
_b0.style.position="relative";
_b3.style.position="absolute";
_b3.style.top="0px";
_b3.style.left="0px";
var _b4=_b1.offsetHeight-this._heightOffset;
var _b5=_b1.offsetWidth;
_b0.style.position="";
_b3.style.position="";
_b3.style.top="";
_b3.style.left="";
if($telerik.isOpera||this._heightOffset>0){
_b1.style.width="";
_b1.style.height="";
}
return {width:_b5,height:_b4};
},_setPanesSize:function(){
var _b6=this._panes;
var _b7=this.isVertical();
var _b8=this._getPanesAvailWidth();
var _b9=this._getPanesAvailHeight();
for(var i=0,_bb=_b6.length;i<_bb;i++){
var _bc=_b6[i];
if(_bc._isPercentSize()){
var _bd=_b7?_b8:_b9;
var _be=_b7?_bc._originalWidth:_bc._originalHeight;
var _bf=parseInt(_be)*_bd/100;
_bf=parseInt(_bf);
_bc.setVarSize(_bf);
$telerik.repaintChildren(_bc);
}
}
if(this._containsFreeSizedPanes()){
var _c0=(_b7)?this._width:this._height;
var _c1=this._getBordersSize();
var _c2=(_b7)?_b8:_b9;
var _c3=0;
for(var i=0,_bb=_b6.length;i<_bb;i++){
var _bc=_b6[i];
if(_bc._isFixedSize()){
_c2-=_bc.getVarSize();
$telerik.repaintChildren(_bc);
}else{
if(_bc._locked||(_bc._collapsed&&_bc._expandedSize>0)){
continue;
}
_c3++;
}
}
var _c4=_c2/_c3;
_c4=parseInt(_c4);
var _c5=this._getFreeSizedPanes();
for(var i=0,_bb=_c5.length;i<_bb;i++){
var _c6=_c5[i];
if(_c6._locked||(_c6._collapsed&&_c6._expandedSize>0)){
continue;
}
_c6.setVarSize(_c4);
$telerik.repaintChildren(_c6);
}
}
},_getFreeSizedPanes:function(){
var _c7=this._panes;
var _c8=[];
for(var i=0,_ca=_c7.length;i<_ca;i++){
var _cb=_c7[i];
if(_cb._isFreeSize()){
_c8[_c8.length]=_cb;
}
}
return _c8;
},_getInitialFreeSizedPanes:function(){
var _cc=this._panes;
var _cd=[];
for(var i=0,_cf=_cc.length;i<_cf;i++){
var _d0=_cc[i];
if(_d0._isInitialFreeSize()){
_cd[_cd.length]=_d0;
}
}
return _cd;
},_getPanesVarSize:function(){
var _d1=this._panes;
var _d2=0;
for(var i=0,_d4=_d1.length;i<_d4;i++){
_d2+=_d1[i].getVarSize();
}
return _d2;
},_getPanesAvailWidth:function(){
var _d5=this._width-this._getBordersSize();
if(this.isVertical()){
_d5-=this._getSplitBarsSize();
}else{
_d5-=2*this._borderSize;
}
return _d5;
},_getPanesAvailHeight:function(){
var _d6=this._height-this._getBordersSize();
if(!this.isVertical()){
_d6-=this._getSplitBarsSize();
}else{
_d6-=2*this._borderSize;
}
return _d6;
},_getPanesBordersSize:function(){
var _d7=this._panes;
var _d8=0;
for(var i=0,_da=_d7.length;i<_da;i++){
var _db=_d7[i];
if(!(_db._collapsed&&_db._expandedSize>0)){
_d8++;
}
}
return (_d8-1)*this._panesBorderSize;
},_getBordersSize:function(){
var _dc=this._panes;
var _dd=0;
for(var i=0,_df=_dc.length;i<_df;i++){
var _e0=_dc[i];
if(!(_e0._collapsed&&_e0._expandedSize>0)){
_dd++;
}
}
return (Math.max(_dd+this._splitBars.length-1,0))*this._panesBorderSize+this._getBordersDiff();
},_getBordersDiff:function(){
var _e1=0;
_e1+=2*this._borderSize;
return _e1;
},_getSplitBarsSize:function(){
var _e2=0;
if(this._splitBarsSizeCalculated){
return this._splitBarsSize;
}
if(this._splitBars.length>0){
var _e3=0;
if(this._splitBarSize!=null){
_e3=parseInt(this._splitBarSize);
}else{
var _e4=this._splitBarsByIndex[0];
var _e5=$get("RAD_SPLITTER_BAR_COLLAPSE_WRAPPER_"+_e4.get_id());
if(_e5==null){
_e5=$get("RAD_SPLITBAR_SPACER_"+_e4.get_id());
}
if(_e5){
_e3=(this.isVertical())?_e5.offsetWidth:_e5.offsetHeight;
}
_e3=Math.max(_e3,0);
}
_e2=this._splitBars.length*_e3;
}
this._splitBarsSizeCalculated=true;
this._splitBarsSize=_e2;
return _e2;
},_getAvailIncreaseDelta:function(_e6,_e7){
var _e8=0;
switch(this._resizeMode){
case Telerik.Web.UI.SplitterResizeMode.EndPane:
var _e9=(_e7==Telerik.Web.UI.SplitterDirection.Forward)?this.getEndPane():this.getStartPane();
_e8=_e9._getAvailIncreaseDelta();
break;
case Telerik.Web.UI.SplitterResizeMode.Proportional:
var _ea=this._panesByIndex;
var _eb=[];
if(_e7==Telerik.Web.UI.SplitterDirection.Forward){
for(var i=_e6+1,_ed=this._panes.length;i<_ed;i++){
_eb[_eb.length]=_ea[i];
}
}else{
for(var i=_e6-1;i>=0;i--){
_eb[_eb.length]=_ea[i];
}
}
for(var i=0,_ed=_eb.length;i<_ed;i++){
_e8+=_eb[i]._getAvailIncreaseDelta();
}
break;
case Telerik.Web.UI.SplitterResizeMode.AdjacentPane:
default:
var _ee=this._getAvailAdjacentPane(_e6,_e7);
if(_ee==null){
return 0;
}
_e8+=_ee._getAvailIncreaseDelta();
}
_e8=Math.max(_e8,0);
return _e8;
},_getAvailAdjacentPane:function(_ef,_f0){
if((this._panes.length-1)==_ef){
_f0=Telerik.Web.UI.SplitterDirection.Backward;
}else{
if(_ef==0){
_f0=Telerik.Web.UI.SplitterDirection.Forward;
}
}
var _f1=(_f0==Telerik.Web.UI.SplitterDirection.Forward)?1:-1;
var _f2=_ef+_f1;
var _f3=null;
var _f4=this._panesByIndex;
do{
_f3=_f4[_f2];
if(_f3==null){
return null;
}
_f2+=_f1;
}while((_f3._collapsed&&_f3._expandedSize>0)||_f3._locked);
return _f3;
},_getAvailDecreaseDelta:function(_f5,_f6){
var _f7=0;
switch(this._resizeMode){
case Telerik.Web.UI.SplitterResizeMode.EndPane:
var _f8=(_f6==Telerik.Web.UI.SplitterDirection.Forward)?this.getEndPane():this.getStartPane();
_f7=_f8._getAvailDecreaseDelta();
break;
case Telerik.Web.UI.SplitterResizeMode.Proportional:
var _f9=[];
var _fa=this._panesByIndex;
if(_f6==Telerik.Web.UI.SplitterDirection.Forward){
for(var i=_f5+1,_fc=this._panes.length;i<_fc;i++){
_f9[_f9.length]=_fa[i];
}
}else{
for(var i=_f5-1;i>=0;i--){
_f9[_f9.length]=_fa[i];
}
}
for(var i=0,_fd=_f9.length;i<_fd;i++){
_f7+=_f9[i]._getAvailDecreaseDelta();
}
break;
case Telerik.Web.UI.SplitterResizeMode.AdjacentPane:
default:
var _fe=this._getAvailAdjacentPane(_f5,_f6);
if(_fe==null){
return 0;
}
_f7=_fe._getAvailDecreaseDelta();
}
_f7=Math.max(_f7,0);
return _f7;
},_collapsePane:function(_ff,_100){
if(!_ff._initialCollapseMode){
var _101=new Telerik.Web.UI.PaneBeforeCollapseEventArgs();
_ff.raiseEvent("beforeCollapse",_101);
if(_101.get_cancel()){
return false;
}
}
this._isCollapseMode=true;
if(typeof (_100)=="undefined"){
_100=Telerik.Web.UI.SplitterDirection.Forward;
}
var _102=_ff.getVarSize();
if(_102>0){
_102+=this._panesBorderSize;
}
var _103=this._getAvailIncreaseDelta(_ff._indexInPanes,_100);
if(_103<_102){
this._isCollapseMode=false;
return false;
}
_102*=-1;
_ff._collapse(_100);
_ff.resize(_102,_100);
if(!_ff._initialCollapseMode){
_ff.raiseEvent("collapsed",new Telerik.Web.UI.PaneCollapsedEventArgs());
}
this._isCollapseMode=false;
return true;
},_expandPane:function(_104,_105){
if(!_104._initialExpandMode){
var _106=new Telerik.Web.UI.PaneBeforeExpandEventArgs();
_104.raiseEvent("beforeExpand",_106);
if(_106.get_cancel()){
return false;
}
}
this._isExpandMode=true;
if(typeof (_105)=="undefined"){
_105=Telerik.Web.UI.SplitterDirection.Forward;
}
var _107=_104._expandedSize;
_107+=this._panesBorderSize;
var _108=this._getAvailDecreaseDelta(_104._indexInPanes,_105);
if(_108<=0){
this._isExpandMode=false;
return false;
}
var _109=_104.getVarMinSize();
if(_109>_108){
this._isExpandMode=false;
return false;
}
var _10a=Math.min(_108,_107);
_104._show();
_104.resize(_10a,_105);
_10a-=this._panesBorderSize;
_104._expand(_10a);
if(!_104._initialExpandMode){
_104.raiseEvent("expanded",new Telerik.Web.UI.PaneExpandedEventArgs());
}
this._isExpandMode=false;
return true;
},_resizePanes:function(_10b,_10c,_10d){
if(typeof (_10d)=="undefined"){
_10d=Telerik.Web.UI.SplitterDirection.Forward;
}
switch(this._resizeMode){
case Telerik.Web.UI.SplitterResizeMode.EndPane:
this._resizeEndPane(_10b,_10c,_10d);
break;
case Telerik.Web.UI.SplitterResizeMode.Proportional:
this._resizeProportional(_10b,_10c,_10d);
break;
case Telerik.Web.UI.SplitterResizeMode.AdjacentPane:
default:
this._resizeAdjacentPane(_10b,_10c,_10d);
}
},_changeOriginalWidth:function(_10e){
this._originalWidth=_10e;
},_changeOriginalHeight:function(_10f){
this._originalHeight=_10f;
},_getMinMaxSize:function(_110,_111,_112,_113){
var _114=this._panes.length;
if(!_110){
_110=0;
}
if(!_111){
_111=_114;
}
_110=Math.max(0,_110);
_111=Math.min(_111,_114);
var _115=(_113)?"get_width":"get_height";
var _116=(_112)?"get_min":"get_max";
_116+=(_113)?"Width":"Height";
var _117=this._getSplitBarsSize()+this._getBordersSize();
for(var i=_110;i<_111;i++){
var _119=this.getPaneByIndex(i);
_117+=(_119._locked)?_119[_115]():_119[_116]();
}
return _117;
},_isVisible:function(){
return (this.getContainerElement().offsetWidth!=0);
},_createSizeHelper:function(){
if(!this._sizeHelper){
var _11a=this.get_element();
var _11b=document.createElement("DIV");
_11b.style.position="absolute";
_11b.style.top="-9999px";
_11b.style.left="-9999px";
_11b.style.width=_11a.style.width;
_11b.style.height=_11a.style.height;
_11a.parentNode.insertBefore(_11b,_11a);
this._sizeHelper=_11b;
}
},_appLoadHandler:function(){
var _11c=this.get_element();
var _11d=false;
var _11e=(this._originalWidth.toString().indexOf("%")>-1||this._originalHeight.toString().indexOf("%")>-1);
if(_11e&&(this._containsInitialFreeSizedPanes()||this._containsInitialPercentSizedPanes())){
_11d=true;
}
var _11f=this.isNested();
if((_11e||_11f)&&$telerik.isIE6){
this._createSizeHelper();
}
if(_11d&&this._resizeWithBrowserWindow&&!_11f){
$addHandlers(window,{"resize":this._windowResizeHandler},this);
this._resizeHandlerAttached=true;
}
if(this._isVisible()){
this._calculateInitialSize();
}
this._initializedInternal=true;
Sys.Application.remove_load(this._appLoadHandler);
this.raiseEvent("loaded");
},repaint:function(){
var self=this;
var t=function(){
if(!self._isVisible()||!self._initializedInternal||self.isNested()){
return;
}
self._handlePageResize(true);
};
window.setTimeout(t,10);
},_calculateInitialSize:function(){
if(this._initialSizeApplied){
return;
}
if(!this._isVisible()){
return;
}
this._setSize();
this._setPanesSize();
this._fixSplitterActualSize();
if(!this._visibleDuringInit){
var _122=this.getContainerElement();
_122.style.visibility="visible";
Sys.UI.DomElement.removeCssClass(_122,"HideBordersWhileLoading");
}
this._initialSizeApplied=true;
}};
Telerik.Web.UI.RadSplitter.registerClass("Telerik.Web.UI.RadSplitter",Telerik.Web.UI.RadWebControl);

