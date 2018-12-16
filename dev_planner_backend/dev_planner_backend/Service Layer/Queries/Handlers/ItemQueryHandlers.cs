using dev_planner_backend.Service_Layer.Queries;

namespace dev_planner_backend.Service_Layer
{
    public class ItemQueryHandlers
    {
        public readonly GetItemsByNameQueryHandler GetItemsByName;
        public readonly GetFullItemsQueryHandler GetFullItems;
        
        public ItemQueryHandlers(GetItemsByNameQueryHandler getItemsByName, GetFullItemsQueryHandler getFullItems)
        {
            GetItemsByName = getItemsByName;
            GetFullItems = getFullItems;
        }
        
    }
}