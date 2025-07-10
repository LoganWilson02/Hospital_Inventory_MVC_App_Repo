using AspNetCoreGeneratedDocument;
using Hospital_Inventory_MVC_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hospital_Inventory_MVC_App.Data.Service
{
    public class InventoryItemService : IInventoryItemsService
    {
        private readonly ApplicationDbContext _context;
        public InventoryItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(InventoryItem item)
        {
            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var InventoryItem = await _context.InventoryItems.SingleOrDefaultAsync(item => item.Id == id);
            if (InventoryItem != null) // Ensure the item is not null to avoid CS8604
            {
                _context.InventoryItems.Remove(InventoryItem); // Remove the entity directly
                await _context.SaveChangesAsync();
            }
        }

        public async Task<InventoryItem> Edit(InventoryItem item)
        {
            var itemToEdit = await _context.InventoryItems.SingleOrDefaultAsync(i => i.Id == item.Id);
            if (itemToEdit == null)
            {
                throw new KeyNotFoundException($"Inventory item with ID {item.Id} not found.");
            }

            // Update properties
            itemToEdit.Department = item.Department;
            itemToEdit.Name = item.Name;
            itemToEdit.Quantity = item.Quantity;
            itemToEdit.UnitOfMeasure = item.UnitOfMeasure;
            itemToEdit.PricePerUnit = item.PricePerUnit;
            itemToEdit.LastUpdated = DateTime.Now;

            _context.InventoryItems.Update(itemToEdit);
            await _context.SaveChangesAsync();
            return itemToEdit;
        }

        public async Task<IEnumerable<InventoryItem>> GetAll()
        {
            var InventoryItems = await _context.InventoryItems.OrderBy(item => item.Department).ToListAsync();
            return InventoryItems;
        }
    }
}
