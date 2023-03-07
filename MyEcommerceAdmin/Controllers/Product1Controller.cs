using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommerceAdmin.Models;
using PagedList;
//using PagedList.Mvc;

namespace MyEcommerceAdmin.Controllers
{
    public class Product1Controller : Controller
    {
        MyEcommerceDbContext db = new MyEcommerceDbContext();


        public ActionResult Index()
        {
            ViewBag.Categories = db.Categories.Select(x => x.Name).ToList();
           
            //ViewBag.TopRatedProducts = TopSoldProducts();
            ViewBag.RecentViewsProducts = RecentViewProducts();

            return View("Products");
        }

        //TOP SOLD PRODUCTS
        //public List<TopSoldProduct> TopSoldProducts()
        //{
        //    var prodList = (from prod in db.OrderDetails
        //                    select new { prod.ProductID, prod.Quantity } into p
        //                    group p by p.ProductID into g
        //                    select new
        //                    {
        //                        pID = g.Key,
        //                        sold = g.Sum(x => x.Quantity)
        //                    }).OrderByDescending(y => y.sold).Take(3).ToList();



        //    List<TopSoldProduct> topSoldProds = new List<TopSoldProduct>();

        //    for (int i = 0; i < 3; i++)
        //    {
        //        topSoldProds.Add(new TopSoldProduct()
        //        {
        //            product = db.Products.Find(prodList[i].pID),
        //            CountSold = Convert.ToInt32(prodList[i].sold)
        //        });
        //    }
        //    return topSoldProds;
        //}
        //RECENT VIEWS PRODUCTS
        public IEnumerable<Product> RecentViewProducts()
        {
            if (TempShpData.UserID > 0)
            {
                var top3Products = (from recent in db.RecentlyViews
                                    where recent.CustomerID == TempShpData.UserID
                                    orderby recent.ViewDate descending
                                    select recent.ProductID).ToList().Take(3);

                var recentViewProd = db.Products.Where(x => top3Products.Contains(x.ProductID));
                return recentViewProd;
            }
            else
            {
                var prod = (from p in db.Products
                            select p).OrderByDescending(x => x.UnitPrice).Take(3).ToList();
                return prod;
            }
        }

        

        //VIEW DETAILS
        public ActionResult ViewDetails(int id)
        {
            var prod = db.Products.Find(id);
            ViewBag.RelatedProducts = db.Products.Where(y => y.CategoryID == prod.CategoryID).ToList();
            AddRecentViewProduct(id);

            return View(prod);
        }

  

        //ADD RECENT VIEWS PRODUCT IN DB
        public void AddRecentViewProduct(int pid)
        {
            if (TempShpData.UserID > 0)
            {
                RecentlyView Rv = new RecentlyView();
                Rv.CustomerID = TempShpData.UserID;
                Rv.ProductID = pid;
                Rv.ViewDate = DateTime.Now;
                db.RecentlyViews.Add(Rv);
                db.SaveChanges();
            }
        }




        public ActionResult Products(int subCatID)
        {
            ViewBag.Categories = db.Categories.Select(x => x.Name).ToList();
            var prods = db.Products.Where(y => y.SubCategoryID == subCatID).ToList();
            return View(prods);
        }

        //GET PRODUCTS BY CATEGORY
        public ActionResult GetProductsByCategory(string categoryName, int? page)
        {
            ViewBag.Categories = db.Categories.Select(x => x.Name).ToList();
            ViewBag.SubCategories = db.SubCategories.Select(x => x.Name).ToList();
            //ViewBag.TopRatedProducts = TopSoldProducts();

            ViewBag.RecentViewsProducts = RecentViewProducts();

            var prods = db.Products.Where(x => x.SubCategory.Name == categoryName).ToList();
            return View("Products", prods.ToPagedList(page ?? 1, 9));
            
        }

        

        //SEARCH BAR RESULT
        public ActionResult Search(string product, int? page)
        {
            ViewBag.SubCategories = db.SubCategories.Select(x => x.Name).ToList();
            //ViewBag.TopRatedProducts = TopSoldProducts();

            ViewBag.RecentViewsProducts = RecentViewProducts();

            List<Product> products;
            if (!string.IsNullOrEmpty(product))
            {
                products = db.Products.Where(x => x.Name.StartsWith(product)).ToList();
            }
            else
            {
                products = db.Products.ToList();
            }
            return View("Products", products.ToPagedList(page ?? 1, 6));
        }

        public JsonResult GetProducts(string term)
        {
            List<string> prodNames = db.Products.Where(x => x.Name.StartsWith(term)).Select(y => y.Name).ToList();
            return Json(prodNames, JsonRequestBehavior.AllowGet);

        }

        //  Filter Product By Price
        public ActionResult FilterByPrice(int minPrice, int maxPrice, int? page)
        {
            ViewBag.SubCategories = db.SubCategories.Select(x => x.Name).ToList();
            //ViewBag.TopRatedProducts = TopSoldProducts();

            ViewBag.RecentViewsProducts = RecentViewProducts();
            ViewBag.filterByPrice = true;
            var filterProducts = db.Products.Where(x => x.UnitPrice >= minPrice && x.UnitPrice <= maxPrice).ToList();
            return View("Products", filterProducts.ToPagedList(page ?? 1, 9));
        }


    }
}