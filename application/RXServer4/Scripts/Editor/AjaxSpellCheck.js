Type.registerNamespace("Telerik.Web.UI.Editor");
Telerik.Web.UI.Editor.AjaxSpellCheck=function(_1){
Telerik.Web.UI.Editor.AjaxSpellCheck.initializeBase(this,[_1]);
this._language="";
this._editor=null;
this._originalHtml=null;
this._protectedData=[];
this._ignoreTags=new RegExp("(<!--)([\\s\\S]*?)(-->)","gi");
};
Telerik.Web.UI.Editor.AjaxSpellCheck.prototype={initialize:function(){
var _2=this.get_editor();
this._finalCheckMessage=_2.getLocalizedString("SpellCheckEnd","Finish spellchecking");
this._completeMessage=_2.getLocalizedString("SpellCheckComplete","Spellchecking complete!");
this._cancelMessage=_2.getLocalizedString("CancelButton","Cancel");
this._addWordSuccessMessage=_2.getLocalizedString("AddCustomWordSuccess");
this._spellingInProgressMessage=_2.getLocalizedString("SpellingInProgress");
this._spellingModeMessage=_2.getLocalizedString("SpellingMode");
this._noSpellingMistakesMessage=_2.getLocalizedString("NoSpellingMistakes","No mistakes found.");
this._loadingIconCss="rade_loading";
this._createUI();
},get_editor:function(){
return this._editor;
},set_editor:function(_3){
this._editor=_3;
},get_language:function(){
return this._language;
},set_language:function(_4){
this._language=_4;
},getSpellService:function(){
var _5=this.get_editor().get_spellCheckService();
var _6=this.get_language();
if(_6){
_5.set_language(_6);
}
return _5;
},dispose:function(){
if(this._cancelButton){
this._cancelButton.Parent=null;
this._cancelButton.onclick=null;
}
this._cancelButton=null;
if(this._finishButton){
this._finishButton.Parent=null;
this._finishButton.onclick=null;
}
this._finishButton=null;
if(this._spellEngine){
this._spellEngine.dispose();
}
this._editor=null;
this._topElement=null;
this._protectedData=null;
},raiseEvent:function(_7,_8){
var _9=this.get_events().getHandler(_7);
if(_9){
if(!_8){
_8=Sys.EventArgs.Empty;
}
_9(this,_8);
}
},add_spellCheckStart:function(_a){
this.get_events().addHandler("spellCheckStart",_a);
},remove_spellCheckStart:function(_b){
this.get_events().removeHandler("spellCheckStart",_b);
},add_spellCheckEnd:function(_c){
this.get_events().addHandler("spellCheckEnd",_c);
},remove_spellCheckEnd:function(_d){
this.get_events().removeHandler("spellCheckEnd",_d);
},spellCheck:function(){
if(!this._spellEngine){
this._spellEngine=new Telerik.Web.UI.Editor.SpellEngineUI(this.get_editor(),this);
this._spellEngine.onSpellCheckComplete=Function.createDelegate(this,function(){
this.finishSpellCheck();
alert(this._completeMessage);
});
this._spellEngine.onAddCustomWord=Function.createDelegate(this,function(_e){
this.addCustomWord(_e);
});
}
if(this._spellEngine._spellcheckComplete){
this.finishSpellCheck(false);
}
this._setVisible(true);
this._setLoadingIconVisible(true);
this._enableButtons(false);
this._originalHtml=this.get_editor().get_contentArea().innerHTML;
var _f=this.getSpellService();
var _10=Function.createDelegate(this,function(_11,_12){
_f.remove_complete(_10);
this.beginSpellCheck(_12);
});
_f.add_complete(_10);
this._saveSpecialContent();
_f.spellCheck(this._spellEngine._escapeNewLines(this._originalHtml));
},beginSpellCheck:function(_13){
this._setLoadingIconVisible(false);
this._enableButtons(true);
this.raiseEvent("spellCheckStart");
if(_13.badWords.length==0){
alert(this._noSpellingMistakesMessage);
this.finishSpellCheck();
}else{
this._spellEngine.initialize(_13,this._originalHtml);
}
},finishSpellCheck:function(_14){
this._setVisible(false);
this._spellEngine.finalize();
this.restoreSavedContent();
this._originalHtml=null;
if(false!=_14){
this.raiseEvent("spellCheckEnd");
}
},cancelSpellCheck:function(){
this._setVisible(false);
this._spellEngine.finalize(false);
if(null!=this._originalHtml){
Telerik.Web.UI.Editor.Utils.setElementInnerHtml(this.get_editor().get_contentArea(),this._originalHtml);
this._originalHtml=null;
}
this.restoreSavedContent();
var _15=this.get_editor().get_commandsManager();
var _16=_15.get_commands();
_15.removeCommandAt(_16.length-1);
this.raiseEvent("spellCheckEnd");
this.get_editor().raiseEvent("selectionChange",Sys.EventArgs.Empty);
},_saveSpecialContent:function(){
this._protectedData=[];
var _17=Function.createDelegate(this,function(_18,_19,_1a,_1b,_1c,_1d){
Array.add(this._protectedData,_19+_1a+_1b);
return "<RADEDITORFORMATTED_"+this._protectedData.length+"/>";
});
this._originalHtml=this._originalHtml.replace(this._ignoreTags,_17);
},restoreSavedContent:function(){
if(this._protectedData&&this._protectedData.length>0){
var _1e=this.get_editor().get_contentArea().innerHTML;
for(var i=0;i<this._protectedData.length;i++){
var _20=new RegExp("<RADEDITORFORMATTED_"+(i+1)+"\\s*\\/>");
_1e=_1e.replace(_20,this._protectedData[i]);
}
Telerik.Web.UI.Editor.Utils.setElementInnerHtml(this.get_editor().get_contentArea(),_1e);
}
},addCustomWord:function(_21){
var _22=this.getSpellService();
var _23=this;
var _24=this._addWordSuccessMessage;
var _25=function(_26,_27){
alert(_21+" "+_24);
_23._spellEngine.clearWrongWords(_21,_21);
_22.remove_complete(_25);
};
_22.add_complete(_25);
_22.addCustomWord(_21);
},_createUI:function(){
var _28=document;
var _29=_28.createElement("table");
_29.cellSpacing=2;
_29.cellPadding=0;
_29.className="rade_ajaxspell_wrapper";
_29.style.width="100%";
_29.style.backgroundColor="#ffffcc";
_29.style.clear="both";
_29.style.borderBottom="1px solid #adadad";
_29.insertRow(-1);
var _2a=_29.rows[0].insertCell(-1);
_2a.style.width="100%";
var _2b=_28.createElement("button");
_2b.className="RadEXhtmlButton";
_2a=_29.rows[0].insertCell(-1);
this._finishButton=_2b.cloneNode(true);
this._finishButton.Parent=this;
this._finishButton.innerHTML=this._finalCheckMessage;
this._finishButton.onclick=new Function("this.Parent.finishSpellCheck();return false;");
_2a.appendChild(this._finishButton);
_2a=_29.rows[0].insertCell(-1);
this._cancelButton=_2b.cloneNode(true);
this._cancelButton.Parent=this;
this._cancelButton.innerHTML=this._cancelMessage;
this._cancelButton.onclick=new Function("this.Parent.cancelSpellCheck();return false;");
_2a.appendChild(this._cancelButton);
this._topElement=_29;
this.get_element().appendChild(this._topElement);
},_setVisible:function(_2c){
this._topElement.style.display=_2c?"":"none";
},_enableButtons:function(_2d){
var _2e=this._topElement.getElementsByTagName("button");
for(var i=0;i<_2e.length;i++){
_2e[i].disabled=!_2d;
}
},_setLoadingIconVisible:function(_30){
var _31=this._topElement.rows[0].cells[0];
_31.innerHTML="";
if(_30){
var _32=document.createElement("SPAN");
_32.className=this._loadingIconCss;
_31.appendChild(_32);
_31.innerHTML+="<label>"+this._spellingInProgressMessage+"</label>";
}else{
_31.innerHTML="<label>"+this._spellingModeMessage+"</label>";
}
}};
Telerik.Web.UI.Editor.AjaxSpellCheck.registerClass("Telerik.Web.UI.Editor.AjaxSpellCheck",Sys.UI.Control);
Telerik.Web.UI.Editor.SpellEngineUI=function(_33,_34){
this._editor=_33;
this._parentControl=_34;
this._suggestionDropdown=null;
this._suggestionBox=null;
this._wrongWordCounter=0;
this._wrongWordsArray=null;
this._spanId="RadESpellError_";
this._selectedEditorElement=null;
this._spellcheckComplete=true;
this._automaticAdvance=true;
this._localizedCommandName=this._editor.getLocalizedString("spellCheck","Check spelling");
this._localizedName=this._editor.getLocalizedString("SpellingChange","Spelling Change");
this._noSuggestionsString=this._editor.getLocalizedString("NoSuggestions","(no suggestions)");
this._changeWordString=this._editor.getLocalizedString("ChangeWordString","Change");
this._ignoreAllString=this._editor.getLocalizedString("IgnoreAllString","Ignore All");
this._ignoreString=this._editor.getLocalizedString("IgnoreString","Ignore");
this._moreThanOnceMessage=this._editor.getLocalizedString("MoreThanOnceMessage","This word occurs more than once in the text. Would you like to replace all instances?");
this._undoDisabledMessage=this._editor.getLocalizedString("UndoDisabledMessage","You cannot undo further while in spellcheck mode. Please finish spellchecking first.");
this._addToDictionaryString=this._editor.getLocalizedString("AddToDictionary","Add to dictionary");
this._addIconCss="rade_ajaxspell_addicon";
this._okIconCss="rade_ajaxspell_okicon";
this._ignoreIconCss="rade_ajaxspell_ignoreicon";
};
Telerik.Web.UI.Editor.SpellEngineUI.prototype={onAddCustomWord:function(_35){
},onSpellCheckComplete:function(){
},dispose:function(){
this._editor=null;
this.onSpellCheckComplete=null;
},_configureUndo:function(_36){
if(_36){
this._editor.enableEditing(true);
var _37=this._editor.get_commandsManager();
var _38=_37.get_commands();
var i=this._currentUndoIndex;
while(i<_38.length){
_37.removeCommandAt(_38.length-1);
}
this._editor.executeCommand(this.SaveStateCmd);
if(this._onCommandExecutingDelegate){
this._editor.remove_commandExecuting(this._onCommandExecutingDelegate);
}
this._onCommandExecutingDelegate=null;
}else{
var _3a=this._editor.get_commandsManager();
this._currentUndoIndex=_3a.getCommandsToUndo().length;
this._onCommandExecutingDelegate=Function.createDelegate(this,function(_3b,_3c){
var _3d=_3c.get_commandName();
if(_3d=="Undo"&&this._currentUndoIndex>=_3a.getCommandsToUndo().length){
alert(this._undoDisabledMessage);
_3c.set_cancel(true);
}
});
this._editor.add_commandExecuting(this._onCommandExecutingDelegate);
this._editor.enableEditing(false,Telerik.Web.UI.EditingOptions.All,{"Undo":true,"Redo":true,"AjaxSpellCheck":true});
}
},finalize:function(_3e){
if(true!=this._initialized){
return;
}
if(false!=_3e){
this.clearWrongWords();
}
if(this._parentControl){
this._parentControl.restoreSavedContent();
this._parentControl=null;
}
var _3f=this._editor;
if(this.OnMouseHandler){
_3f.detachEventHandler("click",this.OnMouseHandler);
}
if(this.OnKeyDownHandler){
_3f.detachEventHandler("keydown",this.OnKeyDownHandler);
}
if(this.OnContextMenu){
_3f.detachEventHandler("contextmenu",this.OnContextMenu);
}
if(this.OnEditorSubmit){
_3f.remove_submit(this.OnEditorSubmit);
}
this._configureUndo(true);
_3f.setFocus();
_3f.raiseEvent("selectionChange",Sys.EventArgs.Empty);
this._wrongWordsArray=null;
this._spellcheckComplete=true;
this._initialized=false;
},initialize:function(_40,_41){
this._initialized=true;
this._wrongWordsArray=_40.badWords;
this._wordOffsets=_40.wordOffsets;
var _42=this._editor;
this.SaveStateCmd=new Telerik.Web.UI.Editor.GenericCommand(this._localizedCommandName,_42.get_contentWindow());
this.markWrongWords(_41);
this._spellcheckComplete=false;
this._wrongWordCounter=0;
var _43=this;
this.OnEditorSubmit=function(){
_43.finalize();
};
this._editor.add_submit(this.OnEditorSubmit);
this.OnMouseHandler=function(e){
_43._showSuggestionDropdown();
return $telerik.cancelRawEvent(e);
};
this.OnKeyDownHandler=function(e){
if(e.keyCode==9){
_43.moveToNextWrongWord();
return $telerik.cancelRawEvent(e);
}
var _46=false;
if(_43._suggestionDropdown){
var _47=_43._suggestionDropdown;
var _48=(_47.isExpanded());
var _49=e.keyCode;
if(_48){
if(38==_49){
_47.selectPreviousItem();
_46=true;
}else{
if(40==_49){
_47.selectNextItem();
_46=true;
}else{
if(13==_49){
_47.hide();
if(_47.get_activeIndex){
_47.set_selectedIndex(_47.get_activeIndex());
}
_43._onDropDownValueSelected(_47);
try{
e.keyCode=123;
}
catch(e){
}
_46=true;
}else{
if(27==_49){
_47.hide();
}
}
}
}
_46=true;
}
}
if(_46){
return $telerik.cancelRawEvent(e);
}
};
this.OnContextMenu=function(e){
if(this._editor.isIE){
_43.OnMouseHandler(e);
}
e.cancelBubble=true;
if(this._editor.isIE){
return false;
}
};
window.setTimeout(function(){
var ed=_43._editor;
ed.attachEventHandler("click",_43.OnMouseHandler);
ed.attachEventHandler("keydown",_43.OnKeyDownHandler);
ed.attachEventHandler("contextmenu",Function.createDelegate(_43,_43.OnContextMenu));
if(_43._automaticAdvance){
ed.setFocus();
if(ed.isIE){
try{
var _4c=ed.getSelection().getRange();
if(_4c){
_4c.moveToElementText(ed.get_contentArea());
_4c.collapse();
_4c.select();
}
}
catch(e){
}
}
_43.moveToNextWrongWord();
}
},50);
this._configureUndo(false);
},moveToNextWrongWord:function(){
var dir=-1;
var _4e=this._editor.getSelection();
var _4f=_4e.getParentElement();
var _50=null;
if(this.isHighlightedWord(_4f)&&!this._editor.getSelectionHtml()){
_50=_4f;
}else{
_4e.Collapse();
var _51=this._editor;
var _52=this;
var _53=null;
function getWrongWord(){
var _54=_51.get_document().getElementsByTagName("SPAN");
var i=0;
var _56=_54[i];
_53=_51.getSelection().getRange();
while(_56!=null){
if(_52.isHighlightedWord(_56)){
var _57=null;
if(_51.isIE){
if(_53.duplicate){
tempRange=_53.duplicate();
}else{
tempRange=_51.get_contentArea().createTextRange();
}
if(tempRange.moveToElementText){
tempRange.moveToElementText(_56);
}
if(!_53.compareEndPoints){
break;
}
_57=_53.compareEndPoints("EndToStart",tempRange);
if(0==_57){
_50=_56;
break;
}
}else{
if(_53){
tempRange=_53.cloneRange();
tempRange.selectNodeContents(_56);
_57=_53.compareBoundaryPoints(Range.END_TO_START,tempRange);
}
}
if(dir==_57){
_50=_56;
break;
}
}
i++;
_56=_54[i];
}
return _56;
}
var _50=getWrongWord();
if(!_50){
var _58=_51.get_contentArea();
if(_58&&_58.createTextRange){
var _59=_58.createTextRange();
_59.moveToElementText(_58);
_59.collapse(true);
_59.select();
}else{
var _5a=_51.get_document().getElementsByTagName("SPAN")[0];
if(_5a){
_51.selectElement(_5a);
}
}
try{
var _53=_51.getSelection().getRange();
if(_53&&_53.moveStart){
_53.moveStart("character",-1);
_53.select();
}
}
catch(e){
}
_51.getSelection().Collapse(true);
_50=getWrongWord();
}
}
if(_50){
this._editor.selectElement(_50);
var _5b=this._editor.getSelection().getRange();
if(_5b&&_5b.scrollIntoView&&_5b.select){
_5b.scrollIntoView(true);
_5b.select();
}else{
if(_50.scrollIntoView){
_50.scrollIntoView(false);
}
}
this._showSuggestionDropdown();
}
},clearWrongWords:function(_5c,_5d){
var _5e=this._editor.get_document().getElementsByTagName("SPAN");
for(var i=0;i<_5e.length;i++){
var _60=_5e[i];
if(this.isHighlightedWord(_60)){
if(_5c){
if(_60.innerHTML==_5c){
this.clearHighlightedElement(_60,_5d);
i--;
}
continue;
}else{
this.clearHighlightedElement(_60);
}
i--;
}
}
},isHighlightedRemaining:function(){
var _61=this._editor.get_document().getElementsByTagName("SPAN");
for(var i=0;i<_61.length;i++){
var _63=_61[i];
if(this.isHighlightedWord(_63)){
return true;
}
}
return false;
},getCurrentWrongWord:function(){
var _64=this._selectedEditorElement;
var _65=_64.innerHTML.replace(/<\/?[^>]*>/ig,"");
return _65;
},isHighlightedWord:function(_66){
if(!_66||!_66.getAttribute){
return false;
}
var id=_66.getAttribute("id");
if(id&&id.indexOf(this._spanId)>-1){
return true;
}
return false;
},clearHighlightedElement:function(_68,_69){
var _6a=true;
if(_68!=this._selectedEditorElement){
_6a=false;
}
var _6b=_69?_69:_68.innerHTML.replace(/<\/?[^>]*>/ig,"");
var _6c=_69?true:false;
this._editor.selectElement(_68,false);
var _6d=new Telerik.Web.UI.Editor.GenericCommand(this._localizedName,this._editor.get_contentWindow());
var _6e=this._editor.get_document().createTextNode(_6b);
_68.parentNode.replaceChild(_6e,_68);
if(this._editor.isIE){
range=this._editor.get_contentArea().createTextRange();
range.findText(_6e.data);
range.select();
}else{
this._editor.selectElement(_6e,false);
}
this._editor.getSelection().collapse();
if(_6c){
this._editor.executeCommand(_6d);
}
if(_6a){
this._selectedEditorElement=null;
}
},markWrongWords:function(_6f){
var _70=function(_71,_72,_73,_74){
this.badWords=_71;
this._wordOffsets=_72;
this._spanId=_73;
this.Content=_74;
this.CurrentWordIndex=0;
this.Result=null;
};
_70.prototype={GetSplitContent:function(){
var _75=new Array(this.badWords.length*2+1);
for(var i=0;i<this.badWords.length;i++){
var _77=i*2;
_75[_77]=this.GetBeforeText(i);
_75[_77+1]=this.badWords[i].wordString;
}
_75[_75.length-1]=this.GetLastText();
return _75;
},GetMarkedSplitContent:function(_78){
for(var i=1;i<_78.length;i+=2){
_78[i]=this.GetMarkedWord(_78[i]);
this.CurrentWordIndex++;
}
return _78;
},GetBeforeText:function(_7a){
var _7b=0;
var _7c=this.GetWordStartIndex(this.badWords[_7a]);
if(_7a!=0){
badWordBefore=this.badWords[_7a-1];
_7b=this.GetWordEndCharIndex(badWordBefore);
}
return this.Content.substring(_7b,_7c);
},GetLastText:function(){
var _7d=this.badWords[this.badWords.length-1];
var _7e=this.GetWordEndCharIndex(_7d);
var _7f=this.Content.length;
return this.GetSubContent(_7e,_7f);
},GetWordEndCharIndex:function(_80){
return this.GetWordStartIndex(_80)+_80.wordString.length;
},GetSubContent:function(_81,_82){
return this.Content.substring(_81,_82);
},GetWordStartIndex:function(_83){
return this._wordOffsets[_83.textOffset];
},GetMarkedWord:function(_84){
return "<span class='RadEWrongWord' id='"+this._spanId+this.CurrentWordIndex+"'>"+_84+"</span>";
},GetResult:function(){
if(this.Result==null){
this.Result=this.GetMarkedSplitContent(this.GetSplitContent()).join("");
}
return this.Result;
}};
var _85=new _70(this._wrongWordsArray,this._wordOffsets,this._spanId,this._escapeNewLines(_6f));
Telerik.Web.UI.Editor.Utils.setElementInnerHtml(this._editor.get_contentArea(),this._unescapeNewLines(_85.GetResult()));
},_escapeNewLines:function(_86){
var _87=_86.replace(/\n/gi,"<telerikcr />");
_87=_87.replace(/\r/gi,"<teleriklf />");
return _87;
},_unescapeNewLines:function(_88){
var _89=_88.replace(/\<telerikcr\s*\/\>/gi,"\n");
var _89=_89.replace(/\<teleriklf\s*\/\>/gi,"\r");
return _89;
},_getSuggestionsForWord:function(_8a){
var _8b=this._wrongWordsArray;
for(var i=0;i<_8b.length;i++){
var _8d=_8b[i].wordString;
if(_8d==_8a){
var _8e=_8b[i].suggestionsString;
if(_8e.length==0){
return [["",this._noSuggestionsString]];
}else{
_8e=_8e.concat([]);
for(var j=0;j<_8e.length;j++){
_8e[j]=[_8e[j],_8e[j]];
}
}
return _8e;
}
}
return [];
},_get_footerItems:function(_90){
var _91=[];
if(this._editor.get_spellAllowAddCustom()){
_91.splice(0,0,["rade_add_to_dictionary",this._addToDictionaryString,this._addIconCss]);
}
_91.splice(0,0,["rade_change",this._changeWordString,this._okIconCss]);
if(this._occursMoreThanOnce(_90)){
_91.splice(0,0,["rade_ignore_all",this._ignoreAllString,this._ignoreIconCss]);
}
_91.splice(0,0,["",this._ignoreString,this._ignoreIconCss]);
return _91;
},_occursMoreThanOnce:function(_92){
var _93=this._editor.get_text();
var re=new RegExp("(\\b)"+_92+"(\\b)","g");
var res=_93.match(re);
return (res&&res.length>1);
},fire:function(_96,_97){
var _98=_97.SelectedValue;
var _99=this._selectedEditorElement&&this._selectedEditorElement.innerHTML?this._selectedEditorElement.innerHTML:"";
if(_98=="rade_add_to_dictionary"){
this.onAddCustomWord(this.getCurrentWrongWord());
}else{
if(_98=="rade_ignore_all"){
this.clearWrongWords(_99,"");
}else{
if(_98=="rade_change"){
this._showSuggestionBox(this._selectedEditorElement);
return;
}else{
var _9a=false;
if(_98){
var _9b=this._occursMoreThanOnce(_99);
if(_9b){
var _9c=confirm(this._moreThanOnceMessage);
if(_9c){
this.clearWrongWords(_99,_98);
_9a=true;
}
}
}
if(!_9a){
this.clearHighlightedElement(this._selectedEditorElement,_98);
}
}
}
}
var res=this.isHighlightedRemaining();
if(!res){
this.onSpellCheckComplete();
return;
}
this._editor.raiseEvent("selectionChange",Sys.EventArgs.Empty);
if(this._automaticAdvance){
this.moveToNextWrongWord();
}
},_onDropDownValueSelected:function(_9e,_9f){
var _a0=_9e.get_selectedItem();
this.fire("",{SelectedValue:_a0});
},_onDropDownBeforeShow:function(_a1,_a2){
var _a3=this.getCurrentWrongWord();
var _a4=this._getSuggestionsForWord(_a3);
_a1.set_items(_a4);
},_showSuggestionDropdown:function(){
var _a5=this._editor;
var _a6=_a5.getSelection().getParentElement();
if(!this.isHighlightedWord(_a6)){
return;
}
this._selectedEditorElement=_a6;
var _a7=this.getCurrentWrongWord();
if(!this._suggestionDropdown){
this._onDropDownValueSelectedDelegate=Function.createDelegate(this,this._onDropDownValueSelected);
this._onDropDownBeforeShowDelegate=Function.createDelegate(this,this._onDropDownBeforeShow);
var _a8={"valueSelected":this._onDropDownValueSelectedDelegate,"show":this._onDropDownBeforeShowDelegate};
var _a9={};
_a9["popupwidth"]="160px";
_a9["parentElement"]=_a5.get_contentAreaElement();
_a9["skin"]=_a5.get_skin();
_a9["sizetofit"]=true;
var _aa=$create(Telerik.Web.UI.EditorSpellSuggestionBox,_a9,_a8,null,document.createElement("SPAN"));
this._suggestionDropdown=_aa;
}
var _aa=this._suggestionDropdown;
_aa.hide();
_aa.set_footerItems(this._get_footerItems(_a7));
_aa.set_wrongWordWrapper(_a6);
_aa.show();
_aa.selectNextItem();
if(_a5.isIE){
_a5.setFocus();
}
},_onTextboxValueSelected:function(_ab,_ac){
var val=_ab.get_selectedItem();
this._editor.setFocus();
this.fire("",{SelectedValue:val});
},_showSuggestionBox:function(_ae){
var _af=this._editor;
if(!this._suggestionBox){
this._onTextboxValueSelectedDelegate=Function.createDelegate(this,this._onTextboxValueSelected);
var _b0={"valueSelected":this._onTextboxValueSelectedDelegate};
var _b1={};
_b1["parentElement"]=_af.get_contentAreaElement();
_b1["skin"]=_af.get_skin();
_b1["sizetofit"]=true;
var _b2=$create(Telerik.Web.UI.EditorAjaxSpellTextbox,_b1,_b0,null,document.createElement("SPAN"));
this._suggestionBox=_b2;
}
var _b3=this._suggestionBox;
var _b4=this.getCurrentWrongWord();
window.setTimeout(function(){
_b3.set_wrongWordWrapper(_ae);
_b3.show();
_b3.setValue(_b4);
},10);
}};
Telerik.Web.UI.EditorSpellSuggestionBox=function(_b5){
Telerik.Web.UI.EditorSpellSuggestionBox.initializeBase(this,[_b5]);
this._parentElement=null;
this._wrongWordWrapper=null;
this._maxItemSize=5;
this._popupClassName="rade_AjaxSpellCheck";
};
Telerik.Web.UI.EditorSpellSuggestionBox.prototype={dispose:function(){
this._wrongWordWrapper=null;
Telerik.Web.UI.EditorSpellSuggestionBox.callBaseMethod(this,"dispose");
},initialize:function(){
},set_footerItems:function(_b6){
this._footerItems=_b6;
},renderChildren:function(){
Telerik.Web.UI.EditorSpellSuggestionBox.callBaseMethod(this,"renderChildren");
var _b7=20;
var _b8=this._items.length>this._maxItemSize?this._maxItemSize:this._items.length;
var _b9=_b8>1?(_b8*_b7):25;
var div=document.createElement("DIV");
div.style.overflow="auto";
div.style.height=_b9+"px";
div.className="rade_AjaxSpellCheckSuggestions";
var _bb=this._itemRootElement;
_bb.cellSpacing="0";
var _bc=_bb.parentNode;
_bc.removeChild(_bb);
div.appendChild(_bb);
div.style.overflowX="hidden";
div.style.width="100%";
var _bd=this.renderItemRoot();
_bd.cellSpacing="0";
_bc.appendChild(_bd);
this.renderNewRow();
var _be=this.renderItemContainer();
_be.appendChild(div);
var _bf=document.createElement("DIV");
_bf.className="rade_AjaxSpellCheckSeparator";
_be.appendChild(_bf);
var _c0=this._items.length;
for(var i=0;i<this._footerItems.length;i++){
this.renderNewRow();
var _c2=this.renderItemContainer();
this.markItemContainer(_c2,_c0);
this.renderChild(_c2,this._footerItems[i],_c0);
_c0++;
}
this._items=this._items.concat(this._footerItems);
},configurePopupPropertiesBeforeShow:function(){
var _c3=this._popupBehavior;
_c3.set_positioningMode(Telerik.Web.PositioningMode.Absolute);
var _c4=this.get_parentElement();
if(_c4){
_c3.set_parentElement(_c4);
}
var _c5=this.get_wrongWordWrapper();
if(_c5){
var _c6=$telerik.getBounds(_c5);
_c3.set_x(_c6.x);
_c3.set_y(_c6.y+_c6.height);
}
},get_parentElement:function(){
return this._parentElement;
},set_parentElement:function(_c7){
this._parentElement=_c7;
},get_maxItemSize:function(){
return this._maxItemSize;
},set_maxItemSize:function(_c8){
this._maxItemSize=_c8;
},get_wrongWordWrapper:function(){
return this._wrongWordWrapper;
},set_wrongWordWrapper:function(_c9){
this._wrongWordWrapper=_c9;
}};
Telerik.Web.UI.EditorSpellSuggestionBox.registerClass("Telerik.Web.UI.EditorSpellSuggestionBox",Telerik.Web.UI.EditorSplitButton);
Telerik.Web.UI.EditorAjaxSpellTextbox=function(_ca){
Telerik.Web.UI.EditorAjaxSpellTextbox.initializeBase(this,[_ca]);
};
Telerik.Web.UI.EditorAjaxSpellTextbox.prototype={dispose:function(){
if(null!=this._element){
this._element.onchange=null;
this._element.onkeypress=null;
this._element.onclick=null;
this._element.Parent=null;
}
this._element=null;
Telerik.Web.UI.EditorAjaxSpellTextbox.callBaseMethod(this,"dispose");
},setValue:function(_cb){
if(this._textElement){
this._textElement.value=_cb;
}
var _cc=this._textElement;
try{
if(_cc){
_cc.focus();
}
if(_cc&&_cc.setActive){
_cc.setActive();
var _cd=document.selection.createRange();
_cd.moveStart("word",1);
_cd.select();
_cd.collapse();
}
}
catch(e){
}
},get_selectedItem:function(){
return this._textElement.value;
},fire:function(){
this.hide();
this.raiseEvent("valueSelected");
},attachEventHandlers:function(){
},show:function(){
if(!this._rendered){
this.render();
}
this._show();
},configurePopupPropertiesBeforeShow:function(){
Telerik.Web.UI.EditorAjaxSpellTextbox.callBaseMethod(this,"configurePopupPropertiesBeforeShow");
var _ce=this._popupBehavior;
var _cf=this.get_wrongWordWrapper();
if(_cf){
var _d0=$telerik.getBounds(_cf);
_ce.set_y(_d0.y);
}
},renderChildren:function(){
},renderItemRoot:function(){
this._createBox();
this._itemRootElement=this._element;
return this._itemRootElement;
},_createBox:function(){
var _d1=document.createElement("INPUT");
_d1.setAttribute("size","20");
_d1.Parent=this;
var _d2=function(e,_d4,_d5){
if(_d5){
if(_d4.Executed){
_d4.Executed=false;
return $telerik.cancelRawEvent(e);
}
}
_d4.Executed=true;
_d4.Parent.fire();
return $telerik.cancelRawEvent(e);
};
_d1.onclick=new Function("this.focus();");
_d1.onkeypress=function(e){
if(!e){
e=window.event;
}
if(e&&e.keyCode==13){
return _d2(e,this);
}
};
this._textElement=_d1;
var _d7=document.createElement("div");
var _d8=document.createElement("button");
_d8.onmousedown=new Function("e","return false;");
_d8.onclick=new Function("e","this.parentNode.getElementsByTagName('input')[0].Parent.fire();return false;");
_d8.className="rade_ajaxspell_okicon";
_d7.appendChild(_d1);
_d7.appendChild(_d8);
this._element=_d7;
return this._element;
}};
Telerik.Web.UI.EditorAjaxSpellTextbox.registerClass("Telerik.Web.UI.EditorAjaxSpellTextbox",Telerik.Web.UI.EditorSpellSuggestionBox);

