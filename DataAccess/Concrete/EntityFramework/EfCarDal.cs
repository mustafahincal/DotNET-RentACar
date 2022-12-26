using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
      public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
      {
            public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
            {
                  using (CarRentalContext context = new CarRentalContext())
                  {
                        var result = from cr in context.Cars
                                     join cl in context.Colors
                                     on cr.ColorId equals cl.Id
                                     join b in context.Brands
                                     on cr.BrandId equals b.Id
                                     join mn in context.Models
                                     on cr.ModelId equals mn.Id
                                     select new CarDetailDto
                                     {
                                           CarId = cr.Id,
                                           BrandId = b.Id,
                                           ColorId = cl.Id,
                                           ModelId = mn.Id,
                                           ColorName = cl.Name,
                                           BrandName = b.Name,
                                           ModelName = mn.Name,
                                           DailyPrice = cr.DailyPrice,
                                           Description = cr.Description,
                                           HasRented = cr.HasRented,
                                           ModelYear = cr.ModelYear,
                                           ImagePath = (from m in context.CarImages where m.CarId == cr.Id select m.ImagePath).FirstOrDefault()
                                     };

                        return filter == null
                      ? result.ToList()
                      : result.Where(filter).ToList();
                  }
            }
      }
}
