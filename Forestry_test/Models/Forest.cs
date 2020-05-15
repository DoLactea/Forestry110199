using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forestry_test.Models
{
    public class Forest
    {
        [Key]
        public int ForestID { get; set; }
        public int? CarID { get; set; }
        public int? SortID { get; set; }
        //public int Quarters { get; set; } //посмотреть нужно ли здесь это
        public int? PointID { get; set; }
        public int? LocID { get; set; }
        [Range(1, 239, ErrorMessage = "Недопустимый квартал")]
        public int Quarter { get; set; }
        [Required(ErrorMessage = "Выберите водителя")]
        public Mazist FIO { get; set; }
        [Required(ErrorMessage = "Выберите продукцию")]
        public Sort SortD  { get; set; } //посмотреть нужно ли здесь это
        [Required(ErrorMessage = "Выберите место назначения")]
        public Appointment PointName { get; set; }
        [Required(ErrorMessage = "Выберите лесничество")]
        public Location Loc { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfAppointment { get; set; }
    }
}
