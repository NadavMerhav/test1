using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthForYou.Models;
using Microsoft.AspNetCore.Identity;

namespace HealthForYou.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the HealthForYouUser class
    public class HealthForYouUser : IdentityUser
    {

        public string fullname { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}
