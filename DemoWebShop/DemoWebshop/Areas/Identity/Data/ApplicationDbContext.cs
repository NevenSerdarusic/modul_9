﻿using DemoWebshop.Areas.Identity.Data;
using DemoWebshop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
    }
}
