using Demo.Data;
using Demo.Data.models;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using CompanyDbContext context = new CompanyDbContext();

            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll; //Default of Changetracker
            #region CRUD Operations

            #region Insert

            //var emp01 = new Employee() { Name = "omar", Age = 23,Email="omar@gmail.com" };
            //var emp02 = new Employee() { Name = "ahmed", Age = 23, Email = "ahmed@gmail.com" };

            //Console.WriteLine(context.Entry(emp01).State);//detached
            //context.Add(emp01);
            //Console.WriteLine(context.Entry(emp01).State);//added  ==>Change entry state 

            //context.Entry(emp02).State=EntityState.Added;

            //context.SaveChanges();

            //Console.WriteLine(context.Entry(emp01).State);//detached 
            #endregion

            #region Update

            //var employee= context.Employees.AsNoTracking().FirstOrDefault(e => e.EmpId == 3);//TOP(1)
            //                                                                                 //employee= context.Employees.SingleOrDefault(e => e.EmpId == 3);//TOP(2)
            // Console.WriteLine(context.Entry(employee).State);//detached because of AsNoTracking() ==> will be unchanged while not using AsNoTracking()
            // Console.WriteLine(employee?.Name??"NA");
            // if (employee != null) {
            //     employee.Name = "omar";
            // }
            // context.SaveChanges();
            // Console.WriteLine(context.Entry(employee).State);//detached 
            #endregion

            #region Delete

            var employee= context.Employees.FirstOrDefault(e => e.EmpId == 3);//TOP(1)
            Console.WriteLine(context.Entry(employee).State);//unchanged

            if (employee != null) { 
            context.Remove(employee);
            }context.SaveChanges();

            Console.WriteLine(context.Entry(employee).State);//detached


            #endregion

            #endregion


        }
    }
}
