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
            ICarImageService _carImageService;
            public CarManager(ICarDal carDal, ICarImageService carImageService)
            {
                  _carDal = carDal;
                  _carImageService = carImageService;
            }

            [ValidationAspect(typeof(CarValidator))]
            [CacheRemoveAspect("IProductService.Get")]
            public IResult Add(AddCarDto addCarDto)
            {
                  Car carToAdd = new Car
                  {
                        ModelId = addCarDto.ModelId,
                        BrandId = addCarDto.BrandId,
                        ColorId = addCarDto.ColorId,
                        DailyPrice = addCarDto.DailyPrice,
                        Description = addCarDto.Description,
                        ModelYear = addCarDto.ModelYear,
                  };

                  _carDal.Add(carToAdd);

                  CarImage carImageToAdd = new CarImage();
                  _carImageService.Add(addCarDto.file, carImageToAdd, carToAdd.Id);

                  //return new Result(true,"Ekleme yapıldı")
                  return new SuccessResult("Araba eklendi");

            }
            public IResult Delete(DeleteCarDto deleteCarDto)
            {
                  Car carToDelete = _carDal.Get(c => c.Id == deleteCarDto.CarId);
                  _carDal.Delete(carToDelete);
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
