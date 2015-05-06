using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public partial class PaymentOption
    {
        public PaymentOption()
        {
            this.Products = new HashSet<Product>();
        }

        public int PaymentOptionId { get; set; }
        public string PaymentType { get; set; }
        public Nullable<int> PickUpOrderId { get; set; }

        public virtual PickUpOrder PickUpOrder { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
