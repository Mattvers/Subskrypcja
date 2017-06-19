using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceSub.Models
{
    public class Subscriber
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Imie jest wymagane")]
        [StringLength(50, ErrorMessage = "Imie jest wymagane")]
        [Display(Name ="Imie")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [StringLength(50, ErrorMessage = "Nazwisko może mieć maksymalnie 50 znaków")]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [StringLength(100, ErrorMessage = "Adres email może mieć maksymalnie 100 znaków")]
        [Required(ErrorMessage = "Musisz podać adres email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adres e-mail")]
        [RegularExpression(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$", 
            ErrorMessage = "Adres email jest niepoprawny")]
        public string Email { get; set; }

        [Display(Name = "Data rejestracji")]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }
    }
}