using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forestry_test.Models
{
    public class Appointment
    {
        [Display(Name = "Код места назначения")]
        [Key]
        public int PointID { get; set; }
        [Display(Name = "Место назначения")]
        public string PointName { get; set; }
       
        public ICollection<Forest> Forests { get; set; }
    }
}
