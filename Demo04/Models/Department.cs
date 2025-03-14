using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04.Models
{
    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }



        public virtual Employee Manager { get; set; }
        public int ManagerId { get; set; }

        //public ICollection<Employee> Employees { get; set; }

    }
}
