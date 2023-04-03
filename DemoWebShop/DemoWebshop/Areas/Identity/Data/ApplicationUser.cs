using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity; //


namespace DemoWebshop.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class

//Identity User --> mi s tim nasljeđujemo glavna svojstva (name,email) i možemo to proširiti 
public class ApplicationUser : IdentityUser
{
    //Kreiramo nova svojstva ua User
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [StringLength(150)]
    public string Adress { get; set; }
}

