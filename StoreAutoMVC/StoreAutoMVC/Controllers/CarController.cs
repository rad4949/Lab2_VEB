using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreAutoMVC.Entity;
using StoreAutoMVC.Models;
using StoreAutoMVC.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StoreAutoMVC.Controllers
{
    public enum SortState
    {
        BrandNameAsc,
        BrandNameDesc,
        ModelNameAsc,
        ModelNameDesc,
        EquipmentNameAsc,
        EquipmentNameDesc
    }
    public class CarController : Controller
    {
        readonly DBContext dBContext;
        public CarController(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        
        public async Task<IActionResult> Cars(string name, int brand = 0, int page = 1, 
            SortState sortCars = SortState.BrandNameAsc)
        {
            int pageSize = 4;

            IQueryable<CarViewModel> cars = from equipment in dBContext.Set<Equipment>()
                                    from model in dBContext.Set<StoreAutoMVC.Models.Model>().Where(model => model.Id == equipment.ModelId).DefaultIfEmpty()
                                    from brands in dBContext.Set<Brand>().Where(brand => brand.Id == model.BrandId).DefaultIfEmpty()
                                    select new CarViewModel
                                    {
                                        Equipment = equipment,
                                        Model = model,
                                        Brand = brands
                                    };

            if(brand != 0)
            {
                cars = cars.Where(p => p.Brand.Id == brand);
            }
            if (!string.IsNullOrEmpty(name))
            {
                cars = cars.Where(p => p.Model.NameModel.Contains(name));
            }

            switch (sortCars)
            {
                case SortState.BrandNameDesc:
                    cars = cars.OrderByDescending(s => s.Brand.NameBrand);
                    break;
                case SortState.ModelNameAsc:
                    cars = cars.OrderBy(s => s.Model.NameModel);
                    break;
                case SortState.ModelNameDesc:
                    cars = cars.OrderByDescending(s => s.Model.NameModel);
                    break;
                case SortState.EquipmentNameAsc:
                    cars = cars.OrderBy(s => s.Equipment.NameEquipment);
                    break;
                case SortState.EquipmentNameDesc:
                    cars = cars.OrderByDescending(s => s.Equipment.NameEquipment);
                    break;
                default:
                    cars = cars.OrderBy(s => s.Brand.NameBrand);
                    break;
            }

            var count = await cars.CountAsync();
            var items = await cars.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            IndexViewModel viewModel = new IndexViewModel(
               items,
               new PageViewModel(count, page, pageSize),
               new FilterViewModel(dBContext.Brands.ToList(), brand, name),
               new SortViewModel(sortCars)
           );

            return View(viewModel);
        }
    }
}
