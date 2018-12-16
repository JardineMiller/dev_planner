using System.Collections.Generic;

namespace dev_planner_backend.Service_Layer.Queries
{
    public class GetFullItemsQuery
    {
        public readonly HashSet<int> ItemIds;

        public GetFullItemsQuery(HashSet<int> itemIds = null)
        {
            this.ItemIds = itemIds;
        }
        
    }
}