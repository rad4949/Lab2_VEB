using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreAutoMVC.Entity;
using StoreAutoMVC.Models;
using StoreAutoMVC.ViewModels;

namespace StoreAutoMVC.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        readonly DBContext dBContext;
        public BrandController(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(dBContext.Brands.ToList());
        }            

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            dBContext.Brands.Add(brand);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = dBContext.Brands.Find(id);
            if (item == null) return NotFound();

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            dBContext.Brands.Update(brand);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = dBContext.Brands.Find(id);

            if (item == null)
                return NotFound();

            dBContext.Brands.Remove(item);
            dBContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
