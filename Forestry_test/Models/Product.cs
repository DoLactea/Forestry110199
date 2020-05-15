using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forestry_test.Models
{
    public class Product
    {
        [Key]
        public int ProdID { get; set; }
        public int? SortID { get; set; }
        public Sort Sorte { get; set; }
        [Range(1, 9, ErrorMessage = "Недопустимая длина")]
        public int Lght { get; set; }
        [Range(1, 1000, ErrorMessage = "Недопустимый объём")]
        public int Volume { get; set; }
        [Range(1, 239, ErrorMessage = "Недопустимый квартал")]
        public int Quarters { get; set; }
        public int? LocID { get; set; }
        public Location Loc { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfShipment { get; set; }
        // public ICollection<Forest> Forests { get; set; }
    }
}
