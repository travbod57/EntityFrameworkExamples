using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkExamples.Controllers
{
    public class BaseController : Controller
    {
        protected UnitOfWork _unitOfWork { get; set; }
        protected StudentService StudentService { get; set; }
        protected LINQExamplesService LINQExamplesService { get; set; }

        public BaseController()
        {
            _unitOfWork = new UnitOfWork(new SchoolContext());
            StudentService = new StudentService(_unitOfWork);
            LINQExamplesService = new LINQExamplesService(_unitOfWork);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose(disposing);
            StudentService.Dispose(disposing);
            LINQExamplesService.Dispose(disposing);
            base.Dispose(disposing);
        }
    }
}