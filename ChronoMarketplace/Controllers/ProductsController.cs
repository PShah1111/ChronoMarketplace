using System;
using System.IO; // Required for FileStream and Path classes
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChronoMarketplace.Areas.Identity.Data;
using ChronoMarketplace.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;

namespace ChronoMarketplace.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ChronoMarketplaceDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsController(ChronoMarketplaceDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? pageNumber)
        
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ProductdescSortParm"] = sortOrder == "productdesc" ? "productdesc_desc" : "productdesc";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var products = from s in _context.Product
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.PName.Contains(searchString)
                                       || s.PDescription.Contains(searchString));
            }
            switch (sortOrder)
        {
                case "name_desc":
                    products = products.OrderByDescending(s => s.PName);
                    break;
                case "productdesc":
                    products = products.OrderBy(s => s.PDescription);
                    break;
                case "productdesc_desc":
                    products = products.OrderByDescending(s => s.PDescription);
                    break;
                default:
                    products = products.OrderBy(s => s.PName);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
            return View(await products.AsNoTracking().ToListAsync());
        }
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,BrandId,PName,PImage,ImageName,PPrice,PDescription")] Product product)
        {
            // Checks if the model state is valid
            if (!ModelState.IsValid)
            {
                // Check if the image file (PImage) is not null
                if (product.PImage != null)
                {
                    // Saves Image to wwwroot/images
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(product.PImage.FileName);
                    string extension = Path.GetExtension(product.PImage.FileName);
                    product.ImageName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/lib/Images/", product.ImageName); // Update to use ImageName

                    // Save the image file to the specified path
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await product.PImage.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    // In the case where there' no image is uploaded a defualt image will be shown
                    product.ImageName = "Casio2.jpg"; // Bundle of Casio watches is the default image
                }

                // Inserting the product record into the database
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If the model state is invalid, repopulate the Brand dropdown and return the view
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName", product.BrandId);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName", product.BrandId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,BrandId,PName,PImage,ImageName,PPrice,PDescription")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandName", product.BrandId);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}