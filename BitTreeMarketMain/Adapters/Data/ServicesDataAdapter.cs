using BitTreeMarketMain.Data;
using BitTreeMarketMain.Model;
using BitTreeMarketMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitTreeMarketMain.Adapters.Data
{
    public class ServicesDataAdapter : IServicesAdapter
    {
        public ServicesVm GetServices()
        {

            using (BitTreeMarketDbContext db = new BitTreeMarketDbContext())
            {
                return new ServicesVm()
                {
                    Services = db.Products.Where(s => s.CategoryId == 19).Select(a => new ProductVm()
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