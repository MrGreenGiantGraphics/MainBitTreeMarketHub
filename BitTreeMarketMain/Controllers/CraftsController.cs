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
    public class CraftsController : Controller
    {
        private ICraftsAdapter _adapter;

        public CraftsController()
        {
            _adapter = new CraftsDataAdapter();
        }

        public CraftsController(ICraftsAdapter adapter)
        {
            _adapter = adapter;
        }


        public ActionResult Index()
        {
            CraftsVm cvm = _adapter.GetCrafts();


            return View(cvm);
        }
    }
}
