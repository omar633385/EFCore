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
        public required string Duration { get; set; }
        public required string Name { get; set; }
        public required int Top_Id { get; set; }
    }
}
