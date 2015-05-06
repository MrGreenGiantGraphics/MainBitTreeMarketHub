using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitTreeMarketMain.Model;
using BitTreeMarketMain.Models;

namespace BitTreeMarketMain.Adapters
{
    public interface IFoodsAdapter
    {
        FoodsVm GetFoods();
    }
}