using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Products = new HashSet<Product>();
            this.PickUpOrders = new HashSet<PickUpOrder>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string BitAddress { get; set; }
        public string ImageLink { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<PickUpOrder> PickUpOrders { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
