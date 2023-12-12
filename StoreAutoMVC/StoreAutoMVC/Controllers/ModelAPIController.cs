using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreAutoMVC.Entity;
using StoreAutoMVC.Models;

namespace StoreAutoMVC.Controllers
{
    [ApiController]
    [Route("api/ModelAPI")]
    public class ModelAPIController : Controller
    {
        readonly DBContext dBContext;
        public ModelAPIController(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet("List")]
        public async Task<ActionResult> GetModels()
        {
            var models = await dBContext.Models
                .Select(e => new Model
                {
                    Id = e.Id,
                    NameModel = e.NameModel,
                    BodyType = e.BodyType,
                    Guarantee = e.Guarantee,
                    BrandId = e.BrandId
                }).ToListAsync();

            return Ok(models);
        }

        [HttpPost("add/name/{nameModel}/bodyType/{bodyType}/guarantee/{guarantee}")]
        public async Task<ActionResult> AddEquipment(
             [FromRoute] string nameModel,
             [FromRoute] string bodyType,
             [FromRoute] string guarantee,
             [FromQuery] string brandName)
        {
            var brand = await dBContext.Brands.Where(x => x.NameBrand == brandName).FirstOrDefaultAsync();

            await dBContext.Models.AddAsync(new Model
            {
                NameModel = nameModel,
                BodyType = bodyType,
                Guarantee = guarantee,
                BrandId = brand.Id
            });

            await dBContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("update/id/{id}/name/{nameModel}/bodyType/{bodyType}/guarantee/{guarantee}")]
        public async Task<ActionResult> UpdateModel(
                    [FromRoute] int id,
                    [FromRoute] string nameModel,
                    [FromRoute] string bodyType,
                    [FromRoute] string guarantee,
                    [FromQuery] string brandName)
        {
            var model = await dBContext.Models.Where(x => x.Id == id).FirstOrDefaultAsync();
            var brand = await dBContext.Brands.Where(x => x.NameBrand == brandName).FirstOrDefaultAsync();

            model.NameModel = nameModel;
            model.BodyType = bodyType;
            model.Guarantee = guarantee;
            model.BrandId = brand.Id;

            await dBContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("delete/id/{id}")]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            var item = await dBContext.Models.FindAsync(id);

            if (item == null)
                return NotFound();

            dBContext.Models.Remove(item);
            await dBContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
