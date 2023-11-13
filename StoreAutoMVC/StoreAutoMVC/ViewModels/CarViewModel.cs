using StoreAutoMVC.Models;

namespace StoreAutoMVC.ViewModels
{
    public class CarViewModel
    {
        public Equipment Equipment { get; set; } = new Equipment();
        public Model Model { get; set; } = new Model();
        public Brand Brand { get; set; } = new Brand();
    }
}
