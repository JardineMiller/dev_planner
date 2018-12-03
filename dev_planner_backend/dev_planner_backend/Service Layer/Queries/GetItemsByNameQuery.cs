using System.Collections.Generic;
using System.Linq;
using dev_planner_backend.Models;
using dev_planner_backend.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace dev_planner_backend.Service_Layer.Queries
{
    public class GetItemsByNameQuery
    {
        private IGenericRepository<Item> repo;
        private readonly ILogger<GetItemsByNameQuery> logger;

        private readonly List<int> itemIds;
        private List<Item> items;

        public GetItemsByNameQuery(IGenericRepository<Item> repo, ILogger<GetItemsByNameQuery> logger, List<int> itemIds = null)
        {
            this.repo = repo;
            this.logger = logger;
            this.itemIds = itemIds;
        }

        public Dictionary<string, Item> Run()
        {
            initialiseContext();

            var itemsByName = new Dictionary<string, Item>();

            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.Name)) continue;

                if (!itemsByName.ContainsKey(item.Name))
                {
                    itemsByName.Add(item.Name, item);
                }
                else
                {
                    // TODO: This is to just demonstrate/test the functionality of Query classes - I know the logic below doesn't make much sense, but work with me here.
                    logger.LogWarning($"Person with the name {item.Name} already found in the dictionary, adding the person that was created last.");
                    if (itemsByName[item.Name].Id < item.Id)
                    {
                        itemsByName[item.Name] = item;
                    }
                }
            }

            return itemsByName;
        }

        private void initialiseContext()
        {
            items = itemIds != null ? 
                repo.Query(p => itemIds.Contains(p.Id)).ToList() : repo.Get();
        }
    }
}