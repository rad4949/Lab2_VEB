using Microsoft.AspNetCore.Mvc;
using StoreAutoMVC.Entity;
using StoreAutoMVC.Models;

namespace StoreAutoMVC.Controllers
{
    public class ModelController : Controller
    {
        readonly DBContext dBContext;
        public ModelController(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public IActionResult Index()
        {
            return View(dBContext.Models.ToList());
        }
    }
}
