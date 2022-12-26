using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
      public interface IRentalService
      {
            IDataResult<List<Rental>> GetAll();
            IDataResult<Rental> GetById(int rentalId);
            IResult Add(RentCarDto rentCarDto);
            IResult Delete(Rental rental);
            IResult Update(Rental rental);
            IDataResult<List<RentalDetailDto>> GetRentalDetails();
            IDataResult<List<RentalDetailDto>> GetRentalDetailsById(int id);
            IDataResult<List<RentalDetailDto>> GetRentalDetailsByUserId(int userId);

      }
}
