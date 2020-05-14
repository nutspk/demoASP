using demoASP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoASP.Models;
using System.Data.Entity;

namespace demoASP.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [Route("foo/{id}/bar")]
        public ActionResult gg(int? foobar)
        {
            return View();
        }

    }
}