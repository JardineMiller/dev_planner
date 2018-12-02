using System;
using System.Collections;
using System.Linq;
using dev_planner_backend.Contexts;
using dev_planner_backend.Controllers;
using dev_planner_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace dev_planner_backend.Services.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private ApplicationDbContext cnt;
        private readonly ILogger<ItemRepository> logger;

        public ItemRepository(ILogger<ItemRepository> logger, ApplicationDbContext cnt)
        {
            this.cnt = cnt;
            this.logger = logger;
        }

        public bool ItemExists(int itemId)
        {
            return cnt.Items.Any(i => i.Id == itemId);
        }

        public IEnumerable GetItems()
        {
            return cnt.Items.ToList();
        }

        public Item GetItem(int itemId, bool getFull = false)
        {
            if (getFull)
            {
                return cnt.Items
                    .Include(i => i.Owner)
                    .Include(i => i.State).FirstOrDefault(i => i.Id == itemId);
            }

            return cnt.Items.FirstOrDefault(i => i.Id == itemId);
        }

        public State GetItemState(int itemId)
        {
            var item = cnt.Items.Include(i => i.State).FirstOrDefault(i => i.Id == itemId);

            if (item != null)
            {
                return item.State;

            }
            logger.LogError($"Could not find Item with the id: {itemId}");
            return null;
        }

        public Person GetItemOwner(int itemId)
        {
            var item = cnt.Items.Include(i => i.Owner).FirstOrDefault(i => i.Id == itemId);

            if (item != null)
            {
                return item.Owner;
            }

            logger.LogError($"Could not find Item with the id: {itemId}");
            return null;
        }
    }
}