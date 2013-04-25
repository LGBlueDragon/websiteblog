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
                    case "odbc" : return "[dbo].[user]";
                    case "local":
                    case "remote": return "website.user";
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
                    case "odbc": return "[dbo].[blog]";
                    case "local":
                    case "remote": return "website.blog";
                    default: throw new ConfigurationErrorsException("Missing 'generalSettings' in .config");
                }
            }
        }

    }
}
