using StoreAutoMVC.Controllers;

namespace StoreAutoMVC.ViewModels
{
    public class SortViewModel
    {
        public SortState BrandSort { get; }
        public SortState ModelSort { get; }
        public SortState EquipmentName { get; }
        public SortState Current { get; }

        public SortViewModel(SortState sortOrder)
        {
            BrandSort = sortOrder == SortState.BrandNameAsc ? SortState.BrandNameDesc : SortState.BrandNameAsc;
            ModelSort = sortOrder == SortState.ModelNameAsc ? SortState.ModelNameDesc : SortState.ModelNameAsc;
            EquipmentName = sortOrder == SortState.EquipmentNameAsc ? SortState.EquipmentNameDesc : SortState.EquipmentNameAsc;
            Current = sortOrder;
        }
    }
}
