Type.registerNamespace("Telerik.Web.UI.Scheduler.Views.Month");
Telerik.Web.UI.Scheduler.Views.Month.Model=function(_1,_2){
this._owner=_1;
this._modelData=Sys.Serialization.JavaScriptSerializer.deserialize(_2);
this._start=new Date(Date.parse(this._modelData.start));
};
Telerik.Web.UI.Scheduler.Views.Month.Model.prototype={initialize:function(){
},getTimeSlotFromDomElement:function(_3){
var _4=this._getRawIndexFromDomElement(_3);
var _5=this._getTimeFromDomElement(_3);
return new Telerik.Web.UI.Scheduler.Views.Month.TimeSlot(_4,_5);
},_getTimeFromDomElement:function(_6){
var _7=this._getRawIndexFromDomElement(_6);
var _8=new Date(this._modelData.start);
var _9=this._modelData.weekLength;
var _a=Math.floor(_7.dayIndex/_9);
var _b=_7.dayIndex%_9;
var _c=(_a*7)+_b;
Telerik.Web.UI.RadScheduler._incrementTime(_8,24*_c,0);
return _8;
},_getRawIndexFromDomElement:function(_d){
while(_d&&(_d.tagName.toUpperCase()!="TD")){
_d=_d.parentNode;
}
if(_d){
var _e=_d.parentNode;
var _f=_e.cells.length;
var _10=_d.cellIndex;
var _11=_e.rowIndex;
return {dayIndex:(_f*_11)+_10};
}
return null;
}};
Telerik.Web.UI.Scheduler.Views.Month.Model.registerClass("Telerik.Web.UI.Scheduler.Views.Month.Model",null,Telerik.Web.UI.ISchedulerModel);
Telerik.Web.UI.Scheduler.Views.Month.TimeSlot=function(_12,_13){
this._rawIndex=_12;
this._startTime=_13;
};
Telerik.Web.UI.Scheduler.Views.Month.TimeSlot.prototype={get_index:function(){
var _14=this.get_rawIndex();
return String.format("{0}",_14.dayIndex);
},get_rawIndex:function(){
return this._rawIndex;
},get_startTime:function(){
return this._startTime;
},get_isAllDay:function(){
return true;
}};
Telerik.Web.UI.Scheduler.Views.Month.TimeSlot.registerClass("Telerik.Web.UI.Scheduler.Views.Month.TimeSlot",null,Telerik.Web.UI.ISchedulerTimeSlot);

