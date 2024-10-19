Type.registerNamespace("Telerik.Web.UI.Spell");
Telerik.Web.UI.Spell.SpellDialog=function(_1){
Telerik.Web.UI.Spell.SpellDialog.initializeBase(this,[_1]);
this._clientParameters=null;
this._spell=null;
this._modeChangedHandler=null;
this._suggestionsDblClickHandler=null;
this._localization={};
this._spellProcessor=null;
this._contentDisplay=null;
this._serviceConfiguration=null;
this._serviceUrl=null;
};
Telerik.Web.UI.Spell.SpellDialog.prototype={initialize:function(){
Telerik.Web.UI.Spell.SpellDialog.callBaseMethod(this,"initialize");
this._windowClosingDelegate=Function.createDelegate(this,this.prepareClose);
this.initChildControls();
},dispose:function(){
if(this._contentDisplay){
this._contentDisplay.remove_modeChanged(this._modeChangedHandler);
this._modeChangedHandler=null;
this._contentDisplay.remove_suggestionsDblClick(this._suggestionsDblClickHandler);
this._suggestionsDblClickHandler=null;
}
this._windowClosingDelegate=null;
Telerik.Web.UI.Spell.SpellDialog.callBaseMethod(this,"dispose");
},clientInit:function(_2){
this._suggestions.disabled=false;
this._suggestions.options.length=0;
this._suggestions.focus();
this._suggestions.disabled=true;
this.enableButton(this._cancel);
this.findChildElement("_TextContainer").innerHTML="";
this._clientParameters=_2;
this._spell=this._clientParameters.spell;
this._textSource=this._clientParameters.textSource;
if(!this._textSource||!this._textSource.get_text){
alert("This textsource does not support the get_text() method.");
return;
}
Sys.Application.add_unload(this._windowClosingDelegate);
this._textToCheck=this.escapeNewLines(this._textSource.get_text());
var _3=this;
if(this._clientParameters.dictionaryLanguage){
this.get_service().set_language(this._clientParameters.dictionaryLanguage);
}
this.get_service().spellCheck(this._textToCheck);
},initChildControls:function(){
this._suggestions=this.findChildElement("_Suggestions");
this._ignore=this.getConfiguredButton("_Ignore",this.ignoreHandler);
this._ignoreAll=this.getConfiguredButton("_IgnoreAll",this.ignoreAllHandler);
this._addCustom=this.getConfiguredButton("_AddCustom",this.addCustomHandler);
this._change=this.getConfiguredButton("_Change",this.changeHandler);
this._changeAll=this.getConfiguredButton("_ChangeAll",this.changeAllHandler);
this._undo=this.getConfiguredButton("_Undo",this.undoHandler);
this._cancel=this.getConfiguredButton("_Cancel",this.cancelHandler);
},ignoreHandler:function(){
if(this._contentDisplay.get_editMode()){
this._contentDisplay.switchMode();
}else{
this._spellProcessor.ignore();
this.raiseOnClientWordIgnoredEvent(false);
this.moveForward();
}
},ignoreAllHandler:function(){
if(this._ignoreAll.disabled){
return;
}
this._spellProcessor.ignoreAll();
this.raiseOnClientWordIgnoredEvent(true);
this.moveForward();
},addCustomHandler:function(){
if(this._addCustom.disabled){
return;
}
var _4=this._spellProcessor.currentBadWord().wordString;
if(!confirm(this.get_localization()["AddWord1"]+_4+this.get_localization()["AddWord2"])){
return;
}
this.disableAllButtons();
var _5=this;
this.get_service().addCustomWord(_4);
},changeHandler:function(){
if(this._change.disabled){
return;
}
this.changeCurrentWord(this._contentDisplay.replacementWord());
},changeAllHandler:function(){
if(this._changeAll.disabled){
return;
}
if(this._spellProcessor.allWordsFixed()){
return;
}
this._spellProcessor.changeAll(this._contentDisplay.replacementWord());
this.raiseOnClientWordCorrectedEvent(true);
this.moveForward();
},undoHandler:function(){
if(this._undo.disabled){
return;
}
var _6=this._spellProcessor.lastActionBadWordStartCharOffsets();
this._spellProcessor.undo();
this.raiseOnClientActionUndoneEvent(_6);
this.processCurrentStep();
},cancelHandler:function(){
if(this._cancel.disabled){
return;
}
this.closeDialog(this._spellProcessor&&this._spellProcessor.textChanged()&&confirm(this.get_localization()["Confirm"]));
},disableButton:function(_7){
_7.disabled=true;
_7.className="buttonDisabled";
},enableButton:function(_8){
_8.disabled=false;
_8.className="button";
},setButtonEnabled:function(_9,_a){
if(_a){
this.enableButton(_9);
}else{
this.disableButton(_9);
}
},getConfiguredButton:function(_b,_c){
var _d=this.findChildElement(_b);
if(_d){
$addHandlers(_d,{click:_c},this);
_d.disabled=true;
}
return _d;
},findChildElement:function(_e){
return $get(this.get_id()+_e);
},get_service:function(){
if(this._service==null){
this._service=$create(Telerik.Web.UI.SpellCheckService,null,null,null);
this._service.set_configuration(this.get_serviceConfiguration());
this._service.set_url(this.get_serviceUrl());
this._service.add_complete(Function.createDelegate(this,this.spellCheckResponseReceived));
}
return this._service;
},changeCurrentWord:function(_f){
if(this._spellProcessor.allWordsFixed()){
return;
}
this._spellProcessor.change(_f);
this.raiseOnClientWordCorrectedEvent(false);
this.moveForward();
},moveForward:function(){
this._spellProcessor.moveToNextWord();
this.processCurrentStep();
},processCurrentStep:function(){
if(!this._spellProcessor.allWordsFixed()){
this.updateContent();
}else{
this.closeDialog(true);
}
},prepareClose:function(_10){
Sys.Application.remove_unload(this._windowClosingDelegate);
this.disableAllButtons();
this.raiseDialogClosingEvents();
if(this._spellProcessor){
if(this._spellProcessor.allWordsFixed()){
this._spell.set_spellChecked(true);
}
if(_10){
this.applyChanges();
}
this._spellProcessor=null;
}
},closeDialog:function(_11){
this.prepareClose(_11);
this._spell.raiseEvent("clientDialogClosing",Sys.EventArgs.Empty);
Telerik.Web.UI.Dialogs.CommonDialogScript.get_windowReference().close();
},spellCheckResponseReceived:function(_12,_13){
if(_13.AddCustomWord){
var _14=this._spellProcessor.currentBadWord().wordString;
this._spellProcessor.processCustomWordAddition();
this.raiseOnClientCustomWordAddedEvent(_14);
this.processCurrentStep();
this.enableButton(this._cancel);
}else{
var _15={textToCheck:this._textToCheck,badWords:_13.badWords,wordOffsets:_13.wordOffsets};
this._spellProcessor=$create(Telerik.Web.UI.Spell.SpellProcessor,_15,null,null);
if(!this._spellProcessor.allWordsFixed()){
this.initContentDisplay();
this.updateContent();
}else{
this.closeDialog(true);
}
}
},escapeNewLines:function(_16){
var _17=_16.replace(/\n/gi,"&nbsp;<telerikcr />");
_17=_17.replace(/\r/gi,"<teleriklf />");
return _17;
},unEscapeNewLines:function(_18){
var _19=_18.replace(/(&nbsp;)?<telerikcr\s*\/>/gi,"\n");
var _19=_19.replace(/<teleriklf\s*\/>/gi,"\r");
return _19;
},updateContent:function(){
if(this._contentDisplay.get_editMode()){
this._contentDisplay.switchMode();
}
this._contentDisplay.showText(this._spellProcessor.currentErrorContent());
this.focusCurrentError();
this._contentDisplay.fillSuggestions(this._spellProcessor.currentSuggestions());
this.updateButtonStates();
},focusCurrentError:function(){
var _1a=document.getElementById(this._spellProcessor.highlightedElementId());
if(_1a&&!this._contentDisplay.get_editMode()){
this._contentDisplay.get_textContainer().scrollTop=_1a.offsetTop;
_1a.focus();
}
},disableAllButtons:function(){
this.disableButton(this._ignore);
this.disableButton(this._ignoreAll);
this.disableButton(this._change);
this.disableButton(this._changeAll);
this.disableButton(this._undo);
this.disableButton(this._cancel);
if(this._addCustom){
this.disableButton(this._addCustom);
}
},initContentDisplay:function(){
this._modeChangedHandler=Function.createDelegate(this,this.contentDisplay_modeChanged);
this._suggestionsDblClickHandler=Function.createDelegate(this,this.contentDisplay_suggestionsDblClick);
var _1b={localization:this.get_localization(),textContainer:this.findChildElement("_TextContainer"),textEditor:this.findChildElement("_TextEditor"),suggestions:this._suggestions};
var _1c={modeChanged:this._modeChangedHandler,suggestionsDblClick:this._suggestionsDblClickHandler};
if(!this._contentDisplay){
this._contentDisplay=$create(Telerik.Web.UI.Spell.ContentDisplay,_1b,_1c,null);
}
this._contentDisplay.focus();
},updateButtonStates:function(){
var _1d=this._spellProcessor.currentSuggestions().length>0;
this.enableButton(this._ignore);
this.setButtonEnabled(this._ignoreAll,!this._contentDisplay.get_editMode());
this.setButtonEnabled(this._undo,this._spellProcessor.currentUndoAction()!=null);
this.setButtonEnabled(this._change,this._contentDisplay.get_editMode()||_1d);
this.setButtonEnabled(this._changeAll,!this._contentDisplay.get_editMode()&&_1d);
if(this._addCustom!=null){
this.setButtonEnabled(this._addCustom,!this._contentDisplay.get_editMode());
}
this._ignore.innerHTML=this._contentDisplay.get_editMode()?this.get_localization()["UndoEdit"]:this.get_localization()["Ignore"];
},contentDisplay_modeChanged:function(_1e,_1f){
var _20="";
if(_1f.editMode){
_20=this._spellProcessor.currentBadWord().wordString;
}else{
_20=this._spellProcessor.currentErrorContent();
}
this.updateButtonStates();
this._contentDisplay.showText(_20);
this.focusCurrentError();
},contentDisplay_suggestionsDblClick:function(_21,_22){
if(this._spellProcessor.currentSuggestions().length>0){
this.changeCurrentWord(_22.selectedValue);
}else{
alert(this.get_localization()["Nosuggestions"]);
}
},applyChanges:function(){
this._textSource.set_text(this.unEscapeNewLines(this._spellProcessor._textToCheck));
},raiseDialogClosingEvents:function(){
if(this._spellProcessor&&this._spellProcessor.allWordsFixed()){
var _23={suppressCompleteMessage:false};
this._spell.raiseEvent("clientCheckFinished",_23);
if(!_23.suppressCompleteMessage){
alert(this.get_localization()["SpellCheckComplete"]);
}
}else{
this._spell.raiseEvent("clientCheckCancelled",Sys.EventArgs.Empty);
}
},raiseOnClientWordCorrectedEvent:function(_24){
var _25=this._spellProcessor.currentBadWord();
var _26={originalWord:_25.originalWordString,newWord:_25.wordString,offsets:this._spellProcessor.lastActionBadWordStartCharOffsets(),changeAll:_24};
this._spell.raiseEvent("clientWordCorrected",_26);
},raiseOnClientWordIgnoredEvent:function(_27){
var _28=this._spellProcessor.currentBadWord();
var _29={ignoreWord:_28.originalWordString,offsets:this._spellProcessor.lastActionBadWordStartCharOffsets(),ignoreAll:_27};
this._spell.raiseEvent("clientWordIgnored",_29);
},raiseOnClientActionUndoneEvent:function(_2a){
var _2b=this._spellProcessor.currentBadWord();
var _2c={originalWord:_2b.originalWordString,offsets:_2a};
this._spell.raiseEvent("clientActionUndone",_2c);
},raiseOnClientCustomWordAddedEvent:function(_2d){
var _2e={customWord:_2d};
this._spell.raiseEvent("clientCustomWordAdded",_2e);
},get_language:function(){
return this._language;
},set_language:function(_2f){
this._language=_2f;
},get_localization:function(){
return this._localization;
},set_localization:function(_30){
this._localization=_30;
},get_serviceUrl:function(){
return this._serviceUrl;
},set_serviceUrl:function(_31){
this._serviceUrl=_31;
},get_serviceConfiguration:function(){
return this._serviceConfiguration;
},set_serviceConfiguration:function(_32){
this._serviceConfiguration=_32;
}};
Telerik.Web.UI.Spell.SpellDialog.registerClass("Telerik.Web.UI.Spell.SpellDialog",Telerik.Web.UI.RadWebControl,Telerik.Web.IParameterConsumer);
Telerik.Web.UI.Spell.SpellProcessorActions=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.Spell.SpellProcessorActions.prototype={Change:0,ChangeAll:1,Ignore:2,IgnoreAll:4,AddCustom:8};
Telerik.Web.UI.Spell.SpellProcessorActions.registerEnum("Telerik.Web.UI.Spell.SpellProcessorActions",false);
Telerik.Web.UI.Spell.SpellProcessor=function(){
Telerik.Web.UI.Spell.SpellProcessor.initializeBase(this);
this._textToCheck=null;
this._badWords=null;
this._wordOffsets=null;
this._currentBadWordIndex=0;
this._undoActions=[];
this._surroundingWordsCount=10;
};
Telerik.Web.UI.Spell.SpellProcessor.prototype={initialize:function(){
Telerik.Web.UI.Spell.SpellProcessor.callBaseMethod(this,"initialize");
},dispose:function(){
Telerik.Web.UI.Spell.SpellProcessor.callBaseMethod(this,"dispose");
},moveToNextWord:function(){
var _33=this.nextBadWordIndex();
if(_33<0){
return;
}
this.set_currentBadWordIndex(_33);
},moveToPreviousWord:function(){
this.set_currentBadWordIndex(this.nextBadWordIndex(0));
},nextBadWordIndex:function(_34){
if(typeof (_34)=="undefined"){
_34=this.get_currentBadWordIndex();
}
for(var i=_34;i<this._badWords.length;i++){
if(this.getBadWord(i).originalWordString==null){
return i;
}
}
return -1;
},allWordsFixed:function(){
return this.nextBadWordIndex()<0;
},currentErrorContent:function(){
var _36=this.currentBadWord();
return this.startString(this.get_currentBadWordIndex(),true)+"<a style='border-bottom: 1px dotted red;font-weight: bold;' id="+this.highlightedElementId()+">"+_36.wordString+"</a>"+this.endString(this.get_currentBadWordIndex(),true);
},highlightedElementId:function(){
return "spell_highlight_"+this.currentBadWord().wordString;
},startString:function(_37,_38){
var _39=0;
var _3a=this.getBadWord(_37);
if(_38&&(_3a.textOffset>this._surroundingWordsCount)){
var _3b=_3a.textOffset-this._surroundingWordsCount;
_39=this._wordOffsets[_3b];
}
return this._textToCheck.substring(_39,this.wordStartCharIndex(_37));
},endString:function(_3c,_3d){
var _3e=this._textToCheck.length;
var _3f=this.getBadWord(_3c);
if(_3d&&(this._wordOffsets.length>_3f.textOffset+this._surroundingWordsCount)){
var _40=_3f.textOffset+this._surroundingWordsCount;
_3e=this._wordOffsets[_40];
}
return this._textToCheck.substring(this.wordEndCharIndex(_3c),_3e);
},wordStartCharIndex:function(_41){
return this._wordOffsets[this.wordOffset(_41)];
},wordEndCharIndex:function(_42){
return this.wordStartCharIndex(_42)+this.getBadWord(_42).wordString.length;
},getBadWord:function(_43){
return this._badWords[_43];
},currentBadWord:function(){
return this.getBadWord(this.get_currentBadWordIndex());
},wordOffset:function(_44){
return this.getBadWord(_44).textOffset;
},currentWordOffset:function(){
return this.currentBadWord().textOffset;
},currentSuggestions:function(){
return this.currentBadWord().suggestionsString;
},ignore:function(){
this.changeWord(this.currentBadWord().wordString,Telerik.Web.UI.Spell.SpellProcessorActions.Ignore);
},ignoreAll:function(){
this.changeAllWords(this.currentBadWord().wordString,Telerik.Web.UI.Spell.SpellProcessorActions.IgnoreAll);
},change:function(_45){
this.changeWord(_45,Telerik.Web.UI.Spell.SpellProcessorActions.Change);
},changeAll:function(_46){
this.changeAllWords(_46,Telerik.Web.UI.Spell.SpellProcessorActions.ChangeAll);
},processCustomWordAddition:function(){
var _47=this.sameWordStringBadWordIndexes();
for(var i=_47.length-1;i>=0;i--){
var _49=_47[i];
this._badWords.splice(_49,1);
}
this.moveToNextWord();
},changeWord:function(_4a,_4b){
var _4c=[this.get_currentBadWordIndex()];
this.processChange(_4c,_4a,false,_4b);
this.registerUndoStep(_4c);
},changeAllWords:function(_4d,_4e){
var _4f=this.sameWordStringBadWordIndexes();
this.processChange(_4f,_4d,false,_4e);
this.registerUndoStep(_4f);
},changeText:function(_50,_51){
this._textToCheck=this.startString(_50,false)+_51+this.endString(_50,false);
},offsetsByBadWordIndexes:function(_52){
var _53=[];
for(var i=0;i<_52.length;i++){
_53[_53.length]=this.wordOffset(_52[i]);
}
return _53;
},lastActionBadWordOffsets:function(){
var _55=this.currentUndoAction();
return this.offsetsByBadWordIndexes(_55);
},lastActionBadWordStartCharOffsets:function(){
var _56=[];
var _57=this.lastActionBadWordOffsets();
for(var i=0;i<_57.length;i++){
_56[_56.length]=this._wordOffsets[_57[i]];
}
return _56;
},sameWordStringBadWordIndexes:function(){
var _59=this.currentBadWord().wordString;
var _5a=[this.get_currentBadWordIndex()];
for(var _5b=this.get_currentBadWordIndex()+1;_5b<this._badWords.length;_5b++){
if(this.getBadWord(_5b).wordString==_59){
_5a[_5a.length]=_5b;
}
}
return _5a;
},undo:function(){
var _5c=this.currentUndoAction();
var _5d=this.getBadWord(_5c[0]).originalWordString;
this.processChange(_5c,_5d,true);
this.unregisterUndoStep();
this.moveToPreviousWord();
},correctWord:function(_5e,_5f,_60){
if(this.getBadWord(_5e).originalWordString){
return;
}
var _61=this.getBadWord(_5e);
_61.originalWordString=_61.wordString;
_61.wordString=_5f;
_61.correctionAction=_60;
},restoreWord:function(_62){
var _63=this.getBadWord(_62);
_63.wordString=_63.originalWordString;
_63.originalWordString=null;
_63.correctionAction=null;
},processChange:function(_64,_65,_66,_67){
for(var i=0;i<_64.length;i++){
var _69=_64[i];
var _6a=this.getBadWord(_69);
var _6b=_65.length-_6a.wordString.length;
this.adjustOffsetsAfterChangedWord(_6a,_6b);
this.changeText(_69,_65);
if(_66){
this.restoreWord(_69);
}else{
this.correctWord(_69,_65,_67);
}
}
},adjustOffsetsAfterChangedWord:function(_6c,_6d){
for(var _6e=_6c.textOffset+1;_6e<this._wordOffsets.length;_6e++){
this._wordOffsets[_6e]+=_6d;
}
},currentUndoAction:function(){
if(this._undoActions.length==0){
return null;
}
return this._undoActions[this._undoActions.length-1];
},registerUndoStep:function(_6f){
this._undoActions[this._undoActions.length]=_6f;
},unregisterUndoStep:function(){
this._undoActions=this._undoActions.slice(0,-1);
},textChanged:function(){
for(var i=0;i<this.get_currentBadWordIndex();i++){
var _71=this.getBadWord(i).correctionAction;
if(_71==Telerik.Web.UI.Spell.SpellProcessorActions.Change||_71==Telerik.Web.UI.Spell.SpellProcessorActions.ChangeAll){
return true;
}
}
return false;
},get_currentBadWordIndex:function(){
return this._currentBadWordIndex;
},set_currentBadWordIndex:function(_72){
this._currentBadWordIndex=_72;
},get_textToCheck:function(){
return this._textToCheck;
},set_textToCheck:function(_73){
this._textToCheck=_73;
},get_badWords:function(){
return this._badWords;
},set_badWords:function(_74){
this._badWords=_74;
},get_wordOffsets:function(){
return this._wordOffsets;
},set_wordOffsets:function(_75){
this._wordOffsets=_75;
}};
Telerik.Web.UI.Spell.SpellProcessor.registerClass("Telerik.Web.UI.Spell.SpellProcessor",Sys.Component);
Telerik.Web.UI.Spell.ContentDisplay=function(){
Telerik.Web.UI.Spell.ContentDisplay.initializeBase(this);
this._editMode=false;
this._textContainer=null;
this._textEditor=null;
this._suggestions=null;
this._localization=null;
};
Telerik.Web.UI.Spell.ContentDisplay.prototype={initialize:function(){
Telerik.Web.UI.Spell.ContentDisplay.callBaseMethod(this,"initialize");
$addHandlers(this.get_textContainer(),{click:this.switchMode},this);
this.get_suggestions().disabled=false;
$addHandlers(this.get_suggestions(),{dblclick:this.suggestionsDblClick},this);
},dispose:function(){
$clearHandlers(this.get_suggestions());
$clearHandlers(this.get_textContainer());
this._textContainer=null;
this._textEditor=null;
this._suggestions=null;
this._localization=null;
Telerik.Web.UI.Spell.ContentDisplay.callBaseMethod(this,"dispose");
},showText:function(_76){
if(this.get_editMode()){
this.get_textEditor().value=_76;
}else{
this.get_textContainer().innerHTML=_76;
}
},focus:function(){
if(this.get_editMode()){
this.get_textEditor().focus();
}else{
if(this.get_suggestions().disabled){
this.get_suggestions().disabled=false;
}
this.get_suggestions().focus();
}
},switchMode:function(){
this.set_editMode(!this.get_editMode());
if(this.get_editMode()){
this.get_textContainer().style.display="none";
this.get_textEditor().style.display="block";
this.get_textEditor().focus();
this.get_suggestions().disabled=true;
}else{
this.get_textContainer().style.display="";
this.get_textEditor().style.display="none";
this.get_suggestions().disabled=false;
}
this.raiseEvent("modeChanged",{editMode:this.get_editMode()});
this.focus();
},replacementWord:function(){
if(this.get_editMode()){
return this.get_textEditor().value;
}else{
return this.selectedSuggestion();
}
},selectedSuggestion:function(){
return this.get_suggestions().options[this.get_suggestions().selectedIndex].value;
},fillSuggestions:function(_77){
this.clearSuggestions();
if(_77.length>0){
for(var i=0;i<_77.length;i++){
this.addSuggestion(_77[i]);
}
}else{
this.addSuggestion(this.get_localization()["Nosuggestions"]);
}
this.get_suggestions().selectedIndex=0;
},clearSuggestions:function(){
this.get_suggestions().options.length=0;
},addSuggestion:function(_79){
this.get_suggestions().options[this.get_suggestions().options.length]=new Option(_79,_79);
},suggestionsDblClick:function(){
this.raiseEvent("suggestionsDblClick",{selectedValue:this.selectedSuggestion()});
},raiseEvent:function(_7a,_7b){
var _7c=this.get_events().getHandler(_7a);
if(_7c){
if(!_7b){
_7b=Sys.EventArgs.Empty;
}
_7c(this,_7b);
}
},add_modeChanged:function(_7d){
this.get_events().addHandler("modeChanged",_7d);
},remove_modeChanged:function(_7e){
this.get_events().removeHandler("modeChanged",_7e);
},add_suggestionsDblClick:function(_7f){
this.get_events().addHandler("suggestionsDblClick",_7f);
},remove_suggestionsDblClick:function(_80){
this.get_events().removeHandler("suggestionsDblClick",_80);
},set_localization:function(_81){
this._localization=_81;
},get_localization:function(){
return this._localization;
},set_suggestions:function(_82){
this._suggestions=_82;
},get_suggestions:function(){
return this._suggestions;
},set_textContainer:function(_83){
this._textContainer=_83;
},get_textContainer:function(){
return this._textContainer;
},set_editMode:function(_84){
this._editMode=_84;
},get_editMode:function(){
return this._editMode;
},set_textEditor:function(_85){
this._textEditor=_85;
},get_textEditor:function(){
return this._textEditor;
}};
Telerik.Web.UI.Spell.ContentDisplay.registerClass("Telerik.Web.UI.Spell.ContentDisplay",Sys.Component);

