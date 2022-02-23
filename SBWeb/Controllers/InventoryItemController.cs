using SBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.IO;

namespace SBWeb.Controllers
{
    public class InventoryItemController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            IEnumerable<InventoryItem> itemList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("InventoryItem").Result;
            itemList = response.Content.ReadAsAsync<List<InventoryItem>>().Result;
            var itemData = new InventoryItemDTO()
            {
                InventoryItemList = itemList.ToList()
            };
            return View(itemData);
        }

        [HttpPost]
        public ActionResult Create(InventoryItemDTO itemDto)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("InventoryItem", itemDto.InvItem).Result;
            TempData["SuccessMessage"] = "Saved Successfully";
            return RedirectToAction("Create");
        }
        
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("InventoryItem/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Create");
        }

        public ActionResult Update(InventoryItemDTO itemDto, int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("InventoryItem", itemDto.InvItem + id.ToString()).Result;
            TempData["SuccessMessage"] = "Updated Successfully";
            return RedirectToAction("Create");
        }
        public ActionResult Details(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("InventoryItem/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<InventoryItem>().Result);
        }
    }
}