﻿using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyIceDream.Areas.Identity.Data;
using MyIceDream.Models;


namespace MyIceDream.Controllers
{
    public class ProductsController : Controller
    {
       private readonly ApplicationDbContext _context;
      
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
            
        }


        // GET: Product

        public async Task<IActionResult> Index(int? SelectedCategoryId)
        {
            IQueryable<Product> products = _context.Products.Include(p => p.Category);

            if (SelectedCategoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == SelectedCategoryId.Value);
            }
            var model = new ProductIndexViewModel
            {
                Products = await products.ToListAsync(),
                Categories = _context.Categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList(),


                SelectedCategoryId = SelectedCategoryId

            };
           
            return View(model);

        }


        // GET: Product/Details/{id}
        public IActionResult Details(int id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Image, Price, CategoryId, Availability")] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var files = HttpContext.Request.Form.Files;

                    if (files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                        if (!Directory.Exists(uploads))
                        {
                            Directory.CreateDirectory(uploads);
                        }

                        var extension = Path.GetExtension(files[0].FileName);

                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        product.Image = $"/images/{fileName}{extension}";
                    }

                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log error, e.g.:
                    Console.WriteLine($"Error saving product: {ex.Message}");
                    ModelState.AddModelError("", "An error occurred while saving the product. Please try again.");
                }
            }
            //if (ModelState.IsValid)
            //{
            //    var files = HttpContext.Request.Form.Files;


            //    if (files.Count > 0)
            //    {
            //        string fileName = Guid.NewGuid().ToString();
            //        var uploads = Path.Combine(@"images");
            //        var extension = Path.GetExtension(files[0].FileName);

            //        using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            //        {
            //            files[0].CopyTo(fileStream);
            //        }

            //        product.Image = @"\images\" + fileName + extension;

            //    }

            //    _context.Products.Add(product);
            //    _context.SaveChanges();
            //    return RedirectToAction(nameof(Index));
            //}
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);


        }

        // GET: Product/Edit/{id}
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/{id}
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Image, Price, CategoryId, Availability")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {

                    var files = HttpContext.Request.Form.Files;

                    if (files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(@"images");
                        var extension = Path.GetExtension(files[0].FileName);

                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        product.Image = @"\images\" + fileName + extension;
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Product/Delete/{id}
        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            return RedirectToAction(nameof(Index));
        }

        
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }


    }
}
