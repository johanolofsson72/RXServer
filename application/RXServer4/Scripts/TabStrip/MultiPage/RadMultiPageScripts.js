Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadPageViewCollection=function(_1){
this._owner=_1;
this._data=[];
};
Telerik.Web.UI.RadPageViewCollection.prototype={get_count:function(){
return this._data.length;
},_add:function(_2){
this._insert(this.get_count(),_2);
},_insert:function(_3,_4){
Array.insert(this._data,_3,_4);
_4._multiPage=this._owner;
},insert:function(_5,_6){
this._insert(_5,_6);
this._owner._onPageViewInserted(_5,_6);
},add:function(_7){
this.insert(this.get_count(),_7);
},getPageView:function(_8){
return this._data[_8]||null;
},removeAt:function(_9){
var _a=this.getPageView(_9);
if(_a){
this.remove(_a);
}
},remove:function(_b){
this._owner._onPageViewRemoving(_b);
_b.unselect();
Array.remove(this._data,_b);
this._owner._onPageViewRemoved(_b);
}};
Telerik.Web.UI.RadPageViewCollection.registerClass("Telerik.Web.UI.RadPageViewCollection");
Telerik.Web.UI.RadPageView=function(_c){
this._element=_c;
};
Telerik.Web.UI.RadPageView.prototype={_select:function(_d){
var _e=this.get_multiPage();
if(!_e){
this._cachedSelected=true;
return;
}
_e._selectPageViewByIndex(this.get_index(),_d);
},hide:function(){
if(this.get_element()){
this.get_element().style.display="none";
}
},show:function(){
if(!this.get_element()){
return;
}
this.get_element().style.display="block";
if(this._repaintCalled){
return;
}
$telerik.repaintChildren(this);
this._repaintCalled=true;
},get_element:function(){
return this._element;
},get_index:function(){
return Array.indexOf(this.get_multiPage().get_pageViews()._data,this);
},get_id:function(){
return this._id;
},set_id:function(_f){
this._id=_f;
if(this.get_element()){
this.get_element().id=_f;
}
},get_multiPage:function(){
return this._multiPage||null;
},get_selected:function(){
return this.get_multiPage().get_selectedPageView()==this;
},set_selected:function(_10){
if(_10){
this.select();
}else{
this.unselect();
}
},select:function(){
this._select();
},unselect:function(){
if(this.get_selected()){
this.get_multiPage().set_selectedIndex(-1);
}
}};
Telerik.Web.UI.RadPageView.registerClass("Telerik.Web.UI.RadPageView");
Telerik.Web.UI.RadMultiPage=function(_11){
Telerik.Web.UI.RadMultiPage.initializeBase(this,[_11]);
this._pageViews=new Telerik.Web.UI.RadPageViewCollection(this);
this._selectedIndex=-1;
this._pageViewData=null;
this._changeLog=[];
};
Telerik.Web.UI.RadMultiPage.prototype={_logInsert:function(_12){
if(!this._trackingChanges){
return;
}
Array.add(this._changeLog,{type:1,index:_12.get_index()});
},_logRemove:function(_13){
if(!this._trackingChanges){
return;
}
Array.add(this._changeLog,{type:2,index:_13.get_index()});
},_onPageViewRemoving:function(_14){
this._logRemove(_14);
},_onPageViewInserted:function(_15,_16){
var _17=_16.get_element();
if(!_17){
_17=_16._element=document.createElement("div");
}
_17.style.display="none";
if(_16.get_id()){
_17.id=_16.get_id();
}
var _18=this.get_pageViews().getPageView(_15+1);
if(_18){
this.get_element().insertBefore(_17,_18.get_element());
}else{
this.get_element().appendChild(_17);
}
if(_16._cachedSelected){
_16._cachedSelected=false;
_16.select();
}
this._logInsert(_16);
},_onPageViewRemoved:function(_19){
if(_19.get_element()){
this.get_element().removeChild(_19.get_element());
}
},_selectPageViewByIndex:function(_1a,_1b){
if(this._selectedIndex==_1a){
return;
}
if(!this.get_isInitialized()){
this._selectedIndex=_1a;
return;
}
if(_1a<-1||_1a>=this.get_pageViews().get_count()){
return;
}
var _1c=this.get_selectedPageView();
this._selectedIndex=_1a;
var _1d=this.get_selectedPageView();
if(!_1b){
if(_1c){
_1c.hide();
}
if(_1d){
_1d.show();
}
}
this.updateClientState();
},trackChanges:function(){
this._trackingChanges=true;
},commitChanges:function(){
this.updateClientState();
this._trackingChanges=false;
},get_pageViewData:function(){
return this._pageViewData;
},set_pageViewData:function(_1e){
this._pageViewData=_1e;
},initialize:function(){
Telerik.Web.UI.RadMultiPage.callBaseMethod(this,"initialize");
var _1f=this.get_pageViewData();
for(var i=0;i<_1f.length;i++){
var _21=new Telerik.Web.UI.RadPageView($get(_1f[i].id));
_21._id=_1f[i].id;
this._pageViews._add(_21);
}
},findPageViewByID:function(id){
for(var i=0;i<this.get_pageViews().get_count();i++){
var _24=this.get_pageViews().getPageView(i);
if(_24.get_id()==id){
return _24;
}
}
return null;
},get_pageViews:function(){
return this._pageViews;
},get_selectedIndex:function(){
return this._selectedIndex;
},set_selectedIndex:function(_25){
this._selectPageViewByIndex(_25);
},get_selectedPageView:function(){
return this.get_pageViews().getPageView(this.get_selectedIndex());
},saveClientState:function(){
var _26={};
_26.selectedIndex=this.get_selectedIndex();
_26.changeLog=this._changeLog;
return Sys.Serialization.JavaScriptSerializer.serialize(_26);
}};
Telerik.Web.UI.RadMultiPage.registerClass("Telerik.Web.UI.RadMultiPage",Telerik.Web.UI.RadWebControl);

