using Demo.Data.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data
{
    internal class CompanyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-TKKIPFC;Initial Catalog=Company;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
