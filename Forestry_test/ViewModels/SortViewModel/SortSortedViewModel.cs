using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;

namespace Forestry_test.ViewModels.SortViewModel
{
    public class SortSortedViewModel
    {
        public SortState SortIDSort { get; private set; }
        public SortState SortDSort { get; private set; }
        public SortState Current { get; private set; }
        public SortSortedViewModel(SortState sortOrder)
        {
            SortIDSort = sortOrder == SortState.SortIDAsc ? SortState.SortIDDesc : SortState.SortIDAsc;
            SortDSort = sortOrder == SortState.SortDAsc ? SortState.SortDDesc : SortState.SortDAsc;
            Current = sortOrder;
        }
    }
}
