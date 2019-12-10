using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestCase.Areas.Customer.Controllers
{
    public class InfoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}