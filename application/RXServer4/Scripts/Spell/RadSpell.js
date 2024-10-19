Type.registerNamespace("Telerik.Web.UI");
function GetRadSpell(_1){
return $find(_1);
}
Telerik.Web.UI.RadSpell=function(_2){
Telerik.Web.UI.RadSpell.initializeBase(this,[_2]);
this._dictionaryLanguage=null;
this._languagesDropDown=null;
this._textSource=null;
this._controlToCheck=null;
this._controlsToCheck=null;
this._ajaxUrl=null;
this._clientTextSource=null;
};
Telerik.Web.UI.RadSpell.prototype={initialize:function(){
Telerik.Web.UI.RadSpell.callBaseMethod(this,"initialize");
this._languagesDropDown=$get(this.get_id()+"Language");
this._spellCheckButton=$get(this.get_id()+"SpellCheck");
if(this._spellCheckButton){
$addHandlers(this._spellCheckButton,{click:this.startSpellCheck},this);
if(this._spellCheckButton.tagName&&this._spellCheckButton.tagName.toLowerCase()!="input"){
$addHandlers(this._spellCheckButton,{keypress:this.startSpellCheck},this);
}
}
this.set_spellChecked(false);
this.add_clientCheckFinished(this.checkFinishedHandler);
this.add_clientCheckStarted(this.checkStartedHandler);
},dispose:function(){
this._controlToCheck=null;
this._controlsToCheck=null;
this._dialogOpener=null;
if(this._spellCheckButton){
$clearHandlers(this._spellCheckButton);
}
this.remove_clientCheckFinished(this.checkFinishedHandler);
this.remove_clientCheckStarted(this.checkStartedHandler);
Telerik.Web.UI.RadSpell.callBaseMethod(this,"dispose");
},checkFinishedHandler:function(_3,_4){
_3.set_spellChecked(true);
},checkStartedHandler:function(_5,_6){
_5.set_spellChecked(false);
},startSpellCheck:function(){
var _7=this.get_textSource();
if(_7!=null){
this.spellCheck(_7);
}else{
alert("Cannot find a TextSource. Please, set the ControlToCheck server-side property, or use the SetTextSource() client-side method.");
}
},spellCheck:function(_8){
var _9=new Sys.CancelEventArgs();
this.raiseEvent("clientCheckStarted",_9);
if(!_9.get_cancel()){
var _a={dictionaryLanguage:this.get_selectedLanguage(),textSource:_8,spell:this};
this.get_dialogOpener().open("SpellCheckDialog",_a);
}
},get_selectedLanguage:function(){
if(this.get_dictionaryLanguage()){
return this.get_dictionaryLanguage();
}
if(!this._languagesDropDown){
return null;
}
var _b=this._languagesDropDown.options[this._languagesDropDown.selectedIndex];
return _b!=null?_b.value:null;
},get_textSource:function(){
if(this._textSource==null){
if(null!=this.get_controlsToCheck()&&this.get_controlsToCheck().length>0){
var _c=[];
for(var i=0;i<this.get_controlsToCheck().length;i++){
_c[_c.length]=new Telerik.Web.UI.Spell.HtmlElementTextSource($get(this.get_controlsToCheck()[i]));
}
this.set_textSource($create(Telerik.Web.UI.Spell.MultipleHtmlElementsSource,{elements:_c},null,null));
}else{
if(this.get_controlToCheck()){
var _e=document.getElementById(this.get_controlToCheck());
this.set_textSource($create(Telerik.Web.UI.Spell.HtmlElementTextSource,{element:_e},null,null));
}else{
if(this.get_clientTextSource()){
this.set_textSource(eval(this.get_clientTextSource()));
}
}
}
}
return this._textSource;
},set_textSource:function(_f){
this._textSource=_f;
},get_spellChecked:function(){
return this._spellChecked;
},set_spellChecked:function(_10){
$get(this.get_id()+"SpellChecked").value=_10?"true":"";
this._spellChecked=_10;
},get_dialogOpener:function(){
return this._dialogOpener;
},set_dialogOpener:function(_11){
this._dialogOpener=_11;
},get_dictionaryLanguage:function(){
return this._dictionaryLanguage;
},set_dictionaryLanguage:function(_12){
this._dictionaryLanguage=_12;
},get_controlToCheck:function(){
return this._controlToCheck;
},set_controlToCheck:function(_13){
this._controlToCheck=_13;
},get_controlsToCheck:function(){
return this._controlsToCheck;
},set_controlsToCheck:function(_14){
this._controlsToCheck=_14;
},get_clientTextSource:function(){
return this._clientTextSource;
},set_clientTextSource:function(_15){
this._clientTextSource=_15;
},get_ajaxUrl:function(){
return this._ajaxUrl;
},set_ajaxUrl:function(_16){
this._ajaxUrl=_16;
},add_clientDialogClosing:function(_17){
this.get_events().addHandler("clientDialogClosing",_17);
},remove_clientDialogClosing:function(_18){
this.get_events().removeHandler("clientDialogClosing",_18);
},add_clientCheckCancelled:function(_19){
this.get_events().addHandler("clientCheckCancelled",_19);
},remove_clientCheckCancelled:function(_1a){
this.get_events().removeHandler("clientCheckCancelled",_1a);
},add_clientCheckFinished:function(_1b){
this.get_events().addHandler("clientCheckFinished",_1b);
},remove_clientCheckFinished:function(_1c){
this.get_events().removeHandler("clientCheckFinished",_1c);
},add_clientCheckStarted:function(_1d){
this.get_events().addHandler("clientCheckStarted",_1d);
},remove_clientCheckStarted:function(_1e){
this.get_events().removeHandler("clientCheckStarted",_1e);
}};
Telerik.Web.UI.RadSpell.registerClass("Telerik.Web.UI.RadSpell",Telerik.Web.UI.RadWebControl);
Type.registerNamespace("Telerik.Web.UI.Spell");
Telerik.Web.UI.Spell.HtmlElementTextSource=function(_1f){
Telerik.Web.UI.Spell.HtmlElementTextSource.initializeBase(this);
this._element=_1f;
};
Telerik.Web.UI.Spell.HtmlElementTextSource.prototype={initialize:function(){
Telerik.Web.UI.Spell.HtmlElementTextSource.callBaseMethod(this,"initialize");
var _20=this.get_element();
if(_20==null){
alert("Could not find target HTML element. Please verify that ControlToCheck points to a valid control.");
this.set_element({value:""});
}else{
if(_20.nodeName=="IFRAME"&&_20.contentWindow!=null){
this.set_element(_20.contentWindow.document.body);
}
}
_20=null;
},dispose:function(){
this._element=null;
Telerik.Web.UI.Spell.HtmlElementTextSource.callBaseMethod(this,"dispose");
},get_text:function(){
var _21="";
if(this.get_element().value!=null){
try{
_21=this.get_element().value;
}
catch(exc){
alert("Error getting text from control.\n"+exc.message);
}
}else{
if(this.get_element().innerHTML!=null){
try{
_21=this.get_element().innerHTML;
}
catch(exc){
alert("Error getting HTML from the control.\n"+exc.message);
}
}else{
alert("No value or innerHTML attribute. Cannot access text.");
}
}
return _21;
},set_text:function(_22){
if(this.get_element()==null){
return;
}
if(this.get_element().value!=null){
this.get_element().value=_22;
}else{
if(this.get_element().innerHTML!=null){
this.get_element().innerHTML=_22;
}else{
alert("No value or innerHTML attribute. Cannot access text.");
}
}
},get_element:function(){
return this._element;
},set_element:function(_23){
this._element=_23;
}};
Telerik.Web.UI.Spell.HtmlElementTextSource.registerClass("Telerik.Web.UI.Spell.HtmlElementTextSource",Sys.Component);
Telerik.Web.UI.Spell.MultipleHtmlElementsSource=function(_24){
Telerik.Web.UI.Spell.MultipleHtmlElementsSource.initializeBase(this);
this._elements=_24;
};
Telerik.Web.UI.Spell.MultipleHtmlElementsSource.prototype={initialize:function(){
Telerik.Web.UI.Spell.MultipleHtmlElementsSource.callBaseMethod(this,"initialize");
},dispose:function(){
this._elements=null;
Telerik.Web.UI.Spell.MultipleHtmlElementsSource.callBaseMethod(this,"dispose");
},get_text:function(){
var _25=[];
for(var i=0;i<this._elements.length;i++){
_25[_25.length]=this._elements[i].get_text();
}
return _25.join("<controlSeparator><br/></controlSeparator>");
},set_text:function(_27){
var _28=_27.split("<controlSeparator><br/></controlSeparator>");
for(var i=0;i<this._elements.length;i++){
this._elements[i].set_text(_28[i]);
}
},get_elements:function(){
return this._elements;
},set_elements:function(_2a){
this._elements=_2a;
}};
Telerik.Web.UI.Spell.MultipleHtmlElementsSource.registerClass("Telerik.Web.UI.Spell.MultipleHtmlElementsSource",Sys.Component);

