using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dev_planner_backend.Contexts;
using dev_planner_backend.Models;
using dev_planner_backend.Services;
using dev_planner_backend.Services.Mail;
using dev_planner_backend.Services.Repositories;
using dev_planner_backend.Service_Layer;
using dev_planner_backend.Service_Layer.Commands._1._Command_Handlers;
using dev_planner_backend.Service_Layer.Queries;
using dev_planner_backend.Service_Layer.Queries.Handlers;
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
        private readonly IGenericRepository<Item> repo;
        private readonly ILogger<ItemsController> logger;
        private ItemQueryHandlers queries;

        public ItemsController(IGenericRepository<Item> repo, ILogger<ItemsController> logger, ItemQueryHandlers queries)
        {
            this.repo = repo;
            this.logger = logger;
            this.queries = queries;
        }

        [HttpGet]
        public IActionResult GetItems([FromQuery] bool full)
        {
            if (!full)
            {
                return Ok(repo.Get());
            }
            
            var query = new GetFullItemsQuery();
            var result = queries.GetFullItems.Run(query);

            return Ok(result);
        }

        [HttpGet("{itemId}")]
        public IActionResult GetItem(int itemId, [FromQuery] bool full)
        {
            if (!full)
            {
                var item = repo.Get(i => i.Id == itemId).FirstOrDefault();
                if (item != null)
                {
                    return Ok(item);
                }

                logger.LogWarning($"Item with ID: {itemId} not found in the database.");
                return NotFound();  
            }

            var query = new GetFullItemQuery(itemId);
            var result = queries.GetFullItems.Run(query);

            if (result != null)
            {
                return Ok(result);
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
                return StatusCode(500, $"Something went wrong and your update request could not be processed. Please try again.");
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
                return StatusCode(500, $"Something went wrong and your delete request could not be processed. Please try again.");
            }
        }
    }
}