using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ServiceSub.Models
{
    public class Newsletter
    {
        [Required(ErrorMessage = "Temat jest wymagany")]
        [Display(Name = "Temat")]
        [StringLength(20, ErrorMessage = "Temat nie może mieć więcej niż 20 znaków")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Treść jest wymagana.")]
        [Display(Name = "Temat")]
        [StringLength(200, ErrorMessage = "Wiadomość może mieć maksymalnie 20 znaków")]
        public string Content { get; set; }
    }
}