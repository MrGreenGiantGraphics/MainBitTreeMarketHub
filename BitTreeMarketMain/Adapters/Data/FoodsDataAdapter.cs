using BitTreeMarketMain.Data;
using BitTreeMarketMain.Model;
using BitTreeMarketMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitTreeMarketMain.Adapters.Data
{
    public class FoodsDataAdapter : IFoodsAdapter
    {
        public FoodsVm GetFoods()
        {

            using (BitTreeMarketDbContext db = new BitTreeMarketDbContext())
            {
                return new FoodsVm()
                {
                    Foods = db.Products.Where(f => f.CategoryId == 16).Select(a => new ProductVm()
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