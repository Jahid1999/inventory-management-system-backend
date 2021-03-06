using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystemBackend.Model;

namespace InventoryManagementSystemBackend.Data
{
    public class InventoryManagementSystemBackendContext : DbContext
    {
        // public InventoryManagementSystemBackendContext (DbContextOptions<InventoryManagementSystemBackendContext> options)
        //     : base(options)
        // {
        // }

        // Completed this project in my linux(ubuntu) operating system. That is why the connection string is different.
        public const string ConnectionString = "Server=localhost;USER ID=sa;Password=Jahid123;Database=InvSys;Trusted_Connection=false;MultipleActiveResultSets=true";
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }

        public DbSet<InventoryManagementSystemBackend.Model.Admin> Admin { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<InventoryManagementSystemBackend.Model.Admin>().HasData(
                new Admin
                {
                    Id=1,
                    Name = "Jahid",
                    Email = "jahid@admin.com",
                    Password = "iit12345"
                }
            );
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
