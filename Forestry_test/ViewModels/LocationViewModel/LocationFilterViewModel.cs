using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forestry_test.ViewModels.LocationViewModel
{
    public class LocationFilterViewModel
    {
        public LocationFilterViewModel(string loc)
        {
            Selectedloc = loc;
        }
        public string Selectedloc { get; private set; }
    }
}
