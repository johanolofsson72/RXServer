Type.registerNamespace("Telerik.Web.UI.Scheduler.Views.Timeline");
Telerik.Web.UI.Scheduler.Views.Timeline.Model=function(_1,_2){
this._owner=_1;
this._modelData=Sys.Serialization.JavaScriptSerializer.deserialize(_2);
this._start=new Date(Date.parse(this._modelData.start));
this._slotDuration=this._modelData.slotDuration;
};
Telerik.Web.UI.Scheduler.Views.Timeline.Model.prototype={initialize:function(){
},getTimeSlotFromDomElement:function(_3){
var _4=this._getRawIndexFromDomElement(_3);
var _5=this._getTimeFromDomElement(_3);
return new Telerik.Web.UI.Scheduler.Views.Timeline.TimeSlot(_4,_5);
},_getTimeFromDomElement:function(_6){
var _7=this._getRawIndexFromDomElement(_6);
var _8=new Date(this._start.getTime());
Telerik.Web.UI.RadScheduler._incrementTime(_8,0,this._slotDuration*_7.intervalIndex);
return _8;
},_getRawIndexFromDomElement:function(_9){
while(_9&&(_9.tagName.toUpperCase()!="TD")){
_9=_9.parentNode;
}
if(_9){
return {intervalIndex:_9.cellIndex};
}
return null;
}};
Telerik.Web.UI.Scheduler.Views.Timeline.Model.registerClass("Telerik.Web.UI.Scheduler.Views.Timeline.Model",null,Telerik.Web.UI.ISchedulerModel);
Telerik.Web.UI.Scheduler.Views.Timeline.TimeSlot=function(_a,_b){
this._rawIndex=_a;
this._startTime=_b;
};
Telerik.Web.UI.Scheduler.Views.Timeline.TimeSlot.prototype={get_index:function(){
var _c=this.get_rawIndex();
return String.format("{0}",_c.intervalIndex);
},get_rawIndex:function(){
return this._rawIndex;
},get_startTime:function(){
return this._startTime;
},get_isAllDay:function(){
return true;
}};
Telerik.Web.UI.Scheduler.Views.Timeline.TimeSlot.registerClass("Telerik.Web.UI.Scheduler.Views.Timeline.TimeSlot",null,Telerik.Web.UI.ISchedulerTimeSlot);

