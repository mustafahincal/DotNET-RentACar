using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
      public class CarDetailDto : IDto
      {
            public int CarId { get; set; }
            public int BrandId { get; set; }
            public int ColorId { get; set; }
            public int ModelId { get; set; }
            public string ModelName { get; set; }
            public string BrandName { get; set; }
            public string ColorName { get; set; }
            public bool HasRented { get; set; }
            public int DailyPrice { get; set; }
            public string ImagePath { get; set; }
            public string ModelYear { get; set; }
            public string Description { get; set; }
      }
}
