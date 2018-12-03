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

        [HttpGet("full")]
        public IActionResult GetFullItems()
        {
            var items = repo.Query()
                .Include(i => i.State)
                .Include(i => i.Owner);

            return Ok(items);
        }

        [HttpGet("{itemId}")]
        public IActionResult GetItem(int itemId)
        {
            var item = repo.Get(i => i.Id == itemId).FirstOrDefault();
            if (item != null)
            {
                return Ok(item);
            }

            logger.LogWarning($"Item with ID: {itemId} not found in the database.");
            return NotFound();
        }

        [HttpGet("{itemId}/full")]
        public IActionResult GetFullItem(int itemId)
        {
            var item = repo.Query(i => i.Id == itemId)
                .Include(i => i.State)
                .Include(i => i.Owner)
                .FirstOrDefault();

            if (item != null)
            {
                return Ok(item);
            }

            logger.LogWarning($"Item with ID: {itemId} not found in the database.");
            return NotFound();
        }

        [HttpPost]
        public IActionResult InsertItem([FromBody] Item item)
        {
            try
            {
                var savedItem = repo.Insert(item);
                return Ok(savedItem.Id);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, $"Something went wrong and your create request could not be processed. Please try again.");
            }
        }

        [HttpPut("{itemId}")]
        public IActionResult UpdateItem(int itemId, [FromBody] Item item)
        {
            if (itemId != item.Id) return BadRequest("The ID in the URL does not match the ID of the object provided.");

            try
            {
                repo.Update(item);
                return Ok(item);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, $"Something went wrong and your create request could not be processed. Please try again.");
            }
        }

        [HttpDelete("{itemId}")]
        public IActionResult DeleteItem(int itemId)
        {
            try
            {
                repo.Delete(itemId);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return StatusCode(500, $"Something went wrong and your create request could not be processed. Please try again.");
            }
        }
    }
}