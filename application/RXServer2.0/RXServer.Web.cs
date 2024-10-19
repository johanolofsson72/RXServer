using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace RXServer
{
    namespace Web
    {
        #region public class CultureInfo
        public static class CultureInfo
        {
            static string CLASSNAME = "[Namespace::RXServer::Web][Class::CultureInfo]";
            public static void SetCultureInfo()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::SetCultureInfo]";
                try
                {
                    using (RXServer.Site s = new Site(CurrentValues.SitId, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                    {
                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(s.Language.ToString());
                        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(s.Language.ToString());  
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }
        }
        #endregion public class CultureInfo

        #region public class CurrentValues
        public static class CurrentValues
        {
            public static Int32 SitId
            {
                get
                {
                    Int32 x = 0;
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session["RXServer.Web.CurrentValues.SitId"] != null)
                            Int32.TryParse(HttpContext.Current.Session["RXServer.Web.CurrentValues.SitId"].ToString(), out x);
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.CurrentValues.SitId"] = value;
                }
            }
            public static Int32 PagId
            {
                get
                {
                    Int32 x = 0;
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session["RXServer.Web.CurrentValues.PagId"] != null)
                            Int32.TryParse(HttpContext.Current.Session["RXServer.Web.CurrentValues.PagId"].ToString(), out x);
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.CurrentValues.PagId"] = value;
                }
            }
        }
        #endregion public class CurrentValues

        #region public class SelectedPages
        public static class SelectedPages
        {
            static string CLASSNAME = "[Namespace::RXServer::Web][Class::SelectedPages]";
            public static Int32 Level1
            {
                get
                {
                    Int32 x = 0;
                    String y = "RXServer.Web.SelectedPages.Level1_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();    
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            Int32.TryParse(HttpContext.Current.Session[y].ToString(), out x);
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level1_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static Int32 Level2
            {
                get
                {
                    Int32 x = 0;
                    String y = "RXServer.Web.SelectedPages.Level2_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            Int32.TryParse(HttpContext.Current.Session[y].ToString(), out x);
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level2_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static Int32 Level3
            {
                get
                {
                    Int32 x = 0;
                    String y = "RXServer.Web.SelectedPages.Level3_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            Int32.TryParse(HttpContext.Current.Session[y].ToString(), out x);
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level3_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static Int32 Level4
            {
                get
                {
                    Int32 x = 0;
                    String y = "RXServer.Web.SelectedPages.Level4_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            Int32.TryParse(HttpContext.Current.Session[y].ToString(), out x);
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level4_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static Int32 Level5
            {
                get
                {
                    Int32 x = 0;
                    String y = "RXServer.Web.SelectedPages.Level5_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            Int32.TryParse(HttpContext.Current.Session[y].ToString(), out x);
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level5_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static Int32 Level6
            {
                get
                {
                    Int32 x = 0;
                    String y = "RXServer.Web.SelectedPages.Level6_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            Int32.TryParse(HttpContext.Current.Session[y].ToString(), out x);
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level6_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static Int32 Level7
            {
                get
                {
                    Int32 x = 0;
                    String y = "RXServer.Web.SelectedPages.Level7_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            Int32.TryParse(HttpContext.Current.Session[y].ToString(), out x);
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level7_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static Int32 Level8
            {
                get
                {
                    Int32 x = 0;
                    String y = "RXServer.Web.SelectedPages.Level8_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            Int32.TryParse(HttpContext.Current.Session[y].ToString(), out x);
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level8_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static Int32 Level9
            {
                get
                {
                    Int32 x = 0;
                    String y = "RXServer.Web.SelectedPages.Level9_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            Int32.TryParse(HttpContext.Current.Session[y].ToString(), out x);
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level9_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static String Level1Name
            {
                get
                {
                    String x = String.Empty;
                    String y = "RXServer.Web.SelectedPages.Level1Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            x = HttpContext.Current.Session[y].ToString();
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level1Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static String Level2Name
            {
                get
                {
                    String x = String.Empty;
                    String y = "RXServer.Web.SelectedPages.Level2Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            x = HttpContext.Current.Session[y].ToString();
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level2Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static String Level3Name
            {
                get
                {
                    String x = String.Empty;
                    String y = "RXServer.Web.SelectedPages.Level3Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            x = HttpContext.Current.Session[y].ToString();
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level3Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static String Level4Name
            {
                get
                {
                    String x = String.Empty;
                    String y = "RXServer.Web.SelectedPages.Level4Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            x = HttpContext.Current.Session[y].ToString();
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level4Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static String Level5Name
            {
                get
                {
                    String x = String.Empty;
                    String y = "RXServer.Web.SelectedPages.Level5Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            x = HttpContext.Current.Session[y].ToString();
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level5Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static String Level6Name
            {
                get
                {
                    String x = String.Empty;
                    String y = "RXServer.Web.SelectedPages.Level6Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            x = HttpContext.Current.Session[y].ToString();
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level6Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static String Level7Name
            {
                get
                {
                    String x = String.Empty;
                    String y = "RXServer.Web.SelectedPages.Level7Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            x = HttpContext.Current.Session[y].ToString();
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level7Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static String Level8Name
            {
                get
                {
                    String x = String.Empty;
                    String y = "RXServer.Web.SelectedPages.Level8Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            x = HttpContext.Current.Session[y].ToString();
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level8Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }
            public static String Level9Name
            {
                get
                {
                    String x = String.Empty;
                    String y = "RXServer.Web.SelectedPages.Level9Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString();
                    if (HttpContext.Current.Session != null)
                        if (HttpContext.Current.Session[y] != null)
                            x = HttpContext.Current.Session[y].ToString();
                    return x;
                }
                set
                {
                    HttpContext.Current.Session["RXServer.Web.SelectedPages.Level9Name_On_SitId_" + RXServer.Web.CurrentValues.SitId.ToString()] = value;
                }
            }

            public static void SetSelected()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::SetSelected]";
                Int32 CurrentSitId = 0;
                Int32 CurrentPagId = 0;
                try
                {
                    Level1 = 0;
                    Level2 = 0;
                    Level3 = 0;
                    Level4 = 0;
                    Level5 = 0;
                    Level6 = 0;
                    Level7 = 0;
                    Level8 = 0;
                    Level9 = 0;
                    Level1Name = String.Empty;
                    Level2Name = String.Empty;
                    Level3Name = String.Empty;
                    Level4Name = String.Empty;
                    Level5Name = String.Empty;
                    Level6Name = String.Empty;
                    Level7Name = String.Empty;
                    Level8Name = String.Empty;
                    Level9Name = String.Empty;
                    CurrentSitId = CurrentValues.SitId;
                    CurrentPagId = CurrentValues.PagId;
                    if (!CurrentPagId.Equals(0))
                    {
                        using (Menus.MenuItem m = new Menus.MenuItem(CurrentSitId, CurrentPagId))
                        {
                            if (!m.ParentId.Equals(0))
                            {
                                GetParent(CurrentSitId, m.ParentId);
                                switch (m.Parents.Length)
                                {
                                    case 1:
                                        Level2 = CurrentPagId;
                                        Level2Name = m.Name;
                                        break;
                                    case 2:
                                        Level3 = CurrentPagId;
                                        Level3Name = m.Name;
                                        break;
                                    case 3:
                                        Level4 = CurrentPagId;
                                        Level4Name = m.Name;
                                        break;
                                    case 4:
                                        Level5 = CurrentPagId;
                                        Level5Name = m.Name;
                                        break;
                                    case 5:
                                        Level6 = CurrentPagId;
                                        Level6Name = m.Name;
                                        break;
                                    case 6:
                                        Level7 = CurrentPagId;
                                        Level7Name = m.Name;
                                        break;
                                    case 7:
                                        Level8 = CurrentPagId;
                                        Level8Name = m.Name;
                                        break;
                                    case 8:
                                        Level9 = CurrentPagId;
                                        Level9Name = m.Name;
                                        break;
                                }
                            }
                            else
                            {
                                Level1 = CurrentPagId;
                                Level1Name = m.Name;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }
            private static void GetParent(Int32 SitId, Int32 PagId)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetParent]";
                try
                {
                    using (Menus.MenuItem m = new Menus.MenuItem(SitId, PagId))
                    {
                        if (!m.ParentId.Equals(0))
                        {
                            GetParent(SitId, m.ParentId);
                            switch (m.Parents.Length)
                            {
                                case 1:
                                    Level2 = PagId;
                                    Level2Name = m.Name;
                                    break;
                                case 2:
                                    Level3 = PagId;
                                    Level3Name = m.Name;
                                    break;
                                case 3:
                                    Level4 = PagId;
                                    Level4Name = m.Name;
                                    break;
                                case 4:
                                    Level5 = PagId;
                                    Level5Name = m.Name;
                                    break;
                                case 5:
                                    Level6 = PagId;
                                    Level6Name = m.Name;
                                    break;
                                case 6:
                                    Level7 = PagId;
                                    Level7Name = m.Name;
                                    break;
                                case 7:
                                    Level8 = PagId;
                                    Level8Name = m.Name;
                                    break;
                                case 8:
                                    Level9 = PagId;
                                    Level9Name = m.Name;
                                    break;
                            }
                        }
                        else
                        {
                            Level1 = PagId;
                            Level1Name = m.Name;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }
            public static String GetSelectedSiteMapPath(String Devider)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetSelectedSiteMapPath]";
                StringBuilder ret = new StringBuilder();
                try
                {
                    if (Level9Name.Equals(String.Empty))
                    {
                        if (Level8Name.Equals(String.Empty))
                        {
                            if (Level7Name.Equals(String.Empty))
                            {
                                if (Level6Name.Equals(String.Empty))
                                {
                                    if (Level5Name.Equals(String.Empty))
                                    {
                                        if (Level4Name.Equals(String.Empty))
                                        {
                                            if (Level3Name.Equals(String.Empty))
                                            {
                                                if (Level2Name.Equals(String.Empty))
                                                {
                                                    ret.Append(Level1Name);
                                                }
                                                else
                                                {
                                                    ret.Append(Level1Name);
                                                    ret.Append(Devider);
                                                    ret.Append(Level2Name);
                                                }
                                            }
                                            else
                                            {
                                                ret.Append(Level1Name);
                                                ret.Append(Devider);
                                                ret.Append(Level2Name);
                                                ret.Append(Devider);
                                                ret.Append(Level3Name);
                                            }
                                        }
                                        else
                                        {
                                            ret.Append(Level1Name);
                                            ret.Append(Devider);
                                            ret.Append(Level2Name);
                                            ret.Append(Devider);
                                            ret.Append(Level3Name);
                                            ret.Append(Devider);
                                            ret.Append(Level4Name);
                                        }
                                    }
                                    else
                                    {
                                        ret.Append(Level1Name);
                                        ret.Append(Devider);
                                        ret.Append(Level2Name);
                                        ret.Append(Devider);
                                        ret.Append(Level3Name);
                                        ret.Append(Devider);
                                        ret.Append(Level4Name);
                                        ret.Append(Devider);
                                        ret.Append(Level5Name);
                                    }
                                }
                                else
                                {
                                    ret.Append(Level1Name);
                                    ret.Append(Devider);
                                    ret.Append(Level2Name);
                                    ret.Append(Devider);
                                    ret.Append(Level3Name);
                                    ret.Append(Devider);
                                    ret.Append(Level4Name);
                                    ret.Append(Devider);
                                    ret.Append(Level5Name);
                                    ret.Append(Devider);
                                    ret.Append(Level6Name);
                                }
                            }
                            else
                            {
                                ret.Append(Level1Name);
                                ret.Append(Devider);
                                ret.Append(Level2Name);
                                ret.Append(Devider);
                                ret.Append(Level3Name);
                                ret.Append(Devider);
                                ret.Append(Level4Name);
                                ret.Append(Devider);
                                ret.Append(Level5Name);
                                ret.Append(Devider);
                                ret.Append(Level6Name);
                                ret.Append(Devider);
                                ret.Append(Level7Name);
                            }
                        }
                        else
                        {
                            ret.Append(Level1Name);
                            ret.Append(Devider);
                            ret.Append(Level2Name);
                            ret.Append(Devider);
                            ret.Append(Level3Name);
                            ret.Append(Devider);
                            ret.Append(Level4Name);
                            ret.Append(Devider);
                            ret.Append(Level5Name);
                            ret.Append(Devider);
                            ret.Append(Level6Name);
                            ret.Append(Devider);
                            ret.Append(Level7Name);
                            ret.Append(Devider);
                            ret.Append(Level8Name);
                        }
                    }
                    else
                    {
                        ret.Append(Level1Name);
                        ret.Append(Devider);
                        ret.Append(Level2Name);
                        ret.Append(Devider);
                        ret.Append(Level3Name);
                        ret.Append(Devider);
                        ret.Append(Level4Name);
                        ret.Append(Devider);
                        ret.Append(Level5Name);
                        ret.Append(Devider);
                        ret.Append(Level6Name);
                        ret.Append(Devider);
                        ret.Append(Level7Name);
                        ret.Append(Devider);
                        ret.Append(Level8Name);
                        ret.Append(Devider);
                        ret.Append(Level9Name);
                    }
                    return ret.ToString();
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                    return ret.ToString();
                }
            }
            public static Boolean IsSelected(Int32 PagId)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::IsSelected]";
                try
                {
                    if (PagId.Equals(SelectedPages.Level1) ||
                        PagId.Equals(SelectedPages.Level2) ||
                        PagId.Equals(SelectedPages.Level3) ||
                        PagId.Equals(SelectedPages.Level4) ||
                        PagId.Equals(SelectedPages.Level5) ||
                        PagId.Equals(SelectedPages.Level6) ||
                        PagId.Equals(SelectedPages.Level7) ||
                        PagId.Equals(SelectedPages.Level8) ||
                        PagId.Equals(SelectedPages.Level9))
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                    return false;
                }
            }
            public static String GetDynamicSiteMapPath(Int32 PagId, String Devider)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetDynamicSiteMapPath]";
                StringBuilder ret = new StringBuilder();
                try
                {
                    if (!PagId.Equals(0))
                    {
                        using (Menus.MenuItem m = new Menus.MenuItem(CurrentValues.SitId, PagId))
                        {
                            if (!m.ParentId.Equals(0))
                            {
                                GetDynamicSiteMapPathParent(m.ParentId, ref ret, Devider);
                                ret.Append(Devider + m.Name);
                            }
                            else
                                ret.Append(m.Name);
                        }
                    }
                    return ret.ToString();
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                    return ret.ToString();
                }
            }
            private static void GetDynamicSiteMapPathParent(Int32 PagId, ref StringBuilder ret, String Devider)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetDynamicSiteMapPathParent]";
                try
                {
                    if (!PagId.Equals(0))
                    {
                        using (Menus.MenuItem m = new Menus.MenuItem(CurrentValues.SitId, PagId))
                        {
                            if (!m.ParentId.Equals(0))
                            {
                                GetDynamicSiteMapPathParent(m.ParentId, ref ret, Devider);
                                ret.Append(Devider + m.Name);
                            }
                            else
                                ret.Append(m.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }
        }
        #endregion public class SelectedPages

        #region public class ControlValues
        public static class ControlValues
        {
            static string CLASSNAME = "[Namespace::RXServer::Web][Class::ControlValues]";
            public static string PageControlDate
            {
                get
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::PageControlDate::Get]";
                    try
                    {
                        String ret = String.Empty;
                        using (RXServer.Web.Menus.MenuItem mi = new RXServer.Web.Menus.MenuItem(CurrentValues.SitId, CurrentValues.PagId))
                        {
                            ret = mi.Settings.ControlDate;
                        }
                        return ret;
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                        return String.Empty;
                    }
                }
                set
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::PageControlDate:Set]";
                    try
                    {
                        using (RXServer.Web.Menus.MenuItem mi = new RXServer.Web.Menus.MenuItem(CurrentValues.SitId, CurrentValues.PagId))
                        {
                            mi.Settings.ControlDate = value;
                            mi.Settings.Save(); 
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                    }
                }
            }  
        }
        #endregion public class ControlValues

        #region public class RequestValues
        public static class RequestValues
        {
            public static Int32 SitId
            {
                get
                {
                    Int32 x = 0;
                    if (HttpContext.Current.Request["SitId"] != null)
                        Int32.TryParse(HttpContext.Current.Request["SitId"], out x);
                    return x;
                }
            }
            public static Int32 PagId
            {
                get
                {
                    Int32 x = 0;
                    if (HttpContext.Current.Request["PagId"] != null)
                        Int32.TryParse(HttpContext.Current.Request["PagId"], out x);
                    return x;
                }
            }
            public static Int32 ModId
            {
                get
                {
                    Int32 x = 0;
                    if (HttpContext.Current.Request["ModId"] != null)
                        Int32.TryParse(HttpContext.Current.Request["ModId"], out x);
                    return x;
                }
            }
            public static Int32 MenId
            {
                get
                {
                    Int32 x = 0;
                    if (HttpContext.Current.Request["MenId"] != null)
                        Int32.TryParse(HttpContext.Current.Request["MenId"], out x);
                    return x;
                }
            }
            public static Int32 ItmId
            {
                get
                {
                    Int32 x = 0;
                    if (HttpContext.Current.Request["ItmId"] != null)
                        Int32.TryParse(HttpContext.Current.Request["ItmId"], out x);
                    return x;
                }
            }
            public static Int32 ForumId
            {
                get
                {
                    Int32 x = 0;
                    if (HttpContext.Current.Request["ForumId"] != null)
                        Int32.TryParse(HttpContext.Current.Request["ForumId"], out x);
                    return x;
                }
            }
            public static Int32 ThreadId
            {
                get
                {
                    Int32 x = 0;
                    if (HttpContext.Current.Request["ThreadId"] != null)
                        Int32.TryParse(HttpContext.Current.Request["ThreadId"], out x);
                    return x;
                }
            }
            public static Int32 Sort
            {
                get
                {
                    Int32 x = 0;
                    if (HttpContext.Current.Request["Sort"] != null)
                        Int32.TryParse(HttpContext.Current.Request["Sort"], out x);
                    return x;
                }
            }
            public static String Url
            {
                get
                {
                    String x = String.Empty;
                    if (HttpContext.Current.Request["Url"] != null)
                        x = HttpContext.Current.Request["Url"].ToString();
                    return x;
                }
            }
            public static String ConPa
            {
                get
                {
                    String x = String.Empty;
                    if (HttpContext.Current.Request["ConPa"] != null)
                        x = HttpContext.Current.Request["ConPa"].ToString();
                    return x;
                }
            }
        }
        #endregion public class RequestValues

        #region public class Redirect
        public static class Redirect
        {
            public static void To(String Url)
            {
                HttpContext.Current.Response.Redirect(Url, false);
            }
        }
        #endregion public class Redirect

        #region public class SiteMap
        public static class SiteMap
        {
            static string CLASSNAME = "[Namespace::RXServer::Web][Class::SiteMap]";
            private static StringBuilder Html = new StringBuilder();
            public static StringBuilder GenerateHtml(Int32 SitId)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GenerateHtml]";
                try
                {
                    return _GenerateHtml(SitId, 0);
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                    return new StringBuilder();
                }
            }
            public static StringBuilder GenerateHtml(Int32 SitId, Int32 PagId)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GenerateHtml]";
                try
                {
                    return _GenerateHtml(SitId, PagId);
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                    return new StringBuilder();
                }
            }
            private static StringBuilder _GenerateHtml(Int32 SitId, Int32 PagId)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::_GenerateHtml]";
                try
                {
                    Html = new StringBuilder();
                    using (RXServer.PageCollection pc = new RXServer.PageCollection(SitId, PagId, false, RXServer.Data.DataSource, RXServer.Data.ConnectionString))
                    {
                        if (!PagId.Equals(0))
                            using (RXServer.Web.Menus.MenuItem mi = new RXServer.Web.Menus.MenuItem(SitId, PagId))
                            {
                                Html.Append("<div class=\"sitemapitem0\"><a href=\"Default.aspx?PagId=" + PagId.ToString() + "\">" + HttpContext.Current.Server.UrlDecode(mi.Name) + "</a></div>");
                            }
                        Write(pc);
                    }
                    return Html;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                    return new StringBuilder();
                }
            }
            private static void Write(RXServer.PageCollection pc)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::Write]";
                try
                {
                    foreach (RXServer.Page p in pc.Items)
                    {
                        if (!p.Hidden)
                        {
                            System.Text.StringBuilder s = new System.Text.StringBuilder();
                            Int32 index = 0;
                            if (p.Parents != null)
                            {
                                index = p.Parents.Length;
                                //for (Int32 i = 0; i < index; i++)
                                //    s.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
                            }
                            s.Append("<div class=\"sitemapitem" + index.ToString() + "\"><a href=\"Default.aspx?PagId=" + p.Id.ToString() + "\">" + HttpContext.Current.Server.UrlDecode(p.Name) + "</a></div>");
                            Html.Append(s.ToString()); 

                            if (p.Pages.Count() > 0)
                                Write(p.Pages);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }
        }
        #endregion public class SiteMap
    }
}
