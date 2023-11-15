using Microsoft.AspNetCore.Mvc.Rendering;
using StoreAutoMVC.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StoreAutoMVC.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Brand> brands, int brand, string name)
        {
            brands.Insert(0, new Brand { NameBrand = "Всі", Id = 0 });
            Brands = new SelectList(brands, "Id", "NameBrand", brand);
            SelectedBrand = brand;
            SelectedModel = name;
        }
        public SelectList Brands { get; } 
        public int SelectedBrand { get; }
        public string SelectedModel { get; } 
    }
}
