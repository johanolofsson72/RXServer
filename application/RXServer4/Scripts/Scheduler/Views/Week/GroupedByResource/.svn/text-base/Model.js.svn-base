Type.registerNamespace("Telerik.Web.UI");
Type.registerNamespace("Telerik.Web.UI.Scheduler");
Telerik.Web.UI.Scheduler.ResourceGroupedWeekModel=function(_1,_2){
this._owner=_1;
this._modelData=Sys.Serialization.JavaScriptSerializer.deserialize(_2);
this._rawModelData=_2;
this._weekModels=new Array();
this._resources=new Telerik.Web.UI.SchedulerResourceCollection();
this._tablesPerModel=0;
};
Telerik.Web.UI.Scheduler.ResourceGroupedWeekModel.prototype={initialize:function(){
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
return new Telerik.Web.UI.Scheduler.ResourceGroupedWeekTimeSlot(_7,_8,_9);
},_getRawIndexFromDomElement:function(_a){
while(_a&&(_a.tagName.toUpperCase()!="TD")){
_a=_a.parentNode;
}
var _b=_a.parentNode;
var _c=_b.parentNode;
var _d=_c.parentNode;
var _e=_d.parentNode;
var _f=this._owner._modelTables;
var _10=this._owner._getElementIndex(_f,_d);
var _11=parseInt(_10/this._tablesPerModel);
var _12=this._weekModels[_11];
var _13=_12._getRawIndexFromDomElement(_a);
_13.modelIndex=_11;
return _13;
},_getTimeFromDomElement:function(_14){
return this._weekModels[0]._getTimeFromDomElement(_14);
}};
Telerik.Web.UI.Scheduler.ResourceGroupedWeekModel.registerClass("Telerik.Web.UI.Scheduler.ResourceGroupedWeekModel");
Telerik.Web.UI.Scheduler.ResourceGroupedWeekTimeSlot=function(_15,_16,_17){
this._resource=_17;
Telerik.Web.UI.Scheduler.ResourceGroupedWeekTimeSlot.initializeBase(this,[_15,_16]);
};
Telerik.Web.UI.Scheduler.ResourceGroupedWeekTimeSlot.prototype={get_index:function(){
var _18=this.get_rawIndex();
var _19=Telerik.Web.UI.Scheduler.ResourceGroupedWeekTimeSlot.callBaseMethod(this,"get_index");
return String.format("{0}:{1}",_18.modelIndex,_19);
},get_resource:function(){
return this._resource;
}};
Telerik.Web.UI.Scheduler.ResourceGroupedWeekTimeSlot.registerClass("Telerik.Web.UI.Scheduler.ResourceGroupedWeekTimeSlot",Telerik.Web.UI.Scheduler.WeekTimeSlot);

