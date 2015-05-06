using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public partial class SalesReward
    {
        public SalesReward()
        {
            this.Products = new HashSet<Product>();
        }

        public int SalesRewardId { get; set; }
        public Nullable<int> CommissionId { get; set; }
        public Nullable<int> RewardId { get; set; }

        public virtual Commission Commission { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Reward Reward { get; set; }
    }
}
