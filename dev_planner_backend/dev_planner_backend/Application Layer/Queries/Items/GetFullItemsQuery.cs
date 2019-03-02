using System.Collections.Generic;
using dev_planner_backend.Models;
using MediatR;

namespace dev_planner_backend.Service_Layer.Queries
{
    public class GetFullItemsQuery : IRequest<List<Item>>
    {
        public HashSet<int> ItemIds;
        public int? ItemId;

        public GetFullItemsQuery(int? itemId = null, HashSet<int> itemIds = null)
        {
            this.ItemIds = itemIds;
            this.ItemId = itemId;
        }
    }
}