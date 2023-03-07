using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommerceAdmin.Models;
namespace MyEcommerceAdmin.Controllers
{
    public class HomeController : Controller
    {
        MyEcommerceDbContext db = new MyEcommerceDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}