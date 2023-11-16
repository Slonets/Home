using DateAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Data
{
    public class CarajeDbContext : IdentityDbContext<AppUser>
    {
        public CarajeDbContext(DbContextOptions<CarajeDbContext> options) : base(options)
        {
            //видаляє базу даних
            //Database.EnsureDeleted();

            ////створює базу даних
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedCar();
            modelBuilder.SeedCategory();
            modelBuilder.SeedStorage();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarajeDbContext).Assembly);
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Storage> Storage { get; set; }       
        
    }
}
