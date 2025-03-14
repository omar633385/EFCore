using Demo04.Data;
using Demo04.InheritanceMapping.Entities;
using Demo04.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using DemoDbContext dbContext = new DemoDbContext();

            #region Inheritance-Mapping
            #region Seeding Data For Inheritance-Mapping TPH
            //PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            //{ Address="cairo",
            //  Age=23,
            //CountOfHour=10,
            //HourRate=200,
            //Name="Omar"};

            //FullTimeEmployee fullTimeEmployee = new FullTimeEmployee() { Name = "Omar", Address = "Alex", Age = 24, Salary = 5_000, StartDate = DateTime.Now };
            //dbContext.Add(partTimeEmployee);
            //dbContext.Add(fullTimeEmployee);
            //dbContext.SaveChanges(); 
            #endregion

            //foreach (var full in dbContext.EmployeeContainers.OfType<FullTimeEmployee>())
            //{
            //    Console.WriteLine($"Name:{full.Name} Salary:{full.Salary}");
            //}
            //foreach (var part in dbContext.EmployeeContainers.OfType<PartTimeEmployee>())
            //{
            //    Console.WriteLine($"Name:{part.Name} Salary:{part.HourRate * part.CountOfHour}");
            //}
            #endregion

            #region Related Data Loading

            #region Default Behaviour
            //var employee = dbContext.Employees
            //       .FirstOrDefault(e => e.Id == 8);

            //Console.WriteLine($"EmpName:{employee?.Name} DepartmentName:{employee?.Department?.DeptName}"); //didn't load department data as it is navigational property 


            #endregion

            #region Explicit Loading
            // extra trip: takes 2 requests to server which is not effecient way
            //but the advantage of explicit loading => load data you want to be loaded


            //dbContext.Entry(employee).Reference(e=>e.Department).Load();
            //Console.WriteLine($"EmpName:{employee?.Name} DepartmentName:{employee?.Department?.DeptName}"); //didn't load department data as it is navigational property 

            #endregion

            #region Eager Loading
            //retrieve related data with one query => reduces requests to database
            //ThenInclude => Multilevel relationships
            //uses left join if relation is optional
            //uses inner join if relation is mandatory


            //var employee = dbContext.Employees.Include(e=>e.Department)
            //       .FirstOrDefault(e => e.Id == 8);

            //Console.WriteLine($"EmpName:{employee?.Name} DepartmentName:{employee?.Department?.DeptName}"); //didn't load department data as it is navigational property 

            #endregion

            #region Lazy Loading

            //to change default behaviour of ef core=> don't load related data
            // By using lazy loading it will be loaded per request 
            //1.Install Microsoft.EntityFrameWorkCore.Proxies
            //2. Go to onConfiguring method to enable lazyLoading => By using Extension Method (UseLazyLoadingProxies)
            //3. All models should be public not internal 
            //4. navigational propeties should be virtual => implicitly override get method

            //var employee = dbContext.Employees
            //       .FirstOrDefault(e => e.Id == 8);

            //Console.WriteLine($"EmpName:{employee?.Name} DepartmentName:{employee?.Department?.DeptName}"); //didn't load department data as it is navigational property 


            #endregion


            #endregion

            #region Mapping View

            foreach (var item in dbContext.EmployeeDepartments)
            {
                Console.WriteLine(item.Name);
            }
            #endregion

        }
    }
}
