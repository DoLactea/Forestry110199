using System;
using System.Threading.Tasks;
using Forestry_test.Models;

namespace Forestry_test.ViewModels.MazistViewModel
{
    public class MazistSortViewModel
    {
        public SortState CarIDSort { get; private set; }
        public SortState FIOSort { get; private set; }
        public SortState CarNumberSort { get; private set; }
        public SortState Current { get; private set; }

        public MazistSortViewModel(SortState sortOrder)
        {
            CarIDSort = sortOrder == SortState.CarIDAsc ? SortState.CarIDDesc : SortState.CarIDAsc;
            FIOSort = sortOrder == SortState.FIOAsc ? SortState.FIODesc : SortState.FIOAsc;
            CarNumberSort = sortOrder == SortState.CarNumberAsc ? SortState.CarNumberDesc : SortState.CarNumberAsc;
            Current = sortOrder;
        }
    }
}
