using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ViewComponents
{
    public class MyViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.name = "分布视图";
            return View();
        }
    }
}
