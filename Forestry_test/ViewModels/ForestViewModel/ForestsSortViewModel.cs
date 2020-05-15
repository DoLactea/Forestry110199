using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;

namespace Forestry_test.ViewModels.ForestViewModel
{
    public class ForestsSortViewModel
    {
        public SortState ForestIDSort { get; private set; }
        public SortState FIOSort { get; private set; }
        public SortState SortDSort { get; private set; }
        public SortState LghtSort { get; private set; }
        public SortState VolumeSort { get; private set; }
        public SortState QuarterSort { get; private set; }
        public SortState PointNameSort { get; private set; }
        public SortState LocSort { get; private set; }
        public SortState DateOfAppointmentSort { get; private set; }
        public SortState Current { get; private set; }

        public ForestsSortViewModel(SortState sortOrder)
        {
            ForestIDSort = sortOrder == SortState.ForestIDAsc ? SortState.ForestIDDesc : SortState.ForestIDAsc;
            FIOSort = sortOrder == SortState.FIOAsc ? SortState.FIODesc : SortState.FIOAsc;
            SortDSort = sortOrder == SortState.SortDAsc ? SortState.SortDDesc : SortState.SortDAsc;
            LghtSort = sortOrder == SortState.LghtAsc ? SortState.LghtDesc : SortState.LghtAsc;
            VolumeSort = sortOrder == SortState.VolumeAsc ? SortState.VolumeDesc : SortState.VolumeAsc;
            QuarterSort = sortOrder == SortState.QuarterAsc ? SortState.QuarterDesc : SortState.QuarterAsc;
            PointNameSort = sortOrder == SortState.PointNameAsc ? SortState.PointNameDesc : SortState.PointNameAsc;
            LocSort = sortOrder == SortState.LocAsc ? SortState.LocDesc : SortState.LocAsc;
            DateOfAppointmentSort = sortOrder == SortState.DateOfAppointmentAsc ? SortState.DateOfAppointmentDesc : SortState.DateOfAppointmentAsc;
            Current = sortOrder;
        }
    }
}
