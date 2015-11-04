using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkExamples.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var leftJoin = LINQExamplesService.LeftJoin().ToList();
            var rightJoin = LINQExamplesService.RightJoin().ToList(); // switch round the join order and use the same DefaultIfEmpty()

            var groupByQuery = LINQExamplesService.GroupByQuery().ToList();
            var groupByLambda = LINQExamplesService.GroupByLambda().ToList();

            SchoolContext _ctx = new SchoolContext();

            // GetByID uses .Find() gets from Context if there already else the DB
            School sc1 = _unitOfWork.Repository<School>().GetByID(1);
            sc1.Name = "Bromley High";

            _unitOfWork.Save();

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