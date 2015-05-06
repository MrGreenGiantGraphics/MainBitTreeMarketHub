using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public partial class Commission
    {
        public Commission()
        {
            this.SalesRewards = new HashSet<SalesReward>();
        }

        public int CommissionId { get; set; }
        public Nullable<int> Amount { get; set; }

        public virtual ICollection<SalesReward> SalesRewards { get; set; }
    }
}
