using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;

namespace Forestry_test.ViewModels.LocationViewModel
{
    public class LocationViewModel
    {
        public IEnumerable<Location> Locations { get; set; }
        public Location Location { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public LocationSortViewModel SortViewModel { get; set; }
        public LocationFilterViewModel FilterViewModel { get; set; }
    }
}
