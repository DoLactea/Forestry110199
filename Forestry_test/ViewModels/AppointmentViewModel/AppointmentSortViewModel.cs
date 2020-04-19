using System;
using System.Threading.Tasks;
using Forestry_test.Models;

namespace Forestry_test.ViewModels.AppointmentViewModel
{
    public class AppointmentSortViewModel
    {
        public SortState PointIDSort { get; private set; }
        public SortState PointNameSort { get; private set; }
        public SortState Current { get; private set; }

        public AppointmentSortViewModel(SortState sortOrder)
        {
            PointIDSort = sortOrder == SortState.PointIDAsc ? SortState.PointIDDesc : SortState.PointIDAsc;
            PointNameSort = sortOrder == SortState.PointNameAsc ? SortState.PointNameDesc : SortState.PointNameAsc;
            Current = sortOrder;
        }
    }
}
