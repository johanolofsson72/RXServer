using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using iConsulting.iCDataHandler;

namespace RXServer
{
    namespace Web
    {
        namespace Model
        {

            #region public class Settings
            public static class Settings
            {
                static string CLASSNAME = "[Namespace::RXServer.Web.Model][Class::Settings]";
                public static ModuleDefinition[] GetPageModules(Int32 PagId)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetPageModules]";
                    try
                    {
                        ModuleDefinition[] md = { new ModuleDefinition() };
                        String[] x = { "", "", "", "", "" };
                        using (Menus.MenuItem m = new Menus.MenuItem(CurrentValues.SitId, PagId))
                        {
                            switch (m.Level)
                            {
                                case 1:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level1.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level1.Modules"].Split(';');
                                    break;
                                case 2:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level2.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level2.Modules"].Split(';');
                                    break;
                                case 3:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level3.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level3.Modules"].Split(';');
                                    break;
                                case 4:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level4.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level4.Modules"].Split(';');
                                    break;
                                case 5:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level5.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level5.Modules"].Split(';');
                                    break;
                                case 6:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level6.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level6.Modules"].Split(';');
                                    break;
                                case 7:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level7.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level7.Modules"].Split(';');
                                    break;
                                case 8:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level8.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level8.Modules"].Split(';');
                                    break;
                                case 9:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level9.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level9.Modules"].Split(';');
                                    break;
                            }
                            md = new ModuleDefinition[x.Length];
                            for (Int32 i = 0; i < x.Length; i++)
                            {
                                md[i] = new ModuleDefinition();
                                if (x[i].Length > 0)
                                {
                                    Int32 Values = x[i].Split(',').Length;
                                    if (Values > 0)
                                        md[i].Name = x[i].Split(',').GetValue(0).ToString();
                                    if (Values > 1)
                                        md[i].ContentPane = x[i].Split(',').GetValue(1).ToString();
                                    if (Values > 2)
                                        md[i].DefinitionId = Convert.ToInt32(x[i].Split(',').GetValue(2));
                                    if (Values > 3)
                                        md[i].Skin = x[i].Split(',').GetValue(3).ToString();
                                    if (Values > 4)
                                        md[i].Secure = (x[i].Split(',').GetValue(4).ToString()).Equals("0") ? false : true;
                                }
                            }
                            return md;
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                        return new ModuleDefinition[0];
                    }
                }
                public static ModuleDefinition[] GetReadMoreModules(Int32 PagId)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetReadMoreModules]";
                    try
                    {
                        ModuleDefinition[] md = { new ModuleDefinition() };
                        String[] x = { "", "", "", "", "" };
                        using (Menus.MenuItem m = new Menus.MenuItem(CurrentValues.SitId, PagId))
                        {
                            switch (m.Level)
                            {
                                case 1:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level1.Readmore.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level1.Readmore.Modules"].Split(';');
                                    break;
                                case 2:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level2.Readmore.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level2.Readmore.Modules"].Split(';');
                                    break;
                                case 3:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level3.Readmore.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level3.Readmore.Modules"].Split(';');
                                    break;
                                case 4:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level4.Readmore.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level4.Readmore.Modules"].Split(';');
                                    break;
                                case 5:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level5.Readmore.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level5.Readmore.Modules"].Split(';');
                                    break;
                                case 6:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level6.Readmore.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level6.Readmore.Modules"].Split(';');
                                    break;
                                case 7:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level7.Readmore.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level7.Readmore.Modules"].Split(';');
                                    break;
                                case 8:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level8.Readmore.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level8.Readmore.Modules"].Split(';');
                                    break;
                                case 9:
                                    if (System.Configuration.ConfigurationManager.AppSettings["Model.Level9.Readmore.Modules"] != null)
                                        x = System.Configuration.ConfigurationManager.AppSettings["Model.Level9.Readmore.Modules"].Split(';');
                                    break;
                            }
                            md = new ModuleDefinition[x.Length];
                            for (Int32 i = 0; i < x.Length; i++)
                            {
                                md[i] = new ModuleDefinition();
                                if (x[i].Length > 0)
                                {
                                    Int32 Values = x[i].Split(',').Length;
                                    if (Values > 0)
                                        md[i].Name = x[i].Split(',').GetValue(0).ToString();
                                    if (Values > 1)
                                        md[i].ContentPane = x[i].Split(',').GetValue(1).ToString();
                                    if (Values > 2)
                                        md[i].DefinitionId = Convert.ToInt32(x[i].Split(',').GetValue(2));
                                    if (Values > 3)
                                        md[i].Skin = x[i].Split(',').GetValue(3).ToString();
                                    if (Values > 4)
                                        md[i].Secure = (x[i].Split(',').GetValue(4).ToString()).Equals("0") ? false : true;
                                }
                            }
                            return md;
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                        return new ModuleDefinition[0];
                    }
                }
                public static String GetLevelPageTemplate(Int32 Level)
                {
                    string FUNCTIONNAME = CLASSNAME + "[Function::GetLevelPageTemplate]";
                    try
                    {
                        String x = String.Empty;
                        switch (Level)
                        {
                            case 1:
                                x = System.Configuration.ConfigurationManager.AppSettings["Model.Level1.PageTemplate"];
                                break;
                            case 2:
                                x = System.Configuration.ConfigurationManager.AppSettings["Model.Level2.PageTemplate"];
                                break;
                            case 3:
                                x = System.Configuration.ConfigurationManager.AppSettings["Model.Level3.PageTemplate"];
                                break;
                            case 4:
                                x = System.Configuration.ConfigurationManager.AppSettings["Model.Level4.PageTemplate"];
                                break;
                            case 5:
                                x = System.Configuration.ConfigurationManager.AppSettings["Model.Level5.PageTemplate"];
                                break;
                            case 6:
                                x = System.Configuration.ConfigurationManager.AppSettings["Model.Level6.PageTemplate"];
                                break;
                            case 7:
                                x = System.Configuration.ConfigurationManager.AppSettings["Model.Level7.PageTemplate"];
                                break;
                            case 8:
                                x = System.Configuration.ConfigurationManager.AppSettings["Model.Level8.PageTemplate"];
                                break;
                            case 9:
                                x = System.Configuration.ConfigurationManager.AppSettings["Model.Level9.PageTemplate"];
                                break;
                        }
                        return x;
                    }
                    catch (Exception ex)
                    {
                        Error.Report(ex, FUNCTIONNAME, String.Empty);
                        return String.Empty;
                    }
                }
            }
            #endregion public class Settings

            #region public class ModuleDefinition
            public class ModuleDefinition
            {
                public String Name = String.Empty;
                public String ContentPane = String.Empty;
                public String Skin = String.Empty;
                public Int32 DefinitionId;
                public Boolean Secure = false;
            }
            #endregion public class ModuleDefinition

        }
    }
}
