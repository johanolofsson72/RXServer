Type.registerNamespace("Telerik.Web.UI.Scheduler.Views.Month.GroupedByResource");
Telerik.Web.UI.Scheduler.Views.Month.GroupedByResource.Model=function(_1,_2){
this._owner=_1;
this._modelData=Sys.Serialization.JavaScriptSerializer.deserialize(_2);
this._rawModelData=_2;
this._monthModels=[];
this._resources=null;
};
Telerik.Web.UI.Scheduler.Views.Month.GroupedByResource.Model.prototype={initialize:function(){
var _3=this._modelData.groupingResource;
this._resources=this._owner.get_resources().getResourcesByType(_3);
for(var i=0;i<this._resources.get_count();i++){
this._monthModels[i]=new Telerik.Web.UI.Scheduler.Views.Month.Model(this._owner,this._rawModelData);
}
},getTimeSlotFromDomElement:function(_5){
var _6=this._getRawIndexFromDomElement(_5);
var _7=this._getTimeFromDomElement(_5);
var _8=this._resources.getResource(_6.modelIndex);
return new Telerik.Web.UI.Scheduler.Views.Month.GroupedByResource.TimeSlot(_6,_7,_8);
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
var _c=_b.parentNode;
var _d=_c.parentNode;
var _e=_d.parentNode;
var _f=this._owner._modelTables;
var _10=this._owner._getElementIndex(_f,_d);
var _11=this._monthModels[_10];
var _12=_11._getRawIndexFromDomElement(_a);
_12.modelIndex=_10;
return _12;
}};
Telerik.Web.UI.Scheduler.Views.Month.GroupedByResource.Model.registerClass("Telerik.Web.UI.Scheduler.Views.Month.GroupedByResource.Model",null,Telerik.Web.UI.ISchedulerModel);
Telerik.Web.UI.Scheduler.Views.Month.GroupedByResource.TimeSlot=function(_13,_14,_15){
this._resource=_15;
Telerik.Web.UI.Scheduler.Views.Month.GroupedByResource.TimeSlot.initializeBase(this,[_13,_14]);
};
Telerik.Web.UI.Scheduler.Views.Month.GroupedByResource.TimeSlot.prototype={get_index:function(){
var _16=this.get_rawIndex();
var _17=Telerik.Web.UI.Scheduler.Views.Month.GroupedByResource.TimeSlot.callBaseMethod(this,"get_index");
return String.format("{0}:{1}",_16.modelIndex,_17);
},get_resource:function(){
return this._resource;
}};
Telerik.Web.UI.Scheduler.Views.Month.GroupedByResource.TimeSlot.registerClass("Telerik.Web.UI.Scheduler.Views.Month.GroupedByResource.TimeSlot",Telerik.Web.UI.Scheduler.Views.Month.TimeSlot);

