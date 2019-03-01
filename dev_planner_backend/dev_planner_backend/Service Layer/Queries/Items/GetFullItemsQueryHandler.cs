using System.Collections;
using System.Collections.Generic;
using System.Linq;
using dev_planner_backend.Models;
using dev_planner_backend.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace dev_planner_backend.Service_Layer.Queries
{
    public class GetFullItemsQueryHandler
    {
        private IGenericRepository<Item> repo;
        private readonly ILogger<GetFullItemsQueryHandler> logger;

        public GetFullItemsQueryHandler(IGenericRepository<Item> repo, ILogger<GetFullItemsQueryHandler> logger)
        {
            this.repo = repo;
            this.logger = logger;
        }

        public List<Item> Run(GetFullItemsQuery query)
        {
            List<Item> result;

            if (query.ItemIds != null)
            {
                result = repo.Query(i => query.ItemIds.Contains(i.Id))
                    .Include(i => i.Owner)
                    .Include(i => i.State)
                    .Include(i => i.Comments)
                    .ThenInclude(c => c.Replies)
                    .ThenInclude(c => c.Author).ToList();
            }
            else
            {
                result = repo.Query()
                    .Include(i => i.Owner)
                    .Include(i => i.State)
                    .Include(i => i.Comments)
                    .ThenInclude(c => c.Replies)
                    .ThenInclude(c => c.Author).ToList();
            }

            return result;
        }
        
        public Item Run(GetFullItemQuery query)
        {
            return repo.Query(i => query.ItemId == i.Id)
                .Include(i => i.Owner)
                .Include(i => i.State)
                .Include(i => i.Comments)
                .ThenInclude(c => c.Replies)
                .ThenInclude(c => c.Author)
                .SingleOrDefault();
        }
    }
}