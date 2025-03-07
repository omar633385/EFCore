using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class Instructor
    {
        public int Id { get; set; }
        public required string  Name{ get; set; }
        public required double Bonus { get; set; }
        public required double Salary { get; set; }
        public required string Address { get; set; }
        public required double HourRate { get; set; }
        public required int Dept_Id { get; set; }
    }
}
