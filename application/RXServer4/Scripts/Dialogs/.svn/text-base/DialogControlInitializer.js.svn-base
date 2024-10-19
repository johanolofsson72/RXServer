Type.registerNamespace("Telerik.Web.UI.Dialogs");
function initDialog(){
var _1=$find("initializer");
if(_1){
_1.distributeClientParameters();
}
}
Telerik.Web.UI.Dialogs.DialogInitializer=function(_2){
Telerik.Web.UI.Dialogs.DialogInitializer.initializeBase(this,[_2]);
this._parameterConsumers=[];
};
Telerik.Web.UI.Dialogs.DialogInitializer.prototype={initialize:function(){
Telerik.Web.UI.Dialogs.DialogInitializer.callBaseMethod(this,"initialize");
this._appLoadHandlerDelegate=Function.createDelegate(this,this._appLoadHandler);
Sys.Application.add_load(this._appLoadHandlerDelegate);
},get_parameterConsumers:function(){
return this._parameterConsumers;
},set_parameterConsumers:function(_3){
this._parameterConsumers=_3;
},get_clientParameters:function(){
return Telerik.Web.UI.Dialogs.CommonDialogScript.get_windowReference().ClientParameters;
},autoSizeWindow:function(){
try{
var _4=Telerik.Web.UI.Dialogs.CommonDialogScript.get_windowReference();
if(_4){
var _5=document.body.offsetHeight;
var _6=_4.get_contentFrame().offsetHeight;
var _7=_5-_6;
if(_7&&_7<100){
var _5=_4.getWindowBounds().height;
_5+=_7;
_4.set_height(_5);
}
}
}
catch(e){
}
},distributeClientParameters:function(){
this.autoSizeWindow();
for(var i=0;i<this._parameterConsumers.length;i++){
var _9=$find(this._parameterConsumers[i]);
_9.clientInit(this.get_clientParameters());
}
},_appLoadHandler:function(){
this.distributeClientParameters();
Sys.Application.remove_load(this._appLoadHandlerDelegate);
this._appLoadHandlerDelegate=null;
}};
Telerik.Web.UI.Dialogs.DialogInitializer.registerClass("Telerik.Web.UI.Dialogs.DialogInitializer",Telerik.Web.UI.RadWebControl);

