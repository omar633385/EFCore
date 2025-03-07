using Common;
using Demo.configs;
using Demo.Data.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data
{
    internal class CompanyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-TKKIPFC;Initial Catalog=Company;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configution UsingFluentApi

            //modelBuilder.Entity<Employee>().Property(e => e.Name).IsRequired();
            //modelBuilder.Entity<Employee>().HasKey(e => e.EmpId);
            //modelBuilder.Entity<Employee>().Property(e => e.Salary).HasDefaultValue(5000);
            //modelBuilder.Entity<Department>(d =>
            //{
            //    d.HasKey(d => d.DeptId);
            //    d.Property(d => d.DeptId).UseIdentityColumn(10, 10);

            //    //d.Property(d => d.DeptId).HasDefaultValueSql("NewGuid()");
            //    //d.Property(d => d.DeptId).HasDefaultValue("10");

            //    //d.Property(d=>d.DeptId).ValueGeneratedNever();//disable identity

            //    d.Property(d => d.DeptName)
            //    .HasColumnName("Department Name")
            //    .HasColumnType("varchar(50)").HasMaxLength(20)
            //    .IsRequired(false).HasDefaultValue("HR")
            //    .HasAnnotation("MaxLength", 20);
            //    d.Property(d => d.CreationDate)
            //    .IsRequired(false)
            //    //.HasDefaultValue(DateTime.Now);//sets Time of Migration created
            //    .HasDefaultValueSql("GetDate()") //stay the same after insert [can be set manually] [creation date]
            //    .HasComputedColumnSql("GetDate()"); //recalculated automatically [not manually set] [Updated date]

            //    d.Ignore(d => d.Description); //like [NotMapped] 

            //}); 
            #endregion

            //modelBuilder.ApplyConfiguration(new EmployeeConfig());
            //modelBuilder.ApplyConfiguration(new DepartmentConfigs());   

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//using Reflection

            base.OnModelCreating(modelBuilder);//if base class has entities ,it will be loaded to your data base design 
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }    
}
