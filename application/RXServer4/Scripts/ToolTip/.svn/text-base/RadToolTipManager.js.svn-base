Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadToolTipManager=function(_1){
Telerik.Web.UI.RadToolTipManager.initializeBase(this,[_1]);
this._targetControls=null;
this._isToolTipFactory=false;
this._loadOnDemand=false;
this._toolTipZoneID=null;
this._autoTooltipify=true;
this._updatePanelParent=null;
this._tooltips=[];
this._idCounter=100;
this._webServiceSettings=null;
};
Telerik.Web.UI.RadToolTipManager.prototype={initialize:function(_2){
this.set_zIndex($telerik.getCurrentStyle(this.get_element(),"zIndex"));
var _3=this.get_updatePanel();
if(_3){
this._updatePanelParent=_3.parentNode;
}
var _4=this.get_visibleOnPageLoad();
this.set_visibleOnPageLoad(false);
var _5=this.get_toolTipZoneID();
this.tooltipify(_5?$get(_5):document,_5?this._isDescendant:null);
if(_4&&this._tooltips[0]){
this._tooltips[0].show();
}
window.setTimeout(Function.createDelegate(this,function(){
this._trackPageUpdates();
}),0);
},get_updatePanel:function(){
return $get(this._getUpdatePanelID());
},dispose:function(){
this._moveUpdatePanel();
this._disposeToolTips();
var _6=Sys.WebForms.PageRequestManager.getInstance();
_6.remove_pageLoaded(this._pageLoadedHandler);
this._pageLoadedHandler=null;
this._updatePanelParent=null;
Telerik.Web.UI.RadToolTipManager.callBaseMethod(this,"dispose");
},_disposeToolTips:function(){
for(var i=0;i<this._tooltips.length;i++){
var t=this._tooltips[i];
t.dispose();
}
this._tooltips=null;
},_isDescendant:function(_9,_a){
return $telerik.isDescendant(_9,_a);
},_trackPageUpdates:function(){
this._pageLoadedHandler=Function.createDelegate(this,function(_b,_c){
var _d=_c.get_panelsUpdated();
if(!_d){
return;
}
for(var i=0;i<_d.length;i++){
if(_d[i].id==this._getUpdatePanelID()){
continue;
}
this.tooltipify(_d[i],this._isDescendant);
}
});
var _f=Sys.WebForms.PageRequestManager.getInstance();
_f.add_pageLoaded(this._pageLoadedHandler);
},get_toolTips:function(){
return this._tooltips;
},get_tooltips:function(){
return this.get_toolTips();
},getToolTipByElement:function(_10){
if(!_10){
return null;
}
var _11=this.get_tooltips();
try{
for(var i=0;i<_11.length;i++){
if(_11[i].get_targetControl()==_10){
return _11[i];
}
}
}
catch(ex){
}
return null;
},createToolTip:function(_13,_14,_15){
var _16=_13.getAttribute("title");
_13.removeAttribute("title");
var _17=this.clone(_13,this._getUniqueToolTipID());
this._tooltips[this._tooltips.length]=_17;
if(_14&&_14!=_13.getAttribute("id")){
_17.set_serverTargetControlID(_14);
}
if(_15){
_17.set_serverValue(_15);
}
if(this._loadOnDemand){
this._initializeAjaxToolTip(_17);
}else{
if(this._webServiceSettings){
this._initializeWebServiceToolTip(_17);
}else{
var _18=this.get_text();
if(!_18){
_18=_16;
}
_17.set_text(_18);
}
}
return _17;
},tooltipify:function(_19,_1a){
if(!_19){
_19=document;
}
if(!_1a){
_1a=function(_1b,_1c){
return true;
};
}
var _1d=this.get_targetControls();
if(_1d.length>0){
for(var i=0;i<_1d.length;i++){
var _1f=_1d[i];
var _20=$get(_1f[0]);
if(_20&&_1a(_19,_20)){
this.createToolTip(_20,_1f[1],_1f[2]);
}
}
}else{
if(_19==document&&!this.get_autoTooltipify()){
return;
}
var _1d=_19.getElementsByTagName("*");
for(var i=0;i<_1d.length;i++){
var _20=_1d[i];
var _21=_20.getAttribute("title");
var alt=_20.getAttribute("alt");
if(_20&&(_21||alt)){
if(!_21){
_20.setAttribute("title",alt);
_20.removeAttribute("alt");
}else{
if(alt){
_20.removeAttribute("alt");
}
}
this.createToolTip(_20);
}
}
}
},_initializeWebServiceLoader:function(){
this._webServiceLoader=new Telerik.Web.UI.WebServiceLoader(this.get_webServiceSettings());
this._webServiceLoader.add_loadingError(function(_23,_24){
var _25=_24.get_message();
alert(_25);
});
this._webServiceLoader.add_loadingSuccess(Function.createDelegate(this,this._onWebServiceResponse));
},_onWebServiceResponse:function(_26,_27){
var _28=_27.get_data();
var div=document.createElement("DIV");
div.innerHTML=_28;
if(this._currentServicedToolTip){
this._currentServicedToolTip.set_contentElement(div);
}
},_initializeWebServiceToolTip:function(_2a){
_2a.add_beforeShow(Function.createDelegate(this,function(_2b,_2c){
if(!this._webServiceLoader){
this._initializeWebServiceLoader();
}
var _2d={TargetControlID:_2a.get_targetControlID(),Value:_2a.get_serverValue()};
this._currentServicedToolTip=_2b;
this._webServiceLoader.loadData({context:_2d});
_2b.showLoadingMessage(true);
}));
},_initializeAjaxToolTip:function(_2e){
_2e.add_beforeShow(Function.createDelegate(this,function(_2f,_30){
this._doLoadOnDemand(_2f);
}));
_2e.add_hide(Function.createDelegate(this,function(_31,_32){
var _33=this.get_updatePanel();
var _34=_31.get_popupElement();
var _35=$telerik.isDescendant(_34,_33);
if(_35){
this._moveUpdatePanel();
}
}));
},_doLoadOnDemand:function(_36){
var _37=document.getElementById(_36.get_formID());
if(!_37){
_37=document.forms[0];
}
var _38=this._moveUpdatePanel(_37,true);
_36.showLoadingMessage(true);
var prm=Sys.WebForms.PageRequestManager.getInstance();
prm.add_endRequest(EndRequestHandler);
function EndRequestHandler(_3a,_3b){
_36.set_contentElement(_38);
prm.remove_endRequest(EndRequestHandler);
}
var _3c=_36.get_serverTargetControlID();
if(!_3c){
_3c=_36.get_targetControlID();
}
this._ajaxControlID=_3c;
this._ajaxValue=_36.get_serverValue();
this.updateClientState();
__doPostBack(this._getUpdatePanelID());
},saveClientState:function(){
var _3d={AjaxTargetControl:this._ajaxControlID,Value:this._ajaxValue};
return Sys.Serialization.JavaScriptSerializer.serialize(_3d);
},_getUpdatePanelID:function(){
return this.get_id()+"RTMPanel";
},_getUniqueToolTipID:function(){
this._idCounter++;
return (this.get_id()+this._idCounter+(new Date()-100));
},_moveUpdatePanel:function(_3e,_3f){
if(!_3e){
_3e=this._updatePanelParent;
}
if(_3e&&_3e.appendChild){
var _40=this.get_updatePanel();
if(_40){
if(false!=_3f){
_40.style.display="none";
}
_3e.appendChild(_40);
}
return _40;
}
},get_webServiceSettings:function(){
return this._webServiceSettings;
},set_webServiceSettings:function(_41){
var _42=Sys.Serialization.JavaScriptSerializer.deserialize(_41);
this._webServiceSettings=new Telerik.Web.UI.WebServiceSettings(_42);
},get_autoTooltipify:function(){
return this._autoTooltipify;
},set_autoTooltipify:function(_43){
if(this._autoTooltipify!=_43){
this._autoTooltipify=_43;
}
},get_toolTipZoneID:function(){
return this._toolTipZoneID;
},set_toolTipZoneID:function(_44){
if(this._toolTipZoneID!=_44){
this._toolTipZoneID=_44;
}
},get_isToolTipFactory:function(){
return this._isToolTipFactory;
},set_isToolTipFactory:function(_45){
if(this._isToolTipFactory!=_45){
this._isToolTipFactory=_45;
}
},get_loadOnDemand:function(){
return this._loadOnDemand;
},set_loadOnDemand:function(_46){
if(this._loadOnDemand!=_46){
this._loadOnDemand=_46;
}
},get_targetControls:function(){
return this._targetControls;
},set_targetControls:function(_47){
if(!_47){
this._targetControls=[];
}else{
this._targetControls=eval(_47);
}
}};
Telerik.Web.UI.RadToolTipManager.registerClass("Telerik.Web.UI.RadToolTipManager",Telerik.Web.UI.RadToolTip);

