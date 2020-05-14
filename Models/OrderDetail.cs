using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demoASP.Models
{
    [Table("order_details")]
    public class OrderDetail
    {
        [Key, Column("order_id", Order = 0)]
        public int OrderID { get; set; }

        [Key, Column("product_id", Order = 1)]
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }


        [Column("unit_price")]
        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }

        [Column("quantity")]
        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "The Quantity must be value greater than 0")]
        public int Quantity { get; set; }

        [Column("discount")]
        [Display(Name = "Discount")]
        [Range(0, double.MaxValue, ErrorMessage = "The discount must be value greater than 0")]
        public decimal Discount { get; set; }

        public decimal Total => (decimal)Quantity * UnitPrice;

    }
}