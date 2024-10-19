<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShopBox.ascx.cs" Inherits="Modules_Boxes_ShopBox_ShopBox" %>
<%@ Register src="AddToCartWrapper.ascx" tagname="AddToCartWrapper" tagprefix="uc1" %>
<%@ Register src="AddToCartWrapperCat.ascx" tagname="AddToCartWrapperCat" tagprefix="uc1" %>

<div id="ShopBox_holder" runat="server">
    <div id="ShopBox">
		<div id="menu">
			<asp:Repeater ID="rptMenuItems" runat="server">
				<ItemTemplate>
					<div class='<%#DataBinder.Eval(Container.DataItem, "item_class")%>'>
						<asp:HyperLink ID="hplItem" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "item_url")%>'>
							<%#DataBinder.Eval(Container.DataItem, "item_text")%>
						</asp:HyperLink>
					</div>
					<div class='<%#DataBinder.Eval(Container.DataItem, "divider_class")%>'></div>
				</ItemTemplate>
			</asp:Repeater>
		</div>
		<div id="product" runat="server" class="product">
			<h2><asp:Label ID="lblTitle" runat="server" Text="lblTitle" /></h2>
			<div id="product_left">
				<div id="gallery">
					<div id="big_image_wrapper">
						<div id="big_image_<%= this.ModId %>" class="big_image"></div>
					</div>
					<div id="x_big_image_<%= this.ModId %>" class="x_big_image"></div>
					<div id="thumb_wrapper" runat="server">
						<div id="thumbs">
							<asp:Literal ID="ltrThumbs" runat="server" />
						</div>
					</div>
				</div>
				<div id="text">
					<asp:Label ID="lblProductText" runat="server" Text="lblProductText" />
				</div>
			</div>
			<div id="extra_price" runat="server" class="extra_price" visible="false"><asp:Image ID="imgExtraPrice" runat="server" ImageUrl="~/Images/Modules/Boxes/sb_special_price.jpg" /></div>
			<div id="price"><asp:Label ID="lblPrice" runat="server" Text="lblPrice" /></div>
			<div id="old_price" runat="server" class="old_price" visible="false"><asp:Label ID="lblOldPrice" runat="server" Text="lblPrice" /></div>
			<div id="product_arrow"></div>
			<div id="product_right">
				<div id="options" runat="server" class="options">
					<div id="options_title">
						<asp:Label ID="lblSelectionsTitle" runat="server" Text="lblSelectionsTitle" />
					</div>
					<div id="divider"></div>
					<div id="options_radio">
						<asp:RadioButtonList ID="rdBtnLstChoices" runat="server" Visible="true" />
					</div>
				</div>
				<div id="quantity" runat="server">
					ANTAL:
					&nbsp;
					<asp:TextBox ID="txtQuantity" runat="server" Width="20px">1</asp:TextBox>
				</div>
				<div id="stock">
					LAGERSTATUS:
					<asp:Label ID="lblStock" runat="server" Text="lblStock" />
				</div>
				<div id="add_to_cart">
					<uc1:AddToCartWrapper ID="AddToCartWrapper1" runat="server" />
				</div>
			</div>
		</div>
		<div id="category" runat="server" class="category" visible="false">
			<h2><asp:Label ID="lblCatTitle" runat="server" Text="lblCatTitle" /></h2>
			<div id="text">
				<asp:Label ID="lblCatText" runat="server" Text="lblCatText" />
			</div>
			<asp:Repeater ID="rptCategoryItems" runat="server">
				<ItemTemplate>
					<div class="category_item">
						<asp:HyperLink ID="hplReadMoreImg" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "prod_url")%>'>
							<asp:Image ID="imgProdImage" runat="server" CssClass="image" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "prod_img_url")%>' />
						</asp:HyperLink>
						<div class="cat_item_title">
							<%#DataBinder.Eval(Container.DataItem, "prod_title")%>
						</div>
						<div class="read_more">
							<asp:HyperLink ID="hplReadMore" runat="server" NavigateUrl='<%#DataBinder.Eval(Container.DataItem, "prod_url")%>'>
								Mer info
							</asp:HyperLink>
						</div>
						<div class="add_to_cart_button">
							<uc1:AddToCartWrapperCat ID="AddToCartWrapperCat1" runat="server" ProdId='<%#DataBinder.Eval(Container.DataItem, "prod_id")%>' />
						</div>
						<div class="extraprice">
							<%#DataBinder.Eval(Container.DataItem, "extraprice")%>
						</div>
						<div class='<%#DataBinder.Eval(Container.DataItem, "price_class")%>'>
							<%#DataBinder.Eval(Container.DataItem, "price")%>
						</div>
					</div>
					<div class='<%#DataBinder.Eval(Container.DataItem, "divider_class")%>'></div>
				</ItemTemplate>
			</asp:Repeater>
		</div>
    </div>
</div>

<!-- Huge gallery script -->
<script type="text/javascript">
	var selectedId_<%= this.ModId %> = 1;
	
	$(window).load(function() {
		var MOD_ID = <%= this.ModId %>;
		var THUMB_COUNT = <%= this.thumbCount %>;
		var FADE_SPEED = 200;
		
		//Big image
		$("#big_image_" + MOD_ID).hide();
		var title = $("#thumb_" + MOD_ID + "_" + 1).find("img").attr("title");
		var htmlBigImage = "<img src='" + $("#big_image_url_" + MOD_ID + "_" + 1).text() + "' class='gallery_image' title='" + title + "' />";
		$("#big_image_" + MOD_ID).html(htmlBigImage);
		$("#big_image_" + MOD_ID).fadeIn(FADE_SPEED);
		$("#dimmer_" + MOD_ID + "_" + 1).fadeTo(0, 0);
		if($("#x_big_image_url_" + MOD_ID + "_" + 1).length != 0)
		{
			$("#big_image_" + MOD_ID).css("cursor", "pointer");
		}
		else
		{
			$("#big_image_" + MOD_ID).css("cursor", "default");
		}
		
		//Extra big image
		var info = $("#x_big_image_text_" + MOD_ID + "_" + 1).text();
		$("#x_big_image_" + MOD_ID).html("<img src='" + $("#x_big_image_url_" + MOD_ID + "_" + 1).text() + "' /><div class='x_big_image_display_text'>" + info + "</div>");
		$("#big_image_" + MOD_ID).click(function(){
			if($("#x_big_image_url_" + MOD_ID + "_" + selectedId_<%= this.ModId %>).length != 0)
			{
				$.modal.defaults.closeClass = "x_big_image";
				$("#x_big_image_" + MOD_ID).modal({
					opacity:50,
					overlayCss: {backgroundColor:"#000000"},
					onOpen: function (dialog) {
						dialog.overlay.fadeIn(FADE_SPEED);
						dialog.container.fadeIn(0);
						dialog.data.fadeIn(FADE_SPEED);
					},
					onClose: function (dialog) {
						dialog.overlay.fadeOut(FADE_SPEED);
						dialog.container.fadeOut(0);
						dialog.data.fadeOut(FADE_SPEED, function () {
							$.modal.close(); // must call this!
						});
					}
				});
			}
		});
		$("#x_big_image_" + MOD_ID).hide();
		
		//Thumbs
		var thumbs = new Array();
		for(i = 0; i < THUMB_COUNT; i++)
		{
			thumbs[i] = (i + 1);
		}
		$.each(thumbs, function(index, item){
			$("#thumb_" + MOD_ID + "_" + item).hover(function() {
				if(!$("#dimmer_" + MOD_ID + "_" + item).is(":animated"))
				{
					$("#dimmer_" + MOD_ID + "_" + item).fadeTo(FADE_SPEED, 0);
				}
			}, function() {
				if(selectedId_<%= this.ModId %> != item)
				{
					$("#dimmer_" + MOD_ID + "_" + item).fadeTo(FADE_SPEED, 0.5);
				}
			});
			
			$("#thumb_" + MOD_ID + "_" + item).click(function(){
				$("#dimmer_" + MOD_ID + "_" + item).fadeTo(0, 0);
				if(item != selectedId_<%= this.ModId %>)
				{
					$("#dimmer_" + MOD_ID + "_" + selectedId_<%= this.ModId %>).fadeTo(FADE_SPEED, 0.5);
				}
				selectedId_<%= this.ModId %> = item;
				$("#big_image_" + MOD_ID).fadeOut(FADE_SPEED, function(){
					var title = $("#thumb_" + MOD_ID + "_" + item).find("img").attr("title");
					var htmlBigImage = "<img src='" + $("#big_image_url_" + MOD_ID + "_" + item).text() + "' class='gallery_image' title='" + title + "' />";
					var info = $("#x_big_image_text_" + MOD_ID + "_" + item).text();
					$("#x_big_image_" + MOD_ID).html("<img src='" + $("#x_big_image_url_" + MOD_ID + "_" + item).text() + "' /><div class='x_big_image_display_text'>" + info + "</div>");
					$("#big_image_" + MOD_ID).html(htmlBigImage);
					$("#big_image_" + MOD_ID).fadeIn(FADE_SPEED);
				});
				
				if($("#x_big_image_url_" + MOD_ID + "_" + item).length != 0)
				{
					$("#big_image_" + MOD_ID).css("cursor", "pointer");
				}
				else
				{
					$("#big_image_" + MOD_ID).css("cursor", "default");
				}
			});
			
			if(item != 1)
			{
				$("#dimmer_" + MOD_ID + "_" + item).fadeTo(0, 0.5);
			}
		});
	});
</script>

<!-- Ellipsis for FF -->
<script type="text/javascript">
	$(window).load(function() {
		$(".cat_item_title").ellipsis();
	});
</script>

<!-- Center loader -->
<script type="text/javascript">
	function centerElementOnScreen(element, loader) 
	{
		var top = $(window).height() / 2 - 10;
		$("#" + element).css("width", $(window).width() + "px");
		$("#" + element).css("height", $(window).height() + "px");
		$("#" + loader).css("margin-top", top + "px");
		
		$(window).resize(function(){
			var top = $(window).height() / 2 - 10;
			$("#" + element).css("width", $(window).width() + "px");
			$("#" + element).css("height", $(window).height() + "px");
			$("#" + loader).css("margin-top", top + "px");
		});
	}
	
	function removeOnResize()
	{
		$(window).unbind("resize");
	}
</script>