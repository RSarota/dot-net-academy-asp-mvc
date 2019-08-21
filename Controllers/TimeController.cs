using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using dot_net_academy_asp_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_academy_asp_mvc.Controllers
{
    public class TimeController : Controller
    {
        private ITomorrowWrapper _tw;

        public TimeController(ITomorrowWrapper tomorrowWrapper)
        {
            _tw = tomorrowWrapper;
        }
        public IActionResult Index()
        {
            return View(_tw.GetTomorrow());
        }
    }
}