using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Укажите как вас зовут")]
        public string Name { get; set; }


        [Display(Name = "Первый адрес")]
        [Required(ErrorMessage = "Вставьте первый адрес доставки")]
        public string Line1 { get; set; }

        [Display(Name = "Второй адрес")]
        public string Line2 { get; set; }

        [Display(Name = "Третий адрес")]
        public string Line3 { get; set; }

        [Display(Name = "Ваш город")]
        [Required(ErrorMessage = "Укажите город")]
        public string City { get; set; }


        [Display(Name="Ваша страна")]
        [Required(ErrorMessage = "Укажите страну")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
