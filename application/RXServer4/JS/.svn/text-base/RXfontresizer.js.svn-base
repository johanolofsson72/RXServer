function SetFontSize(w) {createCookie('rx3_fs',w,365);}

function GetFontSize() {return(readCookie('rx3_fs'));}

function ChangeFontSize(obj,f1,f2) 
{
    var ca = obj.split(';');
    var x = GetFontSize();
    for(var i=0;i < ca.length;i++) 
    {
        var textfield = document.getElementById(ca[i]);
        
        txt = textfield.innerHTML;        
        txt = txt.replace(/<\/big>/gi, "");
        txt = txt.replace(/<big>/gi, "");
        
        if(x == "medium")
        {
            html = "<big>" + txt + "</big>";        
            ge = document.getElementById(ca[i]);
            ge.style.display = "block";
            ge.innerHTML = html;
        }
        else if(x == "large")
        {
            html = "<big><big>" + txt + "</big></big>";        
            ge = document.getElementById(ca[i]);
            ge.style.display = "block";
            ge.innerHTML = html;
        }
        else
        {
            html = txt; 

            ge = document.getElementById(ca[i]);
            ge.style.display = "block";
            ge.innerHTML = html;
        }           
    }
}

function createCookie(name,value,days) 
{
    if (days) 
    {
        var date = new Date();
        date.setTime(date.getTime()+(days*24*60*60*1000));
        var expires = "; expires="+date.toGMTString();
    }
    else var expires = "";
    document.cookie = name+"="+value+expires+"; path=/";
}

function readCookie(name) {
    
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for(var i=0;i < ca.length;i++) {
        var c = ca[i];
        while (c.charAt(0)==' ') c = c.substring(1,c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
    }
    return null;
}

function eraseCookie(name) 
{
    createCookie(name,"",-1);
}