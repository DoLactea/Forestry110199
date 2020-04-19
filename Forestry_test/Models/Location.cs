using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forestry_test.Models
{
    public class Location
    {
        [Display(Name = "Код лесничества")]
        [Key]
        public int LocID { get; set; }
        [Display(Name = "Лесничество")]
        public string Loc { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
