using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace SolarEnergy.DbContext
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Image> Images { get; set; }
        public DbSet<MechanicalDesignForm> MechanicalDesignForms { get; set; }
        public DbSet<MaintenanceForm> MaintenanceForms { get; set; }

        

    }

    
}
