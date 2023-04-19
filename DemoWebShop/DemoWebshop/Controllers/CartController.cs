using DemoWebshop.Data;
using DemoWebshop.Services;
using DemoWebshop.Services.Cart;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebshop.Controllers;

public class CartController : Controller
{
    //Stvaramo objekt klase za pristup bazi podataka, kako bi provjerili da li proizvod uopće postoji
    private readonly ApplicationDbContext _dbContext;

    //KLjuč naše sesije za košaricu
    public const string sessionCartKey = "_cart";

    //KONSTRUKTOR - Dependencies injection
    public CartController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    //GET: Cart/Index
    public IActionResult Index()
    {

        //Korak 1: Provjeri košaricu iz sesije
        List<CartItem> cart = HttpContext.Session.GetCartObjectFromJson(sessionCartKey);

        //Korak 2: Provjeri error poruku 
        ViewBag.CartErrorMessage = TempData["CartErrorMessage"] as string ?? ""; //Ako je lijeva strana null (TempData["CartErrorMessage"] as string ) ?? postavi default da bude prazan string (odnosno desna strana)

        return View(cart);
    }

    //TODO: AddToCart(int productId, decimal quantity)
    //POST: Cart/AddToCart(int productId, decimal quantity)
    [HttpPost]
    public IActionResult AddToCart(int productId, decimal quantity)
    {

        //Ako je Quantity = 0, izbaci korisnika, odnosno vrati ga na Home stranicu
        if (quantity <= 0)
        {
            return RedirectToAction(nameof(Index), "Home");
        }

        //Mogući scenariji:
        //1. Košarica je prazna (kreiraj objekt klase CartItem i popuni sa podacima, dodaj u kolekciju te spremi u sesiju)
        //2. Košarica nije prazna (A: isti proizvod već postoji, ažuriraj količinu i pohrani sve u sesiju) (B: proizvod ne postoji, dodaj ga, ažuriraj sve i dodaj u sesiju)

        //KORAK 1: Provjeri ako postoji proizvod
        var findProduct = _dbContext.Products.Find(productId);

        if (findProduct == null) 
        {
            return RedirectToAction(nameof(Index), "Home");
        }

        //KORAK 2: Provjeri sesiju za košaricu
        List<CartItem> cart = HttpContext.Session.GetCartObjectFromJson(sessionCartKey);

        //KORAK 3: Uvijeti za korištenje košarice
        if (cart.Count == 0)
        {
            //Što ako netko želi više proizvoda nego što je dostupno?
            if (quantity > findProduct.InStock)
            {
                TempData["CartErrorMessage"] = $"Nije moguće odati proizvod u košaricu! Na zalihi je dostupno {findProduct.InStock}";
                return RedirectToAction(nameof(Index));
            }

            //Kreiraj novi objekt klase CartItem i popuni ga s podacima o proizvodu i količini
            CartItem newItem = new CartItem()
            {
                Product = findProduct,
                Quantity = quantity
            };

            //Dodaj stavku u kolekciju košarice
            cart.Add(newItem);
            //Ažuriraj sesiju za košaricu
            HttpContext.Session.SetCartObjectAsJson(sessionCartKey, cart);

        }
        else 
        {
            //Ako proizvod nije u košarici, kreiraj novi objekt klase CartItem. Ako je u košarici onda samo ažuriraj količinu tog proizvoda
            var updateOrCreateItem = cart.Find(p => p.Product.Id == productId) ?? new CartItem(); //Ako je cartItem prazan, stvori prazan objekt (CartITem) koji ćemo popuniti sa podacima

            //Provjera količine proizvoda u košarici (da ne bi otišli u minus u odnosu onoga što je na stanju)
            //nova količina koja je dodana u košaricu + postojeća količina proizvoda koja se već nalazi u košarici > ukupne količine proizvoda na stanju
            if (quantity + updateOrCreateItem.Quantity > findProduct.InStock)
            {
                TempData["CartErrorMessage"] = $"Nije moguće dodati odabranu količinu proizvoda. Na zalihi je dostupno: {findProduct.InStock} proizvoda {findProduct.Title}";
                return RedirectToAction(nameof(Index));
            }

            //Uvjet za ažuriranje podataka sesije. 
            if (updateOrCreateItem.Quantity == 0) //Ako proizvod ne postoji u košarici
            {
                updateOrCreateItem.Product = findProduct;
                updateOrCreateItem.Quantity = quantity;
                cart.Add(updateOrCreateItem);
            }
            else //ako proizvod postoji u košarici pa ga dodajemo još 
            {
                updateOrCreateItem.Quantity += quantity;
            }

            //Ažuriraj sesiju, odnosno košaricu
            HttpContext.Session.SetCartObjectAsJson(sessionCartKey, cart);
        }

        return RedirectToAction(nameof(Index));

    }

    //TODO: RemoveFromCart(int productId)


    //GET: TestSession() akcija
    public IActionResult TestSession()
    {
        //SESIJA je kolekcija unutar naše aplikacije

        //Primjer 1: Jednostavan primjer dodavanja sesije po ključu i vrijednosti
        HttpContext.Session.SetString("sessionString", "Ovo je moja prva vrijednost za ključ sesije!"); //SetString(ključ,vrijednost)

        ViewBag.ReadSessionString = HttpContext.Session.GetString("sessionString");
        //Primjer ažuriranja vrijednosti postojećeg ključa sesije
        HttpContext.Session.SetString("sessionString", "Ovo je ažurirana vrijednost sesije");

        return View();
    }
}
