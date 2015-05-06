using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public partial class Rating
    {
        public Rating()
        {
            this.Products = new HashSet<Product>();
        }

        public int RatingId { get; set; }
        public int Score { get; set; }
        public string Review { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
