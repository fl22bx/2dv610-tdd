﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace _2dv610_TDD.Controllers
{
    public class HomeController : Controller
{
    /// <summary>
    /// Start Page
    /// </summary>
    /// <returns></returns>
    public ViewResult Index()
    {
        return View();
    }
}
}
