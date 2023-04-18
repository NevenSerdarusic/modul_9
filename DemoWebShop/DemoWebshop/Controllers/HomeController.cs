using DemoWebshop.Data;
using DemoWebshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoWebshop.Controllers;

//primjenjuje se na cijeli kontroler ili na određene akcije klase
//[Authorize] ---> Ako tu stavim ovaj atribut ne mogu mu pristupiti bez da se logiram ili registriram
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    //Privatna varijabla - instanciranje objekta klase koja komunicira sa bazom
    private readonly ApplicationDbContext _dbContext;

    //KONSTRUKTOR:
    //Dependencies injection sa klasom koja komunicira sa BAZOM
    //Tu možemo napraviti i Repository da ne spamamo Controller!!
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    //parametar string/int je NULLABLE (?) jer on ne postoji ako nismo ništa pretraživali
    public IActionResult Index(string? searchQuery, int? orderBy, int? categoryId = 0)
    {
        //FILTRIRANJE:
            //1. Ako je parametar "searchQuery" prazan ili ne postoji, prikaži sve proizvode u WebShopu   
            List<Product> products = _dbContext.Products.ToList(); //moramo inicijalizirati listu prije uvjeta

        // 2. Ako parametar "categoryId" postoji i nije 0, filtriraj proizvode po kategoriji
        if (categoryId > 0)
        {
            products = products.Where( // popis proizvoda, i postavljanje kriterija
                p => _dbContext.ProductCategories.Where(
                        pc => pc.CategoryId == categoryId // Ako je u tablici ProductCategories vrijednost stupca CategoryId = categoryId
                    ).Select(
                        pc => pc.ProductId // ako je kriterij zadovoljen, vrati vrijednost stupca productId
                    ).ToList().Contains(
                        p.Id // Nakon toga, vrati objekte klase Product, čiji ID se nalazi u rezultatu kriterija 
                    )
            ).ToList();
        }

        //2. Ako parametar "searchQuery" postoji i nije prazan, filtriraj proizvode (pretraži ključnu riječ u naslovu)
        if (!String.IsNullOrEmpty(searchQuery))
        {
                products = products.Where(p => p.Title.ToLower().Contains(searchQuery.ToLower())).ToList();
        }

        //SORTIRANJE:
            //Šifrarnik za sortiranje (0 - zadani prikaz rezultata/default, 1 - sortiranje po naslovu uzlazno, 2 - sortiranje po naslovu silazno, 3 - sortiranje po cijeni uzlazno, 4 - sortiranje po cijeni silazno)
            switch (orderBy)
            {
                case 1: products = products.OrderBy(p => p.Title).ToList(); break;
                case 2: products = products.OrderByDescending(p => p.Title).ToList(); break;
                case 3: products = products.OrderBy(p => p.Price).ToList(); break;
                case 4: products = products.OrderByDescending(p => p.Price).ToList(); break;
                
            }

        // Lista kategorija
        ViewBag.Categories = _dbContext.Categories.ToList();

        return View(products);
        //return View(_dbContext.Products.ToList()); //Kolekcija podataka klase Product na Index View-u. Ovo je u slučaju kada nema filtiriranja. Samo pokaži sve proizvode

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}