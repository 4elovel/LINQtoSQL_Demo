using System;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;

namespace LINQtoSQL_Demo
{
    public class DataBase
    {
        DbConnection connection;
        public DataBase(DbConnection connection)
        {
            this.connection = connection;
        }
        public void AddUkraine()
        {
            var context = new DataContext(connection);
            context.GetTable<Country>().InsertOnSubmit(new Country { Name = "Ukraine", Capital = "Kyiv", Area = 1415786, Population = 6462462, WorldPart = "Europe", Guid = Guid.NewGuid().ToString() });
            context.SubmitChanges();
        }
        public void SelectAll()
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>();
                foreach (var c in col)
                {
                    Console.WriteLine($"{c.Guid} | {c.Name} | {c.Capital} | {c.Population} | {c.Area} | {c.WorldPart}");
                }
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectCountries()
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>();
                foreach (var c in col)
                {
                    Console.WriteLine($"{c.Guid} | {c.Name}");
                }
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectCapitals()
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>();
                foreach (var c in col)
                {
                    Console.WriteLine($"{c.Guid} | {c.Capital}");
                }
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectEurope()
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>().Where(u => u.WorldPart == "Europe");
                foreach (var c in col)
                {
                    Console.WriteLine($"{c.Guid} | {c.Name} | {c.Capital} | {c.Population} | {c.Area} | {c.WorldPart}");
                }
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectByArea(int area)
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>().Where(u => u.Area > area);
                foreach (var c in col)
                {
                    Console.WriteLine($"{c.Guid} | {c.Name} | {c.Capital} | {c.Population} | {c.Area} | {c.WorldPart}");
                }
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectCountriesContainsAU()
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>().Where(u => u.Name.ToLower().Contains("a") && u.Name.ToLower().Contains("u"));
                foreach (var c in col)
                {
                    Console.WriteLine($"{c.Guid} | {c.Name} | {c.Capital} | {c.Population} | {c.Area} | {c.WorldPart}");
                }
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectCountriesContainsA()
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>().Where(u => u.Name.ToLower().Contains("a"));
                foreach (var c in col)
                {
                    Console.WriteLine($"{c.Guid} | {c.Name} | {c.Capital} | {c.Population} | {c.Area} | {c.WorldPart}");
                }
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectCountriesBetweenArea(int min, int max)
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>().Where(u => u.Area > min && u.Area < max);
                foreach (var c in col)
                {
                    Console.WriteLine($"{c.Guid} | {c.Name} | {c.Capital} | {c.Population} | {c.Area} | {c.WorldPart}");
                }
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectTop5ByArea()
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>().OrderByDescending(u => u.Area).ToList();
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{col[i].Guid} | {col[i].Name} | {col[i].Capital} | {col[i].Population} | {col[i].Area} | {col[i].WorldPart}");
                    Console.WriteLine(12);
                }
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectTop5ByPopulation()
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>().OrderByDescending(u => u.Population).ToList();
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{col[i].Guid} | {col[i].Name} | {col[i].Capital} | {col[i].Population} | {col[i].Area} | {col[i].WorldPart}");
                }
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectTopByArea()
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>().OrderByDescending(u => u.Area).ToList();
                Console.WriteLine($"{col[0].Guid} | {col[0].Name} | {col[0].Capital} | {col[0].Population} | {col[0].Area} | {col[0].WorldPart}");
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectTopByPopulation()
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>().OrderByDescending(u => u.Population).ToList();
                Console.WriteLine($"{col[0].Guid} | {col[0].Name} | {col[0].Capital} | {col[0].Population} | {col[0].Area} | {col[0].WorldPart}");
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectBottomAreaInAfrica()
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>().Where(u => u.WorldPart == "Africa").OrderBy(u => u.Area).ToList();
                Console.WriteLine($"{col[0].Guid} | {col[0].Name} | {col[0].Capital} | {col[0].Population} | {col[0].Area} | {col[0].WorldPart}");
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
        public void SelectAverageAreaAsia()
        {
            try
            {
                var context = new DataContext(connection);
                var col = context.GetTable<Country>().Where(c => c.WorldPart == "Asia").Average(c => c.Area);
                Console.WriteLine(col);
                context.SubmitChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
