using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dev_planner_backend.Contexts;
using dev_planner_backend.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace dev_planner_backend.Service_Layer.Queries
{
    public class GetFullItemsQueryHandler : IRequestHandler<GetFullItemsQuery, List<Item>>
    {
        private readonly ILogger<GetFullItemsQueryHandler> logger;
        private ApplicationDbContext cnt;

        public GetFullItemsQueryHandler(ILogger<GetFullItemsQueryHandler> logger, ApplicationDbContext cnt)
        {
            this.logger = logger;
            this.cnt = cnt;
        }

        public async Task<List<Item>> Handle(GetFullItemsQuery query, CancellationToken token)
        {
            List<Item> items;
            
            if (query.ItemIds.Any())
            {
                items = cnt.Items.Where(i => query.ItemIds.Contains(i.Id)).ToList();
                var notFound = query.ItemIds.Where(id => !items.Select(i => i.Id).Contains(id)).ToList();

                if (notFound.Any())
                {
                    logger.LogWarning($"Could not find ids for [{string.Join("],[",  notFound)}]");
                }  
            }
            else
            {
                items = cnt.Items.ToList();
            }

            return items;
        }


    }
}