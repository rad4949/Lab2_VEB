using System.Reflection;

namespace StoreAutoMVC.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string DriverType { get; set; }
        public float EngineCapacity { get; set; }
        public string FuelType { get; set; }
        public int ModelYear { get; set; }
        public decimal PriceEquipment { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

    }
}
