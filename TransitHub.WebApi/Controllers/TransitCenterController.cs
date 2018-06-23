using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitHub.WebApi.Models;

namespace TransitHub.WebApi.Controllers
{
    public class TransitCenterController: Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using(TransitHubContext context = new TransitHubContext())
            {
                return View(context.TransitStops);
            }
        }
    }
}
