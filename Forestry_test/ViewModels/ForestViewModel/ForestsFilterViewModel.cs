using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Forestry_test.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Forestry_test.ViewModels.ForestsViewModel
{
    public class ForestsFilterViewModel
    {
        public ForestsFilterViewModel(List<Mazist> names, List<Appointment> points, List<Sort> sorts, List<Forest> forests, int? point, int? name, int? sort, int? forest)
        {
            var dat = DateTime.Today;
            names.Insert(0, new Mazist { CarID = 0, FIO = "Все" });
            points.Insert(0, new Appointment { PointID = 0, PointName = "Все" });
            sorts.Insert(0, new Sort { SortID = 0, SortD = "Все" });
            forests.Insert(0, new Forest { ForestID = 0, DateOfAppointment = dat });
            fIO = new SelectList(names, "CarID", "FIO", names);
            pointName = new SelectList(points, "PointID", "PointName", points);
            sortD = new SelectList(sorts, "SortID", "SortD", sorts);
            dateOfAppointment = new SelectList(forests, "ForestID", "DateOfAppointment", forests);
        }
        public SelectList fIO { get; private set; }
        public SelectList pointName { get; private set; }
        public SelectList sortD { get; private set; }
        public SelectList dateOfAppointment { get; private set; }
        public int? SelectedfIO { get; private set; }
        public int? SelectedpointName { get; private set; }
        public int? SelectedsortD { get; private set; }
        public int? SelecteddateOfAppointment { get; private set; }
    }
}
