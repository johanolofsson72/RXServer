using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RXServer
{
    [DefaultProperty("PaneName")]
    [ToolboxData("<{0}:RXContentHolder runat=server></{0}:RXContentHolder>")]
    public class RXContentHolder : PlaceHolder
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("ContentPane1")]
        [Localizable(true)]
        public string PaneName
        {
            get
            {
                String s = (String)ViewState["PaneName"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["PaneName"] = value;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }
    }
    
}
