using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionBindSample
{
    public class School
    {
        public string ClassName { get; set; }
        public List<Student> Student { get; set; }
    }
    public class Student
    {
        public string name { get; set; }
        public int age { get; set; }
    }
}
