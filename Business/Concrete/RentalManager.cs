using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
      public class RentalManager : IRentalService
      {
            IRentalDal _rentalDal;
            ICarService _carService;
            public RentalManager(IRentalDal rentalDal, ICarService carService)
            {
                  _rentalDal = rentalDal;
                  _carService = carService;
            }
            public IResult Add(RentCarDto rentCarDto)
            {
                  Rental rentalToAdd = new Rental
                  {
                        CarId = rentCarDto.CarId,
                        UserId = rentCarDto.UserId,
                        Amount = rentCarDto.Amount,
                        Day = rentCarDto.Day
                  };
                  _rentalDal.Add(rentalToAdd);
                  var carToUpdate = _carService.GetById(rentCarDto.CarId).Data;
                  carToUpdate.HasRented = true;
                  _carService.Update(carToUpdate);
                  return new SuccessResult("Araç Kiralama Başarıyla Yapıldı");
            }

            public IResult Delete(Rental rental)
            {
                  _rentalDal.Delete(rental);
                  return new SuccessResult();
            }

            public IDataResult<List<Rental>> GetAll()
            {
                  return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            }

            public IDataResult<Rental> GetById(int rentalId)
            {
                  return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
            }

            public IDataResult<List<RentalDetailDto>> GetRentalDetails()
            {
                  return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
            }

            public IDataResult<List<RentalDetailDto>> GetRentalDetailsById(int id)
            {
                  return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CarId == id));
            }

            public IDataResult<List<RentalDetailDto>> GetRentalDetailsByUserId(int userId)
            {
                  return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.UserId == userId));
            }

            public IResult Update(Rental rental)
            {
                  _rentalDal.Update(rental);
                  return new SuccessResult();
            }
      }
}
