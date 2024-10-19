using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using iConsulting.iCDataHandler;
using RXServer.Web.Model;
using System.Xml;
using System.Reflection;
using Cambia.Web.CoreLib;

namespace RXServer
{
    namespace Web
    {
        namespace List
        {
            #region public class PageFlip
            /// <summary>
            /// RXServer.Web.List.Meta
            /// </summary>
            /// <example>The following is an example of initializing a 
            /// <c>RXServer.Web.List.Meta</c> type:
            ///   <code>
            /// protected void Page_Load(object sender, EventArgs e)
            /// {
            ///     if (!Page.IsPostBack)
            ///         BindData();
            /// }
            /// private void BindData()
            /// {
            ///     ListBox1.Items.Clear();
            ///     using (RXServer.Web.List.Meta m = new RXServer.Web.List.Meta(1, 1))
            ///     {
            ///         m.Sort(RXServer.Web.List.Meta.SortParamEnum.Name, RXServer.Web.List.Meta.SortOrderEnum.Ascending);
            ///         foreach (RXServer.Web.List.Meta.Tag t in m)
            ///         {
            ///             ListBox1.Items.Add(new ListItem(t.Name, t.Id.ToString()));
            ///         }
            ///     }
            /// }
            /// protected void Add_Click(object sender, EventArgs e)
            /// {
            ///     using(RXServer.Web.List.Meta m = new RXServer.Web.List.Meta(1, 1))
            ///     {
            ///         m.Add(new RXServer.Web.List.Meta.Tag(TextBox1.Text, TextBox2.Text));
            ///     }
            ///     BindData();
            /// }
            /// protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
            /// {
            ///     using (RXServer.Web.List.Meta.Tag t = new RXServer.Web.List.Meta.Tag(Convert.ToInt32(ListBox1.SelectedValue)))
            ///     {
            ///         t.Deleted = true;
            ///         t.Save();
            ///     }
            ///     BindData();
            /// }
            ///   </code>
            /// </example>
            public class PageFlip : CollectionBase, IDisposable
            {
                // exempel på hur man skapar en ny typ av lista
                // i detta fallet personer...
                //public class Personer : List
                //{
                //    public Personer(Int32 SitId, Int32 PagId) : base(SitId, PagId) { }
                //    public int Add(Person itm)
                //    {
                //        return base.Add(itm);
                //    }
                //    public void Remove(Person itm)
                //    {
                //        base.Remove(itm);
                //    }
                //    public class Person : ListItem
                //    {
                //        public Person(String Name, String Value) : base(Name, Value) { }
                //    }
                //}

                static String CLASSNAME = "[Namespace::RXServer.Web.List][Class::PageFlip]";

                #region Private Variables
                private Int32 m_sit_id = 0;
                private Int32 m_pag_id = 0;
                private Int32 m_mde_id = 0;
                private Int32 m_def_id = 0;
                private RXServer.Module m_module;
                private RXServer.Object m_settings;
                private String m_header = String.Empty;
                private String m_headerimage = String.Empty;
                private String m_text = String.Empty;
                private String m_contentpane = String.Empty;
                private String m_width = String.Empty;
                private String m_height = String.Empty;
                private Boolean m_hcover = false;
                private Boolean m_transparency = false;
                private String m_prepage = String.Empty;
                private String m_path = String.Empty;
                private String m_filename = String.Empty;
                #endregion Private Variables

                #region Properties
                public String Header
                {
                    get
                    {
                        return this.m_header;
                    }
                    set
                    {
                        this.m_header = value;
                    }
                }
                public String HeaderImage
                {
                    get
                    {
                        return this.m_headerimage;
                    }
                    set
                    {
                        this.m_headerimage = value;
                    }
                }
                public String Text
                {
                    get
                    {
                        return this.m_text;
                    }
                    set
                    {
                        this.m_text = value;
                    }
                }
                public String Width
                {
                    get
                    {
                        return this.m_width;
                    }
                    set
                    {
                        this.m_width = value;
                    }
                }
                public String Height
                {
                    get
                    {
                        return this.m_height;
                    }
                    set
                    {
                        this.m_height = value;
                    }
                }
                public Boolean Hcover
                {
                    get
                    {
                        return this.m_hcover;
                    }
                    set
                    {
                        this.m_hcover = value;
                    }
                }
                public Boolean Transparency
                {
                    get
                    {
                        return this.m_transparency;
                    }
                    set
                    {
                        this.m_transparency = value;
                    }
                }
                public String PrePage
                {
                    get
                    {
                        return this.m_prepage;
                    }
                    set
                    {
                        this.m_prepage = value;
                    }
                }
                public String Path
                {
                    get
                    {
                        return this.m_path;
                    }
                    set
                    {
                        this.m_path = value;
                    }
                }
                public String FileName
                {
                    get
                    {
                        return this.m_filename;
                    }
                    set
                    {
                        this.m_filename = value;
                    }
                }
                #endregion Properties

                #region Constructors
                /// <summary>
                /// Used for creating new PageFlip items only...
                /// </summary>
                public PageFlip(Int32 SitId, Int32 PagId)
                { 
                    string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                    try
                    {
                        this.m_sit_id = SitId;
                        this.m_pag_id = PagId;

                        this.m_module = new RXServer.Module(SitId, PagId, SitId.ToString() + "_" + PagId.ToString(), RXServer.Data.DataSource, RXServer.Data.ConnectionString);
                        this.m_path = HttpContext.Current.Server.UrlDecode(this.m_module.EditSource);
                        this.m_def_id = this.m_module.ModuleDefinitionId;
                        this.m_contentpane = this.m_module.Pane;
                        this.m_module.Refresh = true;
                        this.m_module.Save();
                        this.m_module.Exist = true;

                        this.m_settings = new RXServer.Object(SitId, PagId, "PageFlip_Settings_" + SitId.ToString() + "_" + PagId.ToString(), RXServer.Data.DataSource, RXServer.Data.ConnectionString);
                        this.m_settings.Refresh = true;
                        this.m_settings.Save();
                        this.m_settings.Exist = true;
                        this.m_header = this.m_settings.Field1;
                        this.m_headerimage = this.m_settings.Field9;
                        this.m_text = this.m_settings.Field2;
                        this.m_width = this.m_settings.Field3;
                        this.m_height = this.m_settings.Field4;
                        this.m_hcover = this.m_settings.Field5.Equals("") ? false : this.m_settings.Field5.Equals("0") ? false : true;
                        this.m_transparency = this.m_settings.Field6.Equals("") ? false : this.m_settings.Field6.Equals("0") ? false : true;
                        this.m_filename = this.m_settings.Field8;
                        this.m_prepage = this.m_settings.Field7;

                        GetAllBySitIdPagId();
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                public PageFlip(Int32 SitId, Int32 PagId, Int32 DefId, String ContentPane, String Width, String Height, Boolean Hcover, Boolean Transparency, String PrePage, String Path)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                    try
                    {
                        this.m_sit_id = SitId;
                        this.m_pag_id = PagId;
                        this.m_def_id = DefId;
                        this.m_contentpane = ContentPane;
                        this.m_width = Width;
                        this.m_height = Height;
                        this.m_hcover = Hcover;
                        this.m_transparency = Transparency;
                        this.m_prepage = PrePage;
                        this.m_path = FixPath(Path);
                        this.m_filename = System.IO.Path.GetFileName(this.m_path);

                        this.m_module = new RXServer.Module(SitId, PagId, SitId.ToString() + "_" + PagId.ToString(), RXServer.Data.DataSource, RXServer.Data.ConnectionString);
                        this.m_module.Refresh = true;
                        this.m_module.Save();
                        this.m_module.Exist = true;

                        this.m_settings = new RXServer.Object(SitId, PagId, "PageFlip_Settings_" + SitId.ToString() + "_" + PagId.ToString(), RXServer.Data.DataSource, RXServer.Data.ConnectionString);
                        this.m_settings.Field1 = this.Header;
                        this.m_settings.Field2 = this.Text;
                        this.m_settings.Field3 = this.Width;
                        this.m_settings.Field4 = this.Height;
                        this.m_settings.Field5 = this.Hcover ? "1" : "0";
                        this.m_settings.Field6 = this.Transparency ? "1" : "0";
                        this.m_settings.Field7 = this.PrePage;
                        this.m_settings.Field8 = this.FileName;
                        this.m_settings.Field9 = this.HeaderImage;
                        this.m_settings.Refresh = true;
                        this.m_settings.Save();
                        this.m_settings.Exist = true;

                        GetAllBySitIdPagId();
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                ~PageFlip()
                { xFinalize(); }
                public void Dispose()
                {
                    xFinalize();
                    System.GC.SuppressFinalize(this);
                }
                private void xFinalize()
                {
                }
                #endregion Constructors

                #region Private Functions
                private String FixPath(String Path)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::FixPath]";
                    try
                    {
                        return PathHelper.ToType(Path, PathType.Physical);
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                        return String.Empty;
                    }
                }
                private int _Add(ListItem itm)
                {
                    return List.Add(itm);
                }
                private void GetAllBySitIdPagId()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetAllBySitIdPagId]";
                    DataTable dt = null;
                    try
                    {
                        String CacheItem = RXServer.Data.CACHEITEM_META_COLLECTION + "::SitId" + m_sit_id.ToString() + "::PagId" + m_pag_id.ToString();
                        if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                        if (dt == null)
                        {
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("SELECT obd_id FROM obd_objectdata WHERE obd_type = " + Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_PageFlipItem) + " AND sit_id = " + m_sit_id.ToString() + " AND pag_id = " + m_pag_id.ToString() + " AND obd_deleted = 0");
                            using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                            {
                                dt = oDo.GetDataTable(sSQL.ToString());
                            }
                            RXServer.Data.CacheInsert(CacheItem, dt);
                        }
                        foreach (DataRow dr in dt.Rows)
                        {
                            ListItem i = new ListItem(Convert.ToInt32(dr["obd_id"].ToString()));
                            this._Add(i);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                #endregion Private Functions

                #region Public Functions
                public void Save()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                    try
                    {
                        //GetAllBySitIdPagId();
                        this.m_module.EditSource = HttpContext.Current.Server.UrlEncode(this.m_path);
                        this.m_module.ModuleDefinitionId = this.m_def_id;
                        this.m_module.Pane = this.m_contentpane;
                        this.m_module.Refresh = true;
                        this.m_module.Save();
                        this.m_module.ResetThis();

                        this.m_settings.Field1 = this.Header;
                        this.m_settings.Field2 = this.Text;
                        this.m_settings.Field3 = this.Width;
                        this.m_settings.Field4 = this.Height;
                        this.m_settings.Field5 = this.Hcover ? "1" : "0";
                        this.m_settings.Field6 = this.Transparency ? "1" : "0";
                        this.m_settings.Field7 = this.PrePage;
                        this.m_settings.Field8 = this.FileName;
                        this.m_settings.Field9 = this.HeaderImage;
                        this.m_settings.Refresh = true;
                        this.m_settings.Save();

                        XmlTextWriter textWriter = new XmlTextWriter(this.m_path, null);
                        textWriter.WriteStartDocument();
                        textWriter.WriteComment("This file is generated by RXServer and");
                        textWriter.WriteComment("should not be configured by hand.");
                        textWriter.WriteStartElement("content");
                        textWriter.WriteAttributeString("width", this.m_width);
                        textWriter.WriteAttributeString("height", this.m_height);
                        textWriter.WriteAttributeString("hcover", this.m_hcover ? "true" : "false");
                        textWriter.WriteAttributeString("transparency", this.m_transparency ? "true" : "false");
                        textWriter.WriteAttributeString("prepage", this.m_prepage);

                        foreach (ListItem li in this.List)
                        {
                            textWriter.WriteStartElement("page", "");
                            textWriter.WriteAttributeString("src", li.Src);
                            textWriter.WriteAttributeString("preLoad", li.PreLoad ? "true" : "false");
                            textWriter.WriteEndElement();
                        }

                        textWriter.WriteEndElement();

                        textWriter.WriteEndDocument();
                        textWriter.Close();
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                public static void ResetThis()
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
                    try
                    {
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_META_ID);
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_META_ALIAS);
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_META_COLLECTION);
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, "");
                    }
                }
                public virtual int Add(ListItem itm)
                {
                    itm.SitId = this.m_sit_id;
                    itm.PagId = this.m_pag_id;
                    itm.ModId = this.m_module.Id; 
                    itm.Save();
                    return List.Add(itm);
                }
                public virtual void Remove(ListItem itm)
                {
                    itm.Deleted = true;
                    itm.Update();
                    List.Remove(itm);
                }
                public virtual ListItem this[int index]
                {
                    get
                    {
                        return ((ListItem)List[index]);
                    }
                    set
                    {
                        List[index] = value;
                    }
                }
                #endregion Public Functions

                public class ListItem : IDisposable
                {
                    static String CLASSNAME = "[Namespace::RXServer.Web.List.PageFlip][Class::ListItem]";

                    #region Private Variables
                    private Boolean m_exists = false;

                    private Int32 m_itm_id = 0;
                    private Int32 m_sit_id = 0;
                    private Int32 m_pag_id = 0;
                    private Int32 m_mod_id = 0;
                    private Int32 m_sta_id = 0;
                    private Int32 m_lng_id = 0;
                    private Int32 m_itm_parentid = 0;
                    private Int32 m_itm_order = 0;
                    private String m_itm_title = String.Empty;
                    private String m_itm_alias = String.Empty;
                    private String m_itm_description = String.Empty;
                    private String m_itm_type = String.Empty;
                    private String m_itm_src = String.Empty;
                    private Boolean m_itm_preload = false;
                    private DateTime m_itm_createddate = DateTime.Now;
                    private String m_itm_createdby = String.Empty;
                    private DateTime m_itm_updateddate = DateTime.Now;
                    private String m_itm_updatedby = String.Empty;
                    private Boolean m_itm_hidden = false;
                    private Boolean m_itm_deleted = false;
                    #endregion Private Variables

                    #region Properties

                    public Boolean Exist
                    {
                        get
                        {
                            return this.m_exists;
                        }
                        set
                        {
                            this.m_exists = value;
                        }
                    }
                    public Int32 SitId
                    {
                        get
                        {
                            return this.m_sit_id;
                        }
                        set
                        {
                            this.m_sit_id = value;
                        }
                    }
                    public Int32 PagId
                    {
                        get
                        {
                            return this.m_pag_id;
                        }
                        set
                        {
                            this.m_pag_id = value;
                        }
                    }
                    public Int32 ModId
                    {
                        get
                        {
                            return this.m_mod_id;
                        }
                        set
                        {
                            this.m_mod_id = value;
                        }
                    }
                    public Int32 Id
                    {
                        get
                        {
                            return this.m_itm_id;
                        }
                        set
                        {
                            this.m_itm_id = value;
                        }
                    }
                    public Int32 Status
                    {
                        get
                        {
                            return this.m_sta_id;
                        }
                        set
                        {
                            this.m_sta_id = value;
                        }
                    }
                    public Int32 Language
                    {
                        get
                        {
                            return this.m_lng_id;
                        }
                        set
                        {
                            this.m_lng_id = value;
                        }
                    }
                    public Int32 ParentId
                    {
                        get
                        {
                            return this.m_itm_parentid;
                        }
                        set
                        {
                            this.m_itm_parentid = value;
                        }
                    }
                    public Int32 Order
                    {
                        get
                        {
                            return this.m_itm_order;
                        }
                        set
                        {
                            this.m_itm_order = value;
                        }
                    }
                    public String Name
                    {
                        get
                        {
                            return this.m_itm_title;
                        }
                        set
                        {
                            this.m_itm_title = Common.SafeString(value);
                        }
                    }
                    public String Alias
                    {
                        get
                        {
                            return this.m_itm_alias;
                        }
                        set
                        {
                            this.m_itm_alias = Common.SafeString(value);
                        }
                    }
                    public String Description
                    {
                        get
                        {
                            return this.m_itm_description;
                        }
                        set
                        {
                            this.m_itm_description = Common.SafeString(value);
                        }
                    }
                    public String Type
                    {
                        get { return this.m_itm_type; }
                        set { this.m_itm_type = value; }
                    }
                    public String Src
                    {
                        get { return this.m_itm_src; }
                        set { this.m_itm_src = value; }
                    }
                    public Boolean PreLoad
                    {
                        get { return this.m_itm_preload; }
                        set { this.m_itm_preload = value; }
                    }
                    public DateTime CreatedDate
                    {
                        get
                        {
                            return this.m_itm_createddate;
                        }
                        set
                        {
                            this.m_itm_createddate = value;
                        }
                    }
                    public string CreatedBy
                    {
                        get
                        {
                            return this.m_itm_createdby;
                        }
                        set
                        {
                            this.m_itm_createdby = Common.SafeString(value);
                        }
                    }
                    public DateTime UpdatedDate
                    {
                        get
                        {
                            return this.m_itm_updateddate;
                        }
                        set
                        {
                            this.m_itm_updateddate = value;
                        }
                    }
                    public string UpdatedBy
                    {
                        get
                        {
                            return this.m_itm_updatedby;
                        }
                        set
                        {
                            this.m_itm_updatedby = Common.SafeString(value);
                        }
                    }
                    public Boolean Hidden
                    {
                        get
                        {
                            return this.m_itm_hidden;
                        }
                        set
                        {
                            this.m_itm_hidden = value;
                        }
                    }
                    public Boolean Deleted
                    {
                        get
                        {
                            return this.m_itm_deleted;
                        }
                        set
                        {
                            this.m_itm_deleted = value;
                        }
                    }

                    #endregion Properties

                    #region Constructors
                    public ListItem() { }
                    public ListItem(Int32 ItmId)
                    {
                        m_itm_id = ItmId;
                        GetById();
                    }
                    public ListItem(String Src, Boolean PreLoad)
                    {
                        this.Src = Src;
                        this.PreLoad = PreLoad;
                    }
                    ~ListItem()
                    { xFinalize(); }
                    public void Dispose()
                    {
                        xFinalize();
                        System.GC.SuppressFinalize(this);
                    }
                    private void xFinalize()
                    {
                    }
                    #endregion Constructors

                    #region Public Functions
                    /// <summary>
                    /// Update
                    /// </summary>
                    public virtual void Update()
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::Update]";
                        try
                        {
                            if (this.m_exists)
                            {
                                StringBuilder sSQL = new StringBuilder();
                                sSQL.Append("UPDATE obd_objectdata SET ");
                                sSQL.Append("sta_id = " + this.m_sta_id.ToString() + ", ");
                                sSQL.Append("lng_id = " + this.m_lng_id.ToString() + ", ");
                                sSQL.Append("obd_parentid = " + this.m_itm_parentid.ToString() + ", ");
                                sSQL.Append("obd_order = " + this.m_itm_order.ToString() + ", ");
                                sSQL.Append("obd_title = '" + this.m_itm_title.ToString() + "', ");
                                sSQL.Append("obd_alias = '" + this.m_itm_alias.ToString() + "', ");
                                sSQL.Append("obd_description = '" + this.m_itm_description.ToString() + "', ");
                                sSQL.Append("obd_varchar1 = '" + this.m_itm_src.ToString() + "', ");
                                sSQL.Append("obd_varchar2 = '" + Convert.ToString(!this.m_itm_preload ? "0" : "1") + "', ");
                                sSQL.Append("obd_createddate = '" + this.m_itm_createddate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                                sSQL.Append("obd_createdby = '" + this.m_itm_createdby.ToString() + "', ");
                                sSQL.Append("obd_updateddate = '" + this.m_itm_updateddate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                                sSQL.Append("obd_updatedby = '" + this.m_itm_updatedby.ToString() + "', ");
                                sSQL.Append("obd_hidden = " + Convert.ToString(!this.m_itm_hidden ? "0" : "1") + ", ");
                                sSQL.Append("obd_deleted = " + Convert.ToString(!this.m_itm_deleted ? "0" : "1") + " ");
                                sSQL.Append("WHERE obd_id = " + m_itm_id.ToString());
                                using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                                    oDo.ExecuteNonQuery(sSQL.ToString());

                                ResetThis();
                                SortAll();

                                if (this.m_itm_deleted)
                                    DeleteRelations();
                            }
                            else
                            {
                                Save();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    /// <summary>
                    /// Save
                    /// </summary>
                    public virtual void Save()
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
                        try
                        {
                            if (!this.m_exists)
                            {
                                DataSet ds = new DataSet();
                                StringBuilder sSQL = new StringBuilder();
                                sSQL.Append("INSERT INTO obd_objectdata (sta_id, sit_id, pag_id, mod_id, lng_id, obd_parentid, obd_order, obd_type, obd_title, obd_alias, obd_description, obd_varchar1, obd_varchar2, obd_createddate, obd_createdby, obd_updateddate, obd_updatedby, obd_hidden, obd_deleted) VALUES ( ");
                                sSQL.Append(this.Status.ToString() + ", ");
                                sSQL.Append(this.m_sit_id.ToString() + ", ");
                                sSQL.Append(this.m_pag_id.ToString() + ", ");
                                sSQL.Append(this.m_mod_id.ToString() + ", ");
                                sSQL.Append(this.Language.ToString() + ", ");
                                sSQL.Append(this.ParentId.ToString() + ", ");
                                sSQL.Append(this.Order.ToString() + ", ");
                                sSQL.Append(Convert.ToString((Int32)RXServer.ObjectType.RXServerDefined_Modules_PageFlipItem) + ", ");
                                sSQL.Append("'" + this.Name + "', ");
                                sSQL.Append("'" + this.Alias + "', ");
                                sSQL.Append("'" + this.Description + "', ");
                                sSQL.Append("'" + this.Src + "', ");
                                sSQL.Append("'" + Convert.ToString(!this.PreLoad ? "0" : "1") + "', ");
                                sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                                if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
                                if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                sSQL.Append("0, ");
                                sSQL.Append("0)");
                                using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, true))
                                {
                                    Int32 ret = oDo.ExecuteNonQuery(sSQL.ToString());
                                    this.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                                }

                                this.m_exists = true;
                                ResetThis();
                                SortAll();
                            }
                            else
                            {
                                Update();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    #endregion Public Functions

                    #region Private Functions
                    private void GetById()
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::GetById]";
                        DataTable dt = null;
                        try
                        {
                            String CacheItem = RXServer.Data.CACHEITEM_LIST_ID + "::ItmId" + m_itm_id.ToString();
                            if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                            if (dt == null)
                            {
                                StringBuilder sSQL = new StringBuilder();
                                sSQL.Append("SELECT * FROM obd_objectdata WHERE obd_id = " + m_itm_id.ToString());
                                using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true))
                                {
                                    dt = oDo.GetDataTable(sSQL.ToString());
                                }
                                RXServer.Data.CacheInsert(CacheItem, dt);
                            }
                            if (dt.Rows.Count > 0)
                            {
                                DataRow dr = dt.Rows[0];
                                this.m_itm_id = Convert.ToInt32(dr["obd_id"]);
                                this.m_sta_id = Convert.ToInt32(dr["sta_id"]);
                                this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                                this.m_itm_parentid = Convert.ToInt32(dr["obd_parentid"]);
                                this.m_itm_order = Convert.ToInt32(dr["obd_order"]);
                                this.m_itm_title = Convert.ToString(dr["obd_title"]);
                                this.m_itm_alias = Convert.ToString(dr["obd_alias"]);
                                this.m_itm_description = Convert.ToString(dr["obd_description"]);
                                this.m_itm_src = Convert.ToString(dr["obd_varchar1"]);
                                this.m_itm_preload = dr["obd_varchar2"].ToString().Equals("") ? false : dr["obd_varchar2"].ToString().Equals("0") ? false : true;
                                this.m_itm_createddate = Convert.ToDateTime(dr["obd_createddate"]);
                                this.m_itm_createdby = Convert.ToString(dr["obd_createdby"]);
                                this.m_itm_updateddate = Convert.ToDateTime(dr["obd_updateddate"]);
                                this.m_itm_updatedby = Convert.ToString(dr["obd_updatedby"]);
                                this.m_itm_hidden = Convert.ToBoolean(dr["obd_hidden"]);
                                this.m_itm_deleted = Convert.ToBoolean(dr["obd_deleted"]);
                                this.m_exists = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    private void SortAll()
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::SortAll]";
                        try
                        {
                            Int32 Order = (Int32)OrderMinMax.Min;
                            StringBuilder sSQL = new StringBuilder();
                            sSQL.Append("SELECT * FROM obd_objectdata WHERE obd_deleted = 0 ORDER BY sit_id, pag_id, obd_type, obd_order");
                            using (iCDataObject oDo = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, false))
                            {
                                DataTable dt = oDo.GetDataTable(sSQL.ToString());
                                foreach (DataRow dr in dt.Rows)
                                {
                                    StringBuilder sSQL2 = new StringBuilder();
                                    sSQL2.Append("UPDATE obd_objectdata SET obd_order = " + Order.ToString() + " WHERE obd_id = " + dr["obd_id"].ToString());
                                    using (iCDataObject oDo2 = new iCDataObject(RXServer.Data.DataSource, RXServer.Data.ConnectionString, false, true, false))
                                        oDo2.ExecuteNonQuery(sSQL2.ToString());
                                    Order = Order + (Int32)OrderMinMax.Step;
                                }
                                ResetThis();
                            }
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    private void DeleteRelations()
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::DeleteRelations]";
                        try
                        {
                            // Delete SiteCollection... 
                            // not in use for Objects...

                            // Delete PageCollection...
                            // not in use for Objects...

                            // Delete TaskCollection...
                            // not in use for Objects...

                            // Delete ModuleCollection... 
                            // not in use for Objects...

                            // Delete DocumentCollection...
                            // not in use for Objects...

                            // Delete ObjectCollection...
                            // not in use for Objects...
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                        }
                    }
                    #endregion Private Functions

                    #region public class GenericComparer
                    public int CompareTo(object obj, string Property)
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::CompareTo]";
                        try
                        {
                            Type type = this.GetType();
                            PropertyInfo propertie = type.GetProperty(Property);


                            Type type2 = obj.GetType();
                            PropertyInfo propertie2 = type2.GetProperty(Property);

                            object[] index = null;

                            object Obj1 = propertie.GetValue(this, index);
                            object Obj2 = propertie2.GetValue(obj, index);

                            IComparable Ic1 = (IComparable)Obj1;
                            IComparable Ic2 = (IComparable)Obj2;

                            int ret = Ic1.CompareTo(Ic2);

                            return ret;

                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                            return 0;
                        }
                    }
                    #endregion public class GenericComparer

                }

                #region public class GenericComparer

                public enum SortOrderEnum
                {
                    Ascending,
                    Descending
                }

                public enum SortParamEnum
                {
                    Id,
                    Status,
                    Language,
                    ParentId,
                    Order,
                    Name,
                    Alias,
                    Description,
                    Value,
                    CreatedDate,
                    CreatedBy,
                    UpdatedDate,
                    UpdatedBy,
                    Hidden,
                    Deleted
                }

                public class GenericComparer : IComparer
                {
                    private String _Property = null;
                    private SortOrderEnum _SortOrder = SortOrderEnum.Ascending;

                    public String SortProperty
                    {
                        get { return _Property; }
                        set { _Property = value; }
                    }

                    public SortOrderEnum SortOrder
                    {
                        get { return _SortOrder; }
                        set { _SortOrder = value; }
                    }


                    public int Compare(object x, object y)
                    {
                        string FUNCTIONNAME = CLASSNAME + "[Function::Compare]";
                        try
                        {
                            ListItem ing1 = (ListItem)x;
                            ListItem ing2 = (ListItem)y;

                            if (this.SortOrder.Equals(SortOrderEnum.Ascending))
                                return ing1.CompareTo(ing2, this.SortProperty);
                            else
                                return ing2.CompareTo(ing1, this.SortProperty);
                        }
                        catch (Exception ex)
                        {
                            Error.Report(ex, FUNCTIONNAME, "");
                            return 0;
                        }

                    }
                }

                public void Sort(SortParamEnum SortBy, SortOrderEnum SortOrder)
                {
                    GenericComparer comparer = new GenericComparer();
                    comparer.SortProperty = SortBy.ToString();
                    comparer.SortOrder = SortOrder;
                    this.InnerList.Sort(comparer);
                }

                #endregion public class GenericComparer
            }
            #endregion public class PageFlip

            //#region public class PageFlip

            //[Serializable]
            //public class PageFlip : IDisposable, IEnumerable
            //{
            //    string CLASSNAME = "[Namespace::RXServer.Web.Modules][Class::PageFlip]";
            //    private RXServer.Module mSource;
            //    public Int32 DefId;
            //    public String ContentPane = String.Empty;
            //    public String Alias = String.Empty;

            //    #region DataHandler Variables

            //    private string m_datasource;
            //    private string m_connectionstring;

            //    #endregion DataHandler Variables

            //    #region Private Variables

            //    private PageFlipItem m_object;
            //    private PageFlipItem[] m_objects;
            //    private ObjectType m_objecttype = ObjectType.RXServerDefined_Modules_PageFlipItem;
            //    private Int32 m_sit_id = 0;
            //    private Int32 m_pag_id = 0;
            //    private Int32 m_mod_id = 0;
            //    private Int32 m_obd_parentid = 0;
            //    private String m_obd_alias = String.Empty;
            //    private bool m_autoupdate = false;
            //    private DataTable m_dtobjects;
            //    private Boolean m_refresh;
            //    private String m_width = String.Empty;
            //    private String m_height = String.Empty;
            //    private Boolean m_hcover = false;
            //    private Boolean m_transparency = false;
            //    private String m_prepage = String.Empty;
            //    private String m_path = String.Empty;

            //    #endregion Private Variables

            //    #region Properties

            //    public IEnumerator GetEnumerator()
            //    {
            //        return new RXPageFlipEnum(this.m_objects);
            //    }
               
            //    public PageFlipItem this[Int32 index]
            //    {
            //        get
            //        {
            //            string FUNCTIONNAME = CLASSNAME + "[Function::PageFlipItem]";
            //            try
            //            {
            //                this.m_object = (PageFlipItem)this.m_objects[index];
            //                return this.m_object;
            //            }
            //            catch (Exception ex)
            //            {
            //                Error.Report(ex, FUNCTIONNAME, "");
            //                return new PageFlipItem();
            //            }
            //        }
            //    }

            //    public PageFlipItem[] Items
            //    {
            //        get
            //        {
            //            string FUNCTIONNAME = CLASSNAME + "[Function::PageFlipItem]";
            //            try
            //            {
            //                return this.m_objects;
            //            }
            //            catch (Exception ex)
            //            {
            //                Error.Report(ex, FUNCTIONNAME, "");
            //                return new PageFlipItem[0];
            //            }
            //        }
            //    }

            //    public PageFlipItem GetPageFlipItem(Int32 Id)
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::PageFlipItem]";
            //        try
            //        {
            //            foreach (PageFlipItem o in this.m_objects)
            //            {
            //                if (o.Id == Id)
            //                {
            //                    return o;
            //                }
            //            }
            //            return new PageFlipItem();
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //            return new PageFlipItem();
            //        }
            //    }

            //    public PageFlipItem GetPageFlipItem(string Alias)
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::PageFlipItem]";
            //        try
            //        {
            //            foreach (PageFlipItem o in this.m_objects)
            //            {
            //                if (o.Alias.ToLower() == Alias.ToLower())
            //                {
            //                    return o;
            //                }
            //            }
            //            return new PageFlipItem();
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //            return new PageFlipItem();
            //        }
            //    }

            //    public bool Contains(Int32 Id)
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            //        try
            //        {
            //            foreach (PageFlipItem o in this.m_objects)
            //            {
            //                if (o.Id == Id)
            //                {
            //                    return true;
            //                }
            //            }
            //            return false;
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //            return false;
            //        }
            //    }

            //    public bool Contains(string Alias)
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            //        try
            //        {
            //            foreach (PageFlipItem o in this.m_objects)
            //            {
            //                if (o.Alias.ToLower() == Alias.ToLower())
            //                {
            //                    return true;
            //                }
            //            }
            //            return false;
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //            return false;
            //        }
            //    }

            //    public bool Refresh
            //    {
            //        get
            //        {
            //            return this.m_refresh;
            //        }
            //        set
            //        {
            //            this.m_refresh = value;
            //        }
            //    }

            //    public String Width
            //    {
            //        get
            //        {
            //            return this.m_width;
            //        }
            //        set
            //        {
            //            this.m_width = value;
            //        }
            //    }

            //    public String Height
            //    {
            //        get
            //        {
            //            return this.m_height;
            //        }
            //        set
            //        {
            //            this.m_height = value;
            //        }
            //    }

            //    public Boolean Hcover
            //    {
            //        get
            //        {
            //            return this.m_hcover;
            //        }
            //        set
            //        {
            //            this.m_hcover = value;
            //        }
            //    }

            //    public Boolean Transparency
            //    {
            //        get
            //        {
            //            return this.m_transparency;
            //        }
            //        set
            //        {
            //            this.m_transparency = value;
            //        }
            //    }

            //    public String PrePage
            //    {
            //        get
            //        {
            //            return this.m_prepage;
            //        }
            //        set
            //        {
            //            this.m_prepage = value;
            //        }
            //    }

            //    public String Path
            //    {
            //        get
            //        {
            //            return this.m_path;
            //        }
            //        set
            //        {
            //            this.m_path = value;
            //        }
            //    }
                

            //    #endregion Properties

            //    #region Constructors

            //    public PageFlip() { }

            //    public PageFlip(Int32 SitId, Int32 PagId, String Alias, Int32 DefId, String ContentPane, String Width, String Height, Boolean Hcover, Boolean Transparency, String PrePage, String Path)
            //        : this(SitId, PagId, Alias, DefId, ContentPane, Width, Height, Hcover, Transparency, PrePage, Path, true)
            //    {
            //    }

            //    public PageFlip(Int32 SitId, Int32 PagId, String Alias, Int32 DefId, String ContentPane, String Width, String Height, Boolean Hcover, Boolean Transparency, String PrePage, String Path, Boolean Refresh)
            //    {
            //        mSource = new RXServer.Module(SitId, PagId, Alias, RXServer.Data.DataSource, RXServer.Data.ConnectionString);
            //        this.DefId = DefId;
            //        this.ContentPane = ContentPane;

            //        this.m_datasource = RXServer.Data.DataSource;
            //        this.m_connectionstring = RXServer.Data.ConnectionString;
            //        this.m_sit_id = SitId;
            //        this.m_pag_id = PagId;
            //        this.Alias = Alias;
            //        this.m_width = Width;
            //        this.m_height = Height;
            //        this.m_hcover = Hcover;
            //        this.m_transparency = Transparency;
            //        this.m_prepage = PrePage;
            //        this.m_path = Path;
            //        this.m_autoupdate = false;
            //        this.m_refresh = Refresh;
            //        GetAliasAll();
            //    }

            //    public PageFlip(Int32 SitId, Int32 PagId, Int32 ModId)
            //    {
            //        mSource = new RXServer.Module(SitId, PagId, ModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString);
            //        this.DefId = mSource.ModuleDefinitionId;
            //        this.ContentPane = mSource.Pane;
            //        this.m_path = mSource.EditSource;

            //        this.m_datasource = RXServer.Data.DataSource;
            //        this.m_connectionstring = RXServer.Data.ConnectionString;
            //        this.m_sit_id = SitId;
            //        this.m_pag_id = PagId;
            //        this.m_mod_id = ModId;
            //        this.Alias = SitId.ToString() + "_" + PagId.ToString() + "_" + ModId.ToString();
            //        //this.m_width = Width;
            //        //this.m_height = Height;
            //        //this.m_hcover = Hcover;
            //        //this.m_transparency = Transparency;
            //        //this.m_prepage = PrePage;
            //        //this.m_path = Path;
            //        //this.m_autoupdate = false;
            //        //this.m_refresh = Refresh;
            //        GetAliasAll();
            //    }

            //    ~PageFlip()
            //    {
            //        xFinalize();
            //    }
            //    public void Dispose()
            //    {
            //        xFinalize();
            //        System.GC.SuppressFinalize(this);
            //    }
            //    private void xFinalize()
            //    {
            //        if (!this.Refresh)
            //            ResetThis();
            //        if (RXServer.Data.ActivateGC)
            //            GC.Collect();
            //    }

            //    #endregion Constructors

            //    #region Public Methods

            //    public void Add(PageFlipItem p)
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            //        try
            //        {
            //            this.Add(ref p);
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //        }
            //    }
            //    public void Add(ref PageFlipItem p)
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            //        try
            //        {
            //            DataSet ds = new DataSet();
            //            StringBuilder sSQL = new StringBuilder();
            //            sSQL.Append("INSERT INTO obd_objectdata (lng_id, obd_parentid, sit_id, pag_id, mod_id, obd_order, obd_type, obd_title, obd_alias, obd_description, obd_varchar1, obd_varchar2, obd_varchar3, obd_varchar4, obd_varchar5, obd_varchar6, obd_varchar7, obd_varchar8, obd_varchar9, obd_varchar10, obd_varchar11, obd_varchar12, obd_varchar13, obd_varchar14, obd_varchar15, obd_varchar16, obd_varchar17, obd_varchar18, obd_varchar19, obd_varchar20, obd_varchar21, obd_varchar22, obd_varchar23, obd_varchar24, obd_varchar25, obd_varchar26, obd_varchar27, obd_varchar28, obd_varchar29, obd_varchar30, obd_varchar31, obd_varchar32, obd_varchar33, obd_varchar34, obd_varchar35, obd_varchar36, obd_varchar37, obd_varchar38, obd_varchar39, obd_varchar40, obd_varchar41, obd_varchar42, obd_varchar43, obd_varchar44, obd_varchar45, obd_varchar46, obd_varchar47, obd_varchar48, obd_varchar49, obd_varchar50, obd_createddate, obd_createdby, obd_updateddate, obd_updatedby, obd_hidden, obd_deleted) VALUES ( ");
            //            sSQL.Append(p.Language.ToString() + ", ");
            //            sSQL.Append(p.ParentId.ToString() + ", ");
            //            sSQL.Append(p.SitId.ToString() + ", ");
            //            sSQL.Append(p.PagId.ToString() + ", ");
            //            sSQL.Append(p.ModId.ToString() + ", ");
            //            sSQL.Append(Convert.ToString((Int32)OrderMinMax.Max) + ", ");
            //            sSQL.Append(Convert.ToString((Int32)p.ObjectType) + ", ");
            //            sSQL.Append("'" + p.Name + "', ");
            //            sSQL.Append("'" + p.Alias + "', ");
            //            sSQL.Append("'" + p.Description + "', ");
            //            sSQL.Append("'" + p.Field1 + "', ");
            //            sSQL.Append("'" + p.Field2 + "', ");
            //            sSQL.Append("'" + p.Field3 + "', ");
            //            sSQL.Append("'" + p.Field4 + "', ");
            //            sSQL.Append("'" + p.Field5 + "', ");
            //            sSQL.Append("'" + p.Field6 + "', ");
            //            sSQL.Append("'" + p.Field7 + "', ");
            //            sSQL.Append("'" + p.Field8 + "', ");
            //            sSQL.Append("'" + p.Field9 + "', ");
            //            sSQL.Append("'" + p.Field10 + "', ");
            //            sSQL.Append("'" + p.Field11 + "', ");
            //            sSQL.Append("'" + p.Field12 + "', ");
            //            sSQL.Append("'" + p.Field13 + "', ");
            //            sSQL.Append("'" + p.Field14 + "', ");
            //            sSQL.Append("'" + p.Field15 + "', ");
            //            sSQL.Append("'" + p.Field16 + "', ");
            //            sSQL.Append("'" + p.Field17 + "', ");
            //            sSQL.Append("'" + p.Field18 + "', ");
            //            sSQL.Append("'" + p.Field19 + "', ");
            //            sSQL.Append("'" + p.Field20 + "', ");
            //            sSQL.Append("'" + p.Field21 + "', ");
            //            sSQL.Append("'" + p.Field22 + "', ");
            //            sSQL.Append("'" + p.Field23 + "', ");
            //            sSQL.Append("'" + p.Field24 + "', ");
            //            sSQL.Append("'" + p.Field25 + "', ");
            //            sSQL.Append("'" + p.Field26 + "', ");
            //            sSQL.Append("'" + p.Field27 + "', ");
            //            sSQL.Append("'" + p.Field28 + "', ");
            //            sSQL.Append("'" + p.Field29 + "', ");
            //            sSQL.Append("'" + p.Field30 + "', ");
            //            sSQL.Append("'" + p.Field31 + "', ");
            //            sSQL.Append("'" + p.Field32 + "', ");
            //            sSQL.Append("'" + p.Field33 + "', ");
            //            sSQL.Append("'" + p.Field34 + "', ");
            //            sSQL.Append("'" + p.Field35 + "', ");
            //            sSQL.Append("'" + p.Field36 + "', ");
            //            sSQL.Append("'" + p.Field37 + "', ");
            //            sSQL.Append("'" + p.Field38 + "', ");
            //            sSQL.Append("'" + p.Field39 + "', ");
            //            sSQL.Append("'" + p.Field40 + "', ");
            //            sSQL.Append("'" + p.Field41 + "', ");
            //            sSQL.Append("'" + p.Field42 + "', ");
            //            sSQL.Append("'" + p.Field43 + "', ");
            //            sSQL.Append("'" + p.Field44 + "', ");
            //            sSQL.Append("'" + p.Field45 + "', ");
            //            sSQL.Append("'" + p.Field46 + "', ");
            //            sSQL.Append("'" + p.Field47 + "', ");
            //            sSQL.Append("'" + p.Field48 + "', ");
            //            sSQL.Append("'" + p.Field49 + "', ");
            //            sSQL.Append("'" + p.Field50 + "', ");
            //            sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
            //            if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
            //            sSQL.Append("'" + DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss") + "', ");
            //            if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
            //            sSQL.Append("0, ");
            //            sSQL.Append("0)");
            //            using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
            //            {
            //                Int32 ret = oDo.ExecuteNonQuery(sSQL.ToString());
            //                p.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
            //            }
            //            SortAll();
            //            GetAliasAll();
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //        }
            //    }
            //    public void Remove(PageFlipItem p)
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            //        try
            //        {
            //            this.Remove(p.Id);
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //        }
            //    }
            //    public void Remove(Int32 Id)
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            //        try
            //        {
            //            StringBuilder sSQL = new StringBuilder();
            //            sSQL.Append("UPDATE obd_objectdata SET obd_deleted = 1 ");
            //            sSQL.Append("WHERE obd_id = " + Id.ToString());
            //            using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
            //                oDo.ExecuteNonQuery(sSQL.ToString());
            //            SortAll();
            //            GetAliasAll();
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //        }
            //    }
            //    public void Clear()
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::Clear]";
            //        try
            //        {
            //            this.m_objects = null;
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //        }
            //    }
            //    public Int32 Count()
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::Count]";
            //        try
            //        {
            //            return this.m_objects.Length;
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //            return 0;
            //        }
            //    }
            //    public DataTable DataTable()
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            //        try
            //        {
            //            return this.m_dtobjects;
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //            return new DataTable();
            //        }
            //    }
            //    public DataTable DataTable(ObjectSortField SortField, SortOrder SortOrder)
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            //        try
            //        {
            //            DataView v = new DataView(m_dtobjects);
            //            v.Sort = RetriveSortField(SortField) + Convert.ToString((Int32)SortOrder == 1 ? String.Empty : " DESC");
            //            return v.ToTable();
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //            return new DataTable();
            //        }
            //    }
            //    public void Save()
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
            //        try
            //        {
            //            mSource.EditSource = this.m_path;
            //            mSource.ModuleDefinitionId = this.DefId;
            //            mSource.Pane = this.ContentPane;
            //            mSource.Refresh = true;
            //            mSource.Save();
            //            mSource.ResetThis();

            //            XmlTextWriter textWriter = new XmlTextWriter(this.m_path, null);
            //            textWriter.WriteStartDocument();
            //            textWriter.WriteComment("This file is generated by RXServer and");
            //            textWriter.WriteComment("should not be configured by hand.");
            //            textWriter.WriteStartElement("content");
            //            textWriter.WriteAttributeString("width", this.m_width);
            //            textWriter.WriteAttributeString("height", this.m_height);
            //            textWriter.WriteAttributeString("hcover", this.m_hcover ? "true" : "false");
            //            textWriter.WriteAttributeString("transparency", this.m_transparency ? "true" : "false");
            //            textWriter.WriteAttributeString("prepage", this.m_prepage);

            //            foreach (PageFlipItem p in this.m_objects)
            //            {
            //                textWriter.WriteStartElement("page", "");
            //                textWriter.WriteAttributeString("src", p.Src);
            //                textWriter.WriteAttributeString("preLoad", p.PreLoad ? "true" : "false");
            //                textWriter.WriteEndElement();
            //            }

            //            textWriter.WriteEndElement();

            //            textWriter.WriteEndDocument();
            //            textWriter.Close();

                        
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //        }
            //    }

            //    #endregion Public Methods

            //    #region Private Methods

            //    private void ResetThis()
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            //        try
            //        {
            //            RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_ID);
            //            RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_ALIAS);
            //            RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_COLLECTION);
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //        }
            //    }
            //    private String RetriveSortField(ObjectSortField SortField)
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::RetriveSortField]";
            //        try
            //        {

            //            if ((Int32)SortField == 1) return "obd_id";
            //            if ((Int32)SortField == 2) return "lng_id";
            //            if ((Int32)SortField == 3) return "obd_parentid";
            //            if ((Int32)SortField == 4) return "sit_id";
            //            if ((Int32)SortField == 5) return "pag_id";
            //            if ((Int32)SortField == 64) return "mod_id";
            //            if ((Int32)SortField == 6) return "obd_order";
            //            if ((Int32)SortField == 7) return "obd_title";
            //            if ((Int32)SortField == 8) return "obd_alias";
            //            if ((Int32)SortField == 9) return "obd_description";
            //            if ((Int32)SortField == 10) return "obd_varchar1";
            //            if ((Int32)SortField == 11) return "obd_varchar2";
            //            if ((Int32)SortField == 12) return "obd_varchar3";
            //            if ((Int32)SortField == 13) return "obd_varchar4";
            //            if ((Int32)SortField == 14) return "obd_varchar5";
            //            if ((Int32)SortField == 15) return "obd_varchar6";
            //            if ((Int32)SortField == 16) return "obd_varchar7";
            //            if ((Int32)SortField == 17) return "obd_varchar8";
            //            if ((Int32)SortField == 18) return "obd_varchar9";
            //            if ((Int32)SortField == 19) return "obd_varchar10";
            //            if ((Int32)SortField == 20) return "obd_varchar11";
            //            if ((Int32)SortField == 21) return "obd_varchar12";
            //            if ((Int32)SortField == 22) return "obd_varchar13";
            //            if ((Int32)SortField == 23) return "obd_varchar14";
            //            if ((Int32)SortField == 24) return "obd_varchar15";
            //            if ((Int32)SortField == 25) return "obd_varchar16";
            //            if ((Int32)SortField == 26) return "obd_varchar17";
            //            if ((Int32)SortField == 27) return "obd_varchar18";
            //            if ((Int32)SortField == 28) return "obd_varchar19";
            //            if ((Int32)SortField == 29) return "obd_varchar20";
            //            if ((Int32)SortField == 30) return "obd_varchar21";
            //            if ((Int32)SortField == 31) return "obd_varchar22";
            //            if ((Int32)SortField == 32) return "obd_varchar23";
            //            if ((Int32)SortField == 33) return "obd_varchar24";
            //            if ((Int32)SortField == 34) return "obd_varchar25";
            //            if ((Int32)SortField == 35) return "obd_varchar26";
            //            if ((Int32)SortField == 36) return "obd_varchar27";
            //            if ((Int32)SortField == 37) return "obd_varchar28";
            //            if ((Int32)SortField == 38) return "obd_varchar29";
            //            if ((Int32)SortField == 39) return "obd_varchar30";
            //            if ((Int32)SortField == 40) return "obd_varchar31";
            //            if ((Int32)SortField == 41) return "obd_varchar32";
            //            if ((Int32)SortField == 42) return "obd_varchar33";
            //            if ((Int32)SortField == 43) return "obd_varchar34";
            //            if ((Int32)SortField == 44) return "obd_varchar35";
            //            if ((Int32)SortField == 45) return "obd_varchar36";
            //            if ((Int32)SortField == 46) return "obd_varchar37";
            //            if ((Int32)SortField == 47) return "obd_varchar38";
            //            if ((Int32)SortField == 48) return "obd_varchar39";
            //            if ((Int32)SortField == 49) return "obd_varchar40";
            //            if ((Int32)SortField == 50) return "obd_varchar41";
            //            if ((Int32)SortField == 51) return "obd_varchar42";
            //            if ((Int32)SortField == 52) return "obd_varchar43";
            //            if ((Int32)SortField == 53) return "obd_varchar44";
            //            if ((Int32)SortField == 54) return "obd_varchar45";
            //            if ((Int32)SortField == 55) return "obd_varchar46";
            //            if ((Int32)SortField == 56) return "obd_varchar47";
            //            if ((Int32)SortField == 57) return "obd_varchar48";
            //            if ((Int32)SortField == 58) return "obd_varchar49";
            //            if ((Int32)SortField == 59) return "obd_varchar50";
            //            if ((Int32)SortField == 60) return "obd_createddate";
            //            if ((Int32)SortField == 61) return "obd_createdby";
            //            if ((Int32)SortField == 62) return "obd_updateddate";
            //            if ((Int32)SortField == 63) return "obd_updatedby";
            //            return String.Empty;
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //            return String.Empty;
            //        }
            //    }
            //    private void SortAll()
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::SortAll]";
            //        if (!this.Refresh)
            //            return;
            //        try
            //        {
            //            Int32 Order = (Int32)OrderMinMax.Min;
            //            StringBuilder sSQL = new StringBuilder();
            //            sSQL.Append("SELECT * FROM obd_objectdata WHERE obd_deleted = 0 ORDER BY sit_id, pag_id, mod_id, obd_order");
            //            using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
            //            {
            //                DataTable dt = oDo.GetDataTable(sSQL.ToString());
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    StringBuilder sSQL2 = new StringBuilder();
            //                    sSQL2.Append("UPDATE obd_objectdata SET obd_order = " + Order.ToString() + " WHERE obd_id = " + dr["obd_id"].ToString());
            //                    using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
            //                        oDo2.ExecuteNonQuery(sSQL2.ToString());
            //                    Order = Order + (Int32)OrderMinMax.Step;
            //                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_ID + dr["obd_id"].ToString());
            //                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_ID + dr["obd_alias"].ToString());
            //                }
            //                ResetThis();
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //        }
            //    }
            //    private void GetAliasAll()
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::GetAliasAll]";
            //        DataTable dt = null;
            //        if (!this.Refresh)
            //            return;
            //        try
            //        {
            //            String CacheItem = RXServer.Data.CACHEITEM_OBJECT_COLLECTION +
            //                "::SitId" + this.m_sit_id.ToString() +
            //                "::PagId" + this.m_pag_id.ToString() +
            //                "::Alias" + this.m_mod_id.ToString() +
            //                "::ObdType" + Convert.ToString((Int32)this.m_objecttype);
            //            if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
            //            if (dt == null)
            //            {
            //                StringBuilder sSQL = new StringBuilder();
            //                sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND mod_alias = '" + this.Alias + "'" + Convert.ToString(this.m_objecttype != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_objecttype) : String.Empty) + " AND obd_deleted = 0 ORDER BY obd_order");
            //                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
            //                {
            //                    dt = oDo.GetDataTable(sSQL.ToString());
            //                }
            //                RXServer.Data.CacheInsert(CacheItem, dt);
            //            }
            //            if (dt.Rows.Count > 0)
            //            {
            //                this.m_dtobjects = dt;
            //                Int32 index = 0;
            //                this.m_objects = new PageFlipItem[dt.Rows.Count];
            //                foreach (DataRow dr in dt.Rows)
            //                {
            //                    this.m_objects[index] = new PageFlipItem();
            //                    this.m_objects[index].Id = Convert.ToInt32(dr["obd_id"]);
            //                    this.m_objects[index].Language = Convert.ToInt32(dr["lng_id"]);
            //                    this.m_objects[index].ParentId = Convert.ToInt32(dr["obd_parentid"]);
            //                    this.m_objects[index].Order = Convert.ToInt32(dr["obd_order"]);
            //                    this.m_objects[index].ObjectType = (ObjectType)Convert.ToInt32(dr["obd_type"]);
            //                    this.m_objects[index].Name = Convert.ToString(dr["obd_title"]);
            //                    this.m_objects[index].Alias = Convert.ToString(dr["obd_alias"]);
            //                    this.m_objects[index].Description = Convert.ToString(dr["obd_description"]);
            //                    this.m_objects[index].Field1 = Convert.ToString(dr["obd_varchar1"]);
            //                    this.m_objects[index].Field2 = Convert.ToString(dr["obd_varchar2"]);
            //                    this.m_objects[index].Field3 = Convert.ToString(dr["obd_varchar3"]);
            //                    this.m_objects[index].Field4 = Convert.ToString(dr["obd_varchar4"]);
            //                    this.m_objects[index].Field5 = Convert.ToString(dr["obd_varchar5"]);
            //                    this.m_objects[index].Field6 = Convert.ToString(dr["obd_varchar6"]);
            //                    this.m_objects[index].Field7 = Convert.ToString(dr["obd_varchar7"]);
            //                    this.m_objects[index].Field8 = Convert.ToString(dr["obd_varchar8"]);
            //                    this.m_objects[index].Field9 = Convert.ToString(dr["obd_varchar9"]);
            //                    this.m_objects[index].Field10 = Convert.ToString(dr["obd_varchar10"]);
            //                    this.m_objects[index].Field11 = Convert.ToString(dr["obd_varchar11"]);
            //                    this.m_objects[index].Field12 = Convert.ToString(dr["obd_varchar12"]);
            //                    this.m_objects[index].Field13 = Convert.ToString(dr["obd_varchar13"]);
            //                    this.m_objects[index].Field14 = Convert.ToString(dr["obd_varchar14"]);
            //                    this.m_objects[index].Field15 = Convert.ToString(dr["obd_varchar15"]);
            //                    this.m_objects[index].Field16 = Convert.ToString(dr["obd_varchar16"]);
            //                    this.m_objects[index].Field17 = Convert.ToString(dr["obd_varchar17"]);
            //                    this.m_objects[index].Field18 = Convert.ToString(dr["obd_varchar18"]);
            //                    this.m_objects[index].Field19 = Convert.ToString(dr["obd_varchar19"]);
            //                    this.m_objects[index].Field20 = Convert.ToString(dr["obd_varchar20"]);
            //                    this.m_objects[index].Field21 = Convert.ToString(dr["obd_varchar21"]);
            //                    this.m_objects[index].Field22 = Convert.ToString(dr["obd_varchar22"]);
            //                    this.m_objects[index].Field23 = Convert.ToString(dr["obd_varchar23"]);
            //                    this.m_objects[index].Field24 = Convert.ToString(dr["obd_varchar24"]);
            //                    this.m_objects[index].Field25 = Convert.ToString(dr["obd_varchar25"]);
            //                    this.m_objects[index].Field26 = Convert.ToString(dr["obd_varchar26"]);
            //                    this.m_objects[index].Field27 = Convert.ToString(dr["obd_varchar27"]);
            //                    this.m_objects[index].Field28 = Convert.ToString(dr["obd_varchar28"]);
            //                    this.m_objects[index].Field29 = Convert.ToString(dr["obd_varchar29"]);
            //                    this.m_objects[index].Field30 = Convert.ToString(dr["obd_varchar30"]);
            //                    this.m_objects[index].Field31 = Convert.ToString(dr["obd_varchar31"]);
            //                    this.m_objects[index].Field32 = Convert.ToString(dr["obd_varchar32"]);
            //                    this.m_objects[index].Field33 = Convert.ToString(dr["obd_varchar33"]);
            //                    this.m_objects[index].Field34 = Convert.ToString(dr["obd_varchar34"]);
            //                    this.m_objects[index].Field35 = Convert.ToString(dr["obd_varchar35"]);
            //                    this.m_objects[index].Field36 = Convert.ToString(dr["obd_varchar36"]);
            //                    this.m_objects[index].Field37 = Convert.ToString(dr["obd_varchar37"]);
            //                    this.m_objects[index].Field38 = Convert.ToString(dr["obd_varchar38"]);
            //                    this.m_objects[index].Field39 = Convert.ToString(dr["obd_varchar39"]);
            //                    this.m_objects[index].Field40 = Convert.ToString(dr["obd_varchar40"]);
            //                    this.m_objects[index].Field41 = Convert.ToString(dr["obd_varchar41"]);
            //                    this.m_objects[index].Field42 = Convert.ToString(dr["obd_varchar42"]);
            //                    this.m_objects[index].Field43 = Convert.ToString(dr["obd_varchar43"]);
            //                    this.m_objects[index].Field44 = Convert.ToString(dr["obd_varchar44"]);
            //                    this.m_objects[index].Field45 = Convert.ToString(dr["obd_varchar45"]);
            //                    this.m_objects[index].Field46 = Convert.ToString(dr["obd_varchar46"]);
            //                    this.m_objects[index].Field47 = Convert.ToString(dr["obd_varchar47"]);
            //                    this.m_objects[index].Field48 = Convert.ToString(dr["obd_varchar48"]);
            //                    this.m_objects[index].Field49 = Convert.ToString(dr["obd_varchar49"]);
            //                    this.m_objects[index].Field50 = Convert.ToString(dr["obd_varchar50"]);
            //                    this.m_objects[index].CreatedDate = Convert.ToDateTime(dr["obd_createddate"]);
            //                    this.m_objects[index].CreatedBy = Convert.ToString(dr["obd_createdby"]);
            //                    this.m_objects[index].UpdatedDate = Convert.ToDateTime(dr["obd_updateddate"]);
            //                    this.m_objects[index].UpdatedBy = Convert.ToString(dr["obd_updatedby"]);
            //                    this.m_objects[index].Hidden = Convert.ToBoolean(dr["obd_hidden"]);
            //                    this.m_objects[index].Deleted = Convert.ToBoolean(dr["obd_deleted"]);
            //                    this.m_objects[index].Exist = true;
            //                    index++;
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, "");
            //        }
            //    }

            //    #endregion Private Methods

            //}
            //#endregion public class PageFlip

            //#region public class PageFlipItem
            //public class PageFlipItem : Object
            //{
            //    string CLASSNAME = "[Namespace::RXServer::Web::Modules][Class::PageFlipItem]";

            //    public String Type
            //    {
            //        get { return base.Field1; }
            //        set { base.Field1 = value; }
            //    }
            //    public String Src
            //    {
            //        get { return base.Field2; }
            //        set { base.Field2 = value; }
            //    }
            //    public Boolean PreLoad
            //    {
            //        get { return base.Field3.Equals("1") ? true : false; }
            //        set { base.Field3 = value.Equals(true) ? "1" : "0"; }
            //    }
                
            //    public PageFlipItem(){}
            //    public PageFlipItem(Int32 SitId, Int32 PagId, Int32 ModId)
            //        : base(ObjectType.RXServerDefined_Modules_PageFlipItem, SitId, PagId, ModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString)
            //    {
            //    }
            //    public PageFlipItem(Int32 SitId, Int32 PagId, Int32 ModId, String Src, Boolean PreLoad)
            //        : base(ObjectType.RXServerDefined_Modules_PageFlipItem, SitId, PagId, ModId, RXServer.Data.DataSource, RXServer.Data.ConnectionString)
            //    {
            //        this.Src = Src;
            //        this.PreLoad = PreLoad;
            //        this.Save();
            //    }
                
            //    public override void Save()
            //    {
            //        string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
            //        try
            //        {
            //            base.Name = "PageFlipItem";
            //            base.Alias = "PageFlipItem";
            //            base.Description = "PageFlipItem";
            //            base.Save();
            //        }
            //        catch (Exception ex)
            //        {
            //            Error.Report(ex, FUNCTIONNAME, String.Empty);
            //        }
            //    }
            //}
            //#endregion public class PageFlipItem

        }
    }
}
