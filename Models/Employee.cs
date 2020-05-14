using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace demoASP.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("employee_id")]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "max length 50 charactors")]
        [Column("last_name")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "max length 50 charactors")]
        [Column("first_name")]
        [Display(Name = "Fist name")]
        public string FirstName { get; set; }

        [Display(Name = "Customer name")]
        public string FullName => Title + " " + FirstName + " " + this.LastName;

        [Required]
        [StringLength(30, ErrorMessage = "max length 30 charactors")]
        [Column("title")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [StringLength(30, ErrorMessage = "max length 30 charactors")]
        [Column("title_of_courtesy")]
        [Display(Name = "Title Of Courtesy")]
        public string TitleOfCourtesy { get; set; }

        [Column("birth_date")]
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        [Column("hire_date")]
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }

        [StringLength(60, ErrorMessage = "max length 60 charactors")]
        [Column("address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(15, ErrorMessage = "max length 15 charactors")]
        [Column("city")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(15, ErrorMessage = "max length 15 charactors")]
        [Column("region")]
        [Display(Name = "Region")]
        public string Region { get; set; }

        [StringLength(10, ErrorMessage = "max length 10 charactors")]
        [Column("postal_code")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [StringLength(15, ErrorMessage = "max length 15 charactors")]
        [Column("country")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [StringLength(24, ErrorMessage = "max length 24 charactors")]
        [Column("home_phone")]
        [Display(Name = "Tel.")]
        public string HomePhone { get; set; }

        [StringLength(4, ErrorMessage = "max length 4 charactors")]
        [Column("extension")]
        [Display(Name = "Extension")]
        public string Extension { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("report_to")]
        public int? ReportsTo { get; set; }

        [ForeignKey("ReportsTo")]
        public virtual Employee ReportTo { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}