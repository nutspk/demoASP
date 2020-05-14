using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demoASP.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index]
        [Column("order_id")]
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }

        [Required]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Column("employee_id")]
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        [Column("order_date")]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [Column("required_date")]
        [Display(Name = "Required Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RequiredDate { get; set; }

        [Column("shipped_date")]
        [Display(Name = "Shipped Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ShippedDate { get; set; }

        [Column("ship_via")]
        [Display(Name = "Shipping by")]
        public int ShipperId { get; set; }
        public virtual Shipper Shipper { get; set; }

        [Column("freight")]
        [Display(Name = "Freight cost")]
        [Range(0, double.MaxValue, ErrorMessage ="The Freight cost must be greater than 0")]
        public decimal freight { get; set; }

        [Required]
        [Column("ship_name")]
        [Display(Name = "Ship name")]
        [StringLength(150, ErrorMessage = "max length 150 charactors")]
        public string ShipName { get; set; }

        [Required]
        [Column("ship_Address")]
        [Display(Name = "Ship Address")]
        [StringLength(200, ErrorMessage = "max length 200 charactors")]
        public string ShipAddress { get; set; }

        [Column("ship_city")]
        [Display(Name = "Ship city")]
        [StringLength(200, ErrorMessage = "max length 200 charactors")]
        public string ShipCity { get; set; }

        [Column("ship_region")]
        [Display(Name = "Ship region")]
        [StringLength(50, ErrorMessage = "max length 50 charactors")]
        public string ShipRegion { get; set; }

        [Required]
        [Column("ship_postal_code")]
        [Display(Name = "Ship Postal code")]
        [StringLength(10, ErrorMessage = "max length 10 charactors")]
        public string ShipPostalCode { get; set; }

        [Required]
        [Column("ship_country")]
        [Display(Name = "Ship Country")]
        [StringLength(50, ErrorMessage = "max length 50 charactors")]
        public string ShipCountry { get; set; }

        [Required]
        public virtual ICollection<OrderDetail> OrderItem { get; set; }  
        = new HashSet<OrderDetail>();

        public decimal SubTotal => OrderItem.Sum(x => x.Total);
        public decimal VatAmount => Math.Round(SubTotal * 0.07m, 2, MidpointRounding.AwayFromZero);
        public decimal NetTotal => SubTotal + VatAmount;
    }
}