using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dev_planner_backend.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dev_planner_backend.Controllers
{
    [Produces("application/json")]
    [Route("api/items")]
    public class ItemsController : Controller
    {
        private ApplicationDbContext cnt;

        public ItemsController(ApplicationDbContext cnt)
        {
            this.cnt = cnt;
        }

        [HttpGet]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
        
    }
}