using DemoWebshop.Areas.Identity.Data;
using DemoWebshop.Data;
using DemoWebshop.Models;
using DemoWebshop.Services;
using DemoWebshop.Services.Cart;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebshop.Controllers;

public class OrderController : Controller
{

    //KLjuč naše sesije za košaricu
    public const string sessionCartKey = "_cart"; //ovo može biti konstantna klasa u kojoj će biti sve kontante. Jer se isti ključ nalazi i u CartControlleru.cs 


    //Objekt za pristup bazi podataka
    private readonly ApplicationDbContext _dbContext;

    //Objekt za pristup prijavljenom korisniku
    private readonly UserManager<ApplicationUser> _userManager;

    //DEPENDENCIES INJECTION kroz konstruktor
    public OrderController(ApplicationDbContext dbContext, UserManager<ApplicationUser> user)
    {
        _dbContext = dbContext;
        _userManager = user;
    }




    //GET: Order/Checkout
    public IActionResult Checkout()
    {
        //KORAK 1: pronađi sesiju i provjeri ako postoji barem jedan proizvod u košarici
        List<CartItem> cart = HttpContext.Session.GetCartObjectFromJson(sessionCartKey);

        if (cart.Count <= 0)
        {
            return RedirectToAction("Index", "Home");
        }

        //KORAK 2: Definiraj ViewBag za ispis poruka
        ViewBag.CheckoutMessages = TempData["CheckoutMessages"] as string ?? "";
        
        return View(cart);
    }

    //TODO: CreateOrder(Order newOrder)
    [HttpPost]
    public IActionResult CreateOrder(Order newOrder)
    {
        //1.KORAK - Provjera ako je košarica prazna
        //2.KORAK - Provjera ako model klase validan (Required i ostala polja)
        //3.KORAK - Pohrana na bazu, čišćenje košarice, preusmjeravanje 

        List<CartItem> cart = HttpContext.Session.GetCartObjectFromJson(sessionCartKey);

        if (cart.Count <= 0) 
        {
            return RedirectToAction("Index", "Home");
        }

        //hvatamo greške u slučaju ako netko nešto ne ispuni što je Required
        var modelErrors = new List<string>();
        if (ModelState.IsValid)
        {
            //TRUE - sva svojstva su validna
            newOrder.Total = 0; //Ovo je u slučaju da naši proizvodi imaju PDV uračunat u cijenu
            newOrder.Tax = 0;
            newOrder.Total = cart.Sum(item => item.GetTotal());

            //Uz pomoć User svojstva je moguće dobiti ID korisnika ako je prijavljen
            newOrder.UserId = _userManager.GetUserId(User);
            newOrder.User = null; //PREVARA JER ME TRAŽI User-a

            _dbContext.Orders.Add(newOrder); //Pozivamo EF i kažemo to dodaj u tablicu Orders u bazi podataka
            _dbContext.SaveChanges();

            foreach (var cartItem in cart)
            {
                OrderItem newOrderItem = new OrderItem()
                {
                    OrderId = newOrder.Id,
                    ProductID = cartItem.Product.Id,
                    Price = cartItem.Product.Price,
                    Quantity = cartItem.Quantity,
                    Total = cartItem.GetTotal()
                };
                _dbContext.OrderItems.Add(newOrderItem);
            }

            _dbContext.SaveChanges();

            //Čišćenje košarice
            HttpContext.Session.SetCartObjectAsJson(sessionCartKey, "");

            //Poruka za korisnika nakon kupnje
            TempData["ThankYouMessage"] = "Thank you for ordering";
            return RedirectToAction("Index", "Home"); //povratak na stranicu Index, Home controllera


        }
        else 
        {
            //FALSE - neki podatak nije validan!
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    modelErrors.Add(error.ErrorMessage);
                }
            }

            //Izbacuje string sa svim uhvaćenim errorima..Rezultat: Error mail <br/> Error lastname <br/>
            TempData["CheckoutMessages"] = String.Join("<br />", modelErrors);
            return RedirectToAction("Checkout");
        }

        
       
    }
}
