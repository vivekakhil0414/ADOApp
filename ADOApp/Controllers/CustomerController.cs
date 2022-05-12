using BusinessAccessLayer.Contract;
using CommanLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADOApp.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomer customerService;
        public CustomerController(ICustomer customer)
        {
            customerService = customer;
        }
        public IActionResult Index()
        {
            var customers = customerService.GetCustomers();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer obj)
        {
            if (ModelState.IsValid)
            {
                var result = customerService.CreateCustomer(obj);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error in customer create!");
                    return View(obj);
                }
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var result = customerService.DeleteCustomer(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Error in delete!";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
       public IActionResult Edit(int id)
        {
            var result = customerService.GetCustomerById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            var result = customerService.EditCustomer(customer);
            if (result!=null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                
                return RedirectToAction("Index");
            }
        }

    }
}
