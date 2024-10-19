using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Drawing.Printing;

public partial class Modules_Boxes_GalleryBox_GalleryBox : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Boxes_GalleryBox_GalleryBox";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (!Page.IsPostBack)
            {
                bindData();
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void bindData()
    {
        String function_name = "bindData";
        try
        {
            if (!this.Hidden || RXServer.Auth.IsInRole("Admin"))
            {
				RXServer.Modules.MediaModule mm = new RXServer.Modules.MediaModule(this.SitId, this.PagId, this.ModId);

                this.GalleryBox_holder.Visible = true;

                // Sets Module Width

                Int32 ModelId = 0;
                Int32.TryParse(mm.ModelId, out ModelId);
                Int32 _width = RXMali.GetModelSize(ModelId.ToString());

                String _style = "";
                _style = "position: relative; float: " + mm.Float + "; width: " + _width + "px;";

                this.GalleryBox_holder.Attributes.Add("style", _style);

                String html = "";

                String activeDir = "Upload/Pages/" + this.PagId + "/" + this.ModId + "/";
                string filename = RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + activeDir + "Gallery.xml";


                html = RXMali.GetGalleryCode(RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "imagerotator.swf", "rotator_" + this.ModId, _width, _width, filename);

                
                this.ltrGallery.Text = html;
            }
            else
            {
                this.GalleryBox_holder.Visible = false;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private String GetConPa()
    {
        String function_name = "GetConPa";
        try
        {
            RXServer.Modules.MediaModule mm = new RXServer.Modules.MediaModule(this.SitId, this.PagId, this.ModId);
            return mm.ContentPane;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return "";
        }
    }
}
