using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VisionOne.Core.Domain;

namespace VisionOne.DAL.Infrastructure
{
    public class ApplicationSession
    {
        // private constructor
        private readonly IHttpContextAccessor _contextAccessor;
        private ApplicationSession(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            UserDetail = new User();
            UserRole = new Role();
        }

        public string GetDataFromSession()
        {
            return _contextAccessor.HttpContext.Session.TryGetValue("userId");
        }
        // Gets the current session.
        public static ApplicationSession Current
        {

            get
            {
                ApplicationSession session =
                (ApplicationSession)_contextAccessor.HttpContext.Session["__ApplicationSession__"];
                if (session == null)
                {
                    session = new ApplicationSession();
                    HttpContext.Current.Session["__ApplicationSession__"] = session;
                }
                return session;
            }

        }

        // Gets the current session.
        public static bool IsSessionExpired
        {
            get
            {
                ApplicationSession session =
                (ApplicationSession)HttpContext.Current.Session["__ApplicationSession__"];
                if (session == null)
                {
                    return true;
                }
                return false;
            }

        }

        public User UserDetail { get; set; }

        public Role UserRole { get; set; }
    }
}
