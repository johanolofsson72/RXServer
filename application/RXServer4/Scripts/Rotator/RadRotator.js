Type.registerNamespace("Telerik.Web.UI");
Telerik.Web.UI.RadRotator=function(_1){
Telerik.Web.UI.RadRotator.initializeBase(this,[_1]);
this._skin="Default";
this._postBackReference=null;
this._items=null;
this._webServiceSettings=new Telerik.Web.UI.WebServiceSettings({});
this._webServiceLoader=null;
this._containerElement=null;
this._clickDelegate=null;
this._mouseOutDelegate=null;
this._mouseOverDelegate=null;
this._useRandomSlide=false;
this._transitionEffect=null;
this._pauseOnMouseOver=true;
var _2=Telerik.Web.UI.RotatorScrollDirection;
this._scrollDirection=_2.Left+_2.Right;
this._slideShowAnimationSettings={};
this._rotatorType=Telerik.Web.UI.RotatorType.AutomaticAdvance;
this._scrollDuration=500;
this._frameDuration=2000;
this._initialItemIndex=0;
this._wrapFrames=true;
this._controlButtons={};
this._relativeWrapper=null;
this._clipElement=null;
this._itemsElement=null;
this._animationDirection=_2.Left;
this._rightButton=null;
this._leftButton=null;
this._downButton=null;
this._upButton=null;
};
Telerik.Web.UI.RadRotator.prototype={initialize:function(){
Telerik.Web.UI.RadRotator.callBaseMethod(this,"initialize");
this._createUI();
this._createChildItems();
this._attachEvents(true);
this._loadInitialFrame();
this._enableDisableButtons();
if(this.isAutomaticAdvance()){
var _3=this.get_frameDuration();
if(_3>0){
window.setTimeout(Function.createDelegate(this,this.startAutoPlay),_3);
}else{
this.startAutoPlay();
}
}
},dispose:function(){
this._attachEvents(false);
this._containerElement=null;
if(this._animation){
this._animation.dispose();
this._animation=null;
}
if(this._slideShowAnimation){
this._slideShowAnimation.dispose();
this._slideShowAnimation=null;
}
if(this._rightButton){
$clearHandlers(this._rightButton);
}
if(this._leftButton){
$clearHandlers(this._leftButton);
}
if(this._downButton){
$clearHandlers(this._downButton);
}
if(this._upButton){
$clearHandlers(this._upButton);
}
Telerik.Web.UI.RadRotator.callBaseMethod(this,"dispose");
},_createChildItems:function(){
var _4=$telerik.getChildrenByTagName(this.get_containerElement(),"li");
for(var i=0;i<_4.length;i++){
var _6=$create(Telerik.Web.UI.RadRotatorItem,this.get_items()[i],null,null,_4[i]);
var _7=_6.get_index();
_4[i]._item=_6;
this.get_items()[i]=_6;
}
},_getNextItemToShow:function(){
var _8=this.getItemHtmlElements();
var _9=this.isScrollingForward();
if(this._nextItemIndex==null){
var _a=_9?0:_8.length-1;
this._nextItemIndex=_a;
}
if(this._nextItemIndex<0){
return null;
}
var li=_8[this._nextItemIndex];
if(_9){
this._nextItemIndex++;
}else{
this._nextItemIndex--;
}
if(this._nextItemIndex>_8.length-1||this._nextItemIndex<0){
this._nextItemIndex=null;
}
return li;
},get_currentItem:function(){
var _c=this._currentItem;
if(!_c){
var _d=this._itemsElement;
var _e=this.getItemHtmlElements();
_c=this.isScrollingForward()?_e[0]:_e[_e.length-1];
}
return _c;
},_needsShift:function(_f){
if(null==_f){
_f=this._animationDirection;
}
var _10=this._itemsElement;
var _11=this._clipElement;
var _12=parseInt(_10.style.left);
var _13=parseInt(_10.style.top);
var _14=$telerik.getOuterSize(_10);
var _15=$telerik.getContentSize(_11);
var _16=this.get_currentItem();
var _17=$telerik.getOuterSize(_16);
var _18=false;
var _19=Telerik.Web.UI.RotatorScrollDirection;
switch(_f){
case _19.Left:
_18=_12+_14.width<=_15.width+_17.width;
break;
case _19.Up:
_18=_13+_14.height<=_15.height+_17.height;
break;
case _19.Right:
_18=_12*-1<=_17.width;
break;
case _19.Down:
_18=_13*-1<=_15.height;
break;
}
return _18;
},_getMoveAnimation:function(){
if(this._animation){
return this._animation;
}
var _1a=this._itemsElement;
var _1b=this._getCalculatedAnimationDuration();
var fps=25;
this._animation=new Telerik.Web.Animation.MoveAnimation(_1a,_1b,fps,true,false,false,"px");
function returnZeroPixels(_1d,end,_1f){
return 0;
}
if(this.get_vertical()){
this._animation._horizontalAnimation.interpolate=returnZeroPixels;
}else{
this._animation._verticalAnimation.interpolate=returnZeroPixels;
}
return this._animation;
},scrollViewport:function(){
var _20=this._itemsElement;
if(!this._animation){
var _21=this._getMoveAnimation();
var _22=Function.createDelegate(this,function(){
var _23=this._hasViewportWidth();
if(!_23&&this.get_wrapFrames()){
var _24=this.getItemHtmlElements().length;
for(var i=0;i<_24;i++){
this._shiftItemInList();
_23=this._hasViewportWidth();
if(_23){
break;
}
}
}
var _26=this._getViewPortPixelsToScroll();
var _27=this.isScrollingForward();
if(this.get_vertical()){
var _28=parseInt(_20.style.top)+(_27?-_26:_26);
_21.set_vertical(_28);
}else{
var _28=parseInt(_20.style.left)+(_27?-_26:_26);
_21.set_horizontal(_28);
}
});
_21.add_started(Function.createDelegate(this,function(){
this.stopViewportAnimation();
var _29=null;
var _2a=new Telerik.Web.UI.RadRotatorCancelEventArgs(_29);
this.raiseEvent("itemShowing",_2a);
if(_2a.get_cancel&&_2a.get_cancel()){
return false;
}
if(this.isSlideShow()){
_20.style.visibility="hidden";
}
_22();
}));
_21.add_ended(Function.createDelegate(this,function(){
this._enableDisableButtons();
if(this.isSlideShow()){
_20.style.visibility="visible";
this.runSlideShowAnimation();
}else{
var _2b=null;
this.raiseEvent("itemShown",new Telerik.Web.UI.RadRotatorEventArgs(_2b));
}
}));
}
this._animation.play();
},scrollItem:function(){
var _2c=this._clipElement;
var _2d=this._itemsElement;
if(!this._animation){
this._animation=this._getMoveAnimation();
var _2e=this._animation;
var _2f=Function.createDelegate(this,function(){
var _30=this._getNextItemToShow();
this._currentItem=_30;
var _31=$telerik.getOuterSize(_30);
if(this.isScrollingForward()){
_31.width*=-1;
_31.height*=-1;
}
if(this.get_vertical()){
var _32=parseInt(_2d.style.top)+_31.height;
_2e.set_vertical(_32);
}else{
var _32=parseInt(_2d.style.left)+_31.width;
_2e.set_horizontal(_32);
}
});
_2e.add_started(Function.createDelegate(this,function(){
var _33=null;
var _34=new Telerik.Web.UI.RadRotatorCancelEventArgs(_33);
this.raiseEvent("itemShowing",_34);
if(_34.get_cancel&&_34.get_cancel()){
return false;
}
var _35=this._needsShift();
if(_35){
this._shiftItemInList();
}
if(this._stopAnimationButtonOver){
return;
}
_2f();
}));
_2e.add_ended(Function.createDelegate(this,function(){
var _36=null;
this.raiseEvent("itemShown",new Telerik.Web.UI.RadRotatorEventArgs(_36));
if(this._stopAnimationButtonOver){
return;
}
if(this.get_frameDuration()>0){
this.pause(this.get_frameDuration());
}else{
this._animation.play();
}
}));
}
this._animation.stop();
this._animation.play();
},_shiftItemInList:function(){
var _37=this._itemsElement;
var lis=this.getItemHtmlElements();
var _39=this.get_vertical();
var _3a=this.isScrollingForward();
var _3b=parseInt(_37.style.left);
var _3c=parseInt(_37.style.top);
var _3d=_3a?lis[0]:lis[lis.length-1];
var _3e=$telerik.getOuterSize(_3d);
_3d.parentNode.removeChild(_3d);
if(!_3a){
_37.insertBefore(_3d,_37.firstChild);
}
if(_39){
_37.style.top=(_3c+(_3a?_3e.height:-_3e.height))+"px";
}else{
_37.style.left=(_3b+(_3a?_3e.width:-_3e.width))+"px";
}
if(_3a){
_37.appendChild(_3d);
}
this._nextItemIndex=_3a?lis.length-1:0;
return _3d;
},_loadInitialFrame:function(){
var _3f=this.get_initialItemIndex();
var _40=this._animationDirection;
var _41=Telerik.Web.UI.RotatorScrollDirection;
var _42=this.isVertical();
var _43=this._itemsElement;
var _44=$telerik.getOuterSize(_43);
var _45=$telerik.getContentSize(this._clipElement);
var x=0;
var y=0;
if(_3f==0){
if(_42){
y=(_40==_41.Up)?0:-_44.height+_45.height;
}else{
x=(_40==_41.Left)?0:-_44.width+_45.width;
}
}else{
if(_3f==-1){
if(_42){
y=(_40==_41.Down)?-_44.height:_45.height;
}else{
x=(_40==_41.Right)?-_44.width:_45.width;
}
}else{
}
}
_43.style.left=x+"px";
_43.style.top=y+"px";
},pause:function(_48){
this._clearAnimationTimeout();
if(this._animation){
this._animation.pause();
}
if(_48){
this._setAnimationTimeout(_48);
}
},resume:function(){
this._clearAnimationTimeout();
if(this._animation){
this._animation.play();
}
},isViewportScrollMode:function(){
var _49=Telerik.Web.UI.RotatorType;
if(this._isRotatorTypeEnabled(_49.AutomaticAdvance)||this._isRotatorTypeEnabled(_49.ButtonsOver)){
return false;
}
return true;
},_getButtonScrollDirection:function(_4a){
var _4b=Telerik.Web.UI.RotatorScrollDirection;
var _4c=_4b.Left;
switch(_4a){
case this._rightButton:
_4c=_4b.Left;
break;
case this._leftButton:
_4c=_4b.Right;
break;
case this._downButton:
_4c=_4b.Up;
break;
case this._upButton:
_4c=_4b.Down;
break;
}
return _4c;
},_buttonClicked:function(e){
var _4e=e.target;
if(this._isButtonDisabled(_4e)){
return;
}
var _4f=this._getButtonScrollDirection(_4e);
this.set_animationDirection(_4f);
this.scrollViewport();
return $telerik.cancelRawEvent(e);
},_buttonOver:function(e){
var _51=e.target;
if(this._isButtonDisabled(_51)){
return;
}
var _52=this._getButtonScrollDirection(_51);
this.set_animationDirection(_52);
this._stopAnimationButtonOver=false;
this.scrollItem();
return $telerik.cancelRawEvent(e);
},_buttonOut:function(e){
var _54=e.target;
if(this._isButtonDisabled(_54)){
return;
}
var _55=this._getButtonScrollDirection(_54);
this.set_animationDirection(_55);
this._stopAnimationButtonOver=true;
return $telerik.cancelRawEvent(e);
},_initializeButtonsRotatorType:function(){
var _56=this.get_controlButtons();
this._rightButton=$telerik.getElementsByClassName(this._rotatorRightClass,this._rootElement)[0];
this._leftButton=$telerik.getElementsByClassName(this._rotatorLeftClass,this._rootElement)[0];
this._downButton=$telerik.getElementsByClassName(this._rotatorDownClass,this._rootElement)[0];
this._upButton=$telerik.getElementsByClassName(this._rotatorUpClass,this._rootElement)[0];
var _57=Telerik.Web.UI.RotatorScrollDirection;
var _58=[_57.Right,_57.Left,_57.Down,_57.Up];
var _59=[this._leftButton,this._rightButton,this._upButton,this._downButton];
var _5a=[_56.LeftButtonID?$get(_56.LeftButtonID):null,_56.RightButtonID?$get(_56.RightButtonID):null,_56.UpButtonID?$get(_56.UpButtonID):null,_56.DownButtonID?$get(_56.DownButtonID):null];
var _5b=[this._rotatorLeftClass,this._rotatorRightClass,this._rotatorUpClass,this._rotatorDownClass];
var _5c=["marginLeft","marginRight","marginTop","marginBottom"];
var _5d=["paddingLeft","paddingRight","paddingTop","paddingBottom"];
var _5e=["width","width","height","height"];
var _5f=this._relativeWrapper;
var _60=this.get_element();
for(var i=0;i<_59.length;i++){
var _62=_59[i];
var _63=(null!=_5a[i])?_5a[i]:_62;
this._createButton(_62,_5b[i]);
if(this._isScrollDirectionEnabled(_58[i])&&null==_5a[i]){
_62.style.display="block";
var _64=_5e[i];
var _65=parseInt($telerik.getCurrentStyle(_62,_64));
_5f.style[_64]=(parseInt(_5f.style[_64])-_65)+"px";
_60.style[_64]=(parseInt(_60.style[_64])-_65)+"px";
_60.style[_5d[i]]=_65+"px";
}
if(this._isRotatorTypeEnabled(Telerik.Web.UI.RotatorType.Buttons)||this._isRotatorTypeEnabled(Telerik.Web.UI.RotatorType.SlideShowButtons)){
$addHandlers(_63,{"click":this._buttonClicked},this);
}else{
$addHandlers(_63,{"mouseover":this._buttonOver,"mouseout":this._buttonOut},this);
}
}
this._rightButton=_5a[1]||this._rightButton;
this._leftButton=_5a[0]||this._leftButton;
this._downButton=_5a[3]||this._downButton;
this._upButton=_5a[2]||this._upButton;
var _66=false;
for(var i=0;i<_5a.length;i++){
if(_5a[i]){
_66=true;
}
break;
}
return _66;
},runSlideShowAnimation:function(){
if(!this._slideShowAnimation){
var _67=this._itemsElement;
var _68=this.get_slideShowAnimationSettings().duration||500;
_68=_68/1000;
var _69=this.get_slideShowAnimationSettings().type||Telerik.Web.UI.RotatorAnimationType.None;
var _6a=Function.createDelegate(this,function(){
var _6b=null;
this.raiseEvent("itemShown",new Telerik.Web.UI.RadRotatorEventArgs(_6b));
if(this.get_frameDuration()>0&&this.isAutomaticAdvance()){
this.pause(this.get_frameDuration());
}
});
switch(_69){
case Telerik.Web.UI.RotatorAnimationType.Fade:
this._slideShowAnimation=new Telerik.Web.Animation.FadeInAnimation(_67,_68);
this._slideShowAnimation.add_ended(_6a);
break;
case Telerik.Web.UI.RotatorAnimationType.Pulse:
this._slideShowAnimation=new Telerik.Web.Animation.PulseAnimation(_67,null);
this._slideShowAnimation.set_iterations(1);
this._slideShowAnimation.set_duration(_68);
this._slideShowAnimation.add_ended(_6a);
break;
case Telerik.Web.UI.RotatorAnimationType.Pulse:
default:
this._slideShowAnimation={};
this._slideShowAnimation.play=_6a;
this._slideShowAnimation.dispose=function(){
};
break;
}
}
this._slideShowAnimation.play();
},_hasViewportWidth:function(_6c){
if(null==_6c){
_6c=this._animationDirection;
}
var _6d=this._itemsElement;
var _6e=this._clipElement;
var _6f=parseInt(_6d.style.left);
var _70=parseInt(_6d.style.top);
var _71=$telerik.getOuterSize(_6d);
var _72=$telerik.getContentSize(_6e);
var _73=false;
var _74=Telerik.Web.UI.RotatorScrollDirection;
switch(_6c){
case _74.Left:
_73=_71.width+_6f>=_72.width*2;
break;
case _74.Up:
_73=_71.height+_70>=_72.height*2;
break;
case _74.Right:
_73=(_6f*-1>=_72.width);
break;
case _74.Down:
_73=(_70*-1>=_72.height);
break;
}
return _73;
},stopViewportAnimation:function(){
var _75=this._animation;
if(!_75){
return;
}
if(_75.get_isPlaying()){
_75.stop();
var _76=this.get_vertical();
var _77=_76?_75.get_vertical():_75.get_horizontal();
if(null!=_77){
this._itemsElement.style[_76?"top":"left"]=_77+"px";
}
}
},_getViewPortPixelsToScroll:function(){
var _78=this.get_vertical();
var _79=$telerik.getContentSize(this._clipElement);
var _7a=_78?_79.height:_79.width;
return _7a;
},showNext:function(_7b){
this.set_animationDirection(_7b);
if(this.isViewportScrollMode()){
this.scrollViewport();
}else{
this.scrollItem();
}
},getItemHtmlElements:function(){
var _7c=this._itemsElement;
if(!this._hasCleanedList){
var _7d=_7c.childNodes;
for(var i=0;i<_7d.length;i++){
var _7f=_7d[i];
if(_7f&&_7f.tagName!="LI"){
_7c.removeChild(_7f);
i--;
}
}
this._hasCleanedList=true;
}
return _7c.childNodes;
},_getCalculatedAnimationDuration:function(_80){
var _81=this.get_scrollDuration()/1000;
return _81;
},_setAnimationTimeout:function(_82){
this._clearAnimationTimeout();
this._currentAnimationTimeout=window.setTimeout(Function.createDelegate(this,this.resume),_82);
},_clearAnimationTimeout:function(){
if(this._currentAnimationTimeout){
window.clearTimeout(this._currentAnimationTimeout);
}
this._currentAnimationTimeout=0;
},isAutomaticAdvance:function(){
var _83=Telerik.Web.UI.RotatorType;
if(this._isRotatorTypeEnabled(_83.AutomaticAdvance)||this._isRotatorTypeEnabled(_83.SlideShow)){
return true;
}
return false;
},isSlideShow:function(){
var _84=Telerik.Web.UI.RotatorType;
if(this._isRotatorTypeEnabled(_84.SlideShow)||this._isRotatorTypeEnabled(_84.SlideShowButtons)){
return true;
}
return false;
},isScrollingForward:function(){
return this.isScrollingLeft()||this.isScrollingUp();
},isScrollingLeft:function(){
return this._isAnimationDirectionOn(Telerik.Web.UI.RotatorScrollDirection.Left);
},isScrollingUp:function(){
return this._isAnimationDirectionOn(Telerik.Web.UI.RotatorScrollDirection.Up);
},_isAnimationDirectionOn:function(_85){
return _85==this._animationDirection?true:false;
},_enableDisableButtons:function(){
if(this._rotatorType==Telerik.Web.UI.RotatorType.AutomaticAdvance){
return;
}
var _86=this.get_wrapFrames();
var _87=Telerik.Web.UI.RotatorScrollDirection;
this._enableButton(this._rightButton,_86||this._canSlideMore(_87.Left));
this._enableButton(this._leftButton,_86||this._canSlideMore(_87.Right));
this._enableButton(this._downButton,_86||this._canSlideMore(_87.Up));
this._enableButton(this._upButton,_86||this._canSlideMore(_87.Down));
},_enableButton:function(_88,_89){
if(!_88){
return;
}
if(_89){
Sys.UI.DomElement.removeCssClass(_88,this._rotatorButtonDisabledClass);
_88.removeAttribute("disabled");
}else{
Sys.UI.DomElement.addCssClass(_88,this._rotatorButtonDisabledClass);
_88.setAttribute("disabled","disabled");
}
},_canSlideMore:function(_8a){
if(null==_8a){
_8a=this._animationDirection;
}
var _8b=false;
var _8c=this._itemsElement;
var _8d=this._clipElement;
var _8e=Telerik.Web.UI.RotatorScrollDirection;
var _8f=parseInt(_8c.style.left);
var _90=parseInt(_8c.style.top);
var _91=$telerik.getBounds(_8c);
var _92=$telerik.getBounds(_8d);
if(_8a==_8e.Left){
_8b=(_91.width+_8f)>_92.width;
}else{
if(_8a==_8e.Up){
_8b=(_91.height+_90)>_92.height;
}else{
if(_8a==_8e.Right){
_8b=(_8f<0);
}else{
if(_8a==_8e.Down){
_8b=(_90<0);
}
}
}
}
return _8b;
},_getCalculatedAnimationDirection:function(){
var _93=this._animationDirection;
var _94=Telerik.Web.UI.RotatorScrollDirection;
var _95=23;
switch(_93){
case _94.Left:
_95=21;
break;
case _94.Down:
_95=32;
break;
case _94.Up:
_95=12;
break;
default:
_95=23;
}
return _95;
},startAutoPlay:function(){
this._loadInitialFrame();
var _96=Telerik.Web.UI.RotatorScrollDirection;
var dir=0;
if(this._isScrollDirectionEnabled(_96.Left)){
dir=_96.Left;
}else{
if(this._isScrollDirectionEnabled(_96.Up)){
dir=_96.Up;
}else{
if(this._isScrollDirectionEnabled(_96.Right)){
dir=_96.Right;
}else{
if(this._isScrollDirectionEnabled(_96.Down)){
dir=_96.Down;
}
}
}
}
if(!dir){
dir=_96.Left;
}
this.showNext(dir);
},get_containerElement:function(){
return this._itemsElement;
},_createUI:function(){
this._rotatorListClass="radr_itemsList";
this._rotatorVerticalClass="radr_verticalList";
this._rotatorRelativeWrapperClass="radr_relativeWrapper";
this._rotatorClipRegionClass="radr_clipRegion";
this._rotatorRightClass="radr_buttonRight";
this._rotatorLeftClass="radr_buttonLeft";
this._rotatorDownClass="radr_buttonDown";
this._rotatorUpClass="radr_buttonUp";
this._rotatorButtonDisabledClass="radr_buttonDisabled";
this._rootElement=this.get_element();
this._relativeWrapper=$telerik.getElementsByClassName(this._rotatorRelativeWrapperClass,this._rootElement)[0];
this._clipElement=$telerik.getElementsByClassName(this._rotatorClipRegionClass,this._rootElement)[0];
this._itemsElement=$telerik.getElementsByClassName(this._rotatorListClass,this._rootElement)[0];
var _98=this.get_element();
var _99=this._relativeWrapper;
_99.style.height=_98.offsetHeight+"px";
_99.style.width=_98.offsetWidth+"px";
var _9a=true;
if(this._isRotatorTypeEnabled(Telerik.Web.UI.RotatorType.Buttons)||this._isRotatorTypeEnabled(Telerik.Web.UI.RotatorType.ButtonsOver)||this._isRotatorTypeEnabled(Telerik.Web.UI.RotatorType.SlideShowButtons)){
_9a=this._initializeButtonsRotatorType();
}
if(_9a){
Sys.UI.DomElement.addCssClass(_98,"radr_noBorder");
}
if(this.get_vertical()){
this.set_vertical(true);
}
this._relativeWrapper.style.overflow="auto";
var _9b=this._clipElement;
_9b.style.overflow="auto";
_9b.style.width="10000px";
_9b.style.height="10000px";
this._itemsElement.style.width=this.get_vertical()?this._relativeWrapper.style.width:this._itemsElement.offsetWidth+"px";
this._itemsElement.style.height=this._itemsElement.offsetHeight+"px";
this._relativeWrapper.style.overflow="";
_9b.style.width=this._relativeWrapper.style.width;
_9b.style.height=this._relativeWrapper.style.height;
_9b.style.overflow="hidden";
_9b.style.position="relative";
this._itemsElement.style.position="relative";
this.get_element().style.visibility="visible";
},_createButton:function(_9c,_9d){
var _9e=_9c;
if(!_9e){
_9e=document.createElement("div");
}
if(!_9e.className){
_9e.className=this._rotatorDownClass;
}
return _9e;
},_isButtonDisabled:function(_9f){
if(!_9f){
return true;
}
return Sys.UI.DomElement.containsCssClass(_9f,this._rotatorButtonDisabledClass);
},_isScrollDirectionEnabled:function(_a0){
return _a0&this._scrollDirection?true:false;
},_isRotatorTypeEnabled:function(_a1){
return _a1==this._rotatorType?true:false;
},get_rotatorType:function(){
return this._rotatorType;
},set_rotatorType:function(_a2){
this._rotatorType=_a2;
},get_wrapFrames:function(){
return this._wrapFrames;
},set_wrapFrames:function(_a3){
this._wrapFrames=_a3;
},get_scrollDuration:function(){
if(this.isSlideShow()){
return 1;
}else{
return this._scrollDuration;
}
},set_scrollDuration:function(_a4){
this._scrollDuration=_a4;
},set_vertical:function(_a5){
if(this._itemsElement){
Sys.UI.DomElement.addCssClass(this._itemsElement,this._rotatorVerticalClass);
}
},get_vertical:function(){
var _a6=Telerik.Web.UI.RotatorScrollDirection;
return (this._isScrollDirectionEnabled(_a6.Down)||this._isScrollDirectionEnabled(_a6.Up));
},isVertical:function(){
if(this._itemsElement){
return Sys.UI.DomElement.containsCssClass(this._itemsElement,this._rotatorVerticalClass);
}
return false;
},get_height:function(){
return this.get_element().style.height;
},set_height:function(_a7){
this.get_element().style.height=_a7;
},get_width:function(){
return this.get_element().style.width;
},set_width:function(_a8){
this.get_element().style.width=_a8;
},get_scrollDirection:function(){
return this._scrollDirection;
},set_scrollDirection:function(_a9){
this._scrollDirection=_a9;
},get_frameDuration:function(){
return this._frameDuration;
},set_frameDuration:function(_aa){
this._frameDuration=_aa;
},get_controlButtons:function(){
return this._controlButtons;
},set_controlButtons:function(_ab){
this._controlButtons=_ab;
},get_initialItemIndex:function(){
return this._initialItemIndex;
},set_initialItemIndex:function(_ac){
this._initialItemIndex=_ac;
},get_slideShowAnimationSettings:function(){
return this._slideShowAnimationSettings;
},set_slideShowAnimationSettings:function(_ad){
this._slideShowAnimationSettings=_ad;
},set_animationDirection:function(_ae){
this._animationDirection=_ae?_ae:Telerik.Web.UI.RotatorScrollDirection.Left;
},get_animationDirection:function(){
return this._animationDirection;
},_attachEvents:function(_af){
var _b0=this.get_containerElement();
if(null==_b0){
return;
}
if(_af!=false){
this._clickDelegate=Function.createDelegate(this,this._mouseClickHandler);
this._mouseOutDelegate=Function.createDelegate(this,this._mouseOutHandler);
this._mouseOverDelegate=Function.createDelegate(this,this._mouseOverHandler);
$addHandler(_b0,"mouseover",this._mouseOverDelegate);
$addHandler(_b0,"mouseout",this._mouseOutDelegate);
$addHandler(_b0,"click",this._clickDelegate);
}else{
$removeHandler(_b0,"mouseover",this._mouseOverDelegate);
$removeHandler(_b0,"mouseout",this._mouseOutDelegate);
$removeHandler(_b0,"click",this._clickDelegate);
this._clickDelegate=null;
this._mouseOutDelegate=null;
this._mouseOverDelegate=null;
}
},_mouseOverHandler:function(_b1){
if(!this.isAutomaticAdvance()){
return;
}
this.pause();
var _b2=this._getItemFromEvent(_b1.target);
if(null!=_b2){
this.raiseEvent("mouseOver",new Telerik.Web.UI.RadRotatorEventArgs(_b2));
}
},_mouseOutHandler:function(_b3){
if(!this.isAutomaticAdvance()){
return;
}
this.resume();
var _b4=this._getItemFromEvent(_b3.target);
if(null!=_b4){
this.raiseEvent("mouseOut",new Telerik.Web.UI.RadRotatorEventArgs(_b4));
}
},_mouseClickHandler:function(_b5){
var _b6=this._getItemFromEvent(_b5.target);
if(null!=_b6){
var _b7=new Telerik.Web.UI.RadRotatorCancelEventArgs(_b6);
this.raiseEvent("itemClicking",_b7);
if(_b7.get_cancel&&_b7.get_cancel()){
$telerik.cancelRawEvent(_b5.rawEvent);
return false;
}
window.setTimeout(Function.createDelegate(this,function(){
this.raiseEvent("itemClicked",new Telerik.Web.UI.RadRotatorEventArgs(_b6));
this._postback(_b6.get_index());
}),0);
}
},_postback:function(_b8){
if(!this._postBackReference){
return;
}
var _b9=this._postBackReference.replace("arguments",_b8);
eval(_b9);
},_getItemFromEvent:function(_ba){
var _bb=this.get_containerElement();
var _bc=null;
while(null!=_ba&&_ba!=_bb){
if(_ba.tagName.toLowerCase()=="li"&&null!=_ba._item&&Object.getTypeName(_ba._item)=="Telerik.Web.UI.RadRotatorItem"){
_bc=_ba._item;
}
_ba=_ba.parentNode;
}
return _bc;
},_initializeWebServiceLoader:function(){
this._webServiceLoader=new Telerik.Web.UI.WebServiceLoader(this.get_webServiceSettings());
this._webServiceLoader.add_loadingStarted(Function.createDelegate(this,this._onItemLoadingStarted));
this._webServiceLoader.add_loadingSuccess(Function.createDelegate(this,this._onItemLoadingSuccess));
this._webServiceLoader.add_loadingError(Function.createDelegate(this,this._onItemLoadingError));
},_loadChildrenFromWebService:function(_bd,_be){
if(!this._webServiceLoader){
this._initializeWebServiceLoader();
}
var _bf={itemIndex:_bd,itemCount:_be};
this._webServiceLoader.loadData(_bf,_bf);
},_onItemLoadingStarted:function(_c0,_c1){
},_onItemLoadingSuccess:function(_c2,_c3){
var _c4=_c3.get_data();
if(_c4&&_c4.length>0){
for(var i=0;i<_c4.length;i++){
this.createRotatorItem(_c4[i]);
}
}
},_onItemLoadingError:function(_c6,_c7){
var _c8=_c7.get_message();
alert(_c8);
},createRotatorItem:function(_c9){
var _ca=this.get_containerElement();
var _cb=_ca.ownerDocument.createElement("li");
_ca.appendChild(_cb);
_cb.innerHTML=_c9.Html;
var _cc={cssClass:_c9.CssClass,visible:_c9.Visible};
var _cd=$create(Telerik.Web.UI.RadRotatorItem,_cc,null,null,_cb);
_cb._item=_cd;
Array.add(this.get_items(),_cd);
},add_itemClicking:function(_ce){
this.get_events().addHandler("itemClicking",_ce);
},remove_itemClicking:function(_cf){
this.get_events().removeHandler("itemClicking",_cf);
},add_itemClicked:function(_d0){
this.get_events().addHandler("itemClicked",_d0);
},remove_itemClicked:function(_d1){
this.get_events().removeHandler("itemClicked",_d1);
},add_mouseOver:function(_d2){
this.get_events().addHandler("mouseOver",_d2);
},remove_mouseOver:function(_d3){
this.get_events().removeHandler("mouseOver",_d3);
},add_mouseOut:function(_d4){
this.get_events().addHandler("mouseOut",_d4);
},remove_mouseOut:function(_d5){
this.get_events().removeHandler("mouseOut",_d5);
},add_itemShowing:function(_d6){
this.get_events().addHandler("itemShowing",_d6);
},remove_itemShowing:function(_d7){
this.get_events().removeHandler("itemShowing",_d7);
},add_itemShown:function(_d8){
this.get_events().addHandler("itemShown",_d8);
},remove_itemShown:function(_d9){
this.get_events().removeHandler("itemShown",_d9);
},get_items:function(){
return this._items;
},set_items:function(_da){
this._items=_da;
},get_webServiceSettings:function(){
return this._webServiceSettings;
},set_webServiceSettings:function(_db){
var _dc=Sys.Serialization.JavaScriptSerializer.deserialize(_db);
this._webServiceSettings=new Telerik.Web.UI.WebServiceSettings(_dc);
},get_skin:function(){
return this._skin;
},set_skin:function(_dd){
this._skin=_dd;
}};
Telerik.Web.UI.RadRotator.registerClass("Telerik.Web.UI.RadRotator",Telerik.Web.UI.RadWebControl);
Telerik.Web.UI.RadRotatorEventArgs=function(_de){
Telerik.Web.UI.RadRotatorEventArgs.initializeBase(this);
this._item=_de;
};
Telerik.Web.UI.RadRotatorEventArgs.prototype={get_item:function(){
return this._item;
}};
Telerik.Web.UI.RadRotatorEventArgs.registerClass("Telerik.Web.UI.RadRotatorEventArgs",Sys.EventArgs);
Telerik.Web.UI.RadRotatorCancelEventArgs=function(_df){
Telerik.Web.UI.RadRotatorCancelEventArgs.initializeBase(this);
this._item=_df;
};
Telerik.Web.UI.RadRotatorCancelEventArgs.prototype={get_item:function(){
return this._item;
}};
Telerik.Web.UI.RadRotatorCancelEventArgs.registerClass("Telerik.Web.UI.RadRotatorCancelEventArgs",Sys.CancelEventArgs);
Telerik.Web.UI.RadRotatorItem=function(_e0){
Telerik.Web.UI.RadRotatorItem.initializeBase(this,[_e0]);
this._visible=null;
this._cssClass=null;
this._index=-1;
};
Telerik.Web.UI.RadRotatorItem.prototype={initialize:function(){
Telerik.Web.UI.RadRotatorItem.callBaseMethod(this,"initialize");
},dispose:function(){
Telerik.Web.UI.RadRotatorItem.callBaseMethod(this,"dispose");
},get_index:function(){
if(this._index==-1){
var _e1=0;
var _e2=this.get_element();
var _e3=_e2.parentNode;
if(null!=_e3){
var _e4=$telerik.getChildrenByTagName(_e3,"li");
if(null!=_e4){
for(_e1=0;_e1<_e4.length&&_e4[_e1]!=_e2;_e1++){
}
if(_e1==_e4.length){
_e1=0;
}
}
}
this._index=_e1;
}
return this._index;
},get_visible:function(){
return this._visible;
},set_visible:function(_e5){
this._visible=_e5;
},get_cssClass:function(){
return this._cssClass;
},set_cssClass:function(_e6){
this._cssClass=_e6;
}};
Telerik.Web.UI.RadRotatorItem.registerClass("Telerik.Web.UI.RadRotatorItem",Sys.UI.Control);
Telerik.Web.UI.RotatorScrollDirection=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.RotatorScrollDirection.prototype={Left:1,Right:2,Up:4,Down:8};
Telerik.Web.UI.RotatorScrollDirection.registerEnum("Telerik.Web.UI.RotatorScrollDirection",false);
Telerik.Web.UI.RotatorAnimationType=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.RotatorAnimationType.prototype={None:1,Fade:2,Pulse:3};
Telerik.Web.UI.RotatorAnimationType.registerEnum("Telerik.Web.UI.RotatorAnimationType",false);
Telerik.Web.UI.RotatorType=function(){
throw Error.invalidOperation();
};
Telerik.Web.UI.RotatorType.prototype={AutomaticAdvance:1,ButtonsOver:2,Buttons:3,SlideShow:4,SlideShowButtons:5,FromCode:6};
Telerik.Web.UI.RotatorType.registerEnum("Telerik.Web.UI.RotatorType",false);

