using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Promotion
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Display(Name = "Tytuł promocji")]
        [StringLength(100, ErrorMessage = "Nie może być więcej niż 100 znaków")]
        public string PromotionTitle { get; set; }

        [Display(Name = "Nazwa towaru")]
        [StringLength(50, ErrorMessage = "Nie może być więcej niż 50 znaków")]
        public string ProductName { get; set; }

        [Display(Name = "Procent obniżki")]
        public int DiscountPercent { get; set; }

        [Display(Name = "Data rozpoczęcia")]
        [DataType(DataType.Date)]
        public DateTime BeginningDate { get; set; }

        [Display(Name = "Data zakończenia")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Do ilu sztuk")]
        public int MaxQuantity { get; set; }
    }
}