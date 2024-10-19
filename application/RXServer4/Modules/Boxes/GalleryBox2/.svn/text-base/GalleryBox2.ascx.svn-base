<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleryBox2.ascx.cs" Inherits="Modules_Boxes_GalleryBox2_GalleryBox2" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="GalleryBox2_holder" runat="server">
    <div id="GalleryBox2">    
    		<script type="text/javascript">
			document.write("<style type='text/css'>div.navigation{width:300px;float: left;}div.content{display:block;}</style>");
		</script>
    
            <div id="Gallery" class="content" style="display:block; float: left;">
				<div id="loading" class="loader"></div>
				<div id="slideshow" class="slideshow"></div>
				<div id="caption" class="embox"></div>
			</div>

        <div id="Gallery_navigation" class="navigation" style="width:100%;float: left;">
            <asp:Literal id="ltrGallery2" runat="server" />   
            </div>
            
		<script type="text/javascript">
			// Initially set opacity on thumbs and add
			// additional styling for hover effect on thumbs
			var onMouseOutOpacity = 0.67;
			$('#Gallery_navigation ul.thumbs li').css('opacity', onMouseOutOpacity)
				.hover(
					function () {
						$(this).not('.selected').fadeTo('fast', 1.0);
					}, 
					function () {
						$(this).not('.selected').fadeTo('fast', onMouseOutOpacity);
					}
				);

			$(document).ready(function() {
				// Initialize Advanced Galleriffic Gallery
				var galleryAdv = $('#Gallery').galleriffic('#Gallery_navigation', {
					delay:                  2000,
					numThumbs:              12,
					preloadAhead:           10,
					enableTopPager:         false,
					enableBottomPager:      true,
					imageContainerSel:      '#slideshow',
					controlsContainerSel:   '#controls',
					captionContainerSel:    '#caption',
					loadingContainerSel:    '#loading',
					renderNavControls:      false,
					playLinkText:           'Play Slideshow',
					pauseLinkText:          'Pause Slideshow',
					prevLinkText:           '&lsaquo; Previous Photo',
					nextLinkText:           'Next Photo &rsaquo;',
					nextPageLinkText:       'Next &rsaquo;',
					prevPageLinkText:       '&lsaquo; Prev',
					enableHistory:          false,
					autoStart:              false,
					onChange:               function(prevIndex, nextIndex) {
						$('#Gallery_navigation ul.thumbs').children()
							.eq(prevIndex).fadeTo('fast', onMouseOutOpacity).end()
							.eq(nextIndex).fadeTo('fast', 1.0);
					},
					onTransitionOut:        function(callback) {
						$('#slideshow, #caption').fadeOut('fast', callback);
					},
					onTransitionIn:         function() {
						$('#slideshow, #caption').fadeIn('fast');
					},
					onPageTransitionOut:    function(callback) {
						$('#Gallery_navigation ul.thumbs').fadeOut('fast', callback);
					},
					onPageTransitionIn:     function() {
						$('#Gallery_navigation ul.thumbs').fadeIn('fast');
					}
				});

			});
		</script>
        

    
   </div></div>