using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommerceAdmin.Models;
using System.Data;

namespace IMS_Project.Controllers
{
    public class DashboardController : Controller
    {
        MyEcommerceDbContext db = new MyEcommerceDbContext();
        public ActionResult Index()
        {

            return View();
        }

    }
}