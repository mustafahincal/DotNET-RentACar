using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
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
                  optionsBuilder.UseSqlServer(@"Server=localhost;Database=CarRental;User Id=SA;Password=reallyStrongPwd123;MultipleActiveResultSets=True;");

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


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  HashingHelper.CreatePasswordHash("12345678", out byte[] hash, out byte[] salt);
                  User[] users = {
                new User
                {
                    Id = 1,
                    Email = "admin@gmail.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Status=true,
                    PasswordHash=hash,
                    PasswordSalt=salt
                }
            };
                  OperationClaim[] operationClaims = {
                new OperationClaim { Id = 1, Name = "Admin" },
                new OperationClaim { Id = 2, Name = "Editor" },
                new OperationClaim { Id = 3, Name = "Kullanıcı" }
            };
                  UserOperationClaim[] userOperationClaims = { new UserOperationClaim { Id = 1, UserId = 1, OperationClaimId = 1 } };
                  modelBuilder.Entity<User>().HasData(users);
                  modelBuilder.Entity<UserOperationClaim>().HasData(userOperationClaims);
                  modelBuilder.Entity<OperationClaim>().HasData(operationClaims);
                  base.OnModelCreating(modelBuilder);
            }

      }



}
