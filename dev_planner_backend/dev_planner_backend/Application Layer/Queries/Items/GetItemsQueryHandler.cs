using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dev_planner_backend.Contexts;
using dev_planner_backend.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace dev_planner_backend.Service_Layer.Queries
{
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, List<Item>>
    {
        private readonly ILogger<GetItemsQueryHandler> logger;
        private readonly ApplicationDbContext cnt;

        public GetItemsQueryHandler(ILogger<GetItemsQueryHandler> logger, ApplicationDbContext cnt)
        {
            this.logger = logger;
            this.cnt = cnt;
        }

        public async Task<List<Item>> Handle(GetItemsQuery query, CancellationToken token)
        {
            if (query.ItemId != null)
            {
                return await cnt.Items.Where(i => i.Id == query.ItemId)
                    .ToListAsync(token);
            }

            if (query.ItemIds == null)
            {
                return await cnt.Items
                    .ToListAsync(token);
            }

            var items = cnt.Items.Where(i => query.ItemIds.Contains(i.Id))
                .ToListAsync(token);
                
            var notFound = query.ItemIds.Where(id => !items.Result.Select(i => i.Id).Contains(id)).ToList();
            if (notFound.Any())
            {
                var ids = string.Join("],[", notFound);
                logger.LogWarning($"Could not find tasks for Ids: [{ids}]");
            }

            return await items;
        }
    }
}