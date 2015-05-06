using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitTreeMarketMain.Models
{
    public class ProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string ImageLink { get; set; }



        public int? CategoryId { get; set; }
    }
}