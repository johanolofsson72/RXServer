if (typeof window.RadControlsNamespace=="undefin\x65\x64"){window.RadControlsNamespace= {} ; }if (typeof(window.RadControlsNamespace.Browser)=="\x75ndefi\x6e\x65d" || typeof(window.RadControlsNamespace.Browser.Version)==null || window.RadControlsNamespace.Browser.Version<1){window.RadControlsNamespace.Browser= {Version: 1 } ; window.RadControlsNamespace.Browser.ParseBrowserInfo= function (){ this.IsMacIE=(navigator.appName=="M\x69\x63rosoft \x49\x6eter\x6e\x65t \x45\x78plo\x72\x65r") && ((navigator.userAgent.toLowerCase().indexOf("mac")!=-1) || (navigator.appVersion.toLowerCase().indexOf("mac")!=-1)); this.IsSafari=(navigator.userAgent.toLowerCase().indexOf("safari")!=-1); this.IsMozilla=window.netscape && !window.opera; this.IsNetscape=/\x4e\x65\x74\x73\x63\x61\x70\x65/.test(navigator.userAgent); this.IsOpera=window.opera; this.IsOpera9=window.opera && (parseInt(window.opera.version())>8); this.IsIE=!this.IsMacIE && !this.IsMozilla && !this.IsOpera && !this.IsSafari; this.IsIE7=/\x4d\x53\x49\x45\x20\x37/.test(navigator.appVersion); this.StandardsMode=this.IsSafari || this.IsOpera9 || this.IsMozilla || document.compatMode=="CSS1\x43\x6fmpat"; this.IsMac=/\x4d\x61\x63/.test(navigator.userAgent); };RadControlsNamespace.Browser.ParseBrowserInfo(); }
if (typeof(Sys) != "undefined"){if (Sys.Application != null && Sys.Application.notifyScriptLoaded != null){Sys.Application.notifyScriptLoaded();}}
