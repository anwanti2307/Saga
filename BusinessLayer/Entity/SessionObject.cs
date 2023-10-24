using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BusinessLayer
{
    public class SessionObject
    {
        public User SiteUSer = null;
        public static SessionObject Sess(HttpSessionState s)
        {
            return (SessionObject)s["UserSession"];
        }

        public class User
        {
            public int UserID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MobileNo { get; set; }
            public string EmailId { get; set; }
            public string Password { get; set; }
        }
    }
}