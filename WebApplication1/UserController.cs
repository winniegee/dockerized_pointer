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
    
    public class UserController : Controller
    {

        //public UserController(IConfiguration configuration)
        //{
        //    Configuration = configuration;



        //}
        public UserController(IDbContext ctx)
        {
            this.ctx = ctx;



        }
        public IDbContext ctx { get; set; }
        // public IConfiguration Configuration { get; }
        [HttpGet, Route("Usersp")]
        public IActionResult GetUsers()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Context")).EnableSensitiveDataLogging();
            //DataContext ctx = new DataContext(optionsBuilder.Options);
            var users = ctx.Set<User>().ToList();
            return Ok(users);
        }
        [HttpPost,Route("Add")]
        public IActionResult AddUsers()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Context")).EnableSensitiveDataLogging();
            //DataContext ctx = new DataContext(optionsBuilder.Options);
            User us = new User() { Email = "hshsh@gm.con", Location = "abj", Name = "mark", PhoneNumber = "0292020202" };
            User us1 = new User() { Email = "2hshsh@gm.con", Location = "abj", Name = "mark", PhoneNumber = "0292020202" };
            User us2= new User() { Email = "3hshsh@gm.con", Location = "abj", Name = "mark", PhoneNumber = "0292020202" };
            ctx.Set<User>().Add(us1);
            ctx.Set<User>().Add(us);
            ctx.SaveChanges();
           // ctx.Add(us2);
            return Ok("added");
        }
    }
}
