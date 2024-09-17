using Computer_Shop.Contexts;
using Computer_Shop.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Computer_Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ComputerContext _context;
        public OrderController()
        {
            _context = new ComputerContext();
        }
        public async  Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Select(x => new Orders
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate,
                    Quantity = x.Quantity,
                    TotalPrice = x.TotalPrice,
                    CustomerId = x.CustomerId,
                }).ToListAsync();

            return View(orders);
        }




        [HttpGet]
        public async Task<IActionResult> AddOrder()
        {
            Orders orders = new();
            return View(orders);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(Orders orders)
        {
            _context.Orders.Add(orders);
            _context.SaveChanges();
            return View(orders);
        }



        public async Task<IActionResult> Edit(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                {
                    return RedirectToAction("Index", "Order");
                }
            }

            var ordermodel = new Orders()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice,
                CustomerId = order.CustomerId,
               

            };
            ViewData["id"] = order.Id;
            return View(ordermodel);



        }
        [HttpPost]
        public IActionResult Edit(int id, Orders order)
        {
            var orders = _context.Orders.Find(id);
            if (orders == null)
            {
                return RedirectToAction("Index", "Order");

            }

            orders.OrderDate = order.OrderDate;
            orders.Quantity = order.Quantity;
            orders.TotalPrice = order.TotalPrice;
            orders.CustomerId=order.CustomerId;
            _context.SaveChanges();
            return RedirectToAction("Index", "Order");

        }


        public IActionResult Delete(int id)
        {
            var orders = _context.Orders.Find(id);
            if (orders == null)
            {
                return RedirectToAction("Index", "Order");
            }

            _context.Orders.Remove(orders);
            _context.SaveChanges(true);

            return RedirectToAction("Index", "Order");


        }

    }
}




    