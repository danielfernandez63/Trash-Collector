using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trash_Collector.Models
{
    public class PickUpDay
    {
        [Key]
        public int PickUpId { get; set; }


        [Display(Name = "Pickup Day of the Week")]
        public string PickUpWeekday { get; set; }

    }
}