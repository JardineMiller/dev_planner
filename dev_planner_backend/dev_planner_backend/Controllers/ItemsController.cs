using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dev_planner_backend.Contexts;
using dev_planner_backend.Models;
using dev_planner_backend.Services;
using dev_planner_backend.Services.Mail;
using dev_planner_backend.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;

namespace dev_planner_backend.Controllers
{
    [Produces("application/json")]
    [Route("api/items")]
    public class ItemsController : Controller
    {
        private IGenericRepository<Item> repo;
        private readonly ILogger<ItemsController> logger;

        public ItemsController(IGenericRepository<Item> repo, ILogger<ItemsController> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(repo.Get());
        }

        [HttpGet("{itemId}")]
        public IActionResult GetItem(int itemId)
        {
            var item = repo.Query(i => i.Id == itemId)
                .Include(i => i.State)
                .Include(i => i.Owner)
                .FirstOrDefault();
            
            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpGet("{itemId}/state")]
        public IActionResult GetItemState(int itemId)
        {
            var item = repo.Query(i => i.Id == itemId)
                .Include(i => i.State)
                .FirstOrDefault();
            
            if (item != null)
            {
                return Ok(item.State);
            }

            return NotFound();
        }
        
        [HttpGet("{itemId}/owner")]
        public IActionResult GetItemOwner(int itemId)
        {
            var item = repo.Query(i => i.Id == itemId)
                .Include(i => i.Owner)
                .FirstOrDefault();
            
            if (item != null)
            {
                return Ok(item.Owner);
            }

            return NotFound();
        }
    }
}