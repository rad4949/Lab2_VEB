using Microsoft.EntityFrameworkCore;
using StoreAutoMVC.Models;

namespace StoreAutoMVC.Interfaces
{
    public interface IDBContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
    }
}
