using dev_planner_backend.Service_Layer.Queries;

namespace dev_planner_backend.Service_Layer
{
    public class ItemQueryHandlers
    {
        public readonly GetItemsByNameQueryHandler GetItemsByName;
        
        public ItemQueryHandlers(GetItemsByNameQueryHandler getItemsByName)
        {
            GetItemsByName = getItemsByName;
        }
        
    }
}