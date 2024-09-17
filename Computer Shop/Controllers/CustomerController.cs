using Computer_Shop.Contexts;
using Computer_Shop.Entities;
using Computer_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Computer_Shop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ComputerContext _context;
        public CustomerController()
        {
            _context = new ComputerContext();
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _context.Customers
                .Select(x => new Customers
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address
                }).ToListAsync();
            return View(customers);
        }

        [HttpGet]
        public async Task<IActionResult> AddCustomer()
        {
            Customers customer = new();
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customers customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return View(customer);
        }

        public async  Task<IActionResult> Edit(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                {
                    return RedirectToAction("Index", "Customer");
                }
            }

            var customermodel = new Customers()
            {
                Id = customer.Id,
                FirstName= customer.FirstName,
                LastName= customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address

            };
            ViewData["id"] = customer.Id;
            return View(customermodel);



        }
        [HttpPost]
        public IActionResult Edit(int id, Customers customer)
        {
            var customers=_context.Customers.Find(id);
            if(customers == null)
            {
                return RedirectToAction("Index", "Customer");

            }

            customers.FirstName = customer.FirstName;
            customers.LastName = customer.LastName;
            customers.Email = customer.Email;
            customers.PhoneNumber = customer.PhoneNumber;
            customers.Address = customer.Address;
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");

        }


        public IActionResult Delete(int id)
        {
            var customers = _context.Customers.Find(id);
            if (customers == null)
            {
                return RedirectToAction("Index", "Customer");
            }

            _context.Customers.Remove(customers);
            _context.SaveChanges(true);

            return RedirectToAction("Index", "Customer");


        }

    }
}
