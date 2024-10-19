Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.MaskedEventWrap=function(e,_2){
this.event=e.rawEvent;
this._selectionStart=_2.selectionStart;
this._selectionEnd=_2.selectionEnd;
this.fieldValue=_2.value;
};
Telerik.Web.UI.MaskedEventWrap.prototype={IsUpArrow:function(){
return this.event.keyCode==38;
},IsDownArrow:function(){
return this.event.keyCode==40;
}};
Telerik.Web.UI.MaskedEventWrap.registerClass("Telerik.Web.UI.MaskedEventWrap");
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadMaskPart=function(){
this.value="";
this.index=-1;
this.type=-1;
this.PromptChar="_";
};
Telerik.Web.UI.RadMaskPart.prototype={HandleKey:function(ev){
return false;
},HandleWheel:function(_4){
return true;
},SetController:function(_5){
this.controller=_5;
},GetValue:function(){
return this.value.toString();
},GetVisValue:function(){
return "";
},SetValue:function(_6,_7){
return true;
},CanHandle:function(_8,_9){
return true;
},IsCaseSensitive:function(){
return false;
},GetLength:function(){
return 1;
},IsAlpha:function(_a){
return _a.match(/[^\u005D\u005B\t\n\r\f\s\v\\!-@|^_`{-¿]{1}/)!=null;
}};
Telerik.Web.UI.RadMaskPart.registerClass("Telerik.Web.UI.RadMaskPart");
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadDigitMaskPart=function(){
Telerik.Web.UI.RadDigitMaskPart.initializeBase(this);
};
Telerik.Web.UI.RadDigitMaskPart.prototype={GetValue:function(){
return this.value.toString();
},IsCaseSensitive:function(){
return true;
},GetVisValue:function(){
if(this.value.toString()==""){
return this.PromptChar;
}
return this.value.toString();
},CanHandle:function(_b,_c){
if(isNaN(parseInt(_b))){
this.controller._OnChunkError(this,this.GetValue(),_b);
return false;
}
return true;
},SetValue:function(_d,_e){
if(_d==""||_d==this.PromptChar||_d==" "){
this.value="";
return true;
}
if(this.CanHandle(_d,_e)){
this.value=parseInt(_d);
}
return true;
}};
Telerik.Web.UI.RadDigitMaskPart.registerClass("Telerik.Web.UI.RadDigitMaskPart",Telerik.Web.UI.RadMaskPart);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadEnumerationMaskPart=function(_f){
Telerik.Web.UI.RadEnumerationMaskPart.initializeBase(this);
this.SetOptions(_f);
this.lastOffsetPunched=-1;
this.selectedForCompletion=0;
this.FlipDirection=0;
this.RebuildKeyBuff();
};
Telerik.Web.UI.RadEnumerationMaskPart.prototype={SetOptions:function(_10){
this.length=0;
this.Options=_10;
this.optionsIndex=[];
for(var i=0;i<this.Options.length;i++){
this.length=Math.max(this.length,this.Options[i].length);
this.optionsIndex[this.Options[i]]=i;
}
},CanHandle:function(){
return true;
},SetController:function(_12){
this.controller=_12;
this.InitializeSelection(_12.get_allowEmptyEnumerations());
},InitializeSelection:function(_13){
if(_13){
this.value="";
this.selectedIndex=-1;
}else{
this.value=this.Options[0];
this.selectedIndex=0;
}
},RebuildKeyBuff:function(){
this.keyBuff=[];
for(i=0;i<this.length;i++){
this.keyBuff[i]="";
}
this.keyBuffRebuilt=true;
},IsCaseSensitive:function(){
return true;
},ResetCompletion:function(){
this.selectedForCompetion=0;
},SelectNextCompletion:function(){
this.selectedForCompletion++;
},Store:function(_14,_15){
if(this.lastOffsetPunched==_15){
if(this.keyBuff[_15]==_14){
this.SelectNextCompletion();
}else{
this.RebuildKeyBuff();
}
}else{
this.ResetCompletion();
}
this.lastOffsetPunched=_15;
this.keyBuff[_15]=_14;
},SetNoCompletionValue:function(){
if(this.controller.get_allowEmptyEnumerations()){
this.SetOption(-1);
}
},SetValue:function(_16,_17){
_17-=this.offset;
this.Store(_16,_17);
var _18=new Telerik.Web.UI.CompletionList(this.Options,this.PromptChar);
var _19=_18.GetCompletions(this.keyBuff,_17);
if(_19.length>0){
var _1a=this.optionsIndex[_19[this.selectedForCompletion%_19.length]];
this.SetOption(_1a);
}else{
this.SetNoCompletionValue();
return false;
}
return true;
},GetVisValue:function(){
var v=this.value;
while(v.length<this.length){
v+=this.PromptChar;
}
return v;
},GetLength:function(){
return this.length;
},GetSelectedIndex:function(){
return this.selectedIndex;
},SetOption:function(_1c,up){
var _1e=this.value;
if(this.controller.get_allowEmptyEnumerations()){
if(_1c<-1){
_1c=this.Options.length+_1c+1;
this.FlipDirection=-1;
}else{
if(_1c>=this.Options.length){
_1c=_1c-this.Options.length-1;
this.FlipDirection=1;
}
}
}else{
if(_1c<0){
_1c=this.Options.length+_1c;
this.FlipDirection=-1;
}else{
if(_1c>=this.Options.length){
_1c=_1c-this.Options.length;
this.FlipDirection=1;
}
}
}
this.selectedIndex=_1c;
this.value=_1c==-1?"":this.Options[_1c];
if(typeof (up)!="undefined"){
if(up){
this.controller._OnMoveUp(this,_1e,this.value);
}else{
this.controller._OnMoveDown(this,_1e,this.value);
}
}
this.controller._OnEnumChanged(this,_1e,this.value);
this.FlipDirection=0;
},HandleKey:function(e){
this.controller._calculateSelection();
var _20=new Telerik.Web.UI.MaskedEventWrap(e,this.controller._textBoxElement);
if(_20.IsDownArrow()){
this.SetOption(this.selectedIndex+1,false);
this.controller._Visualise();
this.controller._FixSelection(_20);
return true;
}else{
if(_20.IsUpArrow()){
this.SetOption(this.selectedIndex-1,true);
this.controller._Visualise();
this.controller._FixSelection(_20);
return true;
}
}
},HandleWheel:function(e){
this.controller._calculateSelection();
var _22=new Telerik.Web.UI.MaskedEventWrap(e,this.controller._textBoxElement);
this.SetOption(this.selectedIndex-e.rawEvent.wheelDelta/120);
this.controller._Visualise();
this.controller._FixSelection(_22);
return false;
}};
Telerik.Web.UI.RadEnumerationMaskPart.registerClass("Telerik.Web.UI.RadEnumerationMaskPart",Telerik.Web.UI.RadMaskPart);
Telerik.Web.UI.CompletionList=function(_23,_24){
this.options=_23;
this.blankChar=_24;
};
Telerik.Web.UI.CompletionList.prototype={GetCompletions:function(_25,_26){
var _27=this.options;
for(var _28=0;_28<=_26;_28++){
var _29=_25[_28].toLowerCase();
_27=this.FilterCompletions(_27,_28,_29);
}
return _27;
},FilterCompletions:function(_2a,_2b,key){
var _2d=[];
for(var _2e=0;_2e<_2a.length;_2e++){
var _2f=_2a[_2e];
var _30=_2f.charAt(_2b).toLowerCase();
if(this.CharacterMatchesCompletion(key,_30)){
_2d[_2d.length]=_2f;
}
}
return _2d;
},CharacterMatchesCompletion:function(_31,_32){
return _31==this.blankChar||_31==" "||_31==_32;
}};
Telerik.Web.UI.CompletionList.registerClass("Telerik.Web.UI.CompletionList");
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadFreeMaskPart=function(){
Telerik.Web.UI.RadFreeMaskPart.initializeBase(this);
};
Telerik.Web.UI.RadFreeMaskPart.prototype={IsCaseSensitive:function(){
return true;
},GetVisValue:function(){
if(this.value.toString()==""){
return this.PromptChar;
}
return this.value;
},SetValue:function(_33,_34){
this.value=_33;
return true;
}};
Telerik.Web.UI.RadFreeMaskPart.registerClass("Telerik.Web.UI.RadFreeMaskPart",Telerik.Web.UI.RadMaskPart);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadLiteralMaskPart=function(ch){
Telerik.Web.UI.RadLiteralMaskPart.initializeBase(this);
this.ch=ch;
};
Telerik.Web.UI.RadLiteralMaskPart.prototype={GetVisValue:function(){
return this.ch;
},GetLength:function(){
if(Sys.Browser.agent==Sys.Browser.Firefox){
return this.ch.length-(this.ch.split("\r\n").length-1);
}
return this.ch.length;
},GetValue:function(){
return "";
},IsCaseSensitive:function(){
if(this.NextChunk!=null){
return this.NextChunk.IsCaseSensitive();
}
},SetValue:function(_36,_37){
_37-=this.offset;
return _36==this.ch.charAt(_37)||!_36;
},CanHandle:function(_38,_39){
_39-=this.offset;
if(_38==this.ch.charAt(_39)){
return true;
}
if(!_38){
return true;
}
if(this.NextChunk!=null){
return this.NextChunk.CanHandle(_38,_39+this.GetLength());
}
}};
Telerik.Web.UI.RadLiteralMaskPart.registerClass("Telerik.Web.UI.RadLiteralMaskPart",Telerik.Web.UI.RadMaskPart);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadLowerMaskPart=function(){
Telerik.Web.UI.RadLowerMaskPart.initializeBase(this);
};
Telerik.Web.UI.RadLowerMaskPart.prototype={CanHandle:function(_3a,_3b){
if(!this.IsAlpha(_3a)){
this.controller._OnChunkError(this,this.GetValue(),_3a);
return false;
}
return true;
},GetVisValue:function(){
if(this.value.toString()==""){
return this.PromptChar;
}
return this.value.toString();
},SetValue:function(_3c,_3d){
if(_3c==""){
this.value="";
return true;
}
if(this.IsAlpha(_3c)){
this.value=_3c.toLowerCase();
}else{
this.controller._OnChunkError(this,this.GetValue(),_3c);
}
return true;
}};
Telerik.Web.UI.RadLowerMaskPart.registerClass("Telerik.Web.UI.RadLowerMaskPart",Telerik.Web.UI.RadMaskPart);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadNumericRangeMaskPart=function(_3e,_3f,_40,_41){
Telerik.Web.UI.RadNumericRangeMaskPart.initializeBase(this);
this.upperLimit=_3f;
this.lowerLimit=_3e;
this.length=Math.max(this.lowerLimit.toString().length,this.upperLimit.toString().length);
this.leftAlign=_40;
this.zeroFill=_41;
this.minusIncluded=this.lowerLimit<0||this.upperLimit<0;
this.value=_3e;
this.FlipDirection=0;
};
Telerik.Web.UI.RadNumericRangeMaskPart.prototype={SetController:function(_42){
this.controller=_42;
this.GetVisValue();
},IsCaseSensitive:function(){
return true;
},CanHandle:function(_43,_44){
if((_43=="-"||_43=="+")&&this.lowerLimit<0){
return true;
}
if(isNaN(parseInt(_43))){
this.controller._OnChunkError(this,this.GetValue(),_43);
return false;
}
return true;
},InsertAt:function(_45,_46){
return this.visValue.substr(0,_46)+_45.toString()+this.visValue.substr(_46+1,this.visValue.length);
},ReplacePromptChar:function(_47){
var _48=this.leftAlign?"":"0";
while(_47.indexOf(this.PromptChar)>-1){
_47=_47.replace(this.PromptChar,_48);
}
return _47;
},SetValue:function(_49,_4a){
if(_49==""){
_49=0;
}
if(isNaN(parseInt(_49))&&_49!="+"&&_49!="-"){
return true;
}
_4a-=this.offset;
var _4b=this.InsertAt(_49,_4a);
_4b=this.ReplacePromptChar(_4b);
if(_4b.indexOf("-")!=-1&&_4b.indexOf("-")>0){
_4b=_4b.replace("-","0");
}
if(isNaN(parseInt(_4b))){
_4b=0;
}
if(this.controller.get_roundNumericRanges()){
_4b=Math.min(this.upperLimit,_4b);
_4b=Math.max(this.lowerLimit,_4b);
this.setInternalValue(_4b);
}else{
if(_4b<=this.upperLimit&&_4b>=this.lowerLimit){
this.setInternalValue(_4b);
this.GetVisValue();
}else{
return false;
}
}
this.GetVisValue();
return true;
},setInternalValue:function(_4c){
var _4d=this.value;
this.value=_4c;
this.controller._OnEnumChanged(this,_4d,_4c);
if(_4d>_4c){
this.controller._OnMoveDown(this,_4d,_4c);
}else{
if(_4d<_4c){
this.controller._OnMoveUp(this,_4d,_4c);
}
}
this.FlipDirection=0;
},GetVisValue:function(){
var out="";
var _4f=Math.abs(this.value).toString();
if(this.leftAlign){
if(this.value<0){
out+=this.PromptChar;
}
out+=_4f;
while(out.length<this.length){
out+=this.controller.get_promptChar();
}
}else{
var _50=this.zeroFill?"0":this.controller.get_promptChar();
if(this.value<0){
_4f="-"+_4f;
}
while(out.length<this.length-_4f.length){
out+=_50;
}
out+=_4f;
}
this.visValue=out;
return out;
},GetLength:function(){
return this.length;
},HandleKey:function(e){
this.controller._calculateSelection();
var _52=new Telerik.Web.UI.MaskedEventWrap(e,this.controller._textBoxElement);
if(_52.IsDownArrow()){
this.MoveDown();
this.controller._FixSelection(_52);
return true;
}else{
if(_52.IsUpArrow()){
this.MoveUp();
this.controller._FixSelection(_52);
return true;
}
}
},MoveUp:function(){
var _53=this.value;
_53++;
if(_53>this.upperLimit){
_53=this.lowerLimit;
this.FlipDirection=1;
}
this.setInternalValue(_53);
this.controller._Visualise();
},MoveDown:function(){
var _54=this.value;
_54--;
if(_54<this.lowerLimit){
_54=this.upperLimit;
this.FlipDirection=-1;
}
this.setInternalValue(_54);
this.controller._Visualise();
},HandleWheel:function(e){
var _56=this.value;
var _57;
if(e.rawEvent.wheelDelta){
_57=e.rawEvent.wheelDelta/120;
if(window.opera){
_57=-_57;
}
}else{
if(e.rawEvent.detail){
_57=-e.rawEvent.detail/3;
}
}
_56=parseInt(_56)+_57;
var _58=new Telerik.Web.UI.MaskedEventWrap(e,this.controller._textBoxElement);
if(_56<this.lowerLimit){
_56=this.upperLimit-(this.lowerLimit-_56-1);
this.FlipDirection=-1;
}
if(_56>this.upperLimit){
_56=this.lowerLimit+(_56-this.upperLimit-1);
this.FlipDirection=1;
}
this.setInternalValue(_56);
this.controller._Visualise();
this.controller._FixSelection(_58);
return false;
}};
Telerik.Web.UI.RadNumericRangeMaskPart.registerClass("Telerik.Web.UI.RadNumericRangeMaskPart",Telerik.Web.UI.RadMaskPart);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadUpperMaskPart=function(){
Telerik.Web.UI.RadUpperMaskPart.initializeBase(this);
};
Telerik.Web.UI.RadUpperMaskPart.prototype={CanHandle:function(_59,_5a){
if(!this.IsAlpha(_59)){
this.controller._OnChunkError(this,this.GetValue(),_59);
return false;
}
return true;
},GetVisValue:function(){
if(this.value.toString()==""){
return this.PromptChar;
}
return this.value.toString();
},SetValue:function(_5b,_5c){
if(_5b==""){
this.value="";
return true;
}
if(this.IsAlpha(_5b)){
this.value=_5b.toUpperCase();
}else{
this.controller._OnChunkError(this,this.GetValue(),_5b);
}
return true;
}};
Telerik.Web.UI.RadUpperMaskPart.registerClass("Telerik.Web.UI.RadUpperMaskPart",Telerik.Web.UI.RadMaskPart);
Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadMaskedTextBox=function(_5d){
Telerik.Web.UI.RadMaskedTextBox.initializeBase(this,[_5d]);
this._parts=[];
this._partIndex=[];
this._displayPartIndex=[];
this._value="";
this._lastState=null;
this._length=0;
this._displayLength=0;
this._internalValueUpdate=false;
this._projectedValue="";
this._isTextarea=false;
this._initialMasks=[];
this._initialDisplayMasks=[];
this._promptChar="_";
this._displayPromptChar="_";
this._displayFormatPosition=Telerik.Web.UI.DisplayFormatPosition.Left;
this._hideOnBlur=false;
this._resetCaretOnFocus=false;
this._roundNumericRanges=true;
this._allowEmptyEnumerations=false;
this._readOnly=false;
this._focusOnStartup=false;
this._onTextBoxMouseUpDelegate=null;
this._onTextBoxMouseDownDelegate=null;
this._onTextBoxPasteDelegate=null;
this._onTextBoxPropertyChangeDelegate=null;
this._onTextBoxInputDelegate=null;
this._onFormResetDelegate=null;
this._isInitialized=false;
this._originalValue="";
};
Telerik.Web.UI.RadMaskedTextBox.prototype={initialize:function(){
Telerik.Web.UI.RadMaskedTextBox.callBaseMethod(this,"initialize");
this._fixAbsolutePositioning();
this._setMask(this.get__initialMasks());
if(this.get__initialDisplayMasks().length){
this._setDisplayMask(this.get__initialDisplayMasks());
}
this._SetValue(this._textBoxElement.value);
this._Visualise();
this._textBoxElement._oldValue=this._textBoxElement.value;
this._isTextarea=this._textBoxElement.tagName.toLowerCase()=="textarea";
if(this.get_focusOnStartup()){
this.focus();
}
this._RecordInitialState();
this._isInitialized=true;
},dispose:function(){
if(this._onTextBoxMouseUpDelegate){
$removeHandler(this._textBoxElement,"mouseup",this._onTextBoxMouseUpDelegate);
this._onTextBoxMouseUpDelegate=null;
}
if(this._onTextBoxMouseDownDelegate){
$removeHandler(this._textBoxElement,"mousedown",this._onTextBoxMouseDownDelegate);
this._onTextBoxMouseDownDelegate=null;
}
if(this._onFormResetDelegate){
if(this._textBoxElement.form){
$removeHandler(this._textBoxElement.form,"reset",this._onFormResetDelegate);
}
this._onFormResetDelegate=null;
}
if(Sys.Browser.agent==Sys.Browser.InternetExplorer){
if(this._onTextBoxPasteDelegate){
$removeHandler(this._textBoxElement,"paste",this._onTextBoxPasteDelegate);
this._onTextBoxPasteDelegate=null;
}
if(this._onTextBoxPropertyChangeDelegate){
$removeHandler(this._textBoxElement,"propertychange",this._onTextBoxPropertyChangeDelegate);
this._onTextBoxPropertyChangeDelegate=null;
}
}else{
if(this._onTextBoxInputDelegate){
$removeHandler(this._textBoxElement,"input",this._onTextBoxInputDelegate);
this._onTextBoxInputDelegate=null;
}
}
Telerik.Web.UI.RadMaskedTextBox.callBaseMethod(this,"dispose");
},isEmpty:function(){
return this._value=="";
},resetCursor:function(){
this.set_cursorPosition(0);
},inSelection:function(e){
this._calculateSelection();
if(this._textBoxElement.selectionStart!=this._textBoxElement.selectionEnd){
this._OnActivity(e);
return true;
}
if(e.ctrlKey||e.altKey||Sys.Browser.agent==Sys.Browser.Safari){
this._OnActivity(e);
return true;
}
return false;
},updateDisplayValue:function(){
if(this._isInitialized){
if(this._focused){
if((this.get_hideOnBlur()&&this.isEmpty())||this._displayParts){
this._Visualise();
this._textBoxElement.select();
}
if(this.get_resetCaretOnFocus()){
this.resetCursor();
}
}else{
this._Visualise();
}
}
},updateHiddenValue:function(){
return this._setHiddenValue(this.get_valueWithPromptAndLiterals());
},GetValueWithLiterals:function(){
return this.get_valueWithLiterals();
},GetValueWithPromptAndLiterals:function(){
return this.get_valueWithPromptAndLiterals();
},GetPrompt:function(){
return this.get_prompt();
},SetCursorPosition:function(_5f){
this.set_cursorPosition(_5f);
},get_valueWithLiterals:function(){
var _60=[];
for(var i=0;i<this._parts.length;i++){
_60[i]=this._parts[i].ch||this._parts[i].GetValue();
}
return _60.join("");
},get_valueWithPromptAndLiterals:function(){
return this._GetVisibleValues(this._parts);
},get_prompt:function(){
var _62=new RegExp(".","g");
var _63=[];
for(var i=0;i<this._parts.length;i++){
_63[i]=this._parts[i].ch||this._parts[i].GetVisValue().replace(_62,this.get_promptChar());
}
return _63.join("");
},get_displayValue:function(){
var _65=this._value;
while(_65.length<this._displayLength){
if(this.get_displayFormatPosition()){
_65=this.get_promptChar()+_65;
}else{
_65+=this.get_promptChar();
}
}
this._UpdateDisplayPartsInRange(_65,0,this._displayLength);
return this._GetVisibleValues(this._displayParts);
},set_cursorPosition:function(_66){
if(!this._focused){
return;
}
this._calculateSelection();
if(Sys.Browser.agent==Sys.Browser.InternetExplorer){
this._textBoxElement.select();
sel=document.selection.createRange();
var _67=this._textBoxElement.value.substr(0,_66).split("\r\n").length-1;
sel.move("character",_66-_67);
sel.select();
}else{
this._textBoxElement.selectionStart=_66;
this._textBoxElement.selectionEnd=_66;
}
},get_value:function(){
var _68=[];
for(var i=0;i<this._parts.length;i++){
_68[i]=this._parts[i].GetValue();
}
return _68.join("");
},set_value:function(_6a){
this._SetValue(_6a);
this.raise_valueChanged();
this._textBoxElement._oldValue=this._textBoxElement.value;
},get_promptChar:function(){
return this._promptChar;
},set_promptChar:function(_6b){
if(this._promptChar!=_6b){
this._promptChar=_6b;
this.raisePropertyChanged("PromptChar");
}
},get_displayPromptChar:function(){
return this._displayPromptChar;
},set_displayPromptChar:function(_6c){
if(this._displayPromptChar!=_6c){
this._displayPromptChar=_6c;
this.raisePropertyChanged("DisplayPromptChar");
}
},get_displayPromptChar:function(){
return this._displayPromptChar;
},set_displayPromptChar:function(_6d){
if(this._displayPromptChar!=_6d){
this._displayPromptChar=_6d;
this.raisePropertyChanged("DisplayPromptChar");
}
},get_displayPromptChar:function(){
return this._displayPromptChar;
},set_displayPromptChar:function(_6e){
if(this._displayPromptChar!=_6e){
this._displayPromptChar=_6e;
this.raisePropertyChanged("DisplayPromptChar");
}
},get_displayFormatPosition:function(){
return this._displayFormatPosition;
},set_displayFormatPosition:function(_6f){
if(this._displayFormatPosition!=_6f){
this._displayFormatPosition=_6f;
this.raisePropertyChanged("DisplayFormatPosition");
}
},get_hideOnBlur:function(){
return this._hideOnBlur;
},set_hideOnBlur:function(_70){
if(this._hideOnBlur!=_70){
this._hideOnBlur=_70;
this.raisePropertyChanged("HideOnBlur");
}
},get_resetCaretOnFocus:function(){
return this._resetCaretOnFocus;
},set_resetCaretOnFocus:function(_71){
if(this._resetCaretOnFocus!=_71){
this._resetCaretOnFocus=_71;
this.raisePropertyChanged("ResetCaretOnFocus");
}
},get_roundNumericRanges:function(){
return this._roundNumericRanges;
},set_roundNumericRanges:function(_72){
if(this._roundNumericRanges!=_72){
this._roundNumericRanges=_72;
this.raisePropertyChanged("RoundNumericRanges");
}
},get_allowEmptyEnumerations:function(){
return this._allowEmptyEnumerations;
},set_allowEmptyEnumerations:function(_73){
if(this._allowEmptyEnumerations!=_73){
this._allowEmptyEnumerations=_73;
this.raisePropertyChanged("AllowEmptyEnumerations");
}
},get_readOnly:function(){
return this._readOnly;
},set_readOnly:function(_74){
if(this._readOnly!=_74){
this._readOnly=_74;
this.raisePropertyChanged("ReadOnly");
}
},get_focusOnStartup:function(){
return this._focusOnStartup;
},set_focusOnStartup:function(_75){
if(this._focusOnStartup!=_75){
this._focusOnStartup=_75;
this.raisePropertyChanged("FocusOnStartup");
}
},_attachMouseEventHandlers:function(){
Telerik.Web.UI.RadMaskedTextBox.callBaseMethod(this,"_attachMouseEventHandlers");
this._onTextBoxMouseUpDelegate=Function.createDelegate(this,this._onTextBoxMouseUpHandler);
this._onTextBoxMouseDownDelegate=Function.createDelegate(this,this._onTextBoxMouseDownHandler);
$addHandler(this._textBoxElement,"mouseup",this._onTextBoxMouseUpDelegate);
$addHandler(this._textBoxElement,"mousedown",this._onTextBoxMouseDownDelegate);
},_attachEventHandlers:function(){
Telerik.Web.UI.RadMaskedTextBox.callBaseMethod(this,"_attachEventHandlers");
this._onFormResetDelegate=Function.createDelegate(this,this._onFormResetHandler);
$addHandler(this._textBoxElement.form,"reset",this._onFormResetDelegate);
if(Sys.Browser.agent==Sys.Browser.InternetExplorer){
this._onTextBoxPasteDelegate=Function.createDelegate(this,this._onTextBoxPasteHandler);
this._onTextBoxPropertyChangeDelegate=Function.createDelegate(this,this._onTextBoxPropertyChangeHandler);
$addHandler(this._textBoxElement,"paste",this._onTextBoxPasteDelegate);
$addHandler(this._textBoxElement,"propertychange",this._onTextBoxPropertyChangeDelegate);
}else{
this._onTextBoxInputDelegate=Function.createDelegate(this,this._onTextBoxInputHandler);
$addHandler(this._textBoxElement,"input",this._onTextBoxInputDelegate);
}
if(Sys.Browser.agent==Sys.Browser.Opera){
var _76=this;
var _77=function(){
return _76._ValueHandler({});
};
setInterval(_77,10);
}
},_SetValue:function(_78){
this._internalValueUpdate=true;
this._UpdatePartsInRange(_78,0,this._length);
this._internalValueUpdate=false;
this._Visualise();
},_initializeHiddenElement:function(id){
this._hiddenElement=$get(id+"_Value");
},_initializeValidationField:function(id){
this._validationField=$get(id);
},_setValidationField:function(_7b){
if(this.isEmpty()){
this._validationField.value="";
}else{
this._validationField.value=this.get_valueWithLiterals();
}
},_getValidationField:function(_7c){
return this._validationField;
},_onFormResetHandler:function(e){
if(this._originalValue==null){
this._originalValue="";
}
this._setHiddenValue(this._originalValue);
this._SetValue(this._originalValue);
},_onTextBoxInputHandler:function(e){
this._ValueHandler(e);
},_onMouseWheel:function(e){
return this._OnMouseWheel(event);
},_onTextBoxPropertyChangeHandler:function(e){
this._OnPropertyChange();
},_onTextBoxPasteHandler:function(e){
if(this.get_readOnly()){
return false;
}
if(this._selectionStart==this._value.length){
return false;
}
var _82=this;
setTimeout(function(){
_82._FakeOnPropertyChange();
},1);
},_onTextBoxBlurHandler:function(e){
this._focused=false;
this._hovered=false;
this.raise_valueChanged();
this.raise_blur(Sys.EventArgs.Empty);
this.updateDisplayValue();
this.updateCssClass();
if(this.get_autoPostBack()&&this._ValueHasChanged()){
this.raisePostBackEvent();
}
this._textBoxElement._oldValue=this._textBoxElement.value;
},_onTextBoxMouseUpHandler:function(e){
this._FakeOnPropertyChange();
this._ValueHandler(e);
this._ActivityHandler(e);
},_onTextBoxMouseOutHandler:function(e){
this._hovered=false;
this.updateCssClass();
this.raise_mouseOut(Sys.EventArgs.Empty);
},_onTextBoxMouseOverHandler:function(e){
this._FakeOnPropertyChange();
this._hovered=true;
this.updateCssClass();
this.raise_mouseOver(Sys.EventArgs.Empty);
},_onTextBoxMouseDownHandler:function(e){
this._FakeOnPropertyChange();
this._ActivityHandler(e);
},_onTextBoxFocusHandler:function(e){
this._focused=true;
this.updateDisplayValue();
this.updateCssClass();
this._updateSelectionOnFocus();
this._FakeOnPropertyChange();
this._ActivityHandler(e);
this.raise_focus(Sys.EventArgs.Empty);
},_onTextBoxKeyUpHandler:function(e){
this._FakeOnPropertyChange();
},_OnActivity:function(e){
this._calculateSelection();
this._lastState=new Telerik.Web.UI.MaskedEventWrap(e,this._textBoxElement);
},_OnPropertyChange:function(){
if(this._internalValueUpdate){
return;
}
if(event.propertyName=="value"){
var e=event;
var _8c=this;
var _8d=function(){
_8c._ValueHandler(e);
};
this._calculateSelection();
if(this._textBoxElement.selectionStart>0||this._textBoxElement.selectionEnd>0){
_8d();
}else{
setTimeout(_8d,1);
}
}
},_onTextBoxMouseWheelHandler:function(e){
if(this.get_readOnly()){
return false;
}
this._calculateSelection();
var _8f=this._partIndex[this._textBoxElement.selectionStart];
if(_8f==null){
return true;
}
return _8f.HandleWheel(e);
},_updateSelectionOnFocus:function(){
switch(this.get_selectionOnFocus()){
case 0:
break;
case 1:
var _90=0;
var i;
for(i=0;i<this._partIndex.length;i++){
if(!this._partIndex[i].ch){
_90=i;
break;
}
}
this.set_caretPosition(_90);
break;
case 2:
if(this._textBoxElement.value.length>0){
this.set_caretPosition(this._textBoxElement.value.length);
}
break;
case 3:
this.selectAllText();
break;
default:
this.set_caretPosition(0);
break;
}
},_onTextBoxKeyDownHandler:function(e){
this._FakeOnPropertyChange();
if(this.inSelection(e)){
return true;
}
var _93=this._partIndex[this._textBoxElement.selectionStart];
if(this.get_readOnly()&&(e.keyCode==46||e.keyCode==8||e.keyCode==38||e.keyCode==40)){
e.preventDefault();
return false;
}else{
if(e.keyCode==13){
return true;
}else{
if(_93==null&&e.keyCode!=8){
return true;
}else{
if(_93!=null){
if(_93.HandleKey(e)){
e.preventDefault();
return false;
}
}
}
}
}
var _94=this._textBoxElement.selectionEnd;
var _95=false;
if((e.keyCode==46)&&_94<this._textBoxElement.value.length&&Sys.Browser.agent!=Sys.Browser.Opera){
_93.SetValue("",this._textBoxElement.selectionStart);
_94++;
_95=true;
}else{
if(e.keyCode==8&&_94&&Sys.Browser.agent!=Sys.Browser.Opera){
this._partIndex[this._textBoxElement.selectionStart-1].SetValue("",this._textBoxElement.selectionStart-1);
_94--;
_95=true;
}
}
if(_95){
return this._UpdateAfterKeyHandled(e,_94);
}
this._OnActivity(e);
return true;
},_onTextBoxKeyPressHandler:function(e){
if(this.get_readOnly()){
e.preventDefault();
e.stopPropagation();
return false;
}
var _97=new Telerik.Web.UI.InputKeyPressEventArgs(e,e.charCode,String.fromCharCode(e.charCode));
this.raise_keyPress(_97);
if(_97.get_cancel()){
e.stopPropagation();
e.preventDefault();
return false;
}
if(this.inSelection(e)){
return true;
}
var _98=this._partIndex[this._textBoxElement.selectionStart];
if(_98==null){
return true;
}
if(Sys.Browser.agent==Sys.Browser.Firefox||Sys.Browser.agent==Sys.Browser.Opera){
if(e.charCode==8){
e.preventDefault();
e.stopPropagation();
return false;
}
if(!e.which){
this._OnActivity(e);
e.stopPropagation();
return true;
}
}
var _99=this._textBoxElement.selectionEnd;
if(e.charCode==13){
if(this.get_autoPostBack()){
this.raisePostBackEvent();
}
return true;
}
var ch=String.fromCharCode(e.charCode);
if(_98.CanHandle(ch)){
while(_99<this._textBoxElement.value.length){
if(this._partIndex[_99].SetValue(ch,_99)){
_99++;
break;
}
_99++;
}
}
var _9b=this._UpdateAfterKeyHandled(e,_99);
if(!_9b){
e.preventDefault();
}
e.stopPropagation();
return _9b;
},_OnEnumChanged:function(_9c,_9d,_9e){
var _9f=new Telerik.Web.UI.MaskedTextBoxEventArgs(_9e,_9d,_9c);
this.raise_enumerationChanged(_9f);
},_OnMoveUp:function(_a0,_a1,_a2){
var _a3=new Telerik.Web.UI.MaskedTextBoxEventArgs(_a2,_a1,_a0);
this.raise_moveUp(_a3);
},_OnMoveDown:function(_a4,_a5,_a6){
var _a7=new Telerik.Web.UI.MaskedTextBoxEventArgs(_a6,_a5,_a4);
this.raise_moveDown(_a7);
},_OnValueChange:function(_a8,_a9,_aa){
var _ab=new Telerik.Web.UI.MaskedTextBoxEventArgs(_aa,_a9,_a8);
this.raiseEvent("valueChanged",_ab);
},_OnChunkError:function(_ac,_ad,_ae){
var _af=new Telerik.Web.UI.MaskedTextBoxEventArgs(_ae,_ad,_ac);
this.raise_error(_af);
},_fixAbsolutePositioning:function(){
var f=this._textBoxElement;
if(f.previousSibling&&f.previousSibling.tagName.toLowerCase()=="label"&&f.style.position=="absolute"){
f.style.position="static";
var _b1=f.parentNode;
_b1.style.position="absolute";
_b1.style.top=f.style.top;
_b1.style.left=f.style.left;
}
},_RecordInitialState:function(){
this.initialFieldValue=this._textBoxElement.value;
},_PartAt:function(_b2){
return this._partIndex[_b2];
},_CreatePartCollection:function(_b3,_b4){
var _b5;
var _b6=[];
var _b7=0;
for(var j=0;j<_b3.length;j++){
_b5=_b3[j];
_b5.PromptChar=_b4;
_b5.SetController(this);
_b5.index=this._parts.length;
_b6[_b6.length]=_b5;
if(_b6.length>1){
_b6[_b6.length-2].NextChunk=_b5;
}
_b5.NextChunk=null;
var _b9=_b5.GetLength();
_b5.offset=_b7;
_b7+=_b9;
}
return _b6;
},_setMask:function(_ba){
this._parts=this._CreatePartCollection(_ba,this.get_promptChar());
for(var i=0;i<this._parts.length;i++){
var _bc=this._parts[i].GetLength();
for(var j=this._length;j<this._length+_bc;j++){
this._partIndex[j]=this._parts[i];
}
this._length+=_bc;
}
},_setDisplayMask:function(_be){
this._displayParts=this._CreatePartCollection(_be,this.get_displayPromptChar());
for(var i=0;i<this._displayParts.length;i++){
var _c0=this._displayParts[i];
var _c1=_c0.GetLength();
if(_c0.ch){
continue;
}
for(var j=this._displayLength;j<this._displayLength+_c1;j++){
this._displayPartIndex[j]=this._displayParts[i];
}
this._displayLength+=_c1;
}
},_SafariSelectionFix:function(e){
var _c4=this._StrCompare(this._lastState.fieldValue,e.fieldValue);
e._selectionStart=_c4[0];
e._selectionEnd=_c4[0];
this._lastState._selectionStart=_c4[1];
this._lastState._selectionEnd=_c4[2];
},_HandleValueChange:function(e){
if(this.get_readOnly()){
this._Visualise();
return false;
}
if(this._lastState==null){
return;
}
var i,j;
if(Sys.Browser.agent==Sys.Browser.Safari){
this._SafariSelectionFix(e);
}
if(this._lastState.fieldValue.length>e.fieldValue.length){
if(e._selectionStart==this._textBoxElement.value.length){
this._partIndex[this._partIndex.length-1].SetValue("",this._partIndex.length-1);
}
if(this._lastState._selectionEnd>e._selectionStart){
i=this._lastState._selectionEnd;
while(i-->e._selectionStart){
this._partIndex[i].SetValue("",i);
}
}else{
i=this._lastState._selectionEnd+1;
while(i-->e._selectionStart){
this._partIndex[i].SetValue("",i);
e._selectionEnd++;
}
}
}
var _c8=this._lastState._selectionStart;
var _c9=Math.min(e._selectionStart,this._length);
var _ca=e.fieldValue.substr(_c8,_c9-_c8);
var _cb=this._UpdatePartsInRange(_ca,_c8,_c9);
e._selectionEnd+=_cb;
this._FixSelection(e);
},_SetPartValues:function(_cc,_cd,_ce,_cf,to){
var _d1;
var i=0;
var j=_cf;
var _d4=0;
_ce=_ce.toString();
while(i<to-_cf&&j<_cd){
_d1=_ce.charAt(i);
if(_d1==this.get_promptChar()){
_d1="";
}
if(_cc[j].SetValue(_d1,j)){
i++;
}else{
_d4++;
}
j++;
}
return _d4;
},_UpdateDisplayPartsInRange:function(_d5,_d6,to){
this._SetPartValues(this._displayPartIndex,this._displayLength,_d5,_d6,to);
},_UpdatePartsInRange:function(_d8,_d9,to){
var _db=this._SetPartValues(this._partIndex,this._length,_d8,_d9,to);
this._Visualise();
return _db;
},_FixSelection:function(_dc){
this.set_cursorPosition(_dc._selectionEnd);
},_GetVisibleValues:function(_dd){
var _de=[];
for(var i=0;i<_dd.length;i++){
_de[i]=_dd[i].GetVisValue();
}
return _de.join("");
},_Visualise:function(){
var _e0=this.get_valueWithPromptAndLiterals();
var _e1=this.get_value();
this._internalValueUpdate=true;
this._Render(_e0);
this.updateCssClass();
this._value=_e1;
this.updateHiddenValue();
this._internalValueUpdate=false;
this._projectedValue=this._textBoxElement.value;
},_Render:function(_e2){
this._isEmptyMessage=false;
if(!this._focused){
if(this.get_hideOnBlur()&&this.isEmpty()){
this._isEmptyMessage=true;
this.set_textBoxValue(this.get_emptyMessage());
}else{
if(this._displayParts&&this._displayParts.length){
this.set_textBoxValue(this.get_displayValue());
}else{
this.set_textBoxValue(_e2);
}
}
}else{
this.set_textBoxValue(_e2);
}
},_getResetValue:function(){
var _e3="";
var _e4=this._parts[0];
while(_e4.NextChunk){
if(_e4.GetVisValue()==_e4.GetValue()){
_e3+=_e4.PromptChar;
}else{
_e3+=_e4.GetVisValue();
}
_e4=_e4.NextChunk;
}
return _e3;
},_ValueHasChanged:function(){
return this._textBoxElement.value!=this._textBoxElement._oldValue;
},_FakeOnPropertyChange:function(){
if(document.createEventObject){
if(event){
var ev=document.createEventObject(event);
}else{
var ev=document.createEventObject();
}
ev.propertyName="value";
this._textBoxElement.fireEvent("onpropertychange",ev);
}
},_UpdateAfterKeyHandled:function(e,_e7){
this._Visualise();
var _e8=new Telerik.Web.UI.MaskedEventWrap(e,this._textBoxElement);
_e8._selectionEnd=_e7;
this._FixSelection(_e8);
return false;
},_ValueHandler:function(e){
if(this._internalValueUpdate){
return true;
}
if(!e){
e=window.event;
}
this._calculateSelection();
var _ea=new Telerik.Web.UI.MaskedEventWrap(e,this._textBoxElement);
if(_ea.fieldValue!=this._projectedValue){
this._HandleValueChange(_ea);
}
return true;
},_ActivityHandler:function(e){
if(this._internalValueUpdate){
return true;
}
if(!e){
e=window.event;
}
this._OnActivity(e);
return true;
},_calculateSelection:function(){
if(document.selection&&Sys.Browser.agent!=Sys.Browser.Opera){
var s1;
try{
s1=document.selection.createRange();
}
catch(error){
return;
}
if(s1.parentElement()!=this._textBoxElement){
return;
}
var s=s1.duplicate();
if(this._isTextarea){
s.moveToElementText(this._textBoxElement);
}else{
s.move("character",-this._textBoxElement.value.length);
}
s.setEndPoint("EndToStart",s1);
this._textBoxElement.selectionStart=s.text.length;
this._textBoxElement.selectionEnd=this._textBoxElement.selectionStart+s1.text.length;
if(this._isTextarea){
}
}
},_StrCompare:function(_ee,_ef){
var i;
var _f1,_f2,_f3;
i=0;
while(_ee.charAt(i)==_ef.charAt(i)&&i<_ee.length){
i++;
}
_f2=i;
_ee=_ee.substr(_f2).split("").reverse().join("");
_ef=_ef.substr(_f2).split("").reverse().join("");
i=0;
while(_ee.charAt(i)==_ef.charAt(i)&&i<_ee.length){
i++;
}
_f1=_f2+_ef.length-i;
_f3=_ee.length-i+_f2;
return [_f1,_f2,_f3];
},get__initialMasks:function(){
return this._initialMasks;
},set__initialMasks:function(_f4){
this._initialMasks=_f4;
},get__initialDisplayMasks:function(){
return this._initialDisplayMasks;
},set__initialDisplayMasks:function(_f5){
this._initialDisplayMasks=_f5;
},raise_valueChanged:function(){
if(this._ValueHasChanged()){
this._triggerDOMChangeEvent(this._getValidationField());
this._OnValueChange(null,this._textBoxElement._oldValue,this._textBoxElement.value);
}
}};
Telerik.Web.UI.RadMaskedTextBox.registerClass("Telerik.Web.UI.RadMaskedTextBox",Telerik.Web.UI.RadInputControl);

