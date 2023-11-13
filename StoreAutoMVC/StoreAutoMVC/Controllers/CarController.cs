using Microsoft.AspNetCore.Mvc;
using StoreAutoMVC.Entity;
using StoreAutoMVC.Models;
using StoreAutoMVC.ViewModels;

namespace StoreAutoMVC.Controllers
{
    public class CarController : Controller
    {
        readonly DBContext dBContext;
        public CarController(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult Cars()
        {
            IEnumerable<CarViewModel> cars = from equipment in dBContext.Set<Equipment>()
                                    from model in dBContext.Set<Model>().Where(model => model.Id == equipment.ModelId).DefaultIfEmpty()
                                    from brand in dBContext.Set<Brand>().Where(brand => brand.Id == model.BrandId).DefaultIfEmpty()
                                    select new CarViewModel
                                    {
                                        Equipment = equipment,
                                        Model = model,
                                        Brand = brand
                                    };
            return View(cars);
        }
    }
}
