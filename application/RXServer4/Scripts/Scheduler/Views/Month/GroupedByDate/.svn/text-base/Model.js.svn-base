Type.registerNamespace("Telerik.Web.UI.Scheduler.Views.Month.GroupedByDate");
Telerik.Web.UI.Scheduler.Views.Month.GroupedByDate.Model=function(_1,_2){
this._owner=_1;
this._modelData=Sys.Serialization.JavaScriptSerializer.deserialize(_2);
this._rawModelData=_2;
this._monthModels=[];
this._resources=null;
};
Telerik.Web.UI.Scheduler.Views.Month.GroupedByDate.Model.prototype={initialize:function(){
var _3=this._modelData.groupingResource;
this._resources=this._owner.get_resources().getResourcesByType(_3);
for(var i=0;i<this._resources.get_count();i++){
this._monthModels[i]=new Telerik.Web.UI.Scheduler.Views.Month.Model(this._owner,this._rawModelData);
}
},getTimeSlotFromDomElement:function(_5){
var _6=this._getRawIndexFromDomElement(_5);
var _7=this._getTimeFromDomElement(_5);
var _8=this._resources.getResource(_6.modelIndex);
return new Telerik.Web.UI.Scheduler.Views.Month.GroupedByDate.TimeSlot(_6,_7,_8);
},_getTimeFromDomElement:function(_9){
return this._monthModels[0]._getTimeFromDomElement(_9);
},_getRawIndexFromDomElement:function(_a){
while(_a&&(_a.tagName.toUpperCase()!="TD")){
_a=_a.parentNode;
}
if(!_a){
return null;
}
var _b=_a.parentNode;
var _c=_a.cellIndex;
var _d=_c%this._resources.get_count();
var _e=_b.parentNode;
var _f=_e.parentNode;
var _10=_b.rowIndex;
var _11=_b.cells.length/this._resources.get_count();
var _12=Math.floor(_c/this._resources.get_count());
var _13;
var _14;
var _15;
if(this._modelData.isVertical){
_13=_12;
_14=_f.rows.length;
_15=_10;
}else{
_13=_10;
_14=_11;
_15=_12;
}
var _16=(_13*_14)+_15;
return {modelIndex:_d,dayIndex:_16};
}};
Telerik.Web.UI.Scheduler.Views.Month.GroupedByDate.Model.registerClass("Telerik.Web.UI.Scheduler.Views.Month.GroupedByDate.Model",null,Telerik.Web.UI.ISchedulerModel);
Telerik.Web.UI.Scheduler.Views.Month.GroupedByDate.TimeSlot=function(_17,_18,_19){
this._resource=_19;
Telerik.Web.UI.Scheduler.Views.Month.GroupedByDate.TimeSlot.initializeBase(this,[_17,_18]);
};
Telerik.Web.UI.Scheduler.Views.Month.GroupedByDate.TimeSlot.prototype={get_index:function(){
var _1a=this.get_rawIndex();
var _1b=Telerik.Web.UI.Scheduler.Views.Month.GroupedByDate.TimeSlot.callBaseMethod(this,"get_index");
return String.format("{0}:{1}",_1a.modelIndex,_1b);
},get_resource:function(){
return this._resource;
}};
Telerik.Web.UI.Scheduler.Views.Month.GroupedByDate.TimeSlot.registerClass("Telerik.Web.UI.Scheduler.Views.Month.GroupedByDate.TimeSlot",Telerik.Web.UI.Scheduler.Views.Month.TimeSlot);

