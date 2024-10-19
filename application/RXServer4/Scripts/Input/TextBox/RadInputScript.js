Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadInputControl=function(_1){
Telerik.Web.UI.RadInputControl.initializeBase(this,[_1]);
this._autoPostBack=false;
this._enabled=true;
this._showButton=false;
this._invalidStyleDuration=100;
this._emptyMessage="";
this._selectionOnFocus=Telerik.Web.UI.SelectionOnFocus.None;
this._postBackEventReferenceScript="";
this._styles=null;
this._onTextBoxKeyUpDelegate=null;
this._onTextBoxKeyPressDelegate=null;
this._onTextBoxBlurDelegate=null;
this._onTextBoxFocusDelegate=null;
this._onTextBoxMouseOutDelegate=null;
this._onTextBoxMouseOverDelegate=null;
this._onTextBoxKeyDownDelegate=null;
this._onTextBoxMouseWheelDelegate=null;
this._onTextBoxDragDropDelegate=null;
};
Telerik.Web.UI.RadInputControl.prototype={initialize:function(){
Telerik.Web.UI.RadInputControl.callBaseMethod(this,"initialize");
this._clientID=this.get_id();
this._wrapperElementID=this.get_id()+"_wrapper";
this._textBoxElement=$get(this.get_id()+"_text");
this._originalTextBoxCssText=this._textBoxElement.style.cssText;
if(this._originalTextBoxCssText.indexOf(";")!=this._originalTextBoxCssText.length-1){
this._originalTextBoxCssText+=";";
}
this._updatePercentageHeight();
this._originalMaxLength=this._textBoxElement.maxLength;
if(this._originalMaxLength==-1){
this._originalMaxLength=2147483647;
}
this._initializeHiddenElement(this.get_id());
this._initializeValidationField(this.get_id());
this._selectionEnd=0;
this._selectionStart=0;
this._isInFocus=true;
this._focused=false;
this._hovered=false;
this._invalid=false;
this._attachEventHandlers();
this.updateCssClass();
this._initializeButtons();
this._initialValue=this.get_value();
this.raise_load(Sys.EventArgs.Empty);
},dispose:function(){
Telerik.Web.UI.RadInputControl.callBaseMethod(this,"dispose");
if(this.Button){
if(this._onButtonClickDelegate){
$removeHandler(this.Button,"click",this._onButtonClickDelegate);
this._onButtonClickDelegate=null;
}
}
if(this._onTextBoxKeyDownDelegate){
$removeHandler(this._textBoxElement,"keydown",this._onTextBoxKeyDownDelegate);
this._onTextBoxKeyDownDelegate=null;
}
if(this._onTextBoxKeyPressDelegate){
$removeHandler(this._textBoxElement,"keypress",this._onTextBoxKeyPressDelegate);
this._onTextBoxKeyPressDelegate=null;
}
if(this._onTextBoxKeyUpDelegate){
$removeHandler(this._textBoxElement,"keyup",this._onTextBoxKeyUpDelegate);
this._onTextBoxKeyUpDelegate=null;
}
if(this._onTextBoxBlurDelegate){
$removeHandler(this._textBoxElement,"blur",this._onTextBoxBlurDelegate);
this._onTextBoxBlurDelegate=null;
}
if(this._onTextBoxFocusDelegate){
$removeHandler(this._textBoxElement,"focus",this._onTextBoxFocusDelegate);
this._onTextBoxFocusDelegate=null;
}
if(this._onTextBoxMouseOutDelegate){
$removeHandler(this._textBoxElement,"mouseout",this._onTextBoxMouseOutDelegate);
this._onTextBoxMouseOutDelegate=null;
}
if(this._onTextBoxMouseOverDelegate){
$removeHandler(this._textBoxElement,"mouseover",this._onTextBoxMouseOverDelegate);
this._onTextBoxMouseOverDelegate=null;
}
if(Sys.Browser.agent!=Sys.Browser.InternetExplorer){
if(this._onTextBoxMouseWheelDelegate){
$removeHandler(this._textBoxElement,"DOMMouseScroll",this._onTextBoxMouseWheelDelegate);
this._onTextBoxMouseWheelDelegate=null;
}
if(this._onTextBoxDragDropDelegate){
$removeHandler(this._textBoxElement,"dragdrop",this._onTextBoxDragDropDelegate);
this._onTextBoxDragDropDelegate=null;
}
}else{
if(this._onTextBoxMouseWheelDelegate){
$removeHandler(this._textBoxElement,"mousewheel",this._onTextBoxMouseWheelDelegate);
this._onTextBoxMouseWheelDelegate=null;
}
if(this._onTextBoxDragDropDelegate){
$removeHandler(this._textBoxElement,"drop",this._onTextBoxDragDropDelegate);
this._onTextBoxDragDropDelegate=null;
}
}
},clear:function(){
this.set_value("");
},disable:function(){
this.set_enabled(false);
this._textBoxElement.disabled="disabled";
this.updateCssClass();
this.raise_disable(Sys.EventArgs.Empty);
},enable:function(){
this.set_enabled(true);
this._textBoxElement.disabled="";
this.updateCssClass();
this.raise_enable(Sys.EventArgs.Empty);
},focus:function(){
this._textBoxElement.focus();
},blur:function(){
this._textBoxElement.blur();
},isEmpty:function(){
return this._hiddenElement.value=="";
},isNegative:function(){
return false;
},isReadOnly:function(){
return this._textBoxElement.readOnly||!this._enabled;
},isMultiLine:function(){
return this._textBoxElement.tagName.toUpperCase()=="TEXTAREA";
},updateDisplayValue:function(){
if(this._focused){
this.set_textBoxValue(this.get_editValue());
}else{
if(this.isEmpty()&&this.get_emptyMessage()){
this._textBoxElement.maxLength=2147483647;
this._isEmptyMessage=true;
this.set_textBoxValue(this.get_emptyMessage());
this._textBoxElement.maxLength=this._originalMaxLength;
}else{
this._isEmptyMessage=false;
this.set_textBoxValue(this.get_displayValue());
}
}
},__isEmptyMessage:function(){
return this.isEmpty()&&this.get_emptyMessage();
},updateCssClass:function(){
if(this._enabled&&(!this.__isEmptyMessage())&&(!this.isNegative())){
this._textBoxElement.style.cssText=this._originalTextBoxCssText+this.updateCssText(this.get_styles()["EnabledStyle"][0]);
this._textBoxElement.className=this.get_styles()["EnabledStyle"][1];
}
if(this._enabled&&(!this.__isEmptyMessage())&&this.isNegative()){
this._textBoxElement.style.cssText=this._originalTextBoxCssText+this.updateCssText(this.get_styles()["NegativeStyle"][0]);
this._textBoxElement.className=this.get_styles()["NegativeStyle"][1];
}
if(this._enabled&&this.__isEmptyMessage()){
this._textBoxElement.style.cssText=this._originalTextBoxCssText+this.updateCssText(this.get_styles()["EmptyMessageStyle"][0]);
this._textBoxElement.className=this.get_styles()["EmptyMessageStyle"][1];
}
if(this._hovered){
this._textBoxElement.style.cssText=this._originalTextBoxCssText+this.updateCssText(this.get_styles()["HoveredStyle"][0]);
this._textBoxElement.className=this.get_styles()["HoveredStyle"][1];
}
if(this._focused){
this._textBoxElement.style.cssText=this._originalTextBoxCssText+this.updateCssText(this.get_styles()["FocusedStyle"][0]);
this._textBoxElement.className=this.get_styles()["FocusedStyle"][1];
}
if(this._invalid){
this._textBoxElement.style.cssText=this._originalTextBoxCssText+this.updateCssText(this.get_styles()["InvalidStyle"][0]);
this._textBoxElement.className=this.get_styles()["InvalidStyle"][1];
}
if(this._textBoxElement.readOnly){
this._textBoxElement.style.cssText=this._originalTextBoxCssText+this.updateCssText(this.get_styles()["ReadOnlyStyle"][0]);
this._textBoxElement.className=this.get_styles()["ReadOnlyStyle"][1];
}
if(!this._enabled){
this._textBoxElement.style.cssText=this._originalTextBoxCssText+this.updateCssText(this.get_styles()["DisabledStyle"][0]);
this._textBoxElement.className=this.get_styles()["DisabledStyle"][1];
}
},updateCssText:function(_2){
var _3=_2.split(";");
var i;
var _5="";
for(i=0;i<_3.length;i++){
var _6=_3[i].split(":");
if(_6.length==2){
var _7=""+_6[0].toLowerCase();
if(_7!="width"&&_7!="height"){
_5+=_3[i]+";";
}
}
}
return _5;
},selectText:function(_8,_9){
this._selectionStart=_8;
this._selectionEnd=_9;
this._applySelection();
},selectAllText:function(){
if(this._textBoxElement.value.length>0){
this.selectText(0,this._textBoxElement.value.length);
return true;
}
return false;
},GetValue:function(){
return this.get_value();
},SetValue:function(_a){
this.set_value(_a);
},GetDisplayValue:function(){
return this.get_displayValue();
},GetEditValue:function(){
return this.get_editValue();
},SetCaretPosition:function(_b){
this.set_caretPosition(_b);
},GetWrapperElement:function(){
return this.get_wrapperElement();
},GetTextBoxValue:function(){
return this.get_textBoxValue();
},SetTextBoxValue:function(_c){
this.set_textBoxValue(_c);
},get_value:function(){
return this._hiddenElement.value;
},set_value:function(_d){
var _e=new Telerik.Web.UI.InputValueChangingEventArgs(_d,this._initialValue);
this.raise_valueChanging(_e);
if(_e.get_cancel()==true){
this._SetValue(this._initialValue);
return false;
}
if(_e.get_newValue()){
_d=_e.get_newValue();
}
var _f=this._setHiddenValue(_d);
if(_f==false){
_d="";
}
this._triggerDOMChangeEvent(this._getValidationField());
this.raise_valueChanged(_d,this._initialValue);
if(typeof (_f)=="undefined"||_f==true){
this.set_textBoxValue(this.get_editValue());
this.updateDisplayValue();
this.updateCssClass();
}
},get_displayValue:function(){
return this._hiddenElement.value;
},get_editValue:function(){
return this._hiddenElement.value;
},set_caretPosition:function(_10){
this._selectionStart=_10;
this._selectionEnd=_10;
this._applySelection();
},raisePostBackEvent:function(){
eval(this._postBackEventReferenceScript);
},get_wrapperElement:function(){
return $get(this._wrapperElementID);
},get_textBoxValue:function(){
return this._textBoxElement.value;
},set_textBoxValue:function(_11){
if(this._textBoxElement.value!=_11){
this._textBoxElement.value=_11;
}
},get_autoPostBack:function(){
return this._autoPostBack;
},set_autoPostBack:function(_12){
if(this._autoPostBack!==_12){
this._autoPostBack=_12;
this.raisePropertyChanged("autoPostBack");
}
},get_emptyMessage:function(){
return this._emptyMessage;
},set_emptyMessage:function(_13){
if(this._emptyMessage!==_13){
this._emptyMessage=_13;
this._isEmptyMessage=(_13!="");
this.raisePropertyChanged("emptyMessage");
}
},get_selectionOnFocus:function(){
return this._selectionOnFocus;
},set_selectionOnFocus:function(_14){
if(this._selectionOnFocus!==_14){
this._selectionOnFocus=_14;
this.raisePropertyChanged("selectionOnFocus");
}
},get_showButton:function(){
return this._showButton;
},set_showButton:function(_15){
if(this._showButton!==_15){
this._showButton=_15;
this.raisePropertyChanged("showButton");
}
},get_invalidStyleDuration:function(){
return this._invalidStyleDuration;
},set_invalidStyleDuration:function(_16){
if(this._invalidStyleDuration!==_16){
this._invalidStyleDuration=_16;
this.raisePropertyChanged("invalidStyleDuration");
}
},get_enabled:function(){
return this._enabled;
},set_enabled:function(_17){
if(this._enabled!==_17){
this._enabled=_17;
this.raisePropertyChanged("enabled");
}
},get_styles:function(){
return this._styles;
},set_styles:function(_18){
if(this._styles!==_18){
this._styles=_18;
this.raisePropertyChanged("styles");
}
},_updatePercentageHeight:function(){
var _19=$get(this._wrapperElementID);
if(_19.style.height.indexOf("%")>-1){
if(_19.offsetHeight!=0){
this._textBoxElement.style.height=_19.offsetHeight+"px";
this._originalTextBoxCssText+="height:"+this._textBoxElement.style.height+";";
}else{
var obj=this;
window.setTimeout(function(){
obj._textBoxElement.style.height=_19.offsetHeight+"px";
obj._originalTextBoxCssText+="height:"+obj._textBoxElement.style.height+";";
},0);
}
}
},_initializeHiddenElement:function(id){
this._hiddenElement=$get(id);
},_initializeValidationField:function(id){
},_initializeButtons:function(){
this._onButtonClickDelegate=Function.createDelegate(this,this._onButtonClickHandler);
this.Button=null;
var _1d=$get(this._wrapperElementID);
var _1e=_1d.getElementsByTagName("a");
for(i=0;i<_1e.length;i++){
if(_1e[i].className.indexOf("gobutton")!=(-1)){
this.Button=_1e[i];
$addHandler(this.Button,"click",this._onButtonClickDelegate);
}
}
},_attachEventHandlers:function(){
this._onTextBoxKeyUpDelegate=Function.createDelegate(this,this._onTextBoxKeyUpHandler);
this._onTextBoxKeyPressDelegate=Function.createDelegate(this,this._onTextBoxKeyPressHandler);
this._onTextBoxBlurDelegate=Function.createDelegate(this,this._onTextBoxBlurHandler);
this._onTextBoxFocusDelegate=Function.createDelegate(this,this._onTextBoxFocusHandler);
this._onTextBoxKeyDownDelegate=Function.createDelegate(this,this._onTextBoxKeyDownHandler);
$addHandler(this._textBoxElement,"keydown",this._onTextBoxKeyDownDelegate);
$addHandler(this._textBoxElement,"keypress",this._onTextBoxKeyPressDelegate);
$addHandler(this._textBoxElement,"keyup",this._onTextBoxKeyUpDelegate);
$addHandler(this._textBoxElement,"blur",this._onTextBoxBlurDelegate);
$addHandler(this._textBoxElement,"focus",this._onTextBoxFocusDelegate);
this._attachMouseEventHandlers();
},_attachMouseEventHandlers:function(){
this._onTextBoxMouseOutDelegate=Function.createDelegate(this,this._onTextBoxMouseOutHandler);
this._onTextBoxMouseOverDelegate=Function.createDelegate(this,this._onTextBoxMouseOverHandler);
this._onTextBoxMouseWheelDelegate=Function.createDelegate(this,this._onTextBoxMouseWheelHandler);
this._onTextBoxDragDropDelegate=Function.createDelegate(this,this._onTextBoxDragDropHandler);
$addHandler(this._textBoxElement,"mouseout",this._onTextBoxMouseOutDelegate);
$addHandler(this._textBoxElement,"mouseover",this._onTextBoxMouseOverDelegate);
if(Sys.Browser.agent!=Sys.Browser.InternetExplorer){
$addHandler(this._textBoxElement,"DOMMouseScroll",this._onTextBoxMouseWheelDelegate);
$addHandler(this._textBoxElement,"dragdrop",this._onTextBoxDragDropDelegate);
}else{
$addHandler(this._textBoxElement,"mousewheel",this._onTextBoxMouseWheelDelegate);
$addHandler(this._textBoxElement,"drop",this._onTextBoxDragDropDelegate);
}
},_onTextBoxKeyPressHandler:function(e){
var _20=new Telerik.Web.UI.InputKeyPressEventArgs(e,e.charCode,String.fromCharCode(e.charCode));
this.raise_keyPress(_20);
if(_20.get_cancel()){
e.stopPropagation();
e.preventDefault();
return false;
}
if((e.charCode==13)&&!this.isMultiLine()){
this._updateHiddenValueOnKeyPress(e);
if(this.get_autoPostBack()){
this.raisePostBackEvent();
if(Sys.Browser.agent==Sys.Browser.InternetExplorer){
e.stopPropagation();
e.preventDefault();
}
}
return true;
}
},_onTextBoxKeyUpHandler:function(e){
this._updateHiddenValueOnKeyPress(e);
},_onTextBoxBlurHandler:function(e){
if(!this._isInFocus){
e.preventDefault();
e.stopPropagation();
return false;
}
this._isInFocus=false;
this._focused=false;
var _23=this.get_textBoxValue();
if(this._initialValue!=_23){
this.set_value(_23);
}else{
this.updateDisplayValue();
this.updateCssClass();
}
this.raise_blur(Sys.EventArgs.Empty);
},_onTextBoxFocusHandler:function(e){
this._isInFocus=true;
this._focused=true;
this.updateDisplayValue();
this.updateCssClass();
this._updateSelectionOnFocus();
this.raise_focus(Sys.EventArgs.Empty);
},_onTextBoxMouseOutHandler:function(e){
this._hovered=false;
this.updateCssClass();
this.raise_mouseOut(Sys.EventArgs.Empty);
},_onTextBoxMouseOverHandler:function(e){
this._hovered=true;
this.updateCssClass();
this.raise_mouseOver(Sys.EventArgs.Empty);
},_onTextBoxKeyDownHandler:function(e){
},_onTextBoxMouseWheelHandler:function(e){
var _29;
if(this._focused){
if(e.rawEvent.wheelDelta){
_29=e.rawEvent.wheelDelta/120;
if(window.opera){
_29=-_29;
}
}else{
if(e.detail){
_29=-e.rawEvent.detail/3;
}else{
if(e.rawEvent&&e.rawEvent.detail){
_29=-e.rawEvent.detail/3;
}
}
}
if(_29>0){
this._handleWheel(false);
}else{
this._handleWheel(true);
}
return true;
}
return false;
},_onButtonClickHandler:function(e){
var _2b=new Telerik.Web.UI.InputButtonClickEventArgs(Telerik.Web.UI.InputButtonType.Button);
this.raise_buttonClick(_2b);
},_onTextBoxDragDropHandler:function(e){
if(Sys.Browser.agent==Sys.Browser.InternetExplorer){
this.set_value(e.rawEvent.dataTransfer.getData("text"));
}else{
this.set_value(this.get_textBoxValue());
}
},_getValidationField:function(){
return this._hiddenElement;
},_calculateSelection:function(){
if((Sys.Browser.agent==Sys.Browser.Opera)||!document.selection){
this._selectionEnd=this._textBoxElement.selectionEnd;
this._selectionStart=this._textBoxElement.selectionStart;
return;
}
var s1=document.selection.createRange();
if(s1.parentElement()!=this._textBoxElement){
return;
}
var s=s1.duplicate();
s.move("character",-this._textBoxElement.value.length);
s.setEndPoint("EndToStart",s1);
var _2f=s.text.length;
var _30=s.text.length+s1.text.length;
this._selectionEnd=Math.max(_2f,_30);
this._selectionStart=Math.min(_2f,_30);
},_SetValue:function(_31){
var _32=this._setHiddenValue(_31);
if(typeof (_32)=="undefined"||_32==true){
this.set_textBoxValue(this.get_editValue());
}
},_triggerDOMChangeEvent:function(_33){
if(_33.fireEvent&&document.createEventObject){
var _34=document.createEventObject();
_33.fireEvent("onchange",_34);
}else{
if(_33.dispatchEvent){
var _35=true;
var _34=document.createEvent("HTMLEvents");
_34.initEvent("change",_35,true);
_33.dispatchEvent(_34);
}
}
},_updateSelectionOnFocus:function(){
switch(this.get_selectionOnFocus()){
case Telerik.Web.UI.SelectionOnFocus.None:
break;
case Telerik.Web.UI.SelectionOnFocus.CaretToBeginning:
this.set_caretPosition(0);
break;
case Telerik.Web.UI.SelectionOnFocus.CaretToEnd:
if(this._textBoxElement.value.length>0){
this.set_caretPosition(this._textBoxElement.value.length);
}
break;
case Telerik.Web.UI.SelectionOnFocus.SelectAll:
this.selectAllText();
break;
default:
this.set_caretPosition(0);
break;
}
},_applySelection:function(){
if((Sys.Browser.agent==Sys.Browser.Opera)||!document.selection){
this._textBoxElement.selectionStart=this._selectionStart;
this._textBoxElement.selectionEnd=this._selectionEnd;
return;
}
this._textBoxElement.select();
sel=document.selection.createRange();
sel.collapse();
sel.moveStart("character",this._selectionStart);
sel.collapse();
sel.moveEnd("character",this._selectionEnd-this._selectionStart);
sel.select();
},_clearHiddenValue:function(){
this._hiddenElement.value="";
},_handleWheel:function(_36){
},_setHiddenValue:function(_37){
if(this._hiddenElement.value!=_37.toString()){
this._hiddenElement.value=_37;
}
this._setValidationField(_37);
return true;
},_setValidationField:function(_38){
},_updateHiddenValueOnKeyPress:function(){
this._updateHiddenValue();
},_updateHiddenValue:function(){
return this._setHiddenValue(this._textBoxElement.value);
},_escapeNewLineChars:function(_39,_3a){
_39=escape(_39);
var i;
for(i=0;i<_39.length;i++){
if(_39.indexOf("%0D%0A")>-1){
_39=_39.replace("%0D%0A",_3a);
}else{
if(_39.indexOf("%0A")>-1){
_39=_39.replace("%0A",_3a);
}else{
if(_39.indexOf("%0D")>-1){
_39=_39.replace("%0D",_3a);
}
}
}
}
return unescape(_39);
},_isNormalChar:function(e){
if(($telerik.isFirefox&&e.rawEvent.keyCode)||($telerik.isOpera&&e.rawEvent.which==0)||($telerik.isSafari&&(e.charCode<Sys.UI.Key.space||e.charCode>60000))){
return false;
}
return true;
},add_blur:function(_3d){
this.get_events().addHandler("blur",_3d);
},remove_blur:function(_3e){
this.get_events().removeHandler("blur",_3e);
},raise_blur:function(_3f){
this.raiseEvent("blur",_3f);
},add_mouseOut:function(_40){
this.get_events().addHandler("mouseOut",_40);
},remove_mouseOut:function(_41){
this.get_events().removeHandler("mouseOut",_41);
},raise_mouseOut:function(_42){
this.raiseEvent("mouseOut",_42);
},add_valueChanged:function(_43){
this.get_events().addHandler("valueChanged",_43);
},remove_valueChanged:function(_44){
this.get_events().removeHandler("valueChanged",_44);
},raise_valueChanged:function(_45,_46){
if(_45.toString()==_46.toString()){
return false;
}
this._initialValue=this.get_value();
var _47=new Telerik.Web.UI.InputValueChangedEventArgs(_45,_46);
this.raiseEvent("valueChanged",_47);
var _48=!_47.get_cancel();
if(this.get_autoPostBack()&&_48){
this.raisePostBackEvent();
}
},add_error:function(_49){
this.get_events().addHandler("error",_49);
},remove_error:function(_4a){
this.get_events().removeHandler("error",_4a);
},raise_error:function(_4b){
if(this.InEventRaise){
return;
}
this.InEventRaise=true;
this.raiseEvent("error",_4b);
if(!_4b.get_cancel()){
this._invalid=true;
this._errorHandlingCanceled=false;
this.updateCssClass();
var _4c=this;
var _4d=function(){
_4c._invalid=false;
_4c.updateCssClass();
};
setTimeout(_4d,this.get_invalidStyleDuration());
}else{
this._errorHandlingCanceled=true;
}
this.InEventRaise=false;
},add_load:function(_4e){
this.get_events().addHandler("load",_4e);
},remove_load:function(_4f){
this.get_events().removeHandler("load",_4f);
},raise_load:function(_50){
this.raiseEvent("load",_50);
},add_mouseOver:function(_51){
this.get_events().addHandler("mouseOver",_51);
},remove_mouseOver:function(_52){
this.get_events().removeHandler("mouseOver",_52);
},raise_mouseOver:function(_53){
this.raiseEvent("mouseOver",_53);
},add_focus:function(_54){
this.get_events().addHandler("focus",_54);
},remove_focus:function(_55){
this.get_events().removeHandler("focus",_55);
},raise_focus:function(_56){
this.raiseEvent("focus",_56);
},add_disable:function(_57){
this.get_events().addHandler("disable",_57);
},remove_disable:function(_58){
this.get_events().removeHandler("disable",_58);
},raise_disable:function(_59){
this.raiseEvent("disable",_59);
},add_enable:function(_5a){
this.get_events().addHandler("enable",_5a);
},remove_enable:function(_5b){
this.get_events().removeHandler("enable",_5b);
},raise_enable:function(_5c){
this.raiseEvent("enable",_5c);
},add_keyPress:function(_5d){
this.get_events().addHandler("keyPress",_5d);
},remove_keyPress:function(_5e){
this.get_events().removeHandler("keyPress",_5e);
},raise_keyPress:function(_5f){
this.raiseEvent("keyPress",_5f);
},add_enumerationChanged:function(_60){
this.get_events().addHandler("enumerationChanged",_60);
},remove_enumerationChanged:function(_61){
this.get_events().removeHandler("enumerationChanged",_61);
},raise_enumerationChanged:function(_62){
this.raiseEvent("enumerationChanged",_62);
},add_moveUp:function(_63){
this.get_events().addHandler("moveUp",_63);
},remove_moveUp:function(_64){
this.get_events().removeHandler("moveUp",_64);
},raise_moveUp:function(_65){
this.raiseEvent("moveUp",_65);
},add_moveDown:function(_66){
this.get_events().addHandler("moveDown",_66);
},remove_moveDown:function(_67){
this.get_events().removeHandler("moveDown",_67);
},raise_moveDown:function(_68){
this.raiseEvent("moveDown",_68);
},add_buttonClick:function(_69){
this.get_events().addHandler("buttonClick",_69);
},remove_buttonClick:function(_6a){
this.get_events().removeHandler("buttonClick",_6a);
},raise_buttonClick:function(_6b){
this.raiseEvent("buttonClick",_6b);
},add_valueChanging:function(_6c){
this.get_events().addHandler("valueChanging",_6c);
},remove_valueChanging:function(_6d){
this.get_events().removeHandler("valueChanging",_6d);
},raise_valueChanging:function(_6e){
this.raiseEvent("valueChanging",_6e);
}};
Telerik.Web.UI.RadInputControl.registerClass("Telerik.Web.UI.RadInputControl",Telerik.Web.UI.RadWebControl);
if(typeof (ValidatorSetFocus)=="function"){
ValidatorSetFocus=function(val,_70){
var _71;
if(typeof (val.controlhookup)=="string"){
var _72;
if((typeof (_70)!="undefined")&&(_70!=null)){
if((typeof (_70.srcElement)!="undefined")&&(_70.srcElement!=null)){
_72=_70.srcElement;
}else{
_72=_70.target;
}
}
if((typeof (_72)!="undefined")&&(_72!=null)&&(typeof (_72.id)=="string")&&(_72.id==val.controlhookup)){
_71=_72;
}
}
if((typeof (_71)=="undefined")||(_71==null)){
_71=document.getElementById(val.controltovalidate);
}
var _73=false;
if((_71.style)&&(typeof (_71.style.visibility)!="undefined")&&(_71.style.visibility=="hidden")&&(typeof (_71.style.width)!="undefined")&&(document.getElementById(_71.id+"_text"))&&(_71.tagName.toLowerCase()=="input")){
_73=true;
}
if((typeof (_71)!="undefined")&&(_71!=null)&&(_71.tagName.toLowerCase()!="table"||(typeof (_70)=="undefined")||(_70==null))&&((_71.tagName.toLowerCase()!="input")||(_71.type.toLowerCase()!="hidden"))&&(typeof (_71.disabled)=="undefined"||_71.disabled==null||_71.disabled==false)&&(typeof (_71.visible)=="undefined"||_71.visible==null||_71.visible!=false)&&(IsInVisibleContainer(_71)||_73)){
if(_71.tagName.toLowerCase()=="table"&&(typeof (__nonMSDOMBrowser)=="undefined"||__nonMSDOMBrowser)){
var _74=_71.getElementsByTagName("input");
var _75=_74[_74.length-1];
if(_75!=null){
_71=_75;
}
}
if(typeof (_71.focus)!="undefined"&&_71.focus!=null){
if(_73){
document.getElementById(_71.id+"_text").focus();
}else{
_71.focus();
}
Page_InvalidControlToBeFocused=_71;
}
}
};
}
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.InputErrorReason=function(){
};
Telerik.Web.UI.InputErrorReason.prototype={ParseError:1,OutOfRange:2};
Telerik.Web.UI.InputErrorReason.registerEnum("Telerik.Web.UI.InputErrorReason",false);
Telerik.Web.UI.SelectionOnFocus=function(){
};
Telerik.Web.UI.SelectionOnFocus.prototype={None:0,CaretToBeginning:1,CaretToEnd:2,SelectAll:3};
Telerik.Web.UI.SelectionOnFocus.registerEnum("Telerik.Web.UI.SelectionOnFocus",false);
Telerik.Web.UI.InputButtonType=function(){
};
Telerik.Web.UI.InputButtonType.prototype={Button:1,MoveUpButton:2,MoveDownButton:3};
Telerik.Web.UI.InputButtonType.registerEnum("Telerik.Web.UI.InputButtonType",false);
Telerik.Web.UI.DisplayFormatPosition=function(){
};
Telerik.Web.UI.DisplayFormatPosition.prototype={Left:1,Right:2};
Telerik.Web.UI.DisplayFormatPosition.registerEnum("Telerik.Web.UI.DisplayFormatPosition",false);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.InputValueChangedEventArgs=function(_76,_77){
Telerik.Web.UI.InputValueChangedEventArgs.initializeBase(this);
this._newValue=_76;
this._oldValue=_77;
};
Telerik.Web.UI.InputValueChangedEventArgs.prototype={get_oldValue:function(){
return this._oldValue;
},get_newValue:function(){
return this._newValue;
}};
Telerik.Web.UI.InputValueChangedEventArgs.registerClass("Telerik.Web.UI.InputValueChangedEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.InputValueChangingEventArgs=function(_78,_79){
Telerik.Web.UI.InputValueChangingEventArgs.initializeBase(this,[_78,_79]);
};
Telerik.Web.UI.InputValueChangingEventArgs.prototype={set_newValue:function(_7a){
if(this._newValue!==_7a){
this._newValue=_7a;
}
}};
Telerik.Web.UI.InputValueChangingEventArgs.registerClass("Telerik.Web.UI.InputValueChangingEventArgs",Telerik.Web.UI.InputValueChangedEventArgs);
Telerik.Web.UI.MaskedTextBoxEventArgs=function(_7b,_7c,_7d){
Telerik.Web.UI.MaskedTextBoxEventArgs.initializeBase(this);
this._newValue=_7b;
this._oldValue=_7c;
this._chunk=_7d;
};
Telerik.Web.UI.MaskedTextBoxEventArgs.prototype={get_oldValue:function(){
return this._oldValue;
},get_newValue:function(){
return this._newValue;
},get_currentPart:function(){
return this._chunk;
}};
Telerik.Web.UI.MaskedTextBoxEventArgs.registerClass("Telerik.Web.UI.MaskedTextBoxEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.InputKeyPressEventArgs=function(_7e,_7f,_80){
Telerik.Web.UI.InputKeyPressEventArgs.initializeBase(this);
this._domEvent=_7e;
this._keyCode=_7f;
this._keyCharacter=_80;
};
Telerik.Web.UI.InputKeyPressEventArgs.prototype={get_domEvent:function(){
return this._domEvent;
},get_keyCode:function(){
return this._keyCode;
},get_keyCharacter:function(){
return this._keyCharacter;
}};
Telerik.Web.UI.InputKeyPressEventArgs.registerClass("Telerik.Web.UI.InputKeyPressEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.InputButtonClickEventArgs=function(_81){
Telerik.Web.UI.InputButtonClickEventArgs.initializeBase(this);
this._buttonType=_81;
};
Telerik.Web.UI.InputButtonClickEventArgs.prototype={get_buttonType:function(){
return this._buttonType;
}};
Telerik.Web.UI.InputButtonClickEventArgs.registerClass("Telerik.Web.UI.InputButtonClickEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.InputErrorEventArgs=function(_82,_83){
Telerik.Web.UI.InputErrorEventArgs.initializeBase(this);
this._reason=_82;
this._inputText=_83;
};
Telerik.Web.UI.InputErrorEventArgs.prototype={get_reason:function(){
return this._reason;
},get_inputText:function(){
return this._inputText;
}};
Telerik.Web.UI.InputErrorEventArgs.registerClass("Telerik.Web.UI.InputErrorEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.NumericInputErrorEventArgs=function(_84,_85,_86,_87){
Telerik.Web.UI.NumericInputErrorEventArgs.initializeBase(this);
this._keyCode=_86;
this._keyCharacter=_87;
};
Telerik.Web.UI.NumericInputErrorEventArgs.prototype={get_reason:function(){
return this._reason;
},get_inputText:function(){
return this._inputText;
},get_keyCode:function(){
return this._keyCode;
},get_keyCharacter:function(){
return this._keyCharacter;
}};
Telerik.Web.UI.NumericInputErrorEventArgs.registerClass("Telerik.Web.UI.NumericInputErrorEventArgs",Telerik.Web.UI.InputErrorEventArgs);
Telerik.Web.UI.RadTextBox=function(_88){
Telerik.Web.UI.RadTextBox.initializeBase(this,[_88]);
this._maxLength=0;
};
Telerik.Web.UI.RadTextBox.prototype={initialize:function(){
Telerik.Web.UI.RadTextBox.callBaseMethod(this,"initialize");
if((!$telerik.isFirefox)&&(this._textBoxElement)&&(this._textBoxElement.type=="password")){
var obj=this;
setTimeout(function(){
obj._SetValue("");
obj.updateDisplayValue();
},0);
}
if(this._textBoxElement&&this._textBoxElement.nodeName&&(this._textBoxElement.nodeName.toUpperCase()=="TEXTAREA")){
this.updateDisplayValue();
}
},dispose:function(){
Telerik.Web.UI.RadTextBox.callBaseMethod(this,"dispose");
},_onTextBoxKeyPressHandler:function(e){
Telerik.Web.UI.RadTextBox.callBaseMethod(this,"_onTextBoxKeyPressHandler",[e]);
var _8b=this._escapeNewLineChars(this._textBoxElement.value,"");
if((this.get_maxLength()>0)&&(_8b.length>=this.get_maxLength())&&(this._isNormalChar(e))){
e.stopPropagation();
e.preventDefault();
return false;
}
},get_maxLength:function(){
return this._maxLength;
},set_maxLength:function(_8c){
if(this._maxLength!==_8c){
this._maxLength=_8c;
this.raisePropertyChanged("maxLength");
}
}};
Telerik.Web.UI.RadTextBox.registerClass("Telerik.Web.UI.RadTextBox",Telerik.Web.UI.RadInputControl);

