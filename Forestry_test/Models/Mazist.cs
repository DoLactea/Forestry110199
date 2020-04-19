using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forestry_test.Models
{
    public class Mazist
    {
        [Display(Name = "Код водителя")]
        [Key]
        public int CarID { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "ФИО водителя")]
        public string FIO { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Длина строки должна быть от 4 до 10 символов")]
        [Display(Name = "Гос номер")]
        public string CarNumber { get; set; }
        public ICollection<Forest> Forests { get; set; }
    }
}
