using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Data.models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введіть ім'я")]
        [StringLength(30)]
        [Required(ErrorMessage = "Довжина ім'я повинна бути до 30 символів і не може бути пустою")]
        public string FirstName { get; set; } //required

        [Display(Name = "Прізвище")]
        [StringLength(50)]
        [Required(ErrorMessage = "Довжина прізвища повинна бути до 50 символів і не може бути пустою")]
        public string LastName { get; set; } //required

        [Display(Name = "Електронна пошта")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [Required(ErrorMessage = "Довжина пошти повинна бути до 50 символів і не може бути пустою")]
        public string Email { get; set; }

        [Display(Name = "Номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 13, ErrorMessage = "Довжина номеру телефону повинна бути не менше 10 цифр", MinimumLength = 10)]
        [Required(ErrorMessage = "Довжина номеру телефону повинна бути від 10 до 13 цифр")]
        public string Phone { get; set; } //required

        [Display(Name = "Адреса")]
        [StringLength(50)]
        [Required(ErrorMessage = "Довжина адреси повинна бути до 50 символів і не може бути пустою")]
        public string Address { get; set; } //required

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }  //required

        [BindNever]
        public List<OrderItem> OrderItems { get; set; } // список елементів замовлення
    }
}
