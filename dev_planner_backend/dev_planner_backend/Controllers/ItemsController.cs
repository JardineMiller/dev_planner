using System;
using System.Collections.Generic;
using dev_planner_backend.Models;
using dev_planner_backend.Service_Layer.Queries;
using dev_planner_backend.Service_Layer.Queries.Handlers;
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
        public IActionResult GetItems()
        {
            var query = new GetFullItemsQuery();
            var result = mediator.Send(query).Result;
            
            return Ok(result);
        }

        [HttpGet("{itemId}")]
        public IActionResult GetItem([FromQuery] int itemId)
        {
            var query = new GetFullItemsQuery{ ItemIds = new HashSet<int> { itemId } };
            var result = mediator.Send(query).Result;

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