using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoreModel;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using static Google.Protobuf.WellKnownTypes.Field.Types;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// core默认的注入
        /// </summary>
        private readonly CoreContext db;
        private readonly IPerson entity;
        public HomeController(CoreContext db, IPerson entity)
        {
            this.db = db;
            this.entity = entity;
        }
        public IActionResult Index()
        {
            var student = entity.GetIds();
            return View();
        }
        public async Task<IActionResult> Student()
        {
            db.teacher.Add(new Teacher() { name = "pgb" });
            await db.SaveChangesAsync();
            return Content("");
        }

    }
}
