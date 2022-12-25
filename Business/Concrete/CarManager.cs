using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
      public class CarManager : ICarService
      {
            ICarDal _carDal;
            public CarManager(ICarDal carDal)
            {
                  _carDal = carDal;
            }

            [ValidationAspect(typeof(CarValidator))]
            [SecuredOperation("car.add,Admin")]
            [CacheRemoveAspect("IProductService.Get")]
            public IResult Add(Car car)
            {

                  _carDal.Add(car);
                  //return new Result(true,"Ekleme yapıldı")
                  return new SuccessResult("Araba eklendi");

            }
            public IResult Delete(Car car)
            {
                  _carDal.Delete(car);
                  return new SuccessResult("Araba silindi");
            }

            public IResult Update(Car car)
            {
                  _carDal.Update(car);
                  return new SuccessResult("Araba güncellendi");
            }

            public IDataResult<List<Car>> GetAll()
            {
                  //return new DataResult<List<Car>>(_carDal.GetAll(), true, Messages.CarsListed);
                  return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
            }
            public IDataResult<List<Car>> GetCarsByBrandId(int id)
            {
                  return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.CarsListed);
            }

            public IDataResult<List<Car>> GetCarsByColorId(int id)
            {
                  return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
            }
            public IDataResult<List<CarDetailDto>> GetCarDetails()
            {
                  return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
            }

            public IDataResult<Car> GetById(int carId)
            {
                  return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId), "Aradığınız araç bulundu");
            }

            public IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId)
            {
                  return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId), Messages.CarsListed);
            }

            public IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId)
            {
                  return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId), Messages.CarsListed);
            }

            public IDataResult<List<CarDetailDto>> GetCarDetailsById(int id)
            {
                  return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == id), Messages.CarsListed);
            }
      }
}
