using BitTreeMarketMain.Data;
using BitTreeMarketMain.Model;
using BitTreeMarketMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitTreeMarketMain.Adapters.Data
{
    public class FeaturedProductDataAdapter : IFeaturedProductsAdapter
    {
        public FeaturedProductVm GetFeaturedProducts()
        {

            using (BitTreeMarketDbContext db = new BitTreeMarketDbContext())
            {
                return new FeaturedProductVm()
                {
                    FeaturedProducts = db.Products.Take(12).Select(a => new ProductVm()
                    {
                        Id = a.Id,
                        Details = a.Details,
                        Name = a.Name,
                        CategoryId = a.CategoryId,
                        ImageLink = a.ImageLink
                    }).ToList()
                };

            }


        }
    }
}