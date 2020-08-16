using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Retailer.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the RetailerUser class
    public class RetailerUser : IdentityUser
    {
        [PersonalData]
        [Required]
        public string FirstName { get; set; }

        [PersonalData]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// UserType: (a) Buyer (b) Seller
        /// </summary>
        [PersonalData]
        [Required]
        public string UserType { get; set; }
    }
}
