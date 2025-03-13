using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04.InheritanceMapping.Entities
{
    internal class FullTimeEmployee:EmployeeContainer
    {
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
    }
}
