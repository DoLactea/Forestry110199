using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;

namespace Forestry_test.ViewModels.ProductViewModel
{
    public class ProductsSortViewModel
    {
        public SortState ProdIDSort { get; private set; }
        public SortState SortDSort { get; private set; }
        public SortState LghtSort { get; private set; }
        public SortState VolumeSort { get; private set; }
        public SortState QuartersSort { get; private set; }
        public SortState LocSort { get; private set; }
        public SortState DateOfShipmentSort { get; private set; }
        public SortState Current { get; private set; }
        public ProductsSortViewModel(SortState sortOrder)
        {
            ProdIDSort = sortOrder == SortState.ProdIDAsc ? SortState.ProdIDDesc : SortState.ProdIDAsc;
            SortDSort = sortOrder == SortState.SortDAsc ? SortState.SortDDesc : SortState.SortDAsc;
            LghtSort = sortOrder == SortState.LghtAsc ? SortState.LghtDesc : SortState.LghtAsc;
            VolumeSort = sortOrder == SortState.VolumeAsc ? SortState.VolumeDesc : SortState.VolumeAsc;
            QuartersSort = sortOrder == SortState.QuartersAsc ? SortState.QuartersDesc : SortState.QuartersAsc;
            LocSort = sortOrder == SortState.LocAsc ? SortState.LocDesc : SortState.LocAsc;
            DateOfShipmentSort = sortOrder == SortState.DateOfShipmentAsc ? SortState.DateOfShipmentDesc : SortState.DateOfShipmentAsc;
            Current = sortOrder;
        }
    }
}
