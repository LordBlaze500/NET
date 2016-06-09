using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Birthdays
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Display(Name = "Imie")]
        [StringLength(100, ErrorMessage = "Maksymalnie 100 znaków")]
        public string uName { get; set; }

        [Display(Name = "Nazwisko")]
        [StringLength(1000, ErrorMessage = "Maksymalnie 1000 znaków")]
        public string uSurname{ get; set; }

        [Display(Name = "Kiedy?")]
        [DataType(DataType.Date)]
        public DateTime uBirthdayDate{ get; set; }

    }
}