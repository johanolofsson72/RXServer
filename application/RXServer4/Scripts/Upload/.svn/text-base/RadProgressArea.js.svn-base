Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.ProgressAreaContainerName="Panel";
function getRadProgressArea(_1){
return $find(_1);
}
Telerik.Web.UI.RadProgressArea=function(_2){
Telerik.Web.UI.RadProgressArea.initializeBase(this,[_2]);
this._progressManagerFound=false;
this._popupVisible=false;
this._bodyElement=($telerik.standardsMode)?document.documentElement:document.body;
};
Telerik.Web.UI.RadProgressArea.prototype={initialize:function(){
Telerik.Web.UI.RadProgressArea.callBaseMethod(this,"initialize");
if(!this._progressManagerFound){
alert("Could not find an instance of RadProgressManager on the page. Are you missing the control declaration?");
}
this._setupControls();
this.cancelClicked=false;
if(this._cancelButtonElement){
$addHandlers(this._cancelButtonElement,{"click":this.cancelRequest},this);
}
if(typeof (Telerik.Web.UI.ProgressAreas)=="undefined"){
Telerik.Web.UI.ProgressAreas=[];
}
Telerik.Web.UI.ProgressAreas[Telerik.Web.UI.ProgressAreas.length]=this;
},dispose:function(){
if(this._cancelButtonElement){
$clearHandlers(this._cancelButtonElement);
}
Telerik.Web.UI.RadProgressArea.callBaseMethod(this,"dispose");
},_addSafariDefinition:function(_3){
_3[_3.length]=String.format("{0} = new SafariProgressArea('{0}');",this.get_id());
},_setupControls:function(){
this._clientId=this.get_id();
this._element=$get(this._clientId);
this._primaryProgressBarElement=this._findElement("PrimaryProgressBarInnerDiv");
this._primaryTotalElement=this._findElement("PrimaryTotal");
this._primaryValueElement=this._findElement("PrimaryValue");
this._primaryPercentElement=this._findElement("PrimaryPercent");
this._secondaryProgressBarElement=this._findElement("SecondaryProgressBarInnerDiv");
this._secondaryTotalElement=this._findElement("SecondaryTotal");
this._secondaryValueElement=this._findElement("SecondaryValue");
this._secondaryPercentElement=this._findElement("SecondaryPercent");
this._currentOperationElement=this._findElement("CurrentOperation");
this._timeElapsedElement=this._findElement("TimeElapsed");
this._timeEstimatedElement=this._findElement("TimeEstimated");
this._speedElement=this._findElement("Speed");
this._cancelButtonElement=this._findElement("CancelButton");
},_setupSafariProgressAreaControls:function(){
if($telerik.isSafari){
this._getSafariProgressArea()._primaryProgressBarElement=this._primaryProgressBarElement;
this._getSafariProgressArea()._primaryTotalElement=this._primaryTotalElement;
this._getSafariProgressArea()._primaryValueElement=this._primaryValueElement;
this._getSafariProgressArea()._primaryPercentElement=this._getSafariProgressArea();
this._getSafariProgressArea()._secondaryProgressBarElement=this._secondaryProgressBarElement;
this._getSafariProgressArea()._secondaryTotalElement=this._secondaryTotalElement;
this._getSafariProgressArea()._secondaryValueElement=this._secondaryValueElement;
this._getSafariProgressArea()._secondaryPercentElement=this._secondaryPercentElement;
this._getSafariProgressArea()._currentOperationElement=this._currentOperationElement;
this._getSafariProgressArea()._timeElapsedElement=this._timeElapsedElement;
this._getSafariProgressArea()._timeEstimatedElement=this._timeEstimatedElement;
this._getSafariProgressArea()._speedElement=this._speedElement;
this._getSafariProgressArea()._cancelButtonElement=this._cancelButtonElement;
if(!this._element){
this._element=$get(this._clientId);
}
this._getSafariProgressArea()._element=this._element;
}
},_getSafariProgressArea:function(){
if(!this._safariProgressArea){
this._safariProgressArea=getRadProgressManager()._safariPoller.contentWindow[this.get_id()];
}
return this._safariProgressArea;
},_findElement:function(_4){
var _5=this._clientId+"_"+Telerik.Web.UI.ProgressAreaContainerName+"_"+_4;
return $get(_5);
},cancelRequest:function(){
this.cancelClicked=true;
},update:function(_6){
if(!$telerik.isSafari){
var _7=new Sys.CancelEventArgs();
_7._progressData=_6;
_7.get_progressData=function(){
return this._progressData;
};
this.raiseEvent("progressUpdating",_7);
if(_7.get_cancel()){
return;
}
this.show();
_7._progressValue=_6.PrimaryPercent;
_7._progressBarElementName="PrimaryProgressBar";
_7._progressBarElement=this._primaryProgressBarElement;
_7.get_progressValue=function(){
return this._progressValue;
};
_7.get_progressBarElementName=function(){
return this._progressBarElementName;
};
_7.get_progressBarElement=function(){
return this._progressBarElement;
};
this.raiseEvent("progressBarUpdating",_7);
if(!_7.get_cancel()){
this.updateHorizontalProgressBar(this._primaryProgressBarElement,_6.PrimaryPercent);
}
_7._progressValue=_6.SecondaryPercent;
_7._progressBarElementName="SecondaryProgressBar";
_7._progressBarElement=this._secondaryProgressBarElement;
this.raiseEvent("progressBarUpdating",_7);
if(!_7.get_cancel()){
this.updateHorizontalProgressBar(this._secondaryProgressBarElement,_6.SecondaryPercent);
}
}else{
this.show();
this.updateHorizontalProgressBar(this._primaryProgressBarElement,_6.PrimaryPercent);
this.updateHorizontalProgressBar(this._secondaryProgressBarElement,_6.SecondaryPercent);
}
this.updateTextIndicator(this._primaryTotalElement,_6.PrimaryTotal);
this.updateTextIndicator(this._primaryValueElement,_6.PrimaryValue);
this.updateTextIndicator(this._primaryPercentElement,_6.PrimaryPercent);
this.updateTextIndicator(this._secondaryTotalElement,_6.SecondaryTotal);
this.updateTextIndicator(this._secondaryValueElement,_6.SecondaryValue);
this.updateTextIndicator(this._secondaryPercentElement,_6.SecondaryPercent);
this.updateTextIndicator(this._currentOperationElement,_6.CurrentOperationText);
this.updateTextIndicator(this._timeElapsedElement,_6.TimeElapsed);
this.updateTextIndicator(this._timeEstimatedElement,_6.TimeEstimated);
this.updateTextIndicator(this._speedElement,_6.Speed);
},show:function(){
if(!this._element){
this._element=$get(this._clientId);
}
this._element.style.display="";
if(!$telerik.isSafari&&this._element.style.position=="absolute"){
if(!this._popupBehavior){
this._popupBehavior=$create(Telerik.Web.PopupBehavior,{"id":(new Date()-100)+"PopupBehavior","parentElement":this._bodyElement},null,null,this._element);
}
if(this._popupVisible==false){
this._popupVisible=true;
var _8=$telerik.getBounds(this._element);
var _9=this._element.style;
var x=_9.left?parseInt(_9.left):_8.x;
var y=_9.top?parseInt(_9.top):_8.y;
this._popupBehavior.set_x(x);
this._popupBehavior.set_y(y);
this._popupBehavior.show();
}
}
},hide:function(){
this._element.style.display="none";
if(this._popupBehavior){
this._popupBehavior.hide(true);
}
},updateTextIndicator:function(_c,_d){
if(_c&&typeof (_d)!="undefined"){
if(typeof (_c.value)=="string"){
_c.value=_d;
}else{
if(typeof (_c.innerHTML)=="string"){
_c.innerHTML=_d;
}
}
}
},updateHorizontalProgressBar:function(_e,_f){
if(_e&&typeof (_f)!="undefined"){
_e.style.width=_f+"%";
}
},updateVerticalProgressBar:function(_10,_11){
if(_10&&typeof (_11)!="undefined"){
_10.style.height=_11+"%";
}
},get_progressManagerFound:function(){
return this._progressManagerFound;
},set_progressManagerFound:function(_12){
this._progressManagerFound=_12;
},add_progressUpdating:function(_13){
this.get_events().addHandler("progressUpdating",_13);
},remove_progressUpdating:function(_14){
this.get_events().removeHandler("progressUpdating",_14);
},add_progressBarUpdating:function(_15){
this.get_events().addHandler("progressBarUpdating",_15);
},remove_progressBarUpdating:function(_16){
this.get_events().removeHandler("progressBarUpdating",_16);
}};
Telerik.Web.UI.RadProgressArea.registerClass("Telerik.Web.UI.RadProgressArea",Telerik.Web.UI.RadWebControl);

