using WorkProject.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkProject.Data
{
    public class CarApiDbContext : DbContext
    {
        private static Random random = new Random();

        public CarApiDbContext(DbContextOptions options) : base(options)
        {
            FillCarDatabase();
        }

        public DbSet<Car> Cars { get; set; }

        public void FillCarDatabase() // filling the database 50 car records
        {
            if (Cars.Count() != 0)
            {
                return;
            }

            List<Car> cars = new List<Car>();

            for (int i = 0; i < 50; i++)
            {
                Car car = new Car
                {
                    Id = Guid.NewGuid(),
                    Model = i.ToString(),
                    AutoMaker = RandomString(30),
                    Price = random.NextDouble()
                };

                cars.Add(car);
            }

            Cars.AddRange(cars);
            this.SaveChanges();
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }

    }
}
