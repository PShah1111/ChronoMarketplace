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
    public class Shopping_CartController : Controller
    {
        private readonly ChronoMarketplaceDbContext _context;

        public Shopping_CartController(ChronoMarketplaceDbContext context)
        {
            _context = context;
        }

        // GET: Shopping_Cart
        public async Task<IActionResult> Index()
        {
              return _context.Shopping_Cart != null ? 
                          View(await _context.Shopping_Cart.ToListAsync()) :
                          Problem("Entity set 'ChronoMarketplaceDbContext.Shopping_Cart'  is null.");
        }

        // GET: Shopping_Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shopping_Cart == null)
            {
                return NotFound();
            }

            var shopping_Cart = await _context.Shopping_Cart
                .FirstOrDefaultAsync(m => m.Cart_ID == id);
            if (shopping_Cart == null)
            {
                return NotFound();
            }

            return View(shopping_Cart);
        }

        // GET: Shopping_Cart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shopping_Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cart_ID,User_ID,Product_ID,Quantity,Total_price")] Shopping_Cart shopping_Cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopping_Cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopping_Cart);
        }

        // GET: Shopping_Cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Shopping_Cart == null)
            {
                return NotFound();
            }

            var shopping_Cart = await _context.Shopping_Cart.FindAsync(id);
            if (shopping_Cart == null)
            {
                return NotFound();
            }
            return View(shopping_Cart);
        }

        // POST: Shopping_Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cart_ID,User_ID,Product_ID,Quantity,Total_price")] Shopping_Cart shopping_Cart)
        {
            if (id != shopping_Cart.Cart_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopping_Cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Shopping_CartExists(shopping_Cart.Cart_ID))
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
            return View(shopping_Cart);
        }

        // GET: Shopping_Cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shopping_Cart == null)
            {
                return NotFound();
            }

            var shopping_Cart = await _context.Shopping_Cart
                .FirstOrDefaultAsync(m => m.Cart_ID == id);
            if (shopping_Cart == null)
            {
                return NotFound();
            }

            return View(shopping_Cart);
        }

        // POST: Shopping_Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shopping_Cart == null)
            {
                return Problem("Entity set 'ChronoMarketplaceDbContext.Shopping_Cart'  is null.");
            }
            var shopping_Cart = await _context.Shopping_Cart.FindAsync(id);
            if (shopping_Cart != null)
            {
                _context.Shopping_Cart.Remove(shopping_Cart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Shopping_CartExists(int id)
        {
          return (_context.Shopping_Cart?.Any(e => e.Cart_ID == id)).GetValueOrDefault();
        }
    }
}
