using DemoWebshop.Areas.Identity.Data;
using DemoWebshop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DemoWebshop.Data;

//VEZA ZA KOMUNIKACIJU SA BAZOM
//Slično DbContext klasi iz 8.modula (on je dio Entity Frameworka)
//IdentityDBContext mora imati pristup bazi. Dio Identity paketa. Dobiva klasu User <ApplicationUser>  ----> Posrednik između Entity Frameworka i baze
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    //Mapiranje C# klase modela s tablicama u bazi podataka
    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<ProductCategory> ProductCategories { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }



    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {

    }


    //Za seedanje podataka
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);


        Product product01 = new Product() { Id= 1,  Title = "Jabuka crvena", Description = "Crvena jabuka", Sku = "j01-voće", InStock = 1023.13M, Price = 0.77M, Image = "crvenajabuka.png" };
        Product product02 = new Product() { Id = 2, Title = "Jabuka zelena", Description = "Zelena jabuka", Sku = "j02-voće", InStock = 957.15M, Price = 0.73M, Image = "zelenajabuka.png" };
        Product product03 = new Product() { Id = 17, Title = "Jogurt 0,5L", Description = "Jogurt sa 2,8% mm", Sku = "j03-jog", InStock = 500M, Price = 1.22M, Image = "jogurt2,8%.png" };
        Product product04 = new Product() { Id = 54, Title = "Pivo 0,33L", Description = "Bavaria", Sku = "p17-pića", InStock = 257M, Price = 2.14M, Image = "bavaria.png" };
        Product product05 = new Product() { Id = 22, Title = "Kruh Klara", Description = "Kruh sa sjemenkama", Sku = "p09-peka", InStock = 150M, Price = 1.27M, Image = "kruhsjemnkeKlara.png" };

        


        Category mliječniProizvodi = new Category() { Id = 10, Title = "Mliječni proizvodi", Description = "Mlijeko i mliječni proizvodi", Image = "mlijecniproizvodi.png" };
        Category voće = new Category() { Id = 1, Title = "Voće", Description = "Voće i proizvodi od voća", Image = "voce.png" };
        Category pekarskiProizvodi = new Category() { Id = 20, Title = "Pekarski proizvodi", Description = "Proizvodi od brašna", Image = "pekarskiproizvodi.png" };
        Category pića = new Category() { Id = 50, Title = "Pića", Description = "Pića i napitci", Image = "pica.png" };
        Category meso = new Category() { Id = 70, Title = "Meso", Description = "Meso i proizvodi od mesa", Image = "meso.png" };


        builder.Entity<Product>().HasData(product01, product02, product03, product04, product05);
        builder.Entity<Category>().HasData(mliječniProizvodi, voće, pekarskiProizvodi, pića, meso);

    }
}
