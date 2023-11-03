using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Web;
using VisionOne.DAL.Data;

namespace VisionOne.DAL.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        VisionOneDataContext dbContext;

        public VisionOneDataContext Init()
        {

            
            return dbContext ?? (dbContext = string.IsNullOrWhiteSpace(strConn) ? new VisionOneDataContext() : new VisionOneDataContext(strConn));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
        public static class ConnectionString
        {
            public static string Connection
            {
                get
                {
                    if (string.IsNullOrWhiteSpace(Convert.ToString(ConfigurationManager.AppSettings["connRiskXchange"])))
                        return "";
                    return Convert.ToString(ConfigurationManager.AppSettings["connRiskXchange"]);
                }
            }

            public static void Redirect()
            {
                HttpContext.Current.Response.Redirect("/Login/Login");
            }

            public static string MyConnection()
            {
                return Convert.ToString(ConfigurationManager.AppSettings["connRiskXchange"]);//"this is one test";//
            }
        }
    }
}
