using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Retailer.Models;

namespace Retailer.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly RetailerDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsController(RetailerDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductCode,ProductName,ProductDetails,ProductFreeze, ProductImageFile, ProductImageName")] Product product)
        {
            if (ModelState.IsValid)
            {
                // save image to wwwroot/Images/Products
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ProductImageFile.FileName);
                string extention = Path.GetExtension(product.ProductImageFile.FileName);
                product.ProductImageName = fileName = fileName + DateTime.Now.ToString("ddmmyyyyssfff") + extention;

                string pathToUploadImage = Path.Combine(wwwRootPath + "/Images/Products/", fileName);

                using (var fileStream = new FileStream(pathToUploadImage, FileMode.Create))
                {
                    await product.ProductImageFile.CopyToAsync(fileStream);
                }

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductCode,ProductName,ProductDetails,ProductFreeze, ProductImageFile, ProductImageName")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // save new image to wwwroot/Images/Products
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(product.ProductImageFile.FileName);
                    string extention = Path.GetExtension(product.ProductImageFile.FileName);
                    product.ProductImageName = fileName = fileName + DateTime.Now.ToString("ddmmyyyyssfff") + extention;

                    string pathToUploadImage = Path.Combine(wwwRootPath + "/Images/Products/", fileName);

                    using (var fileStream = new FileStream(pathToUploadImage, FileMode.Create))
                    {
                        await product.ProductImageFile.CopyToAsync(fileStream);
                    }

                    

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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
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
            var product = await _context.Products.FindAsync(id);

            // delete previous image
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "/Images/Products/", product.ProductImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
