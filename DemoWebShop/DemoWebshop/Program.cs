using DemoWebshop.Areas.Identity.Data; //Poveznica za User klasu
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DemoWebshop.Data;
using System.Globalization;

namespace DemoWebshop;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Dohvat connection stringa
        var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

        //servis za kreiranje resursa objekta klase konteksta
        builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(connectionString));

        //Servis koji kaže kako je klasa ApplicationUser glavna za identifikaciju korisnika
        //SignIn.RequireConfirmedAccount = true --- se mora promijenit u false
        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

       

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        //Kreiranje servisa za korištenje RazorPage opcija
        builder.Services.AddRazorPages();


        //Postavke za lozinku za registraciju novih korisnika (Samo za vježbu da ne zaboravimo)
        builder.Services.Configure<IdentityOptions>(
            options =>
            {
                //Osnovne postavke za lozinku 
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 7;
            }
         );


        //Kreiraj servise za sesiju
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        //Postavke aplikacije za rukovanje decimalnim vrijednostima (Culture Info)
        var cultureInfo = new CultureInfo("de-De");
        cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
        cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
        app.UseRequestLocalization(
            new RequestLocalizationOptions 
            { 
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(cultureInfo), 
                SupportedCultures = new List<CultureInfo> { cultureInfo }, 
                SupportedUICultures = new List<CultureInfo> { cultureInfo } 
            }
         );


        app.UseRouting();
        app.UseAuthentication();

        app.UseAuthorization();

        //Želimo koristiti sesiju 
        app.UseSession();

        //dodavanje rute za Admina
        app.MapAreaControllerRoute(
            name: "Admin",
            areaName: "Admin",
            pattern: "admin/{controller}/{action}/{id?}"
            );

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        //Mapiranje RazorPage stranica
        app.MapRazorPages();

        app.Run();
    }
}