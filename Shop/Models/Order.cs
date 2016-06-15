using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Order
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [ForeignKey("Products")]
        [Display(Name = "Id produktu")]
        public virtual long ProductsId { get; set; }
        public virtual Products Products { get; set; }

        [Display(Name = "Ilośc towaru")]
        public int Quantity { get; set; }
        [Display(Name = "Nr telefonu")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "Adres e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data zamówienia")]
        public DateTime OrderedDate { get; set; }
        [Display(Name = "Data wysyłki")]
        [DataType(DataType.Date)]
        public DateTime ShippingDate { get; set; }
    }
}