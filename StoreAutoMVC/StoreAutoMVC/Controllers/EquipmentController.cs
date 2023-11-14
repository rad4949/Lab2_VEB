using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StoreAutoMVC.Entity;
using StoreAutoMVC.Models;

namespace StoreAutoMVC.Controllers
{
    public class EquipmentController : Controller
    {
        readonly DBContext dBContext;
        SelectList ModelIdList;
        public EquipmentController(DBContext dBContext)
        {
            this.dBContext = dBContext;
            ModelIdList = new SelectList(dBContext.Models.ToList(), "Id", "NameModel");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(dBContext.Equipments.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ModelIdList = ModelIdList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Equipment equipment)
        {
            if (!ModelState.IsValid || equipment.ModelId == 0)
            {
                ViewBag.ModelIdList = ModelIdList;
                return View();
            }

            dBContext.Equipments.Add(equipment);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.ModelIdList = ModelIdList;
            var item = dBContext.Equipments.Find(id);
            if (item == null) return NotFound();

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(Equipment equipment)
        {
            if (!ModelState.IsValid || equipment.ModelId == 0)
            {
                ViewBag.ModelIdList = ModelIdList;
                return View();
            }

            dBContext.Equipments.Update(equipment);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = dBContext.Equipments.Find(id);

            if (item == null)
                return NotFound();

            dBContext.Equipments.Remove(item);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
