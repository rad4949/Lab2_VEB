using StoreAutoMVC.Controllers;

namespace StoreAutoMVC.ViewModels
{
    public class SortViewModel
    {
        public SortState BrandSort { get; }
        public SortState ModelSort { get; }
        public SortState EquipmentSort { get; }
        public SortState Current { get; }
        public bool BrandSortActive { get; set; } = false;
        public bool ModelSortActive { get; set; } = false;
        public bool EquipmentSortActive { get; set; } = false;
        public bool IsUp { get; set; } = false;

        public SortViewModel(SortState sortCars)
        {
            BrandSort = sortCars == SortState.BrandNameAsc ? SortState.BrandNameDesc : SortState.BrandNameAsc;
            ModelSort = sortCars == SortState.ModelNameAsc ? SortState.ModelNameDesc : SortState.ModelNameAsc;
            EquipmentSort = sortCars == SortState.EquipmentNameAsc ? SortState.EquipmentNameDesc : SortState.EquipmentNameAsc;
            Current = sortCars;

            switch (sortCars)
            {
                case SortState.BrandNameDesc:
                    BrandSortActive = true;
                    IsUp = false;
                    break;
                case SortState.ModelNameAsc:
                    ModelSortActive = true;
                    IsUp = true;
                    break;
                case SortState.ModelNameDesc:
                    ModelSortActive = true;
                    IsUp = false;
                    break;
                case SortState.EquipmentNameAsc:
                    EquipmentSortActive = true;
                    IsUp = true;
                    break;
                case SortState.EquipmentNameDesc:
                    EquipmentSortActive = true;
                    IsUp = false;
                    break;
                default:
                    BrandSortActive = true;
                    IsUp = true;
                    break;
            }
        }
    }
}
