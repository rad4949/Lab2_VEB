using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace StoreAutoMVC.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter brand name")]
        [MaxLength(20, ErrorMessage = "Brand name must be 20 characters or less"),
           MinLength(2, ErrorMessage = "The Brand name must contain at least 2 characters")]
        public string NameBrand { get; set; }

        [Required(ErrorMessage = "Enter Producing country")]
        [MaxLength(20, ErrorMessage = "Producing country name must be 20 characters or less"),
          MinLength(3, ErrorMessage = "Producing country must contain at least 3 characters")]
        public string ProducingCountry { get; set; }

        public ICollection<Model>? Models { get; set; }

    }
}
