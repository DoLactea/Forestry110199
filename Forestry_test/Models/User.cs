using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Forestry_test.Models
{
    public class User : IdentityUser
    {
        public string LocUser { get; set; }
    }
}
