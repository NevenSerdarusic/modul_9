using DemoWebshop.Services.Cart;
using Newtonsoft.Json; //paket za serijalizaciju objekta

namespace DemoWebshop.Services;

public static class SessionExtensions
{
    //SERIJALIZACIJA:
    //proširujemo ISession
    public static void SetCartObjectAsJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    //DESERIJALIZACIJA:
    public static List<CartItem> GetCartObjectFromJson(this ISession session, string key)
    {
        var value = session.GetString(key);
        //ako je vrijednost null (korisnik nema još ništa u košarici) vrati praznu listu, ako je sesija zabilježena vrati njenu vrijednost kroz deserijalizaciju
        return value == null ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(value);
    }
}
