Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.DialogDefinition=function(){
this.Width="600px";
this.Height="400px";
this.Title="";
this.Behaviors=36;
this.Modal=true;
this.VisibleStatusbar=false;
this.VisibleTitlebar=true;
this.ClientCallbackFunction="";
};
Telerik.Web.UI.DialogDefinition.registerClass("Telerik.Web.UI.DialogDefinition",null);
Telerik.Web.UI.DialogDefinitionsDictionary=function(_1){
for(var _2 in _1){
var _3=_1[_2];
var _4=new Telerik.Web.UI.DialogDefinition();
for(var _5 in _3){
_4[_5]=_3[_5];
}
this[_2]=_4;
}
};
Telerik.Web.UI.DialogDefinitionsDictionary.registerClass("Telerik.Web.UI.DialogDefinitionsDictionary",null);
Telerik.Web.UI.DialogOpenEventArgs=function(_6,_7){
Telerik.Web.UI.DialogOpenEventArgs.initializeBase(this);
this._dialogName=_6;
if(_7){
this._parameters=_7;
}else{
this._parameters={};
}
};
Telerik.Web.UI.DialogOpenEventArgs.prototype={get_dialogName:function(){
return this._dialogName;
},set_parameters:function(_8){
this._parameters=_8;
},get_parameters:function(){
return this._parameters;
}};
Telerik.Web.UI.DialogOpenEventArgs.registerClass("Telerik.Web.UI.DialogOpenEventArgs",Sys.EventArgs);
Telerik.Web.UI.DialogOpener=function(_9){
Telerik.Web.UI.DialogOpener.initializeBase(this,[_9]);
this._additionalQueryString="";
this._dialogDefinitions={};
this._handlerUrl="";
this._handlerChecked=false;
this._useClassicDialogs=false;
this._language="en-US";
this._skin="";
this._dialogParametersProviderTypeName="";
this._dialogUrlLengthLimit=2000;
this._dialogUniqueID="";
this._dialogContainers={};
this._container=null;
this._something="";
};
Telerik.Web.UI.DialogOpener.prototype={initialize:function(){
Telerik.Web.UI.DialogOpener.callBaseMethod(this,"initialize");
this._dialogDefinitions=new Telerik.Web.UI.DialogDefinitionsDictionary(this.get_dialogDefinitions());
},dispose:function(){
Telerik.Web.UI.DialogOpener.callBaseMethod(this,"dispose");
},get_container:function(){
if(this._container==null){
this._container=this._findChildControl("Window");
}
return this._container;
},get_additionalQueryString:function(){
return this._additionalQueryString;
},set_additionalQueryString:function(_a){
this._additionalQueryString=_a;
},get_dialogDefinitions:function(){
return this._dialogDefinitions;
},get_handlerUrl:function(){
return this._handlerUrl;
},set_handlerUrl:function(_b){
this._handlerUrl=_b;
},get_useClassicDialogs:function(){
return this._useClassicDialogs;
},set_useClassicDialogs:function(_c){
this._useClassicDialogs=_c;
},get_language:function(){
return this._language;
},set_language:function(_d){
this._language=_d;
},get_skin:function(){
return this._skin;
},set_skin:function(_e){
this._skin=_e;
},add_open:function(_f){
this.get_events().addHandler("open",_f);
},remove_open:function(_10){
this.get_events().removeHandler("open",_10);
},add_close:function(_11){
this.get_events().addHandler("close",_11);
},remove_close:function(_12){
this.get_events().removeHandler("close",_12);
},openUrl:function(url,_14,_15,_16,_17,_18,_19,_1a,_1b,_1c,_1d){
var _1e=this._getDialogContainer("EXTERNAL_URL");
_1e.set_width(_15+"px");
_1e.set_height(_16+"px");
_1e.set_behaviors(_1b||Telerik.Web.UI.WindowBehaviors.Default);
_1e.set_modal(_1a||true);
_1e.set_visibleStatusbar(_1c||true);
_1e.set_visibleTitlebar(_1d||true);
var _1f=new Telerik.Web.UI.DialogOpenEventArgs(url,_14);
this.raiseEvent("open",_1f);
_1e.ClientParameters=_14;
_1e.set_clientCallBackFunction(_17);
_1e.setUrl(url);
_1e.show();
_1e.center();
window.setTimeout(function(){
_1e.setActive(true);
},100);
_1e._iframe.focus();
},open:function(_20,_21,_22){
if(!this._handlerChecked){
this._checkDialogHandler(this.get_handlerUrl());
}
var _23=this._getDialogContainer(_20);
var _24=this._getDialogDefinition(_20);
var _25=_24["Height"];
_23.set_height(_25);
_23.set_width(_24["Width"]);
_23.set_behaviors(_24["Behaviors"]);
_23.set_modal(_24["Modal"]);
_23.set_visibleStatusbar(_24["VisibleStatusbar"]);
_23.set_visibleTitlebar(_24["VisibleTitlebar"]);
if(_24["ReloadOnShow"]!=null){
_23.set_reloadOnShow(_24["ReloadOnShow"]);
}
var _26=new Telerik.Web.UI.DialogOpenEventArgs(_20,_21);
this.raiseEvent("open",_26);
_23.ClientParameters=_26.get_parameters();
this._applyParameters(_20,_23);
if(!_22){
_22=_24.ClientCallbackFunction;
}
if(_22){
_23.set_clientCallBackFunction(_22);
}
_23.show();
_23.set_height(_25);
_23.center();
window.setTimeout(function(){
_23.setActive(true);
},100);
if(!$telerik.isSafari||$telerik.isSafari3){
_23._iframe.focus();
}
},_applyParameters:function(_27,_28){
var _29=this._getDialogParameters(_27);
if(!_29){
return;
}
var _2a="&dp="+encodeURIComponent(this._getDialogParameters(_27));
var _2b=this._getBaseDialogUrl(_27);
var _2c=_2b.length+_2a.length;
var _2d=this._dialogParametersProviderTypeName=="";
var _2e=_2d&&_2c<=this._dialogUrlLengthLimit;
if(_2e){
var _2f=_28.get_navigateUrl();
var url=_2b+_2a;
if(_2f!=url){
_28.setUrl(url);
}else{
var _31=_28.get_contentFrame();
if(_31&&_31.contentWindow&&_31.contentWindow.$find){
var _32=_31.contentWindow.initDialog;
if(_32){
_31.contentWindow.setTimeout(function(){
_32();
},1);
}
}
}
}else{
_28.setUrl(_2b);
_28.DialogParameters=this._getDialogParameters(_27);
}
},_closeContainerDelegate:function(_33){
this.raiseEvent("close",_33);
},_getDialogContainer:function(_34){
if(typeof (this._dialogContainers[_34])=="undefined"){
var _35=$find(this.get_id()+_34);
if(null!=_35){
_35.dispose();
}
this._dialogContainers[_34]=this.get_container().clone(this.get_id()+_34);
var _36=this;
this._dialogContainers[_34].get_dialogOpener=function(){
return _36;
};
this._dialogContainers[_34].add_close(Function.createDelegate(this,this._closeContainerDelegate));
}
return this._dialogContainers[_34];
},_getBaseDialogUrl:function(_37){
var _38=this.get_handlerUrl().indexOf("?")<0?"?":"&";
return this.get_handlerUrl()+_38+"DialogName="+_37+"&Skin="+this.get_skin()+"&Title="+this._getDialogDefinition(_37)["Title"]+"&doid="+this._dialogUniqueID+"&dpptn="+encodeURIComponent(this._dialogParametersProviderTypeName)+this.get_additionalQueryString();
},_getDialogDefinition:function(_39){
var _3a=this.get_dialogDefinitions()[_39];
if(_3a){
return _3a;
}else{
throw Error.argumentNull("dialogName",String.format("Dialog Parameters for the {0} dialog do not exist",_39));
}
},_getDialogParameters:function(_3b){
return this._getDialogDefinition(_3b)["SerializedParameters"];
},_checkDialogHandler:function(url){
var _3d=url.indexOf("?")<0?"?":"&";
var _3e=url+_3d+"checkHandler=true";
var _3f=new Sys.Net.WebRequest();
_3f.set_url(_3e);
_3f.add_completed(Function.createDelegate(this,this._checkRequestCompleted));
var _40=new Sys.Net.XMLHttpExecutor();
_3f.set_executor(_40);
_40.executeRequest();
},_checkRequestCompleted:function(_41,_42){
if(_41.get_responseAvailable()){
var _43=_41.get_webRequest();
var _44=_41.get_responseData();
if(_44&&_44.indexOf("HandlerCheckOK")>0){
this._handlerChecked=true;
return;
}
}
window.alert("Web.config registration missing!\n The Telerik dialogs require a HttpHandler registration in the web.config file. Please, use the control's Smart Tag to add the handler automatically, or see the help for more information: Controls > Editor > Dialogs");
}};
Telerik.Web.UI.DialogOpener.registerClass("Telerik.Web.UI.DialogOpener",Telerik.Web.UI.RadWebControl);

