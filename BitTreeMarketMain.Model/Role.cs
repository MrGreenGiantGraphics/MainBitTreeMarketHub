using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public class Role : IdentityRole
    {
        public const string ADMIN = "Admin";
        public const string GUEST = "Guest";
        public const string PARTNER = "Partner";
    }
}
