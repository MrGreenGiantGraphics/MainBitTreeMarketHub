using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public partial class Product : ShopEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public bool GMO { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public string ImageLink { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> SelectedQuantity { get; set; }
        public Nullable<int> SmallBusinessId { get; set; }
        public Nullable<int> CorporationId { get; set; }
        public Nullable<int> RatingId { get; set; }
        public Nullable<int> SalesRewardId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> PaymentOptionId { get; set; }

        public virtual Category Category { get; set; }
        public virtual SmallBusiness SmallBusiness { get; set; }
        public virtual Corporation Corportation { get; set; }
        public virtual PaymentOption PaymentOption { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual SalesReward SalesReward { get; set; }
    }
}
