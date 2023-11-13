using System.Reflection;

namespace StoreAutoMVC.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string NameBrand { get; set; }
        public string ProducingCountry { get; set; }

        public ICollection<Model> Models { get; set; }

    }
}
