using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class SuppliesController : Controller
    {
        // GET: Supplies
        public ActionResult Index()
        {
            return View();
        }
    }
}