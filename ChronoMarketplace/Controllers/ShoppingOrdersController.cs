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
    public class ShoppingOrdersController : Controller
    {
        private readonly ChronoMarketplaceDbContext _context;

        public ShoppingOrdersController(ChronoMarketplaceDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingOrders
        public async Task<IActionResult> Index()
        {
              return _context.Shopping_Order != null ? 
                          View(await _context.Shopping_Order.ToListAsync()) :
                          Problem("Entity set 'ChronoMarketplaceDbContext.Shopping_Order'  is null.");
        }

        // GET: ShoppingOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shopping_Order == null)
            {
                return NotFound();
            }

            var shoppingOrder = await _context.Shopping_Order
                .FirstOrDefaultAsync(m => m.ShoppingOrderId == id);
            if (shoppingOrder == null)
            {
                return NotFound();
            }

            return View(shoppingOrder);
        }

        // GET: ShoppingOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingOrderId,CustomerId,PaymentId,ShoppingFirstName,Orderdate,Shipmentdate,Totalprice,OrderStatus,CartQuantity")] ShoppingOrder shoppingOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingOrder);
        }

        // GET: ShoppingOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shopping_Order == null)
            {
                return NotFound();
            }

            var shoppingOrder = await _context.Shopping_Order.FindAsync(id);
            if (shoppingOrder == null)
            {
                return NotFound();
            }
            return View(shoppingOrder);
        }

        // POST: ShoppingOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingOrderId,CustomerId,PaymentId,ShoppingFirstName,Orderdate,Shipmentdate,Totalprice,OrderStatus,CartQuantity")] ShoppingOrder shoppingOrder)
        {
            if (id != shoppingOrder.ShoppingOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingOrderExists(shoppingOrder.ShoppingOrderId))
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
            return View(shoppingOrder);
        }

        // GET: ShoppingOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shopping_Order == null)
            {
                return NotFound();
            }

            var shoppingOrder = await _context.Shopping_Order
                .FirstOrDefaultAsync(m => m.ShoppingOrderId == id);
            if (shoppingOrder == null)
            {
                return NotFound();
            }

            return View(shoppingOrder);
        }

        // POST: ShoppingOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shopping_Order == null)
            {
                return Problem("Entity set 'ChronoMarketplaceDbContext.Shopping_Order'  is null.");
            }
            var shoppingOrder = await _context.Shopping_Order.FindAsync(id);
            if (shoppingOrder != null)
            {
                _context.Shopping_Order.Remove(shoppingOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingOrderExists(int id)
        {
          return (_context.Shopping_Order?.Any(e => e.ShoppingOrderId == id)).GetValueOrDefault();
        }
    }
}
