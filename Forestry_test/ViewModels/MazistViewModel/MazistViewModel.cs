using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;
using Forestry_test.ViewModels.MazistViewModel;

namespace Forestry_test.ViewModels.MazistViewModel
{
    public class MazistViewModel
    {
        public IEnumerable<Mazist> Mazists { get; set; }
        public Mazist Mazist { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public MazistSortViewModel SortViewModel { get; set; }
        public MazistFilterViewModel FilterViewModel { get; set; }
    }
}
