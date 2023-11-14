using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace StoreAutoMVC.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter driver type")]
        [MaxLength(20, ErrorMessage = "Driver type must be 20 characters or less"),
           MinLength(2, ErrorMessage = "Driver type must contain at least 2 characters")]
        public string DriverType { get; set; }

        [Required(ErrorMessage = "Enter engine capacity")]
        [Range(0.1, 6.5, ErrorMessage = "Incorrect engine capacity")]
        public float EngineCapacity { get; set; }

        [Required(ErrorMessage = "Enter fuel type")]
        [MaxLength(20, ErrorMessage = "Fuel type must be 20 characters or less"),
           MinLength(2, ErrorMessage = "Fuel type must contain at least 2 characters")]
        public string FuelType { get; set; }

        [Required(ErrorMessage = "Enter model year")]
        [Range(2018, 2023, ErrorMessage = "Incorrect model year")]
        public int ModelYear { get; set; }

        [Required(ErrorMessage = "Enter price equipment")]
        [Range(1000, 1000000, ErrorMessage = "Incorrect price equipment")]
        public decimal PriceEquipment { get; set; }

        [Required(ErrorMessage = "Choose model")]
        public int ModelId { get; set; }
        public Model? Model { get; set; }

    }
}
