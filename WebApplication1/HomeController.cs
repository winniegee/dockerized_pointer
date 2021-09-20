using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        public IDbContext ctx;
        public HomeController(IConfiguration configuration, IDbContext ctx)
        {
            Configuration = configuration;
            this.ctx = ctx;
        }

        [Route("UserIndex")]
        public IActionResult Indexx()
        {
            return View();
        }
        
       
    }
}
