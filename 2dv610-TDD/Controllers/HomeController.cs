using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace _2dv610_TDD.Controllers
{
    public class HomeController : Controller
{
    // GET: /<controller>/
    public ViewResult Index()
    {
        return View();
    }
}
}
