using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trash_Collector.Models
{
    public class Customer
    {

        [Key]   
        public int CustomerID { get; set; }



        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }


        [Display(Name = "Complete Pick")]
        public bool CompletePickUp { get; set; }

        //[DataType(DataType.Currency)]
        //[Column(TypeName = "money")]
        [Display(Name = "Current Balance In Dollars")]
        public int Balance { get; set; }

        [ForeignKey("ZipCode")]
        [Display(Name = "Zip Code")]
        public int ZipCodeId { get; set; }
        public ZipCode ZipCode { get; set; }


        //[Display(Name = "Pick Up Day")]
        //public string PickUpDate { get; set; }


        [ForeignKey("PickUpDay")]
        [Display(Name = "Pickup Day of the Week")]
        public int PickUpId { get; set; }
        public PickUpDay PickUpDay { get; set; }


        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}