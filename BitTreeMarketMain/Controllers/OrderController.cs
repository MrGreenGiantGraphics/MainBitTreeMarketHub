using BitTreeMarketMain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http;

namespace BitTreeMarketMain.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Order> _orderRepo;

        public OrderController()
            : this(new MemoryRepository<Product>(), new MemoryRepository<Order>())
        { }

        public OrderController(IRepository<Product> productRepo, IRepository<Order> orderRepo)
        {
            _productRepo = productRepo;
            _orderRepo = orderRepo;
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepo.Items;
        }

        public void Put(int id, Approval approval)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            var order = _orderRepo.Get(id);
            if (order.Approved == approval.Approved) return;

            order.Approved = approval.Approved;
            _orderRepo.Update(order);

            ShoppingCartHub.Value.Clients.Client(order.UserId).orderApproved(order);

            if (!order.Approved)
            {
                if (!ValidateQuantities(order)) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Order has illegal quantities!."));

                foreach (var product in order.Products)
                {
                    var originalProduct = _productRepo.Get(product.ProductId);
                    originalProduct.Quantity += product.SelectedQuantity;
                    _productRepo.Update(originalProduct);
                    ShoppingCartHub.Value.Clients.All.updateProductCount(originalProduct);
                }
            }
        }

        public void Post(Order order)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));
            if (!ValidateQuantities(order)) throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Order has illegal quantities!."));

            foreach (var product in order.Products)
            {
                var originalProduct = _productRepo.Get(product.ProductId);
                originalProduct.Quantity -= product.SelectedQuantity;
                _productRepo.Update(originalProduct);
                ShoppingCartHub.Value.Clients.All.updateProductCount(originalProduct);
            }

            var added = _orderRepo.Add(order);
            AdminHub.Value.Clients.All.orderReceived(added);
        }

        private bool ValidateQuantities(Order order)
        {
            foreach (var product in order.Products)
            {
                var originalProduct = _productRepo.Get(product.ProductId);
                if (originalProduct.Quantity < product.SelectedQuantity) return false;
            }

            return true;
        }
    }
}