using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChronoMarketplace.Areas.Identity.Data;
using ChronoMarketplace.Models;

namespace ChronoMarketplace.Controllers
{
    public class Shopping_OrderController : Controller
    {
        private readonly ChronoMarketplaceDbContext _context;

        public Shopping_OrderController(ChronoMarketplaceDbContext context)
        {
            _context = context;
        }

        // GET: Shopping_Order
        public async Task<IActionResult> Index()
        {
              return _context.Shopping_Order != null ? 
                          View(await _context.Shopping_Order.ToListAsync()) :
                          Problem("Entity set 'ChronoMarketplaceDbContext.Shopping_Order'  is null.");
        }

        // GET: Shopping_Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shopping_Order == null)
            {
                return NotFound();
            }

            var shopping_Order = await _context.Shopping_Order
                .FirstOrDefaultAsync(m => m.Order_ID == id);
            if (shopping_Order == null)
            {
                return NotFound();
            }

            return View(shopping_Order);
        }

        // GET: Shopping_Order/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shopping_Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Order_ID,User_ID,Cart_ID,Payment_ID,Order_date,Shipment_date")] Shopping_Order shopping_Order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopping_Order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopping_Order);
        }

        // GET: Shopping_Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shopping_Order == null)
            {
                return NotFound();
            }

            var shopping_Order = await _context.Shopping_Order.FindAsync(id);
            if (shopping_Order == null)
            {
                return NotFound();
            }
            return View(shopping_Order);
        }

        // POST: Shopping_Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Order_ID,User_ID,Cart_ID,Payment_ID,Order_date,Shipment_date")] Shopping_Order shopping_Order)
        {
            if (id != shopping_Order.Order_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopping_Order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Shopping_OrderExists(shopping_Order.Order_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shopping_Order);
        }

        // GET: Shopping_Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shopping_Order == null)
            {
                return NotFound();
            }

            var shopping_Order = await _context.Shopping_Order
                .FirstOrDefaultAsync(m => m.Order_ID == id);
            if (shopping_Order == null)
            {
                return NotFound();
            }

            return View(shopping_Order);
        }

        // POST: Shopping_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shopping_Order == null)
            {
                return Problem("Entity set 'ChronoMarketplaceDbContext.Shopping_Order'  is null.");
            }
            var shopping_Order = await _context.Shopping_Order.FindAsync(id);
            if (shopping_Order != null)
            {
                _context.Shopping_Order.Remove(shopping_Order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Shopping_OrderExists(int id)
        {
          return (_context.Shopping_Order?.Any(e => e.Order_ID == id)).GetValueOrDefault();
        }
    }
}
