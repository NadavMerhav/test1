using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthForYou.Areas.Identity.Data;
using HealthForYou.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthForYou.Data
{
    public class HealthForYouContext : IdentityDbContext<HealthForYouUser>
    {
        public HealthForYouContext(DbContextOptions<HealthForYouContext> options)
            : base(options)
        {
        }
        public DbSet<HealthForYouUser> ApplicationUsers { get; set; }
        public DbSet<MedicalTeam>MedicTeam { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
