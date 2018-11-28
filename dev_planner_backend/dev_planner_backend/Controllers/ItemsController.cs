using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dev_planner_backend.Contexts;
using dev_planner_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

namespace dev_planner_backend.Controllers
{
    [Produces("application/json")]
    [Route("api/items")]
    public class ItemsController : Controller
    {
        private ApplicationDbContext cnt;
        private readonly ILogger<ItemsController> logger;
        private readonly IMailService mailService;

        public ItemsController(ApplicationDbContext cnt, ILogger<ItemsController> logger, IMailService mailService)
        {
            this.cnt = cnt;
            this.logger = logger;
            this.mailService = mailService;
        }

        [HttpGet]
        public IActionResult TestDatabase()
        {
            //logger.LogInformation("Hitting Get Items API Route to validate that logging works correctly.");
            mailService.Send("Test Email", "Hitting Get Items API Route to validate that logging works correctly.");
            return Ok();
        }
        
    }
}