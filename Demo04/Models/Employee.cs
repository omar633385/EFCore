using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string Phone  { get; set; }
        public Address Address { get; set; }
        public Department? ManagedDepartment { get; set; }//[ONE]


        public int? DepartmentId { get; set; }
        public Department Department { get; set; }//[Many]
    }
}
