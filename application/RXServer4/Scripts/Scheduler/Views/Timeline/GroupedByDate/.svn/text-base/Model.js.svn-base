Type.registerNamespace("Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByDate");
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByDate.Model=function(_1,_2){
this._owner=_1;
this._modelData=Sys.Serialization.JavaScriptSerializer.deserialize(_2);
this._rawModelData=_2;
this._timelineModels=new Array();
this._resources=null;
};
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByDate.Model.prototype={initialize:function(){
var _3=this._modelData.groupingResource;
this._resources=this._owner.get_resources().getResourcesByType(_3);
for(var i=0;i<this._resources.get_count();i++){
this._timelineModels[i]=new Telerik.Web.UI.Scheduler.Views.Timeline.Model(this._owner,this._rawModelData);
}
},getTimeSlotFromDomElement:function(_5){
var _6=this._getRawIndexFromDomElement(_5);
var _7=this._getTimeFromDomElement(_5);
var _8=this._resources.getResource(_6.modelIndex);
return new Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByDate.TimeSlot(_6,_7,_8);
},_getRawIndexFromDomElement:function(_9){
while(_9&&(_9.tagName.toUpperCase()!="TD")){
_9=_9.parentNode;
}
if(!_9){
return null;
}
var _a=_9.cellIndex;
var _b={};
_b.modelIndex=_a;
var _c=_9;
while(!Sys.UI.DomElement.containsCssClass(_c,"rsTimelineTable")){
_c=_c.parentNode;
}
var _d=this._owner._modelTables;
var _e=this._owner._getElementIndex(_d,_c);
_b.intervalIndex=_e;
return _b;
},_getTimeFromDomElement:function(_f){
return this._timelineModels[0]._getTimeFromDomElement(_f);
}};
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByDate.Model.registerClass("Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByDate.Model");
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByDate.TimeSlot=function(_10,_11,_12){
this._resource=_12;
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByDate.TimeSlot.initializeBase(this,[_10,_11]);
};
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByDate.TimeSlot.prototype={get_index:function(){
var _13=this.get_rawIndex();
var _14=Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByDate.TimeSlot.callBaseMethod(this,"get_index");
return String.format("{0}:{1}",_13.modelIndex,_14);
},get_resource:function(){
return this._resource;
}};
Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByDate.TimeSlot.registerClass("Telerik.Web.UI.Scheduler.Views.Timeline.GroupedByDate.TimeSlot",Telerik.Web.UI.Scheduler.Views.Timeline.TimeSlot);

