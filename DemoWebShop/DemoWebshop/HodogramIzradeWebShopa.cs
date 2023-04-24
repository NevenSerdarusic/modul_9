namespace DemoWebshop
{
    #region
    //KOJI SE SVE PAKETI DODAJU U DEPENDECIES:
    //Microsoft.AspNetCore.Identity --> ovaj paket generira ostala 4 paketa
    //Microsoft.AspNetCore.Identity.EntityFrameworkCore
    //Microsoft.EntityFrameworkCore.SqlServer
    //Microsoft.EntityFrameworkCore.Tools
    //Microsoft.VisualStudio.Web.CodeGeneration.Design
    #endregion

    //============================================================================================================

    #region
    //SADRŽAJ AREAS FOLDER-a:
    //Identity
    //Data
    //ApplicationDbContext.cs
    //ApplicationUser.cs
    //Pages
    //Account
    #endregion

    //============================================================================================================

    #region
    //PODEŠAVANJE PROJEKTA:

    //Dodavanje partial View-a Identifikacije ----- Views/Shared/Layout.cshtml (Register/Login)

    //Kreiranje servisa za korištenje RazorPage opcija ----- Program.cs ---> builder.Services.AddRazorPages();

    //Mapiranje RazorPage stranica ---- Program.cs ---> app.MapRazorPages();

    //Brisanje generiranog Connection stringa iz datoteke ---- appsettings.json (sakrivamo povjerljive podatke)

    //Stvaranje novog Connection stringa ----appsettings.Development.json ---> "Server=localhost\\sqlexpress; Database=m9_webshop; Integrated Security=true; TrustServerCertificate=true; MultipleActiveResultSets=true;" (u ovoj datoteci ostaje Connection string LOKALNO, ne ide na Github)

    //Izbacivanje gornje datoteke iz projekta ---- .gitIgnore (LocalDisc C: > users > anama > source > modul_9)  (drag and drop u VS) ---> appsettings.Development.json

    //Ovo gore ne prolazi jer smo već stavili .gitIgnore na Github. Onda brišemo datoteku aasettings.Development.json i ponovno je stvaramo na Add/New Item (samo upišem to ime dataoteke, ona će direktno spremiti pod appsettings.json)

    //Ažurirati conection String ---- Program.cs ---> var connectionString = builder.Configuration.GetConnectionString("Default")

    //Promjena bool-a za slanje mailova za potvrdu --- Program.cs ---> SignIn.RequireConfirmedAccount = false 

    //Radimo prvu migraciju prema bazi ---- Package Manager Console ---> PM> add-migration CreateIdentityTables (stvara se folder Migration u hijerarhiji)

    //Radimo prvi update u bazu --- Package Manager Console ---> PM> update-database

    //U bazi nama su važne tablice: AspNetRoles/AspNetUserRoles/AspNetUsers

    //Ako želimo promijeniti svojstva User-a to radimo unutar ApplicationUser.cs

    //Radimo drugu migraciju, dodajemo proširenje tablice User ---- Package Manager Console ---> add-migration ExpandUserTable

    //Radimo drugi update u bazu --- Package Manager Console ---> PM> update-database

    //Kreiranje klasa modela ---- Models Folder ---> (Category, Order, Product, OrderItem, ProductCategory)

    //Radimo seed-anje podataka za tablice --- AplicationDbContext.cs ---> DbSet<Category>, ...
    #endregion

    //============================================================================================================

    #region
    //PODEŠAVANJE ADMINISTRATORA:

    //Ograničavamo autorizaciju za neprijavljene korisnike --- HomeController.cs ---> [Authorize] atribut iznad same klase (zaključavanje koda za neprijavljene korisnike)

    //Seed-anje prvog korisničkog računa, administratora --- AplicationDbContext.cs ---> ADMIN, CUSTOMER

    //Radimo migraciju podataka za korisnike --- Package Manager Console ---> PM> add-migration SeedAspNetRolesTable

    //update-database migracije gore navedene (u SQL-u to možemo provjeriti na dbo.AspNetRoles)

    //Kreiranje Administratora --- AplicationDbContext.cs ---> Asp.Net.Users i Asp.Net.UserRoles

    //kreiranje migracije za , odnosno za podatke iznad --- Package Manager Console ---> CreateAdminUser

    //updejtanje baze podataka --- Package Manager Console ---> update-database

    //Nakon ovoga sad možemo se logirati sa podacima za admnina: username+lozinka --- na početnoj stranici piše Hello, admin!

    //Kreiranje foldera za Admina unutar Areas Foldera (Controllers + Views). Odvajamo javni dio aplikaicje od ograničenog, dostupnog samo preko admina

    //Radimo novi kontroler unutar mape Areas/Admin/Controllers --- (Add New Controler) ---> MVC Controller with Views using Entity Framework (predložak) - ovo izgenerira CRUD unutar View-s na temelju model klase koji smo izabrali (npr.Category)   

    //želimo ubaciti izbornik pored Privacy-a na početnoj stranici za Administratora (taj dio se vidi samo kad se Admin prijavi) --- Views/Shared ---> Add New View/Empty ---> _AdminMenuPartial (naziv djelomičnog pogleda)

    //Dodajemo gore navedeni Partial View na ribbon u glavnom izborniku --- Views/Shared/Layout.cshtml

    //Moramo dodati uloge unutar postavki servisa --- Program.cs ---> builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>(); ___dio koji dodajemo: AddRoles<IdentityRole>()

    //dodavanje rute za Admina unutar posavki servisa ---- Program.cs ---> app.MapAreaControllerRoute

    //unutar partial viewa za admina dodati padajuće izbornike (npr.Category) --- _AdminMenuPartial 

    //pošto nemamo dizajn unutar novog partial view-a (Categories) u Admin izborniku moramo kopirati (_ViewImports.cshtml i _ViewStart.cshtml) koji se nalaze unutar Views foldera i kopirati te dvije datoteke unutar Areas/Admin/Views
    #endregion

    //=========================================================================================================

    #region
    //PODEŠAVANJE LOZINKE ZA KORISNIKA (ako želimo olabaviti lozinku)

    //unutar Program.cs ---> builder.Services.Configure<IdentityOptions>
    #endregion

    //==========================================================================================================

    #region
    //PROŠIRIVANJE HTML FORME za registraciju korisnika (ime,prezime,adresa) i želimo im automatski dodijeliti ulogu Customer

    //To radimo unutar Register.cshtml.cs --- Areas/Identity/Pages/Account/Register.cshtml ---> private readonly RoleManager<IdentityRole> _roleManager;

    //Nakon toga moramo to napraviti i u HTML-u da se to renderira kad odemo na Register--- Register.cshtml 

    //Moramo dodati novog korisnika u metodu --- Register.cshtml.cs ---> public async Task<IActionResult> OnPostAsync(string returnUrl = null)

    //Dodavanje uloge Cutomera --- Register.cshtml.cs ---> var customerRole = _roleManager.FindByNameAsync("Customer").Result;

    //Ostaje još jedan problem!! Kupac može u URL-u doći do podataka (pr.https://localhost:7192/admin/products/index)

    //To rješavamo tako da unutar Controllera koji pripadaju Adminu proširimo na: [Authorize(Roles = "Admin")] 
    #endregion

    //==========================================================================================================

    #region
    //PODEŠAVANJE DIZAJNA JAVNOG DIJELA APLIKACIJE (Home Page)
    //(ovaj dio je vidljiv na Home dijelu stranice bez potrebe da se logiramo ili registriramo)

    //Uređivanje Home Page-a --- Views/Home/Index.cshtml

    //Prebacivanje liste proizvoda iz baze podataka u Home/Index View --- HomeController.cs ---> Index Akcija + ApplicationDbContext
    //Glavna klasa, most između baze podataka i Controllera: [ApplicationDbContext.cs] --- preko nje dohvaćamo naše klase koje smo stvorili

    //Dodali smo Defaultni Placeholder za Fotografije (Copy/Paste) unutar foldera wwwroot/images/

    //FILTRIRANJE proizvoda ---- Views/Home/Index.cshtml (radimo html formu uz pomoć Bootstrapa)
    //                      ---- HomeController.cs/Index Akcija (proslijeđujemo parametar searchQuery iz forme iznad)
    //Uključiti Case Sensitive za mala i velika slova

    //SORTIRANJE proizvoda
    #endregion

    //==========================================================================================================

    #region
    //EDITIRANJE I BRISANJE PROIZVODA

    //EDITIRANJE:
    //Promjene koje radimo su u datotekama ----> Areas/Admin/Controllers/ProductsControllers.cs i Areas/Admin/Views/Products/Edit.cshtml

    //Kada radimo Edit a imamo partial view moramo dodati još jedan parametar u ProductController.cs u Edit akciju --- int[] categoryIds --- _CategoryDropDownPartial.cshtml

    //Za promjenu slike u editiranju dodali smo još jedan parametar --- IFormFile? newImage (on je opcionalan, zato stavljamo ?)

    //Kod editiranja smo imali problem sa dodavanjem nove slike proizvoda, koja se drukčije šalje preko Html forme (IFormFile newImage je prazan a dodali smo novu sliku)
    //moramo uključiti enkripciju za kompleksnije podatke kao što su slike
    //Rješenje: enctype="multipart/form-data" dodati u početnu formu --- form asp-action="Edit" enctype="multipart/form-data"
    //Tada se ta datoteka pohranjuje u privremeni/TEMP folder i kada više nema HTTP zahtjeva Temp se briše

    //Preselektirane kategorije proizvoda --- ProductControllers.cs/[GET] Edit ---> ViewBag.ProductCategories = _context.ProductCategories.Where(c => c.ProductId == product.Id).Select(p => p.CategoryId).ToList();
    //Nakon te linije koda moramo ažurirati partialView ---> _CategoryDropDownPartial.cshtml

    //BRISANJE:
    //ProductsController.cs --- GET Delete akcija

    //Brisanje fotografija proizvoda (u slučaju da proizvodi ne dijele istu fotografiju) --- proširujemo metodu u GET Delete akciji
    #endregion

    //==========================================================================================================

    #region
    //IZRADA SESIJE

    //link za sesije na dokumentaciji: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-6.0#session-state

    //dodajemo novi Empty Controller za košaricu --- Controllers Folder - Add New - CartController.cs

    //kreiranje servisa za sesiju --- Program.cs ---> builder.Services.AddDistributedMemoryCache(); , builder.Services.AddSession();, app.UseSession();

    //Dodajemo TestSession/Košarica gumba na Home page-u --- Views/Shared/Layout.cshtml ---> ispod Privacy buttona

    //Dodavanje Empty Viewa za TestSession akciju --- označiti akciju i AddView ---> sprema se u Views/Cart folder

    //Dodali smo također ključ ako netko posjeti stranicu Privacy na našem webu --- Views/Home/Privacy.cshtml (samo za probu)
    #endregion

    //==========================================================================================================

    #region
    //IZRADA KOŠARICE

    //Dodavanje forme za košaricu --- Index.cshtml ---> <form method="POST" asp-area="" asp-controller="Cart" asp-action="AddToCart">

    //Dodavanje HTTP Post akcije u kontroleru --- CartController.cs ---> public IActionResult AddToCart(int productId, decimal quantity)

    //Treba postaviti uvjete za košaricu --- CartController.cs ---> public IActionResult AddToCart

    //Ubrizgavamo ovisnost o dbContext klasi unutar našeg kontrolera --- CartController.cs ---> private readonly ApplicationDbContext _dbContext;

    //Radimo novi folder --- Services

    //Unutar tog foldera radimo folder koji je vezan uz košaricu --- Cart 

    //Unutar foldera Cart radimo klasu koja će biti vezana uz sesiju --- CartItem.cs

    //Radimo statičku klasu za sesije --- Services/SessionExtensions.cs

    //Moramo instalirati paket za serijalizaciju --- Nuget ---> NewtonSoft.json

    //Unutar SessionExtensions.cs radimo metode za serijalizaciju/deserijalizaciju

    //Definiramo varijablu za ključ sesije za košaricu --- CartController.cs ---> public const string sessionCartKey = "_cart";

    //Radimo view za košaricu --- CartController.cs/Index Akcija ---> add Empty View (Index.cshtml) koji se nalazi u Views/Cart/

    //Dodajemo gumb za košaricu na ribbon početne stranice --- Views/Shared/Layout.cshtml

    //Dodajemo tablicu za ispis proizvoda koji se nalazi u košarici --- Views/Cart/Index.cshtml
    #endregion

    #region
    //IZRADA NARUDŽBE

    //radimo gumb za narudžbu --- Views/Cart/Index.cshtml

    //Radimo novi Empty kontroller --- OrderController.cs ---> Controllers/

    //Radimo Empty View za akciju Checkout u tom kontroleru --- Checkout.cshtml ---> Views/Order/

    //Zato jer nam se ponavlja isti dio koda da korisniku pokažemo proizvode bilo bi dobro napraviti partial view

    //Moramo prebaciti podatke o korisniku iz forme kod narudžbe koju smo stvorili u Views/Order/Checkout.cshtml --- Order.cs --> FirstName, LastNAme, Email, PhoneNumber, Country, City, PostalCode, Address, Message

    //Radimo migraciju prema bazi za propertyima iz Order.cs --- PackageManagerConsole ---> PM> add-migration ExtendOrdersTable

    //Nakon toga radimo update baze podataka --- PackageManagerConsole ---> update-database

    //Ako je sve u redu provjeravamo u bazi podataka da li je sve uspješno prošlo --- dbo.Orders-Column i provjeriti u dbo.EFMigrationHistroy da li se zadnja migracija tamo nalazi

    //Moramo napraviti gumbove na formi koji će slati podatke --- Checkout.cshtml

    //Radimo mapiranje podataka koji se šalju iz forme, odnosno akciju. Trebamo dobiti objekt klase Order --- OrderController.cs ---> public IActionResult CreateOrder(Order newOrder) koji je HTTP Post

    //U OrederController.cs moramo naprviti dva priuvatna polja za pristup bazi i useru: private readonly ApplicationDbContext _dbContext; private readonly UserManager<ApplicationUser> _userManager; i napraviti Dependencies Injection u konstruktor :
    /*public OrderController(ApplicationDbContext dbContext, UserManager<ApplicationUser> user)
       {
        _dbContext = dbContext;
        _userManager = user;
      }
     */

    //Sa tim ovisnostima možemo dohvatiti usera preko ID-a ako je prijavljen --- OrderController.cs ---> newOrder.UserId = _userManager.GetUserId(User);

    //dodajemo novog korisnika u Orders u bazi podataka i spremamo promjene --- _dbContext.Orders.Add(newOrder); _dbContext.SaveChanges();

    //Provjera da li sve radi: Dodaj nešto u košaricu i odi na Checkout, ispuni sva polja sejvaj.

    //Ako je sve dobro pogledati u bazi podataka u tablici Orders, tamo zapis o kupnji mora postojati



    #endregion
}
