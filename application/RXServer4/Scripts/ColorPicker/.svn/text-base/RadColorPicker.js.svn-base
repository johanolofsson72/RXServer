Type.registerNamespace("Telerik.Web");
Telerik.Web.UI.ColorPickerColorChangeEventArgs=function(_1){
Telerik.Web.UI.ColorPickerColorChangeEventArgs.initializeBase(this);
this._oldColor=_1;
};
Telerik.Web.UI.ColorPickerColorChangeEventArgs.prototype={get_oldColor:function(){
return this._oldColor;
}};
Telerik.Web.UI.ColorPickerColorChangeEventArgs.registerClass("Telerik.Web.UI.ColorPickerColorChangeEventArgs",Sys.EventArgs);
Telerik.Web.UI.ColorPickerColorSelectingEventArgs=function(_2){
Telerik.Web.UI.ColorPickerColorSelectingEventArgs.initializeBase(this);
this._color=_2;
};
Telerik.Web.UI.ColorPickerColorSelectingEventArgs.prototype={get_color:function(){
return this._color;
}};
Telerik.Web.UI.ColorPickerColorSelectingEventArgs.registerClass("Telerik.Web.UI.ColorPickerColorSelectingEventArgs",Sys.EventArgs);
Telerik.Web.UI.RadColorPicker=function(_3){
Telerik.Web.UI.RadColorPicker.initializeBase(this,[_3]);
this._selectedColor=null;
this._autoPostBack=false;
this._enabled=true;
this._previewColor=true;
this._showIcon=false;
this._showEmptyColor=true;
this._lastPreviewColor="";
this._elementsByColor=[];
this._mouseUpHandler=null;
this._pickColorText="";
this._currentColorText="";
this._noColorText="";
this._popupBehavior=null;
this._paletteDisplayed=false;
this._realWidthIE6=0;
this._realWidthIE7=0;
this._realWidthColorBoxOpera=0;
this._uniqueID=null;
};
Telerik.Web.UI.RadColorPicker.prototype={initialize:function(){
Telerik.Web.UI.RadColorPicker.callBaseMethod(this,"initialize");
this._wrapperElement=$get(this.get_id());
this._previewElement=$get(this.get_id()+"_preview");
this._emptyColorElement=$get(this.get_id()+"_emptycolor");
this._iconElement=$get(this.get_id()+"_icon");
this._iconWrapperElement=$get(this.get_id()+"_label");
this._paletteWrapperElement=$get(this.get_id()+"_palette");
if(!this._showIcon){
this._paletteDisplayed=true;
}else{
if(!this._popupBehavior){
this._popupBehavior=$create(Telerik.Web.PopupBehavior,{"id":this.get_id()+"PopupBehavior","parentElement":this._iconWrapperElement},null,null,this._paletteWrapperElement);
}
}
var _4=this._paletteWrapperElement.getElementsByTagName("A");
for(var i=0;i<_4.length;i++){
if(this._getColorBoxElement(_4[i])==null){
continue;
}
this._elementsByColor[this._getElementColor(_4[i])]=_4[i];
}
if(Sys.Browser.agent==Sys.Browser.Opera){
var _6=this._paletteWrapperElement.getElementsByTagName("LI");
for(var i=0;i<_6.length;i++){
_6[i].style.width=this._realWidthColorBoxOpera+"px";
}
}
if(this._enabled){
this._initializeEventHandlers();
}
this.set_selectedColor(this._selectedColor);
this.raiseEvent("loaded");
},dispose:function(){
if(this._popupBehavior){
this._popupBehavior.dispose();
this._popupBehavior=null;
}
if(this._enabled){
this._disposeHandlers();
}
Telerik.Web.UI.RadColorPicker.callBaseMethod(this,"dispose");
},showPalette:function(){
var _7=$telerik.getBounds(this._iconWrapperElement);
this._popupBehavior.set_x(0);
this._popupBehavior.set_y(_7.height);
if(Sys.Browser.agent==Sys.Browser.InternetExplorer&&Sys.Browser.version==6){
this._paletteWrapperElement.style.width=this._realWidthIE6+"px";
}else{
if(Sys.Browser.agent==Sys.Browser.InternetExplorer&&Sys.Browser.version==7){
this._paletteWrapperElement.style.width=this._realWidthIE7+"px";
}else{
this._paletteWrapperElement.style.width=this._realWidthIE7+"px";
}
}
this._popupBehavior.show();
this._paletteDisplayed=true;
},hidePalette:function(){
this._popupBehavior.hide();
this._paletteDisplayed=false;
},getIconContainer:function(){
return this._iconWrapperElement;
},getPaletteContainer:function(){
return this._paletteWrapperElement;
},ShowPalette:function(){
this.showPalette();
},HidePalette:function(){
this.hidePalette();
},GetIconContainer:function(){
this.getIconContainer();
},GetPaletteContainer:function(){
this.getPaletteContainer();
},saveClientState:function(){
var _8=["selectedColor"];
var _9={};
for(var i=0;i<_8.length;i++){
_9[_8[i]]=this["get_"+_8[i]]();
}
return Sys.Serialization.JavaScriptSerializer.serialize(_9);
},add_loaded:function(_b){
this.get_events().addHandler("loaded",_b);
},remove_loaded:function(_c){
this.get_events().removeHandler("loaded",_c);
},add_colorSelecting:function(_d){
this.get_events().addHandler("colorSelecting",_d);
},remove_colorSelecting:function(_e){
this.get_events().removeHandler("colorSelecting",_e);
},add_colorChange:function(_f){
this.get_events().addHandler("colorChange",_f);
},remove_colorChange:function(_10){
this.get_events().removeHandler("colorChange",_10);
},get_selectedColor:function(){
return this._selectedColor;
},set_selectedColor:function(_11){
if(!_11){
_11=null;
}
var _12=this._selectedColor;
if(!_12){
_12=null;
}
if(_11!=null){
_11=_11.toUpperCase();
}
this._selectedColor=_11;
var _13=this._getMarkedElement();
if(_13!=null){
if(_13==this._emptyColorElement){
_13.className="emptycolor";
}else{
_13.className="colorbox";
}
}
var _14=this._getBoxElementByColor(_11);
if(_14!=null){
this._setMarkedElement(_14);
if(_14==this._emptyColorElement){
_14.className="emptycolor selectedcolor";
}else{
_14.className="selectedcolor";
}
}
this._previewCurrentColor(_11);
if(this._showIcon){
this._setIconColor(_11);
}
this.updateClientState();
if(this._selectedColor!=_12){
var _15=new Telerik.Web.UI.ColorPickerColorChangeEventArgs(_12);
this.raiseEvent("colorChange",_15);
if(this._autoPostBack){
this._raiseColorChangedServerEvent();
}
}
},get_selectedColorTitle:function(){
var _16=this._getBoxElementByColor(this._selectedColor);
if(_16!=null){
return _16.getAttribute("title");
}
return this._selectedColor;
},get_enabled:function(){
return this._enabled;
},set_enabled:function(_17){
this._enabled=_17;
},_initializeEventHandlers:function(){
$addHandlers(this._paletteWrapperElement,{"mouseover":this._onBoxMouseOver,"mouseup":this._onBoxClick,"selectstart":this._onSelectStart},this);
if(this._showEmptyColor){
$addHandlers(this._emptyColorElement,{"click":this._onEmptyColorClick},this);
}
if(this._showIcon){
$addHandlers(this._iconWrapperElement,{"mousedown":this._onIconMouseDown,"mouseup":this._onIconMouseUp},this);
this._mouseUpHandler=Function.createDelegate(this,this._onMouseUp);
$addHandler(document,"mouseup",this._mouseUpHandler);
}
},_disposeHandlers:function(){
$clearHandlers(this._paletteWrapperElement);
if(this._showEmptyColor){
$clearHandlers(this._emptyColorElement);
}
if(this._showIcon){
$clearHandlers(this._iconWrapperElement);
$removeHandler(document,"mouseup",this._mouseUpHandler);
}
this._mouseUpHandler=null;
},_raiseColorChangedServerEvent:function(){
__doPostBack(this._uniqueID);
},_onMouseUp:function(){
this.hidePalette();
},_onBoxMouseOver:function(evt){
var _19=this._getColorBoxElement(evt.target);
if(_19==null){
return;
}
var _1a=this._getElementColor(_19);
if(_1a!=this._lastPreviewColor){
var _1b=new Telerik.Web.UI.ColorPickerColorSelectingEventArgs(_1a);
this.raiseEvent("colorSelecting",_1b);
}
this._previewCurrentColor(_1a,_19.title);
},_onEmptyColorClick:function(evt){
this.set_selectedColor(null);
if(this._showIcon){
this.hidePalette();
}
},_onIconMouseDown:function(evt){
evt.preventDefault();
evt.stopPropagation();
},_onIconMouseUp:function(evt){
if(this._paletteDisplayed){
this.hidePalette();
}else{
this.showPalette();
}
evt.preventDefault();
evt.stopPropagation();
},_getElementColor:function(_1f){
if(_1f==this._emptyColorElement){
return null;
}
return _1f.firstChild.innerHTML;
},_setIconColor:function(_20){
if(_20==null){
_20="#FFFFFF";
this._iconWrapperElement.title=this._pickColorText+" "+this._currentColorText.toString().replace("{0}","blank");
}else{
this._iconWrapperElement.title=this._pickColorText+" "+this._currentColorText.toString().replace("{0}",_20);
}
this._iconElement.style.backgroundColor=_20;
},_onSelectStart:function(evt){
evt.stopPropagation();
evt.preventDefault();
},_onBoxClick:function(evt){
if(evt.button!=0){
return;
}
evt.stopPropagation();
var _23=this._getColorBoxElement(evt.target);
if(_23==null){
return;
}
this.set_selectedColor(this._getElementColor(_23));
if(this._showIcon){
this.hidePalette();
}
},_getMarkedElement:function(){
if(this._markedElement){
return this._markedElement;
}
var _24=this._paletteWrapperElement.getElementsByTagName("A");
for(var i=0;i<_24.length;i++){
if(_24[i].className=="selectedcolor"){
return _24[i];
}
}
return null;
},_setMarkedElement:function(_26){
this._markedElement=_26;
},_getColorBoxElement:function(_27){
var _28=3;
var i=0;
while(i<_28){
if(_27.className=="colorbox"||_27.className=="selectedcolor"||_27.className.indexOf("emptycolor")>-1){
return _27;
}
i++;
_27=_27.parentNode;
}
return null;
},_getBoxElementByColor:function(_2a){
if(!_2a){
return this._emptyColorElement;
}
_2a=_2a.toUpperCase();
return this._elementsByColor[_2a];
},_previewCurrentColor:function(_2b,_2c){
if(!this.get_isInitialized()){
return;
}
this._lastPreviewColor=_2b;
if(!this._previewColor){
return;
}
if(_2b==null){
_2b="#FFFFFF";
_2c=this._noColorText;
}
_2b=_2b.toUpperCase();
if(!_2c){
_2c=_2b;
}
this._previewElement.style.backgroundColor=_2b;
this._previewElement.getElementsByTagName("span")[0].innerHTML=_2c;
this._previewElement.getElementsByTagName("span")[1].innerHTML=_2c;
}};
Telerik.Web.UI.RadColorPicker.registerClass("Telerik.Web.UI.RadColorPicker",Telerik.Web.UI.RadWebControl);

