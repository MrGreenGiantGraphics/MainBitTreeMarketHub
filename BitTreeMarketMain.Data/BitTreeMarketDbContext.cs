using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BitTreeMarketMain.Model;

namespace BitTreeMarketMain.Data
{
    public class BitTreeMarketDbContext : IdentityDbContext<ApplicationUser>
    {
        public BitTreeMarketDbContext()
            : base("name=BitTreeMarket-2018", throwIfV1Schema: true)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Commission> Commissions { get; set; }
        public virtual DbSet<Corporation> Corporations { get; set; }
        public virtual DbSet<SmallBusiness> Members { get; set; }
        public virtual DbSet<PaymentOption> PaymentOptions { get; set; }
        public virtual DbSet<PickUpOrder> PickUpOrders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Approval> Aprovals { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<SalesReward> SalesRewards { get; set; }


        public static BitTreeMarketDbContext Create()
        {
            return new BitTreeMarketDbContext();
        }

    }
}
