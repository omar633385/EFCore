using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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



        public Department? ManagedDepartment { get; set; }//[ONE]
        
        public  int? Dept_Id { get; set; }
        public Department Department { get; set; }//[Many]
        
    }
}
