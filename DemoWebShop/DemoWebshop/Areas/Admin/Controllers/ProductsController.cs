using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoWebshop.Data;
using DemoWebshop.Models;
using Microsoft.AspNetCore.Authorization;

namespace DemoWebshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] //Zaključavamo kontroler, ako netko pokuša pristupiti preko rute, Identity paket će ga tražiti autentifikaciju 
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
              return _context.Products != null ? 
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Products'  is null.");
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            //prebacujemo što smo napisali dolje niže unutar HTTP Post Create
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? ""; //ako ne postoji poruka ona je po defaultu prazna
            
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Sku,InStock,Price,Image")] Product product, int[] categoryIds, IFormFile Image) //tu smo dodali categoryIds i IFormFile za hvatanje datoteke image
        {

            //1.korak = provjeri ako je parametar categoryIds prazan ili null
            if (categoryIds.Length == 0 || categoryIds == null)
            {
                //izbaci poruku kako se kategorije moraju odabrati
                //TempData je svojstvo/kolekcija koja kreira kratkoročne poruke u sesiji između dvije akcije kontrolera
                TempData["ErrorMessage"] = "Molimo odaberite minimalno jednu kategoriju!";
                return RedirectToAction("Create");
            }

            //2.korak = pohrani proizvod u tablicu i nakon toga poveži proizvod sa odabranim kategorijama
            if (ModelState.IsValid)
            {
                //2.1 korak = pokušaj pohraniti sliku na disk i spremi naziv slike u product.Image
                try
                {
                    //Primjer 1 naziva slike 
                    var imageName = Image.FileName.ToLower();


                    //odabir putanje gdje će slika biti spremljena
                    //rezultat: ~/www.root/images/products/naziv-slike.png
                    var saveImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", imageName);


                    //Kreiraj direktorije i podirektorije unutar zadane putanje (wwwroot/images/products)
                    Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));

                    //ovdje se datoteka fizički kopira unutar zadane putanje (wwwroot/images/products) direktorija projekta
                    using (var stream = new FileStream(saveImagePath, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }

                    //u stupac tablice u SQL pohranjujemo samo naziv datoteke
                    product.Image = imageName;

                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return RedirectToAction(nameof(Create)); //ako uploda ne prođe izbaci poruku i vrati nas na Create akciju
                }
                
                _context.Add(product); 
                await _context.SaveChangesAsync();
                
                //nakon pohrane zapisa u tablicu EF Core će u objektu popuniti vrijednost za svojstvo product.Id

                //2.2 korak = poveži product.Id sa stavkama niza categoryIds i pohrani sve u tablicu ProductCategories
                foreach (var categoryId in categoryIds)
                {
                    ProductCategory productCategory = new ProductCategory();
                    productCategory.CategoryId = categoryId;
                    productCategory.ProductId = product.Id;

                    _context.ProductCategories.Add(productCategory);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            //Dohvati ID-eve kategorija s kojima je proizvod povezan u SQL tablici ProductCategories (preselected)
            ViewBag.ProductCategories = _context.ProductCategories.Where(c => c.ProductId == product.Id).Select(p => p.CategoryId).ToList(); //to je povezano sa djelomičnim pogledom _CategoryDropDownPartial.cshtml...Vrati nam koji je proizvod povezan sa kategorijom ili kategorijama

            //Ako ne postoji error poruka spremi u ViewBag svojsvto
            ViewBag.ErrorMessage = TempData["ErrorMessage"] ?? "";


            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Sku,InStock,Price,Image")] Product product, IFormFile? newImage, int[] categoryIds)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            //Provjeri ako je odabrana barem jedna kategorija 
            if (categoryIds.Length == 0)
            {
                TempData["ErrorMessage"] = "Molimo odaberite bar jednu kategoriju"; //Vraćamo korisnika na istu formu
                return RedirectToAction(nameof(Edit), new {id = id}); //anonimni atribut =  new {id = id}
            }

            //ModelState --> prati naš model, klasu Product, odnosno atribute iznad property-a npr ako je [Required]
            if (ModelState.IsValid)
            {
                try
                {
                    //provjeri postoji li vrijednost parametra newImage (netko je dodao novu sliku)
                    if (newImage != null)
                    {
                        //Primjer naziva nove slike: 2023-04-13-19-16-22_moja_slika1.jpg
                        var newImageName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + " " + newImage.FileName.ToLower().Replace(" ", "_");

                        //odabir putanje gdje će slika biti spremljena
                        //rezultat: ~/www.root/images/products/naziv-slike.png
                        var saveImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products", newImageName);


                        //Kreiraj direktorije i podirektorije unutar zadane putanje (wwwroot/images/products)
                        Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));

                        //ovdje se datoteka fizički kopira unutar zadane putanje (wwwroot/images/products) direktorija projekta
                        using (var stream = new FileStream(saveImagePath, FileMode.Create))
                        {
                            newImage.CopyTo(stream);
                        }

                        //u stupac tablice u SQL pohranjujemo samo naziv datoteke
                        product.Image = newImageName;
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();

                    //AŽURIRANJE kategorije proizvoda u SQL tablici ProductCategories

                    //1. Izbriši sve postojeće konekcije između kategorije i proizvoda (ako postoje)
                    _context.ProductCategories.RemoveRange(_context.ProductCategories.Where(p => p.ProductId == id));
                    _context.SaveChanges();

                    //2. Ažuriraj nove podatke s vezom između proizvoda i kategorije u SQL tablici ProductCategory
                    foreach (var category in categoryIds)
                    {
                        ProductCategory productCategory = new ProductCategory();
                        productCategory.ProductId = product.Id;
                        productCategory.CategoryId = category;

                        _context.Add(productCategory);
                    }
                    _context.SaveChanges();

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
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
