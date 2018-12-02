using System.Collections;
using System.Linq;
using dev_planner_backend.Migrations;
using dev_planner_backend.Models;

namespace dev_planner_backend.Services.Repositories
{
    public interface IItemRepository
    {
        /// <summary>
        /// Checks whether the supplied itemId matches with an item in the database
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns>True if the item is found, False if it isn't</returns>
        bool ItemExists(int itemId);
        
        /// <summary>
        /// Get all items from the database
        /// </summary>
        /// <returns>A list of items</returns>
        IEnumerable GetItems();

        /// <summary>
        /// Get a single item from the database
        /// </summary>
        /// <param name="itemId">Required. (Int) Id of the item you wish to return.</param>
        /// <param name="getFull">Optional. (Bool) Return item with all includes or not.)</param>
        /// <returns>A single item. Null if not found.</returns>
        Item GetItem(int itemId, bool getFull = false);
        
        /// <summary>
        /// Get the current state of a single item
        /// </summary>
        /// <param name="itemId">Required. (Int) Id of the item you wish to return.</param>
        /// <returns>The state of the item required. Null if not found.</returns>
        State GetItemState(int itemId);

        /// <summary>
        /// Get the current owner of a single item
        /// </summary>
        /// <param name="itemId">Required. (Int) Id of the item you wish to return.</param>
        /// <returns>The owner of the item required. Null if not found</returns>
        Person GetItemOwner(int itemId);
    }
}