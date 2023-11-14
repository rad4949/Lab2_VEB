using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreAutoMVC.Entity;
using StoreAutoMVC.Models;

namespace StoreAutoMVC.Controllers
{
    public class ModelController : Controller
    {
        readonly DBContext dBContext;
        SelectList BrandIdList;
        public ModelController(DBContext dBContext)
        {
            this.dBContext = dBContext;
            BrandIdList = new SelectList(dBContext.Brands.ToList(), "Id", "NameBrand");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(dBContext.Models.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.BrandIdList = BrandIdList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Model model)
        {
            if (!ModelState.IsValid || model.BrandId == 0)
            {
                ViewBag.BrandIdList = BrandIdList;
                return View();
            }

            dBContext.Models.Add(model);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.BrandIdList = BrandIdList;
            var item = dBContext.Models.Find(id);
            if (item == null) return NotFound();

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(Model model)
        {
            if (!ModelState.IsValid || model.BrandId == 0)
            {
                ViewBag.BrandIdList = BrandIdList;
                return View();
            }

            dBContext.Models.Update(model);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = dBContext.Models.Find(id);

            if (item == null)
                return NotFound();

            dBContext.Models.Remove(item);
            dBContext.SaveChanges(); 

            return RedirectToAction("Index");
        }
    }
}
