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

        /*  Index Action Method
         *  This method retrieves all inventory items and returns them to the view.
         */
        public async Task<IActionResult> Index()
        {
            var InventoryItems = await _inventoryItemsService.GetAll();

            return View(InventoryItems);
        }

        /*  Create Action Method
         *  This method displays the form for creating a new inventory item.
         */
        public IActionResult Create()
        {
            return View();
        }

        /*  Create Action Method (POST)
         *  This method handles the form submission for creating a new inventory item.
         *  It validates the model and adds the item to the database.
         */
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

        /*  Edit Action Method
         *  This method retrieves an inventory item by its ID and returns it to the view for editing.
         */
        public async Task<IActionResult> Edit(int id)
        {
            var item = (await _inventoryItemsService.GetAll()).FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        /*  Edit Action Method (POST)
         *  This method handles the form submission for editing an existing inventory item.
         *  It validates the model and updates the item in the database.
         */
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

        /*  Delete Action Method
         *  This method displays the confirmation view for deleting an inventory item.
         *  Delete could be implemented without this.
         */
        public IActionResult Delete()
        {
            return View();
        }

        /*  Delete Action Method (POST)
         *  This method handles the confirmation submission for deleting an inventory item.
         *  It deletes the item from the database and redirects to the index view.
         */
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _inventoryItemsService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
