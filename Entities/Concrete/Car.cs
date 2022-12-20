using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
      public class Car : IEntity
      {
            public int Id { get; set; }
            public int? ModelId { get; set; }
            public int? BrandId { get; set; }
            public int? ColorId { get; set; }
            public int DailyPrice { get; set; }
            public string ModelYear { get; set; }
            public string Description { get; set; }
            public Model? Model { get; set; }
            public Brand? Brand { get; set; }
            public Color? Color { get; set; }
      }
}
