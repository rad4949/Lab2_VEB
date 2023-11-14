using System.ComponentModel.DataAnnotations;

namespace StoreAutoMVC.Models
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter model name")]
        [MaxLength(20, ErrorMessage = "Model name must be 20 characters or less"),
            MinLength(2, ErrorMessage = "The model name must contain at least 2 characters")]
        public string NameModel { get; set; }

        [Required(ErrorMessage = "Enter body type")]
        [MaxLength(20, ErrorMessage = "Body type must be 20 characters or less"),
            MinLength(3, ErrorMessage = "Body type must contain at least 20 characters")]
        public string BodyType { get; set; }

        [Required(ErrorMessage = "Enter guarantee")]
        [MaxLength(20, ErrorMessage = "Guarantee must be 2 characters or less"),
            MinLength(1, ErrorMessage = "Guarantee must contain at least 1 characters")]
        public string Guarantee { get; set; }

        [Required(ErrorMessage = "Choose brand")]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public ICollection<Equipment>? Equipments { get; set; }
    }
}
