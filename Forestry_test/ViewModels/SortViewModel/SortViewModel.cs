using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;

namespace Forestry_test.ViewModels.SortViewModel
{
    public class SortViewModel
    {
        public IEnumerable<Sort> Sorts { get; set; }
        public Sort Sort { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SortSortedViewModel SortedViewModel { get; set; }
        public SortFilterViewModel FilterViewModel { get; set; }
    }
}
