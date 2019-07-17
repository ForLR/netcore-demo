using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace 用户管理.Controllers
{
    [Authorize(Policy = "仅限qq邮箱")]
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}