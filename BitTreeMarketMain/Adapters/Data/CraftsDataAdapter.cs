using BitTreeMarketMain.Data;
using BitTreeMarketMain.Model;
using BitTreeMarketMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitTreeMarketMain.Adapters.Data
{
    public class CraftsDataAdapter : ICraftsAdapter
    {
        public CraftsVm GetCrafts()
        {

            using (BitTreeMarketDbContext db = new BitTreeMarketDbContext())
            {
                return new CraftsVm()
                {
                    Crafts = db.Products.Where(c => c.CategoryId == 18).Select(a => new ProductVm()
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