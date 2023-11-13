namespace StoreAutoMVC.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string NameModel { get; set; }
        public string BodyType { get; set; }
        public string Guarantee { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<Equipment> Equipments { get; set; }
    }
}
