namespace dev_planner_backend.Service_Layer.Queries.Handlers
{
    public class ItemQueryHandlers
    {
        public readonly GetFullItemsQueryHandler GetFullItems;
        public readonly GetItemsByNameQueryHandler GetItemsNyName;
        
        public ItemQueryHandlers(GetFullItemsQueryHandler getFullItems, GetItemsByNameQueryHandler getItemsNyName)
        {
            GetFullItems = getFullItems;
            GetItemsNyName = getItemsNyName;
        }
        
    }
}