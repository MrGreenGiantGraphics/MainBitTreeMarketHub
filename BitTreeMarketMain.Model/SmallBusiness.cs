using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public partial class SmallBusiness
    {
        public SmallBusiness()
        {
            this.Products = new HashSet<Product>();
        }

        public int SmallBusinessId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
