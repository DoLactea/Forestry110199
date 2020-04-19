using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forestry_test.ViewModels.SortViewModel
{
    public class SortFilterViewModel
    {
        public SortFilterViewModel(string sortD)
        {
            SelectedsortD = sortD;
        }
        public string SelectedsortD { get; private set; }
    }
}
