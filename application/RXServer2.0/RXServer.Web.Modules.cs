using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace RXServer
{
    namespace Web
    {
        namespace Modules
        {

            #region public class TeaserImage
            public class TeaserImage : ArticleBase
            {
                string CLASSNAME = "[Namespace::RXServer::Web::Modules][Class::TeaserImage]";

                public Boolean PreserveImageBaseWidth = false;

                public TeaserImage(Int32 SitId, Int32 PagId, Int32 ModId)
                    : base(SitId, PagId, ModId)
                {
                }

                public override void Save()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                    try
                    {
                        // Create Standard Article And ReadMorePage...
                        base.Save();

                        // Skapa combo gif...
                        if (base.Header1.Length > 0 && base.Header2.Length > 0)
                        {
                            RXServer.Library.Image.CreateComboHeaderImage(
                                Header1,
                                0,
                                0,
                                Header1FontColor,
                                Header1FontName,
                                Header1FontSize,
                                Header1FontStyle,
                                Header1FontUnit,
                                Header2,
                                0,
                                0,
                                Header2FontColor,
                                Header2FontName,
                                Header2FontSize,
                                Header2FontStyle,
                                Header2FontUnit,
                                HeaderSourceImageUrl,
                                HeaderDestinationImageUrl);
                        }
                        else if (base.Header1.Length > 0 && base.Header2.Length.Equals(0))
                        {
                            if (PreserveImageBaseWidth)
                            {
                                RXServer.Library.Image.CreateTeaserImage(
                                        Header1,
                                        Ingress,
                                     14,
                                        8,
                                        Header1FontColor,
                                        Header1FontName,
                                        Header1FontSize,
                                        Header1FontStyle,
                                        Header1FontUnit,
                                        IngressFontColor,
                                        IngressFontName,
                                        IngressFontSize,
                                        IngressFontStyle,
                                        IngressFontUnit,
                                        HeaderSourceImageUrl,
                                        HeaderDestinationImageUrl);
                            }
                            else
                            {
                                RXServer.Library.Image.CreateHeaderImage(
                                        Header1,
                                        5,
                                        5,
                                        Header1FontColor,
                                        Header1FontName,
                                        Header1FontSize,
                                        Header1FontStyle,
                                        Header1FontUnit,
                                        HeaderSourceImageUrl,
                                        HeaderDestinationImageUrl);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                    }
                }
            }
            #endregion public class TeaserImage

            #region public class Article
            public class Article : ArticleBase
            {
                string CLASSNAME = "[Namespace::RXServer::Web::Modules][Class::Article]";

                public Boolean PreserveImageBaseWidth = false;

                public Article(Int32 SitId, Int32 PagId, Int32 ModId)
                    : base(SitId, PagId, ModId)
                {
                }

                public override void Save()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                    try
                    {
                        // Create Standard Article And ReadMorePage...
                        base.Save();

                        if (this.Header1FontName.Length.Equals(0))
                            return;

                        // Skapa combo gif...
                        if (base.Header1.Length > 0 && base.Header2.Length > 0)
                        {
                            RXServer.Library.Image.CreateComboHeaderImage(
                                Header1,
                                0,
                                0,
                                Header1FontColor,
                                Header1FontName,
                                Header1FontSize,
                                Header1FontStyle,
                                Header1FontUnit,
                                Header2,
                                0,
                                0,
                                Header2FontColor,
                                Header2FontName,
                                Header2FontSize,
                                Header2FontStyle,
                                Header2FontUnit,
                                HeaderSourceImageUrl,
                                HeaderDestinationImageUrl);
                        }
                        else if (base.Header1.Length > 0 && base.Header2.Length.Equals(0))
                        {
                            if (PreserveImageBaseWidth)
                            {
                                RXServer.Library.Image.CreateTeaserImage(
                                        Header1,
                                        Ingress,
                                     14,
                                        10,
                                        Header1FontColor,
                                        Header1FontName,
                                        Header1FontSize,
                                        Header1FontStyle,
                                        Header1FontUnit,
                                        IngressFontColor,
                                        IngressFontName,
                                        IngressFontSize,
                                        IngressFontStyle,
                                        IngressFontUnit,
                                        HeaderSourceImageUrl,
                                        HeaderDestinationImageUrl);
                            }
                            else
                            {
                                RXServer.Library.Image.CreateHeaderImage(
                                        Header1,
                                        5,
                                        5,
                                        Header1FontColor,
                                        Header1FontName,
                                        Header1FontSize,
                                        Header1FontStyle,
                                        Header1FontUnit,
                                        HeaderSourceImageUrl,
                                        HeaderDestinationImageUrl);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                    }
                }
            }
            #endregion public class Article

            #region public class ArticleBase
            public class ArticleBase : Object
            {
                string CLASSNAME = "[Namespace::RXServer::Web::Modules][Class::ArticleBase]";
                private Module mSource;
                public Int32 DefId;
                public String ContentPane = String.Empty;
                public String ReadMoreContentPanes = String.Empty;
                public String ReadMoreAlias = String.Empty;
                public String Date
                {
                    get { return base.Field1; }
                    set { base.Field1 = value; }
                }
                public String Header
                {
                    get { return base.Field2; }
                    set { base.Field2 = value; }
                }
                public String Ingress
                {
                    get { return base.Field3; }
                    set { base.Field3 = value; }
                }
                public String Text
                {
                    get { return base.Field4; }
                    set { base.Field4 = value; }
                }
                public Boolean HasImage
                {
                    get
                    {
                        if (base.Field5.Equals(String.Empty))
                            return false;
                        return base.Field5.Equals("0") ? false : true;
                    }
                    set { base.Field5 = value.Equals(true) ? "1" : "0"; }
                }
                public String ImageUrl
                {
                    get { return base.Field6; }
                    set { base.Field6 = value; }
                }
                public Boolean HasReadMore
                {
                    get
                    {
                        if (base.Field7.Equals(String.Empty))
                            return false;
                        return base.Field7.Equals("0") ? false : true;
                    }
                    set { base.Field7 = value.Equals(true) ? "1" : "0"; }
                }
                public String PageTemplate
                {
                    get { return base.Field8; }
                    set { base.Field8 = value; }
                }
                public Int32 ReadMorePagId
                {
                    get { return base.Field9.Length > 0 ? Convert.ToInt32(base.Field9) : 0; }
                    set { base.Field9 = value.ToString(); }
                }
                public Int32 ReadMoreModId
                {
                    get { return base.Field10.Length > 0 ? Convert.ToInt32(base.Field10) : 0; }
                    set { base.Field10 = value.ToString(); }
                }
                public String ContentType
                {
                    get { return base.Field11; }
                    set { base.Field11 = value; }
                }
                public String Header1
                {
                    get { return base.Field2; }
                    set { base.Field2 = value; }
                }
                public String Header2
                {
                    get { return base.Field12; }
                    set { base.Field12 = value; }
                }
                public String Header1FontName
                {
                    get { return base.Field13; }
                    set { base.Field13 = value; }
                }
                public String Header2FontName
                {
                    get { return base.Field14; }
                    set { base.Field14 = value; }
                }
                public String IngressFontName
                {
                    get { return base.Field30; }
                    set { base.Field30 = value; }
                }
                public Int32[] Header1FontColor
                {
                    get
                    {
                        if (base.Field15.Length > 3)
                        {
                            Int32[] i = new Int32[3];
                            i[0] = Convert.ToInt32(base.Field15.Split(',').GetValue(0));
                            i[1] = Convert.ToInt32(base.Field15.Split(',').GetValue(1));
                            i[2] = Convert.ToInt32(base.Field15.Split(',').GetValue(2));
                            return i;
                        }
                        else
                            return new Int32[3];
                    }
                    set { base.Field15 = value[0].ToString() + "," + value[1].ToString() + "," + value[2].ToString(); }
                }
                public Int32[] Header2FontColor
                {
                    get
                    {
                        if (base.Field16.Length > 3)
                        {
                            Int32[] i = new Int32[3];
                            i[0] = Convert.ToInt32(base.Field16.Split(',').GetValue(0));
                            i[1] = Convert.ToInt32(base.Field16.Split(',').GetValue(1));
                            i[2] = Convert.ToInt32(base.Field16.Split(',').GetValue(2));
                            return i;
                        }
                        else
                            return new Int32[3];
                    }
                    set { base.Field16 = value[0].ToString() + "," + value[1].ToString() + "," + value[2].ToString(); }
                }
                public Int32[] IngressFontColor
                {
                    get
                    {
                        if (base.Field29.Length > 3)
                        {
                            Int32[] i = new Int32[3];
                            i[0] = Convert.ToInt32(base.Field29.Split(',').GetValue(0));
                            i[1] = Convert.ToInt32(base.Field29.Split(',').GetValue(1));
                            i[2] = Convert.ToInt32(base.Field29.Split(',').GetValue(2));
                            return i;
                        }
                        else
                            return new Int32[3];
                    }
                    set { base.Field29 = value[0].ToString() + "," + value[1].ToString() + "," + value[2].ToString(); }
                }
                public float Header1FontSize
                {
                    get
                    {
                        float f = 8.0f;
                        float.TryParse(base.Field17, out f);
                        return f;
                    }
                    set { base.Field17 = value.ToString(); }
                }
                public float Header2FontSize
                {
                    get
                    {
                        float f = 8.0f;
                        float.TryParse(base.Field18, out f);
                        return f;
                    }
                    set { base.Field18 = value.ToString(); }
                }
                public float IngressFontSize
                {
                    get
                    {
                        float f = 8.0f;
                        float.TryParse(base.Field28, out f);
                        return f;
                    }
                    set { base.Field28 = value.ToString(); }
                }
                public System.Drawing.FontStyle Header1FontStyle
                {
                    get
                    {
                        switch (base.Field19.ToLower())
                        {
                            case "bold":
                                return System.Drawing.FontStyle.Bold;
                            case "italic":
                                return System.Drawing.FontStyle.Italic;
                            case "regular":
                                return System.Drawing.FontStyle.Regular;
                            case "strikeout":
                                return System.Drawing.FontStyle.Strikeout;
                            case "underline":
                                return System.Drawing.FontStyle.Underline;
                            default:
                                return System.Drawing.FontStyle.Regular;
                        }
                    }
                    set
                    {
                        switch (value)
                        {
                            case System.Drawing.FontStyle.Bold:
                                base.Field19 = "Bold";
                                break;
                            case System.Drawing.FontStyle.Italic:
                                base.Field19 = "Italic";
                                break;
                            case System.Drawing.FontStyle.Regular:
                                base.Field19 = "Regular";
                                break;
                            case System.Drawing.FontStyle.Strikeout:
                                base.Field19 = "Strikeout";
                                break;
                            case System.Drawing.FontStyle.Underline:
                                base.Field19 = "Underline";
                                break;
                        }
                    }
                }
                public System.Drawing.FontStyle Header2FontStyle
                {
                    get
                    {
                        switch (base.Field20.ToLower())
                        {
                            case "bold":
                                return System.Drawing.FontStyle.Bold;
                            case "italic":
                                return System.Drawing.FontStyle.Italic;
                            case "regular":
                                return System.Drawing.FontStyle.Regular;
                            case "strikeout":
                                return System.Drawing.FontStyle.Strikeout;
                            case "underline":
                                return System.Drawing.FontStyle.Underline;
                            default:
                                return System.Drawing.FontStyle.Regular;
                        }
                    }
                    set
                    {
                        switch (value)
                        {
                            case System.Drawing.FontStyle.Bold:
                                base.Field20 = "Bold";
                                break;
                            case System.Drawing.FontStyle.Italic:
                                base.Field20 = "Italic";
                                break;
                            case System.Drawing.FontStyle.Regular:
                                base.Field20 = "Regular";
                                break;
                            case System.Drawing.FontStyle.Strikeout:
                                base.Field20 = "Strikeout";
                                break;
                            case System.Drawing.FontStyle.Underline:
                                base.Field20 = "Underline";
                                break;
                        }
                    }
                }
                public System.Drawing.FontStyle IngressFontStyle
                {
                    get
                    {
                        switch (base.Field31.ToLower())
                        {
                            case "bold":
                                return System.Drawing.FontStyle.Bold;
                            case "italic":
                                return System.Drawing.FontStyle.Italic;
                            case "regular":
                                return System.Drawing.FontStyle.Regular;
                            case "strikeout":
                                return System.Drawing.FontStyle.Strikeout;
                            case "underline":
                                return System.Drawing.FontStyle.Underline;
                            default:
                                return System.Drawing.FontStyle.Regular;
                        }
                    }
                    set
                    {
                        switch (value)
                        {
                            case System.Drawing.FontStyle.Bold:
                                base.Field31 = "Bold";
                                break;
                            case System.Drawing.FontStyle.Italic:
                                base.Field31 = "Italic";
                                break;
                            case System.Drawing.FontStyle.Regular:
                                base.Field31 = "Regular";
                                break;
                            case System.Drawing.FontStyle.Strikeout:
                                base.Field31 = "Strikeout";
                                break;
                            case System.Drawing.FontStyle.Underline:
                                base.Field31 = "Underline";
                                break;
                        }
                    }
                }
                public System.Drawing.GraphicsUnit Header1FontUnit
                {
                    get
                    {
                        switch (base.Field21.ToLower())
                        {
                            case "display":
                                return System.Drawing.GraphicsUnit.Display;
                            case "document":
                                return System.Drawing.GraphicsUnit.Document;
                            case "inch":
                                return System.Drawing.GraphicsUnit.Inch;
                            case "millimeter":
                                return System.Drawing.GraphicsUnit.Millimeter;
                            case "pixel":
                                return System.Drawing.GraphicsUnit.Pixel;
                            case "point":
                                return System.Drawing.GraphicsUnit.Point;
                            case "world":
                                return System.Drawing.GraphicsUnit.World;
                            default:
                                return System.Drawing.GraphicsUnit.Pixel;
                        }
                    }
                    set
                    {
                        switch (value)
                        {
                            case System.Drawing.GraphicsUnit.Display:
                                base.Field21 = "Display";
                                break;
                            case System.Drawing.GraphicsUnit.Document:
                                base.Field21 = "Document";
                                break;
                            case System.Drawing.GraphicsUnit.Inch:
                                base.Field21 = "Inch";
                                break;
                            case System.Drawing.GraphicsUnit.Millimeter:
                                base.Field21 = "Millimeter";
                                break;
                            case System.Drawing.GraphicsUnit.Pixel:
                                base.Field21 = "Pixel";
                                break;
                            case System.Drawing.GraphicsUnit.Point:
                                base.Field21 = "Point";
                                break;
                            case System.Drawing.GraphicsUnit.World:
                                base.Field21 = "World";
                                break;
                        }
                    }
                }
                public System.Drawing.GraphicsUnit Header2FontUnit
                {
                    get
                    {
                        switch (base.Field22.ToLower())
                        {
                            case "display":
                                return System.Drawing.GraphicsUnit.Display;
                            case "document":
                                return System.Drawing.GraphicsUnit.Document;
                            case "inch":
                                return System.Drawing.GraphicsUnit.Inch;
                            case "millimeter":
                                return System.Drawing.GraphicsUnit.Millimeter;
                            case "pixel":
                                return System.Drawing.GraphicsUnit.Pixel;
                            case "point":
                                return System.Drawing.GraphicsUnit.Point;
                            case "world":
                                return System.Drawing.GraphicsUnit.World;
                            default:
                                return System.Drawing.GraphicsUnit.Pixel;
                        }
                    }
                    set
                    {
                        switch (value)
                        {
                            case System.Drawing.GraphicsUnit.Display:
                                base.Field22 = "Display";
                                break;
                            case System.Drawing.GraphicsUnit.Document:
                                base.Field22 = "Document";
                                break;
                            case System.Drawing.GraphicsUnit.Inch:
                                base.Field22 = "Inch";
                                break;
                            case System.Drawing.GraphicsUnit.Millimeter:
                                base.Field22 = "Millimeter";
                                break;
                            case System.Drawing.GraphicsUnit.Pixel:
                                base.Field22 = "Pixel";
                                break;
                            case System.Drawing.GraphicsUnit.Point:
                                base.Field22 = "Point";
                                break;
                            case System.Drawing.GraphicsUnit.World:
                                base.Field22 = "World";
                                break;
                        }
                    }
                }
                public System.Drawing.GraphicsUnit IngressFontUnit
                {
                    get
                    {
                        switch (base.Field27.ToLower())
                        {
                            case "display":
                                return System.Drawing.GraphicsUnit.Display;
                            case "document":
                                return System.Drawing.GraphicsUnit.Document;
                            case "inch":
                                return System.Drawing.GraphicsUnit.Inch;
                            case "millimeter":
                                return System.Drawing.GraphicsUnit.Millimeter;
                            case "pixel":
                                return System.Drawing.GraphicsUnit.Pixel;
                            case "point":
                                return System.Drawing.GraphicsUnit.Point;
                            case "world":
                                return System.Drawing.GraphicsUnit.World;
                            default:
                                return System.Drawing.GraphicsUnit.Pixel;
                        }
                    }
                    set
                    {
                        switch (value)
                        {
                            case System.Drawing.GraphicsUnit.Display:
                                base.Field27 = "Display";
                                break;
                            case System.Drawing.GraphicsUnit.Document:
                                base.Field27 = "Document";
                                break;
                            case System.Drawing.GraphicsUnit.Inch:
                                base.Field27 = "Inch";
                                break;
                            case System.Drawing.GraphicsUnit.Millimeter:
                                base.Field27 = "Millimeter";
                                break;
                            case System.Drawing.GraphicsUnit.Pixel:
                                base.Field27 = "Pixel";
                                break;
                            case System.Drawing.GraphicsUnit.Point:
                                base.Field27 = "Point";
                                break;
                            case System.Drawing.GraphicsUnit.World:
                                base.Field27 = "World";
                                break;
                        }
                    }
                }
                public String HeaderSourceImageUrl
                {
                    get { return base.Field23; }
                    set { base.Field23 = value; }
                }
                public String HeaderDestinationImageUrl
                {
                    get { return base.Field24; }
                    set { base.Field24 = value; }
                }
                public Int32 LinkedPagId
                {
                    get { return base.Field25.Length > 0 ? Convert.ToInt32(base.Field25) : 0; }
                    set { base.Field25 = value.ToString(); }
                }
                public String HeaderImageUrl
                {
                    get { return base.Field26; }
                    set { base.Field26 = value; }
                }
                public String Type
                {
                    get { return base.Field27; }
                    set { base.Field27 = value; }
                }
                public String Skin
                {
                    get { return base.Field28; }
                    set { base.Field28 = value; }
                }
                public String imgAltText
                {
                    get { return base.Field29; }
                    set { base.Field29 = value; }
                }
                public String ControlledDate
                {
                    get { return base.Field30; }
                    set { base.Field30 = value; }
                }

                public ArticleBase(Int32 SitId, Int32 PagId, Int32 ModId)
                    : base(ObjectType.RXServerDefined_Modules_ArticleType1, SitId, PagId, ModId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString)
                {
                    mSource = new RXServer.Module(SitId, PagId, ModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString);
                    this.DefId = mSource.ModuleDefinitionId;
                    this.Language = mSource.Language;
                    this.ContentPane = mSource.Pane;
                }

                public override void Save()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                    try
                    {
                        base.Name = this.Header.Length > 30 ? this.Header.Substring(0, 30) : this.Header;

                        if (this.HasReadMore)
                        {
                            // Create readmore article things...
                            using (RXServer.Page org = new RXServer.Page(base.SitId, base.PagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                            {
                                // Create readmore page...
                                using (RXServer.Page read = new RXServer.Page(base.SitId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                                {
                                    read.Name = base.Name;
                                    read.Alias = this.ReadMoreAlias;
                                    read.Skin = this.ReadMoreContentPanes;
                                    read.Theme = org.Theme;
                                    read.ParentId = base.PagId;
                                    read.Hidden = true;
                                    read.Refresh = false;
                                    read.Save();
                                    this.ReadMorePagId = read.Id;

                                    // Read Model database and create modules...
                                    foreach (Model.ModuleDefinition md in Model.Settings.GetPageModules(base.PagId))
                                    {
                                        if (!md.DefinitionId.Equals(0))
                                        {
                                            using (RXServer.Module m = new RXServer.Module(CurrentValues.SitId, this.ReadMorePagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                                            {
                                                m.Order = 1;
                                                m.ModuleDefinitionId = md.DefinitionId;
                                                m.Name = md.Name;
                                                m.Alias = md.Name;
                                                m.Description = md.Name;
                                                m.Language = base.Language;
                                                m.Pane = md.ContentPane;
                                                m.Skin = md.Skin;
                                                m.Refresh = false;
                                                m.Save();
                                            }
                                        }
                                    }

                                    // Create readmore module...
                                    using (RXServer.Module m = new RXServer.Module(base.SitId, this.ReadMorePagId, this.ReadMoreModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                                    {
                                        m.ModuleDefinitionId = this.DefId;
                                        m.Name = base.Name;
                                        m.Language = base.Language;
                                        m.Pane = this.ContentPane;
                                        m.Skin = this.ReadMoreContentPanes;
                                        m.Refresh = false;
                                        m.Save();
                                        this.ReadMoreModId = m.Id;

                                        // Create readmore object...
                                        using (RXServer.Object o = new RXServer.Object(this.ObjectType, base.SitId, this.ReadMorePagId, this.ReadMoreModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                                        {
                                            o.Name = base.Name;
                                            o.ModId = this.ReadMoreModId;
                                            o.Alias = this.ReadMoreAlias;
                                            o.Field1 = base.Field1;
                                            o.Field2 = base.Field2;
                                            o.Field3 = base.Field3;
                                            o.Field4 = base.Field4;
                                            o.Field5 = base.Field5;
                                            o.Field6 = base.Field6;
                                            o.Field7 = "0";
                                            o.Field8 = base.Field8;
                                            o.Field9 = base.Field9;
                                            o.Field10 = base.Field10;
                                            o.Field11 = base.Field11;
                                            o.Refresh = false;
                                            o.Save();
                                        }
                                    }
                                }
                            }
                        }

                        mSource.ModuleDefinitionId = this.DefId;
                        mSource.Name = this.Name;
                        mSource.Language = base.Language;
                        mSource.Pane = this.ContentPane;
                        mSource.Save();
                        base.ModId = mSource.Id;
                        base.Save();
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                    }
                }
            }
            #endregion public class ArticleBase

        }
    }
}
