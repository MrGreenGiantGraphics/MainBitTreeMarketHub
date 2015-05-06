using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public partial class PickUpOrder
    {
        public PickUpOrder()
        {
            this.PaymentOptions = new HashSet<PaymentOption>();
        }

        public int PickUpOrderId { get; set; }
        public decimal Value { get; set; }
        public System.DateTime DateSold { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<PaymentOption> PaymentOptions { get; set; }
    }
}
