using Hospital_Inventory_MVC_App.Data;
using Hospital_Inventory_MVC_App.Data.Service;
using Hospital_Inventory_MVC_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Inventory_MVC_App.Controllers
{
    public class InventoryItemsController : Controller
    {
        private readonly IInventoryItemsService _inventoryItemsService;
        public InventoryItemsController(IInventoryItemsService inventoryItemsService)
        {
            _inventoryItemsService = inventoryItemsService;
        }
        public async Task<IActionResult> Index()
        {
            var InventoryItems = await _inventoryItemsService.GetAll();

            return View(InventoryItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.InventoryItem item)
        {
            if(ModelState.IsValid)
            {
                await _inventoryItemsService.Add(item);

                return RedirectToAction("Index");
            }

            return View(item);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = (await _inventoryItemsService.GetAll()).FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, InventoryItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _inventoryItemsService.Edit(item); // Pass the edited item
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _inventoryItemsService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
