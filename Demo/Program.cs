using Demo.Data;
using Demo.Data.models;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using CompanyDbContext context = new CompanyDbContext();

            context.Employees.Where(e => e.EmpId == 1);
            context.Set<Employee>().ToList();
        }
    }
}
