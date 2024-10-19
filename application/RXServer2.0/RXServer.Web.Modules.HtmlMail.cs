using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.ComponentModel;
using System.Data;
using iConsulting.iCDataHandler;

namespace RXServer
{
    namespace Web
    {
        namespace Modules
        {

            #region public class HtmlMail
            public class HtmlMail : RXServer.Object, IDisposable
            {
                string CLASSNAME = "[Namespace::RXServer.Web.Modules][Class::HtmlMail]";
                private RXServer.Module mSource;
                public String Header
                {
                    get { return base.Field1; }
                    set { base.Field1 = value; }
                }
                public String Subject
                {
                    get { return base.Field2; }
                    set { base.Field2 = value; }
                }
                public String BodyHeader
                {
                    get { return base.Field3; }
                    set { base.Field3 = value; }
                }
                public String BodyIngress
                {
                    get { return base.Field4; }
                    set { base.Field4 = value; }
                }
                public String BodyText
                {
                    get { return base.Field5; }
                    set { base.Field5 = value; }
                }
                public String BodyImageUrl
                {
                    get { return base.Field6; }
                    set { base.Field6 = value; }
                }
                public String Template
                {
                    get { return base.Field7; }
                    set { base.Field7 = value; }
                }
                public HtmlMail() { }
                public HtmlMail(Int32 HtmId) : base(HtmId, RXServer.Data.DataSource, RXServer.Data.ConnectionString) { }
                public HtmlMail(Int32 SitId, Int32 PagId, Int32 ModId) : base(ObjectType.RXServerDefined_Modules_HtmlMail, SitId, PagId, ModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString)
                {
                    // gör så att jag kan skapa fler än ett alternativ i db...
                    //base.Exist = false;
                    mSource = new RXServer.Module(SitId, PagId, ModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString);
                }
                ~HtmlMail()
                {
                    xFinalize();
                }
                private void xFinalize()
                {
                }
                public void SendTo(String Body, RXServer.Web.Modules.List maillist)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::SendTo]";
                    try
                    {
                        RXServer.Business b = new RXServer.Business();
                        foreach (RXServer.Web.Modules.List.IListItem li in maillist.Items)
                        {   
                            b.SendMail(System.Configuration.ConfigurationManager.AppSettings["DefaultMailServer"].ToString(),
                                System.Configuration.ConfigurationManager.AppSettings["DefaultMailPort"].ToString(),
                                System.Configuration.ConfigurationManager.AppSettings["DefaultMailSender"].ToString(),
                                li.Field1,
                                this.Subject,
                                Body,
                                null);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                public override void Save()
                {
                    if (mSource != null)
                        base.ModId = mSource.Id;
                    base.Refresh = true;
                    base.Save();
                }

            }
            #endregion public class HtmlMail

        }
    }
}