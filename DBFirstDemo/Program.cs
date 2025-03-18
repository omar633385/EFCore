using DBFirstDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace DBFirstDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using NorthwindContext dbcontext = new NorthwindContext();
            //var categories = dbcontext.Categories.ToList();
            //foreach (var category in categories)
            //{
            //    Console.WriteLine(category.CategoryName);
            //}

            #region RunSqlRaw
            //Execute Select Statment 
            //  =>1. use FromSqlRaw=> takes query as string   2.FromSqlInterpolated => like FromSqlRaw but uses string interpolation

            //var categories = dbcontext.Categories.FromSqlRaw("Select *  " +
            //                                "from Categories");

            //int count = 3;
            // categories = dbcontext.Categories.FromSqlRaw("Select top ({0})* from Categories",count);
            // categories = dbcontext.Categories.FromSqlRaw($"Select top ({count})* from Categories");
            // categories = dbcontext.Categories.FromSqlInterpolated($"Select top ({count})* from Categories");
            //foreach (var category in categories)
            //{
            //    Console.WriteLine(category.CategoryName);
            //}

            //2. Execute DML Statment
            //               => 1.ExecuteSqlRaw             2.ExecuteSqlInterpolated

            //var result = dbcontext.Database.ExecuteSqlRaw("update Categories \r\nset CategoryName ='hamada'\r\nwhere CategoryID=3"); // return no of rows affected
            //result = dbcontext.Database.ExecuteSqlInterpolated($"update Categories \r\nset CategoryName ='hamada'\r\nwhere CategoryID=5"); // return no of rows affected 
            //Console.WriteLine(result);//1
            #endregion

            #region StoredProcedures
            //NorthwindContextProcedures procedures = new NorthwindContextProcedures(dbcontext);
            //var products = await procedures.SalesByCategoryAsync("Beverages", "1998");
            //foreach (var product in products)
            //{
            //    //Console.WriteLine($"{product.ProductName} ::: {product.TotalPurchase}");
            //    Console.WriteLine(product);
            //}
            #endregion

            #region Local
            //checks first if it
            if(dbcontext.Products.Local.Any(p => p.UnitsInStock == 0))
                Console.WriteLine("There is at least one product out of stock From Cache");
            else if (dbcontext.Products.Any(p => p.UnitsInStock == 0))
                Console.WriteLine("There is at least one product out of stock From DataBase");

            var product= dbcontext.Products.FirstOrDefault();
            if(product != null)
            {
                Console.WriteLine(product.UnitPrice);
                product.UnitPrice = 10;
            }
            if(dbcontext.Products.Local.Any(p=>p.UnitPrice==10))
                Console.WriteLine("The first product unit price is 10 from Cache");
            else if(dbcontext.Products.Any(p=>p.UnitPrice==10))
                Console.WriteLine("Found From DB");

            //Find Operator already uses local first if found retrieve the data from cache if not then go to database
            product=dbcontext.Products.Find(1);

            dbcontext.Products.Load(); // loads data from db to meomry cache then if you want to make this query again it will be loaded from meomry not from db


            #endregion 
        }
    }
}
