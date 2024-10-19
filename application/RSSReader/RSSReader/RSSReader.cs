using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.IO;

namespace RXServer
{
    namespace UserControls
    {
        public class News
        {
            // Methods
            public static DataTable GetNews(string strURL)
            {
                DataTable table = new DataTable("News");
                table.Columns.Add("Title");
                table.Columns.Add("Link");
                try
                {
                    XmlDocument document = new XmlDocument();
                    XmlDocument document2 = new XmlDocument();
                    document2.Load(strURL);
                    XmlNodeList elementsByTagName = document2.GetElementsByTagName("channel");
                    foreach (XmlNode node in elementsByTagName)
                    {
                        XmlNodeList childNodes = node.ChildNodes;
                        foreach (XmlNode node2 in childNodes)
                        {
                            if (node2.LocalName == "item")
                            {
                                string innerText = node2.SelectSingleNode("title").InnerText;
                                string str2 = node2.SelectSingleNode("link").InnerText;
                                DataRow row = table.NewRow();
                                row["Title"] = innerText;
                                row["Link"] = str2;
                                table.Rows.Add(row);
                            }
                        }
                    }
                    return table;
                }
                catch
                {
                    return table;
                }
            }
        }

        [ToolboxData("<{0}:RssReader runat=server></{0}:RssReader>"), DefaultProperty("HeaderText")]
        public class RssReader : WebControl
        {
            // Methods
            public string GetContents()
            {
                Table table = new Table();
                table.Width = new Unit(Convert.ToInt32(this.RSSContainerWidth));
                table.BorderWidth = 1;
                table.BorderColor = Color.Black;
                table.CellPadding = 2;
                table.CellSpacing = 0;
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = this.HeaderText;
                cell.CssClass = this.HeaderCssClass;
                row.Cells.Add(cell);
                table.Rows.Add(row);
                row = new TableRow();
                cell = new TableCell();
                cell.Text = "  <div id='divRss' style='width: " + (Convert.ToInt32(this.RSSContainerWidth) - 20).ToString() + "px; height: " + (Convert.ToInt32(this.RSSContainerHeight) - 100).ToString() + "px' runat='server'>NewsData</div>";
                row.Cells.Add(cell);
                table.Rows.Add(row);
                row = new TableRow();
                cell = new TableCell();
                cell.CssClass = this.FooterCssClass;
                cell.Text = this.FooterText;
                row.Cells.Add(cell);
                table.Rows.Add(row);
                StringWriter writer = new StringWriter();
                HtmlTextWriter writer2 = new HtmlTextWriter(writer);
                table.RenderControl(writer2);
                return writer.ToString();
            }

            protected override void RenderContents(HtmlTextWriter output)
            {
                try
                {
                    DataTable news = new DataTable();
                    if (this.URL != "")
                    {
                        news = News.GetNews(this.URL);
                    }
                    StringBuilder builder = new StringBuilder();
                    builder.Append("<Marquee OnMouseOver='this.stop();' OnMouseOut='this.start();' height='" + this.RSSContainerHeight + "px' direction='" + this.RSSDirection + "' scrollamount='" + this.RSSSpeed + "'>");
                    if (news.Rows.Count > 0)
                    {
                        builder.Append("<br><div class='" + this.RSSHeadingCssClass + "'>" + this.RSSHeading + "</div><br>");
                        for (int i = 0; i < news.Rows.Count; i++)
                        {
                            builder.Append("<div class='" + this.RSSNewsCSSClass + "'>" + news.Rows[i]["Title"].ToString() + "&nbsp;&nbsp;<a href='" + news.Rows[i]["Link"].ToString() + "' target='_blank'>" + this.RSSReadMoreText + "</a></div><br>");
                        }
                    }
                    builder.Append("</Marquee>");
                    if (this.HeaderText == "")
                    {
                        this.HeaderText = "&nbsp;";
                    }
                    string str = this.GetContents().Replace("NewsData", builder.ToString());
                    output.Write(str);
                }
                catch
                {
                    output.Write("Error in Reading Rss.");
                }
            }

            // Properties
            [Localizable(true), Bindable(true), Category("Appearance"), DefaultValue("")]
            public string FooterCssClass
            {
                get
                {
                    string str = (string)this.ViewState["FooterCssClass"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["FooterCssClass"] = value;
                }
            }

            [Localizable(true), Bindable(true), Category("Appearance"), DefaultValue("")]
            public string FooterText
            {
                get
                {
                    string str = (string)this.ViewState["FooterText"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["FooterText"] = value;
                }
            }

            [Category("Appearance"), Bindable(true), DefaultValue(""), Localizable(true)]
            public string HeaderCssClass
            {
                get
                {
                    string str = (string)this.ViewState["HeaderCssClass"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["HeaderCssClass"] = value;
                }
            }

            [Localizable(true), Bindable(true), Category("Appearance"), DefaultValue("")]
            public string HeaderText
            {
                get
                {
                    string str = (string)this.ViewState["HeaderText"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["HeaderText"] = value;
                }
            }

            [Category("Appearance"), Bindable(true), DefaultValue(""), Localizable(true)]
            public string RSSHeading
            {
                get
                {
                    string str = (string)this.ViewState["RSSHeading"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["RSSHeading"] = value;
                }
            }

            [Localizable(true), DefaultValue(""), Bindable(true), Category("Appearance")]
            public string RSSHeadingCssClass
            {
                get
                {
                    string str = (string)this.ViewState["RSSHeadingCssClass"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["RSSHeadingCssClass"] = value;
                }
            }

            [DefaultValue(""), Localizable(true), Category("Appearance"), Bindable(true)]
            public string RSSNewsCSSClass
            {
                get
                {
                    string str = (string)this.ViewState["RSSNewsCSSClass"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["RSSNewsCSSClass"] = value;
                }
            }

            [DefaultValue("250"), Localizable(true), Category("Appearance"), Bindable(true)]
            public string RSSContainerWidth
            {
                get
                {
                    string str = (string)this.ViewState["RSSContainerWidth"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["RSSContainerWidth"] = value;
                }
            }

            [DefaultValue("210"), Localizable(true), Category("Appearance"), Bindable(true)]
            public string RSSContainerHeight
            {
                get
                {
                    string str = (string)this.ViewState["RSSContainerHeight"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["RSSContainerHeight"] = value;
                }
            }

            [DefaultValue("More info..."), Localizable(true), Category("Appearance"), Bindable(true)]
            public string RSSReadMoreText
            {
                get
                {
                    string str = (string)this.ViewState["RSSReadMoreText"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["RSSReadMoreText"] = value;
                }
            }

            [DefaultValue("up"), Localizable(true), Category("Appearance"), Bindable(true)]
            public string RSSDirection
            {
                get
                {
                    string str = (string)this.ViewState["RSSDirection"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["RSSDirection"] = value;
                }
            }

            [DefaultValue("3"), Localizable(true), Category("Appearance"), Bindable(true)]
            public string RSSSpeed
            {
                get
                {
                    string str = (string)this.ViewState["RSSSpeed"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["RSSSpeed"] = value;
                }
            }

            [Bindable(true), Localizable(true), Category("Appearance"), DefaultValue("")]
            public string URL
            {
                get
                {
                    string str = (string)this.ViewState["URL"];
                    return ((str == null) ? string.Empty : str);
                }
                set
                {
                    this.ViewState["URL"] = value;
                }
            }
        }
    }
}
