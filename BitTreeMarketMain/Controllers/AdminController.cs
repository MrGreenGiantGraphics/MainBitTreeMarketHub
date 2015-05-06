using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BitTreeMarketMain.Data;
using BitTreeMarketMain.Model;
using System.Web.Http;
using System.Net.Http;

namespace BitTreeMarketMain.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IRepository<Product> _repository;

        public AdminController()
            : this(new MemoryRepository<Product>())
        { }

        public AdminController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public void Put(int id, Product product)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));

            product.ProductId = id;
            var newProduct = _repository.Update(product);
            ShoppingCartHub.Value.Clients.All.updateProductCount(newProduct);
        }
    }
}