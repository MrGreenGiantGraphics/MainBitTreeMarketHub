using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public class Order : ShopEntity
    {
        public Order()
        {
            this.Products = new HashSet<Product>();

        }
        public int OrderId { get; set; }
        public bool Approved { get; set; }
        public double OrderTotal { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
