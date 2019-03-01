using System.Collections.Generic;
using dev_planner_backend.Models;
using MediatR;

namespace dev_planner_backend.Service_Layer.Queries
{
    public class GetFullItemsQuery : IRequest<List<Item>>
    {
        public HashSet<int> ItemIds = new HashSet<int>();
        
    }
}