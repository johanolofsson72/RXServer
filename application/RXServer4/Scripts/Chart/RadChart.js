function WebForm_CallbackComplete(){
for(var i=0;i<__pendingCallbacks.length;i++){
var _2=__pendingCallbacks[i];
if(_2&&_2.xmlRequest&&(_2.xmlRequest.readyState==4)){
__pendingCallbacks[i]=null;
WebForm_ExecuteCallback(_2);
if(!_2.async){
__synchronousCallBackIndex=-1;
}
var _3="__CALLBACKFRAME"+i;
var _4=document.getElementById(_3);
if(_4){
_4.parentNode.removeChild(_4);
}
}
}
}
Type.registerNamespace("Telerik.Web.UI");
Type.registerNamespace("Telerik.Web.UI.Chart");
Telerik.Web.UI.Chart.ScrollMode=function(){
};
Telerik.Web.UI.Chart.ScrollMode.prototype={XOnly:0,YOnly:1,Both:2,None:3};
Telerik.Web.UI.Chart.ScrollMode.registerEnum("Telerik.Web.UI.Chart.ScrollMode",false);
Telerik.Web.UI.Chart.SeriesOrientation=function(){
};
Telerik.Web.UI.Chart.SeriesOrientation.prototype={Vertical:0,Horizontal:1};
Telerik.Web.UI.Chart.SeriesOrientation.registerEnum("Telerik.Web.UI.Chart.SeriesOrientation",false);
Telerik.Web.UI.RadChart=function(_5){
Telerik.Web.UI.RadChart.initializeBase(this,[_5]);
this._uniqueId="";
this._dragStart=false;
this._chunkMatrix=[];
this._clientSettings={};
this._xAxisMarker=null;
this._yAxisMarker=null;
this._yAxis2Marker=null;
this._loadTimeout=50;
this._timeOutTimerID=null;
this._axesSwapped=false;
this._seriesOrientation=Telerik.Web.UI.Chart.SeriesOrientation.Vertical;
};
Telerik.Web.UI.RadChart.prototype={initialize:function(){
Telerik.Web.UI.RadChart.callBaseMethod(this,"initialize");
this._plotAreaElement=$get(this.get_id()+"_rcPlotArea");
this._plotAreaImageWrapper=$get(this.get_id()+"_rchImgWrap");
this._plotAreaVirtualWidth=parseInt(this._plotAreaImageWrapper.style.width,10);
this._plotAreaVirtualHeight=parseInt(this._plotAreaImageWrapper.style.height,10);
this._xAxisElement=$get(this.get_id()+"_xAxis");
this._yAxisElement=$get(this.get_id()+"_yAxis");
this._yAxis2Element=$get(this.get_id()+"_yAxis2");
this._initializeZoomDiv();
this._initializeChunkMatrix();
this._initializeAxisMarkers();
this._scrollToPosition();
this._initializeCallbackDelegates();
this._attachDOMEvents();
var _6=this;
window.setTimeout(function(){
_6._updateChunks();
},200);
},dispose:function(){
if(this._clientSettings["EnableZoom"]==true){
$removeHandler(this._zoomDivScreenElement,"mousedown",this._onMouseDownDelegate);
$removeHandler(this._zoomDivScreenElement,"mousemove",this._onMouseMoveDelegate);
}
$removeHandler(this._plotAreaElement,"scroll",this._onScrollDelegate);
$removeHandler(this._plotAreaElement,"mouseover",this._onMouseOverDelegate);
$removeHandler(this._plotAreaElement,"mouseout",this._onMouseOutDelegate);
$removeHandler(document.body,"mouseup",this._onMouseUpDelegate);
Telerik.Web.UI.RadChart.callBaseMethod(this,"dispose");
},scroll:function(_7,_8){
this._clientSettings.XScrollOffset=this._validateOffsetArgument(_7,"XOffset");
if(typeof (_8)!="undefined"){
this._clientSettings.YScrollOffset=this._validateOffsetArgument(_8,"YOffset");
}
this._scrollToPosition();
},zoom:function(_9,_a,_b,_c){
_9=this._validateScaleArgument(_9,"XScale");
if(typeof (_a)!="undefined"){
_a=this._validateScaleArgument(_a,"YScale");
if(typeof (_b)!="undefined"){
_b=this._validateOffsetArgument(_b,"XOffset");
if(typeof (_c)!="undefined"){
_c=this._validateOffsetArgument(_c,"YOffset");
}
}
}
this._makePostback(["zoom",(_b?_b:this.get_xScrollOffset()),(_c?_c:this.get_yScrollOffset()),(_9?_9:this.get_xScale()),(_a?_a:this.get_yScale())].join(","));
},zoomOut:function(){
this._makePostback("zoomout");
},resetZoom:function(){
this._makePostback(["zoom",0,0,1,1].join(","));
},get_xScrollOffset:function(){
return this._clientSettings.XScrollOffset;
},get_yScrollOffset:function(){
return this._clientSettings.YScrollOffset;
},get_xScale:function(){
return this._clientSettings.XScale;
},get_yScale:function(){
return this._clientSettings.YScale;
},_initializeCallbackDelegates:function(){
this._onCallbackDelegate=Function.createDelegate(this,this._onCallbackSuccess);
this._onErrorDelegate=Function.createDelegate(this,this._onCallbackError);
},_attachDOMEvents:function(){
this._onMouseUpDelegate=Function.createDelegate(this,this._onMouseUpHandler);
this._onMouseDownDelegate=Function.createDelegate(this,this._onMouseDownHandler);
this._onMouseMoveDelegate=Function.createDelegate(this,this._onMouseMoveHandler);
this._onScrollDelegate=Function.createDelegate(this,this._onScrollHandler);
this._onMouseOutDelegate=Function.createDelegate(this,this._onMouseOutHandler);
this._onMouseOverDelegate=Function.createDelegate(this,this._onMouseOverHandler);
$addHandler(document.body,"mouseup",this._onMouseUpDelegate);
if(this._clientSettings["EnableZoom"]==true){
$addHandler(this._zoomDivScreenElement,"mousedown",this._onMouseDownDelegate);
$addHandler(this._zoomDivScreenElement,"mousemove",this._onMouseMoveDelegate);
}
$addHandler(this._plotAreaElement,"scroll",this._onScrollDelegate);
$addHandler(this._plotAreaElement,"mouseout",this._onMouseOutDelegate);
$addHandler(this._plotAreaElement,"mouseover",this._onMouseOverDelegate);
},_scrollToPosition:function(){
switch(this._clientSettings["ScrollMode"]){
case Telerik.Web.UI.Chart.ScrollMode.XOnly:
this._plotAreaElement.scrollLeft=this._clientSettings.XScrollOffset*parseInt(this._plotAreaImageWrapper.style.width,10);
break;
case Telerik.Web.UI.Chart.ScrollMode.YOnly:
this._plotAreaElement.scrollTop=this._clientSettings.YScrollOffset*parseInt(this._plotAreaImageWrapper.style.height,10);
break;
case Telerik.Web.UI.Chart.ScrollMode.Both:
this._plotAreaElement.scrollLeft=this._clientSettings.XScrollOffset*parseInt(this._plotAreaImageWrapper.style.width,10);
this._plotAreaElement.scrollTop=this._clientSettings.YScrollOffset*parseInt(this._plotAreaImageWrapper.style.height,10);
break;
}
this._adjustAxesScroll();
},_getEventSource:function(e){
return e.target||e.srcElement;
},_initializeZoomDiv:function(){
if(this._clientSettings["EnableZoom"]==false){
return;
}
var _e=document.createElement("DIV");
var _f=document.createElement("DIV");
switch(this._clientSettings["ScrollMode"]){
case Telerik.Web.UI.Chart.ScrollMode.XOnly:
_e.className="rchZoomX";
break;
case Telerik.Web.UI.Chart.ScrollMode.YOnly:
_e.className="rchZoomY";
break;
case Telerik.Web.UI.Chart.ScrollMode.Both:
_e.className="rchZoomXY";
break;
}
_e.style.position="absolute";
_e.style.display="none";
_e.style.backgroundColor=this._clientSettings["ZoomRectangleColor"]["hex"];
_f.style.top="0px";
_f.style.left="0px";
_f.style.width=this._plotAreaImageWrapper.style.width;
_f.style.height=this._plotAreaImageWrapper.style.height;
_f.className="rchZoomScreen";
this._plotAreaElement.appendChild(_e);
this._plotAreaElement.appendChild(_f);
$telerik.setOpacity(_e,this._clientSettings["ZoomRectangleOpacity"]);
this._zoomDivScreenElement=_f;
this._zoomDivElement=_e;
},_initializeChunkMatrix:function(){
var _10=Math.ceil(this._calculateElementWidth(this._plotAreaImageWrapper)/this._calculateElementWidth(this._plotAreaElement));
var _11=Math.ceil(this._calculateElementHeight(this._plotAreaImageWrapper)/this._calculateElementHeight(this._plotAreaElement));
switch(this._clientSettings["ScrollMode"]){
case Telerik.Web.UI.Chart.ScrollMode.XOnly:
this._initializeMatrix(_10,1);
break;
case Telerik.Web.UI.Chart.ScrollMode.YOnly:
this._initializeMatrix(1,_11);
break;
case Telerik.Web.UI.Chart.ScrollMode.Both:
this._initializeMatrix(_10,_11);
break;
case Telerik.Web.UI.Chart.ScrollMode.None:
this._chunkMatrix=null;
break;
}
},_initializeMatrix:function(x,y){
for(var _14=0;_14<x;_14++){
this._chunkMatrix[_14]=[];
for(var _15=0;_15<y;_15++){
this._chunkMatrix[_14][_15]=false;
}
}
},_onZoom:function(e){
var _17=this._getNormalizedScale();
var pos=this._getNormalizedPosition();
this._makePostback(["zoom",pos.X,pos.Y,_17.X,_17.Y].join(","));
},_getNormalizedScale:function(){
var _19=parseInt(this._zoomDivElement.style.width,10);
var _1a=parseInt(this._zoomDivElement.style.height,10);
var _1b=parseInt(this._plotAreaElement.style.width,10);
var _1c=parseInt(this._plotAreaElement.style.height,10);
var _1d=this._plotAreaVirtualWidth/_1b;
var _1e=this._plotAreaVirtualHeight/_1c;
var _1f=_1b/_19;
_1f=_1f*_1d;
_1f=this._normalizeScale(_1f);
var _20=_1c/_1a;
_20=_20*_1e;
_20=this._normalizeScale(_20);
return {X:_1f,Y:_20};
},_getNormalizedPosition:function(){
var _21=parseInt(this._zoomDivElement.style.left,10);
var top=parseInt(this._zoomDivElement.style.top,10);
var _23=_21/this._plotAreaVirtualWidth;
_23=this._normalizePosition(_23);
var _24=top/this._plotAreaVirtualHeight;
_24=this._normalizePosition(_24);
return {X:_23,Y:_24};
},_normalizeScale:function(_25){
return Math.ceil(_25*100)/100;
},_normalizePosition:function(pos){
return Math.ceil(pos*1000)/1000;
},_onMouseDownHandler:function(e){
var _28=this._getOffsetX(e);
var _29=this._getOffsetY(e);
this._initialZoomTop=_29;
this._initialZoomLeft=_28;
this._zoomDivElement.style.top=_29+"px";
this._zoomDivElement.style.left=_28+"px";
this._zoomDivElement.style.width="0px";
this._zoomDivElement.style.height="0px";
this._zoomDivElement.style.display="block";
this._dragStart=true;
},_onMouseUpHandler:function(e){
if(!this._dragStart){
return false;
}
this._onZoom();
this._zoomDivElement.style.display="none";
this._dragStart=false;
},_onMouseMoveHandler:function(e){
var _2c=this._getOffsetX(e);
var _2d=this._getOffsetY(e);
this._updateAxisMarkerPosition(_2c,_2d);
if(!this._dragStart){
return false;
}
if(this._getEventSource(e)==this._zoomDivElement){
return false;
}
var _2e;
var _2f;
var _30;
var _31;
if(this._initialZoomLeft>_2c){
_2f=_2c;
}else{
_2f=this._initialZoomLeft;
}
if(this._initialZoomTop>_2d){
_2e=_2d;
}else{
_2e=this._initialZoomTop;
}
_30=Math.abs(_2c-this._initialZoomLeft);
_31=Math.abs(_2d-this._initialZoomTop);
this._resizeZoomSelection(_2e,_2f,_30,_31);
},_onMouseOutHandler:function(e){
this._hideAxisMarkers();
},_onMouseOverHandler:function(e){
this._showAxisMarkers();
},_onScrollHandler:function(e){
this._adjustAxesScroll();
this._updateScrollOffsets();
this._updateChunksDelegate();
},_adjustAxesScroll:function(){
var _35=this._plotAreaElement.scrollLeft;
var _36=this._plotAreaElement.scrollTop;
this._xAxisElement.style.left=-_35+"px";
this._yAxisElement.style.top=-_36+"px";
if(this._yAxis2Element!=null){
if(this._seriesOrientation==Telerik.Web.UI.Chart.SeriesOrientation.Vertical){
this._yAxis2Element.style.top=-_36+"px";
}else{
this._yAxis2Element.style.left=-_35+"px";
}
}
},_updateScrollOffsets:function(){
var _37=this._plotAreaElement.scrollLeft/this._plotAreaVirtualWidth;
var _38=this._plotAreaElement.scrollTop/this._plotAreaVirtualHeight;
this._clientSettings.XScrollOffset=this._normalizePosition(_37);
this._clientSettings.YScrollOffset=this._normalizePosition(_38);
},_resizeZoomSelection:function(_39,_3a,_3b,_3c){
switch(this._clientSettings["ScrollMode"]){
case Telerik.Web.UI.Chart.ScrollMode.XOnly:
this._zoomDivElement.style.top="0px";
this._zoomDivElement.style.left=_3a+"px";
this._zoomDivElement.style.width=_3b+"px";
this._zoomDivElement.style.height=this._plotAreaElement.style.height;
break;
case Telerik.Web.UI.Chart.ScrollMode.YOnly:
this._zoomDivElement.style.top=_39+"px";
this._zoomDivElement.style.left="0px";
this._zoomDivElement.style.height=_3c+"px";
this._zoomDivElement.style.width=this._plotAreaElement.style.width;
break;
case Telerik.Web.UI.Chart.ScrollMode.Both:
this._zoomDivElement.style.top=_39+"px";
this._zoomDivElement.style.left=_3a+"px";
this._zoomDivElement.style.width=_3b+"px";
this._zoomDivElement.style.height=_3c+"px";
break;
}
},_loadChunk:function(row,col){
if(!this._chunkMatrix[col][row]){
this._chunkMatrix[col][row]=true;
var _3f=this._getChunkElement(row,col);
var _40=["LC",parseInt(_3f.style.left,10),parseInt(_3f.style.top,10),parseInt(_3f.style.width,10),parseInt(_3f.style.height,10)].join(":");
this._makeCallback(_40,[row,col]);
}
},_updateChunksDelegate:function(){
if(this._timeOutTimerID!=null){
clearTimeout(this._timeOutTimerID);
}
var _41=this;
this._timeOutTimerID=setTimeout(function(){
_41._updateChunks();
},this._loadTimeout);
},_updateChunks:function(){
var _42=this._checkVisibility();
this._loadChunk(_42["y1"],_42["x1"]);
this._loadChunk(_42["y2"],_42["x1"]);
this._loadChunk(_42["y1"],_42["x2"]);
this._loadChunk(_42["y2"],_42["x2"]);
},_getChunkElement:function(row,col){
return $get(this.get_id()+"_c_"+row+"_"+col,this._plotAreaImageWrapper);
},_calculateElementWidth:function(_45){
if(Sys.Browser.agent==Sys.Browser.InternetExplorer&&Sys.Browser.version==6){
return parseInt(_45.style.width,10);
}
return (_45.offsetWidth!=0)?_45.offsetWidth:parseInt(_45.style.width,10);
},_calculateElementHeight:function(_46){
if(Sys.Browser.agent==Sys.Browser.InternetExplorer&&Sys.Browser.version==6){
return parseInt(_46.style.height,10);
}
return (_46.offsetHeight!=0)?_46.offsetHeight:parseInt(_46.style.height,10);
},_checkVisibility:function(){
var _47=this._calculateElementWidth(this._plotAreaElement);
var _48=this._calculateElementHeight(this._plotAreaElement);
var _49=this._plotAreaElement.scrollLeft;
var _4a=this._plotAreaElement.scrollTop;
var _4b=_49/_47;
var _4c=_4a/_48;
var _4d=this._calculateElementWidth(this._plotAreaImageWrapper);
var _4e=this._calculateElementHeight(this._plotAreaImageWrapper);
var _4f=Math.ceil(_4d/_47);
var _50=Math.ceil(_4e/_48);
var _51={"x1":null,"x2":null,"y1":null,"y2":null};
_51["x1"]=Math.floor(_4b);
_51["x2"]=Math.min(Math.ceil(_4b),_4f-1);
_51["y1"]=Math.floor(_4c);
_51["y2"]=Math.min(Math.ceil(_4c),_50-1);
if(this._clientSettings["ScrollMode"]==Telerik.Web.UI.Chart.ScrollMode.XOnly){
_51["y1"]=0;
_51["y2"]=0;
}
if(this._clientSettings["ScrollMode"]==Telerik.Web.UI.Chart.ScrollMode.YOnly){
_51["x1"]=0;
_51["x2"]=0;
}
return _51;
},_initializeYAxis2Marker:function(){
if(this._yAxis2Element!=null){
var _52=this._clientSettings.AxisMarkersSize+"px";
if(this._seriesOrientation==Telerik.Web.UI.Chart.SeriesOrientation.Vertical){
this._yAxis2Marker=this._createAxisMarker(this._yAxis2Element,"1px",_52);
}else{
this._yAxis2Marker=this._createAxisMarker(this._yAxis2Element,_52,"1px");
}
}
},_initializeAxisMarkers:function(){
if(!this._clientSettings["EnableZoom"]||!this._clientSettings["EnableAxisMarkers"]){
return;
}
var _53=this._clientSettings.AxisMarkersSize;
var _54=this._clientSettings.AxisMarkersSize+"px";
switch(this._clientSettings["ScrollMode"]){
case Telerik.Web.UI.Chart.ScrollMode.XOnly:
this._xAxisMarker=this._createAxisMarker(this._xAxisElement,_54,"1px");
if(this._seriesOrientation==Telerik.Web.UI.Chart.SeriesOrientation.Horizontal){
this._initializeYAxis2Marker();
}
break;
case Telerik.Web.UI.Chart.ScrollMode.YOnly:
this._yAxisMarker=this._createAxisMarker(this._yAxisElement,"1px",_54);
if(this._seriesOrientation==Telerik.Web.UI.Chart.SeriesOrientation.Vertical){
this._initializeYAxis2Marker();
}
break;
case Telerik.Web.UI.Chart.ScrollMode.Both:
this._xAxisMarker=this._createAxisMarker(this._xAxisElement,_54,"1px");
this._yAxisMarker=this._createAxisMarker(this._yAxisElement,"1px",_54);
this._initializeYAxis2Marker();
break;
}
this._setAxisMarkerPosition();
},_createAxisMarker:function(_55,_56,_57){
var _58=document.createElement("div");
_58.style.position="absolute";
_58.style.display="none";
_58.style.backgroundColor=this._clientSettings["AxisMarkersColor"]["hex"];
_58.style.width=_57;
_58.style.height=_56;
_58.style.overflow="hidden";
_55.appendChild(_58);
if(Sys.Browser.agent==Sys.Browser.InternetExplorer&&Sys.Browser.version==6){
if(_58.style.width=="100%"){
_58.style.width=_58.parentNode.style.width;
}
if(_58.style.height=="100%"){
_58.style.height=_58.parentNode.style.height;
}
}
return _58;
},_setAxisMarkerPosition:function(){
var _59=this._clientSettings["ScrollMode"];
var _5a=this._clientSettings.AxisMarkersSize;
if(_59==Telerik.Web.UI.Chart.ScrollMode.XOnly||_59==Telerik.Web.UI.Chart.ScrollMode.Both){
if(this._seriesOrientation==Telerik.Web.UI.Chart.SeriesOrientation.Horizontal){
this._xAxisMarker.style.left=this._calculateElementWidth(this._xAxisElement)-_5a+"px";
}
}
if(_59==Telerik.Web.UI.Chart.ScrollMode.YOnly||_59==Telerik.Web.UI.Chart.ScrollMode.Both){
if(this._seriesOrientation==Telerik.Web.UI.Chart.SeriesOrientation.Vertical||this._axesSwapped){
this._yAxisMarker.style.left=this._calculateElementWidth(this._yAxisElement)-_5a+"px";
}else{
this._yAxisMarker.style.top=this._calculateElementHeight(this._yAxisElement)-_5a+"px";
}
}
if(this._yAxis2Marker!=null&&this._seriesOrientation==Telerik.Web.UI.Chart.SeriesOrientation.Horizontal){
this._yAxis2Marker.style.top=this._calculateElementHeight(this._yAxis2Element)-_5a+"px";
}
},_updateAxisMarkerPosition:function(_5b,_5c){
if(!this._clientSettings["EnableZoom"]||!this._clientSettings["EnableAxisMarkers"]){
return;
}
if(this._xAxisMarker!=null){
var _5d=parseInt(this._plotAreaElement.style.left,10)-parseInt(this._xAxisElement.parentNode.style.left,10);
this._xAxisMarker.style.left=_5b+_5d+"px";
}
if(this._yAxisMarker!=null){
var _5e=parseInt(this._plotAreaElement.style.top,10)-parseInt(this._yAxisElement.parentNode.style.top,10);
this._yAxisMarker.style.top=_5c+_5e+"px";
}
if(this._yAxis2Marker!=null){
if(this._seriesOrientation==Telerik.Web.UI.Chart.SeriesOrientation.Vertical){
var _5e=parseInt(this._plotAreaElement.style.top,10)-parseInt(this._yAxis2Element.parentNode.style.top,10);
this._yAxis2Marker.style.top=_5c+_5e+"px";
}else{
var _5d=parseInt(this._plotAreaElement.style.left,10)-parseInt(this._yAxis2Element.parentNode.style.left,10);
this._yAxis2Marker.style.left=_5b+_5d+"px";
}
}
},_showAxisMarkers:function(){
if(!this._clientSettings["EnableZoom"]||!this._clientSettings["EnableAxisMarkers"]){
return;
}
if(this._xAxisMarker!=null){
this._xAxisMarker.style.display="";
}
if(this._yAxisMarker!=null){
this._yAxisMarker.style.display="";
}
if(this._yAxis2Marker!=null){
this._yAxis2Marker.style.display="";
}
},_hideAxisMarkers:function(){
if(!this._clientSettings["EnableZoom"]||!this._clientSettings["EnableAxisMarkers"]){
return;
}
if(this._xAxisMarker!=null){
this._xAxisMarker.style.display="none";
}
if(this._yAxisMarker!=null){
this._yAxisMarker.style.display="none";
}
if(this._yAxis2Marker!=null){
this._yAxis2Marker.style.display="none";
}
},_getOffsetX:function(e){
var _60=e.offsetX;
if(Sys.Browser.agent==Sys.Browser.Firefox){
_60=_60+this._plotAreaElement.scrollLeft;
}
return _60;
},_getOffsetY:function(e){
var _62=e.offsetY;
if(Sys.Browser.agent==Sys.Browser.Firefox){
_62=_62+this._plotAreaElement.scrollTop;
}
return _62;
},_makePostback:function(_63){
if(typeof (__doPostBack)!="undefined"){
__doPostBack(this._uniqueId,_63);
}
},_makeCallback:function(_64,_65){
this._fixAspNetCallbacks();
if(typeof (WebForm_DoCallback)!="undefined"){
WebForm_DoCallback(this._uniqueId,_64,this._onCallbackDelegate,_65,this._onErrorDelegate,true);
}
},_fixAspNetCallbacks:function(){
if(window.__theFormPostData){
window.__theFormPostData="";
}
if(window.__theFormPostCollection){
window.__theFormPostCollection=[];
}
if(window.WebForm_InitCallback){
window.WebForm_InitCallback();
}
},_onCallbackSuccess:function(_66,_67){
var _68=this._getChunkElement(_67[0],_67[1]);
if(_68!=null){
var _69=document.createElement("IMG");
_69.src=_66;
_69.toElement=_68;
_69.onload=function(){
this.toElement.style.background="url("+this.src+")";
};
}
},_onCallbackError:function(_6a,_6b){
var _6c=_6a.replace(/(\d*\|.*)/,"");
throw new Error(_6c);
},_validateScaleArgument:function(_6d,_6e){
_6d=parseFloat(_6d);
if(isNaN(_6d)||_6d<0){
throw new Error(_6e+" factor should be numeric value greater than 0.");
}
return _6d;
},_validateOffsetArgument:function(_6f,_70){
_6f=parseFloat(_6f);
if(isNaN(_6f)||_6f>1||_6f<0){
throw new Error(_70+"Offset should be numeric value between 0 and 1.");
}
return _6f;
}};
Telerik.Web.UI.RadChart.registerClass("Telerik.Web.UI.RadChart",Telerik.Web.UI.RadWebControl);

