using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;
using Forestry_test.ViewModels.ForestsViewModel;

namespace Forestry_test.ViewModels.ForestViewModel
{
    public class ForestsViewModel
    {
        public IEnumerable<Forest> Forests { get; set; }

        public ForestViewModel ForestViewModel { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public SelectList AppointmentsList { get; set; }
        public SelectList MazistsList { get; set; }
        public SelectList ProductsList { get; set; }
        public SelectList SortsList { get; set; }
        public SelectList LocList { get; set; }


        public ForestsSortViewModel SortViewModel { get; set; }
        public ForestsFilterViewModel FilterViewModel { get; set; }
        
    }
}
