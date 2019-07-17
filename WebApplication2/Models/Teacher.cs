using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Teacher
    {
        [Key]
       
        public int id { get; set; }
        public string name { get; set; }
        public DateTime createtime { get; set; }
    }
}
