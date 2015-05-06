using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitTreeMarket.Hubs
{
    [HubName("cart")]
    public class ShoppingCartHub : Hub
    { }
}