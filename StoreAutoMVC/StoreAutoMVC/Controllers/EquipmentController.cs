using Microsoft.AspNetCore.Mvc;
using StoreAutoMVC.Entity;

namespace StoreAutoMVC.Controllers
{
    public class EquipmentController : Controller
    {
        readonly DBContext dBContext;
        public EquipmentController(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public IActionResult Index()
        {
            return View(dBContext.Equipments.ToList());
        }
    }
}
