using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StoreAutoMVC.Interfaces;
using StoreAutoMVC.Models;

namespace StoreAutoMVC.Entity
{
    public class DBContext : DbContext, IDBContext
    {
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Model> Models { get; set; } = null!;
        public DbSet<Equipment> Equipments { get; set; } = null!;
        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();


            modelBuilder
               .Entity<Equipment>()
               .HasOne(x => x.Model)
               .WithMany(x => x.Equipments)
               .HasForeignKey("ModelId")
               .IsRequired();

            modelBuilder
              .Entity<Model>()
              .HasOne(x => x.Brand)
              .WithMany(x => x.Models)
              .HasForeignKey("BrandId")
              .IsRequired();
            
        }
    }
}
