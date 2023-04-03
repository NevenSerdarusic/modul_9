﻿namespace DemoWebshop
{
    #region
    //KOJI SE SVEPAKETI DODAJU U DEPENDECIES:
    //Microsoft.AspNetCore.Identity.EntityFrameworkCore
    //Microsoft.AspNetCore.Identity --> ovaj paket generira ostala 4 paketa
    //Microsoft.EntityFrameworkCore.SqlServer
    //Microsoft.EntityFrameworkCore.Tools
    //Microsoft.VisualStudio.Web.CodeGeneration.Design
    #endregion

    #region
    //AREAS FOLDER:
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

    //Ako želimo promijeniti svojstva Useta to radimo unutar ApplicationUser.cs

    //Radimo drugu migraciju, dodajemo proširenje tablice User ---- Package Manager Console ---> add-migration ExpandUserTable

    //Radimo drugi update u bazu --- Package Manager Console ---> PM> update-database

    //Kreiranje klasa modela ---- Models Folder

    //

    #endregion
}
