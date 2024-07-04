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
    public class ShoppingCartsController : Controller
    {
        private readonly ChronoMarketplaceDbContext _context;

        public ShoppingCartsController(ChronoMarketplaceDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
              return _context.Shopping_Cart != null ? 
                          View(await _context.Shopping_Cart.ToListAsync()) :
                          Problem("Entity set 'ChronoMarketplaceDbContext.Shopping_Cart'  is null.");
        }

        // GET: ShoppingCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shopping_Cart == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.Shopping_Cart
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,ProductId,Quantity,Totalprice")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shopping_Cart == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.Shopping_Cart.FindAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,ProductId,Quantity,Totalprice")] ShoppingCart shoppingCart)
        {
            if (id != shoppingCart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingCartExists(shoppingCart.CartId))
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
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shopping_Cart == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.Shopping_Cart
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shopping_Cart == null)
            {
                return Problem("Entity set 'ChronoMarketplaceDbContext.Shopping_Cart'  is null.");
            }
            var shoppingCart = await _context.Shopping_Cart.FindAsync(id);
            if (shoppingCart != null)
            {
                _context.Shopping_Cart.Remove(shoppingCart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingCartExists(int id)
        {
          return (_context.Shopping_Cart?.Any(e => e.CartId == id)).GetValueOrDefault();
        }
    }
}
