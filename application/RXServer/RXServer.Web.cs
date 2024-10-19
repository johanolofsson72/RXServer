using System;
using System.Collections.Generic;
using System.Text;

namespace RXServer
{
    namespace Web
    {
        namespace Modules
        {
            public class TeaserImage : ArticleBase
            {
                string CLASSNAME = "[Namespace::RXServer::Web::Modules][Class::TeaserImage]";
                public TeaserImage(Int32 SitId, Int32 PagId, Int32 ModId)
                    : base(SitId, PagId, ModId)
                {
                }
            }
            public class TeaserArticle : ArticleBase
            {
                string CLASSNAME = "[Namespace::RXServer::Web::Modules][Class::TeaserArticle]";
                public TeaserArticle(Int32 SitId, Int32 PagId, Int32 ModId)
                    : base(SitId, PagId, ModId)
                {
                }
            }
            public class Article : ArticleBase
            {
                string CLASSNAME = "[Namespace::RXServer::Web::Modules][Class::Article]";
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

                        // Create topBar module...
                        using (RXServer.Module m = new RXServer.Module(base.SitId, base.ReadMorePagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                        {
                            m.Order = 1;
                            m.ModuleDefinitionId = 1;
                            m.Name = "topBar";
                            m.Language = base.Language;
                            m.Pane = "ContentPane1";
                            m.Skin = base.ReadMoreContentPanes;
                            m.Refresh = false;
                            m.Save();
                        }

                        // Create top module...
                        using (RXServer.Module m = new RXServer.Module(base.SitId, base.ReadMorePagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                        {
                            m.Order = 3;
                            m.ModuleDefinitionId = 2;
                            m.Name = "top";
                            m.Language = base.Language;
                            m.Pane = "ContentPane2";
                            m.Skin = base.ReadMoreContentPanes;
                            m.Refresh = false;
                            m.Save();
                        }

                        // Create Menu01 module...
                        using (RXServer.Module m = new RXServer.Module(base.SitId, base.ReadMorePagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                        {
                            m.Order = 5;
                            m.ModuleDefinitionId = 11;
                            m.Name = "Menu01";
                            m.Language = base.Language;
                            m.Pane = "ContentPane11";
                            m.Skin = base.ReadMoreContentPanes;
                            m.Refresh = false;
                            m.Save();
                        }

                        // Create Menu04 module...
                        using (RXServer.Module m = new RXServer.Module(base.SitId, base.ReadMorePagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                        {
                            m.Order = 7;
                            m.ModuleDefinitionId = 12;
                            m.Name = "Menu04";
                            m.Language = base.Language;
                            m.Pane = "ContentPane12";
                            m.Skin = base.ReadMoreContentPanes;
                            m.Refresh = false;
                            m.Save();
                        }

                        // Create Menu03 module...
                        using (RXServer.Module m = new RXServer.Module(base.SitId, base.ReadMorePagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                        {
                            m.Order = 9;
                            m.ModuleDefinitionId = 13;
                            m.Name = "Menu03";
                            m.Language = base.Language;
                            m.Pane = "ContentPane13";
                            m.Skin = base.ReadMoreContentPanes;
                            m.Refresh = false;
                            m.Save();
                        }

                        // Create botBar module...
                        using (RXServer.Module m = new RXServer.Module(base.SitId, base.ReadMorePagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                        {
                            m.Order = 11;
                            m.ModuleDefinitionId = 51;
                            m.Name = "botBar";
                            m.Language = base.Language;
                            m.Pane = "ContentPane51";
                            m.Skin = base.ReadMoreContentPanes;
                            m.Refresh = false;
                            m.Save();
                        }

                        // Create bot module...
                        using (RXServer.Module m = new RXServer.Module(base.SitId, base.ReadMorePagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                        {
                            m.Order = 13;
                            m.ModuleDefinitionId = 52;
                            m.Name = "bot";
                            m.Language = base.Language;
                            m.Pane = "ContentPane52";
                            m.Skin = base.ReadMoreContentPanes;
                            m.Refresh = false;
                            m.Save();
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                    }
                }
            }
            public class ArticleBase : Object
            {
                string CLASSNAME = "[Namespace::RXServer::Web::Modules][Class::ArticleBase]";
                public Int32 DefId;
                public String Pane;
                public String ReadMoreContentPanes;
                public String ReadMoreAlias;
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
                    get { return base.Field5.Equals("0") ? false : true; }
                    set { base.Field5 = value.Equals(true) ? "1" : "0"; }
                }
                public String ImageUrl
                {
                    get { return base.Field6; }
                    set { base.Field6 = value; }
                }
                public Boolean HasReadMore
                {
                    get { return base.Field7.Equals("0") ? false : true; }
                    set { base.Field7 = value.Equals(true) ? "1" : "0"; }
                }
                public String ContentPane
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
                
                public ArticleBase(Int32 SitId, Int32 PagId, Int32 ModId)
                    : base(ObjectType.RXServerDefined_Modules_ArticleType1, SitId, PagId, ModId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString)       
                { 
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

                                    // Create readmore module...
                                    using (RXServer.Module m = new RXServer.Module(base.SitId, this.ReadMorePagId, this.ReadMoreModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                                    {
                                        m.ModuleDefinitionId = this.DefId;
                                        m.Name = base.Name;
                                        m.Language = base.Language;
                                        m.Pane = this.Pane;
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
                        // Create main module...
                        using (RXServer.Module m = new RXServer.Module(base.SitId, base.PagId, base.ModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                        {
                            m.ModuleDefinitionId = this.DefId;
                            m.Name = this.Name;
                            m.Language = base.Language;
                            m.Pane = this.Pane;
                            m.Save();
                            base.ModId = m.Id;
                        }
                        base.Save();
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                    }
                }
            }
        }
    }
}
