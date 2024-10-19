    function clearTextBox(name)
    {
        document.getElementById(name).value="";
    }
        
    function getQueryVariable(variable) 
    {
        var query = window.location.search.substring(1);
        var vars = query.split("&");
        for (var i=0;i<vars.length;i++) 
        {
            var pair = vars[i].split("=");
            if (pair[0] == variable) 
            {
                return pair[1];
            }
        }
    }
    
   
    function GetRadWindow()
    {
        var oWindow = null;
        if (window.radWindow) { oWindow = window.radWindow; }
        else if (window.frameElement.radWindow) { oWindow = window.frameElement.radWindow; }
        return oWindow;
    }            
                    
    function returnToParent()
    {
        var oArg = new object();
        var oWnd = GetRadWindow();         
        var win = window.parent;
        win.location.reload(); 
        oWnd.close();
    }

    function CloseRedirect(url)
    {   
        var win = window.parent;      
        var oWnd = GetRadWindow();
        win.location.href = url;      
        oWnd.close();  
    }  
    
    function Redirect(url)
    {   
        window.parent.location.href = url;
    }  

    function CloseWindow()
    {
        var oArg = new object();
        var oWnd = GetRadWindow();         
        oWnd.close();
    }
        
    function OnClientclose(radWindow)
    {         
              
    }     

    function OnClientclose_cancel(radWindow)
    {           
          
    }     



    function MySpaceClick(U, T, C, L) 
    {
	    window.open('http://www.myspace.com/Modules/PostTo/Pages/?t=' + encodeURIComponent(T) + '&c=' + encodeURIComponent(C) + '&u=' + encodeURIComponent(U) + '&l=' + L , 'myspace','toolbar=no,top=100,left=20,width=600,height=550');
    }

    function FaceBookClick(u, t, s, i) 
    {
	    window.open('http://www.facebook.com/sharer.php?s=100&p[title]='+encodeURIComponent(t)+'&p[images][0]='+encodeURIComponent(i)+'&p[medium]=102&p[summary]='+encodeURIComponent(s)+'&p[url]='+encodeURIComponent(u), 'facebook', 'toolbar=0,status=0,top=100,left=20,width=626,height=436');
    }
    
    function DeliciousClick(u,t)
    {
        window.open('http://delicious.com/save?v=5&amp;noui&amp;jump=close&amp;url='+encodeURIComponent(u)+'&amp;title='+encodeURIComponent(t)+'', 'delicious','toolbar=no,top=100,left=20,width=600,height=550');
    }
    
    function TellaFriendClick(path,p,v,id)
    {
        window.open(path + 'Modules/PopUp/TellaFriend/TellaFriend.aspx?pg='+p+'&Var='+v+'&Id='+id, 'tellafriend','toolbars=0, scrollbars=0, statusbars=0, menubars=0,top=100,left=20,width=400,height=450');        
    }
    
    function PrintClick(path,m,i,p)
    {
       window.open(path + 'Modules/PopUp/Print/Print.aspx?mod=' + m +'&id=' + i +'&pg=' + p +'', 'print','toolbar=no,top=100,left=20,width=600,height=650');
    }
    
    