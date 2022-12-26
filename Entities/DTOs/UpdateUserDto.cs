using Core.Entities;

namespace Entities.DTOs
{
      public class UpdateUserDto : IDto
      {
            public int UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public int? ResetPassCode { get; set; }
      }
}