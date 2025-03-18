using Demo04.Data;
using Demo04.InheritanceMapping.Entities;
using Demo04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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

            //foreach (var item in dbContext.EmployeeDepartments)
            //{
            //    Console.WriteLine(item.Name);
            //}
            #endregion

            #region Join operators [Deffered Execution]

            #region join [inner Join]

            //query syntax
            //var result = from e in dbContext.Employees
            //             join d in dbContext.Departments
            //             on e.DepartmentId equals d.DeptId 
            //             select new { d.DeptName,e.Name};

            //fluent syntax
            //var result =dbContext.Employees.Join(dbContext.Departments,
            //                            e => e.DepartmentId,
            //                            d => d.DeptId,
            //                            (e,d)=> new { e.Name, d.DeptName,e.Salary }
            //                            ).Where(r=>r.Salary>5000);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Group join
            //groups the elements from the second collection based on key of first collection

            #region Ex01

            //fluent syntax

            //var result = dbContext.Departments.GroupJoin(dbContext.Employees,
            //     d => d.DeptId, e => e.DepartmentId, (d, e) => new { d.DeptName, e });
            //foreach (var item in result) //array of annyonmous types  each type has department and  group of employees
            //{
            //    Console.WriteLine(item.DeptName);
            //    foreach (var item1 in item.e)
            //    {
            //        Console.WriteLine(item1.Name);
            //    }
            //    Console.WriteLine();
            //}

            //query syntax


            //var result = from d in dbContext.Departments
            //             join e in dbContext.Employees
            //             on d.DeptId equals e.DepartmentId into groups
            //             select new
            //             {
            //                 d.DeptName,
            //                 groups
            //             };
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.DeptName);
            //    foreach (var employee in item.groups)
            //    {
            //        Console.WriteLine(employee.Name);
            //    }
            //    Console.WriteLine();
            //} 
            #endregion


            #region EX02

            //fluent syntax

            //var result = dbContext.Departments.GroupJoin(dbContext.Employees,
            //     d => d.DeptId, e => e.DepartmentId,
            //     (d, e) => new { d.DeptName, e })
            //    .Where(a => a.e.Count() > 3);
            //foreach (var item in result) //array of anna each department has a group of employees
            //{
            //    Console.WriteLine(item.DeptName);
            //    foreach (var item1 in item.e)
            //    {
            //        Console.WriteLine(item1.Name);
            //    }
            //    Console.WriteLine();
            //}

            //query syntax


            //var result = from d in dbContext.Departments
            //             join e in dbContext.Employees
            //             on d.DeptId equals e.DepartmentId into groups
            //             select new
            //             {
            //                 Department=d,
            //                 Employees=groups
            //             } into gr 
            //             where gr.Employees.Count()>1
            //             select gr;
            //foreach (var item in result) //array of anna each department has a group of employees
            //{
            //    Console.WriteLine(item.Department.DeptName);
            //    foreach (var item1 in item.Employees)
            //    {
            //        Console.WriteLine(item1.Name);
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            #region LeftJoin
            //left join are not supported anymore

            //var result = dbContext.Departments.LeftJoin(dbContext.Employees,
            //                                d => d.DeptId, e => e.DepartmentId,
            //                               (d, e) => new { d, e });
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.d.DeptName);
            //} 
            #endregion

            #region Group join [Right outer Join]


            //fluent syntax

            //var result = dbContext.Employees.GroupJoin(dbContext.Departments,
            //     e => e.DepartmentId, d => d.DeptId, (d, e) => new { e, d.Name });
            //foreach (var item in result) //array of departments each department has a group of employees
            //{
            //    Console.WriteLine(item.Name);
            //    foreach (var item1 in item.e)
            //    {
            //        Console.WriteLine(item1.DeptName);
            //    }
            //    Console.WriteLine();
            //}

            //query syntax


            //var result = from e in dbContext.Employees
            //             join d in dbContext.Departments
            //             on e.DepartmentId equals d.DeptId into groups
            //             select new
            //             {
            //                 e,
            //                 groups
            //             };
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.e);
            //    foreach (var department in item.groups)
            //    {
            //        Console.WriteLine(department.DeptName);
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            #endregion

            #region CrossJoin

            //query syntax
            //var result = from e in dbContext.Employees
            //             from d in dbContext.Departments
            //             select new {e.Name,d.DeptName};
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //fluent syntax

            var result = dbContext.Departments.SelectMany(d => dbContext.Employees,
                                                         (d, e) => new { d.DeptName, e.Name });
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }


            #endregion
            #endregion

        }
    }
}
