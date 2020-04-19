using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forestry_test.Models
{
    public class Sort
    {
        [Display(Name = "Код наименования")]
        [Key]
        public int SortID { get; set; }
        [Display(Name = "Наименование")]
        public string SortD { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
