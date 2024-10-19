Type.registerNamespace("Telerik.Web.UI.Editor");
Type.registerNamespace("Telerik.Web.UI.Editor.Modules");
Telerik.Web.UI.Editor.ModulesManager=function(_1){
this._editor=_1;
this._modules=[];
this._onEditorModeChangeDelegate=Function.createDelegate(this,this._onEditorModeChange);
};
Telerik.Web.UI.Editor.ModulesManager.prototype={initialize:function(){
this.createModules();
this._editor.add_modeChange(this._onEditorModeChangeDelegate);
},getModuleByName:function(_2){
for(var i=0;i<this._modules.length;i++){
if(this._modules[i].get_name()==_2){
return this._modules[i];
}
}
return null;
},createModules:function(){
if(!this._editor){
return;
}
var _4=this._editor.get_modulesJSON();
for(var i=0;i<_4.length;i++){
this.createModule(_4[i]);
}
},createModule:function(_6){
if(_6.attributes){
for(var _7 in _6.attributes){
_6[_7.toLowerCase()]=_6.attributes[_7];
}
}
var _8=_6["enabled"];
if(false==_8){
return;
}
_6["editor"]=this._editor;
var _9=_6["name"];
if(_9){
_6["title"]=this._editor.getLocalizedString(_9);
}
var _a=null;
var _b=null;
try{
_a=eval("Telerik.Web.UI.Editor.Modules."+_9);
}
catch(e){
_b=e;
}
if(!_a){
try{
_a=eval(_9);
}
catch(e){
_b=e;
}
}
if(!_a){
}
if(_a){
var _c=document.createElement("DIV");
var _d=this._getModuleZone(_6["dockingzone"]);
delete _6.dockingzone;
delete _6.dockable;
if(_d){
if(_d.innerHTML=="&nbsp;"){
_d.innerHTML="";
}
_d.appendChild(_c);
}
this._modules[this._modules.length]=$create(_a,_6,null,null,_c);
}
},_getModuleZone:function(_e){
var id=this._editor.get_id();
var _10=$get(id+_e);
if(!_10){
_10=$get(id+"Module");
}
return _10;
},_onEditorModeChange:function(_11,_12){
var _13=Telerik.Web.UI.EditModes;
var _14=_11.get_mode();
this.setModulesVisible((_14==_13.Design));
},setModulesVisible:function(_15){
var _16=this._modules;
if(!this._enabledModules){
this._enabledModules={};
}
for(var i=0;i<_16.length;i++){
var _18=_16[i];
var _19=_18.get_name();
var _1a=_15;
if(!_1a){
if(_18.get_visible()){
this._enabledModules[_19]=true;
}
}else{
if(this._enabledModules[_19]){
_1a=true;
}else{
_1a=false;
}
}
_18.set_visible(_1a);
}
if(_15){
this._enabledModules=null;
}
this._fixIEBottomZoneDisplacement(_15);
},_fixIEBottomZoneDisplacement:function(_1b){
if($telerik.isIE){
if(!this._emptySpan){
this._emptySpan=document.createElement("span");
var _1c=this._getModuleZone("Bottom");
if(_1c){
var _1d=this._emptySpan;
_1d.innerHTML="&nbsp;";
_1d.style.display="none";
_1c.appendChild(_1d);
}
}
this._emptySpan.style.display=_1b?"none":"";
}
},get_modules:function(){
return this._modules;
}};
Telerik.Web.UI.Editor.ModulesManager.registerClass("Telerik.Web.UI.Editor.ModulesManager",null);
Telerik.Web.UI.Editor.Modules.ModuleBase=function(_1e){
Telerik.Web.UI.Editor.Modules.ModuleBase.initializeBase(this,[_1e]);
this._editor=null;
this._name="";
this._visible=true;
this._enabled=true;
this._rendered=false;
this._enableMaxWidth=true;
this._title="";
this._className="rade_module";
this._scriptFile="";
this._attributes={};
this.isSafari=$telerik.isSafari;
this.isIE=$telerik.isIE;
this.isOpera=$telerik.isOpera;
this.isFirefox=$telerik.isFirefox;
};
Telerik.Web.UI.Editor.Modules.ModuleBase.prototype={initialize:function(){
Telerik.Web.UI.Editor.Modules.ModuleBase.callBaseMethod(this,"initialize");
if(this.get_visible()){
this.render();
}
},render:function(){
var _1f=this.get_element();
if(_1f){
_1f.className=this._className;
}
this._rendered=true;
},toggleVisibility:function(){
this.set_visible(!this.get_visible());
},attachEventHandler:function(_20,_21){
var _22=this.get_editor();
if(_22){
_22.attachEventHandler(_20,_21);
}
},_getLocalizedString:function(_23,_24){
return this._editor.getLocalizedString(_23,_24);
},get_editor:function(){
return this._editor;
},set_editor:function(_25){
this._editor=_25;
},get_attributes:function(){
return this._attributes;
},set_attributes:function(_26){
this._attributes=_26;
},get_scriptFile:function(){
return this._scriptFile;
},set_scriptFile:function(_27){
this._scriptFile=_27;
},get_visible:function(){
var _28=this.get_element();
if(!_28){
return false;
}
return (_28.style.display!="none");
},set_visible:function(_29){
if(_29&&!this._rendered){
this.render();
}
var _2a=this.get_element();
_2a.style.display=_29?"":"none";
},get_enabled:function(){
return this._enabled;
},set_enabled:function(_2b){
this._enabled=_2b;
},get_title:function(){
return this._title;
},set_title:function(_2c){
this._title=_2c;
},get_name:function(){
return this._name;
},set_name:function(_2d){
this._name=_2d;
}};
Telerik.Web.UI.Editor.Modules.ModuleBase.registerClass("Telerik.Web.UI.Editor.Modules.ModuleBase",Sys.UI.Control);
Telerik.Web.UI.Editor.Modules.RadEditorDomInspector=function(_2e){
Telerik.Web.UI.Editor.Modules.RadEditorDomInspector.initializeBase(this,[_2e]);
};
Telerik.Web.UI.Editor.Modules.RadEditorDomInspector.prototype={initialize:function(){
this._onSelectionChangeDelegate=Function.createDelegate(this,this.showDomPath);
this._editorPathArray=[];
this._removeElementString=this._getLocalizedString("DomInspectorRemoveElement","Remove Element");
Telerik.Web.UI.Editor.Modules.RadEditorDomInspector.callBaseMethod(this,"initialize");
},dispose:function(){
this.clear();
this._registerMouseHandlers(false);
Telerik.Web.UI.Editor.Modules.RadEditorDomInspector.callBaseMethod(this,"dispose");
},render:function(){
Telerik.Web.UI.Editor.Modules.RadEditorDomInspector.callBaseMethod(this,"render");
this.clear();
this.get_editor().add_selectionChange(this._onSelectionChangeDelegate);
this._registerMouseHandlers(true);
this.showDomPath();
},_registerMouseHandlers:function(_2f){
var _30=this.get_element();
if(true==_2f){
var _31={click:this._onMouseClick,mouseover:this._onMouseOver,mouseout:this._onMouseOut};
$addHandlers(_30,_31,this);
}else{
if(_30){
$clearHandlers(_30);
}
}
},_onMouseOver:function(e){
var _33=this._getReferredEditorElement(e);
if(!_33||this._isSelectedElement(_33)){
return;
}
try{
Sys.UI.DomElement.addCssClass(_33,"RadEDomMouseOver");
}
catch(e){
}
},_onMouseOut:function(e){
var _35=this._getReferredEditorElement(e);
if(!_35){
return;
}
try{
Sys.UI.DomElement.removeCssClass(_35,"RadEDomMouseOver");
if(""==_35.className){
_35.removeAttribute("className",0);
_35.removeAttribute("class",0);
}
}
catch(e){
}
},_onMouseClick:function(e){
var _37=e.target;
if(!_37||_37.tagName!="A"){
return null;
}
if(_37.innerHTML==this._removeElementString){
var _38=this._editorPathArray[0];
this.removeSelectedElement(_38);
}else{
var _38=this._getReferredEditorElement(e);
this.selectElement(_38);
}
return $telerik.cancelRawEvent(e);
},clear:function(){
this.get_element().innerHTML="&nbsp;";
this._editorPathArray=[];
},_createRemoveLink:function(){
var _39=document.createElement("A");
_39.innerHTML=this._removeElementString;
_39.href="javascript:void(0)";
_39.className="rade_module_domlink";
this.get_element().appendChild(_39);
},addDomCouple:function(_3a,_3b){
if(!_3a||!_3a.tagName){
return;
}
var _3c=this.get_element();
var _3d=document.createElement("A");
_3d.oncontextmenu=$telerik.cancelRawEvent;
_3d.href="javascript:void(0);";
_3d.innerHTML=_3a.tagName;
_3d.className=_3b?"rade_module_domlink_selected ":"rade_module_domlink";
_3c.appendChild(_3d);
var _3e=document.createElement("SPAN");
_3e.innerHTML="&nbsp;> ";
_3c.appendChild(_3e);
},_getPathArray:function(_3f,_40){
var _41=[];
while(_3f!=_40&&null!=_3f){
_41[_41.length]=_3f;
_3f=_3f.parentNode;
}
return _41;
},_isSelectedElement:function(_42){
var _43=this._editorPathArray;
if(_43&&_43[0]==_42){
return true;
}
},_getReferredEditorElement:function(e){
var _45=e.target;
if(!_45||_45.tagName!="A"){
return null;
}
var _46=this.get_element().getElementsByTagName("A");
var _47=-1;
for(var i=0;i<_46.length;i++){
if(_46[i]==_45){
_47=i;
break;
}
}
if(_47>-1){
var _49=this._editorPathArray.concat([]).reverse();
return _49[_47];
}
},showDomPath:function(){
if(!this.get_visible()){
return;
}
try{
var _4a=this.get_editor().getSelectedElement();
if(!_4a){
return;
}
var _4b=this.get_editor().get_contentArea();
if(this.isIE&&!_4b.contains(_4a)){
return;
}
this.clear();
this._editorPathArray=this._getPathArray(_4a,_4b);
var _4c=this._editorPathArray;
for(var i=_4c.length-1;i>=0;i--){
this.addDomCouple(_4c[i],(i==0));
}
if(_4c.length>0){
this._createRemoveLink();
}
}
catch(ex){
}
},selectElement:function(_4e){
try{
this._selectedElement=_4e;
this.get_editor().selectElement(_4e);
this._selectedElement=null;
}
catch(ex){
}
},removeSelectedElement:function(_4f){
try{
if(_4f.tagName=="TD"||_4f.tagName=="TH"){
this.get_editor().fire("DeleteCell");
}else{
if(_4f.tagName=="TR"){
this.get_editor().fire("DeleteRow");
}else{
if(_4f.tagName=="TABLE"||_4f.tagName=="TBODY"||_4f.tagName=="THEAD"||_4f.tagName=="TFOOT"||_4f.tagName=="EMBED"||_4f.tagName=="OBJECT"||_4f.tagName=="INPUT"||_4f.tagName=="IMG"||_4f.tagName=="HR"){
var cmd=new Telerik.Web.UI.Editor.GenericCommand(this._removeElementString,this.get_editor().get_contentWindow());
var _51=_4f.parentNode;
_51.removeChild(_4f);
this.get_editor().setFocus();
this.get_editor().executeCommand(cmd);
_52.select();
this.get_editor().setActive();
this.get_editor().setFocus();
}else{
if(_4f.tagName!="BODY"){
var _52=this.get_editor().createRestorePoint();
var _51=_4f.parentNode;
var cmd=new Telerik.Web.UI.Editor.GenericCommand(this._removeElementString,this.get_editor().get_contentWindow());
var _53="";
for(var i=0;i<_51.childNodes.length;i++){
if(_4f!=_51.childNodes[i]){
_53+=Telerik.Web.UI.Editor.Utils.getOuterHtml(_51.childNodes[i]);
}else{
_53+=_4f.innerHTML;
}
}
_51.innerHTML=_53;
this.get_editor().setFocus();
this.get_editor().executeCommand(cmd);
_52.select();
this.get_editor().setActive();
this.get_editor().setFocus();
}
}
}
}
}
catch(ex){
}
this.get_editor().raiseEvent("selectionChange");
}};
Telerik.Web.UI.Editor.Modules.RadEditorDomInspector.registerClass("Telerik.Web.UI.Editor.Modules.RadEditorDomInspector",Telerik.Web.UI.Editor.Modules.ModuleBase);
Telerik.Web.UI.Editor.Modules.RadEditorHtmlInspector=function(_55){
Telerik.Web.UI.Editor.Modules.RadEditorHtmlInspector.initializeBase(this,[_55]);
};
Telerik.Web.UI.Editor.Modules.RadEditorHtmlInspector.prototype={initialize:function(){
this._onSelectionChangedDelegate=Function.createDelegate(this,this._onSelectionChanged);
this._intervalDelegate=Function.createDelegate(this,this.updateEditorContent);
this._textarea=null;
Telerik.Web.UI.Editor.Modules.RadEditorHtmlInspector.callBaseMethod(this,"initialize");
},dispose:function(){
if(this._textarea){
this._textarea.value="";
}
this._clearInterval();
Telerik.Web.UI.Editor.Modules.RadEditorHtmlInspector.callBaseMethod(this,"dispose");
},_clearInterval:function(){
if(this._interval){
window.clearInterval(this._interval);
}
},set_visible:function(_56){
Telerik.Web.UI.Editor.Modules.RadEditorHtmlInspector.callBaseMethod(this,"set_visible",[_56]);
if(_56){
this._interval=window.setInterval(this._intervalDelegate,4000);
this._onSelectionChanged();
}else{
this._clearInterval();
}
},render:function(){
Telerik.Web.UI.Editor.Modules.RadEditorHtmlInspector.callBaseMethod(this,"render");
var _57=document.createElement("TEXTAREA");
_57.style.width="99%";
_57.className="rade_textarea";
_57.setAttribute("rows","10");
_57.setAttribute("cols","80");
this._textarea=_57;
if(!this.isIE){
_57.onclick=new Function("this.focus();");
}
var _58=this.get_element();
_58.appendChild(_57);
this.get_editor().add_selectionChange(this._onSelectionChangedDelegate);
},updateEditorContent:function(){
if(!this.get_visible()){
return;
}
var _59=this._textarea.value;
var _5a=this.get_editor().get_document().body.innerHTML;
if(_59==this._oldContent||_59==_5a){
return;
}
this._oldContent=_59;
this._updateFlag=true;
this.get_editor().set_html(_59,this._getLocalizedString("Typing"),false);
this._textarea.focus();
},_onSelectionChanged:function(){
if(this._updateFlag){
this._updateFlag=false;
return;
}
this._textarea.value=this.get_editor().get_document().body.innerHTML;
}};
Telerik.Web.UI.Editor.Modules.RadEditorHtmlInspector.registerClass("Telerik.Web.UI.Editor.Modules.RadEditorHtmlInspector",Telerik.Web.UI.Editor.Modules.ModuleBase);
Telerik.Web.UI.Editor.Modules.RadEditorNodeInspector=function(_5b){
Telerik.Web.UI.Editor.Modules.RadEditorNodeInspector.initializeBase(this,[_5b]);
this._updateMainPanelDelegate=Function.createDelegate(this,this._updateMainPanel);
this._onToolValueSelectedDelegate=Function.createDelegate(this,this._onToolValueSelected);
this._onDropDownBeforeShowDelegate=Function.createDelegate(this,this._onDropDownBeforeShow);
this._tools={};
this._toolNames={};
this._selectedElement=null;
};
Telerik.Web.UI.Editor.Modules.RadEditorNodeInspector.prototype={_nodeAttributesArray:{TABLE:["width","cellSpacing","bgColor","className","SetTableProperties","height","cellPadding","align","border"],TH:["width","bgColor","className","SetCellProperties","height","align","noWrap"],TD:["width","bgColor","className","SetCellProperties","height","align","noWrap"],TR:["width","className","height"],A:["href","className","LinkManager","title","target"],IMG:["width","borderColor","className","SetImageProperties","height","align","border","alt"],INPUT:["NAME","width","height","id","title","value","className"],FORM:["className","width","height","NAME","action","id"],TEXTAREA:["className","width","height","NAME","id","rows","cols"]},_nodeInspectorAttributesArray:[["rows","NAME","width","cellSpacing","align","href","value","className","SetTableProperties","SetCellProperties","LinkManager","SetImageProperties"],["cols","id","height","action","cellPadding","borderColor","bgColor","border","alt","noWrap","title","target"]],initialize:function(){
Telerik.Web.UI.Editor.Modules.RadEditorNodeInspector.callBaseMethod(this,"initialize");
this.get_editor().add_selectionChange(this._updateMainPanelDelegate);
this._invalidValueString=this._getLocalizedString("NodeInspectorInvalidValue","Invalid value. Please enter a number.");
},render:function(){
Telerik.Web.UI.Editor.Modules.RadEditorNodeInspector.callBaseMethod(this,"render");
var _5c=this.get_element();
_5c.style.height="62px";
},get_skin:function(){
return this._editor.get_skin();
},getNamedCssForSelectedElement:function(_5d){
return this.get_editor().getCssArray(_5d);
},dispose:function(){
this._tools=[];
this._mainPanel=null;
Telerik.Web.UI.Editor.Modules.RadEditorNodeInspector.callBaseMethod(this,"dispose");
},_createMainPanel:function(){
var _5e=this._tools;
var _5f=this._toolNames;
var _60=this._nodeInspectorAttributesArray;
var _61=document.createElement("TABLE");
_61.border=0;
_61.cellSpacing=0;
_61.cellPadding=0;
for(var _62=0;_62<_60.length;_62++){
var _63=_60[_62];
var _64=_61.insertRow(-1);
for(var i=0;i<_63.length;i++){
var _66=_63[i];
var _67=_64.insertCell(-1);
_67.style.display="none";
_67.setAttribute("controlName",_66);
_67.innerHTML=this._getLocalizedString(_66,_66)+":";
_67.style.verticalAlign="middle";
_67.align="right";
_67.vAlign="middle";
_67.style.paddingLeft="4px";
_67.style.paddingRight="2px";
_67=_64.insertCell(-1);
_67.style.display="none";
_67.setAttribute("controlHolder",_66);
var _68=this._getControlByName(_66);
if(_68){
_5e[_66]=_68;
var _69=_68.get_element();
if(_69.tagName=="LI"){
var _69=Telerik.Web.UI.EditorButton.createToolWrapper(_68,this.get_skin());
}
_67.appendChild(_69);
}
}
}
return _61;
},_updateMainPanel:function(){
if(!this.get_visible()){
return;
}
if(!this._isMainCreated){
this._mainPanel=this._createMainPanel();
this._mainPanel.style.display="none";
this.get_element().appendChild(this._mainPanel);
this._isMainCreated=true;
}
var _6a=this.get_editor();
var _6b=_6a.getSelectedElement();
if(!_6b||_6b.tagName=="BODY"||_6b.ownerDocument!=_6a.get_document()){
this._mainPanel.style.display="none";
return;
}
if(_6b.tagName=="TBODY"&&this.isOpera){
_6b=_6b.parentNode;
}
var _6c=this._nodeAttributesArray[_6b.tagName];
if(!_6c){
var _6d=Telerik.Web.UI.Editor.Utils.getElementParentByTag(_6b,"A");
if(!_6d){
_6d=Telerik.Web.UI.Editor.Utils.getElementParentByTag(_6b,"TD");
}
if(!_6d){
_6d=Telerik.Web.UI.Editor.Utils.getElementParentByTag(_6b,"TH");
}
if(_6d){
_6b=_6d;
}else{
this._mainPanel.style.display="none";
return;
}
}
var _6e=null;
if(this._selectedElement){
try{
_6e=this._selectedElement.tagName;
}
catch(e){
}
}
if(!this._selectedElement||(_6e!=_6b.tagName)){
var _6f=this.get_editor().get_document();
this._tools["align"].setTagName(_6b.tagName);
}
this._selectedElement=_6b;
this._updateControlValues(this._selectedElement);
this._mainPanel.style.display="";
},_arrayValueExists:function(_70,_71){
return Array.contains(_71,_70);
},_issValidAttribValue:function(_72){
if(null==_72){
return false;
}
_72=_72.trim();
if(""==_72){
return true;
}
var _73=parseInt(_72);
if(isNaN(_73)){
return false;
}
return true;
},_onDropDownBeforeShow:function(_74,_75){
var _76=this.get_editor();
var _77=_74.get_name();
var _78=_74.get_items();
if(_78&&_78.length>0){
return;
}
var _79=null;
switch(_77){
case "className":
var _7a=this._selectedElement;
var _7b=_7a&&_7a.tagName?_7a.tagName:"";
_79=_76.getCssArray(_7b);
break;
case "target":
_79=[["_blank",this._getLocalizedString("blank","New Window")],["_self",this._getLocalizedString("self","Same Window")],["_parent",this._getLocalizedString("parent","Parent window")],["_top",this._getLocalizedString("top","Top browser window")],["_search",this._getLocalizedString("search","Search pane")],["_media",this._getLocalizedString("media","Media pane")]];
break;
case "bgColor":
case "borderColor":
_79=_76.get_colors();
break;
}
if(_79){
_74.set_items(_79);
}
},_onToolValueSelected:function(_7c,_7d){
if(_7c){
if(Telerik.Web.UI.EditorDropDown.isInstanceOfType(_7c)||Telerik.Web.UI.EditorSpinBox.isInstanceOfType(_7c)||Telerik.Web.UI.EditorCheckBox.isInstanceOfType(_7c)||Telerik.Web.UI.EditorTextBox.isInstanceOfType(_7c)){
this.fire(_7c);
}else{
this.get_editor().fire(_7c.get_name());
}
}
},executeStyleRuleCommand:function(_7e,_7f,_80,_81){
var _82=this.get_editor();
var _83=new Telerik.Web.UI.Editor.StyleRuleCommand(_81,_82.get_contentWindow(),_7e,_7f,_80);
_82.executeCommand(_83);
},executeAttributeCommand:function(_84,_85,_86,_87){
var _88=this.get_editor();
var _89=new Telerik.Web.UI.Editor.AttributeCommand(_87,_88.get_contentWindow(),_84,_85,_86);
_88.executeCommand(_89);
},_updateControlValues:function(_8a){
var _8b=this._nodeAttributesArray[_8a.tagName];
var _8c=this._mainPanel;
var _8d=this._tools;
for(var _8e=0;_8e<_8c.rows.length;_8e++){
var _8f=_8c.rows[_8e];
for(var i=0;i<_8f.cells.length;i++){
var _91=_8f.cells[i];
var _92=_91.getAttribute("controlName");
if(_92){
_91.style.display=this._arrayValueExists(_92,_8b)?"":"none";
}
var _93=_91.getAttribute("controlHolder");
if(_93){
_91.style.display=this._arrayValueExists(_93,_8b)?"":"none";
if("none"==_91.style.display){
continue;
}
var _94=_8d[_93];
var _95=_8a.getAttribute?_8a.getAttribute(_93,2):"";
if(_93=="noWrap"){
_94.set_value(_8a.noWrap);
}else{
if(_93=="borderColor"||_93=="bgColor"){
var _96=_8a.style[_93];
if(!_96){
_96=_8a.getAttribute(_93);
}
_94.set_color(_96);
}else{
if(_93=="align"){
_94.updateValue(_8a.getAttribute("align"),_8a.getAttribute("vAlign"));
}else{
if(_93=="target"){
var _96=_8a.getAttribute(_93);
_94.updateValue(_96);
}else{
if(_93=="width"||_93=="height"){
var _96=_8a.style[_93];
if(!_96){
_96=_8a.getAttribute(_93);
}
_94.set_value(_96);
}else{
if("name"==_93.toLowerCase()){
_94.set_value(_8a.name);
}else{
if("className"==_93){
if(!this.isIE){
_95=_8a.getAttribute("class");
}
if(!_95){
_95="";
}
_94.updateValue(_95);
}else{
if(_95&&_94.set_value){
_94.set_value(_95);
}else{
if(_94.set_value){
_94.set_value("");
}
}
}
}
}
}
}
}
}
}
}
}
},fire:function(_97){
if(!_97){
return;
}
var _98=_97.get_name();
var _99=this.get_editor();
var _9a=this._getLocalizedString(_98,_98);
var _9b=this._selectedElement;
if("AlignmentSelector"==_98){
var _9c=_97.getAlign();
var _9d=_97.getVAlign();
this.executeAttributeCommand(_9b,"align",_9c,_9a);
_9a=this._getLocalizedString("vAlign","vAlign");
this.executeAttributeCommand(_9b,"vAlign",_9d,_9a);
}else{
if("borderColor"==_98){
var _9e=_97.get_selectedItem();
this.executeStyleRuleCommand(this._selectedElement,"borderColor",_9e,_9a);
}else{
if("width"==_98||"height"==_98){
var _9e=_97.get_selectedItem();
if(!this._issValidAttribValue(_9e)){
alert(this._invalidValueString);
return;
}
function ConvertIntToPixel(_9f){
var _a0=""+_9f;
if(_a0.indexOf("%")!=-1){
return _a0;
}else{
_a0=parseInt(_a0);
if(!isNaN(_a0)){
_a0=_a0+"px";
return _a0;
}
}
return _9f;
}
_9e=ConvertIntToPixel(_9e);
if(this._selectedElement.removeAttribute){
this._selectedElement.removeAttribute(_98);
}
this.executeStyleRuleCommand(this._selectedElement,_98,_9e,_9a);
}else{
var _a1=_98;
var _a2=_97.get_selectedItem();
switch(_98){
case "bgColor":
case "background":
case "className":
case "target":
case "value":
break;
case "noWrap":
if(_a2){
_a2="noWrap";
}else{
_a2="";
}
break;
case "border":
case "cellSpacing":
case "cellPadding":
if(!this._issValidAttribValue(_a2)){
alert(this._invalidValueString);
return;
}
break;
case "NAME":
if(!this.isIE){
_a1="name";
}
}
this.executeAttributeCommand(_9b,_a1,_a2,_9a);
}
}
}
if(this._selectedElement){
this._updateControlValues(this._selectedElement);
}
},_getControlByName:function(_a3){
var _a4=null;
var _a5={text:this._getLocalizedString(_a3),name:_a3,addClickHandler:true,skin:this.get_skin()};
var _a6={"valueSelected":this._onToolValueSelectedDelegate,"show":this._onDropDownBeforeShowDelegate};
switch(_a3){
case "className":
_a5["text"]=this._getLocalizedString("className");
_a4=Telerik.Web.UI.EditorButton.createTool(_a5,_a6,Telerik.Web.UI.Editor.ApplyClassDropDown);
break;
case "borderColor":
case "bgColor":
_a4=Telerik.Web.UI.EditorButton.createTool(_a5,_a6,Telerik.Web.UI.Editor.ColorPicker);
break;
case "align":
_a5["name"]="AlignmentSelector";
_a5["text"]=this._getLocalizedString("align");
_a4=Telerik.Web.UI.EditorButton.createTool(_a5,_a6,Telerik.Web.UI.Editor.AlignmentSelector);
break;
case "SetCellProperties":
case "SetTableProperties":
case "SetImageProperties":
case "LinkManager":
delete _a6.show;
_a4=Telerik.Web.UI.EditorButton.createTool(_a5,_a6);
break;
case "target":
_a5["sizetofit"]=true;
_a4=Telerik.Web.UI.EditorButton.createTool(_a5,_a6,Telerik.Web.UI.EditorUpdateableDropDown);
break;
case "noWrap":
delete _a6.show;
_a4=Telerik.Web.UI.EditorButton.createTool(_a5,_a6,Telerik.Web.UI.EditorCheckBox,document.createElement("span"));
break;
case "width":
case "height":
case "cellPadding":
case "cellSpacing":
case "rows":
case "cols":
case "border":
delete _a6.show;
_a4=Telerik.Web.UI.EditorButton.createTool(_a5,_a6,Telerik.Web.UI.EditorSpinBox,document.createElement("span"));
break;
default:
delete _a6.show;
if(_a3=="href"){
_a5["width"]="170px";
}
_a4=Telerik.Web.UI.EditorButton.createTool(_a5,_a6,Telerik.Web.UI.EditorTextBox,document.createElement("span"));
}
return _a4;
}};
Telerik.Web.UI.Editor.Modules.RadEditorNodeInspector.registerClass("Telerik.Web.UI.Editor.Modules.RadEditorNodeInspector",Telerik.Web.UI.Editor.Modules.ModuleBase);
Telerik.Web.UI.Editor.Modules.RadEditorStatistics=function(_a7){
Telerik.Web.UI.Editor.Modules.RadEditorStatistics.initializeBase(this,[_a7]);
};
Telerik.Web.UI.Editor.Modules.RadEditorStatistics.prototype={initialize:function(){
this._enableMaxWidth=false;
this._wordsString=this._getLocalizedString("StatisticsWords","Words:");
this._charactersString=this._getLocalizedString("StatisticsCharacters","Characters:");
this._onDoCountDelegate=Function.createDelegate(this,this.doCount);
Telerik.Web.UI.Editor.Modules.RadEditorStatistics.callBaseMethod(this,"initialize");
},render:function(){
Telerik.Web.UI.Editor.Modules.RadEditorStatistics.callBaseMethod(this,"render");
this.get_editor().add_selectionChange(this._onDoCountDelegate);
this.doCount();
},doCount:function(){
if(!this.get_visible()){
return;
}
var _a8=this.get_editor().get_text();
var _a9=0;
var _aa=0;
if(_a8){
var _ab=/[!\.?;,:&_\-\�\{\}\[\]\(\)~#'"]/g;
_a8=_a8.replace(_ab,"");
var _ac=/(^\s+)|(\s+$)/g;
_a8=_a8.replace(_ac,"");
if(_a8){
splitRegX=/\s+/;
var _ad=_a8.split(splitRegX);
_a9=_ad.length;
var _ae=/(\r\n)+/g;
_a8=_a8.replace(_ae,"");
_aa=_a8.length;
}
}
var _af=this.get_element();
_af.innerHTML="<span style='line-height:22px'>"+this._wordsString+" "+_a9+" "+this._charactersString+" "+_aa+"&nbsp;</span>";
}};
Telerik.Web.UI.Editor.Modules.RadEditorStatistics.registerClass("Telerik.Web.UI.Editor.Modules.RadEditorStatistics",Telerik.Web.UI.Editor.Modules.ModuleBase);

