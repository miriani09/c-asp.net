using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.RecentlyViews = new HashSet<RecentlyView>();
        }
        [Key]
        public int CustomerID { get; set; }
        [StringLength(50), DisplayName("First Name"), MinLength(2), MaxLength(10), Required(ErrorMessage = "Please Enter First Name")]
        public string First_Name { get; set; }
        [StringLength(50), DisplayName("Last Name"), MinLength(2), MaxLength(10), Required(ErrorMessage = "Please Enter Last Name")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Please Enter Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Email { get; set; }
        [StringLength(50), DisplayName("Phone"), MinLength(2), MaxLength(10), Required(ErrorMessage = "Please Enter Phone"), RegularExpression("^([\\+]?(?:00)?[0-9]{1,3}[\\s.-]?[0-9]{1,12})([\\s.-]?[0-9]{1,4}?)$", ErrorMessage = "enter 9 digit phone number")]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Display(Name = "Picture")]
        public string PicturePath { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<RecentlyView> RecentlyViews { get; set; }
    }
}