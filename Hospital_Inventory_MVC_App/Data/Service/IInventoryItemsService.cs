using Hospital_Inventory_MVC_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Inventory_MVC_App.Data.Service
{
    //  Interface used for Dependency Injection.
    public interface IInventoryItemsService
    {
        Task<IEnumerable<InventoryItem>> GetAll();
        Task Delete(int id);
        Task<InventoryItem> Edit(InventoryItem item);
        Task Add(InventoryItem item);
    }
}
