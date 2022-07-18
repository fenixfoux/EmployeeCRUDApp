using EmployeeCRUDApp.Data;
using EmployeeCRUDApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace EmployeeCRUDApp.Controllers
{
    public class SupplierController : Controller
    {
        //display list of all
        private readonly StoreContext _context;

        public SupplierController (StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var suppliers = _context.SUPPLIER.ToList();
            ViewBag.SUPPLIER = suppliers;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveSupplier(Supplier supplier)
        {
            await _context.AddAsync(supplier);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _context.SUPPLIER.FirstOrDefaultAsync(s => s.Id == id);
            if (supplier != null)
            {
                _context.SUPPLIER.Remove(supplier);
                await _context.SaveChangesAsync(); 
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
