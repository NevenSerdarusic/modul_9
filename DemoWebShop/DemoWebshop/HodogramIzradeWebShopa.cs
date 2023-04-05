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

    #region
    //Sadržaj AREAS FOLDER-a:
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

    //Kreiranje klasa modela ---- Models Folder (Category, Order, Product, OrderItem, ProductCategory)

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
}
