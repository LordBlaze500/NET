using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Promotion
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [ForeignKey("Products")]
        [Display(Name = "Id produktu")]
        public virtual long ProductsId { get; set; }
        public virtual Products Products { get; set; }

        [Display(Name = "Tytuł promocji")]
        [StringLength(100, ErrorMessage = "Nie może być więcej niż 100 znaków")]
        public string PromotionTitle { get; set; }

        [Display(Name = "Procent obniżki")]
        [Range(1, 99, ErrorMessage = "Podaj wartość z zakresu 1-99")]
        public int DiscountPercent { get; set; }

        [Display(Name = "Data rozpoczęcia")]
        [DataType(DataType.Date)]
        public DateTime BeginningDate { get; set; }

        [Display(Name = "Data zakończenia")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Do ilu sztuk")]
        [Range(1, 1000, ErrorMessage = "Podaj wartość z zakresu od 1 do 1000")]
        public int MaxQuantity { get; set; }
    }
}