using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class student
    {
        
        [Display(Name ="名字")]
        public string name { get; set; }
      
        public int id { get; set; }
        public string address { get; set; }
    }
}
