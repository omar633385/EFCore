using Demo04.InheritanceMapping.Entities;
using Demo04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo04.Data
{
    internal class DemoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=DESKTOP-TKKIPFC;Initial Catalog=Company02;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<FullTimeEmployee>().Property(f => f.Salary).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<PartTimeEmployee>().Property(f => f.HourRate).HasColumnType("decimal(18,2)");


            modelBuilder.Entity<PartTimeEmployee>().HasBaseType<EmployeeContainer>();

            //to tell ef core that EmployeeDepartmentView is a view not table
            modelBuilder.Entity<EmployeeDepartment>().ToView("EmployeeDepartmentView");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

        #region TPCC
        //public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        //public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        #endregion  

        public DbSet<EmployeeContainer> EmployeeContainers { get; set; }
    }
}
