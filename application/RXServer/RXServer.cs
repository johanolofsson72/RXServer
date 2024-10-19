using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using iConsulting.iCDataHandler;
using System.Security.Cryptography;
using iConsulting;
using System.Text;
using System.IO;
using Telerik.WebControls.RadUploadUtils;
using Telerik.RadUploadUtils;
using Telerik.WebControls;
using System.Globalization;
using System.Xml;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace RXServer
{

    #region public class MySql
    public class MySql
    {
        static string CLASSNAME = "[Namespace::RXServer][Class::MySql]";
        static string FUNCTIONNAME;
        #region Public Methods
        public static DataSet GetAllDatabases(String Host)
        {
            FUNCTIONNAME = CLASSNAME + "[Function::GetAllDatabases]";
            DataSet ds = new DataSet();
            try
            {
                using (iCDataObject oDo = new iCDataObject("mysql", "Database=mysql; User Id=root; Port=3306; Host=" + Host, false, true, true))
                    ds = oDo.GetDataSet("SHOW DATABASES");
                return ds;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
                return ds;
            }
        }
        #endregion Public Methods

        #region Private Methods
        #endregion Private Methods
    }
    #endregion public class MySql

    #region public class XmlDb
    public class XmlDb
    {
        static string CLASSNAME = "[Namespace::RXServer][Class::XmlDb]";
        static string FUNCTIONNAME;
        #region Public Methods
        public static ArrayList GetAllDatabases(String Path)
        {
            FUNCTIONNAME = CLASSNAME + "[Function::GetAllDatabases]";
            ArrayList Files = new ArrayList();
            try
            {
                foreach (String f in Directory.GetFiles(Path))
                {
                    FileInfo fi = new FileInfo(f);
                    if (fi.Extension.ToLower() == ".xmldb")
                        Files.Add(fi.Name);
                }
                return Files;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
                return Files;
            }
        }
        #endregion Public Methods

        #region Private Methods
        #endregion Private Methods
    }
    #endregion public class XmlDb

    #region public TemporaryChangeCulture
    public class TemporaryChangeCulture : IDisposable
    {
        CultureInfo def;
        public TemporaryChangeCulture(CultureInfo c)
        {
            def = RXServer.Data.CultureInfo;
            try
            {
                RXServer.Data.CultureInfo = c;
            }
            catch
            {
                xFinalize();
            }
        }
        ~TemporaryChangeCulture()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            RXServer.Data.CultureInfo = def;
        }
    }
    #endregion public TemporaryChangeCulture

    #region public static class Data
    public static class Data
    {
        static string CLASSNAME = "[Namespace::RXServer][Class::Data]";
        private static String m_DataSource;
        private static String m_ConnectionString;
        private static Int32 m_CacheTimeOut;
        private static Int32 m_Group;
        private static CultureInfo m_CultureInfo;
        private static String m_SecurityLogin;
        private static String m_SecurityPassword;
        private static Boolean m_ActivateGC;

        #region Constants
        public const String CACHEITEM_SITE_COLLECTION = "RXServer::SiteCollection";
        public const String CACHEITEM_SITE_ID = "RXServer::SiteId";
        public const String CACHEITEM_SITE_ALIAS = "RXServer::SiteAlias";
        public const String CACHEITEM_SITE_ROLES = "RXServer::SiteRoles";
        public const String CACHEITEM_SITE_GROUPS = "RXServer::SiteGroups";

        public const String CACHEITEM_PAGE_COLLECTION = "RXServer::PageCollection";
        public const String CACHEITEM_PAGE_ID = "RXServer::PageId";
        public const String CACHEITEM_PAGE_ALIAS = "RXServer::PageAlias";
        public const String CACHEITEM_PAGE_ROLES = "RXServer::PageRoles";
        public const String CACHEITEM_PAGE_GROUPS = "RXServer::PageGroups";

        public const String CACHEITEM_TASK_COLLECTION = "RXServer::TaskCollection";
        public const String CACHEITEM_TASK_ID = "RXServer::TaskId";
        public const String CACHEITEM_TASK_ALIAS = "RXServer::TaskAlias";
        public const String CACHEITEM_TASK_ROLES = "RXServer::TaskRoles";
        public const String CACHEITEM_TASK_GROUPS = "RXServer::TaskGroups";

        public const String CACHEITEM_OBJECT_COLLECTION = "RXServer::ObjectCollection";
        public const String CACHEITEM_OBJECT_ID = "RXServer::ObjectId";
        public const String CACHEITEM_OBJECT_ALIAS = "RXServer::ObjectAlias";

        public const String CACHEITEM_DOCUMENT_COLLECTION = "RXServer::DocumentCollection";
        public const String CACHEITEM_DOCUMENT_ID = "RXServer::DocumentId";
        public const String CACHEITEM_DOCUMENT_ALIAS = "RXServer::DocumentAlias";
        public const String CACHEITEM_DOCUMENT_ROLES = "RXServer::DocumentRoles";
        public const String CACHEITEM_DOCUMENT_GROUPS = "RXServer::DocumentGroups";

        public const String CACHEITEM_MODULE_COLLECTION = "RXServer::ModuleCollection";
        public const String CACHEITEM_MODULE_ID = "RXServer::ModuleId";
        public const String CACHEITEM_MODULE_ALIAS = "RXServer::ModuleAlias";
        public const String CACHEITEM_MODULE_ROLES = "RXServer::ModuleRoles";
        public const String CACHEITEM_MODULE_GROUPS = "RXServer::ModuleGroups";
        public const String CACHEITEM_MODULE_SOURCE = "RXServer::ModuleSource";

        public const String CACHEITEM_ROLE_CHECK = "RXServer::RoleCheck";
        #endregion Constants

        #region Properties
        public static Boolean ActivateGC
        {
            get
            {
                return m_ActivateGC; 
            }
            set
            {
                m_ActivateGC = value;
            }
        }

        /// <summary>
        /// RXServer.Data.Login is replaced with RXServer.Security.LoggedInUserName
        /// This property will be removed in next version of RXServer.
        /// </summary>
        public static String Login
        {
            set
            {
                m_SecurityLogin = Common.SafeString(value);
            }
            get
            {
                return m_SecurityLogin;
            }
        }

        /// <summary>
        /// RXServer.Data.Password is replaced with RXServer.Security.LoggedInUserPassword
        /// This property will be removed in next version of RXServer.
        /// </summary>
        public static String Password
        {
            set
            {
                m_SecurityPassword = Common.SafeString(value);
            }
            get
            {
                return m_SecurityPassword;
            }
        }

        public static String DataSource
        {
            get
            {
                String x = String.Empty;
                if (HttpContext.Current.Session != null)
                    if (HttpContext.Current.Session["RXServer.Data.DataSource"] != null)
                        x = HttpContext.Current.Session["RXServer.Data.DataSource"].ToString();
                return x;
            }
            set
            {
                m_DataSource = value;
                HttpContext.Current.Session["RXServer.Data.DataSource"] = value;
            }
            //set
            //{
            //    m_DataSource = value;
            //}
            //get
            //{
            //    return m_DataSource;
            //}
        }

        public static String ConnectionString
        {
            get
            {
                String x = String.Empty;
                if (HttpContext.Current.Session != null)
                    if (HttpContext.Current.Session["RXServer.Data.ConnectionString"] != null)
                        x = HttpContext.Current.Session["RXServer.Data.ConnectionString"].ToString();
                return x;
            }
            set
            {
                m_ConnectionString = value;
                HttpContext.Current.Session["RXServer.Data.ConnectionString"] = value;
            }
            //set
            //{
            //    m_ConnectionString = value;
            //}
            //get
            //{
            //    return m_ConnectionString;
            //}
        }

        public static Int32 Group
        {
            get
            {
                Int32 x = 0;
                if (HttpContext.Current.Session != null)
                    if (HttpContext.Current.Session["RXServer.Data.Group"] != null)
                        x = Convert.ToInt32(HttpContext.Current.Session["RXServer.Data.Group"].ToString());
                return x;
            }
            set
            {
                m_Group = value;
                HttpContext.Current.Session["RXServer.Data.Group"] = value;
            }
            //set
            //{
            //    m_Group = value;
            //}
            //get
            //{
            //    return m_Group;
            //}
        }

        public static Int32 CacheTimeOut
        {
            get
            {
                Int32 x = 0;
                if (HttpContext.Current.Session != null)
                    if (HttpContext.Current.Session["RXServer.Data.CacheTimeOut"] != null)
                        x = Convert.ToInt32(HttpContext.Current.Session["RXServer.Data.CacheTimeOut"].ToString());
                return x;
            }
            set
            {
                m_CacheTimeOut = value;
                HttpContext.Current.Session["RXServer.Data.CacheTimeOut"] = value;
            }
            //set
            //{
            //    m_CacheTimeOut = value;
            //}
            //get
            //{
            //    return m_CacheTimeOut;
            //}
        }

        public static CultureInfo CultureInfo
        {
            get
            {
                CultureInfo x = new CultureInfo("sv-SE"); 
                if (HttpContext.Current.Session != null)
                    if (HttpContext.Current.Session["RXServer.Data.CultureInfo"] != null)
                        x = (CultureInfo)HttpContext.Current.Session["RXServer.Data.CultureInfo"];
                return x;
            }
            set
            {
                m_CultureInfo = value;
                HttpContext.Current.Session["RXServer.Data.CultureInfo"] = value;
            }
            //set
            //{
            //    m_CultureInfo = value;
            //}
            //get
            //{
            //    return m_CultureInfo;
            //}
        }

        #endregion Properties

        #region Public Methods
        public static void Init()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Init]";
            try
            {
                DataSource = string.Empty;
                ConnectionString = string.Empty;
                CacheTimeOut = 0;
                CultureInfo = null;
                m_SecurityLogin = string.Empty;
                m_SecurityPassword = string.Empty;
                Group = 0;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }

        /// <summary>
   		/// RXServer.Data.SignOut() is replaced with RXServer.Security.SignOut()
        /// This method will be removed in next version of RXServer.
   		/// </summary>
        public static void SignOut()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::SignOut]";
            try
            {
                m_SecurityLogin = string.Empty;
                m_SecurityPassword = string.Empty;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }
        public static void ResetCache(String CachePreValue)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetCache]";
            try
            {
                if (HttpContext.Current != null)
                {
                    String cacheItem = String.Empty;
                    IDictionaryEnumerator CacheEnum = HttpContext.Current.Cache.GetEnumerator();
                    while (CacheEnum.MoveNext())
                    {
                        cacheItem = CacheEnum.Key.ToString();
                        if (cacheItem.StartsWith(CachePreValue))
                        {
                            System.Diagnostics.Debug.WriteLine("Remove: " + cacheItem + " from cache.");
                            HttpContext.Current.Cache.Remove(cacheItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }
        public static void ResetCache()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetCache]";
            try
            {
                ResetCache("RXServer");
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }
        public static void CacheInsert(String CacheItem, DataSet ds)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::CacheInsert]";
            try
            {
                if (HttpContext.Current != null)
                {
                    ResetCache(CacheItem);
                    HttpContext.Current.Cache.Insert(CacheItem, ds, null, DateTime.Now.AddMinutes(CacheTimeOut), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                    ds = (DataSet)HttpContext.Current.Cache[CacheItem];
                    System.Diagnostics.Debug.WriteLine("Insert: " + CacheItem + " item into cache.");
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }
        public static void CacheInsert(String CacheItem, DataTable dt)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::CacheInsert]";
            try
            {
                if (HttpContext.Current != null)
                {
                    ResetCache(CacheItem);
                    HttpContext.Current.Cache.Insert(CacheItem, dt, null, DateTime.Now.AddMinutes(CacheTimeOut), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                    dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                    System.Diagnostics.Debug.WriteLine("Insert: " + CacheItem + " item into cache.");
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }
        public static void CacheInsert(String CacheItem, Int32[] val)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::CacheInsert]";
            try
            {
                if (HttpContext.Current != null)
                {
                    ResetCache(CacheItem);
                    HttpContext.Current.Cache.Insert(CacheItem, val, null, DateTime.Now.AddMinutes(CacheTimeOut), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                    val = (Int32[])HttpContext.Current.Cache[CacheItem]; 
                    System.Diagnostics.Debug.WriteLine("Insert: " + CacheItem + " with " + val.Length.ToString() + "items into cache.");
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }
        #endregion Public Methods

        #region Private Methods
        #endregion Private Methods
    }
    #endregion public static class Data


    #region public enum SettingType
    public enum SettingType
    {
        Site = 1,
        Page = 2,
        Module = 3,
        Task = 4
    }
    #endregion public struct SettingType

    #region public enum PropertyUpdateType
    public enum PropertyUpdateType
    {
        String = 1,
        Int32 = 2,
        Boolean = 3,
        DateTime = 4,
        Int32Array = 5,
        FileStream = 6
    }
    #endregion public enum PropertyUpdateType

    #region public enum PropertyUpdateTableType
    public enum PropertyUpdateTableType
    {
        Standard = 1,
        Settings = 2
    }
    #endregion public enum PropertyUpdateTableType

    #region public enum ObjectType
    public enum ObjectType
    {
        Undefined = 0,
        Editor = 1,
        News = 2,
        Menu = 3,
        SubMenu = 4,
        Announcement = 5,
        Banner = 6,
        Survey = 7,
        Whois = 8,
        Contact = 9,
        Discussion = 10,
        Event = 11,
        Faq = 12,
        Feedback = 13,
        Html = 14,
        IFrame = 15,
        Link = 16,
        Maps = 17,
        Search = 18,
        UsersOnline = 19,
        Weather = 20,
        Vendor = 21,
        Xml = 22,
        Generic = 23,
        UserDefined = 24,
        UserMenu = 25,
        StyleSheet = 26,
        Web = 27,
        Console = 28,
        Window = 29,
        MetaData = 30,
        Scope = 31,
        Entity = 32,
        Port = 33,
        Operation = 34,
        Transformation = 35,
        Schema = 36,
        Calendar = 37,
        Chart = 38,
        Dock = 39,
        Grid = 40,
        Panel = 41,
        Spell = 42,
        Tabstrip = 43,
        Toolbar = 44,
        Flash = 45,
        Mail = 46,
        Treeview = 47,
        WebSite = 48,
        VirtualDirectory = 49,
        ApplicationPool = 50,
        FtpSite = 51,
        Quota = 52,
        IO = 53,
        User = 54,
        Customer = 55,
        Role = 56,
        Queue = 57,
        ChangeQuota = 58,
        RemoveQuota = 59,
        AddQuota = 60,
        ChangeWebSite = 61,
        DeleteWebSite = 62,
        AddWebSite = 63,
        SupportTicket = 64,
        Ticket = 65,
        NewCustomer = 66,
        MySQLSystem = 67,
        MySQLDatabase = 68,
        XMLSystem = 69,
        XMLDatabase = 70,
        Directories = 71,
        Files = 72,
        DirectoryPermission = 73,
        FilePermission = 74,
        Article1 = 75,
        Article2 = 76,
        Article3 = 77,
        Article4 = 78,
        Article5 = 79,
        SiteSettings = 80,
        PageSettings = 81,
        TaskSettings = 82,
        ObjectSettings = 83,
        DocumentSettings = 84,
        ModuleSettings = 85,
        Forum = 86,
        ForumThread = 87,
        RXServerDefined_Menu = 88,
        RXServerDefined_SubMenu = 89,
        RXServerDefined_MenuItem = 90,
        RXServerDefined_MenuItems = 91,
        ForumReplies = 92,
        Visitor = 93,
        OrderMaterial = 94,
        Message = 95,
        RXServerDefined_UserSettings = 96,
        RXServerDefined_Modules_ArticleType1 = 97,
        RXServerDefined_Modules_DocumentType1 = 98
    }
    #endregion public struct ObjectType

    #region public enum SortField
    public enum SiteSortField
    {
        Id = 1,
        Language = 2,
        Order = 3,
        ParentId = 4,
        Title = 5,
        Alias = 6,
        Description = 7,
        Theme = 8,
        Skin = 9,
        CreatedDate = 10,
        CreatedBy = 11,
        UpdatedDate = 12,
        UpdatedBy = 13
    }
    public enum PageSortField
    {
        Id = 1,
        SitId = 2,
        Language = 3,
        Order = 4,
        ParentId = 5,
        Title = 6,
        Alias = 7,
        Description = 8,
        Theme = 9,
        Skin = 10,
        CreatedDate = 11,
        CreatedBy = 12,
        UpdatedDate = 13,
        UpdatedBy = 14
    }
    public enum TaskSortField
    {
        Id = 1,
        SitId = 2,
        Language = 3,
        Order = 4,
        ParentId = 5,
        Title = 6,
        Alias = 7,
        Description = 8,
        Theme = 9,
        Skin = 10,
        CreatedDate = 11,
        CreatedBy = 12,
        UpdatedDate = 13,
        UpdatedBy = 14
    }
    public enum ObjectSortField
    {
        Id = 1,
        Language = 2,
        ParentId = 3,
        SitId = 4,
        PagId = 5,
        Order = 6,
        Title = 7,
        Alias = 8,
        Description = 9,
        Field1 = 10,
        Field2 = 11,
        Field3 = 12,
        Field4 = 13,
        Field5 = 14,
        Field6 = 15,
        Field7 = 16,
        Field8 = 17,
        Field9 = 18,
        Field10 = 19,
        Field11 = 20,
        Field12 = 21,
        Field13 = 22,
        Field14 = 23,
        Field15 = 24,
        Field16 = 25,
        Field17 = 26,
        Field18 = 27,
        Field19 = 28,
        Field20 = 29,
        Field21 = 30,
        Field22 = 31,
        Field23 = 32,
        Field24 = 33,
        Field25 = 34,
        Field26 = 35,
        Field27 = 36,
        Field28 = 37,
        Field29 = 38,
        Field30 = 39,
        Field31 = 40,
        Field32 = 41,
        Field33 = 42,
        Field34 = 43,
        Field35 = 44,
        Field36 = 45,
        Field37 = 46,
        Field38 = 47,
        Field39 = 48,
        Field40 = 49,
        Field41 = 50,
        Field42 = 51,
        Field43 = 52,
        Field44 = 53,
        Field45 = 54,
        Field46 = 55,
        Field47 = 56,
        Field48 = 57,
        Field49 = 58,
        Field50 = 59,
        CreatedDate = 60,
        CreatedBy = 61,
        UpdatedDate = 62,
        UpdatedBy = 63,
        ModId = 64
    }
    public enum DocumentSortField
    {
        Id = 1,
        SitId = 2,
        PagId = 3,
        Language = 4,
        Type = 5,
        ParentId = 6,
        Order = 7,
        Title = 8,
        Alias = 9,
        Description = 10,
        ContentType = 11,
        ContentSize = 12,
        Version = 13,
        CharSet = 14,
        Extension = 15,
        Path = 16,
        CheckOutUsrId = 17,
        CheckOutDate = 18,
        CheckOutExpireDate = 19,
        LastViewedDate = 20,
        LastViewedBy = 21,
        IsDirty = 22,
        IsDelivered = 23,
        IsSigned = 24,
        IsCertified = 25,
        DeliverDate = 26,
        DeliverBy = 27,
        DeliverTo = 28,
        CreatedDate = 29,
        CreatedBy = 30,
        UpdatedDate = 31,
        UpdatedBy = 32
    }
    public enum ModuleSortField
    {
        Id = 1,
        SitId = 2,
        PagId = 3,
        MdeId = 4,
        Language = 5,
        Order = 6,
        ParentId = 7,
        Title = 8,
        Alias = 9,
        Description = 10,
        Src = 11,
        Pane = 12,
        Theme = 13,
        Skin = 14,
        CacheTime = 15,
        EditSrc = 16,
        Secure = 17,
        AllPages = 18,
        CreatedDate = 19,
        CreatedBy = 20,
        UpdatedDate = 21,
        UpdatedBy = 22
    }
    #endregion public struct SortField

    #region public enum SortOrder
    public enum SortOrder
    {
        Ascending = 1,
        Descending = 2
    }
    #endregion public struct SortOrder

    #region public enum OrderMinMax
    public enum OrderMinMax
    {
        Min = 1,
        Max = 2100000000,
        Step = 2
    }
    #endregion public struct OrderMinMax

    #region public class EnumerationClasses
    public class RXSiteEnum : IEnumerator
    {
        public Site[] m_site;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public RXSiteEnum(Site[] list)
        {
            m_site = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < m_site.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return m_site[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
    public class RXPageEnum : IEnumerator
    {
        public Page[] m_page;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public RXPageEnum(Page[] list)
        {
            m_page = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < m_page.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return m_page[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
    public class RXTaskEnum : IEnumerator
    {
        public Task[] m_task;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public RXTaskEnum(Task[] list)
        {
            m_task = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < m_task.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return m_task[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
    public class RXObjectEnum : IEnumerator
    {
        public Object[] m_object;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public RXObjectEnum(Object[] list)
        {
            m_object = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < m_object.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return m_object[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
    public class RXDocumentEnum : IEnumerator
    {
        public Document[] m_document;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public RXDocumentEnum(Document[] list)
        {
            m_document = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < m_document.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return m_document[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
    public class RXModuleEnum : IEnumerator
    {
        public Module[] m_module;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public RXModuleEnum(Module[] list)
        {
            m_module = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < m_module.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return m_module[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
    #endregion public class EnumerationClasses


    #region public class SiteCollection

    /// <summary>
    /// 
    /// </summary>
    public class SiteCollection : IDisposable, IEnumerable
    {
        string CLASSNAME = "[Namespace::RXServer][Class::SiteCollection]";

        #region DataHandler Variables

        private string m_datasource;
        private string m_connectionstring;

        #endregion DataHandler Variables

        #region Private Variables

        private Site m_site;
        private Site[] m_sites = new Site[0];
        private bool m_autoupdate;
        private DataTable m_dtsites;
        private Boolean m_refresh; 

        #endregion Private Variables

        #region Properties


        public IEnumerator GetEnumerator()
        {
            return new RXSiteEnum(this.m_sites);
        }
        /// <summary>
        /// 
        /// </summary>
        public Site this[Int32 index]
        {
            get
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Site]";
                try
                {
                    this.m_site = (Site)this.m_sites[index];
                    return this.m_site;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "Default Property Sites()");
                    return new Site(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Site[] Items
        {
            get
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Site]";
                try
                {
                    return this.m_sites;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return new Site[0];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Site GetSite(Int32 id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetSite]";
            try
            {
                foreach (Site s in this.m_sites)
                {
                    if (s.Id == id)
                    {
                        return s;
                    }
                }
                return new Site(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Site(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public Site GetSite(string alias)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetSite]";
            try
            {
                foreach (Site s in this.m_sites)
                {
                    if (s.Alias.ToLower() == alias.ToLower())
                    {
                        return s;
                    }
                }
                return new Site(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Site(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Contains(Int32 id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            try
            {
                foreach (Site s in this.m_sites)
                {
                    if (s.Id == id)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public bool Contains(string alias)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            try
            {
                foreach (Site s in this.m_sites)
                {
                    if (s.Alias.ToLower() == alias.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        public bool Refresh
        {
            get
            {
                return this.m_refresh;
            }
            set
            {
                this.m_refresh = value;
            }
        }


        #endregion Properties

        #region Constructors

        public SiteCollection(bool AutoUpdate, String DataSource, String ConnectionString) : this(AutoUpdate, DataSource, ConnectionString, true)  
        {}
        
        public SiteCollection(bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh; 
            GetAll();
        }
        
        ~SiteCollection()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            if (!this.Refresh)
                ResetThis();
            if (RXServer.Data.ActivateGC)
                GC.Collect(); 
        }
        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="site"></param>
        public void Add(Site site)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            try
            {
                this.Add(ref site);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void Add(ref Site site)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            try
            {
                DataSet ds = new DataSet();
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("INSERT INTO sit_sites (lng_id, sit_parentid, sit_order, sit_title, ");
                sSQL.Append("sit_alias, sit_description, sit_theme, sit_skin, sit_createddate, sit_createdby, sit_updateddate, ");
                sSQL.Append("sit_updatedby, sit_hidden, sit_deleted) ");
                sSQL.Append("VALUES (");
                sSQL.Append("" + site.Language + ", ");
                sSQL.Append("" + site.ParentId + ", ");
                sSQL.Append("" + site.Order + ", ");
                sSQL.Append("'" + site.Name + "', ");
                sSQL.Append("'" + site.Alias + "', ");
                sSQL.Append("'" + site.Description + "', ");
                sSQL.Append("'" + site.Theme + "', ");
                sSQL.Append("'" + site.Skin + "', ");
                sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', ");
                sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', ");
                sSQL.Append("" + Convert.ToInt32(site.Hidden).ToString() + ", ");
                sSQL.Append("" + Convert.ToInt32(site.Deleted).ToString() + "");
                sSQL.Append(")");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                {
                    oDo.ExecuteNonQuery(sSQL.ToString());
                    site.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                }

                foreach (Int32 r in site.AuthorizedEditRoles)
                {
                    sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO asr_authorizedsitesroles (sit_id, rol_id, asr_createddate, asr_createdby, asr_updateddate, asr_updatedby, asr_hidden, asr_deleted) VALUES ( ");
                    sSQL.Append(site.Id.ToString() + ", ");
                    sSQL.Append(r.ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());
                }

                foreach (Int32 g in site.AuthorizedEditGroups)
                {
                    sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO asg_authorizedsitesgroups (sit_id, grp_id, asg_createddate, asg_createdby, asg_updateddate, asg_updatedby, asg_hidden, asg_deleted) VALUES ( ");
                    sSQL.Append(site.Id.ToString() + ", ");
                    sSQL.Append(g.ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());
                }
                SortAll();
                GetAll();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="site"></param>
        public void Remove(Site site)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            try
            {
                this.Remove(site.Id);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(Int32 id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            try
            {
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("UPDATE sit_sites SET sit_deleted = 1 ");
                sSQL.Append("WHERE sit_id = " + id.ToString());
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                    oDo.ExecuteNonQuery(sSQL.ToString());
                SortAll();
                GetAll();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Clear]";
            try
            {
                this.m_sites = null;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int32 Count()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Count]";
            try
            {
                return this.m_sites.Length;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return 0;
            }
        }

        public DataTable DataTable()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            try
            {
                return m_dtsites;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new DataTable();
            }
        }

        public DataTable DataTable(SiteSortField SortField, SortOrder SortOrder)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            try
            {
                DataView v = new DataView(m_dtsites);
                v.Sort = RetriveSortField(SortField) + Convert.ToString((Int32)SortOrder == 1 ? String.Empty : " DESC");
                return v.ToTable();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new DataTable();
            }
        }


        #endregion Public Methods

        #region Private Methods

        private void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_COLLECTION);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_ROLES);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_GROUPS);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private String RetriveSortField(SiteSortField SortField)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::RetriveSortField]";
            try
            {

                if ((Int32)SortField == 1) return "sit_id";
                if ((Int32)SortField == 2) return "lng_id";
                if ((Int32)SortField == 3) return "sit_order";
                if ((Int32)SortField == 4) return "sit_parentid";
                if ((Int32)SortField == 5) return "sit_title";
                if ((Int32)SortField == 6) return "sit_alias";
                if ((Int32)SortField == 7) return "sit_description";
                if ((Int32)SortField == 8) return "sit_theme";
                if ((Int32)SortField == 9) return "sit_skin";
                if ((Int32)SortField == 10) return "sit_createddate";
                if ((Int32)SortField == 11) return "sit_createdby";
                if ((Int32)SortField == 12) return "sit_updateddate";
                if ((Int32)SortField == 13) return "sit_updatedby";
                return String.Empty;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return String.Empty;
            }
        }
        private void GetAll()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAll]";
            DataTable dt = null;
            if (!this.Refresh)
                return;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_SITE_COLLECTION;
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM sit_sites WHERE sit_deleted = 0 ORDER BY sit_order");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    this.m_dtsites = dt;
                    Int32 index = 0;
                    this.m_sites = new Site[dt.Rows.Count];
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.m_sites[index] = new Site(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
                        this.m_sites[index].Id = Convert.ToInt32(dr["sit_id"]);
                        this.m_sites[index].Language = Convert.ToInt32(dr["lng_id"]);
                        this.m_sites[index].ParentId = Convert.ToInt32(dr["sit_parentid"]);
                        this.m_sites[index].Order = Convert.ToInt32(dr["sit_order"]);
                        this.m_sites[index].Name = Convert.ToString(dr["sit_title"]);
                        this.m_sites[index].Alias = Convert.ToString(dr["sit_alias"]);
                        this.m_sites[index].Description = Convert.ToString(dr["sit_description"]);
                        this.m_sites[index].AuthorizedEditRoles = this.GetAuthorizedEditRoles(Convert.ToInt32(dr["sit_id"]));
                        this.m_sites[index].AuthorizedEditGroups = this.GetAuthorizedEditGroups(Convert.ToInt32(dr["sit_id"]));
                        this.m_sites[index].Theme = Convert.ToString(dr["sit_theme"]);
                        this.m_sites[index].Skin = Convert.ToString(dr["sit_skin"]);
                        this.m_sites[index].CreatedDate = Convert.ToDateTime(dr["sit_createddate"]);
                        this.m_sites[index].CreatedBy = Convert.ToString(dr["sit_createdby"]);
                        this.m_sites[index].UpdatedDate = Convert.ToDateTime(dr["sit_updateddate"]);
                        this.m_sites[index].UpdatedBy = Convert.ToString(dr["sit_updatedby"]);
                        this.m_sites[index].Hidden = Convert.ToBoolean(dr["sit_hidden"]);
                        this.m_sites[index].Deleted = Convert.ToBoolean(dr["sit_deleted"]);
                        this.m_sites[index].Exist = true;
                        index++;
                    }
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
            if (!this.Refresh)
                return;
            try
            {
                Int32 Order = (Int32)OrderMinMax.Min;
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("SELECT * FROM sit_sites WHERE sit_deleted = 0 ORDER BY sit_order");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                {
                    DataTable dt = oDo.GetDataTable(sSQL.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE sit_sites SET sit_order = " + Order.ToString() + " WHERE sit_id = " + dr["sit_id"].ToString());
                        using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
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
        private Int32[] GetAuthorizedEditRoles(Int32 SitId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditRoles]";
            Int32[] Roles;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_SITE_ROLES + "::SitId" + SitId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM asr_authorizedsitesroles WHERE sit_id = " + SitId.ToString() + " AND asr_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Roles = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Roles[i] = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                return Roles;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Int32[] GetAuthorizedEditGroups(Int32 SitId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditGroups]";
            Int32[] Groups;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_SITE_GROUPS + "::SitId" + SitId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM asg_authorizedsitesgroups WHERE sit_id = " + SitId.ToString() + " AND asg_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Groups = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Groups[i] = Convert.ToInt32(dt.Rows[i]["grp_id"]);
                return Groups;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }

        #endregion Private Methods

    }
    #endregion public class SiteCollection

    #region public class Site

    public class Site : IDisposable
    {
        string CLASSNAME = "[Namespace::RXServer][Class::Site]";

        #region DataHandler Variables

        private string m_datasource;
        private string m_connectionstring;

        #endregion DataHandler Variables

        #region Private Variables

        private bool m_exists = false;
        private bool m_autoupdate = false;

        private Int32 m_sit_id = 0;
        private Int32 m_lng_id = 0;
        private Int32 m_sit_order = 0;
        private Int32 m_sit_parentid = 0;
        private Int32[] m_sit_parents = new Int32[0];
        private String m_sit_name = String.Empty;
        private String m_sit_alias = String.Empty;
        private String m_sit_description = String.Empty;
        private String m_sit_theme = String.Empty;
        private String m_sit_skin = String.Empty;
        private Int32[] m_sit_authorizededitroles = new Int32[0];
        private Int32[] m_sit_authorizededitgroups = new Int32[0];
        private DateTime m_sit_createddate = DateTime.Now;
        private String m_sit_createdby = String.Empty;
        private DateTime m_sit_updateddate = DateTime.Now;
        private String m_sit_updatedby = String.Empty;
        private bool m_sit_hidden = false;
        private bool m_sit_deleted = false;

        private bool m_sit_haschildren = false;
        private bool m_sit_hasparent = false;

        #endregion Private Variables

        #region Properties

        public PageCollection Pages
        {
            get
            {
                return new PageCollection(this.Id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }
        public TaskCollection Tasks
        {
            get
            {
                return new TaskCollection(this.Id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }
        public ObjectCollection Objects
        {
            get
            {
                return new ObjectCollection(this.Id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }
        public bool AutoUpdate
        {
            set
            {
                this.m_autoupdate = value;
            }
        }
        public bool Exist
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
        public bool HasChildren
        {
            get
            {
                this.m_sit_haschildren = this.FindChildren();
                return this.m_sit_haschildren;
            }
        }
        public bool HasParent
        {
            get
            {
                this.m_sit_hasparent = this.m_sit_parentid == 0 ? false : true;
                return this.m_sit_hasparent;
            }
        }
        public Int32 Id
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
        public Int32 Language
        {
            get
            {
                return this.m_lng_id;
            }
            set
            {
                this.m_lng_id = value;
                PropertyUpdate("lng_id", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public Int32 Order
        {
            get
            {
                return this.m_sit_order;
            }
            set
            {
                this.m_sit_order = value;
                PropertyUpdate("sit_order", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public Int32 ParentId
        {
            get
            {
                return this.m_sit_parentid;
            }
            set
            {
                this.m_sit_parentid = value;
                PropertyUpdate("sit_parentid", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public Int32[] Parents
        {
            get
            {
                GetParents();
                return this.m_sit_parents;
            }
        }
        public string Name
        {
            get
            {
                return this.m_sit_name;
            }
            set
            {
                this.m_sit_name = Common.SafeString(value);
                PropertyUpdate("sit_title", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Alias
        {
            get
            {
                return this.m_sit_alias;
            }
            set
            {
                if (!this.m_exists)
                {
                    this.m_sit_alias = Common.SafeString(value);
                    PropertyUpdate("sit_alias", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
                }
            }
        }
        public string Description
        {
            get
            {
                return this.m_sit_description;
            }
            set
            {
                this.m_sit_description = Common.SafeString(value);
                PropertyUpdate("sit_description", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Theme
        {
            get
            {
                return this.m_sit_theme;
            }
            set
            {
                this.m_sit_theme = Common.SafeString(value);
                PropertyUpdate("sit_theme", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Skin
        {
            get
            {
                return this.m_sit_skin;
            }
            set
            {
                this.m_sit_skin = Common.SafeString(value);
                PropertyUpdate("sit_skin", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public Int32[] AuthorizedEditRoles
        {
            get
            {
                return this.m_sit_authorizededitroles;
            }
            set
            {
                this.m_sit_authorizededitroles = value;
                PropertyUpdate("rol_id", value, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
            }
        }
        public Int32[] AuthorizedEditGroups
        {
            get
            {
                return this.m_sit_authorizededitgroups;
            }
            set
            {
                this.m_sit_authorizededitgroups = value;
                PropertyUpdate("grp_id", value, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return this.m_sit_createddate;
            }
            set
            {
                this.m_sit_createddate = value;
            }
        }
        public string CreatedBy
        {
            get
            {
                return this.m_sit_createdby;
            }
            set
            {
                this.m_sit_createdby = Common.SafeString(value);
            }
        }
        public DateTime UpdatedDate
        {
            get
            {
                return this.m_sit_updateddate;
            }
            set
            {
                this.m_sit_updateddate = value;
            }
        }
        public string UpdatedBy
        {
            get
            {
                return this.m_sit_updatedby;
            }
            set
            {
                this.m_sit_updatedby = Common.SafeString(value);
            }
        }
        public bool Hidden
        {
            get
            {
                return this.m_sit_hidden;
            }
            set
            {
                this.m_sit_hidden = value;
                PropertyUpdate("sit_hidden", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public bool Deleted
        {
            get
            {
                return this.m_sit_deleted;
            }
            set
            {
                this.m_sit_deleted = value;
                PropertyUpdate("sit_deleted", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }


        #endregion Properties

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Alias"></param>
        /// <param name="AutoUpdate"></param>
        public Site(string Alias, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_alias = Alias;
            this.GetByAlias();
            this.m_autoupdate = AutoUpdate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="AutoUpdate"></param>
        public Site(Int32 Id, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = Id;
            this.GetById();
            this.m_autoupdate = AutoUpdate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AutoUpdate"></param>
        public Site(bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Alias"></param>
        public Site(string Alias, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_alias = Alias;
            this.GetByAlias();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        public Site(Int32 Id, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = Id;
            this.GetById();
        }

        /// <summary>
        /// 
        /// </summary>
        public Site(String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
        }

        ~Site()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            if (RXServer.Data.ActivateGC)
                GC.Collect();
        }
        #endregion Constructors

        #region Public Methods

        public void Update()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Update]";
            try
            {
                if (this.m_exists)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("UPDATE sit_sites SET ");
                    sSQL.Append("lng_id = " + this.m_lng_id.ToString() + ", ");
                    sSQL.Append("sit_parentid = " + this.m_sit_parentid.ToString() + ", ");
                    sSQL.Append("sit_order = " + this.m_sit_order.ToString() + ", ");
                    sSQL.Append("sit_title = '" + this.m_sit_name.ToString() + "', ");
                    sSQL.Append("sit_alias = '" + this.m_sit_alias.ToString() + "', ");
                    sSQL.Append("sit_theme = '" + this.m_sit_theme.ToString() + "', ");
                    sSQL.Append("sit_skin = '" + this.m_sit_skin.ToString() + "', ");
                    sSQL.Append("sit_description = '" + this.m_sit_description.ToString() + "', ");
                    sSQL.Append("sit_createddate = '" + this.m_sit_createddate.ToString() + "', ");
                    sSQL.Append("sit_createdby = '" + this.m_sit_createdby.ToString() + "', ");
                    sSQL.Append("sit_updateddate = '" + this.m_sit_updateddate.ToString() + "', ");
                    sSQL.Append("sit_updatedby = '" + this.m_sit_updatedby.ToString() + "', ");
                    sSQL.Append("sit_hidden = " + Convert.ToString(!this.m_sit_hidden ? "0" : "1") + ", ");
                    sSQL.Append("sit_deleted = " + Convert.ToString(!this.m_sit_deleted ? "0" : "1") + " ");
                    sSQL.Append("WHERE sit_id = " + m_sit_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());

                    ResetThis();

                    this.PropertyUpdate("rol_id", this.m_sit_authorizededitroles, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
                    this.PropertyUpdate("grp_id", this.m_sit_authorizededitgroups, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);

                    if (this.m_sit_deleted)
                        DeleteRelations();
                }
                else
                {
                    throw new Exception("Can´t update a site that not exists");
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void ChangeOrderUp()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderUp]";
            try
            {
                this.m_sit_order = this.m_sit_order + 3;
                StringBuilder sSQL2 = new StringBuilder();
                sSQL2.Append("UPDATE sit_sites SET sit_order = " + this.m_sit_order.ToString() + " WHERE sit_id = " + this.m_sit_id.ToString());
                using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    oDo2.ExecuteNonQuery(sSQL2.ToString());
                SortAll();
                GetById();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void ChangeOrderDown()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderDown]";
            try
            {
                if (this.m_sit_order > 2)
                {
                    this.m_sit_order = this.m_sit_order - 3;
                    StringBuilder sSQL2 = new StringBuilder();
                    sSQL2.Append("UPDATE sit_sites SET sit_order = " + this.m_sit_order.ToString() + " WHERE sit_id = " + this.m_sit_id.ToString());
                    using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                        oDo2.ExecuteNonQuery(sSQL2.ToString());
                    SortAll();
                    GetById();
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_COLLECTION);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_ROLES);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_GROUPS);
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
                sSQL.Append("SELECT * FROM sit_sites WHERE sit_deleted = 0 ORDER BY sit_order");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                {
                    DataTable dt = oDo.GetDataTable(sSQL.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE sit_sites SET sit_order = " + Order.ToString() + " WHERE sit_id = " + dr["sit_id"].ToString());
                        using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                            oDo2.ExecuteNonQuery(sSQL2.ToString());
                        Order = Order + (Int32)OrderMinMax.Step;
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_ID + dr["sit_id"].ToString());
                    }
                    ResetThis();
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void PropertyUpdate(string Column, object Value, PropertyUpdateType Type, PropertyUpdateTableType Table)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::PropertyUpdate]";
            try
            {
                if ((this.m_exists) && (this.m_autoupdate))
                {
                    StringBuilder sSQL = new StringBuilder();
                    if (Table == PropertyUpdateTableType.Standard)
                    {
                        sSQL.Append("UPDATE sit_sites SET ");
                        switch (Type)
                        {
                            case PropertyUpdateType.String: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                            case PropertyUpdateType.Int32: sSQL.Append(Column + " = " + Value.ToString() + " ");
                                break;
                            case PropertyUpdateType.Boolean: sSQL.Append(Column + " = " + Convert.ToInt32(Value).ToString() + " ");
                                break;
                            case PropertyUpdateType.DateTime: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                            default: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                        }
                        sSQL.Append("WHERE sit_id = " + m_sit_id.ToString());
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());
                        ResetThis();

                        if(m_sit_deleted)
                            DeleteRelations();
                    }
                    else
                    {
                        switch (Column.ToLower())
                        {
                            case "rol_id":
                                {
                                    sSQL = new StringBuilder();
                                    sSQL.Append("UPDATE asr_authorizedsitesroles SET asr_deleted = 1 WHERE sit_id = " + this.m_sit_id.ToString());
                                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                        oDo.ExecuteNonQuery(sSQL.ToString());

                                    foreach (Int32 r in (Int32[])Value)
                                    {

                                        sSQL = new StringBuilder();
                                        sSQL.Append("INSERT INTO asr_authorizedsitesroles (sit_id, rol_id, asr_createddate, asr_createdby, asr_updateddate, asr_updatedby, asr_hidden, asr_deleted) VALUES ( ");
                                        sSQL.Append(this.m_sit_id.ToString() + ", ");
                                        sSQL.Append(r.ToString() + ", ");
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("0, ");
                                        sSQL.Append("0)");
                                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                            oDo.ExecuteNonQuery(sSQL.ToString());
                                    }
                                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_ROLES + m_sit_id.ToString());
                                    break;
                                }
                            case "grp_id":
                                {
                                    sSQL = new StringBuilder();
                                    sSQL.Append("UPDATE asg_authorizedsitesgroups SET asg_deleted = 1 WHERE sit_id = " + this.m_sit_id.ToString());
                                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                        oDo.ExecuteNonQuery(sSQL.ToString());

                                    foreach (Int32 g in (Int32[])Value)
                                    {

                                        sSQL = new StringBuilder();
                                        sSQL.Append("INSERT INTO asg_authorizedsitesgroups (sit_id, grp_id, asg_createddate, asg_createdby, asg_updateddate, asg_updatedby, asg_hidden, asg_deleted) VALUES ( ");
                                        sSQL.Append(this.m_sit_id.ToString() + ", ");
                                        sSQL.Append(g.ToString() + ", ");
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("0, ");
                                        sSQL.Append("0)");
                                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                            oDo.ExecuteNonQuery(sSQL.ToString());
                                    }
                                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_SITE_GROUPS + m_sit_id.ToString());
                                    break;
                                }
                            default:
                                {

                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetById()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetById]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_SITE_ID + "::SitId" + m_sit_id.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM sit_sites WHERE sit_id = " + m_sit_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                    this.m_sit_parentid = Convert.ToInt32(dr["sit_parentid"]);
                    this.m_sit_order = Convert.ToInt32(dr["sit_order"]);
                    this.m_sit_name = Convert.ToString(dr["sit_title"]);
                    this.m_sit_alias = Convert.ToString(dr["sit_alias"]);
                    this.m_sit_description = Convert.ToString(dr["sit_description"]);
                    this.m_sit_authorizededitroles = this.GetAuthorizedEditRoles(Convert.ToInt32(dr["sit_id"]));
                    this.m_sit_authorizededitgroups = this.GetAuthorizedEditGroups(Convert.ToInt32(dr["sit_id"]));
                    this.m_sit_theme = Convert.ToString(dr["sit_theme"]);
                    this.m_sit_skin = Convert.ToString(dr["sit_skin"]);
                    this.m_sit_createddate = Convert.ToDateTime(dr["sit_createddate"]);
                    this.m_sit_createdby = Convert.ToString(dr["sit_createdby"]);
                    this.m_sit_updateddate = Convert.ToDateTime(dr["sit_updateddate"]);
                    this.m_sit_updatedby = Convert.ToString(dr["sit_updatedby"]);
                    this.m_sit_hidden = Convert.ToBoolean(dr["sit_hidden"]);
                    this.m_sit_deleted = Convert.ToBoolean(dr["sit_deleted"]);
                    this.m_exists = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetByAlias()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetByAlias]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_SITE_ALIAS + "::SitAlias" + m_sit_alias;
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM sit_sites WHERE sit_alias = '" + m_sit_alias + "'");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                    this.m_sit_parentid = Convert.ToInt32(dr["sit_parentid"]);
                    this.m_sit_order = Convert.ToInt32(dr["sit_order"]);
                    this.m_sit_name = Convert.ToString(dr["sit_title"]);
                    this.m_sit_alias = Convert.ToString(dr["sit_alias"]);
                    this.m_sit_description = Convert.ToString(dr["sit_description"]);
                    this.m_sit_authorizededitroles = this.GetAuthorizedEditRoles(Convert.ToInt32(dr["sit_id"]));
                    this.m_sit_authorizededitgroups = this.GetAuthorizedEditGroups(Convert.ToInt32(dr["sit_id"]));
                    this.m_sit_theme = Convert.ToString(dr["sit_theme"]);
                    this.m_sit_skin = Convert.ToString(dr["sit_skin"]);
                    this.m_sit_createddate = Convert.ToDateTime(dr["sit_createddate"]);
                    this.m_sit_createdby = Convert.ToString(dr["sit_createdby"]);
                    this.m_sit_updateddate = Convert.ToDateTime(dr["sit_updateddate"]);
                    this.m_sit_updatedby = Convert.ToString(dr["sit_updatedby"]);
                    this.m_sit_hidden = Convert.ToBoolean(dr["sit_hidden"]);
                    this.m_sit_deleted = Convert.ToBoolean(dr["sit_deleted"]);
                    this.m_exists = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetParents()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetParents]";
            Int32[] Parents = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_SITE_ID + "::SitId" + m_sit_id.ToString() + "::Parents";
                if (HttpContext.Current != null) if (HttpContext.Current != null) Parents = (Int32[])HttpContext.Current.Cache[CacheItem];
                if (Parents == null)
                {
                    if (this.ParentId > 0)
                    {
                        Parents = new Int32[1];
                        Parents[0] = this.ParentId;
                        Parents = Generic.GrowArray(GetNextParent(Parents, this.ParentId), 0);
                        RXServer.Data.CacheInsert(CacheItem, Parents);
                    }
                }
                this.m_sit_parents = Parents;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private Boolean FindChildren()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::FindChildren]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_SITE_ID + "::SitId" + m_sit_id.ToString() + "::Children";
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT sit_id FROM sit_sites WHERE sit_parentid = " + m_sit_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }
        private Int32[] GetNextParent(Int32[] Parents, Int32 SitId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetNextParent]";
            try
            {
                Site s = new Site(SitId, Data.DataSource, Data.ConnectionString);
                if (s.ParentId > 0)
                {
                    Parents = Generic.GrowArray(Parents, Parents.Length + 1);
                    Parents[Parents.Length - 1] = s.ParentId;
                    Parents = GetNextParent(Parents, s.ParentId);
                }
                return Parents;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return Parents;
            }
        }
        private Int32[] GetAuthorizedEditRoles(Int32 SitId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditRoles]";
            Int32[] Roles;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_SITE_ROLES + "::SitId" + SitId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM asr_authorizedsitesroles WHERE sit_id = " + SitId.ToString() + " AND asr_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Roles = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Roles[i] = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                return Roles;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Int32[] GetAuthorizedEditGroups(Int32 SitId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditGroups]";
            Int32[] Groups;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_SITE_GROUPS + "::SitId" + SitId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM asg_authorizedsitesgroups WHERE sit_id = " + SitId.ToString() + " AND asg_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Groups = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Groups[i] = Convert.ToInt32(dt.Rows[i]["grp_id"]);
                return Groups;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private void DeleteRelations()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DeleteRelations]";
            try
            {
                // Delete SiteCollection... 
                // not in use for Sites...

                // Delete PageCollection...
                using (PageCollection pc = new PageCollection(this.m_sit_id, true, true, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                {
                    foreach (Page p in pc.Items)
                        p.Deleted = true;
                }

                // Delete TaskCollection...
                using (TaskCollection tc = new TaskCollection(this.m_sit_id, true, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                {
                    foreach (Task t in tc.Items)
                        t.Deleted = true;
                }

                // Delete ModuleCollection... 
                // not in use for Sites...

                // Delete DocumentCollection...
                using (DocumentCollection dc = new DocumentCollection(this.m_sit_id, true, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                {
                    foreach (Document d in dc.Items)
                        d.Deleted = true;
                }

                // Delete ObjectCollection...
                using (ObjectCollection oc = new ObjectCollection(this.m_sit_id, true, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                {
                    foreach (Object o in oc.Items)
                        o.Deleted = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        #endregion Private Methods

    }
    #endregion public class Site

    #region public class PageCollection

    /// <summary>
    /// PageCollection
    /// </summary>
    public class PageCollection : IDisposable, IEnumerable
    {
        string CLASSNAME = "[Namespace::RXServer][Class::PageCollection]";

        #region DataHandler Variables

        private string m_datasource;
        private string m_connectionstring;

        #endregion DataHandler Variables

        #region Private Variables

        private Page m_page;
        private Page[] m_pages = new Page[0];
        private Int32 m_sit_id;
        private Int32 m_pag_parentid;
        private Boolean m_autoupdate;
        private Boolean m_includehidden;
        private DataTable m_dtpages;
        private Boolean m_refresh; 

        #endregion Private Variables

        #region Properties


        public IEnumerator GetEnumerator()
        {
            return new RXPageEnum(this.m_pages);
        }
        /// <summary>
        /// 
        /// </summary>
        public Page this[Int32 index]
        {
            get
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Page]";
                try
                {
                    this.m_page = (Page)this.m_pages[index];
                    return this.m_page;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return new Page(this.m_sit_id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Page[] Items
        {
            get
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Page]";
                try
                {
                    return this.m_pages;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return new Page[0];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Page GetPage(Int32 Id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetPage]";
            try
            {
                foreach (Page p in this.m_pages)
                {
                    if (p.Id == Id)
                    {
                        return p;
                    }
                }
                return new Page(this.m_sit_id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Page(this.m_sit_id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>true | false</returns>
        public bool Contains(Int32 Id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            try
            {
                foreach (Page p in this.m_pages)
                {
                    if (p.Id == Id)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool Contains(string Name)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            try
            {
                foreach (Page p in this.m_pages)
                {
                    if (p.Name.ToLower() == Name.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        public bool Refresh
        {
            get
            {
                return this.m_refresh; 
            }
            set
            {
                this.m_refresh = value;
            }
        }


        #endregion Properties

        #region Constructors

        public PageCollection(Int32 SitId, Boolean AutoUpdate, String Datasource, String ConnectionString) : this(SitId, AutoUpdate, Datasource, ConnectionString, true)
        {
        }
        public PageCollection(Int32 SitId, Int32 PageParentId, Boolean AutoUpdate, String Datasource, String ConnectionString) : this(SitId, PageParentId, AutoUpdate, Datasource, ConnectionString, true)
        {
        }
        public PageCollection(Int32 SitId, Boolean AutoUpdate, Boolean IncludeHidden, String Datasource, String ConnectionString) : this(SitId, AutoUpdate, IncludeHidden, Datasource, ConnectionString, true)
        {
        }
        public PageCollection(Int32 SitId, Int32 PageParentId, Boolean AutoUpdate, Boolean IncludeHidden, String Datasource, String ConnectionString) : this(SitId, PageParentId, AutoUpdate, IncludeHidden, Datasource, ConnectionString, true)
        {}
        
        public PageCollection(Int32 SitId, Boolean AutoUpdate, String Datasource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = Datasource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_parentid = 0;
            this.m_autoupdate = AutoUpdate;
            this.m_includehidden = true;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public PageCollection(Int32 SitId, Int32 PageParentId, Boolean AutoUpdate, String Datasource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = Datasource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_parentid = PageParentId;
            this.m_autoupdate = AutoUpdate;
            this.m_includehidden = true;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public PageCollection(Int32 SitId, Boolean AutoUpdate, Boolean IncludeHidden, String Datasource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = Datasource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_parentid = 0;
            this.m_autoupdate = AutoUpdate;
            this.m_includehidden = IncludeHidden;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public PageCollection(Int32 SitId, Int32 PageParentId, Boolean AutoUpdate, Boolean IncludeHidden, String Datasource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = Datasource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_parentid = PageParentId;
            this.m_autoupdate = AutoUpdate;
            this.m_includehidden = IncludeHidden;
            this.m_refresh = Refresh; 
            GetAll();
        }

        ~PageCollection()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            if (!this.Refresh)
                ResetThis();
            if (RXServer.Data.ActivateGC)
                GC.Collect();
        }
        #endregion Constructors

        #region Public Methods

        public void Add(Page page)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            try
            {
                this.Add(ref page);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void Add(ref Page page)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            try
            {
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("INSERT INTO pag_pages (sit_id, lng_id, pag_parentid, pag_order, ");
                sSQL.Append("pag_title, pag_alias, pag_description, pag_theme, pag_skin, pag_createddate, ");
                sSQL.Append("pag_createdby, pag_updateddate, pag_updatedby, ");
                sSQL.Append("pag_hidden, pag_deleted) VALUES (");
                sSQL.Append(page.SiteId.ToString() + ", ");
                sSQL.Append(page.Language.ToString() + ", ");
                sSQL.Append(page.ParentId.ToString() + ", ");
                sSQL.Append(page.Order.ToString() + ", ");
                sSQL.Append("'" + page.Name + "', ");
                sSQL.Append("'" + page.Alias + "', ");
                sSQL.Append("'" + page.Description + "', ");
                sSQL.Append("'" + page.Theme + "', ");
                sSQL.Append("'" + page.Skin + "', ");
                sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                sSQL.Append(page.Hidden + ",");
                sSQL.Append("0)");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                {
                    oDo.ExecuteNonQuery(sSQL.ToString());
                    page.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                }

                foreach (Int32 r in page.AuthorizedEditRoles)
                {
                    sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO apr_authorizedpagesroles (pag_id, rol_id, apr_createddate, apr_createdby, apr_updateddate, apr_updatedby, apr_hidden, apr_deleted) VALUES ( ");
                    sSQL.Append(page.Id.ToString() + ", ");
                    sSQL.Append(r.ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());
                }

                foreach (Int32 g in page.AuthorizedEditGroups)
                {
                    sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO apg_authorizedpagesgroups (pag_id, grp_id, apg_createddate, apg_createdby, apg_updateddate, apg_updatedby, apg_hidden, apg_deleted) VALUES ( ");
                    sSQL.Append(page.Id.ToString() + ", ");
                    sSQL.Append(g.ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());
                }

                SortAll();
                GetAll();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        public void Remove(Page page)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            try
            {
                this.Remove(page.Id);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        public void Remove(Int32 id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            try
            {
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("UPDATE pag_pages SET pag_deleted = 1 ");
                sSQL.Append("WHERE pag_id = " + id.ToString());
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                    oDo.ExecuteNonQuery(sSQL.ToString());
                SortAll(); 
                GetAll();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        public void Clear()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Clear]";
            try
            {
                this.m_pages = null;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        public Int32 Count()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Count]";
            try
            {
                return this.m_pages.Length;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return 0;
            }
        }

        public DataTable DataTable()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            try
            {
                return m_dtpages;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new DataTable();
            }
        }

        public DataTable DataTable(PageSortField SortField, SortOrder SortOrder)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            try
            {
                DataView v = new DataView(m_dtpages);
                v.Sort = RetriveSortField(SortField) + Convert.ToString((Int32)SortOrder == 1 ? String.Empty : " DESC");
                return v.ToTable();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new DataTable();
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_COLLECTION);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_ROLES);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_GROUPS);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private String RetriveSortField(PageSortField SortField)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::RetriveSortField]";
            try
            {

                if ((Int32)SortField == 1) return "pag_id";
                if ((Int32)SortField == 2) return "sit_id";
                if ((Int32)SortField == 3) return "lng_id";
                if ((Int32)SortField == 4) return "pag_order";
                if ((Int32)SortField == 5) return "pag_parentid";
                if ((Int32)SortField == 6) return "pag_title";
                if ((Int32)SortField == 7) return "pag_alias";
                if ((Int32)SortField == 8) return "pag_description";
                if ((Int32)SortField == 9) return "pag_theme";
                if ((Int32)SortField == 10) return "pag_skin";
                if ((Int32)SortField == 11) return "pag_createddate";
                if ((Int32)SortField == 12) return "pag_createdby";
                if ((Int32)SortField == 13) return "pag_updateddate";
                if ((Int32)SortField == 14) return "pag_updatedby";
                return String.Empty;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return String.Empty;
            }
        }
        private void GetAll()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAll]";
            DataTable dt = null;
            if (!this.Refresh)
                return;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_PAGE_COLLECTION + "::SitId" + this.m_sit_id.ToString() + "::PageParentId" + this.m_pag_parentid.ToString() + "::IncludeHidden" + this.m_includehidden.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    if (this.m_pag_parentid == 0)
                        sSQL.Append("SELECT * FROM pag_pages WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_parentid = 0" + (!this.m_includehidden ? " AND pag_hidden = 0" : String.Empty) + " AND pag_deleted = 0 ORDER BY pag_order");
                    else
                        sSQL.Append("SELECT * FROM pag_pages WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_parentid = " + this.m_pag_parentid.ToString() + (!this.m_includehidden ? " AND pag_hidden = 0" : String.Empty) + " AND pag_deleted = 0 ORDER BY pag_order");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    this.m_dtpages = dt;
                    Int32 index = 0;
                    this.m_pages = new Page[dt.Rows.Count];
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.m_pages[index] = new Page(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
                        this.m_pages[index].Id = Convert.ToInt32(dr["pag_id"]);
                        this.m_pages[index].SiteId = Convert.ToInt32(dr["sit_id"]);
                        this.m_pages[index].Language = Convert.ToInt32(dr["lng_id"]);
                        this.m_pages[index].ParentId = Convert.ToInt32(dr["pag_parentid"]);
                        this.m_pages[index].Order = Convert.ToInt32(dr["pag_order"]);
                        this.m_pages[index].Name = Convert.ToString(dr["pag_title"]);
                        this.m_pages[index].Alias = Convert.ToString(dr["pag_alias"]);
                        this.m_pages[index].Description = Convert.ToString(dr["pag_description"]);
                        this.m_pages[index].AuthorizedEditRoles = this.GetAuthorizedEditRoles(Convert.ToInt32(dr["pag_id"]));
                        this.m_pages[index].AuthorizedEditGroups = this.GetAuthorizedEditGroups(Convert.ToInt32(dr["pag_id"]));
                        this.m_pages[index].Theme = Convert.ToString(dr["pag_theme"]);
                        this.m_pages[index].Skin = Convert.ToString(dr["pag_skin"]);
                        this.m_pages[index].CreatedDate = Convert.ToDateTime(dr["pag_createddate"]);
                        this.m_pages[index].CreatedBy = Convert.ToString(dr["pag_createdby"]);
                        this.m_pages[index].UpdatedDate = Convert.ToDateTime(dr["pag_updateddate"]);
                        this.m_pages[index].UpdatedBy = Convert.ToString(dr["pag_updatedby"]);
                        this.m_pages[index].Hidden = Convert.ToBoolean(dr["pag_hidden"]);
                        this.m_pages[index].Deleted = Convert.ToBoolean(dr["pag_deleted"]);
                        this.m_pages[index].Exist = true;
                        index++;
                    }
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
            if (!this.Refresh)
                return;
            try
            {
                Int32 Order = (Int32)OrderMinMax.Min;
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("SELECT * FROM pag_pages WHERE pag_deleted = 0 ORDER BY sit_id, pag_order");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                {
                    DataTable dt = oDo.GetDataTable(sSQL.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE pag_pages SET pag_order = " + Order.ToString() + " WHERE pag_id = " + dr["pag_id"].ToString());
                        using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
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
        private Int32[] GetAuthorizedEditRoles(Int32 PagId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditRoles]";
            Int32[] Roles;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_PAGE_ROLES + "::PagId" + PagId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM apr_authorizedpagesroles WHERE pag_id = " + PagId.ToString() + " AND apr_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Roles = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Roles[i] = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                return Roles;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Int32[] GetAuthorizedEditGroups(Int32 PagId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditGroups]";
            Int32[] Groups;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_PAGE_GROUPS + "::PagId" + PagId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM apg_authorizedpagesgroups WHERE pag_id = " + PagId.ToString() + " AND apg_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Groups = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Groups[i] = Convert.ToInt32(dt.Rows[i]["grp_id"]);
                return Groups;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }

        #endregion Private Methods

    }
    #endregion public class PageCollection

    #region public class Page

    public class Page : IDisposable
    {
        string CLASSNAME = "[Namespace::RXServer][Class::Page]";

        #region DataHandler Variables

        private string m_datasource;
        private string m_connectionstring;

        #endregion DataHandler Variables

        #region Private Variables

        private bool m_exists = false;
        private bool m_autoupdate = false;
        private bool m_refresh = true;

        private Int32 m_pag_id = 0;
        private Int32 m_sit_id = 0;
        private Int32 m_lng_id = 0;
        private Int32 m_pag_order = 0;
        private Int32 m_pag_parentid = 0;
        private Int32[] m_pag_parents = new Int32[0];
        private String m_pag_name = String.Empty;
        private String m_pag_alias = String.Empty;
        private String m_pag_theme = String.Empty;
        private String m_pag_skin = String.Empty;
        private string m_pag_description = String.Empty;
        private Int32[] m_pag_authorizededitroles = new Int32[0];
        private Int32[] m_pag_authorizededitgroups = new Int32[0];
        private DateTime m_pag_createddate = DateTime.Now;
        private String m_pag_createdby = String.Empty;
        private DateTime m_pag_updateddate = DateTime.Now;
        private String m_pag_updatedby = String.Empty;
        private bool m_pag_hidden = false;
        private bool m_pag_deleted = false;

        private bool m_pag_haschildren = false;
        private bool m_pag_hasparent = false;

        #endregion Private Variables

        #region Properties

        public bool AutoUpdate
        {
            set
            {
                this.m_autoupdate = value;
            }
        }
        public bool Exist
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
        public bool HasChildren
        {
            get
            {
                this.m_pag_haschildren = this.FindChildren();
                return this.m_pag_haschildren;
            }
        }
        public bool HasParent
        {
            get
            {
                this.m_pag_hasparent = this.m_pag_parentid == 0 ? false : true;
                return this.m_pag_hasparent;
            }
        }
        public ModuleCollection Modules
        {
            get
            {
                return new ModuleCollection(this.m_sit_id, this.m_pag_id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }
        public ObjectCollection Objects
        {
            get
            {
                return new ObjectCollection(this.m_sit_id, this.m_pag_id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }
        public Int32 SiteId
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
        public Int32 Id
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
        public Int32 Language
        {
            get
            {
                return this.m_lng_id;
            }
            set
            {
                this.m_lng_id = value;
                PropertyUpdate("lng_id", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public Int32 Order
        {
            get
            {
                return this.m_pag_order;
            }
            set
            {
                this.m_pag_order = value;
                PropertyUpdate("pag_order", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public Int32 ParentId
        {
            get
            {
                return this.m_pag_parentid;
            }
            set
            {
                this.m_pag_parentid = value;
                PropertyUpdate("pag_parentid", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public Int32[] Parents
        {
            get
            {
                GetParents();
                return this.m_pag_parents;
            }
        }
        public string Name
        {
            get
            {
                return this.m_pag_name;
            }
            set
            {
                this.m_pag_name = Common.SafeString(value);
                PropertyUpdate("pag_name", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Alias
        {
            get
            {
                return this.m_pag_alias;
            }
            set
            {
                this.m_pag_alias = Common.SafeString(value);
                PropertyUpdate("pag_alias", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Theme
        {
            get
            {
                return this.m_pag_theme;
            }
            set
            {
                this.m_pag_theme = Common.SafeString(value);
                PropertyUpdate("pag_theme", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Skin
        {
            get
            {
                return this.m_pag_skin;
            }
            set
            {
                this.m_pag_skin = Common.SafeString(value);
                PropertyUpdate("pag_skin", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Description
        {
            get
            {
                return this.m_pag_description;
            }
            set
            {
                this.m_pag_description = Common.SafeString(value);
                PropertyUpdate("pag_description", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public Int32[] AuthorizedEditRoles
        {
            get
            {
                return this.m_pag_authorizededitroles;
            }
            set
            {
                this.m_pag_authorizededitroles = value;
                PropertyUpdate("rol_id", value, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
            }
        }
        public Int32[] AuthorizedEditGroups
        {
            get
            {
                return this.m_pag_authorizededitgroups;
            }
            set
            {
                this.m_pag_authorizededitgroups = value;
                PropertyUpdate("grp_id", value, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return this.m_pag_createddate;
            }
            set
            {
                this.m_pag_createddate = value;
            }
        }
        public string CreatedBy
        {
            get
            {
                return this.m_pag_createdby;
            }
            set
            {
                this.m_pag_createdby = Common.SafeString(value);
            }
        }
        public DateTime UpdatedDate
        {
            get
            {
                return this.m_pag_updateddate;
            }
            set
            {
                this.m_pag_updateddate = value;
            }
        }
        public string UpdatedBy
        {
            get
            {
                return this.m_pag_updatedby;
            }
            set
            {
                this.m_pag_updatedby = Common.SafeString(value);
            }
        }
        public bool Hidden
        {
            get
            {
                return this.m_pag_hidden;
            }
            set
            {
                this.m_pag_hidden = value;
                PropertyUpdate("pag_hidden", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public bool Deleted
        {
            get
            {
                return this.m_pag_deleted;
            }
            set
            {
                this.m_pag_deleted = value;
                PropertyUpdate("pag_deleted", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public bool Refresh
        {
            get
            {
                return this.m_refresh;
            }
            set
            {
                this.m_refresh = value;
            }
        }

        #endregion Properties

        #region Constructors

        public Page(Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.GetById();
            this.m_autoupdate = AutoUpdate;
        }

        public Page(Int32 SitId, Int32 PagId, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.GetById();
        }

        public Page(Int32 SitId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_autoupdate = AutoUpdate;
        }

        public Page(bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
        }

        public Page(String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
        }

        public Page()
        {
        }

        ~Page()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            if (RXServer.Data.ActivateGC)
                GC.Collect();
        }
        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public void Update()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Update]";
            try
            {
                if (this.m_exists)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("UPDATE pag_pages SET ");
                    sSQL.Append("sit_id = " + this.m_sit_id.ToString() + ", ");
                    sSQL.Append("lng_id = " + this.m_lng_id.ToString() + ", ");
                    sSQL.Append("pag_parentid = " + this.m_pag_parentid.ToString() + ", ");
                    sSQL.Append("pag_order = " + this.m_pag_order.ToString() + ", ");
                    sSQL.Append("pag_title = '" + this.m_pag_name.ToString() + "', ");
                    sSQL.Append("pag_alias = '" + this.m_pag_alias.ToString() + "', ");
                    sSQL.Append("pag_theme = '" + this.m_pag_theme.ToString() + "', ");
                    sSQL.Append("pag_skin = '" + this.m_pag_skin.ToString() + "', ");
                    sSQL.Append("pag_description = '" + this.m_pag_description.ToString() + "', ");
                    sSQL.Append("pag_createddate = '" + this.m_pag_createddate.ToString() + "', ");
                    sSQL.Append("pag_createdby = '" + this.m_pag_createdby.ToString() + "', ");
                    sSQL.Append("pag_updateddate = '" + this.m_pag_updateddate.ToString() + "', ");
                    sSQL.Append("pag_updatedby = '" + this.m_pag_updatedby.ToString() + "', ");
                    sSQL.Append("pag_hidden = " + Convert.ToString(!this.m_pag_hidden ? "0" : "1") + ", ");
                    sSQL.Append("pag_deleted = " + Convert.ToString(!this.m_pag_deleted ? "0" : "1") + " ");
                    sSQL.Append("WHERE pag_id = " + m_pag_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());

                    ResetThis();

                    this.PropertyUpdate("rol_id", this.m_pag_authorizededitroles, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
                    this.PropertyUpdate("grp_id", this.m_pag_authorizededitgroups, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);

                    if (this.m_pag_deleted)
                        DeleteRelations();
                }
                else
                {
                    throw new Exception("Can´t update a page that not exists");
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void Save()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
            try
            {
                if (!this.Exist)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO pag_pages (sit_id, lng_id, pag_parentid, pag_order, ");
                    sSQL.Append("pag_title, pag_alias, pag_description, pag_theme, pag_skin, pag_createddate, ");
                    sSQL.Append("pag_createdby, pag_updateddate, pag_updatedby, ");
                    sSQL.Append("pag_hidden, pag_deleted) VALUES (");
                    sSQL.Append(this.SiteId.ToString() + ", ");
                    sSQL.Append(this.Language.ToString() + ", ");
                    sSQL.Append(this.ParentId.ToString() + ", ");
                    sSQL.Append(this.Order.ToString() + ", ");
                    sSQL.Append("'" + this.Name + "', ");
                    sSQL.Append("'" + this.Alias + "', ");
                    sSQL.Append("'" + this.Description + "', ");
                    sSQL.Append("'" + this.Theme + "', ");
                    sSQL.Append("'" + this.Skin + "', ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append(this.Hidden + ",");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                    {
                        oDo.ExecuteNonQuery(sSQL.ToString());
                        this.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                    }

                    foreach (Int32 r in this.AuthorizedEditRoles)
                    {
                        sSQL = new StringBuilder();
                        sSQL.Append("INSERT INTO apr_authorizedpagesroles (pag_id, rol_id, apr_createddate, apr_createdby, apr_updateddate, apr_updatedby, apr_hidden, apr_deleted) VALUES ( ");
                        sSQL.Append(this.Id.ToString() + ", ");
                        sSQL.Append(r.ToString() + ", ");
                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("0, ");
                        sSQL.Append("0)");
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());
                    }

                    foreach (Int32 g in this.AuthorizedEditGroups)
                    {
                        sSQL = new StringBuilder();
                        sSQL.Append("INSERT INTO apg_authorizedpagesgroups (pag_id, grp_id, apg_createddate, apg_createdby, apg_updateddate, apg_updatedby, apg_hidden, apg_deleted) VALUES ( ");
                        sSQL.Append(this.Id.ToString() + ", ");
                        sSQL.Append(g.ToString() + ", ");
                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("0, ");
                        sSQL.Append("0)");
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());
                    }

                    if (this.m_refresh)
                    {
                        ResetThis();
                        SortAll();
                    }
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
        public void ChangeOrderUp()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderUp]";
            try
            {
                this.m_pag_order = this.m_pag_order + 3;
                StringBuilder sSQL2 = new StringBuilder();
                sSQL2.Append("UPDATE pag_pages SET pag_order = " + this.m_pag_order.ToString() + " WHERE pag_id = " + this.m_pag_id.ToString());
                using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    oDo2.ExecuteNonQuery(sSQL2.ToString());
                SortAll();
                GetById();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void ChangeOrderDown()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderDown]";
            try
            {
                if (this.m_pag_order > 2)
                {
                    this.m_pag_order = this.m_pag_order - 3;
                    StringBuilder sSQL2 = new StringBuilder();
                    sSQL2.Append("UPDATE pag_pages SET pag_order = " + this.m_pag_order.ToString() + " WHERE pag_id = " + this.m_pag_id.ToString());
                    using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                        oDo2.ExecuteNonQuery(sSQL2.ToString());
                    SortAll();
                    GetById();
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_COLLECTION);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_ROLES);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_GROUPS);
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
                sSQL.Append("SELECT * FROM pag_pages WHERE pag_deleted = 0 ORDER BY sit_id, pag_parentid, pag_order");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                {
                    DataTable dt = oDo.GetDataTable(sSQL.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE pag_pages SET pag_order = " + Order.ToString() + " WHERE pag_id = " + dr["pag_id"].ToString());
                        using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                            oDo2.ExecuteNonQuery(sSQL2.ToString());
                        Order = Order + (Int32)OrderMinMax.Step;
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_ID + dr["pag_id"].ToString());
                    }
                    ResetThis();
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void PropertyUpdate(string Column, object Value, PropertyUpdateType Type, PropertyUpdateTableType Table)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::PropertyUpdate]";
            try
            {
                if ((this.m_exists) && (this.m_autoupdate))
                {
                    StringBuilder sSQL = new StringBuilder();
                    if (Table == PropertyUpdateTableType.Standard)
                    {
                        sSQL.Append("UPDATE pag_pages SET ");
                        switch (Type)
                        {
                            case PropertyUpdateType.String: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                            case PropertyUpdateType.Int32: sSQL.Append(Column + " = " + Value.ToString() + " ");
                                break;
                            case PropertyUpdateType.Boolean: sSQL.Append(Column + " = " + Convert.ToInt32(Value).ToString() + " ");
                                break;
                            case PropertyUpdateType.DateTime: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                            default: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                        }
                        sSQL.Append("WHERE pag_id = " + m_pag_id.ToString());
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());
                        ResetThis();
                        if (this.m_pag_deleted)
                            DeleteRelations();
                    }
                    else
                    {
                        switch (Column.ToLower())
                        {
                            case "rol_id":
                                {
                                    sSQL = new StringBuilder();
                                    sSQL.Append("UPDATE apr_authorizedpagesroles SET apr_deleted = 1 WHERE pag_id = " + this.m_pag_id.ToString());
                                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                        oDo.ExecuteNonQuery(sSQL.ToString());

                                    foreach (Int32 r in (Int32[])Value)
                                    {

                                        sSQL = new StringBuilder();
                                        sSQL.Append("INSERT INTO apr_authorizedpagesroles (pag_id, rol_id, apr_createddate, apr_createdby, apr_updateddate, apr_updatedby, apr_hidden, apr_deleted) VALUES ( ");
                                        sSQL.Append(this.m_pag_id.ToString() + ", ");
                                        sSQL.Append(r.ToString() + ", ");
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("0, ");
                                        sSQL.Append("0)");
                                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                            oDo.ExecuteNonQuery(sSQL.ToString());
                                    }
                                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_ROLES + m_pag_id.ToString());
                                    break;
                                }
                            case "grp_id":
                                {
                                    sSQL = new StringBuilder();
                                    sSQL.Append("UPDATE apg_authorizedpagesgroups SET apg_deleted = 1 WHERE pag_id = " + this.m_pag_id.ToString());
                                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                        oDo.ExecuteNonQuery(sSQL.ToString());

                                    foreach (Int32 g in (Int32[])Value)
                                    {

                                        sSQL = new StringBuilder();
                                        sSQL.Append("INSERT INTO apg_authorizedpagesgroups (pag_id, grp_id, apg_createddate, apg_createdby, apg_updateddate, apg_updatedby, apg_hidden, apg_deleted) VALUES ( ");
                                        sSQL.Append(this.m_pag_id.ToString() + ", ");
                                        sSQL.Append(g.ToString() + ", ");
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("0, ");
                                        sSQL.Append("0)");
                                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                            oDo.ExecuteNonQuery(sSQL.ToString());
                                    }
                                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_PAGE_GROUPS + m_pag_id.ToString());
                                    break;
                                }
                            default:
                                {

                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetParents()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetParents]";
            Int32[] Parents = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_PAGE_ID + "::PagId" + m_pag_id.ToString() + "::Parents";
                if (HttpContext.Current != null) if (HttpContext.Current != null) Parents = (Int32[])HttpContext.Current.Cache[CacheItem];
                if (Parents == null)
                {
                    if (this.ParentId > 0)
                    {
                        Parents = new Int32[1];
                        Parents[0] = this.ParentId;
                        Parents = Generic.GrowArray(GetNextParent(Parents, this.ParentId), 0);
                        RXServer.Data.CacheInsert(CacheItem, Parents);
                    }
                }
                this.m_pag_parents = Parents;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private Int32[] GetNextParent(Int32[] Parents, Int32 PagId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetNextParent]";
            try
            {
                Page p = new Page(this.SiteId, PagId, Data.DataSource, Data.ConnectionString);
                if (p.ParentId > 0)
                {
                    Parents = Generic.GrowArray(Parents, Parents.Length + 1);
                    Parents[Parents.Length - 1] = p.ParentId;
                    Parents = GetNextParent(Parents, p.ParentId);
                }
                return Parents;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return Parents;
            }
        }
        private void GetById()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetById]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_PAGE_ID + "::PagId" + m_pag_id.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM pag_pages WHERE pag_id = " + m_pag_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.m_sit_id = Convert.ToInt32(dr["sit_id"]);
                    this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                    this.m_pag_parentid = Convert.ToInt32(dr["pag_parentid"]);
                    this.m_pag_order = Convert.ToInt32(dr["pag_order"]);
                    this.m_pag_name = Convert.ToString(dr["pag_title"]);
                    this.m_pag_alias = Convert.ToString(dr["pag_alias"]);
                    this.m_pag_description = Convert.ToString(dr["pag_description"]);
                    this.m_pag_authorizededitroles = this.GetAuthorizedEditRoles(Convert.ToInt32(dr["pag_id"]));
                    this.m_pag_authorizededitgroups = this.GetAuthorizedEditGroups(Convert.ToInt32(dr["pag_id"]));
                    this.m_pag_theme = Convert.ToString(dr["pag_theme"]);
                    this.m_pag_skin = Convert.ToString(dr["pag_skin"]);
                    this.m_pag_createddate = Convert.ToDateTime(dr["pag_createddate"]);
                    this.m_pag_createdby = Convert.ToString(dr["pag_createdby"]);
                    this.m_pag_updateddate = Convert.ToDateTime(dr["pag_updateddate"]);
                    this.m_pag_updatedby = Convert.ToString(dr["pag_updatedby"]);
                    this.m_pag_hidden = Convert.ToBoolean(dr["pag_hidden"]);
                    this.m_pag_deleted = Convert.ToBoolean(dr["pag_deleted"]);
                    this.m_exists = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private Int32[] GetAuthorizedEditRoles(Int32 PagId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditRoles]";
            Int32[] Roles;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_PAGE_ROLES + "::PagId" + PagId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM apr_authorizedpagesroles WHERE pag_id = " + PagId.ToString() + " AND apr_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Roles = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Roles[i] = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                return Roles;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Int32[] GetAuthorizedEditGroups(Int32 PagId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditGroups]";
            Int32[] Groups;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_PAGE_GROUPS + "::PagId" + PagId.ToString();
                if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM apg_authorizedpagesgroups WHERE pag_id = " + PagId.ToString() + " AND apg_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Groups = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Groups[i] = Convert.ToInt32(dt.Rows[i]["grp_id"]);
                return Groups;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Boolean FindChildren()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::FindChildren]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_PAGE_ID + "::PagId" + m_pag_id.ToString() + "::Children";
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT pag_id FROM pag_pages WHERE pag_parentid = " + m_pag_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }
        private void DeleteRelations()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DeleteRelations]";
            try
            {
                // Delete SiteCollection... 
                // not in use for Pages...

                // Delete PageCollection...
                using (PageCollection pc = new PageCollection(this.m_sit_id, this.m_pag_id, true, true, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                {
                    foreach (Page p in pc.Items)
                        p.Deleted = true;
                }

                // Delete TaskCollection...
                // not in use for Pages...

                // Delete ModuleCollection... 
                using (ModuleCollection mc = new ModuleCollection(this.m_sit_id, this.m_pag_id, true, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                {
                    foreach (Module m in mc.Items)
                        m.Deleted = true;
                }

                // Delete DocumentCollection...
                using (DocumentCollection dc = new DocumentCollection(this.m_sit_id, this.m_pag_id, true, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                {
                    foreach (Document d in dc.Items)
                        d.Deleted = true;
                }

                // Delete ObjectCollection...
                using (ObjectCollection oc = new ObjectCollection(this.m_sit_id, this.m_pag_id, true, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                {
                    foreach (Object o in oc.Items)
                        o.Deleted = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        #endregion Private Methods

    }
    #endregion public class Page

    #region public class TaskCollection

    /// <summary>
    /// TaskCollection
    /// </summary>
    public class TaskCollection : IDisposable, IEnumerable
    {
        string CLASSNAME = "[Namespace::RXServer][Class::TaskCollection]";

        #region DataHandler Variables

        private string m_datasource;
        private string m_connectionstring;

        #endregion DataHandler Variables

        #region Private Variables

        private Task m_task;
        private Task[] m_tasks = new Task[0];
        private Int32 m_sit_id;
        private bool m_autoupdate;
        private DataTable m_dttasks;
        private Boolean m_refresh; 

        #endregion Private Variables

        #region Properties


        public IEnumerator GetEnumerator()
        {
            return new RXTaskEnum(this.m_tasks);
        }
        /// <summary>
        /// 
        /// </summary>
        public Task this[Int32 index]
        {
            get
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Task]";
                try
                {
                    this.m_task = (Task)this.m_tasks[index];
                    return this.m_task;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return new Task(this.m_sit_id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Task[] Items
        {
            get
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Task]";
                try
                {
                    return this.m_tasks;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return new Task[0];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task GetTask(Int32 Id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetTask]";
            try
            {
                foreach (Task t in this.m_tasks)
                {
                    if (t.Id == Id)
                    {
                        return t;
                    }
                }
                return new Task(this.m_sit_id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Task(this.m_sit_id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>true | false</returns>
        public bool Contains(Int32 Id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            try
            {
                foreach (Task t in this.m_tasks)
                {
                    if (t.Id == Id)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool Contains(String Name)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            try
            {
                foreach (Task t in this.m_tasks)
                {
                    if (t.Name.ToLower() == Name.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        public bool Refresh
        {
            get
            {
                return this.m_refresh;
            }
            set
            {
                this.m_refresh = value;
            }
        }


        #endregion Properties

        #region Constructors

        public TaskCollection(Int32 SitId, bool AutoUpdate, String Datasource, String ConnectionString) : this(SitId, AutoUpdate, Datasource, ConnectionString, true)
        {
        }

        public TaskCollection(Int32 SitId, bool AutoUpdate, String Datasource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = Datasource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh;
            GetAll();
        }

        ~TaskCollection()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            if (!this.Refresh)
                ResetThis();
            if (RXServer.Data.ActivateGC)
                GC.Collect();
        }
        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="page"></param>
        public void Add(Task task)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            try
            {
                this.Add(ref task);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void Add(ref Task task)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            try
            {
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("INSERT INTO tas_tasks (sit_id, lng_id, tas_parentid, tas_order, ");
                sSQL.Append("tas_title, tas_alias, tas_description, tas_theme, tas_skin, tas_createddate, ");
                sSQL.Append("tas_createdby, tas_updateddate, tas_updatedby, ");
                sSQL.Append("tas_hidden, tas_deleted) VALUES (");
                sSQL.Append(task.SiteId.ToString() + ", ");
                sSQL.Append(task.Language.ToString() + ", ");
                sSQL.Append(task.ParentId.ToString() + ", ");
                sSQL.Append(task.Order.ToString() + ", ");
                sSQL.Append("'" + task.Name + "', ");
                sSQL.Append("'" + task.Alias + "', ");
                sSQL.Append("'" + task.Description + "', ");
                sSQL.Append("'" + task.Theme + "', ");
                sSQL.Append("'" + task.Skin + "', ");
                sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                sSQL.Append("0, ");
                sSQL.Append("0)");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                {
                    oDo.ExecuteNonQuery(sSQL.ToString());
                    task.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                }

                foreach (Int32 r in task.AuthorizedEditRoles)
                {
                    sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO atr_authorizedtasksroles (tas_id, rol_id, atr_createddate, atr_createdby, atr_updateddate, atr_updatedby, atr_hidden, atr_deleted) VALUES ( ");
                    sSQL.Append(task.Id.ToString() + ", ");
                    sSQL.Append(r.ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());
                }

                foreach (Int32 g in task.AuthorizedEditGroups)
                {
                    sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO atg_authorizedtasksgroups (pag_id, grp_id, atg_createddate, atg_createdby, atg_updateddate, atg_updatedby, atg_hidden, atg_deleted) VALUES ( ");
                    sSQL.Append(task.Id.ToString() + ", ");
                    sSQL.Append(g.ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());
                }
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_COLLECTION);

                SortAll();
                GetAll();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        public void Remove(Task task)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            try
            {
                this.Remove(task.Id);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(Int32 id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            try
            {
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("UPDATE tas_tasks SET tas_deleted = 1 ");
                sSQL.Append("WHERE tas_id = " + id.ToString());
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                    oDo.ExecuteNonQuery(sSQL.ToString());
                SortAll();
                GetAll();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// Clear
        /// </summary>
        public void Clear()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Clear]";
            try
            {
                this.m_tasks = null;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int32 Count()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Count]";
            try
            {
                return this.m_tasks.Length;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return 0;
            }
        }

        public DataTable DataTable()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            try
            {
                return m_dttasks;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new DataTable();
            }
        }

        public DataTable DataTable(TaskSortField SortField, SortOrder SortOrder)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            try
            {
                DataView v = new DataView(m_dttasks);
                v.Sort = RetriveSortField(SortField) + Convert.ToString((Int32)SortOrder == 1 ? String.Empty : " DESC");
                return v.ToTable();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new DataTable();
            }
        }


        #endregion Public Methods

        #region Private Methods

        private void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_COLLECTION);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_ROLES);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_GROUPS);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private String RetriveSortField(TaskSortField SortField)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::RetriveSortField]";
            try
            {

                if ((Int32)SortField == 1) return "tas_id";
                if ((Int32)SortField == 2) return "sit_id";
                if ((Int32)SortField == 3) return "lng_id";
                if ((Int32)SortField == 4) return "tas_order";
                if ((Int32)SortField == 5) return "tas_parentid";
                if ((Int32)SortField == 6) return "tas_title";
                if ((Int32)SortField == 7) return "tas_alias";
                if ((Int32)SortField == 8) return "tas_description";
                if ((Int32)SortField == 9) return "tas_theme";
                if ((Int32)SortField == 10) return "tas_skin";
                if ((Int32)SortField == 11) return "tas_createddate";
                if ((Int32)SortField == 12) return "tas_createdby";
                if ((Int32)SortField == 13) return "tas_updateddate";
                if ((Int32)SortField == 14) return "tas_updatedby";
                return String.Empty;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return String.Empty;
            }
        }
        private void GetAll()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAll]";
            DataTable dt = null;
            if (!this.Refresh)
                return;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_TASK_COLLECTION + "::SitId" + this.m_sit_id.ToString();
                if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM tas_tasks WHERE sit_id = " + this.m_sit_id.ToString() + " AND tas_deleted = 0 ORDER BY tas_order");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    this.m_dttasks = dt;
                    Int32 index = 0;
                    this.m_tasks = new Task[dt.Rows.Count];
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.m_tasks[index] = new Task(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
                        this.m_tasks[index].Id = Convert.ToInt32(dr["tas_id"]);
                        this.m_tasks[index].SiteId = Convert.ToInt32(dr["sit_id"]);
                        this.m_tasks[index].Language = Convert.ToInt32(dr["lng_id"]);
                        this.m_tasks[index].ParentId = Convert.ToInt32(dr["tas_parentid"]);
                        this.m_tasks[index].Order = Convert.ToInt32(dr["tas_order"]);
                        this.m_tasks[index].Name = Convert.ToString(dr["tas_title"]);
                        this.m_tasks[index].Alias = Convert.ToString(dr["tas_alias"]);
                        this.m_tasks[index].Description = Convert.ToString(dr["tas_description"]);
                        this.m_tasks[index].AuthorizedEditRoles = this.GetAuthorizedEditRoles(Convert.ToInt32(dr["tas_id"]));
                        this.m_tasks[index].AuthorizedEditGroups = this.GetAuthorizedEditGroups(Convert.ToInt32(dr["tas_id"]));
                        this.m_tasks[index].Theme = Convert.ToString(dr["tas_theme"]);
                        this.m_tasks[index].Skin = Convert.ToString(dr["tas_skin"]);
                        this.m_tasks[index].CreatedDate = Convert.ToDateTime(dr["tas_createddate"]);
                        this.m_tasks[index].CreatedBy = Convert.ToString(dr["tas_createdby"]);
                        this.m_tasks[index].UpdatedDate = Convert.ToDateTime(dr["tas_updateddate"]);
                        this.m_tasks[index].UpdatedBy = Convert.ToString(dr["tas_updatedby"]);
                        this.m_tasks[index].Hidden = Convert.ToBoolean(dr["tas_hidden"]);
                        this.m_tasks[index].Deleted = Convert.ToBoolean(dr["tas_deleted"]);
                        this.m_tasks[index].Exist = true;
                        index++;
                    }
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
            if (!this.Refresh)
                return;
            try
            {
                Int32 Order = (Int32)OrderMinMax.Min;
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("SELECT * FROM tas_tasks WHERE tas_deleted = 0 ORDER BY sit_id, pag_id, tas_order");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                {
                    DataTable dt = oDo.GetDataTable(sSQL.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE tas_tasks SET tas_order = " + Order.ToString() + " WHERE tas_id = " + dr["tas_id"].ToString());
                        using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
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
        private Int32[] GetAuthorizedEditRoles(Int32 TasId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditRoles]";
            Int32[] Roles;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_TASK_ROLES + "::TasId" + TasId.ToString();
                if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM atr_authorizedstasksroles WHERE tas_id = " + TasId.ToString() + " AND atr_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Roles = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Roles[i] = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                return Roles;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Int32[] GetAuthorizedEditGroups(Int32 TasId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditGroups]";
            Int32[] Groups;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_TASK_GROUPS + TasId.ToString();
                if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM atg_authorizedtasksgroups WHERE tas_id = " + TasId.ToString() + " AND atg_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                }
                Groups = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Groups[i] = Convert.ToInt32(dt.Rows[i]["grp_id"]);
                return Groups;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }

        #endregion Private Methods

    }
    #endregion public class TaskCollection

    #region public class Task

    public class Task : IDisposable
    {
        string CLASSNAME = "[Namespace::RXServer][Class::Task]";

        #region DataHandler Variables

        private string m_datasource;
        private string m_connectionstring;

        #endregion DataHandler Variables

        #region Private Variables

        private bool m_exists = false;
        private bool m_autoupdate = false;

        private Int32 m_tas_id = 0;
        private Int32 m_sit_id = 0;
        private Int32 m_lng_id = 0;
        private Int32 m_tas_order = 0;
        private Int32 m_tas_parentid = 0;
        private Int32[] m_tas_parents = new Int32[0];
        private String m_tas_name = String.Empty;
        private String m_tas_alias = String.Empty;
        private String m_tas_theme = String.Empty;
        private String m_tas_skin = String.Empty;
        private String m_tas_description = String.Empty;
        private Int32[] m_tas_authorizededitroles = new Int32[0];
        private Int32[] m_tas_authorizededitgroups = new Int32[0];
        private DateTime m_tas_createddate = DateTime.Now;
        private String m_tas_createdby = String.Empty;
        private DateTime m_tas_updateddate = DateTime.Now;
        private String m_tas_updatedby = String.Empty;
        private bool m_tas_hidden = false;
        private bool m_tas_deleted = false;

        private bool m_tas_haschildren = false;
        private bool m_tas_hasparent = false;

        #endregion Private Variables

        #region Properties

        public bool AutoUpdate
        {
            set
            {
                this.m_autoupdate = value;
            }
        }
        public bool Exist
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
        public bool HasChildren
        {
            get
            {
                this.m_tas_haschildren = this.FindChildren();
                return this.m_tas_haschildren;
            }
        }
        public bool HasParent
        {
            get
            {
                this.m_tas_hasparent = this.m_tas_parentid == 0 ? false : true;
                return this.m_tas_hasparent;
            }
        }
        public Int32 SiteId
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
        public Int32 Id
        {
            get
            {
                return this.m_tas_id;
            }
            set
            {
                this.m_tas_id = value;
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
                PropertyUpdate("lng_id", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public Int32 Order
        {
            get
            {
                return this.m_tas_order;
            }
            set
            {
                this.m_tas_order = value;
                PropertyUpdate("tas_order", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public Int32 ParentId
        {
            get
            {
                return this.m_tas_parentid;
            }
            set
            {
                this.m_tas_parentid = value;
                PropertyUpdate("tas_parentid", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public Int32[] Parents
        {
            get
            {
                GetParents();
                return this.m_tas_parents;
            }
        }
        public string Name
        {
            get
            {
                return this.m_tas_name;
            }
            set
            {
                this.m_tas_name = Common.SafeString(value);
                PropertyUpdate("tas_name", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Alias
        {
            get
            {
                return this.m_tas_alias;
            }
            set
            {
                this.m_tas_alias = Common.SafeString(value);
                PropertyUpdate("tas_alias", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Theme
        {
            get
            {
                return this.m_tas_theme;
            }
            set
            {
                this.m_tas_theme = Common.SafeString(value);
                PropertyUpdate("tas_theme", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Skin
        {
            get
            {
                return this.m_tas_skin;
            }
            set
            {
                this.m_tas_skin = Common.SafeString(value);
                PropertyUpdate("tas_skin", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Description
        {
            get
            {
                return this.m_tas_description;
            }
            set
            {
                this.m_tas_description = Common.SafeString(value);
                PropertyUpdate("tas_description", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public Int32[] AuthorizedEditRoles
        {
            get
            {
                return this.m_tas_authorizededitroles;
            }
            set
            {
                this.m_tas_authorizededitroles = value;
                PropertyUpdate("rol_id", value, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
            }
        }
        public Int32[] AuthorizedEditGroups
        {
            get
            {
                return this.m_tas_authorizededitgroups;
            }
            set
            {
                this.m_tas_authorizededitgroups = value;
                PropertyUpdate("grp_id", value, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return this.m_tas_createddate;
            }
            set
            {
                this.m_tas_createddate = value;
            }
        }
        public string CreatedBy
        {
            get
            {
                return this.m_tas_createdby;
            }
            set
            {
                this.m_tas_createdby = Common.SafeString(value);
            }
        }
        public DateTime UpdatedDate
        {
            get
            {
                return this.m_tas_updateddate;
            }
            set
            {
                this.m_tas_updateddate = value;
            }
        }
        public string UpdatedBy
        {
            get
            {
                return this.m_tas_updatedby;
            }
            set
            {
                this.m_tas_updatedby = Common.SafeString(value);
            }
        }
        public bool Hidden
        {
            get
            {
                return this.m_tas_hidden;
            }
            set
            {
                this.m_tas_hidden = value;
                PropertyUpdate("tas_hidden", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public bool Deleted
        {
            get
            {
                return this.m_tas_deleted;
            }
            set
            {
                this.m_tas_deleted = value;
                PropertyUpdate("tas_deleted", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SitId"></param>
        /// <param name="PagId"></param>
        /// <param name="AutoUpdate"></param>
        public Task(Int32 SitId, Int32 TasId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_tas_id = TasId;
            this.GetById();
            this.m_autoupdate = AutoUpdate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SitId"></param>
        /// <param name="PagId"></param>
        public Task(Int32 SitId, Int32 TasId, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_tas_id = TasId;
            this.GetById();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SitId"></param>
        /// <param name="AutoUpdate"></param>
        public Task(Int32 SitId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_autoupdate = AutoUpdate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AutoUpdate"></param>
        public Task(bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
        }

        /// <summary>
        /// 
        /// </summary>
        public Task(String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
        }

        ~Task()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            if (RXServer.Data.ActivateGC)
                GC.Collect();
        }
        #endregion Constructors

        #region Public Methods

        public void Update()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Update]";
            try
            {
                if (this.m_exists)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("UPDATE tas_tasks SET ");
                    sSQL.Append("sit_id = " + this.m_sit_id.ToString() + ", ");
                    sSQL.Append("lng_id = " + this.m_lng_id.ToString() + ", ");
                    sSQL.Append("tas_parentid = " + this.m_tas_parentid.ToString() + ", ");
                    sSQL.Append("tas_order = " + this.m_tas_order.ToString() + ", ");
                    sSQL.Append("tas_title = '" + this.m_tas_name.ToString() + "', ");
                    sSQL.Append("tas_alias = '" + this.m_tas_alias.ToString() + "', ");
                    sSQL.Append("tas_theme = '" + this.m_tas_theme.ToString() + "', ");
                    sSQL.Append("tas_skin = '" + this.m_tas_skin.ToString() + "', ");
                    sSQL.Append("tas_description = '" + this.m_tas_description.ToString() + "', ");
                    sSQL.Append("tas_createddate = '" + this.m_tas_createddate.ToString() + "', ");
                    sSQL.Append("tas_createdby = '" + this.m_tas_createdby.ToString() + "', ");
                    sSQL.Append("tas_updateddate = '" + this.m_tas_updateddate.ToString() + "', ");
                    sSQL.Append("tas_updatedby = '" + this.m_tas_updatedby.ToString() + "', ");
                    sSQL.Append("tas_hidden = " + Convert.ToString(!this.m_tas_hidden ? "0" : "1") + ", ");
                    sSQL.Append("tas_deleted = " + Convert.ToString(!this.m_tas_deleted ? "0" : "1") + " ");
                    sSQL.Append("WHERE tas_id = " + m_tas_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());

                    ResetThis();

                    this.PropertyUpdate("rol_id", this.m_tas_authorizededitroles, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
                    this.PropertyUpdate("grp_id", this.m_tas_authorizededitgroups, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);

                    if (this.m_tas_deleted)
                        DeleteRelations();
                }
                else
                {
                    throw new Exception("Can´t update a task that not exists");
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void ChangeOrderUp()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderUp]";
            try
            {
                this.m_tas_order = this.m_tas_order + 3;
                StringBuilder sSQL2 = new StringBuilder();
                sSQL2.Append("UPDATE tas_tasks SET tas_order = " + this.m_tas_order.ToString() + " WHERE tas_id = " + this.m_tas_id.ToString());
                using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    oDo2.ExecuteNonQuery(sSQL2.ToString());
                SortAll();
                GetById();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void ChangeOrderDown()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderDown]";
            try
            {
                if (this.m_tas_order > 2)
                {
                    this.m_tas_order = this.m_tas_order - 3;
                    StringBuilder sSQL2 = new StringBuilder();
                    sSQL2.Append("UPDATE tas_tasks SET tas_order = " + this.m_tas_order.ToString() + " WHERE tas_id = " + this.m_tas_id.ToString());
                    using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                        oDo2.ExecuteNonQuery(sSQL2.ToString());
                    SortAll();
                    GetById();
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_COLLECTION);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_ROLES);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_GROUPS);
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
                sSQL.Append("SELECT * FROM tas_tasks WHERE tas_deleted = 0 ORDER BY sit_id, pag_id, tas_order");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                {
                    DataTable dt = oDo.GetDataTable(sSQL.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE tas_tasks SET tas_order = " + Order.ToString() + " WHERE tas_id = " + dr["tas_id"].ToString());
                        using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
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
        private void PropertyUpdate(string Column, object Value, PropertyUpdateType Type, PropertyUpdateTableType Table)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::PropertyUpdate]";
            try
            {
                if ((this.m_exists) && (this.m_autoupdate))
                {
                    StringBuilder sSQL = new StringBuilder();
                    if (Table == PropertyUpdateTableType.Standard)
                    {
                        sSQL.Append("UPDATE tas_tasks SET ");
                        switch (Type)
                        {
                            case PropertyUpdateType.String: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                            case PropertyUpdateType.Int32: sSQL.Append(Column + " = " + Value.ToString() + " ");
                                break;
                            case PropertyUpdateType.Boolean: sSQL.Append(Column + " = " + Convert.ToInt32(Value).ToString() + " ");
                                break;
                            case PropertyUpdateType.DateTime: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                            default: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                        }
                        sSQL.Append("WHERE tas_id = " + m_tas_id.ToString());
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());
                        ResetThis();
                        if (this.m_tas_deleted)
                            DeleteRelations();
                    }
                    else
                    {
                        switch (Column.ToLower())
                        {
                            case "rol_id":
                                {
                                    sSQL = new StringBuilder();
                                    sSQL.Append("UPDATE atr_authorizedtasksroles SET atr_deleted = 1 WHERE tas_id = " + this.m_tas_id.ToString());
                                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                        oDo.ExecuteNonQuery(sSQL.ToString());

                                    foreach (Int32 r in (Int32[])Value)
                                    {

                                        sSQL = new StringBuilder();
                                        sSQL.Append("INSERT INTO atr_authorizedtasksroles (tas_id, rol_id, atr_createddate, atr_createdby, atr_updateddate, atr_updatedby, atr_hidden, atr_deleted) VALUES ( ");
                                        sSQL.Append(this.m_tas_id.ToString() + ", ");
                                        sSQL.Append(r.ToString() + ", ");
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("0, ");
                                        sSQL.Append("0)");
                                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                            oDo.ExecuteNonQuery(sSQL.ToString());
                                    }
                                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_ROLES + m_tas_id.ToString());
                                    break;
                                }
                            case "grp_id":
                                {
                                    sSQL = new StringBuilder();
                                    sSQL.Append("UPDATE atg_authorizedtasksgroups SET atg_deleted = 1 WHERE tas_id = " + this.m_tas_id.ToString());
                                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                        oDo.ExecuteNonQuery(sSQL.ToString());

                                    foreach (Int32 g in (Int32[])Value)
                                    {

                                        sSQL = new StringBuilder();
                                        sSQL.Append("INSERT INTO atg_authorizedtasksgroups (tas_id, grp_id, atg_createddate, atg_createdby, atg_updateddate, atg_updatedby, atg_hidden, atg_deleted) VALUES ( ");
                                        sSQL.Append(this.m_tas_id.ToString() + ", ");
                                        sSQL.Append(g.ToString() + ", ");
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("0, ");
                                        sSQL.Append("0)");
                                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                            oDo.ExecuteNonQuery(sSQL.ToString());
                                    }
                                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_TASK_GROUPS + m_tas_id.ToString());
                                    break;
                                }
                            default:
                                {

                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetById()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetById]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_TASK_ID + "::TasId" + m_tas_id.ToString();
                if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM tas_tasks WHERE tas_id = " + m_tas_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.m_sit_id = Convert.ToInt32(dr["sit_id"]);
                    this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                    this.m_tas_parentid = Convert.ToInt32(dr["tas_parentid"]);
                    this.m_tas_order = Convert.ToInt32(dr["tas_order"]);
                    this.m_tas_name = Convert.ToString(dr["tas_title"]);
                    this.m_tas_alias = Convert.ToString(dr["tas_alias"]);
                    this.m_tas_description = Convert.ToString(dr["tas_description"]);
                    this.m_tas_authorizededitroles = this.GetAuthorizedEditRoles(Convert.ToInt32(dr["tas_id"]));
                    this.m_tas_authorizededitgroups = this.GetAuthorizedEditGroups(Convert.ToInt32(dr["tas_id"]));
                    this.m_tas_theme = Convert.ToString(dr["tas_theme"]);
                    this.m_tas_skin = Convert.ToString(dr["tas_skin"]);
                    this.m_tas_createddate = Convert.ToDateTime(dr["tas_createddate"]);
                    this.m_tas_createdby = Convert.ToString(dr["tas_createdby"]);
                    this.m_tas_updateddate = Convert.ToDateTime(dr["tas_updateddate"]);
                    this.m_tas_updatedby = Convert.ToString(dr["tas_updatedby"]);
                    this.m_tas_hidden = Convert.ToBoolean(dr["tas_hidden"]);
                    this.m_tas_deleted = Convert.ToBoolean(dr["tas_deleted"]);
                    this.m_exists = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetParents()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetParents]";
            Int32[] Parents = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_TASK_ID + "::TasId" + m_tas_id.ToString() + "::Parents";
                if (HttpContext.Current != null) if (HttpContext.Current != null) Parents = (Int32[])HttpContext.Current.Cache[CacheItem];
                if (Parents == null)
                {
                    if (this.ParentId > 0)
                    {
                        Parents = new Int32[1];
                        Parents[0] = this.ParentId;
                        Parents = Generic.GrowArray(GetNextParent(Parents, this.ParentId), 0);
                        RXServer.Data.CacheInsert(CacheItem, Parents);
                    }
                }
                this.m_tas_parents = Parents;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private Int32[] GetNextParent(Int32[] Parents, Int32 TasId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetNextParent]";
            try
            {
                Task t = new Task(this.SiteId, TasId, Data.DataSource, Data.ConnectionString);
                if (t.ParentId > 0)
                {
                    Parents = Generic.GrowArray(Parents, Parents.Length + 1);
                    Parents[Parents.Length - 1] = t.ParentId;
                    Parents = GetNextParent(Parents, t.ParentId);
                }
                return Parents;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return Parents;
            }
        }
        private Int32[] GetAuthorizedEditRoles(Int32 TasId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditRoles]";
            Int32[] Roles;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_TASK_ROLES + "::TasId" + m_tas_id.ToString();
                if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM atr_authorizedstasksroles WHERE tas_id = " + TasId.ToString() + " AND atr_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Roles = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Roles[i] = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                return Roles;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Int32[] GetAuthorizedEditGroups(Int32 TasId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditGroups]";
            Int32[] Groups;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_TASK_GROUPS + m_tas_id.ToString();
                if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM atg_authorizedtasksgroups WHERE tas_id = " + TasId.ToString() + " AND atg_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                }
                Groups = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Groups[i] = Convert.ToInt32(dt.Rows[i]["grp_id"]);
                return Groups;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Boolean FindChildren()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::FindChildren]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_TASK_ID + "::TasId" + m_tas_id.ToString() + "::Children";
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT tas_id FROM tas_tasks WHERE tas_parentid = " + m_tas_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }
        private void DeleteRelations()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DeleteRelations]";
            try
            {
                // Delete SiteCollection... 
                // not in use for Tasks...

                // Delete PageCollection...
                // not in use for Tasks...

                // Delete TaskCollection...
                // not in use for Tasks...

                // Delete ModuleCollection... 
                // not in use for Tasks...

                // Delete DocumentCollection...
                // not in use for Tasks...

                // Delete ObjectCollection...
                // not in use for Tasks...
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        #endregion Private Methods

    }
    #endregion public class Task

    #region public class ObjectCollection

    /// <summary>
    /// 
    /// </summary>
    public class ObjectCollection : IDisposable, IEnumerable
    {
        string CLASSNAME = "[Namespace::RXServer][Class::ObjectCollection]";

        #region DataHandler Variables

        private string m_datasource;
        private string m_connectionstring;

        #endregion DataHandler Variables

        #region Private Variables

        private Object m_object;
        private Object[] m_objects = new Object[0];
        private ObjectType m_objecttype = ObjectType.Undefined;
        private Int32 m_sit_id = 0;
        private Int32 m_pag_id = 0;
        private Int32 m_mod_id = 0;
        private Int32 m_obd_parentid = 0;
        private String m_obd_alias = String.Empty;
        private bool m_autoupdate = false;
        private DataTable m_dtobjects;
        private Boolean m_refresh; 

        #endregion Private Variables

        #region Properties


        public IEnumerator GetEnumerator()
        {
            return new RXObjectEnum(this.m_objects);
        }
        /// <summary>
        /// 
        /// </summary>
        public Object this[Int32 index]
        {
            get
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Object]";
                try
                {
                    this.m_object = (Object)this.m_objects[index];
                    return this.m_object;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return new Object(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Object[] Items
        {
            get
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Object]";
                try
                {
                    return this.m_objects;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return new Object[0];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Object GetObject(Int32 Id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetObject]";
            try
            {
                foreach (Object o in this.m_objects)
                {
                    if (o.Id == Id)
                    {
                        return o;
                    }
                }
                return new Object(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Object(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public Object GetObject(string Alias)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetObject]";
            try
            {
                foreach (Object o in this.m_objects)
                {
                    if (o.Alias.ToLower() == Alias.ToLower())
                    {
                        return o;
                    }
                }
                return new Object(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Object(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Contains(Int32 Id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            try
            {
                foreach (Object o in this.m_objects)
                {
                    if (o.Id == Id)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public bool Contains(string Alias)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            try
            {
                foreach (Object o in this.m_objects)
                {
                    if (o.Alias.ToLower() == Alias.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        public bool Refresh
        {
            get
            {
                return this.m_refresh;
            }
            set
            {
                this.m_refresh = value;
            }
        }


        #endregion Properties

        #region Constructors

        public ObjectCollection() { }

        // Standard...
        public ObjectCollection(bool AutoUpdate, String DataSource, String ConnectionString) : this(AutoUpdate, DataSource, ConnectionString, true)
        { 
        }
        public ObjectCollection(Int32 SitId, bool AutoUpdate, String DataSource, String ConnectionString) : this(SitId, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public ObjectCollection(Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString) : this(SitId, PagId, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public ObjectCollection(ObjectType ObjectType, bool AutoUpdate, String DataSource, String ConnectionString) : this(ObjectType, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public ObjectCollection(ObjectType ObjectType, Int32 SitId, bool AutoUpdate, String DataSource, String ConnectionString) : this(ObjectType, SitId, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        /// <summary>
        /// This method will be removed in next version of RXServer.
        /// </summary>
        public ObjectCollection(ObjectType ObjectType, Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString) : this(ObjectType, SitId, PagId, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        // skapa denna senare...
        //public ObjectCollection(ObjectType ObjectType, Int32 SitId, Int32 ParentId, bool AutoUpdate, String DataSource, String ConnectionString)
        //{
        //    new ObjectCollection(ObjectType, SitId, ParentId, AutoUpdate, DataSource, ConnectionString, true); 
        //}
        public ObjectCollection(Int32 SitId, Int32 PagId, Int32 ParentId, bool AutoUpdate, String DataSource, String ConnectionString) : this(SitId, PagId, ParentId, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public ObjectCollection(ObjectType ObjectType, Int32 SitId, Int32 PagId, Int32 ParentId, bool AutoUpdate, String DataSource, String ConnectionString) : this(ObjectType, SitId, PagId, ParentId, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public ObjectCollection(Int32 SitId, Int32 PagId, String Alias, bool AutoUpdate, String DataSource, String ConnectionString) : this(SitId, PagId, Alias, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public ObjectCollection(ObjectType ObjectType, Int32 SitId, Int32 PagId, String Alias, bool AutoUpdate, String DataSource, String ConnectionString) : this(ObjectType, SitId, PagId, Alias, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public ObjectCollection(Int32 SitId, Int32 PagId, Int32 ModId, String Alias, bool AutoUpdate, String DataSource, String ConnectionString) : this(SitId, PagId, ModId, Alias, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public ObjectCollection(ObjectType ObjectType, Int32 SitId, Int32 PagId, Int32 ModId, String Alias, bool AutoUpdate, String DataSource, String ConnectionString) : this(ObjectType, SitId, PagId, ModId, Alias, AutoUpdate, DataSource, ConnectionString, true)
        {
        }

        // Overrides...
        public ObjectCollection(bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public ObjectCollection(Int32 SitId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public ObjectCollection(Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public ObjectCollection(ObjectType ObjectType, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
            this.m_objecttype = ObjectType;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public ObjectCollection(ObjectType ObjectType, Int32 SitId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_autoupdate = AutoUpdate;
            this.m_objecttype = ObjectType;
            this.m_refresh = Refresh; 
            GetAll();
        }
        /// <summary>
        /// This method will be removed in next version of RXServer.
        /// </summary>
        public ObjectCollection(ObjectType ObjectType, Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_autoupdate = AutoUpdate;
            this.m_objecttype = ObjectType;
            this.m_refresh = Refresh; 
            GetAll();
        }
        // skapa denna senare...
        //public ObjectCollection(ObjectType ObjectType, Int32 SitId, Int32 ParentId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        //{
        //    this.m_datasource = DataSource;
        //    this.m_connectionstring = ConnectionString;
        //    this.m_sit_id = SitId;
        //    this.m_pag_id = PagId;
        //    this.m_autoupdate = AutoUpdate;
        //    this.m_objecttype = ObjectType;
        //    this.m_refresh = Refresh; 
        //    GetAll();
        //}
        public ObjectCollection(Int32 SitId, Int32 PagId, Int32 ParentId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_obd_parentid = ParentId;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public ObjectCollection(ObjectType ObjectType, Int32 SitId, Int32 PagId, Int32 ParentId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_obd_parentid = ParentId;
            this.m_autoupdate = AutoUpdate;
            this.m_objecttype = ObjectType;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public ObjectCollection(Int32 SitId, Int32 PagId, String Alias, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_obd_alias = Alias;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public ObjectCollection(ObjectType ObjectType, Int32 SitId, Int32 PagId, String Alias, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_obd_alias = Alias;
            this.m_autoupdate = AutoUpdate;
            this.m_objecttype = ObjectType;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public ObjectCollection(Int32 SitId, Int32 PagId, Int32 ModId, String Alias, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_mod_id = ModId;
            this.m_obd_alias = Alias;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public ObjectCollection(ObjectType ObjectType, Int32 SitId, Int32 PagId, Int32 ModId, String Alias, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_mod_id = ModId;
            this.m_obd_alias = Alias;
            this.m_autoupdate = AutoUpdate;
            this.m_objecttype = ObjectType;
            this.m_refresh = Refresh; 
            GetAll();
        }

        ~ObjectCollection()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            if (!this.Refresh)
                ResetThis();
            if (RXServer.Data.ActivateGC)
                GC.Collect();
        }
        #endregion Constructors

        #region Public Methods

        public void Add(Object Object)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            try
            {
                this.Add(ref Object);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void Add(ref Object Object)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            try
            {
                DataSet ds = new DataSet();
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("INSERT INTO obd_objectdata (lng_id, obd_parentid, sit_id, pag_id, mod_id, obd_order, obd_type, obd_title, obd_alias, obd_description, obd_varchar1, obd_varchar2, obd_varchar3, obd_varchar4, obd_varchar5, obd_varchar6, obd_varchar7, obd_varchar8, obd_varchar9, obd_varchar10, obd_varchar11, obd_varchar12, obd_varchar13, obd_varchar14, obd_varchar15, obd_varchar16, obd_varchar17, obd_varchar18, obd_varchar19, obd_varchar20, obd_varchar21, obd_varchar22, obd_varchar23, obd_varchar24, obd_varchar25, obd_varchar26, obd_varchar27, obd_varchar28, obd_varchar29, obd_varchar30, obd_varchar31, obd_varchar32, obd_varchar33, obd_varchar34, obd_varchar35, obd_varchar36, obd_varchar37, obd_varchar38, obd_varchar39, obd_varchar40, obd_varchar41, obd_varchar42, obd_varchar43, obd_varchar44, obd_varchar45, obd_varchar46, obd_varchar47, obd_varchar48, obd_varchar49, obd_varchar50, obd_createddate, obd_createdby, obd_updateddate, obd_updatedby, obd_hidden, obd_deleted) VALUES ( ");
                sSQL.Append(Object.Language.ToString() + ", ");
                sSQL.Append(Object.ParentId.ToString() + ", ");
                sSQL.Append(Object.SitId.ToString() + ", ");
                sSQL.Append(Object.PagId.ToString() + ", ");
                sSQL.Append(Object.ModId.ToString() + ", ");
                sSQL.Append(Convert.ToString((Int32)OrderMinMax.Max) + ", ");
                sSQL.Append(Convert.ToString((Int32)Object.ObjectType) + ", ");
                sSQL.Append("'" + Object.Name + "', ");
                sSQL.Append("'" + Object.Alias + "', ");
                sSQL.Append("'" + Object.Description + "', ");
                sSQL.Append("'" + Object.Field1 + "', ");
                sSQL.Append("'" + Object.Field2 + "', ");
                sSQL.Append("'" + Object.Field3 + "', ");
                sSQL.Append("'" + Object.Field4 + "', ");
                sSQL.Append("'" + Object.Field5 + "', ");
                sSQL.Append("'" + Object.Field6 + "', ");
                sSQL.Append("'" + Object.Field7 + "', ");
                sSQL.Append("'" + Object.Field8 + "', ");
                sSQL.Append("'" + Object.Field9 + "', ");
                sSQL.Append("'" + Object.Field10 + "', ");
                sSQL.Append("'" + Object.Field11 + "', ");
                sSQL.Append("'" + Object.Field12 + "', ");
                sSQL.Append("'" + Object.Field13 + "', ");
                sSQL.Append("'" + Object.Field14 + "', ");
                sSQL.Append("'" + Object.Field15 + "', ");
                sSQL.Append("'" + Object.Field16 + "', ");
                sSQL.Append("'" + Object.Field17 + "', ");
                sSQL.Append("'" + Object.Field18 + "', ");
                sSQL.Append("'" + Object.Field19 + "', ");
                sSQL.Append("'" + Object.Field20 + "', ");
                sSQL.Append("'" + Object.Field21 + "', ");
                sSQL.Append("'" + Object.Field22 + "', ");
                sSQL.Append("'" + Object.Field23 + "', ");
                sSQL.Append("'" + Object.Field24 + "', ");
                sSQL.Append("'" + Object.Field25 + "', ");
                sSQL.Append("'" + Object.Field26 + "', ");
                sSQL.Append("'" + Object.Field27 + "', ");
                sSQL.Append("'" + Object.Field28 + "', ");
                sSQL.Append("'" + Object.Field29 + "', ");
                sSQL.Append("'" + Object.Field30 + "', ");
                sSQL.Append("'" + Object.Field31 + "', ");
                sSQL.Append("'" + Object.Field32 + "', ");
                sSQL.Append("'" + Object.Field33 + "', ");
                sSQL.Append("'" + Object.Field34 + "', ");
                sSQL.Append("'" + Object.Field35 + "', ");
                sSQL.Append("'" + Object.Field36 + "', ");
                sSQL.Append("'" + Object.Field37 + "', ");
                sSQL.Append("'" + Object.Field38 + "', ");
                sSQL.Append("'" + Object.Field39 + "', ");
                sSQL.Append("'" + Object.Field40 + "', ");
                sSQL.Append("'" + Object.Field41 + "', ");
                sSQL.Append("'" + Object.Field42 + "', ");
                sSQL.Append("'" + Object.Field43 + "', ");
                sSQL.Append("'" + Object.Field44 + "', ");
                sSQL.Append("'" + Object.Field45 + "', ");
                sSQL.Append("'" + Object.Field46 + "', ");
                sSQL.Append("'" + Object.Field47 + "', ");
                sSQL.Append("'" + Object.Field48 + "', ");
                sSQL.Append("'" + Object.Field49 + "', ");
                sSQL.Append("'" + Object.Field50 + "', ");
                sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                sSQL.Append("0, ");
                sSQL.Append("0)");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                {
                    Int32 ret = oDo.ExecuteNonQuery(sSQL.ToString());
                    Object.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                }
                SortAll();
                GetAll();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void Remove(Object Object)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            try
            {
                this.Remove(Object.Id);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void Remove(Int32 Id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            try
            {
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("UPDATE obd_objectdata SET obd_deleted = 1 ");
                sSQL.Append("WHERE obd_id = " + Id.ToString());
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                    oDo.ExecuteNonQuery(sSQL.ToString());
                SortAll();
                GetAll();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void Clear()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Clear]";
            try
            {
                this.m_objects = null;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public Int32 Count()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Count]";
            try
            {
                return this.m_objects.Length;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return 0;
            }
        }
        public DataTable DataTable()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            try
            {
                return this.m_dtobjects;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new DataTable();
            }
        }
        public DataTable DataTable(ObjectSortField SortField, SortOrder SortOrder)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            try
            {
                DataView v = new DataView(m_dtobjects);
                v.Sort = RetriveSortField(SortField) + Convert.ToString((Int32)SortOrder == 1 ? String.Empty : " DESC");
                return v.ToTable();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new DataTable();
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_COLLECTION);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private String RetriveSortField(ObjectSortField SortField)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::RetriveSortField]";
            try
            {

                if ((Int32)SortField == 1) return "obd_id";
                if ((Int32)SortField == 2) return "lng_id";
                if ((Int32)SortField == 3) return "obd_parentid";
                if ((Int32)SortField == 4) return "sit_id";
                if ((Int32)SortField == 5) return "pag_id";
                if ((Int32)SortField == 64) return "mod_id";
                if ((Int32)SortField == 6) return "obd_order";
                if ((Int32)SortField == 7) return "obd_title";
                if ((Int32)SortField == 8) return "obd_alias";
                if ((Int32)SortField == 9) return "obd_description";
                if ((Int32)SortField == 10) return "obd_varchar1";
                if ((Int32)SortField == 11) return "obd_varchar2";
                if ((Int32)SortField == 12) return "obd_varchar3";
                if ((Int32)SortField == 13) return "obd_varchar4";
                if ((Int32)SortField == 14) return "obd_varchar5";
                if ((Int32)SortField == 15) return "obd_varchar6";
                if ((Int32)SortField == 16) return "obd_varchar7";
                if ((Int32)SortField == 17) return "obd_varchar8";
                if ((Int32)SortField == 18) return "obd_varchar9";
                if ((Int32)SortField == 19) return "obd_varchar10";
                if ((Int32)SortField == 20) return "obd_varchar11";
                if ((Int32)SortField == 21) return "obd_varchar12";
                if ((Int32)SortField == 22) return "obd_varchar13";
                if ((Int32)SortField == 23) return "obd_varchar14";
                if ((Int32)SortField == 24) return "obd_varchar15";
                if ((Int32)SortField == 25) return "obd_varchar16";
                if ((Int32)SortField == 26) return "obd_varchar17";
                if ((Int32)SortField == 27) return "obd_varchar18";
                if ((Int32)SortField == 28) return "obd_varchar19";
                if ((Int32)SortField == 29) return "obd_varchar20";
                if ((Int32)SortField == 30) return "obd_varchar21";
                if ((Int32)SortField == 31) return "obd_varchar22";
                if ((Int32)SortField == 32) return "obd_varchar23";
                if ((Int32)SortField == 33) return "obd_varchar24";
                if ((Int32)SortField == 34) return "obd_varchar25";
                if ((Int32)SortField == 35) return "obd_varchar26";
                if ((Int32)SortField == 36) return "obd_varchar27";
                if ((Int32)SortField == 37) return "obd_varchar28";
                if ((Int32)SortField == 38) return "obd_varchar29";
                if ((Int32)SortField == 39) return "obd_varchar30";
                if ((Int32)SortField == 40) return "obd_varchar31";
                if ((Int32)SortField == 41) return "obd_varchar32";
                if ((Int32)SortField == 42) return "obd_varchar33";
                if ((Int32)SortField == 43) return "obd_varchar34";
                if ((Int32)SortField == 44) return "obd_varchar35";
                if ((Int32)SortField == 45) return "obd_varchar36";
                if ((Int32)SortField == 46) return "obd_varchar37";
                if ((Int32)SortField == 47) return "obd_varchar38";
                if ((Int32)SortField == 48) return "obd_varchar39";
                if ((Int32)SortField == 49) return "obd_varchar40";
                if ((Int32)SortField == 50) return "obd_varchar41";
                if ((Int32)SortField == 51) return "obd_varchar42";
                if ((Int32)SortField == 52) return "obd_varchar43";
                if ((Int32)SortField == 53) return "obd_varchar44";
                if ((Int32)SortField == 54) return "obd_varchar45";
                if ((Int32)SortField == 55) return "obd_varchar46";
                if ((Int32)SortField == 56) return "obd_varchar47";
                if ((Int32)SortField == 57) return "obd_varchar48";
                if ((Int32)SortField == 58) return "obd_varchar49";
                if ((Int32)SortField == 59) return "obd_varchar50";
                if ((Int32)SortField == 60) return "obd_createddate";
                if ((Int32)SortField == 61) return "obd_createdby";
                if ((Int32)SortField == 62) return "obd_updateddate";
                if ((Int32)SortField == 63) return "obd_updatedby";
                return String.Empty;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return String.Empty;
            }
        }
        private void SortAll()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::SortAll]";
            if (!this.Refresh)
                return;
            try
            {
                Int32 Order = (Int32)OrderMinMax.Min;
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("SELECT * FROM obd_objectdata WHERE obd_deleted = 0 ORDER BY sit_id, pag_id, obd_order");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                {
                    DataTable dt = oDo.GetDataTable(sSQL.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE obd_objectdata SET obd_order = " + Order.ToString() + " WHERE obd_id = " + dr["obd_id"].ToString());
                        using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                            oDo2.ExecuteNonQuery(sSQL2.ToString());
                        Order = Order + (Int32)OrderMinMax.Step;
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_ID + dr["obd_id"].ToString());
                        RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_ID + dr["obd_alias"].ToString());
                    }
                    ResetThis();
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetAll()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAll]";
            DataTable dt = null;
            if (!this.Refresh)
                return;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_OBJECT_COLLECTION +
                    "::SitId" + this.m_sit_id.ToString() +
                    "::PagId" + this.m_pag_id.ToString() +
                    "::ModId" + this.m_mod_id.ToString() +
                    "::ObdAlias" + this.m_obd_alias.ToString() +
                    "::ObdParentId" + this.m_obd_parentid.ToString() +
                    "::ObdType" + Convert.ToString((Int32)this.m_objecttype);
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    if (this.m_sit_id > 0 && this.m_pag_id > 0 && this.m_mod_id > 0 && this.m_obd_parentid > 0)
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND mod_id = " + this.m_mod_id.ToString() + " AND obd_parentid = " + this.m_obd_parentid.ToString() + Convert.ToString(this.m_objecttype != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_objecttype) : String.Empty) + " AND obd_deleted = 0 ORDER BY obd_order");
                    else if (this.m_sit_id > 0 && this.m_pag_id > 0 && this.m_mod_id > 0)
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND mod_id = " + this.m_mod_id.ToString() + " AND obd_parentid = " + this.m_obd_parentid.ToString() + Convert.ToString(this.m_objecttype != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_objecttype) : String.Empty) + " AND obd_deleted = 0 ORDER BY obd_order");
                    else if (this.m_sit_id > 0 && this.m_pag_id > 0 && this.m_obd_parentid > 0)
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND obd_parentid = " + this.m_obd_parentid.ToString() + Convert.ToString(this.m_objecttype != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_objecttype) : String.Empty) + " AND obd_deleted = 0 ORDER BY obd_order");
                    else if (this.m_sit_id > 0 && this.m_pag_id > 0 && this.m_obd_alias.Length > 0)
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND obd_alias = '" + this.m_obd_alias.ToString() + "' " + Convert.ToString(this.m_objecttype != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_objecttype) : String.Empty) + " AND obd_deleted = 0 ORDER BY obd_order");
                    else if (this.m_sit_id > 0 && this.m_pag_id > 0)
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + Convert.ToString(this.m_objecttype != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_objecttype) : String.Empty) + " AND obd_deleted = 0 ORDER BY obd_order");
                    else if (this.m_sit_id > 0 && this.m_pag_id == 0 && this.m_obd_parentid > 0)
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_id = 0 AND obd_parentid = " + this.m_obd_parentid.ToString() + Convert.ToString(this.m_objecttype != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_objecttype) : String.Empty) + " AND obd_deleted = 0 ORDER BY obd_order");
                    else if (this.m_sit_id > 0 && this.m_pag_id == 0)
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + Convert.ToString(this.m_objecttype != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_objecttype) : String.Empty) + " AND obd_deleted = 0 ORDER BY obd_order");
                    else
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE obd_deleted = 0" + Convert.ToString(this.m_objecttype != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_objecttype) : String.Empty) + " ORDER BY obd_order");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    this.m_dtobjects = dt;
                    Int32 index = 0;
                    this.m_objects = new Object[dt.Rows.Count];
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.m_objects[index] = new Object(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
                        this.m_objects[index].Id = Convert.ToInt32(dr["obd_id"]);
                        this.m_objects[index].Language = Convert.ToInt32(dr["lng_id"]);
                        this.m_objects[index].ParentId = Convert.ToInt32(dr["obd_parentid"]);
                        this.m_objects[index].Order = Convert.ToInt32(dr["obd_order"]);
                        this.m_objects[index].ObjectType = (ObjectType)Convert.ToInt32(dr["obd_type"]);
                        this.m_objects[index].Name = Convert.ToString(dr["obd_title"]);
                        this.m_objects[index].Alias = Convert.ToString(dr["obd_alias"]);
                        this.m_objects[index].Description = Convert.ToString(dr["obd_description"]);
                        this.m_objects[index].Field1 = Convert.ToString(dr["obd_varchar1"]);
                        this.m_objects[index].Field2 = Convert.ToString(dr["obd_varchar2"]);
                        this.m_objects[index].Field3 = Convert.ToString(dr["obd_varchar3"]);
                        this.m_objects[index].Field4 = Convert.ToString(dr["obd_varchar4"]);
                        this.m_objects[index].Field5 = Convert.ToString(dr["obd_varchar5"]);
                        this.m_objects[index].Field6 = Convert.ToString(dr["obd_varchar6"]);
                        this.m_objects[index].Field7 = Convert.ToString(dr["obd_varchar7"]);
                        this.m_objects[index].Field8 = Convert.ToString(dr["obd_varchar8"]);
                        this.m_objects[index].Field9 = Convert.ToString(dr["obd_varchar9"]);
                        this.m_objects[index].Field10 = Convert.ToString(dr["obd_varchar10"]);
                        this.m_objects[index].Field11 = Convert.ToString(dr["obd_varchar11"]);
                        this.m_objects[index].Field12 = Convert.ToString(dr["obd_varchar12"]);
                        this.m_objects[index].Field13 = Convert.ToString(dr["obd_varchar13"]);
                        this.m_objects[index].Field14 = Convert.ToString(dr["obd_varchar14"]);
                        this.m_objects[index].Field15 = Convert.ToString(dr["obd_varchar15"]);
                        this.m_objects[index].Field16 = Convert.ToString(dr["obd_varchar16"]);
                        this.m_objects[index].Field17 = Convert.ToString(dr["obd_varchar17"]);
                        this.m_objects[index].Field18 = Convert.ToString(dr["obd_varchar18"]);
                        this.m_objects[index].Field19 = Convert.ToString(dr["obd_varchar19"]);
                        this.m_objects[index].Field20 = Convert.ToString(dr["obd_varchar20"]);
                        this.m_objects[index].Field21 = Convert.ToString(dr["obd_varchar21"]);
                        this.m_objects[index].Field22 = Convert.ToString(dr["obd_varchar22"]);
                        this.m_objects[index].Field23 = Convert.ToString(dr["obd_varchar23"]);
                        this.m_objects[index].Field24 = Convert.ToString(dr["obd_varchar24"]);
                        this.m_objects[index].Field25 = Convert.ToString(dr["obd_varchar25"]);
                        this.m_objects[index].Field26 = Convert.ToString(dr["obd_varchar26"]);
                        this.m_objects[index].Field27 = Convert.ToString(dr["obd_varchar27"]);
                        this.m_objects[index].Field28 = Convert.ToString(dr["obd_varchar28"]);
                        this.m_objects[index].Field29 = Convert.ToString(dr["obd_varchar29"]);
                        this.m_objects[index].Field30 = Convert.ToString(dr["obd_varchar30"]);
                        this.m_objects[index].Field31 = Convert.ToString(dr["obd_varchar31"]);
                        this.m_objects[index].Field32 = Convert.ToString(dr["obd_varchar32"]);
                        this.m_objects[index].Field33 = Convert.ToString(dr["obd_varchar33"]);
                        this.m_objects[index].Field34 = Convert.ToString(dr["obd_varchar34"]);
                        this.m_objects[index].Field35 = Convert.ToString(dr["obd_varchar35"]);
                        this.m_objects[index].Field36 = Convert.ToString(dr["obd_varchar36"]);
                        this.m_objects[index].Field37 = Convert.ToString(dr["obd_varchar37"]);
                        this.m_objects[index].Field38 = Convert.ToString(dr["obd_varchar38"]);
                        this.m_objects[index].Field39 = Convert.ToString(dr["obd_varchar39"]);
                        this.m_objects[index].Field40 = Convert.ToString(dr["obd_varchar40"]);
                        this.m_objects[index].Field41 = Convert.ToString(dr["obd_varchar41"]);
                        this.m_objects[index].Field42 = Convert.ToString(dr["obd_varchar42"]);
                        this.m_objects[index].Field43 = Convert.ToString(dr["obd_varchar43"]);
                        this.m_objects[index].Field44 = Convert.ToString(dr["obd_varchar44"]);
                        this.m_objects[index].Field45 = Convert.ToString(dr["obd_varchar45"]);
                        this.m_objects[index].Field46 = Convert.ToString(dr["obd_varchar46"]);
                        this.m_objects[index].Field47 = Convert.ToString(dr["obd_varchar47"]);
                        this.m_objects[index].Field48 = Convert.ToString(dr["obd_varchar48"]);
                        this.m_objects[index].Field49 = Convert.ToString(dr["obd_varchar49"]);
                        this.m_objects[index].Field50 = Convert.ToString(dr["obd_varchar50"]);
                        this.m_objects[index].CreatedDate = Convert.ToDateTime(dr["obd_createddate"]);
                        this.m_objects[index].CreatedBy = Convert.ToString(dr["obd_createdby"]);
                        this.m_objects[index].UpdatedDate = Convert.ToDateTime(dr["obd_updateddate"]);
                        this.m_objects[index].UpdatedBy = Convert.ToString(dr["obd_updatedby"]);
                        this.m_objects[index].Hidden = Convert.ToBoolean(dr["obd_hidden"]);
                        this.m_objects[index].Deleted = Convert.ToBoolean(dr["obd_deleted"]);
                        this.m_objects[index].Exist = true;
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        #endregion Private Methods

    }
    #endregion public class ObjectCollection

    #region public class Object

    [Serializable]
    public class Object : IDisposable
    {
        string CLASSNAME = "[Namespace::RXServer][Class::Object]";

        #region DataHandler Variables

        private String m_datasource;
        private String m_connectionstring;

        #endregion DataHandler Variables

        #region Private Variables

        private bool m_exists = false;
        private bool m_autoupdate = false;
        private bool m_refresh = true;

        private Int32 m_obd_id = 0;
        private Int32 m_lng_id = 0;
        private Int32 m_obd_parentid = 0;
        private Int32[] m_obd_parents = new Int32[0];
        private Int32 m_sit_id = 0;
        private Int32 m_pag_id = 0;
        private Int32 m_mod_id = 0;
        private Int32 m_obd_order = 0;
        private ObjectType m_obd_type = ObjectType.Undefined;
        private String m_obd_title = String.Empty;
        private String m_obd_alias = String.Empty;
        private String m_obd_description = String.Empty;

        private String m_obd_field1 = String.Empty;
        private String m_obd_field2 = String.Empty;
        private String m_obd_field3 = String.Empty;
        private String m_obd_field4 = String.Empty;
        private String m_obd_field5 = String.Empty;
        private String m_obd_field6 = String.Empty;
        private String m_obd_field7 = String.Empty;
        private String m_obd_field8 = String.Empty;
        private String m_obd_field9 = String.Empty;
        private String m_obd_field10 = String.Empty;
        private String m_obd_field11 = String.Empty;
        private String m_obd_field12 = String.Empty;
        private String m_obd_field13 = String.Empty;
        private String m_obd_field14 = String.Empty;
        private String m_obd_field15 = String.Empty;
        private String m_obd_field16 = String.Empty;
        private String m_obd_field17 = String.Empty;
        private String m_obd_field18 = String.Empty;
        private String m_obd_field19 = String.Empty;
        private String m_obd_field20 = String.Empty;
        private String m_obd_field21 = String.Empty;
        private String m_obd_field22 = String.Empty;
        private String m_obd_field23 = String.Empty;
        private String m_obd_field24 = String.Empty;
        private String m_obd_field25 = String.Empty;
        private String m_obd_field26 = String.Empty;
        private String m_obd_field27 = String.Empty;
        private String m_obd_field28 = String.Empty;
        private String m_obd_field29 = String.Empty;
        private String m_obd_field30 = String.Empty;
        private String m_obd_field31 = String.Empty;
        private String m_obd_field32 = String.Empty;
        private String m_obd_field33 = String.Empty;
        private String m_obd_field34 = String.Empty;
        private String m_obd_field35 = String.Empty;
        private String m_obd_field36 = String.Empty;
        private String m_obd_field37 = String.Empty;
        private String m_obd_field38 = String.Empty;
        private String m_obd_field39 = String.Empty;
        private String m_obd_field40 = String.Empty;
        private String m_obd_field41 = String.Empty;
        private String m_obd_field42 = String.Empty;
        private String m_obd_field43 = String.Empty;
        private String m_obd_field44 = String.Empty;
        private String m_obd_field45 = String.Empty;
        private String m_obd_field46 = String.Empty;
        private String m_obd_field47 = String.Empty;
        private String m_obd_field48 = String.Empty;
        private String m_obd_field49 = String.Empty;
        private String m_obd_field50 = String.Empty;


        private DateTime m_obd_createddate = DateTime.Now;
        private String m_obd_createdby = String.Empty;
        private DateTime m_obd_updateddate = DateTime.Now;
        private String m_obd_updatedby = String.Empty;
        private bool m_obd_hidden = false;
        private bool m_obd_deleted = false;

        private bool m_obd_haschildren = false;
        private bool m_obd_hasparent = false;

        #endregion Private Variables

        #region Properties

        public bool AutoUpdate
        {
            set
            {
                this.m_autoupdate = value;
            }
        }
        public bool Exist
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
        public bool HasChildren
        {
            get
            {
                this.m_obd_haschildren = this.FindChildren();
                return this.m_obd_haschildren;
            }
        }
        public bool HasParent
        {
            get
            {
                this.m_obd_hasparent = this.m_obd_parentid == 0 ? false : true;
                return this.m_obd_hasparent;
            }
        }
        public int Id
        {
            get
            {
                return this.m_obd_id;
            }
            set
            {
                this.m_obd_id = value;
            }
        }
        public ObjectType ObjectType
        {
            get
            {
                return this.m_obd_type;
            }
            set
            {
                this.m_obd_type = value;
            }
        }
        public int ParentId
        {
            get
            {
                return this.m_obd_parentid;
            }
            set
            {
                this.m_obd_parentid = value;
            }
        }
        public Int32[] Parents
        {
            get
            {
                GetParents();
                return this.m_obd_parents;
            }
        }
        public int SitId
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
        public int PagId
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
        public int ModId
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
        public int Language
        {
            get
            {
                return this.m_lng_id;
            }
            set
            {
                this.m_lng_id = value;
                PropertyUpdate("lng_id", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public int Order
        {
            get
            {
                return this.m_obd_order;
            }
            set
            {
                this.m_obd_order = value;
                PropertyUpdate("obd_order", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public string Alias
        {
            get
            {
                return this.m_obd_alias;
            }
            set
            {
                this.m_obd_alias = Common.SafeString(value);
                PropertyUpdate("obd_alias", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Name
        {
            get
            {
                return this.m_obd_title;
            }
            set
            {
                this.m_obd_title = Common.SafeString(value);
                PropertyUpdate("obd_title", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Description
        {
            get
            {
                return this.m_obd_description;
            }
            set
            {
                this.m_obd_description = Common.SafeString(value);
                PropertyUpdate("obd_description", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field1
        {
            get
            {
                return this.m_obd_field1;
            }
            set
            {
                this.m_obd_field1 = Common.SafeString(value);
                PropertyUpdate("obd_field1", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field2
        {
            get
            {
                return this.m_obd_field2;
            }
            set
            {
                this.m_obd_field2 = Common.SafeString(value);
                PropertyUpdate("obd_field2", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field3
        {
            get
            {
                return this.m_obd_field3;
            }
            set
            {
                this.m_obd_field3 = Common.SafeString(value);
                PropertyUpdate("obd_field3", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field4
        {
            get
            {
                return this.m_obd_field4;
            }
            set
            {
                this.m_obd_field4 = Common.SafeString(value);
                PropertyUpdate("obd_field4", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field5
        {
            get
            {
                return this.m_obd_field5;
            }
            set
            {
                this.m_obd_field5 = Common.SafeString(value);
                PropertyUpdate("obd_field5", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field6
        {
            get
            {
                return this.m_obd_field6;
            }
            set
            {
                this.m_obd_field6 = Common.SafeString(value);
                PropertyUpdate("obd_field6", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field7
        {
            get
            {
                return this.m_obd_field7;
            }
            set
            {
                this.m_obd_field7 = Common.SafeString(value);
                PropertyUpdate("obd_field7", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field8
        {
            get
            {
                return this.m_obd_field8;
            }
            set
            {
                this.m_obd_field8 = Common.SafeString(value);
                PropertyUpdate("obd_field8", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field9
        {
            get
            {
                return this.m_obd_field9;
            }
            set
            {
                this.m_obd_field9 = Common.SafeString(value);
                PropertyUpdate("obd_field9", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field10
        {
            get
            {
                return this.m_obd_field10;
            }
            set
            {
                this.m_obd_field10 = Common.SafeString(value);
                PropertyUpdate("obd_field10", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field11
        {
            get
            {
                return this.m_obd_field11;
            }
            set
            {
                this.m_obd_field11 = Common.SafeString(value);
                PropertyUpdate("obd_field11", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field12
        {
            get
            {
                return this.m_obd_field12;
            }
            set
            {
                this.m_obd_field12 = Common.SafeString(value);
                PropertyUpdate("obd_field12", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field13
        {
            get
            {
                return this.m_obd_field13;
            }
            set
            {
                this.m_obd_field13 = Common.SafeString(value);
                PropertyUpdate("obd_field13", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field14
        {
            get
            {
                return this.m_obd_field14;
            }
            set
            {
                this.m_obd_field14 = Common.SafeString(value);
                PropertyUpdate("obd_field14", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field15
        {
            get
            {
                return this.m_obd_field15;
            }
            set
            {
                this.m_obd_field15 = Common.SafeString(value);
                PropertyUpdate("obd_field15", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field16
        {
            get
            {
                return this.m_obd_field16;
            }
            set
            {
                this.m_obd_field16 = Common.SafeString(value);
                PropertyUpdate("obd_field16", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field17
        {
            get
            {
                return this.m_obd_field17;
            }
            set
            {
                this.m_obd_field17 = Common.SafeString(value);
                PropertyUpdate("obd_field17", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field18
        {
            get
            {
                return this.m_obd_field18;
            }
            set
            {
                this.m_obd_field18 = Common.SafeString(value);
                PropertyUpdate("obd_field18", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field19
        {
            get
            {
                return this.m_obd_field19;
            }
            set
            {
                this.m_obd_field19 = Common.SafeString(value);
                PropertyUpdate("obd_field19", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field20
        {
            get
            {
                return this.m_obd_field20;
            }
            set
            {
                this.m_obd_field20 = Common.SafeString(value);
                PropertyUpdate("obd_field20", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field21
        {
            get
            {
                return this.m_obd_field21;
            }
            set
            {
                this.m_obd_field21 = Common.SafeString(value);
                PropertyUpdate("obd_field21", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field22
        {
            get
            {
                return this.m_obd_field22;
            }
            set
            {
                this.m_obd_field22 = Common.SafeString(value);
                PropertyUpdate("obd_field22", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field23
        {
            get
            {
                return this.m_obd_field23;
            }
            set
            {
                this.m_obd_field23 = Common.SafeString(value);
                PropertyUpdate("obd_field23", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field24
        {
            get
            {
                return this.m_obd_field24;
            }
            set
            {
                this.m_obd_field24 = Common.SafeString(value);
                PropertyUpdate("obd_field24", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field25
        {
            get
            {
                return this.m_obd_field25;
            }
            set
            {
                this.m_obd_field25 = Common.SafeString(value);
                PropertyUpdate("obd_field25", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field26
        {
            get
            {
                return this.m_obd_field26;
            }
            set
            {
                this.m_obd_field26 = Common.SafeString(value);
                PropertyUpdate("obd_field26", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field27
        {
            get
            {
                return this.m_obd_field27;
            }
            set
            {
                this.m_obd_field27 = Common.SafeString(value);
                PropertyUpdate("obd_field27", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field28
        {
            get
            {
                return this.m_obd_field28;
            }
            set
            {
                this.m_obd_field28 = Common.SafeString(value);
                PropertyUpdate("obd_field28", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field29
        {
            get
            {
                return this.m_obd_field29;
            }
            set
            {
                this.m_obd_field29 = Common.SafeString(value);
                PropertyUpdate("obd_field29", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field30
        {
            get
            {
                return this.m_obd_field30;
            }
            set
            {
                this.m_obd_field30 = Common.SafeString(value);
                PropertyUpdate("obd_field30", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field31
        {
            get
            {
                return this.m_obd_field31;
            }
            set
            {
                this.m_obd_field31 = Common.SafeString(value);
                PropertyUpdate("obd_field31", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field32
        {
            get
            {
                return this.m_obd_field32;
            }
            set
            {
                this.m_obd_field32 = Common.SafeString(value);
                PropertyUpdate("obd_field32", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field33
        {
            get
            {
                return this.m_obd_field33;
            }
            set
            {
                this.m_obd_field33 = Common.SafeString(value);
                PropertyUpdate("obd_field33", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field34
        {
            get
            {
                return this.m_obd_field34;
            }
            set
            {
                this.m_obd_field34 = Common.SafeString(value);
                PropertyUpdate("obd_field34", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field35
        {
            get
            {
                return this.m_obd_field35;
            }
            set
            {
                this.m_obd_field35 = Common.SafeString(value);
                PropertyUpdate("obd_field35", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field36
        {
            get
            {
                return this.m_obd_field36;
            }
            set
            {
                this.m_obd_field36 = Common.SafeString(value);
                PropertyUpdate("obd_field36", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field37
        {
            get
            {
                return this.m_obd_field37;
            }
            set
            {
                this.m_obd_field37 = Common.SafeString(value);
                PropertyUpdate("obd_field37", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field38
        {
            get
            {
                return this.m_obd_field38;
            }
            set
            {
                this.m_obd_field38 = Common.SafeString(value);
                PropertyUpdate("obd_field38", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field39
        {
            get
            {
                return this.m_obd_field39;
            }
            set
            {
                this.m_obd_field39 = Common.SafeString(value);
                PropertyUpdate("obd_field39", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field40
        {
            get
            {
                return this.m_obd_field40;
            }
            set
            {
                this.m_obd_field40 = Common.SafeString(value);
                PropertyUpdate("obd_field40", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field41
        {
            get
            {
                return this.m_obd_field41;
            }
            set
            {
                this.m_obd_field41 = Common.SafeString(value);
                PropertyUpdate("obd_field41", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field42
        {
            get
            {
                return this.m_obd_field42;
            }
            set
            {
                this.m_obd_field42 = Common.SafeString(value);
                PropertyUpdate("obd_field42", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field43
        {
            get
            {
                return this.m_obd_field43;
            }
            set
            {
                this.m_obd_field43 = Common.SafeString(value);
                PropertyUpdate("obd_field43", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field44
        {
            get
            {
                return this.m_obd_field44;
            }
            set
            {
                this.m_obd_field44 = Common.SafeString(value);
                PropertyUpdate("obd_field44", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field45
        {
            get
            {
                return this.m_obd_field45;
            }
            set
            {
                this.m_obd_field45 = Common.SafeString(value);
                PropertyUpdate("obd_field45", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field46
        {
            get
            {
                return this.m_obd_field46;
            }
            set
            {
                this.m_obd_field46 = Common.SafeString(value);
                PropertyUpdate("obd_field46", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field47
        {
            get
            {
                return this.m_obd_field47;
            }
            set
            {
                this.m_obd_field47 = Common.SafeString(value);
                PropertyUpdate("obd_field47", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field48
        {
            get
            {
                return this.m_obd_field48;
            }
            set
            {
                this.m_obd_field48 = Common.SafeString(value);
                PropertyUpdate("obd_field48", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field49
        {
            get
            {
                return this.m_obd_field49;
            }
            set
            {
                this.m_obd_field49 = Common.SafeString(value);
                PropertyUpdate("obd_field49", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Field50
        {
            get
            {
                return this.m_obd_field50;
            }
            set
            {
                this.m_obd_field50 = Common.SafeString(value);
                PropertyUpdate("obd_field50", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return this.m_obd_createddate;
            }
            set
            {
                this.m_obd_createddate = value;
            }
        }
        public string CreatedBy
        {
            get
            {
                return this.m_obd_createdby;
            }
            set
            {
                this.m_obd_createdby = Common.SafeString(value);
            }
        }
        public DateTime UpdatedDate
        {
            get
            {
                return this.m_obd_updateddate;
            }
            set
            {
                this.m_obd_updateddate = value;
            }
        }
        public string UpdatedBy
        {
            get
            {
                return this.m_obd_updatedby;
            }
            set
            {
                this.m_obd_updatedby = Common.SafeString(value);
            }
        }
        public bool Hidden
        {
            get
            {
                return this.m_obd_hidden;
            }
            set
            {
                this.m_obd_hidden = value;
                PropertyUpdate("obd_hidden", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public bool Deleted
        {
            get
            {
                return this.m_obd_deleted;
            }
            set
            {
                this.m_obd_deleted = value;
                PropertyUpdate("obd_deleted", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public bool Refresh
        {
            get
            {
                return this.m_refresh;
            }
            set
            {
                this.m_refresh = value;
            }
        }

        #endregion Properties

        #region Constructors

        public Object() { }
        public Object(string Alias, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.GetByAlias();
            this.m_autoupdate = AutoUpdate;
        }
        public Object(Int32 Id, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_id = Id;
            this.GetById();
            this.m_autoupdate = AutoUpdate;
        }
        public Object(bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
        }
        public Object(string Alias, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.GetByAlias();
        }
        public Object(Int32 Id, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_id = Id;
            this.GetById();
        }
        public Object(String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
        }

        public Object(Int32 SitId, string Alias, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.m_sit_id = SitId;
            this.GetByAlias();
            this.m_autoupdate = AutoUpdate;
        }
        public Object(Int32 SitId, string Alias, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.m_sit_id = SitId;
            this.GetByAlias();
        }

        public Object(Int32 SitId, Int32 PagId, string Alias, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.GetByAlias();
            this.m_autoupdate = AutoUpdate;
        }
        public Object(Int32 SitId, Int32 PagId, string Alias, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.GetByAlias();
        }
        public Object(Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_id = Id;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.GetById();
            this.m_autoupdate = AutoUpdate;
        }
        public Object(Int32 SitId, Int32 PagId, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_id = Id;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.GetById();
        }


        public Object(ObjectType ObjectType, string Alias, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.m_obd_type = ObjectType;
            this.GetByAlias();
            this.m_autoupdate = AutoUpdate;
        }
        public Object(ObjectType ObjectType, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
            this.m_obd_type = ObjectType;
        }
        public Object(ObjectType ObjectType, string Alias, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.m_obd_type = ObjectType;
            this.GetByAlias();
        }
        public Object(ObjectType ObjectType, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_type = ObjectType;
        }

        public Object(ObjectType ObjectType, Int32 SitId, string Alias, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.m_sit_id = SitId;
            this.m_obd_type = ObjectType;
            this.GetByAlias();
            this.m_autoupdate = AutoUpdate;
        }
        public Object(ObjectType ObjectType, Int32 SitId, string Alias, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.m_sit_id = SitId;
            this.m_obd_type = ObjectType;
            this.GetByAlias();
        }

        public Object(ObjectType ObjectType, Int32 SitId, Int32 PagId, string Alias, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_obd_type = ObjectType;
            this.GetByAlias();
            this.m_autoupdate = AutoUpdate;
        }
        public Object(ObjectType ObjectType, Int32 SitId, Int32 PagId, string Alias, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_obd_type = ObjectType;
            this.GetByAlias();
        }
        public Object(ObjectType ObjectType, Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_obd_type = ObjectType;
            this.GetBySitIdPagId();
            this.m_autoupdate = AutoUpdate;
        }
        public Object(ObjectType ObjectType, Int32 SitId, Int32 PagId, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_obd_type = ObjectType;
            this.GetBySitIdPagId();
        }

        public Object(ObjectType ObjectType, Int32 SitId, Int32 PagId, Int32 ModId, string Alias, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_mod_id = ModId;
            this.m_obd_type = ObjectType;
            this.GetByAlias();
            this.m_autoupdate = AutoUpdate;
        }
        public Object(ObjectType ObjectType, Int32 SitId, Int32 PagId, Int32 ModId, string Alias, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_obd_alias = Alias;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_mod_id = ModId;
            this.m_obd_type = ObjectType;
            this.GetByAlias();
        }
        public Object(ObjectType ObjectType, Int32 SitId, Int32 PagId, Int32 ModId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_mod_id = ModId;
            this.m_obd_type = ObjectType;
            this.GetBySitIdPagIdModId();
            this.m_autoupdate = AutoUpdate;
        }
        public Object(ObjectType ObjectType, Int32 SitId, Int32 PagId, Int32 ModId, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_mod_id = ModId;
            this.m_obd_type = ObjectType;
            this.GetBySitIdPagIdModId();
        }
        public Object(Int32 SitId, Int32 PagId, Int32 ModId, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_mod_id = ModId;
            this.GetBySitIdPagIdModId();
        }

        ~Object()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            if (RXServer.Data.ActivateGC)
                GC.Collect();
        }
        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public void Update()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Update]";
            try
            {
                if (this.m_exists)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("UPDATE obd_objectdata SET ");
                    sSQL.Append("obd_id = " + this.m_obd_id.ToString() + ", ");
                    sSQL.Append("lng_id = " + this.m_lng_id.ToString() + ", ");
                    sSQL.Append("obd_parentid = " + this.m_obd_parentid.ToString() + ", ");
                    sSQL.Append("sit_id = " + this.m_sit_id.ToString() + ", ");
                    sSQL.Append("pag_id = " + this.m_pag_id.ToString() + ", ");
                    sSQL.Append("mod_id = " + this.m_mod_id.ToString() + ", ");
                    sSQL.Append("obd_order = " + this.m_obd_order.ToString() + ", ");
                    sSQL.Append("obd_type = " + Convert.ToString((Int32)this.m_obd_type) + ", ");
                    sSQL.Append("obd_title = '" + this.m_obd_title.ToString() + "', ");
                    sSQL.Append("obd_alias = '" + this.m_obd_alias.ToString() + "', ");
                    sSQL.Append("obd_description = '" + this.m_obd_description.ToString() + "', ");
                    sSQL.Append("obd_varchar1 = '" + this.m_obd_field1.ToString() + "', ");
                    sSQL.Append("obd_varchar2 = '" + this.m_obd_field2.ToString() + "', ");
                    sSQL.Append("obd_varchar3 = '" + this.m_obd_field3.ToString() + "', ");
                    sSQL.Append("obd_varchar4 = '" + this.m_obd_field4.ToString() + "', ");
                    sSQL.Append("obd_varchar5 = '" + this.m_obd_field5.ToString() + "', ");
                    sSQL.Append("obd_varchar6 = '" + this.m_obd_field6.ToString() + "', ");
                    sSQL.Append("obd_varchar7 = '" + this.m_obd_field7.ToString() + "', ");
                    sSQL.Append("obd_varchar8 = '" + this.m_obd_field8.ToString() + "', ");
                    sSQL.Append("obd_varchar9 = '" + this.m_obd_field9.ToString() + "', ");
                    sSQL.Append("obd_varchar10 = '" + this.m_obd_field10.ToString() + "', ");
                    sSQL.Append("obd_varchar11 = '" + this.m_obd_field11.ToString() + "', ");
                    sSQL.Append("obd_varchar12 = '" + this.m_obd_field12.ToString() + "', ");
                    sSQL.Append("obd_varchar13 = '" + this.m_obd_field13.ToString() + "', ");
                    sSQL.Append("obd_varchar14 = '" + this.m_obd_field14.ToString() + "', ");
                    sSQL.Append("obd_varchar15 = '" + this.m_obd_field15.ToString() + "', ");
                    sSQL.Append("obd_varchar16 = '" + this.m_obd_field16.ToString() + "', ");
                    sSQL.Append("obd_varchar17 = '" + this.m_obd_field17.ToString() + "', ");
                    sSQL.Append("obd_varchar18 = '" + this.m_obd_field18.ToString() + "', ");
                    sSQL.Append("obd_varchar19 = '" + this.m_obd_field19.ToString() + "', ");
                    sSQL.Append("obd_varchar20 = '" + this.m_obd_field20.ToString() + "', ");
                    sSQL.Append("obd_varchar21 = '" + this.m_obd_field21.ToString() + "', ");
                    sSQL.Append("obd_varchar22 = '" + this.m_obd_field22.ToString() + "', ");
                    sSQL.Append("obd_varchar23 = '" + this.m_obd_field23.ToString() + "', ");
                    sSQL.Append("obd_varchar24 = '" + this.m_obd_field24.ToString() + "', ");
                    sSQL.Append("obd_varchar25 = '" + this.m_obd_field25.ToString() + "', ");
                    sSQL.Append("obd_varchar26 = '" + this.m_obd_field26.ToString() + "', ");
                    sSQL.Append("obd_varchar27 = '" + this.m_obd_field27.ToString() + "', ");
                    sSQL.Append("obd_varchar28 = '" + this.m_obd_field28.ToString() + "', ");
                    sSQL.Append("obd_varchar29 = '" + this.m_obd_field29.ToString() + "', ");
                    sSQL.Append("obd_varchar30 = '" + this.m_obd_field30.ToString() + "', ");
                    sSQL.Append("obd_varchar31 = '" + this.m_obd_field31.ToString() + "', ");
                    sSQL.Append("obd_varchar32 = '" + this.m_obd_field32.ToString() + "', ");
                    sSQL.Append("obd_varchar33 = '" + this.m_obd_field33.ToString() + "', ");
                    sSQL.Append("obd_varchar34 = '" + this.m_obd_field34.ToString() + "', ");
                    sSQL.Append("obd_varchar35 = '" + this.m_obd_field35.ToString() + "', ");
                    sSQL.Append("obd_varchar36 = '" + this.m_obd_field36.ToString() + "', ");
                    sSQL.Append("obd_varchar37 = '" + this.m_obd_field37.ToString() + "', ");
                    sSQL.Append("obd_varchar38 = '" + this.m_obd_field38.ToString() + "', ");
                    sSQL.Append("obd_varchar39 = '" + this.m_obd_field39.ToString() + "', ");
                    sSQL.Append("obd_varchar40 = '" + this.m_obd_field40.ToString() + "', ");
                    sSQL.Append("obd_varchar41 = '" + this.m_obd_field41.ToString() + "', ");
                    sSQL.Append("obd_varchar42 = '" + this.m_obd_field42.ToString() + "', ");
                    sSQL.Append("obd_varchar43 = '" + this.m_obd_field43.ToString() + "', ");
                    sSQL.Append("obd_varchar44 = '" + this.m_obd_field44.ToString() + "', ");
                    sSQL.Append("obd_varchar45 = '" + this.m_obd_field45.ToString() + "', ");
                    sSQL.Append("obd_varchar46 = '" + this.m_obd_field46.ToString() + "', ");
                    sSQL.Append("obd_varchar47 = '" + this.m_obd_field47.ToString() + "', ");
                    sSQL.Append("obd_varchar48 = '" + this.m_obd_field48.ToString() + "', ");
                    sSQL.Append("obd_varchar49 = '" + this.m_obd_field49.ToString() + "', ");
                    sSQL.Append("obd_varchar50 = '" + this.m_obd_field50.ToString() + "', ");
                    sSQL.Append("obd_createddate = '" + this.m_obd_createddate.ToString() + "', ");
                    sSQL.Append("obd_createdby = '" + this.m_obd_createdby.ToString() + "', ");
                    sSQL.Append("obd_updateddate = '" + DateTime.Now.ToString() + "', ");
                    sSQL.Append("obd_updatedby = '" + this.m_obd_updatedby.ToString() + "', ");
                    sSQL.Append("obd_hidden = " + Convert.ToString(!this.m_obd_hidden ? "0" : "1") + ", ");
                    sSQL.Append("obd_deleted = " + Convert.ToString(!this.m_obd_deleted ? "0" : "1") + " ");
                    sSQL.Append("WHERE obd_id = " + m_obd_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());

                    ResetThis();
                    SortAll();

                    if (this.m_obd_deleted)
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
        public virtual void Save()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
            try
            {
                if (!this.m_exists)
                {
                    DataSet ds = new DataSet();
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO obd_objectdata (lng_id, obd_parentid, sit_id, pag_id, mod_id, obd_order, obd_type, obd_title, obd_alias, obd_description, obd_varchar1, obd_varchar2, obd_varchar3, obd_varchar4, obd_varchar5, obd_varchar6, obd_varchar7, obd_varchar8, obd_varchar9, obd_varchar10, obd_varchar11, obd_varchar12, obd_varchar13, obd_varchar14, obd_varchar15, obd_varchar16, obd_varchar17, obd_varchar18, obd_varchar19, obd_varchar20, obd_varchar21, obd_varchar22, obd_varchar23, obd_varchar24, obd_varchar25, obd_varchar26, obd_varchar27, obd_varchar28, obd_varchar29, obd_varchar30, obd_varchar31, obd_varchar32, obd_varchar33, obd_varchar34, obd_varchar35, obd_varchar36, obd_varchar37, obd_varchar38, obd_varchar39, obd_varchar40, obd_varchar41, obd_varchar42, obd_varchar43, obd_varchar44, obd_varchar45, obd_varchar46, obd_varchar47, obd_varchar48, obd_varchar49, obd_varchar50, obd_createddate, obd_createdby, obd_updateddate, obd_updatedby, obd_hidden, obd_deleted) VALUES ( ");
                    sSQL.Append(this.Language.ToString() + ", ");
                    sSQL.Append(this.ParentId.ToString() + ", ");
                    sSQL.Append(this.SitId.ToString() + ", ");
                    sSQL.Append(this.PagId.ToString() + ", ");
                    sSQL.Append(this.ModId.ToString() + ", ");
                    sSQL.Append(Convert.ToString((Int32)OrderMinMax.Max) + ", ");
                    sSQL.Append(Convert.ToString((Int32)this.ObjectType) + ", ");
                    sSQL.Append("'" + this.Name + "', ");
                    sSQL.Append("'" + this.Alias + "', ");
                    sSQL.Append("'" + this.Description + "', ");
                    sSQL.Append("'" + this.Field1 + "', ");
                    sSQL.Append("'" + this.Field2 + "', ");
                    sSQL.Append("'" + this.Field3 + "', ");
                    sSQL.Append("'" + this.Field4 + "', ");
                    sSQL.Append("'" + this.Field5 + "', ");
                    sSQL.Append("'" + this.Field6 + "', ");
                    sSQL.Append("'" + this.Field7 + "', ");
                    sSQL.Append("'" + this.Field8 + "', ");
                    sSQL.Append("'" + this.Field9 + "', ");
                    sSQL.Append("'" + this.Field10 + "', ");
                    sSQL.Append("'" + this.Field11 + "', ");
                    sSQL.Append("'" + this.Field12 + "', ");
                    sSQL.Append("'" + this.Field13 + "', ");
                    sSQL.Append("'" + this.Field14 + "', ");
                    sSQL.Append("'" + this.Field15 + "', ");
                    sSQL.Append("'" + this.Field16 + "', ");
                    sSQL.Append("'" + this.Field17 + "', ");
                    sSQL.Append("'" + this.Field18 + "', ");
                    sSQL.Append("'" + this.Field19 + "', ");
                    sSQL.Append("'" + this.Field20 + "', ");
                    sSQL.Append("'" + this.Field21 + "', ");
                    sSQL.Append("'" + this.Field22 + "', ");
                    sSQL.Append("'" + this.Field23 + "', ");
                    sSQL.Append("'" + this.Field24 + "', ");
                    sSQL.Append("'" + this.Field25 + "', ");
                    sSQL.Append("'" + this.Field26 + "', ");
                    sSQL.Append("'" + this.Field27 + "', ");
                    sSQL.Append("'" + this.Field28 + "', ");
                    sSQL.Append("'" + this.Field29 + "', ");
                    sSQL.Append("'" + this.Field30 + "', ");
                    sSQL.Append("'" + this.Field31 + "', ");
                    sSQL.Append("'" + this.Field32 + "', ");
                    sSQL.Append("'" + this.Field33 + "', ");
                    sSQL.Append("'" + this.Field34 + "', ");
                    sSQL.Append("'" + this.Field35 + "', ");
                    sSQL.Append("'" + this.Field36 + "', ");
                    sSQL.Append("'" + this.Field37 + "', ");
                    sSQL.Append("'" + this.Field38 + "', ");
                    sSQL.Append("'" + this.Field39 + "', ");
                    sSQL.Append("'" + this.Field40 + "', ");
                    sSQL.Append("'" + this.Field41 + "', ");
                    sSQL.Append("'" + this.Field42 + "', ");
                    sSQL.Append("'" + this.Field43 + "', ");
                    sSQL.Append("'" + this.Field44 + "', ");
                    sSQL.Append("'" + this.Field45 + "', ");
                    sSQL.Append("'" + this.Field46 + "', ");
                    sSQL.Append("'" + this.Field47 + "', ");
                    sSQL.Append("'" + this.Field48 + "', ");
                    sSQL.Append("'" + this.Field49 + "', ");
                    sSQL.Append("'" + this.Field50 + "', ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                    {
                        Int32 ret = oDo.ExecuteNonQuery(sSQL.ToString());
                        this.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                    }

                    if (this.m_refresh)
                    {
                        ResetThis();
                        SortAll();
                    }
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

        public void ChangeOrderUp()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderUp]";
            try
            {
                this.m_obd_order = this.m_obd_order + 3;
                StringBuilder sSQL2 = new StringBuilder();
                sSQL2.Append("UPDATE obd_objectdata SET obd_order = " + this.m_obd_order.ToString() + " WHERE obd_id = " + this.m_obd_id.ToString());
                using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    oDo2.ExecuteNonQuery(sSQL2.ToString());
                SortAll();
                GetById();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void ChangeOrderDown()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderDown]";
            try
            {
                if (this.m_obd_order > 2)
                {
                    this.m_obd_order = this.m_obd_order - 3;
                    StringBuilder sSQL2 = new StringBuilder();
                    sSQL2.Append("UPDATE obd_objectdata SET obd_order = " + this.m_obd_order.ToString() + " WHERE obd_id = " + this.m_obd_id.ToString());
                    using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                        oDo2.ExecuteNonQuery(sSQL2.ToString());
                    SortAll();
                    GetById();
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_OBJECT_COLLECTION);
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
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                {
                    DataTable dt = oDo.GetDataTable(sSQL.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE obd_objectdata SET obd_order = " + Order.ToString() + " WHERE obd_id = " + dr["obd_id"].ToString());
                        using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
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
        private void PropertyUpdate(string Column, object Value, PropertyUpdateType Type, PropertyUpdateTableType Table)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::PropertyUpdate]";
            try
            {
                if ((this.m_exists) && (this.m_autoupdate))
                {
                    StringBuilder sSQL = new StringBuilder();
                    if (Table == PropertyUpdateTableType.Standard)
                    {
                        sSQL.Append("UPDATE obd_objectdata SET ");
                        switch (Type)
                        {
                            case PropertyUpdateType.String: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                            case PropertyUpdateType.Int32: sSQL.Append(Column + " = " + Value.ToString() + " ");
                                break;
                            case PropertyUpdateType.Boolean: sSQL.Append(Column + " = " + Convert.ToInt32(Value).ToString() + " ");
                                break;
                            case PropertyUpdateType.DateTime: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                            default: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                        }
                        sSQL.Append("WHERE obd_id = " + m_obd_id.ToString());
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());
                        ResetThis();

                        if (this.m_obd_deleted)
                            DeleteRelations();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetById()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetById]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_OBJECT_ID + "::ObdId" + m_obd_id.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM obd_objectdata WHERE obd_id = " + m_obd_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.m_obd_id = Convert.ToInt32(dr["obd_id"]);
                    this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                    this.m_obd_parentid = Convert.ToInt32(dr["obd_parentid"]);
                    this.m_sit_id = Convert.ToInt32(dr["sit_id"]);
                    this.m_pag_id = Convert.ToInt32(dr["pag_id"]);
                    this.m_mod_id = Convert.ToInt32(dr["mod_id"]);
                    this.m_obd_order = Convert.ToInt32(dr["obd_order"]);
                    this.m_obd_type = (ObjectType)Convert.ToInt32(dr["obd_type"]);
                    this.m_obd_title = Convert.ToString(dr["obd_title"]);
                    this.m_obd_alias = Convert.ToString(dr["obd_alias"]);
                    this.m_obd_description = Convert.ToString(dr["obd_description"]);
                    this.m_obd_field1 = Convert.ToString(dr["obd_varchar1"]);
                    this.m_obd_field2 = Convert.ToString(dr["obd_varchar2"]);
                    this.m_obd_field3 = Convert.ToString(dr["obd_varchar3"]);
                    this.m_obd_field4 = Convert.ToString(dr["obd_varchar4"]);
                    this.m_obd_field5 = Convert.ToString(dr["obd_varchar5"]);
                    this.m_obd_field6 = Convert.ToString(dr["obd_varchar6"]);
                    this.m_obd_field7 = Convert.ToString(dr["obd_varchar7"]);
                    this.m_obd_field8 = Convert.ToString(dr["obd_varchar8"]);
                    this.m_obd_field9 = Convert.ToString(dr["obd_varchar9"]);
                    this.m_obd_field10 = Convert.ToString(dr["obd_varchar10"]);
                    this.m_obd_field11 = Convert.ToString(dr["obd_varchar11"]);
                    this.m_obd_field12 = Convert.ToString(dr["obd_varchar12"]);
                    this.m_obd_field13 = Convert.ToString(dr["obd_varchar13"]);
                    this.m_obd_field14 = Convert.ToString(dr["obd_varchar14"]);
                    this.m_obd_field15 = Convert.ToString(dr["obd_varchar15"]);
                    this.m_obd_field16 = Convert.ToString(dr["obd_varchar16"]);
                    this.m_obd_field17 = Convert.ToString(dr["obd_varchar17"]);
                    this.m_obd_field18 = Convert.ToString(dr["obd_varchar18"]);
                    this.m_obd_field19 = Convert.ToString(dr["obd_varchar19"]);
                    this.m_obd_field20 = Convert.ToString(dr["obd_varchar20"]);
                    this.m_obd_field21 = Convert.ToString(dr["obd_varchar21"]);
                    this.m_obd_field22 = Convert.ToString(dr["obd_varchar22"]);
                    this.m_obd_field23 = Convert.ToString(dr["obd_varchar23"]);
                    this.m_obd_field24 = Convert.ToString(dr["obd_varchar24"]);
                    this.m_obd_field25 = Convert.ToString(dr["obd_varchar25"]);
                    this.m_obd_field26 = Convert.ToString(dr["obd_varchar26"]);
                    this.m_obd_field27 = Convert.ToString(dr["obd_varchar27"]);
                    this.m_obd_field28 = Convert.ToString(dr["obd_varchar28"]);
                    this.m_obd_field29 = Convert.ToString(dr["obd_varchar29"]);
                    this.m_obd_field30 = Convert.ToString(dr["obd_varchar30"]);
                    this.m_obd_field31 = Convert.ToString(dr["obd_varchar31"]);
                    this.m_obd_field32 = Convert.ToString(dr["obd_varchar32"]);
                    this.m_obd_field33 = Convert.ToString(dr["obd_varchar33"]);
                    this.m_obd_field34 = Convert.ToString(dr["obd_varchar34"]);
                    this.m_obd_field35 = Convert.ToString(dr["obd_varchar35"]);
                    this.m_obd_field36 = Convert.ToString(dr["obd_varchar36"]);
                    this.m_obd_field37 = Convert.ToString(dr["obd_varchar37"]);
                    this.m_obd_field38 = Convert.ToString(dr["obd_varchar38"]);
                    this.m_obd_field39 = Convert.ToString(dr["obd_varchar39"]);
                    this.m_obd_field40 = Convert.ToString(dr["obd_varchar40"]);
                    this.m_obd_field41 = Convert.ToString(dr["obd_varchar41"]);
                    this.m_obd_field42 = Convert.ToString(dr["obd_varchar42"]);
                    this.m_obd_field43 = Convert.ToString(dr["obd_varchar43"]);
                    this.m_obd_field44 = Convert.ToString(dr["obd_varchar44"]);
                    this.m_obd_field45 = Convert.ToString(dr["obd_varchar45"]);
                    this.m_obd_field46 = Convert.ToString(dr["obd_varchar46"]);
                    this.m_obd_field47 = Convert.ToString(dr["obd_varchar47"]);
                    this.m_obd_field48 = Convert.ToString(dr["obd_varchar48"]);
                    this.m_obd_field49 = Convert.ToString(dr["obd_varchar49"]);
                    this.m_obd_field50 = Convert.ToString(dr["obd_varchar50"]);
                    this.m_obd_createddate = Convert.ToDateTime(dr["obd_createddate"]);
                    this.m_obd_createdby = Convert.ToString(dr["obd_createdby"]);
                    this.m_obd_updateddate = Convert.ToDateTime(dr["obd_updateddate"]);
                    this.m_obd_updatedby = Convert.ToString(dr["obd_updatedby"]);
                    this.m_obd_hidden = Convert.ToBoolean(dr["obd_hidden"]);
                    this.m_obd_deleted = Convert.ToBoolean(dr["obd_deleted"]);
                    this.m_exists = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetBySitId()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetBySitId]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_OBJECT_ID + "::SitId" + m_sit_id.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + m_sit_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.m_obd_id = Convert.ToInt32(dr["obd_id"]);
                    this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                    this.m_obd_parentid = Convert.ToInt32(dr["obd_parentid"]);
                    this.m_sit_id = Convert.ToInt32(dr["sit_id"]);
                    this.m_pag_id = Convert.ToInt32(dr["pag_id"]);
                    this.m_mod_id = Convert.ToInt32(dr["mod_id"]);
                    this.m_obd_order = Convert.ToInt32(dr["obd_order"]);
                    this.m_obd_type = (ObjectType)Convert.ToInt32(dr["obd_type"]);
                    this.m_obd_title = Convert.ToString(dr["obd_title"]);
                    this.m_obd_alias = Convert.ToString(dr["obd_alias"]);
                    this.m_obd_description = Convert.ToString(dr["obd_description"]);
                    this.m_obd_field1 = Convert.ToString(dr["obd_varchar1"]);
                    this.m_obd_field2 = Convert.ToString(dr["obd_varchar2"]);
                    this.m_obd_field3 = Convert.ToString(dr["obd_varchar3"]);
                    this.m_obd_field4 = Convert.ToString(dr["obd_varchar4"]);
                    this.m_obd_field5 = Convert.ToString(dr["obd_varchar5"]);
                    this.m_obd_field6 = Convert.ToString(dr["obd_varchar6"]);
                    this.m_obd_field7 = Convert.ToString(dr["obd_varchar7"]);
                    this.m_obd_field8 = Convert.ToString(dr["obd_varchar8"]);
                    this.m_obd_field9 = Convert.ToString(dr["obd_varchar9"]);
                    this.m_obd_field10 = Convert.ToString(dr["obd_varchar10"]);
                    this.m_obd_field11 = Convert.ToString(dr["obd_varchar11"]);
                    this.m_obd_field12 = Convert.ToString(dr["obd_varchar12"]);
                    this.m_obd_field13 = Convert.ToString(dr["obd_varchar13"]);
                    this.m_obd_field14 = Convert.ToString(dr["obd_varchar14"]);
                    this.m_obd_field15 = Convert.ToString(dr["obd_varchar15"]);
                    this.m_obd_field16 = Convert.ToString(dr["obd_varchar16"]);
                    this.m_obd_field17 = Convert.ToString(dr["obd_varchar17"]);
                    this.m_obd_field18 = Convert.ToString(dr["obd_varchar18"]);
                    this.m_obd_field19 = Convert.ToString(dr["obd_varchar19"]);
                    this.m_obd_field20 = Convert.ToString(dr["obd_varchar20"]);
                    this.m_obd_field21 = Convert.ToString(dr["obd_varchar21"]);
                    this.m_obd_field22 = Convert.ToString(dr["obd_varchar22"]);
                    this.m_obd_field23 = Convert.ToString(dr["obd_varchar23"]);
                    this.m_obd_field24 = Convert.ToString(dr["obd_varchar24"]);
                    this.m_obd_field25 = Convert.ToString(dr["obd_varchar25"]);
                    this.m_obd_field26 = Convert.ToString(dr["obd_varchar26"]);
                    this.m_obd_field27 = Convert.ToString(dr["obd_varchar27"]);
                    this.m_obd_field28 = Convert.ToString(dr["obd_varchar28"]);
                    this.m_obd_field29 = Convert.ToString(dr["obd_varchar29"]);
                    this.m_obd_field30 = Convert.ToString(dr["obd_varchar30"]);
                    this.m_obd_field31 = Convert.ToString(dr["obd_varchar31"]);
                    this.m_obd_field32 = Convert.ToString(dr["obd_varchar32"]);
                    this.m_obd_field33 = Convert.ToString(dr["obd_varchar33"]);
                    this.m_obd_field34 = Convert.ToString(dr["obd_varchar34"]);
                    this.m_obd_field35 = Convert.ToString(dr["obd_varchar35"]);
                    this.m_obd_field36 = Convert.ToString(dr["obd_varchar36"]);
                    this.m_obd_field37 = Convert.ToString(dr["obd_varchar37"]);
                    this.m_obd_field38 = Convert.ToString(dr["obd_varchar38"]);
                    this.m_obd_field39 = Convert.ToString(dr["obd_varchar39"]);
                    this.m_obd_field40 = Convert.ToString(dr["obd_varchar40"]);
                    this.m_obd_field41 = Convert.ToString(dr["obd_varchar41"]);
                    this.m_obd_field42 = Convert.ToString(dr["obd_varchar42"]);
                    this.m_obd_field43 = Convert.ToString(dr["obd_varchar43"]);
                    this.m_obd_field44 = Convert.ToString(dr["obd_varchar44"]);
                    this.m_obd_field45 = Convert.ToString(dr["obd_varchar45"]);
                    this.m_obd_field46 = Convert.ToString(dr["obd_varchar46"]);
                    this.m_obd_field47 = Convert.ToString(dr["obd_varchar47"]);
                    this.m_obd_field48 = Convert.ToString(dr["obd_varchar48"]);
                    this.m_obd_field49 = Convert.ToString(dr["obd_varchar49"]);
                    this.m_obd_field50 = Convert.ToString(dr["obd_varchar50"]);
                    this.m_obd_createddate = Convert.ToDateTime(dr["obd_createddate"]);
                    this.m_obd_createdby = Convert.ToString(dr["obd_createdby"]);
                    this.m_obd_updateddate = Convert.ToDateTime(dr["obd_updateddate"]);
                    this.m_obd_updatedby = Convert.ToString(dr["obd_updatedby"]);
                    this.m_obd_hidden = Convert.ToBoolean(dr["obd_hidden"]);
                    this.m_obd_deleted = Convert.ToBoolean(dr["obd_deleted"]);
                    this.m_exists = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetBySitIdPagId()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetBySitIdPagId]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_OBJECT_ID + "::SitId" + m_sit_id.ToString() + "::PagId" + m_pag_id.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + m_sit_id.ToString() + " AND pag_id = " + m_pag_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.m_obd_id = Convert.ToInt32(dr["obd_id"]);
                    this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                    this.m_obd_parentid = Convert.ToInt32(dr["obd_parentid"]);
                    this.m_sit_id = Convert.ToInt32(dr["sit_id"]);
                    this.m_pag_id = Convert.ToInt32(dr["pag_id"]);
                    this.m_mod_id = Convert.ToInt32(dr["mod_id"]);
                    this.m_obd_order = Convert.ToInt32(dr["obd_order"]);
                    this.m_obd_type = (ObjectType)Convert.ToInt32(dr["obd_type"]);
                    this.m_obd_title = Convert.ToString(dr["obd_title"]);
                    this.m_obd_alias = Convert.ToString(dr["obd_alias"]);
                    this.m_obd_description = Convert.ToString(dr["obd_description"]);
                    this.m_obd_field1 = Convert.ToString(dr["obd_varchar1"]);
                    this.m_obd_field2 = Convert.ToString(dr["obd_varchar2"]);
                    this.m_obd_field3 = Convert.ToString(dr["obd_varchar3"]);
                    this.m_obd_field4 = Convert.ToString(dr["obd_varchar4"]);
                    this.m_obd_field5 = Convert.ToString(dr["obd_varchar5"]);
                    this.m_obd_field6 = Convert.ToString(dr["obd_varchar6"]);
                    this.m_obd_field7 = Convert.ToString(dr["obd_varchar7"]);
                    this.m_obd_field8 = Convert.ToString(dr["obd_varchar8"]);
                    this.m_obd_field9 = Convert.ToString(dr["obd_varchar9"]);
                    this.m_obd_field10 = Convert.ToString(dr["obd_varchar10"]);
                    this.m_obd_field11 = Convert.ToString(dr["obd_varchar11"]);
                    this.m_obd_field12 = Convert.ToString(dr["obd_varchar12"]);
                    this.m_obd_field13 = Convert.ToString(dr["obd_varchar13"]);
                    this.m_obd_field14 = Convert.ToString(dr["obd_varchar14"]);
                    this.m_obd_field15 = Convert.ToString(dr["obd_varchar15"]);
                    this.m_obd_field16 = Convert.ToString(dr["obd_varchar16"]);
                    this.m_obd_field17 = Convert.ToString(dr["obd_varchar17"]);
                    this.m_obd_field18 = Convert.ToString(dr["obd_varchar18"]);
                    this.m_obd_field19 = Convert.ToString(dr["obd_varchar19"]);
                    this.m_obd_field20 = Convert.ToString(dr["obd_varchar20"]);
                    this.m_obd_field21 = Convert.ToString(dr["obd_varchar21"]);
                    this.m_obd_field22 = Convert.ToString(dr["obd_varchar22"]);
                    this.m_obd_field23 = Convert.ToString(dr["obd_varchar23"]);
                    this.m_obd_field24 = Convert.ToString(dr["obd_varchar24"]);
                    this.m_obd_field25 = Convert.ToString(dr["obd_varchar25"]);
                    this.m_obd_field26 = Convert.ToString(dr["obd_varchar26"]);
                    this.m_obd_field27 = Convert.ToString(dr["obd_varchar27"]);
                    this.m_obd_field28 = Convert.ToString(dr["obd_varchar28"]);
                    this.m_obd_field29 = Convert.ToString(dr["obd_varchar29"]);
                    this.m_obd_field30 = Convert.ToString(dr["obd_varchar30"]);
                    this.m_obd_field31 = Convert.ToString(dr["obd_varchar31"]);
                    this.m_obd_field32 = Convert.ToString(dr["obd_varchar32"]);
                    this.m_obd_field33 = Convert.ToString(dr["obd_varchar33"]);
                    this.m_obd_field34 = Convert.ToString(dr["obd_varchar34"]);
                    this.m_obd_field35 = Convert.ToString(dr["obd_varchar35"]);
                    this.m_obd_field36 = Convert.ToString(dr["obd_varchar36"]);
                    this.m_obd_field37 = Convert.ToString(dr["obd_varchar37"]);
                    this.m_obd_field38 = Convert.ToString(dr["obd_varchar38"]);
                    this.m_obd_field39 = Convert.ToString(dr["obd_varchar39"]);
                    this.m_obd_field40 = Convert.ToString(dr["obd_varchar40"]);
                    this.m_obd_field41 = Convert.ToString(dr["obd_varchar41"]);
                    this.m_obd_field42 = Convert.ToString(dr["obd_varchar42"]);
                    this.m_obd_field43 = Convert.ToString(dr["obd_varchar43"]);
                    this.m_obd_field44 = Convert.ToString(dr["obd_varchar44"]);
                    this.m_obd_field45 = Convert.ToString(dr["obd_varchar45"]);
                    this.m_obd_field46 = Convert.ToString(dr["obd_varchar46"]);
                    this.m_obd_field47 = Convert.ToString(dr["obd_varchar47"]);
                    this.m_obd_field48 = Convert.ToString(dr["obd_varchar48"]);
                    this.m_obd_field49 = Convert.ToString(dr["obd_varchar49"]);
                    this.m_obd_field50 = Convert.ToString(dr["obd_varchar50"]);
                    this.m_obd_createddate = Convert.ToDateTime(dr["obd_createddate"]);
                    this.m_obd_createdby = Convert.ToString(dr["obd_createdby"]);
                    this.m_obd_updateddate = Convert.ToDateTime(dr["obd_updateddate"]);
                    this.m_obd_updatedby = Convert.ToString(dr["obd_updatedby"]);
                    this.m_obd_hidden = Convert.ToBoolean(dr["obd_hidden"]);
                    this.m_obd_deleted = Convert.ToBoolean(dr["obd_deleted"]);
                    this.m_exists = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetBySitIdPagIdModId()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetBySitIdPagIdModId]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_OBJECT_ID + "::SitId" + m_sit_id.ToString() + "::PagId" + m_pag_id.ToString() + "::ModId" + m_mod_id.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + m_sit_id.ToString() + " AND pag_id = " + m_pag_id.ToString() + " AND mod_id = " + m_mod_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.m_obd_id = Convert.ToInt32(dr["obd_id"]);
                    this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                    this.m_obd_parentid = Convert.ToInt32(dr["obd_parentid"]);
                    this.m_sit_id = Convert.ToInt32(dr["sit_id"]);
                    this.m_pag_id = Convert.ToInt32(dr["pag_id"]);
                    this.m_mod_id = Convert.ToInt32(dr["mod_id"]);
                    this.m_obd_order = Convert.ToInt32(dr["obd_order"]);
                    this.m_obd_type = (ObjectType)Convert.ToInt32(dr["obd_type"]);
                    this.m_obd_title = Convert.ToString(dr["obd_title"]);
                    this.m_obd_alias = Convert.ToString(dr["obd_alias"]);
                    this.m_obd_description = Convert.ToString(dr["obd_description"]);
                    this.m_obd_field1 = Convert.ToString(dr["obd_varchar1"]);
                    this.m_obd_field2 = Convert.ToString(dr["obd_varchar2"]);
                    this.m_obd_field3 = Convert.ToString(dr["obd_varchar3"]);
                    this.m_obd_field4 = Convert.ToString(dr["obd_varchar4"]);
                    this.m_obd_field5 = Convert.ToString(dr["obd_varchar5"]);
                    this.m_obd_field6 = Convert.ToString(dr["obd_varchar6"]);
                    this.m_obd_field7 = Convert.ToString(dr["obd_varchar7"]);
                    this.m_obd_field8 = Convert.ToString(dr["obd_varchar8"]);
                    this.m_obd_field9 = Convert.ToString(dr["obd_varchar9"]);
                    this.m_obd_field10 = Convert.ToString(dr["obd_varchar10"]);
                    this.m_obd_field11 = Convert.ToString(dr["obd_varchar11"]);
                    this.m_obd_field12 = Convert.ToString(dr["obd_varchar12"]);
                    this.m_obd_field13 = Convert.ToString(dr["obd_varchar13"]);
                    this.m_obd_field14 = Convert.ToString(dr["obd_varchar14"]);
                    this.m_obd_field15 = Convert.ToString(dr["obd_varchar15"]);
                    this.m_obd_field16 = Convert.ToString(dr["obd_varchar16"]);
                    this.m_obd_field17 = Convert.ToString(dr["obd_varchar17"]);
                    this.m_obd_field18 = Convert.ToString(dr["obd_varchar18"]);
                    this.m_obd_field19 = Convert.ToString(dr["obd_varchar19"]);
                    this.m_obd_field20 = Convert.ToString(dr["obd_varchar20"]);
                    this.m_obd_field21 = Convert.ToString(dr["obd_varchar21"]);
                    this.m_obd_field22 = Convert.ToString(dr["obd_varchar22"]);
                    this.m_obd_field23 = Convert.ToString(dr["obd_varchar23"]);
                    this.m_obd_field24 = Convert.ToString(dr["obd_varchar24"]);
                    this.m_obd_field25 = Convert.ToString(dr["obd_varchar25"]);
                    this.m_obd_field26 = Convert.ToString(dr["obd_varchar26"]);
                    this.m_obd_field27 = Convert.ToString(dr["obd_varchar27"]);
                    this.m_obd_field28 = Convert.ToString(dr["obd_varchar28"]);
                    this.m_obd_field29 = Convert.ToString(dr["obd_varchar29"]);
                    this.m_obd_field30 = Convert.ToString(dr["obd_varchar30"]);
                    this.m_obd_field31 = Convert.ToString(dr["obd_varchar31"]);
                    this.m_obd_field32 = Convert.ToString(dr["obd_varchar32"]);
                    this.m_obd_field33 = Convert.ToString(dr["obd_varchar33"]);
                    this.m_obd_field34 = Convert.ToString(dr["obd_varchar34"]);
                    this.m_obd_field35 = Convert.ToString(dr["obd_varchar35"]);
                    this.m_obd_field36 = Convert.ToString(dr["obd_varchar36"]);
                    this.m_obd_field37 = Convert.ToString(dr["obd_varchar37"]);
                    this.m_obd_field38 = Convert.ToString(dr["obd_varchar38"]);
                    this.m_obd_field39 = Convert.ToString(dr["obd_varchar39"]);
                    this.m_obd_field40 = Convert.ToString(dr["obd_varchar40"]);
                    this.m_obd_field41 = Convert.ToString(dr["obd_varchar41"]);
                    this.m_obd_field42 = Convert.ToString(dr["obd_varchar42"]);
                    this.m_obd_field43 = Convert.ToString(dr["obd_varchar43"]);
                    this.m_obd_field44 = Convert.ToString(dr["obd_varchar44"]);
                    this.m_obd_field45 = Convert.ToString(dr["obd_varchar45"]);
                    this.m_obd_field46 = Convert.ToString(dr["obd_varchar46"]);
                    this.m_obd_field47 = Convert.ToString(dr["obd_varchar47"]);
                    this.m_obd_field48 = Convert.ToString(dr["obd_varchar48"]);
                    this.m_obd_field49 = Convert.ToString(dr["obd_varchar49"]);
                    this.m_obd_field50 = Convert.ToString(dr["obd_varchar50"]);
                    this.m_obd_createddate = Convert.ToDateTime(dr["obd_createddate"]);
                    this.m_obd_createdby = Convert.ToString(dr["obd_createdby"]);
                    this.m_obd_updateddate = Convert.ToDateTime(dr["obd_updateddate"]);
                    this.m_obd_updatedby = Convert.ToString(dr["obd_updatedby"]);
                    this.m_obd_hidden = Convert.ToBoolean(dr["obd_hidden"]);
                    this.m_obd_deleted = Convert.ToBoolean(dr["obd_deleted"]);
                    this.m_exists = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetByAlias()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetByAlias]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_OBJECT_ALIAS + "::SitId" + this.m_sit_id.ToString() + "::PagId" + this.m_pag_id.ToString() + "::ModId" + this.m_mod_id.ToString() + "::ObdType" + Convert.ToString((Int32)this.m_obd_type) + "::ObdAlias" + m_obd_alias;
                if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    if (this.m_sit_id > 0 && this.m_pag_id > 0 && this.m_mod_id > 0)
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND mod_id = " + this.m_mod_id.ToString() + Convert.ToString(this.m_obd_type != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_obd_type) : String.Empty) + " AND obd_alias = '" + m_obd_alias + "'");
                    else if (this.m_sit_id > 0 && this.m_pag_id > 0)
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + Convert.ToString(this.m_obd_type != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_obd_type) : String.Empty) + " AND obd_alias = '" + m_obd_alias + "'");
                    else if (this.m_sit_id > 0 && this.m_pag_id == 0)
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE sit_id = " + this.m_sit_id.ToString() + Convert.ToString(this.m_obd_type != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_obd_type) : String.Empty) + " AND obd_alias = '" + m_obd_alias + "'");
                    else
                        sSQL.Append("SELECT * FROM obd_objectdata WHERE obd_alias = '" + m_obd_alias + "'" + Convert.ToString(this.m_obd_type != ObjectType.Undefined ? " AND obd_type = " + Convert.ToString((Int32)this.m_obd_type) : String.Empty));
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.m_obd_id = Convert.ToInt32(dr["obd_id"]);
                    this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                    this.m_obd_parentid = Convert.ToInt32(dr["obd_parentid"]);
                    this.m_sit_id = Convert.ToInt32(dr["sit_id"]);
                    this.m_pag_id = Convert.ToInt32(dr["pag_id"]);
                    this.m_mod_id = Convert.ToInt32(dr["mod_id"]);
                    this.m_obd_order = Convert.ToInt32(dr["obd_order"]);
                    this.m_obd_type = (ObjectType)Convert.ToInt32(dr["obd_type"]);
                    this.m_obd_title = Convert.ToString(dr["obd_title"]);
                    this.m_obd_alias = Convert.ToString(dr["obd_alias"]);
                    this.m_obd_description = Convert.ToString(dr["obd_description"]);
                    this.m_obd_field1 = Convert.ToString(dr["obd_varchar1"]);
                    this.m_obd_field2 = Convert.ToString(dr["obd_varchar2"]);
                    this.m_obd_field3 = Convert.ToString(dr["obd_varchar3"]);
                    this.m_obd_field4 = Convert.ToString(dr["obd_varchar4"]);
                    this.m_obd_field5 = Convert.ToString(dr["obd_varchar5"]);
                    this.m_obd_field6 = Convert.ToString(dr["obd_varchar6"]);
                    this.m_obd_field7 = Convert.ToString(dr["obd_varchar7"]);
                    this.m_obd_field8 = Convert.ToString(dr["obd_varchar8"]);
                    this.m_obd_field9 = Convert.ToString(dr["obd_varchar9"]);
                    this.m_obd_field10 = Convert.ToString(dr["obd_varchar10"]);
                    this.m_obd_field11 = Convert.ToString(dr["obd_varchar11"]);
                    this.m_obd_field12 = Convert.ToString(dr["obd_varchar12"]);
                    this.m_obd_field13 = Convert.ToString(dr["obd_varchar13"]);
                    this.m_obd_field14 = Convert.ToString(dr["obd_varchar14"]);
                    this.m_obd_field15 = Convert.ToString(dr["obd_varchar15"]);
                    this.m_obd_field16 = Convert.ToString(dr["obd_varchar16"]);
                    this.m_obd_field17 = Convert.ToString(dr["obd_varchar17"]);
                    this.m_obd_field18 = Convert.ToString(dr["obd_varchar18"]);
                    this.m_obd_field19 = Convert.ToString(dr["obd_varchar19"]);
                    this.m_obd_field20 = Convert.ToString(dr["obd_varchar20"]);
                    this.m_obd_field21 = Convert.ToString(dr["obd_varchar21"]);
                    this.m_obd_field22 = Convert.ToString(dr["obd_varchar22"]);
                    this.m_obd_field23 = Convert.ToString(dr["obd_varchar23"]);
                    this.m_obd_field24 = Convert.ToString(dr["obd_varchar24"]);
                    this.m_obd_field25 = Convert.ToString(dr["obd_varchar25"]);
                    this.m_obd_field26 = Convert.ToString(dr["obd_varchar26"]);
                    this.m_obd_field27 = Convert.ToString(dr["obd_varchar27"]);
                    this.m_obd_field28 = Convert.ToString(dr["obd_varchar28"]);
                    this.m_obd_field29 = Convert.ToString(dr["obd_varchar29"]);
                    this.m_obd_field30 = Convert.ToString(dr["obd_varchar30"]);
                    this.m_obd_field31 = Convert.ToString(dr["obd_varchar31"]);
                    this.m_obd_field32 = Convert.ToString(dr["obd_varchar32"]);
                    this.m_obd_field33 = Convert.ToString(dr["obd_varchar33"]);
                    this.m_obd_field34 = Convert.ToString(dr["obd_varchar34"]);
                    this.m_obd_field35 = Convert.ToString(dr["obd_varchar35"]);
                    this.m_obd_field36 = Convert.ToString(dr["obd_varchar36"]);
                    this.m_obd_field37 = Convert.ToString(dr["obd_varchar37"]);
                    this.m_obd_field38 = Convert.ToString(dr["obd_varchar38"]);
                    this.m_obd_field39 = Convert.ToString(dr["obd_varchar39"]);
                    this.m_obd_field40 = Convert.ToString(dr["obd_varchar40"]);
                    this.m_obd_field41 = Convert.ToString(dr["obd_varchar41"]);
                    this.m_obd_field42 = Convert.ToString(dr["obd_varchar42"]);
                    this.m_obd_field43 = Convert.ToString(dr["obd_varchar43"]);
                    this.m_obd_field44 = Convert.ToString(dr["obd_varchar44"]);
                    this.m_obd_field45 = Convert.ToString(dr["obd_varchar45"]);
                    this.m_obd_field46 = Convert.ToString(dr["obd_varchar46"]);
                    this.m_obd_field47 = Convert.ToString(dr["obd_varchar47"]);
                    this.m_obd_field48 = Convert.ToString(dr["obd_varchar48"]);
                    this.m_obd_field49 = Convert.ToString(dr["obd_varchar49"]);
                    this.m_obd_field50 = Convert.ToString(dr["obd_varchar50"]);
                    this.m_obd_createddate = Convert.ToDateTime(dr["obd_createddate"]);
                    this.m_obd_createdby = Convert.ToString(dr["obd_createdby"]);
                    this.m_obd_updateddate = Convert.ToDateTime(dr["obd_updateddate"]);
                    this.m_obd_updatedby = Convert.ToString(dr["obd_updatedby"]);
                    this.m_obd_hidden = Convert.ToBoolean(dr["obd_hidden"]);
                    this.m_obd_deleted = Convert.ToBoolean(dr["obd_deleted"]);
                    this.m_exists = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetParents()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetParents]";
            Int32[] Parents = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_OBJECT_ID + "::ObdId" + m_obd_id.ToString() + "::Parents";
                if (HttpContext.Current != null) if (HttpContext.Current != null) Parents = (Int32[])HttpContext.Current.Cache[CacheItem];
                if (Parents == null)
                {
                    if (this.ParentId > 0)
                    {
                        Parents = new Int32[1];
                        Parents[0] = this.ParentId;
                        Parents = Generic.GrowArray(GetNextParent(Parents, this.ParentId), 0);
                        RXServer.Data.CacheInsert(CacheItem, Parents);
                    }
                }
                this.m_obd_parents = Parents;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private Int32[] GetNextParent(Int32[] Parents, Int32 ObdId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetNextParent]";
            try
            {
                Object o = new Object(ObdId, Data.DataSource, Data.ConnectionString);
                if (o.ParentId > 0)
                {
                    Parents = Generic.GrowArray(Parents, Parents.Length + 1);
                    Parents[Parents.Length - 1] = o.ParentId;
                    Parents = GetNextParent(Parents, o.ParentId);
                }
                return Parents;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return Parents;
            }
        }
        private Boolean FindChildren()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::FindChildren]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_OBJECT_ID + "::ObdId" + m_obd_id.ToString() + "::Children";
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT obd_id FROM obd_objectdata WHERE obd_parentid = " + m_obd_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
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

        #endregion Private Methods

    }
    #endregion public class Object

    #region public class DocumentCollection

    /// <summary>
    /// 
    /// </summary>
    public class DocumentCollection : IDisposable, IEnumerable
    {
        string CLASSNAME = "[Namespace::RXServer][Class::DocumentCollection]";

        #region DataHandler Variables

        private string m_datasource;
        private string m_connectionstring;

        #endregion DataHandler Variables

        #region Private Variables

        private Document m_document;
        private Document[] m_documents = new Document[0];
        private ObjectType m_objecttype = ObjectType.Undefined;
        private Int32 m_sit_id;
        private Int32 m_pag_id;
        private bool m_autoupdate;
        private DataTable m_dtdocuments;
        private Boolean m_refresh; 

        #endregion Private Variables

        #region Properties


        public IEnumerator GetEnumerator()
        {
            return new RXDocumentEnum(this.m_documents);
        }
        /// <summary>
        /// 
        /// </summary>
        public Document this[Int32 index]
        {
            get
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Document]";
                try
                {
                    this.m_document = (Document)this.m_documents[index];
                    return this.m_document;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return new Document(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Document[] Items
        {
            get
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Document]";
                try
                {
                    return this.m_documents;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return new Document[0];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Document GetDocument(Int32 id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetDocument]";
            try
            {
                foreach (Document d in this.m_documents)
                {
                    if (d.Id == id)
                    {
                        return d;
                    }
                }
                return new Document(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Document(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public Document GetDocument(string alias)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetDocument]";
            try
            {
                foreach (Document d in this.m_documents)
                {
                    if (d.Alias.ToLower() == alias.ToLower())
                    {
                        return d;
                    }
                }
                return new Document(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Document(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Contains(Int32 id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            try
            {
                foreach (Document d in this.m_documents)
                {
                    if (d.Id == id)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public bool Contains(string alias)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            try
            {
                foreach (Document d in this.m_documents)
                {
                    if (d.Alias.ToLower() == alias.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        public bool Refresh
        {
            get
            {
                return this.m_refresh;
            }
            set
            {
                this.m_refresh = value;
            }
        }


        #endregion Properties

        #region Constructors

        public DocumentCollection(bool AutoUpdate, String DataSource, String ConnectionString) : this(AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public DocumentCollection(Int32 SitId, bool AutoUpdate, String DataSource, String ConnectionString) : this(SitId, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public DocumentCollection(Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString) : this(SitId, PagId, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public DocumentCollection(ObjectType ObjectType, bool AutoUpdate, String DataSource, String ConnectionString) : this(ObjectType, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public DocumentCollection(ObjectType ObjectType, Int32 SitId, bool AutoUpdate, String DataSource, String ConnectionString) : this(ObjectType, SitId, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public DocumentCollection(ObjectType ObjectType, Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString) : this(ObjectType, SitId, PagId, AutoUpdate, DataSource, ConnectionString, true)
        {   
        }
        
        public DocumentCollection(bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public DocumentCollection(Int32 SitId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public DocumentCollection(Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public DocumentCollection(ObjectType ObjectType, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
            this.m_objecttype = ObjectType;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public DocumentCollection(ObjectType ObjectType, Int32 SitId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_autoupdate = AutoUpdate;
            this.m_objecttype = ObjectType;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public DocumentCollection(ObjectType ObjectType, Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_autoupdate = AutoUpdate;
            this.m_objecttype = ObjectType;
            this.m_refresh = Refresh; 
            GetAll();
        }

        ~DocumentCollection()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            if (!this.Refresh)
                ResetThis();
            if (RXServer.Data.ActivateGC)
                GC.Collect();
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="site"></param>
        public void Add(Document Document)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            try
            {
                this.Add(ref Document);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void Add(ref Document Document)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            try
            {
                DataSet ds = new DataSet();
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("INSERT INTO doc_documents (lng_id, doc_parentid, sit_id, pag_id, doc_order, doc_type, doc_title, ");
                sSQL.Append("doc_alias, doc_description, ");
                sSQL.Append("doc_contenttype, doc_contentsize, doc_version, doc_charset, doc_extension, doc_path, doc_checkoutusrid, doc_checkoutdate, doc_checkoutexpiredate, doc_lastvieweddate, doc_lastviewedby, doc_isdirty, doc_isdelivered, doc_issigned, doc_iscertified, doc_deliverdate, doc_deliverby, doc_deliverto, ");
                sSQL.Append("doc_createddate, doc_createdby, doc_updateddate, ");
                sSQL.Append("doc_updatedby, doc_hidden, doc_deleted) ");
                sSQL.Append("VALUES (");
                sSQL.Append("" + Document.Language.ToString() + ", ");
                sSQL.Append("" + Document.ParentId.ToString() + ", ");
                sSQL.Append("" + Document.SitId.ToString() + ", ");
                sSQL.Append("" + Document.PagId.ToString() + ", ");
                sSQL.Append("" + Document.Order.ToString() + ", ");
                sSQL.Append(Convert.ToString((Int32)Document.ObjectType) + ", ");
                sSQL.Append("'" + Document.Name.ToString() + "', ");
                sSQL.Append("'" + Document.Alias.ToString() + "', ");
                sSQL.Append("'" + Document.Description.ToString() + "', ");

                sSQL.Append("'" + Document.ContentType.ToString() + "', ");
                sSQL.Append("" + Document.ContentSize.ToString() + ", ");
                sSQL.Append("" + Document.Version.ToString() + ", ");
                sSQL.Append("'" + Document.CharSet.ToString() + "', ");
                sSQL.Append("'" + Document.Extension.ToString() + "', ");
                sSQL.Append("'" + Document.Path.ToString() + "', ");
                sSQL.Append("" + Document.CheckOutUsrId.ToString() + ", ");
                sSQL.Append("'" + Document.CheckOutDate.ToString() + "', ");
                sSQL.Append("'" + Document.CheckOutExpireDate.ToString() + "', ");
                sSQL.Append("'" + Document.LastViewedDate.ToString() + "', ");
                sSQL.Append("'" + Document.LastViewedBy.ToString() + "', ");
                sSQL.Append("" + Convert.ToInt32(Document.IsDirty).ToString() + ", ");
                sSQL.Append("" + Convert.ToInt32(Document.IsDelivered).ToString() + ", ");
                sSQL.Append("" + Convert.ToInt32(Document.IsSigned).ToString() + ", ");
                sSQL.Append("" + Convert.ToInt32(Document.IsCertified).ToString() + ", ");
                sSQL.Append("'" + Document.DeliverDate.ToString() + "', ");
                sSQL.Append("'" + Document.DeliverBy.ToString() + "', ");
                sSQL.Append("'" + Document.DeliverTo.ToString() + "', ");

                sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', ");
                sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', ");
                sSQL.Append("" + Convert.ToInt32(Document.Hidden).ToString() + ", ");
                sSQL.Append("" + Convert.ToInt32(Document.Deleted).ToString() + "");
                sSQL.Append(")");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                {
                    oDo.ExecuteNonQuery(sSQL.ToString());
                    Document.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                }

                foreach (Int32 r in Document.AuthorizedEditRoles)
                {
                    sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO adr_authorizeddocumentsroles (doc_id, rol_id, adr_createddate, adr_createdby, adr_updateddate, adr_updatedby, adr_hidden, adr_deleted) VALUES ( ");
                    sSQL.Append(Document.Id.ToString() + ", ");
                    sSQL.Append(r.ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());
                }

                foreach (Int32 g in Document.AuthorizedEditGroups)
                {
                    sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO adg_authorizeddocumentsgroups (doc_id, grp_id, adg_createddate, adg_createdby, adg_updateddate, adg_updatedby, adg_hidden, adg_deleted) VALUES ( ");
                    sSQL.Append(Document.Id.ToString() + ", ");
                    sSQL.Append(g.ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());
                }
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_COLLECTION);

                System.Object _tmp = Document.FileStream;
                Document = new Document(Document.SitId, Document.PagId, Document.Id, Data.DataSource, Data.ConnectionString);
                Document.FileStream = _tmp;

                if (Document.FileStream is HttpPostedFile)
                {
                    HttpPostedFile file = (HttpPostedFile)Document.FileStream;
                    DirectoryInfo di = this.GenerateFileName(Document.Id);
                    file.SaveAs(di.FullName + "\\" + System.IO.Path.GetFileName(file.FileName));
                    Document.Path = di.FullName + "\\" + System.IO.Path.GetFileName(file.FileName);
                    Document.Extension = System.IO.Path.GetExtension(file.FileName);
                    Document.ContentSize = file.ContentLength;
                    Document.ContentType = file.ContentType;
                    Document.Update();
                    file = null;
                }
                else if (Document.FileStream is UploadedFile)
                {
                    UploadedFile file = (UploadedFile)Document.FileStream;
                    DirectoryInfo di = this.GenerateFileName(Document.Id);
                    file.SaveAs(di.FullName + "\\" + file.GetName());
                    Document.Path = di.FullName + "\\" + file.GetName();
                    Document.Extension = file.GetExtension();
                    Document.ContentSize = file.ContentLength;
                    Document.ContentType = file.ContentType;
                    Document.Update();
                    file = null;
                }
                else if (Document.FileStream is FileInfo)
                {
                    FileInfo file = (FileInfo)Document.FileStream;
                    DirectoryInfo di = this.GenerateFileName(Document.Id);
                    file.CopyTo(di.FullName + "\\" + file.Name);
                    Document.Path = di.FullName + "\\" + file.Name;
                    Document.Extension = file.Extension;
                    Document.ContentSize = Convert.ToInt32(file.Length);
                    Document.ContentType = String.Empty;
                    Document.Update();
                    file = null;
                }

                SortAll();
                GetAll();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="site"></param>
        public void Remove(Document Document)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            try
            {
                this.Remove(Document.Id);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(Int32 id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            try
            {
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("UPDATE doc_documents SET doc_deleted = 1 ");
                sSQL.Append("WHERE doc_id = " + id.ToString());
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                    oDo.ExecuteNonQuery(sSQL.ToString());
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_ID + id.ToString());
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_COLLECTION);
                GetAll();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Clear]";
            try
            {
                this.m_documents = null;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int32 Count()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Count]";
            try
            {
                return this.m_documents.Length;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return 0;
            }
        }

        public DataTable DataTable()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            try
            {
                return m_dtdocuments;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new DataTable();
            }
        }

        public DataTable DataTable(DocumentSortField SortField, SortOrder SortOrder)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            try
            {
                DataView v = new DataView(m_dtdocuments);
                v.Sort = RetriveSortField(SortField) + Convert.ToString((Int32)SortOrder == 1 ? String.Empty : " DESC");
                return v.ToTable();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new DataTable();
            }
        }


        #endregion Public Methods

        #region Private Methods

        private void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_COLLECTION);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_ROLES);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_GROUPS);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private String RetriveSortField(DocumentSortField SortField)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::RetriveSortField]";
            try
            {

                if ((Int32)SortField == 1) return "doc_id";
                if ((Int32)SortField == 2) return "sit_id";
                if ((Int32)SortField == 3) return "pag_id";
                if ((Int32)SortField == 4) return "lng_id";
                if ((Int32)SortField == 5) return "doc_type";
                if ((Int32)SortField == 6) return "doc_parentid";
                if ((Int32)SortField == 7) return "doc_order";
                if ((Int32)SortField == 8) return "doc_title";
                if ((Int32)SortField == 9) return "doc_alias";
                if ((Int32)SortField == 10) return "doc_description";
                if ((Int32)SortField == 11) return "doc_contenttype";
                if ((Int32)SortField == 12) return "doc_contentsize";
                if ((Int32)SortField == 13) return "doc_version";
                if ((Int32)SortField == 14) return "doc_charset";
                if ((Int32)SortField == 15) return "doc_extension";
                if ((Int32)SortField == 16) return "doc_path";
                if ((Int32)SortField == 17) return "doc_checkoutusrid";
                if ((Int32)SortField == 18) return "doc_checkoutdate";
                if ((Int32)SortField == 19) return "doc_checkoutexpiredate";
                if ((Int32)SortField == 20) return "doc_lastviewedate";
                if ((Int32)SortField == 21) return "doc_lastviewedby";
                if ((Int32)SortField == 22) return "doc_isdirty";
                if ((Int32)SortField == 23) return "doc_isdelivered";
                if ((Int32)SortField == 24) return "doc_issigned";
                if ((Int32)SortField == 25) return "doc_iscertified";
                if ((Int32)SortField == 26) return "doc_deliverdate";
                if ((Int32)SortField == 27) return "doc_deliverby";
                if ((Int32)SortField == 28) return "doc_deliverto";
                if ((Int32)SortField == 29) return "doc_createddate";
                if ((Int32)SortField == 30) return "doc_createdby";
                if ((Int32)SortField == 31) return "doc_updateddate";
                if ((Int32)SortField == 32) return "doc_updatedby";
                return String.Empty;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return String.Empty;
            }
        }
        private void GetAll()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAll]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_DOCUMENT_COLLECTION + "::SitId" + this.m_sit_id.ToString() + "::PagId" + this.m_pag_id.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    if (this.m_sit_id > 0 && this.m_pag_id > 0)
                        sSQL.Append("SELECT * FROM doc_documents WHERE doc_deleted = 0 AND sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + Convert.ToString(this.m_objecttype != ObjectType.Undefined ? " AND doc_type = " + Convert.ToString((Int32)this.m_objecttype) : String.Empty) + " ORDER BY doc_order");
                    else if (this.m_sit_id > 0 && this.m_pag_id == 0)
                        sSQL.Append("SELECT * FROM doc_documents WHERE doc_deleted = 0 AND pag_id = " + this.m_pag_id.ToString() + Convert.ToString(this.m_objecttype != ObjectType.Undefined ? " AND doc_type = " + Convert.ToString((Int32)this.m_objecttype) : String.Empty) + " ORDER BY doc_order");
                    else
                        sSQL.Append("SELECT * FROM doc_documents WHERE doc_deleted = 0" + Convert.ToString(this.m_objecttype != ObjectType.Undefined ? " AND doc_type = " + Convert.ToString((Int32)this.m_objecttype) : String.Empty) + " ORDER BY doc_order");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    this.m_dtdocuments = dt;
                    Int32 index = 0;
                    this.m_documents = new Document[dt.Rows.Count];
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.m_documents[index] = new Document(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
                        this.m_documents[index].Id = Convert.ToInt32(dr["sit_id"]);
                        this.m_documents[index].SitId = Convert.ToInt32(dr["sit_id"]);
                        this.m_documents[index].PagId = Convert.ToInt32(dr["pag_id"]);
                        this.m_documents[index].Language = Convert.ToInt32(dr["lng_id"]);
                        this.m_documents[index].ParentId = Convert.ToInt32(dr["doc_parentid"]);
                        this.m_documents[index].ObjectType = (ObjectType)Convert.ToInt32(dr["doc_type"]);
                        this.m_documents[index].Order = Convert.ToInt32(dr["doc_order"]);
                        this.m_documents[index].Name = Convert.ToString(dr["doc_title"]);
                        this.m_documents[index].Alias = Convert.ToString(dr["doc_alias"]);
                        this.m_documents[index].Description = Convert.ToString(dr["doc_description"]);
                        this.m_documents[index].AuthorizedEditRoles = this.GetAuthorizedEditRoles(Convert.ToInt32(dr["doc_id"]));
                        this.m_documents[index].AuthorizedEditGroups = this.GetAuthorizedEditGroups(Convert.ToInt32(dr["doc_id"]));

                        this.m_documents[index].ContentType = Convert.ToString(dr["doc_contenttype"]);
                        this.m_documents[index].ContentSize = Convert.ToInt32(dr["doc_contentsize"]);
                        this.m_documents[index].Version = Convert.ToInt32(dr["doc_version"]);
                        this.m_documents[index].CharSet = Convert.ToString(dr["doc_charset"]);
                        this.m_documents[index].Extension = Convert.ToString(dr["doc_extension"]);
                        this.m_documents[index].Path = Convert.ToString(dr["doc_path"]);
                        this.m_documents[index].CheckOutUsrId = Convert.ToInt32(dr["doc_checkoutusrid"]);
                        this.m_documents[index].CheckOutDate = Convert.ToDateTime(dr["doc_checkoutdate"]);
                        this.m_documents[index].CheckOutExpireDate = Convert.ToDateTime(dr["doc_checkoutexpiredate"]);
                        this.m_documents[index].LastViewedDate = Convert.ToDateTime(dr["doc_lastvieweddate"]);
                        this.m_documents[index].LastViewedBy = Convert.ToString(dr["doc_lastviewedby"]);
                        this.m_documents[index].IsDirty = Convert.ToBoolean(dr["doc_isdirty"]);
                        this.m_documents[index].IsDelivered = Convert.ToBoolean(dr["doc_isdelivered"]);
                        this.m_documents[index].IsSigned = Convert.ToBoolean(dr["doc_issigned"]);
                        this.m_documents[index].IsCertified = Convert.ToBoolean(dr["doc_iscertified"]);
                        this.m_documents[index].DeliverDate = Convert.ToDateTime(dr["doc_deliverdate"]);
                        this.m_documents[index].DeliverBy = Convert.ToString(dr["doc_deliverby"]);
                        this.m_documents[index].DeliverTo = Convert.ToString(dr["doc_deliverto"]);

                        this.m_documents[index].CreatedDate = Convert.ToDateTime(dr["doc_createddate"]);
                        this.m_documents[index].CreatedBy = Convert.ToString(dr["doc_createdby"]);
                        this.m_documents[index].UpdatedDate = Convert.ToDateTime(dr["doc_updateddate"]);
                        this.m_documents[index].UpdatedBy = Convert.ToString(dr["doc_updatedby"]);
                        this.m_documents[index].Hidden = Convert.ToBoolean(dr["doc_hidden"]);
                        this.m_documents[index].Deleted = Convert.ToBoolean(dr["doc_deleted"]);
                        this.m_documents[index].Exist = true;
                        index++;
                    }
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
                sSQL.Append("SELECT * FROM doc_documents WHERE doc_deleted = 0 ORDER BY sit_id, pag_id, doc_order");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                {
                    DataTable dt = oDo.GetDataTable(sSQL.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE doc_documents SET doc_order = " + Order.ToString() + " WHERE doc_id = " + dr["doc_id"].ToString());
                        using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
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
        private Int32[] GetAuthorizedEditRoles(Int32 DocId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditRoles]";
            Int32[] Roles;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_DOCUMENT_ROLES + "::DocId" + DocId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM adr_authorizeddocumentsroles WHERE doc_id = " + DocId.ToString() + " AND adr_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Roles = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Roles[i] = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                return Roles;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Int32[] GetAuthorizedEditGroups(Int32 DocId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditGroups]";
            Int32[] Groups;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_DOCUMENT_GROUPS + "::DocId" + DocId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM adg_authorizeddocumentsgroups WHERE doc_id = " + DocId.ToString() + " AND adg_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Groups = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Groups[i] = Convert.ToInt32(dt.Rows[i]["grp_id"]);
                return Groups;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private DirectoryInfo GenerateFileName(Int32 DocId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GenerateFileName]";
            try
            {
                String filename = HttpContext.Current.Server.MapPath("~/DocumentRoot/");

                DirectoryInfo di = new DirectoryInfo(filename);
                if (!di.Exists)
                    di.Create();

                if (this.m_sit_id > 0)
                {
                    filename += "\\sit" + this.m_sit_id.ToString();
                    di = new DirectoryInfo(filename);
                    if (!di.Exists)
                        di.Create();
                }
                if (this.m_pag_id > 0)
                {
                    filename += "\\pag" + this.m_pag_id.ToString();
                    di = new DirectoryInfo(filename);
                    if (!di.Exists)
                        di.Create();
                }
                filename += "\\doc" + DocId.ToString();
                di = new DirectoryInfo(filename);
                if (!di.Exists)
                    di.Create();

                return di;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return null;
            }
        }

        #endregion Private Methods

    }
    #endregion public class DocumentCollection

    #region public class Document

    public class Document : IDisposable
    {
        string CLASSNAME = "[Namespace::RXServer][Class::Document]";

        #region DataHandler Variables

        private String m_datasource;
        private String m_connectionstring;

        #endregion DataHandler Variables

        #region Private Variables

        private bool m_exists = false;
        private bool m_autoupdate = false;

        private Int32 m_doc_id = 0;
        private Int32 m_sit_id = 0;
        private Int32 m_pag_id = 0;
        private Int32 m_lng_id = 0;
        private ObjectType m_doc_type = ObjectType.Undefined;
        private Int32 m_doc_parentid = 0;
        private Int32[] m_doc_parents = new Int32[0];
        private Int32 m_doc_order = 0;
        private String m_doc_title = String.Empty;
        private String m_doc_alias = String.Empty;
        private String m_doc_description = String.Empty;
        private Int32[] m_doc_authorizededitroles = new Int32[0];
        private Int32[] m_doc_authorizededitgroups = new Int32[0];

        private String m_doc_contenttype = String.Empty;
        private Int32 m_doc_contentsize = 0;
        private Int32 m_doc_version = 0;
        private String m_doc_charset = String.Empty;
        private String m_doc_extension = String.Empty;
        private String m_doc_path = String.Empty;
        private System.Object m_doc_stream;
        private Int32 m_doc_checkoutusrid = 0;
        private DateTime m_doc_checkoutdate = DateTime.Now;
        private DateTime m_doc_checkoutexpiredate = DateTime.Now;
        private DateTime m_doc_lastvieweddate = DateTime.Now;
        private String m_doc_lastviewedby = String.Empty;
        private bool m_doc_isdirty = false;
        private bool m_doc_isdelivered = false;
        private bool m_doc_issigned = false;
        private bool m_doc_iscertified = false;
        private DateTime m_doc_deliverdate = DateTime.Now;
        private String m_doc_deliverby = String.Empty;
        private String m_doc_deliverto = String.Empty;

        private DateTime m_doc_createddate = DateTime.Now;
        private String m_doc_createdby = String.Empty;
        private DateTime m_doc_updateddate = DateTime.Now;
        private String m_doc_updatedby = String.Empty;
        private bool m_doc_hidden = false;
        private bool m_doc_deleted = false;

        private bool m_doc_haschildren = false;
        private bool m_doc_hasparent = false;

        #endregion Private Variables

        #region Properties

        public bool AutoUpdate
        {
            set
            {
                this.m_autoupdate = value;
            }
        }
        public bool Exist
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
        public bool HasChildren
        {
            get
            {
                this.m_doc_haschildren = this.FindChildren();
                return this.m_doc_haschildren;
            }
        }
        public bool HasParent
        {
            get
            {
                this.m_doc_hasparent = this.m_doc_parentid == 0 ? false : true;
                return this.m_doc_hasparent;
            }
        }
        public int SitId
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
        public int PagId
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
        public int Id
        {
            get
            {
                return this.m_doc_id;
            }
            set
            {
                this.m_doc_id = value;
            }
        }
        public ObjectType ObjectType
        {
            get
            {
                return this.m_doc_type;
            }
            set
            {
                this.m_doc_type = value;
            }
        }
        public int ParentId
        {
            get
            {
                return this.m_doc_parentid;
            }
            set
            {
                this.m_doc_parentid = value;
            }
        }
        public Int32[] Parents
        {
            get
            {
                GetParents();
                return this.m_doc_parents;
            }
        }
        public int Language
        {
            get
            {
                return this.m_lng_id;
            }
            set
            {
                this.m_lng_id = value;
                PropertyUpdate("lng_id", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public int Order
        {
            get
            {
                return this.m_doc_order;
            }
            set
            {
                this.m_doc_order = value;
                PropertyUpdate("doc_order", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public string Alias
        {
            get
            {
                return this.m_doc_alias;
            }
            set
            {
                this.m_doc_alias = Common.SafeString(value);
                PropertyUpdate("doc_alias", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Name
        {
            get
            {
                return this.m_doc_title;
            }
            set
            {
                this.m_doc_title = Common.SafeString(value);
                PropertyUpdate("doc_title", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Description
        {
            get
            {
                return this.m_doc_description;
            }
            set
            {
                this.m_doc_description = Common.SafeString(value);
                PropertyUpdate("doc_description", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public System.Object FileStream
        {
            get
            {
                return this.m_doc_stream;
            }
            set
            {
                this.m_doc_stream = value;
                PropertyUpdate("doc_stream", value, PropertyUpdateType.FileStream, PropertyUpdateTableType.Settings);
            }
        }
        public Int32[] AuthorizedEditRoles
        {
            get
            {
                return this.m_doc_authorizededitroles;
            }
            set
            {
                this.m_doc_authorizededitroles = value;
                PropertyUpdate("rol_id", value, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
            }
        }
        public Int32[] AuthorizedEditGroups
        {
            get
            {
                return this.m_doc_authorizededitgroups;
            }
            set
            {
                this.m_doc_authorizededitgroups = value;
                PropertyUpdate("grp_id", value, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
            }
        }
        public string ContentType
        {
            get
            {
                return this.m_doc_contenttype;
            }
            set
            {
                this.m_doc_contenttype = Common.SafeString(value);
                PropertyUpdate("doc_contenttype", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public Int32 ContentSize
        {
            get
            {
                return this.m_doc_contentsize;
            }
            set
            {
                this.m_doc_contentsize = value;
                PropertyUpdate("doc_contentsize", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public Int32 Version
        {
            get
            {
                return this.m_doc_version;
            }
            set
            {
                this.m_doc_version = value;
                PropertyUpdate("doc_version", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public string CharSet
        {
            get
            {
                return this.m_doc_charset;
            }
            set
            {
                this.m_doc_charset = Common.SafeString(value);
                PropertyUpdate("doc_charset", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Extension
        {
            get
            {
                return this.m_doc_extension;
            }
            set
            {
                this.m_doc_extension = Common.SafeString(value);
                PropertyUpdate("doc_extension", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Path
        {
            get
            {
                return this.m_doc_path;
            }
            set
            {
                this.m_doc_path = Common.SafeString(value);
                PropertyUpdate("doc_path", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public Int32 CheckOutUsrId
        {
            get
            {
                return this.m_doc_checkoutusrid;
            }
            set
            {
                this.m_doc_checkoutusrid = value;
                PropertyUpdate("doc_checkoutusrid", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public DateTime CheckOutDate
        {
            get
            {
                return this.m_doc_checkoutdate;
            }
            set
            {
                this.m_doc_checkoutdate = value;
                PropertyUpdate("doc_checkoutdate", value, PropertyUpdateType.DateTime, PropertyUpdateTableType.Standard);
            }
        }
        public DateTime CheckOutExpireDate
        {
            get
            {
                return this.m_doc_checkoutexpiredate;
            }
            set
            {
                this.m_doc_checkoutexpiredate = value;
                PropertyUpdate("doc_checkoutexpiredate", value, PropertyUpdateType.DateTime, PropertyUpdateTableType.Standard);
            }
        }
        public DateTime LastViewedDate
        {
            get
            {
                return this.m_doc_lastvieweddate;
            }
            set
            {
                this.m_doc_lastvieweddate = value;
                PropertyUpdate("doc_lastvieweddate", value, PropertyUpdateType.DateTime, PropertyUpdateTableType.Standard);
            }
        }
        public string LastViewedBy
        {
            get
            {
                return this.m_doc_lastviewedby;
            }
            set
            {
                this.m_doc_lastviewedby = Common.SafeString(value);
                PropertyUpdate("doc_lastviewedby", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public bool IsDirty
        {
            get
            {
                return this.m_doc_isdirty;
            }
            set
            {
                this.m_doc_isdirty = value;
                PropertyUpdate("doc_isdirty", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public bool IsDelivered
        {
            get
            {
                return this.m_doc_isdelivered;
            }
            set
            {
                this.m_doc_isdelivered = value;
                PropertyUpdate("doc_isdelivered", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public bool IsSigned
        {
            get
            {
                return this.m_doc_issigned;
            }
            set
            {
                this.m_doc_issigned = value;
                PropertyUpdate("doc_issigned", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public bool IsCertified
        {
            get
            {
                return this.m_doc_iscertified;
            }
            set
            {
                this.m_doc_iscertified = value;
                PropertyUpdate("doc_iscertified", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public DateTime DeliverDate
        {
            get
            {
                return this.m_doc_deliverdate;
            }
            set
            {
                this.m_doc_deliverdate = value;
                PropertyUpdate("doc_deliverdate", value, PropertyUpdateType.DateTime, PropertyUpdateTableType.Standard);
            }
        }
        public string DeliverBy
        {
            get
            {
                return this.m_doc_deliverby;
            }
            set
            {
                this.m_doc_deliverby = Common.SafeString(value);
                PropertyUpdate("doc_deliverby", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string DeliverTo
        {
            get
            {
                return this.m_doc_deliverto;
            }
            set
            {
                this.m_doc_deliverto = Common.SafeString(value);
                PropertyUpdate("doc_deliverto", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return this.m_doc_createddate;
            }
            set
            {
                this.m_doc_createddate = value;
            }
        }
        public string CreatedBy
        {
            get
            {
                return this.m_doc_createdby;
            }
            set
            {
                this.m_doc_createdby = Common.SafeString(value);
            }
        }
        public DateTime UpdatedDate
        {
            get
            {
                return this.m_doc_updateddate;
            }
            set
            {
                this.m_doc_updateddate = value;
            }
        }
        public string UpdatedBy
        {
            get
            {
                return this.m_doc_updatedby;
            }
            set
            {
                this.m_doc_updatedby = Common.SafeString(value);
            }
        }
        public bool Hidden
        {
            get
            {
                return this.m_doc_hidden;
            }
            set
            {
                this.m_doc_hidden = value;
                PropertyUpdate("doc_hidden", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public bool Deleted
        {
            get
            {
                return this.m_doc_deleted;
            }
            set
            {
                this.m_doc_deleted = value;
                PropertyUpdate("doc_deleted", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }

        #endregion Properties

        #region Constructors

        public Document(int SitId, int PagId, int DocId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_doc_id = DocId;
            this.GetById();
            this.m_autoupdate = AutoUpdate;
        }
        public Document(int SitId, int PagId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_autoupdate = AutoUpdate;
        }
        public Document(int SitId, int PagId, int DocId, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_doc_id = DocId;
            this.GetById();
        }
        public Document(int DocId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_doc_id = DocId;
            this.GetById();
            this.m_autoupdate = AutoUpdate;
        }
        public Document(int DocId, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_doc_id = DocId;
            this.GetById();
        }
        public Document(bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
        }
        public Document(String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
        }

        public Document(ObjectType ObjectType, int SitId, int PagId, int DocId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_doc_id = DocId;
            this.m_doc_type = ObjectType;
            this.GetById();
            this.m_autoupdate = AutoUpdate;
        }
        public Document(ObjectType ObjectType, int SitId, int PagId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_doc_type = ObjectType;
            this.m_autoupdate = AutoUpdate;
        }
        public Document(ObjectType ObjectType, int SitId, int PagId, int DocId, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_doc_id = DocId;
            this.m_doc_type = ObjectType;
            this.GetById();
        }
        public Document(ObjectType ObjectType, int SitId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_doc_type = ObjectType;
            this.m_autoupdate = AutoUpdate;
        }
        public Document(ObjectType ObjectType, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
            this.m_doc_type = ObjectType;
        }
        public Document(ObjectType ObjectType, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_doc_type = ObjectType;
        }

        ~Document()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            if (RXServer.Data.ActivateGC)
                GC.Collect();
        }
        #endregion Constructors

        #region Public Methods

        public void Update()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Update]";
            try
            {
                if (this.m_exists)
                {
                    if (this.FileStream is HttpPostedFile)
                    {
                        HttpPostedFile file = (HttpPostedFile)this.FileStream;
                        DirectoryInfo di = this.GenerateFileName(this.Id);
                        file.SaveAs(di.FullName + "\\" + System.IO.Path.GetFileName(file.FileName));
                        this.Path = di.FullName + "\\" + System.IO.Path.GetFileName(file.FileName);
                        this.Extension = System.IO.Path.GetExtension(file.FileName);
                        this.ContentSize = file.ContentLength;
                        this.ContentType = file.ContentType;
                        file = null;
                    }
                    else if (this.FileStream is UploadedFile)
                    {
                        UploadedFile file = (UploadedFile)this.FileStream;
                        DirectoryInfo di = this.GenerateFileName(this.Id);
                        file.SaveAs(di.FullName + "\\" + file.GetName());
                        this.Path = di.FullName + "\\" + file.GetName();
                        this.Extension = file.GetExtension();
                        this.ContentSize = file.ContentLength;
                        this.ContentType = file.ContentType;
                        file = null;
                    }
                    else if (this.FileStream is FileInfo)
                    {
                        FileInfo file = (FileInfo)this.FileStream;
                        DirectoryInfo di = this.GenerateFileName(this.Id);
                        file.CopyTo(di.FullName + "\\" + file.Name);
                        this.Path = di.FullName + "\\" + file.Name;
                        this.Extension = file.Extension;
                        this.ContentSize = Convert.ToInt32(file.Length);
                        this.ContentType = String.Empty;
                        file = null;
                    }

                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("UPDATE doc_documents SET ");
                    sSQL.Append("sit_id = " + this.m_sit_id.ToString() + ", ");
                    sSQL.Append("pag_id = " + this.m_pag_id.ToString() + ", ");
                    sSQL.Append("lng_id = " + this.m_lng_id.ToString() + ", ");
                    sSQL.Append("doc_parentid = " + this.m_doc_parentid.ToString() + ", ");
                    sSQL.Append("doc_type = " + Convert.ToString((Int32)this.m_doc_type) + ", ");
                    sSQL.Append("doc_order = " + this.m_doc_order.ToString() + ", ");
                    sSQL.Append("doc_title = '" + this.m_doc_title.ToString() + "', ");
                    sSQL.Append("doc_alias = '" + this.m_doc_alias.ToString() + "', ");
                    sSQL.Append("doc_description = '" + this.m_doc_description.ToString() + "', ");

                    sSQL.Append("doc_contenttype = '" + this.m_doc_contenttype.ToString() + "', ");
                    sSQL.Append("doc_contentsize = " + this.m_doc_contentsize.ToString() + ", ");
                    sSQL.Append("doc_version = " + this.m_doc_version.ToString() + ", ");
                    sSQL.Append("doc_charset = '" + this.m_doc_charset.ToString() + "', ");
                    sSQL.Append("doc_extension = '" + this.m_doc_extension.ToString() + "', ");
                    sSQL.Append("doc_path = '" + this.m_doc_path.ToString() + "', ");
                    sSQL.Append("doc_checkoutusrid = " + this.m_doc_checkoutusrid.ToString() + ", ");
                    sSQL.Append("doc_checkoutdate = '" + this.m_doc_checkoutdate.ToString() + "', ");
                    sSQL.Append("doc_checkoutexpiredate = '" + this.m_doc_checkoutexpiredate.ToString() + "', ");
                    sSQL.Append("doc_lastvieweddate = '" + this.m_doc_lastvieweddate.ToString() + "', ");
                    sSQL.Append("doc_lastviewedby = '" + this.m_doc_lastviewedby.ToString() + "', ");
                    sSQL.Append("doc_isdirty = " + Convert.ToString(!this.m_doc_isdirty ? "0" : "1") + ", ");
                    sSQL.Append("doc_isdelivered = " + Convert.ToString(!this.m_doc_isdelivered ? "0" : "1") + ", ");
                    sSQL.Append("doc_issigned = " + Convert.ToString(!this.m_doc_issigned ? "0" : "1") + ", ");
                    sSQL.Append("doc_iscertified = " + Convert.ToString(!this.m_doc_iscertified ? "0" : "1") + ", ");
                    sSQL.Append("doc_deliverdate = '" + this.m_doc_deliverdate.ToString() + "', ");
                    sSQL.Append("doc_deliverby = '" + this.m_doc_deliverby.ToString() + "', ");
                    sSQL.Append("doc_deliverto = '" + this.m_doc_deliverto.ToString() + "', ");

                    sSQL.Append("doc_createddate = '" + this.m_doc_createddate.ToString() + "', ");
                    sSQL.Append("doc_createdby = '" + this.m_doc_createdby.ToString() + "', ");
                    sSQL.Append("doc_updateddate = '" + this.m_doc_updateddate.ToString() + "', ");
                    sSQL.Append("doc_updatedby = '" + this.m_doc_updatedby.ToString() + "', ");
                    sSQL.Append("doc_hidden = " + Convert.ToString(!this.m_doc_hidden ? "0" : "1") + ", ");
                    sSQL.Append("doc_deleted = " + Convert.ToString(!this.m_doc_deleted ? "0" : "1") + " ");
                    sSQL.Append("WHERE doc_id = " + m_doc_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());

                    ResetThis();

                    this.PropertyUpdate("rol_id", this.m_doc_authorizededitroles, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
                    this.PropertyUpdate("grp_id", this.m_doc_authorizededitgroups, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);

                    if (this.m_doc_deleted)
                        DeleteRelations();

                }
                else
                {
                    throw new Exception("Can´t update a document that not exists");
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void ChangeOrderUp()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderUp]";
            try
            {
                this.m_doc_order = this.m_doc_order + 3;
                StringBuilder sSQL2 = new StringBuilder();
                sSQL2.Append("UPDATE doc_documents SET doc_order = " + this.m_doc_order.ToString() + " WHERE doc_id = " + this.m_doc_id.ToString());
                using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    oDo2.ExecuteNonQuery(sSQL2.ToString());
                SortAll();
                GetById();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void ChangeOrderDown()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderDown]";
            try
            {
                if (this.m_doc_order > 2)
                {
                    this.m_doc_order = this.m_doc_order - 3;
                    StringBuilder sSQL2 = new StringBuilder();
                    sSQL2.Append("UPDATE doc_documents SET doc_order = " + this.m_doc_order.ToString() + " WHERE doc_id = " + this.m_doc_id.ToString());
                    using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                        oDo2.ExecuteNonQuery(sSQL2.ToString());
                    SortAll();
                    GetById();
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_COLLECTION);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_ROLES);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_GROUPS);
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
                sSQL.Append("SELECT * FROM doc_documents WHERE doc_deleted = 0 ORDER BY sit_id, pag_id, doc_order");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                {
                    DataTable dt = oDo.GetDataTable(sSQL.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE doc_documents SET doc_order = " + Order.ToString() + " WHERE doc_id = " + dr["doc_id"].ToString());
                        using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
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
        private DirectoryInfo GenerateFileName(Int32 DocId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GenerateFileName]";
            try
            {
                String filename = HttpContext.Current.Server.MapPath("~/DocumentRoot/");

                DirectoryInfo di = new DirectoryInfo(filename);
                if (!di.Exists)
                    di.Create();

                if (this.m_sit_id > 0)
                {
                    filename += "\\sit" + this.m_sit_id.ToString();
                    di = new DirectoryInfo(filename);
                    if (!di.Exists)
                        di.Create();
                }
                if (this.m_pag_id > 0)
                {
                    filename += "\\pag" + this.m_pag_id.ToString();
                    di = new DirectoryInfo(filename);
                    if (!di.Exists)
                        di.Create();
                }
                filename += "\\doc" + DocId.ToString();
                di = new DirectoryInfo(filename);
                if (!di.Exists)
                    di.Create();

                return di;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return null;
            }
        }
        private void PropertyUpdate(string Column, object Value, PropertyUpdateType Type, PropertyUpdateTableType Table)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::PropertyUpdate]";
            try
            {
                if ((this.m_exists) && (this.m_autoupdate))
                {
                    StringBuilder sSQL = new StringBuilder();
                    if (Table == PropertyUpdateTableType.Standard)
                    {
                        sSQL.Append("UPDATE doc_documents SET ");
                        switch (Type)
                        {
                            case PropertyUpdateType.String: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                            case PropertyUpdateType.Int32: sSQL.Append(Column + " = " + Value.ToString() + " ");
                                break;
                            case PropertyUpdateType.Boolean: sSQL.Append(Column + " = " + Convert.ToInt32(Value).ToString() + " ");
                                break;
                            case PropertyUpdateType.DateTime: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                            default: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                        }
                        sSQL.Append("WHERE doc_id = " + m_doc_id.ToString());
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());
                        ResetThis();

                        if (this.m_doc_deleted)
                            DeleteRelations();
                    }
                    else
                    {
                        switch (Column.ToLower())
                        {
                            case "rol_id":
                                {
                                    sSQL = new StringBuilder();
                                    sSQL.Append("UPDATE adr_authorizeddocumentsroles SET adr_deleted = 1 WHERE doc_id = " + this.m_doc_id.ToString());
                                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                        oDo.ExecuteNonQuery(sSQL.ToString());

                                    foreach (Int32 r in (Int32[])Value)
                                    {

                                        sSQL = new StringBuilder();
                                        sSQL.Append("INSERT INTO adr_authorizeddocumentsroles (doc_id, rol_id, adr_createddate, adr_createdby, adr_updateddate, adr_updatedby, adr_hidden, adr_deleted) VALUES ( ");
                                        sSQL.Append(this.m_doc_id.ToString() + ", ");
                                        sSQL.Append(r.ToString() + ", ");
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("0, ");
                                        sSQL.Append("0)");
                                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                            oDo.ExecuteNonQuery(sSQL.ToString());
                                    }
                                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_ROLES + m_doc_id.ToString());
                                    break;
                                }
                            case "grp_id":
                                {
                                    sSQL = new StringBuilder();
                                    sSQL.Append("UPDATE adg_authorizeddocumentsgroups SET adg_deleted = 1 WHERE doc_id = " + this.m_doc_id.ToString());
                                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                        oDo.ExecuteNonQuery(sSQL.ToString());

                                    foreach (Int32 g in (Int32[])Value)
                                    {

                                        sSQL = new StringBuilder();
                                        sSQL.Append("INSERT INTO adg_authorizeddocumentsgroups (doc_id, grp_id, adg_createddate, adg_createdby, adg_updateddate, adg_updatedby, adg_hidden, adg_deleted) VALUES ( ");
                                        sSQL.Append(this.m_doc_id.ToString() + ", ");
                                        sSQL.Append(g.ToString() + ", ");
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("0, ");
                                        sSQL.Append("0)");
                                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                            oDo.ExecuteNonQuery(sSQL.ToString());
                                    }
                                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_DOCUMENT_GROUPS + m_doc_id.ToString());
                                    break;
                                }
                            case "doc_stream":
                                {
                                    if (this.m_doc_stream is HttpPostedFile)
                                    {
                                        HttpPostedFile file = (HttpPostedFile)this.m_doc_stream;
                                        DirectoryInfo di = this.GenerateFileName(this.m_doc_id);
                                        file.SaveAs(di.FullName + "\\" + System.IO.Path.GetFileName(file.FileName));
                                        this.m_doc_path = di.FullName + "\\" + System.IO.Path.GetFileName(file.FileName);
                                        this.m_doc_extension = System.IO.Path.GetExtension(file.FileName);
                                        this.m_doc_contentsize = file.ContentLength;
                                        this.m_doc_contenttype = file.ContentType;
                                        this.Update();
                                        file = null;
                                        break;
                                    }
                                    else if (this.m_doc_stream is UploadedFile)
                                    {
                                        UploadedFile file = (UploadedFile)this.m_doc_stream;
                                        DirectoryInfo di = this.GenerateFileName(this.m_doc_id);
                                        file.SaveAs(di.FullName + "\\" + file.GetName());
                                        this.m_doc_path = di.FullName + "\\" + file.GetName();
                                        this.m_doc_extension = file.GetExtension();
                                        this.m_doc_contentsize = file.ContentLength;
                                        this.m_doc_contenttype = file.ContentType;
                                        this.Update();
                                        file = null;
                                        break;
                                    }
                                    else if (this.m_doc_stream is FileInfo)
                                    {
                                        FileInfo file = (FileInfo)this.m_doc_stream;
                                        DirectoryInfo di = this.GenerateFileName(this.m_doc_id);
                                        file.CopyTo(di.FullName + "\\" + file.Name);
                                        this.m_doc_path = di.FullName + "\\" + file.Name;
                                        this.m_doc_extension = file.Extension;
                                        this.m_doc_contentsize = Convert.ToInt32(file.Length);
                                        this.m_doc_contenttype = String.Empty;
                                        this.Update();
                                        file = null;
                                        break;
                                    }
                                    else
                                        throw new FileNotFoundException();
                                }
                            default:
                                {

                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetById()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetById]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_DOCUMENT_ID + "::DocId" + m_doc_id.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM doc_documents WHERE doc_id = " + m_doc_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.m_sit_id = Convert.ToInt32(dr["sit_id"]);
                    this.m_pag_id = Convert.ToInt32(dr["pag_id"]);
                    this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                    this.m_doc_parentid = Convert.ToInt32(dr["doc_parentid"]);
                    this.m_doc_type = (ObjectType)Convert.ToInt32(dr["doc_type"]);
                    this.m_doc_order = Convert.ToInt32(dr["doc_order"]);
                    this.m_doc_title = Convert.ToString(dr["doc_title"]);
                    this.m_doc_alias = Convert.ToString(dr["doc_alias"]);
                    this.m_doc_description = Convert.ToString(dr["doc_description"]);
                    this.m_doc_authorizededitroles = this.GetAuthorizedEditRoles(Convert.ToInt32(dr["doc_id"]));
                    this.m_doc_authorizededitgroups = this.GetAuthorizedEditGroups(Convert.ToInt32(dr["doc_id"]));

                    this.m_doc_contenttype = Convert.ToString(dr["doc_contenttype"]);
                    this.m_doc_contentsize = Convert.ToInt32(dr["doc_contentsize"]);
                    this.m_doc_version = Convert.ToInt32(dr["doc_version"]);
                    this.m_doc_charset = Convert.ToString(dr["doc_charset"]);
                    this.m_doc_extension = Convert.ToString(dr["doc_extension"]);
                    this.m_doc_path = Convert.ToString(dr["doc_path"]);
                    this.m_doc_checkoutusrid = Convert.ToInt32(dr["doc_checkoutusrid"]);
                    this.m_doc_checkoutdate = Convert.ToDateTime(dr["doc_checkoutdate"]);
                    this.m_doc_checkoutexpiredate = Convert.ToDateTime(dr["doc_checkoutexpiredate"]);
                    this.m_doc_lastvieweddate = Convert.ToDateTime(dr["doc_lastvieweddate"]);
                    this.m_doc_lastviewedby = Convert.ToString(dr["doc_lastviewedby"]);
                    this.m_doc_isdirty = Convert.ToBoolean(dr["doc_isdirty"]);
                    this.m_doc_isdelivered = Convert.ToBoolean(dr["doc_isdelivered"]);
                    this.m_doc_issigned = Convert.ToBoolean(dr["doc_issigned"]);
                    this.m_doc_iscertified = Convert.ToBoolean(dr["doc_iscertified"]);
                    this.m_doc_deliverdate = Convert.ToDateTime(dr["doc_deliverdate"]);
                    this.m_doc_deliverby = Convert.ToString(dr["doc_deliverby"]);
                    this.m_doc_deliverto = Convert.ToString(dr["doc_deliverto"]);

                    this.m_doc_createddate = Convert.ToDateTime(dr["doc_createddate"]);
                    this.m_doc_createdby = Convert.ToString(dr["doc_createdby"]);
                    this.m_doc_updateddate = Convert.ToDateTime(dr["doc_updateddate"]);
                    this.m_doc_updatedby = Convert.ToString(dr["doc_updatedby"]);
                    this.m_doc_hidden = Convert.ToBoolean(dr["doc_hidden"]);
                    this.m_doc_deleted = Convert.ToBoolean(dr["doc_deleted"]);
                    this.m_exists = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetByAlias()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetByAlias]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_DOCUMENT_ALIAS + "::DocType" + Convert.ToString((Int32)this.m_doc_type) + "::PagId" + this.m_pag_id.ToString() + "::DocAlias" + m_doc_alias;
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    if (this.m_sit_id > 0 && this.m_pag_id > 0)
                        sSQL.Append("SELECT * FROM doc_documents WHERE doc_id = " + m_doc_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + Convert.ToString(this.m_doc_type != ObjectType.Undefined ? " AND doc_type = " + Convert.ToString((Int32)this.m_doc_type) : String.Empty) + " AND doc_alias = '" + m_doc_alias + "'");
                    else if (this.m_sit_id > 0 && this.m_pag_id == 0)
                        sSQL.Append("SELECT * FROM doc_documents WHERE doc_id = " + m_doc_id.ToString() + Convert.ToString(this.m_doc_type != ObjectType.Undefined ? " AND doc_type = " + Convert.ToString((Int32)this.m_doc_type) : String.Empty) + " AND doc_alias = '" + m_doc_alias + "'");
                    else
                        sSQL.Append("SELECT * FROM doc_documents WHERE doc_alias = '" + m_doc_alias + "'" + Convert.ToString(this.m_doc_type != ObjectType.Undefined ? " AND doc_type = " + Convert.ToString((Int32)this.m_doc_type) : String.Empty));
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.m_sit_id = Convert.ToInt32(dr["sit_id"]);
                    this.m_pag_id = Convert.ToInt32(dr["pag_id"]);
                    this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                    this.m_doc_parentid = Convert.ToInt32(dr["doc_parentid"]);
                    this.m_doc_type = (ObjectType)Convert.ToInt32(dr["doc_type"]);
                    this.m_doc_order = Convert.ToInt32(dr["doc_order"]);
                    this.m_doc_title = Convert.ToString(dr["doc_title"]);
                    this.m_doc_alias = Convert.ToString(dr["doc_alias"]);
                    this.m_doc_description = Convert.ToString(dr["doc_description"]);
                    this.m_doc_authorizededitroles = this.GetAuthorizedEditRoles(Convert.ToInt32(dr["doc_id"]));
                    this.m_doc_authorizededitgroups = this.GetAuthorizedEditGroups(Convert.ToInt32(dr["doc_id"]));

                    this.m_doc_contenttype = Convert.ToString(dr["doc_contenttype"]);
                    this.m_doc_contentsize = Convert.ToInt32(dr["doc_contentsize"]);
                    this.m_doc_version = Convert.ToInt32(dr["doc_version"]);
                    this.m_doc_charset = Convert.ToString(dr["doc_charset"]);
                    this.m_doc_extension = Convert.ToString(dr["doc_extension"]);
                    this.m_doc_path = Convert.ToString(dr["doc_path"]);
                    this.m_doc_checkoutusrid = Convert.ToInt32(dr["doc_checkoutusrid"]);
                    this.m_doc_checkoutdate = Convert.ToDateTime(dr["doc_checkoutdate"]);
                    this.m_doc_checkoutexpiredate = Convert.ToDateTime(dr["doc_checkoutexpiredate"]);
                    this.m_doc_lastvieweddate = Convert.ToDateTime(dr["doc_lastvieweddate"]);
                    this.m_doc_lastviewedby = Convert.ToString(dr["doc_lastviewedby"]);
                    this.m_doc_isdirty = Convert.ToBoolean(dr["doc_isdirty"]);
                    this.m_doc_isdelivered = Convert.ToBoolean(dr["doc_isdelivered"]);
                    this.m_doc_issigned = Convert.ToBoolean(dr["doc_issigned"]);
                    this.m_doc_iscertified = Convert.ToBoolean(dr["doc_iscertified"]);
                    this.m_doc_deliverdate = Convert.ToDateTime(dr["doc_deliverdate"]);
                    this.m_doc_deliverby = Convert.ToString(dr["doc_deliverby"]);
                    this.m_doc_deliverto = Convert.ToString(dr["doc_deliverto"]);

                    this.m_doc_createddate = Convert.ToDateTime(dr["doc_createddate"]);
                    this.m_doc_createdby = Convert.ToString(dr["doc_createdby"]);
                    this.m_doc_updateddate = Convert.ToDateTime(dr["doc_updateddate"]);
                    this.m_doc_updatedby = Convert.ToString(dr["doc_updatedby"]);
                    this.m_doc_hidden = Convert.ToBoolean(dr["doc_hidden"]);
                    this.m_doc_deleted = Convert.ToBoolean(dr["doc_deleted"]);
                    this.m_exists = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetParents()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetParents]";
            Int32[] Parents = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_DOCUMENT_ID + "::DocId" + m_doc_id.ToString() + "::Parents";
                if (HttpContext.Current != null) if (HttpContext.Current != null) Parents = (Int32[])HttpContext.Current.Cache[CacheItem];
                if (Parents == null)
                {
                    if (this.ParentId > 0)
                    {
                        Parents = new Int32[1];
                        Parents[0] = this.ParentId;
                        Parents = Generic.GrowArray(GetNextParent(Parents, this.ParentId), 0);
                        RXServer.Data.CacheInsert(CacheItem, Parents);
                    }
                }
                this.m_doc_parents = Parents;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private Int32[] GetNextParent(Int32[] Parents, Int32 DocId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetNextParent]";
            try
            {
                Document d = new Document(this.SitId, this.PagId, DocId, Data.DataSource, Data.ConnectionString);
                if (d.ParentId > 0)
                {
                    Parents = Generic.GrowArray(Parents, Parents.Length + 1);
                    Parents[Parents.Length - 1] = d.ParentId;
                    Parents = GetNextParent(Parents, d.ParentId);
                }
                return Parents;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return Parents;
            }
        }
        private Int32[] GetAuthorizedEditRoles(Int32 DocId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditRoles]";
            Int32[] Roles;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_DOCUMENT_ROLES + "::DocId" + DocId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM adr_authorizeddocumentsroles WHERE doc_id = " + DocId.ToString() + " AND adr_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Roles = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Roles[i] = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                return Roles;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Int32[] GetAuthorizedEditGroups(Int32 DocId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditGroups]";
            Int32[] Groups;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_DOCUMENT_GROUPS + "::DocId" + DocId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM adg_authorizeddocumentsgroups WHERE doc_id = " + DocId.ToString() + " AND adg_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Groups = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Groups[i] = Convert.ToInt32(dt.Rows[i]["grp_id"]);
                return Groups;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Boolean FindChildren()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::FindChildren]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_DOCUMENT_ID + "::DocId" + m_doc_id.ToString() + "::Children";
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT doc_id FROM doc_documents WHERE doc_parentid = " + m_doc_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }
        private void DeleteRelations()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DeleteRelations]";
            try
            {
                // Delete SiteCollection... 
                // not in use for Documents...

                // Delete PageCollection...
                // not in use for Documents...

                // Delete TaskCollection...
                // not in use for Documents...

                // Delete ModuleCollection... 
                // not in use for Documents...

                // Delete DocumentCollection...
                // not in use for Documents...

                // Delete ObjectCollection...
                // not in use for Documents...
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        #endregion Private Methods

    }
    #endregion public class Document

    #region public class ModuleCollection

    /// <summary>
    /// 
    /// </summary>
    public class ModuleCollection : IDisposable, IEnumerable
    {
        string CLASSNAME = "[Namespace::RXServer][Class::ModuleCollection]";

        #region DataHandler Variables

        private string m_datasource;
        private string m_connectionstring;

        #endregion DataHandler Variables

        #region Private Variables

        private bool m_autoupdate = false;
        private Int32 m_sit_id = 0;
        private Int32 m_pag_id = 0;
        private Int32 m_mod_parentid = 0;
        private Module m_module;
        private Module[] m_modules = new Module[0];
        private DataTable m_dtmodules;
        private Boolean m_refresh; 

        #endregion Private Variables

        #region Properties

        public IEnumerator GetEnumerator()
        {
            return new RXModuleEnum(this.m_modules);
        }
        /// <summary>
        /// 
        /// </summary>
        public Module this[Int32 index]
        {
            get
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Module]";
                try
                {
                    this.m_module = (Module)this.m_modules[index];
                    return this.m_module;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return new Module(this.m_sit_id, this.m_pag_id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Module[] Items
        {
            get
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Module]";
                try
                {
                    return this.m_modules;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, "");
                    return new Module[0];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Module GetModule(Int32 id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetModule]";
            try
            {
                foreach (Module m in this.m_modules)
                {
                    if (m.Id == id)
                    {
                        return m;
                    }
                }
                return new Module(this.m_sit_id, this.m_pag_id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Module(this.m_sit_id, this.m_pag_id, this.m_autoupdate, this.m_datasource, this.m_connectionstring);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Contains(Int32 id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            try
            {
                foreach (Module m in this.m_modules)
                {
                    if (m.Id == id)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Contains(string name)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Contains]";
            try
            {
                foreach (Module m in this.m_modules)
                {
                    if (m.Name.ToLower() == name.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        public bool Refresh
        {
            get
            {
                return this.m_refresh;
            }
            set
            {
                this.m_refresh = value;
            }
        }


        #endregion Properties

        #region Constructors

        public ModuleCollection(Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString) : this(SitId, PagId, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        public ModuleCollection(Int32 SitId, Int32 PagId, Int32 ParentId, bool AutoUpdate, String DataSource, String ConnectionString) : this(SitId, PagId, ParentId, AutoUpdate, DataSource, ConnectionString, true)
        {
        }
        
        public ModuleCollection(Int32 SitId, Int32 PagId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh; 
            GetAll();
        }
        public ModuleCollection(Int32 SitId, Int32 PagId, Int32 ParentId, bool AutoUpdate, String DataSource, String ConnectionString, Boolean Refresh)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_mod_parentid = ParentId;
            this.m_autoupdate = AutoUpdate;
            this.m_refresh = Refresh; 
            GetAll();
        }

        ~ModuleCollection()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            if (!this.Refresh)
                ResetThis();
            if (RXServer.Data.ActivateGC)
                GC.Collect();
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="module"></param>
        public void Add(Module module)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            try
            {
                this.Add(ref module);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void Add(ref Module module)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Add]";
            try
            {
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("INSERT INTO mod_modules (sit_id, pag_id, lng_id, mde_id, mod_parentid, mod_order, ");
                sSQL.Append("mod_title, mod_alias, mod_description, mod_pane, mod_cachetime, mod_theme, mod_skin, mod_editsrc, mod_secure, ");
                sSQL.Append("mod_allpages, mod_createddate, mod_createdby, mod_updateddate, mod_updatedby, ");
                sSQL.Append("mod_hidden, mod_deleted) VALUES (");
                sSQL.Append(module.SitId + ", ");
                sSQL.Append(module.PagId + ", ");
                sSQL.Append(module.Language + ", ");
                sSQL.Append(module.ModuleDefinitionId + ", ");
                sSQL.Append(module.ParentId + ", ");
                sSQL.Append(module.Order + ", ");
                sSQL.Append("'" + module.Name + "', ");
                sSQL.Append("'" + module.Alias + "', ");
                sSQL.Append("'" + module.Description + "', ");
                sSQL.Append("'" + module.Pane + "', ");
                sSQL.Append(module.CacheTimeMilliSeconds + ", ");
                sSQL.Append("'" + module.Theme + "', ");
                sSQL.Append("'" + module.Skin + "', ");
                sSQL.Append("'" + module.EditSource + "', ");
                sSQL.Append(Convert.ToInt32(module.Secure).ToString() + ", ");
                sSQL.Append(Convert.ToInt32(module.AllPages).ToString() + ", ");
                sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                sSQL.Append("0, ");
                sSQL.Append("0)");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                {
                    oDo.ExecuteNonQuery(sSQL.ToString());
                    module.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                }

                foreach (Int32 r in module.AuthorizedEditRoles)
                {
                    sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO amr_authorizedmodulesroles (mod_id, rol_id, amr_createddate, amr_createdby, amr_updateddate, amr_updatedby, amr_hidden, amr_deleted) VALUES ( ");
                    sSQL.Append(module.Id.ToString() + ", ");
                    sSQL.Append(r.ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());
                }

                foreach (Int32 g in module.AuthorizedEditGroups)
                {
                    sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO amg_authorizedmodulesgroups (mod_id, grp_id, amg_createddate, amg_createdby, amg_updateddate, amg_updatedby, amg_hidden, amg_deleted) VALUES ( ");
                    sSQL.Append(module.Id.ToString() + ", ");
                    sSQL.Append(g.ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());
                }

                SortAll();
                GetAll();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="module"></param>
        public void Remove(Module module)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            try
            {
                Remove(module.Id);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Remove(Int32 id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Remove]";
            try
            {
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("UPDATE mod_modules SET mod_deleted = 1 ");
                sSQL.Append("WHERE mod_id = " + id.ToString());
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                    oDo.ExecuteNonQuery(sSQL.ToString());
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_COLLECTION);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_ID + id.ToString());
                GetAll();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Clear]";
            try
            {
                this.m_modules = null;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int32 Count()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Count]";
            try
            {
                return this.m_modules.Length;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return 0;
            }
        }

        public DataTable DataTable()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            try
            {
                return m_dtmodules;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new DataTable();
            }
        }

        public DataTable DataTable(ModuleSortField SortField, SortOrder SortOrder)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DataTable]";
            try
            {
                DataView v = new DataView(m_dtmodules);
                v.Sort = RetriveSortField(SortField) + Convert.ToString((Int32)SortOrder == 1 ? String.Empty : " DESC");
                return v.ToTable();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new DataTable();
            }
        }


        #endregion Public Methods

        #region Private Methods

        private void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_COLLECTION);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_ROLES);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_GROUPS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_SOURCE);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private String RetriveSortField(ModuleSortField SortField)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::RetriveSortField]";
            try
            {

                if ((Int32)SortField == 1) return "mod_id";
                if ((Int32)SortField == 2) return "sit_id";
                if ((Int32)SortField == 3) return "pag_id";
                if ((Int32)SortField == 4) return "mde_id";
                if ((Int32)SortField == 5) return "lng_id";
                if ((Int32)SortField == 6) return "mod_order";
                if ((Int32)SortField == 7) return "mod_parentid";
                if ((Int32)SortField == 8) return "mod_title";
                if ((Int32)SortField == 9) return "mod_alias";
                if ((Int32)SortField == 10) return "mod_description";
                if ((Int32)SortField == 11) return "mod_src";
                if ((Int32)SortField == 12) return "mod_pane";
                if ((Int32)SortField == 13) return "mod_theme";
                if ((Int32)SortField == 14) return "mod_skin";
                if ((Int32)SortField == 15) return "mod_cachetime";
                if ((Int32)SortField == 16) return "mod_editsrc";
                if ((Int32)SortField == 17) return "mod_secure";
                if ((Int32)SortField == 18) return "mod_allpages";
                if ((Int32)SortField == 19) return "mod_createddate";
                if ((Int32)SortField == 20) return "mod_createdby";
                if ((Int32)SortField == 21) return "mod_updateddate";
                if ((Int32)SortField == 22) return "mod_updatedby";
                return String.Empty;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return String.Empty;
            }
        }
        private void GetAll()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAll]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_MODULE_COLLECTION + "::SitId" + this.m_sit_id.ToString() + "::PagId" + this.m_pag_id.ToString() + "::ParentId" + this.m_mod_parentid.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM mod_modules WHERE sit_id = " + this.m_sit_id.ToString() + " AND pag_id = " + this.m_pag_id.ToString() + " AND mod_parentid = " + this.m_mod_parentid.ToString() + " AND mod_deleted = 0 ORDER BY mod_order");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    this.m_dtmodules = dt;
                    Int32 index = 0;
                    this.m_modules = new Module[dt.Rows.Count];
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.m_modules[index] = new Module(this.m_autoupdate, this.m_datasource, this.m_connectionstring);
                        this.m_modules[index].Id = Convert.ToInt32(dr["mod_id"]);
                        this.m_modules[index].SitId = Convert.ToInt32(dr["sit_id"]);
                        this.m_modules[index].PagId = Convert.ToInt32(dr["pag_id"]);
                        this.m_modules[index].Language = Convert.ToInt32(dr["lng_id"]);
                        this.m_modules[index].ModuleDefinitionId = Convert.ToInt32(dr["mde_id"]);
                        this.m_modules[index].ParentId = Convert.ToInt32(dr["mod_parentid"]);
                        this.m_modules[index].Order = Convert.ToInt32(dr["mod_order"]);
                        this.m_modules[index].Name = Convert.ToString(dr["mod_title"]);
                        this.m_modules[index].Alias = Convert.ToString(dr["mod_alias"]);
                        this.m_modules[index].Description = Convert.ToString(dr["mod_description"]);
                        this.m_modules[index].Src = this.GetModuleSource(Convert.ToInt32(dr["mde_id"]));
                        this.m_modules[index].Pane = Convert.ToString(dr["mod_pane"]);
                        this.m_modules[index].AuthorizedEditRoles = this.GetAuthorizedEditRoles((Int32)dr["mod_id"]);
                        this.m_modules[index].AuthorizedEditGroups = this.GetAuthorizedEditGroups((Int32)dr["mod_id"]);
                        this.m_modules[index].CacheTimeMilliSeconds = Convert.ToInt32(dr["mod_cachetime"]);
                        this.m_modules[index].EditSource = Convert.ToString(dr["mod_editsrc"]);
                        this.m_modules[index].Width = Convert.ToString(dr["mod_width"]);
                        this.m_modules[index].Height = Convert.ToString(dr["mod_height"]);
                        this.m_modules[index].EditWidth = Convert.ToString(dr["mod_editwidth"]);
                        this.m_modules[index].EditHeight = Convert.ToString(dr["mod_editheight"]);
                        this.m_modules[index].Theme = Convert.ToString(dr["mod_theme"]);
                        this.m_modules[index].Skin = Convert.ToString(dr["mod_skin"]);
                        this.m_modules[index].Secure = Convert.ToBoolean(dr["mod_secure"]);
                        this.m_modules[index].AllPages = Convert.ToBoolean(dr["mod_allpages"]);
                        this.m_modules[index].CreatedDate = Convert.ToDateTime(dr["mod_createddate"]);
                        this.m_modules[index].CreatedBy = Convert.ToString(dr["mod_createdby"]);
                        this.m_modules[index].UpdatedDate = Convert.ToDateTime(dr["mod_updateddate"]);
                        this.m_modules[index].UpdatedBy = Convert.ToString(dr["mod_updatedby"]);
                        this.m_modules[index].Hidden = Convert.ToBoolean(dr["mod_hidden"]);
                        this.m_modules[index].Deleted = Convert.ToBoolean(dr["mod_deleted"]);
                        this.m_modules[index].Exist = true;
                        index++;
                    }
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
                sSQL.Append("SELECT * FROM mod_modules WHERE mod_deleted = 0 ORDER BY sit_id, pag_id, mod_pane, mod_order");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                {
                    DataTable dt = oDo.GetDataTable(sSQL.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE mod_modules SET mod_order = " + Order.ToString() + " WHERE mod_id = " + dr["mod_id"].ToString());
                        using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
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
        private Int32[] GetAuthorizedEditRoles(Int32 ModId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditRoles]";
            Int32[] Roles;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_MODULE_ROLES + "::ModId" + ModId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM amr_authorizedmodulesroles WHERE mod_id = " + ModId.ToString() + " AND amr_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Roles = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Roles[i] = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                return Roles;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Int32[] GetAuthorizedEditGroups(Int32 ModId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditGroups]";
            Int32[] Groups;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_MODULE_GROUPS + "::ModId" + ModId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM amg_authorizedmodulesgroups WHERE mod_id = " + ModId.ToString() + " AND amg_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Groups = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Groups[i] = Convert.ToInt32(dt.Rows[i]["grp_id"]);
                return Groups;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private String GetModuleSource(Int32 MdeId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetModuleSource]";
            DataTable dt;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_MODULE_SOURCE + "::MdeId" + MdeId.ToString();
                dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM mde_moduledefinitions WHERE mde_id = " + MdeId.ToString() + " AND mde_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count < 1)
                    return String.Empty;
                return dt.Rows[0]["mde_src"].ToString();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return String.Empty;
            }
        }

        #endregion Private Methods

    }
    #endregion public class ModuleCollection

    #region public class Module

    public class Module : IDisposable
    {
        string CLASSNAME = "[Namespace::RXServer][Class::Module]";

        #region DataHandler Variables

        private String m_datasource;
        private String m_connectionstring;

        #endregion DataHandler Variables

        #region Private Variables

        private bool m_exists = false;
        private bool m_autoupdate = false;
        private bool m_refresh = true;

        private Int32 m_mod_id = 0;
        private Int32 m_sit_id = 0;
        private Int32 m_pag_id = 0;
        private Int32 m_lng_id = 0;
        private Int32 m_mde_id = 0;
        private Int32 m_mod_parentid = 0;
        private Int32[] m_mod_parents = new Int32[0];
        private Int32 m_mod_order = 0;
        private String m_mod_title = String.Empty;
        private String m_mod_alias = String.Empty;
        private String m_mod_description = String.Empty;
        private String m_mod_src = String.Empty;
        private String m_mod_pane = String.Empty;
        private Int32[] m_mod_authorizededitroles = new Int32[0];
        private Int32[] m_mod_authorizededitgroups = new Int32[0];
        private Int32 m_mod_cachetime = 0;
        private String m_mod_theme = String.Empty;
        private String m_mod_skin = String.Empty;
        private String m_mod_editsrc = String.Empty;
        private String m_mod_width = String.Empty;
        private String m_mod_height = String.Empty;
        private String m_mod_editwidth = String.Empty;
        private String m_mod_editheight = String.Empty;
        private bool m_mod_secure = false;
        private bool m_mod_allpages = false;
        private DateTime m_mod_createddate = DateTime.Now;
        private String m_mod_createdby = String.Empty;
        private DateTime m_mod_updateddate = DateTime.Now;
        private String m_mod_updatedby = String.Empty;
        private bool m_mod_hidden = false;
        private bool m_mod_deleted = false;

        private bool m_mod_haschildren = false;
        private bool m_mod_hasparent = false;

        #endregion Private Variables

        #region Properties

        public bool AutoUpdate
        {
            set
            {
                this.m_autoupdate = value;
            }
        }
        public bool Exist
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
        public bool HasChildren
        {
            get
            {
                this.m_mod_haschildren = this.FindChildren();
                return this.m_mod_haschildren;
            }
        }
        public bool HasParent
        {
            get
            {
                this.m_mod_hasparent = this.m_mod_parentid == 0 ? false : true;
                return this.m_mod_hasparent;
            }
        }
        public int SitId
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
        public int PagId
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
        public int Id
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
        public int ParentId
        {
            get
            {
                return this.m_mod_parentid;
            }
            set
            {
                this.m_mod_parentid = value;
            }
        }
        public Int32[] Parents
        {
            get
            {
                GetParents();
                return this.m_mod_parents;
            }
        }
        public int Language
        {
            get
            {
                return this.m_lng_id;
            }
            set
            {
                this.m_lng_id = value;
                PropertyUpdate("lng_id", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public int ModuleDefinitionId
        {
            get
            {
                return this.m_mde_id;
            }
            set
            {
                this.m_mde_id = value;
                PropertyUpdate("mde_id", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public int Order
        {
            get
            {
                return this.m_mod_order;
            }
            set
            {
                this.m_mod_order = value;
                PropertyUpdate("mod_order", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public string Alias
        {
            get
            {
                return this.m_mod_alias;
            }
            set
            {
                this.m_mod_alias = Common.SafeString(value);
                PropertyUpdate("mod_alias", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Name
        {
            get
            {
                return this.m_mod_title;
            }
            set
            {
                this.m_mod_title = Common.SafeString(value);
                PropertyUpdate("mod_title", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Description
        {
            get
            {
                return this.m_mod_description;
            }
            set
            {
                this.m_mod_description = Common.SafeString(value);
                PropertyUpdate("mod_description", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Src
        {
            get
            {
                return this.m_mod_src;
            }
            set
            {
                this.m_mod_src = Common.SafeString(value);
            }
        }
        public string Pane
        {
            get
            {
                return this.m_mod_pane;
            }
            set
            {
                this.m_mod_pane = Common.SafeString(value);
                PropertyUpdate("mod_pane", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public Int32[] AuthorizedEditRoles
        {
            get
            {
                return this.m_mod_authorizededitroles;
            }
            set
            {
                this.m_mod_authorizededitroles = value;
                PropertyUpdate("rol_id", value, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
            }
        }
        public Int32[] AuthorizedEditGroups
        {
            get
            {
                return this.m_mod_authorizededitgroups;
            }
            set
            {
                this.m_mod_authorizededitgroups = value;
                PropertyUpdate("grp_id", value, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
            }
        }
        public int CacheTimeMilliSeconds
        {
            get
            {
                return this.m_mod_cachetime;
            }
            set
            {
                this.m_mod_cachetime = value;
                PropertyUpdate("mod_cachetime", value, PropertyUpdateType.Int32, PropertyUpdateTableType.Standard);
            }
        }
        public String Theme
        {
            get
            {
                return this.m_mod_theme;
            }
            set
            {
                this.m_mod_theme = Common.SafeString(value);
                PropertyUpdate("mod_theme", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public String Skin
        {
            get
            {
                return this.m_mod_skin;
            }
            set
            {
                this.m_mod_skin = Common.SafeString(value);
                PropertyUpdate("mod_skin", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string EditSource
        {
            get
            {
                return this.m_mod_editsrc;
            }
            set
            {
                this.m_mod_editsrc = Common.SafeString(value);
                PropertyUpdate("mod_editsrc", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Width
        {
            get
            {
                return this.m_mod_width;
            }
            set
            {
                this.m_mod_width = Common.SafeString(value);
                PropertyUpdate("mod_width", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string Height
        {
            get
            {
                return this.m_mod_height;
            }
            set
            {
                this.m_mod_height = Common.SafeString(value);
                PropertyUpdate("mod_height", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string EditWidth
        {
            get
            {
                return this.m_mod_editwidth;
            }
            set
            {
                this.m_mod_editwidth = Common.SafeString(value);
                PropertyUpdate("mod_editwidth", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public string EditHeight
        {
            get
            {
                return this.m_mod_editheight;
            }
            set
            {
                this.m_mod_editheight = Common.SafeString(value);
                PropertyUpdate("mod_editheight", value, PropertyUpdateType.String, PropertyUpdateTableType.Standard);
            }
        }
        public bool Secure
        {
            get
            {
                return this.m_mod_secure;
            }
            set
            {
                this.m_mod_secure = value;
                PropertyUpdate("mod_secure", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public bool AllPages
        {
            get
            {
                return this.m_mod_allpages;
            }
            set
            {
                this.m_mod_allpages = value;
                PropertyUpdate("mod_allpages", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return this.m_mod_createddate;
            }
            set
            {
                this.m_mod_createddate = value;
            }
        }
        public string CreatedBy
        {
            get
            {
                return this.m_mod_createdby;
            }
            set
            {
                this.m_mod_createdby = Common.SafeString(value);
            }
        }
        public DateTime UpdatedDate
        {
            get
            {
                return this.m_mod_updateddate;
            }
            set
            {
                this.m_mod_updateddate = value;
            }
        }
        public string UpdatedBy
        {
            get
            {
                return this.m_mod_updatedby;
            }
            set
            {
                this.m_mod_updatedby = Common.SafeString(value);
            }
        }
        public bool Hidden
        {
            get
            {
                return this.m_mod_hidden;
            }
            set
            {
                this.m_mod_hidden = value;
                PropertyUpdate("mod_hidden", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public bool Deleted
        {
            get
            {
                return this.m_mod_deleted;
            }
            set
            {
                this.m_mod_deleted = value;
                PropertyUpdate("mod_deleted", value, PropertyUpdateType.Boolean, PropertyUpdateTableType.Standard);
            }
        }
        public bool Refresh
        {
            get
            {
                return this.m_refresh;
            }
            set
            {
                this.m_refresh = value;
            }
        }

        #endregion Properties

        #region Constructors

        public Module(int SitId, int PagId, int ModId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_mod_id = ModId;
            this.GetById();
            this.m_autoupdate = AutoUpdate;
        }
        public Module(int SitId, int PagId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_autoupdate = AutoUpdate;
        }
        public Module(int SitId, int PagId, int ModId, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_sit_id = SitId;
            this.m_pag_id = PagId;
            this.m_mod_id = ModId;
            this.GetById();
        }
        public Module(int ModId, bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_mod_id = ModId;
            this.GetById();
            this.m_autoupdate = AutoUpdate;
        }
        public Module(int ModId, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_mod_id = ModId;
            this.GetById();
        }
        public Module(bool AutoUpdate, String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
            this.m_autoupdate = AutoUpdate;
        }
        public Module(String DataSource, String ConnectionString)
        {
            this.m_datasource = DataSource;
            this.m_connectionstring = ConnectionString;
        }

        ~Module()
        {
            xFinalize();
        }
        public void Dispose()
        {
            xFinalize();
            System.GC.SuppressFinalize(this);
        }
        private void xFinalize()
        {
            if (RXServer.Data.ActivateGC)
                GC.Collect();
        }
        #endregion Constructors

        #region Public Methods

        public void Update()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Update]";
            try
            {
                if (this.m_exists)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("UPDATE mod_modules SET ");
                    sSQL.Append("sit_id = " + this.m_sit_id.ToString() + ", ");
                    sSQL.Append("pag_id = " + this.m_pag_id.ToString() + ", ");
                    sSQL.Append("lng_id = " + this.m_lng_id.ToString() + ", ");
                    sSQL.Append("mde_id = " + this.m_mde_id.ToString() + ", ");
                    sSQL.Append("mod_parentid = " + this.m_mod_parentid.ToString() + ", ");
                    sSQL.Append("mod_order = " + this.m_mod_order.ToString() + ", ");
                    sSQL.Append("mod_title = '" + this.m_mod_title.ToString() + "', ");
                    sSQL.Append("mod_alias = '" + this.m_mod_alias.ToString() + "', ");
                    sSQL.Append("mod_description = '" + this.m_mod_description.ToString() + "', ");
                    sSQL.Append("mod_pane = '" + this.m_mod_pane.ToString() + "', ");
                    sSQL.Append("mod_cachetime = " + this.m_mod_cachetime.ToString() + ", ");
                    sSQL.Append("mod_theme = '" + this.m_mod_theme.ToString() + "', ");
                    sSQL.Append("mod_skin = '" + this.m_mod_skin.ToString() + "', ");
                    sSQL.Append("mod_editsrc = '" + this.m_mod_editsrc.ToString() + "', ");
                    sSQL.Append("mod_width = '" + this.m_mod_width.ToString() + "', ");
                    sSQL.Append("mod_height = '" + this.m_mod_height.ToString() + "', ");
                    sSQL.Append("mod_editwidth = '" + this.m_mod_editwidth.ToString() + "', ");
                    sSQL.Append("mod_editheight = '" + this.m_mod_editheight.ToString() + "', ");
                    sSQL.Append("mod_secure = " + Convert.ToInt32(this.m_mod_secure).ToString() + ", ");
                    sSQL.Append("mod_allpages = " + Convert.ToInt32(this.m_mod_allpages).ToString() + ", ");
                    sSQL.Append("mod_createddate = '" + this.m_mod_createddate.ToString() + "', ");
                    sSQL.Append("mod_createdby = '" + this.m_mod_createdby.ToString() + "', ");
                    sSQL.Append("mod_updateddate = '" + this.m_mod_updateddate.ToString() + "', ");
                    sSQL.Append("mod_updatedby = '" + this.m_mod_updatedby.ToString() + "', ");
                    sSQL.Append("mod_hidden = " + Convert.ToString(!this.m_mod_hidden ? "0" : "1") + ", ");
                    sSQL.Append("mod_deleted = " + Convert.ToString(!this.m_mod_deleted ? "0" : "1") + " ");
                    sSQL.Append("WHERE mod_id = " + m_mod_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                        oDo.ExecuteNonQuery(sSQL.ToString());

                    ResetThis();

                    this.PropertyUpdate("rol_id", this.m_mod_authorizededitroles, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);
                    this.PropertyUpdate("grp_id", this.m_mod_authorizededitgroups, PropertyUpdateType.Int32Array, PropertyUpdateTableType.Settings);

                    if (this.m_mod_deleted)
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
        public virtual void Save()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Save]";
            try
            {
                if (!this.m_exists)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("INSERT INTO mod_modules (sit_id, pag_id, lng_id, mde_id, mod_parentid, mod_order, ");
                    sSQL.Append("mod_title, mod_alias, mod_description, mod_pane, mod_cachetime, mod_theme, mod_skin, mod_editsrc, mod_secure, ");
                    sSQL.Append("mod_allpages, mod_createddate, mod_createdby, mod_updateddate, mod_updatedby, ");
                    sSQL.Append("mod_hidden, mod_deleted) VALUES (");
                    sSQL.Append(this.SitId + ", ");
                    sSQL.Append(this.PagId + ", ");
                    sSQL.Append(this.Language + ", ");
                    sSQL.Append(this.ModuleDefinitionId + ", ");
                    sSQL.Append(this.ParentId + ", ");
                    sSQL.Append(this.Order + ", ");
                    sSQL.Append("'" + this.Name + "', ");
                    sSQL.Append("'" + this.Alias + "', ");
                    sSQL.Append("'" + this.Description + "', ");
                    sSQL.Append("'" + this.Pane + "', ");
                    sSQL.Append(this.CacheTimeMilliSeconds + ", ");
                    sSQL.Append("'" + this.Theme + "', ");
                    sSQL.Append("'" + this.Skin + "', ");
                    sSQL.Append("'" + this.EditSource + "', ");
                    sSQL.Append(Convert.ToInt32(this.Secure).ToString() + ", ");
                    sSQL.Append(Convert.ToInt32(this.AllPages).ToString() + ", ");
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                    if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                    sSQL.Append("0, ");
                    sSQL.Append("0)");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                    {
                        oDo.ExecuteNonQuery(sSQL.ToString());
                        this.Id = Convert.ToInt32(oDo.GetDataTable("SELECT @@Identity").Rows[0][0]);
                    }

                    foreach (Int32 r in this.AuthorizedEditRoles)
                    {
                        sSQL = new StringBuilder();
                        sSQL.Append("INSERT INTO amr_authorizedmodulesroles (mod_id, rol_id, amr_createddate, amr_createdby, amr_updateddate, amr_updatedby, amr_hidden, amr_deleted) VALUES ( ");
                        sSQL.Append(this.Id.ToString() + ", ");
                        sSQL.Append(r.ToString() + ", ");
                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("0, ");
                        sSQL.Append("0)");
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());
                    }

                    foreach (Int32 g in this.AuthorizedEditGroups)
                    {
                        sSQL = new StringBuilder();
                        sSQL.Append("INSERT INTO amg_authorizedmodulesgroups (mod_id, grp_id, amg_createddate, amg_createdby, amg_updateddate, amg_updatedby, amg_hidden, amg_deleted) VALUES ( ");
                        sSQL.Append(this.Id.ToString() + ", ");
                        sSQL.Append(g.ToString() + ", ");
                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                        sSQL.Append("0, ");
                        sSQL.Append("0)");
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());
                    }

                    if (this.m_refresh)
                    {
                        ResetThis();
                        SortAll();
                    }
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
        public void ChangeOrderUp()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderUp]";
            try
            {
                this.m_mod_order = this.m_mod_order + 3;
                StringBuilder sSQL2 = new StringBuilder();
                sSQL2.Append("UPDATE mod_modules SET mod_order = " + this.m_mod_order.ToString() + " WHERE mod_id = " + this.m_mod_id.ToString());
                using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    oDo2.ExecuteNonQuery(sSQL2.ToString());
                SortAll();
                GetById();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        public void ChangeOrderDown()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ChangeOrderDown]";
            try
            {
                if (this.m_mod_order > 2)
                {
                    this.m_mod_order = this.m_mod_order - 3;
                    StringBuilder sSQL2 = new StringBuilder();
                    sSQL2.Append("UPDATE mod_modules SET mod_order = " + this.m_mod_order.ToString() + " WHERE mod_id = " + this.m_mod_id.ToString());
                    using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                        oDo2.ExecuteNonQuery(sSQL2.ToString());
                    SortAll();
                    GetById();
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void ResetThis()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ResetThis]";
            try
            {
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_ID);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_ALIAS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_COLLECTION);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_ROLES);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_GROUPS);
                RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_SOURCE);
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
                sSQL.Append("SELECT * FROM mod_modules WHERE mod_deleted = 0 ORDER BY sit_id, pag_id, mod_pane, mod_order");
                using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                {
                    DataTable dt = oDo.GetDataTable(sSQL.ToString());
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringBuilder sSQL2 = new StringBuilder();
                        sSQL2.Append("UPDATE mod_modules SET mod_order = " + Order.ToString() + " WHERE mod_id = " + dr["mod_id"].ToString());
                        using (iCDataObject oDo2 = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
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
        private void PropertyUpdate(string Column, object Value, PropertyUpdateType Type, PropertyUpdateTableType Table)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::PropertyUpdate]";
            try
            {
                if ((this.m_exists) && (this.m_autoupdate))
                {
                    StringBuilder sSQL = new StringBuilder();
                    if (Table == PropertyUpdateTableType.Standard)
                    {
                        sSQL.Append("UPDATE mod_modules SET ");
                        switch (Type)
                        {
                            case PropertyUpdateType.String: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                            case PropertyUpdateType.Int32: sSQL.Append(Column + " = " + Value.ToString() + " ");
                                break;
                            case PropertyUpdateType.Boolean: sSQL.Append(Column + " = " + Convert.ToInt32(Value).ToString() + " ");
                                break;
                            case PropertyUpdateType.DateTime: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                            default: sSQL.Append(Column + " = '" + Value.ToString() + "' ");
                                break;
                        }
                        sSQL.Append("WHERE mod_id = " + m_mod_id.ToString());
                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                            oDo.ExecuteNonQuery(sSQL.ToString());
                        ResetThis();

                        if (this.m_mod_deleted)
                            DeleteRelations();
                    }
                    else
                    {
                        switch (Column.ToLower())
                        {
                            case "rol_id":
                                {
                                    sSQL = new StringBuilder();
                                    sSQL.Append("UPDATE amr_authorizedmodulesroles SET amr_deleted = 1 WHERE mod_id = " + this.m_mod_id.ToString());
                                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                        oDo.ExecuteNonQuery(sSQL.ToString());

                                    foreach (Int32 r in (Int32[])Value)
                                    {

                                        sSQL = new StringBuilder();
                                        sSQL.Append("INSERT INTO amr_authorizedmodulesroles (mod_id, rol_id, amr_createddate, amr_createdby, amr_updateddate, amr_updatedby, amr_hidden, amr_deleted) VALUES ( ");
                                        sSQL.Append(this.m_mod_id.ToString() + ", ");
                                        sSQL.Append(r.ToString() + ", ");
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("0, ");
                                        sSQL.Append("0)");
                                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                            oDo.ExecuteNonQuery(sSQL.ToString());
                                    }
                                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_ROLES + m_mod_id.ToString());
                                    break;
                                }
                            case "grp_id":
                                {
                                    sSQL = new StringBuilder();
                                    sSQL.Append("UPDATE amg_authorizedmodulesgroups SET amg_deleted = 1 WHERE mod_id = " + this.m_mod_id.ToString());
                                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                        oDo.ExecuteNonQuery(sSQL.ToString());

                                    foreach (Int32 g in (Int32[])Value)
                                    {

                                        sSQL = new StringBuilder();
                                        sSQL.Append("INSERT INTO amg_authorizedmodulesgroups (mod_id, grp_id, amg_createddate, amg_createdby, amg_updateddate, amg_updatedby, amg_hidden, amg_deleted) VALUES ( ");
                                        sSQL.Append(this.m_mod_id.ToString() + ", ");
                                        sSQL.Append(g.ToString() + ", ");
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("'" + DateTime.Now.ToString() + "', ");
                                        if (HttpContext.Current != null) { sSQL.Append("'" + RXServer.Authentication.User.Identity.Name + "', "); } else { sSQL.Append("'NoIdentity', "); }
                                        sSQL.Append("0, ");
                                        sSQL.Append("0)");
                                        using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, true))
                                            oDo.ExecuteNonQuery(sSQL.ToString());
                                    }
                                    RXServer.Data.ResetCache(RXServer.Data.CACHEITEM_MODULE_GROUPS + m_mod_id.ToString());
                                    break;
                                }
                            default:
                                {

                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetById()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetById]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_MODULE_ID + "::ModId" + m_mod_id.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM mod_modules WHERE mod_id = " + m_mod_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.m_sit_id = Convert.ToInt32(dr["sit_id"]);
                    this.m_pag_id = Convert.ToInt32(dr["pag_id"]);
                    this.m_lng_id = Convert.ToInt32(dr["lng_id"]);
                    this.m_mde_id = Convert.ToInt32(dr["mde_id"]);
                    this.m_mod_parentid = Convert.ToInt32(dr["mod_parentid"]);
                    this.m_mod_order = Convert.ToInt32(dr["mod_order"]);
                    this.m_mod_title = Convert.ToString(dr["mod_title"]);
                    this.m_mod_alias = Convert.ToString(dr["mod_alias"]);
                    this.m_mod_description = Convert.ToString(dr["mod_description"]);
                    this.m_mod_src = this.GetModuleSource(Convert.ToInt32(dr["mde_id"]));
                    this.m_mod_pane = Convert.ToString(dr["mod_pane"]);
                    this.m_mod_authorizededitroles = this.GetAuthorizedEditRoles(Convert.ToInt32(dr["mod_id"]));
                    this.m_mod_authorizededitgroups = this.GetAuthorizedEditGroups(Convert.ToInt32(dr["mod_id"]));
                    this.m_mod_cachetime = Convert.ToInt32(dr["mod_cachetime"]);
                    this.m_mod_theme = Convert.ToString(dr["mod_theme"]);
                    this.m_mod_skin = Convert.ToString(dr["mod_skin"]);
                    this.m_mod_editsrc = Convert.ToString(dr["mod_editsrc"]);
                    this.m_mod_width = Convert.ToString(dr["mod_width"]);
                    this.m_mod_height = Convert.ToString(dr["mod_height"]);
                    this.m_mod_editwidth = Convert.ToString(dr["mod_editwidth"]);
                    this.m_mod_editheight = Convert.ToString(dr["mod_editheight"]);
                    this.m_mod_secure = Convert.ToBoolean(dr["mod_secure"]);
                    this.m_mod_allpages = Convert.ToBoolean(dr["mod_allpages"]);
                    this.m_mod_createddate = Convert.ToDateTime(dr["mod_createddate"]);
                    this.m_mod_createdby = Convert.ToString(dr["mod_createdby"]);
                    this.m_mod_updateddate = Convert.ToDateTime(dr["mod_updateddate"]);
                    this.m_mod_updatedby = Convert.ToString(dr["mod_updatedby"]);
                    this.m_mod_hidden = Convert.ToBoolean(dr["mod_hidden"]);
                    this.m_mod_deleted = Convert.ToBoolean(dr["mod_deleted"]);
                    this.m_exists = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private void GetParents()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetParents]";
            Int32[] Parents = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_MODULE_ID + "::ModId" + m_mod_id.ToString() + "::Parents";
                if (HttpContext.Current != null) if (HttpContext.Current != null) Parents = (Int32[])HttpContext.Current.Cache[CacheItem];
                if (Parents == null)
                {
                    if (this.ParentId > 0)
                    {
                        Parents = new Int32[1];
                        Parents[0] = this.ParentId;
                        Parents = Generic.GrowArray(GetNextParent(Parents, this.ParentId), 0);
                        RXServer.Data.CacheInsert(CacheItem, Parents);
                    }
                }
                this.m_mod_parents = Parents;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }
        private Int32[] GetNextParent(Int32[] Parents, Int32 ModId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetNextParent]";
            try
            {
                Module m = new Module(this.SitId, this.PagId, ModId, Data.DataSource, Data.ConnectionString);
                if (m.ParentId > 0)
                {
                    Parents = Generic.GrowArray(Parents, Parents.Length + 1);
                    Parents[Parents.Length - 1] = m.ParentId;
                    Parents = GetNextParent(Parents, m.ParentId);
                }
                return Parents;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return Parents;
            }
        }
        private Int32[] GetAuthorizedEditRoles(Int32 ModId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditRoles]";
            Int32[] Roles;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_MODULE_ROLES + "::ModId" + ModId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM amr_authorizedmodulesroles WHERE mod_id = " + ModId.ToString() + " AND amr_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Roles = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Roles[i] = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                return Roles;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private Int32[] GetAuthorizedEditGroups(Int32 ModId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetAuthorizedEditGroups]";
            Int32[] Groups;
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_MODULE_GROUPS + "::ModId" + ModId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM amg_authorizedmodulesgroups WHERE mod_id = " + ModId.ToString() + " AND amg_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                Groups = new Int32[dt.Rows.Count];
                for (Int32 i = 0; i < dt.Rows.Count; i++)
                    Groups[i] = Convert.ToInt32(dt.Rows[i]["grp_id"]);
                return Groups;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return new Int32[0];
            }
        }
        private String GetModuleSource(Int32 MdeId)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetModuleSource]";
            DataTable dt;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_MODULE_SOURCE + "::MdeId" + MdeId.ToString();
                dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT * FROM mde_moduledefinitions WHERE mde_id = " + MdeId.ToString() + " AND mde_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count < 1)
                    return String.Empty;
                return dt.Rows[0]["mde_src"].ToString();
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return String.Empty;
            }
        }
        private Boolean FindChildren()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::FindChildren]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_MODULE_ID + "::ModId" + m_mod_id.ToString() + "::Children";
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT mod_id FROM mod_modules WHERE mod_parentid = " + m_mod_id.ToString());
                    using (iCDataObject oDo = new iCDataObject(this.m_datasource, this.m_connectionstring, false, true))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                if (dt.Rows.Count > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }
        private void DeleteRelations()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::DeleteRelations]";
            try
            {
                // Delete SiteCollection... 
                // not in use for Modules...

                // Delete PageCollection...
                // not in use for Modules...

                // Delete TaskCollection...
                // not in use for Modules...

                // Delete ModuleCollection... 
                using (ModuleCollection mc = new ModuleCollection(this.m_sit_id, this.m_pag_id, this.m_mod_id, true, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                {
                    foreach (Module m in mc.Items)
                        m.Deleted = true;
                }

                // Delete DocumentCollection...
                // not in use for Modules...

                // Delete ObjectCollection...
                using (ObjectCollection oc = new ObjectCollection(this.m_sit_id, this.m_pag_id, true, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                {
                    foreach (Object o in oc.Items)
                        if(o.ModId.Equals(this.m_mod_id))
                            o.Deleted = true;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
            }
        }

        #endregion Private Methods

    }
    #endregion public class Module

    #region public class Generic
    public class Generic
    {
        static string CLASSNAME = "[Namespace::RXServer][Class::Generic]";
        static string FUNCTIONNAME;
        public static Int32[] GrowArray(Int32[] pOldArray, Int32 pNewSize)
        {
            FUNCTIONNAME = CLASSNAME + "[Function::GrowArray]";
            Int32 counter = 0;
            Int32[] newArray = null;

            if (pOldArray != null)
            {
                if (pNewSize <= pOldArray.Length)
                {
                    newArray = pOldArray;
                }
                else
                {
                    newArray = new Int32[pNewSize];
                    foreach (Int32 item in pOldArray)
                    {
                        newArray[counter] = item;
                        counter++;
                    }
                }
            }
            return newArray;
        }
    }
    #endregion public class Generic

    #region public class Error
    public class Error
    {
        public static void Report(Exception ex, String function, String variant)
        {
            try
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["ErrorMailOn"]))
                    EventMail(ex, function, variant);
            }
            catch (Exception)
            {
            }
            try
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["ErrorRssOn"]))
                    EventRss(ex, function, variant);
            }
            catch (Exception)
            {
            }
            try
            {
                EventLog(ex, function, variant);
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
                System.Diagnostics.Debug.WriteLine(function);
                System.Diagnostics.Debug.WriteLine(variant);
            }
            catch (Exception)
            {
            }
        }

        private static void EventLog(Exception ex, String function, String variant)
        {
            try
            {
                if (HttpContext.Current != null)
                {
                    variant +=
                        "\r\nCurrent.User.Identity.Name: " + RXServer.Authentication.User.Identity.Name != null ? RXServer.Authentication.User.Identity.Name : "none" +
                        "\r\nCurrent.User.Identity.IsAuthenticated: " + RXServer.Authentication.IsAuthenticated +
                        "\r\nCurrent.User.Identity.AuthenticationType: RXServer.Authentication";
                }
                System.Diagnostics.EventLog.WriteEntry(
                    "RXServer",
                    ex.GetType().ToString() + "occured in " + function + "\r\nSource: " + ex.Source + "\r\nMessage: " + ex.Message + "\r\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase + "\r\nCaller: " + System.Reflection.Assembly.GetCallingAssembly().CodeBase + "\r\nStack trace: " + ex.StackTrace +
                    "\r\nVariant Data: " + variant +
                    "\r\nRXServer.Data.CacheTimeOut: " + RXServer.Data.CacheTimeOut.ToString() +
                    "\r\nRXServer.Data.ConnectionString: " + RXServer.Data.ConnectionString +
                    "\r\nRXServer.Data.DataSource: " + RXServer.Data.DataSource +
                    "\r\nRXServer.Data.CultureInfo: " + RXServer.Data.CultureInfo.DisplayName,
                    System.Diagnostics.EventLogEntryType.Error
                );
            }
            catch (Exception)
            {

            }
        }

        private static void EventRss(Exception ex, String function, String variant)
        {
            try
            {
                if (HttpContext.Current != null)
                {
                    variant +=
                        "<br/><br/>Current.User.Identity.Name: " + RXServer.Authentication.User.Identity.Name != null ? RXServer.Authentication.User.Identity.Name : "none" +
                        "<br/><br/>Current.User.Identity.IsAuthenticated: " + RXServer.Authentication.IsAuthenticated +
                        "<br/><br/>Current.User.Identity.AuthenticationType: RXServer.Authentication";
                }
                Rss oRss = new Rss();
                oRss.AddItem(ex.GetType().ToString() + "occured in " + function,
                    "Source: " + ex.Source + "\r\nMessage: " + ex.Message + "\r\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase + "\r\nCaller: " + System.Reflection.Assembly.GetCallingAssembly().CodeBase + "\r\nStack trace: " + ex.StackTrace +
                    "<br/><br/>Variant Data: " + variant +
                    "<br/><br/>RXServer.Data.CacheTimeOut: " + RXServer.Data.CacheTimeOut.ToString() +
                    "<br/><br/>RXServer.Data.ConnectionString: " + RXServer.Data.ConnectionString +
                    "<br/><br/>RXServer.Data.DataSource: " + RXServer.Data.DataSource +
                    "<br/><br/>RXServer.Data.CultureInfo: " + RXServer.Data.CultureInfo.DisplayName,
                    "");
            }
            catch (Exception)
            {
            }
        }

        private static void EventMail(Exception ex, String function, String variant)
        {
            try
            {
                if (HttpContext.Current != null)
                {
                    variant +=
                        "<br/><br/>Current.User.Identity.Name: " + RXServer.Authentication.User.Identity.Name != null ? RXServer.Authentication.User.Identity.Name : "none" +
                        "<br/><br/>Current.User.Identity.IsAuthenticated: " + RXServer.Authentication.IsAuthenticated +
                        "<br/><br/>Current.User.Identity.AuthenticationType: RXServer.Authentication";
                }
                Business oBus = new Business();
                oBus.SendMail(ConfigurationManager.AppSettings["ErrorMailServer"].ToString(),
                    ConfigurationManager.AppSettings["ErrorMailPort"].ToString(),
                    ConfigurationManager.AppSettings["ErrorMailSender"].ToString(),
                    ConfigurationManager.AppSettings["ErrorMailAddress"].ToString(),
                    "An Exception was thrown in the application RXServer...",
                    "In function/routine: " + function + "<br/><br/>" + ex.Message +
                    "<br/><br/>Version: " + System.Reflection.Assembly.GetExecutingAssembly().CodeBase + "<br/>Caller: " + System.Reflection.Assembly.GetCallingAssembly().CodeBase + "<br/>Stack trace: " + ex.StackTrace +
                    "<br/><br/>Variant Data: " + variant +
                    "<br/><br/>RXServer.Data.CacheTimeOut: " + RXServer.Data.CacheTimeOut.ToString() +
                    "<br/><br/>RXServer.Data.ConnectionString: " + RXServer.Data.ConnectionString +
                    "<br/><br/>RXServer.Data.DataSource: " + RXServer.Data.DataSource +
                    "<br/><br/>RXServer.Data.CultureInfo: " + RXServer.Data.CultureInfo.DisplayName,
                    null);
            }
            catch (Exception)
            {
            }
        }
    }
    #endregion public class Error

    #region public class Rss
    public class Rss
    {
        string CLASSNAME = "[Namespace::RXServer][Class::Rss]";
        private static String rssfile = String.Empty;
        public Rss()
        {
            rssfile = ConfigurationManager.AppSettings["SystemRssFilePath"].ToString();
        }

        private Stream CreateNew()
        {
            XmlTextWriter writer = new XmlTextWriter(rssfile, System.Text.Encoding.UTF8);
            this.OpenRss(writer);
            this.CloseRss(writer);
            writer.Flush();
            writer.Close();
            return writer.BaseStream;
        }

        public void AddItem(String Title, String Link, String Description)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::AddItem]";
            if (File.Exists(rssfile))
            {
                StreamReader sr = File.OpenText(rssfile);
                long i = sr.BaseStream.Length;
                String orgdata = sr.ReadToEnd();
                sr.Close();
                if (i > 1)
                {
                    Int32 Index = orgdata.IndexOf("</channel>");
                    if (Index > 1)
                    {
                        orgdata = orgdata.Substring(0, Index);
                        using (StreamWriter sw = File.CreateText(rssfile))
                        {
                            sw.Write(orgdata);
                            sw.Write("<item>");
                            sw.Write("<title>" + HttpContext.Current.Server.HtmlEncode(Title) + "</title>");
                            sw.Write("<description><![CDATA[ " + HttpContext.Current.Server.HtmlEncode(Description) + " ]]></description>");
                            sw.Write("<link>" + Link + "</link>");
                            sw.Write("<pubDate>" + DateTime.Now.ToString("r") + "</pubDate>");
                            sw.Write("</item>");
                            sw.Write("</channel>");
                            sw.Write("</rss>");
                            sw.Close();
                        }
                        return;
                    }
                }
            }

            XmlTextWriter writer = new XmlTextWriter(rssfile, System.Text.Encoding.UTF8);
            this.OpenRss(writer);
            this.sAddItem(writer, Title, Link, Description, true);
            this.CloseRss(writer);
            writer.Flush();
            writer.Close();
        }

        private void AddItemToRss()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::AddItemToRss]";
        }

        private XmlTextWriter OpenRss(XmlTextWriter writer)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::OpenRss]";
            writer.WriteStartDocument();
            writer.WriteComment("Generated at " + DateTime.Now.ToString("r"));
            writer.WriteStartElement("rss");
            writer.WriteAttributeString("version", "2.0");
            writer.WriteAttributeString("xmlns:mscom", "http://www.iconsulting.se/rss/");
            writer.WriteStartElement("channel");
            writer.WriteElementString("title", "LiquidCore Error Handler       ");
            writer.WriteElementString("link", "http://www.iconsulting.se/");
            writer.WriteElementString("description", "Error information in rss format.");
            writer.WriteElementString("copyright", "Copyright 2005 Johan Olofsson");
            writer.WriteElementString("generator", "LiquidCore RssCreator 1.0");

            return writer;
        }

        private XmlTextWriter sAddItem(XmlTextWriter writer, string sItemTitle, string sItemLink, string sItemDescription)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::sAddItem]";
            writer.WriteStartElement("item");
            writer.WriteElementString("title", sItemTitle);
            writer.WriteElementString("link", sItemLink);

            writer.WriteElementString("description", sItemDescription);

            writer.WriteElementString("pubDate", DateTime.Now.ToString("r"));
            writer.WriteEndElement();

            return writer;
        }

        private XmlTextWriter sAddItem(XmlTextWriter writer, string sItemTitle, string sItemLink, string sItemDescription, bool bDescAsCDATA)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::sAddItem]";
            writer.WriteStartElement("item");
            writer.WriteElementString("title", sItemTitle);
            writer.WriteElementString("link", sItemLink);

            if (bDescAsCDATA == true)
            {
                // Now we can write the description as CDATA to support html content.
                // We find this used quite often in aggregators

                writer.WriteStartElement("description");
                writer.WriteCData(sItemDescription);
                writer.WriteEndElement();
            }
            else
            {
                writer.WriteElementString("description", sItemDescription);
            }

            writer.WriteElementString("pubDate", DateTime.Now.ToString("r"));
            writer.WriteEndElement();

            return writer;
        }

        private XmlTextWriter CloseRss(XmlTextWriter writer)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::CloseRss]";
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();

            return writer;
        }
    }
    #endregion public class Rss

    #region public class Business
    public class Business
    {
        string CLASSNAME = "[Namespace::RXServer][Class::Business]";
        public Business()
        {


        }

        public void SendMail(string Server, string Port, string From, string To, string Subject, string Body, ArrayList Attachments)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::SendMail]";
            try
            {
                MailMessage message = new MailMessage(From, To, Subject, Body);
                message.IsBodyHtml = true;
                if (Attachments != null)
                {
                    foreach (Attachment a in Attachments)
                    {
                        message.Attachments.Add(a);
                    }
                }

                SmtpClient client = new SmtpClient(Server, Convert.ToInt32(Port));
                client.Send(message);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }

        public void SendMail(string Server, string Port, string From, string To, string Subject, string Body, ArrayList Attachments, MailAddressCollection Cc)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::SendMail]";
            try
            {
                MailMessage message = new MailMessage(From, To, Subject, Body);
                foreach (MailAddress m in Cc)
                    message.CC.Add(m);
                message.IsBodyHtml = true;
                if (Attachments != null)
                {
                    foreach (Attachment a in Attachments)
                    {
                        message.Attachments.Add(a);
                    }
                }

                SmtpClient client = new SmtpClient(Server, Convert.ToInt32(Port));
                client.Send(message);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }

    }
    #endregion public class Business

    #region public class Common
    public class Common
    {
        static String CLASSNAME = "[Namespace::RXServer][Class::Common]";
        public Common()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static Control FindControlRecursive(Control Root, String Id)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::FindControlRecursive]";
            try
            {
                if (Root.ID == Id)
                    return Root;
                foreach (Control Ctl in Root.Controls)
                {
                    Control FoundCtl = FindControlRecursive(Ctl, Id);
                    if (FoundCtl != null)
                        return FoundCtl;
                }
                return null;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
                return null;
            }
        }

        public static Control FindRXContentHolder(Control Root, String Tag)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::FindRXContentHolder]";
            try
            {
                if (Root.GetType() == typeof(RXServer.RXContentHolder))
                    return Root;
                foreach (Control Ctl in Root.Controls)
                {
                    Control FoundCtl = FindRXContentHolder(Ctl, Tag);
                    if (FoundCtl != null)
                        if (FoundCtl.GetType() == typeof(RXServer.RXContentHolder))
                        {
                            RXServer.RXContentHolder ch = (RXServer.RXContentHolder)FoundCtl;
                            if (ch.PaneName == Tag)
                                return FoundCtl;
                        }
                }
                return null;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
                return null;
            }
        }

        public static string SafeString(string Source)
        {
            Source = Source.Replace("'", "´");
            return Source;
        }

        public static string RemoveNonNumeric(string strString)
        {
            // Variables
            string strValidCharacters = "1234567890";
            string strReturn = "";
            string strBuffer = "";
            int intIndex = 0;


            // Loop through the string 
            for (intIndex = 0; intIndex < strString.Length; intIndex++)
            {
                // Get this character
                strBuffer = strString.Substring(intIndex, 1);

                // Is this a number
                if (strValidCharacters.IndexOf(strBuffer) > -1)
                {
                    // Yes
                    strReturn += strBuffer;
                }
            }

            // Return the value
            return strReturn;
        }

        public static string CleanWordHtml(string html)
        {
            html = html.Replace("\"","'");
            System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
            // get rid of unnecessary tag spans (comments and title)   
            sc.Add(@"<!--(\w|\W)+?-->");
            sc.Add(@"<title>(\w|\W)+?</title>");
            // Get rid of classes and styles   
            sc.Add(@"\s?class=\w+");
            sc.Add(@"\s+style='[^']+'");
            sc.Add(@"\s+style=[^']");
            // Get rid of unnecessary tags   
            sc.Add(
            @"<(meta|link|/?o:|/?style|/?h1|/?h2|/?h3|/?h4|/?h5|/?h6|/?h7|/?h8|/?font|/?FONT|/?div|/?st\d|/?head|/?html|body|/?body|/?span|!\[)[^>]*?>");
            // Get rid of empty paragraph tags   
            sc.Add(@"(<[^>]+>)+&nbsp;(</\w+>)+");
            // remove bizarre v: element attached to <img> tag   
            sc.Add(@"\s+v:\w+=""[^""]+""");
            // remove extra lines   
            sc.Add(@"(\n\r){2,}");
            foreach (string s in sc)
                html = System.Text.RegularExpressions.Regex.Replace(html, s, "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return html;
        }

        public static string FixEntities(string html)   
        {
            System.Collections.Specialized.NameValueCollection nvc = new System.Collections.Specialized.NameValueCollection();   
            nvc.Add("“", "&ldquo;");   
            nvc.Add("”", "&rdquo;");   
            nvc.Add("–", "&mdash;");   
            foreach (string key in nvc.Keys)   
            {   
                html = html.Replace(key, nvc[key]);   
            }   
            return html;   
        }  

    }
    #endregion public class Common

    #region public class Security
    public class Security
    {
        static String CLASSNAME = "[Namespace::RXServer][Class::Security]";
        private static byte[] CRYPTO_KEY = { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc };
        private static byte[] CRYPTO_IV = { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0xcd };
        private static String m_SecurityLogin;
        private static String m_SecurityPassword;

        public static String LoggedInUserName
        {
            set
            {
                m_SecurityLogin = Common.SafeString(value);
            }
            get
            {
                return m_SecurityLogin;
            }
        }

        public static String LoggedInUserPassword
        {
            set
            {
                m_SecurityPassword = Common.SafeString(value);
            }
            get
            {
                return m_SecurityPassword;
            }
        }


        public Security()
        {
        }

        public static string Encrypt(string PlainText)
        {
            try
            {
                RijndaelManaged RMCrypto = new RijndaelManaged();
                byte[] ByteArray = Encoding.UTF8.GetBytes(PlainText);
                ICryptoTransform enc = RMCrypto.CreateEncryptor(CRYPTO_KEY, CRYPTO_IV);
                byte[] ByteArr = enc.TransformFinalBlock(ByteArray, 0, ByteArray.GetLength(0));
                return Convert.ToBase64String(ByteArr);
            }
            catch (Exception ex)
            {
                return "Encrypt - " + ex.Message.ToString();
            }
        }

        public static string Decrypt(string Base64String)
        {
            try
            {
                RijndaelManaged RMCrypto = new RijndaelManaged();
                ICryptoTransform dec = RMCrypto.CreateDecryptor(CRYPTO_KEY, CRYPTO_IV);
                byte[] ByteArr = Convert.FromBase64String(Base64String);
                return Encoding.UTF8.GetString(dec.TransformFinalBlock(ByteArr, 0, ByteArr.GetLength(0)));
            }
            catch (Exception ex)
            {
                return "Decrypt - " + ex.Message.ToString();
            }
        }

        private static Boolean CheckRoleAlias(Int32 RolId, String Alias)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::CheckRoleAlias]";
            DataTable dt = null;
            try
            {
                String CacheItem = RXServer.Data.CACHEITEM_ROLE_CHECK + "::RolId" + RolId.ToString();
                if (HttpContext.Current != null) if (HttpContext.Current != null) dt = (DataTable)HttpContext.Current.Cache[CacheItem];
                if (dt == null)
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT rol_title FROM rol_roles WHERE rol_id = " + RolId.ToString() + " AND rol_deleted = 0");
                    using (iCDataObject oDo = new iCDataObject(Data.DataSource, Data.ConnectionString, false, true, false))
                    {
                        dt = oDo.GetDataTable(sSQL.ToString());
                    }
                    RXServer.Data.CacheInsert(CacheItem, dt);
                }
                foreach (DataRow dr in dt.Rows)
                    if (dr["rol_title"].ToString().ToLower().Equals(Alias.ToLower()))
                        return true;
                return false;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, "");
                return false;
            }
        }

        /// <summary>
        /// RXServer.Security.Login() is replaced with RXServer.Security.SignIn()
        /// This method will be removed in next version of RXServer.
        /// </summary>
        public static bool Login(String Email, String Password, Int32 Group)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::Login]";
            try
            {
                bool Authorized = false;
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("SELECT usr_users.usr_id FROM ");
                sSQL.Append("usr_users JOIN ugr_usersgroups ON ugr_usersgroups.usr_id = usr_users.usr_id JOIN grp_groups ON grp_groups.grp_id = ugr_usersgroups.grp_id WHERE ");
                sSQL.Append("usr_users.usr_loginname = '" + Email + "' AND ");
                sSQL.Append("usr_users.usr_password = '" + Encrypt(Password) + "' AND grp_groups.grp_id = " + Group.ToString());
                using (iCDataObject oDO = new iCDataObject(Data.DataSource, Data.ConnectionString, false, true))
                {
                    DataTable dt = oDO.GetDataTable(sSQL.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        Data.Group = Group;
                        Data.Login = Email;
                        Data.Password = Encrypt(Password);
                        Authorized = true;
                    }
                    //IDataReader oReader = oDO.ExecuteReader(sSQL.ToString());
                    //if (ReaderHasRows(oReader))
                    //{
                    //    Data.Group = Group;
                    //    Data.Login = Email;
                    //    Data.Password = Encrypt(Password);
                    //    Authorized = true;
                    //}
                    //oReader.Close();
                }
                return Authorized;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
                return false;
            }
        }

        public static bool SignIn(String Email, String Password, Int32 Group)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::SignIn]";
            try
            {
                return Login(Email, Password, Group);
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
                return false;
            }
        }

        public static void SignOut()
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::SignOut]";
            try
            {
                m_SecurityLogin = string.Empty;
                m_SecurityPassword = string.Empty;
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }

        public static bool ReaderHasRows(IDataReader oReader)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::ReaderHasRows]";
            try
            {
                switch (Data.DataSource.ToLower())
                {
                    case "mysql":
                        {
                            MySqlDataReader dr = (MySqlDataReader)oReader;
                            if (dr.HasRows)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    case "mssqlserver":
                        {
                            SqlDataReader dr = (SqlDataReader)oReader;
                            if (dr.HasRows)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
                return false;
            }
        }

        public static bool IsInRole(String Role)
        {
            Int32 RolId = 0;
            Int32.TryParse(Role, out RolId);
            if (RolId != 0)
                return HttpContext.Current.User.IsInRole(Role.ToString());
            else
            {
                String User = String.Empty;
                if (HttpContext.Current != null) if (HttpContext.Current != null) User = RXServer.Authentication.User.Identity.Name != null ? RXServer.Authentication.User.Identity.Name : "none";
                String[] roles = GetRolesArray(User, true);
                foreach (String role in roles)
                {
                    if (CheckRoleAlias(Convert.ToInt32(role), Role))
                        return true;
                }
                return false;
            }
        }

        public static string[] GetRolesArray(string Email, bool UseRoleCache)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetRolesArray]";
            try
            {
                String Password = Data.Password;

                ArrayList userRoles = new ArrayList();
                if (UseRoleCache)
                {
                    string CacheKey = FUNCTIONNAME + RXServer.Data.CultureInfo.DisplayName + "GetRolesArray-" + Email;
                    userRoles = (ArrayList)HttpContext.Current.Cache[CacheKey];
                    if (userRoles == null)
                        GetRolesArray_Loader(CacheKey, Email, Password);
                    userRoles = (ArrayList)HttpContext.Current.Cache[CacheKey];
                    return (String[])userRoles.ToArray(typeof(String));
                }
                else
                {
                    StringBuilder sSQL = new StringBuilder();
                    sSQL.Append("SELECT DISTINCT rol_roles.rol_id FROM ");
                    sSQL.Append("rol_roles, uro_usersroles, usr_users WHERE ");
                    sSQL.Append("rol_roles.rol_id = uro_usersroles.rol_id AND ");
                    sSQL.Append("uro_usersroles.usr_id = usr_users.usr_id AND ");
                    sSQL.Append("usr_users.usr_loginname = '" + Email + "' AND usr_users.usr_password = '" + Password + "'");
                    using (iCDataObject oDO = new iCDataObject(Data.DataSource, Data.ConnectionString, false, true))
                    {
                        IDataReader oReader = oDO.ExecuteReader(sSQL.ToString());
                        while (oReader.Read())
                        {
                            userRoles.Add(oReader["rol_id"].ToString());
                        }
                        oReader.Close();
                    }
                    return (String[])userRoles.ToArray(typeof(String));
                }

            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
                return null;
            }
        }

        private static void GetRolesArray_Loader(String CacheKey, String Email, String Password)
        {
            string FUNCTIONNAME = CLASSNAME + "[Function::GetRolesArray_Loader]";
            try
            {
                Double CacheTimeOut = 1;
                ArrayList userRoles = new ArrayList();
                StringBuilder sSQL = new StringBuilder();
                sSQL.Append("SELECT DISTINCT rol_roles.rol_id FROM ");
                sSQL.Append("rol_roles, uro_usersroles, usr_users WHERE ");
                sSQL.Append("rol_roles.rol_id = uro_usersroles.rol_id AND ");
                sSQL.Append("uro_usersroles.usr_id = usr_users.usr_id AND ");
                sSQL.Append("usr_users.usr_loginname = '" + Email + "' AND usr_users.usr_password = '" + Password + "'");
                using (iCDataObject oDO = new iCDataObject(Data.DataSource, Data.ConnectionString, false, true))
                {
                    IDataReader oReader = oDO.ExecuteReader(sSQL.ToString());
                    while (oReader.Read())
                    {
                        userRoles.Add(oReader["rol_id"].ToString());
                    }
                    oReader.Close();
                }
                try
                {
                    CacheTimeOut = Convert.ToDouble(Data.CacheTimeOut);
                }
                catch (Exception)
                { }
                HttpContext.Current.Cache.Insert(CacheKey, userRoles, null, DateTime.MaxValue, TimeSpan.FromMinutes(CacheTimeOut));
            }
            catch (Exception ex)
            {
                Error.Report(ex, FUNCTIONNAME, String.Empty);
            }
        }

        public static void AddErrorData(Exception ex, string function)
        {
            try
            {
                Error.Report(ex, function, DateTime.Now.ToLongTimeString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    #endregion

    #region public class RXPageVirtual
    public class RXPageVirtual : System.Web.UI.Page
    {
        public RXServer.Page RXPage;
        public Int32 SitId = 1;
        public Int32 PagId = 1;

        public virtual void Page_PreInit(object sender, EventArgs e)
        {
            // Check current culture...
            if (RXServer.Data.CultureInfo.Name == "nn-NO")
                SitId = 2;
            else if (RXServer.Data.CultureInfo.Name == "fi-FI")
                SitId = 3;
            else if (RXServer.Data.CultureInfo.Name == "da-DK")
                SitId = 4;
            else
                SitId = 1;

            if (Request["PageId"] != null)
                Int32.TryParse(Request["PageId"], out PagId);

            this.RXPage = new RXServer.Page(SitId, PagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString);

            this.Title = "Ko-life";// Server.UrlDecode(RXPage.Name);
            this.Theme = RXPage.Theme;

            //Control c = Page.FindControl("ContentTemplate");
            Control c = Common.FindControlRecursive(Page.Master, "ContentTemplate");
            c.SkinID = RXPage.Skin;
        }

        public virtual void Page_Init(object sender, EventArgs e)
        {
            String ModuleType = String.Empty;
            String ModuleWidth = String.Empty;
            String ModuleHeight = String.Empty;
            Int32 ModuleCounter1 = 0;
            Int32 ModuleCounter2 = 0;
            foreach (RXServer.Module m in this.RXPage.Modules)
            {
                Control c = Common.FindRXContentHolder(Page, m.Pane);
                if (c != null)
                {
                    RXModuleGlobal mg = (RXModuleGlobal)Page.LoadControl(m.Src);
                    mg.SitId = m.SitId;
                    mg.PagId = m.PagId;
                    mg.ModId = m.Id;
                    mg.Skin = m.Skin;
                    mg.Height = m.Height;
                    mg.Width = m.Width;
                    mg.EditHeight = m.EditHeight;
                    mg.EditWidth = m.EditWidth;

                    RenderContentControl(c, mg);
                    Image Spacer = (Image)Common.FindControlRecursive(mg, "spacer");

                    using (Object o = new Object(m.SitId, m.PagId, m.Id, Data.DataSource, Data.ConnectionString))
                    {
                        if (o.Exist)
                        {
                            ModuleType = o.Field31.ToLower();

                            // moduler som finns på startsidan...
                            if (ModuleType.Equals("articletype4"))
                            {
                                ModuleCounter1++;

                                // Kollar föregående modul...
                                if (ModuleCounter1 > 1)
                                {
                                    if (o.Field29.ToLower().Equals("61") && ModuleHeight.Equals("61"))
                                        ModuleCounter1 = 0;
                                    else if (o.Field29.ToLower().Equals("132"))
                                        ModuleCounter1 = 0;
                                }

                                // Kollar den nya modulen...
                                ModuleWidth = o.Field30.ToLower();
                                ModuleHeight = o.Field29.ToLower();

                                if (ModuleCounter1.Equals(1))
                                    if (!Spacer.Equals(null))
                                        Spacer.Width = Unit.Pixel(10);

                            }
                            // moduler som finns på undersidan...
                            else if (ModuleType.Equals("articletype1") ||
                                     ModuleType.Equals("articletype2") ||
                                     ModuleType.Equals("articletype3"))
                            {
                                ModuleCounter2++;

                                // Kollar föregående modul...
                                if (ModuleCounter2.Equals(1) && o.Field30.ToLower().Equals("510"))
                                    ModuleCounter2 = 0;
                                else if (ModuleCounter2 > 1)
                                    ModuleCounter2 = 0;

                                // Kollar den nya modulen...
                                ModuleWidth = o.Field30.ToLower();
                                ModuleHeight = o.Field29.ToLower();

                                if (ModuleCounter2.Equals(1))
                                    if (!Spacer.Equals(null))
                                        Spacer.Width = Unit.Pixel(28);





















                                //if (ModuleHeight.Equals("61"))
                                //    ApplySpacer = false;
                                //else if (ModuleHeight.Equals("132"))
                                //    ApplySpacer = true;

                                //ModuleType = o.Field31.ToLower();
                                //ModuleWidth = o.Field30.ToLower();
                                //ModuleHeight = o.Field1.ToLower();

                                //if (ApplySpacer)
                                //{
                                //    // dessa bredder är tillåtna...
                                //    if (ModuleWidth.Equals("450"))
                                //    {
                                //        // låg modul eller hög modul...
                                //        if (ModuleHeight.Equals("61"))
                                //        {
                                //            RenderContentSpacer(c, true, false);
                                //        }
                                //        else if (ModuleHeight.Equals("132"))
                                //        {
                                //            RenderContentSpacer(c, true, true);
                                //        }
                                //    }
                                //}
                            }
                            //if (o.Field32.Equals("0"))
                            //    ModuleCounter = 0;
                            //else
                            //{
                            //    if (o.Field32.Equals("1") && o.Field32.Equals(ModuleType) && ModuleCounter % 2 == 0)
                            //        RenderContentSpacer(c, o.Field31.ToLower().Equals("articletype4"), o.Field1.ToLower().Equals("132"));
                            //}
                            //ModuleType = o.Field32;
                            //ModuleCounter++;
                        }
                    }
                }
            }
        }

        public virtual void RenderContentControl(Control c, Control Mod)
        {
            c.Controls.Add(new LiteralControl("<table cellpadding='0' cellspacing='0' align='left' style='display: inline; float: left;'><tr><td>"));
            c.Controls.Add(Mod);
            c.Controls.Add(new LiteralControl("</td></tr></table>"));
        }

        public virtual void RenderContentSpacer(Control c, Boolean Thin, Boolean High)
        {
            if (Thin)
            {
                if (High)
                {
                    c.Controls.Add(new LiteralControl("<table align='left' style='display: inline; '><tr>"));
                    c.Controls.Add(new LiteralControl("<td class='module_start_spacer_big'><img src='../images/pixel_trans.gif' /></td>"));
                    c.Controls.Add(new LiteralControl("</tr></table>"));
                }
                else
                {
                    c.Controls.Add(new LiteralControl("<table align='left' style='display: inline; '><tr>"));
                    c.Controls.Add(new LiteralControl("<td class='module_start_spacer_mini'><img src='../images/pixel_trans.gif' /></td>"));
                    c.Controls.Add(new LiteralControl("</tr></table>"));
                }
            }
            else
            {
                c.Controls.Add(new LiteralControl("<table align='left' style='display: inline; '><tr>"));
                c.Controls.Add(new LiteralControl("<td class='module_spacer'><img src='../images/pixel_trans.gif' /></td>"));
                c.Controls.Add(new LiteralControl("</tr></table>"));
            }
        }
    }
    #endregion public class RXPageVirtual

    #region public class RXModuleGlobal
    public class RXModuleGlobal : System.Web.UI.UserControl
    {
        private RXModuleSettings _ModuleSettings = new RXModuleSettings();
        public Int32 SitId
        {
            get
            {
                return _ModuleSettings.SitId;
            }
            set
            {
                _ModuleSettings.SitId = value;
            }
        }
        public Int32 PagId
        {
            get
            {
                return _ModuleSettings.PagId;
            }
            set
            {
                _ModuleSettings.PagId = value;
            }
        }
        public Int32 ModId
        {
            get
            {
                return _ModuleSettings.ModId;
            }
            set
            {
                _ModuleSettings.ModId = value;
            }
        }
        public String Skin
        {
            get
            {
                return _ModuleSettings.Skin; 
            }
            set 
            {
                _ModuleSettings.Skin = Common.SafeString(value);
            }
        }
        public String EditWidth
        {
            get
            {
                return _ModuleSettings.EditWidth;
            }
            set
            {
                _ModuleSettings.EditWidth = Common.SafeString(value);
            }
        }
        public String EditHeight
        {
            get
            {
                return _ModuleSettings.EditHeight;
            }
            set
            {
                _ModuleSettings.EditHeight = Common.SafeString(value);
            }
        }
        public String Width
        {
            get
            {
                return _ModuleSettings.Width;
            }
            set
            {
                _ModuleSettings.Width = Common.SafeString(value);
            }
        }
        public String Height
        {
            get
            {
                return _ModuleSettings.Height;
            }
            set
            {
                _ModuleSettings.Height = Common.SafeString(value);
            }
        }
    }
    #endregion public class RXModuleGlobal

    #region public class RXModuleSettings
    public class RXModuleSettings
    {
        public Int32 SitId;
        public Int32 PagId;
        public Int32 ModId;
        public String Skin;
        public String EditWidth;
        public String EditHeight;
        public String Width;
        public String Height;
    }
    #endregion
}