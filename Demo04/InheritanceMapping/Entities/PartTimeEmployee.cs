using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04.InheritanceMapping.Entities
{
    internal class PartTimeEmployee:EmployeeContainer
    {
        public decimal HourRate { get; set; }
        public int CountOfHour { get; set; }
    }
}
