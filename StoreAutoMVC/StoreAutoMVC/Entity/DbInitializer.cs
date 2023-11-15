using Microsoft.EntityFrameworkCore;
using StoreAutoMVC.Models;
using System.Reflection.Emit;

namespace StoreAutoMVC.Entity
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {

            modelBuilder.Entity<Brand>().HasData(
               new Brand { Id = 1, NameBrand = "Mercedes-Benz", ProducingCountry = "Germany" },
               new Brand { Id = 2, NameBrand = "Audi", ProducingCountry = "Germany" }
            );

            modelBuilder.Entity<Model>().HasData(
                new Model { Id = 1, BrandId = 1, Guarantee = "5 years", NameModel = "GLS", BodyType = "Crossover" },
                new Model { Id = 2, BrandId = 2, Guarantee = "6 years", NameModel = "A6", BodyType = "Universal" },
                new Model { Id = 3, BrandId = 1, Guarantee = "10 years", NameModel = "E-class", BodyType = "Sedan" }
            );

            modelBuilder.Entity<Equipment>().HasData(
               new Equipment
               {
                   Id = 1,
                   ModelId = 1,
                   NameEquipment = "AMG 400",
                   DriverType = "All-wheel drive",
                   EngineCapacity = 3,
                   FuelType = "Gasoline",
                   ModelYear = 2020,
                   PriceEquipment = 250000,
               },
               new Equipment
               {
                   Id = 2,
                   ModelId = 2,
                   NameEquipment = "Comfort +",
                   DriverType = "All-wheel drive",
                   EngineCapacity = 2,
                   FuelType = "Gasoline",
                   ModelYear = 2021,
                   PriceEquipment = 200000
               },
               new Equipment
               {
                   Id = 3,
                   ModelId = 3,
                   NameEquipment = "AMG 63s",
                   DriverType = "Rear wheel drive",
                   EngineCapacity = 3,
                   FuelType = "Diesel",
                   ModelYear = 2019,
                   PriceEquipment = 210000,
               }
           );

        }
    }
}
