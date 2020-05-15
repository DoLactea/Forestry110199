using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;

namespace Forestry_test.ViewModels.ProductViewModel
{
    public class ProductViewModel
    {
        [Display(Name = "Код")]
        public int ProdID { get; set; }
        [Display(Name = "Наименование")]
        public string SortD { get; set; }
        [Display(Name = "Длина, м")]
        public string Lght { get; set; }
        [Display(Name = "Объем, м3")]
        public string Volume { get; set; }
        [Display(Name = "Квартал")]
        public string Quarters { get; set; }
        [Display(Name = "Лесничество")]
        public string Location { get; set; }
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/2020", "1/1/2060")]
        [Display(Name = "Дата погрузки")]
        public System.DateTime DateOfShipment { get; set; }

    }
}
