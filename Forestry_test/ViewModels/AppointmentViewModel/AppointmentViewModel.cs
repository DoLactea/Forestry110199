using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;
using Forestry_test.ViewModels.AppointmentViewModel;

namespace Forestry_test.ViewModels.AppointmentViewModel
{
    public class AppointmentViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; }
        public Appointment Appointment { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public AppointmentSortViewModel SortViewModel { get; set; }
        public AppointmentFilterViewModel FilterViewModel { get; set; }
    }
}
