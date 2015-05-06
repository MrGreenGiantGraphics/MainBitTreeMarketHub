using BitTreeMarketMain.Data;
using BitTreeMarketMain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BitTreeMarketMain.Controllers
{
    public class ProductsController : Controller
    {


        // Start Shopping Cart 
        private readonly IRepository<Product> _repository;

        public ProductsController()
            : this(new MemoryRepository<Product>())
        {
        }

        public ProductsController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> Get()
        {
            return _repository.Items;
        }
        // End Shopping Cart



        private BitTreeMarketDbContext db = new BitTreeMarketDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Corportation).Include(p => p.PaymentOption).Include(p => p.Rating).Include(p => p.SalesReward).Include(p => p.SmallBusiness);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewBag.CorporationId = new SelectList(db.Corporations, "CorporationId", "Name");
            ViewBag.PaymentOptionId = new SelectList(db.PaymentOptions, "PaymentOptionId", "PaymentType");
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingId", "Review");
            ViewBag.SalesRewardId = new SelectList(db.SalesRewards, "SalesRewardId", "SalesRewardId");
            ViewBag.SmallBusinessId = new SelectList(db.Members, "SmallBusinessId", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,Details,GMO,Location,Quantity,SelectedQuantity,SmallBusinessId,CorporationId,RatingId,SalesRewardId,CategoryId,PaymentOptionId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.CorporationId = new SelectList(db.Corporations, "CorporationId", "Name", product.CorporationId);
            ViewBag.PaymentOptionId = new SelectList(db.PaymentOptions, "PaymentOptionId", "PaymentType", product.PaymentOptionId);
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingId", "Review", product.RatingId);
            ViewBag.SalesRewardId = new SelectList(db.SalesRewards, "SalesRewardId", "SalesRewardId", product.SalesRewardId);
            ViewBag.SmallBusinessId = new SelectList(db.Members, "SmallBusinessId", "Name", product.SmallBusinessId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.CorporationId = new SelectList(db.Corporations, "CorporationId", "Name", product.CorporationId);
            ViewBag.PaymentOptionId = new SelectList(db.PaymentOptions, "PaymentOptionId", "PaymentType", product.PaymentOptionId);
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingId", "Review", product.RatingId);
            ViewBag.SalesRewardId = new SelectList(db.SalesRewards, "SalesRewardId", "SalesRewardId", product.SalesRewardId);
            ViewBag.SmallBusinessId = new SelectList(db.Members, "SmallBusinessId", "Name", product.SmallBusinessId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Details,GMO,Location,Quantity,SelectedQuantity,SmallBusinessId,CorporationId,RatingId,SalesRewardId,CategoryId,PaymentOptionId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.CorporationId = new SelectList(db.Corporations, "CorporationId", "Name", product.CorporationId);
            ViewBag.PaymentOptionId = new SelectList(db.PaymentOptions, "PaymentOptionId", "PaymentType", product.PaymentOptionId);
            ViewBag.RatingId = new SelectList(db.Ratings, "RatingId", "Review", product.RatingId);
            ViewBag.SalesRewardId = new SelectList(db.SalesRewards, "SalesRewardId", "SalesRewardId", product.SalesRewardId);
            ViewBag.SmallBusinessId = new SelectList(db.Members, "SmallBusinessId", "Name", product.SmallBusinessId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}