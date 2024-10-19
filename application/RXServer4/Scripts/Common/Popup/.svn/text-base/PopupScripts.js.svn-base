Type.registerNamespace("Telerik.Web");
Telerik.Web.BehaviorBase=function(_1){
Telerik.Web.BehaviorBase.initializeBase(this,[_1]);
this._clientStateFieldID=null;
this._pageRequestManager=null;
this._partialUpdateBeginRequestHandler=null;
this._partialUpdateEndRequestHandler=null;
};
Telerik.Web.BehaviorBase.prototype={initialize:function(){
Telerik.Web.BehaviorBase.callBaseMethod(this,"initialize");
},dispose:function(){
Telerik.Web.BehaviorBase.callBaseMethod(this,"dispose");
if(this._pageRequestManager){
if(this._partialUpdateBeginRequestHandler){
this._pageRequestManager.remove_beginRequest(this._partialUpdateBeginRequestHandler);
this._partialUpdateBeginRequestHandler=null;
}
if(this._partialUpdateEndRequestHandler){
this._pageRequestManager.remove_endRequest(this._partialUpdateEndRequestHandler);
this._partialUpdateEndRequestHandler=null;
}
this._pageRequestManager=null;
}
},get_ClientStateFieldID:function(){
return this._clientStateFieldID;
},set_ClientStateFieldID:function(_2){
if(this._clientStateFieldID!=_2){
this._clientStateFieldID=_2;
this.raisePropertyChanged("ClientStateFieldID");
}
},get_ClientState:function(){
if(this._clientStateFieldID){
var _3=document.getElementById(this._clientStateFieldID);
if(_3){
return _3.value;
}
}
return null;
},set_ClientState:function(_4){
if(this._clientStateFieldID){
var _5=document.getElementById(this._clientStateFieldID);
if(_5){
_5.value=_4;
}
}
},registerPartialUpdateEvents:function(){
if(Sys&&Sys.WebForms&&Sys.WebForms.PageRequestManager){
this._pageRequestManager=Sys.WebForms.PageRequestManager.getInstance();
if(this._pageRequestManager){
this._partialUpdateBeginRequestHandler=Function.createDelegate(this,this._partialUpdateBeginRequest);
this._pageRequestManager.add_beginRequest(this._partialUpdateBeginRequestHandler);
this._partialUpdateEndRequestHandler=Function.createDelegate(this,this._partialUpdateEndRequest);
this._pageRequestManager.add_endRequest(this._partialUpdateEndRequestHandler);
}
}
},_partialUpdateBeginRequest:function(_6,_7){
},_partialUpdateEndRequest:function(_8,_9){
}};
Telerik.Web.BehaviorBase.registerClass("Telerik.Web.BehaviorBase",Sys.UI.Behavior);
Type.registerNamespace("Telerik.Web");
Telerik.Web.IDragSource=function(){
};
Telerik.Web.IDragSource.prototype={get_dragDataType:function(){
throw Error.notImplemented();
},getDragData:function(){
throw Error.notImplemented();
},get_dragMode:function(){
throw Error.notImplemented();
},onDragStart:function(){
throw Error.notImplemented();
},onDrag:function(){
throw Error.notImplemented();
},onDragEnd:function(){
throw Error.notImplemented();
}};
Telerik.Web.IDragSource.registerInterface("Telerik.Web.IDragSource");
Telerik.Web.IDropTarget=function(){
};
Telerik.Web.IDropTarget.prototype={get_dropTargetElement:function(){
throw Error.notImplemented();
},canDrop:function(){
throw Error.notImplemented();
},drop:function(){
throw Error.notImplemented();
},onDragEnterTarget:function(){
throw Error.notImplemented();
},onDragLeaveTarget:function(){
throw Error.notImplemented();
},onDragInTarget:function(){
throw Error.notImplemented();
}};
Telerik.Web.IDropTarget.registerInterface("Telerik.Web.IDropTarget");
Telerik.Web.DragMode=function(){
throw Error.invalidOperation();
};
Telerik.Web.DragMode.prototype={Copy:0,Move:1};
Telerik.Web.DragMode.registerEnum("Telerik.Web.DragMode");
Telerik.Web.DragDropEventArgs=function(_a,_b,_c){
this._dragMode=_a;
this._dataType=_b;
this._data=_c;
};
Telerik.Web.DragDropEventArgs.prototype={get_dragMode:function(){
return this._dragMode||null;
},get_dragDataType:function(){
return this._dataType||null;
},get_dragData:function(){
return this._data||null;
}};
Telerik.Web.DragDropEventArgs.registerClass("Telerik.Web.DragDropEventArgs");
Telerik.Web._DragDropManager=function(){
this._instance=null;
this._events=null;
};
Telerik.Web._DragDropManager.prototype={add_dragStart:function(_d){
this.get_events().addHandler("dragStart",_d);
},remove_dragStart:function(_e){
this.get_events().removeHandler("dragStart",_e);
},get_events:function(){
if(!this._events){
this._events=new Sys.EventHandlerList();
}
return this._events;
},add_dragStop:function(_f){
this.get_events().addHandler("dragStop",_f);
},remove_dragStop:function(_10){
this.get_events().removeHandler("dragStop",_10);
},_getInstance:function(){
if(!this._instance){
if(Sys.Browser.agent===Sys.Browser.InternetExplorer){
this._instance=new Telerik.Web.IEDragDropManager();
}else{
this._instance=new Telerik.Web.GenericDragDropManager();
}
this._instance.initialize();
this._instance.add_dragStart(Function.createDelegate(this,this._raiseDragStart));
this._instance.add_dragStop(Function.createDelegate(this,this._raiseDragStop));
}
return this._instance;
},startDragDrop:function(_11,_12,_13){
this._getInstance().startDragDrop(_11,_12,_13);
},registerDropTarget:function(_14,_15){
this._getInstance().registerDropTarget(_14,_15);
},unregisterDropTarget:function(_16){
this._getInstance().unregisterDropTarget(_16);
},dispose:function(){
delete this._events;
Sys.Application.unregisterDisposableObject(this);
Sys.Application.removeComponent(this);
},_raiseDragStart:function(_17,_18){
var _19=this.get_events().getHandler("dragStart");
if(_19){
_19(this,_18);
}
},_raiseDragStop:function(_1a,_1b){
var _1c=this.get_events().getHandler("dragStop");
if(_1c){
_1c(this,_1b);
}
}};
Telerik.Web._DragDropManager.registerClass("Telerik.Web._DragDropManager");
Telerik.Web.DragDropManager=new Telerik.Web._DragDropManager();
Telerik.Web.IEDragDropManager=function(){
Telerik.Web.IEDragDropManager.initializeBase(this);
this._dropTargets=null;
this._radius=10;
this._activeDragVisual=null;
this._activeContext=null;
this._activeDragSource=null;
this._underlyingTarget=null;
this._oldOffset=null;
this._potentialTarget=null;
this._isDragging=false;
this._mouseUpHandler=null;
this._documentMouseMoveHandler=null;
this._documentDragOverHandler=null;
this._dragStartHandler=null;
this._mouseMoveHandler=null;
this._dragEnterHandler=null;
this._dragLeaveHandler=null;
this._dragOverHandler=null;
this._dropHandler=null;
this._areEventsWired=false;
};
Telerik.Web.IEDragDropManager.prototype={add_dragStart:function(_1d){
this.get_events().addHandler("dragStart",_1d);
},remove_dragStart:function(_1e){
this.get_events().removeHandler("dragStart",_1e);
},add_dragStop:function(_1f){
this.get_events().addHandler("dragStop",_1f);
},remove_dragStop:function(_20){
this.get_events().removeHandler("dragStop",_20);
},initialize:function(){
Telerik.Web.IEDragDropManager.callBaseMethod(this,"initialize");
this._mouseUpHandler=Function.createDelegate(this,this._onMouseUp);
this._documentMouseMoveHandler=Function.createDelegate(this,this._onDocumentMouseMove);
this._documentDragOverHandler=Function.createDelegate(this,this._onDocumentDragOver);
this._dragStartHandler=Function.createDelegate(this,this._onDragStart);
this._mouseMoveHandler=Function.createDelegate(this,this._onMouseMove);
this._dragEnterHandler=Function.createDelegate(this,this._onDragEnter);
this._dragLeaveHandler=Function.createDelegate(this,this._onDragLeave);
this._dragOverHandler=Function.createDelegate(this,this._onDragOver);
this._dropHandler=Function.createDelegate(this,this._onDrop);
},dispose:function(){
if(this._dropTargets){
for(var i=0;i<this._dropTargets;i++){
this.unregisterDropTarget(this._dropTargets[i]);
}
this._dropTargets=null;
}
Telerik.Web.IEDragDropManager.callBaseMethod(this,"dispose");
},startDragDrop:function(_22,_23,_24){
var ev=window._event;
if(this._isDragging){
return;
}
this._underlyingTarget=null;
this._activeDragSource=_22;
this._activeDragVisual=_23;
this._activeContext=_24;
var _26={x:ev.clientX,y:ev.clientY};
_23.originalPosition=_23.style.position;
var _27=$telerik.getLocation(_23);
_23.style.position="absolute";
document._lastPosition=_26;
_23.startingPoint=_26;
var _28=this.getScrollOffset(_23,true);
_23.startingPoint=this.addPoints(_23.startingPoint,_28);
if(_23.style.position=="absolute"){
_23.startingPoint=this.subtractPoints(_23.startingPoint,_27);
}else{
var _29=parseInt(_23.style.left);
var top=parseInt(_23.style.top);
if(isNaN(_29)){
_29="0";
}
if(isNaN(top)){
top="0";
}
_23.startingPoint=this.subtractPoints(_23.startingPoint,{x:_29,y:top});
}
this._prepareForDomChanges();
_22.onDragStart();
var _2b=new Telerik.Web.DragDropEventArgs(_22.get_dragMode(),_22.get_dragDataType(),_22.getDragData(_24));
var _2c=this.get_events().getHandler("dragStart");
if(_2c){
_2c(this,_2b);
}
this._recoverFromDomChanges();
this._unwireEvents();
this._wireEvents();
this._drag(true);
},_stopDragDrop:function(_2d){
var ev=window._event;
if(this._activeDragSource!=null){
this._unwireEvents();
if(!_2d){
_2d=(this._underlyingTarget==null);
}
if(!_2d&&this._underlyingTarget!=null){
this._underlyingTarget.drop(this._activeDragSource.get_dragMode(),this._activeDragSource.get_dragDataType(),this._activeDragSource.getDragData(this._activeContext));
}
this._activeDragSource.onDragEnd(_2d);
var _2f=this.get_events().getHandler("dragStop");
if(_2f){
_2f(this,Sys.EventArgs.Empty);
}
this._activeDragVisual.style.position=this._activeDragVisual.originalPosition;
this._activeDragSource=null;
this._activeContext=null;
this._activeDragVisual=null;
this._isDragging=false;
this._potentialTarget=null;
ev.preventDefault();
}
},_drag:function(_30){
var ev=window._event;
var _32={x:ev.clientX,y:ev.clientY};
document._lastPosition=_32;
var _33=this.getScrollOffset(this._activeDragVisual,true);
var _34=this.addPoints(this.subtractPoints(_32,this._activeDragVisual.startingPoint),_33);
if(!_30&&parseInt(this._activeDragVisual.style.left)==_34.x&&parseInt(this._activeDragVisual.style.top)==_34.y){
return;
}
$telerik.setLocation(this._activeDragVisual,_34);
this._prepareForDomChanges();
this._activeDragSource.onDrag();
this._recoverFromDomChanges();
this._potentialTarget=this._findPotentialTarget(this._activeDragSource,this._activeDragVisual);
var _35=(this._potentialTarget!=this._underlyingTarget||this._potentialTarget==null);
if(_35&&this._underlyingTarget!=null){
this._leaveTarget(this._activeDragSource,this._underlyingTarget);
}
if(this._potentialTarget!=null){
if(_35){
this._underlyingTarget=this._potentialTarget;
this._enterTarget(this._activeDragSource,this._underlyingTarget);
}else{
this._moveInTarget(this._activeDragSource,this._underlyingTarget);
}
}else{
this._underlyingTarget=null;
}
},_wireEvents:function(){
$addHandler(document,"mouseup",this._mouseUpHandler);
$addHandler(document,"mousemove",this._documentMouseMoveHandler);
$addHandler(document.body,"dragover",this._documentDragOverHandler);
$addHandler(this._activeDragVisual,"dragstart",this._dragStartHandler);
$addHandler(this._activeDragVisual,"dragend",this._mouseUpHandler);
$addHandler(this._activeDragVisual,"drag",this._mouseMoveHandler);
this._areEventsWired=true;
},_unwireEvents:function(){
if(!this._areEventsWired){
return;
}
$removeHandler(this._activeDragVisual,"drag",this._mouseMoveHandler);
$removeHandler(this._activeDragVisual,"dragend",this._mouseUpHandler);
$removeHandler(this._activeDragVisual,"dragstart",this._dragStartHandler);
$removeHandler(document.body,"dragover",this._documentDragOverHandler);
$removeHandler(document,"mousemove",this._documentMouseMoveHandler);
$removeHandler(document,"mouseup",this._mouseUpHandler);
this._areEventsWired=false;
},registerDropTarget:function(_36,_37){
if(this._dropTargets==null){
this._dropTargets=[];
}
if(_37){
Array.add(this._dropTargets,_36);
}else{
Array.insert(this._dropTargets,0,_36);
}
this._wireDropTargetEvents(_36);
},unregisterDropTarget:function(_38){
this._unwireDropTargetEvents(_38);
if(this._dropTargets){
Array.remove(this._dropTargets,_38);
}
},_wireDropTargetEvents:function(_39){
var _3a=_39.get_dropTargetElement();
_3a._dropTarget=_39;
$addHandler(_3a,"dragenter",this._dragEnterHandler);
$addHandler(_3a,"dragleave",this._dragLeaveHandler);
$addHandler(_3a,"dragover",this._dragOverHandler);
$addHandler(_3a,"drop",this._dropHandler);
},_unwireDropTargetEvents:function(_3b){
var _3c=_3b.get_dropTargetElement();
if(_3c._dropTarget){
_3c._dropTarget=null;
$removeHandler(_3c,"dragenter",this._dragEnterHandler);
$removeHandler(_3c,"dragleave",this._dragLeaveHandler);
$removeHandler(_3c,"dragover",this._dragOverHandler);
$removeHandler(_3c,"drop",this._dropHandler);
}
},_onDragStart:function(ev){
window._event=ev;
document.selection.empty();
var dt=ev.dataTransfer;
if(!dt&&ev.rawEvent){
dt=ev.rawEvent.dataTransfer;
}
var _3f=this._activeDragSource.get_dragDataType().toLowerCase();
var _40=this._activeDragSource.getDragData(this._activeContext);
if(_40){
if(_3f!="text"&&_3f!="url"){
_3f="text";
if(_40.innerHTML!=null){
_40=_40.innerHTML;
}
}
dt.effectAllowed="move";
dt.setData(_3f,_40.toString());
}
},_onMouseUp:function(ev){
window._event=ev;
this._stopDragDrop(false);
},_onDocumentMouseMove:function(ev){
window._event=ev;
this._dragDrop();
},_onDocumentDragOver:function(ev){
window._event=ev;
if(this._potentialTarget){
ev.preventDefault();
}
},_onMouseMove:function(ev){
window._event=ev;
this._drag();
},_onDragEnter:function(ev){
window._event=ev;
if(this._isDragging){
ev.preventDefault();
}else{
var _46=Telerik.Web.IEDragDropManager._getDataObjectsForDropTarget(this._getDropTarget(ev.target));
for(var i=0;i<_46.length;i++){
this._dropTarget.onDragEnterTarget(Telerik.Web.DragMode.Copy,_46[i].type,_46[i].value);
}
}
},_onDragLeave:function(ev){
window._event=ev;
if(this._isDragging){
ev.preventDefault();
}else{
var _49=Telerik.Web.IEDragDropManager._getDataObjectsForDropTarget(this._getDropTarget(ev.target));
for(var i=0;i<_49.length;i++){
this._dropTarget.onDragLeaveTarget(Telerik.Web.DragMode.Copy,_49[i].type,_49[i].value);
}
}
},_onDragOver:function(ev){
window._event=ev;
if(this._isDragging){
ev.preventDefault();
}else{
var _4c=Telerik.Web.IEDragDropManager._getDataObjectsForDropTarget(this._getDropTarget(ev.target));
for(var i=0;i<_4c.length;i++){
this._dropTarget.onDragInTarget(Telerik.Web.DragMode.Copy,_4c[i].type,_4c[i].value);
}
}
},_onDrop:function(ev){
window._event=ev;
if(!this._isDragging){
var _4f=Telerik.Web.IEDragDropManager._getDataObjectsForDropTarget(this._getDropTarget(ev.target));
for(var i=0;i<_4f.length;i++){
this._dropTarget.drop(Telerik.Web.DragMode.Copy,_4f[i].type,_4f[i].value);
}
}
ev.preventDefault();
},_getDropTarget:function(_51){
while(_51){
if(_51._dropTarget!=null){
return _51._dropTarget;
}
_51=_51.parentNode;
}
return null;
},_dragDrop:function(){
if(this._isDragging){
return;
}
this._isDragging=true;
this._activeDragVisual.dragDrop();
document.selection.empty();
},_moveInTarget:function(_52,_53){
this._prepareForDomChanges();
_53.onDragInTarget(_52.get_dragMode(),_52.get_dragDataType(),_52.getDragData(this._activeContext));
this._recoverFromDomChanges();
},_enterTarget:function(_54,_55){
this._prepareForDomChanges();
_55.onDragEnterTarget(_54.get_dragMode(),_54.get_dragDataType(),_54.getDragData(this._activeContext));
this._recoverFromDomChanges();
},_leaveTarget:function(_56,_57){
this._prepareForDomChanges();
_57.onDragLeaveTarget(_56.get_dragMode(),_56.get_dragDataType(),_56.getDragData(this._activeContext));
this._recoverFromDomChanges();
},_findPotentialTarget:function(_58,_59){
var ev=window._event;
if(this._dropTargets==null){
return null;
}
var _5b=_58.get_dragDataType();
var _5c=_58.get_dragMode();
var _5d=_58.getDragData(this._activeContext);
var _5e=this.getScrollOffset(document.body,true);
var x=ev.clientX+_5e.x;
var y=ev.clientY+_5e.y;
var _61={x:x-this._radius,y:y-this._radius,width:this._radius*2,height:this._radius*2};
var _62;
for(var i=0;i<this._dropTargets.length;i++){
_62=$telerik.getBounds(this._dropTargets[i].get_dropTargetElement());
if(this._overlaps(_61,_62)&&this._dropTargets[i].canDrop(_5c,_5b,_5d)){
return this._dropTargets[i];
}
}
return null;
},_overlaps:function(r1,r2){
var _66=(r1.x>=r2.x&&r1.x<=(r2.x+r2.width));
var _67=((r1.x+r1.width)>=r2.x&&(r1.x+r1.width)<=r2.x+r2.width);
var _68=((r1.x<r2.x)&&((r1.x+r1.width)>(r2.x+r2.width)));
var _69=(r1.y>=r2.y&&r1.y<=(r2.y+r2.height));
var _6a=((r1.y+r1.height)>=r2.y&&(r1.y+r1.height)<=r2.y+r2.height);
var _6b=((r1.y<r2.y)&&((r1.y+r1.height)>(r2.y+r2.height)));
if((_66||_67||_68)&&(_69||_6a||_6b)){
return true;
}
return false;
},_prepareForDomChanges:function(){
this._oldOffset=$telerik.getLocation(this._activeDragVisual);
},_recoverFromDomChanges:function(){
var _6c=$telerik.getLocation(this._activeDragVisual);
if(this._oldOffset.x!=_6c.x||this._oldOffset.y!=_6c.y){
this._activeDragVisual.startingPoint=this.subtractPoints(this._activeDragVisual.startingPoint,this.subtractPoints(this._oldOffset,_6c));
scrollOffset=this.getScrollOffset(this._activeDragVisual,true);
var _6d=this.addPoints(this.subtractPoints(document._lastPosition,this._activeDragVisual.startingPoint),scrollOffset);
$telerik.setLocation(this._activeDragVisual,_6d);
}
},addPoints:function(p1,p2){
return {x:p1.x+p2.x,y:p1.y+p2.y};
},subtractPoints:function(p1,p2){
return {x:p1.x-p2.x,y:p1.y-p2.y};
},getScrollOffset:function(_72,_73){
var _74=_72.scrollLeft;
var top=_72.scrollTop;
if(_73){
var _76=_72.parentNode;
while(_76!=null&&_76.scrollLeft!=null){
_74+=_76.scrollLeft;
top+=_76.scrollTop;
if(_76==document.body&&(_74!=0&&top!=0)){
break;
}
_76=_76.parentNode;
}
}
return {x:_74,y:top};
},getBrowserRectangle:function(){
var _77=window.innerWidth;
var _78=window.innerHeight;
if(_77==null){
_77=document.body.clientWidth;
}
if(_78==null){
_78=document.body.clientHeight;
}
return {x:0,y:0,width:_77,height:_78};
},getNextSibling:function(_79){
for(_79=_79.nextSibling;_79!=null;_79=_79.nextSibling){
if(_79.innerHTML!=null){
return _79;
}
}
return null;
},hasParent:function(_7a){
return (_7a.parentNode!=null&&_7a.parentNode.tagName!=null);
}};
Telerik.Web.IEDragDropManager.registerClass("Telerik.Web.IEDragDropManager",Sys.Component);
Telerik.Web.IEDragDropManager._getDataObjectsForDropTarget=function(_7b){
if(_7b==null){
return [];
}
var ev=window._event;
var _7d=[];
var _7e=["URL","Text"];
var _7f;
for(var i=0;i<_7e.length;i++){
var dt=ev.dataTransfer;
if(!dt&&ev.rawEvent){
dt=ev.rawEvent.dataTransfer;
}
_7f=dt.getData(_7e[i]);
if(_7b.canDrop(Telerik.Web.DragMode.Copy,_7e[i],_7f)){
if(_7f){
Array.add(_7d,{type:_7e[i],value:_7f});
}
}
}
return _7d;
};
Telerik.Web.GenericDragDropManager=function(){
Telerik.Web.GenericDragDropManager.initializeBase(this);
this._dropTargets=null;
this._scrollEdgeConst=40;
this._scrollByConst=10;
this._scroller=null;
this._scrollDeltaX=0;
this._scrollDeltaY=0;
this._activeDragVisual=null;
this._activeContext=null;
this._activeDragSource=null;
this._oldOffset=null;
this._potentialTarget=null;
this._mouseUpHandler=null;
this._mouseMoveHandler=null;
this._keyPressHandler=null;
this._scrollerTickHandler=null;
this._areEventsWired=false;
};
Telerik.Web.GenericDragDropManager.prototype={initialize:function(){
Telerik.Web.GenericDragDropManager.callBaseMethod(this,"initialize");
this._mouseUpHandler=Function.createDelegate(this,this._onMouseUp);
this._mouseMoveHandler=Function.createDelegate(this,this._onMouseMove);
this._keyPressHandler=Function.createDelegate(this,this._onKeyPress);
this._scrollerTickHandler=Function.createDelegate(this,this._onScrollerTick);
if(Sys.Browser.agent===Sys.Browser.Safari){
Telerik.Web.GenericDragDropManager.__loadSafariCompatLayer(this);
}
this._scroller=new Telerik.Web.Timer();
this._scroller.set_interval(10);
this._scroller.add_tick(this._scrollerTickHandler);
},startDragDrop:function(_82,_83,_84){
this._activeDragSource=_82;
this._activeDragVisual=_83;
this._activeContext=_84;
Telerik.Web.GenericDragDropManager.callBaseMethod(this,"startDragDrop",[_82,_83,_84]);
},_stopDragDrop:function(_85){
this._scroller.set_enabled(false);
Telerik.Web.GenericDragDropManager.callBaseMethod(this,"_stopDragDrop",[_85]);
},_drag:function(_86){
Telerik.Web.GenericDragDropManager.callBaseMethod(this,"_drag",[_86]);
this._autoScroll();
},_wireEvents:function(){
$addHandler(document,"mouseup",this._mouseUpHandler);
$addHandler(document,"mousemove",this._mouseMoveHandler);
$addHandler(document,"keypress",this._keyPressHandler);
this._areEventsWired=true;
},_unwireEvents:function(){
if(!this._areEventsWired){
return;
}
$removeHandler(document,"keypress",this._keyPressHandler);
$removeHandler(document,"mousemove",this._mouseMoveHandler);
$removeHandler(document,"mouseup",this._mouseUpHandler);
this._areEventsWired=false;
},_wireDropTargetEvents:function(_87){
},_unwireDropTargetEvents:function(_88){
},_onMouseUp:function(e){
window._event=e;
this._stopDragDrop(false);
},_onMouseMove:function(e){
window._event=e;
this._drag();
},_onKeyPress:function(e){
window._event=e;
var k=e.keyCode?e.keyCode:e.rawEvent.keyCode;
if(k==27){
this._stopDragDrop(true);
}
},_autoScroll:function(){
var ev=window._event;
var _8e=this.getBrowserRectangle();
if(_8e.width>0){
this._scrollDeltaX=this._scrollDeltaY=0;
if(ev.clientX<_8e.x+this._scrollEdgeConst){
this._scrollDeltaX=-this._scrollByConst;
}else{
if(ev.clientX>_8e.width-this._scrollEdgeConst){
this._scrollDeltaX=this._scrollByConst;
}
}
if(ev.clientY<_8e.y+this._scrollEdgeConst){
this._scrollDeltaY=-this._scrollByConst;
}else{
if(ev.clientY>_8e.height-this._scrollEdgeConst){
this._scrollDeltaY=this._scrollByConst;
}
}
if(this._scrollDeltaX!=0||this._scrollDeltaY!=0){
this._scroller.set_enabled(true);
}else{
this._scroller.set_enabled(false);
}
}
},_onScrollerTick:function(){
var _8f=document.body.scrollLeft;
var _90=document.body.scrollTop;
window.scrollBy(this._scrollDeltaX,this._scrollDeltaY);
var _91=document.body.scrollLeft;
var _92=document.body.scrollTop;
var _93=this._activeDragVisual;
var _94={x:parseInt(_93.style.left)+(_91-_8f),y:parseInt(_93.style.top)+(_92-_90)};
$telerik.setLocation(_93,_94);
}};
Telerik.Web.GenericDragDropManager.registerClass("Telerik.Web.GenericDragDropManager",Telerik.Web.IEDragDropManager);
if(Sys.Browser.agent===Sys.Browser.Safari){
Telerik.Web.GenericDragDropManager.__loadSafariCompatLayer=function(ddm){
ddm._getScrollOffset=ddm.getScrollOffset;
ddm.getScrollOffset=function(_96,_97){
return {x:0,y:0};
};
ddm._getBrowserRectangle=ddm.getBrowserRectangle;
ddm.getBrowserRectangle=function(){
var _98=ddm._getBrowserRectangle();
var _99=ddm._getScrollOffset(document.body,true);
return {x:_98.x+_99.x,y:_98.y+_99.y,width:_98.width+_99.x,height:_98.height+_99.y};
};
};
}
Type.registerNamespace("Telerik.Web");
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.ModalExtender=function(_9a){
this._windowResizeDelegate=null;
this._windowScrollDelegate=null;
this._xCoordinate=-1;
this._yCoordinate=-1;
this._backgroundElement=null;
this._foregroundElement=_9a;
this._saveTabIndexes=new Array();
this._saveDesableSelect=new Array();
this._tagWithTabIndex=new Array("A","AREA","BUTTON","INPUT","OBJECT","SELECT","TEXTAREA","IFRAME");
};
Telerik.Web.UI.ModalExtender.prototype={dispose:function(){
this.hide();
this._backgroundElement=null;
this._foregroundElement=null;
},show:function(){
this._attachWindowHandlers(true);
var _9b=this._getModalOverlay();
this._foregroundElement.parentNode.appendChild(_9b);
_9b.style.zIndex=$telerik.getCurrentStyle(this._foregroundElement,"zIndex",this._foregroundElement.style.zIndex)-1;
_9b.style.display="";
this._disableTab();
this._updatePageLayout();
this._updatePageLayout();
},_storeBrowserPosition:function(){
var _9c=document.body;
var _9d=document.documentElement;
this._browserTop=_9c.scrollTop>_9d.scrollTop?_9c.scrollTop:_9d.scrollTop;
this._browserLeft=_9c.scrollLeft>_9d.scrollLeft?_9c.scrollTop:_9d.scrollLeft;
},_restoreBrowserPosition:function(_9e,top){
try{
if(null==_9e){
_9e=this._browserLeft;
}
if(null==top){
top=this._browserTop;
}
var _a0=document.body;
var _a1=document.documentElement;
_a0.scrollTop=top;
_a0.scrollLeft=_9e;
_a1.scrollTop=top;
_a1.scrollLeft=_9e;
}
catch(ex){
}
},hide:function(){
this._backgroundElement.style.display="none";
this._restoreTab();
this._attachWindowHandlers(false);
},_enableScroll:function(_a2){
if(_a2){
document.body.style.overflow=null!=this._overflow?this._overflow:"";
document.documentElement.style.overflow=null!=this._documentOverflow?this._documentOverflow:"";
document.body.style.marginRight="";
}else{
this._overflow=document.body.style.overflow;
document.body.style.overflow="hidden";
this._documentOverflow=document.documentElement.style.overflow;
document.documentElement.style.overflow="hidden";
document.body.style.marginRight="18px";
}
},_getModalOverlay:function(){
if(!this._backgroundElement){
var div=document.createElement("div");
div.style.display="none";
div.style.position="absolute";
div.style.left="0px";
div.style.top="0px";
div.style.zIndex=10000;
div.style.backgroundColor="#aaaaaa";
div.style.filter="progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=50)";
div.style.opacity=".5";
div.style.mozOpacity=".5";
div.className="TelerikModalOverlay";
this._backgroundElement=div;
}
return this._backgroundElement;
},_attachWindowHandlers:function(_a4){
var _a5=window;
if(true==_a4){
this._windowResizeDelegate=Function.createDelegate(this,this._updatePageLayout);
$addHandler(_a5,"resize",this._windowResizeDelegate);
this._windowScrollDelegate=Function.createDelegate(this,this._updatePageLayout);
$addHandler(_a5,"scroll",this._windowScrollDelegate);
}else{
if(this._windowResizeDelegate){
$removeHandler(_a5,"resize",this._windowResizeDelegate);
}
this._windowResizeDelegate=null;
if(this._windowScrollDelegate){
$removeHandler(_a5,"scroll",this._windowScrollDelegate);
}
this._windowScrollDelegate=null;
}
},_updatePageLayout:function(){
var _a6=(document.documentElement.scrollLeft?document.documentElement.scrollLeft:document.body.scrollLeft);
var _a7=(document.documentElement.scrollTop?document.documentElement.scrollTop:document.body.scrollTop);
var _a8=$telerik.getClientBounds();
var _a9=_a8.width;
var _aa=_a8.height;
var _ab=this._getModalOverlay();
_ab.style.width=Math.max(Math.max(document.documentElement.scrollWidth,document.body.scrollWidth),_a9)+"px";
_ab.style.height=Math.max(Math.max(document.documentElement.scrollHeight,document.body.scrollHeight),_aa)+"px";
},_disableTab:function(){
var i=0;
var _ad;
var _ae=new Array();
Array.clear(this._saveTabIndexes);
for(var j=0;j<this._tagWithTabIndex.length;j++){
_ad=this._foregroundElement.getElementsByTagName(this._tagWithTabIndex[j]);
for(var k=0;k<_ad.length;k++){
_ae[i]=_ad[k];
i++;
}
}
i=0;
for(var j=0;j<this._tagWithTabIndex.length;j++){
_ad=document.getElementsByTagName(this._tagWithTabIndex[j]);
for(var k=0;k<_ad.length;k++){
if(Array.indexOf(_ae,_ad[k])==-1){
this._saveTabIndexes[i]={tag:_ad[k],index:_ad[k].tabIndex};
_ad[k].tabIndex="-1";
i++;
}
}
}
i=0;
if((Sys.Browser.agent===Sys.Browser.InternetExplorer)&&(Sys.Browser.version<7)){
var _b1=new Array();
for(var j=0;j<this._tagWithTabIndex.length;j++){
_ad=this._foregroundElement.getElementsByTagName("SELECT");
for(var k=0;k<_ad.length;k++){
_b1[i]=_ad[k];
i++;
}
}
i=0;
Array.clear(this._saveDesableSelect);
_ad=document.getElementsByTagName("SELECT");
for(var k=0;k<_ad.length;k++){
if(Array.indexOf(_b1,_ad[k])==-1){
this._saveDesableSelect[i]={tag:_ad[k],visib:$telerik.getCurrentStyle(_ad[k],"visibility")};
_ad[k].style.visibility="hidden";
i++;
}
}
}
},_restoreTab:function(){
for(var i=0;i<this._saveTabIndexes.length;i++){
this._saveTabIndexes[i].tag.tabIndex=this._saveTabIndexes[i].index;
}
if((Sys.Browser.agent===Sys.Browser.InternetExplorer)&&(Sys.Browser.version<7)){
for(var k=0;k<this._saveDesableSelect.length;k++){
this._saveDesableSelect[k].tag.style.visibility=this._saveDesableSelect[k].visib;
}
}
}};
Telerik.Web.UI.ModalExtender.registerClass("Telerik.Web.UI.ModalExtender",null);
Type.registerNamespace("Telerik.Web");
Telerik.Web.PositioningMode=function(){
throw Error.invalidOperation();
};
Telerik.Web.PositioningMode.prototype={Absolute:0,Center:1,BottomLeft:2,BottomRight:3,TopLeft:4,TopRight:5};
Telerik.Web.PositioningMode.registerEnum("Telerik.Web.PositioningMode");
Telerik.Web.PopupBehavior=function(_b4){
Telerik.Web.PopupBehavior.initializeBase(this,[_b4]);
this._x=0;
this._y=0;
this._positioningMode=Telerik.Web.PositioningMode.Absolute;
this._parentElement=null;
this._parentElementID=null;
this._moveHandler=null;
this._firstPopup=true;
this._originalParent=null;
this._overlay=false;
this._keepInScreenBounds=true;
this._manageVisibility=true;
};
Telerik.Web.PopupBehavior._ie6pinnedList={};
Telerik.Web.PopupBehavior.prototype={getPageOffset:function(){
var _b5={x:(document.documentElement.scrollLeft||document.body.scrollLeft),y:(document.documentElement.scrollTop||document.body.scrollTop)};
return _b5;
},pin:function(_b6){
var _b7=this.get_element();
var _b8=this.getPageOffset();
if($telerik.isIE6){
var id=this.get_id();
if(_b6){
if(Telerik.Web.PopupBehavior._ie6pinnedList[id]){
return;
}
var _ba=$telerik.getBounds(_b7);
Telerik.Web.PopupBehavior._ie6pinnedList[id]=window.setInterval(Function.createDelegate(this,function(){
var _bb=this.getPageOffset();
var x=_ba.x-_b8.x+_bb.x;
var y=_ba.y-_b8.y+_bb.y;
var _be=this.get_parentElement();
this.set_parentElement(document.documentElement);
this.set_x(x);
this.set_y(y);
this.show();
this.set_parentElement(_be);
}),130);
}else{
var _bf=Telerik.Web.PopupBehavior._ie6pinnedList[id];
if(_bf){
window.clearInterval(_bf);
}
delete Telerik.Web.PopupBehavior._ie6pinnedList[id];
}
}else{
var _c0=_b6?"fixed":"absolute";
if(_b7.style.position==_c0){
return;
}
var _ba=$telerik.getBounds(_b7);
if(_b6&&(_b8.x||_b8.y)){
this._x=_ba.x-_b8.x;
this._y=_ba.y-_b8.y;
$telerik.setLocation(_b7,{x:this._x,y:this._y});
}
_b7.style.position=_c0;
}
},center:function(){
var _c1=this.get_element();
if(this._manageVisibility){
$telerik.setVisible(_c1,true);
}
var _c2=$telerik.getClientBounds();
var _c3=$telerik.getBounds(_c1);
var x=parseInt((_c2.width-_c3.width)/2);
var y=parseInt((_c2.height-_c3.height)/2);
var _c6=this.get_parentElement();
this.set_parentElement(document.documentElement);
this.set_x(x);
this.set_y(y);
this.show();
this.set_parentElement(_c6);
},get_parentElement:function(){
if(!this._parentElement&&this._parentElementID){
this.set_parentElement($get(this._parentElementID));
Sys.Debug.assert(this._parentElement!=null,String.format("Couldn't find parent element \"{0}\"",this._parentElementID));
}
return this._parentElement;
},set_parentElement:function(_c7){
this._parentElement=_c7;
},get_parentElementID:function(){
if(this._parentElement){
return this._parentElement.id;
}
return this._parentElementID;
},set_parentElementID:function(_c8){
this._parentElementID=_c8;
if(this.get_isInitialized()){
this.set_parentElement($get(_c8));
}
},get_positioningMode:function(){
return this._positioningMode;
},set_positioningMode:function(_c9){
this._positioningMode=_c9;
},get_x:function(){
return this._x;
},set_x:function(_ca){
if(_ca!=this._x){
this._x=_ca;
if($telerik.getVisible(this.get_element())&&this._manageVisibility){
this.show();
}
}
},get_y:function(){
return this._y;
},set_y:function(_cb){
if(_cb!=this._y){
this._y=_cb;
if($telerik.getVisible(this.get_element())&&this._manageVisibility){
this.show();
}
}
},get_overlay:function(){
return this._overlay;
},set_overlay:function(_cc){
this._overlay=_cc;
this._attachWindowHandlers(false);
if(this._overlay){
this._attachWindowHandlers(true);
}else{
if(!((Sys.Browser.agent===Sys.Browser.InternetExplorer)&&(Sys.Browser.version<7))){
var elt=this.get_element();
var _ce=elt._hideWindowedElementsIFrame;
if(_ce){
_ce.style.display="none";
}
}
}
},get_manageVisibility:function(){
return this._manageVisibility;
},set_manageVisibility:function(_cf){
this._manageVisibility=_cf;
},get_keepInScreenBounds:function(){
return this._keepInScreenBounds;
},set_keepInScreenBounds:function(_d0){
this._keepInScreenBounds=_d0;
},hide:function(){
var elt=this.get_element();
if(this._manageVisibility){
$telerik.setVisible(elt,false);
}
if(elt.originalWidth){
elt.style.width=elt.originalWidth+"px";
elt.originalWidth=null;
}
if(Sys.Browser.agent===Sys.Browser.InternetExplorer||this._overlay){
var _d2=elt._hideWindowedElementsIFrame;
if(_d2){
_d2.style.display="none";
}
}
},show:function(){
var elt=this.get_element();
if($telerik.isFirefox){
var doc=document.documentElement;
var _d5=$telerik.getCurrentStyle(doc,"overflow");
if("hidden"==_d5){
elt.style.left=doc.scrollLeft+"px";
elt.style.top=doc.scrollLeft+"px";
}
}
if(this._manageVisibility){
$telerik.setVisible(elt,true);
}
var _d6=elt.offsetParent||document.documentElement;
var _d7;
var _d8;
if(this._parentElement){
_d8=$telerik.getBounds(this._parentElement);
if(_d6.tagName.toUpperCase()!="BODY"&&_d6.tagName.toUpperCase()!="HTML"){
var _d9=$telerik.getLocation(_d6);
_d7={x:_d8.x-_d9.x+_d6.scrollLeft,y:_d8.y-_d9.y+_d6.scrollTop};
}else{
_d7={x:_d8.x,y:_d8.y};
}
}else{
_d8=$telerik.getBounds(_d6);
_d7={x:0,y:0};
}
var _da=elt.offsetWidth-(elt.clientLeft?elt.clientLeft*2:0);
var _db=elt.offsetHeight-(elt.clientTop?elt.clientTop*2:0);
var _dc;
switch(this._positioningMode){
case Telerik.Web.PositioningMode.Center:
_dc={x:Math.round(_d8.width/2-_da/2),y:Math.round(_d8.height/2-_db/2)};
break;
case Telerik.Web.PositioningMode.BottomLeft:
_dc={x:0,y:_d8.height};
break;
case Telerik.Web.PositioningMode.BottomRight:
_dc={x:_d8.width-_da,y:_d8.height};
break;
case Telerik.Web.PositioningMode.TopLeft:
_dc={x:0,y:-elt.offsetHeight};
break;
case Telerik.Web.PositioningMode.TopRight:
_dc={x:_d8.width-_da,y:-elt.offsetHeight};
break;
default:
_dc={x:0,y:0};
}
_dc.x+=this._x+_d7.x;
_dc.y+=this._y+_d7.y;
$telerik.setLocation(elt,_dc);
if(this._firstPopup){
elt.style.width=_da+"px";
}
this._firstPopup=false;
var _dd=$telerik.getBounds(elt);
var _de=this._getViewportBounds();
if(this._keepInScreenBounds){
var _df=false;
var _e0=self.innerWidth?self.innerWidth:document.documentElement.clientWidth;
if(!_e0){
_e0=document.body.clientWidth;
}
if(_dd.x+_dd.width-_de.scrollLeft>_e0){
_dc.x-=_dd.x+_dd.width-_e0+_de.scrollLeft;
_df=true;
}
if(_dd.x<0){
_dc.x-=_dd.x;
_df=true;
}
if(_dd.y<0){
_dc.y-=_dd.y;
_df=true;
}
if(_de.height<_dd.y+_dd.height-_de.scrollTop){
if(_de.height-_dd.height>0){
_dc.y=_de.height-_dd.height+_de.scrollTop;
_df=true;
}
}
if(_df){
$telerik.setLocation(elt,_dc);
_dd=$telerik.getBounds(elt);
}
}
elt.zIndex=1000;
if(((Sys.Browser.agent===Sys.Browser.InternetExplorer)&&(Sys.Browser.version<7))||this._overlay){
var _e1=elt._hideWindowedElementsIFrame;
if(!_e1){
_e1=document.createElement("iframe");
_e1.src="javascript:'<html></html>';";
_e1.style.position="absolute";
_e1.style.display="none";
_e1.scrolling="no";
_e1.frameBorder="0";
_e1.tabIndex="-1";
_e1.style.filter="progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=0)";
elt.parentNode.insertBefore(_e1,elt);
elt._hideWindowedElementsIFrame=_e1;
this._moveHandler=Function.createDelegate(this,this._onMove);
Sys.UI.DomEvent.addHandler(elt,"move",this._moveHandler);
}
$telerik.setBounds(_e1,_dd);
if(Sys.Browser.agent===Sys.Browser.Firefox){
_e1.style.top=parseInt(_dd.y)-_de.scrollTop+"px";
_e1.style.left=parseInt(_dd.x)-_de.scrollLeft+"px";
_e1.style.position="fixed";
}
if($telerik.quirksMode){
return;
}
_e1.style.display=elt.style.display;
if(elt.currentStyle&&elt.currentStyle.zIndex){
_e1.style.zIndex=elt.currentStyle.zIndex;
}else{
if(elt.style.zIndex){
_e1.style.zIndex=elt.style.zIndex;
}
}
}
},_getViewportBounds:function(){
var _e2=$telerik.getClientBounds();
var _e3=document.documentElement.scrollLeft||document.body.scrollLeft;
var _e4=document.documentElement.scrollTop||document.body.scrollTop;
_e2.scrollLeft=_e3;
_e2.scrollTop=_e4;
return _e2;
},_setCoordinates:function(x,y){
var _e7=false;
if(x!=this._x){
this._x=x;
_e7=true;
}
if(y!=this._y){
this._y=y;
_e7=true;
}
if($telerik.getVisible(this.get_element())&&_e7&&this._manageVisibility){
this.show();
}
},initialize:function(){
Telerik.Web.PopupBehavior.callBaseMethod(this,"initialize");
this.hide();
this.get_element().style.position="absolute";
},dispose:function(){
var elt=this.get_element();
if(elt){
if(this._moveHandler){
Sys.UI.DomEvent.removeHandler(elt,"move",this._moveHandler);
this._moveHandler=null;
}
this._attachWindowHandlers(false);
if($telerik.getVisible(elt)&&this._manageVisibility){
this.hide();
}
if(this._originalParent){
elt.parentNode.removeChild(elt);
this._originalParent.appendChild(elt);
this._originalParent=null;
}
}
this._parentElement=null;
Telerik.Web.PopupBehavior.callBaseMethod(this,"dispose");
},_onMove:function(){
var elt=this.get_element();
var _ea=elt._hideWindowedElementsIFrame;
if(_ea){
if(Sys.Browser.agent===Sys.Browser.Firefox){
var _eb=this._getViewportBounds();
_ea.style.top=parseInt(elt.style.top)-_eb.scrollTop+"px";
_ea.style.left=parseInt(elt.style.left)-_eb.scrollLeft+"px";
_ea.style.position="fixed";
}else{
_ea.style.top=elt.style.top;
_ea.style.left=elt.style.left;
}
}
},_handleElementResize:function(){
var elt=this.get_element();
var _ed=elt._hideWindowedElementsIFrame;
if(_ed){
var _ee=$telerik.getBounds(elt);
$telerik.setBounds(_ed,_ee);
}
},_attachWindowHandlers:function(_ef){
if(!Sys.Browser.agent===Sys.Browser.Firefox){
return;
}
var _f0=window;
if(true==_ef){
this._windowResizeDelegate=Function.createDelegate(this,this._onMove);
$addHandler(_f0,"resize",this._windowResizeDelegate);
this._windowScrollDelegate=Function.createDelegate(this,this._onMove);
$addHandler(_f0,"scroll",this._windowScrollDelegate);
}else{
if(this._windowResizeDelegate){
$removeHandler(_f0,"resize",this._windowResizeDelegate);
}
this._windowResizeDelegate=null;
if(this._windowScrollDelegate){
$removeHandler(_f0,"scroll",this._windowScrollDelegate);
}
this._windowScrollDelegate=null;
}
}};
Telerik.Web.PopupBehavior.registerClass("Telerik.Web.PopupBehavior",Telerik.Web.BehaviorBase);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.ResizeExtender=function(_f1,_f2,_f3,_f4,doc,_f6){
this._document=doc?doc:document;
this._documentMouseMoveDelegate=null;
this._documentMouseUpDelegate=null;
this._element=null;
this._tableElement=null;
this._moveCursorType="move";
this._enabled=true;
this._jsOwner=null;
this._saveDelegates={};
this.makeResizable(_f1,_f2,_f3,_f4,_f6);
};
Telerik.Web.UI.ResizeExtender.containsBounds=function(_f7,_f8){
if(!_f7||!_f8){
return false;
}
var _f9=$telerik.containsPoint(_f7,_f8.x,_f8.y);
if(_f9){
var x=_f8.x+_f8.width;
var y=_f8.y+_f8.height;
_f9=$telerik.containsPoint(_f7,x,y);
}
return _f9;
};
Telerik.Web.UI.ResizeExtender.prototype={dispose:function(){
this._attachDocumentHandlers(false);
this._configureHandleElements(false);
this._jsOwner=null;
},enable:function(_fc){
this._enabled=_fc;
},makeResizable:function(_fd,_fe,_ff,_100,_101){
if(!_fe){
return;
}
if(this._element){
alert("Element "+_fe.getAttribute("id")+" cannot be made resizable, as the resizeExtender already has the element "+this._element.getAttribute("id")+" associated with it. You must create a new extender resizer object");
return;
}
this._jsOwner=_fd;
this._element=_fe;
this._tableElement=_100;
this._resizeHandles=_ff;
if(_101){
this._moveCursorType=_101;
}
this._startX=0;
this._startY=0;
this._cancelResize=true;
this._configureHandleElements(true);
},_raiseDragEvent:function(_102,ev,_104){
if(this._jsOwner&&this._jsOwner["on"+_102]){
var args=ev;
if(!args){
args={};
}
args.element=this._element;
args.ownerEvent=_104;
return this._jsOwner["on"+_102](args);
}
return true;
},_raiseEvent:function(_106,ev){
if(this._jsOwner&&this._jsOwner["on"+_106]){
if(!ev){
ev=new Sys.EventArgs();
}else{
if(_106=="Resize"){
ev=this._resizeDir;
}else{
if(_106=="Resizing"){
ev=this._getProposedBounds(ev);
}
}
}
return this._jsOwner["on"+_106](ev);
}
return true;
},_getProposedBounds:function(b1){
var b2=$telerik.getBounds(this._element);
return {x:b1.x||b2.x,y:b1.y||b2.y,width:b1.width||b2.width,height:b1.height||b2.height};
},_resize:function(e){
if(!this._enabled||this._cancelResize){
return false;
}
var _10b=0;
var _10c=0;
var _10d=0;
var nTop=0;
var _10f=this._originalBounds;
var _110=this._resizeDir.move;
if(_110){
_10d=_10f.x+(e.clientX-this._startX);
nTop=_10f.y+(e.clientY-this._startY);
}else{
if(this._resizeDir.east){
_10b=_10f.width+(e.clientX-this._startX);
}else{
if(this._resizeDir.west){
_10d=e.clientX-this._leftHandleMouseDelta;
_10b=_10f.width-(e.clientX-this._startX);
}
}
if(this._resizeDir.south){
_10c=_10f.height+(e.clientY-this._startY);
}else{
if(this._resizeDir.north){
nTop=e.clientY;
_10c=_10f.height-(e.clientY-this._startY);
}
}
}
if(this._offsetLocation){
_10d-=this._offsetLocation.x;
nTop-=this._offsetLocation.y;
}
var _111=new Sys.UI.Bounds(_10d,nTop,_10b,_10c);
var _112=_110?this._raiseDragEvent("Drag",_111,e):this._raiseEvent("Resizing",_111);
if(false==_112){
return true;
}
if(_110||_111.x>0){
this._element.style.left=_111.x+"px";
}
if(_110||_111.y>0){
this._element.style.top=_111.y+"px";
}
if(_111.width>0){
this._element.style.width=_111.width+"px";
}
if(_111.height>0){
this._element.style.height=_111.height+"px";
}
if(!_110){
this._updateInnerTableSize();
}
return true;
},_storeStartCoords:function(e){
if(!this._enabled){
return;
}
this._cancelResize=false;
this._startX=e.clientX;
this._startY=e.clientY;
var _114=$telerik.getBounds(this._element);
this._originalBounds=_114;
var _115=e.target?e.target:e.srcElement;
if(_115&&_115.type==3){
_115=_115.parentNode;
}
this._resizeType=$telerik.getCurrentStyle(_115,"cursor");
this._resizeDir={north:this._resizeType.match(/n.?-/)?1:0,east:this._resizeType.match(/e-/)?1:0,south:this._resizeType.match(/s.?-/)?1:0,west:this._resizeType.match(/w-/)?1:0,move:new RegExp(this._moveCursorType).test(this._resizeType)?1:0};
this._leftHandleMouseDelta=0;
if(this._resizeDir.west){
this._leftHandleMouseDelta=Math.abs($telerik.getBounds(_115).x-this._startX);
}
if(this._resizeDir.move){
var _116=this._raiseDragEvent("DragStart",null,e);
this._cancelResize=(_116==false);
}else{
this._raiseEvent("ResizeStart");
}
var _117=$telerik.getCurrentStyle(this._element.parentNode,"position");
var _118=("relative"==_117)||("absolute"==_117);
this._offsetLocation=_118?$telerik.getLocation(this._element.parentNode):null;
if(!this._cancelResize){
this._clearSelection();
this._setIframesVisible(false);
this._attachDocumentHandlers(false);
this._attachDocumentHandlers(true);
}
},_updateInnerTableSize:function(){
var dir=this._resizeDir;
if(dir.south||dir.north){
var _11a=this._element.style.height;
var _11b=this._tableElement;
if(_11b){
_11b.style.height=_11a;
this._fixIeHeight(_11b,_11a);
}
}
},_setIframesVisible:function(_11c){
var _11d=this._document.getElementsByTagName("IFRAME");
for(var i=0;i<_11d.length;i++){
_11d[i].style.visibility=_11c?"":"hidden";
}
},_configureHandleElements:function(_11f){
var _120=["nw","n","ne","w","e","sw","s","se",this._moveCursorType];
for(var i=0;i<_120.length;i++){
var _122=_120[i];
var _123=this._resizeHandles[_122];
if(_123){
if(_123 instanceof Array){
for(var j=0;j<_123.length;j++){
this._configureHandle("id"+i+"_"+j,_11f,_123[j],_122);
}
}else{
this._configureHandle("id"+i,_11f,_123,_122);
}
}
}
if(!_11f){
this._saveDelegates={};
}
},_configureHandle:function(_125,_126,_127,_128){
if(_126){
var _129=Function.createDelegate(this,this._onHandleMouseDown);
$telerik.addExternalHandler(_127,"mousedown",_129);
this._saveDelegates[_125]={delegate:_129,element:_127};
var _12a=(_128==this._moveCursorType?this._moveCursorType:_128+"-resize");
_127.style.cursor=_12a;
}else{
$telerik.removeExternalHandler(_127,"mousedown",this._saveDelegates[_125].delegate);
_127.style.cursor="";
}
},_attachDocumentHandlers:function(_12b){
var _12c=this._document;
if(true==_12b){
this._documentMouseMoveDelegate=Function.createDelegate(this,this._onDocumentMouseMove);
$telerik.addExternalHandler(_12c,"mousemove",this._documentMouseMoveDelegate);
this._documentMouseUpDelegate=Function.createDelegate(this,this._onDocumentMouseUp);
$telerik.addExternalHandler(_12c,"mouseup",this._documentMouseUpDelegate);
}else{
if(this._documentMouseMoveDelegate){
$telerik.removeExternalHandler(_12c,"mousemove",this._documentMouseMoveDelegate);
}
this._documentMouseMoveDelegate=null;
if(this._documentMouseUpDelegate){
$telerik.removeExternalHandler(_12c,"mouseup",this._documentMouseUpDelegate);
}
this._documentMouseUpDelegate=null;
}
},_onDocumentMouseMove:function(e){
var _12e=this._resize(e);
if(_12e){
return $telerik.cancelRawEvent(e);
}
},_onDocumentMouseUp:function(e){
var _130=!this._cancelResize;
this._cancelResize=true;
if(_130){
this._clearSelection();
this._setIframesVisible(true);
if(this._resizeDir&&this._resizeDir.move){
this._raiseDragEvent("DragEnd",null,e);
}else{
this._raiseEvent("ResizeEnd");
}
this._attachDocumentHandlers(false);
}
},_onHandleMouseDown:function(e){
this._storeStartCoords(e);
return $telerik.cancelRawEvent(e);
},_clearSelection:function(){
if(this._document.selection&&this._document.selection.empty){
this._document.selection.empty();
}
},_fixIeHeight:function(_132,_133){
if("CSS1Compat"==document.compatMode){
var _134=(_132.offsetHeight-parseInt(_133));
if(_134>0){
var _135=(parseInt(_132.style.height)-_134);
if(_135>0){
_132.style.height=_135+"px";
}
}
}
}};
Telerik.Web.UI.ResizeExtender.registerClass("Telerik.Web.UI.ResizeExtender",null);

