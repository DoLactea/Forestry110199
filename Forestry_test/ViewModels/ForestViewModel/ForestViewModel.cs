using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Forestry_test.ViewModels.ForestViewModel
{
    public class ForestViewModel
    {
        [Display(Name = "Код")]
        public int ForestID { get; set; }
        [Required(ErrorMessage = "Выберите водителя")]
        [Display(Name = "Имя водителя")]
        public string FIO { get; set; }
        [Required(ErrorMessage = "Выберите продукцию")]
        [Display(Name = "Продукция")]
        public string SortD { get; set; }
        [Required(ErrorMessage = "Выберите место назначения")]
        [Display(Name = "Назначение")]
        public string PointName { get; set; }

        [Required(ErrorMessage = "Квартал может быть от 1 до 400")]
        [Range(1, 400)]
        [Display(Name = "Квартал")]
        public int Quarter { get; set; }
        [Required(ErrorMessage = "Выберите лесничество")]
        [Display(Name = "Лесничество")]
        public string Location { get; set; }
    }
}
