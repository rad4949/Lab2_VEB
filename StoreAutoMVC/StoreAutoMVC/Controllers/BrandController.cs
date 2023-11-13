using Microsoft.AspNetCore.Mvc;
using StoreAutoMVC.Entity;
using StoreAutoMVC.Models;
using StoreAutoMVC.ViewModels;

namespace StoreAutoMVC.Controllers
{
    public class BrandController : Controller
    {
        readonly DBContext dBContext;
        public BrandController(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public IActionResult Index()
        {
            return View(dBContext.Brands.ToList());
        }
    }
}
