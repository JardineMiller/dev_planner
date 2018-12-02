using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dev_planner_backend.Contexts;
using dev_planner_backend.Services;
using dev_planner_backend.Services.Mail;
using dev_planner_backend.Services.Repositories;
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
        private IItemRepository repo;
        private readonly ILogger<ItemsController> logger;
        private readonly IMailService mailService;

        public ItemsController(IItemRepository repo, ILogger<ItemsController> logger, IMailService mailService)
        {
            this.repo = repo;
            this.logger = logger;
            this.mailService = mailService;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(repo.GetItems());
        }

        [HttpGet("{itemId}")]
        public IActionResult GetItem(int itemId)
        {
            if (!repo.ItemExists(itemId)) return NotFound();
            return Ok(repo.GetItem(itemId, getFull: true));
        }

        [HttpGet("{itemId}/state")]
        public IActionResult GetItemState(int itemId)
        {
            if (!repo.ItemExists(itemId)) return NotFound();
            return Ok(repo.GetItemState(itemId));
        }
        
        [HttpGet("{itemId}/owner")]
        public IActionResult GetItemOwner(int itemId)
        {
            if (!repo.ItemExists(itemId)) return NotFound();
            return Ok(repo.GetItemOwner(itemId));
        }
    }
}