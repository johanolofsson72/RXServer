Type.registerNamespace("Telerik.Web.UI");
Type.registerNamespace("Telerik.Web.UI.ProgressManager");
function getRadProgressManager(){
return Telerik.Web.UI.ProgressManager.Manager;
}
Telerik.Web.UI.RadProgressManager=function(_1){
Telerik.Web.UI.RadProgressManager.initializeBase(this,[_1]);
this._uniqueRequestIdentifier="RadUrid";
this._formId="";
this._form=null;
this._pageGUID="";
this._suppressMissingHttpModuleError=false;
this._refreshPeriod=500;
this._shouldRegisterForSubmit=true;
this._ajaxCallUrl="";
this._timeFormat="%HOURS%:%MINUTES%:%SECONDS%s";
};
Telerik.Web.UI.RadProgressManager.prototype={initialize:function(){
Telerik.Web.UI.RadProgressManager.callBaseMethod(this,"initialize");
this._registerAsPageManager();
this._initializeForm();
this._callbackUrl=this._createCallbackUrl(this._ajaxCallUrl);
this._waitingForResponse=false;
if(typeof (Telerik.Web.UI.ProgressAreas)=="undefined"){
Telerik.Web.UI.ProgressAreas=[];
}
if($telerik.isSafari){
this._safariPollerDelegate=Function.createDelegate(this,this._createSafariPoller);
Sys.Application.add_load(this._safariPollerDelegate);
}
},dispose:function(){
if(this._form&&this._shouldRegisterForSubmit==true){
$removeHandler(this._form,"submit",this._clientSubmitDelegate);
this._clientSubmitDelegate=null;
}
if($telerik.isSafari&&this._safariPollerDelegate){
Sys.Application.remove_load(this._safariPollerDelegate);
this._safariPollerDelegate=null;
}
Telerik.Web.UI.RadProgressManager.callBaseMethod(this,"dispose");
},_getSafariPollerDefinition:function(){
function SafariPoller(_2,_3,_4){
this._callbackUrl=_2;
this._refreshPeriod=_3;
this._waitingForResponse=false;
this._timeFormat=_4;
}
SafariPoller.prototype={_createReadyStateChangeDelegate:this._createReadyStateChangeDelegate,_sendXmlHttpRequest:this._sendXmlHttpRequest,_makeCallback:this._makeCallback,_getTimeStampedCallbackUrl:this._getTimeStampedCallbackUrl,_handleCallback:this._handleCallback,_errorOccured:this._errorOccured,_showNotFoundMessage:this._showNotFoundMessage,_showGenericErrorMessage:this._showGenericErrorMessage,_showInvalidContentMessage:this._showInvalidContentMessage,get_refreshPeriod:this.get_refreshPeriod,_modifyProgressData:this._modifyProgressData,getFormattedTime:this.getFormattedTime,_normalizeTime:this._normalizeTime,_toSeconds:this._toSeconds,_updateProgressAreas:this._updateProgressAreas,_formatTimePart:this._formatTimePart};
return SafariPoller;
},_getSafariProgressAreaDefinition:function(){
function SafariProgressArea(id){
this._id=id;
if(typeof (window.progressAreas)=="undefined"){
window.progressAreas=[];
}
window.progressAreas[window.progressAreas.length]=this;
}
SafariProgressArea.prototype={get_id:function(){
return this._id;
},show:Telerik.Web.UI.RadProgressArea.prototype.show,update:Telerik.Web.UI.RadProgressArea.prototype.update,updateHorizontalProgressBar:Telerik.Web.UI.RadProgressArea.prototype.updateHorizontalProgressBar,updateTextIndicator:Telerik.Web.UI.RadProgressArea.prototype.updateTextIndicator};
return SafariProgressArea;
},_addClassAsString:function(_6,_7,_8){
_8[_8.length]=_6.toString();
_8[_8.length]=";";
_8[_8.length]=_7;
_8[_8.length]=".prototype = {";
var _9=true;
for(var _a in _6.prototype){
var _b=_6.prototype[_a];
if(typeof (_b)!="function"){
continue;
}
if(!_9){
_8[_8.length]=",";
}
_9=false;
_8[_8.length]=_a;
_8[_8.length]=":";
_8[_8.length]=_b.toString();
}
_8[_8.length]="};";
},_createSafariPoller:function(){
this._createSafariIFrame();
},_addSafariProgressAreas:function(_c){
for(var i=0;i<Telerik.Web.UI.ProgressAreas.length;i++){
Telerik.Web.UI.ProgressAreas[i]._addSafariDefinition(_c);
}
},_setupSafariProgressAreas:function(){
for(var i=0;i<Telerik.Web.UI.ProgressAreas.length;i++){
Telerik.Web.UI.ProgressAreas[i]._setupSafariProgressAreaControls();
}
},_createSafariIFrame:function(){
this._safariPoller=document.createElement("iframe");
this._safariPoller.id=this._safariPoller.name=this.get_id()+"_safariPoller";
this._safariPoller.src="javascript:''";
this._safariPoller.style.display="none";
document.forms[0].appendChild(this._safariPoller);
var _f=this._safariPoller.contentWindow.document;
_f.open();
var _10=[];
_10[_10.length]="<scri"+"pt type='text/javascript'>";
this._addClassAsString(this._getSafariPollerDefinition(),"SafariPoller",_10);
_10[_10.length]="var pollerInstance = new SafariPoller('"+this._callbackUrl+"', "+this.get_refreshPeriod()+", '"+this.get_timeFormat()+"');";
_10[_10.length]="$telerik = {};";
_10[_10.length]="$telerik.isSafari = ";
_10[_10.length]=$telerik.isSafari.toString();
_10[_10.length]=";";
this._addClassAsString(this._getSafariProgressAreaDefinition(),"SafariProgressArea",_10);
this._addSafariProgressAreas(_10);
_10[_10.length]="</scr"+"ipt>";
_f.write("<html><head>"+_10.join("")+"</head><body></body></html>");
_f.close();
this._setupSafariProgressAreas();
},_registerAsPageManager:function(){
if(!Telerik.Web.UI.ProgressManager.Manager){
Telerik.Web.UI.ProgressManager.Manager=this;
}
},_initializeForm:function(){
this._form=$get(this._formId);
if(!this._form){
this._form=document.forms[0];
}
this._updateFormAction(this._form);
if(this._shouldRegisterForSubmit==true){
this._registerForSubmit(this._form);
}
},_updateFormAction:function(_11){
if(typeof (_11.action)=="undefined"){
_11.action="";
}
if(_11.action.match(/\?/)){
_11.action=this._removeQueryStringParameter(_11.action,this._uniqueRequestIdentifier);
if(_11.action.substring(_11.action.length-1)!="?"){
_11.action+="&";
}
}else{
_11.action+="?";
}
_11.action+=this._uniqueRequestIdentifier+"="+this._pageGUID;
_11.enctype=_11.encoding="multipart/form-data";
_11._initialAction=_11.action;
},_removeQueryStringParameter:function(_12,_13){
var _14=new RegExp("&?"+_13+"=[^&]*");
if(_12.match(_14)){
return _12.replace(_14,"");
}
return _12;
},_registerForSubmit:function(_15){
this._registerForLinkButtons(_15);
this._registerForRegularButtons(_15);
},_registerForLinkButtons:function(_16){
var _17=_16.submit;
try{
var _18=this;
_16.submit=function(){
if(_18._clientSubmitHandler()==false){
return;
}
_16.submit=_17;
_16.submit();
};
}
catch(exception){
try{
var _19=__doPostBack;
__doPostBack=function(_1a,_1b){
var _1c=true;
if(typeof (Page_ClientValidate)=="function"){
_1c=Page_ClientValidate();
}
if(_1c){
if(_18._clientSubmitHandler()==false){
return;
}
_19(_1a,_1b);
}
};
}
catch(exception){
}
}
},_registerForRegularButtons:function(_1d){
this._clientSubmitDelegate=Function.createDelegate(this,this._clientSubmitHandler);
$addHandler(_1d,"submit",this._clientSubmitDelegate);
},_clientSubmitHandler:function(_1e){
var _1f=new Sys.CancelEventArgs();
this.raiseEvent("submitting",_1f);
if(_1f.get_cancel()){
return $telerik.cancelRawEvent(_1e);
}
if(typeof (Page_IsValid)!="undefined"){
if(!Page_IsValid){
return;
}
}
this.startProgressPolling();
},startProgressPolling:function(){
this._initSelectedFilesCount();
this.raiseEvent("progressStarted");
if($telerik.isSafari){
this._safariPoller.contentWindow.pollerInstance._startTime=new Date();
this._safariPoller.contentWindow.pollerInstance._makeCallback();
this._safariPoller.contentWindow.pollerInstance._selectedFilesCount=this._selectedFilesCount;
}else{
this._startTime=new Date();
this._makeCallback();
}
},_initSelectedFilesCount:function(){
this._selectedFilesCount=0;
var _20=document.getElementsByTagName("input");
for(var i=0;i<_20.length;i++){
var _22=_20[i];
if(_22.type=="file"&&_22.value!=""){
this._selectedFilesCount++;
}
}
},_createReadyStateChangeDelegate:function(){
if(!$telerik.isSafari){
return Function.createDelegate(this,this._handleCallback);
}
var _23=this;
return function(){
_23._handleCallback();
};
},_sendXmlHttpRequest:function(){
if(typeof (XMLHttpRequest)!="undefined"){
this._xmlHttpRequest=new XMLHttpRequest();
}else{
if(typeof (ActiveXObject)!="undefined"){
this._xmlHttpRequest=new ActiveXObject("Microsoft.XMLHTTP");
}else{
return;
}
}
this._xmlHttpRequest.onreadystatechange=this._createReadyStateChangeDelegate();
if($telerik.isSafari){
this._xmlHttpRequest.open("GET",this._getTimeStampedCallbackUrl(),false);
}else{
this._xmlHttpRequest.open("GET",this._getTimeStampedCallbackUrl(),true);
}
this._xmlHttpRequest.send("");
},_makeCallback:function(){
if(!this._waitingForResponse){
this._waitingForResponse=true;
this._sendXmlHttpRequest();
}
},_handleCallback:function(){
if(this._xmlHttpRequest.readyState!=4){
return;
}
this._waitingForResponse=false;
if(this._errorOccured()){
return;
}
var _24=this._xmlHttpRequest.responseText;
if(_24){
try{
eval(_24);
}
catch(ex){
this._showInvalidContentMessage();
return;
}
if(rawProgressData){
if(!this._suppressMissingHttpModuleError&&rawProgressData.ProgressError){
alert(rawProgressData.ProgressError);
return;
}
if(rawProgressData.InProgress){
if(this._selectedFilesCount>0||rawProgressData.RadProgressContextCustomCounters){
this._modifyProgressData(rawProgressData);
if(!this._updateProgressAreas(rawProgressData)){
this.hideProgressAreas();
this._resetCancelClicked();
if(window.stop){
window.stop();
}else{
try{
document.execCommand("Stop");
}
catch(ex){
window.location.href=window.location.href;
}
}
return;
}
}
}
}
}
if($telerik.isSafari){
var _25=this;
var _26=function(){
_25._makeCallback();
};
window.setTimeout(_26,this.get_refreshPeriod());
}else{
if(Function.createDelegate){
var _26=Function.createDelegate(this,this._makeCallback);
window.setTimeout(_26,this.get_refreshPeriod());
}
}
},_createCallbackUrl:function(_27){
var _28=_27.indexOf("?")<0?"?":"&";
return _27+_28+this._uniqueRequestIdentifier+"="+this._pageGUID;
},_getTimeStampedCallbackUrl:function(){
return this._callbackUrl+"&RadUploadTimeStamp="+new Date().getTime()+"&";
},_modifyProgressData:function(_29){
var _2a=new Date()-this._startTime;
if(typeof (_29.TimeElapsed)=="undefined"){
_29.TimeElapsed=this.getFormattedTime(this._toSeconds(_2a));
}else{
if(parseInt(_29.TimeElapsed).toString()==_29.TimeElapsed){
_29.TimeElapsed=this.getFormattedTime(this._toSeconds(_29.TimeElapsed));
}
}
if(typeof (_29.SecondaryTotal)=="undefined"){
_29.SecondaryTotal=this._selectedFilesCount;
}
if(typeof (_29.SecondaryPercent)=="undefined"){
_29.SecondaryPercent=Math.round(100*_29.SecondaryValue/(this._selectedFilesCount!=0?this._selectedFilesCount:1));
}
if(typeof (_29.TimeEstimated)=="undefined"&&typeof (_29.PrimaryPercent)=="number"){
if(_29.PrimaryPercent==0){
_29.TimeEstimated=this.getFormattedTime(this._toSeconds(359999000));
}else{
_29.TimeEstimated=this.getFormattedTime(this._toSeconds(_2a*(100/_29.PrimaryPercent-1)));
}
}else{
if(parseInt(_29.TimeEstimated).toString()==_29.TimeEstimated){
_29.TimeEstimated=this.getFormattedTime(this._toSeconds(_29.TimeEstimated));
}
}
},_updateProgressAreas:function(_2b){
if($telerik.isSafari){
for(var i=0;i<progressAreas.length;i++){
var _2d=progressAreas[i];
if(_2d.cancelClicked){
return false;
}
_2d.update(_2b);
}
}else{
this.raiseEvent("progressUpdating",{ProgressData:_2b});
for(var i=0;i<Telerik.Web.UI.ProgressAreas.length;i++){
var _2d=Telerik.Web.UI.ProgressAreas[i];
if(_2d.cancelClicked){
return false;
}
_2d.update(_2b);
}
}
return true;
},_resetCancelClicked:function(){
for(var i=0;i<Telerik.Web.UI.ProgressAreas.length;i++){
Telerik.Web.UI.ProgressAreas[i].cancelClicked=false;
}
this._initializeForm();
},hideProgressAreas:function(){
for(var i=0;i<Telerik.Web.UI.ProgressAreas.length;i++){
Telerik.Web.UI.ProgressAreas[i].hide();
}
},_toSeconds:function(_30){
return Math.round(_30/1000);
},_formatBytes:function(_31){
var _32=_31/1024;
var _33=_32/1024;
if(_33>0.8){
return ""+Math.round(_33*100)/100+"MB";
}
if(_32>0.8){
return ""+Math.round(_32*100)/100+"kB";
}
return ""+_31+" bytes";
},getFormattedTime:function(_34){
var _35=this._normalizeTime(_34);
return this._timeFormat.replace(/%HOURS%/,_35.Hours).replace(/%MINUTES%/,_35.Minutes).replace(/%SECONDS%/,_35.Seconds);
},_normalizeTime:function(_36){
var _37=this._formatTimePart(_36%60);
var _38=Math.floor(_36/60);
var _39=this._formatTimePart(_38%60);
var _3a=this._formatTimePart(Math.floor(_38/60));
return {Hours:_3a,Minutes:_39,Seconds:_37};
},_formatTimePart:function(_3b){
if(_3b.toString().length>1){
return _3b.toString();
}
return "0"+_3b.toString();
},_errorOccured:function(){
if(!document.all){
return false;
}
if(this._xmlHttpRequest.status==404){
this._showNotFoundMessage();
}else{
if(this._xmlHttpRequest.status>0&&this._xmlHttpRequest.status!=200){
this._showGenericErrorMessage();
}else{
return false;
}
}
return true;
},_showNotFoundMessage:function(){
alert("RadUpload Ajax callback error. Source url was not found: \n\r\n\r"+this._callbackUrl+"\n\r\n\rDid you register the RadUploadProgressHandler in web.config?"+"\r\n\r\nPlease, see the help for more details: RadUpload for ASP.NET Ajax - Configuration - RadUploadProgressHandler.");
},_showGenericErrorMessage:function(){
alert("RadUpload Ajax callback error. Source url returned error: "+this._xmlHttpRequest.status+" \n\r\n\r"+this._xmlHttpRequest.statusText+" \n\r\n\r"+this._callbackUrl+"\n\r\n\rDid you register the RadUploadProgressHandler in web.config?"+"\r\n\r\nPlease, see the help for more details: RadUpload for ASP.NET Ajax - Configuration - RadUploadProgressHandler.");
},_showInvalidContentMessage:function(){
alert("RadUpload Ajax callback error. Source url returned invalid content: \n\r\n\r"+this._xmlHttpRequest.responseText+"\n\r\n\r"+this._callbackUrl+"\n\r\n\rDid you register the RadUploadProgressHandler in web.config?"+"\r\n\r\nPlease, see the help for more details: RadUpload for ASP.NET Ajax - Configuration - RadUploadProgressHandler.");
},get_formId:function(){
return this._formId;
},set_formId:function(_3c){
this._formId=_3c;
},get_refreshPeriod:function(){
return this._refreshPeriod;
},set_refreshPeriod:function(_3d){
if(_3d&&!isNaN(_3d)&&_3d>=500){
this._refreshPeriod=_3d;
}
},get_pageGUID:function(){
return this._pageGUID;
},set_pageGUID:function(_3e){
this._pageGUID=_3e;
},get_suppressMissingHttpModuleError:function(){
return this._suppressMissingHttpModuleError;
},set_suppressMissingHttpModuleError:function(_3f){
this._suppressMissingHttpModuleError=_3f;
},get_shouldRegisterForSubmit:function(){
return this._shouldRegisterForSubmit;
},set_shouldRegisterForSubmit:function(_40){
this._shouldRegisterForSubmit=_40;
},get_ajaxCallUrl:function(){
return this._ajaxCallUrl;
},set_ajaxCallUrl:function(_41){
this._ajaxCallUrl=_41;
},get_timeFormat:function(){
return this._timeFormat;
},set_timeFormat:function(_42){
this._timeFormat=_42;
},add_progressStarted:function(_43){
this.get_events().addHandler("progressStarted",_43);
},remove_progressStarted:function(_44){
this.get_events().removeHandler("progressStarted",_44);
},add_progressUpdating:function(_45){
this.get_events().addHandler("progressUpdating",_45);
},remove_progressUpdating:function(_46){
this.get_events().removeHandler("progressUpdating",_46);
},add_submitting:function(_47){
this.get_events().addHandler("submitting",_47);
},remove_submitting:function(_48){
this.get_events().removeHandler("submitting",_48);
}};
Telerik.Web.UI.RadProgressManager.registerClass("Telerik.Web.UI.RadProgressManager",Telerik.Web.UI.RadWebControl);

