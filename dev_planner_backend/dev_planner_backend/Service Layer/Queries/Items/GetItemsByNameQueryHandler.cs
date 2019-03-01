using System.Collections.Generic;
using System.Linq;
using dev_planner_backend.Models;
using Microsoft.Extensions.Logging;


namespace dev_planner_backend.Service_Layer.Queries
{
    public class GetItemsByNameQueryHandler
    {
        private readonly ILogger<GetItemsByNameQueryHandler> logger;

        private List<Item> items;

        public GetItemsByNameQueryHandler(ILogger<GetItemsByNameQueryHandler> logger)
        {
            this.logger = logger;
        }

        public Dictionary<string, Item> Run(GetItemsByNameQuery query)
        {
            initialiseContext(query.ItemIds);

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
                    logger.LogWarning($"Person with the name [{item.Name}] already found in the dictionary, adding the person that was created last.");
                    if (itemsByName[item.Name].Id < item.Id)
                    {
                        itemsByName[item.Name] = item;
                    }
                }
            }

            return itemsByName;
        }

        private void initialiseContext(ICollection<int> itemIds)
        {
            
        }
    }
}