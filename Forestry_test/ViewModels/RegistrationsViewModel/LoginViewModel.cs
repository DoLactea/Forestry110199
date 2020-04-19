using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Forestry_test.ViewModels.RegistrationsViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Неверный Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Wrong Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Неверный пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Запомнить пользователя?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
