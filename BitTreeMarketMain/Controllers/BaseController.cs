using System;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using BitTreeMarket.Hubs;

namespace BitTreeMarketMain.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected readonly Lazy<IHubContext> ShoppingCartHub = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<ShoppingCartHub>());
        protected readonly Lazy<IHubContext> AdminHub = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<AdminHub>());
    }
}