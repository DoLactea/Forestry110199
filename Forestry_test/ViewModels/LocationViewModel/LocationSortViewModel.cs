using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;

namespace Forestry_test.ViewModels.LocationViewModel
{
    public class LocationSortViewModel
    {
        public SortState LocIDSort { get; private set; }
        public SortState LocSort { get; private set; }
        public SortState Current { get; private set; }
        public LocationSortViewModel(SortState sortOrder)
        {
            LocIDSort = sortOrder == SortState.LocIDAsc ? SortState.LocIDDesc : SortState.LocIDAsc;
            LocSort = sortOrder == SortState.LocAsc ? SortState.LocDesc : SortState.LocAsc;
            Current = sortOrder;
        }
    }
}
