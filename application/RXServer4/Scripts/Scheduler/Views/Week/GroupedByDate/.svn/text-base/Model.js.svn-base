Type.registerNamespace("Telerik.Web.UI.Scheduler");
Telerik.Web.UI.Scheduler.DateGroupedWeekModel=function(_1,_2){
this._owner=_1;
this._modelData=Sys.Serialization.JavaScriptSerializer.deserialize(_2);
this._rawModelData=_2;
this._weekModels=new Array();
this._resources=new Telerik.Web.UI.SchedulerResourceCollection();
this._tablesPerModel=0;
};
Telerik.Web.UI.Scheduler.DateGroupedWeekModel.prototype={initialize:function(){
var _3=this._modelData.groupingResource;
this._resources=this._owner.get_resources().getResourcesByType(_3);
for(var i=0;i<this._resources.get_count();i++){
this._weekModels[i]=new Telerik.Web.UI.Scheduler.WeekModel(this._owner,this._rawModelData);
}
var _5=this._modelData.showAllDayRow==true;
this._tablesPerModel=_5?2:1;
},getTimeSlotFromDomElement:function(_6){
var _7=this._getRawIndexFromDomElement(_6);
var _8=this._getTimeFromDomElement(_6);
var _9=this._resources.getResource(_7.modelIndex);
return new Telerik.Web.UI.Scheduler.DateGroupedWeekTimeSlot(_7,_8,_9);
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
var _f=_a.cellIndex;
var _10=_a.parentNode.rowIndex;
var _11=Sys.UI.DomElement.containsCssClass(_d,"rsAllDayTable");
var _12=_11?0:1;
var _13=this._owner._modelTables;
var _14=this._owner._getElementIndex(_13,_d);
_14=parseInt(_14/this._tablesPerModel);
var _15=_f%this._resources.get_count();
return {modelIndex:_15,viewPartIndex:_12,rowIndex:_10,cellIndex:_14};
},_getTimeFromDomElement:function(_16){
return this._weekModels[0]._getTimeFromDomElement(_16);
}};
Telerik.Web.UI.Scheduler.DateGroupedWeekModel.registerClass("Telerik.Web.UI.Scheduler.DateGroupedWeekModel");
Telerik.Web.UI.Scheduler.DateGroupedWeekTimeSlot=function(_17,_18,_19){
this._resource=_19;
Telerik.Web.UI.Scheduler.DateGroupedWeekTimeSlot.initializeBase(this,[_17,_18]);
};
Telerik.Web.UI.Scheduler.DateGroupedWeekTimeSlot.prototype={get_index:function(){
var _1a=this.get_rawIndex();
var _1b=Telerik.Web.UI.Scheduler.DateGroupedWeekTimeSlot.callBaseMethod(this,"get_index");
return String.format("{0}:{1}",_1a.modelIndex,_1b);
},get_resource:function(){
return this._resource;
}};
Telerik.Web.UI.Scheduler.DateGroupedWeekTimeSlot.registerClass("Telerik.Web.UI.Scheduler.DateGroupedWeekTimeSlot",Telerik.Web.UI.Scheduler.WeekTimeSlot);

