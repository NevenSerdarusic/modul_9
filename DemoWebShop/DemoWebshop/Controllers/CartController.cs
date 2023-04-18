using Microsoft.AspNetCore.Mvc;

namespace DemoWebshop.Controllers;

public class CartController : Controller
{
    //GET: Cart/Index
    public IActionResult Index()
    {
        return View();
    }

    //TODO: AddToCart(int productId, decimal quantity)

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
