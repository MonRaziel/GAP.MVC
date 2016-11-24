using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GAP.Prueba.Web.Helpers
{
    public static class HelperUrlServices
    {
        public static string GetUrlServiceArticle()
        {
            return ConfigurationManager.AppSettings.Get("UrlArticle");
        }

        public static string GetUrlServiceStore()
        {
            return ConfigurationManager.AppSettings.Get("UrlStore");
        }

        public static string GetCredential()
        {
            return ConfigurationManager.AppSettings.Get("UserPassServ");
        }
    }
}