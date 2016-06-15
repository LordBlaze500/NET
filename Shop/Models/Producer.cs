using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Producer
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Imie")]
        [StringLength(50, ErrorMessage = "Zbyt dużo znaków!!!")]
        public string Imie { get; set; }
        
        [Display(Name = "Nazwisko")]
        [DataType(DataType.Text)]
        public string Nazwisko { get; set; }

        [Display(Name = "Pesel")]
        [DataType(DataType.Text)]
        public string Pesel { get; set; }        
    }
}