using BitTreeMarketMain.Adapters;
using BitTreeMarketMain.Adapters.Data;
using BitTreeMarketMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace BitTreeMarketMain.Controllers
{
    public class FeaturedProductController : Controller
    {
        private IFeaturedProductsAdapter _adapter;

        public FeaturedProductController()
        {
            _adapter = new FeaturedProductDataAdapter();
        }

        public FeaturedProductController(IFeaturedProductsAdapter adapter)
        {
            _adapter = adapter;
        }


        public ActionResult Index()
        {
            FeaturedProductVm Fvm = _adapter.GetFeaturedProducts();


            return View(Fvm);
        }
    }
}
