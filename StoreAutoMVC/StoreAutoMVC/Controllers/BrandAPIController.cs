using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using StoreAutoMVC.Entity;
using StoreAutoMVC.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace StoreAutoMVC.Controllers
{
    [ApiController]
    [Route("api/Brand")]
    public class BrandAPIController : Controller
    {
        readonly DBContext dBContext;
        public BrandAPIController(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet("List")]
        public async Task<ActionResult> GetBrands()
        {
            var brands = await dBContext.Brands.ToListAsync();

            return Ok(brands);
        }

        [HttpPost("add/name/{nameBrand}/country/{producingCountry}")]
        public async Task<ActionResult> AddBrand(string nameBrand, string producingCountry)
        {
            await dBContext.Brands.AddAsync(new Brand
            {
                NameBrand = nameBrand,
                ProducingCountry = producingCountry
            });

            await dBContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("update/id/{id}/name/{nameBrand}/country/{producingCountry}")]
        public async Task<ActionResult> UpdateBrand(int id, string nameBrand, string producingCountry)
        {
            var brand = await dBContext.Brands.Where(x => x.Id == id).FirstOrDefaultAsync();

            brand.NameBrand = nameBrand;
            brand.ProducingCountry = producingCountry;

            await dBContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("delete/id/{id}")]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            var item = await dBContext.Brands.FindAsync(id);

            if (item == null)
                return NotFound();

            dBContext.Brands.Remove(item);
            await dBContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
