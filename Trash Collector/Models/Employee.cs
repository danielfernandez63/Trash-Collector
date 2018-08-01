using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trash_Collector.Models
{
    public class Employee
    {
      
        [Key]
        public int EmployeeID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }



        [ForeignKey("ZipCode")]
        [Display(Name = "Zip Code Service Area")]
        public int ZipCodeId { get; set; }
        public ZipCode ZipCode { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }



    }
}