using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BitTreeMarketMain.Adapters;
using BitTreeMarketMain.Adapters.Data;
using BitTreeMarketMain.Models;

namespace BitTreeMarketMain.Controllers
{
    public class ClothesController : Controller
    {
        private IClothesAdapter _adapter;

        public ClothesController()
        {
            _adapter = new ClothesDataAdapter();
        }

        public ClothesController(IClothesAdapter adapter)
        {
            _adapter = adapter;
        }



        // GET: FeaturedProduct
        public ActionResult Index()
        {
            ClothesVm cvm = _adapter.GetClothes();


            return View(cvm);
        }
    }
}
