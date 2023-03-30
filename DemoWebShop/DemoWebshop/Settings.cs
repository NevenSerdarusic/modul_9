namespace DemoWebshop
{
    //KOJI SE SVEPAKETI DODAJU U DEPENDECIES:
    //Microsoft.AspNetCore.Identity.EntityFrameworkCore
    //Microsoft.AspNetCore.Identity --> ovaj paket generira ostala 4 paketa
    //Microsoft.EntityFrameworkCore.SqlServer
    //Microsoft.EntityFrameworkCore.Tools
    //Microsoft.VisualStudio.Web.CodeGeneration.Design

    //AREAS FOLDER:
    //Identity
    //Data
    //ApplicationDbContext.cs
    //ApplicationUser.cs
    //Pages
    //Account

    //============================================================================================================

    //KORACI KOJI SLIJEDE:

    //Dodavanje partial View-a Identifikacije ----- Views/Shared/Layout.cshtml (Register/Login)

    //Kreiranje servisa za korištenje RazorPage opcija ----- Program.cs ---> builder.Services.AddRazorPages();

    //Mapiranje RazorPage stranica ---- Program.cs ---> app.MapRazorPages();

    //Brisanje generiranog Connection stringa iz datoteke ---- appsettings.json (sakrivamo povjerljive podatke)

    //Stvaranje novog Connection stringa ----appsettings.Development.json ---> "Server=localhost\\sqlexpress; Database=m9_webshop; Integrated Security=true; TrustServerCertificate=true; MultipleActiveResultSets=true;" (u ovoj datoteci ostaje Connection string LOKALNO, ne ide na Github)

    //Izbacivanje gornje datoteke iz projekta ---- .gitIgnore (LocalDisc C: > users > anama > source > modul_9)  (drag and drop u VS) ---> appsettings.Development.json

    //
}
