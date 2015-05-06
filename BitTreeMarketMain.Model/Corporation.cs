using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public partial class Corporation
    {
        public Corporation()
        {
            this.Products = new HashSet<Product>();
        }

        public int CorporationId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
