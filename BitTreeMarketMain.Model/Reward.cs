using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public partial class Reward
    {
        public Reward()
        {
            this.SalesRewards = new HashSet<SalesReward>();
        }

        public int RewardId { get; set; }
        public Nullable<int> Amount { get; set; }

        public virtual ICollection<SalesReward> SalesRewards { get; set; }
    }
}
