using System;
using System.Collections.Generic;
using System.Linq;
using dev_planner_backend.Models;
using dev_planner_backend.Service_Layer.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dev_planner_backend.Controllers
{
    [Produces("application/json")]
    [Route("api/items")]
    public class ItemsController : Controller
    {
        private readonly ILogger<ItemsController> logger;
        private readonly IMediator mediator;

        public ItemsController(ILogger<ItemsController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetItems([FromQuery] bool returnFull = false)
        {
            List<Item> result;
            
            if (returnFull)
            {
                var query = new GetFullItemsQuery();
                result = mediator.Send(query).Result; 
            }
            else
            {
                var query = new GetItemsQuery();
                result = mediator.Send(query).Result; 
            }

            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("{itemId}")]
        public IActionResult GetItem(int itemId, [FromQuery] bool returnFull = false)
        {
            Item result;
            
            if (returnFull)
            {
                var query = new GetFullItemsQuery(itemId);
                result = mediator.Send(query).Result.FirstOrDefault(); 
            }
            else
            {
                var query = new GetItemsQuery(itemId);
                result = mediator.Send(query).Result.FirstOrDefault(); 
            }

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult InsertItem([FromBody] Item item)
        {
            try
            {
                return Ok();
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