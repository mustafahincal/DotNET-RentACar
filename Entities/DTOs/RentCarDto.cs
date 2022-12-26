using Core.Entities;

namespace Entities.DTOs
{
      public class RentCarDto : IDto
      {
            public int UserId { get; set; }
            public int CarId { get; set; }
            public decimal Amount { get; set; }
            public int Day { get; set; }
      }
}