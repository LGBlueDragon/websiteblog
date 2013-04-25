// -----------------------------------------------------------------------
// <copyright file="Settings.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MyBlog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;

    /// <summary>
    /// Class to abstract the settings handling for different database etc. configs
    /// Uses Configurationmanager to access .config files
    /// </summary>
    public static class Settings
    {
        static Settings()
        {}
        
        public static string ConnectionString
        {
            get
            {
                string general = ConfigurationManager.AppSettings["generalSettings"]; 
                string csName = ConfigurationManager.AppSettings[general + "ConnectionString"];
                return ConfigurationManager.ConnectionStrings[csName].ConnectionString;
            }
        }

        public static string UserTableName
        {
            get
            {
                string general = ConfigurationManager.AppSettings["generalSettings"];
                switch (general)
                {
                    case "sqlserver" : return "[dbo].[user]";
                    case "mysql": return "website.user";
                    default: throw new ConfigurationErrorsException("Missing 'generalSettings' in .config");
                }   
            }
        }


        public static string BlogTableName
        {
            get
            {
                string general = ConfigurationManager.AppSettings["generalSettings"];
                switch (general)
                {
                    case "sqlserver": return "[dbo].[blog]";
                    case "mysql": return "website.blog";
                    default: throw new ConfigurationErrorsException("Missing 'generalSettings' in .config");
                }
            }
        }

    }
}
