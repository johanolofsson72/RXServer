Type.registerNamespace("Telerik.Web.UI.Scheduler");
Telerik.Web.UI.Scheduler.WeekModel=function(_1,_2){
this._owner=_1;
this._modelData=Sys.Serialization.JavaScriptSerializer.deserialize(_2);
this._start=new Date(Date.parse(this._modelData.start));
};
Telerik.Web.UI.Scheduler.WeekModel.prototype={initialize:function(){
},getTimeSlotFromDomElement:function(_3){
var _4=this._getRawIndexFromDomElement(_3);
var _5=this._getTimeFromDomElement(_3);
return new Telerik.Web.UI.Scheduler.WeekTimeSlot(_4,_5);
},_getTimeFromDomElement:function(_6){
var _7=this._getRawIndexFromDomElement(_6);
var _8=new Date(this._modelData.start);
var _9=_7.rowIndex*this._owner.get_minutesPerRow();
Telerik.Web.UI.RadScheduler._incrementTime(_8,24*_7.cellIndex,_9);
return _8;
},_getRawIndexFromDomElement:function(_a){
while(_a&&(_a.tagName.toUpperCase()!="TD")){
_a=_a.parentNode;
}
if(_a){
var _b=_a.cellIndex;
var _c=_a.parentNode.rowIndex;
var _d=_a.parentNode;
var _e=_d.parentNode;
var _f=_e.parentNode;
var _10=Sys.UI.DomElement.containsCssClass(_f,"rsAllDayTable");
var _11=_10?0:1;
return {cellIndex:_b,rowIndex:_c,viewPartIndex:_11};
}
return null;
}};
Telerik.Web.UI.Scheduler.WeekModel.registerClass("Telerik.Web.UI.Scheduler.WeekModel",null,Telerik.Web.UI.ISchedulerModel);
Telerik.Web.UI.Scheduler.WeekTimeSlot=function(_12,_13){
this._rawIndex=_12;
this._startTime=_13;
};
Telerik.Web.UI.Scheduler.WeekTimeSlot.prototype={get_index:function(){
var _14=this.get_rawIndex();
return String.format("{0}:{1}:{2}",_14.viewPartIndex,_14.rowIndex,_14.cellIndex);
},get_rawIndex:function(){
return this._rawIndex;
},get_startTime:function(){
return this._startTime;
},get_isAllDay:function(){
return this.get_rawIndex().viewPartIndex==0;
}};
Telerik.Web.UI.Scheduler.WeekTimeSlot.registerClass("Telerik.Web.UI.Scheduler.WeekTimeSlot",null,Telerik.Web.UI.ISchedulerTimeSlot);

