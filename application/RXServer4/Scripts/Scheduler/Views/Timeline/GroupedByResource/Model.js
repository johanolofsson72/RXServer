Type.registerNamespace("Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByResource");
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByResource.Model=function(_1,_2){
this._owner=_1;
this._modelData=Sys.Serialization.JavaScriptSerializer.deserialize(_2);
this._rawModelData=_2;
this._timelineModels=[];
this._resources=null;
};
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByResource.Model.prototype={initialize:function(){
var _3=this._modelData.groupingResource;
this._resources=this._owner.get_resources().getResourcesByType(_3);
for(var i=0;i<this._resources.get_count();i++){
this._timelineModels[i]=new Telerik.Web.UI.Scheduler.Views.Timeline.Model(this._owner,this._rawModelData);
}
},getTimeSlotFromDomElement:function(_5){
var _6=this._getRawIndexFromDomElement(_5);
var _7=this._getTimeFromDomElement(_5);
var _8=this._resources.getResource(_6.modelIndex);
return new Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByResource.TimeSlot(_6,_7,_8);
},_getTimeFromDomElement:function(_9){
return this._timelineModels[0]._getTimeFromDomElement(_9);
},_getRawIndexFromDomElement:function(_a){
while(_a&&(_a.tagName.toUpperCase()!="TD")){
_a=_a.parentNode;
}
if(!_a){
return null;
}
var _b=_a;
while(!Sys.UI.DomElement.containsCssClass(_b,"rsTimelineTable")){
_b=_b.parentNode;
}
var _c=this._owner._modelTables;
var _d=this._owner._getElementIndex(_c,_b);
var _e=this._timelineModels[_d];
var _f=_e._getRawIndexFromDomElement(_a);
_f.modelIndex=_d;
return _f;
}};
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByResource.Model.registerClass("Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByResource.Model",null,Telerik.Web.UI.ISchedulerModel);
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByResource.TimeSlot=function(_10,_11,_12){
this._resource=_12;
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByResource.TimeSlot.initializeBase(this,[_10,_11]);
};
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByResource.TimeSlot.prototype={get_index:function(){
var _13=this.get_rawIndex();
var _14=Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByResource.TimeSlot.callBaseMethod(this,"get_index");
return String.format("{0}:{1}",_13.modelIndex,_14);
},get_resource:function(){
return this._resource;
}};
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByResource.TimeSlot.registerClass("Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByResource.TimeSlot",Telerik.Web.UI.Scheduler.Views.Timeline.TimeSlot);

