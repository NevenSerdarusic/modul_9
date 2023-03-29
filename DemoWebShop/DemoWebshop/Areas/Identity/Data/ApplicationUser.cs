using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DemoWebshop.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class

//Identity User --> mi s tim nasljeđujemo glavna svojstva (name,email) i možemo to proširiti 
public class ApplicationUser : IdentityUser
{
}

