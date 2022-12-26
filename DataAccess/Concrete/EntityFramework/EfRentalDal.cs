using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
      public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
      {
            public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
            {
                  using (CarRentalContext context = new CarRentalContext())
                  {
                        var result = from r in context.Rentals
                                     join c in context.Cars
                                     on r.CarId equals c.Id
                                     join b in context.Brands
                                     on c.BrandId equals b.Id
                                     join m in context.Models
                                     on c.ModelId equals m.Id
                                     join cl in context.Colors
                                     on c.ColorId equals cl.Id
                                     join u in context.Users
                                     on r.UserId equals u.Id
                                     select new RentalDetailDto
                                     {
                                           CarId = c.Id,
                                           BrandId = b.Id,
                                           BrandName = b.Name,
                                           ColorId = cl.Id,
                                           ColorName = cl.Name,
                                           ModelId = m.Id,
                                           ModelName = m.Name,
                                           RentalId = r.Id,
                                           Amount = r.Amount,
                                           UserId = u.Id,
                                           Day = r.Day,
                                           FirstName = u.FirstName,
                                           LastName = u.LastName

                                     };

                        return filter == null
                      ? result.ToList()
                      : result.Where(filter).ToList();
                  }
            }
      }
}