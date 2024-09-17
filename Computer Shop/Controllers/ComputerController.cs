using Computer_Shop.Contexts;
using Computer_Shop.Entities;
using Computer_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace Computer_Shop.Controllers
{
    public class ComputerController : Controller
    {
        private readonly ComputerContext _context;
        public ComputerController()
        {
            _context = new ComputerContext();
        }
        public async Task<IActionResult> Index()
        {
            var computers = await _context.Computers
                .Select(x => new Computers
                {
                    Id = x.Id,
                    Name = x.Name,
                    Brand = x.Brand,
                    InStock = x.InStock,
                    Price = x.Price,
                    Storagetype = x.Storagetype,
                    Processor = x.Processor,
                    CategoryId=x.CategoryId,
                }).ToListAsync();
            
            return View(computers);
        }
        public async Task<IActionResult> Details(int id)
        {
            var computer= await _context.Computers
                .Include(x => x.Sizes)
                .Select(x => new DetailModel
                {
                    Id = x.Id,
                    Ram = x.Sizes.Ram,
                    Storage = Convert.ToString(x.Sizes.Storage),

                    ScreenSize = x.Sizes.ScreenSize,
                }).FirstOrDefaultAsync(x => x.Id ==id );
            return View(computer);
        }

        [HttpGet]
        public async Task<IActionResult> AddComputer()
        {
            Computers computer = new();
            return View(computer);
        }

        [HttpPost]
        public async Task<IActionResult> AddComputer(Computers computer)
        {
            _context.Computers.Add(computer);
            _context.SaveChanges();
            return View(computer);

        }

        public IActionResult Edit(int id)
        {
            var computer = _context.Computers.Include(x=>x.Sizes).FirstOrDefault(x => x.Id == id);
            if (computer == null)
            {
                {
                    return RedirectToAction("Index", "Coimputer");
                }
            }

            var computers = new Computers()
            {
               Id=computer.Id,
               Name=computer.Name,
               Brand=computer.Brand,
               InStock=computer.InStock,
               Price=computer.Price,
               Processor=computer.Processor,
               Storagetype=computer.Storagetype,
               CategoryId=computer.CategoryId,
               Sizes= new Sizes
               {
                   Ram=computer.Sizes.Ram,
                   Storage=computer.Sizes.Storage,
                   ScreenSize=computer.Sizes.ScreenSize,
               }
              
              
            };
           
            ViewData["id"] = computer.Id;
            return View(computers);

            

        }
        [HttpPost]
        public IActionResult Edit(int id,  Computers computers)
        {
            var computer1 = _context.Computers.Find(id);
            if (computer1 == null)
            {
                return RedirectToAction("Index", "Computer");

            }

            computer1.Name = computers.Name;
            computer1.Brand = computers.Brand;
            computer1.InStock = computers.InStock;
            computer1.Price = computers.Price;
            computer1.Processor = computers.Processor;
            computer1.Storagetype= computers.Storagetype;
            computer1.Category = computers.Category;
            computer1.Sizes = new Sizes
            {
                Ram = computers.Sizes.Ram,
                Storage = computers.Sizes.Storage,
                ScreenSize = computers.Sizes.ScreenSize,
            };
            _context.SaveChanges();
            return RedirectToAction("Index", "Computer");

        }

        public IActionResult Delete(int id)
        {
            var computers = _context.Computers.Find(id);
            if (computers == null)
            {
                return RedirectToAction("Index", "Computer");
            }

            _context.Computers.Remove(computers);
            _context.SaveChanges(true);

            return RedirectToAction("Index", "Computer");


        }
    }
}
