Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RecurrenceState=function(){
};
Telerik.Web.UI.RecurrenceState.prototype={NotRecurring:0,Master:1,Occurrence:2,Exception:3};
Telerik.Web.UI.RecurrenceState.registerEnum("Telerik.Web.UI.RecurrenceState");
Telerik.Web.UI.SchedulerAppointment=function(_1,_2,_3){
this._attributes=new Telerik.Web.UI.SchedulerAttributeCollection(this);
if(!_1){
return;
}
this._id=_1.id;
this._subject=_1.subject;
this._start=new Date(Date.parse(_1.start));
this._end=new Date(Date.parse(_1.end));
this._toolTip=_1.toolTip;
this._internalID=_1.internalID;
this._visible=_1.visible;
this._recurrenceState=_1.recurrenceState;
this._recurrenceParentID=_1.recurrenceParentID;
this._serializedResources=_1.resources;
this._resources=null;
this._domElements=_1.domElements;
this._domElement=null;
this._allowEdit=null;
if(typeof (_1.allowEdit)!="undefined"){
this._allowEdit=_1.allowEdit;
}
this._allowDelete=null;
if(typeof (_1.allowDelete)!="undefined"){
this._allowDelete=_1.allowDelete;
}
this._radScheduler=_2;
this._oldZIndex=null;
this._originalParent=null;
this._selected=false;
if(typeof (_1.attributes)!="undefined"){
this._attributes._load(_1.attributes);
}
};
Telerik.Web.UI.SchedulerAppointment._incrementMilliseconds=function(_4,_5){
_4.setTime(_4.getTime()+_5);
};
Telerik.Web.UI.SchedulerAppointment.prototype={get_id:function(){
return this._id;
},get_subject:function(){
return this._subject;
},set_subject:function(_6){
this._subject=_6;
},get_start:function(){
return this._start;
},set_start:function(_7){
this._start=_7;
},get_end:function(){
return this._end;
},set_end:function(_8){
this._end=_8;
},get_toolTip:function(){
return this._toolTip;
},set_toolTip:function(_9){
this._toolTip=_9;
},get_radScheduler:function(){
return this._radScheduler;
},get_allowEdit:function(){
return this._allowEdit;
},set_allowEdit:function(_a){
this._allowEdit=_a;
},get_allowDelete:function(){
return this._allowDelete;
},set_allowDelete:function(_b){
this._allowDelete=_b;
},get_element:function(){
if(!this._domElement&&this._domElements.length>0){
this._domElement=$get(this._domElements[0]);
}
return this._domElement;
},get_attributes:function(){
return this._attributes;
},get_recurrenceState:function(){
return this._recurrenceState;
},get_recurrenceParentID:function(){
return this._recurrenceParentID;
},get_resources:function(){
if(!this._resources){
this._resources=new Telerik.Web.UI.SchedulerResourceCollection();
for(var _c in this._serializedResources){
var _d=this._serializedResources[_c];
if(_d.text){
this._resources.add(new Telerik.Web.UI.SchedulerResource(_d));
}else{
var _e=this.get_radScheduler().get_resources().getResourcesByType(_d.type);
var _f=this._resources;
_e.forEach(function(_10){
if(_10.get_key()==_d.key){
_f.add(_10);
}
});
}
}
}
return this._resources;
},edit:function(){
var _11=this.get_radScheduler();
if(_11){
_11.editAppointment(this);
}
},remove:function(){
var _12=this.get_radScheduler();
if(_12){
_12.deleteAppointment(this);
}
},_getDuration:function(){
return this._end-this._start;
},_setDuration:function(_13){
var _14=this.get_element();
var _15=_13/60000;
var _16=_14.parentNode.parentNode.offsetHeight;
var _17=$telerik.getBorderWidth(_14.parentNode.parentNode,Telerik.Web.BoxSide.Bottom);
var _18=((_15/this.get_radScheduler().get_minutesPerRow())*_16)-_17;
var _19=parseInt(_14.style.paddingBottom);
if(isNaN(_19)){
_19=0;
}
_14.style.height=_18-_19+"px";
if($telerik.isIE&&$telerik.quirksMode){
var _1a=_14.firstChild;
_1a.style.height="";
Telerik.Web.UI.RadScheduler._adjustSingleAppointmentHeight(_14,_14._initialHeightInRows,1);
}
Telerik.Web.UI.RadScheduler._fixIEBottom(_14);
this._end.setTime(this._start.getTime());
Telerik.Web.UI.SchedulerAppointment._incrementMilliseconds(this._end,_13);
},_startDrag:function(){
var _1b=this.get_element();
var _1c=$telerik.getElementByClassName(_1b,"rsAptWrap","div");
var _1d=this.get_radScheduler().get_element();
this._dragTimeout=window.setTimeout(function(){
$telerik.setOpacity(_1c,0.6);
_1d.style.cursor="move";
},100);
this._oldZIndex=_1b.style.zIndex;
_1b.style.zIndex=999;
this._originalParent=_1b.parentNode;
Sys.UI.DomElement.removeCssClass(_1b,"rsWAppointmentDelete");
},_endDrag:function(_1e){
this._finishDrag(_1e,false);
},_abortDrag:function(){
this._finishDrag(null,true);
},_finishDrag:function(_1f,_20){
var _21=this.get_radScheduler();
window.clearTimeout(this._dragTimeout);
var _1f=this.get_element();
var _22=$telerik.getElementByClassName(_1f,"rsAptWrap","div");
$telerik.setOpacity(_22,1);
_1f.style.zindex=this._oldZIndex;
var _23=this.get_radScheduler().get_element();
if(_23&&_23.style){
this.get_radScheduler().get_element().style.cursor="";
}
var _24;
var _25=this._getDuration();
var _26="Move";
if(this._originalParent.parentNode==_1f||_20){
if(_1f.parentNode!=this._originalParent){
this._originalParent.appendChild(_1f);
}
return;
}
var _27=_21._activeModel.getTimeSlotFromDomElement(this._originalParent.parentNode);
var _28=_21._activeModel.getTimeSlotFromDomElement(_1f);
_24={Command:_26,AppointmentID:this._internalID,EditSeries:false,SourceSlotIndex:_27.get_index(),TargetSlotIndex:_28.get_index()};
var _29={OnConfirm:this._onAppointmentMoveCallback,OnAbort:this._onAppointmentMoveAbortCallback,Scheduler:this.get_radScheduler(),Appointment:this,TargetSlot:_28,PostbackEvent:_24,CallbackIsCalledFromDialog:true};
if(_21.get_displayRecurrenceActionDialogOnMove()&&(this._recurrenceState==1||this._recurrenceState==2)){
var _2a=new Telerik.Web.UI.SchedulerRecurrenceActionDialogShowingEventArgs(_29.Appointment,Telerik.Web.UI.RecurrenceAction.Move);
_21.raise_recurrenceActionDialogShowing(_2a);
if(_2a.get_cancel()){
var _2b=_2a.get_editSeries();
if(_2b!==null){
_29.CallbackIsCalledFromDialog=false;
this._onAppointmentMoveCallback(_2b,_29);
}else{
this._onAppointmentMoveAbortCallback(_29);
}
}else{
_21._recurrenceActionDialog.ConfirmRecurrenceAction(Telerik.Web.UI.RecurrenceAction.Move,_29);
}
}else{
_29.CallbackIsCalledFromDialog=false;
this._onAppointmentMoveCallback(false,_29);
}
},_onAppointmentMoveCallback:function(_2c,_2d){
if(_2d.CallbackIsCalledFromDialog){
var _2e=new Telerik.Web.UI.SchedulerRecurrenceActionDialogClosedEventArgs(_2d.Appointment,Telerik.Web.UI.RecurrenceAction.Move,_2c);
_2d.Scheduler.raise_recurrenceActionDialogClosed(_2e);
}
var _2f=new Telerik.Web.UI.SchedulerAppointmentMoveEndEventArgs(_2d.Appointment,_2d.TargetSlot.get_startTime(),_2c,_2d.TargetSlot);
_2d.Scheduler.raiseEvent("appointmentMoveEnd",_2f);
if(_2f.get_cancel()==false){
_2d.PostbackEvent.EditSeries=_2c;
_2d.Scheduler.postback(_2d.PostbackEvent);
}else{
_2d.Appointment._abortDrag();
}
},_onAppointmentMoveAbortCallback:function(_30){
_30.Appointment._abortDrag();
},_select:function(){
this._selected=true;
},_unselect:function(){
this._selected=false;
}};
Telerik.Web.UI.SchedulerAppointment.registerClass("Telerik.Web.UI.SchedulerAppointment");
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.SchedulerAppointmentCollection=function(){
this._array=new Array();
};
Telerik.Web.UI.SchedulerAppointmentCollection.prototype={add:function(_31){
var _32=this._array.length;
this.insert(_32,_31);
},insert:function(_33,_34){
Array.insert(this._array,_33,_34);
},remove:function(_35){
Array.remove(this._array,_35);
},removeAt:function(_36){
var _37=this.getAppointment(_36);
if(_37){
this.remove(_37);
}
},clear:function(){
this._array=new Array();
},get_count:function(){
return this._array.length;
},getAppointment:function(_38){
return this._array[_38];
},indexOf:function(_39){
return Array.indexOf(this._array,_39);
},forEach:function(_3a){
for(var i=0,_3c=this.get_count();i<_3c;i++){
_3a(this.getAppointment(i));
}
},getAppointmentsInRange:function(_3d,end){
var _3f=new Telerik.Web.UI.SchedulerAppointmentCollection();
this.forEach(function(_40){
var _41=_40.get_start();
var _42=_40.get_end();
if(_41<end&&_42>_3d){
_3f.add(_40);
}
});
return _3f;
},getAppointmentsStartingInRange:function(_43,end){
var _45=new Telerik.Web.UI.SchedulerAppointmentCollection();
this.forEach(function(_46){
var _47=_46.get_start();
if(_47>=_43&&_47<end){
_45.add(_46);
}
});
return _45;
},findByID:function(id){
var _49;
this.forEach(function(_4a){
if(_4a.get_id()==id){
_49=_4a;
}
});
return _49;
}};
Telerik.Web.UI.SchedulerAppointmentCollection.registerClass("Telerik.Web.UI.SchedulerAppointmentCollection");
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.SchedulerAppointmentEventArgs=function(_4b){
Telerik.Web.UI.SchedulerAppointmentEventArgs.initializeBase(this);
this._appointment=_4b;
};
Telerik.Web.UI.SchedulerAppointmentEventArgs.prototype={get_appointment:function(){
return this._appointment;
}};
Telerik.Web.UI.SchedulerAppointmentEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentEventArgs",Sys.EventArgs);
Telerik.Web.UI.SchedulerAppointmentCancelEventArgs=function(_4c){
Telerik.Web.UI.SchedulerAppointmentCancelEventArgs.initializeBase(this);
this._appointment=_4c;
};
Telerik.Web.UI.SchedulerAppointmentCancelEventArgs.prototype={get_appointment:function(){
return this._appointment;
}};
Telerik.Web.UI.SchedulerAppointmentCancelEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentCancelEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.SchedulerAppointmentClickEventArgs=function(_4d){
Telerik.Web.UI.SchedulerAppointmentClickEventArgs.initializeBase(this,[_4d]);
};
Telerik.Web.UI.SchedulerAppointmentClickEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentClickEventArgs",Telerik.Web.UI.SchedulerAppointmentEventArgs);
Telerik.Web.UI.SchedulerAppointmentInsertingEventArgs=function(_4e,_4f,_50){
Telerik.Web.UI.SchedulerAppointmentInsertingEventArgs.initializeBase(this);
this._startTime=_4e;
this._isAllDay=_4f;
this._targetSlot=_50;
};
Telerik.Web.UI.SchedulerAppointmentInsertingEventArgs.prototype={get_startTime:function(){
return this._startTime;
},get_isAllDay:function(){
return this._isAllDay;
},get_targetSlot:function(){
return this._targetSlot;
}};
Telerik.Web.UI.SchedulerAppointmentInsertingEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentInsertingEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.SchedulerAppointmentResizeStartEventArgs=function(_51){
Telerik.Web.UI.SchedulerAppointmentResizeStartEventArgs.initializeBase(this,[_51]);
};
Telerik.Web.UI.SchedulerAppointmentResizeStartEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentResizeStartEventArgs",Telerik.Web.UI.SchedulerAppointmentCancelEventArgs);
Telerik.Web.UI.SchedulerAppointmentResizeEndEventArgs=function(_52,_53,_54){
Telerik.Web.UI.SchedulerAppointmentResizeEndEventArgs.initializeBase(this,[_52]);
this._newTime=_53;
this._editingRecurringSeries=_54;
};
Telerik.Web.UI.SchedulerAppointmentResizeEndEventArgs.prototype={get_newTime:function(){
return this._newTime;
},get_editingRecurringSeries:function(){
return this._editingRecurringSeries;
}};
Telerik.Web.UI.SchedulerAppointmentResizeEndEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentResizeEndEventArgs",Telerik.Web.UI.SchedulerAppointmentCancelEventArgs);
Telerik.Web.UI.SchedulerAppointmentResizingEventArgs=function(_55,_56){
Telerik.Web.UI.SchedulerAppointmentResizingEventArgs.initializeBase(this,[_55]);
this._targetSlot=_56;
};
Telerik.Web.UI.SchedulerAppointmentResizingEventArgs.prototype={get_targetSlot:function(){
return this._targetSlot;
}};
Telerik.Web.UI.SchedulerAppointmentResizingEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentResizingEventArgs",Telerik.Web.UI.SchedulerAppointmentCancelEventArgs);
Telerik.Web.UI.SchedulerAppointmentDeletingEventArgs=function(_57,_58){
Telerik.Web.UI.SchedulerAppointmentDeletingEventArgs.initializeBase(this,[_57]);
this._editingRecurringSeries=_58;
};
Telerik.Web.UI.SchedulerAppointmentDeletingEventArgs.prototype={get_editingRecurringSeries:function(){
return this._editingRecurringSeries;
}};
Telerik.Web.UI.SchedulerAppointmentDeletingEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentDeletingEventArgs",Telerik.Web.UI.SchedulerAppointmentCancelEventArgs);
Telerik.Web.UI.SchedulerAppointmentDeletedEventArgs=function(_59){
Telerik.Web.UI.SchedulerAppointmentDeletedEventArgs.initializeBase(this,[_59]);
};
Telerik.Web.UI.SchedulerAppointmentDeletedEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentDeletedEventArgs",Telerik.Web.UI.SchedulerAppointmentEventArgs);
Telerik.Web.UI.SchedulerAppointmentEditingEventArgs=function(_5a,_5b){
Telerik.Web.UI.SchedulerAppointmentEditingEventArgs.initializeBase(this,[_5a]);
this._editingRecurringSeries=_5b;
};
Telerik.Web.UI.SchedulerAppointmentEditingEventArgs.prototype={get_editingRecurringSeries:function(){
return this._editingRecurringSeries;
}};
Telerik.Web.UI.SchedulerAppointmentEditingEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentEditingEventArgs",Telerik.Web.UI.SchedulerAppointmentCancelEventArgs);
Telerik.Web.UI.SchedulerAppointmentMoveStartEventArgs=function(_5c){
Telerik.Web.UI.SchedulerAppointmentMoveStartEventArgs.initializeBase(this,[_5c]);
};
Telerik.Web.UI.SchedulerAppointmentMoveStartEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentMoveStartEventArgs",Telerik.Web.UI.SchedulerAppointmentCancelEventArgs);
Telerik.Web.UI.SchedulerAppointmentMovingEventArgs=function(_5d,_5e){
Telerik.Web.UI.SchedulerAppointmentMovingEventArgs.initializeBase(this,[_5d]);
this._targetSlot=_5e;
};
Telerik.Web.UI.SchedulerAppointmentMovingEventArgs.prototype={get_targetSlot:function(){
return this._targetSlot;
}};
Telerik.Web.UI.SchedulerAppointmentMovingEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentMovingEventArgs",Telerik.Web.UI.SchedulerAppointmentCancelEventArgs);
Telerik.Web.UI.SchedulerAppointmentMoveEndEventArgs=function(_5f,_60,_61,_62){
Telerik.Web.UI.SchedulerAppointmentMoveEndEventArgs.initializeBase(this,[_5f]);
this._targetSlot=_62;
this._newStartTime=_60;
this._editingRecurringSeries=_61;
};
Telerik.Web.UI.SchedulerAppointmentMoveEndEventArgs.prototype={get_newStartTime:function(){
return this._newStartTime;
},get_editingRecurringSeries:function(){
return this._editingRecurringSeries;
},get_targetSlot:function(){
return this._targetSlot;
}};
Telerik.Web.UI.SchedulerAppointmentMoveEndEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentMoveEndEventArgs",Telerik.Web.UI.SchedulerAppointmentCancelEventArgs);
Telerik.Web.UI.SchedulerTimeSlotClickEventArgs=function(_63,_64){
Telerik.Web.UI.SchedulerTimeSlotClickEventArgs.initializeBase(this);
this._time=_63;
this._targetSlot=_64;
};
Telerik.Web.UI.SchedulerTimeSlotClickEventArgs.prototype={get_time:function(){
return this._time;
},get_targetSlot:function(){
return this._targetSlot;
}};
Telerik.Web.UI.SchedulerTimeSlotClickEventArgs.registerClass("Telerik.Web.UI.SchedulerTimeSlotClickEventArgs",Sys.EventArgs);
Telerik.Web.UI.SchedulerAppointmentDoubleClickEventArgs=function(_65){
Telerik.Web.UI.SchedulerAppointmentDoubleClickEventArgs.initializeBase(this,[_65]);
};
Telerik.Web.UI.SchedulerAppointmentDoubleClickEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentDoubleClickEventArgs",Telerik.Web.UI.SchedulerAppointmentEventArgs);
Telerik.Web.UI.SchedulerRecurrenceActionDialogShowingEventArgs=function(_66,_67){
Telerik.Web.UI.SchedulerRecurrenceActionDialogShowingEventArgs.initializeBase(this,[_66]);
this._recurrenceAction=_67;
this._editSeries=null;
};
Telerik.Web.UI.SchedulerRecurrenceActionDialogShowingEventArgs.prototype={get_recurrenceAction:function(){
return this._recurrenceAction;
},get_editSeries:function(){
return this._editSeries;
},set_editSeries:function(_68){
this._editSeries=_68;
}};
Telerik.Web.UI.SchedulerRecurrenceActionDialogShowingEventArgs.registerClass("Telerik.Web.UI.SchedulerRecurrenceActionDialogShowingEventArgs",Telerik.Web.UI.SchedulerAppointmentCancelEventArgs);
Telerik.Web.UI.SchedulerRecurrenceActionDialogClosedEventArgs=function(_69,_6a,_6b){
Telerik.Web.UI.SchedulerRecurrenceActionDialogClosedEventArgs.initializeBase(this,[_69]);
this._recurrenceAction=_6a;
this._editSeries=_6b;
};
Telerik.Web.UI.SchedulerRecurrenceActionDialogClosedEventArgs.prototype={get_recurrenceAction:function(){
return this._recurrenceAction;
},get_editSeries:function(){
return this._editSeries;
}};
Telerik.Web.UI.SchedulerRecurrenceActionDialogClosedEventArgs.registerClass("Telerik.Web.UI.SchedulerRecurrenceActionDialogClosedEventArgs",Telerik.Web.UI.SchedulerAppointmentEventArgs);
Telerik.Web.UI.SchedulerFormCreatedEventArgs=function(_6c,_6d){
Telerik.Web.UI.SchedulerFormCreatedEventArgs.initializeBase(this,[_6c]);
this._formElement=_6d;
};
Telerik.Web.UI.SchedulerFormCreatedEventArgs.prototype={get_formElement:function(){
return this._formElement;
}};
Telerik.Web.UI.SchedulerFormCreatedEventArgs.registerClass("Telerik.Web.UI.SchedulerFormCreatedEventArgs",Telerik.Web.UI.SchedulerAppointmentCancelEventArgs);
Telerik.Web.UI.SchedulerAppointmentContextMenuEventArgs=function(_6e,_6f){
Telerik.Web.UI.SchedulerAppointmentContextMenuEventArgs.initializeBase(this,[_6e]);
this._domEvent=_6f;
};
Telerik.Web.UI.SchedulerAppointmentContextMenuEventArgs.prototype={get_domEvent:function(){
return this._domEvent;
}};
Telerik.Web.UI.SchedulerAppointmentContextMenuEventArgs.registerClass("Telerik.Web.UI.SchedulerAppointmentContextMenuEventArgs",Telerik.Web.UI.SchedulerAppointmentEventArgs);
Telerik.Web.UI.SchedulerTimeSlotContextMenuEventArgs=function(_70,_71,_72,_73){
Telerik.Web.UI.SchedulerTimeSlotContextMenuEventArgs.initializeBase(this);
this._time=_70;
this._isAllDay=_71;
this._domEvent=_72;
this._targetSlot=_73;
};
Telerik.Web.UI.SchedulerTimeSlotContextMenuEventArgs.prototype={get_time:function(){
return this._time;
},get_isAllDay:function(){
return this._isAllDay;
},get_domEvent:function(){
return this._domEvent;
},get_targetSlot:function(){
return this._targetSlot;
}};
Telerik.Web.UI.SchedulerTimeSlotContextMenuEventArgs.registerClass("Telerik.Web.UI.SchedulerTimeSlotContextMenuEventArgs",Sys.EventArgs);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.SchedulerViewType=function(){
};
Telerik.Web.UI.SchedulerViewType.prototype={DayView:0,WeekView:1,MonthView:2,ResourceView:3,TimelineView:4};
Telerik.Web.UI.SchedulerViewType.registerEnum("Telerik.Web.UI.SchedulerViewType");
Telerik.Web.UI.RadScheduler=function(_74){
Telerik.Web.UI.RadScheduler.initializeBase(this,[_74]);
this._postBackReference=null;
this._minutesPerRow=30;
this._numberOfHoveredRows=2;
this._selectedView=0;
this._readOnly=false;
this._overflowBehavior=1;
this._shouldPostbackOnClick=true;
this._displayDeleteConfirmation=true;
this._displayRecurrenceActionDialogOnMove=false;
this._firstDayStart=null;
this._appointments=null;
this._currentAppointment=null;
this._resources=null;
this._scrollTop=0;
this._localization=null;
this._shouldFireFormCreated=false;
this._inlineFormDiv=null;
this._advancedFormDiv=null;
this._advancedTemplate=null;
this._attributes=new Telerik.Web.UI.SchedulerAttributeCollection();
this._allowEdit=true;
this._allowDelete=true;
this._allowInsert=true;
this._enableAdvancedTemplateScript=false;
this._inPostback=false;
this._dragging=false;
this._editing=false;
this._draggingAppointment=null;
this._selectedAppointment=null;
this._onKeyboardEventDelegate=null;
this._modelClassName=null;
this._modelData={};
this._activeModel=null;
this._modelTables=null;
this._resizingState={};
this._eventMap=new Telerik.Web.UI.EventMap();
this._recurrenceActionDialog=new Telerik.Web.UI.RecurrenceActionDialog(this);
};
Telerik.Web.UI.RadScheduler._adjustHeight=function(_75){
var _76=$get(_75);
var _77=_76.offsetHeight;
var _78=_77;
var _79=null;
var _7a=_76.childNodes;
var _7b=_7a.length;
for(var i=0;i<_7b;i++){
var _7d=_7a[i];
if(_7d.tagName&&_7d.tagName.toLowerCase()=="div"){
if(Sys.UI.DomElement.containsCssClass(_7d,"rsContent")){
_79=_7d;
}else{
_78-=_7d.offsetHeight;
}
}
}
if(_79!=null){
var _7e=$telerik.getPaddingBox(_79).vertical;
var _7f=$telerik.getBorderBox(_79).vertical;
_78-=_7e+_7f;
_78=Math.max(_78,50);
if(_78!=_79.offsetHeight){
_79.style.height=_78+"px";
}
}
var _80=$telerik.getElementByClassName(_76,"rsAllDayLastCell","td");
if(_80){
_80.firstChild.style.width=(Telerik.Web.UI.RadScheduler._getScrollBarWidth()-1)+"px";
}
var _81=$telerik.getElementByClassName(_76,"rsColumnHeaderLastCell","td");
if(_81){
_81.firstChild.style.width=(Telerik.Web.UI.RadScheduler._getScrollBarWidth()-1)+"px";
}
};
Telerik.Web.UI.RadScheduler._incrementTime=function(_82,_83,_84){
if(isNaN(_84)){
_84=0;
}
_82.setTime(_82.getTime()+(_83*3600000)+(_84*60000));
};
Telerik.Web.UI.RadScheduler._getScrollBarWidth=function(){
if(Telerik.Web.UI.RadScheduler._scrollbarWidth){
return Telerik.Web.UI.RadScheduler._scrollbarWidth;
}
var _85,_86=0;
var _87=document.createElement("div");
_87.style.position="absolute";
_87.style.top="-1000px";
_87.style.left="-1000px";
_87.style.width="100px";
_87.style.height="50px";
_87.style.overflow="hidden";
var _88=document.createElement("div");
_88.style.width="100%";
_88.style.height="200px";
_87.appendChild(_88);
document.body.appendChild(_87);
var _89=_88.offsetWidth;
_87.style.overflow="auto";
var _8a=_88.offsetWidth;
Telerik.Web.UI.RadScheduler._scrollbarWidth=_89-_8a;
if(Telerik.Web.UI.RadScheduler._scrollbarWidth<=0){
_88.style.width="300px";
_85=_87.offsetWidth;
_86=_87.clientWidth;
Telerik.Web.UI.RadScheduler._scrollbarWidth=_85-_86;
}
if(Telerik.Web.UI.RadScheduler._scrollbarWidth<=0){
Telerik.Web.UI.RadScheduler._scrollbarWidth=16;
}
document.body.removeChild(document.body.lastChild);
return Telerik.Web.UI.RadScheduler._scrollbarWidth;
};
Telerik.Web.UI.RadScheduler._adjustAppointmentsHeight=function(_8b){
if(!($telerik.isIE&&$telerik.quirksMode)){
return;
}
var _8c=$get(_8b);
var _8d=_8c.getElementsByTagName("div");
for(var i=0;i<_8d.length;i++){
var _8f=_8d[i];
if(!Sys.UI.DomElement.containsCssClass(_8f,"rsApt")){
continue;
}
var _90=parseInt(_8f.offsetHeight);
if(_90==0){
return;
}
if(!_8f.style.height.endsWith("%")){
return;
}
var _91=parseInt(_8f.style.height)/100;
Telerik.Web.UI.RadScheduler._adjustSingleAppointmentHeight(_8f,_91);
_8f._initialHeightInRows=_91;
}
};
Telerik.Web.UI.RadScheduler._adjustSingleAppointmentHeight=function(_92,_93){
var _94=_92.parentNode.parentNode;
var _95=$telerik.getBorderBox(_94).vertical;
var _96=_95*2;
var _97=parseInt(_92.offsetHeight);
var _98=_97+(_93*_96)+_95;
var _99=$telerik.getPaddingBox(_92).vertical;
_98=_98-_99;
_92.style.height=_98+"px";
var _9a=_92.firstChild;
_9a.style.height=_98+"px";
Telerik.Web.UI.RadScheduler._fixIEBottom(_92);
};
Telerik.Web.UI.RadScheduler._fixIEBottom=function(_9b){
if($telerik.isIE6||($telerik.isIE&&$telerik.quirksMode)){
var _9c=$telerik.getElementByClassName(_9b,"rsAptBottom","div");
if(_9b.offsetHeight%2!=0){
_9c.style.bottom="-1px";
}else{
_9c.style.bottom="0px";
}
}
};
Telerik.Web.UI.RadScheduler.prototype={initialize:function(){
var _9d=this.get_element();
Telerik.Web.UI.RadScheduler.callBaseMethod(this,"initialize");
this._activeModel=new (Type.parse(this._modelClassName))(this,this._modelData);
this._activeModel.initialize();
this._eventMap.initialize(this);
this.repaint();
var _9e=$telerik.getFirstChildByTagName(_9d,"div",0);
if(_9e&&Sys.UI.DomElement.containsCssClass(_9e,"rsAdvancedEdit")){
this._advancedFormDiv=_9e;
if(typeof (Telerik.Web.UI.Scheduling)!="undefined"&&typeof (Telerik.Web.UI.Scheduling.AdvancedTemplate)!="undefined"&&this._enableAdvancedTemplateScript){
this._advancedTemplate=new Telerik.Web.UI.Scheduling.AdvancedTemplate(this._advancedFormDiv);
this._advancedTemplate.initialize();
}
}else{
this._eventMap.addHandlerForClassName("dblclick","rsAptEdit",this._stopEventPropagation);
this._eventMap.addHandlerForClassName("dblclick","rsApt",this._onAppointmentDoubleClick);
this._eventMap.addHandlerForClassName("dblclick","rsAllDayCell",this._onCellDoubleClick);
this._eventMap.addHandlerForClassName("dblclick","rsCell",this._onCellDoubleClick);
this._eventMap.addHandlerForClassName("click","rsAptResize",this._onResizeGripMouseClick);
this._eventMap.addHandlerForClassName("click","rsApt",this._onAppointmentClick);
this._eventMap.addHandlerForClassName("click","rsAptDelete",this._onAppointmentDeleteClick);
this._eventMap.addHandlerForClassName("click","rsArrowTop",this._onPreviousDayClick);
this._eventMap.addHandlerForClassName("click","rsArrowBottom",this._onNextDayClick);
this._eventMap.addHandlerForClassName("click","rsArrowLeft",this._onPreviousDayClick);
this._eventMap.addHandlerForClassName("click","rsArrowRight",this._onNextDayClick);
this._eventMap.addHandlerForClassName("click","rsNextDay",this._onNextSchedulerDayClick);
this._eventMap.addHandlerForClassName("click","rsPrevDay",this._onPreviousSchedulerDayClick);
this._eventMap.addHandlerForClassName("click","rsToday",this._onTodayClick);
this._eventMap.addHandlerForClassName("click","rsFullTime",this._onFullTimeLinkClick);
this._eventMap.addHandlerForClassName("click","rsAptEdit",this._onEditFormClick);
this._eventMap.addHandlerForClassName("click","rsShowMore",this._onShowMoreClick);
this._eventMap.addHandlerForClassName("click","rsHeaderDay",this._onDayViewTabClick);
this._eventMap.addHandlerForClassName("click","rsHeaderWeek",this._onWeekViewTabClick);
this._eventMap.addHandlerForClassName("click","rsHeaderMonth",this._onMonthViewTabClick);
this._eventMap.addHandlerForClassName("click","rsHeaderTimeline",this._onTimelineViewTabClick);
this._eventMap.addHandlerForClassName("click","rsCell",this._onCellClick);
this._eventMap.addHandlerForClassName("click","rsAllDayCell",this._onCellClick);
this._eventMap.addHandlerForClassName("mouseover","rsCell",this._onRowMouseOver);
this._eventMap.addHandlerForClassName("mouseover","rsAllDayCell",this._onAllDayCellMouseOver);
this._eventMap.addHandlerForClassName("mouseover","rsApt",this._onAppointmentMouseOver);
this._eventMap.addHandlerForClassName("mouseover","rsAptResize",this._onResizeGripMouseOver);
this._eventMap.addHandlerForClassName("mouseout","rsCell",this._onRowMouseOut);
this._eventMap.addHandlerForClassName("mouseout","rsAllDayCell",this._onRowMouseOut);
this._eventMap.addHandlerForClassName("mouseout","rsApt",this._onAppointmentMouseOut);
this._eventMap.addHandlerForClassName("mousedown","rsAptDelete",this._stopEventPropagation);
this._eventMap.addHandlerForClassName("mousedown","rsApt",this._onAppointmentMouseDown);
this._eventMap.addHandlerForClassName("mousedown","rsAptResize",this._onResizeGripMouseDown);
this._eventMap.addHandlerForClassName("mouseup","rsCell",this._endDrag);
this._eventMap.addHandlerForClassName("contextmenu","rsApt",this._onAppointmentContextMenu);
this._eventMap.addHandlerForClassName("contextmenu","rsCell",this._onCellContextMenu);
this._eventMap.addHandlerForClassName("contextmenu","rsAllDayCell",this._onCellContextMenu);
this._onKeyboardEventDelegate=Function.createDelegate(this,this._onKeyboardEvent);
$addHandler(document.documentElement,"keydown",this._onKeyboardEventDelegate);
}
this._onResizeGripMouseMoveDelegate=Function.createDelegate(this,this._onResizeGripMouseMove);
this._onResizeGripMouseUpDelegate=Function.createDelegate(this,this._onResizeGripMouseUp);
this._onSelectStartDelegate=Function.createDelegate(this,this._onSelectStart);
this._onDocMouseUpDelegate=Function.createDelegate(this,this._onDocMouseUp);
this._onDocumentMouseMoveDelegate=Function.createDelegate(this,this._onDocumentMouseMove);
var _9f=$telerik.getElementByClassName(this.get_element(),"rsContent","div");
if(_9f){
_9f.scrollTop=this.get_scrollTop();
}
this._fireFormCreated();
},dispose:function(){
var _a0=this.get_element();
if(this._onKeyboardEventDelegate){
$removeHandler(document.documentElement,"keydown",this._onKeyboardEventDelegate);
}
this._eventMap.dispose();
this._recurrenceActionDialog.dispose();
if(this._advancedTemplate){
this._advancedTemplate.dispose();
}
this._modelTables=null;
this._resizingState=null;
Telerik.Web.UI.RadScheduler.callBaseMethod(this,"dispose");
},repaint:function(){
if(this.get_overflowBehavior()==1){
Telerik.Web.UI.RadScheduler._adjustHeight(this.get_id());
if(typeof (Telerik.Web.UI.Scheduling)!="undefined"&&typeof (Telerik.Web.UI.Scheduling.AdvancedTemplate)!="undefined"){
Telerik.Web.UI.Scheduling.AdvancedTemplate._adjustHeight(this.get_id());
}
}
Telerik.Web.UI.RadScheduler._adjustAppointmentsHeight(this.get_id());
this._initializeModelTables();
},get_appointments:function(){
return this._appointments;
},set_appointments:function(_a1){
this._appointments=new Telerik.Web.UI.SchedulerAppointmentCollection();
var _a2=eval("("+_a1+")");
for(var i=0;i<_a2.length;i++){
var _a4=new Telerik.Web.UI.SchedulerAppointment(_a2[i],this);
this._appointments.add(_a4);
}
},get_resources:function(){
return this._resources;
},set_resources:function(_a5){
this._resources=new Telerik.Web.UI.SchedulerResourceCollection();
var _a6=Sys.Serialization.JavaScriptSerializer.deserialize(_a5);
for(var i=0;i<_a6.length;i++){
var _a8=new Telerik.Web.UI.SchedulerResource(_a6[i]);
this._resources.add(_a8);
}
},get_firstDayStart:function(){
return this._firstDayStart;
},set_firstDayStart:function(_a9){
this._firstDayStart=new Date(Date.parse(_a9));
},get_currentAppointment:function(){
return this._currentAppointment;
},set_currentAppointment:function(_aa){
var _ab=Sys.Serialization.JavaScriptSerializer.deserialize(_aa);
this._currentAppointment=new Telerik.Web.UI.SchedulerAppointment(_ab,this,null);
},get_localization:function(){
return this._localization;
},set_localization:function(_ac){
this._localization=Sys.Serialization.JavaScriptSerializer.deserialize(_ac);
},get_scrollTop:function(){
return this._scrollTop;
},set_scrollTop:function(_ad){
this._scrollTop=_ad;
},get_displayDeleteConfirmation:function(){
return this._displayDeleteConfirmation;
},set_displayDeleteConfirmation:function(_ae){
this._displayDeleteConfirmation=_ae;
},get_displayRecurrenceActionDialogOnMove:function(){
return this._displayRecurrenceActionDialogOnMove;
},set_displayRecurrenceActionDialogOnMove:function(_af){
this._displayRecurrenceActionDialogOnMove=_af;
},get_shouldPostbackOnClick:function(){
return this._shouldPostbackOnClick;
},set_shouldPostbackOnClick:function(_b0){
this._shouldPostbackOnClick=_b0;
},get_overflowBehavior:function(){
return this._overflowBehavior;
},set_overflowBehavior:function(_b1){
this._overflowBehavior=_b1;
},get_readOnly:function(){
return this._readOnly;
},set_readOnly:function(_b2){
this._readOnly=_b2;
},get_selectedView:function(){
return this._selectedView;
},set_selectedView:function(_b3){
this._selectedView=_b3;
},get_minutesPerRow:function(){
return this._minutesPerRow;
},set_minutesPerRow:function(_b4){
this._minutesPerRow=_b4;
},get_postBackReference:function(){
return this._postBackReference;
},set_postBackReference:function(_b5){
this._postBackReference=_b5;
},get_allowEdit:function(){
return this._allowEdit;
},set_allowEdit:function(_b6){
this._allowEdit=_b6;
},get_allowDelete:function(){
return this._allowDelete;
},set_allowDelete:function(_b7){
this._allowDelete=_b7;
},get_allowInsert:function(){
return this._allowInsert;
},set_allowInsert:function(_b8){
this._allowInsert=_b8;
},get_attributes:function(){
return this._attributes;
},set_attributes:function(_b9){
this._attributes._load(_b9);
},get_activeModel:function(){
return this._activeModel;
},set_numberOfHoveredRows:function(_ba){
this._numberOfHoveredRows=_ba;
},get_numberOfHoveredRows:function(){
return this._numberOfHoveredRows;
},set_groupBy:function(_bb){
this._groupBy=_bb;
},get_groupBy:function(){
return this._groupBy;
},showInsertFormAt:function(_bc){
var _bd={command:"Insert",appointmentID:-1,targetSlotIndex:_bc.get_index()};
this.postback(_bd);
},insertAppointment:function(_be){
var _bf={command:"InsertAppointment",appointment:this._getSerializableAppointment(_be),startDate:_be.get_start().format("yyyyMMddHHmm"),endDate:_be.get_end().format("yyyyMMddHHmm")};
this.postback(_bf);
},updateAppointment:function(_c0,_c1){
var _c2={command:"UpdateAppointment",appointmentID:_c0._internalID,appointment:this._getSerializableAppointment(_c0),startDate:_c0.get_start().format("yyyyMMddHHmm"),endDate:_c0.get_end().format("yyyyMMddHHmm"),editSeries:_c1};
this.postback(_c2);
},editAppointment:function(_c3,_c4){
var _c5={command:"Edit",appointmentID:_c3._internalID,editSeries:_c4};
this.postback(_c5);
},deleteAppointment:function(_c6,_c7){
var _c8={command:"Delete",appointmentID:_c6._internalID,editSeries:_c7};
this.postback(_c8);
},getAppointmentDomElement:function(_c9){
while(_c9&&!Sys.UI.DomElement.containsCssClass(_c9,"rsApt")){
_c9=_c9.parentNode;
}
return _c9;
},getAppointmentFromDomElement:function(_ca){
if(!_ca){
return null;
}
var _cb=this.getAppointmentDomElement(_ca);
var _cc=this.get_appointments();
for(var i=0;i<_cc.get_count();i++){
var _ce=_cc.getAppointment(i);
if(!_ce.get_element()){
continue;
}
for(var _cf=0;_cf<_ce._domElements.length;_cf++){
if(_cb.id==_ce._domElements[_cf]){
return _ce;
}
}
}
return null;
},_getSerializableAppointment:function(_d0){
return {ID:_d0._internalID,Subject:_d0.get_subject(),RecurrenceState:_d0.get_recurrenceState(),RecurrenceParentID:_d0.get_recurrenceParentID()};
},_fireFormCreated:function(){
if(this._shouldFireFormCreated){
var _d1=this.get_element();
if(this._inlineFormDiv){
_d1=this._inlineFormDiv;
}else{
if(this._advancedFormDiv){
_d1=this._advancedFormDiv;
}
}
var _d2=new Telerik.Web.UI.SchedulerFormCreatedEventArgs(this.get_currentAppointment(),_d1);
this.raise_formCreated(_d2);
}
},_onKeyboardEvent:function(e){
if(e.keyCode==27){
if(this._dragging){
this._abortDrag(e);
}
if(this._resizingState.resizing){
this._resizingState.resizingAppointment._setDuration(this._resizingState.resizingAppointmentDuration);
this._cleanupResize();
}
}
},_onAppointmentClick:function(e){
var _d5=this.getAppointmentFromDomElement(e.eventMapTarget);
if(_d5._selected){
this._editAppointmentInline(_d5);
return;
}
var _d6=new Telerik.Web.UI.SchedulerAppointmentClickEventArgs(_d5);
this.raise_appointmentClick(_d6);
if(this.get_readOnly()&&this.get_shouldPostbackOnClick()){
var _d7={Command:"Click",AppointmentID:_d5._internalID,EditSeries:false};
this.postback(_d7);
return;
}
if(this._selectedAppointment){
this._selectedAppointment._unselect();
}
_d5._select();
this._selectedAppointment=_d5;
},_onAppointmentContextMenu:function(e){
var _d9=this.getAppointmentFromDomElement(e.eventMapTarget);
var _da=new Telerik.Web.UI.SchedulerAppointmentContextMenuEventArgs(_d9,e);
this.raise_appointmentContextMenu(_da);
},_onEditFormClick:function(e){
e.stopPropagation();
},_removeMonthCellHover:function(){
if(this._currentHoverCell){
Sys.UI.DomElement.removeCssClass(this._currentHoverCell,"rsAptCreate");
}
},_onMonthCellMouseOver:function(e){
if(Sys.UI.DomElement.containsCssClass(e.eventMapTarget,"rsWrap")){
this._currentHoverDiv=e.eventMapTarget;
this._currentHoverCell=e.eventMapTarget.parentNode;
Sys.UI.DomElement.addCssClass(this._currentHoverCell,"rsAptCreate");
}
},_getHourCellFromDomElement:function(_dd){
var _de=_dd;
while(_de.tagName.toLowerCase()!="th"){
_de=_de.parentNode;
}
return _de;
},_onAllDayCellMouseOver:function(e){
if(this._dragging&&this._draggingAppointment){
e.eventMapTarget.lastChild.appendChild(this._draggingAppointment.get_element());
}
this._onRowMouseOver(e);
},_onRowMouseOver:function(e){
if(this._dragging){
return;
}
if(!this._resizingState.resizing){
this._removeRowHover();
this._currentHoverDiv=e.eventMapTarget;
this._currentHoverCell=e.eventMapTarget;
var _e1=this.get_numberOfHoveredRows();
hoveredCells=[];
hoveredCells[0]=this._currentHoverCell;
if(Sys.UI.DomElement.containsCssClass(this._currentHoverCell.parentNode,"rsAllDay")||this.get_selectedView()==Telerik.Web.UI.SchedulerViewType.MonthView){
_e1=1;
}
for(var i=1;i<_e1;i++){
var _e3=this._getNextRowCell(hoveredCells[i-1]);
if(_e3){
hoveredCells[i]=_e3;
}else{
break;
}
}
for(var i=0;i<hoveredCells.length;i++){
Sys.UI.DomElement.addCssClass(hoveredCells[i],"rsAptCreate");
}
this._hoveredCells=hoveredCells;
}
},_getNextRowCell:function(_e4){
var _e5=_e4.parentNode;
var _e6=_e5.parentNode;
while(_e6.tagName.toLowerCase()!="table"){
_e6=_e6.parentNode;
}
var _e7=_e6.rows[_e5.rowIndex+1];
var _e8=null;
if(_e7){
var _e9=_e7.cells.length;
var _ea=_e5.cells.length;
if(_e9==_ea){
_e8=_e7.cells[_e4.cellIndex];
}else{
if(_e9<_ea){
_e8=_e7.cells[_e4.cellIndex-1];
}else{
_e8=_e7.cells[_e4.cellIndex+1];
}
}
}
return _e8;
},_onRowMouseOut:function(e){
try{
var _ec=e.rawEvent.relatedTarget?e.rawEvent.relatedTarget:e.rawEvent.toElement;
if(!_ec||!this._currentHoverCell||$telerik.isDescendant(this._currentHoverDiv,_ec)){
return;
}
this._removeRowHover();
}
catch(ex){
return;
}
},_removeRowHover:function(){
if(!this._hoveredCells){
return;
}
this._currentHoverCell=null;
for(var i=0;i<this._hoveredCells.length;i++){
Sys.UI.DomElement.removeCssClass(this._hoveredCells[i],"rsAptCreate");
}
if(this._currentHoverCell){
Sys.UI.DomElement.removeCssClass(this._currentHoverCell,"rsAptCreate");
}
},_stopEventPropagation:function(e){
e.stopPropagation();
},_onResizeGripMouseDown:function(e){
if(this.get_readOnly()){
return;
}
this._resizingState.resizingElement=this.getAppointmentDomElement(e.eventMapTarget);
var _f0=this.getAppointmentFromDomElement(this._resizingState.resizingElement);
var _f1=(_f0.get_allowEdit()!=null)?_f0.get_allowEdit():this.get_allowEdit();
if(!_f1){
return;
}
var _f2=new Telerik.Web.UI.SchedulerAppointmentResizeStartEventArgs(_f0);
this.raise_appointmentResizeStart(_f2);
if(_f2.get_cancel()==false){
this._resizingState.resizing=true;
this._resizingState.resizingAppointment=_f0;
this._resizingState.resizingAppointmentDuration=_f0._getDuration();
$addHandler(document,"mousemove",this._onResizeGripMouseMoveDelegate);
$addHandler(document,"mouseup",this._onResizeGripMouseUpDelegate);
$addHandler(document,"selectstart",this._onSelectStartDelegate);
}
},_onResizeGripMouseMove:function(e){
var _f4=this._resizingState.resizingElement;
if(!_f4){
return;
}
var _f5=_f4.parentNode.parentNode;
var _f6=10;
var _f7=this._getCellFromCoordinates(e.clientX,e.clientY-_f6);
if(!_f7){
return;
}
var _f8=this._activeModel.getTimeSlotFromDomElement(_f7);
var _f9=new Telerik.Web.UI.SchedulerAppointmentResizingEventArgs(this._resizingState.resizingAppointment,_f8);
this.raise_appointmentResizing(_f9);
if(_f9.get_cancel()){
return;
}
var _fa=_f5.offsetHeight;
var _fb=_f7.parentNode.rowIndex-_f5.parentNode.rowIndex;
var _fc=Math.max(1,(_fb+1))*_fa;
if($telerik.isIE&&$telerik.quirksMode){
var _fd=_f4.firstChild;
_fd.style.height="";
}
var _fe=_f5.parentNode.parentNode.parentNode;
var _ff=_f7.parentNode.parentNode.parentNode;
if(_fe!=_ff){
return;
}
var _100=parseInt(_f4.style.paddingBottom);
_100=isNaN(_100)?0:_100;
var _fc=_fc-_100;
if($telerik.isIE&&$telerik.quirksMode){
_fc-=$telerik.getBorderBox(_f5).vertical*2;
}
_f4.style.height=_fc+"px";
if($telerik.isIE&&$telerik.quirksMode&&_f4._initialHeightInRows){
Telerik.Web.UI.RadScheduler._adjustSingleAppointmentHeight(_f4,_f4._initialHeightInRows);
}
Telerik.Web.UI.RadScheduler._fixIEBottom(this._resizingState.resizingElement);
this._keepElementInView(this._resizingState.resizingElement,true);
},_onSelectStart:function(e){
return false;
},_findResizeTargetSlot:function(_102){
var _103=_102.parentNode.parentNode.offsetHeight;
var _104=Math.ceil(_102.offsetHeight/_103);
var _105=_102.parentNode.parentNode;
var _106=_105.parentNode;
var _107=_106.rowIndex+_104-1;
_107=Math.min(_107,_106.parentNode.rows.length-1);
var _108=_106.parentNode.rows[_107];
var _109=_108.cells[_105.cellIndex];
return this._activeModel.getTimeSlotFromDomElement(_109);
},_onResizeGripMouseUp:function(e){
if(!this._resizingState.resizingElement){
return;
}
var _10b=this._findResizeTargetSlot(this._resizingState.resizingElement);
var _10c=this.getAppointmentFromDomElement(this._resizingState.resizingElement);
var _10d=this._activeModel.getTimeSlotFromDomElement(_10c.get_element());
var _10e=_10b.get_startTime();
Telerik.Web.UI.RadScheduler._incrementTime(_10e,0,this.get_minutesPerRow());
if(_10e.getTime()==_10c.get_end().getTime()){
this._cleanupResize();
return;
}
var args={OnConfirm:this._onAppointmentResizeCallback,OnAbort:this._onAppointmentResizeAbortCallback,Scheduler:this,Appointment:_10c,SourceSlotIndex:_10d.get_index(),TargetSlotIndex:_10b.get_index(),UpdatedEndDate:_10e,ResizingAppointmentDuration:this._resizingState.resizingAppointmentDuration,CallbackIsCalledFromDialog:true};
if(_10c._recurrenceState==1||_10c._recurrenceState==2){
var _110=new Telerik.Web.UI.SchedulerRecurrenceActionDialogShowingEventArgs(args.Appointment,Telerik.Web.UI.RecurrenceAction.Resize);
this.raise_recurrenceActionDialogShowing(_110);
if(_110.get_cancel()){
var _111=_110.get_editSeries();
if(_111!==null){
args.CallbackIsCalledFromDialog=false;
this._onAppointmentResizeCallback(_111,args);
}else{
this._onAppointmentResizeAbortCallback(args);
}
}else{
this._recurrenceActionDialog.ConfirmRecurrenceAction(Telerik.Web.UI.RecurrenceAction.Resize,args);
}
}else{
args.CallbackIsCalledFromDialog=false;
this._onAppointmentResizeCallback(false,args);
}
e.stopPropagation();
this._cleanupResize();
},_cleanupResize:function(){
this._resizingState.resizing=false;
this._resizingState.resizingElement=null;
this._resizingState.resizingAppointment=null;
this._resizingState.resizingAppointmentDuration=null;
$removeHandler(document,"mousemove",this._onResizeGripMouseMoveDelegate);
$removeHandler(document,"mouseup",this._onResizeGripMouseUpDelegate);
$removeHandler(document,"selectstart",this._onSelectStartDelegate);
},_onAppointmentResizeCallback:function(_112,args){
if(args.CallbackIsCalledFromDialog){
var _114=new Telerik.Web.UI.SchedulerRecurrenceActionDialogClosedEventArgs(args.Appointment,Telerik.Web.UI.RecurrenceAction.Resize,_112);
args.Scheduler.raise_recurrenceActionDialogClosed(_114);
}
var _115=new Telerik.Web.UI.SchedulerAppointmentResizeEndEventArgs(args.Appointment,args.UpdatedEndDate,_112);
args.Scheduler.raise_appointmentResizeEnd(_115);
if(_115.get_cancel()==false){
var _116={Command:"Resize",AppointmentID:args.Appointment._internalID,SourceSlotIndex:args.SourceSlotIndex,TargetSlotIndex:args.TargetSlotIndex,EditSeries:_112};
args.Scheduler.postback(_116);
}else{
args.Appointment._setDuration(args.ResizingAppointmentDuration);
}
},_onAppointmentResizeAbortCallback:function(args){
args.Appointment._setDuration(args.ResizingAppointmentDuration);
},_onResizeGripMouseClick:function(e){
e.stopPropagation();
},_onResizeGripMouseOver:function(e){
e.target.style.cursor="s-resize";
e.stopPropagation();
},_initializeModelTables:function(){
this._modelTables=new Array();
var _11a=this.get_element().getElementsByTagName("table");
for(var i=0;i<_11a.length;i++){
var _11c=_11a[i];
if(Sys.UI.DomElement.containsCssClass(_11c,"rsContentTable")||Sys.UI.DomElement.containsCssClass(_11c,"rsAllDayTable")||Sys.UI.DomElement.containsCssClass(_11c,"rsTimelineTable")){
_11c.targetRect=$telerik.getBounds(_11c);
var _11d=_11c.rows[0].cells[0];
_11c.cellWidth=_11d.offsetWidth;
_11c.cellHeight=_11d.offsetHeight;
Array.add(this._modelTables,_11c);
}
}
return this._modelTables;
},_getCellFromCoordinates:function(_11e,_11f){
if(!this.get_element()){
return;
}
var _120=this._modelTables;
var _121=$telerik.getElementByClassName(this.get_element(),"rsContent","div");
var _122=$telerik.getScrollOffset(_121,true);
for(var i=0,_124=_120.length;i<_124;i++){
var x=_11e+_122.x;
var y=_11f+_122.y;
var _127=_120[i];
var _128=_127.targetRect;
var _129=_128.y+_128.height;
var _12a=_128.x+_128.width;
if(x>=_128.x&&x<=_12a&&y>=_128.y&&y<=_129){
var _12b=parseInt((y-_128.y)/_127.cellHeight);
_12b=Math.min(_127.rows.length-1,Math.max(0,_12b));
var _12c=parseInt((x-_128.x)/_127.cellWidth);
_12c=Math.min(_127.rows[_12b].cells.length-1,Math.max(0,_12c));
return _127.rows[_12b].cells[_12c];
}
}
return null;
},_shouldStartDrag:function(_12d){
if(!this._initialDragAppointment||!this._initialDragMousePos){
return false;
}
if(Math.abs(this._initialDragMousePos.x-_12d.x)>4||Math.abs(this._initialDragMousePos.y-_12d.y)>4){
return true;
}
},_onDocumentMouseMove:function(e){
var _12f=this._getMousePosition(e);
if(!this._dragging&&this._shouldStartDrag(_12f)){
this._startDrag(e);
}
if(!this._dragging||!this._draggingAppointment){
return;
}
this._clearSelection();
var _130=this._getCellFromCoordinates(e.clientX,e.clientY-this._draggingOffset);
if(!_130||_130.firstChild==this._draggingAppointment.get_element().parentNode){
return;
}
if(_130.firstChild.nodeType==3){
_130.removeChild(_130.firstChild);
var wrap=this._draggingAppointment.get_element().parentNode.cloneNode(false);
wrap.style.zIndex=_130.parentNode.parentNode.rows.length-_130.parentNode.rowIndex;
if($telerik.isFirefox){
wrap.style.height=_130.clientHeight+"px";
}
_130.appendChild(wrap);
}
if(this.get_selectedView()!=Telerik.Web.UI.SchedulerViewType.MonthView){
_130.firstChild.appendChild(this._draggingAppointment.get_element());
}else{
if(_130.childNodes[1]){
_130.childNodes[1].appendChild(this._draggingAppointment.get_element());
}
}
var _132=this._activeModel.getTimeSlotFromDomElement(_130);
var args=new Telerik.Web.UI.SchedulerAppointmentMovingEventArgs(this._draggingAppointment,_132);
this.raiseEvent("appointmentMoving",args);
if(args.get_cancel()){
this._abortDrag(e);
}else{
if(!_132.get_isAllDay()){
this._keepElementInView(this._draggingAppointment.get_element());
}
}
return;
},_keepElementInView:function(_134,_135){
var _136=$telerik.getElementByClassName(this.get_element(),"rsContent","div");
var _137=this._getRelativeOffsetTop(_134,_136);
var _138=_134.offsetHeight;
var _139=_137+_138;
var _13a=_136.clientHeight+_136.scrollTop;
var _13b=_134.parentNode.parentNode.offsetHeight;
if(!_135&&_137<_136.scrollTop){
_136.scrollTop=_137;
}
if(_139>_13a){
var _13c=_136.scrollTop+(_139-_13a);
if((_136.clientHeight+_13c)>_136.scrollHeight){
return;
}
if(!_135&&_13c>_137){
_13c=_137;
}
_136.scrollTop=_13c;
}
if(_135&&(_139-_13b)<_136.scrollTop){
_136.scrollTop=_139-_13b;
}
},_getRelativeOffsetTop:function(_13d,_13e){
var _13f=_13d.offsetParent;
var _140=_13d.offsetTop;
while(_13f!=_13e){
_140+=_13f.offsetTop;
if(!_13f.offsetParent){
break;
}
_13f=_13f.offsetParent;
}
return _140;
},_getMousePosition:function(e){
var _142=$telerik.getScrollOffset(document.body,true);
var _143=e.clientX;
var _144=e.clientY;
_143+=_142.x;
_144+=_142.y;
return {x:_143,y:_144};
},_onAppointmentMouseDown:function(e){
if(this.get_readOnly()){
return;
}
var _146=this.getAppointmentFromDomElement(e.eventMapTarget);
var _147=(_146.get_allowEdit()!=null)?_146.get_allowEdit():this.get_allowEdit();
if(!_147){
return;
}
this._initialDragMousePos=this._getMousePosition(e);
this._initialDragAppointment=_146;
$addHandler(document,"selectstart",this._onSelectStartDelegate);
$addHandler(document,"mouseup",this._onDocMouseUpDelegate);
$addHandler(document,"mousemove",this._onDocumentMouseMoveDelegate);
this._dragHandlersAttached=true;
},_startDrag:function(e){
var _149=this._initialDragAppointment;
var _14a=new Telerik.Web.UI.SchedulerAppointmentMoveStartEventArgs(_149);
this.raiseEvent("appointmentMoveStart",_14a);
if(_14a.get_cancel()){
return;
}
this._draggingAppointment=_149;
this._dragging=true;
var _14b=this._draggingAppointment.get_element();
var _14c=$telerik.getLocation(_14b);
if($telerik.isFirefox||$telerik.isSafari){
var _14d=$telerik.getScrollOffset(_14b,true);
_14c.x-=_14d.x;
_14c.y-=_14d.y;
if($telerik.isFirefox){
_14c.x+=document.body.parentNode.scrollLeft;
_14c.y+=document.body.parentNode.scrollTop;
}else{
_14c.x+=document.body.scrollLeft;
_14c.y+=document.body.scrollTop;
}
}
var _14e=$telerik.getLocation(this._getCellFromCoordinates(e.clientX,e.clientY));
var _14f=e.clientY-_14c.y;
var _150=e.clientY-_14e.y;
this._draggingOffset=_14f-_150;
if($telerik.isFirefox&&document.compatMode=="BackCompat"){
this._draggingOffset=0;
}
if(this.get_selectedView()==Telerik.Web.UI.SchedulerViewType.MonthView||this.get_selectedView()==Telerik.Web.UI.SchedulerViewType.TimelineView){
this._draggingOffset=0;
}
_149._startDrag();
},_endDrag:function(e){
this._finishDrag(e,false);
},_onDocMouseUp:function(e){
this._finishDrag(e,false);
},_abortDrag:function(e){
this._finishDrag(e,true);
},_finishDrag:function(e,_155){
if(this._dragHandlersAttached){
$removeHandler(document,"selectstart",this._onSelectStartDelegate);
$removeHandler(document,"mouseup",this._onDocMouseUpDelegate);
$removeHandler(document,"mousemove",this._onDocumentMouseMoveDelegate);
this._dragHandlersAttached=false;
}
if(this._dragging){
if(!_155&&this._draggingAppointment.get_element().parentNode&&this._draggingAppointment.get_element().parentNode.parentNode){
var _156=this._draggingAppointment.get_element().parentNode.parentNode;
this._draggingAppointment._endDrag(_156);
}else{
this._draggingAppointment._abortDrag();
}
this._draggingAppointment=null;
this._dragging=false;
e.preventDefault();
e.stopPropagation();
}
},_onAppointmentDoubleClick:function(e){
if(this._resizingState.resizing){
this._resizingState.resizing=false;
e.stopPropagation();
return;
}
this._clearSelection();
var _158=this.getAppointmentFromDomElement(e.eventMapTarget);
var _159=new Telerik.Web.UI.SchedulerAppointmentDoubleClickEventArgs(_158);
this.raise_appointmentDoubleClick(_159);
this._editAppointmentInline(_158);
e.stopPropagation();
},_editAppointmentInline:function(_15a){
if(this.get_readOnly()){
return;
}
if(_15a){
var _15b=(_15a.get_allowEdit()!=null)?_15a.get_allowEdit():this.get_allowEdit();
if(!_15b){
return;
}
var args={OnConfirm:this._onAppointmentEditCallback,Scheduler:this,Appointment:_15a,CallbackIsCalledFromDialog:true};
if(_15a._recurrenceState==1||_15a._recurrenceState==2||_15a._recurrenceState==3){
var _15d=new Telerik.Web.UI.SchedulerRecurrenceActionDialogShowingEventArgs(args.Appointment,Telerik.Web.UI.RecurrenceAction.Edit);
this.raise_recurrenceActionDialogShowing(_15d);
if(_15d.get_cancel()){
var _15e=_15d.get_editSeries();
if(_15e!==null){
args.CallbackIsCalledFromDialog=false;
this._onAppointmentEditCallback(_15e,args);
}
}else{
this._recurrenceActionDialog.ConfirmRecurrenceAction(Telerik.Web.UI.RecurrenceAction.Edit,args);
}
}else{
args.CallbackIsCalledFromDialog=false;
this._onAppointmentEditCallback(false,args);
}
}
},_onAppointmentEditCallback:function(_15f,args){
if(args.CallbackIsCalledFromDialog){
var _161=new Telerik.Web.UI.SchedulerRecurrenceActionDialogClosedEventArgs(args.Appointment,Telerik.Web.UI.RecurrenceAction.Edit,_15f);
args.Scheduler.raise_recurrenceActionDialogClosed(_161);
}
if(!this._editing){
var _162=new Telerik.Web.UI.SchedulerAppointmentEditingEventArgs(args.Appointment,_15f);
args.Scheduler.raise_appointmentEditing(_162);
if(_162.get_cancel()==false){
this._editing=true;
var _163={Command:"Edit",AppointmentID:args.Appointment._internalID,EditSeries:_15f};
args.Scheduler.postback(_163);
}
}
},_clearSelection:function(){
if(document.selection&&document.selection.empty){
document.selection.empty();
}else{
if(window.getSelection&&window.getSelection().removeAllRanges){
window.getSelection().removeAllRanges();
}
}
},_onShowMoreClick:function(e){
var slot=this._activeModel.getTimeSlotFromDomElement(e.eventMapTarget);
var _166={Command:"SwitchToSelectedDay",SourceSlotIndex:slot.get_index()};
this.postback(_166);
},_onAppointmentMouseOver:function(e){
if(this._resizingState.resizing||this._dragging){
e.stopPropagation();
return;
}
var _168=this.getAppointmentDomElement(e.eventMapTarget);
var _169=this.getAppointmentFromDomElement(_168);
var _16a=(_169.get_allowDelete()!=null)?_169.get_allowDelete():this.get_allowDelete();
if(!_16a){
return;
}
this._hoveredAppointmentElement=_168;
var _16b=$telerik.getElementByClassName(_168,"rsAptDelete","a");
if(_16b){
_16b.style.visibility="visible";
}
},_onAppointmentMouseOut:function(e){
var _16d=e.rawEvent.relatedTarget?e.rawEvent.relatedTarget:e.rawEvent.toElement;
if(!_16d||$telerik.isDescendant(this._hoveredAppointmentElement,_16d)){
return;
}else{
var _16e=this.getAppointmentDomElement(e.eventMapTarget);
var _16f=$telerik.getElementByClassName(_16e,"rsAptDelete","a");
if(_16f){
_16f.style.visibility="hidden";
}
}
},_getCellCoordinates:function(_170){
while(_170&&(_170.tagName.toLowerCase()!="td")){
_170=_170.parentNode;
}
if(_170){
var _171=_170.cellIndex;
var _172=_170.parentNode.rowIndex;
return {cellIndex:_171,rowIndex:_172};
}
return -1;
},_getCellTimeFromDomElement:function(_173){
var _174=new Date(this.get_firstDayStart().getTime());
var _175=this._getCellCoordinates(_173);
if(this.get_selectedView()==Telerik.Web.UI.SchedulerViewType.MonthView){
var _176=24*7*_175.rowIndex;
var _177=24*_175.cellIndex;
Telerik.Web.UI.RadScheduler._incrementTime(_174,_176+_177);
}else{
if(this.get_selectedView()==Telerik.Web.UI.SchedulerViewType.ResourceView){
var _178=_175.rowIndex*this.get_minutesPerRow();
Telerik.Web.UI.RadScheduler._incrementTime(_174,0,_178);
}else{
var _178=_175.rowIndex*this.get_minutesPerRow();
Telerik.Web.UI.RadScheduler._incrementTime(_174,24*_175.cellIndex,_178);
}
}
return _174;
},_onCellClick:function(e){
var slot=this._activeModel.getTimeSlotFromDomElement(e.eventMapTarget);
var _17b=new Telerik.Web.UI.SchedulerTimeSlotClickEventArgs(slot.get_startTime(),slot);
this.raise_timeSlotClick(_17b);
},_onCellContextMenu:function(e){
var slot=this._activeModel.getTimeSlotFromDomElement(e.eventMapTarget);
var _17e=new Telerik.Web.UI.SchedulerTimeSlotContextMenuEventArgs(slot.get_startTime(),slot.get_isAllDay(),e,slot);
this.raise_timeSlotContextMenu(_17e);
},_onCellDoubleClick:function(e){
if(!this.get_readOnly()&&this.get_allowInsert()){
var slot=this._activeModel.getTimeSlotFromDomElement(e.eventMapTarget);
var _181=new Telerik.Web.UI.SchedulerAppointmentInsertingEventArgs(slot.get_startTime(),slot.get_isAllDay(),slot);
this.raise_appointmentInserting(_181);
if(_181.get_cancel()==false){
var _182={Command:"Insert",AppointmentID:-1,TargetSlotIndex:slot.get_index()};
this.postback(_182);
}
}
e.stopPropagation();
},_onAppointmentDeleteClick:function(e){
if(!this.get_readOnly()){
var _184=this.getAppointmentFromDomElement(e.eventMapTarget);
if(_184){
var args={OnConfirm:this._onAppointmentDeleteCallback,Scheduler:this,Appointment:_184,CallbackIsCalledFromDialog:true};
if(_184._recurrenceState==1||_184._recurrenceState==2||_184._recurrenceState==3){
var _186=new Telerik.Web.UI.SchedulerRecurrenceActionDialogShowingEventArgs(args.Appointment,Telerik.Web.UI.RecurrenceAction.Delete);
this.raise_recurrenceActionDialogShowing(_186);
if(_186.get_cancel()){
var _187=_186.get_editSeries();
if(_187!==null){
args.CallbackIsCalledFromDialog=false;
this._onAppointmentDeleteCallback(_187,args);
}
}else{
this._recurrenceActionDialog.ConfirmRecurrenceAction(Telerik.Web.UI.RecurrenceAction.Delete,args);
}
}else{
if(this.get_displayDeleteConfirmation()){
this._recurrenceActionDialog.ConfirmDelete(args);
}else{
args.CallbackIsCalledFromDialog=false;
this._onAppointmentDeleteCallback(false,args);
}
}
}
}
e.stopPropagation();
e.preventDefault();
},_onAppointmentDeleteCallback:function(_188,args){
if(args.CallbackIsCalledFromDialog){
var _18a=new Telerik.Web.UI.SchedulerRecurrenceActionDialogClosedEventArgs(args.Appointment,Telerik.Web.UI.RecurrenceAction.Delete,_188);
args.Scheduler.raise_recurrenceActionDialogClosed(_18a);
}
var _18b=new Telerik.Web.UI.SchedulerAppointmentDeletingEventArgs(args.Appointment,_188);
args.Scheduler.raise_appointmentDeleting(_18b);
if(_18b.get_cancel()==false){
var _18c={Command:"Delete",AppointmentID:args.Appointment._internalID,EditSeries:_188};
args.Scheduler.postback(_18c);
}
},_onPreviousDayClick:function(e){
var _18e=this.getAppointmentFromDomElement(e.eventMapTarget);
if(_18e){
var _18f={Command:"GoToPrevious",AppointmentID:_18e._internalID};
this.postback(_18f);
}
e.stopPropagation();
e.preventDefault();
},_onNextDayClick:function(e){
var _191=this.getAppointmentFromDomElement(e.eventMapTarget);
if(_191){
var _192={Command:"GoToNext",AppointmentID:_191._internalID};
this.postback(_192);
}
e.stopPropagation();
e.preventDefault();
},_onDayViewTabClick:function(e){
var _194={Command:"SwitchToDayView"};
this.postback(_194);
e.stopPropagation();
e.preventDefault();
},_onWeekViewTabClick:function(e){
var _196={Command:"SwitchToWeekView"};
this.postback(_196);
e.stopPropagation();
e.preventDefault();
},_onMonthViewTabClick:function(e){
var _198={Command:"SwitchToMonthView"};
this.postback(_198);
e.stopPropagation();
e.preventDefault();
},_onTimelineViewTabClick:function(e){
var _19a={Command:"SwitchToTimelineView"};
this.postback(_19a);
e.stopPropagation();
e.preventDefault();
},_onPreviousSchedulerDayClick:function(e){
var _19c={Command:"NavigateToPreviousPeriod"};
this.postback(_19c);
e.stopPropagation();
e.preventDefault();
},_onNextSchedulerDayClick:function(e){
var _19e={Command:"NavigateToNextPeriod"};
this.postback(_19e);
e.stopPropagation();
e.preventDefault();
},_onTodayClick:function(e){
var _1a0={Command:"GoToToday"};
this.postback(_1a0);
e.stopPropagation();
e.preventDefault();
},_onFullTimeLinkClick:function(e){
var _1a2={Command:"SwitchFullTime"};
this.postback(_1a2);
e.stopPropagation();
e.preventDefault();
},postback:function(args){
var _1a4=$telerik.getElementByClassName(this.get_element(),"rsContent","div");
args.ScrollTop=_1a4.scrollTop;
this._inPostback=true;
var _1a5=this.get_postBackReference().replace("arguments",Sys.Serialization.JavaScriptSerializer.serialize(args));
eval(_1a5);
},_getElementIndex:function(_1a6,_1a7){
if(!_1a6){
return;
}
for(var i=0;i<_1a6.length;i++){
if(_1a6[i]===_1a7){
return i;
}
}
return -1;
},add_appointmentClick:function(_1a9){
this.get_events().addHandler("AppointmentClick",_1a9);
},remove_appointmentClick:function(_1aa){
this.get_events().removeHandler("AppointmentClick",_1aa);
},raise_appointmentClick:function(args){
this.raiseEvent("AppointmentClick",args);
},add_appointmentInserting:function(_1ac){
this.get_events().addHandler("AppointmentInserting",_1ac);
},remove_appointmentInserting:function(_1ad){
this.get_events().removeHandler("AppointmentInserting",_1ad);
},raise_appointmentInserting:function(_1ae){
this.raiseEvent("AppointmentInserting",_1ae);
},add_appointmentDoubleClick:function(_1af){
this.get_events().addHandler("AppointmentDoubleClick",_1af);
},remove_appointmentDoubleClick:function(_1b0){
this.get_events().removeHandler("AppointmentDoubleClick",_1b0);
},raise_appointmentDoubleClick:function(_1b1){
this.raiseEvent("AppointmentDoubleClick",_1b1);
},add_appointmentResizeStart:function(_1b2){
this.get_events().addHandler("AppointmentResizeStart",_1b2);
},remove_appointmentResizeStart:function(_1b3){
this.get_events().removeHandler("AppointmentResizeStart",_1b3);
},raise_appointmentResizeStart:function(args){
this.raiseEvent("AppointmentResizeStart",args);
},add_appointmentResizeEnd:function(_1b5){
this.get_events().addHandler("AppointmentResizeEnd",_1b5);
},remove_appointmentResizeEnd:function(_1b6){
this.get_events().removeHandler("AppointmentResizeEnd",_1b6);
},raise_appointmentResizeEnd:function(args){
this.raiseEvent("AppointmentResizeEnd",args);
},add_appointmentResizing:function(_1b8){
this.get_events().addHandler("AppointmentResizing",_1b8);
},remove_appointmentResizing:function(_1b9){
this.get_events().removeHandler("AppointmentResizing",_1b9);
},raise_appointmentResizing:function(args){
this.raiseEvent("AppointmentResizing",args);
},add_appointmentDeleting:function(_1bb){
this.get_events().addHandler("AppointmentDeleting",_1bb);
},remove_appointmentDeleting:function(_1bc){
this.get_events().removeHandler("AppointmentDeleting",_1bc);
},raise_appointmentDeleting:function(args){
this.raiseEvent("AppointmentDeleting",args);
},add_timeSlotClick:function(_1be){
this.get_events().addHandler("TimeSlotClick",_1be);
},remove_timeSlotClick:function(_1bf){
this.get_events().removeHandler("TimeSlotClick",_1bf);
},raise_timeSlotClick:function(args){
this.raiseEvent("TimeSlotClick",args);
},add_appointmentEditing:function(_1c1){
this.get_events().addHandler("AppointmentEditing",_1c1);
},remove_appointmentEditing:function(_1c2){
this.get_events().removeHandler("AppointmentEditing",_1c2);
},raise_appointmentEditing:function(args){
this.raiseEvent("AppointmentEditing",args);
},add_appointmentMoveStart:function(_1c4){
this.get_events().addHandler("appointmentMoveStart",_1c4);
},remove_appointmentMoveStart:function(_1c5){
this.get_events().removeHandler("appointmentMoveStart",_1c5);
},add_appointmentMoving:function(_1c6){
this.get_events().addHandler("appointmentMoving",_1c6);
},remove_appointmentMoving:function(_1c7){
this.get_events().removeHandler("appointmentMoving",_1c7);
},add_appointmentMoveEnd:function(_1c8){
this.get_events().addHandler("appointmentMoveEnd",_1c8);
},remove_appointmentMoveEnd:function(_1c9){
this.get_events().removeHandler("appointmentMoveEnd",_1c9);
},add_recurrenceActionDialogShowing:function(_1ca){
this.get_events().addHandler("RecurrenceActionDialogShowing",_1ca);
},remove_recurrenceActionDialogShowing:function(_1cb){
this.get_events().removeHandler("RecurrenceActionDialogShowing",_1cb);
},raise_recurrenceActionDialogShowing:function(args){
this.raiseEvent("RecurrenceActionDialogShowing",args);
},add_recurrenceActionDialogClosed:function(_1cd){
this.get_events().addHandler("RecurrenceActionDialogClosed",_1cd);
},remove_recurrenceActionDialogClosed:function(_1ce){
this.get_events().removeHandler("RecurrenceActionDialogClosed",_1ce);
},raise_recurrenceActionDialogClosed:function(args){
this.raiseEvent("RecurrenceActionDialogClosed",args);
},add_formCreated:function(_1d0){
this.get_events().addHandler("FormCreated",_1d0);
},remove_formCreated:function(_1d1){
this.get_events().removeHandler("FormCreated",_1d1);
},raise_formCreated:function(args){
this.raiseEvent("FormCreated",args);
},add_appointmentContextMenu:function(_1d3){
this.get_events().addHandler("AppointmentContextMenu",_1d3);
},remove_appointmentContextMenu:function(_1d4){
this.get_events().removeHandler("AppointmentContextMenu",_1d4);
},raise_appointmentContextMenu:function(args){
this.raiseEvent("AppointmentContextMenu",args);
},add_timeSlotContextMenu:function(_1d6){
this.get_events().addHandler("TimeSlotContextMenu",_1d6);
},remove_timeSlotContextMenu:function(_1d7){
this.get_events().removeHandler("TimeSlotContextMenu",_1d7);
},raise_timeSlotContextMenu:function(args){
this.raiseEvent("TimeSlotContextMenu",args);
}};
Telerik.Web.UI.RadScheduler.registerClass("Telerik.Web.UI.RadScheduler",Telerik.Web.UI.RadWebControl);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RecurrenceAction=function(){
};
Telerik.Web.UI.RecurrenceAction.prototype={Edit:1,Delete:2,Resize:3,Move:4};
Telerik.Web.UI.RecurrenceAction.registerEnum("Telerik.Web.UI.RecurrenceAction");
Telerik.Web.UI.RecurrenceActionDialog=function(_1d9){
this._schedulerDomElement=_1d9.get_element();
this._scheduler=_1d9;
this._recurrenceDialogWrapper=null;
this._args=null;
this._btnOk=null;
this._btnCancel=null;
};
Telerik.Web.UI.RecurrenceActionDialog.CreateRadioButton=function(id,name,_1dc,_1dd){
var _1de;
if($telerik.isIE){
var html="<input type=\"radio\" ";
html+="id=\""+id+"\" ";
html+="name=\""+name+"\" ";
html+="value=\""+_1dc+"\" ";
if(_1dd){
html+="checked ";
}
html+="/>";
_1de=document.createElement(html);
}else{
_1de=document.createElement("input");
_1de.id=id;
_1de.type="radio";
_1de.name=name;
_1de.value=_1dc;
_1de.checked=_1dd;
}
return _1de;
};
Telerik.Web.UI.RecurrenceActionDialog.prototype={ConfirmRecurrenceAction:function(_1e0,args){
localization=this._scheduler.get_localization();
var _1e2;
var _1e3;
var _1e4;
switch(_1e0){
case Telerik.Web.UI.RecurrenceAction.Edit:
_1e2=localization.ConfirmRecurrenceEditTitle;
_1e3=localization.ConfirmRecurrenceEditOccurrence;
_1e4=localization.ConfirmRecurrenceEditSeries;
break;
case Telerik.Web.UI.RecurrenceAction.Resize:
_1e2=localization.ConfirmRecurrenceResizeTitle;
_1e3=localization.ConfirmRecurrenceResizeOccurrence;
_1e4=localization.ConfirmRecurrenceResizeSeries;
break;
case Telerik.Web.UI.RecurrenceAction.Delete:
_1e2=localization.ConfirmRecurrenceDeleteTitle;
_1e3=localization.ConfirmRecurrenceDeleteOccurrence;
_1e4=localization.ConfirmRecurrenceDeleteSeries;
break;
case Telerik.Web.UI.RecurrenceAction.Move:
_1e2=localization.ConfirmRecurrenceMoveTitle;
_1e3=localization.ConfirmRecurrenceMoveOccurrence;
_1e4=localization.ConfirmRecurrenceMoveSeries;
break;
}
var d=document;
this._args=args;
var _1e6=this._createDialog(_1e2);
if(!_1e6){
return;
}
var _1e7=_1e6.appendChild(d.createElement("div"));
var _1e8=_1e7.appendChild(Telerik.Web.UI.RecurrenceActionDialog.CreateRadioButton("choiceOccurrenceSpan_0","choiceOccurrenceSpan","OpenOccurrence",true));
var _1e9=_1e7.appendChild(d.createElement("label"));
_1e9.htmlFor=_1e8.id;
_1e9.appendChild(d.createTextNode(_1e3));
var _1ea=_1e6.appendChild(d.createElement("div"));
var _1eb=_1ea.appendChild(Telerik.Web.UI.RecurrenceActionDialog.CreateRadioButton("choiceOccurrenceSpan_1","choiceOccurrenceSpan","OpenSeries",false));
this._editSeriesRadio=_1eb;
var _1ec=_1ea.appendChild(d.createElement("label"));
_1ec.htmlFor=_1eb.id;
_1ec.appendChild(d.createTextNode(_1e4));
this._createButtons(_1e6,this._confirmRecurrenceActionOkClick,this._removeConfirmAction);
},_confirmRecurrenceActionOkClick:function(e){
var _1ee=this._editSeriesRadio.checked;
this._removeConfirmAction(e);
this._args.OnConfirm(_1ee,this._args);
e.preventDefault();
e.stopPropagation();
},ConfirmDelete:function(args){
localization=this._scheduler.get_localization();
var _1f0=localization.ConfirmDeleteTitle;
var _1f1=localization.ConfirmDeleteText;
var d=document;
this._args=args;
var _1f3=this._createDialog(_1f0);
if(!_1f3){
return;
}
var h2=_1f3.appendChild(d.createElement("h2"));
h2.appendChild(d.createTextNode(_1f1));
this._createButtons(_1f3,this._confirmDeleteOkClick,this._removeConfirmAction);
},_confirmDeleteOkClick:function(e){
var _1f6=false;
this._removeConfirmAction(e);
this._args.OnConfirm(_1f6,this._args);
e.preventDefault();
e.stopPropagation();
},_removeConfirmAction:function(e){
this.dispose();
if(this._args.OnAbort){
this._args.OnAbort(this._args);
}
e.preventDefault();
e.stopPropagation();
},_createDialog:function(_1f8){
var d=document;
if($telerik.getElementByClassName(this._schedulerDomElement,"rsModalContainer","div")){
return;
}
this._recurrenceDialogWrapper=d.createElement("div");
this._recurrenceDialogWrapper.style.position="relative";
this._recurrenceDialogWrapper.style.width="100%";
this._recurrenceDialogWrapper.style.zIndex=10000;
this._schedulerDomElement.insertBefore(this._recurrenceDialogWrapper,this._schedulerDomElement.childNodes[0]);
var _1fa=this._recurrenceDialogWrapper.appendChild(d.createElement("div"));
_1fa.className="rsModalContainer";
_1fa.onselectstart=function(){
return false;
};
_1fa.style.height=this._schedulerDomElement.offsetHeight+"px";
$telerik.setOpacity(_1fa,0.4);
var _1fb=this._recurrenceDialogWrapper.appendChild(d.createElement("div"));
_1fb.className="rsConfirmation";
_1fb.style.top=(this._schedulerDomElement.offsetHeight-_1fb.offsetHeight)/2+"px";
_1fb.style.left=(this._schedulerDomElement.offsetWidth-_1fb.offsetWidth)/2+"px";
_1fb.style.display="block";
var h1=_1fb.appendChild(d.createElement("h1"));
h1.appendChild(d.createTextNode(_1f8));
return _1fb;
},_createButtons:function(_1fd,_1fe,_1ff){
localization=this._scheduler.get_localization();
var OK=localization.ConfirmOK;
var _201=localization.ConfirmCancel;
var d=document;
var _203=_1fd.appendChild(d.createElement("div"));
_203.className="rsButtonContainer";
this._btnOk=_203.appendChild(d.createElement("a"));
this._btnOk.className="rsDialogButton";
this._btnOk.appendChild(d.createTextNode(OK));
this._btnOk.href="#";
this._btnOk.focus();
$addHandlers(this._btnOk,{"click":_1fe},this);
this._btnCancel=_203.appendChild(d.createElement("a"));
this._btnCancel.className="rsDialogButton";
this._btnCancel.appendChild(d.createTextNode(_201));
this._btnCancel.href="#";
$addHandlers(this._btnCancel,{"click":_1ff},this);
},dispose:function(){
if(this._btnOk){
$clearHandlers(this._btnOk);
}
if(this._btnCancel){
$clearHandlers(this._btnCancel);
}
if(this._recurrenceDialogWrapper&&this._recurrenceDialogWrapper.parentNode){
this._recurrenceDialogWrapper.parentNode.removeChild(this._recurrenceDialogWrapper);
}
}};
Telerik.Web.UI.RecurrenceActionDialog.registerClass("Telerik.Web.UI.RecurrenceActionDialog",null,Sys.IDisposable);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.SchedulerResource=function(_204){
this._key=_204.key;
this._type=_204.type;
this._text=_204.text;
this._internalKey=_204.internalKey;
this._available=_204.available;
};
Telerik.Web.UI.SchedulerResource.prototype={get_key:function(){
return this._key;
},get_type:function(){
return this._type;
},get_text:function(){
return this._text;
},get_available:function(){
return this._available;
},_getInternalKey:function(){
return this._internalKey;
}};
Telerik.Web.UI.SchedulerResource.registerClass("Telerik.Web.UI.SchedulerResource");
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.SchedulerResourceCollection=function(){
this._array=new Array();
};
Telerik.Web.UI.SchedulerResourceCollection.prototype={add:function(item){
var _206=this._array.length;
this.insert(_206,item);
},insert:function(_207,item){
Array.insert(this._array,_207,item);
},remove:function(item){
Array.remove(this._array,item);
},removeAt:function(_20a){
var item=this.getAppointment(_20a);
if(item){
this.remove(item);
}
},clear:function(){
this._array=new Array();
},get_count:function(){
return this._array.length;
},forEach:function(_20c){
for(var i=0,_20e=this.get_count();i<_20e;i++){
_20c(this.getResource(i));
}
},getResource:function(_20f){
return this._array[_20f];
},getResourcesByType:function(type){
var _211=new Telerik.Web.UI.SchedulerResourceCollection();
this.forEach(function(_212){
if(_212.get_type()==type){
_211.add(_212);
}
});
return _211;
}};
Telerik.Web.UI.SchedulerResourceCollection.registerClass("Telerik.Web.UI.SchedulerResourceCollection");
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.SchedulerAttributeCollection=function(){
this._data={};
this._keys=[];
};
Telerik.Web.UI.SchedulerAttributeCollection.prototype={getAttribute:function(key){
return this._data[key];
},setAttribute:function(key,_215){
this._add(key,_215);
var _216={};
_216[key]=_215;
},_add:function(key,_218){
if(Array.indexOf(this._keys,key)<0){
Array.add(this._keys,key);
}
this._data[key]=_218;
},removeAttribute:function(key){
Array.remove(this._keys,key);
delete this._data[key];
},_load:function(json){
for(var key in json){
this._add(key,json[key]);
}
},get_count:function(){
return this._keys.length;
}};
Telerik.Web.UI.SchedulerAttributeCollection.registerClass("Telerik.Web.UI.SchedulerAttributeCollection");
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.ISchedulerModel=function(){
};
Telerik.Web.UI.ISchedulerModel.prototype={getTimeSlotFromDomElement:function(_21c){
throw Error.notImplemented();
}};
Telerik.Web.UI.ISchedulerModel.registerInterface("Telerik.Web.UI.ISchedulerModel");
Telerik.Web.UI.ISchedulerTimeSlot=function(){
};
Telerik.Web.UI.ISchedulerTimeSlot.prototype={get_index:function(){
throw Error.notImplemented();
},get_isAllDay:function(){
throw Error.notImplemented();
},get_startTime:function(){
throw Error.notImplemented();
}};
Telerik.Web.UI.ISchedulerTimeSlot.registerInterface("Telerik.Web.UI.ISchedulerTimeSlot");

