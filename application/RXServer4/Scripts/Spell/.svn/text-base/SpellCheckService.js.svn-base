Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.SpellCheckService=function(){
Telerik.Web.UI.SpellCheckService.initializeBase(this);
this._url="Telerik.Web.UI.SpellCheckHandler.axd";
this._language="en-US";
this._configuration=null;
};
Telerik.Web.UI.SpellCheckService.prototype={spellCheck:function(_1){
this._sendRequest(this._getPostData("SpellCheck",_1));
},addCustomWord:function(_2){
this._sendRequest(this._getPostData("AddCustom",_2));
},_processResponse:function(_3,_4){
var _5=_3.get_statusCode();
if(_3.get_responseAvailable()&&200==_5&&_3.get_responseData().length>0){
var _6=_3.get_object();
if(_6.badWords!=null){
_6.badWords=eval(_6.badWords);
}
if(_6.wordOffsets!=null){
_6.wordOffsets=eval(_6.wordOffsets);
}
this.raise_complete(_3.get_object());
}else{
if(_3.get_timedOut()){
alert("Spell Check Request time out");
}else{
if(_3.get_aborted()){
alert("Spell Check Request aborted");
}else{
if(404==_5){
window.alert("Web.config registration missing!\n The spellchecking functionality of requires a HttpHandler registration in web.config. Please, use the control Smart Tag to add the handler automatically, or see the help for more information\n\n"+this.get_url());
}else{
if(_5>0&&_5!=200){
window.alert("Spell Check Handler Server Error:"+_5+"\n"+_3.get_responseData());
}
}
}
}
}
},_sendRequest:function(_7,_8){
var _9=new Sys.Net.WebRequest();
_9.set_url(this.get_url());
_9.set_httpVerb("POST");
_9.set_body(_7);
_9.add_completed(Function.createDelegate(this,this._processResponse));
_9.invoke();
},_getPostData:function(_a,_b){
return "DictionaryLanguage="+this._encode(this._language)+"&Configuration="+this._encode(this._configuration)+"&CommandArgument="+this._encode(_b)+"&CommandName="+_a;
},_encode:function(_c){
var _d=true;
try{
var _e=$telerik.isIE?document.charset:document.characterSet;
_e=_e+"";
if(_e&&_e.toLowerCase().indexOf("utf")==-1){
_d=false;
}
}
catch(e){
}
return (encodeURIComponent&&_d)?encodeURIComponent(_c):escape(_c);
},initialize:function(){
Telerik.Web.UI.SpellCheckService.callBaseMethod(this,"initialize");
},dispose:function(){
Telerik.Web.UI.SpellCheckService.callBaseMethod(this,"dispose");
},get_url:function(){
return this._url;
},set_url:function(_f){
this._url=_f;
},get_language:function(){
return this._language;
},set_language:function(_10){
this._language=_10;
},get_configuration:function(){
return this._configuration;
},set_configuration:function(_11){
this._configuration=_11;
},add_complete:function(_12){
this.get_events().addHandler("complete",_12);
},remove_complete:function(_13){
this.get_events().removeHandler("complete",_13);
},raise_complete:function(_14){
var _15=this.get_events().getHandler("complete");
if(_15){
if(!_14){
_14=Sys.EventArgs.Empty;
}
_15(this,_14);
}
}};
Telerik.Web.UI.SpellCheckService.registerClass("Telerik.Web.UI.SpellCheckService",Sys.Component);

