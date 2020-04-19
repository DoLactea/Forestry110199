using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forestry_test.ViewModels.AppointmentViewModel
{
    public class AppointmentFilterViewModel
    {
        public AppointmentFilterViewModel(string pointName)
        {
            SelectedpointName = pointName;
        }
        public string SelectedpointName { get; private set; }

    }
}
