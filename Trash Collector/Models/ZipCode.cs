using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trash_Collector.Models
{
    public class ZipCode
    {
        [Key]
        public int ZipCodeId { get; set; }
    }
}