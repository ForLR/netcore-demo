using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace OptionBindSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly School _school;

        public HomeController(IOptionsSnapshot<School> options)
        {
            this._school = options.Value;
        }

        public IActionResult Index()
        {
            return View(_school);
        }
    }
}