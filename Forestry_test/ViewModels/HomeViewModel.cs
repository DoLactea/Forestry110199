using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;
using Forestry_test.ViewModels;
using Forestry_test.ViewModels.ForestViewModel;

namespace Forestry_test.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Sort> Sorts { get; set; }
        public IEnumerable<Mazist> Mazists { get; set; }
        public IEnumerable<Forestry_test.Models.Forest> Forests { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public ForestViewModel.ForestsViewModel ForestsViewModel { get; set; }
    }
}
