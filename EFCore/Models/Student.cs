using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class Student
    {
        public  int Id { get; set; }
        public required string Fname { get; set; }
        public required string Lname { get; set; }
        public required string Address { get; set; }
        public required int Age { get; set; }
        public required int Dept_Id { get; set; }
    }
}
