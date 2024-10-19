var Web20AjaxLoadingPanelVersion='1.0';

function renderLoadingPanel(url){
   var a= url+'JS/Loading/Config.xml';
   if(window.ActiveXObject){
      config=new ActiveXObject("Microsoft.XMLDOM");
      config.async=false;
      config.load(a)
   }
   else if(document.implementation&&document.implementation.createDocument){
      config=document.implementation.createDocument("","",null);
      config.async=false;
      config.load(a)
   }
   loadingMessageHeight=config.getElementsByTagName('loadingmessage')[0].getAttribute('height');
   loadingMessageWidth=config.getElementsByTagName('loadingmessage')[0].getAttribute('width');
   var b=document.createElement('div');
   b.setAttribute('id','credits_'+randomid);
   b.setAttribute('unselectable','on');
   b.innerHTML='Powered by Noisy Cricket.';
   b.style.position='absolute';
   b.style.position='fixed';
   b.style.display='block';
   b.style.visibility='visible';
   b.style.bottom='8'+'px';
   b.style.right='8'+'px';
   b.style.zIndex='120000';
   b.style.color='white';
   b.style.font='normal 10px Arial, Verdana, Sans-serif';

   var c=document.createElement('div');
   var d=document.createElement('div');
   var e=document.createElement('link');
   var f=false;
   e.type='text/css';
   e.rel='stylesheet';
   e.href= url+'JS/Loading/'+Web20AjaxLoadingPanelVersion+'/style.css';
   document.getElementsByTagName('head')[0].appendChild(e);
   c.setAttribute('id','LoadingMessageModalPane');
   c.style.background=config.getElementsByTagName('modalpanel')[0].getAttribute('backcolor');
   c.style.height=document.documentElement.scrollHeight+'px';
   d.setAttribute('id','loadingMessageContainer');
   d.unselectable='on';
   d.innerHTML=config.getElementsByTagName('loadingmessage')[0].getAttribute('text');
   d.style.height=loadingMessageHeight+'px';
   d.style.fontFamily=config.getElementsByTagName('loadingmessage')[0].getAttribute('font-family');
   d.style.fontWeight=config.getElementsByTagName('loadingmessage')[0].getAttribute('font-weight');
   d.style.fontStyle=config.getElementsByTagName('loadingmessage')[0].getAttribute('font-style');
   d.style.fontSize=config.getElementsByTagName('loadingmessage')[0].getAttribute('font-size')+'px';
   d.style.color=config.getElementsByTagName('loadingmessage')[0].getAttribute('forecolor');
   d.style.lineHeight=loadingMessageHeight+'px';
   d.style.width=loadingMessageWidth+'px';
   d.style.marginLeft='-'+loadingMessageWidth/'2'+'px';
   d.style.marginTop='-'+loadingMessageHeight/'2'+'px';
   d.style.backgroundColor=config.getElementsByTagName('loadingmessage')[0].getAttribute('backcolor');
   d.style.backgroundImage='url(\''+config.getElementsByTagName("loadingmessage")[0].getAttribute("loadingimage")+'\')';
   document.getElementsByTagName('body')[0].appendChild(b);
   document.getElementsByTagName('body')[0].appendChild(d);
   if(config.getElementsByTagName('modalpanel')[0].getAttribute('modal')!="false"){
      document.getElementsByTagName('body')[0].appendChild(c);
      var g=config.getElementsByTagName('modalpanel')[0].getAttribute('opacity');
      document.getElementById('LoadingMessageModalPane').className='modalPaneTrue';
      document.getElementById('LoadingMessageModalPane').style.filter='alpha(opacity='+g+')';
      document.getElementById('LoadingMessageModalPane').style.opacity='.'+g+''
   }
}
function displayLoadingPanel(){
   var a=false;
   if(!a){
      if(document.getElementById('credits_'+randomid)!=null){
         if(config.getElementsByTagName('modalpanel')[0].getAttribute('modal')!="false")
            document.getElementById('LoadingMessageModalPane').style.display='block'
         if(config.getElementsByTagName('loadingmessage')[0].getAttribute('visible')!="false")
            document.getElementById('loadingMessageContainer').style.display='block'
         document.getElementById('credits_'+randomid).style.display='block';
         hidePageScrollBars();
      }
      else
         alert('Web 2.0 AJAX Loading '+Web20AjaxLoadingPanelVersion+' Panel System Message:\n\nYou are using an illegally modified version of Web 2.0 AJAX Loading Panel. Please, either rollback the changes you\'ve made, or download it again from my website. The script will not start.')
   }
   else{
      document.getElementById('credits_'+randomid).style.display='none';
      if(config.getElementsByTagName('modalpanel')[0].getAttribute('modal')!="false")
         document.getElementById('LoadingMessageModalPane').style.display='block'
      if(config.getElementsByTagName('loadingmessage')[0].getAttribute('visible')!="false")
         document.getElementById('loadingMessageContainer').style.display='block'
      hidePageScrollBars();
   }
}

function hideLoadingPanel(){
   if(config.getElementsByTagName('modalpanel')[0].getAttribute('modal')!="false")
      document.getElementById('LoadingMessageModalPane').style.display='none'
   document.getElementById('loadingMessageContainer').style.display='none';
   if(document.getElementById('credits_'+randomid)!=null)
      document.getElementById('credits_'+randomid).style.display='none'
   showPageScrollBars()
}

function hidePageScrollBars(){
   document.documentElement.style.overflowY='hidden'
}

function showPageScrollBars(){
   document.documentElement.style.overflowY='auto'
}
var randomid=Math.floor(Math.random()*100000000000000);