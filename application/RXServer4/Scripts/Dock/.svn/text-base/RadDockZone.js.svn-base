Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadDockZonesGlobalArray=[];
Telerik.Web.UI.registerRadDockZone=function(_1){
if(!Array.contains(this.RadDockZonesGlobalArray,_1)){
Array.add(this.RadDockZonesGlobalArray,_1);
}
};
Telerik.Web.UI.unregisterRadDockZone=function(_2){
Array.remove(this.RadDockZonesGlobalArray,_2);
};
Telerik.Web.UI.RadDockZone=function(_3){
Telerik.Web.UI.RadDockZone.initializeBase(this,[_3]);
this._clientID=null;
this._highlightedCssClass=null;
this._fitDocks=true;
this._uniqueName=null;
this._layoutID=null;
};
Telerik.Web.UI.RadDockZone.prototype={initialize:function(){
Telerik.Web.UI.RadDockZone.callBaseMethod(this,"initialize");
this._resetDockIndices();
this._placeholder=$get(this.get_clientID()+"_D");
this._clearElement=$get(this.get_clientID()+"_C");
Telerik.Web.UI.registerRadDockZone(this);
},dispose:function(){
Telerik.Web.UI.unregisterRadDockZone(this);
Telerik.Web.UI.RadDockZone.callBaseMethod(this,"dispose");
},dock:function(_4,_5){
var _6=this.get_docks();
var _7=null;
if(_6.length>_5){
_7=_6[_5].get_element();
}
this._dockBefore(_4,_7);
},get_docks:function(){
var _8=[];
var _9=this.get_element().firstChild;
while(_9!=null){
if(_9!=this._placeholder&&_9.id){
var _a=$find(_9.id);
if(_a&&Telerik.Web.UI.RadDock&&Telerik.Web.UI.RadDock.isInstanceOfType(_a)){
Array.add(_8,_a);
}
}
_9=_9.nextSibling;
}
return _8;
},_dockBefore:function(_b,_c){
var _d=_b.get_element();
var _e=this.get_element();
if(_c){
_e.insertBefore(_d,_c);
}else{
_e.insertBefore(_d,this._clearElement);
}
var _f=$find(_b.get_dockZoneID());
if(_f){
_f._resetDockIndices();
}
_b.set_dockZoneID(_e.id);
if(this.get_fitDocks()){
if(!this.get_isHorizontal()){
_b._fitWidth();
}
}else{
if(!this.get_isHorizontal()){
_b._unfitWidth();
}
}
_b._resetPosition();
if(_b._tableElement){
_b._setSize();
}
_b._setPinUnpinVisibility();
this._resetDockIndices();
},_resetDockIndices:function(){
var _10=this.get_docks();
for(var i=0;i<_10.length;i++){
_10[i].set_index(i);
_10[i].updateClientState();
}
},get_isHorizontal:function(){
return Sys.UI.DomElement.containsCssClass(this.get_element(),"rdHorizontal");
},_lastFoundItem:null,_lastFoundItemBounds:null,_findItemAt:function(_12,_13){
var el=this.get_element();
if(!(this._lastFoundItem&&this._isInside(_12,this._lastFoundItemBounds))){
this._lastFoundItem=null;
this._lastFoundItemBounds=null;
var _15=el.firstChild;
while(_15!=null){
if(_15!=this._placeholder&&_15!=_13&&_15.nodeType!=3&&_15.nodeType!=8){
var _16=this._getMarginBox(_13);
var _17=this._getBorderBox(_13);
var _18=$telerik.getBounds(_15);
var loc=$telerik.getLocation(_15);
_18.x=loc.x;
_18.y=loc.y;
_18.x-=(_16.left+_17.left+2);
_18.y-=(_16.top+_17.top+2);
_18.width+=(_16.right+_17.right+2);
_18.height+=(_16.bottom+_17.bottom+2);
if(this._isInside(_12,_18)){
this._lastFoundItem=_15;
this._lastFoundItemBounds=_18;
break;
}
}
_15=_15.nextSibling;
}
}
return this._lastFoundItem;
},_isInside:function(_1a,_1b){
return (_1a.x>_1b.x&&_1a.x<(_1b.x+_1b.width)&&_1a.y>_1b.y&&_1a.y<(_1b.y+_1b.height));
},_showPlaceholder:function(_1c,_1d){
this._repositionPlaceholder(_1c.get_element(),_1d);
var _1e=_1c._getBoundsWithBorderAndMargin();
var _1f=_1c._getMarginBox(this._placeholder);
var _20=_1c._getBorderBox(this._placeholder);
var _21=this.get_isHorizontal();
var _22=this._placeholder.style;
_22.height=_1e.height-(_1f.vertical+_20.vertical)+"px";
_22.width=this.get_fitDocks()&&!_21?"100%":_1e.width-(_1f.horizontal+_20.horizontal)+"px";
_22.display="block";
},_repositionPlaceholder:function(_23,_24){
var _25=this.getScrollOffset(_23,true);
var _26=this._findItemAt(_24,_23);
var _27=this.get_element();
if(null==_26){
_27.insertBefore(this._placeholder,this._clearElement);
}else{
if(_26.previousSibling!=this._placeholder){
_27.insertBefore(this._placeholder,_26);
}
}
},_getMarginBox:function(_28){
return $telerik.getMarginBox(_28);
},_getBorderBox:function(_29){
return $telerik.getBorderBox(_29);
},_hidePlaceholder:function(){
this._placeholder.style.display="none";
this._lastFoundItem=null;
this._lastFoundItemBounds=null;
},canDrop:function(_2a){
return ((_2a.get_dockMode()&Telerik.Web.UI.DockMode.Docked)>0&&Array.indexOf(_2a.get_forbiddenZones(),this.get_uniqueName())<0);
},drop:function(_2b){
var _2c=new Sys.CancelEventArgs();
_2b.raise_dockPositionChanging(_2c);
this._hidePlaceholder();
if(this.get_highlightedCssClass()!=null){
this.removeCssClass(this.get_highlightedCssClass());
}
if(_2c.get_cancel()){
_2b._restorePosition();
}else{
this._dockBefore(_2b,this._placeholder);
_2b.raise_dockPositionChanged(new Sys.EventArgs());
}
},dragEnterTarget:function(_2d,_2e){
this._showPlaceholder(_2d,_2e);
if(this.get_highlightedCssClass()!=null){
this.addCssClass(this.get_highlightedCssClass());
}
},onDragInTarget:function(_2f,_30){
this._repositionPlaceholder(_2f.get_element(),_30);
},dragLeaveTarget:function(_31){
this._hidePlaceholder();
if(this.get_highlightedCssClass()!=null){
this.removeCssClass(this.get_highlightedCssClass());
}
},pointInZone:function(e){
return $telerik.isMouseOverElement(this.get_element(),e);
},hitTest:function(_33,_34,e){
if(this.pointInZone(e)){
if(this.canDrop(_33)){
this.dragEnterTarget(_33,_34);
}
return true;
}else{
this.dragLeaveTarget(_33);
return false;
}
},getScrollOffset:function(_36,_37){
var _38=_36.scrollLeft;
var top=_36.scrollTop;
if(_37){
var _3a=_36.parentNode;
while(_3a!=null&&_3a.scrollLeft!=null){
_38+=_3a.scrollLeft;
top+=_3a.scrollTop;
if(_3a==document.body&&(_38!=0&&top!=0)){
break;
}
_3a=_3a.parentNode;
}
}
return {x:_38,y:top};
},addPoints:function(p1,p2){
return {x:p1.x+p2.x,y:p1.y+p2.y};
},get_clientID:function(){
return this._clientID;
},set_clientID:function(_3d){
this._clientID=_3d;
},get_fitDocks:function(){
return this._fitDocks;
},set_fitDocks:function(_3e){
this._fitDocks=_3e;
},get_highlightedCssClass:function(){
return this._highlightedCssClass;
},set_highlightedCssClass:function(_3f){
this._highlightedCssClass=_3f;
},get_layoutID:function(){
return this._layoutID;
},set_layoutID:function(_40){
this._layoutID=_40;
},get_uniqueName:function(){
return this._uniqueName;
},set_uniqueName:function(_41){
this._uniqueName=_41;
}};
Telerik.Web.UI.RadDockZone.registerClass("Telerik.Web.UI.RadDockZone",Telerik.Web.UI.RadWebControl);

