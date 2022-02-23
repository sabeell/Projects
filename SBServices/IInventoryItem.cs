using SBEntities;
using System.Linq;

namespace SBServices
{
    public interface IInventoryItem
    {
        IQueryable<InventoryItem> GetInventoryItems();
        InventoryItem GetInventoryItem(int ID);
        void SaveInventoryItem(InventoryItem inventoryItem);
        void UpdateInventoryItem(InventoryItem inventoryItem, int ID);
        InventoryItem DeleteInventoryItem(int ID);
    }
}