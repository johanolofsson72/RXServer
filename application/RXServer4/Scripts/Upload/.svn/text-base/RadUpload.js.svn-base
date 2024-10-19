Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.ControlObjectsVisibility=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.ControlObjectsVisibility.prototype={None:0,CheckBoxes:1,RemoveButtons:2,ClearButtons:4,AddButton:8,DeleteSelectedButton:16,Default:(1|2|4|16),All:(1|2|4|8|16)};
Telerik.Web.UI.ControlObjectsVisibility.registerEnum("Telerik.Web.UI.ControlObjectsVisibility",false);
Type.registerNamespace("Telerik.Web.UI.RadUploadUtils");
Telerik.Web.UI.RadUploadUtils.Localization={"Remove":"Remove","Add":"Add","Clear":"Clear","Select":"Select","Delete":"Delete"};
function getRadUpload(_1){
return $find(_1);
}
Telerik.Web.UI.RadUpload=function(_2){
Telerik.Web.UI.RadUpload.initializeBase(this,[_2]);
this._formId="";
this._enabled=true;
this._maxFileCount=0;
this._initialFileInputsCount=1;
this._inputSize=23;
this._controlObjectsVisibility=Telerik.Web.UI.ControlObjectsVisibility.Default;
this._showCheckboxes=true;
this._showRemoveButtons=true;
this._showClearButtons=true;
this._showAddButton=true;
this._showDeleteButton=true;
this._focusOnLoad=false;
this._enableFileInputSkinning=true;
this._readOnlyFileInputs=false;
this._allowedFileExtensions=[];
this._currentIndex=0;
this._localization=null;
};
Telerik.Web.UI.RadUpload.prototype={initialize:function(){
Telerik.Web.UI.RadUpload.callBaseMethod(this,"initialize");
this._updateFormProperties($get(this._formId));
this._listContainer=this._findElement("ListContainer");
this._addButton=this._initButton(this._findElement("AddButton"),"Add",this.addFileInput);
this._deleteButton=this._initButton(this._findElement("DeleteButton"),"Delete",this.deleteSelectedFileInputs);
var _3=this._maxFileCount==0?this._initialFileInputsCount:Math.min(this._initialFileInputsCount,this._maxFileCount);
for(var i=0;i<_3;i++){
this.addFileInput();
}
this._setAddDeleteButtonStates();
this._initialized=true;
},dispose:function(){
if(this._addButton){
$clearHandlers(this._addButton);
}
if(this._deleteButton){
$clearHandlers(this._deleteButton);
}
var _5=this._getRowCount();
for(var i=0;i<_5;i++){
var _7=this._getRow(i);
if(_7){
$clearHandlers(_7);
var _8=this.getFileInputFrom(_7);
if(_8){
$clearHandlers(_8);
}
var _9=this._getChildSelectButton(_7);
if(_9){
$clearHandlers(_9);
}
var _a=this._getChildFileNameInputField(_7);
if(_a){
$clearHandlers(_a);
}
}
}
Telerik.Web.UI.RadUpload.callBaseMethod(this,"dispose");
},_updateFormProperties:function(_b){
if(!_b){
_b=document.forms[0];
}
_b.enctype=_b.encoding="multipart/form-data";
},_getChildInputElement:function(_c,_d){
var _e=_c.getElementsByTagName("input");
for(var i=0;i<_e.length;i++){
if(_e[i].type==_d){
return _e[i];
}
}
return null;
},_getChildInputElements:function(row,_11){
var _12=[];
var _13=row.getElementsByTagName("input");
var num=0;
for(var i=0;i<_13.length;i++){
if(_13[i].type==_11){
_12[num]=_13[i];
num++;
}
}
return _12;
},_getChildUploadCheckbox:function(row){
var _17=new RegExp(this.get_id()+"checkbox\\d+$");
var _18=this._getChildInputElements(row,"checkbox");
for(var i=0;i<_18.length;i++){
if(_18[i].id.match(_17)){
return _18[i];
}
}
return null;
},_getChildSelectButton:function(row){
var _1b=/ruBrowse/;
var _1c=this._getChildInputElements(row,"button");
for(var i=0;i<_1c.length;i++){
if(_1b.test(_1c[i].className)){
return _1c[i];
}
}
return null;
},_getChildFileNameInputField:function(row){
var _1f=/ruFakeInput/;
var _20=this._getChildInputElements(row,"text");
for(var i=0;i<_20.length;i++){
if(_1f.test(_20[i].className)){
return _20[i];
}
}
return null;
},_getRowCount:function(){
var _22=this._listContainer.getElementsByTagName("li").length;
if(this._showAddButton||this._showDeleteButton){
return _22-1;
}else{
return _22;
}
},_getParentRow:function(_23){
if(!_23){
return null;
}
var _24=_23.parentNode;
while(_24.tagName!="LI"){
_24=_24.parentNode;
if(null==_24){
break;
}
}
return _24;
},_getRowIndex:function(row){
var _26=this._listContainer;
var _27=_26.getElementsByTagName("li");
for(var i=0;i<_27.length;i++){
if(_27[i]==row){
return i;
}
}
return null;
},_getRow:function(_29){
var _2a=this._listContainer;
var _2b=_2a.getElementsByTagName("li");
var _2c=(_29<_2b.length)?_2b[_29]:null;
return _2c;
},_addRow:function(_2d){
if(_2d<0){
_2d=0;
}
var row=document.createElement("LI");
var _2f=this._getRow(_2d);
var _30=this._listContainer;
if(_2f){
_30.insertBefore(row,_2f);
}else{
_30.appendChild(row);
}
return row;
},getID:function(_31){
return this.get_id()+_31+this._currentIndex;
},_findElement:function(_32){
var _33=this.get_id()+_32;
return $get(_33);
},_initButton:function(_34,_35,_36){
if(_34){
var loc=this.get_localization();
_34.value=loc[_35];
if(this._enabled){
if(_36){
$addHandlers(_34,{"click":_36},this);
}
}else{
_34.disabled=true;
}
}
return _34;
},addFileInput:function(_38){
var _39=this.addFileInputAt(this._getRowCount());
if(this._initialized){
try{
_39.focus();
}
catch(ex){
}
}
},addFileInputAt:function(_3a){
if(typeof (_3a)=="undefined"||_3a>this._getRowCount()){
_3a=this._getRowCount();
}
if(this._maxFileCount>0&&_3a>=this._maxFileCount){
return;
}
if(this._initialized){
var _3b=new Sys.CancelEventArgs();
this.raiseEvent("adding",_3b);
if(_3b.get_cancel()){
return;
}
}
this.addFileInputAtInternal(_3a);
},addFileInputAtInternal:function(_3c){
var row=this._addRow(_3c);
$addHandlers(row,{"click":this._rowClicked},this);
if(this._showCheckboxes){
this.appendCheckBox(row);
}
this.appendStyledFileInput(row);
if(this._showClearButtons){
this.appendClearButton(row);
}
if(this._showRemoveButtons){
this.appendRemoveButton(row);
}
this._setAddDeleteButtonStates();
var _3e=new Sys.EventArgs();
_3e._row=row;
_3e.get_row=function(){
return this._row;
};
this.raiseEvent("added",_3e);
this._currentIndex++;
return row;
},appendCheckBox:function(_3f){
var _40=document.createElement("input");
_40.type="checkbox";
_40.id=_40.name=this.getID("checkbox");
_3f.appendChild(_40);
_40.className="ruCheck";
_40.disabled=!this._enabled;
return _40;
},appendClearButton:function(_41){
var _42=document.createElement("input");
_42.type="button";
_42.id=this.getID("clear");
_41.appendChild(_42);
this._initButton(_42,"Clear");
_42.className="ruButton ruClear";
_42.name="ClearInput";
_42.disabled=!this._enabled;
return _42;
},appendRemoveButton:function(_43){
var _44=document.createElement("input");
_44.type="button";
_44.id=this.getID("remove");
_43.appendChild(_44);
var loc=this.get_localization();
_44.value=loc["Remove"];
_44.className="ruButton ruRemove";
_44.name="RemoveRow";
_44.disabled=!this._enabled;
return _44;
},appendStyledFileInput:function(_46){
var _47=this.createFileInput();
this._fileInput=_47;
$addHandlers(_47,{"change":this.uploadFileSelected},this);
var _48=document.createElement("span");
_48.className="ruFileWrap";
_46.appendChild(_48);
_48.appendChild(_47);
if(this._enableFileInputSkinning){
Sys.UI.DomElement.addCssClass(_48,"ruStyled");
_48.style.position="static";
_47.className="ruFileInput";
$telerik.setLocation(_47,{x:-1000,y:-1000});
this._appendFakeInput(_48);
if(!this._readOnlyFileInputs){
$addHandlers(_47,{"keyup":this._syncFileInputContent},this);
}else{
$addHandlers(_47,{"keydown":this._cancelEvent},this);
}
var _49={"mousemove":this._getFileInputMouseMoveHandler(),"mouseover":this._getFileInputMouseMoveHandler(),"mouseout":this._getFileInputMouseOutHandler()};
$addHandlers(_47,_49,this);
return _48;
}else{
_47.className="";
if(this._readOnlyFileInputs){
$addHandlers(_47,{"keydown":this._cancelEvent},this);
}
return _47;
}
},_selectButtonMouseOver:function(e){
var _4b=e.target||e.srcElement;
var row=this._getParentRow(_4b);
var _4d=this.getFileInputFrom(row);
this._positionFileInput(_4d,_4b,this._getChildFileNameInputField(row),e);
},_selectButtonMouseOut:function(e){
var _4f=e.target||e.srcElement;
var row=this._getParentRow(_4f);
var _51=this.getFileInputFrom(row);
$telerik.setLocation(_51,{x:-1000,y:-1000});
},_selectButtonClick:function(e){
},_positionFileInput:function(_53,_54,_55,e){
var _57;
if($telerik.isMouseOverElement(_54,e)){
var _58=$telerik.getDocumentRelativeCursorPosition(e);
_57={x:_58.left+10-_53.offsetWidth,y:_58.top+10-_53.offsetHeight};
}else{
if($telerik.isMouseOverElement(_55,e)){
$telerik.setLocation(_53,$telerik.getLocation(_55));
return;
}else{
_57={x:-1000,y:-1000};
}
}
$telerik.setLocation(_53,_57);
},_fileInputMouseMove:function(e){
var _5a=e.target||e.srcElement;
var row=this._getParentRow(_5a);
var _5c=this._getChildSelectButton(row);
this._positionFileInput(_5a,_5c,this._getChildFileNameInputField(row),e);
},_fileInputMouseOut:function(e){
var _5e=e.target||e.srcElement;
var row=this._getParentRow(_5e);
var _60=this._getChildSelectButton(row);
this._positionFileInput(_5e,_60,this._getChildFileNameInputField(row),e);
},_onFakeFileInputMouseEvent:function(e){
var _62=e.target||e.srcElement;
var row=this._getParentRow(_62);
var _64=this.getFileInputFrom(row);
if($telerik.getLocation(_62)==$telerik.getLocation(_64)){
return;
}
this._positionFileInput(_64,this._getChildSelectButton(row),_62,e);
},_getFileInputMouseMoveHandler:function(){
if(this._fileInputMouseMoveHandler==null){
this._fileInputMouseMoveHandler=Function.createDelegate(this,this._fileInputMouseMove);
}
return this._fileInputMouseMoveHandler;
},_getFileInputMouseOutHandler:function(){
if(this._fileInputMouseOutHandler==null){
this._fileInputMouseOutHandler=Function.createDelegate(this,this._fileInputMouseOut);
}
return this._fileInputMouseOutHandler;
},_getSelectButtonMouseOverHandler:function(){
if(this._selectButtonMouseOverHandler==null){
this._selectButtonMouseOverHandler=Function.createDelegate(this,this._selectButtonMouseOver);
}
return this._selectButtonMouseOverHandler;
},_getSelectButtonMouseOutHandler:function(){
if(this._selectButtonMouseOutHandler==null){
this._selectButtonMouseOutHandler=Function.createDelegate(this,this._selectButtonMouseOut);
}
return this._selectButtonMouseOutHandler;
},_getFakeFileInputMouseHandler:function(){
if(this._fakeFileInputMouseHandler==null){
this._fakeFileInputMouseHandler=Function.createDelegate(this,this._onFakeFileInputMouseEvent);
}
return this._fakeFileInputMouseHandler;
},_initFakeInputSelectButton:function(_65){
var _66={"mouseover":this._getSelectButtonMouseOverHandler(),"mouseout":this._getSelectButtonMouseOutHandler()};
if($telerik.isIE){
_66["mousemove"]=this._getSelectButtonMouseOverHandler();
}
$addHandlers(_65,_66,this);
},_appendFakeInput:function(_67){
var _68=document.createElement("input");
_68.type="text";
_68.className="ruFakeInput";
_68.size=this._inputSize-1;
var _69={"mouseover":this._getFakeFileInputMouseHandler(),"mousemove":this._getFakeFileInputMouseHandler(),"mouseout":this._getFakeFileInputMouseHandler()};
$addHandlers(_68,_69,this);
_67.appendChild(_68);
var _6a=document.createElement("input");
_6a.type="button";
_67.appendChild(_6a);
this._initButton(_6a,"Select");
this._initFakeInputSelectButton(_6a);
_6a.disabled=!this._enabled;
_6a.className="ruButton ruBrowse";
if($telerik.isSafari){
var _6b=$telerik.getBounds(_6a).width;
var _6c=$telerik.getBounds(_68).width;
var _6d=this._fileInput;
if(_6d){
_6d.style.width=(_6b+_6c)+"px";
}
}
},createFileInput:function(){
var _6e=document.createElement("input");
_6e.type="file";
_6e.name=this.getID("file");
_6e.id=this.getID("file");
_6e.disabled=!this._enabled;
_6e.size=this._inputSize;
return _6e;
},_setAddDeleteButtonStates:function(){
var _6f=this._getRowCount();
this._setButtonState(this._deleteButton,_6f>0);
this._setButtonState(this._addButton,(this._maxFileCount<=0)||(_6f<this._maxFileCount));
},_setButtonState:function(_70,_71){
if(_70){
if(_71){
Sys.UI.DomElement.removeCssClass(_70,"ruButtonDisabled");
}else{
Sys.UI.DomElement.addCssClass(_70,"ruButtonDisabled");
}
}
},_cancelEvent:function(_72){
return $telerik.cancelRawEvent(_72);
},clearFileInputAt:function(_73){
var row=this._getRow(_73);
if(row){
var _75=new Sys.CancelEventArgs();
_75._fileInputField=this.getFileInputFrom(row);
_75.get_fileInputField=function(){
return this._fileInputField;
};
this.raiseEvent("clearing",_75);
if(_75.get_cancel()){
return false;
}
this.deleteFileInputAt(_73,true);
this.addFileInputAtInternal(_73,true);
}
},deleteSelectedFileInputs:function(_76){
var _77=[];
var _78=[];
var _79=this._getRowCount()-1;
for(var i=_79;i>=0;i--){
var _7b=this._getRow(i);
var _7c=this._getChildUploadCheckbox(_7b);
if(_7c&&_7c.checked){
_78[_78.length]=i;
_77[_77.length]=this.getFileInputFrom(_7b);
}
}
var _7d=new Sys.CancelEventArgs();
_7d._fileInputFields=_77;
_7d.get_fileInputFields=function(){
return this._fileInputFields;
};
this.raiseEvent("deletingSelected",_7d);
if(_7d.get_cancel()){
return;
}
for(var i=0;i<_78.length;i++){
this.deleteFileInputAt(_78[i],true);
}
},deleteFileInputAt:function(_7e,_7f){
var row=this._getRow(_7e);
if(row){
if(!_7f){
var _81=new Sys.CancelEventArgs();
_81._fileInputField=this.getFileInputFrom(row);
_81.get_fileInputField=function(){
return this._fileInputField;
};
this.raiseEvent("deleting",_81);
if(_81.get_cancel()){
return false;
}
}
var _82=this._getChildSelectButton(row);
if(_82){
$clearHandlers(_82);
}
$clearHandlers(row);
row.parentNode.removeChild(row);
this._setAddDeleteButtonStates();
}
},getFileInputFrom:function(row){
return this._getChildInputElement(row,"file");
},getFileInputs:function(){
var _84=[];
var _85=this._getRowCount();
for(var i=0;i<_85;i++){
_84[_84.length]=this.getFileInputFrom(this._getRow(i));
}
return _84;
},uploadFileSelected:function(e){
if(this._enableFileInputSkinning){
this._syncFileInputContent(e);
}
var _88=e.target;
_88.alt=_88.title=_88.value;
var _89=new Sys.EventArgs();
_89._fileInputField=_88;
_89.get_fileInputField=function(){
return this._fileInputField;
};
this.raiseEvent("fileSelected",_89);
},_syncFileInputContent:function(e){
var _8b=e.target;
var _8c=_8b.parentNode.getElementsByTagName("input");
var _8d=null;
for(var i=0;i<_8c.length;i++){
var _8f=_8c[i];
if(_8f.type=="text"){
_8d=_8f;
break;
}
}
if(_8b!==_8d){
_8d.value=_8b.value;
_8d.title=_8b.value;
}
},isExtensionValid:function(_90){
if(_90==""){
return true;
}
var _91=this._allowedFileExtensions.length;
for(var i=0;i<_91;i++){
var _93=this._allowedFileExtensions[i];
var _94=_93.substring(1);
var _95=new RegExp("."+_94+"$","ig");
if(_90.match(_95)){
return true;
}
}
return false;
},validateExtensions:function(){
var _96=this._getRowCount();
for(var i=0;i<_96;i++){
var row=this._getRow(i);
var _99=this.getFileInputFrom(row).value;
if(!this.isExtensionValid(_99)){
return false;
}
}
return true;
},_rowClicked:function(e){
var _9b=e.target;
var _9c=this._getParentRow(_9b);
var _9d=this._getRowIndex(_9c);
if(_9b.name=="RemoveRow"){
this.deleteFileInputAt(_9d);
}else{
if(_9b.name=="ClearInput"){
this.clearFileInputAt(_9d);
}
}
},get_localization:function(){
return this._localization;
},set_localization:function(_9e){
this._localization=_9e;
},get_inputSize:function(){
return this._inputSize;
},set_inputSize:function(_9f){
this._inputSize=_9f;
},get_controlObjectsVisibility:function(){
return this._controlObjectsVisibility;
},set_controlObjectsVisibility:function(_a0){
this._controlObjectsVisibility=_a0;
var _a1=Telerik.Web.UI.ControlObjectsVisibility;
this._showCheckboxes=(_a0&_a1.CheckBoxes);
this._showRemoveButtons=(_a0&_a1.RemoveButtons);
this._showClearButtons=(_a0&_a1.ClearButtons);
this._showAddButton=(_a0&_a1.AddButton);
this._showDeleteButton=(_a0&_a1.DeleteSelectedButton);
},get_allowedFileExtensions:function(){
return this._allowedFileExtensions;
},set_allowedFileExtensions:function(_a2){
if(!_a2){
this._allowedFileExtensions=[];
}else{
this._allowedFileExtensions=eval(_a2);
}
},get_enabled:function(){
return this._enabled;
},set_enabled:function(_a3){
this._enabled=_a3;
},get_maxFileCount:function(){
return this._maxFileCount;
},set_maxFileCount:function(_a4){
this._maxFileCount=_a4;
},get_initialFileInputsCount:function(){
return this._initialFileInputsCount;
},set_initialFileInputsCount:function(_a5){
this._initialFileInputsCount=_a5;
},get_enableFileInputSkinning:function(){
return this._enableFileInputSkinning;
},set_enableFileInputSkinning:function(_a6){
this._enableFileInputSkinning=_a6;
},get_focusOnLoad:function(){
return this._focusOnLoad;
},set_focusOnLoad:function(_a7){
this._focusOnLoad=_a7;
},get_formId:function(){
return this._formId;
},set_formId:function(_a8){
this._formId=_a8;
},get_readOnlyFileInputs:function(){
return this._readOnlyFileInputs;
},set_readOnlyFileInputs:function(_a9){
this._readOnlyFileInputs=_a9;
},add_adding:function(_aa){
this.get_events().addHandler("adding",_aa);
},remove_adding:function(_ab){
this.get_events().removeHandler("adding",_ab);
},add_added:function(_ac){
this.get_events().addHandler("added",_ac);
},remove_added:function(_ad){
this.get_events().removeHandler("added",_ad);
},add_fileSelected:function(_ae){
this.get_events().addHandler("fileSelected",_ae);
},remove_fileSelected:function(_af){
this.get_events().removeHandler("fileSelected",_af);
},add_deleting:function(_b0){
this.get_events().addHandler("deleting",_b0);
},remove_deleting:function(_b1){
this.get_events().removeHandler("deleting",_b1);
},add_clearing:function(_b2){
this.get_events().addHandler("clearing",_b2);
},remove_clearing:function(_b3){
this.get_events().removeHandler("clearing",_b3);
},add_deletingSelected:function(_b4){
this.get_events().addHandler("deletingSelected",_b4);
},remove_deletingSelected:function(_b5){
this.get_events().removeHandler("deletingSelected",_b5);
}};
Telerik.Web.UI.RadUpload.registerClass("Telerik.Web.UI.RadUpload",Telerik.Web.UI.RadWebControl);

