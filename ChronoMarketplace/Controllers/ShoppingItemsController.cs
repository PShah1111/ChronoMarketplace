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
    public class ShoppingItemsController : Controller
    {
        private readonly ChronoMarketplaceDbContext _context;

        public ShoppingItemsController(ChronoMarketplaceDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingItems
        public async Task<IActionResult> Index()
        {
            var chronoMarketplaceDbContext = _context.Shopping_Cart.Include(s => s.Product).Include(s => s.ShoppingOrder);
            return View(await chronoMarketplaceDbContext.ToListAsync());
        }

        // GET: ShoppingItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shopping_Cart == null)
            {
                return NotFound();
            }

            var shoppingItem = await _context.Shopping_Cart
                .Include(s => s.Product)
                .Include(s => s.ShoppingOrder)
                .FirstOrDefaultAsync(m => m.ShoppingItemId == id);
            if (shoppingItem == null)
            {
                return NotFound();
            }

            return View(shoppingItem);
        }

        // GET: ShoppingItems/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pimage");
            ViewData["ShoppingOrderId"] = new SelectList(_context.Shopping_Order, "ShoppingOrderId", "ShoppingOrderId");
            return View();
        }

        // POST: ShoppingItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingItemId,ShoppingOrderId,ProductId,Quantity,Totalprice")] ShoppingItem shoppingItem)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(shoppingItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pimage", shoppingItem.ProductId);
            ViewData["ShoppingOrderId"] = new SelectList(_context.Shopping_Order, "ShoppingOrderId", "ShoppingOrderId", shoppingItem.ShoppingOrderId);
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shopping_Cart == null)
            {
                return NotFound();
            }

            var shoppingItem = await _context.Shopping_Cart.FindAsync(id);
            if (shoppingItem == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pimage", shoppingItem.ProductId);
            ViewData["ShoppingOrderId"] = new SelectList(_context.Shopping_Order, "ShoppingOrderId", "ShoppingOrderId", shoppingItem.ShoppingOrderId);
            return View(shoppingItem);
        }

        // POST: ShoppingItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingItemId,ShoppingOrderId,ProductId,Quantity,Totalprice")] ShoppingItem shoppingItem)
        {
            if (id != shoppingItem.ShoppingItemId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingItemExists(shoppingItem.ShoppingItemId))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pimage", shoppingItem.ProductId);
            ViewData["ShoppingOrderId"] = new SelectList(_context.Shopping_Order, "ShoppingOrderId", "ShoppingOrderId", shoppingItem.ShoppingOrderId);
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shopping_Cart == null)
            {
                return NotFound();
            }

            var shoppingItem = await _context.Shopping_Cart
                .Include(s => s.Product)
                .Include(s => s.ShoppingOrder)
                .FirstOrDefaultAsync(m => m.ShoppingItemId == id);
            if (shoppingItem == null)
            {
                return NotFound();
            }

            return View(shoppingItem);
        }

        // POST: ShoppingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shopping_Cart == null)
            {
                return Problem("Entity set 'ChronoMarketplaceDbContext.Shopping_Cart'  is null.");
            }
            var shoppingItem = await _context.Shopping_Cart.FindAsync(id);
            if (shoppingItem != null)
            {
                _context.Shopping_Cart.Remove(shoppingItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingItemExists(int id)
        {
          return (_context.Shopping_Cart?.Any(e => e.ShoppingItemId == id)).GetValueOrDefault();
        }
    }
}
