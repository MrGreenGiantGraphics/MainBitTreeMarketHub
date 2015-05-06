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
    public class HomeGardenController : Controller
    {
        private IHomeGardenAdapter _adapter;

        public HomeGardenController()
        {
            _adapter = new HomeGardenDataAdapter();
        }

        public HomeGardenController(IHomeGardenAdapter adapter)
        {
            _adapter = adapter;
        }


        public ActionResult Index()
        {
            HomeGardenVm HGvm = _adapter.GetHomeGarden();


            return View(HGvm);
        }
    }
}