using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Products.Dal;

namespace Products.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext context = null;
        public ProductController()
        {
            context = new ProductContext();
        }
        // GET: Product
        public ActionResult Index()
        {
             return View(context.Products.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if(ModelState.IsValid)
            { 
            context.Products.Add(p);
            context.SaveChanges();
           // List<Product> plist = context.products.ToList();
            //return View("Index");
            return RedirectToAction("Index");
            }
            else
            {
                return View("Create",p);
            }
        }
        [HttpGet]
        public ActionResult Edit (string id)
        {   
            Product p = context.Products.Find(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            Product x = context.Products.Find(p.ProductId);
            x.Price = p.Price;
            x.ProductName = p.ProductName;
            x.Price = p.Price;
            context.SaveChanges();
            List<Product> plist = context.Products.ToList();
            return View("Index",plist);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            Product p = context.Products.Find(id);
            context.Products.Remove(p);
            context.SaveChanges();
            List<Product> plist = context.Products.ToList();
            return View("Index", plist);

        }
        public ActionResult Details(string id)
        {
            Product x = context.Products.Find(id);
            return View(x);
        }
    }
}