namespace DemoWebshop
{
    //KOJI SE SVEPAKETI DODAJU U DEPENDECIES:
        //Microsoft.AspNetCore.Identity.EntityFrameworkCore
        //Microsoft.AspNetCore.Identity.
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

    
    
    //KORACI KOJI SLIJEDE:
    //Dodavanje partial View-a od Identifikacije u Views/Shared/Layout.cshtml (Register/Login)

    //Kreiranje servisa za korištenje RazorPage opcija unutar Program.cs ---> builder.Services.AddRazorPages();

    //Mapiranje RazorPage stranica unutar Program.cs ---> app.MapRazorPages();


}
