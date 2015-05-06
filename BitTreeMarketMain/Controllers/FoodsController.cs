using BitTreeMarketMain.Adapters;
using BitTreeMarketMain.Adapters.Data;
using BitTreeMarketMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitTreeMarketMain.Controllers
{
    public class FoodsController : Controller
    {
        private IFoodsAdapter _adapter;

        public FoodsController()
        {
            _adapter = new FoodsDataAdapter();
        }

        public FoodsController(IFoodsAdapter adapter)
        {
            _adapter = adapter;
        }


        public ActionResult Index()
        {
            FoodsVm fvm = _adapter.GetFoods();


            return View(fvm);
        }
    }
}