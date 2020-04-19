using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forestry_test.ViewModels.MazistViewModel
{
    public class MazistFilterViewModel
    {
        public MazistFilterViewModel(string fIO)
        {
            SelectedfIO = fIO;
        }
        public string SelectedfIO { get; private set; }

    }
}
