using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoASP.Controllers
{
    [RoutePrefix("te")]
    public class TestController : Controller
    {
        [Route("a")]
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [Route("a/{id}")]
        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
