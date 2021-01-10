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
    public class ShoppingController : Controller
    {

        private BusinessLogicClass _businessLogicClass;
        public ShoppingController(BusinessLogicClass businessLogicClass)
        {
            this._businessLogicClass = businessLogicClass;
        }

        // GET: ShoppingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShoppingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingController/Create
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

        // HERE
        
        public ActionResult Edit(Guid customerId)
        {
            return View();
        }

        
        [ActionName("StartShoppingMenu")]
        public IActionResult LocationList(Guid customerId)
        {
            List<LocationViewModel> locationViewModelList = _businessLogicClass.LocationList();

            return View(locationViewModelList);

        }

        /*[ActionName("Shopping")]
        public IActionResult ShoppingMenu()

         public IActionResult ProductList(int locationId)
        {

            //return list of products
        }*/

        // POST: ShoppingController/Edit/5
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

        // GET: ShoppingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShoppingController/Delete/5
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
