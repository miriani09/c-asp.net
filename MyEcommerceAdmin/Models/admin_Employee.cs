using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class admin_Employee
    {
        public admin_Employee()
        {
            this.admin_Login = new HashSet<admin_Login>();
        }
        [Key]
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Birth Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }
        public string Address { get; set; }
        [StringLength(50), DisplayName("Phone"), MinLength(2), MaxLength(10), Required(ErrorMessage = "Please Enter Phone"), RegularExpression("^([\\+]?(?:00)?[0-9]{1,3}[\\s.-]?[0-9]{1,12})([\\s.-]?[0-9]{1,4}?)$", ErrorMessage = "enter 9 digit phone number")]
        public string Phone { get; set; }
        public string PicturePath { get; set; }
        public virtual ICollection<admin_Login> admin_Login { get; set; }
    }
}