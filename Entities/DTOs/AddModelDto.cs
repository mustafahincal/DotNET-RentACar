using Core.Entities;

namespace Entities.DTOs
{
      public class AddModelDto : IDto
      {
            public int BrandId { get; set; }
            public string Name { get; set; }
      }
}