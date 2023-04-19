using DemoWebshop.Services;
using DemoWebshop.Services.Cart;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebshop.Controllers;

public class OrderController : Controller
{

    //KLjuč naše sesije za košaricu
    public const string sessionCartKey = "_cart"; //ovo može biti konstantna klasa u kojoj će biti sve kontante. Jer se isti ključ nalazi i u CartControlleru.cs 

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
}
