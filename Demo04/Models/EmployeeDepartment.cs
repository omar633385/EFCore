using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04.Models
{
    [Keyless]
    public class EmployeeDepartment
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
