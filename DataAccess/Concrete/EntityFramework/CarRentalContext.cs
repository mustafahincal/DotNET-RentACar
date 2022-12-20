using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
      public class CarRentalContext : DbContext
      {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                  optionsBuilder.UseSqlServer(@"Server=localhost;Database=CarRental;User Id=SA;Password=MyPassword123#;MultipleActiveResultSets=True;");

            }

            public DbSet<Car> Cars { get; set; }
            public DbSet<Brand> Brands { get; set; }
            public DbSet<Color> Colors { get; set; }
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Rental> Rentals { get; set; }
            public DbSet<CarImage> CarImages { get; set; }

            public DbSet<User> Users { get; set; }
            public DbSet<OperationClaim> OperationClaims { get; set; }
            public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

            public DbSet<CreditCard> CreditCards { get; set; }

            public DbSet<Model> Models { get; set; }
      }
}
