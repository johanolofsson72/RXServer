Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.DockMode=function(){
throw Error.notImplemented();
};
Telerik.Web.UI.DockMode.prototype={Floating:1,Docked:2,Default:3};
Telerik.Web.UI.DockMode.registerEnum("Telerik.Web.UI.DockMode");
Telerik.Web.UI.RadDock=function(_1){
Telerik.Web.UI.RadDock.initializeBase(this,[_1]);
this._initialized=false;
this._enableDrag=true;
this._top=0;
this._left=0;
this._autoPostBack=false;
this._dockZoneID=null;
this._title=null;
this._commands=null;
this._closed=false;
this._collapsed=false;
this._pinned=false;
this._index=0;
this._forbiddenZones=[];
this._layoutID=null;
this._handle=null;
this._dockMode=Telerik.Web.UI.DockMode.Default;
this._resizable=false;
this._width="300px";
this._height=null;
this._expandedHeight=0;
this._uniqueID=null;
this._uniqueName=null;
this._grip=null;
this._titleBar=null;
this._commandsContainer=null;
this._contentContainer=null;
this._handle=null;
this._form=null;
this._skin="Default";
this.set_handle=this.set_handle;
this._isCustomHandle=false;
};
Telerik.Web.UI.RadDock.DragDataType="RadDock";
Telerik.Web.UI.RadDock.prototype={_fixIeHeight:function(_2,_3){
if("CSS1Compat"==document.compatMode){
var _4=(_2.offsetHeight-parseInt(_3));
if(_4>0){
var _5=(parseInt(_2.style.height)-_4);
if(_5>0){
_2.style.height=_5+"px";
}
}
}
},_getTopElement:function(){
var _6=null;
var _7=this.get_titleBar();
if(_7){
_6=_7;
}else{
if(this._grip){
_6=this._grip;
}
}
return _6;
},_setResizeLimit:function(){
var _8=0;
var _9=this._getTopElement();
var _a=0;
if(_9){
var _b=$telerik.getBounds(_9);
_8+=_b.height;
}
var _c=this._calculateResizeHandlesSize();
var _d=this.get_element();
this._minHeight=_8+_c.horizontalHeight;
_d.style.minHeight=this._minHeight+"px";
this.get_innerDockElement().style.minHeight=_8+"px";
var _e=this.get_commandsContainer();
var _f=1+_c.verticalWidth;
var _10=_e?$telerik.getBounds(_e).width:0;
var _11=this.get_titleElement();
var _12=_11?$telerik.getMarginBox(_11).horizontal:0;
_f+=_10+_12;
this._minWidth=_f;
_d.style.minWidth=_f+"px";
},_calculateResizeHandlesSize:function(){
if(!this._tableElement){
return null;
}
var _13=this._tableElement.rows;
var _14={n:$telerik.getBounds(_13[0].cells[1]),w:$telerik.getBounds(_13[1].cells[0]),e:$telerik.getBounds(_13[1].cells[2]),s:$telerik.getBounds(_13[2].cells[1])};
var _15={horizontalHeight:_14.n.height+_14.s.height,verticalWidth:_14.w.width+_14.e.width};
return _15;
},_collapseWrapper:function(){
var _16=this._tableElement;
if(_16){
var _17=this.get_contentContainer();
var _18=$telerik.getBounds(_17);
var _19=parseInt(_16.style.height)-_18.height;
_16.style.height=(_19>0?_19:0)+"px";
}
},_removeWrapper:function(){
var _1a=this._tableElement;
if(_1a){
var _1b=this._calculateResizeHandlesSize();
var _1c=this.get_element();
var _1d=this.get_innerDockElement();
var _1e=this.get_topBorderElement();
var _1f=this.get_bottomBorderElement();
_1c.removeChild(_1a);
this._tableElement=null;
_1c.appendChild(_1d);
_1c.appendChild(_1e);
_1c.appendChild(_1f);
_1d.style.width="100%";
_1d.style.height="100%";
this._fixTableLayoutSize(this._width,this._height);
}
},_updateSizeValues:function(){
var _20=this._getBounds();
this._width=_20.width;
this._height=_20.height;
},_setWidthHtmlEl:function(_21,_22){
if(!_21){
return;
}
if(!_22){
_22=this.get_element();
}
if(_21.toString().indexOf("%")>-1){
_22.style.width=parseInt(_21)+"%";
}else{
_22.style.width=parseInt(_21)+"px";
}
},_setHeightHtmlEl:function(_23,_24){
if(!_23){
return;
}
if(!_24){
_24=this.get_element();
}
if(_23.toString().indexOf("%")>-1){
_24.style.height=parseInt(_23)+"%";
}else{
_24.style.height=parseInt(_23)+"px";
}
},_moveElements:function(_25,_26){
while(_25.childNodes&&_25.childNodes.length>0){
var _27=_25.childNodes[0];
_25.removeChild(_27);
_26.appendChild(_27);
}
},_configureHandles:function(_28){
if(!this._tableElement){
return;
}
var _29=["e","s","se"];
var _2a=this._resizeExtender._resizeHandles;
for(var i=0;i<_29.length;i++){
var _2c=_29[i];
var _2d=_2a[_2c];
if(_2d){
_2d.style.cursor=_28?_2c+"-resize":"";
}
}
},_getFullSkinName:function(){
return " raddock RadDock_"+this._skin+" rdVariableHeight";
},_createResizeWrapper:function(){
var _2e=document.createElement("TABLE");
_2e.id=this.get_id()+"Table";
_2e.className="rdWrapTable";
_2e.width="100%";
_2e.height="100%";
_2e.cellSpacing=0;
_2e.cellPadding=0;
this._tableElement=_2e;
var _2f=["rdTopLeft","rdTopCenter","rdTopRight","rdLeftMiddle","rdCenter","rdRightMiddle","rdBottomLeft","rdBottomCenter","rdBottomRight"];
var _30=0;
for(var i=0;i<3;i++){
var row=_2e.insertRow(-1);
for(var j=0;j<3;j++){
var _34=row.insertCell(-1);
_34.innerHTML="&nbsp;";
_34.className=_2f[_30];
_30++;
}
}
return _2e;
},_fixEmWidth:function(){
if(!this.get_titleBar()){
return;
}
var _35=$telerik.getBounds(this.get_innerDockElement()).width;
var _36=this.get_commandsContainer();
var _37=_36?$telerik.getBounds(_36).width:0;
var _38=this.get_titleElement();
if(_38){
var _39=_35-_37-$telerik.getMarginBox(_38).horizontal;
if($telerik.isSafari){
_39=_35-_37-30;
}
var _3a=_39>0?_39:0;
this._setWidthHtmlEl(_3a,_38);
}
},_enableMoveResize:function(){
if(this._resizeExtender){
this._resizeExtender.dispose();
}
var _3b={};
if(this._resizable){
var _3c=this.get_element();
if(!this._tableElement){
var _3d=this._createResizeWrapper();
var _3e=_3d.rows[1].cells[1];
_3e.innerHTML="";
this._moveElements(_3c,_3e);
_3c.appendChild(_3d);
}
var _3f=this._tableElement.rows;
_3b={e:_3f[1].cells[2],s:_3f[2].cells[1],se:_3f[2].cells[2]};
}else{
this._removeWrapper();
}
if(this._handle&&this.get_enableDrag()&&!this.get_pinned()){
_3b["move"]=this._handle;
}
this._resizeExtender=new Telerik.Web.UI.ResizeExtender(this,this.get_element(),_3b,this._tableElement);
if(this._resizable){
this._setResizeLimit();
this._setSize();
if(this._collapsed||this._dockZoneID){
this._configureHandles(false);
}
}
},_makeResizable:function(){
this._enableMoveResize();
},onResizeStart:function(){
if(this._collapsed||this._dockZoneID){
return;
}
this.get_contentContainer().style.display="none";
this.raise_resizeStart(new Sys.EventArgs());
},onResizing:function(e){
if(this._collapsed||this._dockZoneID){
return false;
}
var _41=this.get_innerDockElement();
_41.style.display="none";
var _42=$telerik.getBounds(_41.parentNode).width;
_41.style.display="";
this._setWidthHtmlEl(_42,_41);
_41.style.width="auto";
this._fixEmWidth();
},onResizeEnd:function(){
if(this._collapsed||this._dockZoneID){
return;
}
var _43=this._getBounds();
var _44=_43.width;
var _45=_43.height;
if(_44<this._minWidth){
_44=this._minWidth;
}
if(_45<this._minHeight){
_45=this._minHeight;
}
this._setSize(_44,_45);
this._updateSizeValues();
this.updateClientState();
this.raise_resizeEnd(new Sys.EventArgs());
},_initializeDrag:function(){
if(this._handle){
this._disposeDrag();
if(this.get_enableDrag()&&!this.get_pinned()){
Sys.UI.DomElement.addCssClass(this._handle,"rdDraggable");
this._enableMoveResize();
}else{
if(this._resizable){
this._enableMoveResize();
}
}
}
},_disposeDrag:function(){
if(this._handle&&this._resizeExtender){
this._resizeExtender.dispose();
this._resizeExtender=null;
Sys.UI.DomElement.removeCssClass(this._handle,"rdDraggable");
}
},_startDragDrop:function(){
var _46=this.get_element();
this.originalZIndex=_46.style.zIndex;
var _47=this._getBounds(_46);
var _48=this._getBorderBox(_46);
_47.width-=_48.horizontal;
_47.height-=_48.vertical;
_46.style.width=_47.width+"px";
_46.style.zIndex="9999999";
var _49=$telerik.getLocation(_46);
this._form.appendChild(_46);
var _4a=$find(this.get_dockZoneID());
if(_4a){
_4a._showPlaceholder(this,_49);
}
this._setLocation(_49);
},onDragStart:function(){
if(!this.get_enableDrag()||this.get_pinned()){
return false;
}
this.get_contentContainer().style.overflow="hidden";
this._startDragDrop();
var _4b=this.get_element();
this.raise_dragStart(new Sys.EventArgs());
return true;
},onDrag:function(_4c){
this._hitZone=this.dockingZoneHitTest(_4c,_4c.ownerEvent);
this.raise_drag(new Sys.EventArgs());
},onDragEnd:function(_4d){
var _4e=this._hitZone;
if(!_4e){
var _4f=this._getBounds();
var _50={x:_4f.x,y:_4f.y};
_4e=this._hitZone=this.dockingZoneHitTest(_50,_4d.ownerEvent);
}
if(_4e){
if(_4e.canDrop(this)){
_4e.drop(this);
}else{
this._restorePosition();
}
}else{
if(this.canDrop()){
this.drop();
}else{
this._restorePosition();
}
}
this.get_contentContainer().style.overflow="auto";
this.raise_dragEnd(new Sys.EventArgs());
},get_dockZones:function(){
if(typeof (Telerik.Web.UI.RadDockZonesGlobalArray)=="undefined"){
return [];
}
return Telerik.Web.UI.RadDockZonesGlobalArray;
},dockingZoneHitTest:function(_51,e){
var _53;
var _54=null;
var _55=this.get_dockZones();
for(var i=0;i<_55.length;i++){
_53=_55[i];
if(_53.hitTest(this,_51,e)){
_54=_53;
}
}
return _54;
},canDrop:function(){
return (this.get_dockMode()&Telerik.Web.UI.DockMode.Floating)>0;
},drop:function(){
var _57=new Sys.CancelEventArgs();
this.raise_dockPositionChanging(_57);
this.get_element().style.zIndex=this.originalZIndex;
if(_57.get_cancel()){
this._restorePosition();
}else{
this.undock();
this.raise_dockPositionChanged(new Sys.EventArgs());
}
},getCommand:function(_58){
return this._commands?this._commands[_58]:null;
},get_handle:function(){
return this._handle;
},set_handle:function(_59){
this._isCustomHandle=true;
this._setHandle(_59);
},_setHandle:function(_5a){
this._disposeDrag();
this._handle=_5a;
this._initializeDrag();
},_repaintHelper:function(){
if(this.get_closed()){
return;
}
this._setContentContainerHeight();
this._setCommandsContainerWidth();
},getInvisibleParent:function(_5b){
while(_5b!=document){
if("none"==$telerik.getCurrentStyle(_5b,"display","")){
return _5b;
}
_5b=_5b.parentNode;
}
return null;
},subtractPoints:function(p1,p2){
return {x:p1.x-p2.x,y:p1.y-p2.y};
},addPoints:function(p1,p2){
return {x:p1.x+p2.x,y:p1.y+p2.y};
},initialize:function(){
Telerik.Web.UI.RadDock.callBaseMethod(this,"initialize");
this._initializeHtmlElementVariables();
this._initializeCommands();
this._updateToggleCommandsState();
this._setPinUnpinVisibility();
this._setHandle(this._titleBar||this._grip);
var _60=this.get_commandsContainer();
this._commandsContainerWidth=_60?$telerik.getBounds(_60).width:0;
var _61=this.get_element();
var _62=_61.parentNode;
var _63=this.getInvisibleParent(this.get_element());
isHidden=(_63!=null);
if(isHidden){
var _64={position:_61.style.position,top:_61.style.top,left:_61.style.left};
_61.parentNode.removeChild(_61);
_61.style.position="absolute";
_61.style.top="-5000px";
_61.style.left="-5000px";
document.body.appendChild(_61);
}
this._makeResizable();
this._setContentContainerHeight();
if(isHidden){
_61.style.position=_64.position;
_61.style.top=_64.top;
_61.style.left=_64.left;
_61.parentNode.removeChild(_61);
_62.appendChild(_61);
}
this._initialized=true;
this.updateClientState();
this.raise_initialize();
},undock:function(){
var _65=this.get_element();
this._form.appendChild(_65);
var _66=this._getLocation(_65);
this.set_left(_66.x);
this.set_top(_66.y);
var _67=$find(this.get_dockZoneID());
if(_67){
this.set_dockZoneID("");
_67._resetDockIndices();
this._unfitWidth();
}
this._setPinUnpinVisibility();
this.updateClientState();
},_fitWidth:function(){
this.get_element().style.width="100%";
if(this._tableElement){
this.get_innerDockElement().style.width="100%";
this._tableElement.style.width="100%";
this._fixEmWidth();
}
},_unfitWidth:function(){
this.set_width(this.get_width());
if(this._tableElement){
this._fixEmWidth();
}
},_initializeHtmlElementVariables:function(){
this._grip=$get(this.get_id()+"_G");
this._titleBar=$get(this.get_id()+"_T");
if(this._titleBar){
var _68=this._titleBar.lastChild;
while(_68){
if(_68.className=="rdCommands"){
this._commandsContainer=_68;
break;
}
_68=_68.previousSibling;
}
}
var _69=this.get_element().parentNode;
while(_69){
if(_69.tagName.toLowerCase()==="form"){
this._form=_69;
break;
}
_69=_69.parentNode;
}
},_initializeCommands:function(){
if(!this._commandsContainer){
return;
}
var _6a=this._commandsContainer.getElementsByTagName("a");
var _6b=this._commands;
if(_6b){
this._commands={};
for(var i=0;i<_6b.length;i++){
var _6d=_6b[i];
var _6e=eval(_6d.clientTypeName);
if(_6e==Telerik.Web.UI.DockCommand||_6e.inheritsFrom(Telerik.Web.UI.DockCommand)){
_6d.radDock=this;
var _6f=null;
if(_6d.command){
_6f={"command":eval(_6d.command)};
delete _6d.command;
}
var cmd=$create(_6e,_6d,_6f,null,_6a[i]);
this._commands[cmd.get_name()]=cmd;
}else{
throw Error.invalidOperation(_6d.clientTypeName+" does not inherit from Telerik.Web.UI.DockCommand.");
}
}
}
},_updateToggleCommandsState:function(){
var _71=this.getCommand("ExpandCollapse");
if(_71){
_71.set_state(this.get_collapsed()?2:1);
}
var _72=this.getCommand("PinUnpin");
if(_72){
_72.set_state(this.get_pinned()?2:1);
}
},_setPinUnpinVisibility:function(){
var _73=this.getCommand("PinUnpin");
if(_73){
_73.get_element().style.display=this.get_dockZoneID()?"none":"inline";
}
this._setCommandsContainerWidth();
},_setCommandsContainerWidth:function(){
if(!this._commandsContainer){
return;
}
var _74=this._commandsContainer.getElementsByTagName("a");
var _75=0;
for(var i=0;i<_74.length;i++){
var _77=this._getBoundsWithBorderAndMargin(_74[i]);
_75+=_77.width;
}
this._commandsContainer.style.width=_75+"px";
},_getBoundsWithoutBorder:function(_78){
if(!_78){
_78=this.get_element();
}
var _79=this._getBounds(_78);
var _7a=this._getBorderBox(_78);
var _7b=_79.width-_7a.horizontal;
var _7c=_79.height-_7a.vertical;
_79.width=_7b>0?_7b:0;
_79.height=_7c>0?_7c:0;
return _79;
},_getBoundsWithBorderAndMargin:function(_7d){
if(!_7d){
_7d=this.get_element();
}
var _7e=this._getBounds(_7d);
var _7f=this._getMarginBox(_7d);
var _80=this._getBorderBox(_7d);
_7e.width+=(_7f.horizontal+_80.horizontal);
_7e.height+=(_7f.vertical+_80.vertical);
return _7e;
},_getBounds:function(_81){
if(!_81){
_81=this.get_element();
}
return $telerik.getBounds(_81);
},_getMarginBox:function(_82){
if(!_82){
_82=this.get_element();
}
return $telerik.getMarginBox(_82);
},_getBorderBox:function(_83){
if(!_83){
_83=this.get_element();
}
return $telerik.getBorderBox(_83);
},_resetPosition:function(){
var _84=this.get_element();
_84.style.top="";
_84.style.left="";
_84.originalPosition="relative";
_84.style.position="relative";
_84.style.zIndex=this.originalZIndex;
},_setContentContainerHeight:function(){
var _85=this.get_contentContainer();
if(!_85){
return;
}
if(!Sys.UI.DomElement.containsCssClass(this.get_element(),"rdVariableHeight")||this._resizable){
var _86=this._getBounds();
var _87=this.get_handle();
if(_87&&!this._isCustomHandle){
var _88=this._getBounds(_87);
_86.height-=_88.height;
}
var _89=this._tableElement?this._calculateResizeHandlesSize().horizontalHeight:2;
var _8a=$telerik.getPaddingBox(_85).vertical;
var _8b=_86.height-_89-_8a;
_85.style.height=(_8b<0?0:_8b)+"px";
}else{
_85.style.height="";
}
},_restorePosition:function(){
var _8c=$find(this.get_dockZoneID());
if(_8c){
_8c.dock(this,this.get_index());
}else{
this.undock();
}
},_getLocation:function(_8d){
if(!_8d){
_8d=this.get_element();
}
return $telerik.getLocation(_8d);
},_setLocation:function(_8e){
$telerik.setLocation(this.get_element(),_8e);
},_setSize:function(_8f,_90){
var _91=this._getBoundsWithoutBorder();
if(!_8f){
_8f=_91.width;
}
if(!_90){
_90=_91.height;
}
this._setWidthHtmlEl(_8f);
this._setHeightHtmlEl(_90);
if(this._tableElement){
this._fixTableLayoutSize(_8f,_90);
}else{
this._setContentContainerHeight();
}
},_fixTableLayoutSize:function(_92,_93){
var _94=this.get_contentContainer();
var _95=$telerik.getPaddingBox(_94).vertical;
var _96=this._getTopElement();
var _97={height:0,width:0};
var _98=0;
if(_96){
_97=$telerik.getBounds(_96);
}
var _99=this.get_innerDockElement();
_99.style.display="none";
var _9a=this._tableElement;
if(_9a){
this._setHeightHtmlEl(_93,_9a);
this._fixIeHeight(_9a,_93);
}
var _9b=$telerik.getBounds(_99.parentNode);
var _92=_9b.width;
if(!this._tableElement){
_92-=this._getBorderBox(_99).horizontal;
}
this._setWidthHtmlEl(_92,_99);
var _9c=_9b.height-_97.height-_95;
_9c=_9c>0?_9c:0;
this._setHeightHtmlEl(_9c,_94);
if(_9c>0){
_94.style.display="";
}
_99.style.display="";
this._fixEmWidth();
if(this._collapsed){
_99.style.height="auto";
}
},get_contentContainer:function(){
if(!this._contentContainer){
this._contentContainer=$get(this.get_id()+"_C");
}
return this._contentContainer;
},get_titleBar:function(){
if(!this._titleBar){
this._titleBar=$get(this.get_id()+"_T");
}
return this._titleBar;
},get_commandsContainer:function(){
if(!this._commandsContainer){
var _9d=this.get_titleBar();
if(_9d){
this._commandsContainer=_9d.getElementsByTagName("span")[0];
}else{
this._commandsContainer=null;
}
}
return this._commandsContainer;
},get_titleElement:function(){
if(!this._titleElement){
var _9e=this.get_titleBar();
this._titleElement=_9e?_9e.getElementsByTagName("em")[0]:null;
}
return this._titleElement;
},get_innerDivElement:function(num){
var _a0=this._tableElement;
if(_a0){
if(_a0.rows.length>1){
var _a1=_a0.rows[1].cells[1];
if(_a1){
return _a1.getElementsByTagName("div")[num];
}
}
}
return this.get_element().getElementsByTagName("div")[num];
},get_innerDockElement:function(){
return this.get_innerDivElement(0);
},get_topBorderElement:function(){
return this.get_innerDivElement(3);
},get_bottomBorderElement:function(){
return this.get_innerDivElement(4);
},saveClientState:function(){
var _a2={Top:this.get_top(),Left:this.get_left(),DockZoneID:this.get_dockZoneID(),Collapsed:this.get_collapsed(),Pinned:this.get_pinned(),Resizable:this.get_resizable(),Closed:this.get_closed(),Width:this.get_width(),Height:this.get_height(),ExpandedHeight:this._expandedHeight,Index:this.get_index()};
return Sys.Serialization.JavaScriptSerializer.serialize(_a2);
},conditionalPostback:function(_a3){
if(this.get_autoPostBack()){
this.doPostBack(_a3);
}
},doPostBack:function(_a4){
__doPostBack(this.get_uniqueID(),_a4);
},add_command:function(_a5){
this.get_events().addHandler("command",_a5);
},remove_command:function(_a6){
this.get_events().removeHandler("command",_a6);
},raise_command:function(_a7){
this.raiseEvent("command",_a7);
},add_dragStart:function(_a8){
this.get_events().addHandler("dragStart",_a8);
},remove_dragStart:function(_a9){
this.get_events().removeHandler("dragStart",_a9);
},raise_dragStart:function(_aa){
this.raiseEvent("dragStart",_aa);
},add_drag:function(_ab){
this.get_events().addHandler("drag",_ab);
},remove_drag:function(_ac){
this.get_events().removeHandler("drag",_ac);
},raise_drag:function(_ad){
this.raiseEvent("drag",_ad);
},add_dragEnd:function(_ae){
this.get_events().addHandler("dragEnd",_ae);
},remove_dragEnd:function(_af){
this.get_events().removeHandler("dragEnd",_af);
},raise_dragEnd:function(_b0){
this.raiseEvent("dragEnd",_b0);
},add_dockPositionChanged:function(_b1){
this.get_events().addHandler("dockPositionChanged",_b1);
},remove_dockPositionChanged:function(_b2){
this.get_events().removeHandler("dockPositionChanged",_b2);
},raise_dockPositionChanged:function(_b3){
this.raiseEvent("dockPositionChanged",_b3);
this.conditionalPostback("dockPositionChanged");
},add_dockPositionChanging:function(_b4){
this.get_events().addHandler("dockPositionChanging",_b4);
},remove_dockPositionChanging:function(_b5){
this.get_events().removeHandler("dockPositionChanging",_b5);
},raise_dockPositionChanging:function(_b6){
this.raiseEvent("dockPositionChanging",_b6);
},add_initialize:function(_b7){
this.get_events().addHandler("initialize",_b7);
},remove_initialize:function(_b8){
this.get_events().removeHandler("initialize",_b8);
},raise_initialize:function(_b9){
this.raiseEvent("initialize",_b9);
},add_resizeStart:function(_ba){
this.get_events().addHandler("resizeStart",_ba);
},remove_resizeStart:function(_bb){
this.get_events().removeHandler("resizeStart",_bb);
},raise_resizeStart:function(_bc){
this.raiseEvent("resizeStart",_bc);
},add_resizeEnd:function(_bd){
this.get_events().addHandler("resizeEnd",_bd);
},remove_resizeEnd:function(_be){
this.get_events().removeHandler("resizeEnd",_be);
},raise_resizeEnd:function(_bf){
this.raiseEvent("resizeEnd",_bf);
},get_top:function(){
return this._top;
},set_top:function(_c0){
if(_c0!=""){
_c0=parseInt(_c0);
if(this._initialized){
this.get_element().style.top=_c0+"px";
}
}
this._top=_c0;
this.updateClientState();
},get_left:function(){
return this._left;
},set_left:function(_c1){
if(_c1!=""){
_c1=parseInt(_c1);
if(this._initialized){
this.get_element().style.left=_c1+"px";
}
}
this._left=_c1;
this.updateClientState();
},get_closed:function(){
return this._closed;
},set_closed:function(_c2){
this._closed=_c2;
var _c3=this.get_element();
_c3.style.display=_c2?"none":"block";
if(!_c2){
this._repaintHelper();
$telerik.repaintChildren(this);
}
},get_collapsed:function(){
return this._collapsed;
},set_collapsed:function(_c4){
this._collapsed=_c4;
_c4?this.get_element().style.height="auto":this._setHeightHtmlEl(this.get_height());
if(this._collapsed){
this._collapseWrapper();
if(this._height){
this._expandedHeight=parseInt(this._height);
}
if(this._resizable){
this.get_innerDockElement().style.height="auto";
}
this._configureHandles(false);
this.addCssClass("rdCollapsed");
}else{
this.removeCssClass("rdCollapsed");
if(this._resizable){
if(this._expandedHeight==0){
this.get_element().style.height="auto";
this._tableElement.style.height="100%";
this.get_contentContainer().style.height="auto";
}
if(!this._dockZoneID){
this._configureHandles(true);
}
this.get_innerDockElement().style.height="";
this._setSize(null,this._expandedHeight);
this._height=this._expandedHeight;
}
if(this.get_height()==null){
this.addCssClass("rdVariableHeight");
}
}
if($telerik.isIE){
setTimeout(Function.createDelegate(this,function(){
this._setContentContainerHeight();
}),0);
}else{
this._setContentContainerHeight();
}
if(!this._collapsed){
$telerik.repaintChildren(this);
}
var _c5=this.getCommand("ExpandCollapse");
if(_c5){
_c5.set_state(_c4?2:1);
}
if(this._resizable){
this._height=$telerik.getBounds(this.get_element()).height+"px";
this.updateClientState();
}
},get_autoPostBack:function(){
return this._autoPostBack;
},set_autoPostBack:function(_c6){
this._autoPostBack=_c6;
},get_commands:function(){
return this._commands;
},set_commands:function(_c7){
this._commands=_c7;
},get_dockMode:function(){
return this._dockMode;
},set_dockMode:function(_c8){
this._dockMode=_c8;
},get_dockZoneID:function(){
return this._dockZoneID;
},set_dockZoneID:function(_c9){
if(_c9==""){
if(!this._collapsed){
this._configureHandles(true);
}
}else{
this._configureHandles(false);
}
this._dockZoneID=_c9;
},get_forbiddenZones:function(){
return this._forbiddenZones;
},set_forbiddenZones:function(_ca){
this._forbiddenZones=_ca;
},get_height:function(){
return this._height;
},set_height:function(_cb){
this._height=_cb;
this.updateClientState();
if(this._initialized){
this._setSize(null,_cb);
if(!this._tableElement){
this.removeCssClass("rdVariableHeight");
}
}
},get_index:function(){
return this._index;
},set_index:function(_cc){
this._index=_cc;
},get_layoutID:function(){
return this._layoutID;
},set_layoutID:function(_cd){
this._layoutID=_cd;
},get_enableDrag:function(){
return this._enableDrag;
},set_enableDrag:function(_ce){
this._enableDrag=_ce;
this._initializeDrag();
},get_pinned:function(){
return this._pinned;
},set_pinned:function(_cf){
this._pinned=_cf;
var _d0=this.getCommand("PinUnpin");
if(_d0){
_d0.set_state(_cf?2:1);
}
if($telerik.isIE6){
if(_cf){
this.set_enableDrag(false);
}else{
this.set_enableDrag(true);
}
return;
}
var _d1=this.get_element();
_d1.style.position="absolute";
var _d2=$telerik.getScrollOffset(_d1,true);
var _d3=this._getLocation(_d1);
if(_cf){
_d3=this.subtractPoints(_d3,_d2);
this._setLocation(_d3);
_d1.style.position="fixed";
this.set_enableDrag(false);
}else{
_d3=this.addPoints(_d3,_d2);
this._setLocation(_d3);
this.set_enableDrag(true);
}
},get_title:function(){
return this._title;
},set_title:function(_d4){
this._title=_d4;
var _d5=this.get_titleElement();
if(_d5){
_d5.innerHTML=_d4;
}
},get_uniqueID:function(){
return this._uniqueID;
},set_uniqueID:function(_d6){
this._uniqueID=_d6;
},get_uniqueName:function(){
return this._uniqueName;
},set_uniqueName:function(_d7){
this._uniqueName=_d7;
},get_width:function(){
return this._width;
},set_width:function(_d8){
this._width=_d8;
this.updateClientState();
if(this._initialized){
this._setSize(_d8,null);
}
},get_skin:function(){
return this._skin;
},set_skin:function(_d9){
if(_d9&&this._skin!=_d9){
this._skin=_d9;
}
},get_resizable:function(){
return this._resizable;
},set_resizable:function(_da){
this._resizable=_da;
if(_da){
this._makeResizable();
}else{
this._removeWrapper();
}
}};
Telerik.Web.UI.RadDock.registerClass("Telerik.Web.UI.RadDock",Telerik.Web.UI.RadWebControl,Telerik.Web.IDragSource);
Telerik.Web.UI.RadDock.prototype.repaint=function(){
this._repaintHelper();
};
Telerik.Web.UI.DockCommand=function(_db){
Telerik.Web.UI.DockCommand.initializeBase(this,[_db]);
this._clientTypeName=null;
this._cssClass="rdCustom";
this._radDock=null;
this._name="Custom";
this._text="Custom";
this._autoPostBack=false;
};
Telerik.Web.UI.DockCommand.prototype={add_command:function(_dc){
this.get_events().addHandler("command",_dc);
},remove_command:function(_dd){
this.get_events().removeHandler("command",_dd);
},raise_command:function(_de){
var _df=this.get_events().getHandler("command");
if(_df){
_df(this.get_radDock(),_de);
}
},get_clientTypeName:function(){
return this._clientTypeName;
},set_clientTypeName:function(_e0){
this._clientTypeName=_e0;
},get_cssClass:function(){
return this._cssClass;
},set_cssClass:function(_e1){
this._cssClass=_e1;
},get_name:function(){
return this._name;
},set_name:function(_e2){
this._name=_e2;
},get_text:function(){
return this._text;
},set_text:function(_e3){
this._text=_e3;
},get_autoPostBack:function(){
return this._autoPostBack;
},set_autoPostBack:function(_e4){
this._autoPostBack=_e4;
},get_radDock:function(){
return this._radDock;
},set_radDock:function(_e5){
this._radDock=_e5;
},onCommand:function(e){
var _e7=new Sys.CancelEventArgs();
_e7.command=this;
_e7.event=e;
_e7.Command=this;
this.raise_command(_e7);
if(_e7.get_cancel()){
return;
}
this.get_radDock().raise_command(_e7);
if(_e7.get_cancel()){
return;
}
this.get_radDock().updateClientState();
this.conditionalPostback();
},onMouseDown:function(e){
$telerik.cancelRawEvent(e);
},conditionalPostback:function(){
if(this.get_autoPostBack()){
this.get_radDock().doPostBack(this.get_name());
}
},initialize:function(){
Telerik.Web.UI.DockCommand.callBaseMethod(this,"initialize");
$addHandlers(this.get_element(),{"click":this.onCommand,"mousedown":this.onMouseDown},this);
},dispose:function(){
$clearHandlers(this.get_element());
Telerik.Web.UI.DockCommand.callBaseMethod(this,"dispose");
}};
Telerik.Web.UI.DockCommand.registerClass("Telerik.Web.UI.DockCommand",Sys.UI.Control);
Telerik.Web.UI.DockToggleCommand=function(_e9){
Telerik.Web.UI.DockToggleCommand.initializeBase(this,[_e9]);
this._state=1;
this._alternateCssClass="rdCustom";
this._alternateText="Custom";
this._initialSetState=false;
};
Telerik.Web.UI.DockToggleCommand.prototype={updateState:function(){
var _ea=this.get_element();
if(this.get_state()==1){
_ea.title=this.get_text();
Sys.UI.DomElement.addCssClass(_ea,this.get_cssClass());
Sys.UI.DomElement.removeCssClass(_ea,this.get_alternateCssClass());
}else{
_ea.title=this.get_alternateText();
Sys.UI.DomElement.addCssClass(_ea,this.get_alternateCssClass());
Sys.UI.DomElement.removeCssClass(_ea,this.get_cssClass());
}
},get_state:function(){
return this._state;
},set_state:function(_eb){
this._state=_eb;
if(this._initialSetState){
this.updateState();
}
},get_alternateCssClass:function(){
return this._alternateCssClass;
},set_alternateCssClass:function(_ec){
this._alternateCssClass=_ec;
},get_alternateText:function(){
return this._alternateText;
},set_alternateText:function(_ed){
this._alternateText=_ed;
},initialize:function(){
Telerik.Web.UI.DockToggleCommand.callBaseMethod(this,"initialize");
this._initialSetState=true;
this.updateState();
},dispose:function(){
Telerik.Web.UI.DockToggleCommand.callBaseMethod(this,"dispose");
}};
Telerik.Web.UI.DockToggleCommand.registerClass("Telerik.Web.UI.DockToggleCommand",Telerik.Web.UI.DockCommand);
Telerik.Web.UI.DockCloseCommand=function(_ee){
Telerik.Web.UI.DockCloseCommand.initializeBase(this,[_ee]);
this._cssClass="rdClose";
this._name="Close";
this._text="Close";
};
Telerik.Web.UI.DockCloseCommand.prototype={onCommand:function(e){
this.get_radDock().set_closed(true);
Telerik.Web.UI.DockCloseCommand.callBaseMethod(this,"onCommand");
}};
Telerik.Web.UI.DockCloseCommand.registerClass("Telerik.Web.UI.DockCloseCommand",Telerik.Web.UI.DockCommand);
Telerik.Web.UI.DockExpandCollapseCommand=function(_f0){
Telerik.Web.UI.DockExpandCollapseCommand.initializeBase(this,[_f0]);
this._cssClass="rdCollapse";
this._alternateCssClass="rdExpand";
this._name="ExpandCollapse";
this._text="Collapse";
this._alternateText="Expand";
};
Telerik.Web.UI.DockExpandCollapseCommand.prototype={onCommand:function(e){
this.get_radDock().set_collapsed(!this.get_radDock().get_collapsed());
Telerik.Web.UI.DockExpandCollapseCommand.callBaseMethod(this,"onCommand");
}};
Telerik.Web.UI.DockExpandCollapseCommand.registerClass("Telerik.Web.UI.DockExpandCollapseCommand",Telerik.Web.UI.DockToggleCommand);
Telerik.Web.UI.DockPinUnpinCommand=function(_f2){
Telerik.Web.UI.DockPinUnpinCommand.initializeBase(this,[_f2]);
this._cssClass="rdUnpin";
this._alternateCssClass="rdPin";
this._name="PinUnpin";
this._text="Pin";
this._alternateText="Unpin";
};
Telerik.Web.UI.DockPinUnpinCommand.prototype={onCommand:function(e){
this.get_radDock().set_pinned(!this.get_radDock().get_pinned());
Telerik.Web.UI.DockPinUnpinCommand.callBaseMethod(this,"onCommand");
}};
Telerik.Web.UI.DockPinUnpinCommand.registerClass("Telerik.Web.UI.DockPinUnpinCommand",Telerik.Web.UI.DockToggleCommand);

