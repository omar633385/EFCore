using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Duration { get; set; }
        public string Name { get; set; }
        public int Top_Id { get; set; }
    }
}
