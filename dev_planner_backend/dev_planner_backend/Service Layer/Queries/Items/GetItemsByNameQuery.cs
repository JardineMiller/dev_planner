using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev_planner_backend.Service_Layer.Queries
{
    public class GetItemsByNameQuery
    {
        public readonly List<int> ItemIds;

        public GetItemsByNameQuery(List<int> itemIds = null)
        {
            this.ItemIds = itemIds;
        }
    }
}
