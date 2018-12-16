using System.Collections.Generic;

namespace dev_planner_backend.Service_Layer.Queries
{
    public class GetFullItemQuery
    {
        public readonly int ItemId;

        public GetFullItemQuery(int itemId)
        {
            this.ItemId = itemId;
        }
        
    }
}