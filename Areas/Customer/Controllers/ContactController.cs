﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestCase.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}