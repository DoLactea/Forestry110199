using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forestry_test.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forestry_test.ViewModels.ProductViewModel
{
    public class ProductsFilterViewModel
    {
        public ProductsFilterViewModel(List<Sort> names, int? name)
        {
            names.Insert(0, new Sort { SortID = 0,SortD = "Все" });
            SortsD = new SelectList(names, "SortID", "SortD", names);
        }

        public ProductsFilterViewModel(List<Product> names, int? name)
        {
            names.Insert(0, new Product { SortID = 0, Lght = 0 });
            SortsD = new SelectList(names, "SortID", "Lght", names);
        }

        public SelectList SortsD { get; private set; }
        public int? SelectedSortD { get; private set; }
    }
}
