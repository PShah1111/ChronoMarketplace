using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ChronoMarketplace.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ChronoMarketplaceUser class
public class ChronoMarketplaceUser : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }



}

