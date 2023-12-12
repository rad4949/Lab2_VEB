using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StoreAutoMVC.Entity;
using StoreAutoMVC.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StoreAutoMVC.Controllers
{
    [ApiController]
    [Route("api/EquipmentAPI")]
    public class EquipmentAPIController : Controller
    {
        readonly DBContext dBContext;
        public EquipmentAPIController(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet("List")]
        public async Task<ActionResult> GetEquipments()
        {
            var equipments = await dBContext.Equipments
                .Select(e => new Equipment
                {
                    Id = e.Id,
                    NameEquipment = e.NameEquipment,
                    DriverType = e.DriverType,
                    EngineCapacity = e.EngineCapacity,
                    FuelType = e.FuelType,
                    ModelYear = e.ModelYear,
                    PriceEquipment = e.PriceEquipment,
                    ModelId = e.ModelId,
                }).ToListAsync();

            return Ok(equipments);
        }

        [HttpPost("add/name/{nameEquipment}/driverType/{driverType}/engineCapacity/{engineCapacity}" +
            "/fuelType/{fuelType}/modelYear/{modelYear}/priceEquipment/{priceEquipment}")]
        public async Task<ActionResult> AddEquipment(
            [FromRoute] string nameEquipment,
            [FromRoute] string driverType,
            [FromRoute] float engineCapacity,
            [FromRoute] string fuelType,
            [FromRoute] int modelYear,
            [FromRoute] decimal priceEquipment,
            [FromQuery] string modelName)
        {
            var model = await dBContext.Models.Where(x => x.NameModel == modelName).FirstOrDefaultAsync();
            await dBContext.Equipments.AddAsync(new Equipment
            {
                NameEquipment = nameEquipment,
                DriverType = driverType,
                EngineCapacity = engineCapacity,
                FuelType = fuelType,
                ModelYear = modelYear,
                PriceEquipment = priceEquipment,
                ModelId = model.Id
            });

            await dBContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("update/id/{id}/name/{nameEquipment}/driverType/{driverType}/engineCapacity/{engineCapacity}" +
             "/fuelType/{fuelType}/modelYear/{modelYear}/priceEquipment/{priceEquipment}")]
        public async Task<ActionResult> UpdateEquipment(
             [FromRoute] int id,
             [FromRoute] string nameEquipment,
             [FromRoute] string driverType,
             [FromRoute] float engineCapacity,
             [FromRoute] string fuelType,
             [FromRoute] int modelYear,
             [FromRoute] decimal priceEquipment,
             [FromQuery] string modelName)
        {
            var equipment = await dBContext.Equipments.Where(x => x.Id == id).FirstOrDefaultAsync();
            var model = await dBContext.Models.Where(x => x.NameModel == modelName).FirstOrDefaultAsync();

            equipment.NameEquipment = nameEquipment;
            equipment.DriverType = driverType;
            equipment.EngineCapacity = engineCapacity;
            equipment.FuelType = fuelType;
            equipment.ModelYear = modelYear;
            equipment.PriceEquipment = priceEquipment;
            equipment.ModelId = model.Id;

            await dBContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("delete/id/{id}")]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            var item = await dBContext.Equipments.FindAsync(id);

            if (item == null)
                return NotFound();

            dBContext.Equipments.Remove(item);
            await dBContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
