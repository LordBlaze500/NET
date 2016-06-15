using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Products
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Display(Name = "Nazwa produktu")]
        [StringLength(50, ErrorMessage = "Zbyt dużo znaków!!!")]
        public string ProductName { get; set; }

        [Display(Name = "Ilość towaru")]
        public int Quantity { get; set; }
        [Display(Name = "Kod produktu")]
        [DataType(DataType.Text)]
        public string Code { get; set; }
        [Display(Name = "Cena")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

		[Display(Name = "VAT")]
		[DataType(DataType.Text)]
		public string VAT { get; set; }

		[Display(Name = "Data dodania produktu")]
		[DataType(DataType.Date)]
		public DateTime AddDate { get; set; }
    }
}