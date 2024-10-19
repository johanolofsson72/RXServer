var NumberFormat={};
NumberFormat.Round=function(_1,_2){
if(!_2.get_numberFormat().AllowRounding){
return _1;
}
var _3=Math.pow(10,_2.get_numberFormat().DecimalDigits);
return Math.round(_1*_3)/_3;
};
NumberFormat.SplitGroups=function(_4,_5,_6){
var sb=_4.toString().split("");
for(var i=sb.length-_5;i>0;i-=_5){
sb.splice(i,0,_6);
}
return sb.join("");
};
NumberFormat.Parse=function(_9,_a,_b,_c){
return parseFloat(_9.toString().replace(_a,"").replace(_b,".").replace(_c,"-"));
};
NumberFormat.Pad=function(_d,_e,_f){
while(_d.toString().length<_e){
_d=_d.toString()+_f.toString();
}
return _d;
};
NumberFormat.Format=function(_10,_11){
var num=parseFloat(_10.toString().replace(_11.get_numberFormat().DecimalSeparator,"."));
if(isNaN(num)){
return "";
}
var _13="";
num=this.Round(num,_11);
var _14=Math.abs(num).toString().split(".");
_13+=this.SplitGroups(_14[0],_11.get_numberFormat().GroupSizes,_11.get_numberFormat().GroupSeparator);
if((!_11.get_numberFormat().AllowRounding)&&(_14[1])){
_13+=_11.get_numberFormat().DecimalSeparator+_14[1];
}else{
if(!_11.get_numberFormat().AllowRounding){
_13=_13;
}else{
if(_14[1]){
_13+=_11.get_numberFormat().DecimalSeparator+this.Pad(_14[1],_11.get_numberFormat().DecimalDigits,"0");
}else{
if(_11.get_numberFormat().DecimalDigits>0){
_13+=_11.get_numberFormat().DecimalSeparator+this.Pad("",_11.get_numberFormat().DecimalDigits,"0");
}
}
}
}
var _15=num<0?_11.get_numberFormat().NegativePattern:_11.get_numberFormat().PositivePattern;
return _15.replace("n",_13);
};
NumberFormat.ReturnZeroIfEmpty=function(_16){
if((_16==null)||(_16=="")||isNaN(_16)){
return 0;
}
return _16;
};
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadNumericTextBox=function(_17){
Telerik.Web.UI.RadNumericTextBox.initializeBase(this,[_17]);
this._showSpinButtons=false;
this._maxValue=70368744177664;
this._minValue=-70368744177664;
this._numberFormat=null;
this._originalValue="";
this._incrementSettings=null;
this._hold=false;
this._selectionOnFocus=Telerik.Web.UI.SelectionOnFocus.SelectAll;
this._onButtonUpMouseDownDelegate=null;
this._onButtonDownMouseDownDelegate=null;
this._onButtonUpMouseUpDelegate=null;
this._onButtonDownMouseUpDelegate=null;
this._onSpinMouseOutDelegate=null;
this._onFormResetDelegate=null;
};
Telerik.Web.UI.RadNumericTextBox.prototype={initialize:function(){
Telerik.Web.UI.RadNumericTextBox.callBaseMethod(this,"initialize");
this._compileRegEx();
this._onFormResetDelegate=Function.createDelegate(this,this._onFormResetHandler);
$addHandler(this._textBoxElement.form,"reset",this._onFormResetDelegate);
if((this._initialValue!="")&&(!this.get_numberFormat().KeepNotRoundedValue)){
this._hiddenElement.value=NumberFormat.Round(this._initialValue,this);
}else{
if((this._initialValue!="")&&(this.get_numberFormat().KeepNotRoundedValue)){
this._hiddenElement.value=this._initialValue;
}
}
},dispose:function(){
if(this.SpinUpButton){
if(this._onButtonUpMouseDownDelegate){
$removeHandler(this.SpinUpButton,"mousedown",this._onButtonUpMouseDownDelegate);
this._onButtonUpMouseDownDelegate=null;
}
if(this._onButtonUpMouseUpDelegate){
$removeHandler(this.SpinUpButton,"mouseup",this._onButtonUpMouseUpDelegate);
this._onButtonUpMouseUpDelegate=null;
}
if(this._onSpinMouseOutDelegate){
$removeHandler(this.SpinUpButton,"mouseout",this._onSpinMouseOutDelegate);
this._onSpinMouseOutDelegate=null;
}
}
if(this.SpinDownButton){
if(this._onButtonDownMouseDownDelegate){
$removeHandler(this.SpinDownButton,"mousedown",this._onButtonDownMouseDownDelegate);
this._onButtonDownMouseDownDelegate=null;
}
if(this._onButtonDownMouseUpDelegate){
$removeHandler(this.SpinDownButton,"mouseup",this._onButtonDownMouseUpDelegate);
this._onButtonDownMouseUpDelegate=null;
}
if(this._onSpinMouseOutDelegate){
$removeHandler(this.SpinDownButton,"mouseout",this._onSpinMouseOutDelegate);
this._onSpinMouseOutDelegate=null;
}
}
if(this._onFormResetDelegate){
if(this._textBoxElement.form){
$removeHandler(this._textBoxElement.form,"reset",this._onFormResetDelegate);
}
this._onFormResetDelegate=null;
}
Telerik.Web.UI.RadNumericTextBox.callBaseMethod(this,"dispose");
},isNegative:function(){
return this.get_value()<0;
},get_value:function(){
var _18=parseFloat(this._hiddenElement.value);
if(isNaN(_18)){
_18="";
}
return _18;
},set_value:function(_19){
if(typeof (_19)=="string"&&_19!=""){
_19=_19.replace(this._rejectRegExp,this.get_numberFormat().DecimalSeparator);
_19=NumberFormat.Parse(_19,this._rejectRegExp,this.get_numberFormat().DecimalSeparator,this.get_numberFormat().NegativeSign);
}
if(_19<this.get_minValue()||_19>this.get_maxValue()){
var _1a=new Telerik.Web.UI.InputErrorEventArgs(Telerik.Web.UI.InputErrorReason.OutOfRange,_19,null,null);
this.raise_error(_1a);
}
Telerik.Web.UI.RadNumericTextBox.callBaseMethod(this,"set_value",[_19]);
},get_displayValue:function(){
return NumberFormat.Format(this._getParsedTextBoxValue(),this);
},get_editValue:function(){
var _1b=this.get_value().toString().replace(".",this.get_numberFormat().DecimalSeparator);
return _1b.replace("-",this.get_numberFormat().NegativeSign);
},get_showSpinButtons:function(){
return this._showSpinButtons;
},set_showSpinButtons:function(_1c){
if(this._showSpinButtons!==_1c){
this._showSpinButtons=_1c;
this.raisePropertyChanged("ShowSpinButtons");
}
},get_maxValue:function(){
return this._maxValue;
},set_maxValue:function(_1d){
if(this._maxValue!==_1d){
this._maxValue=_1d;
this.raisePropertyChanged("MaxValue");
}
},get_minValue:function(){
return this._minValue;
},set_minValue:function(_1e){
if(this._minValue!==_1e){
this._minValue=_1e;
this.raisePropertyChanged("MinValue");
}
},get_numberFormat:function(){
return this._numberFormat;
},set_numberFormat:function(_1f){
this._numberFormat=_1f;
},get_incrementSettings:function(){
return this._incrementSettings;
},set_incrementSettings:function(_20){
if(this._incrementSettings!==_20){
this._incrementSettings=_20;
this.raisePropertyChanged("IncrementSettings");
}
},_getParsedTextBoxValue:function(){
var _21=NumberFormat.Parse(this.get_textBoxValue(),this._rejectRegExp,this.get_numberFormat().DecimalSeparator,this.get_numberFormat().NegativeSign);
_21=Math.max(this.get_minValue(),_21);
_21=Math.min(this.get_maxValue(),_21);
return _21;
},_compileRegEx:function(){
var _22=this.get_numberFormat().DecimalSeparator=="."?"\\.":this.get_numberFormat().DecimalSeparator;
this._acceptRegExp=new RegExp("[0-9"+_22+this.get_numberFormat().NegativeSign+"]{1}");
this._rejectRegExp=new RegExp("[^0-9"+_22+this.get_numberFormat().NegativeSign+"]{1}","g");
this._decimalReplaceRegExp=new RegExp(_22,"g");
},_onFormResetHandler:function(e){
if(this._originalValue==null){
this._originalValue="";
}
this.set_value(this._originalValue);
this._textBoxElement.defaultValue=this._originalValue;
},_onTextBoxKeyDownHandler:function(e){
if(!this.get_incrementSettings().InterceptArrowKeys){
return;
}
if(e.altKey||e.ctrlKey){
return true;
}
if(e.keyCode==38){
this._move(this.get_incrementSettings().Step,false);
}else{
if(e.keyCode==40){
this._move(-this.get_incrementSettings().Step,false);
}else{
if(e.keyCode==110&&this.get_numberFormat().DecimalSeparator!="."){
this._numPadDecimalSeparatorPressed=true;
e.preventDefault();
e.stopPropagation();
this._triggerDecimalSeparatorPressedEvent(this._textBoxElement);
}
}
}
},_triggerDecimalSeparatorPressedEvent:function(_25){
this._fakeKeyPressEventTriggered=true;
var _26=this.get_numberFormat().DecimalSeparator.charCodeAt(0);
if(_25.fireEvent&&document.createEventObject){
var _27=document.createEventObject();
_27.keyCode=_26;
_25.fireEvent("onkeypress",_27);
}else{
if(_25.dispatchEvent){
var _27=document.createEvent("KeyboardEvent");
_27.initKeyEvent("keypress",true,true,null,false,false,false,false,0,_26);
_25.dispatchEvent(_27);
}
}
},_handleWheel:function(_28){
if(!this.get_incrementSettings().InterceptMouseWheel){
return;
}
this._calculateSelection();
if(_28){
this._move(-this.get_incrementSettings().Step,false);
}else{
this._move(this.get_incrementSettings().Step,false);
}
this._applySelection();
},_onTextBoxKeyPressHandler:function(e){
var _2a=String.fromCharCode(e.charCode);
if(e.charCode==46&&this._numPadDecimalSeparatorPressed&&_2a!=this.get_numberFormat().DecimalSeparator){
e.preventDefault();
e.stopPropagation();
return;
}
if(e.altKey||e.ctrlKey){
return true;
}
var _2b=new Telerik.Web.UI.InputKeyPressEventArgs(e,e.charCode,String.fromCharCode(e.charCode));
this.raise_keyPress(_2b);
if(_2b.get_cancel()){
e.stopPropagation();
e.preventDefault();
return false;
}
if(e.charCode==13){
this._updateHiddenValueOnKeyPress(e);
if(this.get_autoPostBack()){
this.raisePostBackEvent();
}
return true;
}
if(!e.charCode||e.charCode==8||e.charCode==9||e.charCode==27){
return true;
}
var _2c=this.get_textBoxValue();
if(!this._isNormalChar(e)){
return true;
}
if(!_2a.match(this._acceptRegExp)){
var _2b=new Telerik.Web.UI.InputErrorEventArgs(Telerik.Web.UI.InputErrorReason.ParseError,_2c,e.charCode,_2a);
this.raise_error(_2b);
e.stopPropagation();
e.preventDefault();
return false;
}
if(_2a==this.get_numberFormat().NegativeSign){
this._calculateSelection();
var _2d=(this._selectionStart!=0);
_2d=_2d||(_2c.indexOf(this.get_numberFormat().NegativeSign)==0&&(this._selectionStart==0&&this._selectionEnd==0));
if(_2d){
var _2b=new Telerik.Web.UI.InputErrorEventArgs(Telerik.Web.UI.InputErrorReason.ParseError,_2c,e.charCode,_2a);
this.raise_error(_2b);
e.stopPropagation();
e.preventDefault();
return false;
}
}
if(_2a==this.get_numberFormat().DecimalSeparator){
this._calculateSelection();
var _2e=_2c.substr(0,this._selectionStart);
var _2f=_2c.substr(this._selectionStart,this._selectionEnd-this._selectionStart);
var _30=_2c.substr(this._selectionEnd,_2c.length-1);
if(_2e.match(this._decimalReplaceRegExp)){
this._selectionStart--;
this._selectionEnd--;
}else{
if(_2f.match(this._decimalReplaceRegExp)){
this._selectionEnd--;
}
}
_2c=_2c.replace(this._decimalReplaceRegExp,"");
if(_2f.length==_2c.length){
this.set_textBoxValue("");
}else{
this.set_textBoxValue((_2e+this.get_numberFormat().DecimalSeparator+_30).replace(this._decimalReplaceRegExp,""));
}
if(this._fakeKeyPressEventTriggered){
this._fakeKeyPressEventTriggered=false;
if(Sys.Browser.agent==Sys.Browser.InternetExplorer){
var _31=document.selection.createRange();
if(_31.parentElement()==this._textBoxElement){
_31.text=_2a;
}
}
}
}
},_moveUp:function(){
return this._move(this.get_incrementSettings().Step,true);
},_moveDown:function(){
return this._move(-this.get_incrementSettings().Step,true);
},_move:function(_32,_33){
if(this.isReadOnly()){
return false;
}
var _34=this.get_value();
_34=_34+_32;
if(!_33){
this._SetValue(_34);
}else{
this.set_value(_34);
}
return true;
},_initializeButtons:function(){
this._onButtonUpMouseDownDelegate=Function.createDelegate(this,this._onButtonUpMouseDownHandler);
this._onButtonDownMouseDownDelegate=Function.createDelegate(this,this._onButtonDownMouseDownHandler);
this._onButtonUpMouseUpDelegate=Function.createDelegate(this,this._onButtonUpMouseUpHandler);
this._onButtonDownMouseUpDelegate=Function.createDelegate(this,this._onButtonDownMouseUpHandler);
this._onSpinMouseOutDelegate=Function.createDelegate(this,this._onSpinMouseOutHandler);
this.SpinUpButton=null;
this.SpinDownButton=null;
this.Button=null;
var _35=$get(this._wrapperElementID);
var _36=_35.getElementsByTagName("a");
var i;
for(i=0;i<_36.length;i++){
if(_36[i].className.indexOf("spinbutton down")!=(-1)){
this.SpinDownButton=_36[i];
}else{
if(_36[i].className.indexOf("spinbutton up")!=(-1)){
this.SpinUpButton=_36[i];
}
}
}
if(this.get_showSpinButtons()){
$addHandler(this.SpinUpButton,"mousedown",this._onButtonUpMouseDownDelegate);
$addHandler(this.SpinDownButton,"mousedown",this._onButtonDownMouseDownDelegate);
$addHandler(this.SpinUpButton,"mouseup",this._onButtonUpMouseUpDelegate);
$addHandler(this.SpinDownButton,"mouseup",this._onButtonDownMouseUpDelegate);
$addHandler(this.SpinUpButton,"mouseout",this._onSpinMouseOutDelegate);
$addHandler(this.SpinDownButton,"mouseout",this._onSpinMouseOutDelegate);
}
Telerik.Web.UI.RadNumericTextBox.callBaseMethod(this,"_initializeButtons");
},_onSpinMouseOutHandler:function(e){
this._hold=false;
},_onButtonUpMouseDownHandler:function(e){
var _3a=new Telerik.Web.UI.InputButtonClickEventArgs(Telerik.Web.UI.InputButtonType.MoveUpButton);
this.raise_buttonClick(_3a);
if(_3a.get_cancel()){
return false;
}
this._hold=true;
this._repeatedMoveUp(300);
},_onButtonDownMouseDownHandler:function(e){
var _3c=new Telerik.Web.UI.InputButtonClickEventArgs(Telerik.Web.UI.InputButtonType.MoveDownButton);
this.raise_buttonClick(_3c);
if(_3c.get_cancel()){
return false;
}
this._hold=true;
this._repeatedMoveDown(300);
},_repeatedMoveUp:function(_3d){
if(this._hold==false){
return;
}
var _3e=this;
var _3f=_3d;
if(_3f>50){
_3f-=40;
}
var _40=function(){
_3e._repeatedMoveUp(_3f);
};
_3e._moveUp();
if(!this.get_autoPostBack()){
window.setTimeout(_40,_3d);
}
},_repeatedMoveDown:function(_41){
if(this._hold==false){
return;
}
var _42=this;
var _43=_41;
if(_43>50){
_43-=40;
}
var _44=function(){
_42._repeatedMoveDown(_43);
};
_42._moveDown();
if(!this.get_autoPostBack()){
window.setTimeout(_44,_41);
}
},_onButtonUpMouseUpHandler:function(e){
this._hold=false;
this.SpinUpButton.blur();
},_onButtonDownMouseUpHandler:function(e){
this._hold=false;
this.SpinDownButton.blur();
},_SetValue:function(_47){
if(_47<this.get_minValue()||_47>this.get_maxValue()){
var _48=new Telerik.Web.UI.InputErrorEventArgs(Telerik.Web.UI.InputErrorReason.OutOfRange,_47,null,null);
this.raise_error(_48);
}
Telerik.Web.UI.RadNumericTextBox.callBaseMethod(this,"_SetValue",[_47]);
},_setHiddenValue:function(_49){
if(typeof (_49)!="number"){
_49=NumberFormat.Parse(_49,this._rejectRegExp,this.get_numberFormat().DecimalSeparator,this.get_numberFormat().NegativeSign);
}
_49=Math.max(this.get_minValue(),_49);
_49=Math.min(this.get_maxValue(),_49);
if(!this.get_numberFormat().KeepNotRoundedValue){
_49=NumberFormat.Round(_49,this);
}
if(isNaN(_49)){
_49="";
}
Telerik.Web.UI.RadNumericTextBox.callBaseMethod(this,"_setHiddenValue",[_49]);
},_initializeHiddenElement:function(id){
this._hiddenElement=$get(id+"_Value");
},_initializeValidationField:function(id){
this._validationField=$get(id);
},_setValidationField:function(_4c){
this._validationField.value=_4c.toString().replace(".",this.get_numberFormat().DecimalSeparator);
},_getValidationField:function(_4d){
return this._validationField;
}};
Telerik.Web.UI.RadNumericTextBox.registerClass("Telerik.Web.UI.RadNumericTextBox",Telerik.Web.UI.RadInputControl);

