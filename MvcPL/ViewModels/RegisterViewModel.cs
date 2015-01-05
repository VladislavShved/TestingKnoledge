using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.ViewModels
{
    public class RegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(100, ErrorMessage = "Пароль должен содержать по крайней мере {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Введите пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите логин")]
        [Display(Name = "Введите логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [Display(Name = "Введите фамилию")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать.")]
        public string ConfirmPassword { get; set; }
    }
}