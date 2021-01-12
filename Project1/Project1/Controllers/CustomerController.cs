using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    
    public class CustomerController : Controller
    {

        private BusinessLogicClass _businessLogicClass;
         public CustomerController(BusinessLogicClass businessLogicClass)
         {
            this._businessLogicClass = businessLogicClass;
         }



        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        [Route("{customerGuid}")]
        public ActionResult EditCustomer(Guid customerGuid)
        {
            CustomerViewModel customerViewModel = _businessLogicClass.EditCustomer(customerGuid);

            return View(customerViewModel);
        }

        [HttpPost]
        [ActionName("EditedCustomer")]
        public ActionResult EditCustomer(CustomerViewModel customerViewModel )
        {
            CustomerViewModel customerViewModel1 = _businessLogicClass.EditedCustomer(customerViewModel);
            return View("DisplayCustomerDetails", customerViewModel1 );
        }

        [ActionName("StartLocationMenu")]
        public IActionResult LocationList(Guid customerGuid)
        {
            List<LocationViewModel> locationViewModelList = _businessLogicClass.LocationList(customerGuid);
            return View("LocationList", locationViewModelList);
        }



        [HttpGet]
        public IActionResult InventoryList(int InventoryList, Guid customerGuid)//passes guid up to here
        {
            List<InventoryViewModel> inventoryViewModels = _businessLogicClass.SearchInventoryList(InventoryList, customerGuid);
            return View("InventoryList", inventoryViewModels);
        }

        [HttpGet]
        public IActionResult AddingToCart(int LocationId, int InventoryId, string productName, Guid customerGuid)//Gets all the necessary values from here
        {
            AmountToAddViewModel amountToAddViewModel = _businessLogicClass.AmountToAdd(LocationId, InventoryId, productName, customerGuid);
            return View("AddToCart", amountToAddViewModel);
        }

        public IActionResult CanBeAdded(AmountToAddViewModel amountToAddView)
        {
            if(amountToAddView.amount > amountToAddView.stock)
            {
                ModelState.AddModelError("Failure", "The amount you chose exceeded stock");
                return View("AddToCart", amountToAddView);
            }
            return View();
        }


        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
