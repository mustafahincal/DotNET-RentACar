using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
      public class Rental : IEntity
      {
            public int Id { get; set; }
            public int CarId { get; set; }
            public int UserId { get; set; }
            public decimal Amount { get; set; }
            public int Day { get; set; }
            public Car Car { get; set; }
            public User User { get; set; }
      }
}
