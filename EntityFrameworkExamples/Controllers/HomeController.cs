using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkExamples.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (SchoolContext ctx = new SchoolContext())
            {
                //ctx.Schools.Add(new School() { Id = 3, Name = "Coopers", Address = "Royal Parade" });
                //ctx.SaveChanges();

                School l = ctx.Schools.Find(1);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}