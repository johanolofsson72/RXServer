Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.PaneBeforeResizeEventArgs=function(_1,_2){
Telerik.Web.UI.PaneBeforeResizeEventArgs.initializeBase(this);
this._delta=_1;
this._resizeDirection=_2;
};
Telerik.Web.UI.PaneBeforeResizeEventArgs.prototype={get_delta:function(){
return this._delta;
},get_resizeDirection:function(){
return this._resizeDirection;
}};
Telerik.Web.UI.PaneBeforeResizeEventArgs.registerClass("Telerik.Web.UI.PaneBeforeResizeEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.PaneResizedEventArgs=function(_3,_4){
Telerik.Web.UI.PaneResizedEventArgs.initializeBase(this);
this._oldWidth=_3;
this._oldHeight=_4;
};
Telerik.Web.UI.PaneResizedEventArgs.prototype={get_oldWidth:function(){
return this._oldWidth;
},get_oldHeight:function(){
return this._oldHeight;
}};
Telerik.Web.UI.PaneResizedEventArgs.registerClass("Telerik.Web.UI.PaneResizedEventArgs",Sys.EventArgs);
Telerik.Web.UI.PaneBeforeCollapseEventArgs=function(){
Telerik.Web.UI.PaneBeforeCollapseEventArgs.initializeBase(this);
};
Telerik.Web.UI.PaneBeforeCollapseEventArgs.prototype={};
Telerik.Web.UI.PaneBeforeCollapseEventArgs.registerClass("Telerik.Web.UI.PaneBeforeCollapseEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.PaneCollapsedEventArgs=function(){
Telerik.Web.UI.PaneCollapsedEventArgs.initializeBase(this);
};
Telerik.Web.UI.PaneCollapsedEventArgs.prototype={};
Telerik.Web.UI.PaneCollapsedEventArgs.registerClass("Telerik.Web.UI.PaneCollapsedEventArgs",Sys.EventArgs);
Telerik.Web.UI.PaneBeforeExpandEventArgs=function(){
Telerik.Web.UI.PaneBeforeExpandEventArgs.initializeBase(this);
};
Telerik.Web.UI.PaneBeforeExpandEventArgs.prototype={};
Telerik.Web.UI.PaneBeforeExpandEventArgs.registerClass("Telerik.Web.UI.PaneBeforeExpandEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.PaneExpandedEventArgs=function(){
Telerik.Web.UI.PaneExpandedEventArgs.initializeBase(this);
};
Telerik.Web.UI.PaneExpandedEventArgs.prototype={};
Telerik.Web.UI.PaneExpandedEventArgs.registerClass("Telerik.Web.UI.PaneExpandedEventArgs",Sys.EventArgs);
Telerik.Web.UI.SplitterPaneBase=function(_5){
Telerik.Web.UI.SplitterPaneBase.initializeBase(this,[_5]);
this._minWidth=20;
this._minHeight=20;
this._maxWidth=10000;
this._maxHeight=10000;
this._collapsed=false;
this._width="";
this._height="";
};
Telerik.Web.UI.SplitterPaneBase.prototype={endUpdate:function(){
if(this._width.toString().indexOf("px")>-1){
this._width=parseInt(this._width,10);
}
if(this._height.toString().indexOf("px")>-1){
this._height=parseInt(this._height,10);
}
Telerik.Web.UI.SplitterPaneBase.callBaseMethod(this,"endUpdate");
},initialize:function(){
Telerik.Web.UI.SplitterPaneBase.callBaseMethod(this,"initialize");
if(this.get_splitter().isVertical()){
this.getVarSize=this.get_width;
this.setVarSize=this.set_width;
this.getVarMinSize=this.get_minWidth;
this.getVarMaxSize=this.get_maxWidth;
}else{
this.getVarSize=this.get_height;
this.setVarSize=this.set_height;
this.getVarMinSize=this.get_minHeight;
this.getVarMaxSize=this.get_maxHeight;
}
this.get_parent()._addPane(this);
},dispose:function(){
Telerik.Web.UI.SplitterPaneBase.callBaseMethod(this,"dispose");
},set_minWidth:function(_6){
this._minWidth=_6;
this.updateClientState();
},get_minWidth:function(){
return this._minWidth;
},set_minHeight:function(_7){
this._minHeight=_7;
this.updateClientState();
},get_minHeight:function(){
return this._minHeight;
},set_maxWidth:function(_8){
this._maxWidth=_8;
this.updateClientState();
},get_maxWidth:function(){
return this._maxWidth;
},set_maxHeight:function(_9){
this._maxHeight=_9;
this.updateClientState();
},get_maxHeight:function(){
return this._maxHeight;
},set_width:function(_a){
this._width=_a;
this.updateClientState();
},get_width:function(){
return this._width;
},set_height:function(_b){
this._height=_b;
this.updateClientState();
},get_height:function(){
return this._height;
},set_collapsed:function(_c){
this._collapsed=_c;
this.updateClientState();
},get_collapsed:function(){
return this._collapsed;
},get_scrolling:function(){
return this._scrolling;
},set_scrolling:function(_d){
if($telerik.isOpera&&(_d==Telerik.Web.UI.SplitterPaneScrolling.X||_d==Telerik.Web.UI.SplitterPaneScrolling.Y)){
this._scrolling=Telerik.Web.UI.SplitterPaneScrolling.Both;
}else{
this._scrolling=_d;
}
this._configureScrolling();
this._scrollingEnabled=(this._scrolling!=Telerik.Web.UI.SplitterPaneScrolling.None);
},add_beforeCollapse:function(_e){
this.get_events().addHandler("beforeCollapse",_e);
},remove_beforeCollapse:function(_f){
this.get_events().removeHandler("beforeCollapse",_f);
},add_beforeExpand:function(_10){
this.get_events().addHandler("beforeExpand",_10);
},remove_beforeExpand:function(_11){
this.get_events().removeHandler("beforeExpand",_11);
},add_beforeResize:function(_12){
this.get_events().addHandler("beforeResize",_12);
},remove_beforeResize:function(_13){
this.get_events().removeHandler("beforeResize",_13);
},add_collapsed:function(_14){
this.get_events().addHandler("collapsed",_14);
},remove_collapsed:function(_15){
this.get_events().removeHandler("collapsed",_15);
},add_expanded:function(_16){
this.get_events().addHandler("expanded",_16);
},remove_expanded:function(_17){
this.get_events().removeHandler("expanded",_17);
},add_resized:function(_18){
this.get_events().addHandler("resized",_18);
},remove_resized:function(_19){
this.get_events().removeHandler("resized",_19);
},_configureScrolling:function(){
var _1a;
if(this.getContentContainer){
_1a=this.getContentContainer();
}else{
if(this.getContentElement){
_1a=this.getContentElement();
}
}
if(_1a){
var _1b=this.get_scrolling();
switch(_1b){
case Telerik.Web.UI.SplitterPaneScrolling.None:
_1a.style.overflow="hidden";
break;
case Telerik.Web.UI.SplitterPaneScrolling.X:
_1a.style.overflowX="auto";
_1a.style.overflowY="hidden";
break;
case Telerik.Web.UI.SplitterPaneScrolling.Y:
_1a.style.overflowX="hidden";
_1a.style.overflowY="auto";
break;
case Telerik.Web.UI.SplitterPaneScrolling.Both:
default:
_1a.style.overflow="auto";
break;
}
}
}};
Telerik.Web.UI.SplitterPaneBase.registerClass("Telerik.Web.UI.SplitterPaneBase",Telerik.Web.UI.SplitterItem);

