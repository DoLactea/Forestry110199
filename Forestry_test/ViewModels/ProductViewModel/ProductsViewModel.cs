using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;
using Forestry_test.ViewModels.ProductViewModel;

namespace Forestry_test.ViewModels.ProductViewModel
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public ProductViewModel ProductViewModel { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public SelectList SortsList { get; set; }
        public SelectList LocList { get; set; }

        public ProductsSortViewModel SortViewModel { get; set; }

        public ProductsFilterViewModel FilterViewModel { get; set; }

    }
}
